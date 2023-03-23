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
    public class ViewFiltersSample : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            ElementId idMuros = new ElementId(BuiltInCategory.OST_Walls);
            List<ElementId> categorias = new List<ElementId>();
            categorias.Add(idMuros);

            FilterRule fr1 = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.FIRE_RATING), "120", false);
            FilterRule fr2 = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.FIRE_RATING), "90", false);
            FilterRule fr3 = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.FIRE_RATING), "60", false);

            ElementParameterFilter rf1 = new ElementParameterFilter(fr1);
            ElementParameterFilter rf2 = new ElementParameterFilter(fr2);
            ElementParameterFilter rf3 = new ElementParameterFilter(fr3);

            using(Transaction t = new Transaction(doc,"FILTROS"))
            {
                t.Start();
                ParameterFilterElement PF1 = ParameterFilterElement.Create(doc, "RF-120", categorias, rf1);
                ParameterFilterElement PF2 = ParameterFilterElement.Create(doc, "RF-90", categorias, rf2);
                ParameterFilterElement PF3 = ParameterFilterElement.Create(doc, "RF-60", categorias, rf3);

                View vista = doc.ActiveView;

                vista.AddFilter(PF1.Id);
                vista.AddFilter(PF2.Id);
                vista.AddFilter(PF3.Id);

                Autodesk.Revit.DB.Color rojo = new Autodesk.Revit.DB.Color(255, 0, 0);
                Autodesk.Revit.DB.Color verde = new Autodesk.Revit.DB.Color(255, 128, 64);
                Autodesk.Revit.DB.Color naranja = new Autodesk.Revit.DB.Color(255, 255, 0);

                ElementId idPattern = new FilteredElementCollector(doc).
                    OfClass(typeof(FillPatternElement))
                    .Cast<FillPatternElement>()
                    .First(x => x.GetFillPattern().IsSolidFill).Id;

                OverrideGraphicSettings sobreescritura1 = new OverrideGraphicSettings();
                sobreescritura1.SetCutForegroundPatternId(idPattern);
                sobreescritura1.SetCutForegroundPatternColor(rojo);

                OverrideGraphicSettings sobreescritura2 = new OverrideGraphicSettings();
                sobreescritura1.SetCutForegroundPatternId(idPattern);
                sobreescritura1.SetCutForegroundPatternColor(naranja);

                OverrideGraphicSettings sobreescritura3 = new OverrideGraphicSettings();
                sobreescritura1.SetCutForegroundPatternId(idPattern);
                sobreescritura1.SetCutForegroundPatternColor(verde);

                vista.SetFilterOverrides(PF1.Id, sobreescritura1);
                vista.SetFilterOverrides(PF2.Id, sobreescritura2);
                vista.SetFilterOverrides(PF3.Id, sobreescritura3);



                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}
