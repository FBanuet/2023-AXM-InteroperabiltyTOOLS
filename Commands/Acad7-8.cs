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
using System;

namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Acad7_8 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            OpenOptions opt = new OpenOptions();

            DWGExportOptions dwgopt = new DWGExportOptions();

            Guid GlobalProjectGuid = new Guid("9352eecd-7567-4ebb-87a6-aacf7a964199");
            Guid BLD78 = new Guid("da65c3c2-72ee-4c67-836a-0109b310ea82");
            Dictionary<string, Guid> PMGuids = new Dictionary<string, Guid>();

            PMGuids.Add("BLD7-8", BLD78);

            DefaultOpenFromCloudCallback defaultOpen = new DefaultOpenFromCloudCallback();

            //string viewNames = "";


            foreach (KeyValuePair<string, Guid> PandMguid in PMGuids)
            {
                ModelPath mpath = ModelPathUtils.ConvertCloudGUIDsToCloudPath(GlobalProjectGuid, PandMguid.Value);

                Document doc360 = app.OpenDocumentFile(mpath, opt, defaultOpen);

                try
                {
                    AutoCADExporter acadExporter = new AutoCADExporter();
                    ICollection<ElementId> ViewsExportIds = acadExporter.GetViewSet(doc360);
                    dwgopt.SharedCoords = false;
                    dwgopt.ExportingAreas = false;
                    dwgopt.TargetUnit = ExportUnit.Millimeter;
                    dwgopt.FileVersion = ACADVersion.R2013;

                    doc360.Export(@"G:\Unidades compartidas\MANSUR\SURMAN PEDREGAL\01_RESIDENCIA MANSUR\01_AXM\01_MNSR_Project\02_CAD\WSP", "MNSR", ViewsExportIds, dwgopt);

                    doc360.Close(false);
                }


                catch (Exception e)
                {
                    TaskDialog.Show("ERROR", e.Message);
                }
            }

            return Result.Succeeded;
        }
        public OpenConflictResult OnOpenConflict(OpenConflictScenario scenario)
        {
            throw new System.NotImplementedException();
        }


    }
}
