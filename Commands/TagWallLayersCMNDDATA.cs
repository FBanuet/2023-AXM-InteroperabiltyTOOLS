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
    public class TagWallLayersCMNDDATA
    {

        public bool Function { get; set; }
        public bool Name { get; set; }

        public bool Thickness { get; set; }

        public bool Keynote { get; set; }

        public ElementId TextTypeId { get; set; }

        public LengthUnitType UnitType { get; set; }

        public int Decimals { get; set; }
    }
}