using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
    public partial class PrintParametersForm : System.Windows.Forms.Form
    {

        private UIDocument uidoc = null;
        public PrintParametersForm(UIDocument uIDocument)
        {
            InitializeComponent();
            uidoc = uIDocument;
            Document doc = uidoc.Document;

            FilteredElementCollector col = new FilteredElementCollector(doc).OfClass(typeof(PrintSetting));

            List<string> impresoras = new List<string>();
            List<string> printsettings = new List<string>();

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				impresoras.Add(printer);

			}

			foreach (PrintSetting ps in col)
			{
				printsettings.Add(ps.Name);
			}

			foreach (string pp in impresoras)
			{
				this.imp.Items.Add(pp);
			}

			foreach (string psi in printsettings)
			{
				this.pset.Items.Add(psi);
			}

			this.imp.SelectedIndex = 0;
			this.pset.SelectedIndex = 0;

		}

		private void PrintParametersForm_Load(object sender, EventArgs e)
        {

        }

        private void imp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VNT_TextChanged(object sender, EventArgs e)
        {

        }

        public string SeleccionarImpresora()
        {
            return this.imp.SelectedItem.ToString();
        }

        public string SeleccionarPSettings()
        {
            return this.pset.SelectedItem.ToString();
        }

        public string Getfilepath()
        {
            return this.VNT.Text.ToString();
        }


    }
}
