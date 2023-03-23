using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;
using DATools.Utility;

namespace DATools.UIForm
{
    public partial class FormByTypeSelector : System.Windows.Forms.Form
    {
        //Generamos una variable de objeto tipo Document sin instancear el objeto
        Document doc;
        public FormByTypeSelector(Document _doc)
        {
            InitializeComponent();
            doc = _doc;

            cmboxCatType.Items.Add("Model");
            cmboxCatType.Items.Add("Annotation");
            cmboxCatType.Items.Add("Analytical");
            cmboxCatType.SelectedIndex = 0;

            lblNumber.Text = new UIDocument(doc).Selection.GetElementIds().Count.ToString();
        }

        
        // SE REALIZAN LOS EVENTOS DE CADA COMPONENTE DE LA INTERFAZ Y SUS METODOS PRIVADOS O DE UTILIDAD(REVIT API)
        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTypes();
        }

        private void SetTypes()
        {
            if (lstCategory.SelectedItem == null)
                lstCategory.DataSource = null;

            lstTypes.DataSource = GetTypes((NameIDObject)lstCategory.SelectedItem);
            lstTypes.DisplayMember = "Name";
            lstTypes.ValueMember = "IdValue";
        }

        private List<NameIDObject> GetTypes(NameIDObject nameIdCategory)
        {
            List<NameIDObject> types;
            if (nameIdCategory.IdValue == (int)BuiltInCategory.OST_Lines)
            {
                types = doc.Settings.Categories
                    .get_Item(BuiltInCategory.OST_Lines)
                    .SubCategories.Cast<Category>()
                    .OrderBy(z => z.Name)
                    .Select(z => new NameIDObject(z.Name, z.Id.IntegerValue)).ToList();

                types = types.Where(z => DoLinesExists(new ElementId(z.IdValue)))
                    .OrderBy(z => z.Name).ToList();


            }
            else
            {
                List<ElementType> elementoTypos = new FilteredElementCollector(doc)
                    .WhereElementIsElementType()
                    .OfCategoryId(new ElementId(nameIdCategory.IdValue))
                    .Cast<ElementType>()
                    .ToList();


                if(nameIdCategory.IdValue == -2000260)
                {
                    elementoTypos = new FilteredElementCollector(doc)
                        .OfClass(typeof(DimensionType))
                        .Cast<ElementType>()
                        .ToList();
                }
                if(!elementoTypos.Any())
                {
                    return new List<NameIDObject>();
                }

                if (elementoTypos.First() is FamilySymbol)
                {
                    types = elementoTypos.Cast<FamilySymbol>()
                        .Select(x => new NameIDObject(x.FamilyName + ":" + x.Name, x.Id.IntegerValue))
                        .ToList();
                }
                else if (elementoTypos.First() is StairsType)
                {
                    types = elementoTypos.Cast<StairsType>()
                        .Select(x => new NameIDObject(x.ConstructionMethod + ":" + x.Name, x.Id.IntegerValue))
                        .ToList();

                }
                else if (elementoTypos.First() is ConduitType)
                {
                    types = elementoTypos.Cast<ConduitType>()
                        .Where(x => x.IsWithFitting)
                        .Select(x => new NameIDObject("Conduits con Piezas Accesorios" + x.Name, x.Id.IntegerValue))
                        .ToList();
                    types.AddRange(elementoTypos.Cast<ConduitType>()
                        .Where(x => !x.IsWithFitting)
                        .Select(x => new NameIDObject("Conduits sin Piezas Accesorios:" + x.Name, x.Id.IntegerValue))
                        .ToList());

                }
                else if (elementoTypos.First() is CableTrayType)
                {
                    types = elementoTypos.Cast<CableTrayType>()
                        .Where(x => x.IsWithFitting)
                        .Select(x => new NameIDObject("Cable Trays con Fittings: " + x.Name, x.Id.IntegerValue))
                        .ToList();
                    types.AddRange(elementoTypos.Cast<CableTrayType>()
                        .Where(x => !x.IsWithFitting)
                        .Select(x => new NameIDObject("Cable Trays sin Fittings: " + x.Name, x.Id.IntegerValue))
                        .ToList());

                }
                else
                {
                    types = elementoTypos
                        .Select(x => new NameIDObject(x.Name, x.Id.IntegerValue))
                        .ToList();
                }


                types = types.Where(x => DoInstancesExist(new ElementId(x.IdValue)))
                    .OrderBy(x => x.Name).ToList();
                    
            }

            if (txtFilter.Text == "")
                return types;
            else
                return types.Where(x => x.Name.Contains(txtFilter.Text)).ToList();


        }

