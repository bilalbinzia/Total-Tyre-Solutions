namespace AppControls
{
    partial class ctrVehicleInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrVehicleInspection));
            this.label41 = new System.Windows.Forms.Label();
            this.ctrCustomerID = new ControlLibrary.TAComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.ctrWorkOrderNo = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVInspactionDetail = new ControlLibrary.libDataGridView();
            this.ID = new ControlLibrary.DGVTextBoxColumn();
            this.InspectionHeadID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemCatalog = new ControlLibrary.DGVTextBoxColumn();
            this.CategoryItem = new ControlLibrary.DGVTextBoxColumn();
            this.IsChange = new ControlLibrary.DGVCheckBoxColumn();
            this.IsRepair = new ControlLibrary.DGVCheckBoxColumn();
            this.IsAccept = new ControlLibrary.DGVCheckBoxColumn();
            this.IsDecline = new ControlLibrary.DGVCheckBoxColumn();
            this.IsIgnore = new ControlLibrary.DGVCheckBoxColumn();
            this.Notes = new ControlLibrary.DGVTextBoxColumn();
            this.ItemPrice = new ControlLibrary.DGVTextBoxColumn();
            this.LaborPrice = new ControlLibrary.DGVTextBoxColumn();
            this.FeePrice = new ControlLibrary.DGVTextBoxColumn();
            this.TotalPrice = new ControlLibrary.DGVTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taTextBox2 = new ControlLibrary.TATextBox();
            this.taTextBox3 = new ControlLibrary.TATextBox();
            this.taTextBox4 = new ControlLibrary.TATextBox();
            this.taTextBox5 = new ControlLibrary.TATextBox();
            this.ctrLicensePlate = new ControlLibrary.TATextBox();
            this.ctrVIN = new ControlLibrary.TATextBox();
            this.ctrVehicleYearMakeModel = new ControlLibrary.TATextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.btnInspectionItems = new ControlLibrary.TAButton();
            this.btnPrintCustomerCopy = new ControlLibrary.TAButton();
            this.btnPrintMechanicCopy = new ControlLibrary.TAButton();
            this.btnAddServices = new ControlLibrary.TAButton();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInspactionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.btnAddServices);
            this.WorkingPanel.Controls.Add(this.btnPrintMechanicCopy);
            this.WorkingPanel.Controls.Add(this.btnPrintCustomerCopy);
            this.WorkingPanel.Controls.Add(this.btnInspectionItems);
            this.WorkingPanel.Controls.Add(this.ctrVehicleYearMakeModel);
            this.WorkingPanel.Controls.Add(this.label52);
            this.WorkingPanel.Controls.Add(this.ctrVIN);
            this.WorkingPanel.Controls.Add(this.ctrLicensePlate);
            this.WorkingPanel.Controls.Add(this.taTextBox4);
            this.WorkingPanel.Controls.Add(this.taTextBox5);
            this.WorkingPanel.Controls.Add(this.taTextBox3);
            this.WorkingPanel.Controls.Add(this.taTextBox2);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Controls.Add(this.label5);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.DGVInspactionDetail);
            this.WorkingPanel.Controls.Add(this.ctrWorkOrderNo);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.label41);
            this.WorkingPanel.Controls.Add(this.ctrCustomerID);
            this.WorkingPanel.Controls.Add(this.label34);
            this.WorkingPanel.Controls.Add(this.label37);
            this.WorkingPanel.Size = new System.Drawing.Size(807, 461);
            this.WorkingPanel.Controls.SetChildIndex(this.label37, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label34, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrCustomerID, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label41, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrWorkOrderNo, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.DGVInspactionDetail, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label5, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox5, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrLicensePlate, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrVIN, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label52, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrVehicleYearMakeModel, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnInspectionItems, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnPrintCustomerCopy, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnPrintMechanicCopy, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnAddServices, 0);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(241, 59);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(51, 13);
            this.label41.TabIndex = 11697;
            this.label41.Text = "Customer";
            // 
            // ctrCustomerID
            // 
            this.ctrCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ctrCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ctrCustomerID.DisplayMember = "FirstName";
            this.ctrCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.ctrCustomerID.Enabled = false;
            this.ctrCustomerID.FormattingEnabled = true;
            this.ctrCustomerID.Location = new System.Drawing.Point(296, 55);
            this.ctrCustomerID.Name = "ctrCustomerID";
            this.ctrCustomerID.Size = new System.Drawing.Size(214, 21);
            this.ctrCustomerID.TabIndex = 11698;
            this.ctrCustomerID.ValueMember = "ID";
            this.ctrCustomerID.xBindingProperty = "CustomerID";
            this.ctrCustomerID.xColumnName = "";
            this.ctrCustomerID.xColumnWidth = 60;
            this.ctrCustomerID.xDisplayMember = "FirstName";
            this.ctrCustomerID.xFillByFieldID = null;
            this.ctrCustomerID.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ctrCustomerID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrCustomerID.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.ctrCustomerID.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.ctrCustomerID.xOrderBy = "FirstName";
            this.ctrCustomerID.xReadOnly = true;
            this.ctrCustomerID.xTableName = "Customer";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(61, 83);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(71, 13);
            this.label34.TabIndex = 11674;
            this.label34.Text = "License Plate";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(267, 83);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(25, 13);
            this.label37.TabIndex = 11678;
            this.label37.Text = "VIN";
            // 
            // ctrWorkOrderNo
            // 
            this.ctrWorkOrderNo.Enabled = false;
            this.ctrWorkOrderNo.Location = new System.Drawing.Point(137, 55);
            this.ctrWorkOrderNo.Name = "ctrWorkOrderNo";
            this.ctrWorkOrderNo.ReadOnly = true;
            this.ctrWorkOrderNo.Size = new System.Drawing.Size(100, 20);
            this.ctrWorkOrderNo.TabIndex = 11702;
            this.ctrWorkOrderNo.xBindingProperty = "WorkOrderNo";
            this.ctrWorkOrderNo.xColumnName = "";
            this.ctrWorkOrderNo.xColumnWidth = 60;
            this.ctrWorkOrderNo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrWorkOrderNo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.ctrWorkOrderNo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrWorkOrderNo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.ctrWorkOrderNo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.ctrWorkOrderNo.xMasked = System32.StaticInfo.Mask.Digit;
            this.ctrWorkOrderNo.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11701;
            this.label1.Text = "WorkOrder No";
            // 
            // DGVInspactionDetail
            // 
            this.DGVInspactionDetail.AllowUserToAddRows = false;
            this.DGVInspactionDetail.AllowUserToDeleteRows = false;
            this.DGVInspactionDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DGVInspactionDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVInspactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVInspactionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InspectionHeadID,
            this.ItemCatalog,
            this.CategoryItem,
            this.IsChange,
            this.IsRepair,
            this.IsAccept,
            this.IsDecline,
            this.IsIgnore,
            this.Notes,
            this.ItemPrice,
            this.LaborPrice,
            this.FeePrice,
            this.TotalPrice});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVInspactionDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVInspactionDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVInspactionDetail.Location = new System.Drawing.Point(0, 164);
            this.DGVInspactionDetail.Name = "DGVInspactionDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVInspactionDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVInspactionDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.DGVInspactionDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVInspactionDetail.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVInspactionDetail.ShowRowErrors = false;
            this.DGVInspactionDetail.Size = new System.Drawing.Size(807, 297);
            this.DGVInspactionDetail.TabIndex = 11703;
            this.DGVInspactionDetail.VirtualMode = true;
            this.DGVInspactionDetail.xIsAutoNo = true;
            this.DGVInspactionDetail.xIsDeleteColumn = true;
            this.DGVInspactionDetail.xOrderBy = null;
            this.DGVInspactionDetail.xTableName = "VehicleInspectionDetail";
            this.DGVInspactionDetail.xTableQuery = resources.GetString("DGVInspactionDetail.xTableQuery");
            this.DGVInspactionDetail.xTableRelation = "FK_VehicleInspectionDetail_VehicleInspection";
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
            // InspectionHeadID
            // 
            this.InspectionHeadID.DataPropertyName = "InspectionHeadID";
            this.InspectionHeadID.HeaderText = "InspectionHeadID";
            this.InspectionHeadID.IsFilteringColumn = false;
            this.InspectionHeadID.Name = "InspectionHeadID";
            this.InspectionHeadID.Visible = false;
            this.InspectionHeadID.xBindingProperty = "InspectionHeadID";
            this.InspectionHeadID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.InspectionHeadID.xDisplayIndex = 0;
            this.InspectionHeadID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.InspectionHeadID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemCatalog
            // 
            this.ItemCatalog.DataPropertyName = "Catalog";
            this.ItemCatalog.HeaderText = "Category";
            this.ItemCatalog.IsFilteringColumn = false;
            this.ItemCatalog.Name = "ItemCatalog";
            this.ItemCatalog.ReadOnly = true;
            this.ItemCatalog.Width = 70;
            this.ItemCatalog.xBindingProperty = "Catalog";
            this.ItemCatalog.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemCatalog.xDisplayIndex = 0;
            this.ItemCatalog.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ItemCatalog.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // CategoryItem
            // 
            this.CategoryItem.DataPropertyName = "CategoryItem";
            this.CategoryItem.HeaderText = "CategoryItem";
            this.CategoryItem.IsFilteringColumn = false;
            this.CategoryItem.Name = "CategoryItem";
            this.CategoryItem.ReadOnly = true;
            this.CategoryItem.Width = 120;
            this.CategoryItem.xBindingProperty = "CategoryItem";
            this.CategoryItem.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.CategoryItem.xDisplayIndex = 0;
            this.CategoryItem.xIsRequired = System32.StaticInfo.YesNo.No;
            this.CategoryItem.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // IsChange
            // 
            this.IsChange.DataPropertyName = "IsChange";
            this.IsChange.HeaderText = "Change";
            this.IsChange.Name = "IsChange";
            this.IsChange.Width = 40;
            this.IsChange.xBindingProperty = null;
            // 
            // IsRepair
            // 
            this.IsRepair.DataPropertyName = "IsRepair";
            this.IsRepair.HeaderText = "Repair";
            this.IsRepair.Name = "IsRepair";
            this.IsRepair.Width = 40;
            this.IsRepair.xBindingProperty = null;
            // 
            // IsAccept
            // 
            this.IsAccept.DataPropertyName = "IsAccept";
            this.IsAccept.HeaderText = "Accept";
            this.IsAccept.Name = "IsAccept";
            this.IsAccept.Width = 40;
            this.IsAccept.xBindingProperty = null;
            // 
            // IsDecline
            // 
            this.IsDecline.DataPropertyName = "IsDecline";
            this.IsDecline.HeaderText = "Decline";
            this.IsDecline.Name = "IsDecline";
            this.IsDecline.Width = 40;
            this.IsDecline.xBindingProperty = null;
            // 
            // IsIgnore
            // 
            this.IsIgnore.DataPropertyName = "IsIgnore";
            this.IsIgnore.HeaderText = "Ignore";
            this.IsIgnore.Name = "IsIgnore";
            this.IsIgnore.Width = 40;
            this.IsIgnore.xBindingProperty = null;
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.IsFilteringColumn = false;
            this.Notes.Name = "Notes";
            this.Notes.Width = 150;
            this.Notes.xBindingProperty = "Notes";
            this.Notes.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Notes.xDisplayIndex = 0;
            this.Notes.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Notes.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "ItemPrice";
            this.ItemPrice.HeaderText = "PartPrice";
            this.ItemPrice.IsFilteringColumn = false;
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 50;
            this.ItemPrice.xBindingProperty = "ItemPrice";
            this.ItemPrice.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.ItemPrice.xDisplayIndex = 0;
            this.ItemPrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemPrice.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // LaborPrice
            // 
            this.LaborPrice.DataPropertyName = "LaborPrice";
            this.LaborPrice.HeaderText = "Labor";
            this.LaborPrice.IsFilteringColumn = false;
            this.LaborPrice.Name = "LaborPrice";
            this.LaborPrice.Width = 50;
            this.LaborPrice.xBindingProperty = "LaborPrice";
            this.LaborPrice.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.LaborPrice.xDisplayIndex = 0;
            this.LaborPrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.LaborPrice.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // FeePrice
            // 
            this.FeePrice.DataPropertyName = "FeePrice";
            this.FeePrice.HeaderText = "Fee";
            this.FeePrice.IsFilteringColumn = false;
            this.FeePrice.Name = "FeePrice";
            this.FeePrice.Width = 50;
            this.FeePrice.xBindingProperty = "FeePrice";
            this.FeePrice.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.FeePrice.xDisplayIndex = 0;
            this.FeePrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.FeePrice.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "Total";
            this.TotalPrice.IsFilteringColumn = false;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 60;
            this.TotalPrice.xBindingProperty = "TotalPrice";
            this.TotalPrice.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.TotalPrice.xDisplayIndex = 0;
            this.TotalPrice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.TotalPrice.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(648, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 11704;
            this.label2.Text = "Totals";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 11706;
            this.label5.Text = "Total Parts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 11707;
            this.label3.Text = "Total Labor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11708;
            this.label4.Text = "Total Tax";
            // 
            // taTextBox2
            // 
            this.taTextBox2.Enabled = false;
            this.taTextBox2.Location = new System.Drawing.Point(695, 57);
            this.taTextBox2.Name = "taTextBox2";
            this.taTextBox2.ReadOnly = true;
            this.taTextBox2.Size = new System.Drawing.Size(90, 20);
            this.taTextBox2.TabIndex = 11709;
            this.taTextBox2.xBindingProperty = "TotalAmount";
            this.taTextBox2.xColumnName = "";
            this.taTextBox2.xColumnWidth = 60;
            this.taTextBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox2.xReadOnly = true;
            // 
            // taTextBox3
            // 
            this.taTextBox3.Enabled = false;
            this.taTextBox3.Location = new System.Drawing.Point(695, 78);
            this.taTextBox3.Name = "taTextBox3";
            this.taTextBox3.ReadOnly = true;
            this.taTextBox3.Size = new System.Drawing.Size(90, 20);
            this.taTextBox3.TabIndex = 11710;
            this.taTextBox3.xBindingProperty = "TotalParts";
            this.taTextBox3.xColumnName = "";
            this.taTextBox3.xColumnWidth = 60;
            this.taTextBox3.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox3.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox3.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox3.xReadOnly = true;
            // 
            // taTextBox4
            // 
            this.taTextBox4.Enabled = false;
            this.taTextBox4.Location = new System.Drawing.Point(695, 120);
            this.taTextBox4.Name = "taTextBox4";
            this.taTextBox4.ReadOnly = true;
            this.taTextBox4.Size = new System.Drawing.Size(90, 20);
            this.taTextBox4.TabIndex = 11712;
            this.taTextBox4.xBindingProperty = "TotalTax";
            this.taTextBox4.xColumnName = "";
            this.taTextBox4.xColumnWidth = 60;
            this.taTextBox4.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox4.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox4.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox4.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox4.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox4.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox4.xReadOnly = true;
            // 
            // taTextBox5
            // 
            this.taTextBox5.Enabled = false;
            this.taTextBox5.Location = new System.Drawing.Point(695, 99);
            this.taTextBox5.Name = "taTextBox5";
            this.taTextBox5.ReadOnly = true;
            this.taTextBox5.Size = new System.Drawing.Size(90, 20);
            this.taTextBox5.TabIndex = 11711;
            this.taTextBox5.xBindingProperty = "TotalLabor";
            this.taTextBox5.xColumnName = "";
            this.taTextBox5.xColumnWidth = 60;
            this.taTextBox5.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox5.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox5.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox5.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox5.xReadOnly = true;
            // 
            // ctrLicensePlate
            // 
            this.ctrLicensePlate.Enabled = false;
            this.ctrLicensePlate.Location = new System.Drawing.Point(137, 79);
            this.ctrLicensePlate.Name = "ctrLicensePlate";
            this.ctrLicensePlate.ReadOnly = true;
            this.ctrLicensePlate.Size = new System.Drawing.Size(100, 20);
            this.ctrLicensePlate.TabIndex = 11713;
            this.ctrLicensePlate.xBindingProperty = "";
            this.ctrLicensePlate.xColumnName = "";
            this.ctrLicensePlate.xColumnWidth = 60;
            this.ctrLicensePlate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrLicensePlate.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.ctrLicensePlate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrLicensePlate.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.ctrLicensePlate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.ctrLicensePlate.xMasked = System32.StaticInfo.Mask.None;
            this.ctrLicensePlate.xReadOnly = false;
            // 
            // ctrVIN
            // 
            this.ctrVIN.Enabled = false;
            this.ctrVIN.Location = new System.Drawing.Point(296, 79);
            this.ctrVIN.Name = "ctrVIN";
            this.ctrVIN.ReadOnly = true;
            this.ctrVIN.Size = new System.Drawing.Size(100, 20);
            this.ctrVIN.TabIndex = 11714;
            this.ctrVIN.xBindingProperty = "";
            this.ctrVIN.xColumnName = "";
            this.ctrVIN.xColumnWidth = 60;
            this.ctrVIN.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrVIN.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.ctrVIN.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrVIN.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.ctrVIN.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.ctrVIN.xMasked = System32.StaticInfo.Mask.None;
            this.ctrVIN.xReadOnly = false;
            // 
            // ctrVehicleYearMakeModel
            // 
            this.ctrVehicleYearMakeModel.Enabled = false;
            this.ctrVehicleYearMakeModel.Location = new System.Drawing.Point(137, 103);
            this.ctrVehicleYearMakeModel.Name = "ctrVehicleYearMakeModel";
            this.ctrVehicleYearMakeModel.ReadOnly = true;
            this.ctrVehicleYearMakeModel.Size = new System.Drawing.Size(259, 20);
            this.ctrVehicleYearMakeModel.TabIndex = 11716;
            this.ctrVehicleYearMakeModel.xBindingProperty = "";
            this.ctrVehicleYearMakeModel.xColumnName = "";
            this.ctrVehicleYearMakeModel.xColumnWidth = 60;
            this.ctrVehicleYearMakeModel.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ctrVehicleYearMakeModel.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.ctrVehicleYearMakeModel.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrVehicleYearMakeModel.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.ctrVehicleYearMakeModel.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.ctrVehicleYearMakeModel.xMasked = System32.StaticInfo.Mask.None;
            this.ctrVehicleYearMakeModel.xReadOnly = false;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(38, 107);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(97, 13);
            this.label52.TabIndex = 11715;
            this.label52.Text = "Year, Make, Model";
            // 
            // btnInspectionItems
            // 
            this.btnInspectionItems.BackColor = System.Drawing.SystemColors.Control;
            this.btnInspectionItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnInspectionItems.Location = new System.Drawing.Point(5, 124);
            this.btnInspectionItems.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnInspectionItems.Name = "btnInspectionItems";
            this.btnInspectionItems.Size = new System.Drawing.Size(118, 25);
            this.btnInspectionItems.TabIndex = 11717;
            this.btnInspectionItems.Text = "Inspection Items";
            this.btnInspectionItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnPrintCustomerCopy
            // 
            this.btnPrintCustomerCopy.Location = new System.Drawing.Point(310, 124);
            this.btnPrintCustomerCopy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnPrintCustomerCopy.Name = "btnPrintCustomerCopy";
            this.btnPrintCustomerCopy.Size = new System.Drawing.Size(131, 25);
            this.btnPrintCustomerCopy.TabIndex = 11718;
            this.btnPrintCustomerCopy.Text = "Print Customer Copy";                        
            // 
            // btnPrintMechanicCopy
            //             
            this.btnPrintMechanicCopy.Location = new System.Drawing.Point(447, 124);
            this.btnPrintMechanicCopy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnPrintMechanicCopy.Name = "btnPrintMechanicCopy";
            this.btnPrintMechanicCopy.Size = new System.Drawing.Size(131, 25);
            this.btnPrintMechanicCopy.TabIndex = 11719;
            this.btnPrintMechanicCopy.Text = "Print Mechanic Copy";            
            // 
            // btnAddServices
            //             
            this.btnAddServices.Location = new System.Drawing.Point(447, 81);
            this.btnAddServices.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAddServices.Name = "btnAddServices";
            this.btnAddServices.Size = new System.Drawing.Size(131, 38);
            this.btnAddServices.TabIndex = 11720;
            this.btnAddServices.Text = "Add Services to Workorder";            
            // 
            // ctrVehicleInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrVehicleInspection";
            this.Size = new System.Drawing.Size(807, 461);
            this.xBNCountItemIsVisible = false;
            this.xBNPositionItemIsVisible = false;
            this.xBNSeparator1IsVisible = false;
            this.xBNSeparator2IsVisible = false;
            this.xBNSeparatorIsVisible = false;
            this.xbtnBNAddItemIsVisible = false;
            this.xbtnBNDeleteItemIsVisible = false;
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNMoveFirstItemIsVisible = false;
            this.xbtnBNMoveLastItemIsVisible = false;
            this.xbtnBNMoveNextItemIsVisible = false;
            this.xbtnBNMovePreviousItemIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "VI";
            this.xTableName = "VehicleInspection";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInspactionDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label41;
        private ControlLibrary.TAComboBox ctrCustomerID;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label37;
        private ControlLibrary.TATextBox ctrWorkOrderNo;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.libDataGridView DGVInspactionDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ControlLibrary.TATextBox taTextBox2;
        private ControlLibrary.TATextBox taTextBox4;
        private ControlLibrary.TATextBox taTextBox5;
        private ControlLibrary.TATextBox taTextBox3;
        private ControlLibrary.TATextBox ctrVIN;
        private ControlLibrary.TATextBox ctrLicensePlate;
        private ControlLibrary.TATextBox ctrVehicleYearMakeModel;
        private System.Windows.Forms.Label label52;
        private ControlLibrary.TAButton btnInspectionItems;
        private ControlLibrary.TAButton btnPrintMechanicCopy;
        private ControlLibrary.TAButton btnPrintCustomerCopy;
        private ControlLibrary.DGVTextBoxColumn ID;
        private ControlLibrary.DGVTextBoxColumn InspectionHeadID;
        private ControlLibrary.DGVTextBoxColumn ItemCatalog;
        private ControlLibrary.DGVTextBoxColumn CategoryItem;
        private ControlLibrary.DGVCheckBoxColumn IsChange;
        private ControlLibrary.DGVCheckBoxColumn IsRepair;
        private ControlLibrary.DGVCheckBoxColumn IsAccept;
        private ControlLibrary.DGVCheckBoxColumn IsDecline;
        private ControlLibrary.DGVCheckBoxColumn IsIgnore;
        private ControlLibrary.DGVTextBoxColumn Notes;
        private ControlLibrary.DGVTextBoxColumn ItemPrice;
        private ControlLibrary.DGVTextBoxColumn LaborPrice;
        private ControlLibrary.DGVTextBoxColumn FeePrice;
        private ControlLibrary.DGVTextBoxColumn TotalPrice;
        private ControlLibrary.TAButton btnAddServices;
    }
}
