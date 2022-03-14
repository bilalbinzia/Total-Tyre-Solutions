namespace AppControls
{
    partial class ctrVendorPaymentList
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
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems6 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems7 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems8 = new CButtonLib.cBlendItems();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrintPayment = new ControlLibrary.TAButton();
            this.taCheckBox2 = new ControlLibrary.TACheckBox();
            this.txtBoxOpenAmount = new ControlLibrary.TATextBox();
            this.btnVoidTransactions = new ControlLibrary.TAButton();
            this.btnUpdateOpenAmount = new ControlLibrary.TAButton();
            this.DGVVendorList = new ControlLibrary.TAZSearchDataGridView();
            this.DGVVendorBillList = new ControlLibrary.TAZSearchDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBillBatches = new ControlLibrary.TAButton();
            this.chkboxShowBills = new ControlLibrary.TACheckBox();
            this.chkboxShowAll = new ControlLibrary.TACheckBox();
            this.btnNewVendorBill = new ControlLibrary.TAButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAutoSelect = new ControlLibrary.TAButton();
            this.btnClearSelected = new ControlLibrary.TAButton();
            this.chkboxShowClosedTransactions = new ControlLibrary.TACheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalToPay = new ControlLibrary.TATextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTotalDiscount = new ControlLibrary.TATextBox();
            this.txtTotalApplied = new ControlLibrary.TATextBox();
            this.btnProceedPayment = new ControlLibrary.TAButton();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tableLayoutPanel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(1120, 597);
            this.WorkingPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DGVVendorList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVVendorBillList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.8896F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.1104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 597);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 220);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 28);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.87956F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.109489F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.51095F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.23723F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.835766F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.33577F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Controls.Add(this.btnPrintPayment, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.taCheckBox2, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtBoxOpenAmount, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnVoidTransactions, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnUpdateOpenAmount, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1120, 28);
            this.tableLayoutPanel3.TabIndex = 11569;
            // 
            // btnPrintPayment
            // 
            this.btnPrintPayment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPrintPayment.ColorFillBlend = cBlendItems1;
            this.btnPrintPayment.DesignerSelected = false;
            this.btnPrintPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPrintPayment.ImageIndex = 0;
            this.btnPrintPayment.Location = new System.Drawing.Point(239, 1);
            this.btnPrintPayment.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintPayment.Name = "btnPrintPayment";
            this.btnPrintPayment.Size = new System.Drawing.Size(90, 25);
            this.btnPrintPayment.TabIndex = 10;
            this.btnPrintPayment.Text = "Print Bill";
            this.btnPrintPayment.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // taCheckBox2
            // 
            this.taCheckBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.taCheckBox2.AutoSize = true;
            this.taCheckBox2.Location = new System.Drawing.Point(977, 5);
            this.taCheckBox2.Margin = new System.Windows.Forms.Padding(0);
            this.taCheckBox2.Name = "taCheckBox2";
            this.taCheckBox2.Size = new System.Drawing.Size(67, 17);
            this.taCheckBox2.TabIndex = 12;
            this.taCheckBox2.Text = "Show All";
            this.taCheckBox2.ToolTipText = null;
            this.taCheckBox2.UseVisualStyleBackColor = true;
            this.taCheckBox2.Visible = false;
            this.taCheckBox2.xBindingProperty = null;
            this.taCheckBox2.xColumnName = null;
            this.taCheckBox2.xColumnWidth = 60;
            this.taCheckBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // txtBoxOpenAmount
            // 
            this.txtBoxOpenAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBoxOpenAmount.Location = new System.Drawing.Point(783, 4);
            this.txtBoxOpenAmount.Margin = new System.Windows.Forms.Padding(0);
            this.txtBoxOpenAmount.MaxLength = 150;
            this.txtBoxOpenAmount.Name = "txtBoxOpenAmount";
            this.txtBoxOpenAmount.Size = new System.Drawing.Size(130, 20);
            this.txtBoxOpenAmount.TabIndex = 11568;
            this.txtBoxOpenAmount.Visible = false;
            this.txtBoxOpenAmount.xBindingProperty = "";
            this.txtBoxOpenAmount.xColumnName = "";
            this.txtBoxOpenAmount.xColumnWidth = 80;
            this.txtBoxOpenAmount.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxOpenAmount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxOpenAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBoxOpenAmount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtBoxOpenAmount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxOpenAmount.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtBoxOpenAmount.xReadOnly = false;
            // 
            // btnVoidTransactions
            // 
            this.btnVoidTransactions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnVoidTransactions.ColorFillBlend = cBlendItems2;
            this.btnVoidTransactions.DesignerSelected = false;
            this.btnVoidTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVoidTransactions.ImageIndex = 0;
            this.btnVoidTransactions.Location = new System.Drawing.Point(386, 1);
            this.btnVoidTransactions.Margin = new System.Windows.Forms.Padding(0);
            this.btnVoidTransactions.Name = "btnVoidTransactions";
            this.btnVoidTransactions.Size = new System.Drawing.Size(146, 25);
            this.btnVoidTransactions.TabIndex = 10;
            this.btnVoidTransactions.Text = "Void Transactions";
            this.btnVoidTransactions.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnUpdateOpenAmount
            // 
            this.btnUpdateOpenAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnUpdateOpenAmount.ColorFillBlend = cBlendItems3;
            this.btnUpdateOpenAmount.DesignerSelected = false;
            this.btnUpdateOpenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdateOpenAmount.ImageIndex = 0;
            this.btnUpdateOpenAmount.Location = new System.Drawing.Point(559, 1);
            this.btnUpdateOpenAmount.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateOpenAmount.Name = "btnUpdateOpenAmount";
            this.btnUpdateOpenAmount.Size = new System.Drawing.Size(153, 25);
            this.btnUpdateOpenAmount.TabIndex = 11;
            this.btnUpdateOpenAmount.Text = "Update Open Amount";
            this.btnUpdateOpenAmount.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateOpenAmount.Visible = false;
            // 
            // DGVVendorList
            // 
            this.DGVVendorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorList.Location = new System.Drawing.Point(0, 27);
            this.DGVVendorList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVVendorList.Name = "DGVVendorList";
            this.DGVVendorList.Size = new System.Drawing.Size(1120, 193);
            this.DGVVendorList.TabIndex = 3;
            // 
            // DGVVendorBillList
            // 
            this.DGVVendorBillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorBillList.Location = new System.Drawing.Point(4, 252);
            this.DGVVendorBillList.Margin = new System.Windows.Forms.Padding(4);
            this.DGVVendorBillList.Name = "DGVVendorBillList";
            this.DGVVendorBillList.Size = new System.Drawing.Size(1112, 248);
            this.DGVVendorBillList.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 27);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.54002F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.89682F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.89682F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.108F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.btnBillBatches, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkboxShowBills, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkboxShowAll, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNewVendorBill, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1120, 27);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // btnBillBatches
            // 
            this.btnBillBatches.Anchor = System.Windows.Forms.AnchorStyles.Right;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBillBatches.ColorFillBlend = cBlendItems4;
            this.btnBillBatches.DesignerSelected = false;
            this.btnBillBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBillBatches.ImageIndex = 0;
            this.btnBillBatches.Location = new System.Drawing.Point(373, 1);
            this.btnBillBatches.Margin = new System.Windows.Forms.Padding(0);
            this.btnBillBatches.Name = "btnBillBatches";
            this.btnBillBatches.Size = new System.Drawing.Size(101, 25);
            this.btnBillBatches.TabIndex = 14;
            this.btnBillBatches.Text = "  Batches";
            this.btnBillBatches.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBillBatches.Visible = false;
            // 
            // chkboxShowBills
            // 
            this.chkboxShowBills.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowBills.AutoSize = true;
            this.chkboxShowBills.Location = new System.Drawing.Point(474, 5);
            this.chkboxShowBills.Margin = new System.Windows.Forms.Padding(0);
            this.chkboxShowBills.Name = "chkboxShowBills";
            this.chkboxShowBills.Size = new System.Drawing.Size(74, 17);
            this.chkboxShowBills.TabIndex = 15;
            this.chkboxShowBills.Text = "Show Bills";
            this.chkboxShowBills.ToolTipText = null;
            this.chkboxShowBills.UseVisualStyleBackColor = true;
            this.chkboxShowBills.Visible = false;
            this.chkboxShowBills.xBindingProperty = null;
            this.chkboxShowBills.xColumnName = null;
            this.chkboxShowBills.xColumnWidth = 60;
            this.chkboxShowBills.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkboxShowBills.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkboxShowBills.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // chkboxShowAll
            // 
            this.chkboxShowAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowAll.AutoSize = true;
            this.chkboxShowAll.Location = new System.Drawing.Point(744, 5);
            this.chkboxShowAll.Margin = new System.Windows.Forms.Padding(0);
            this.chkboxShowAll.Name = "chkboxShowAll";
            this.chkboxShowAll.Size = new System.Drawing.Size(67, 17);
            this.chkboxShowAll.TabIndex = 13;
            this.chkboxShowAll.Text = "Show All";
            this.chkboxShowAll.ToolTipText = null;
            this.chkboxShowAll.UseVisualStyleBackColor = true;
            this.chkboxShowAll.Visible = false;
            this.chkboxShowAll.xBindingProperty = null;
            this.chkboxShowAll.xColumnName = null;
            this.chkboxShowAll.xColumnWidth = 60;
            this.chkboxShowAll.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkboxShowAll.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkboxShowAll.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // btnNewVendorBill
            // 
            this.btnNewVendorBill.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNewVendorBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNewVendorBill.ColorFillBlend = cBlendItems5;
            this.btnNewVendorBill.DesignerSelected = false;
            this.btnNewVendorBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNewVendorBill.ImageIndex = 0;
            this.btnNewVendorBill.Location = new System.Drawing.Point(151, 1);
            this.btnNewVendorBill.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewVendorBill.Name = "btnNewVendorBill";
            this.btnNewVendorBill.Size = new System.Drawing.Size(79, 25);
            this.btnNewVendorBill.TabIndex = 9;
            this.btnNewVendorBill.Text = "  New Bill";
            this.btnNewVendorBill.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 66);
            this.panel3.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 8;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.06025F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.98154F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.56463F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00972F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.482993F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.51837F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.093185F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.06073F));
            this.tableLayoutPanel5.Controls.Add(this.btnAutoSelect, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnClearSelected, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.chkboxShowClosedTransactions, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalToPay, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label19, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label20, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalDiscount, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalApplied, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnProceedPayment, 7, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.42857F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1112, 64);
            this.tableLayoutPanel5.TabIndex = 11624;
            // 
            // btnAutoSelect
            // 
            this.btnAutoSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAutoSelect.ColorFillBlend = cBlendItems6;
            this.btnAutoSelect.DesignerSelected = false;
            this.btnAutoSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAutoSelect.ImageIndex = 0;
            this.btnAutoSelect.Location = new System.Drawing.Point(137, 21);
            this.btnAutoSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSelect.Name = "btnAutoSelect";
            this.btnAutoSelect.Size = new System.Drawing.Size(108, 22);
            this.btnAutoSelect.TabIndex = 11621;
            this.btnAutoSelect.Text = "Auto Select";
            this.btnAutoSelect.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAutoSelect.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnAutoSelect_ClickButtonArea);
            // 
            // btnClearSelected
            // 
            this.btnClearSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClearSelected.ColorFillBlend = cBlendItems7;
            this.btnClearSelected.DesignerSelected = false;
            this.btnClearSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearSelected.ImageIndex = 0;
            this.btnClearSelected.Location = new System.Drawing.Point(245, 21);
            this.btnClearSelected.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearSelected.Name = "btnClearSelected";
            this.btnClearSelected.Size = new System.Drawing.Size(108, 22);
            this.btnClearSelected.TabIndex = 11622;
            this.btnClearSelected.Text = "Clear Selected";
            this.btnClearSelected.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearSelected.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnClearSelected_ClickButtonArea);
            // 
            // chkboxShowClosedTransactions
            // 
            this.chkboxShowClosedTransactions.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkboxShowClosedTransactions.AutoSize = true;
            this.chkboxShowClosedTransactions.Location = new System.Drawing.Point(90, 46);
            this.chkboxShowClosedTransactions.Name = "chkboxShowClosedTransactions";
            this.chkboxShowClosedTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkboxShowClosedTransactions.Size = new System.Drawing.Size(152, 15);
            this.chkboxShowClosedTransactions.TabIndex = 11620;
            this.chkboxShowClosedTransactions.Text = "Show Closed Transactions";
            this.chkboxShowClosedTransactions.ToolTipText = null;
            this.chkboxShowClosedTransactions.UseVisualStyleBackColor = true;
            this.chkboxShowClosedTransactions.xBindingProperty = null;
            this.chkboxShowClosedTransactions.xColumnName = null;
            this.chkboxShowClosedTransactions.xColumnWidth = 60;
            this.chkboxShowClosedTransactions.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkboxShowClosedTransactions.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkboxShowClosedTransactions.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(416, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 11607;
            this.label14.Text = "Total to Pay";
            // 
            // txtTotalToPay
            // 
            this.txtTotalToPay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalToPay.BackColor = System.Drawing.Color.White;
            this.txtTotalToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalToPay.Location = new System.Drawing.Point(498, 3);
            this.txtTotalToPay.MaxLength = 150;
            this.txtTotalToPay.Name = "txtTotalToPay";
            this.txtTotalToPay.Size = new System.Drawing.Size(76, 20);
            this.txtTotalToPay.TabIndex = 11608;
            this.txtTotalToPay.xBindingProperty = "";
            this.txtTotalToPay.xColumnName = "";
            this.txtTotalToPay.xColumnWidth = 60;
            this.txtTotalToPay.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtTotalToPay.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalToPay.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalToPay.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalToPay.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalToPay.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalToPay.xReadOnly = false;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(402, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 11604;
            this.label19.Text = "Total Discount";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(410, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 13);
            this.label20.TabIndex = 11606;
            this.label20.Text = "Total Applied";
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalDiscount.BackColor = System.Drawing.Color.White;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.Location = new System.Drawing.Point(498, 24);
            this.txtTotalDiscount.MaxLength = 150;
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.ReadOnly = true;
            this.txtTotalDiscount.Size = new System.Drawing.Size(76, 20);
            this.txtTotalDiscount.TabIndex = 11603;
            this.txtTotalDiscount.xBindingProperty = "";
            this.txtTotalDiscount.xColumnName = "";
            this.txtTotalDiscount.xColumnWidth = 60;
            this.txtTotalDiscount.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtTotalDiscount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalDiscount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalDiscount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalDiscount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalDiscount.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalDiscount.xReadOnly = false;
            // 
            // txtTotalApplied
            // 
            this.txtTotalApplied.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalApplied.BackColor = System.Drawing.Color.White;
            this.txtTotalApplied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalApplied.Location = new System.Drawing.Point(498, 46);
            this.txtTotalApplied.MaxLength = 150;
            this.txtTotalApplied.Name = "txtTotalApplied";
            this.txtTotalApplied.ReadOnly = true;
            this.txtTotalApplied.Size = new System.Drawing.Size(76, 20);
            this.txtTotalApplied.TabIndex = 11605;
            this.txtTotalApplied.xBindingProperty = "";
            this.txtTotalApplied.xColumnName = "";
            this.txtTotalApplied.xColumnWidth = 60;
            this.txtTotalApplied.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtTotalApplied.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalApplied.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalApplied.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalApplied.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalApplied.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalApplied.xReadOnly = true;
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems8.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems8.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnProceedPayment.ColorFillBlend = cBlendItems8;
            this.btnProceedPayment.DesignerSelected = false;
            this.btnProceedPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProceedPayment.ImageIndex = 0;
            this.btnProceedPayment.Location = new System.Drawing.Point(895, 21);
            this.btnProceedPayment.Margin = new System.Windows.Forms.Padding(0);
            this.btnProceedPayment.Name = "btnProceedPayment";
            this.btnProceedPayment.Size = new System.Drawing.Size(148, 22);
            this.btnProceedPayment.TabIndex = 11602;
            this.btnProceedPayment.Text = "Proceed Payment";
            this.btnProceedPayment.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ctrVendorPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ctrVendorPaymentList";
            this.Size = new System.Drawing.Size(1120, 597);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVVendorList;
        public ControlLibrary.TAZSearchDataGridView DGVVendorBillList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TAButton btnVoidTransactions;
        private ControlLibrary.TAButton btnUpdateOpenAmount;
        private ControlLibrary.TAButton btnBillBatches;
        private ControlLibrary.TATextBox txtBoxOpenAmount;
        private ControlLibrary.TAButton btnPrintPayment;
        private System.Windows.Forms.Panel panel3;
        private ControlLibrary.TAButton btnClearSelected;
        private ControlLibrary.TAButton btnAutoSelect;
        private ControlLibrary.TACheckBox chkboxShowClosedTransactions;
        private ControlLibrary.TATextBox txtTotalToPay;
        private ControlLibrary.TAButton btnProceedPayment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private ControlLibrary.TATextBox txtTotalApplied;
        private System.Windows.Forms.Label label19;
        private ControlLibrary.TATextBox txtTotalDiscount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ControlLibrary.TAButton btnNewVendorBill;
        private ControlLibrary.TACheckBox taCheckBox2;
        private ControlLibrary.TACheckBox chkboxShowBills;
        private ControlLibrary.TACheckBox chkboxShowAll;
    }
}
