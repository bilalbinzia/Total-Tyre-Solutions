namespace AppControls
{
    partial class ctrItemGroupItems
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
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveClose = new ControlLibrary.TAButton();
            this.DGVItemGroupItems = new ControlLibrary.libDataGridView();
            this.ID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemGroupID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemID = new ControlLibrary.DGVTextBoxColumn();
            this.Delete = new ControlLibrary.DGVButtonColumn();
            this.Counter = new ControlLibrary.DGVTextBoxColumn();
            this.ItemSize = new ControlLibrary.DGVTextBoxColumn();
            this.ItemCatalog = new ControlLibrary.DGVTextBoxColumn();
            this.ItemDescription = new ControlLibrary.DGVTextBoxColumn();
            this.Type = new ControlLibrary.DGVTextBoxColumn();
            this.btnAddItem = new ControlLibrary.TAButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemGroupItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveClose);
            this.panel1.Controls.Add(this.DGVItemGroupItems);
            this.panel1.Controls.Add(this.btnAddItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 310);
            this.panel1.TabIndex = 0;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSaveClose.ColorFillBlend = cBlendItems1;
            this.btnSaveClose.DesignerSelected = false;
            this.btnSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSaveClose.ImageIndex = 0;
            this.btnSaveClose.Location = new System.Drawing.Point(485, 10);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(103, 26);
            this.btnSaveClose.TabIndex = 11673;
            this.btnSaveClose.Text = "Save && Close";
            this.btnSaveClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveClose.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // DGVItemGroupItems
            // 
            this.DGVItemGroupItems.AllowUserToAddRows = false;
            this.DGVItemGroupItems.AllowUserToDeleteRows = false;
            this.DGVItemGroupItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DGVItemGroupItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVItemGroupItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVItemGroupItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemGroupID,
            this.ItemID,
            this.Delete,
            this.Counter,
            this.ItemSize,
            this.ItemCatalog,
            this.ItemDescription,
            this.Type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVItemGroupItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVItemGroupItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVItemGroupItems.Location = new System.Drawing.Point(0, 43);
            this.DGVItemGroupItems.Name = "DGVItemGroupItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVItemGroupItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVItemGroupItems.RowHeadersVisible = false;
            this.DGVItemGroupItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.DGVItemGroupItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVItemGroupItems.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVItemGroupItems.ShowRowErrors = false;
            this.DGVItemGroupItems.Size = new System.Drawing.Size(595, 267);
            this.DGVItemGroupItems.TabIndex = 11672;
            this.DGVItemGroupItems.VirtualMode = true;
            this.DGVItemGroupItems.xIsAutoNo = true;
            this.DGVItemGroupItems.xIsDeleteColumn = true;
            this.DGVItemGroupItems.xOrderBy = null;
            this.DGVItemGroupItems.xTableName = "";
            this.DGVItemGroupItems.xTableQuery = null;
            this.DGVItemGroupItems.xTableRelation = "";
            this.DGVItemGroupItems.Click += new System.EventHandler(this.DGVItemGroupItems_Click);
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
            // ItemGroupID
            // 
            this.ItemGroupID.DataPropertyName = "ItemGroupID";
            this.ItemGroupID.HeaderText = "ItemGroupID";
            this.ItemGroupID.IsFilteringColumn = false;
            this.ItemGroupID.Name = "ItemGroupID";
            this.ItemGroupID.Visible = false;
            this.ItemGroupID.xBindingProperty = "ItemGroupID";
            this.ItemGroupID.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemGroupID.xDisplayIndex = 0;
            this.ItemGroupID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemGroupID.xShowCurrency = System32.StaticInfo.YesNo.No;
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
            // Delete
            // 
            this.Delete.HeaderText = "X";
            this.Delete.Tag = "ItemID";
            this.Delete.Text = "X";
            this.Delete.Name = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 20;
            this.Delete.xButtonType = null;
            // 
            // Counter
            // 
            this.Counter.HeaderText = "N";
            this.Counter.IsFilteringColumn = false;
            this.Counter.Name = "Counter";
            this.Counter.ToolTipText = "AutoNumber";
            this.Counter.Width = 25;
            this.Counter.xBindingProperty = null;
            this.Counter.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Counter.xDisplayIndex = 0;
            this.Counter.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Counter.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemSize
            // 
            this.ItemSize.DataPropertyName = "ItemSize";
            this.ItemSize.HeaderText = "Item Size";
            this.ItemSize.IsFilteringColumn = false;
            this.ItemSize.Name = "ItemSize";
            this.ItemSize.ReadOnly = true;
            this.ItemSize.Width = 120;
            this.ItemSize.xBindingProperty = "ItemSize";
            this.ItemSize.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemSize.xDisplayIndex = 0;
            this.ItemSize.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemSize.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemCatalog
            // 
            this.ItemCatalog.DataPropertyName = "Catalog";
            this.ItemCatalog.HeaderText = "Item Catalog";
            this.ItemCatalog.IsFilteringColumn = false;
            this.ItemCatalog.Name = "ItemCatalog";
            this.ItemCatalog.ReadOnly = true;
            this.ItemCatalog.Width = 120;
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
            this.ItemDescription.Width = 250;
            this.ItemDescription.xBindingProperty = "Name";
            this.ItemDescription.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.ItemDescription.xDisplayIndex = 0;
            this.ItemDescription.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ItemDescription.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.IsFilteringColumn = false;
            this.Type.Name = "Type";
            this.Type.Width = 50;
            this.Type.xBindingProperty = "Type";
            this.Type.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Type.xDisplayIndex = 0;
            this.Type.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Type.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAddItem.ColorFillBlend = cBlendItems2;
            this.btnAddItem.DesignerSelected = false;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddItem.ImageIndex = 0;
            this.btnAddItem.Location = new System.Drawing.Point(17, 10);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(79, 26);
            this.btnAddItem.TabIndex = 11671;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ctrItemGroupItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrItemGroupItems";
            this.Size = new System.Drawing.Size(595, 310);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemGroupItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAButton btnAddItem;
        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.libDataGridView DGVItemGroupItems;
        private ControlLibrary.TAButton btnSaveClose;
        private ControlLibrary.DGVTextBoxColumn ID;
        private ControlLibrary.DGVTextBoxColumn ItemGroupID;
        private ControlLibrary.DGVTextBoxColumn ItemID;
        private ControlLibrary.DGVButtonColumn Delete;
        private ControlLibrary.DGVTextBoxColumn Counter;
        private ControlLibrary.DGVTextBoxColumn ItemSize;
        private ControlLibrary.DGVTextBoxColumn ItemCatalog;
        private ControlLibrary.DGVTextBoxColumn ItemDescription;
        private ControlLibrary.DGVTextBoxColumn Type;
    }
}
