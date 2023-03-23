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
    public partial class FilePathForm : System.Windows.Forms.Form
    {
        public FilePathForm()
        {
            InitializeComponent();
            

            
        }

        private void FilePathForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        

        public string FPFGetfilepath()
        {
            return this.datab.Text.ToString();
        }
    }
}
