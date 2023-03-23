namespace DATools.UIForm
{
    partial class PrintParametersForm
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
            this.imp = new System.Windows.Forms.ComboBox();
            this.pset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.CANCEL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.VNT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "EXPORTAR PDFS SELECCIONADOS";
            // 
            // imp
            // 
            this.imp.FormattingEnabled = true;
            this.imp.Location = new System.Drawing.Point(191, 100);
            this.imp.Name = "imp";
            this.imp.Size = new System.Drawing.Size(434, 21);
            this.imp.TabIndex = 1;
            this.imp.SelectedIndexChanged += new System.EventHandler(this.imp_SelectedIndexChanged);
            // 
            // pset
            // 
            this.pset.FormattingEnabled = true;
            this.pset.Location = new System.Drawing.Point(191, 150);
            this.pset.Name = "pset";
            this.pset.Size = new System.Drawing.Size(434, 21);
            this.pset.TabIndex = 2;
            this.pset.SelectedIndexChanged += new System.EventHandler(this.pset_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "IMPRESORAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "PRINT SETTINGS";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(62, 267);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(165, 26);
            this.OK.TabIndex = 5;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // CANCEL
            // 
            this.CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANCEL.Location = new System.Drawing.Point(318, 267);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(165, 26);
            this.CANCEL.TabIndex = 6;
            this.CANCEL.Text = "CANCEL";
            this.CANCEL.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "VIEWSET NAME TEMPORAL";
            // 
            // VNT
            // 
            this.VNT.Location = new System.Drawing.Point(243, 200);
            this.VNT.Name = "VNT";
            this.VNT.Size = new System.Drawing.Size(381, 20);
            this.VNT.TabIndex = 8;
            this.VNT.TextChanged += new System.EventHandler(this.VNT_TextChanged);
            // 
            // PrintParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(695, 327);
            this.Controls.Add(this.VNT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pset);
            this.Controls.Add(this.imp);
            this.Controls.Add(this.label1);
            this.Name = "PrintParametersForm";
            this.Text = "AXM || CUSTOM PDF PRINTER";
            this.Load += new System.EventHandler(this.PrintParametersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox imp;
        private System.Windows.Forms.ComboBox pset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button CANCEL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VNT;
    }
}