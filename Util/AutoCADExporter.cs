using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using DATools.Util;
namespace DATools.Util
{
    public class AutoCADExporter
    {
        Document document = null;

        public AutoCADExporter()
        {

        }

        public ICollection<ElementId>GetViewSet(Document doc)
        {
            this.document = doc;

            ICollection<ElementId> viewsExport = new List<ElementId>();
            List<View3D> all3dviews = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .Cast<View3D>().ToList();

            bool checker = false;

            try
            {
                foreach(View3D vista in all3dviews)
                {
                    if(vista.IsTemplate == checker && vista.Name.Contains("MNSR"))
                    {
                        viewsExport.Add(vista.Id);
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            catch(Exception e)
            {
                TaskDialog.Show("ERROR INTERNO!", "NO SE ENCONTRO NINGUNA VISTA EN EL" +
                    "MODELO CON EL PREFIJO MNSR, FAVOR DE VERIFICAR" + Environment.NewLine
                    + e.Message);
            }

            return viewsExport;
        }
        
    }
}
