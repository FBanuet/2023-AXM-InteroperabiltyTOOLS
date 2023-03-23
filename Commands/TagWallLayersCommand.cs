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
    public class TagWallLayersCommand : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //GLOBAL VARIABLES


            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            
            ///VERIFICANDO SI ESTAMOS EN UN DOCUMENTO DE PROYECTO 

            if(doc.IsFamilyDocument)
            {
               
                TaskDialog.Show("WARNING", "SOME ERROR JUST HAPPENED");

            }

            /// GET THE ACTIVE VIEW()

            Autodesk.Revit.DB.View AView = uidoc.ActiveView;
            bool canCreateTextNoteinAView = false;

            switch(AView.ViewType)
            {
                
                case ViewType.FloorPlan:
                    canCreateTextNoteinAView = true;
                    break;
               
                case ViewType.CeilingPlan:
                    canCreateTextNoteinAView = true;
                    break;
                
                case ViewType.Detail:
                    canCreateTextNoteinAView = true;
                    break;

                case ViewType.Elevation:
                    canCreateTextNoteinAView = true;
                    break;

                case ViewType.Section:
                    canCreateTextNoteinAView = true;
                    break;

                
            }

            var userinfo = new TagWallLayersCMNDDATA();

            

            if (!canCreateTextNoteinAView)

            {

               TaskDialog.Show("ERROR", "EN ESTA VISTA NO SE PUEDE COLOCAR ELEMENTOS 2D!");
                return Result.Cancelled;
            }

            using (var window = new TagWallLayersForm(uidoc))
            {
                window.ShowDialog();

                if (window.DialogResult == DialogResult.Cancel)
                {
                    return Result.Cancelled;
                }

                userinfo = window.GetInfo();
            }


            /// PROMPR THE USER TO PICK A WALL IN THE USER INTERFACE(ONLY WORKS WITH BASIC WALLS)
            /// 

            Reference Refwall = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element,new SelectionFilter("Walls"),"seleccione un Muro Básico");
            Element EWall = doc.GetElement(Refwall);
            Wall wall = EWall as Wall;

            //CHECK IF THE USER PICK ONLY BASIC WALLS

            if(wall.IsStackedWall)
            {
                TaskDialog.Show("ERROR!", "PORFAVOR SELECCIONE UN MURO DE TIPO Basic Wall!" + Environment.NewLine + "TIPO DE MURO NO SOPORTADO");
                return Result.Cancelled;
            }

            

            // GETTING THE WALL LAYERS

            IList<CompoundStructureLayer> layers =   wall.WallType.GetCompoundStructure().GetLayers();

            var msg = new StringBuilder();

            foreach (CompoundStructureLayer layer in layers)
            {
                Material material = doc.GetElement(layer.MaterialId) as Material;

                Parameter KEY = material.get_Parameter(BuiltInParameter.KEYNOTE_PARAM);


                msg.AppendLine();
                if(userinfo.Function)
                {
                    msg.Append(layer.Function.ToString());
                }
                if(userinfo.Name)
                {
                    if(material != null)
                        msg.Append(" " + material.Name);
                    else
                        msg.Append("Default(by Category)");



                }
                if(userinfo.Thickness)
                {
                    msg.Append("  " + LengthUnitConverter.ConvertToMetric(layer.Width,userinfo.UnitType,userinfo.Decimals).ToString());
                }
                if(userinfo.Keynote)
                {
                    if (KEY != null)
                        msg.Append(" - CódigoMF : " + KEY.AsString());
                    else
                        msg.Append("SIN KEYNOTE ASIGNADO!");
                }
            }


            ///MOPEN THE TRANSACTION IN ACTIVE DOC!
            ///
            TextNoteOptions txtOpt = new TextNoteOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                TypeId = userinfo.TextTypeId,
                

            };

             using(Transaction trans = new Transaction(doc,"TAG WALL LAYERS"))

            {
                trans.Start();

                XYZ pt = new XYZ();
                if(AView.ViewType == ViewType.Elevation || AView.ViewType == ViewType.Section)
                {
                    Plane plane = Plane.CreateByNormalAndOrigin(AView.ViewDirection, AView.Origin);
                    SketchPlane skplane = SketchPlane.Create(doc, plane);
                    AView.SketchPlane = skplane;

                    pt = uidoc.Selection.PickPoint("PORFAVOR SELECCIONE UN PUNTO ");

                }
                else
                {
                    pt = uidoc.Selection.PickPoint("PORFAVOR SELECCIONE UN PUNTO ");
                }

                TextNote txt = TextNote.Create(doc, AView.Id, pt, msg.ToString(),txtOpt);
                txt.AddLeader(TextNoteLeaderTypes.TNLT_STRAIGHT_L);
                


                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
