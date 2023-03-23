using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.Attributes;

namespace DATools.UIForm
{
    public partial class PlaceSelectedViewsOnSheets : System.Windows.Forms.Form
    {
        private UIDocument uidoc = null;
        public PlaceSelectedViewsOnSheets(UIDocument uidocument)
        {
            InitializeComponent();
            uidoc = uidocument;
            Document doc = uidoc.Document;

            FilteredElementCollector planosModelo = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet));


            List<string> numerosPlanos = new List<string>();

            foreach (ViewSheet vs in planosModelo)
            {
                numerosPlanos.Add(vs.SheetNumber);
            }

            foreach (string num in numerosPlanos)
            {
                this.DropDown.Items.Add(num);

            }

            this.DropDown.SelectedIndex = 0;
        }

        private void PlaceSelectedViewsOnSheets_Load(object sender, EventArgs e)
        {

        }

        private void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string SeleccionarNumero()
        {
            return this.DropDown.SelectedItem.ToString();
        }
    }
}
