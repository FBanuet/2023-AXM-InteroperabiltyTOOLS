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

namespace DATools
{


    public class Main : IExternalApplication
    {


        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "AXM MNSR";

            string panelName = "Annotation";
            string panel2Name = " Views";
            string panel3Name = " Sheets";
            string panel4name = "Navisworks";
            string panel5Name = "Selección";
            string panel6Name = "Visibility";
            string panel7Name = "2022";
            string panel8Name = "SheetExporters";
            application.CreateRibbonTab(tabName);

            RibbonPanel rpanel = application.CreateRibbonPanel(tabName, panelName);
            RibbonPanel rpanel2 = application.CreateRibbonPanel(tabName, panel2Name);
            RibbonPanel rpanel3 = application.CreateRibbonPanel(tabName, panel3Name);
            RibbonPanel rpanel4 = application.CreateRibbonPanel(tabName, panel4name);
            RibbonPanel rpanel5 = application.CreateRibbonPanel(tabName, panel5Name);
            RibbonPanel rpanel6 = application.CreateRibbonPanel(tabName, panel6Name);
            RibbonPanel rpanel7 = application.CreateRibbonPanel(tabName, panel7Name);
            RibbonPanel rpanel8 = application.CreateRibbonPanel(tabName, panel8Name);

            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyPath = assembly.Location;


            PushButton tagWallLayerbtn = rpanel.AddItem(new PushButtonData("TagWallLayers", "Tag wall Layers", assemblyPath, "DATools.Commands.TagWallLayersCommand")) as PushButton;
            tagWallLayerbtn.ToolTip = "TAG ALL THE LAYERS INSIDE A WALL WITHIN THE INFO INSIDE IT";
            tagWallLayerbtn.LargeImage = GetResourceImage(assembly, "DATools.Resources.show32.png");
            tagWallLayerbtn.Image = GetResourceImage(assembly, "DATools.Resources.show16.png");


            PushButton OpenAciteViewportView = rpanel2.AddItem(new PushButtonData("ActivarViewport", "Open Viewport View", assemblyPath, "DATools.Commands.OpenViewViewportCommand")) as PushButton;
            OpenAciteViewportView.ToolTip = "Click in the Desire Viewport an activate/Open the View inside it";
            OpenAciteViewportView.LargeImage = GetResourceImage(assembly, "DATools.Resources.VIEW32.png");
            OpenAciteViewportView.Image = GetResourceImage(assembly, "DATools.Resources.VIEW16.png");

            PushButton DuplicateDetailActiveView = rpanel2.AddItem(new PushButtonData("Duplicar Vista Activa", "Duplicar Vista Act", assemblyPath, "DATools.Commands.DuplicateDetailingActiveView")) as PushButton;
            DuplicateDetailActiveView.ToolTip = "DUPLIQUE LA VISTA ACTUAL CON DETALLE";
            DuplicateDetailActiveView.LargeImage = GetResourceImage(assembly, "DATools.Resources.SHEET32.png");
            DuplicateDetailActiveView.Image = GetResourceImage(assembly, "DATools.Resources.SHEET16.png");

            PushButton PlaceViewOnSheet = rpanel2.AddItem(new PushButtonData("PlaceViewOnSheet", "Colocar Vista Plano", assemblyPath, "DATools.Commands.PlaceViewOnSheet")) as PushButton;
            PlaceViewOnSheet.ToolTip = "COLOQUE LA VISTA ACTUAL EN EL PLANO DESEADO";
            PlaceViewOnSheet.LargeImage = GetResourceImage(assembly, "DATools.Resources.LAYOUT32.png");
            PlaceViewOnSheet.Image = GetResourceImage(assembly, "DATools.Resources.LAYOUT16.png");

            PushButton PlaceSelectedViewsOnSheet = rpanel2.AddItem(new PushButtonData("PlaceSelectedViewsOnSheet", "ColocarVistas", assemblyPath, "DATools.Commands.PlaceSelectedViewsOnSheet")) as PushButton;
            PlaceSelectedViewsOnSheet.ToolTip = "COLOQUE lAS VISTAS SELECCIONADAS PREVIAMENTE EN EL PROJECT BROWSER EN EL PLANO DESEADO";
            PlaceSelectedViewsOnSheet.LargeImage = GetResourceImage(assembly, "DATools.Resources.Layouts32.png");
            PlaceSelectedViewsOnSheet.Image = GetResourceImage(assembly, "DATools.Resources.Layouts16.png");

