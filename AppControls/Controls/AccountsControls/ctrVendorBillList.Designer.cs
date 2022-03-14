namespace AppControls
{
    partial class ctrVendorBillList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrintBill = new ControlLibrary.TAButton();
            this.txtBoxOpenAmount = new ControlLibrary.TATextBox();
            this.chkShowAll = new ControlLibrary.TACheckBox();
            this.btnUpdateOpenAmount = new ControlLibrary.TAButton();
            this.btnToggleOpenAmount = new ControlLibrary.TAButton();
            this.btnShowChecksAppliedToThisBill = new ControlLibrary.TAButton();
            this.DGVVendorList = new ControlLibrary.TAZSearchDataGridView();
            this.DGVVendorBillList = new ControlLibrary.TAZSearchDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkboxShowAll = new ControlLibrary.TACheckBox();
            this.chkboxShowBills = new ControlLibrary.TACheckBox();
            this.btnNewVendorBill = new ControlLibrary.TAButton();
            this.btnBillBatches = new ControlLibrary.TAButton();
            this.btnBillVoid = new ControlLibrary.TAButton();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tableLayoutPanel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(1037, 550);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.6F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 550);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrintBill);
            this.panel2.Controls.Add(this.txtBoxOpenAmount);
            this.panel2.Controls.Add(this.chkShowAll);
            this.panel2.Controls.Add(this.btnUpdateOpenAmount);
            this.panel2.Controls.Add(this.btnToggleOpenAmount);
            this.panel2.Controls.Add(this.btnShowChecksAppliedToThisBill);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 191);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 25);
            this.panel2.TabIndex = 7;
            // 
            // btnPrintBill
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPrintBill.ColorFillBlend = cBlendItems1;
            this.btnPrintBill.DesignerSelected = false;
            this.btnPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPrintBill.ImageIndex = 0;
            this.btnPrintBill.Location = new System.Drawing.Point(273, 1);
            this.btnPrintBill.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(88, 25);
            this.btnPrintBill.TabIndex = 10;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // txtBoxOpenAmount
            // 
            this.txtBoxOpenAmount.Location = new System.Drawing.Point(740, 3);
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
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(878, 5);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(67, 17);
            this.chkShowAll.TabIndex = 12;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.ToolTipText = null;
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.xBindingProperty = null;
            this.chkShowAll.xColumnName = null;
            this.chkShowAll.xColumnWidth = 60;
            this.chkShowAll.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkShowAll.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkShowAll.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // btnUpdateOpenAmount
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnUpdateOpenAmount.ColorFillBlend = cBlendItems2;
            this.btnUpdateOpenAmount.DesignerSelected = false;
            this.btnUpdateOpenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdateOpenAmount.ImageIndex = 0;
            this.btnUpdateOpenAmount.Location = new System.Drawing.Point(588, 1);
            this.btnUpdateOpenAmount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnUpdateOpenAmount.Name = "btnUpdateOpenAmount";
            this.btnUpdateOpenAmount.Size = new System.Drawing.Size(146, 25);
            this.btnUpdateOpenAmount.TabIndex = 11;
            this.btnUpdateOpenAmount.Text = "Update Open Amount";
            this.btnUpdateOpenAmount.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateOpenAmount.Visible = false;
            // 
            // btnToggleOpenAmount
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnToggleOpenAmount.ColorFillBlend = cBlendItems3;
            this.btnToggleOpenAmount.DesignerSelected = false;
            this.btnToggleOpenAmount.Enabled = false;
            this.btnToggleOpenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnToggleOpenAmount.ImageIndex = 0;
            this.btnToggleOpenAmount.Location = new System.Drawing.Point(442, 1);
            this.btnToggleOpenAmount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnToggleOpenAmount.Name = "btnToggleOpenAmount";
            this.btnToggleOpenAmount.Size = new System.Drawing.Size(146, 25);
            this.btnToggleOpenAmount.TabIndex = 10;
            this.btnToggleOpenAmount.Text = "Toggle Open Amount";
            this.btnToggleOpenAmount.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnToggleOpenAmount.Visible = false;
            // 
            // btnShowChecksAppliedToThisBill
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnShowChecksAppliedToThisBill.ColorFillBlend = cBlendItems4;
            this.btnShowChecksAppliedToThisBill.DesignerSelected = false;
            this.btnShowChecksAppliedToThisBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnShowChecksAppliedToThisBill.ImageIndex = 0;
            this.btnShowChecksAppliedToThisBill.Location = new System.Drawing.Point(77, 1);
            this.btnShowChecksAppliedToThisBill.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnShowChecksAppliedToThisBill.Name = "btnShowChecksAppliedToThisBill";
            this.btnShowChecksAppliedToThisBill.Size = new System.Drawing.Size(190, 25);
            this.btnShowChecksAppliedToThisBill.TabIndex = 7;
            this.btnShowChecksAppliedToThisBill.Text = "Show Checks applied to this bill";
            this.btnShowChecksAppliedToThisBill.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnShowChecksAppliedToThisBill.Visible = false;
            // 
            // DGVVendorList
            // 
            this.DGVVendorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorList.Location = new System.Drawing.Point(0, 25);
            this.DGVVendorList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVVendorList.Name = "DGVVendorList";
            this.DGVVendorList.Size = new System.Drawing.Size(1037, 166);
            this.DGVVendorList.TabIndex = 3;
            this.DGVVendorList.Load += new System.EventHandler(this.DGVVendorList_Load);
            // 
            // DGVVendorBillList
            // 
            this.DGVVendorBillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorBillList.Location = new System.Drawing.Point(0, 216);
            this.DGVVendorBillList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVVendorBillList.Name = "DGVVendorBillList";
            this.DGVVendorBillList.Size = new System.Drawing.Size(1037, 325);
            this.DGVVendorBillList.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 25);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.chkboxShowAll, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkboxShowBills, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNewVendorBill, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBillBatches, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBillVoid, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1037, 25);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // chkboxShowAll
            // 
            this.chkboxShowAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowAll.AutoSize = true;
            this.chkboxShowAll.Location = new System.Drawing.Point(774, 4);
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
            // chkboxShowBills
            // 
            this.chkboxShowBills.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowBills.AutoSize = true;
            this.chkboxShowBills.Location = new System.Drawing.Point(516, 4);
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
            // btnNewVendorBill
            // 
            this.btnNewVendorBill.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.btnNewVendorBill.Location = new System.Drawing.Point(129, 0);
            this.btnNewVendorBill.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewVendorBill.Name = "btnNewVendorBill";
            this.btnNewVendorBill.Size = new System.Drawing.Size(79, 25);
            this.btnNewVendorBill.TabIndex = 5;
            this.btnNewVendorBill.Text = "  New Bill";
            this.btnNewVendorBill.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBillBatches
            // 
            this.btnBillBatches.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBillBatches.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBillBatches.ColorFillBlend = cBlendItems6;
            this.btnBillBatches.DesignerSelected = false;
            this.btnBillBatches.Enabled = false;
            this.btnBillBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBillBatches.ImageIndex = 0;
            this.btnBillBatches.Location = new System.Drawing.Point(387, 0);
            this.btnBillBatches.Margin = new System.Windows.Forms.Padding(0);
            this.btnBillBatches.Name = "btnBillBatches";
            this.btnBillBatches.Size = new System.Drawing.Size(101, 25);
            this.btnBillBatches.TabIndex = 14;
            this.btnBillBatches.Text = "  Batches";
            this.btnBillBatches.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBillBatches.Visible = false;
            // 
            // btnBillVoid
            // 
            this.btnBillVoid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBillVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBillVoid.ColorFillBlend = cBlendItems7;
            this.btnBillVoid.DesignerSelected = false;
            this.btnBillVoid.Enabled = false;
            this.btnBillVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBillVoid.ImageIndex = 0;
            this.btnBillVoid.Location = new System.Drawing.Point(258, 0);
            this.btnBillVoid.Margin = new System.Windows.Forms.Padding(0);
            this.btnBillVoid.Name = "btnBillVoid";
            this.btnBillVoid.Size = new System.Drawing.Size(101, 25);
            this.btnBillVoid.TabIndex = 6;
            this.btnBillVoid.Text = "  Delete / Void";
            this.btnBillVoid.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBillVoid.Visible = false;
            // 
            // ctrVendorBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrVendorBillList";
            this.Size = new System.Drawing.Size(1037, 550);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVVendorList;
        public ControlLibrary.TAZSearchDataGridView DGVVendorBillList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TAButton btnBillVoid;
        private ControlLibrary.TAButton btnNewVendorBill;
        private ControlLibrary.TAButton btnToggleOpenAmount;
        private ControlLibrary.TAButton btnShowChecksAppliedToThisBill;
        private ControlLibrary.TAButton btnUpdateOpenAmount;
        private ControlLibrary.TACheckBox chkShowAll;
        private ControlLibrary.TACheckBox chkboxShowAll;
        private ControlLibrary.TACheckBox chkboxShowBills;
        private ControlLibrary.TAButton btnBillBatches;
        private ControlLibrary.TATextBox txtBoxOpenAmount;
        private ControlLibrary.TAButton btnPrintBill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        
    }
}
