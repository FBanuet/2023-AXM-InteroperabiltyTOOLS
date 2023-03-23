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

namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PlaceViewOnSheet : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            View activeview = doc.ActiveView;

            ElementId eleid = activeview.Id;
            AddViewOnSheet inter = new AddViewOnSheet(uidoc);

            inter.ShowDialog();

            if (inter.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string numeroplano = inter.SeleccionarNumero();
                ElementId idPlano = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet))
                    .Cast<ViewSheet>().First(z => z.SheetNumber == numeroplano).Id;

                XYZ center = new XYZ(UnitUtils.ConvertToInternalUnits(524, DisplayUnitType.DUT_MILLIMETERS),
                                     UnitUtils.ConvertToInternalUnits(420, DisplayUnitType.DUT_MILLIMETERS), 0);

                using (Transaction trans = new Transaction(doc, "DAT COLOCAR VISTA"))
                {
                    try
                    {
                        trans.Start();

                        Viewport.Create(doc, idPlano, eleid, center);

                        trans.Commit();
                        View av = doc.GetElement(idPlano) as View;
                        uidoc.ActiveView = av;
                    }
                    catch (Exception e)
                    {
                        TaskDialog.Show("ERROR!", e.ToString());
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
