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
    public class TagSystemLayersData
    {
        public bool WallCat { get; set; }

        public bool FloorCat { get; set; }

        public bool CeilingCat { get; set; }

        public bool RoofCat { get; set; }


        public TagSystemLayersData()
        {

        }
    }
}
