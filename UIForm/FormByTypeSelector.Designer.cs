
namespace DATools.UIForm
{
    partial class FormByTypeSelector
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
            this.cmboxCatType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.lstTypes = new System.Windows.Forms.ListBox();
            this.clearSel = new System.Windows.Forms.Button();
            this.chkCurrentView = new System.Windows.Forms.CheckBox();
            this.bntAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmboxCatType
            // 
            this.cmboxCatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxCatType.FormattingEnabled = true;
            this.cmboxCatType.Location = new System.Drawing.Point(12, 12);
            this.cmboxCatType.Name = "cmboxCatType";
            this.cmboxCatType.Size = new System.Drawing.Size(121, 21);
            this.cmboxCatType.TabIndex = 0;
            this.cmboxCatType.SelectedIndexChanged += new System.EventHandler(this.cmboxCatType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(139, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter por:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(220, 13);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(127, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lstCategory
            // 
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(14, 44);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(146, 342);
            this.lstCategory.TabIndex = 3;
            this.lstCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
            // 
            // lstTypes
            // 
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.Location = new System.Drawing.Point(187, 40);
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(159, 303);
            this.lstTypes.TabIndex = 4;
            // 
            // clearSel
            // 
            this.clearSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearSel.Location = new System.Drawing.Point(12, 424);
            this.clearSel.Name = "clearSel";
            this.clearSel.Size = new System.Drawing.Size(131, 38);
            this.clearSel.TabIndex = 5;
            this.clearSel.Text = "Limpiar Seleccion";
            this.clearSel.UseVisualStyleBackColor = true;
            this.clearSel.Click += new System.EventHandler(this.clearSel_Click);
            // 
            // chkCurrentView
            // 
            this.chkCurrentView.AutoSize = true;
            this.chkCurrentView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkCurrentView.Location = new System.Drawing.Point(187, 360);
            this.chkCurrentView.Name = "chkCurrentView";
            this.chkCurrentView.Size = new System.Drawing.Size(142, 17);
            this.chkCurrentView.TabIndex = 6;
            this.chkCurrentView.Text = "Vista Activa Unicamente";
            this.chkCurrentView.UseVisualStyleBackColor = false;
            // 
            // bntAll
            // 
            this.bntAll.Location = new System.Drawing.Point(176, 395);
            this.bntAll.Name = "bntAll";
            this.bntAll.Size = new System.Drawing.Size(88, 26);
            this.bntAll.TabIndex = 7;
            this.bntAll.Text = "Todo";
            this.bntAll.UseVisualStyleBackColor = true;
            this.bntAll.Click += new System.EventHandler(this.bntAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(270, 395);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(85, 25);
            this.btnNone.TabIndex = 8;
            this.btnNone.Text = "Ninguno";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(176, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Count:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumber.Location = new System.Drawing.Point(248, 424);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 16);
            this.lblNumber.TabIndex = 10;
            this.lblNumber.Text = "0";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(172, 455);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(174, 42);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FormByTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(364, 509);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.bntAll);
            this.Controls.Add(this.chkCurrentView);
            this.Controls.Add(this.clearSel);
            this.Controls.Add(this.lstTypes);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboxCatType);
            this.Name = "FormByTypeSelector";
            this.Text = "FormByTypeSelector";
            this.Load += new System.EventHandler(this.FormByTypeSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboxCatType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.ListBox lstTypes;
        private System.Windows.Forms.Button clearSel;
        private System.Windows.Forms.CheckBox chkCurrentView;
        private System.Windows.Forms.Button bntAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnSelect;
    }
}