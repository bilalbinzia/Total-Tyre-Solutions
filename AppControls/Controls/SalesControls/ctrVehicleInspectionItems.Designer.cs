namespace AppControls
{
    partial class ctrVehicleInspectionItems
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TDataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTextBoxColumn1 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvButtonColumn1 = new ControlLibrary.DGVButtonColumn();
            this.dgvTextBoxColumn2 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvTextBoxColumn3 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvTextBoxColumn4 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvTextBoxColumn5 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvTextBoxColumn6 = new ControlLibrary.DGVTextBoxColumn();
            this.dgvCheckBoxColumn1 = new ControlLibrary.DGVCheckBoxColumn();
            this.dgvCheckBoxColumn2 = new ControlLibrary.DGVCheckBoxColumn();
            this.btnAddItems = new ControlLibrary.TAButton();
            this.btnClose = new ControlLibrary.TAButton();
            this.btnUnCheckAll = new ControlLibrary.TAButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 461);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 417);
            this.panel1.TabIndex = 0;
            // 
            // TDataGridView
            // 
            this.TDataGridView.AllowUserToAddRows = false;
            this.TDataGridView.AllowUserToDeleteRows = false;
            this.TDataGridView.AllowUserToResizeColumns = false;
            this.TDataGridView.AllowUserToResizeRows = false;
            this.TDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.TDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TDataGridView.Name = "TDataGridView";
            this.TDataGridView.RowHeadersVisible = true;
            this.TDataGridView.Size = new System.Drawing.Size(403, 417);
            this.TDataGridView.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUnCheckAll);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnAddItems);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 32);
            this.panel2.TabIndex = 1;
            // 
            // dgvTextBoxColumn1
            // 
            this.dgvTextBoxColumn1.HeaderText = "ID";
            this.dgvTextBoxColumn1.IsFilteringColumn = false;
            this.dgvTextBoxColumn1.Name = "dgvTextBoxColumn1";
            this.dgvTextBoxColumn1.Visible = false;
            this.dgvTextBoxColumn1.xBindingProperty = null;
            this.dgvTextBoxColumn1.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn1.xDisplayIndex = 0;
            this.dgvTextBoxColumn1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn1.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvButtonColumn1
            // 
            this.dgvButtonColumn1.HeaderText = "";
            this.dgvButtonColumn1.Name = "dgvButtonColumn1";
            this.dgvButtonColumn1.Text = "-";
            this.dgvButtonColumn1.Width = 15;
            this.dgvButtonColumn1.xButtonType = null;
            // 
            // dgvTextBoxColumn2
            // 
            this.dgvTextBoxColumn2.HeaderText = "AccID";
            this.dgvTextBoxColumn2.IsFilteringColumn = false;
            this.dgvTextBoxColumn2.Name = "dgvTextBoxColumn2";
            this.dgvTextBoxColumn2.Visible = false;
            this.dgvTextBoxColumn2.xBindingProperty = null;
            this.dgvTextBoxColumn2.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn2.xDisplayIndex = 0;
            this.dgvTextBoxColumn2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn2.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvTextBoxColumn3
            // 
            this.dgvTextBoxColumn3.DataPropertyName = "Catalog";
            this.dgvTextBoxColumn3.HeaderText = "Catalog";
            this.dgvTextBoxColumn3.IsFilteringColumn = false;
            this.dgvTextBoxColumn3.Name = "dgvTextBoxColumn3";
            this.dgvTextBoxColumn3.Width = 80;
            this.dgvTextBoxColumn3.xBindingProperty = "Catalog";
            this.dgvTextBoxColumn3.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn3.xDisplayIndex = 0;
            this.dgvTextBoxColumn3.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn3.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvTextBoxColumn4
            // 
            this.dgvTextBoxColumn4.DataPropertyName = "CategoryItem";
            this.dgvTextBoxColumn4.HeaderText = "Description";
            this.dgvTextBoxColumn4.IsFilteringColumn = false;
            this.dgvTextBoxColumn4.Name = "dgvTextBoxColumn4";
            this.dgvTextBoxColumn4.Width = 180;
            this.dgvTextBoxColumn4.xBindingProperty = "CategoryItem";
            this.dgvTextBoxColumn4.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn4.xDisplayIndex = 0;
            this.dgvTextBoxColumn4.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn4.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvTextBoxColumn5
            // 
            this.dgvTextBoxColumn5.DataPropertyName = "AccTypeID";
            this.dgvTextBoxColumn5.HeaderText = "AccTypeID";
            this.dgvTextBoxColumn5.IsFilteringColumn = false;
            this.dgvTextBoxColumn5.Name = "dgvTextBoxColumn5";
            this.dgvTextBoxColumn5.Visible = false;
            this.dgvTextBoxColumn5.xBindingProperty = "AccTypeID";
            this.dgvTextBoxColumn5.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn5.xDisplayIndex = 0;
            this.dgvTextBoxColumn5.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn5.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvTextBoxColumn6
            // 
            this.dgvTextBoxColumn6.DataPropertyName = "AccLevel";
            this.dgvTextBoxColumn6.HeaderText = "AccLevel";
            this.dgvTextBoxColumn6.IsFilteringColumn = false;
            this.dgvTextBoxColumn6.Name = "dgvTextBoxColumn6";
            this.dgvTextBoxColumn6.Visible = false;
            this.dgvTextBoxColumn6.xBindingProperty = "AccLevel";
            this.dgvTextBoxColumn6.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.dgvTextBoxColumn6.xDisplayIndex = 0;
            this.dgvTextBoxColumn6.xIsRequired = System32.StaticInfo.YesNo.No;
            this.dgvTextBoxColumn6.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // dgvCheckBoxColumn1
            // 
            this.dgvCheckBoxColumn1.DataPropertyName = "IsRepair";
            this.dgvCheckBoxColumn1.HeaderText = "IsRepair";
            this.dgvCheckBoxColumn1.Name = "dgvCheckBoxColumn1";
            this.dgvCheckBoxColumn1.Width = 40;
            this.dgvCheckBoxColumn1.xBindingProperty = null;
            // 
            // dgvCheckBoxColumn2
            // 
            this.dgvCheckBoxColumn2.DataPropertyName = "IsChange";
            this.dgvCheckBoxColumn2.HeaderText = "IsChange";
            this.dgvCheckBoxColumn2.Name = "dgvCheckBoxColumn2";
            this.dgvCheckBoxColumn2.Width = 40;
            this.dgvCheckBoxColumn2.xBindingProperty = null;
            // 
            // btnAddItems
            // 
            this.btnAddItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnAddItems.Location = new System.Drawing.Point(234, 4);
            this.btnAddItems.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(81, 25);
            this.btnAddItems.TabIndex = 11681;
            this.btnAddItems.Text = "Add Items";
            this.btnAddItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnClose.Location = new System.Drawing.Point(321, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 25);
            this.btnClose.TabIndex = 11682;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnUnCheckAll.Location = new System.Drawing.Point(27, 4);
            this.btnUnCheckAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(93, 25);
            this.btnUnCheckAll.TabIndex = 11683;
            this.btnUnCheckAll.Text = "Uncheck All";
            this.btnUnCheckAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // ctrVehicleInspectionItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctrVehicleInspectionItems";
            this.Size = new System.Drawing.Size(409, 461);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn1;
        private ControlLibrary.DGVButtonColumn dgvButtonColumn1;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn2;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn3;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn4;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn5;
        private ControlLibrary.DGVTextBoxColumn dgvTextBoxColumn6;
        private ControlLibrary.DGVCheckBoxColumn dgvCheckBoxColumn1;
        private ControlLibrary.DGVCheckBoxColumn dgvCheckBoxColumn2;
        private System.Windows.Forms.DataGridView TDataGridView;
        private ControlLibrary.TAButton btnClose;
        private ControlLibrary.TAButton btnAddItems;
        private ControlLibrary.TAButton btnUnCheckAll;

        
    }
}
