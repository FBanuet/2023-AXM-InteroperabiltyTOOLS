using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using DATools.Commands;

namespace DATools.Utility
{
    public static class LengthUnitConverter
    {

        public static double ConvertToMetric(double value,LengthUnitType type , int decimals)
        {
            switch (type)
            {
                case LengthUnitType.milimeters:
                    return Math.Round(value * 304.8, decimals);
                case LengthUnitType.centimeter:
                    return Math.Round(value * 30.48, decimals);
                case LengthUnitType.decimeter:
                    return Math.Round(value * 3.048, decimals);
                case LengthUnitType.meters:
                    return Math.Round(value * 0.3048, decimals);
                case LengthUnitType.kilometer:
                    return Math.Round(value * 0.0003048, decimals);
                default:
                    return value;
            }

        }
    }
}