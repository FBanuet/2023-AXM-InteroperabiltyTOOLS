using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
namespace DATools.Commands
{
    public enum  LengthUnitType
    {

        milimeters = 0,
        centimeter = 1,
        decimeter = 2,
        meters = 3,
        kilometer =4,

    }
}