            PushButton DuplicateSelectedViews = rpanel2.AddItem(new PushButtonData("DuplicateSelectedViews", "DuplicateSelectedViews", assemblyPath, "DATools.Commands.DuplicateSelectedViews")) as PushButton;
            DuplicateSelectedViews.ToolTip = "DUPLICA A DETALLE LAS VISTAS SELECCIONADAS EN EL PROJECT BROWSER";
            DuplicateSelectedViews.LargeImage = GetResourceImage(assembly, "DATools.Resources.Duplicate32.png");
            DuplicateSelectedViews.Image = GetResourceImage(assembly, "DATools.Resources.Duplicate16.png");



            PushButton CustomPrint = rpanel3.AddItem(new PushButtonData("PrintSelectedSheets", "CustomPrint ", assemblyPath, "DATools.Commands.PrintPDFCommand")) as PushButton;
            CustomPrint.ToolTip = "EXPORTA A PDF LOS SHEETS SELECCIONADOS PREVIAMENTE EN EL PROJECT BROWSER";
            CustomPrint.LargeImage = GetResourceImage(assembly, "DATools.Resources.plano32.png");
            CustomPrint.Image = GetResourceImage(assembly, "DATools.Resources.plano16.png");

            PushButton RenamePDF = rpanel3.AddItem(new PushButtonData("RenamePDF", "RenombrarPDF ", assemblyPath, "DATools.Commands.RenamePDFCommand")) as PushButton;
            RenamePDF.ToolTip = "RENOMBRA LOS ARCHIVOS PDF DADO EL DIRECTORIO DIRECTO ABSOLUTO";
            RenamePDF.LargeImage = GetResourceImage(assembly, "DATools.Resources.pdf32.png");
            RenamePDF.Image = GetResourceImage(assembly, "DATools.Resources.pdf16.png");


            PushButton SetSheetIssueDate  = rpanel3.AddItem(new PushButtonData("SetIssueDate", "IssueDate", assemblyPath, "DATools.Commands.SheetListCommand")) as PushButton;
            SetSheetIssueDate.ToolTip = "Genere e incorpore la fecha actual ala revisión de los planos seleccionados.";
            SetSheetIssueDate.LargeImage = GetResourceImage(assembly, "DATools.Resources.calendar_32.png");
            SetSheetIssueDate.Image = GetResourceImage(assembly, "DATools.Resources.calendar_16.png");

            PushButton Rebar3DViews = rpanel6.AddItem(new PushButtonData("SetRebarSolidInView", "3DViewRebarManager", assemblyPath, "DATools.Commands.SolidCommand")) as PushButton;
            Rebar3DViews.ToolTip = "Manipule y gestione los estilos de visibilidad de los elementos tipo REBAR en las vistas 3D  a su dispocisión";
            Rebar3DViews.LargeImage = GetResourceImage(assembly, "DATools.Resources.rebar32.png");
            Rebar3DViews.Image = GetResourceImage(assembly, "DATools.Resources.rebar16.png");


            PushButton TypeSelector = rpanel5.AddItem(new PushButtonData("Selector PRO AXM", "AXM PRO Selector", assemblyPath, "DATools.Commands.SelectByTypeCommand")) as PushButton;
            TypeSelector.ToolTip = "GENERE CONJUNTOS DE SELECCIÓN Y FILTROS POR TIPO O CATEGORIA Y TIPO DE ELEMENTO YA SEA MODELO, 2D O SOLO DATUM CON ESTA HERRAMIENTA";
            TypeSelector.LargeImage = GetResourceImage(assembly, "DATools.Resources.seleccion32.png");
            TypeSelector.Image = GetResourceImage(assembly, "DATools.Resources.seleccion16.png");

            #region EXPORTADOR DE PLANOS POR MODELO

