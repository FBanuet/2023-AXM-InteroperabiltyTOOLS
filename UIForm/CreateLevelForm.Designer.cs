
namespace DATools.UIForm
{
    partial class CreateLevelForm
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
            this.Continue = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LevelNMBR = new System.Windows.Forms.TextBox();
            this.LevelHeigth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Continue
            // 
            this.Continue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Continue.Location = new System.Drawing.Point(25, 183);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(181, 39);
            this.Continue.TabIndex = 0;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(248, 183);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(181, 39);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad de Niveles a Desarrollar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Altura de Entrepiso (NPT - NPT)";
            // 
            // LevelNMBR
            // 
            this.LevelNMBR.Location = new System.Drawing.Point(224, 73);
            this.LevelNMBR.Name = "LevelNMBR";
            this.LevelNMBR.Size = new System.Drawing.Size(135, 20);
            this.LevelNMBR.TabIndex = 5;
            this.LevelNMBR.TextChanged += new System.EventHandler(this.LevelNMBR_TextChanged);
            // 
            // LevelHeigth
            // 
            this.LevelHeigth.Location = new System.Drawing.Point(224, 125);
            this.LevelHeigth.Name = "LevelHeigth";
            this.LevelHeigth.Size = new System.Drawing.Size(135, 20);
            this.LevelHeigth.TabIndex = 6;
            this.LevelHeigth.TextChanged += new System.EventHandler(this.LevelHeigth_TextChanged);
            // 
            // CreateLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 260);
            this.Controls.Add(this.LevelHeigth);
            this.Controls.Add(this.LevelNMBR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Continue);
            this.Name = "CreateLevelForm";
            this.Text = "CreateLevelForm";
            this.Load += new System.EventHandler(this.CreateLevelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LevelNMBR;
        private System.Windows.Forms.TextBox LevelHeigth;
    }
}