namespace AppControls
{
    partial class ctrPackages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrPackages));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCatalog = new ControlLibrary.TATextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btnAddCatalog = new ControlLibrary.TAButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.taTextBox2 = new ControlLibrary.TATextBox();
            this.taCheckBox2 = new ControlLibrary.TACheckBox();
            this.taTextBox5 = new ControlLibrary.TATextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.DGVPackages = new ControlLibrary.libDataGridView();
            this.ID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemID = new ControlLibrary.DGVTextBoxColumn();
            this.FeeID = new ControlLibrary.DGVTextBoxColumn();
            this.LaborID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemCatalog = new ControlLibrary.DGVTextBoxColumn();
            this.ItemName = new ControlLibrary.DGVTextBoxColumn();
            this.CType = new ControlLibrary.DGVTextBoxColumn();
            this.Qty = new ControlLibrary.DGVTextBoxColumn();
            this.PriceOverride = new ControlLibrary.DGVTextBoxColumn();
            this.Amount = new ControlLibrary.DGVTextBoxColumn();
            this.IsOverride = new ControlLibrary.DGVCheckBoxColumn();
            this.IsOptional = new ControlLibrary.DGVCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.DGVPackages);
            this.WorkingPanel.Controls.Add(this.panel1);
            this.WorkingPanel.Controls.Add(this.panel3);
            this.WorkingPanel.Size = new System.Drawing.Size(570, 420);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.panel3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.panel1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.DGVPackages, 0);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCatalog);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.btnAddCatalog);
            this.panel1.Location = new System.Drawing.Point(3, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 32);
            this.panel1.TabIndex = 11585;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatalog.Location = new System.Drawing.Point(195, 5);
            this.txtCatalog.MaxLength = 150;
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(142, 20);
            this.txtCatalog.TabIndex = 11683;
            this.txtCatalog.xBindingProperty = "";
            this.txtCatalog.xColumnName = "";
            this.txtCatalog.xColumnWidth = 80;
            this.txtCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.txtCatalog.xReadOnly = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(122, 8);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 13);
            this.label39.TabIndex = 11682;
            this.label39.Text = "Add Catalog";
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAddCatalog.ColorFillBlend = cBlendItems1;
            this.btnAddCatalog.DesignerSelected = false;
            this.btnAddCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddCatalog.ImageIndex = 0;
            this.btnAddCatalog.Location = new System.Drawing.Point(353, 3);
            this.btnAddCatalog.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(93, 25);
            this.btnAddCatalog.TabIndex = 11681;
            this.btnAddCatalog.Text = "Add Catalog";
            this.btnAddCatalog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCatalog.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.taTextBox2);
            this.panel3.Controls.Add(this.taCheckBox2);
            this.panel3.Controls.Add(this.taTextBox5);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.taTextBox1);
            this.panel3.Controls.Add(this.taCheckBox1);
            this.panel3.Location = new System.Drawing.Point(3, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(556, 77);
            this.panel3.TabIndex = 11584;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11464;
            this.label1.Text = "Catalog";
            // 
            // taTextBox2
            // 
            this.taTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taTextBox2.Location = new System.Drawing.Point(194, 9);
            this.taTextBox2.Name = "taTextBox2";
            this.taTextBox2.Size = new System.Drawing.Size(102, 20);
            this.taTextBox2.TabIndex = 0;
            this.taTextBox2.xBindingProperty = "Catalog";
            this.taTextBox2.xColumnName = null;
            this.taTextBox2.xColumnWidth = 60;
            this.taTextBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox2.xReadOnly = false;
            // 
            // taCheckBox2
            // 
            this.taCheckBox2.AutoSize = true;
            this.taCheckBox2.Location = new System.Drawing.Point(304, 55);
            this.taCheckBox2.Name = "taCheckBox2";
            this.taCheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.taCheckBox2.Size = new System.Drawing.Size(99, 17);
            this.taCheckBox2.TabIndex = 4;
            this.taCheckBox2.Text = "Show In Button";
            this.taCheckBox2.ToolTipText = null;
            this.taCheckBox2.UseVisualStyleBackColor = false;
            this.taCheckBox2.xBindingProperty = "ShowInButton";
            this.taCheckBox2.xColumnName = null;
            this.taCheckBox2.xColumnWidth = 60;
            this.taCheckBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox2.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taCheckBox2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // taTextBox5
            // 
            this.taTextBox5.Location = new System.Drawing.Point(195, 53);
            this.taTextBox5.MaxLength = 150;
            this.taTextBox5.Name = "taTextBox5";
            this.taTextBox5.Size = new System.Drawing.Size(72, 20);
            this.taTextBox5.TabIndex = 11468;
            this.taTextBox5.xBindingProperty = "PackageWithTax";
            this.taTextBox5.xColumnName = "";
            this.taTextBox5.xColumnWidth = 60;
            this.taTextBox5.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox5.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox5.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox5.xReadOnly = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(94, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 11462;
            this.label13.Text = "Package with Tax";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 11370;
            this.label8.Text = "Package Name";
            // 
            // taTextBox1
            // 
            this.taTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taTextBox1.Location = new System.Drawing.Point(194, 31);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(209, 20);
            this.taTextBox1.TabIndex = 2;
            this.taTextBox1.xBindingProperty = "Name";
            this.taTextBox1.xColumnName = null;
            this.taTextBox1.xColumnWidth = 60;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(347, 11);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.taCheckBox1.Size = new System.Drawing.Size(56, 17);
            this.taCheckBox1.TabIndex = 1;
            this.taCheckBox1.Text = "Active";
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = false;
            this.taCheckBox1.xBindingProperty = "Active";
            this.taCheckBox1.xColumnName = null;
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // DGVPackages
            // 
            this.DGVPackages.AllowUserToAddRows = false;
            this.DGVPackages.AllowUserToDeleteRows = false;
            this.DGVPackages.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGVPackages.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPackages.BackgroundColor = System.Drawing.Color.White;
            this.DGVPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPackages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemID,
            this.FeeID,
            this.LaborID,
            this.ItemCatalog,
            this.ItemName,
            this.CType,
            this.Qty,
            this.PriceOverride,
            this.Amount,
            this.IsOverride,
            this.IsOptional});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPackages.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPackages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVPackages.GridColor = System.Drawing.Color.White;
            this.DGVPackages.Location = new System.Drawing.Point(0, 187);
            this.DGVPackages.Name = "DGVPackages";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPackages.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPackages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            this.DGVPackages.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVPackages.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVPackages.ShowRowErrors = false;
            this.DGVPackages.Size = new System.Drawing.Size(570, 213);
            this.DGVPackages.TabIndex = 5;
            this.DGVPackages.VirtualMode = true;
            this.DGVPackages.xIsAutoNo = true;
            this.DGVPackages.xIsDeleteColumn = true;
            this.DGVPackages.xOrderBy = null;
            this.DGVPackages.xTableName = "WarehousePackagesDetail";
            this.DGVPackages.xTableQuery = resources.GetString("DGVPackages.xTableQuery");
            this.DGVPackages.xTableRelation = "FK_WarehousePackagesDetail_WarehousePackages";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.IsFilteringColumn = false;
            this.ID.Name = "ID";
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
            this.ItemID.Visible = false;
            this.ItemID.xBindingProperty = "ItemID";
            this.ItemID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemID.xDisplayIndex = 0;
            this.ItemID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // FeeID
            // 
            this.FeeID.DataPropertyName = "FeeID";
            this.FeeID.HeaderText = "FeeID";
            this.FeeID.IsFilteringColumn = false;
            this.FeeID.Name = "FeeID";
            this.FeeID.ReadOnly = true;
            this.FeeID.Visible = false;
            this.FeeID.xBindingProperty = "FeeID";
            this.FeeID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.FeeID.xDisplayIndex = 0;
            this.FeeID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.FeeID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // LaborID
            // 
            this.LaborID.DataPropertyName = "LaborID";
            this.LaborID.HeaderText = "LaborID";
            this.LaborID.IsFilteringColumn = false;
            this.LaborID.Name = "LaborID";
            this.LaborID.ReadOnly = true;
            this.LaborID.Visible = false;
            this.LaborID.xBindingProperty = "LaborID";
            this.LaborID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.LaborID.xDisplayIndex = 0;
            this.LaborID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.LaborID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemCatalog
            // 
            this.ItemCatalog.DataPropertyName = "Catalog";
            this.ItemCatalog.HeaderText = "Catalog";
            this.ItemCatalog.IsFilteringColumn = false;
            this.ItemCatalog.Name = "ItemCatalog";
            this.ItemCatalog.ReadOnly = true;
            this.ItemCatalog.xBindingProperty = "Catalog";
            this.ItemCatalog.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemCatalog.xDisplayIndex = 0;
            this.ItemCatalog.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ItemCatalog.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.HeaderText = "Description";
            this.ItemName.IsFilteringColumn = false;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 300;
            this.ItemName.xBindingProperty = "Name";
            this.ItemName.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemName.xDisplayIndex = 0;
            this.ItemName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ItemName.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // CType
            // 
            this.CType.DataPropertyName = "CType";
            this.CType.HeaderText = "Type";
            this.CType.IsFilteringColumn = false;
            this.CType.Name = "CType";
            this.CType.ReadOnly = true;
            this.CType.Width = 30;
            this.CType.xBindingProperty = "CType";
            this.CType.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.CType.xDisplayIndex = 0;
            this.CType.xIsRequired = System32.StaticInfo.YesNo.No;
            this.CType.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Qty";
            this.Qty.IsFilteringColumn = false;
            this.Qty.Name = "Qty";
            this.Qty.Width = 40;
            this.Qty.xBindingProperty = "Qty";
            this.Qty.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.Qty.xDisplayIndex = 0;
            this.Qty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Qty.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // PriceOverride
            // 
            this.PriceOverride.DataPropertyName = "PriceOverride";
            this.PriceOverride.HeaderText = "PriceOverride";
            this.PriceOverride.IsFilteringColumn = false;
            this.PriceOverride.Name = "PriceOverride";
            this.PriceOverride.Width = 60;
            this.PriceOverride.xBindingProperty = "PriceOverride";
            this.PriceOverride.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.PriceOverride.xDisplayIndex = 0;
            this.PriceOverride.xIsRequired = System32.StaticInfo.YesNo.No;
            this.PriceOverride.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.IsFilteringColumn = false;
            this.Amount.Name = "Amount";
            this.Amount.Width = 60;
            this.Amount.xBindingProperty = "Amount";
            this.Amount.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Amount.xDisplayIndex = 0;
            this.Amount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Amount.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // IsOverride
            // 
            this.IsOverride.DataPropertyName = "IsOverride";
            this.IsOverride.HeaderText = "IsOverride";
            this.IsOverride.Name = "IsOverride";
            this.IsOverride.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsOverride.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsOverride.Width = 40;
            this.IsOverride.xBindingProperty = null;
            // 
            // IsOptional
            // 
            this.IsOptional.DataPropertyName = "IsOptional";
            this.IsOptional.HeaderText = "IsOptional";
            this.IsOptional.Name = "IsOptional";
            this.IsOptional.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsOptional.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsOptional.Width = 40;
            this.IsOptional.xBindingProperty = null;
            // 
            // ctrPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.controlName = "Warehouse Packages";
            this.Name = "ctrPackages";
            this.Size = new System.Drawing.Size(570, 420);
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNPrintIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "Pkg";
            this.xTableName = "WarehousePackages";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPackages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.libDataGridView DGVPackages;
        private ControlLibrary.TACheckBox taCheckBox1;
        private ControlLibrary.TATextBox taTextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private ControlLibrary.TACheckBox taCheckBox2;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox taTextBox2;
        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.TATextBox taTextBox5;
        private ControlLibrary.TAButton btnAddCatalog;
        private ControlLibrary.TATextBox txtCatalog;
        private System.Windows.Forms.Label label39;
        private ControlLibrary.DGVTextBoxColumn ID;
        private ControlLibrary.DGVTextBoxColumn ItemID;
        private ControlLibrary.DGVTextBoxColumn FeeID;
        private ControlLibrary.DGVTextBoxColumn LaborID;
        private ControlLibrary.DGVTextBoxColumn ItemCatalog;
        private ControlLibrary.DGVTextBoxColumn ItemName;
        private ControlLibrary.DGVTextBoxColumn CType;
        private ControlLibrary.DGVTextBoxColumn Qty;
        private ControlLibrary.DGVTextBoxColumn PriceOverride;
        private ControlLibrary.DGVTextBoxColumn Amount;
        private ControlLibrary.DGVCheckBoxColumn IsOverride;
        private ControlLibrary.DGVCheckBoxColumn IsOptional;

    }
}
