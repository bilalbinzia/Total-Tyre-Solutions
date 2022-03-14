namespace AppControls
{
    partial class ctrVendorBillDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGVPOBillDetails = new ControlLibrary.libDataGridView();
            this.ID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemCatalog = new ControlLibrary.DGVTextBoxColumn();
            this.ItemDescription = new ControlLibrary.DGVTextBoxColumn();
            this.BillQty = new ControlLibrary.DGVTextBoxColumn();
            this.CatalogCost = new ControlLibrary.DGVTextBoxColumn();
            this.BillAmount = new ControlLibrary.DGVTextBoxColumn();
            this.txtGridTotalAmount = new ControlLibrary.TATextBox();
            this.txtGridTotalQty = new ControlLibrary.TATextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.NumSaleTaxPercent = new ControlLibrary.TATextBox();
            this.NumSaleTaxSurchargePercent = new ControlLibrary.TATextBox();
            this.NumSaleTaxDiscountPercent = new ControlLibrary.TATextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaleTaxAmount = new ControlLibrary.TATextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBillTotalAmount = new ControlLibrary.TATextBox();
            this.txtSaleTaxSurchargePrice = new ControlLibrary.TATextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSaleTaxDiscountPrice = new ControlLibrary.TATextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorTerms = new ControlLibrary.TATextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBillPayFreightTo = new ControlLibrary.TATextBox();
            this.txtBillFreight = new ControlLibrary.TATextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPOID = new ControlLibrary.TATextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBillID = new ControlLibrary.TATextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrDueDate = new ControlLibrary.TADateControl();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrBillDate = new ControlLibrary.TADateControl();
            this.txtInvoiceNo = new ControlLibrary.TATextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBillNotes = new ControlLibrary.TATextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPOBillDetails)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGVPOBillDetails);
            this.panel3.Controls.Add(this.txtGridTotalAmount);
            this.panel3.Controls.Add(this.txtGridTotalQty);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.txtBillID);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ctrDueDate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ctrBillDate);
            this.panel3.Controls.Add(this.txtInvoiceNo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtBillNotes);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 333);
            this.panel3.TabIndex = 9;
            // 
            // DGVPOBillDetails
            // 
            this.DGVPOBillDetails.AllowUserToAddRows = false;
            this.DGVPOBillDetails.AllowUserToDeleteRows = false;
            this.DGVPOBillDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGVPOBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPOBillDetails.BackgroundColor = System.Drawing.Color.White;
            this.DGVPOBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPOBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemID,
            this.ItemCatalog,
            this.ItemDescription,
            this.BillQty,
            this.CatalogCost,
            this.BillAmount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPOBillDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPOBillDetails.Enabled = false;
            this.DGVPOBillDetails.GridColor = System.Drawing.Color.White;
            this.DGVPOBillDetails.Location = new System.Drawing.Point(5, 157);
            this.DGVPOBillDetails.Name = "DGVPOBillDetails";
            this.DGVPOBillDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPOBillDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPOBillDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            this.DGVPOBillDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVPOBillDetails.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVPOBillDetails.ShowRowErrors = false;
            this.DGVPOBillDetails.Size = new System.Drawing.Size(505, 146);
            this.DGVPOBillDetails.TabIndex = 11603;
            this.DGVPOBillDetails.VirtualMode = true;
            this.DGVPOBillDetails.xIsAutoNo = true;
            this.DGVPOBillDetails.xIsDeleteColumn = false;
            this.DGVPOBillDetails.xOrderBy = null;
            this.DGVPOBillDetails.xTableName = "";
            this.DGVPOBillDetails.xTableQuery = null;
            this.DGVPOBillDetails.xTableRelation = "";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.IsFilteringColumn = false;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.xBindingProperty = "ID";
            this.ID.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.ID.xDisplayIndex = 0;
            this.ID.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.IsFilteringColumn = false;
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            this.ItemID.xBindingProperty = "ItemID";
            this.ItemID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemID.xDisplayIndex = 0;
            this.ItemID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemCatalog
            // 
            this.ItemCatalog.DataPropertyName = "Catalog";
            this.ItemCatalog.HeaderText = "Item Catalog";
            this.ItemCatalog.IsFilteringColumn = false;
            this.ItemCatalog.Name = "ItemCatalog";
            this.ItemCatalog.ReadOnly = true;
            this.ItemCatalog.xBindingProperty = "Catalog";
            this.ItemCatalog.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemCatalog.xDisplayIndex = 0;
            this.ItemCatalog.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ItemCatalog.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemDescription
            // 
            this.ItemDescription.DataPropertyName = "Name";
            this.ItemDescription.HeaderText = "Item Description";
            this.ItemDescription.IsFilteringColumn = false;
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Width = 180;
            this.ItemDescription.xBindingProperty = "Name";
            this.ItemDescription.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemDescription.xDisplayIndex = 0;
            this.ItemDescription.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemDescription.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // BillQty
            // 
            this.BillQty.DataPropertyName = "BillQty";
            this.BillQty.HeaderText = "Qty";
            this.BillQty.IsFilteringColumn = false;
            this.BillQty.Name = "BillQty";
            this.BillQty.ReadOnly = true;
            this.BillQty.Width = 50;
            this.BillQty.xBindingProperty = "BillQty";
            this.BillQty.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.BillQty.xDisplayIndex = 0;
            this.BillQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.BillQty.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // CatalogCost
            // 
            this.CatalogCost.DataPropertyName = "CatalogCost";
            this.CatalogCost.HeaderText = "Cost";
            this.CatalogCost.IsFilteringColumn = false;
            this.CatalogCost.Name = "CatalogCost";
            this.CatalogCost.ReadOnly = true;
            this.CatalogCost.Width = 50;
            this.CatalogCost.xBindingProperty = "CatalogCost";
            this.CatalogCost.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.CatalogCost.xDisplayIndex = 0;
            this.CatalogCost.xIsRequired = System32.StaticInfo.YesNo.No;
            this.CatalogCost.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // BillAmount
            // 
            this.BillAmount.DataPropertyName = "BillAmount";
            this.BillAmount.HeaderText = "BillAmount";
            this.BillAmount.IsFilteringColumn = false;
            this.BillAmount.Name = "BillAmount";
            this.BillAmount.ReadOnly = true;
            this.BillAmount.Width = 70;
            this.BillAmount.xBindingProperty = "BillAmount";
            this.BillAmount.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.BillAmount.xDisplayIndex = 0;
            this.BillAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.BillAmount.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // txtGridTotalAmount
            // 
            this.txtGridTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtGridTotalAmount.Location = new System.Drawing.Point(385, 307);
            this.txtGridTotalAmount.MaxLength = 150;
            this.txtGridTotalAmount.Name = "txtGridTotalAmount";
            this.txtGridTotalAmount.ReadOnly = true;
            this.txtGridTotalAmount.Size = new System.Drawing.Size(75, 20);
            this.txtGridTotalAmount.TabIndex = 11602;
            this.txtGridTotalAmount.xBindingProperty = "GridTotalAmount";
            this.txtGridTotalAmount.xColumnName = "";
            this.txtGridTotalAmount.xColumnWidth = 60;
            this.txtGridTotalAmount.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtGridTotalAmount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtGridTotalAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtGridTotalAmount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtGridTotalAmount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtGridTotalAmount.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtGridTotalAmount.xReadOnly = false;
            // 
            // txtGridTotalQty
            // 
            this.txtGridTotalQty.BackColor = System.Drawing.Color.White;
            this.txtGridTotalQty.Location = new System.Drawing.Point(296, 307);
            this.txtGridTotalQty.MaxLength = 150;
            this.txtGridTotalQty.Name = "txtGridTotalQty";
            this.txtGridTotalQty.ReadOnly = true;
            this.txtGridTotalQty.Size = new System.Drawing.Size(75, 20);
            this.txtGridTotalQty.TabIndex = 11601;
            this.txtGridTotalQty.xBindingProperty = "GridTotalQty";
            this.txtGridTotalQty.xColumnName = "";
            this.txtGridTotalQty.xColumnWidth = 60;
            this.txtGridTotalQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtGridTotalQty.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtGridTotalQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtGridTotalQty.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtGridTotalQty.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtGridTotalQty.xMasked = System32.StaticInfo.Mask.Digit;
            this.txtGridTotalQty.xReadOnly = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 11600;
            this.label9.Text = "Totals";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.NumSaleTaxPercent);
            this.panel4.Controls.Add(this.NumSaleTaxSurchargePercent);
            this.panel4.Controls.Add(this.NumSaleTaxDiscountPercent);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtSaleTaxAmount);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txtBillTotalAmount);
            this.panel4.Controls.Add(this.txtSaleTaxSurchargePrice);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.txtSaleTaxDiscountPrice);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(314, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(196, 94);
            this.panel4.TabIndex = 11599;
            // 
            // NumSaleTaxPercent
            // 
            this.NumSaleTaxPercent.BackColor = System.Drawing.Color.White;
            this.NumSaleTaxPercent.Location = new System.Drawing.Point(64, 3);
            this.NumSaleTaxPercent.MaxLength = 150;
            this.NumSaleTaxPercent.Name = "NumSaleTaxPercent";
            this.NumSaleTaxPercent.ReadOnly = true;
            this.NumSaleTaxPercent.Size = new System.Drawing.Size(49, 20);
            this.NumSaleTaxPercent.TabIndex = 11587;
            this.NumSaleTaxPercent.xBindingProperty = "SaleTaxPercent";
            this.NumSaleTaxPercent.xColumnName = "";
            this.NumSaleTaxPercent.xColumnWidth = 60;
            this.NumSaleTaxPercent.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.NumSaleTaxPercent.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxPercent.xIsRequired = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxPercent.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxPercent.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxPercent.xMasked = System32.StaticInfo.Mask.Decimal;
            this.NumSaleTaxPercent.xReadOnly = false;
            // 
            // NumSaleTaxSurchargePercent
            // 
            this.NumSaleTaxSurchargePercent.BackColor = System.Drawing.Color.White;
            this.NumSaleTaxSurchargePercent.Location = new System.Drawing.Point(64, 47);
            this.NumSaleTaxSurchargePercent.MaxLength = 150;
            this.NumSaleTaxSurchargePercent.Name = "NumSaleTaxSurchargePercent";
            this.NumSaleTaxSurchargePercent.ReadOnly = true;
            this.NumSaleTaxSurchargePercent.Size = new System.Drawing.Size(49, 20);
            this.NumSaleTaxSurchargePercent.TabIndex = 11586;
            this.NumSaleTaxSurchargePercent.xBindingProperty = "SaleTaxSurchargePercent";
            this.NumSaleTaxSurchargePercent.xColumnName = "";
            this.NumSaleTaxSurchargePercent.xColumnWidth = 60;
            this.NumSaleTaxSurchargePercent.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.NumSaleTaxSurchargePercent.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxSurchargePercent.xIsRequired = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxSurchargePercent.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxSurchargePercent.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxSurchargePercent.xMasked = System32.StaticInfo.Mask.Decimal;
            this.NumSaleTaxSurchargePercent.xReadOnly = true;
            // 
            // NumSaleTaxDiscountPercent
            // 
            this.NumSaleTaxDiscountPercent.BackColor = System.Drawing.Color.White;
            this.NumSaleTaxDiscountPercent.Location = new System.Drawing.Point(64, 25);
            this.NumSaleTaxDiscountPercent.MaxLength = 150;
            this.NumSaleTaxDiscountPercent.Name = "NumSaleTaxDiscountPercent";
            this.NumSaleTaxDiscountPercent.ReadOnly = true;
            this.NumSaleTaxDiscountPercent.Size = new System.Drawing.Size(49, 20);
            this.NumSaleTaxDiscountPercent.TabIndex = 11585;
            this.NumSaleTaxDiscountPercent.xBindingProperty = "SaleTaxDiscountPercent";
            this.NumSaleTaxDiscountPercent.xColumnName = "";
            this.NumSaleTaxDiscountPercent.xColumnWidth = 60;
            this.NumSaleTaxDiscountPercent.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.NumSaleTaxDiscountPercent.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxDiscountPercent.xIsRequired = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxDiscountPercent.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxDiscountPercent.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.NumSaleTaxDiscountPercent.xMasked = System32.StaticInfo.Mask.Decimal;
            this.NumSaleTaxDiscountPercent.xReadOnly = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 11584;
            this.label7.Text = "%";
            // 
            // txtSaleTaxAmount
            // 
            this.txtSaleTaxAmount.BackColor = System.Drawing.Color.White;
            this.txtSaleTaxAmount.Location = new System.Drawing.Point(130, 3);
            this.txtSaleTaxAmount.MaxLength = 150;
            this.txtSaleTaxAmount.Name = "txtSaleTaxAmount";
            this.txtSaleTaxAmount.ReadOnly = true;
            this.txtSaleTaxAmount.Size = new System.Drawing.Size(60, 20);
            this.txtSaleTaxAmount.TabIndex = 11580;
            this.txtSaleTaxAmount.xBindingProperty = "SaleTaxAmount";
            this.txtSaleTaxAmount.xColumnName = "";
            this.txtSaleTaxAmount.xColumnWidth = 60;
            this.txtSaleTaxAmount.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxAmount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxAmount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxAmount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxAmount.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtSaleTaxAmount.xReadOnly = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 11579;
            this.label14.Text = "Sales Tax";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11583;
            this.label1.Text = "Total Amount";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 11550;
            this.label20.Text = "Surcharge";
            // 
            // txtBillTotalAmount
            // 
            this.txtBillTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtBillTotalAmount.Location = new System.Drawing.Point(91, 69);
            this.txtBillTotalAmount.MaxLength = 12;
            this.txtBillTotalAmount.Name = "txtBillTotalAmount";
            this.txtBillTotalAmount.ReadOnly = true;
            this.txtBillTotalAmount.Size = new System.Drawing.Size(99, 20);
            this.txtBillTotalAmount.TabIndex = 11582;
            this.txtBillTotalAmount.xBindingProperty = "BillTotalAmount";
            this.txtBillTotalAmount.xColumnName = "";
            this.txtBillTotalAmount.xColumnWidth = 120;
            this.txtBillTotalAmount.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBillTotalAmount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBillTotalAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBillTotalAmount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtBillTotalAmount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBillTotalAmount.xMasked = System32.StaticInfo.Mask.None;
            this.txtBillTotalAmount.xReadOnly = false;
            // 
            // txtSaleTaxSurchargePrice
            // 
            this.txtSaleTaxSurchargePrice.BackColor = System.Drawing.Color.White;
            this.txtSaleTaxSurchargePrice.Location = new System.Drawing.Point(130, 47);
            this.txtSaleTaxSurchargePrice.MaxLength = 150;
            this.txtSaleTaxSurchargePrice.Name = "txtSaleTaxSurchargePrice";
            this.txtSaleTaxSurchargePrice.ReadOnly = true;
            this.txtSaleTaxSurchargePrice.Size = new System.Drawing.Size(60, 20);
            this.txtSaleTaxSurchargePrice.TabIndex = 11547;
            this.txtSaleTaxSurchargePrice.xBindingProperty = "SaleTaxSurchargePrice";
            this.txtSaleTaxSurchargePrice.xColumnName = "";
            this.txtSaleTaxSurchargePrice.xColumnWidth = 60;
            this.txtSaleTaxSurchargePrice.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxSurchargePrice.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxSurchargePrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxSurchargePrice.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxSurchargePrice.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxSurchargePrice.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtSaleTaxSurchargePrice.xReadOnly = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(113, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 13);
            this.label21.TabIndex = 11548;
            this.label21.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 11546;
            this.label19.Text = "Discount";
            // 
            // txtSaleTaxDiscountPrice
            // 
            this.txtSaleTaxDiscountPrice.BackColor = System.Drawing.Color.White;
            this.txtSaleTaxDiscountPrice.Location = new System.Drawing.Point(130, 25);
            this.txtSaleTaxDiscountPrice.MaxLength = 150;
            this.txtSaleTaxDiscountPrice.Name = "txtSaleTaxDiscountPrice";
            this.txtSaleTaxDiscountPrice.ReadOnly = true;
            this.txtSaleTaxDiscountPrice.Size = new System.Drawing.Size(60, 20);
            this.txtSaleTaxDiscountPrice.TabIndex = 11532;
            this.txtSaleTaxDiscountPrice.xBindingProperty = "SaleTaxDiscountPrice";
            this.txtSaleTaxDiscountPrice.xColumnName = "";
            this.txtSaleTaxDiscountPrice.xColumnWidth = 60;
            this.txtSaleTaxDiscountPrice.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxDiscountPrice.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxDiscountPrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxDiscountPrice.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtSaleTaxDiscountPrice.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtSaleTaxDiscountPrice.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtSaleTaxDiscountPrice.xReadOnly = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(113, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 11535;
            this.label12.Text = "%";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtVendorTerms);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.txtBillPayFreightTo);
            this.panel5.Controls.Add(this.txtBillFreight);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.txtPOID);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(3, 57);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 94);
            this.panel5.TabIndex = 11598;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11587;
            this.label3.Text = "Term";
            // 
            // txtVendorTerms
            // 
            this.txtVendorTerms.BackColor = System.Drawing.Color.White;
            this.txtVendorTerms.Location = new System.Drawing.Point(185, 25);
            this.txtVendorTerms.MaxLength = 150;
            this.txtVendorTerms.Name = "txtVendorTerms";
            this.txtVendorTerms.ReadOnly = true;
            this.txtVendorTerms.Size = new System.Drawing.Size(119, 20);
            this.txtVendorTerms.TabIndex = 11586;
            this.txtVendorTerms.xBindingProperty = "Terms";
            this.txtVendorTerms.xColumnName = "";
            this.txtVendorTerms.xColumnWidth = 120;
            this.txtVendorTerms.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtVendorTerms.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtVendorTerms.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtVendorTerms.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtVendorTerms.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtVendorTerms.xMasked = System32.StaticInfo.Mask.None;
            this.txtVendorTerms.xReadOnly = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 11584;
            this.label16.Text = "Pay Freight to";
            // 
            // txtBillPayFreightTo
            // 
            this.txtBillPayFreightTo.BackColor = System.Drawing.Color.White;
            this.txtBillPayFreightTo.Location = new System.Drawing.Point(82, 47);
            this.txtBillPayFreightTo.MaxLength = 150;
            this.txtBillPayFreightTo.Name = "txtBillPayFreightTo";
            this.txtBillPayFreightTo.ReadOnly = true;
            this.txtBillPayFreightTo.Size = new System.Drawing.Size(221, 20);
            this.txtBillPayFreightTo.TabIndex = 11583;
            this.txtBillPayFreightTo.xBindingProperty = "BillPayFreightTo";
            this.txtBillPayFreightTo.xColumnName = "";
            this.txtBillPayFreightTo.xColumnWidth = 80;
            this.txtBillPayFreightTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBillPayFreightTo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBillPayFreightTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBillPayFreightTo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBillPayFreightTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBillPayFreightTo.xMasked = System32.StaticInfo.Mask.None;
            this.txtBillPayFreightTo.xReadOnly = false;
            // 
            // txtBillFreight
            // 
            this.txtBillFreight.BackColor = System.Drawing.Color.White;
            this.txtBillFreight.Location = new System.Drawing.Point(82, 25);
            this.txtBillFreight.MaxLength = 150;
            this.txtBillFreight.Name = "txtBillFreight";
            this.txtBillFreight.ReadOnly = true;
            this.txtBillFreight.Size = new System.Drawing.Size(60, 20);
            this.txtBillFreight.TabIndex = 11581;
            this.txtBillFreight.xBindingProperty = "BillFreight";
            this.txtBillFreight.xColumnName = "";
            this.txtBillFreight.xColumnWidth = 60;
            this.txtBillFreight.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtBillFreight.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBillFreight.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBillFreight.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtBillFreight.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBillFreight.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtBillFreight.xReadOnly = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 11580;
            this.label15.Text = "Freight";
            // 
            // txtPOID
            // 
            this.txtPOID.BackColor = System.Drawing.Color.White;
            this.txtPOID.Location = new System.Drawing.Point(82, 3);
            this.txtPOID.MaxLength = 150;
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.ReadOnly = true;
            this.txtPOID.Size = new System.Drawing.Size(60, 20);
            this.txtPOID.TabIndex = 11570;
            this.txtPOID.xBindingProperty = "POID";
            this.txtPOID.xColumnName = "";
            this.txtPOID.xColumnWidth = 120;
            this.txtPOID.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtPOID.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtPOID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtPOID.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtPOID.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtPOID.xMasked = System32.StaticInfo.Mask.None;
            this.txtPOID.xReadOnly = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 11571;
            this.label8.Text = "P/O No.";
            // 
            // txtBillID
            // 
            this.txtBillID.BackColor = System.Drawing.Color.White;
            this.txtBillID.Location = new System.Drawing.Point(247, 9);
            this.txtBillID.MaxLength = 150;
            this.txtBillID.Name = "txtBillID";
            this.txtBillID.ReadOnly = true;
            this.txtBillID.Size = new System.Drawing.Size(68, 20);
            this.txtBillID.TabIndex = 11596;
            this.txtBillID.xBindingProperty = "BillID";
            this.txtBillID.xColumnName = "";
            this.txtBillID.xColumnWidth = 120;
            this.txtBillID.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBillID.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBillID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBillID.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBillID.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBillID.xMasked = System32.StaticInfo.Mask.None;
            this.txtBillID.xReadOnly = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11597;
            this.label5.Text = "Ref. #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11595;
            this.label2.Text = "Due Date";
            // 
            // ctrDueDate
            // 
            this.ctrDueDate.BackColor = System.Drawing.Color.White;
            this.ctrDueDate.Enabled = false;
            this.ctrDueDate.Location = new System.Drawing.Point(407, 31);
            this.ctrDueDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrDueDate.Name = "ctrDueDate";
            this.ctrDueDate.Size = new System.Drawing.Size(99, 20);
            this.ctrDueDate.TabIndex = 11594;
            this.ctrDueDate.xBindingProperty = "DueDate";
            this.ctrDueDate.xColumnName = null;
            this.ctrDueDate.xColumnWidth = 60;
            this.ctrDueDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrDueDate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrDueDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.ctrDueDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11593;
            this.label6.Text = "Date.";
            // 
            // ctrBillDate
            // 
            this.ctrBillDate.BackColor = System.Drawing.Color.White;
            this.ctrBillDate.Enabled = false;
            this.ctrBillDate.Location = new System.Drawing.Point(407, 9);
            this.ctrBillDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrBillDate.Name = "ctrBillDate";
            this.ctrBillDate.Size = new System.Drawing.Size(99, 20);
            this.ctrBillDate.TabIndex = 11592;
            this.ctrBillDate.xBindingProperty = "BillDate";
            this.ctrBillDate.xColumnName = null;
            this.ctrBillDate.xColumnWidth = 60;
            this.ctrBillDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrBillDate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrBillDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.ctrBillDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.White;
            this.txtInvoiceNo.Location = new System.Drawing.Point(88, 9);
            this.txtInvoiceNo.MaxLength = 150;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(98, 20);
            this.txtInvoiceNo.TabIndex = 11590;
            this.txtInvoiceNo.xBindingProperty = "Reference";
            this.txtInvoiceNo.xColumnName = "";
            this.txtInvoiceNo.xColumnWidth = 80;
            this.txtInvoiceNo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtInvoiceNo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xMasked = System32.StaticInfo.Mask.None;
            this.txtInvoiceNo.xReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11591;
            this.label4.Text = "Vendor Inv. #.";
            // 
            // txtBillNotes
            // 
            this.txtBillNotes.BackColor = System.Drawing.Color.White;
            this.txtBillNotes.Location = new System.Drawing.Point(88, 31);
            this.txtBillNotes.MaxLength = 150;
            this.txtBillNotes.Name = "txtBillNotes";
            this.txtBillNotes.ReadOnly = true;
            this.txtBillNotes.Size = new System.Drawing.Size(227, 20);
            this.txtBillNotes.TabIndex = 11588;
            this.txtBillNotes.xBindingProperty = "Notes";
            this.txtBillNotes.xColumnName = "";
            this.txtBillNotes.xColumnWidth = 80;
            this.txtBillNotes.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBillNotes.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBillNotes.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBillNotes.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBillNotes.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBillNotes.xMasked = System32.StaticInfo.Mask.None;
            this.txtBillNotes.xReadOnly = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 11589;
            this.label10.Text = "Notes";
            // 
            // ctrVendorBillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "ctrVendorBillDetail";
            this.Size = new System.Drawing.Size(518, 333);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPOBillDetails)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private ControlLibrary.libDataGridView DGVPOBillDetails;
        private ControlLibrary.DGVTextBoxColumn ID;
        private ControlLibrary.DGVTextBoxColumn ItemID;
        private ControlLibrary.DGVTextBoxColumn ItemCatalog;
        private ControlLibrary.DGVTextBoxColumn ItemDescription;
        private ControlLibrary.DGVTextBoxColumn BillQty;
        private ControlLibrary.DGVTextBoxColumn CatalogCost;
        private ControlLibrary.DGVTextBoxColumn BillAmount;
        private ControlLibrary.TATextBox txtGridTotalAmount;
        private ControlLibrary.TATextBox txtGridTotalQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private ControlLibrary.TATextBox NumSaleTaxPercent;
        private ControlLibrary.TATextBox NumSaleTaxSurchargePercent;
        private ControlLibrary.TATextBox NumSaleTaxDiscountPercent;
        private System.Windows.Forms.Label label7;
        private ControlLibrary.TATextBox txtSaleTaxAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private ControlLibrary.TATextBox txtBillTotalAmount;
        private ControlLibrary.TATextBox txtSaleTaxSurchargePrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private ControlLibrary.TATextBox txtSaleTaxDiscountPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private ControlLibrary.TATextBox txtVendorTerms;
        private System.Windows.Forms.Label label16;
        private ControlLibrary.TATextBox txtBillPayFreightTo;
        private ControlLibrary.TATextBox txtBillFreight;
        private System.Windows.Forms.Label label15;
        private ControlLibrary.TATextBox txtPOID;
        private System.Windows.Forms.Label label8;
        private ControlLibrary.TATextBox txtBillID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private ControlLibrary.TADateControl ctrDueDate;
        private System.Windows.Forms.Label label6;
        private ControlLibrary.TADateControl ctrBillDate;
        private ControlLibrary.TATextBox txtInvoiceNo;
        private System.Windows.Forms.Label label4;
        private ControlLibrary.TATextBox txtBillNotes;
        private System.Windows.Forms.Label label10;
    }
}
