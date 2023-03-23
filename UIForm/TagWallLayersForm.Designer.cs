
namespace DATools.UIForm
{
    partial class TagWallLayersForm
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.GBOX = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMBOX = new System.Windows.Forms.ComboBox();
            this.CHKTHIK = new System.Windows.Forms.CheckBox();
            this.CHKNAME = new System.Windows.Forms.CheckBox();
            this.CH1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbUnitsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbUnitPlaces = new System.Windows.Forms.ComboBox();
            this.CHKeynote = new System.Windows.Forms.CheckBox();
            this.GBOX.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.OK.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(12, 548);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(131, 30);
            this.OK.TabIndex = 0;
            this.OK.Text = "PRESS OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Red;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(318, 548);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(146, 30);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "PRESS CANCEL";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // GBOX
            // 
            this.GBOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GBOX.Controls.Add(this.CHKeynote);
            this.GBOX.Controls.Add(this.label1);
            this.GBOX.Controls.Add(this.CMBOX);
            this.GBOX.Controls.Add(this.CHKTHIK);
            this.GBOX.Controls.Add(this.CHKNAME);
            this.GBOX.Controls.Add(this.CH1);
            this.GBOX.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBOX.Location = new System.Drawing.Point(46, 31);
            this.GBOX.Name = "GBOX";
            this.GBOX.Size = new System.Drawing.Size(378, 311);
            this.GBOX.TabIndex = 2;
            this.GBOX.TabStop = false;
            this.GBOX.Text = "Propiedades de Taggeos";
            this.GBOX.Enter += new System.EventHandler(this.GBOX_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de TextNote";
            // 
            // CMBOX
            // 
            this.CMBOX.FormattingEnabled = true;
            this.CMBOX.Location = new System.Drawing.Point(24, 241);
            this.CMBOX.Name = "CMBOX";
            this.CMBOX.Size = new System.Drawing.Size(327, 33);
            this.CMBOX.TabIndex = 4;
            this.CMBOX.SelectedIndexChanged += new System.EventHandler(this.CMBOX_SelectedIndexChanged);
            // 
            // CHKTHIK
            // 
            this.CHKTHIK.AutoSize = true;
            this.CHKTHIK.Checked = true;
            this.CHKTHIK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKTHIK.Location = new System.Drawing.Point(33, 129);
            this.CHKTHIK.Name = "CHKTHIK";
            this.CHKTHIK.Size = new System.Drawing.Size(127, 29);
            this.CHKTHIK.TabIndex = 2;
            this.CHKTHIK.Text = "Thickness";
            this.CHKTHIK.UseVisualStyleBackColor = true;
            // 
            // CHKNAME
            // 
            this.CHKNAME.AutoSize = true;
            this.CHKNAME.Checked = true;
            this.CHKNAME.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKNAME.Location = new System.Drawing.Point(34, 80);
            this.CHKNAME.Name = "CHKNAME";
            this.CHKNAME.Size = new System.Drawing.Size(87, 29);
            this.CHKNAME.TabIndex = 1;
            this.CHKNAME.Text = "Name";
            this.CHKNAME.UseVisualStyleBackColor = true;
            this.CHKNAME.CheckedChanged += new System.EventHandler(this.CHKNAME_CheckedChanged);
            // 
            // CH1
            // 
            this.CH1.AutoSize = true;
            this.CH1.Checked = true;
            this.CH1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CH1.Location = new System.Drawing.Point(34, 32);
            this.CH1.Name = "CH1";
            this.CH1.Size = new System.Drawing.Size(126, 29);
            this.CH1.TabIndex = 0;
            this.CH1.Text = "FUNCIÓN";
            this.CH1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbUnitPlaces);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbUnitsType);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 186);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidades";
            // 
            // CmbUnitsType
            // 
            this.CmbUnitsType.FormattingEnabled = true;
            this.CmbUnitsType.Location = new System.Drawing.Point(11, 52);
            this.CmbUnitsType.Name = "CmbUnitsType";
            this.CmbUnitsType.Size = new System.Drawing.Size(337, 26);
            this.CmbUnitsType.TabIndex = 0;
            this.CmbUnitsType.SelectedIndexChanged += new System.EventHandler(this.CmbUnitsType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de Unidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Decimales";
            // 
            // CmbUnitPlaces
            // 
            this.CmbUnitPlaces.FormattingEnabled = true;
            this.CmbUnitPlaces.Location = new System.Drawing.Point(11, 118);
            this.CmbUnitPlaces.Name = "CmbUnitPlaces";
            this.CmbUnitPlaces.Size = new System.Drawing.Size(337, 26);
            this.CmbUnitPlaces.TabIndex = 2;
            this.CmbUnitPlaces.SelectedIndexChanged += new System.EventHandler(this.CmbUnitPlaces_SelectedIndexChanged);
            // 
            // CHKeynote
            // 
            this.CHKeynote.AutoSize = true;
            this.CHKeynote.Checked = true;
            this.CHKeynote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKeynote.Location = new System.Drawing.Point(33, 172);
            this.CHKeynote.Name = "CHKeynote";
            this.CHKeynote.Size = new System.Drawing.Size(109, 29);
            this.CHKeynote.TabIndex = 6;
            this.CHKeynote.Text = "Keynote";
            this.CHKeynote.UseVisualStyleBackColor = true;
            // 
            // TagWallLayersForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(499, 610);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBOX);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "TagWallLayersForm";
            this.Text = "D A T Architects | | Chose Options";
            this.Load += new System.EventHandler(this.TagWallLayersForm_Load);
            this.GBOX.ResumeLayout(false);
            this.GBOX.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.GroupBox GBOX;
        private System.Windows.Forms.CheckBox CHKTHIK;
        private System.Windows.Forms.CheckBox CHKNAME;
        private System.Windows.Forms.CheckBox CH1;
        private System.Windows.Forms.ComboBox CMBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbUnitPlaces;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbUnitsType;
        private System.Windows.Forms.CheckBox CHKeynote;
    }
}