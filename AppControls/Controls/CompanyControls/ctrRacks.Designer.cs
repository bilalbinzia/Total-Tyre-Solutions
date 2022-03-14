namespace AppControls
{
    partial class ctrRacks
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
            this.label58 = new System.Windows.Forms.Label();
            this.cboWarehouse = new ControlLibrary.TAComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cboCompany = new ControlLibrary.TAComboBox();
            this.txtBoxCoCode = new ControlLibrary.TATextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.cboStore = new ControlLibrary.TAComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.lblStore);
            this.WorkingPanel.Controls.Add(this.cboStore);
            this.WorkingPanel.Controls.Add(this.label58);
            this.WorkingPanel.Controls.Add(this.cboWarehouse);
            this.WorkingPanel.Controls.Add(this.cboCompany);
            this.WorkingPanel.Controls.Add(this.label57);
            this.WorkingPanel.Controls.Add(this.label12);
            this.WorkingPanel.Controls.Add(this.txtBoxCoCode);
            this.WorkingPanel.Size = new System.Drawing.Size(424, 202);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxCoCode, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label12, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label57, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.cboCompany, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.cboWarehouse, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label58, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.cboStore, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.lblStore, 0);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(24, 94);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(65, 13);
            this.label58.TabIndex = 11569;
            this.label58.Text = "Warehouse:";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWarehouse.DisplayMember = "CoName";
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(95, 92);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(251, 21);
            this.cboWarehouse.TabIndex = 11568;
            this.cboWarehouse.ValueMember = "ID";
            this.cboWarehouse.xBindingProperty = "WarehouseID";
            this.cboWarehouse.xColumnName = "";
            this.cboWarehouse.xColumnWidth = 60;
            this.cboWarehouse.xDisplayMember = null;
            this.cboWarehouse.xFillByFieldID = null;
            this.cboWarehouse.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.cboWarehouse.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.cboWarehouse.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.cboWarehouse.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.cboWarehouse.xOrderBy = "CoName";
            this.cboWarehouse.xReadOnly = false;
            this.cboWarehouse.xTableName = "Warehouse";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(35, 72);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(54, 13);
            this.label57.TabIndex = 11564;
            this.label57.Text = "Company:";
            // 
            // cboCompany
            // 
            this.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCompany.DisplayMember = "CoName";
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(95, 69);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(251, 21);
            this.cboCompany.TabIndex = 11563;
            this.cboCompany.ValueMember = "ID";
            this.cboCompany.xBindingProperty = "CompanyID";
            this.cboCompany.xColumnName = "";
            this.cboCompany.xColumnWidth = 60;
            this.cboCompany.xDisplayMember = null;
            this.cboCompany.xFillByFieldID = null;
            this.cboCompany.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.cboCompany.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.cboCompany.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.cboCompany.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.cboCompany.xOrderBy = "CoName";
            this.cboCompany.xReadOnly = false;
            this.cboCompany.xTableName = "Company";
            // 
            // txtBoxCoCode
            // 
            this.txtBoxCoCode.Location = new System.Drawing.Point(95, 138);
            this.txtBoxCoCode.Name = "txtBoxCoCode";
            this.txtBoxCoCode.Size = new System.Drawing.Size(99, 20);
            this.txtBoxCoCode.TabIndex = 11523;
            this.txtBoxCoCode.xBindingProperty = "Code";
            this.txtBoxCoCode.xColumnName = "";
            this.txtBoxCoCode.xColumnWidth = 60;
            this.txtBoxCoCode.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxCoCode.xIsEncrypt = System32.StaticInfo.YesNo.Yes;
            this.txtBoxCoCode.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxCoCode.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxCoCode.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxCoCode.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxCoCode.xReadOnly = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(51, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 11524;
            this.label12.Text = "Code :";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(54, 118);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(35, 13);
            this.lblStore.TabIndex = 11571;
            this.lblStore.Text = "Store:";
            // 
            // cboStore
            // 
            this.cboStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStore.DisplayMember = "CoName";
            this.cboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStore.FormattingEnabled = true;
            this.cboStore.Location = new System.Drawing.Point(95, 115);
            this.cboStore.Name = "cboStore";
            this.cboStore.Size = new System.Drawing.Size(251, 21);
            this.cboStore.TabIndex = 11570;
            this.cboStore.ValueMember = "ID";
            this.cboStore.xBindingProperty = "StoreID";
            this.cboStore.xColumnName = "";
            this.cboStore.xColumnWidth = 60;
            this.cboStore.xDisplayMember = "CoName";
            this.cboStore.xFillByFieldID = null;
            this.cboStore.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.cboStore.xIsRequired = System32.StaticInfo.YesNo.No;
            this.cboStore.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.cboStore.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.cboStore.xOrderBy = "CoName";
            this.cboStore.xReadOnly = false;
            this.cboStore.xTableName = "WarehouseStore";
            // 
            // ctrRacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.controlName = "ctrRacks";
            this.Name = "ctrRacks";
            this.Size = new System.Drawing.Size(424, 202);
            this.xBNCountItemIsVisible = false;
            this.xBNPositionItemIsVisible = false;
            this.xBNSeparator1IsVisible = false;
            this.xBNSeparator2IsVisible = false;
            this.xBNSeparatorIsVisible = false;
            this.xbtnBNDeleteItemIsVisible = false;
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNMoveFirstItemIsVisible = false;
            this.xbtnBNMoveLastItemIsVisible = false;
            this.xbtnBNMoveNextItemIsVisible = false;
            this.xbtnBNMovePreviousItemIsVisible = false;
            this.xbtnBNPrintIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "WR";
            this.xTableName = "WarehouseStoreRack";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label58;
        private ControlLibrary.TAComboBox cboWarehouse;
        private System.Windows.Forms.Label label57;
        private ControlLibrary.TAComboBox cboCompany;
        private ControlLibrary.TATextBox txtBoxCoCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStore;
        private ControlLibrary.TAComboBox cboStore;

    }
}
