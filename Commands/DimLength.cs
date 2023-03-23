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
    public class DimLength : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc
                 = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;


            //COLLECCIONAR LOS TIPOS DE COTAS QUE NO SEAN DIAGONAL PARA LA REVISIÓN DE CALIDAD
            var cotas = new FilteredElementCollector(doc).OfClass(typeof(Dimension)).Cast<Dimension>()
                .Where(x => x.DimensionType.Name != "Diagonal" && x.DimensionType.StyleType == DimensionStyleType.Linear);




            //texto de advertencia
            using(Transaction t = new Transaction(doc,"transaccion cotas"))
            {
                t.Start();
                
                foreach(var cota in cotas)
                {
                    int numberSegments = cota.NumberOfSegments;
                    if(numberSegments == 0)
                        cota.Above = "SE NECESITA CAMBIAR ESTE ESTILO DE COTAS";
                    else
                    {
                        foreach(var num in Enumerable.Range(0,numberSegments))
                        {
                            var segmentos = cota.Segments;
                            segmentos.get_Item(num).Above = "SE NECESITA CAMBIAR ESTE ESTILO DE COTAS";
                        }
                    }

                }

                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}
