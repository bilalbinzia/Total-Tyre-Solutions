namespace RptModule.Parameters
{
    partial class TransactionPara
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
            this.btnLoadReport = new ControlLibrary.TAButton();
            this.taCheckBox1 = new ControlLibrary.TACheckBox();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTo = new ControlLibrary.TADateControl();
            this.DateFrom = new ControlLibrary.TADateControl();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.AccountTo = new ControlLibrary.MultiColumnComboBox();
            this.lblLedgerTo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taTextBox2 = new ControlLibrary.TATextBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.chkAllCustomer = new ControlLibrary.TACheckBox();
            this.SuspendLayout();
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnLoadReport.ColorFillBlend = cBlendItems1;
            this.btnLoadReport.DesignerSelected = false;
            this.btnLoadReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadReport.ImageIndex = 0;
            this.btnLoadReport.Location = new System.Drawing.Point(151, 228);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(75, 23);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Load Report";
            this.btnLoadReport.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // taCheckBox1
            // 
            this.taCheckBox1.AutoSize = true;
            this.taCheckBox1.Location = new System.Drawing.Point(136, 539);
            this.taCheckBox1.Name = "taCheckBox1";
            this.taCheckBox1.Size = new System.Drawing.Size(90, 17);
            this.taCheckBox1.TabIndex = 1;
            this.taCheckBox1.Text = "taCheckBox1";
            this.taCheckBox1.ToolTipText = null;
            this.taCheckBox1.UseVisualStyleBackColor = true;
            this.taCheckBox1.Visible = false;
            this.taCheckBox1.xBindingProperty = null;
            this.taCheckBox1.xColumnName = null;
            this.taCheckBox1.xColumnWidth = 60;
            this.taCheckBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taCheckBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // taTextBox1
            // 
            this.taTextBox1.Location = new System.Drawing.Point(126, 467);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(100, 20);
            this.taTextBox1.TabIndex = 4;
            this.taTextBox1.Visible = false;
            this.taTextBox1.xBindingProperty = null;
            this.taTextBox1.xColumnName = null;
            this.taTextBox1.xColumnWidth = 60;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // DateTo
            // 
            this.DateTo.Location = new System.Drawing.Point(124, 96);
            this.DateTo.Margin = new System.Windows.Forms.Padding(0);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(102, 20);
            this.DateTo.TabIndex = 10;
            this.DateTo.xBindingProperty = null;
            this.DateTo.xColumnName = null;
            this.DateTo.xColumnWidth = 60;
            this.DateTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.DateTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // DateFrom
            // 
            this.DateFrom.Location = new System.Drawing.Point(124, 71);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(102, 20);
            this.DateFrom.TabIndex = 9;
            this.DateFrom.xBindingProperty = null;
            this.DateFrom.xColumnName = null;
            this.DateFrom.xColumnWidth = 60;
            this.DateFrom.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsRequired = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.DateFrom.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(62, 100);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(49, 13);
            this.lblDateTo.TabIndex = 12;
            this.lblDateTo.Text = "Date To:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(52, 75);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDateFrom.TabIndex = 11;
            this.lblDateFrom.Text = "Date From:";
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
            this.cboCriteria.Location = new System.Drawing.Point(52, 45);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(174, 21);
            this.cboCriteria.TabIndex = 8;
            // 
            // AccountTo
            // 
            this.AccountTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AccountTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AccountTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AccountTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTo.DropDownWidth = 228;
            this.AccountTo.FormattingEnabled = true;
            this.AccountTo.Location = new System.Drawing.Point(98, 442);
            this.AccountTo.Name = "AccountTo";
            this.AccountTo.Size = new System.Drawing.Size(128, 21);
            this.AccountTo.TabIndex = 14;
            this.AccountTo.Visible = false;
            this.AccountTo.xBindingProperty = null;
            this.AccountTo.xBindingQuery = null;
            this.AccountTo.xColumnName = null;
            this.AccountTo.xColumns = null;
            this.AccountTo.xColumnWidth = 60;
            this.AccountTo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.AccountTo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.AccountTo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.AccountTo.xOrderBy = null;
            this.AccountTo.xTableName = null;
            // 
            // lblLedgerTo
            // 
            this.lblLedgerTo.AutoSize = true;
            this.lblLedgerTo.Location = new System.Drawing.Point(19, 446);
            this.lblLedgerTo.Name = "lblLedgerTo";
            this.lblLedgerTo.Size = new System.Drawing.Size(66, 13);
            this.lblLedgerTo.TabIndex = 16;
            this.lblLedgerTo.Text = "Account To:";
            this.lblLedgerTo.Visible = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(55, 135);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 15;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // taTextBox2
            // 
            this.taTextBox2.Location = new System.Drawing.Point(126, 491);
            this.taTextBox2.Name = "taTextBox2";
            this.taTextBox2.Size = new System.Drawing.Size(100, 20);
            this.taTextBox2.TabIndex = 17;
            this.taTextBox2.Visible = false;
            this.taTextBox2.xBindingProperty = null;
            this.taTextBox2.xColumnName = null;
            this.taTextBox2.xColumnWidth = 60;
            this.taTextBox2.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox2.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox2.xReadOnly = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(52, 153);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(174, 21);
            this.cboCustomer.TabIndex = 20;
            // 
            // chkAllCustomer
            // 
            this.chkAllCustomer.AutoSize = true;
            this.chkAllCustomer.Location = new System.Drawing.Point(115, 133);
            this.chkAllCustomer.Name = "chkAllCustomer";
            this.chkAllCustomer.Size = new System.Drawing.Size(84, 17);
            this.chkAllCustomer.TabIndex = 22;
            this.chkAllCustomer.Text = "All Customer";
            this.chkAllCustomer.ToolTipText = null;
            this.chkAllCustomer.UseVisualStyleBackColor = true;
            this.chkAllCustomer.Visible = false;
            this.chkAllCustomer.xBindingProperty = null;
            this.chkAllCustomer.xColumnName = null;
            this.chkAllCustomer.xColumnWidth = 60;
            this.chkAllCustomer.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAllCustomer.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAllCustomer.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // TransactionPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAllCustomer);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.taTextBox2);
            this.Controls.Add(this.AccountTo);
            this.Controls.Add(this.lblLedgerTo);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.cboCriteria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taTextBox1);
            this.Controls.Add(this.taCheckBox1);
            this.Controls.Add(this.btnLoadReport);
            this.Name = "TransactionPara";
            this.Size = new System.Drawing.Size(254, 602);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public ControlLibrary.TADateControl DateTo;
        public ControlLibrary.TADateControl DateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        public ControlLibrary.MultiColumnComboBox AccountTo;
        private System.Windows.Forms.Label lblLedgerTo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label4;
        public ControlLibrary.TAButton btnLoadReport;
        public ControlLibrary.TACheckBox taCheckBox1;
        public ControlLibrary.TATextBox taTextBox1;
        public System.Windows.Forms.ComboBox cboCriteria;
        public ControlLibrary.TATextBox taTextBox2;
        public System.Windows.Forms.ComboBox cboCustomer;
        public ControlLibrary.TACheckBox chkAllCustomer;
    }
}
