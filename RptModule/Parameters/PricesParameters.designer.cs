namespace RptModule.PricesParameters
{
    partial class PricesParameters
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
            this.btnLoadReport = new ControlLibrary.TAButton();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTo = new ControlLibrary.TADateControl();
            this.DateFrom = new ControlLibrary.TADateControl();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.AccountTo = new ControlLibrary.MultiColumnComboBox();
            this.lblLedgerTo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.chkAllCustomer = new ControlLibrary.TACheckBox();
            this.chkAllCatalog = new ControlLibrary.TACheckBox();
            this.cboCatalogFrom = new System.Windows.Forms.ComboBox();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.lblCatalogFrom = new System.Windows.Forms.Label();
            this.lblCatalogTo = new System.Windows.Forms.Label();
            this.cboCatalogTo = new System.Windows.Forms.ComboBox();
            this.chkAllSize = new ControlLibrary.TACheckBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSizeFrom = new ControlLibrary.TATextBox();
            this.txtSizeTo = new ControlLibrary.TATextBox();
            this.lblSizeFrom = new System.Windows.Forms.Label();
            this.lblSizeTo = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.cboItemType = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.lblItemGroups = new System.Windows.Forms.Label();
            this.cboItemGroups = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnLoadReport.ColorFillBlend = cBlendItems1;
            this.btnLoadReport.DesignerSelected = false;
            this.btnLoadReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadReport.ImageIndex = 0;
            this.btnLoadReport.Location = new System.Drawing.Point(169, 129);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(75, 23);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Load Report";
            this.btnLoadReport.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(136, 566);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.Size = new System.Drawing.Size(90, 17);
            this.taCheckBox1.TabIndex = 1;
            this.taCheckBox1.Text = "taCheckBox1";
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = true;
            this.taCheckBox1.Visible = false;
            this.taCheckBox1.xBindingProperty = null;
            this.taCheckBox1.xColumnName = null;
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // taTextBox1
            // 
            this.taTextBox1.Location = new System.Drawing.Point(52, 540);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(100, 20);
            this.taTextBox1.TabIndex = 4;
            this.taTextBox1.Visible = false;
            this.taTextBox1.xBindingProperty = null;
            this.taTextBox1.xColumnName = null;
            this.taTextBox1.xColumnWidth = 60;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // DateTo
            // 
            this.DateTo.Location = new System.Drawing.Point(79, 85);
            this.DateTo.Margin = new System.Windows.Forms.Padding(0);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(165, 21);
            this.DateTo.TabIndex = 10;
            this.DateTo.Visible = false;
            this.DateTo.xBindingProperty = null;
            this.DateTo.xColumnName = null;
            this.DateTo.xColumnWidth = 60;
            this.DateTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // DateFrom
            // 
            this.DateFrom.Location = new System.Drawing.Point(79, 60);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(165, 21);
            this.DateFrom.TabIndex = 9;
            this.DateFrom.Visible = false;
            this.DateFrom.xBindingProperty = null;
            this.DateFrom.xColumnName = null;
            this.DateFrom.xColumnWidth = 60;
            this.DateFrom.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsRequired = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(25, 89);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(49, 13);
            this.lblDateTo.TabIndex = 12;
            this.lblDateTo.Text = "Date To:";
            this.lblDateTo.Visible = false;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(15, 64);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDateFrom.TabIndex = 11;
            this.lblDateFrom.Text = "Date From:";
            this.lblDateFrom.Visible = false;
            // 
            // cboCriteria
            // 
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This Week",
            "This Month",
            "This Calender Year",
            "This Financial Year",
            "Last Week",
            "Last Month",
            "Last Calender Year",
            "Last Financial Year",
            "Custom"});
            this.cboCriteria.Location = new System.Drawing.Point(22, 36);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(222, 21);
            this.cboCriteria.TabIndex = 8;
            this.cboCriteria.Visible = false;
            // 
            // AccountTo
            // 
            this.AccountTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AccountTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AccountTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AccountTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTo.DropDownWidth = 228;
            this.AccountTo.FormattingEnabled = true;
            this.AccountTo.Location = new System.Drawing.Point(98, 513);
            this.AccountTo.Name = "AccountTo";
            this.AccountTo.Size = new System.Drawing.Size(128, 21);
            this.AccountTo.TabIndex = 14;
            this.AccountTo.Visible = false;
            this.AccountTo.xBindingProperty = null;
            this.AccountTo.xBindingQuery = null;
            this.AccountTo.xColumnName = null;
            this.AccountTo.xColumns = null;
            this.AccountTo.xColumnWidth = 60;
            this.AccountTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.AccountTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.AccountTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.AccountTo.xOrderBy = null;
            this.AccountTo.xTableName = null;
            // 
            // lblLedgerTo
            // 
            this.lblLedgerTo.AutoSize = true;
            this.lblLedgerTo.Location = new System.Drawing.Point(19, 517);
            this.lblLedgerTo.Name = "lblLedgerTo";
            this.lblLedgerTo.Size = new System.Drawing.Size(66, 13);
            this.lblLedgerTo.TabIndex = 16;
            this.lblLedgerTo.Text = "Account To:";
            this.lblLedgerTo.Visible = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(51, 475);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 15;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.Visible = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(48, 493);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(174, 21);
            this.cboCustomer.TabIndex = 20;
            this.cboCustomer.Visible = false;
            // 
            // chkAllCustomer
            // 
            this.chkAllCustomer.AutoSize = true;
            this.chkAllCustomer.Location = new System.Drawing.Point(111, 473);
            this.chkAllCustomer.Name = "chkAllCustomer";
            this.chkAllCustomer.Size = new System.Drawing.Size(84, 17);
            this.chkAllCustomer.TabIndex = 22;
            this.chkAllCustomer.Text = "All Customer";
            this.chkAllCustomer.ToolTipText = null;
            this.chkAllCustomer.UseVisualStyleBackColor = true;
            this.chkAllCustomer.Visible = false;
            this.chkAllCustomer.xBindingProperty = null;
            this.chkAllCustomer.xColumnName = null;
            this.chkAllCustomer.xColumnWidth = 60;
            this.chkAllCustomer.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAllCustomer.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAllCustomer.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkAllCatalog
            // 
            this.chkAllCatalog.AutoSize = true;
            this.chkAllCatalog.Location = new System.Drawing.Point(163, 172);
            this.chkAllCatalog.Name = "chkAllCatalog";
            this.chkAllCatalog.Size = new System.Drawing.Size(76, 17);
            this.chkAllCatalog.TabIndex = 25;
            this.chkAllCatalog.Text = "All Catalog";
            this.chkAllCatalog.ToolTipText = null;
            this.chkAllCatalog.UseVisualStyleBackColor = true;
            this.chkAllCatalog.Visible = false;
            this.chkAllCatalog.xBindingProperty = null;
            this.chkAllCatalog.xColumnName = null;
            this.chkAllCatalog.xColumnWidth = 60;
            this.chkAllCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAllCatalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAllCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.chkAllCatalog.CheckedChanged += new System.EventHandler(this.chkAllCatalog_CheckedChanged);
            // 
            // cboCatalogFrom
            // 
            this.cboCatalogFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCatalogFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCatalogFrom.FormattingEnabled = true;
            this.cboCatalogFrom.Location = new System.Drawing.Point(78, 194);
            this.cboCatalogFrom.Name = "cboCatalogFrom";
            this.cboCatalogFrom.Size = new System.Drawing.Size(165, 21);
            this.cboCatalogFrom.TabIndex = 24;
            this.cboCatalogFrom.Visible = false;
            
            this.cboCatalogFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCatalogFrom_KeyPress);
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(113, 172);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(46, 13);
            this.lblCatalog.TabIndex = 23;
            this.lblCatalog.Text = "Catalog:";
            this.lblCatalog.Visible = false;
            
            // 
            // lblCatalogFrom
            // 
            this.lblCatalogFrom.AutoSize = true;
            this.lblCatalogFrom.Location = new System.Drawing.Point(1, 198);
            this.lblCatalogFrom.Name = "lblCatalogFrom";
            this.lblCatalogFrom.Size = new System.Drawing.Size(72, 13);
            this.lblCatalogFrom.TabIndex = 26;
            this.lblCatalogFrom.Text = "Catalog From:";
            this.lblCatalogFrom.Visible = false;
            
            // 
            // lblCatalogTo
            // 
            this.lblCatalogTo.AutoSize = true;
            this.lblCatalogTo.Location = new System.Drawing.Point(11, 226);
            this.lblCatalogTo.Name = "lblCatalogTo";
            this.lblCatalogTo.Size = new System.Drawing.Size(62, 13);
            this.lblCatalogTo.TabIndex = 28;
            this.lblCatalogTo.Text = "Catalog To:";
            this.lblCatalogTo.Visible = false;
            
            // 
            // cboCatalogTo
            // 
            this.cboCatalogTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCatalogTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCatalogTo.FormattingEnabled = true;
            this.cboCatalogTo.Location = new System.Drawing.Point(78, 222);
            this.cboCatalogTo.Name = "cboCatalogTo";
            this.cboCatalogTo.Size = new System.Drawing.Size(165, 21);
            this.cboCatalogTo.TabIndex = 27;
            this.cboCatalogTo.Visible = false;
            
            this.cboCatalogTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCatalogTo_KeyPress);
            // 
            // chkAllSize
            // 
            this.chkAllSize.AutoSize = true;
            this.chkAllSize.Location = new System.Drawing.Point(178, 249);
            this.chkAllSize.Name = "chkAllSize";
            this.chkAllSize.Size = new System.Drawing.Size(60, 17);
            this.chkAllSize.TabIndex = 30;
            this.chkAllSize.Text = "All Size";
            this.chkAllSize.ToolTipText = null;
            this.chkAllSize.UseVisualStyleBackColor = true;
            this.chkAllSize.Visible = false;
            this.chkAllSize.xBindingProperty = null;
            this.chkAllSize.xColumnName = null;
            this.chkAllSize.xColumnWidth = 60;
            this.chkAllSize.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAllSize.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAllSize.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.chkAllSize.CheckedChanged += new System.EventHandler(this.chkAllSize_CheckedChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(129, 250);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 29;
            this.lblSize.Text = "Size:";
            this.lblSize.Visible = false;
            
            // 
            // txtSizeFrom
            // 
            this.txtSizeFrom.Location = new System.Drawing.Point(78, 272);
            this.txtSizeFrom.Name = "txtSizeFrom";
            this.txtSizeFrom.Size = new System.Drawing.Size(165, 20);
            this.txtSizeFrom.TabIndex = 31;
            this.txtSizeFrom.Visible = false;
            this.txtSizeFrom.xBindingProperty = null;
            this.txtSizeFrom.xColumnName = null;
            this.txtSizeFrom.xColumnWidth = 60;
            this.txtSizeFrom.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtSizeFrom.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtSizeFrom.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtSizeFrom.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtSizeFrom.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtSizeFrom.xMasked = System32.StaticInfo.Mask.None;
            this.txtSizeFrom.xReadOnly = false;
            
            // 
            // txtSizeTo
            // 
            this.txtSizeTo.Location = new System.Drawing.Point(78, 298);
            this.txtSizeTo.Name = "txtSizeTo";
            this.txtSizeTo.Size = new System.Drawing.Size(165, 20);
            this.txtSizeTo.TabIndex = 32;
            this.txtSizeTo.Visible = false;
            this.txtSizeTo.xBindingProperty = null;
            this.txtSizeTo.xColumnName = null;
            this.txtSizeTo.xColumnWidth = 60;
            this.txtSizeTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtSizeTo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtSizeTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtSizeTo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtSizeTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtSizeTo.xMasked = System32.StaticInfo.Mask.None;
            this.txtSizeTo.xReadOnly = false;
            
            // 
            // lblSizeFrom
            // 
            this.lblSizeFrom.AutoSize = true;
            this.lblSizeFrom.Location = new System.Drawing.Point(17, 275);
            this.lblSizeFrom.Name = "lblSizeFrom";
            this.lblSizeFrom.Size = new System.Drawing.Size(56, 13);
            this.lblSizeFrom.TabIndex = 33;
            this.lblSizeFrom.Text = "Size From:";
            this.lblSizeFrom.Visible = false;
            
            // 
            // lblSizeTo
            // 
            this.lblSizeTo.AutoSize = true;
            this.lblSizeTo.Location = new System.Drawing.Point(27, 302);
            this.lblSizeTo.Name = "lblSizeTo";
            this.lblSizeTo.Size = new System.Drawing.Size(46, 13);
            this.lblSizeTo.TabIndex = 34;
            this.lblSizeTo.Text = "Size To:";
            this.lblSizeTo.Visible = false;
            
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(19, 328);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(54, 13);
            this.lblItemType.TabIndex = 36;
            this.lblItemType.Text = "Item Type";
            this.lblItemType.Visible = false;
            
            // 
            // cboItemType
            // 
            this.cboItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(78, 324);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(165, 21);
            this.cboItemType.TabIndex = 35;
            this.cboItemType.Visible = false;
            
            this.cboItemType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboItemType_KeyPress);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(32, 355);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 38;
            this.lblVendor.Text = "Vendor";
            this.lblVendor.Visible = false;
            
            // 
            // cboVendor
            // 
            this.cboVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(78, 351);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(165, 21);
            this.cboVendor.TabIndex = 37;
            this.cboVendor.Visible = false;
            
            this.cboVendor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboVendor_KeyPress);
            // 
            // lblItemGroups
            // 
            this.lblItemGroups.AutoSize = true;
            this.lblItemGroups.Location = new System.Drawing.Point(9, 382);
            this.lblItemGroups.Name = "lblItemGroups";
            this.lblItemGroups.Size = new System.Drawing.Size(64, 13);
            this.lblItemGroups.TabIndex = 40;
            this.lblItemGroups.Text = "Item Groups";
            this.lblItemGroups.Visible = false;
            
            // 
            // cboItemGroups
            // 
            this.cboItemGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemGroups.FormattingEnabled = true;
            this.cboItemGroups.Location = new System.Drawing.Point(78, 378);
            this.cboItemGroups.Name = "cboItemGroups";
            this.cboItemGroups.Size = new System.Drawing.Size(165, 21);
            this.cboItemGroups.TabIndex = 39;
            this.cboItemGroups.Visible = false;
            
            this.cboItemGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboItemGroups_KeyPress);
            // 
            // PricesParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblItemGroups);
            this.Controls.Add(this.cboItemGroups);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.cboVendor);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.cboItemType);
            this.Controls.Add(this.lblSizeTo);
            this.Controls.Add(this.lblSizeFrom);
            this.Controls.Add(this.txtSizeTo);
            this.Controls.Add(this.txtSizeFrom);
            this.Controls.Add(this.chkAllSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblCatalogTo);
            this.Controls.Add(this.cboCatalogTo);
            this.Controls.Add(this.lblCatalogFrom);
            this.Controls.Add(this.chkAllCatalog);
            this.Controls.Add(this.cboCatalogFrom);
            this.Controls.Add(this.lblCatalog);
            this.Controls.Add(this.chkAllCustomer);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.AccountTo);
            this.Controls.Add(this.lblLedgerTo);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.cboCriteria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taTextBox1);
            this.Controls.Add(this.taCheckBox1);
            this.Controls.Add(this.btnLoadReport);
            this.Name = "PricesParameters";
            this.Size = new System.Drawing.Size(254, 602);
            this.Load += new System.EventHandler(this.ValueParameters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public ControlLibrary.TADateControl DateTo;
        public ControlLibrary.TADateControl DateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        public ControlLibrary.MultiColumnComboBox AccountTo;
        private System.Windows.Forms.Label lblLedgerTo;
        private System.Windows.Forms.Label lblCustomer;
        public ControlLibrary.TAButton btnLoadReport;
        public ControlLibrary.TACheckBox taCheckBox1;
        public ControlLibrary.TATextBox taTextBox1;
        public System.Windows.Forms.ComboBox cboCriteria;
        public System.Windows.Forms.ComboBox cboCustomer;
        public ControlLibrary.TACheckBox chkAllCustomer;
        public ControlLibrary.TACheckBox chkAllCatalog;
        public System.Windows.Forms.ComboBox cboCatalogFrom;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Label lblCatalogFrom;
        private System.Windows.Forms.Label lblCatalogTo;
        public System.Windows.Forms.ComboBox cboCatalogTo;
        public ControlLibrary.TACheckBox chkAllSize;
        private System.Windows.Forms.Label lblSize;
        public ControlLibrary.TATextBox txtSizeFrom;
        public ControlLibrary.TATextBox txtSizeTo;
        private System.Windows.Forms.Label lblSizeFrom;
        private System.Windows.Forms.Label lblSizeTo;
        private System.Windows.Forms.Label lblItemType;
        public System.Windows.Forms.ComboBox cboItemType;
        private System.Windows.Forms.Label lblVendor;
        public System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Label lblItemGroups;
        public System.Windows.Forms.ComboBox cboItemGroups;
    }
}
