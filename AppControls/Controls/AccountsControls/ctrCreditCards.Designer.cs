namespace AppControls
{
    partial class ctrCreditCards
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
            this.txtBoxName = new ControlLibrary.TATextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taComboBox5 = new ControlLibrary.TAComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.taComboBox5);
            this.WorkingPanel.Controls.Add(this.taCheckBox1);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.txtBoxName);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Size = new System.Drawing.Size(430, 388);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.searchDataGridView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxName, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taCheckBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taComboBox5, 0);
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 139);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(430, 229);
            this.searchDataGridView1.TabIndex = 4;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(109, 60);
            this.txtBoxName.MaxLength = 150;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(120, 20);
            this.txtBoxName.TabIndex = 11599;
            this.txtBoxName.xBindingProperty = "Name";
            this.txtBoxName.xColumnName = "Name";
            this.txtBoxName.xColumnWidth = 120;
            this.txtBoxName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxName.xReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11600;
            this.label4.Text = "Credit Card:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11601;
            this.label1.Text = "Customer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11602;
            this.label2.Text = "Active:";
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(280, 63);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.Size = new System.Drawing.Size(15, 14);
            this.taCheckBox1.TabIndex = 11667;
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = true;
            this.taCheckBox1.xBindingProperty = "Active";
            this.taCheckBox1.xColumnName = null;
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // taComboBox5
            // 
            this.taComboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox5.DisplayMember = "FirstName";
            this.taComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taComboBox5.FormattingEnabled = true;
            this.taComboBox5.Location = new System.Drawing.Point(109, 84);
            this.taComboBox5.Name = "taComboBox5";
            this.taComboBox5.Size = new System.Drawing.Size(184, 21);
            this.taComboBox5.TabIndex = 11668;
            this.taComboBox5.ValueMember = "ID";
            this.taComboBox5.xBindingProperty = "CustomerID";
            this.taComboBox5.xColumnName = "Customer";
            this.taComboBox5.xColumnWidth = 120;
            this.taComboBox5.xDisplayMember = "FirstName";
            this.taComboBox5.xFillByFieldID = null;
            this.taComboBox5.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.taComboBox5.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox5.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox5.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taComboBox5.xOrderBy = "FirstName";
            this.taComboBox5.xReadOnly = false;
            this.taComboBox5.xTableName = "Customer";
            // 
            // ctrCreditCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrCreditCards";
            this.Size = new System.Drawing.Size(430, 388);
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
            this.xPrefixDocNo = "CC";
            this.xTableName = "CreditCards";
            this.Load += new System.EventHandler(this.ctrCreditCards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox txtBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private ControlLibrary.TACheckBox taCheckBox1;
        private ControlLibrary.TAComboBox taComboBox5;
    }
}
