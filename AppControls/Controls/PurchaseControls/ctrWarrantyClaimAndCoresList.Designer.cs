namespace AppControls
{
    partial class ctrWarrantyClaimAndCoresList
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
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoCores = new System.Windows.Forms.RadioButton();
            this.rdoClaim = new System.Windows.Forms.RadioButton();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.chkShowAllStatuses = new System.Windows.Forms.CheckBox();
            this.btnCredit = new CButtonLib.CButton();
            this.btnVoid = new CButtonLib.CButton();
            this.btnNew = new CButtonLib.CButton();
            this.btnShip = new CButtonLib.CButton();
            this.DGVClaimAndCoresList = new ControlLibrary.TAZSearchDataGridView();
            this.btnPreviewInvoice = new CButtonLib.CButton();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tableLayoutPanel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(788, 389);
            this.WorkingPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVClaimAndCoresList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 389);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPreviewInvoice);
            this.panel1.Controls.Add(this.rdoCores);
            this.panel1.Controls.Add(this.rdoClaim);
            this.panel1.Controls.Add(this.chkShowAll);
            this.panel1.Controls.Add(this.chkShowAllStatuses);
            this.panel1.Controls.Add(this.btnCredit);
            this.panel1.Controls.Add(this.btnVoid);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnShip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 33);
            this.panel1.TabIndex = 6;
            // 
            // rdoCores
            // 
            this.rdoCores.AutoSize = true;
            this.rdoCores.Location = new System.Drawing.Point(384, 8);
            this.rdoCores.Name = "rdoCores";
            this.rdoCores.Size = new System.Drawing.Size(52, 17);
            this.rdoCores.TabIndex = 17;
            this.rdoCores.Text = "Cores";
            this.rdoCores.UseVisualStyleBackColor = true;
            // 
            // rdoClaim
            // 
            this.rdoClaim.AutoSize = true;
            this.rdoClaim.Checked = true;
            this.rdoClaim.Location = new System.Drawing.Point(314, 8);
            this.rdoClaim.Name = "rdoClaim";
            this.rdoClaim.Size = new System.Drawing.Size(55, 17);
            this.rdoClaim.TabIndex = 16;
            this.rdoClaim.TabStop = true;
            this.rdoClaim.Text = "Claims";
            this.rdoClaim.UseVisualStyleBackColor = true;
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(702, 8);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(67, 17);
            this.chkShowAll.TabIndex = 14;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            // 
            // chkShowAllStatuses
            // 
            this.chkShowAllStatuses.AutoSize = true;
            this.chkShowAllStatuses.Location = new System.Drawing.Point(586, 8);
            this.chkShowAllStatuses.Name = "chkShowAllStatuses";
            this.chkShowAllStatuses.Size = new System.Drawing.Size(110, 17);
            this.chkShowAllStatuses.TabIndex = 13;
            this.chkShowAllStatuses.Text = "Show all Statuses";
            this.chkShowAllStatuses.UseVisualStyleBackColor = true;
            // 
            // btnCredit
            // 
            this.btnCredit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCredit.ColorFillBlend = cBlendItems2;
            this.btnCredit.DesignerSelected = false;
            this.btnCredit.ImageIndex = 0;
            this.btnCredit.Location = new System.Drawing.Point(128, 4);
            this.btnCredit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(50, 25);
            this.btnCredit.TabIndex = 11;
            this.btnCredit.Text = "Credit";
            this.btnCredit.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnVoid
            // 
            this.btnVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnVoid.ColorFillBlend = cBlendItems3;
            this.btnVoid.DesignerSelected = false;
            this.btnVoid.ImageIndex = 0;
            this.btnVoid.Location = new System.Drawing.Point(183, 4);
            this.btnVoid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(50, 25);
            this.btnVoid.TabIndex = 12;
            this.btnVoid.Text = "Void";
            this.btnVoid.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNew.ColorFillBlend = cBlendItems4;
            this.btnNew.DesignerSelected = false;
            this.btnNew.ImageIndex = 0;
            this.btnNew.Location = new System.Drawing.Point(18, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnShip
            // 
            this.btnShip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnShip.ColorFillBlend = cBlendItems5;
            this.btnShip.DesignerSelected = false;
            this.btnShip.ImageIndex = 0;
            this.btnShip.Location = new System.Drawing.Point(73, 4);
            this.btnShip.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnShip.Name = "btnShip";
            this.btnShip.Size = new System.Drawing.Size(50, 25);
            this.btnShip.TabIndex = 6;
            this.btnShip.Text = "Ship";
            this.btnShip.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // DGVClaimAndCoresList
            // 
            this.DGVClaimAndCoresList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVClaimAndCoresList.Location = new System.Drawing.Point(3, 36);
            this.DGVClaimAndCoresList.Name = "DGVClaimAndCoresList";
            this.DGVClaimAndCoresList.Size = new System.Drawing.Size(782, 350);
            this.DGVClaimAndCoresList.TabIndex = 3;
            // 
            // btnPreviewInvoice
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPreviewInvoice.ColorFillBlend = cBlendItems1;
            this.btnPreviewInvoice.DesignerSelected = true;
            this.btnPreviewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPreviewInvoice.ImageIndex = 0;
            this.btnPreviewInvoice.Location = new System.Drawing.Point(449, 4);
            this.btnPreviewInvoice.Name = "btnPreviewInvoice";
            this.btnPreviewInvoice.Size = new System.Drawing.Size(100, 24);
            this.btnPreviewInvoice.TabIndex = 11666;
            this.btnPreviewInvoice.Text = "Print Invoice";
            this.btnPreviewInvoice.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ctrWarrantyClaimAndCoresList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrWarrantyClaimAndCoresList";
            this.Size = new System.Drawing.Size(788, 389);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVClaimAndCoresList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CButtonLib.CButton btnShip;
        private CButtonLib.CButton btnNew;
        private CButtonLib.CButton btnCredit;
        private CButtonLib.CButton btnVoid;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.CheckBox chkShowAllStatuses;
        private System.Windows.Forms.RadioButton rdoCores;
        private System.Windows.Forms.RadioButton rdoClaim;
        private CButtonLib.CButton btnPreviewInvoice;
        
    }
}
