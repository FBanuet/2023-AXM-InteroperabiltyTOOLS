namespace DATools.UIForm
{
    partial class TagSystemFamsLayersForm
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
            this.wall = new System.Windows.Forms.CheckBox();
            this.floors = new System.Windows.Forms.CheckBox();
            this.ceil = new System.Windows.Forms.CheckBox();
            this.roof = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.CANCEL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASIGNAR PARÁMETROS DE ACABADOS POR CAPAS";
            // 
            // wall
            // 
            this.wall.AutoSize = true;
            this.wall.Checked = true;
            this.wall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wall.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wall.Location = new System.Drawing.Point(6, 56);
            this.wall.Name = "wall";
            this.wall.Size = new System.Drawing.Size(129, 25);
            this.wall.TabIndex = 1;
            this.wall.Text = "SET WALLS";
            this.wall.UseVisualStyleBackColor = true;
            // 
            // floors
            // 
            this.floors.AutoSize = true;
            this.floors.Checked = true;
            this.floors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.floors.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floors.Location = new System.Drawing.Point(6, 107);
            this.floors.Name = "floors";
            this.floors.Size = new System.Drawing.Size(141, 25);
            this.floors.TabIndex = 2;
            this.floors.Text = "SET FLOORS";
            this.floors.UseVisualStyleBackColor = true;
            // 
            // ceil
            // 
            this.ceil.AutoSize = true;
            this.ceil.Checked = true;
            this.ceil.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ceil.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceil.Location = new System.Drawing.Point(6, 165);
            this.ceil.Name = "ceil";
            this.ceil.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ceil.Size = new System.Drawing.Size(154, 25);
            this.ceil.TabIndex = 3;
            this.ceil.Text = "SET CEILINGS";
            this.ceil.UseVisualStyleBackColor = true;
            // 
            // roof
            // 
            this.roof.AutoSize = true;
            this.roof.Checked = true;
            this.roof.CheckState = System.Windows.Forms.CheckState.Checked;
            this.roof.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roof.Location = new System.Drawing.Point(6, 223);
            this.roof.Name = "roof";
            this.roof.Size = new System.Drawing.Size(131, 25);
            this.roof.TabIndex = 4;
            this.roof.Text = "SET ROOFS";
            this.roof.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.wall);
            this.groupBox1.Controls.Add(this.roof);
            this.groupBox1.Controls.Add(this.floors);
            this.groupBox1.Controls.Add(this.ceil);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 269);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACCIONES A REALIZAR";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(212, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(343, 75);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Nota:\r\nEste comando, asignara valores a los parámetros\r\nInicial,Final e Intermedi" +
    "o los valores por capa (MARK),\r\nen caso de no tener valores en los materiales, s" +
    "e omitiran\r\nlos elementos.";
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.Menu;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OK.Location = new System.Drawing.Point(212, 242);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(136, 44);
            this.OK.TabIndex = 7;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // CANCEL
            // 
            this.CANCEL.BackColor = System.Drawing.SystemColors.Menu;
            this.CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANCEL.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANCEL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CANCEL.Location = new System.Drawing.Point(377, 242);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(136, 44);
            this.CANCEL.TabIndex = 8;
            this.CANCEL.Text = "CANCELAR";
            this.CANCEL.UseVisualStyleBackColor = false;
            this.CANCEL.Click += new System.EventHandler(this.CANCEL_Click);
            // 
            // TagSystemFamsLayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(634, 345);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TagSystemFamsLayersForm";
            this.Text = "TagSystemFamsLayersForm";
            this.Load += new System.EventHandler(this.TagSystemFamsLayersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox wall;
        private System.Windows.Forms.CheckBox floors;
        private System.Windows.Forms.CheckBox ceil;
        private System.Windows.Forms.CheckBox roof;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button CANCEL;
    }
}