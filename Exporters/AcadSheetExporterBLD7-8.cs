﻿using System.Collections.Generic;
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
using DATools.WPFUIS;

namespace DATools.Exporters
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class AcadSheetExporterBLD7_8 : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            OpenOptions opt = new OpenOptions();
            DWGExportOptions dwg = new DWGExportOptions();

            Guid GlobalProjectGuid = new Guid("9352eecd-7567-4ebb-87a6-aacf7a964199");
            Guid BLD78 = new Guid("da65c3c2-72ee-4c67-836a-0109b310ea82");
            Dictionary<string, Guid> PMGuids = new Dictionary<string, Guid>();

            PMGuids.Add("BLD7-8", BLD78);
            DefaultOpenFromCloudCallback defaultOpen = new DefaultOpenFromCloudCallback();

            foreach(KeyValuePair<string, Guid> PandMguid in PMGuids)
            {
                ModelPath mpath = ModelPathUtils.ConvertCloudGUIDsToCloudPath(GlobalProjectGuid, PandMguid.Value);

                Document doc360 = app.OpenDocumentFile(mpath, opt, defaultOpen);

                SheetExporterList exporter = new SheetExporterList(app, doc360, dwg);

                exporter.ShowDialog();
            }



            return Result.Succeeded;
        }
        public OpenConflictResult OnOpenConflict(OpenConflictScenario scenario)
        {
            throw new System.NotImplementedException();
        }
    }

}
