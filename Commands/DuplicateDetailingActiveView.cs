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


namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class DuplicateDetailingActiveView : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document doc = uIDocument.Document;
            View Activeview = doc.ActiveView;
            ElementId ops = null;


            TaskDialog maindialog = new TaskDialog("DATarchitets.NET - DUPLICATE VIEWS");
            maindialog.MainInstruction = "DATarchitets.NET - DUPLICATE VIEWS";
            maindialog.MainContent = "ESTE COMANDO DUPLICA A DETALLE LA VISTA ACTIVA EN EL DOCUMENTO , DAR CLICK EN OK , PARA CONTINUAR";
            maindialog.AllowCancellation = true;
            maindialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
            TaskDialogResult RESULT = maindialog.Show();

            using(Transaction trans = new Transaction(doc,"Custom DAT Duplicate"))
            {
                trans.Start();

                if(RESULT == TaskDialogResult.Ok)
                {
                    ElementId newView = Activeview.Duplicate(ViewDuplicateOption.WithDetailing);

                    View Nueva = doc.GetElement(newView) as View;

                    ops = newView;

                    Nueva.Name = Nueva.Name + " " + "PROTOWORK";

                }
                else
                {
                    TaskDialog.Show("DATarchitets.NET - DUPLICATE VIEWS", "OPERACIÓN CANCELADA!");
                }
                


                trans.Commit();

            }

            View nn = doc.GetElement(ops) as View;
            uIDocument.ActiveView = nn;
            
            
            
            return Result.Succeeded;
        }
    }
}
