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

namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class _5_6_NWC : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            OpenOptions opt = new OpenOptions();
            NavisworksExportOptions nweOptions = new NavisworksExportOptions();

            Guid GlobalProjectGuid = new Guid("9352eecd-7567-4ebb-87a6-aacf7a964199");

            Guid BLD56 = new Guid("05a6b075-4125-4c87-b84d-a5a74a8b91b9");
            Guid BLD78 = new Guid("da65c3c2-72ee-4c67-836a-0109b310ea82");
            Guid BLD34 = new Guid("bc9e34ab-fbfc-4948-8264-2f25a2058be8");
            Guid BLD1 = new Guid("40401acd-033f-43e0-a8c2-e0848d1b5ca2");
            Guid BLD2 = new Guid("f67ca417-165b-42f9-a30e-a8203e8483c4");
            Guid BLD9 = new Guid("cf0fdfec-10c7-4ec4-8868-854acab2f67e");
            Guid BLDLS = new Guid("81cd53c2-4b79-4477-a08e-e0c0a19d7766");
            Guid BLDRD = new Guid("fb09409b-fc72-41dc-81c6-de139948b463");

            Dictionary<string, Guid> PMGuids = new Dictionary<string, Guid>();

            PMGuids.Add("BLD5-6", BLD56);
            //PMGuids.Add("BLD7-8", BLD78);
            //PMGuids.Add("BLD3-4", BLD34);
            //PMGuids.Add("BLD1", BLD1);
            //PMGuids.Add("BLD2", BLD2);
            //PMGuids.Add("BLD9", BLD9);
            //PMGuids.Add("BLDLS", BLDLS);
            //PMGuids.Add("BLDRD", BLDRD);


            DefaultOpenFromCloudCallback defaultOpen = new DefaultOpenFromCloudCallback();

            string viewNames = "";

            foreach (KeyValuePair<string, Guid> PandMguid in PMGuids)
            {
                ModelPath mpath = ModelPathUtils.ConvertCloudGUIDsToCloudPath(GlobalProjectGuid, PandMguid.Value);

                Document doc360 = app.OpenDocumentFile(mpath, opt, defaultOpen);


                try
                {
                    //NEST A FOREACH LOOP THROUG EVERY SET OF VIEWS
                    Nwc3DViewExporter Exporter = new Nwc3DViewExporter();

                    List<View3D> vistasExport = Exporter.GetBIMviews(doc360);

                    foreach (View3D vistaMNSR in vistasExport)
                    {
                        string clave = vistaMNSR.Name;
                        viewNames += clave + Environment.NewLine;
                        nweOptions.ExportScope = NavisworksExportScope.View;
                        nweOptions.ViewId = vistaMNSR.Id;
                        nweOptions.ExportRoomGeometry = false;
                        nweOptions.ExportLinks = true;
                        doc360.Export(@"G:\Unidades compartidas\MANSUR\SURMAN PEDREGAL\01_RESIDENCIA MANSUR\01_AXM\01_MNSR_Project\01_BIM\09_NAVIS\COORDINATION\NWC\TESTING PLUGIN", clave + ".nwc", nweOptions);
                    }


                    doc360.Close(false);

                }
                catch (Exception e)
                {
                    TaskDialog.Show("OPERACIÓN INTERRUMPIDA CON ERRORES", "VERIFICAR NOMENCLATURA DE VISTAS 3D A EXPORTAR COMO NWC" + e.Message);
                }

            }
            TaskDialog.Show("NWC Exporter", "SE HAN EXPORTADO CON ÈXITO LOS SIGUIENTES NWC : " + " - " + viewNames);


            return Result.Succeeded;
        }


        public static string GetNameSpaceCmmnd()
        {
            return typeof(NavisWorksExporterCommand).Namespace + "." + nameof(NavisWorksExporterCommand);
        }
        public OpenConflictResult OnOpenConflict(OpenConflictScenario scenario)
        {
            throw new NotImplementedException();
        }

    }
}
