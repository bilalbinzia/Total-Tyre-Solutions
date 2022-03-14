namespace QBSync
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLog = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.chkItemsGroupType = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkInvoices = new System.Windows.Forms.CheckBox();
            this.lblLastSync = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.chkListItems = new System.Windows.Forms.CheckBox();
            this.chkSalesOrder = new System.Windows.Forms.CheckBox();
            this.chkCreditMemo = new System.Windows.Forms.CheckBox();
            this.chkPO = new System.Windows.Forms.CheckBox();
            this.chkItemUpdateDD = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.chkItemsType = new System.Windows.Forms.CheckBox();
            this.chkItems = new System.Windows.Forms.CheckBox();
            this.chkVendorBills = new System.Windows.Forms.CheckBox();
            this.btnClose = new CButtonLib.CButton();
            this.btnMinToSystray = new CButtonLib.CButton();
            this.btnSynchronizeNow = new CButtonLib.CButton();
            this.btnCancel = new CButtonLib.CButton();
            this.chkVendorPayments = new System.Windows.Forms.CheckBox();
            this.chkInvoicePayment = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.Checked = true;
            this.chkCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomer.ForeColor = System.Drawing.Color.DimGray;
            this.chkCustomer.Location = new System.Drawing.Point(21, 157);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(104, 25);
            this.chkCustomer.TabIndex = 48;
            this.chkCustomer.Text = "Customers";
            this.chkCustomer.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.White;
            this.btnLog.BackgroundImage = global::QBSync.Properties.Resources.ErrorIcon;
            this.btnLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLog.Location = new System.Drawing.Point(66, 370);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(48, 51);
            this.btnLog.TabIndex = 49;
            this.toolTip1.SetToolTip(this.btnLog, "Application Log/History");
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.BackgroundImage = global::QBSync.Properties.Resources.Settings_blue_48;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSettings.Location = new System.Drawing.Point(12, 370);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(48, 51);
            this.btnSettings.TabIndex = 43;
            this.toolTip1.SetToolTip(this.btnSettings, "Default Settings");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // chkItemsGroupType
            // 
            this.chkItemsGroupType.AutoSize = true;
            this.chkItemsGroupType.Checked = true;
            this.chkItemsGroupType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemsGroupType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemsGroupType.ForeColor = System.Drawing.Color.DimGray;
            this.chkItemsGroupType.Location = new System.Drawing.Point(21, 233);
            this.chkItemsGroupType.Name = "chkItemsGroupType";
            this.chkItemsGroupType.Size = new System.Drawing.Size(151, 25);
            this.chkItemsGroupType.TabIndex = 51;
            this.chkItemsGroupType.Text = "Items Group Type";
            this.chkItemsGroupType.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Synchronize QuickBooks  Data";
            this.notifyIcon1.BalloonTipTitle = "QuickBooks  Data Sync Utility is Still Running";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Synchronize QuickBooks  Data";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chkInvoices
            // 
            this.chkInvoices.AutoSize = true;
            this.chkInvoices.Checked = true;
            this.chkInvoices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvoices.ForeColor = System.Drawing.Color.DimGray;
            this.chkInvoices.Location = new System.Drawing.Point(170, 233);
            this.chkInvoices.Name = "chkInvoices";
            this.chkInvoices.Size = new System.Drawing.Size(85, 25);
            this.chkInvoices.TabIndex = 53;
            this.chkInvoices.Text = "Invoices";
            this.chkInvoices.UseVisualStyleBackColor = true;
            // 
            // lblLastSync
            // 
            this.lblLastSync.AutoSize = true;
            this.lblLastSync.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSync.ForeColor = System.Drawing.Color.DimGray;
            this.lblLastSync.Location = new System.Drawing.Point(95, 348);
            this.lblLastSync.Name = "lblLastSync";
            this.lblLastSync.Size = new System.Drawing.Size(65, 17);
            this.lblLastSync.TabIndex = 54;
            this.lblLastSync.Text = "Date here";
            this.lblLastSync.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(4, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "Last Sync On:";
            this.label1.Visible = false;
            // 
            // picIcon
            // 
            this.picIcon.Image = global::QBSync.Properties.Resources.QBMSSync;
            this.picIcon.Location = new System.Drawing.Point(3, 8);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(140, 130);
            this.picIcon.TabIndex = 46;
            this.picIcon.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStatus.Location = new System.Drawing.Point(389, 2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(453, 373);
            this.txtStatus.TabIndex = 68;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // chkListItems
            // 
            this.chkListItems.AutoSize = true;
            this.chkListItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListItems.ForeColor = System.Drawing.Color.DimGray;
            this.chkListItems.Location = new System.Drawing.Point(187, 316);
            this.chkListItems.Name = "chkListItems";
            this.chkListItems.Size = new System.Drawing.Size(165, 25);
            this.chkListItems.TabIndex = 70;
            this.chkListItems.Text = "Terms/Ship Method";
            this.chkListItems.UseVisualStyleBackColor = true;
            this.chkListItems.Visible = false;
            // 
            // chkSalesOrder
            // 
            this.chkSalesOrder.AutoSize = true;
            this.chkSalesOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSalesOrder.ForeColor = System.Drawing.Color.DimGray;
            this.chkSalesOrder.Location = new System.Drawing.Point(21, 289);
            this.chkSalesOrder.Name = "chkSalesOrder";
            this.chkSalesOrder.Size = new System.Drawing.Size(117, 25);
            this.chkSalesOrder.TabIndex = 76;
            this.chkSalesOrder.Text = "Sales Orders";
            this.chkSalesOrder.UseVisualStyleBackColor = true;
            this.chkSalesOrder.Visible = false;
            // 
            // chkCreditMemo
            // 
            this.chkCreditMemo.AutoSize = true;
            this.chkCreditMemo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreditMemo.ForeColor = System.Drawing.Color.DimGray;
            this.chkCreditMemo.Location = new System.Drawing.Point(18, 316);
            this.chkCreditMemo.Name = "chkCreditMemo";
            this.chkCreditMemo.Size = new System.Drawing.Size(120, 25);
            this.chkCreditMemo.TabIndex = 77;
            this.chkCreditMemo.Text = "Credit Memo";
            this.chkCreditMemo.UseVisualStyleBackColor = true;
            this.chkCreditMemo.Visible = false;
            // 
            // chkPO
            // 
            this.chkPO.AutoSize = true;
            this.chkPO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPO.ForeColor = System.Drawing.Color.DimGray;
            this.chkPO.Location = new System.Drawing.Point(187, 350);
            this.chkPO.Name = "chkPO";
            this.chkPO.Size = new System.Drawing.Size(137, 25);
            this.chkPO.TabIndex = 78;
            this.chkPO.Text = "Purchase Order";
            this.chkPO.UseVisualStyleBackColor = true;
            this.chkPO.Visible = false;
            // 
            // chkItemUpdateDD
            // 
            this.chkItemUpdateDD.AutoSize = true;
            this.chkItemUpdateDD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemUpdateDD.ForeColor = System.Drawing.Color.DimGray;
            this.chkItemUpdateDD.Location = new System.Drawing.Point(187, 332);
            this.chkItemUpdateDD.Name = "chkItemUpdateDD";
            this.chkItemUpdateDD.Size = new System.Drawing.Size(180, 21);
            this.chkItemUpdateDD.TabIndex = 79;
            this.chkItemUpdateDD.Text = "Update Item Delivery Date";
            this.chkItemUpdateDD.UseVisualStyleBackColor = true;
            this.chkItemUpdateDD.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(149, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 11722;
            this.label2.Text = "Sync Data";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(187, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 31);
            this.label3.TabIndex = 11722;
            this.label3.Text = "with QuickBooks";
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.Checked = true;
            this.chkVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVendor.ForeColor = System.Drawing.Color.DimGray;
            this.chkVendor.Location = new System.Drawing.Point(170, 157);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(86, 25);
            this.chkVendor.TabIndex = 48;
            this.chkVendor.Text = "Vendors";
            this.chkVendor.UseVisualStyleBackColor = true;
            // 
            // chkItemsType
            // 
            this.chkItemsType.AutoSize = true;
            this.chkItemsType.Checked = true;
            this.chkItemsType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemsType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemsType.ForeColor = System.Drawing.Color.DimGray;
            this.chkItemsType.Location = new System.Drawing.Point(21, 183);
            this.chkItemsType.Name = "chkItemsType";
            this.chkItemsType.Size = new System.Drawing.Size(103, 25);
            this.chkItemsType.TabIndex = 51;
            this.chkItemsType.Text = "Items Type";
            this.chkItemsType.UseVisualStyleBackColor = true;
            // 
            // chkItems
            // 
            this.chkItems.AutoSize = true;
            this.chkItems.Checked = true;
            this.chkItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItems.ForeColor = System.Drawing.Color.DimGray;
            this.chkItems.Location = new System.Drawing.Point(21, 207);
            this.chkItems.Name = "chkItems";
            this.chkItems.Size = new System.Drawing.Size(67, 25);
            this.chkItems.TabIndex = 51;
            this.chkItems.Text = "Items";
            this.chkItems.UseVisualStyleBackColor = true;
            // 
            // chkVendorBills
            // 
            this.chkVendorBills.AutoSize = true;
            this.chkVendorBills.Checked = true;
            this.chkVendorBills.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendorBills.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVendorBills.ForeColor = System.Drawing.Color.DimGray;
            this.chkVendorBills.Location = new System.Drawing.Point(170, 182);
            this.chkVendorBills.Name = "chkVendorBills";
            this.chkVendorBills.Size = new System.Drawing.Size(111, 25);
            this.chkVendorBills.TabIndex = 48;
            this.chkVendorBills.Text = "Vendor Bills";
            this.chkVendorBills.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClose.ColorFillBlend = cBlendItems1;
            this.btnClose.DesignerSelected = false;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.ImageIndex = 0;
            this.btnClose.Location = new System.Drawing.Point(683, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 41);
            this.btnClose.TabIndex = 11721;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnMinToSystray
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnMinToSystray.ColorFillBlend = cBlendItems2;
            this.btnMinToSystray.DesignerSelected = false;
            this.btnMinToSystray.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnMinToSystray.ImageIndex = 0;
            this.btnMinToSystray.Location = new System.Drawing.Point(518, 379);
            this.btnMinToSystray.Name = "btnMinToSystray";
            this.btnMinToSystray.Size = new System.Drawing.Size(150, 41);
            this.btnMinToSystray.TabIndex = 11721;
            this.btnMinToSystray.Text = "MIN TO SYSTRAY";
            this.btnMinToSystray.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnSynchronizeNow
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSynchronizeNow.ColorFillBlend = cBlendItems3;
            this.btnSynchronizeNow.DesignerSelected = false;
            this.btnSynchronizeNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSynchronizeNow.ImageIndex = 0;
            this.btnSynchronizeNow.Location = new System.Drawing.Point(352, 379);
            this.btnSynchronizeNow.Name = "btnSynchronizeNow";
            this.btnSynchronizeNow.Size = new System.Drawing.Size(150, 41);
            this.btnSynchronizeNow.TabIndex = 11721;
            this.btnSynchronizeNow.Text = "SYNCHRONIZE NOW";
            this.btnSynchronizeNow.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnCancel
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCancel.ColorFillBlend = cBlendItems4;
            this.btnCancel.DesignerSelected = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(187, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 41);
            this.btnCancel.TabIndex = 11721;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // chkVendorPayments
            // 
            this.chkVendorPayments.AutoSize = true;
            this.chkVendorPayments.Checked = true;
            this.chkVendorPayments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendorPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVendorPayments.ForeColor = System.Drawing.Color.DimGray;
            this.chkVendorPayments.Location = new System.Drawing.Point(170, 207);
            this.chkVendorPayments.Name = "chkVendorPayments";
            this.chkVendorPayments.Size = new System.Drawing.Size(150, 25);
            this.chkVendorPayments.TabIndex = 48;
            this.chkVendorPayments.Text = "Vendor Payments";
            this.chkVendorPayments.UseVisualStyleBackColor = true;
            // 
            // chkInvoicePayment
            // 
            this.chkInvoicePayment.AutoSize = true;
            this.chkInvoicePayment.Checked = true;
            this.chkInvoicePayment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoicePayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvoicePayment.ForeColor = System.Drawing.Color.DimGray;
            this.chkInvoicePayment.Location = new System.Drawing.Point(170, 257);
            this.chkInvoicePayment.Name = "chkInvoicePayment";
            this.chkInvoicePayment.Size = new System.Drawing.Size(142, 25);
            this.chkInvoicePayment.TabIndex = 53;
            this.chkInvoicePayment.Text = "Invoice Payment";
            this.chkInvoicePayment.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 429);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinToSystray);
            this.Controls.Add(this.btnSynchronizeNow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkItemUpdateDD);
            this.Controls.Add(this.chkPO);
            this.Controls.Add(this.chkCreditMemo);
            this.Controls.Add(this.chkSalesOrder);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.chkListItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkInvoicePayment);
            this.Controls.Add(this.lblLastSync);
            this.Controls.Add(this.chkInvoices);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.chkItems);
            this.Controls.Add(this.chkItemsType);
            this.Controls.Add(this.chkVendorPayments);
            this.Controls.Add(this.chkVendorBills);
            this.Controls.Add(this.chkItemsGroupType);
            this.Controls.Add(this.chkVendor);
            this.Controls.Add(this.chkCustomer);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synchronize QuickBooks  Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkItemsGroupType;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkInvoices;
        private System.Windows.Forms.Label lblLastSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.CheckBox chkListItems;
        private System.Windows.Forms.CheckBox chkSalesOrder;
        private System.Windows.Forms.CheckBox chkCreditMemo;
        private System.Windows.Forms.CheckBox chkPO;
        private System.Windows.Forms.CheckBox chkItemUpdateDD;
        private CButtonLib.CButton btnCancel;
        private CButtonLib.CButton btnSynchronizeNow;
        private CButtonLib.CButton btnMinToSystray;
        private CButtonLib.CButton btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkVendor;
        private System.Windows.Forms.CheckBox chkItemsType;
        private System.Windows.Forms.CheckBox chkItems;
        private System.Windows.Forms.CheckBox chkVendorBills;
        private System.Windows.Forms.CheckBox chkVendorPayments;
        private System.Windows.Forms.CheckBox chkInvoicePayment;
    }
}