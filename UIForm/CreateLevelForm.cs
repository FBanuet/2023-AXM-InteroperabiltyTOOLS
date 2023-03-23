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
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;


namespace DATools.UIForm
{
    public partial class CreateLevelForm : System.Windows.Forms.Form
    {
        private UIApplication UIapp;
        private UIDocument UIDoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;

       public string meterValue;
       public string LevelValue;




        public CreateLevelForm(ExternalCommandData commanddata)
        {
            InitializeComponent();

            UIapp = commanddata.Application;
            UIDoc = UIapp.ActiveUIDocument;
            app = UIapp.Application;
            doc = UIDoc.Document;



        }

        

        private void CreateLevelForm_Load(object sender, EventArgs e)
        {

        }

        private void LevelNMBR_TextChanged(object sender, EventArgs e)
        {

        }

        private void LevelHeigth_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Cancel.DialogResult = DialogResult.Cancel;
            System.Windows.MessageBox.Show("ACCIÓN CANCELADA");

        }
        private void Continue_Click(object sender, EventArgs e)
        {
            LevelValue = LevelNMBR.Text;
            meterValue = LevelHeigth.Text;

            Continue.DialogResult = DialogResult.OK;
            System.Windows.MessageBox.Show("PROCESANDO");
            Close();

            return;
        }
    }
}
