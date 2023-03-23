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
using Autodesk.Revit.Attributes;
using DATools.Commands;
using System.Collections;

namespace DATools.UIForm
{
    public partial class TagWallLayersForm : System.Windows.Forms.Form
    {
        // miembros privados

        private UIDocument uidoc = null;

        private ElementId textTypeId = null;

        private LengthUnitType unitType = LengthUnitType.milimeters;

        private int decimals = 1;

        public TagWallLayersForm(UIDocument uIDocument)
        {
            
            InitializeComponent();


            uidoc = uIDocument;
        }

       
        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void GBOX_Enter(object sender, EventArgs e)
        {

        }

        private void TagWallLayersForm_Load(object sender, EventArgs e)
        {
            PopulateTextNoteTypeList();
            PopulateUnittypeList();
            PopulateDecimalPlaces();

        }

        private void CMBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            textTypeId = ((KeyValuePair<string, ElementId>)CMBOX.SelectedItem).Value;
        }
        private void CmbUnitsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitType = (LengthUnitType)CmbUnitsType.SelectedValue;
        }

        private void CmbUnitPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimals = (int)CmbUnitPlaces.SelectedValue;
        }

        public TagWallLayersCMNDDATA GetInfo()
        {
            var information = new TagWallLayersCMNDDATA()
            {
                Function = CH1.Checked,
                Name = CHKNAME.Checked,
                Thickness = CHKTHIK.Checked,
                Keynote = CHKeynote.Checked,
                TextTypeId = textTypeId,
                UnitType = unitType,
                Decimals = decimals
            };

            return information;
        }
        
        private void PopulateTextNoteTypeList()
        {
            Document doc = uidoc.Document;
            FilteredElementCollector allTextElementTypes = new FilteredElementCollector(doc).OfClass(typeof(TextElementType));

            var list = new List<KeyValuePair<string, ElementId>>();

            foreach(var item in allTextElementTypes)
            {
                list.Add(new KeyValuePair<string, ElementId>(item.Name, item.Id));

            }

            CMBOX.DataSource = null;
            CMBOX.DataSource = new BindingSource(list,null);
            CMBOX.DisplayMember = "Key";
            CMBOX.ValueMember = "Value";
        }


        private void PopulateUnittypeList()
        {
            CmbUnitsType.DataSource = Enum.GetValues(typeof(LengthUnitType));
        }
        
        private void PopulateDecimalPlaces()
        {
            var values = new List<int>() { 0, 1, 2, 3 };

            var source = new BindingSource
            {
                DataSource = values,
            };
            CmbUnitPlaces.DataSource = source.DataSource;
            CmbUnitPlaces.SelectedItem = values[2];
        }

        private void CHKNAME_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
