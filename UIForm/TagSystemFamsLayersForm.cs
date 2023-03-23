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
using DATools.Commands;
using System.Collections;

namespace DATools.UIForm
{
    public partial class TagSystemFamsLayersForm : System.Windows.Forms.Form
    {
        public TagSystemFamsLayersForm()
        {
            InitializeComponent();
        }

        private void TagSystemFamsLayersForm_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();

        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();


        }

        public TagSystemLayersData GetData()
        {
            var information = new TagSystemLayersData()
            {
                WallCat = wall.Checked,
                FloorCat = floors.Checked,
                CeilingCat = ceil.Checked,
                RoofCat = roof.Checked
            };

            return information;
        }
    }
}
