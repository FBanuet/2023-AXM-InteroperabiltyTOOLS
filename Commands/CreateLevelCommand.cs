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
using DATools.UIForm;


namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CreateLevelCommand : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            ///
            CreateLevelForm form = new CreateLevelForm(commandData);
            form.ShowDialog();

            //
            string levelsValueString = form.LevelValue.ToString();
            int intLevelsValue = int.Parse(levelsValueString);

            string meterValueString = form.meterValue.ToString();
            double meterDoubleValue = UnitUtils.ConvertFromInternalUnits(double.Parse(meterValueString), DisplayUnitType.DUT_METERS);


            //Grab Levels
            //
            FilteredElementCollector coLevels = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.INVALID).OfClass(typeof(Level));

            double[] elevArray = { };
            List<double> levs = new List<double>();

            //Highest elevation from active Project

            foreach(Level nivel in coLevels)
            {
                double elevaciones = nivel.Elevation;
                levs.Add(elevaciones);
                elevArray = levs.ToArray();
            }
            double highestElev = elevArray.Max();

                

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FloorType));
            FloorType ftype = collector.FirstElement() as FloorType;

            double _Elevation = highestElev;


            using(Transaction trans = new Transaction(doc,"Buttun Name"))
            {
                try
                {
                    trans.Start();
                     ////
                     ///
                    for(int i = 0; i<intLevelsValue; i++)
                    {
                        // floors

                        _Elevation += meterDoubleValue;

                        Level nivel = Level.Create(doc, _Elevation);

                        XYZ first = new XYZ(0, 0, _Elevation);
                        XYZ second = new XYZ(20, 0, _Elevation);
                        XYZ third = new XYZ(20, 15, _Elevation);
                        XYZ fourth = new XYZ(0, 15, _Elevation);


                        CurveArray profile = new CurveArray();
                        profile.Append(Line.CreateBound(first, second));
                        profile.Append(Line.CreateBound(second, third));
                        profile.Append(Line.CreateBound(third, fourth));
                        profile.Append(Line.CreateBound(fourth, first));

                        XYZ normal = XYZ.BasisZ;

                        doc.Create.NewFloor(profile, ftype, nivel, true, normal);
                    }


                    trans.Commit();

                    return Result.Succeeded;
                }
                catch(Exception ex)
                {
                    TaskDialog.Show("Warning!",ex.Message.ToString());
                    trans.RollBack();
                    return Result.Failed;
                }
            }
        }
    }
}
