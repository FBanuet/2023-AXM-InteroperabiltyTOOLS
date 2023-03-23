using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using DATools.UIForm;
using System.Windows.Forms;
using DATools.Utility;

namespace DATools.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class TagSystemLayersCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            var userInfo = new TagSystemLayersData();
           
            using (var window = new TagSystemFamsLayersForm())
            {
                window.ShowDialog();

                if (window.DialogResult == DialogResult.Cancel)
                {
                    return Result.Cancelled;
                }

                userInfo = window.GetData();
            }

            return Result.Succeeded;
            
            
        }

        private void SetWallInfo(Wall muro,UIDocument uidoc)
        {
            Document doc = uidoc.Document;

            // get SHARED PARAMETERS PER CLASS


            try
            {
                WallType TipoMuro = muro.WallType;


                //UNICAMENTE PODREMOS ITERAR SIEMPRE Y CUANDO LOS MUROS SEAN DEL TIPO <<BASIC>> LOS STACKED Y LOS CURTAIN NO TIENEN COMPOUND STRUCTURES

                if(WallKind.Basic == TipoMuro.Kind)
                {
                    CompoundStructure comstruct = TipoMuro.GetCompoundStructure();

                    //OBTENER LAS CATEGORIAS POR DEFAULT EN CASO DE QUE EL USUARIO NO HAYA SEGUIDO LA METODOLOGIA BIM, ES DECIR MODELO COMO UN CAD O SKETCHUP

                    Categories allCates = doc.Settings.Categories;


                    //DEFINIR CUALES CAPAS ESTAN CON EL MATERIAL<<BY CATEGORY>>

                    Category wallCate = allCates.get_Item(BuiltInCategory.OST_Walls);
                    Material wallDFmaterial = wallCate.Material;

                   using(Transaction trans = new Transaction(doc,"TAGGING PARTS"))
                    {
                        foreach(CompoundStructureLayer structulayer in comstruct.GetLayers())
                        {
                            Material layerMat = doc.GetElement(structulayer.MaterialId) as Material;
                            string valornuevo = "";
                            //SI EL MATERIAL DE  LA CAPA PROVENIENTE DE LA ESTRUCTURA COMPUESTA ESTA ESPECIFICADA, ENTONCES USE LA QUE ESATA, DE LO CONTRARIO USE EL MATERIAL POR
                            //DAFAULT DE LA CATEGORIA, EN ESTE CASO EL MATERIAL POR DEFAULT DE LA CATEGORIA WALLS

                            if(null == layerMat)
                            {
                                switch(structulayer.Function)
                                {
                                    case MaterialFunctionAssignment.None:
                                        valornuevo = allCates.get_Item(BuiltInCategory.OST_WallsDefault).Material.Name;
                                        break;

                                }
                            }
                        }

                    }

                }

               
            }
            catch (Exception e)
            {
                TaskDialog.Show("WARNING!!", e.Message);

            }
        }

        

       
    }
}
