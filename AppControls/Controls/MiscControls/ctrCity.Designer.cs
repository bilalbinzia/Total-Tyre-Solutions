namespace AppControls
{
    partial class ctrCity
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.taComboBox1 = new ControlLibrary.TAComboBox();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taComboBox2 = new ControlLibrary.TAComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.taComboBox2);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.taTextBox1);
            this.WorkingPanel.Controls.Add(this.taComboBox1);
            this.WorkingPanel.Controls.Add(this.taCheckBox1);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Size = new System.Drawing.Size(412, 402);
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
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox2, 0);
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 124);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(412, 258);
            this.searchDataGridView1.TabIndex = 11522;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11535;
            this.label3.Text = "State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 11534;
            this.label2.Text = "City";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11533;
            this.label1.Text = "Country";
            // 
            // taTextBox1
            // 
            this.taTextBox1.Location = new System.Drawing.Point(246, 84);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(121, 20);
            this.taTextBox1.TabIndex = 11531;
            this.taTextBox1.xBindingProperty = "Name";
            this.taTextBox1.xColumnName = "City";
            this.taTextBox1.xColumnWidth = 160;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // taComboBox1
            // 
            this.taComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox1.DisplayMember = "Name";
            this.taComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox1.FormattingEnabled = true;
            this.taComboBox1.Location = new System.Drawing.Point(75, 60);
            this.taComboBox1.Name = "taComboBox1";
            this.taComboBox1.Size = new System.Drawing.Size(121, 21);
            this.taComboBox1.TabIndex = 11530;
            this.taComboBox1.ValueMember = "ID";
            this.taComboBox1.xBindingProperty = "CountryID";
            this.taComboBox1.xColumnName = "Country";
            this.taComboBox1.xColumnWidth = 60;
            this.taComboBox1.xDisplayMember = "Name";
            this.taComboBox1.xFillByFieldID = null;
            this.taComboBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taComboBox1.xOrderBy = "Name";
            this.taComboBox1.xReadOnly = false;
            this.taComboBox1.xTableName = "Country";
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(202, 62);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.taCheckBox1.Size = new System.Drawing.Size(56, 17);
            this.taCheckBox1.TabIndex = 11529;
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
            // taComboBox2
            // 
            this.taComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox2.DisplayMember = "Name";
            this.taComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox2.FormattingEnabled = true;
            this.taComboBox2.Location = new System.Drawing.Point(75, 84);
            this.taComboBox2.Name = "taComboBox2";
            this.taComboBox2.Size = new System.Drawing.Size(121, 21);
            this.taComboBox2.TabIndex = 11536;
            this.taComboBox2.ValueMember = "ID";
            this.taComboBox2.xBindingProperty = "StateID";
            this.taComboBox2.xColumnName = "State";
            this.taComboBox2.xColumnWidth = 60;
            this.taComboBox2.xDisplayMember = "Name";
            this.taComboBox2.xFillByFieldID = "CountryID";
            this.taComboBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taComboBox2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox2.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox2.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taComboBox2.xOrderBy = "Name";
            this.taComboBox2.xReadOnly = false;
            this.taComboBox2.xTableName = "State";
            // 
            // ctrCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrCity";
            this.Size = new System.Drawing.Size(412, 402);
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
            this.xPrefixDocNo = "CT";
            this.xTableName = "City";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private ControlLibrary.TAComboBox taComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox taTextBox1;
        private ControlLibrary.TAComboBox taComboBox1;
        private ControlLibrary.TACheckBox taCheckBox1;
    }
}
