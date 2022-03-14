namespace AppControls
{
    partial class ctrDBBackUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnOK = new ControlLibrary.TAButton();
            this.btnSelectDB = new ControlLibrary.TAButton();
            this.txtDBName = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 15);
            this.progressBar1.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(134)))), ((int)(((byte)(168)))));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnOK.ColorFillBlend = cBlendItems1;
            this.btnOK.DesignerSelected = false;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnOK.ImageIndex = 0;
            this.btnOK.Location = new System.Drawing.Point(286, 44);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(134)))), ((int)(((byte)(168)))));
            this.btnSelectDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSelectDB.ColorFillBlend = cBlendItems2;
            this.btnSelectDB.DesignerSelected = false;
            this.btnSelectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSelectDB.ImageIndex = 0;
            this.btnSelectDB.Location = new System.Drawing.Point(308, 13);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(32, 23);
            this.btnSelectDB.TabIndex = 3;
            this.btnSelectDB.Text = "...";
            this.btnSelectDB.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            
            // 
            // txtDBName
            // 
            this.txtDBName.Enabled = false;
            this.txtDBName.Location = new System.Drawing.Point(72, 14);
            this.txtDBName.MaxLength = 150;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(231, 20);
            this.txtDBName.TabIndex = 1;
            this.txtDBName.xBindingProperty = null;
            this.txtDBName.xColumnName = null;
            this.txtDBName.xColumnWidth = 60;
            this.txtDBName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtDBName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtDBName.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtDBName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtDBName.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtDBName.xMasked = System32.StaticInfo.Mask.None;
            this.txtDBName.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataBase:";
            // 
            // ctrDBBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.btnSelectDB);
            this.Controls.Add(this.label1);
            this.Name = "ctrDBBackUp";
            this.Size = new System.Drawing.Size(349, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private ControlLibrary.TAButton btnOK;
        private ControlLibrary.TAButton btnSelectDB;
        private ControlLibrary.TATextBox txtDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
