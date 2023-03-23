
namespace DATools.UIForm
{
    partial class PlaceSelectedViewsOnSheets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DropDown = new System.Windows.Forms.ComboBox();
            this.CANCELBTN = new System.Windows.Forms.Button();
            this.okbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar el Sheet Desado";
            // 
            // DropDown
            // 
            this.DropDown.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropDown.FormattingEnabled = true;
            this.DropDown.Location = new System.Drawing.Point(12, 107);
            this.DropDown.Name = "DropDown";
            this.DropDown.Size = new System.Drawing.Size(446, 26);
            this.DropDown.TabIndex = 2;
            // 
            // CANCELBTN
            // 
            this.CANCELBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANCELBTN.Location = new System.Drawing.Point(327, 245);
            this.CANCELBTN.Name = "CANCELBTN";
            this.CANCELBTN.Size = new System.Drawing.Size(143, 34);
            this.CANCELBTN.TabIndex = 5;
            this.CANCELBTN.Text = "CANCEL";
            this.CANCELBTN.UseVisualStyleBackColor = true;
            // 
            // okbtn
            // 
            this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbtn.Location = new System.Drawing.Point(36, 245);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(143, 34);
            this.okbtn.TabIndex = 4;
            this.okbtn.Text = "COLOCAR";
            this.okbtn.UseVisualStyleBackColor = true;
            // 
            // PlaceSelectedViewsOnSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(519, 301);
            this.Controls.Add(this.CANCELBTN);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.DropDown);
            this.Controls.Add(this.label1);
            this.Name = "PlaceSelectedViewsOnSheets";
            this.Text = "COLOCANDO VISTAS SELECCIONADAS EN PLANO";
            this.Load += new System.EventHandler(this.PlaceSelectedViewsOnSheets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DropDown;
        private System.Windows.Forms.Button CANCELBTN;
        private System.Windows.Forms.Button okbtn;
    }
}