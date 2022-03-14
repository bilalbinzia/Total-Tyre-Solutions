namespace AppControls
{
    partial class ctrItemList
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
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems6 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems7 = new CButtonLib.cBlendItems();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdjustment = new ControlLibrary.TAButton();
            this.btnCopyItem = new ControlLibrary.TAButton();
            this.btnItemGroup = new ControlLibrary.TAButton();
            this.btnItemCatalogDetails = new ControlLibrary.TAButton();
            this.btnRefreshItems = new ControlLibrary.TAButton();
            this.btnItemNew = new ControlLibrary.TAButton();
            this.btnItemEdit = new ControlLibrary.TAButton();
            this.DGVItemList = new ControlLibrary.TAZSearchDataGridView();
            this.DGItemSaleHistory = new ControlLibrary.TAZSearchDataGridView();
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
            this.WorkingPanel.Size = new System.Drawing.Size(970, 567);
            this.WorkingPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVItemList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGItemSaleHistory, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 567);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdjustment);
            this.panel1.Controls.Add(this.btnCopyItem);
            this.panel1.Controls.Add(this.btnItemGroup);
            this.panel1.Controls.Add(this.btnItemCatalogDetails);
            this.panel1.Controls.Add(this.btnRefreshItems);
            this.panel1.Controls.Add(this.btnItemNew);
            this.panel1.Controls.Add(this.btnItemEdit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 25);
            this.panel1.TabIndex = 6;
            // 
            // btnAdjustment
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAdjustment.ColorFillBlend = cBlendItems1;
            this.btnAdjustment.DesignerSelected = false;
            this.btnAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAdjustment.ImageIndex = 0;
            this.btnAdjustment.Location = new System.Drawing.Point(419, 0);
            this.btnAdjustment.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(98, 25);
            this.btnAdjustment.TabIndex = 14;
            this.btnAdjustment.Text = "Adjustment";
            this.btnAdjustment.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnCopyItem
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCopyItem.ColorFillBlend = cBlendItems2;
            this.btnCopyItem.DesignerSelected = false;
            this.btnCopyItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCopyItem.ImageIndex = 0;
            this.btnCopyItem.Location = new System.Drawing.Point(523, 0);
            this.btnCopyItem.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCopyItem.Name = "btnCopyItem";
            this.btnCopyItem.Size = new System.Drawing.Size(80, 25);
            this.btnCopyItem.TabIndex = 13;
            this.btnCopyItem.Text = "Copy";
            this.btnCopyItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnItemGroup
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnItemGroup.ColorFillBlend = cBlendItems3;
            this.btnItemGroup.DesignerSelected = false;
            this.btnItemGroup.Enabled = false;
            this.btnItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnItemGroup.ImageIndex = 0;
            this.btnItemGroup.Location = new System.Drawing.Point(703, 0);
            this.btnItemGroup.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnItemGroup.Name = "btnItemGroup";
            this.btnItemGroup.Size = new System.Drawing.Size(98, 25);
            this.btnItemGroup.TabIndex = 12;
            this.btnItemGroup.Text = "Item Group Details";
            this.btnItemGroup.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnItemGroup.Visible = false;
            // 
            // btnItemCatalogDetails
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnItemCatalogDetails.ColorFillBlend = cBlendItems4;
            this.btnItemCatalogDetails.DesignerSelected = false;
            this.btnItemCatalogDetails.Enabled = false;
            this.btnItemCatalogDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnItemCatalogDetails.ImageIndex = 0;
            this.btnItemCatalogDetails.Location = new System.Drawing.Point(807, 0);
            this.btnItemCatalogDetails.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnItemCatalogDetails.Name = "btnItemCatalogDetails";
            this.btnItemCatalogDetails.Size = new System.Drawing.Size(54, 25);
            this.btnItemCatalogDetails.TabIndex = 11;
            this.btnItemCatalogDetails.Text = "Catalog Packages";
            this.btnItemCatalogDetails.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnItemCatalogDetails.Visible = false;
            // 
            // btnRefreshItems
            // 
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnRefreshItems.ColorFillBlend = cBlendItems5;
            this.btnRefreshItems.DesignerSelected = false;
            this.btnRefreshItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRefreshItems.ImageIndex = 0;
            this.btnRefreshItems.Location = new System.Drawing.Point(609, 0);
            this.btnRefreshItems.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnRefreshItems.Name = "btnRefreshItems";
            this.btnRefreshItems.Size = new System.Drawing.Size(88, 25);
            this.btnRefreshItems.TabIndex = 10;
            this.btnRefreshItems.Text = "Refresh";
            this.btnRefreshItems.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnItemNew
            // 
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnItemNew.ColorFillBlend = cBlendItems6;
            this.btnItemNew.DesignerSelected = false;
            this.btnItemNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnItemNew.ImageIndex = 0;
            this.btnItemNew.Location = new System.Drawing.Point(69, 0);
            this.btnItemNew.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnItemNew.Name = "btnItemNew";
            this.btnItemNew.Size = new System.Drawing.Size(80, 25);
            this.btnItemNew.TabIndex = 5;
            this.btnItemNew.Text = "New Item";
            this.btnItemNew.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnItemEdit
            // 
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnItemEdit.ColorFillBlend = cBlendItems7;
            this.btnItemEdit.DesignerSelected = false;
            this.btnItemEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnItemEdit.ImageIndex = 0;
            this.btnItemEdit.Location = new System.Drawing.Point(154, 0);
            this.btnItemEdit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.Size = new System.Drawing.Size(80, 25);
            this.btnItemEdit.TabIndex = 6;
            this.btnItemEdit.Text = "Edit Item";
            this.btnItemEdit.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // DGVItemList
            // 
            this.DGVItemList.Location = new System.Drawing.Point(3, 28);
            this.DGVItemList.Name = "DGVItemList";
            this.DGVItemList.Size = new System.Drawing.Size(960, 272);
            this.DGVItemList.TabIndex = 3;
            // 
            // DGItemSaleHistory
            // 
            this.DGItemSaleHistory.Location = new System.Drawing.Point(3, 306);
            this.DGItemSaleHistory.Name = "DGItemSaleHistory";
            this.DGItemSaleHistory.Size = new System.Drawing.Size(960, 247);
            this.DGItemSaleHistory.TabIndex = 7;
            // 
            // ctrItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrItemList";
            this.Size = new System.Drawing.Size(970, 567);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVItemList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.TAButton btnRefreshItems;
        private ControlLibrary.TAButton btnItemEdit;
        private ControlLibrary.TAButton btnItemNew;
        private ControlLibrary.TAButton btnItemCatalogDetails;
        private ControlLibrary.TAButton btnItemGroup;
        private ControlLibrary.TAZSearchDataGridView DGItemSaleHistory;
        private ControlLibrary.TAButton btnCopyItem;
        private ControlLibrary.TAButton btnAdjustment;
    }
}
