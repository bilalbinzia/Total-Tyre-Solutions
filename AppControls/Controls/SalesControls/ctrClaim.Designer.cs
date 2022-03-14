namespace AppControls
{
    partial class ctrClaim
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
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtCustomerInvoiceNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.txtCatalogCost = new ControlLibrary.TATextBox();
            this.btnAddCatalog = new ControlLibrary.TAButton();
            this.txtVendorReferenceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new CButtonLib.CButton();
            this.btnSave = new CButtonLib.CButton();
            this.chkAdjustInventoryQty = new ControlLibrary.TACheckBox();
            this.ClaimDate = new ControlLibrary.TADateControl();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Used",
            "Returned"});
            this.cboStatus.Location = new System.Drawing.Point(141, 196);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(99, 21);
            this.cboStatus.TabIndex = 11482;
            // 
            // txtCustomerInvoiceNo
            // 
            this.txtCustomerInvoiceNo.Location = new System.Drawing.Point(379, 174);
            this.txtCustomerInvoiceNo.MaxLength = 20;
            this.txtCustomerInvoiceNo.Name = "txtCustomerInvoiceNo";
            this.txtCustomerInvoiceNo.Size = new System.Drawing.Size(105, 20);
            this.txtCustomerInvoiceNo.TabIndex = 11480;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 11479;
            this.label9.Text = "Customer Invoice #";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 11477;
            this.label7.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 11475;
            this.label6.Text = "Cost:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(141, 108);
            this.txtDescription.MaxLength = 20;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(343, 20);
            this.txtDescription.TabIndex = 11474;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11473;
            this.label5.Text = "Description:";
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(141, 130);
            this.numQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(59, 20);
            this.numQty.TabIndex = 11472;
            this.numQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 11470;
            this.label4.Text = "Adjust Inventory Quantity.?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11469;
            this.label3.Text = "Quantity";
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(141, 86);
            this.txtCatalog.MaxLength = 20;
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(163, 20);
            this.txtCatalog.TabIndex = 11468;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11467;
            this.label2.Text = "Catalog:";
            // 
            // txtVendor
            // 
            this.txtVendor.Enabled = false;
            this.txtVendor.Location = new System.Drawing.Point(141, 64);
            this.txtVendor.MaxLength = 20;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(343, 20);
            this.txtVendor.TabIndex = 11466;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 11455;
            this.label8.Text = "Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 11454;
            this.label10.Text = "Vendor:";
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.txtCatalogCost);
            this.WorkingPanel.Controls.Add(this.btnAddCatalog);
            this.WorkingPanel.Controls.Add(this.txtVendorReferenceNo);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.btnCancel);
            this.WorkingPanel.Controls.Add(this.btnSave);
            this.WorkingPanel.Controls.Add(this.cboStatus);
            this.WorkingPanel.Controls.Add(this.txtCustomerInvoiceNo);
            this.WorkingPanel.Controls.Add(this.label9);
            this.WorkingPanel.Controls.Add(this.label7);
            this.WorkingPanel.Controls.Add(this.label6);
            this.WorkingPanel.Controls.Add(this.txtDescription);
            this.WorkingPanel.Controls.Add(this.label5);
            this.WorkingPanel.Controls.Add(this.numQty);
            this.WorkingPanel.Controls.Add(this.chkAdjustInventoryQty);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Controls.Add(this.txtCatalog);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.txtVendor);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Controls.Add(this.label10);
            this.WorkingPanel.Controls.Add(this.ClaimDate);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(597, 281);
            this.WorkingPanel.TabIndex = 0;
            // 
            // txtCatalogCost
            // 
            this.txtCatalogCost.Location = new System.Drawing.Point(141, 174);
            this.txtCatalogCost.Margin = new System.Windows.Forms.Padding(0);
            this.txtCatalogCost.MaxLength = 150;
            this.txtCatalogCost.Name = "txtCatalogCost";
            this.txtCatalogCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCatalogCost.Size = new System.Drawing.Size(99, 20);
            this.txtCatalogCost.TabIndex = 11682;
            this.txtCatalogCost.xBindingProperty = "";
            this.txtCatalogCost.xColumnName = "";
            this.txtCatalogCost.xColumnWidth = 60;
            this.txtCatalogCost.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtCatalogCost.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCatalogCost.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCatalogCost.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCatalogCost.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCatalogCost.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtCatalogCost.xReadOnly = false;
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAddCatalog.ColorFillBlend = cBlendItems4;
            this.btnAddCatalog.DesignerSelected = false;
            this.btnAddCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddCatalog.ImageIndex = 0;
            this.btnAddCatalog.Location = new System.Drawing.Point(307, 86);
            this.btnAddCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(20, 20);
            this.btnAddCatalog.TabIndex = 11681;
            this.btnAddCatalog.Text = "+";
            this.btnAddCatalog.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddCatalog.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // txtVendorReferenceNo
            // 
            this.txtVendorReferenceNo.Location = new System.Drawing.Point(141, 152);
            this.txtVendorReferenceNo.MaxLength = 20;
            this.txtVendorReferenceNo.Name = "txtVendorReferenceNo";
            this.txtVendorReferenceNo.Size = new System.Drawing.Size(163, 20);
            this.txtVendorReferenceNo.TabIndex = 11670;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11669;
            this.label1.Text = "Vendor Reference";
            // 
            // btnCancel
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCancel.ColorFillBlend = cBlendItems1;
            this.btnCancel.DesignerSelected = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(300, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 11668;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnSave
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSave.ColorFillBlend = cBlendItems2;
            this.btnSave.DesignerSelected = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ImageIndex = 0;
            this.btnSave.Location = new System.Drawing.Point(180, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 11667;
            this.btnSave.Text = "Save";
            this.btnSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // chkAdjustInventoryQty
            // 
            this.chkAdjustInventoryQty.AutoSize = true;
            this.chkAdjustInventoryQty.Location = new System.Drawing.Point(210, 133);
            this.chkAdjustInventoryQty.Name = "chkAdjustInventoryQty";
            this.chkAdjustInventoryQty.Size = new System.Drawing.Size(15, 14);
            this.chkAdjustInventoryQty.TabIndex = 11471;
            this.chkAdjustInventoryQty.ToolTipText = null;
            this.chkAdjustInventoryQty.UseVisualStyleBackColor = false;
            this.chkAdjustInventoryQty.xBindingProperty = null;
            this.chkAdjustInventoryQty.xColumnName = null;
            this.chkAdjustInventoryQty.xColumnWidth = 60;
            this.chkAdjustInventoryQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkAdjustInventoryQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkAdjustInventoryQty.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ClaimDate
            // 
            this.ClaimDate.Location = new System.Drawing.Point(141, 42);
            this.ClaimDate.Margin = new System.Windows.Forms.Padding(0);
            this.ClaimDate.Name = "ClaimDate";
            this.ClaimDate.Size = new System.Drawing.Size(99, 20);
            this.ClaimDate.TabIndex = 11453;
            this.ClaimDate.xBindingProperty = "PRDate";
            this.ClaimDate.xColumnName = "";
            this.ClaimDate.xColumnWidth = 60;
            this.ClaimDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrClaim
            // 
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrClaim";
            this.Size = new System.Drawing.Size(597, 281);
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtCustomerInvoiceNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numQty;
        protected ControlLibrary.TACheckBox chkAdjustInventoryQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        protected ControlLibrary.TADateControl ClaimDate;
        private System.Windows.Forms.Panel WorkingPanel;
        private System.Windows.Forms.TextBox txtVendorReferenceNo;
        private System.Windows.Forms.Label label1;
        private CButtonLib.CButton btnCancel;
        private CButtonLib.CButton btnSave;
        private ControlLibrary.TAButton btnAddCatalog;
        private ControlLibrary.TATextBox txtCatalogCost;

        
        
    }
}
