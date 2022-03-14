namespace AppControls
{
    partial class ctrZipCode
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
            this.tazSearchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.taTextBox2 = new ControlLibrary.TATextBox();
            this.taComboBox2 = new ControlLibrary.TAComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taComboBox1 = new ControlLibrary.TAComboBox();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taComboBox3 = new ControlLibrary.TAComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.taComboBox3);
            this.WorkingPanel.Controls.Add(this.taComboBox2);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.taComboBox1);
            this.WorkingPanel.Controls.Add(this.taCheckBox1);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.taTextBox2);
            this.WorkingPanel.Controls.Add(this.tazSearchDataGridView1);
            this.WorkingPanel.Size = new System.Drawing.Size(394, 402);
            this.WorkingPanel.Controls.SetChildIndex(this.tazSearchDataGridView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taCheckBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            // 
            // tazSearchDataGridView1
            // 
            this.tazSearchDataGridView1.Location = new System.Drawing.Point(0, 148);
            this.tazSearchDataGridView1.Name = "tazSearchDataGridView1";
            this.tazSearchDataGridView1.Size = new System.Drawing.Size(394, 231);
            this.tazSearchDataGridView1.TabIndex = 11535;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11537;
            this.label1.Text = "ZipCode";
            // 
            // taTextBox2
            // 
            this.taTextBox2.Location = new System.Drawing.Point(247, 107);
            this.taTextBox2.MaxLength = 5;
            this.taTextBox2.Name = "taTextBox2";
            this.taTextBox2.Size = new System.Drawing.Size(121, 20);
            this.taTextBox2.TabIndex = 11536;
            this.taTextBox2.xBindingProperty = "ZipID";
            this.taTextBox2.xColumnName = "ZipCode";
            this.taTextBox2.xColumnWidth = 60;
            this.taTextBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox2.xMasked = System32.StaticInfo.Mask.Digit;
            this.taTextBox2.xReadOnly = false;
            // 
            // taComboBox2
            // 
            this.taComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox2.DisplayMember = "Name";
            this.taComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox2.FormattingEnabled = true;
            this.taComboBox2.Location = new System.Drawing.Point(65, 82);
            this.taComboBox2.Name = "taComboBox2";
            this.taComboBox2.Size = new System.Drawing.Size(121, 21);
            this.taComboBox2.TabIndex = 11543;
            this.taComboBox2.ValueMember = "ID";
            this.taComboBox2.xBindingProperty = "StateID";
            this.taComboBox2.xColumnName = "State";
            this.taComboBox2.xColumnWidth = 130;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11542;
            this.label3.Text = "State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 11541;
            this.label2.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11540;
            this.label4.Text = "Country";
            // 
            // taComboBox1
            // 
            this.taComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox1.DisplayMember = "Name";
            this.taComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox1.FormattingEnabled = true;
            this.taComboBox1.Location = new System.Drawing.Point(65, 58);
            this.taComboBox1.Name = "taComboBox1";
            this.taComboBox1.Size = new System.Drawing.Size(121, 21);
            this.taComboBox1.TabIndex = 11539;
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
            this.taCheckBox1.Location = new System.Drawing.Point(201, 60);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.taCheckBox1.Size = new System.Drawing.Size(56, 17);
            this.taCheckBox1.TabIndex = 11538;
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
            // taComboBox3
            // 
            this.taComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox3.DisplayMember = "Name";
            this.taComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox3.FormattingEnabled = true;
            this.taComboBox3.Location = new System.Drawing.Point(65, 106);
            this.taComboBox3.Name = "taComboBox3";
            this.taComboBox3.Size = new System.Drawing.Size(121, 21);
            this.taComboBox3.TabIndex = 11544;
            this.taComboBox3.ValueMember = "ID";
            this.taComboBox3.xBindingProperty = "CityID";
            this.taComboBox3.xColumnName = "City";
            this.taComboBox3.xColumnWidth = 130;
            this.taComboBox3.xDisplayMember = "Name";
            this.taComboBox3.xFillByFieldID = "StateID";
            this.taComboBox3.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taComboBox3.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox3.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox3.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taComboBox3.xOrderBy = "Name";
            this.taComboBox3.xReadOnly = false;
            this.taComboBox3.xTableName = "City";
            // 
            // ctrZipCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrZipCode";
            this.Size = new System.Drawing.Size(394, 402);
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
            this.xPrefixDocNo = "ZC";
            this.xTableName = "ZipCode";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView tazSearchDataGridView1;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox taTextBox2;
        private ControlLibrary.TAComboBox taComboBox3;
        private ControlLibrary.TAComboBox taComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ControlLibrary.TAComboBox taComboBox1;
        private ControlLibrary.TACheckBox taCheckBox1;
    }
}
