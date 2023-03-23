using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;

namespace DATools.Commands
{
    public class SelectionFilter : ISelectionFilter
    {
        /// <summary>
        /// /
        /// </summary>
        #region private members

        private string mCategory = "";


        #endregion

        /// <summary>
        /// /
        /// </summary>
        /// <param name="category"></param>
        public SelectionFilter(string category)
        {
            mCategory = category;

        }



        /// <summary>
        /// //
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool AllowElement(Element element)
        {
            if (element.Category.Name == mCategory)
                return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
