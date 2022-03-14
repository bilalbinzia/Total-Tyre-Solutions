namespace AppControls
{
    partial class ctrPackagesList
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
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVPackageList = new ControlLibrary.TAZSearchDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefreshPackages = new ControlLibrary.TAButton();
            this.btnEditPackage = new ControlLibrary.TAButton();
            this.btnNewPackage = new ControlLibrary.TAButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGVPackageList);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 452);
            this.panel1.TabIndex = 0;
            // 
            // DGVPackageList
            // 
            this.DGVPackageList.Location = new System.Drawing.Point(4, 41);
            this.DGVPackageList.Name = "DGVPackageList";
            this.DGVPackageList.Size = new System.Drawing.Size(773, 398);
            this.DGVPackageList.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefreshPackages);
            this.panel2.Controls.Add(this.btnEditPackage);
            this.panel2.Controls.Add(this.btnNewPackage);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 30);
            this.panel2.TabIndex = 0;
            // 
            // btnRefreshPackages
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnRefreshPackages.ColorFillBlend = cBlendItems1;
            this.btnRefreshPackages.DesignerSelected = false;
            this.btnRefreshPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRefreshPackages.ImageIndex = 0;
            this.btnRefreshPackages.Location = new System.Drawing.Point(664, 2);
            this.btnRefreshPackages.Name = "btnRefreshPackages";
            this.btnRefreshPackages.Size = new System.Drawing.Size(106, 27);
            this.btnRefreshPackages.TabIndex = 11664;
            this.btnRefreshPackages.Text = "Refresh";
            this.btnRefreshPackages.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnEditPackage
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnEditPackage.ColorFillBlend = cBlendItems2;
            this.btnEditPackage.DesignerSelected = false;
            this.btnEditPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEditPackage.ImageIndex = 0;
            this.btnEditPackage.Location = new System.Drawing.Point(116, 2);
            this.btnEditPackage.Name = "btnEditPackage";
            this.btnEditPackage.Size = new System.Drawing.Size(106, 27);
            this.btnEditPackage.TabIndex = 11663;
            this.btnEditPackage.Text = "Edit package";
            this.btnEditPackage.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnNewPackage
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNewPackage.ColorFillBlend = cBlendItems3;
            this.btnNewPackage.DesignerSelected = false;
            this.btnNewPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNewPackage.ImageIndex = 0;
            this.btnNewPackage.Location = new System.Drawing.Point(4, 2);
            this.btnNewPackage.Name = "btnNewPackage";
            this.btnNewPackage.Size = new System.Drawing.Size(106, 27);
            this.btnNewPackage.TabIndex = 11662;
            this.btnNewPackage.Text = "New Package";
            this.btnNewPackage.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ctrPackagesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrPackagesList";
            this.Size = new System.Drawing.Size(780, 455);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.TAZSearchDataGridView DGVPackageList;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TAButton btnRefreshPackages;
        private ControlLibrary.TAButton btnEditPackage;
        private ControlLibrary.TAButton btnNewPackage;
    }
}
