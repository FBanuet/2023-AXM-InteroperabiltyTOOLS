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
    public class Nwc3DViewExporter
    {
        Document document = null;
        public Nwc3DViewExporter()
        {
            
        }

        public List<View3D> GetBIMviews(Document doc)
        {
            this.document = doc;

            List<View3D> vistasNWC = new List<View3D>();
            List<View3D> all3dviews = new FilteredElementCollector(doc).OfClass(typeof(View3D)).Cast<View3D>().ToList();

            bool checker = false;

            try
            {
                foreach (View3D vista in all3dviews)
                {
                    if (vista.IsTemplate == checker && vista.Name.Contains("MNSR"))
                    {
                        vistasNWC.Add(vista);
                    }

                }



            }
            catch (Exception e)
            {
                TaskDialog.Show("ERROR INTERNO!", "NO SE ENCONTRO EN EL MODELO NINGUNA VISTA CON EL PREFIJO MNSR!,FAVOR DE VERIFICAR" + Environment.NewLine + e.Message);
            }

            return vistasNWC;

        }


        
    }
}