        private bool DoLinesExists(ElementId id)
        {
            if (new FilteredElementCollector(doc)
                .OfClass(typeof(CurveElement))
                .Cast<CurveElement>()
                .Where(z => ((GraphicsStyle)z.LineStyle).GraphicsStyleCategory.Id == id).Any())
                return true;
            return false;
        }

        private bool DoInstancesExist(ElementId id)
        {
            if (doc.GetElement(id) is FamilySymbol && new FilteredElementCollector(doc)
                .WhereElementIsNotElementType().
                WherePasses(new FamilyInstanceFilter(doc, id))
                .Any())
                return true;
            if(new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .Where(x => x.GetTypeId() == id)
                .Any())
                return true;
            return false;
        }

        
        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UIDocument uidoc = new UIDocument(doc);
            List<ElementId> selected = uidoc.Selection.GetElementIds().ToList();
            List<Element> elements;

            FilteredElementCollector collector;
            if (chkCurrentView.Checked)
                collector = new FilteredElementCollector(doc, uidoc.ActiveView.Id);
            else
                collector = new FilteredElementCollector(doc);

            foreach (NameIDObject nameId in lstTypes.SelectedItems)
            {
                if (((NameIDObject)lstCategory.SelectedItem).Name == "Lines")
                {
                    elements = collector
                        .OfClass(typeof(CurveElement))
                        .Cast<CurveElement>()
                        .Where(x => ((GraphicsStyle)x.LineStyle).GraphicsStyleCategory.Id.IntegerValue == nameId.IdValue)
                        .Cast<Element>()
                        .ToList();
                }
                else
                {
                    ElementId typeId = new ElementId(nameId.IdValue);
                    elements = collector
                        .WhereElementIsNotElementType()
                        .Where(x => x.GetTypeId() == typeId)
                        .ToList();

                }
                selected.AddRange(elements.Select(x => x.Id).ToList());
            }

            uidoc.Selection.SetElementIds(selected);
            lblNumber.Text = uidoc.Selection.GetElementIds().Count.ToString();
        }

        private void clearSel_Click(object sender, EventArgs e)
        {
            UIDocument uidoc = new UIDocument(doc);
            uidoc.Selection.SetElementIds(new List<ElementId> { });
            lblNumber.Text = "0";

        }

        private void cmboxCatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTypes.DataSource = null;

            CategoryType ctype = CategoryType.Model;

            if (cmboxCatType.SelectedItem.ToString() == "Annotation")
                ctype = CategoryType.Annotation;
            else if (cmboxCatType.SelectedItem.ToString() == "Analytical")
                ctype = CategoryType.AnalyticalModel;

            List<NameIDObject> cats = doc.Settings.Categories.Cast<Category>()
                .Where(x => x.IsVisibleInUI)
                .Where(x => x.CategoryType == ctype)
                .Where(x => new FilteredElementCollector(doc).OfCategoryId(x.Id).Any())
                .Select(q => new NameIDObject(q.Name, q.Id.IntegerValue))
                .OrderBy(x => x.Name)
                .Where(x => GetTypes(x).Any())
                .ToList();

            lstCategory.DataSource = cats;
            lstCategory.DisplayMember = "Name";
            lstCategory.ValueMember = "IdValue";
               

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            SetTypes();

        }

        private void bntAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lstTypes.Items.Count; i++)
            {
                lstTypes.SetSelected(i, true);
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTypes.Items.Count; i++)
            {
                lstTypes.SetSelected(i, false);
            }

        }

        private void FormByTypeSelector_Load(object sender, EventArgs e)
        {


        }


    }
}
