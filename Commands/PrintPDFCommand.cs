using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.Attributes;
using DATools.UIForm;


namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PrintPDFCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                /// variables globales
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                Document doc = uidoc.Document;
                Selection sel = uidoc.Selection;
                ICollection<ElementId> ids = sel.GetElementIds();

                // INSTANCIAMOS EL FORMULARIO PARA INPUTS DE USUARIO
                PrintParametersForm ppf = new PrintParametersForm(uidoc);
                ppf.ShowDialog();

                if(ppf.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    string pSetName = ppf.SeleccionarPSettings();
                    string Impre = ppf.SeleccionarImpresora();
                    string viewsetN = ppf.Getfilepath();

                    ElementId psid = new FilteredElementCollector(doc).OfClass(typeof(PrintSetting))
                        .First(x => x.Name == pSetName).Id;

                    ViewSet vset = ViewSetAddViews(ids, doc, viewsetN, Impre);

                    using(Transaction trans = new Transaction(doc,"PRINTING"))
                    {
                        trans.Start();

                        doc.Print(vset, true);

                        trans.Commit();
                    }

                    TaskDialog.Show("AXM CPrinter", "OPERACIÓN EXITOSA HA FINALIZADO!");
                }

                return Result.Succeeded;

            }
            catch(Exception e)
            {
                TaskDialog.Show("WARNING ERROR!", e.Message);
                return Result.Failed;

            }
            
        }

        private ViewSet ViewSetAddViews(ICollection<ElementId> viewids, Document doc ,string viewsetname , string Printdriver)
        {
            ViewSet vset = new ViewSet();

           foreach(ElementId eleid in viewids)
            {
                Element el = doc.GetElement(eleid);
                View view = el as View;

                vset.Insert(view);

            }

            PrintManager pm = doc.PrintManager;
            pm.SelectNewPrintDriver(Printdriver);

            pm.PrintRange = PrintRange.Select;

            ViewSheetSetting vss = pm.ViewSheetSetting;
            vss.CurrentViewSheetSet.Views = vset;

            using(Transaction trans = new Transaction(doc,"AXM CUSTOM PRINT"))
            {
                trans.Start();

                string SetName = "'" + viewsetname + "SHHETS";

                try
                {
                    vss.SaveAs(SetName);

                }
                catch(Autodesk.Revit.Exceptions.InvalidOperationException)
                {
                    TaskDialog.Show("WARNING!", SetName + "YA ESTA EN USO , FAVOR DE UTILIZAR OTRO NOMBRE");
                    trans.RollBack();
                }

                trans.Commit();
            }

            return vset;

        }
    }
}
