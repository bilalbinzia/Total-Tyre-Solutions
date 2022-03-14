namespace Accounts.Parameter
{
    partial class ctrAcountsLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrAcountsLedger));
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLedgerFrom = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBoxShowZeroBalances = new System.Windows.Forms.CheckBox();
            this.cboBoxAccountTo = new ControlLibrary.TAComboBox();
            this.cboBoxAccountFrom = new ControlLibrary.TAComboBox();
            this.DateTo = new ControlLibrary.TADateControl();
            this.DateFrom = new ControlLibrary.TADateControl();
            this.cboBoxCriteriaByCodeAccountTo = new ControlLibrary.MultiColumnComboBox();
            this.cboBoxCriteriaByCodeAccountFrom = new ControlLibrary.MultiColumnComboBox();
            this.lblAccountTo = new System.Windows.Forms.Label();
            this.lblAccountFrom = new System.Windows.Forms.Label();
            this.chkBoxCriteriaByCode = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboCriteria
            // 
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "This Week",
            "This Month",
            "This Calender Year",
            "This Financial Year",
            "Last Week",
            "Last Month",
            "Last Calender Year",
            "Last Financial Year",
            "Custom"});
            this.cboCriteria.Location = new System.Drawing.Point(11, 14);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(205, 21);
            this.cboCriteria.TabIndex = 0;
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(141, 292);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(75, 23);
            this.btnLoadReport.TabIndex = 5;
            this.btnLoadReport.Text = "Load Report";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date To:";
            // 
            // lblLedgerFrom
            // 
            this.lblLedgerFrom.AutoSize = true;
            this.lblLedgerFrom.Location = new System.Drawing.Point(8, 103);
            this.lblLedgerFrom.Name = "lblLedgerFrom";
            this.lblLedgerFrom.Size = new System.Drawing.Size(47, 13);
            this.lblLedgerFrom.TabIndex = 8;
            this.lblLedgerFrom.Text = "Account";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "To:";
            this.label6.Visible = false;
            // 
            // chkBoxShowZeroBalances
            // 
            this.chkBoxShowZeroBalances.AutoSize = true;
            this.chkBoxShowZeroBalances.Location = new System.Drawing.Point(8, 278);
            this.chkBoxShowZeroBalances.Name = "chkBoxShowZeroBalances";
            this.chkBoxShowZeroBalances.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBoxShowZeroBalances.Size = new System.Drawing.Size(125, 17);
            this.chkBoxShowZeroBalances.TabIndex = 10;
            this.chkBoxShowZeroBalances.Text = "Show Zero Balances";
            this.chkBoxShowZeroBalances.UseVisualStyleBackColor = true;
            this.chkBoxShowZeroBalances.Visible = false;
            // 
            // cboBoxAccountTo
            // 
            this.cboBoxAccountTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBoxAccountTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBoxAccountTo.FormattingEnabled = true;
            this.cboBoxAccountTo.Location = new System.Drawing.Point(55, 145);
            this.cboBoxAccountTo.Name = "cboBoxAccountTo";
            this.cboBoxAccountTo.Size = new System.Drawing.Size(161, 21);
            this.cboBoxAccountTo.TabIndex = 12;
            this.cboBoxAccountTo.Visible = false;
            // 
            // cboBoxAccountFrom
            // 
            this.cboBoxAccountFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBoxAccountFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBoxAccountFrom.FormattingEnabled = true;
            this.cboBoxAccountFrom.Location = new System.Drawing.Point(55, 120);
            this.cboBoxAccountFrom.Name = "cboBoxAccountFrom";
            this.cboBoxAccountFrom.Size = new System.Drawing.Size(161, 21);
            this.cboBoxAccountFrom.TabIndex = 11;
            // 
            // DateTo
            // 
            this.DateTo.Location = new System.Drawing.Point(88, 71);
            this.DateTo.Margin = new System.Windows.Forms.Padding(0);
            this.DateTo.Name = "DateTo";
            this.DateTo.Required = false;
            this.DateTo.Size = new System.Drawing.Size(102, 20);
            this.DateTo.TabIndex = 2;
            // 
            // DateFrom
            // 
            this.DateFrom.Location = new System.Drawing.Point(88, 44);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Required = false;
            this.DateFrom.Size = new System.Drawing.Size(102, 20);
            this.DateFrom.TabIndex = 1;
            // 
            // cboBoxCriteriaByCodeAccountTo
            // 
            this.cboBoxCriteriaByCodeAccountTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBoxCriteriaByCodeAccountTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBoxCriteriaByCodeAccountTo.Columns = ((System.Collections.Generic.List<System.Tuple<string, int>>)(resources.GetObject("cboBoxCriteriaByCodeAccountTo.Columns")));
            this.cboBoxCriteriaByCodeAccountTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBoxCriteriaByCodeAccountTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxCriteriaByCodeAccountTo.DropDownWidth = 228;
            this.cboBoxCriteriaByCodeAccountTo.Enabled = false;
            this.cboBoxCriteriaByCodeAccountTo.FormattingEnabled = true;
            this.cboBoxCriteriaByCodeAccountTo.Location = new System.Drawing.Point(55, 231);
            this.cboBoxCriteriaByCodeAccountTo.Name = "cboBoxCriteriaByCodeAccountTo";
            this.cboBoxCriteriaByCodeAccountTo.Size = new System.Drawing.Size(161, 21);
            this.cboBoxCriteriaByCodeAccountTo.TabIndex = 14;
            this.cboBoxCriteriaByCodeAccountTo.Visible = false;
            // 
            // cboBoxCriteriaByCodeAccountFrom
            // 
            this.cboBoxCriteriaByCodeAccountFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBoxCriteriaByCodeAccountFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBoxCriteriaByCodeAccountFrom.Columns = ((System.Collections.Generic.List<System.Tuple<string, int>>)(resources.GetObject("cboBoxCriteriaByCodeAccountFrom.Columns")));
            this.cboBoxCriteriaByCodeAccountFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBoxCriteriaByCodeAccountFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxCriteriaByCodeAccountFrom.DropDownWidth = 228;
            this.cboBoxCriteriaByCodeAccountFrom.Enabled = false;
            this.cboBoxCriteriaByCodeAccountFrom.FormattingEnabled = true;
            this.cboBoxCriteriaByCodeAccountFrom.Location = new System.Drawing.Point(55, 205);
            this.cboBoxCriteriaByCodeAccountFrom.Name = "cboBoxCriteriaByCodeAccountFrom";
            this.cboBoxCriteriaByCodeAccountFrom.Size = new System.Drawing.Size(161, 21);
            this.cboBoxCriteriaByCodeAccountFrom.TabIndex = 13;
            this.cboBoxCriteriaByCodeAccountFrom.Visible = false;
            // 
            // lblAccountTo
            // 
            this.lblAccountTo.AutoSize = true;
            this.lblAccountTo.Location = new System.Drawing.Point(8, 235);
            this.lblAccountTo.Name = "lblAccountTo";
            this.lblAccountTo.Size = new System.Drawing.Size(23, 13);
            this.lblAccountTo.TabIndex = 16;
            this.lblAccountTo.Text = "To:";
            this.lblAccountTo.Visible = false;
            // 
            // lblAccountFrom
            // 
            this.lblAccountFrom.AutoSize = true;
            this.lblAccountFrom.Location = new System.Drawing.Point(8, 208);
            this.lblAccountFrom.Name = "lblAccountFrom";
            this.lblAccountFrom.Size = new System.Drawing.Size(33, 13);
            this.lblAccountFrom.TabIndex = 15;
            this.lblAccountFrom.Text = "From:";
            this.lblAccountFrom.Visible = false;
            // 
            // chkBoxCriteriaByCode
            // 
            this.chkBoxCriteriaByCode.AutoSize = true;
            this.chkBoxCriteriaByCode.Location = new System.Drawing.Point(69, 182);
            this.chkBoxCriteriaByCode.Name = "chkBoxCriteriaByCode";
            this.chkBoxCriteriaByCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBoxCriteriaByCode.Size = new System.Drawing.Size(144, 17);
            this.chkBoxCriteriaByCode.TabIndex = 17;
            this.chkBoxCriteriaByCode.Text = "Criteria By Account Code";
            this.chkBoxCriteriaByCode.UseVisualStyleBackColor = true;
            this.chkBoxCriteriaByCode.Visible = false;
            this.chkBoxCriteriaByCode.CheckedChanged += new System.EventHandler(this.chkBoxCriteriaByCode_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "From:";
            // 
            // ctrAcountsLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkBoxCriteriaByCode);
            this.Controls.Add(this.cboBoxCriteriaByCodeAccountTo);
            this.Controls.Add(this.cboBoxCriteriaByCodeAccountFrom);
            this.Controls.Add(this.lblAccountTo);
            this.Controls.Add(this.lblAccountFrom);
            this.Controls.Add(this.cboBoxAccountTo);
            this.Controls.Add(this.cboBoxAccountFrom);
            this.Controls.Add(this.chkBoxShowZeroBalances);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLedgerFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.cboCriteria);
            this.Name = "ctrAcountsLedger";
            this.Size = new System.Drawing.Size(228, 502);
            this.Load += new System.EventHandler(this.ctrAcountsLedger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCriteria;
        public System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLedgerFrom;
        private System.Windows.Forms.Label label6;
        public ControlLibrary.TADateControl DateFrom;
        public ControlLibrary.TADateControl DateTo;
        public System.Windows.Forms.CheckBox chkBoxShowZeroBalances;
        public ControlLibrary.TAComboBox cboBoxAccountFrom;
        public ControlLibrary.TAComboBox cboBoxAccountTo;
        public ControlLibrary.MultiColumnComboBox cboBoxCriteriaByCodeAccountTo;
        public ControlLibrary.MultiColumnComboBox cboBoxCriteriaByCodeAccountFrom;
        private System.Windows.Forms.Label lblAccountTo;
        private System.Windows.Forms.Label lblAccountFrom;
        public System.Windows.Forms.CheckBox chkBoxCriteriaByCode;
        private System.Windows.Forms.Label label5;
    }
}
