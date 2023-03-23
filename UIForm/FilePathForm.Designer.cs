namespace DATools.UIForm
{
    partial class FilePathForm
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
            this.datab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datab
            // 
            this.datab.Location = new System.Drawing.Point(9, 87);
            this.datab.Name = "datab";
            this.datab.Size = new System.Drawing.Size(604, 20);
            this.datab.TabIndex = 0;
            this.datab.Text = "Ruta";
            this.datab.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copie y pegue el directorio aqui (Ejemplo) : D:\\\\Users\\\\Admin\\\\Downloads\\\\TSR";
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OK.Location = new System.Drawing.Point(20, 137);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(165, 43);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Cancel.Location = new System.Drawing.Point(425, 137);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(165, 43);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "CANCELAR";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // FilePathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(637, 197);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datab);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "FilePathForm";
            this.Text = "AXM || Renmobrando PDF";
            this.Load += new System.EventHandler(this.FilePathForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox datab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}