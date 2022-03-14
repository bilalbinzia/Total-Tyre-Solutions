namespace AppControls
{
    partial class ctrWarrantyClaim
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemCatalog = new ControlLibrary.TATextBox();
            this.txtItemDescription = new ControlLibrary.TATextBox();
            this.txtComment = new ControlLibrary.TATextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsShipped = new ControlLibrary.TACheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnWarrantyClaim = new ControlLibrary.TAButton();
            this.btnCancel = new ControlLibrary.TAButton();
            this.ctrClaimDate = new ControlLibrary.TADateControl();
            this.ctrShipDate = new ControlLibrary.TADateControl();
            this.txtCustomerInvoice = new ControlLibrary.TATextBox();
            this.numReturnQty = new ControlLibrary.TANumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Catalog:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comment:";
            // 
            // txtItemCatalog
            // 
            this.txtItemCatalog.Enabled = false;
            this.txtItemCatalog.Location = new System.Drawing.Point(108, 20);
            this.txtItemCatalog.Name = "txtItemCatalog";
            this.txtItemCatalog.ReadOnly = true;
            this.txtItemCatalog.Size = new System.Drawing.Size(116, 20);
            this.txtItemCatalog.TabIndex = 3;
            this.txtItemCatalog.xBindingProperty = null;
            this.txtItemCatalog.xColumnName = null;
            this.txtItemCatalog.xColumnWidth = 60;
            this.txtItemCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.txtItemCatalog.xReadOnly = false;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Enabled = false;
            this.txtItemDescription.Location = new System.Drawing.Point(108, 42);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ReadOnly = true;
            this.txtItemDescription.Size = new System.Drawing.Size(260, 20);
            this.txtItemDescription.TabIndex = 4;
            this.txtItemDescription.xBindingProperty = null;
            this.txtItemDescription.xColumnName = null;
            this.txtItemDescription.xColumnWidth = 60;
            this.txtItemDescription.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtItemDescription.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtItemDescription.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtItemDescription.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtItemDescription.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtItemDescription.xMasked = System32.StaticInfo.Mask.None;
            this.txtItemDescription.xReadOnly = false;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(108, 64);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(260, 20);
            this.txtComment.TabIndex = 5;
            this.txtComment.xBindingProperty = null;
            this.txtComment.xColumnName = null;
            this.txtComment.xColumnWidth = 60;
            this.txtComment.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtComment.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtComment.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtComment.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtComment.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtComment.xMasked = System32.StaticInfo.Mask.None;
            this.txtComment.xReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Qty to Return:";
            // 
            // chkIsShipped
            // 
            this.chkIsShipped.AutoSize = true;
            this.chkIsShipped.Location = new System.Drawing.Point(108, 147);
            this.chkIsShipped.Name = "chkIsShipped";
            this.chkIsShipped.Size = new System.Drawing.Size(231, 17);
            this.chkIsShipped.TabIndex = 8;
            this.chkIsShipped.Text = "Has this item been shipped to the supplier.?";
            this.chkIsShipped.ToolTipText = null;
            this.chkIsShipped.UseVisualStyleBackColor = true;
            this.chkIsShipped.xBindingProperty = null;
            this.chkIsShipped.xColumnName = null;
            this.chkIsShipped.xColumnWidth = 60;
            this.chkIsShipped.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkIsShipped.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkIsShipped.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Date Shipped:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Customer Invoice # (optional):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "This will do the following:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(298, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "- Create a Claim entry (See the \'Claims\' button in Vendor Entry)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(281, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "- Create an adjustment in *INVENTORY ADJUSTMENTS*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "- This Purchase Order will NOT be affected.";
            // 
            // btnWarrantyClaim
            // 
            this.btnWarrantyClaim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnWarrantyClaim.Location = new System.Drawing.Point(80, 334);
            this.btnWarrantyClaim.Name = "btnWarrantyClaim";
            this.btnWarrantyClaim.Size = new System.Drawing.Size(161, 23);
            this.btnWarrantyClaim.TabIndex = 15;
            this.btnWarrantyClaim.Text = "Create Warranty Claim";
            
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Location = new System.Drawing.Point(257, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            
            // 
            // ctrClaimDate
            // 
            this.ctrClaimDate.Location = new System.Drawing.Point(108, 86);
            this.ctrClaimDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrClaimDate.Name = "ctrClaimDate";
            this.ctrClaimDate.Size = new System.Drawing.Size(99, 20);
            this.ctrClaimDate.TabIndex = 18;
            this.ctrClaimDate.xBindingProperty = null;
            this.ctrClaimDate.xColumnName = null;
            this.ctrClaimDate.xColumnWidth = 60;
            this.ctrClaimDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrClaimDate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrClaimDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.ctrClaimDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrShipDate
            // 
            this.ctrShipDate.Location = new System.Drawing.Point(108, 168);
            this.ctrShipDate.Margin = new System.Windows.Forms.Padding(0);
            this.ctrShipDate.Name = "ctrShipDate";
            this.ctrShipDate.Size = new System.Drawing.Size(99, 20);
            this.ctrShipDate.TabIndex = 19;
            this.ctrShipDate.xBindingProperty = null;
            this.ctrShipDate.xColumnName = null;
            this.ctrShipDate.xColumnWidth = 60;
            this.ctrShipDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrShipDate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrShipDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.ctrShipDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // txtCustomerInvoice
            // 
            this.txtCustomerInvoice.Location = new System.Drawing.Point(172, 192);
            this.txtCustomerInvoice.Name = "txtCustomerInvoice";
            this.txtCustomerInvoice.Size = new System.Drawing.Size(99, 20);
            this.txtCustomerInvoice.TabIndex = 20;
            this.txtCustomerInvoice.xBindingProperty = null;
            this.txtCustomerInvoice.xColumnName = null;
            this.txtCustomerInvoice.xColumnWidth = 60;
            this.txtCustomerInvoice.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtCustomerInvoice.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCustomerInvoice.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCustomerInvoice.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCustomerInvoice.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCustomerInvoice.xMasked = System32.StaticInfo.Mask.None;
            this.txtCustomerInvoice.xReadOnly = false;
            // 
            // numReturnQty
            // 
            this.numReturnQty.Location = new System.Drawing.Point(108, 108);
            this.numReturnQty.Name = "numReturnQty";
            this.numReturnQty.Size = new System.Drawing.Size(99, 20);
            this.numReturnQty.TabIndex = 21;
            this.numReturnQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReturnQty.xBindingProperty = null;
            this.numReturnQty.xColumnName = null;
            this.numReturnQty.xColumnWidth = 60;
            this.numReturnQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.numReturnQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.numReturnQty.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrWarrantyClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numReturnQty);
            this.Controls.Add(this.txtCustomerInvoice);
            this.Controls.Add(this.ctrShipDate);
            this.Controls.Add(this.ctrClaimDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnWarrantyClaim);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkIsShipped);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtItemDescription);
            this.Controls.Add(this.txtItemCatalog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrWarrantyClaim";
            this.Size = new System.Drawing.Size(394, 378);
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ControlLibrary.TATextBox txtItemCatalog;
        private ControlLibrary.TATextBox txtItemDescription;
        private ControlLibrary.TATextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ControlLibrary.TACheckBox chkIsShipped;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private ControlLibrary.TAButton btnWarrantyClaim;
        private ControlLibrary.TAButton btnCancel;
        private ControlLibrary.TADateControl ctrClaimDate;
        private ControlLibrary.TADateControl ctrShipDate;
        private ControlLibrary.TATextBox txtCustomerInvoice;
        private ControlLibrary.TANumericUpDown numReturnQty;
    }
}