            PushButton Suites56Expo = rpanel8.AddItem(new PushButtonData("BLDS5-6 Sheet Exporter", "Sheet Exporter 5-6", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD5_6")) as PushButton;
            Suites56Expo.ToolTip = "EXPORTAR PLANOS DE JUNIOR SUITES 5-6";
            Suites56Expo.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");

            Suites56Expo.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton Suites78Expo = rpanel8.AddItem(new PushButtonData("BLDS7-8 Sheet Exporter", "Sheet Exporter 7-8", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD7_8")) as PushButton;
            Suites78Expo.ToolTip = "EXPORTAR PLANOS DE JUNIOR SUITES 7-8";
            Suites78Expo.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            Suites78Expo.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton Suites34Expo = rpanel8.AddItem(new PushButtonData("BLDS3-4 Sheet Exporter", "Sheet Exporter 3-4", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD3_4")) as PushButton;
            Suites34Expo.ToolTip = "EXPORTAR PLANOS DE MODELOS 3-4";
            Suites34Expo.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            Suites34Expo.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton BLD1 = rpanel8.AddItem(new PushButtonData("BLDS 1 Sheet Exporter", "Sheet Exporter bld 1", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD1")) as PushButton;
            BLD1.ToolTip = "EXPORTAR PLANOS DE MODELOS 1";
            BLD1.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            BLD1.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton BLD2 = rpanel8.AddItem(new PushButtonData("BLDS 2 Sheet Exporter", "Sheet Exporter bld 2", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD2")) as PushButton;
            BLD2.ToolTip = "EXPORTAR PLANOS DE MODELOS 2";
            BLD2.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            BLD2.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton BLD9 = rpanel8.AddItem(new PushButtonData("BLDS 9 Sheet Exporter", "Sheet Exporter bld 9", assemblyPath, "DATools.Exporters.AcadSheetExporterBLD9")) as PushButton;
            BLD9.ToolTip = "EXPORTAR PLANOS DE MODELOS 9";
            BLD9.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            BLD9.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            PushButton BLDRD = rpanel8.AddItem(new PushButtonData("ROAD Sheet Exporter", "Sheet Exporter ROAD", assemblyPath, "DATools.Exporters.AcadSheetExporterBLDRD")) as PushButton;
            BLDRD.ToolTip = "EXPORTAR PLANOS DE MODELOS ROAD";
            BLDRD.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            BLDRD.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");


            #endregion

            ///////
            ///NWCWEx


            PushButtonData all = new PushButtonData("AXM2NWC", "ALL MODELS", assemblyPath, "DATools.Commands.NavisWorksExporterCommand");
            all.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            all.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            all.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");


            PushButtonData d2 = new PushButtonData("AXM5_6", "5-6 MODELS", assemblyPath, "DATools.Commands._5_6_NWC");
            d2.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d2.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d2.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");

           

            PushButtonData d3 = new PushButtonData("AXM7_8", "7-8 MODELS", assemblyPath, "DATools.Commands._7_8_NWC");
            d3.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d3.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d3.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");

            

            PushButtonData d4 = new PushButtonData("AXM3_4", "3_4 MODELS", assemblyPath, "DATools.Commands.BLD34");
            d4.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d4.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d4.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");


            

            PushButtonData d5 = new PushButtonData("AXMBLD1", "BLD_1MODEL", assemblyPath, "DATools.Commands.BLD1_NWC");
            d5.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d5.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d5.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");


            

            PushButtonData d6 = new PushButtonData("AXMBLD2", "BLD_2MODEL", assemblyPath, "DATools.Commands.BLD2_NWC");
            d6.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d6.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d6.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");


            

            PushButtonData d7 = new PushButtonData("AXMBLD9", "BLD_9MODEL", assemblyPath, "DATools.Commands.BLD9");
            d7.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d7.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d7.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");

            

            PushButtonData d8 = new PushButtonData("AXMBLDLS", "BLD_LSMODEL", assemblyPath, "DATools.Commands.BLDLS");
            d8.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d8.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d8.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");


            PushButtonData d9 = new PushButtonData("AXMBLDRD", "BLD_RDMODEL", assemblyPath, "DATools.Commands.BLDRD");
            d9.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            d9.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            d9.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");



            SplitButtonData sb1 = new SplitButtonData("AxmNWCExporter", "NWCbyMODEL");

            SplitButton sb = rpanel4.AddItem(sb1) as SplitButton;
            sb.AddPushButton(all);
            sb.AddPushButton(d2);
            sb.AddPushButton(d3);
            sb.AddPushButton(d4);
            sb.AddPushButton(d5);
            sb.AddPushButton(d6);
            sb.AddPushButton(d7);
            sb.AddPushButton(d8);
            sb.AddPushButton(d9);

            #region AutocadExporters

            //JR SUITES 5-6
            PushButtonData a56 = new PushButtonData("AXM5_6", "5-6 MODELS", assemblyPath, "DATools.Commands.Acad5_6");
            a56.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a56.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a56.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            //JR SUITES 7-8
            PushButtonData a78 = new PushButtonData("AXM7_8", "7-8 MODELS", assemblyPath, "DATools.Commands.Acad7_8");
            a78.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a78.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a78.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            //BUILDINGS 3-4
            PushButtonData a34 = new PushButtonData("AXM3_4", "3-4 MODELS", assemblyPath, "DATools.Commands.Acad3_4");
            a34.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a34.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a34.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            //FORMAL SPACES
            PushButtonData a1 = new PushButtonData("AXM-1", "MODEL 1", assemblyPath,"DATools.Commands.Acad_1");
            a1.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a1.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a1.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            //FAMILY SPACES BLD 2
            PushButtonData a2 = new PushButtonData("AXM-2", "MODEL 2", assemblyPath, "DATools.Commands.Acad_2");
            a2.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a2.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a2.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            // SPA BLD 9
            PushButtonData a9 = new PushButtonData("AXM-9", "MODEL 9", assemblyPath, "DATools.Commands.Acad_9");
            a9.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            a9.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            a9.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            // RD
            PushButtonData rd = new PushButtonData("AXM-RD", "MODEL RD", assemblyPath, "DATools.Commands.Acad_RD");
            rd.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A AUTOCAD EN LA RUTA SELECCIONADA";
            rd.LargeImage = GetResourceImage(assembly, "DATools.Resources.ACAD-32.png");
            rd.Image = GetResourceImage(assembly, "DATools.Resources.ACAD-16.png");

            //SPLIT BUTTON
            SplitButtonData SPA = new SplitButtonData("AxmAcad3DExporter", "Acad3DbyMODEL");
            SplitButton SB = rpanel7.AddItem(SPA) as SplitButton;
            SB.AddPushButton(a56);
            SB.AddPushButton(a78);
            SB.AddPushButton(a34);
            SB.AddPushButton(a1);
            SB.AddPushButton(a2);
            SB.AddPushButton(a9);
            SB.AddPushButton(rd);


            #endregion

            #region CREANDO UN RADIO BUTTON GROUP
            RadioButtonGroupData radiobtndata = new RadioButtonGroupData("RadioButtonGroup01");
            RadioButtonGroup radioBTNgroup = rpanel7.AddItem(radiobtndata) as RadioButtonGroup;

            //en lugar de PUSHBUTTON ahora este objeto almacena un Toggle button

            ToggleButtonData toggleBTNData = new ToggleButtonData("toggleButton", "TOGGLE", assemblyPath, "DATools.Commands.CreateLevelCommand");
            toggleBTNData.LargeImage = GetResourceImage(assembly, "DATools.Resources.DATA32.png");
            toggleBTNData.Image = GetResourceImage(assembly, "DATools.Resources.DATA16.png");
            toggleBTNData.ToolTip = "BOTON TIPO RADIO BUTTON GROUP CON EL COMANDO CREAR NIVELES";

            radioBTNgroup.AddItem(toggleBTNData);


            ToggleButtonData toggleBTNData_2 = new ToggleButtonData("toggleButton2", "TOGGLE-02", assemblyPath, "DATools.Commands.CreateLevelCommand");
            toggleBTNData_2.LargeImage = GetResourceImage(assembly, "DATools.Resources.DATA32.png");
            toggleBTNData_2.Image = GetResourceImage(assembly, "DATools.Resources.DATA16.png");
            toggleBTNData_2.ToolTip = "EL SEGUNDO BOTON CONTRAPARTE DEL BOTON 1 TOOGLE";

            radioBTNgroup.AddItem(toggleBTNData_2);

            #endregion

            #region STACKED ITEMS
            //
            // CREANDO STACKED ITEMS


            PushButtonData testStacked1 = new PushButtonData("Stacked01", "BLD_LSMODEL", assemblyPath, "DATools.Commands.BLDLS");
            testStacked1.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
           // testStacked1.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            testStacked1.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");
            ContextualHelp ayuda = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            testStacked1.SetContextualHelp(ayuda);

            PushButtonData testStacked2 = new PushButtonData("Stacked02", "BLD_LSMODEL", assemblyPath, "DATools.Commands.BLDLS");
            testStacked2.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            // testStacked1.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            testStacked2.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");
            ContextualHelp ayuda2 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            testStacked2.SetContextualHelp(ayuda2);

            PushButtonData testStacked3 = new PushButtonData("Stacked03", "BLD_LSMODEL", assemblyPath, "DATools.Commands.BLDLS");
            testStacked2.ToolTip = "EXPORTA LAS VISTAS 3D PREVIAMENTE CONFIGURADAS DE LAS ESPECIALIDADES MEP-EST-ARQ A NWC EN LA RUTA SELECCIONADA";
            // testStacked1.LargeImage = GetResourceImage(assembly, "DATools.Resources.navislogo32.png");
            testStacked3.Image = GetResourceImage(assembly, "DATools.Resources.navislogo16.png");
            ContextualHelp ayuda3 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            testStacked2.SetContextualHelp(ayuda3);


            rpanel7.AddStackedItems(testStacked1, testStacked2, testStacked3);


            #endregion

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }


        #region MANEJO DE IMAGENES Y RECURSOS EXTERNOS
        // METODOS PARA MANEJO DE IMAGENES EXTERNAS
        public ImageSource GetResourceImage(Assembly assembly,string imageName)
        {
            try
            {
                Stream resource = assembly.GetManifestResourceStream(imageName);
                return BitmapFrame.Create(resource);

            }
            catch
            {
                return null;
            }
        }

        #endregion

    }
}
