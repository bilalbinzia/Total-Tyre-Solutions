namespace AppControls
{
    partial class ctrDailySaleList
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
            CButtonLib.cBlendItems cBlendItems8 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems9 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems10 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems11 = new CButtonLib.cBlendItems();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.taRadioButton1 = new ControlLibrary.TARadioButton();
            this.chkAdjustInventoryQty = new ControlLibrary.TACheckBox();
            this.btnSelect = new CButtonLib.CButton();
            this.taRadioButton3 = new ControlLibrary.TARadioButton();
            this.taRadioButton2 = new ControlLibrary.TARadioButton();
            this.btnClear = new CButtonLib.CButton();
            this.ClaimDate = new ControlLibrary.TADateControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.taButton1 = new ControlLibrary.TAButton();
            this.btnQBPost = new CButtonLib.CButton();
            this.btnQbSettings = new CButtonLib.CButton();
            this.btnPost = new CButtonLib.CButton();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.DGVDailySale = new ControlLibrary.TAZSearchDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBankSummary = new ControlLibrary.TACheckBox();
            this.chkNewCustomers = new ControlLibrary.TACheckBox();
            this.chkPaymentsBills = new ControlLibrary.TACheckBox();
            this.chkSaleRptMech = new ControlLibrary.TACheckBox();
            this.chkItemGroupSubtotals = new ControlLibrary.TACheckBox();
            this.chkItemGroupSummary = new ControlLibrary.TACheckBox();
            this.chkSaleCategories = new ControlLibrary.TACheckBox();
            this.chkSaleTransaction = new ControlLibrary.TACheckBox();
            this.btnUncheckAll = new CButtonLib.CButton();
            this.btnCheckAll = new CButtonLib.CButton();
            this.btnBrowseInvoices = new CButtonLib.CButton();
            this.btnMechanicTracking = new CButtonLib.CButton();
            this.btnAudit = new CButtonLib.CButton();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.taRadioButton1);
            this.groupBox1.Controls.Add(this.chkAdjustInventoryQty);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.taRadioButton3);
            this.groupBox1.Controls.Add(this.taRadioButton2);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.ClaimDate);
            this.groupBox1.Location = new System.Drawing.Point(17, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 137);
            this.groupBox1.TabIndex = 11717;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Report ";
            // 
            // taRadioButton1
            // 
            this.taRadioButton1.AutoSize = true;
            this.taRadioButton1.Location = new System.Drawing.Point(19, 29);
            this.taRadioButton1.Name = "taRadioButton1";
            this.taRadioButton1.Size = new System.Drawing.Size(173, 17);
            this.taRadioButton1.TabIndex = 11701;
            this.taRadioButton1.TabStop = true;
            this.taRadioButton1.Text = "Generate a new daily report for ";
            this.taRadioButton1.ToolTipText = null;
            this.taRadioButton1.UseVisualStyleBackColor = true;
            this.taRadioButton1.xBindingProperty = null;
            this.taRadioButton1.xColumnName = null;
            this.taRadioButton1.xColumnWidth = 60;
            this.taRadioButton1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taRadioButton1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taRadioButton1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taRadioButton1.xReadOnly = false;
            // 
            // chkAdjustInventoryQty
            // 
            this.chkAdjustInventoryQty.AutoSize = true;
            this.chkAdjustInventoryQty.Checked = true;
            this.chkAdjustInventoryQty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdjustInventoryQty.Enabled = false;
            this.chkAdjustInventoryQty.Location = new System.Drawing.Point(240, 54);
            this.chkAdjustInventoryQty.Name = "chkAdjustInventoryQty";
            this.chkAdjustInventoryQty.Size = new System.Drawing.Size(210, 17);
            this.chkAdjustInventoryQty.TabIndex = 11719;
            this.chkAdjustInventoryQty.Text = "Don\'t include transaction after this date";
            this.chkAdjustInventoryQty.ToolTipText = null;
            this.chkAdjustInventoryQty.UseVisualStyleBackColor = true;
            this.chkAdjustInventoryQty.xBindingProperty = null;
            this.chkAdjustInventoryQty.xColumnName = null;
            this.chkAdjustInventoryQty.xColumnWidth = 60;
            this.chkAdjustInventoryQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAdjustInventoryQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAdjustInventoryQty.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // btnSelect
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSelect.ColorFillBlend = cBlendItems1;
            this.btnSelect.DesignerSelected = false;
            this.btnSelect.FocalPoints.FocusPtX = 1F;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSelect.ImageIndex = 0;
            this.btnSelect.Location = new System.Drawing.Point(332, 97);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(116, 24);
            this.btnSelect.TabIndex = 11717;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // taRadioButton3
            // 
            this.taRadioButton3.AutoSize = true;
            this.taRadioButton3.Location = new System.Drawing.Point(19, 97);
            this.taRadioButton3.Name = "taRadioButton3";
            this.taRadioButton3.Size = new System.Drawing.Size(199, 17);
            this.taRadioButton3.TabIndex = 11703;
            this.taRadioButton3.TabStop = true;
            this.taRadioButton3.Text = "Reprint the Pre-Posting Trial Balance";
            this.taRadioButton3.ToolTipText = null;
            this.taRadioButton3.UseVisualStyleBackColor = true;
            this.taRadioButton3.xBindingProperty = null;
            this.taRadioButton3.xColumnName = null;
            this.taRadioButton3.xColumnWidth = 60;
            this.taRadioButton3.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taRadioButton3.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taRadioButton3.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taRadioButton3.xReadOnly = false;
            // 
            // taRadioButton2
            // 
            this.taRadioButton2.AutoSize = true;
            this.taRadioButton2.Location = new System.Drawing.Point(19, 62);
            this.taRadioButton2.Name = "taRadioButton2";
            this.taRadioButton2.Size = new System.Drawing.Size(162, 17);
            this.taRadioButton2.TabIndex = 11702;
            this.taRadioButton2.TabStop = true;
            this.taRadioButton2.Text = "Reprint the select daily report";
            this.taRadioButton2.ToolTipText = null;
            this.taRadioButton2.UseVisualStyleBackColor = true;
            this.taRadioButton2.xBindingProperty = null;
            this.taRadioButton2.xColumnName = null;
            this.taRadioButton2.xColumnWidth = 60;
            this.taRadioButton2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taRadioButton2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taRadioButton2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taRadioButton2.xReadOnly = false;
            // 
            // btnClear
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClear.ColorFillBlend = cBlendItems2;
            this.btnClear.DesignerSelected = false;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClear.ImageIndex = 0;
            this.btnClear.Location = new System.Drawing.Point(276, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 24);
            this.btnClear.TabIndex = 11712;
            this.btnClear.Text = "Clear";
            this.btnClear.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ClaimDate
            // 
            this.ClaimDate.Location = new System.Drawing.Point(240, 26);
            this.ClaimDate.Margin = new System.Windows.Forms.Padding(0);
            this.ClaimDate.Name = "ClaimDate";
            this.ClaimDate.Size = new System.Drawing.Size(114, 20);
            this.ClaimDate.TabIndex = 11716;
            this.ClaimDate.xBindingProperty = "PRDate";
            this.ClaimDate.xColumnName = "";
            this.ClaimDate.xColumnWidth = 60;
            this.ClaimDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.taButton1);
            this.panel1.Controls.Add(this.btnQBPost);
            this.panel1.Controls.Add(this.btnQbSettings);
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.taCheckBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.DGVDailySale);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnBrowseInvoices);
            this.panel1.Controls.Add(this.btnMechanicTracking);
            this.panel1.Controls.Add(this.btnAudit);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 492);
            this.panel1.TabIndex = 2;
            // 
            // taButton1
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.taButton1.ColorFillBlend = cBlendItems3;
            this.taButton1.DesignerSelected = false;
            this.taButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.taButton1.ImageIndex = 0;
            this.taButton1.Location = new System.Drawing.Point(551, 219);
            this.taButton1.Name = "taButton1";
            this.taButton1.Size = new System.Drawing.Size(117, 24);
            this.taButton1.TabIndex = 11662;
            this.taButton1.Text = "Open Report";
            this.taButton1.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.taButton1.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.taButton1_ClickButtonArea);
            // 
            // btnQBPost
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnQBPost.ColorFillBlend = cBlendItems4;
            this.btnQBPost.DesignerSelected = false;
            this.btnQBPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnQBPost.ImageIndex = 0;
            this.btnQBPost.Location = new System.Drawing.Point(315, 219);
            this.btnQBPost.Name = "btnQBPost";
            this.btnQBPost.Size = new System.Drawing.Size(77, 24);
            this.btnQBPost.TabIndex = 11719;
            this.btnQBPost.Text = "Post to QB";
            this.btnQBPost.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQBPost.Visible = false;
            // 
            // btnQbSettings
            // 
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnQbSettings.ColorFillBlend = cBlendItems5;
            this.btnQbSettings.DesignerSelected = true;
            this.btnQbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnQbSettings.ImageIndex = 0;
            this.btnQbSettings.Location = new System.Drawing.Point(398, 219);
            this.btnQbSettings.Name = "btnQbSettings";
            this.btnQbSettings.Size = new System.Drawing.Size(119, 24);
            this.btnQbSettings.TabIndex = 11719;
            this.btnQbSettings.Text = "QuickBook Settings";
            this.btnQbSettings.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQbSettings.Visible = false;
            // 
            // btnPost
            // 
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPost.ColorFillBlend = cBlendItems6;
            this.btnPost.DesignerSelected = false;
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPost.ImageIndex = 0;
            this.btnPost.Location = new System.Drawing.Point(204, 219);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(105, 24);
            this.btnPost.TabIndex = 11719;
            this.btnPost.Text = "Post";
            this.btnPost.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(831, 226);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.Size = new System.Drawing.Size(67, 17);
            this.taCheckBox1.TabIndex = 11718;
            this.taCheckBox1.Text = "Show All";
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = true;
            this.taCheckBox1.xBindingProperty = null;
            this.taCheckBox1.xColumnName = null;
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.CheckedChanged += new System.EventHandler(this.taCheckBox1_CheckedChanged);
            // 
            // DGVDailySale
            // 
            this.DGVDailySale.Location = new System.Drawing.Point(16, 250);
            this.DGVDailySale.Margin = new System.Windows.Forms.Padding(4);
            this.DGVDailySale.Name = "DGVDailySale";
            this.DGVDailySale.Size = new System.Drawing.Size(882, 226);
            this.DGVDailySale.TabIndex = 11714;
            this.DGVDailySale.Load += new System.EventHandler(this.DGVDailySale_Load);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkBankSummary);
            this.panel2.Controls.Add(this.chkNewCustomers);
            this.panel2.Controls.Add(this.chkPaymentsBills);
            this.panel2.Controls.Add(this.chkSaleRptMech);
            this.panel2.Controls.Add(this.chkItemGroupSubtotals);
            this.panel2.Controls.Add(this.chkItemGroupSummary);
            this.panel2.Controls.Add(this.chkSaleCategories);
            this.panel2.Controls.Add(this.chkSaleTransaction);
            this.panel2.Controls.Add(this.btnUncheckAll);
            this.panel2.Controls.Add(this.btnCheckAll);
            this.panel2.Location = new System.Drawing.Point(551, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 180);
            this.panel2.TabIndex = 11713;
            // 
            // chkBankSummary
            // 
            this.chkBankSummary.AutoSize = true;
            this.chkBankSummary.Enabled = false;
            this.chkBankSummary.Location = new System.Drawing.Point(15, 155);
            this.chkBankSummary.Name = "chkBankSummary";
            this.chkBankSummary.Size = new System.Drawing.Size(231, 17);
            this.chkBankSummary.TabIndex = 11713;
            this.chkBankSummary.Text = "Print Bank Summary (unposted reports only)";
            this.chkBankSummary.ToolTipText = null;
            this.chkBankSummary.UseVisualStyleBackColor = true;
            this.chkBankSummary.xBindingProperty = null;
            this.chkBankSummary.xColumnName = null;
            this.chkBankSummary.xColumnWidth = 60;
            this.chkBankSummary.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkBankSummary.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkBankSummary.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkNewCustomers
            // 
            this.chkNewCustomers.AutoSize = true;
            this.chkNewCustomers.Location = new System.Drawing.Point(15, 135);
            this.chkNewCustomers.Name = "chkNewCustomers";
            this.chkNewCustomers.Size = new System.Drawing.Size(132, 17);
            this.chkNewCustomers.TabIndex = 11712;
            this.chkNewCustomers.Text = "Print New Custommers";
            this.chkNewCustomers.ToolTipText = null;
            this.chkNewCustomers.UseVisualStyleBackColor = true;
            this.chkNewCustomers.xBindingProperty = null;
            this.chkNewCustomers.xColumnName = null;
            this.chkNewCustomers.xColumnWidth = 60;
            this.chkNewCustomers.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkNewCustomers.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkNewCustomers.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkPaymentsBills
            // 
            this.chkPaymentsBills.AutoSize = true;
            this.chkPaymentsBills.Location = new System.Drawing.Point(15, 115);
            this.chkPaymentsBills.Name = "chkPaymentsBills";
            this.chkPaymentsBills.Size = new System.Drawing.Size(138, 17);
            this.chkPaymentsBills.TabIndex = 11711;
            this.chkPaymentsBills.Text = "Print Payments and Bills";
            this.chkPaymentsBills.ToolTipText = null;
            this.chkPaymentsBills.UseVisualStyleBackColor = true;
            this.chkPaymentsBills.xBindingProperty = null;
            this.chkPaymentsBills.xColumnName = null;
            this.chkPaymentsBills.xColumnWidth = 60;
            this.chkPaymentsBills.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkPaymentsBills.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkPaymentsBills.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkSaleRptMech
            // 
            this.chkSaleRptMech.AutoSize = true;
            this.chkSaleRptMech.Location = new System.Drawing.Point(15, 95);
            this.chkSaleRptMech.Name = "chkSaleRptMech";
            this.chkSaleRptMech.Size = new System.Drawing.Size(180, 17);
            this.chkSaleRptMech.TabIndex = 11710;
            this.chkSaleRptMech.Text = "Print Sales Reps and Mechanics";
            this.chkSaleRptMech.ToolTipText = null;
            this.chkSaleRptMech.UseVisualStyleBackColor = true;
            this.chkSaleRptMech.xBindingProperty = null;
            this.chkSaleRptMech.xColumnName = null;
            this.chkSaleRptMech.xColumnWidth = 60;
            this.chkSaleRptMech.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkSaleRptMech.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkSaleRptMech.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkItemGroupSubtotals
            // 
            this.chkItemGroupSubtotals.AutoSize = true;
            this.chkItemGroupSubtotals.Enabled = false;
            this.chkItemGroupSubtotals.Location = new System.Drawing.Point(15, 74);
            this.chkItemGroupSubtotals.Name = "chkItemGroupSubtotals";
            this.chkItemGroupSubtotals.Size = new System.Drawing.Size(149, 17);
            this.chkItemGroupSubtotals.TabIndex = 11709;
            this.chkItemGroupSubtotals.Text = "Print Item Group Subtotals";
            this.chkItemGroupSubtotals.ToolTipText = null;
            this.chkItemGroupSubtotals.UseVisualStyleBackColor = true;
            this.chkItemGroupSubtotals.xBindingProperty = null;
            this.chkItemGroupSubtotals.xColumnName = null;
            this.chkItemGroupSubtotals.xColumnWidth = 60;
            this.chkItemGroupSubtotals.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkItemGroupSubtotals.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkItemGroupSubtotals.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkItemGroupSummary
            // 
            this.chkItemGroupSummary.AutoSize = true;
            this.chkItemGroupSummary.Location = new System.Drawing.Point(15, 53);
            this.chkItemGroupSummary.Name = "chkItemGroupSummary";
            this.chkItemGroupSummary.Size = new System.Drawing.Size(148, 17);
            this.chkItemGroupSummary.TabIndex = 11708;
            this.chkItemGroupSummary.Text = "Print Item Group Summary";
            this.chkItemGroupSummary.ToolTipText = null;
            this.chkItemGroupSummary.UseVisualStyleBackColor = true;
            this.chkItemGroupSummary.xBindingProperty = null;
            this.chkItemGroupSummary.xColumnName = null;
            this.chkItemGroupSummary.xColumnWidth = 60;
            this.chkItemGroupSummary.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkItemGroupSummary.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkItemGroupSummary.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkSaleCategories
            // 
            this.chkSaleCategories.AutoSize = true;
            this.chkSaleCategories.Enabled = false;
            this.chkSaleCategories.Location = new System.Drawing.Point(15, 32);
            this.chkSaleCategories.Name = "chkSaleCategories";
            this.chkSaleCategories.Size = new System.Drawing.Size(196, 17);
            this.chkSaleCategories.TabIndex = 11707;
            this.chkSaleCategories.Text = "Print Sales Categories and Summary";
            this.chkSaleCategories.ToolTipText = null;
            this.chkSaleCategories.UseVisualStyleBackColor = true;
            this.chkSaleCategories.xBindingProperty = null;
            this.chkSaleCategories.xColumnName = null;
            this.chkSaleCategories.xColumnWidth = 60;
            this.chkSaleCategories.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkSaleCategories.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkSaleCategories.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkSaleTransaction
            // 
            this.chkSaleTransaction.AutoSize = true;
            this.chkSaleTransaction.Location = new System.Drawing.Point(15, 11);
            this.chkSaleTransaction.Name = "chkSaleTransaction";
            this.chkSaleTransaction.Size = new System.Drawing.Size(140, 17);
            this.chkSaleTransaction.TabIndex = 11706;
            this.chkSaleTransaction.Text = "Print Sales Transactions";
            this.chkSaleTransaction.ToolTipText = null;
            this.chkSaleTransaction.UseVisualStyleBackColor = true;
            this.chkSaleTransaction.xBindingProperty = null;
            this.chkSaleTransaction.xColumnName = null;
            this.chkSaleTransaction.xColumnWidth = 60;
            this.chkSaleTransaction.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkSaleTransaction.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkSaleTransaction.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // btnUncheckAll
            // 
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnUncheckAll.ColorFillBlend = cBlendItems7;
            this.btnUncheckAll.DesignerSelected = false;
            this.btnUncheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUncheckAll.ImageIndex = 0;
            this.btnUncheckAll.Location = new System.Drawing.Point(239, 50);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(85, 24);
            this.btnUncheckAll.TabIndex = 11705;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnCheckAll
            // 
            cBlendItems8.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems8.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCheckAll.ColorFillBlend = cBlendItems8;
            this.btnCheckAll.DesignerSelected = false;
            this.btnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCheckAll.ImageIndex = 0;
            this.btnCheckAll.Location = new System.Drawing.Point(239, 11);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(85, 24);
            this.btnCheckAll.TabIndex = 11704;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBrowseInvoices
            // 
            cBlendItems9.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems9.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBrowseInvoices.ColorFillBlend = cBlendItems9;
            this.btnBrowseInvoices.DesignerSelected = false;
            this.btnBrowseInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBrowseInvoices.ImageIndex = 0;
            this.btnBrowseInvoices.Location = new System.Drawing.Point(91, 219);
            this.btnBrowseInvoices.Name = "btnBrowseInvoices";
            this.btnBrowseInvoices.Size = new System.Drawing.Size(107, 24);
            this.btnBrowseInvoices.TabIndex = 11709;
            this.btnBrowseInvoices.Text = "Browse Invoices";
            this.btnBrowseInvoices.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnMechanicTracking
            // 
            cBlendItems10.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems10.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnMechanicTracking.ColorFillBlend = cBlendItems10;
            this.btnMechanicTracking.DesignerSelected = false;
            this.btnMechanicTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnMechanicTracking.ImageIndex = 0;
            this.btnMechanicTracking.Location = new System.Drawing.Point(674, 219);
            this.btnMechanicTracking.Name = "btnMechanicTracking";
            this.btnMechanicTracking.Size = new System.Drawing.Size(151, 24);
            this.btnMechanicTracking.TabIndex = 11708;
            this.btnMechanicTracking.Text = "Mechanic Tracking";
            this.btnMechanicTracking.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnAudit
            // 
            cBlendItems11.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems11.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAudit.ColorFillBlend = cBlendItems11;
            this.btnAudit.DesignerSelected = false;
            this.btnAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAudit.ImageIndex = 0;
            this.btnAudit.Location = new System.Drawing.Point(16, 219);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(69, 24);
            this.btnAudit.TabIndex = 11707;
            this.btnAudit.Text = "Audit";
            this.btnAudit.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(298, 20);
            this.label11.TabIndex = 11700;
            this.label11.Text = "Report(s) need to posted to QuickBooks.";
            // 
            // ctrDailySaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrDailySaleList";
            this.Size = new System.Drawing.Size(919, 492);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CButtonLib.CButton btnSelect;
        private CButtonLib.CButton btnPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private ControlLibrary.TARadioButton taRadioButton1;
        private ControlLibrary.TACheckBox chkAdjustInventoryQty;
        private ControlLibrary.TARadioButton taRadioButton3;
        private ControlLibrary.TARadioButton taRadioButton2;
        public ControlLibrary.TAZSearchDataGridView DGVDailySale;
        private CButtonLib.CButton btnClear;
        private CButtonLib.CButton btnBrowseInvoices;
        private CButtonLib.CButton btnAudit;
        public System.Windows.Forms.Panel panel1;
        private ControlLibrary.TACheckBox taCheckBox1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TACheckBox chkBankSummary;
        private ControlLibrary.TACheckBox chkNewCustomers;
        private ControlLibrary.TACheckBox chkPaymentsBills;
        private ControlLibrary.TACheckBox chkSaleRptMech;
        private ControlLibrary.TACheckBox chkItemGroupSubtotals;
        private ControlLibrary.TACheckBox chkItemGroupSummary;
        private ControlLibrary.TACheckBox chkSaleCategories;
        private ControlLibrary.TACheckBox chkSaleTransaction;
        private CButtonLib.CButton btnUncheckAll;
        private CButtonLib.CButton btnCheckAll;
        private System.Windows.Forms.Label label11;
        protected ControlLibrary.TADateControl ClaimDate;
        private CButtonLib.CButton btnMechanicTracking;
        private ControlLibrary.TAButton taButton1;
        private CButtonLib.CButton btnQbSettings;
        private CButtonLib.CButton btnQBPost;
    }
}
