using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;


namespace DATools.Utility
{
    public class NameIDObject
    {
        public NameIDObject(string name,int idValue)
        {
            Name = name;
            IdValue = idValue;
        }

        public string Name { get; set; }
        public int IdValue { get; set; }
    }
}
