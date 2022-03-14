namespace AppControls
{
    partial class ctrProfitBreakDown
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
            this.searchDataGridView1 = new ControlLibrary.libDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RowHeader = new ControlLibrary.DGVTextBoxColumn();
            this.Cost = new ControlLibrary.DGVTextBoxColumn();
            this.Qty = new ControlLibrary.DGVTextBoxColumn();
            this.Price = new ControlLibrary.DGVTextBoxColumn();
            this.FET = new ControlLibrary.DGVTextBoxColumn();
            this.Profit = new ControlLibrary.DGVTextBoxColumn();
            this.Margin = new ControlLibrary.DGVTextBoxColumn();
            this.Markup = new ControlLibrary.DGVTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.AllowUserToAddRows = false;
            this.searchDataGridView1.AllowUserToDeleteRows = false;
            this.searchDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.searchDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.searchDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowHeader,
            this.Cost,
            this.Qty,
            this.Price,
            this.FET,
            this.Profit,
            this.Margin,
            this.Markup});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchDataGridView1.Name = "searchDataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.searchDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.searchDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.searchDataGridView1.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.searchDataGridView1.ShowRowErrors = false;
            this.searchDataGridView1.Size = new System.Drawing.Size(489, 169);
            this.searchDataGridView1.TabIndex = 0;
            this.searchDataGridView1.VirtualMode = true;
            this.searchDataGridView1.xIsAutoNo = true;
            this.searchDataGridView1.xIsDeleteColumn = false;
            this.searchDataGridView1.xOrderBy = null;
            this.searchDataGridView1.xTableName = "ItemType";
            this.searchDataGridView1.xTableQuery = null;
            this.searchDataGridView1.xTableRelation = "ItemType";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchDataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 189);
            this.panel1.TabIndex = 1;
            // 
            // RowHeader
            // 
            this.RowHeader.DataPropertyName = "RowHeader";
            this.RowHeader.HeaderText = "";
            this.RowHeader.IsFilteringColumn = false;
            this.RowHeader.Name = "RowHeader";
            this.RowHeader.Width = 120;
            this.RowHeader.xBindingProperty = "RowHeader";
            this.RowHeader.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.RowHeader.xDisplayIndex = 0;
            this.RowHeader.xIsRequired = System32.StaticInfo.YesNo.No;
            this.RowHeader.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Cost";
            this.Cost.IsFilteringColumn = false;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 50;
            this.Cost.xBindingProperty = "Cost";
            this.Cost.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Cost.xDisplayIndex = 0;
            this.Cost.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Cost.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Qty";
            this.Qty.IsFilteringColumn = false;
            this.Qty.Name = "Qty";
            this.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Qty.Width = 50;
            this.Qty.xBindingProperty = "Qty";
            this.Qty.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Qty.xDisplayIndex = 0;
            this.Qty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Qty.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.IsFilteringColumn = false;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 50;
            this.Price.xBindingProperty = "Price";
            this.Price.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Price.xDisplayIndex = 0;
            this.Price.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Price.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // FET
            // 
            this.FET.DataPropertyName = "FET";
            this.FET.HeaderText = "FET";
            this.FET.IsFilteringColumn = false;
            this.FET.Name = "FET";
            this.FET.ReadOnly = true;
            this.FET.Width = 50;
            this.FET.xBindingProperty = "FET";
            this.FET.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.FET.xDisplayIndex = 0;
            this.FET.xIsRequired = System32.StaticInfo.YesNo.No;
            this.FET.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // Profit
            // 
            this.Profit.DataPropertyName = "Profit";
            this.Profit.HeaderText = "Profit";
            this.Profit.IsFilteringColumn = false;
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.Width = 50;
            this.Profit.xBindingProperty = "Profit";
            this.Profit.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Profit.xDisplayIndex = 0;
            this.Profit.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Profit.xShowCurrency = System32.StaticInfo.YesNo.Yes;
            // 
            // Margin
            // 
            this.Margin.DataPropertyName = "Margin";
            this.Margin.HeaderText = "Margin%";
            this.Margin.IsFilteringColumn = false;
            this.Margin.Name = "Margin";
            this.Margin.ReadOnly = true;
            this.Margin.Width = 55;
            this.Margin.xBindingProperty = "Margin";
            this.Margin.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Margin.xDisplayIndex = 0;
            this.Margin.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Margin.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Markup
            // 
            this.Markup.DataPropertyName = "Markup";
            this.Markup.HeaderText = "Markup%";
            this.Markup.IsFilteringColumn = false;
            this.Markup.Name = "Markup";
            this.Markup.ReadOnly = true;
            this.Markup.Visible = false;
            this.Markup.Width = 55;
            this.Markup.xBindingProperty = "Markup";
            this.Markup.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Markup.xDisplayIndex = 0;
            this.Markup.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Markup.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ctrProfitBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrProfitBreakDown";
            this.Size = new System.Drawing.Size(489, 189);
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.libDataGridView searchDataGridView1;
        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.DGVTextBoxColumn RowHeader;
        private ControlLibrary.DGVTextBoxColumn Cost;
        private ControlLibrary.DGVTextBoxColumn Qty;
        private ControlLibrary.DGVTextBoxColumn Price;
        private ControlLibrary.DGVTextBoxColumn FET;
        private ControlLibrary.DGVTextBoxColumn Profit;
        private ControlLibrary.DGVTextBoxColumn Margin;
        private ControlLibrary.DGVTextBoxColumn Markup;
    }
}
