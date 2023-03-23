using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.Attributes;
using DATools.UIForm;
using Autodesk.Revit.UI.Selection;

namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PlaceSelectedViewsOnSheet : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            // colección de vistas seleccionadas compresas en ElementId <class>
            ICollection<ElementId> ids = sel.GetElementIds();

            PlaceSelectedViewsOnSheets inter = new PlaceSelectedViewsOnSheets(uidoc);

            inter.ShowDialog();

            if (inter.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string numeroplano = inter.SeleccionarNumero();
                ElementId idPlano = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet))
                    .Cast<ViewSheet>().First(z => z.SheetNumber == numeroplano).Id;

                XYZ center = new XYZ(UnitUtils.ConvertToInternalUnits(524, DisplayUnitType.DUT_MILLIMETERS),
                                     UnitUtils.ConvertToInternalUnits(420, DisplayUnitType.DUT_MILLIMETERS), 0);

                //COMENZANDO LA TRANSACCIÓN

                using(Transaction trans = new Transaction(doc,"COLOCANDO VISTAS EN PLANO"))
                {
                    try
                    {
                        trans.Start();

                        foreach(ElementId eid in ids)
                        {
                            Viewport.Create(doc, idPlano, eid, center);
                        }

                       

                        trans.Commit();

                        View av = doc.GetElement(idPlano) as View;
                        uidoc.ActiveView = av;

                    }
                    catch(Exception e)
                    {
                        TaskDialog.Show("ERROR!", e.ToString());
                        trans.RollBack();
                    }

                }
            }
            else
            {
                TaskDialog.Show("PLACE VIEWS ON SHEET", "OPERACION CANCELADA");
            }
            

            return Result.Succeeded;
        }
    }
}
