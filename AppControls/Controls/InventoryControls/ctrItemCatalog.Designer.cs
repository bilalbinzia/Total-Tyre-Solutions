namespace AppControls
{
    partial class ctrItemCatalog
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
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taComboBox1 = new ControlLibrary.TAComboBox();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.taTextBox2 = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taTextBox3 = new ControlLibrary.TATextBox();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.taTextBox3);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.taTextBox2);
            this.WorkingPanel.Controls.Add(this.taTextBox1);
            this.WorkingPanel.Controls.Add(this.taComboBox1);
            this.WorkingPanel.Controls.Add(this.taCheckBox1);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Size = new System.Drawing.Size(570, 420);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.searchDataGridView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taCheckBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 160);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(570, 240);
            this.searchDataGridView1.TabIndex = 5;
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(268, 67);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.taCheckBox1.Size = new System.Drawing.Size(56, 17);
            this.taCheckBox1.TabIndex = 1;
            this.taCheckBox1.Text = "Active";
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = true;
            this.taCheckBox1.xBindingProperty = "Active";
            this.taCheckBox1.xColumnName = "Active";
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            // 
            // taComboBox1
            // 
            this.taComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox1.DisplayMember = "Name";
            this.taComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox1.FormattingEnabled = true;
            this.taComboBox1.Location = new System.Drawing.Point(328, 110);
            this.taComboBox1.Name = "taComboBox1";
            this.taComboBox1.Size = new System.Drawing.Size(121, 21);
            this.taComboBox1.TabIndex = 4;
            this.taComboBox1.ValueMember = "ID";
            this.taComboBox1.xBindingProperty = "ItemGroupID";
            this.taComboBox1.xColumnName = "ItemGroup";
            this.taComboBox1.xColumnWidth = 60;
            this.taComboBox1.xDisplayMember = "Name";
            this.taComboBox1.xFillByFieldID = null;
            this.taComboBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taComboBox1.xOrderBy = null;
            this.taComboBox1.xReadOnly = false;
            this.taComboBox1.xTableName = "ItemGroup";
            // 
            // taTextBox1
            // 
            this.taTextBox1.Location = new System.Drawing.Point(139, 88);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(310, 20);
            this.taTextBox1.TabIndex = 2;
            this.taTextBox1.xBindingProperty = "Name";
            this.taTextBox1.xColumnName = "Name";
            this.taTextBox1.xColumnWidth = 160;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // taTextBox2
            // 
            this.taTextBox2.Location = new System.Drawing.Point(139, 110);
            this.taTextBox2.Name = "taTextBox2";
            this.taTextBox2.Size = new System.Drawing.Size(83, 20);
            this.taTextBox2.TabIndex = 3;
            this.taTextBox2.xBindingProperty = "FeePrice";
            this.taTextBox2.xColumnName = "Charges";
            this.taTextBox2.xColumnWidth = 60;
            this.taTextBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xMasked = System32.StaticInfo.Mask.Decimal;
            this.taTextBox2.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 11526;
            this.label1.Text = "Item Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11527;
            this.label2.Text = "Charges";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11528;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11530;
            this.label4.Text = "Catalog";
            // 
            // taTextBox3
            // 
            this.taTextBox3.Location = new System.Drawing.Point(139, 65);
            this.taTextBox3.Name = "taTextBox3";
            this.taTextBox3.Size = new System.Drawing.Size(83, 20);
            this.taTextBox3.TabIndex = 0;
            this.taTextBox3.xBindingProperty = "Catalog";
            this.taTextBox3.xColumnName = "Catalog";
            this.taTextBox3.xColumnWidth = 60;
            this.taTextBox3.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox3.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox3.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox3.xReadOnly = false;
            // 
            // ctrItemCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrItemCatalog";
            this.Size = new System.Drawing.Size(570, 420);
            this.xBNCountItemIsVisible = false;
            this.xBNPositionItemIsVisible = false;
            this.xBNSeparator1IsVisible = false;
            this.xBNSeparator2IsVisible = false;
            this.xBNSeparatorIsVisible = false;
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNMoveFirstItemIsVisible = false;
            this.xbtnBNMoveLastItemIsVisible = false;
            this.xbtnBNMoveNextItemIsVisible = false;
            this.xbtnBNMovePreviousItemIsVisible = false;
            this.xbtnBNPrintIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "Fe";
            this.xTableName = "Fees";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private ControlLibrary.TATextBox taTextBox2;
        private ControlLibrary.TATextBox taTextBox1;
        private ControlLibrary.TAComboBox taComboBox1;
        private ControlLibrary.TACheckBox taCheckBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private ControlLibrary.TATextBox taTextBox3;
    }
}
