using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATools.UIForm;

namespace DATools.Commands
{
    [Transaction(TransactionMode.ReadOnly)]
    public class SelectByTypeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            FormByTypeSelector form = new FormByTypeSelector(doc);
            form.Show();

            return Result.Succeeded;
        }
    }
}
