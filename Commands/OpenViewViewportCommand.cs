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
    public class OpenViewViewportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            string data = "";
            List<Element> elementos = new FilteredElementCollector(doc).OfClass(typeof(View)).ToList();
            Element el = doc.GetElement(uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element));
            Viewport vp = el as Viewport;
            Parameter par = vp.get_Parameter(BuiltInParameter.VIEW_NAME);

            string valor = par.AsString();
            List<View> vistas = new List<View>();

            foreach(Element elem in elementos)
            {
                View view = elem as View;
                if (view.Name == valor)
                    vistas.Add(view);
            }
            foreach(View vv in vistas)
            {
                data += vv.Name + "  :  " + vv.Id;
                uidoc.ActiveView = vv;
            }
            TaskDialog.Show("INFO DATARCHITECTS VIEW", data);


            return Result.Succeeded;
        }
    }
}
