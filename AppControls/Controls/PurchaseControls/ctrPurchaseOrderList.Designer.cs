namespace AppControls
{
    partial class ctrPurchaseOrderList
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
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems6 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems7 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems8 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems9 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems10 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems11 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems12 = new CButtonLib.cBlendItems();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCatalog = new ControlLibrary.TATextBox();
            this.btnNewLine = new ControlLibrary.TAButton();
            this.btnPODetailSave = new ControlLibrary.TAButton();
            this.btnPODetailCancel = new ControlLibrary.TAButton();
            this.btnProcessAllChanges = new ControlLibrary.TAButton();
            this.btnClearBackOrders = new ControlLibrary.TAButton();
            this.btnReceivedAllOrdered = new ControlLibrary.TAButton();
            this.btnWarrantyClaim = new ControlLibrary.TAButton();
            this.btnBillAllReceived = new ControlLibrary.TAButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNewPurchaseOrder = new ControlLibrary.TAButton();
            this.btnPOSave = new ControlLibrary.TAButton();
            this.btnPOVoid = new ControlLibrary.TAButton();
            this.btnPrintPO = new ControlLibrary.TAButton();
            this.dtpPO = new System.Windows.Forms.DateTimePicker();
            this.DGVVendorList = new ControlLibrary.TAZSearchDataGridView();
            this.DGVPurchaseOrderList = new ControlLibrary.TAZSearchDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalAmountBilled = new ControlLibrary.TATextBox();
            this.lblBackOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalQtyOrder = new ControlLibrary.TATextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalQtyReceived = new ControlLibrary.TATextBox();
            this.txtTotalAmountReceived = new ControlLibrary.TATextBox();
            this.txtTotalAmountOrder = new ControlLibrary.TATextBox();
            this.txtTotalQtyBilled = new ControlLibrary.TATextBox();
            this.DGVPODetail = new ControlLibrary.libDataGridView();
            this.ID = new ControlLibrary.DGVTextBoxColumn();
            this.MID = new ControlLibrary.DGVTextBoxColumn();
            this.ItemID = new ControlLibrary.DGVTextBoxColumn();
            this.Catalog = new ControlLibrary.DGVTextBoxColumn();
            this.Description = new ControlLibrary.DGVTextBoxColumn();
            this.QtyOrdrd = new ControlLibrary.DGVTextBoxColumn();
            this.PrevOrdrd = new ControlLibrary.DGVTextBoxColumn();
            this.QtyRcvd = new ControlLibrary.DGVTextBoxColumn();
            this.PrevRcvd = new ControlLibrary.DGVTextBoxColumn();
            this.QtyBilled = new ControlLibrary.DGVTextBoxColumn();
            this.PrevBilled = new ControlLibrary.DGVTextBoxColumn();
            this.Cost = new ControlLibrary.DGVTextBoxColumn();
            this.FET = new ControlLibrary.DGVTextBoxColumn();
            this.Amount = new ControlLibrary.DGVTextBoxColumn();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPODetail)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tableLayoutPanel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(1037, 535);
            this.WorkingPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVVendorList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVPurchaseOrderList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.DGVPODetail, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 535);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 331);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1037, 25);
            this.panel3.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 9;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.50048F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.678882F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.775313F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06461F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.21119F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.92189F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.92189F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.47541F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12536F));
            this.tableLayoutPanel4.Controls.Add(this.txtCatalog, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnNewLine, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPODetailSave, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPODetailCancel, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnProcessAllChanges, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClearBackOrders, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnReceivedAllOrdered, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnWarrantyClaim, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnBillAllReceived, 7, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1037, 25);
            this.tableLayoutPanel4.TabIndex = 11568;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCatalog.Location = new System.Drawing.Point(0, 2);
            this.txtCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.txtCatalog.MaxLength = 150;
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(130, 20);
            this.txtCatalog.TabIndex = 11567;
            this.txtCatalog.Visible = false;
            this.txtCatalog.WordWrap = false;
            this.txtCatalog.xBindingProperty = "Catalog";
            this.txtCatalog.xColumnName = "";
            this.txtCatalog.xColumnWidth = 80;
            this.txtCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.txtCatalog.xReadOnly = false;
            // 
            // btnNewLine
            // 
            this.btnNewLine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNewLine.ColorFillBlend = cBlendItems1;
            this.btnNewLine.DesignerSelected = false;
            this.btnNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNewLine.ImageIndex = 0;
            this.btnNewLine.Location = new System.Drawing.Point(139, 0);
            this.btnNewLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(79, 24);
            this.btnNewLine.TabIndex = 5;
            this.btnNewLine.Text = "New Item";
            this.btnNewLine.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnPODetailSave
            // 
            this.btnPODetailSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPODetailSave.ColorFillBlend = cBlendItems2;
            this.btnPODetailSave.DesignerSelected = false;
            this.btnPODetailSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPODetailSave.ImageIndex = 0;
            this.btnPODetailSave.Location = new System.Drawing.Point(228, 0);
            this.btnPODetailSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnPODetailSave.Name = "btnPODetailSave";
            this.btnPODetailSave.Size = new System.Drawing.Size(88, 24);
            this.btnPODetailSave.TabIndex = 6;
            this.btnPODetailSave.Text = "Save";
            this.btnPODetailSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnPODetailCancel
            // 
            this.btnPODetailCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPODetailCancel.ColorFillBlend = cBlendItems3;
            this.btnPODetailCancel.DesignerSelected = false;
            this.btnPODetailCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPODetailCancel.ImageIndex = 0;
            this.btnPODetailCancel.Location = new System.Drawing.Point(318, 0);
            this.btnPODetailCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnPODetailCancel.Name = "btnPODetailCancel";
            this.btnPODetailCancel.Size = new System.Drawing.Size(88, 24);
            this.btnPODetailCancel.TabIndex = 6;
            this.btnPODetailCancel.Text = "Cancel";
            this.btnPODetailCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnProcessAllChanges
            // 
            this.btnProcessAllChanges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnProcessAllChanges.ColorFillBlend = cBlendItems4;
            this.btnProcessAllChanges.DesignerSelected = false;
            this.btnProcessAllChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProcessAllChanges.ImageIndex = 0;
            this.btnProcessAllChanges.Location = new System.Drawing.Point(411, 0);
            this.btnProcessAllChanges.Margin = new System.Windows.Forms.Padding(0);
            this.btnProcessAllChanges.Name = "btnProcessAllChanges";
            this.btnProcessAllChanges.Size = new System.Drawing.Size(130, 24);
            this.btnProcessAllChanges.TabIndex = 7;
            this.btnProcessAllChanges.Text = "Process All Changes";
            this.btnProcessAllChanges.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnClearBackOrders
            // 
            this.btnClearBackOrders.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClearBackOrders.ColorFillBlend = cBlendItems5;
            this.btnClearBackOrders.DesignerSelected = false;
            this.btnClearBackOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearBackOrders.ImageIndex = 0;
            this.btnClearBackOrders.Location = new System.Drawing.Point(547, 0);
            this.btnClearBackOrders.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearBackOrders.Name = "btnClearBackOrders";
            this.btnClearBackOrders.Size = new System.Drawing.Size(128, 24);
            this.btnClearBackOrders.TabIndex = 8;
            this.btnClearBackOrders.Text = "Clear BackOrders";
            this.btnClearBackOrders.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnReceivedAllOrdered
            // 
            this.btnReceivedAllOrdered.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnReceivedAllOrdered.ColorFillBlend = cBlendItems6;
            this.btnReceivedAllOrdered.DesignerSelected = false;
            this.btnReceivedAllOrdered.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReceivedAllOrdered.ImageIndex = 0;
            this.btnReceivedAllOrdered.Location = new System.Drawing.Point(680, 0);
            this.btnReceivedAllOrdered.Margin = new System.Windows.Forms.Padding(0);
            this.btnReceivedAllOrdered.Name = "btnReceivedAllOrdered";
            this.btnReceivedAllOrdered.Size = new System.Drawing.Size(128, 24);
            this.btnReceivedAllOrdered.TabIndex = 8;
            this.btnReceivedAllOrdered.Text = "Receive All Ordered";
            this.btnReceivedAllOrdered.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnWarrantyClaim
            // 
            this.btnWarrantyClaim.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnWarrantyClaim.ColorFillBlend = cBlendItems7;
            this.btnWarrantyClaim.DesignerSelected = false;
            this.btnWarrantyClaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnWarrantyClaim.ImageIndex = 0;
            this.btnWarrantyClaim.Location = new System.Drawing.Point(931, 0);
            this.btnWarrantyClaim.Margin = new System.Windows.Forms.Padding(0);
            this.btnWarrantyClaim.Name = "btnWarrantyClaim";
            this.btnWarrantyClaim.Size = new System.Drawing.Size(106, 24);
            this.btnWarrantyClaim.TabIndex = 11568;
            this.btnWarrantyClaim.Text = "Warranty Claim";
            this.btnWarrantyClaim.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBillAllReceived
            // 
            this.btnBillAllReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems8.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems8.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBillAllReceived.ColorFillBlend = cBlendItems8;
            this.btnBillAllReceived.DesignerSelected = false;
            this.btnBillAllReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBillAllReceived.ImageIndex = 0;
            this.btnBillAllReceived.Location = new System.Drawing.Point(813, 0);
            this.btnBillAllReceived.Margin = new System.Windows.Forms.Padding(0);
            this.btnBillAllReceived.Name = "btnBillAllReceived";
            this.btnBillAllReceived.Size = new System.Drawing.Size(109, 24);
            this.btnBillAllReceived.TabIndex = 9;
            this.btnBillAllReceived.Text = "Bill All Received";
            this.btnBillAllReceived.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 25);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.24687F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.63259F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNewPurchaseOrder, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPOSave, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPOVoid, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPrintPO, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpPO, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1037, 25);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Purchase Order";
            // 
            // btnNewPurchaseOrder
            // 
            this.btnNewPurchaseOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems9.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems9.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNewPurchaseOrder.ColorFillBlend = cBlendItems9;
            this.btnNewPurchaseOrder.DesignerSelected = false;
            this.btnNewPurchaseOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNewPurchaseOrder.ImageIndex = 0;
            this.btnNewPurchaseOrder.Location = new System.Drawing.Point(129, 0);
            this.btnNewPurchaseOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewPurchaseOrder.Name = "btnNewPurchaseOrder";
            this.btnNewPurchaseOrder.Size = new System.Drawing.Size(79, 24);
            this.btnNewPurchaseOrder.TabIndex = 5;
            this.btnNewPurchaseOrder.Text = "New PO";
            this.btnNewPurchaseOrder.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnPOSave
            // 
            this.btnPOSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems10.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems10.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPOSave.ColorFillBlend = cBlendItems10;
            this.btnPOSave.DesignerSelected = false;
            this.btnPOSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPOSave.ImageIndex = 0;
            this.btnPOSave.Location = new System.Drawing.Point(387, 0);
            this.btnPOSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnPOSave.Name = "btnPOSave";
            this.btnPOSave.Size = new System.Drawing.Size(111, 24);
            this.btnPOSave.TabIndex = 7;
            this.btnPOSave.Text = "Save Changes";
            this.btnPOSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnPOVoid
            // 
            this.btnPOVoid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems11.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems11.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPOVoid.ColorFillBlend = cBlendItems11;
            this.btnPOVoid.DesignerSelected = false;
            this.btnPOVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPOVoid.ImageIndex = 0;
            this.btnPOVoid.Location = new System.Drawing.Point(258, 0);
            this.btnPOVoid.Margin = new System.Windows.Forms.Padding(0);
            this.btnPOVoid.Name = "btnPOVoid";
            this.btnPOVoid.Size = new System.Drawing.Size(76, 24);
            this.btnPOVoid.TabIndex = 6;
            this.btnPOVoid.Text = "Delete/Void";
            this.btnPOVoid.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnPrintPO
            // 
            this.btnPrintPO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems12.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems12.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPrintPO.ColorFillBlend = cBlendItems12;
            this.btnPrintPO.DesignerSelected = false;
            this.btnPrintPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPrintPO.ImageIndex = 0;
            this.btnPrintPO.Location = new System.Drawing.Point(645, 0);
            this.btnPrintPO.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintPO.Name = "btnPrintPO";
            this.btnPrintPO.Size = new System.Drawing.Size(88, 24);
            this.btnPrintPO.TabIndex = 10;
            this.btnPrintPO.Text = "Print P/O";
            this.btnPrintPO.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // dtpPO
            // 
            this.dtpPO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPO.Location = new System.Drawing.Point(906, 3);
            this.dtpPO.Name = "dtpPO";
            this.dtpPO.Size = new System.Drawing.Size(128, 20);
            this.dtpPO.TabIndex = 12;
            // 
            // DGVVendorList
            // 
            this.DGVVendorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorList.Location = new System.Drawing.Point(0, 0);
            this.DGVVendorList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVVendorList.Name = "DGVVendorList";
            this.DGVVendorList.Size = new System.Drawing.Size(1037, 153);
            this.DGVVendorList.TabIndex = 3;
            // 
            // DGVPurchaseOrderList
            // 
            this.DGVPurchaseOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPurchaseOrderList.Location = new System.Drawing.Point(0, 178);
            this.DGVPurchaseOrderList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVPurchaseOrderList.Name = "DGVPurchaseOrderList";
            this.DGVPurchaseOrderList.Size = new System.Drawing.Size(1037, 153);
            this.DGVPurchaseOrderList.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 509);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1037, 26);
            this.panel4.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 14;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.92575F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.460945F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.821601F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.268081F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.207329F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.460945F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.593057F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.075217F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.014465F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.003858F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.014465F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.810993F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.110897F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tableLayoutPanel5.Controls.Add(this.txtTotalAmountBilled, 13, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblBackOrders, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 12, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalQtyOrder, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 10, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalQtyReceived, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalAmountReceived, 11, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalAmountOrder, 9, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalQtyBilled, 7, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1037, 26);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // txtTotalAmountBilled
            // 
            this.txtTotalAmountBilled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalAmountBilled.Location = new System.Drawing.Point(962, 3);
            this.txtTotalAmountBilled.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalAmountBilled.Name = "txtTotalAmountBilled";
            this.txtTotalAmountBilled.ReadOnly = true;
            this.txtTotalAmountBilled.Size = new System.Drawing.Size(75, 20);
            this.txtTotalAmountBilled.TabIndex = 6;
            this.txtTotalAmountBilled.xBindingProperty = "TotalAmountBilled";
            this.txtTotalAmountBilled.xColumnName = null;
            this.txtTotalAmountBilled.xColumnWidth = 60;
            this.txtTotalAmountBilled.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountBilled.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountBilled.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountBilled.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalAmountBilled.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountBilled.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalAmountBilled.xReadOnly = false;
            // 
            // lblBackOrders
            // 
            this.lblBackOrders.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBackOrders.AutoSize = true;
            this.lblBackOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBackOrders.Location = new System.Drawing.Point(0, 5);
            this.lblBackOrders.Margin = new System.Windows.Forms.Padding(0);
            this.lblBackOrders.Name = "lblBackOrders";
            this.lblBackOrders.Size = new System.Drawing.Size(102, 16);
            this.lblBackOrders.TabIndex = 7;
            this.lblBackOrders.Text = "BackOrders : ";
            this.lblBackOrders.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ord. Qty";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Totals";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rec. Qty";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(527, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Billed Qty";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(909, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Billed Amt";
            // 
            // txtTotalQtyOrder
            // 
            this.txtTotalQtyOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalQtyOrder.Location = new System.Drawing.Point(334, 3);
            this.txtTotalQtyOrder.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalQtyOrder.Name = "txtTotalQtyOrder";
            this.txtTotalQtyOrder.ReadOnly = true;
            this.txtTotalQtyOrder.Size = new System.Drawing.Size(60, 20);
            this.txtTotalQtyOrder.TabIndex = 6;
            this.txtTotalQtyOrder.xBindingProperty = "TotalQtyOrder";
            this.txtTotalQtyOrder.xColumnName = null;
            this.txtTotalQtyOrder.xColumnWidth = 60;
            this.txtTotalQtyOrder.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyOrder.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyOrder.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyOrder.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyOrder.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyOrder.xMasked = System32.StaticInfo.Mask.Digit;
            this.txtTotalQtyOrder.xReadOnly = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(777, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Rec. Amt";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(645, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ord. Amt";
            // 
            // txtTotalQtyReceived
            // 
            this.txtTotalQtyReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalQtyReceived.Location = new System.Drawing.Point(453, 3);
            this.txtTotalQtyReceived.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalQtyReceived.Name = "txtTotalQtyReceived";
            this.txtTotalQtyReceived.ReadOnly = true;
            this.txtTotalQtyReceived.Size = new System.Drawing.Size(60, 20);
            this.txtTotalQtyReceived.TabIndex = 6;
            this.txtTotalQtyReceived.xBindingProperty = "TotalQtyReceived";
            this.txtTotalQtyReceived.xColumnName = null;
            this.txtTotalQtyReceived.xColumnWidth = 60;
            this.txtTotalQtyReceived.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyReceived.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyReceived.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyReceived.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyReceived.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyReceived.xMasked = System32.StaticInfo.Mask.Digit;
            this.txtTotalQtyReceived.xReadOnly = false;
            // 
            // txtTotalAmountReceived
            // 
            this.txtTotalAmountReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalAmountReceived.Location = new System.Drawing.Point(828, 3);
            this.txtTotalAmountReceived.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalAmountReceived.Name = "txtTotalAmountReceived";
            this.txtTotalAmountReceived.ReadOnly = true;
            this.txtTotalAmountReceived.Size = new System.Drawing.Size(81, 20);
            this.txtTotalAmountReceived.TabIndex = 6;
            this.txtTotalAmountReceived.xBindingProperty = "TotalAmountReceived";
            this.txtTotalAmountReceived.xColumnName = null;
            this.txtTotalAmountReceived.xColumnWidth = 60;
            this.txtTotalAmountReceived.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountReceived.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountReceived.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountReceived.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalAmountReceived.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountReceived.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalAmountReceived.xReadOnly = false;
            // 
            // txtTotalAmountOrder
            // 
            this.txtTotalAmountOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalAmountOrder.Location = new System.Drawing.Point(693, 3);
            this.txtTotalAmountOrder.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalAmountOrder.Name = "txtTotalAmountOrder";
            this.txtTotalAmountOrder.ReadOnly = true;
            this.txtTotalAmountOrder.Size = new System.Drawing.Size(81, 20);
            this.txtTotalAmountOrder.TabIndex = 6;
            this.txtTotalAmountOrder.xBindingProperty = "TotalAmountOrder";
            this.txtTotalAmountOrder.xColumnName = null;
            this.txtTotalAmountOrder.xColumnWidth = 60;
            this.txtTotalAmountOrder.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountOrder.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountOrder.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountOrder.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtTotalAmountOrder.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalAmountOrder.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtTotalAmountOrder.xReadOnly = false;
            // 
            // txtTotalQtyBilled
            // 
            this.txtTotalQtyBilled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTotalQtyBilled.Location = new System.Drawing.Point(578, 3);
            this.txtTotalQtyBilled.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalQtyBilled.Name = "txtTotalQtyBilled";
            this.txtTotalQtyBilled.ReadOnly = true;
            this.txtTotalQtyBilled.Size = new System.Drawing.Size(60, 20);
            this.txtTotalQtyBilled.TabIndex = 6;
            this.txtTotalQtyBilled.xBindingProperty = "TotalQtyBilled";
            this.txtTotalQtyBilled.xColumnName = null;
            this.txtTotalQtyBilled.xColumnWidth = 60;
            this.txtTotalQtyBilled.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyBilled.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyBilled.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyBilled.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyBilled.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtTotalQtyBilled.xMasked = System32.StaticInfo.Mask.Digit;
            this.txtTotalQtyBilled.xReadOnly = false;
            // 
            // DGVPODetail
            // 
            this.DGVPODetail.AllowUserToAddRows = false;
            this.DGVPODetail.AllowUserToDeleteRows = false;
            this.DGVPODetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGVPODetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPODetail.BackgroundColor = System.Drawing.Color.White;
            this.DGVPODetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPODetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MID,
            this.ItemID,
            this.Catalog,
            this.Description,
            this.QtyOrdrd,
            this.PrevOrdrd,
            this.QtyRcvd,
            this.PrevRcvd,
            this.QtyBilled,
            this.PrevBilled,
            this.Cost,
            this.FET,
            this.Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPODetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPODetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPODetail.GridColor = System.Drawing.Color.White;
            this.DGVPODetail.Location = new System.Drawing.Point(0, 356);
            this.DGVPODetail.Margin = new System.Windows.Forms.Padding(0);
            this.DGVPODetail.Name = "DGVPODetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPODetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPODetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            this.DGVPODetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVPODetail.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVPODetail.ShowRowErrors = false;
            this.DGVPODetail.Size = new System.Drawing.Size(1037, 153);
            this.DGVPODetail.TabIndex = 9;
            this.DGVPODetail.VirtualMode = true;
            this.DGVPODetail.xIsAutoNo = false;
            this.DGVPODetail.xIsDeleteColumn = true;
            this.DGVPODetail.xOrderBy = null;
            this.DGVPODetail.xTableName = "PurchaseOrderDetails";
            this.DGVPODetail.xTableQuery = null;
            this.DGVPODetail.xTableRelation = null;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.IsFilteringColumn = false;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            this.ID.xBindingProperty = "ID";
            this.ID.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.ID.xDisplayIndex = 0;
            this.ID.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // MID
            // 
            this.MID.DataPropertyName = "MID";
            this.MID.HeaderText = "MID";
            this.MID.IsFilteringColumn = false;
            this.MID.Name = "MID";
            this.MID.ReadOnly = true;
            this.MID.Visible = false;
            this.MID.Width = 10;
            this.MID.xBindingProperty = "MID";
            this.MID.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.MID.xDisplayIndex = 0;
            this.MID.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.MID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.IsFilteringColumn = false;
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            this.ItemID.Width = 10;
            this.ItemID.xBindingProperty = "ItemID";
            this.ItemID.xColumnType = System32.StaticInfo.gColumnType.NumberColumn;
            this.ItemID.xDisplayIndex = 0;
            this.ItemID.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ItemID.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Catalog
            // 
            this.Catalog.DataPropertyName = "Catalog";
            this.Catalog.HeaderText = "Catalog";
            this.Catalog.IsFilteringColumn = false;
            this.Catalog.Name = "Catalog";
            this.Catalog.ReadOnly = true;
            this.Catalog.Width = 200;
            this.Catalog.xBindingProperty = "Catalog";
            this.Catalog.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Catalog.xDisplayIndex = 0;
            this.Catalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Catalog.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.IsFilteringColumn = false;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 500;
            this.Description.xBindingProperty = "Description";
            this.Description.xColumnType = System32.StaticInfo.gColumnType.TextBoxColumn;
            this.Description.xDisplayIndex = 0;
            this.Description.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Description.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // QtyOrdrd
            // 
            this.QtyOrdrd.DataPropertyName = "QtyOrdrd";
            this.QtyOrdrd.HeaderText = "QtyOrdrd";
            this.QtyOrdrd.IsFilteringColumn = false;
            this.QtyOrdrd.Name = "QtyOrdrd";
            this.QtyOrdrd.Width = 50;
            this.QtyOrdrd.xBindingProperty = "QtyOrdrd";
            this.QtyOrdrd.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.QtyOrdrd.xDisplayIndex = 0;
            this.QtyOrdrd.xIsRequired = System32.StaticInfo.YesNo.No;
            this.QtyOrdrd.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // PrevOrdrd
            // 
            this.PrevOrdrd.DataPropertyName = "PrevOrdrd";
            this.PrevOrdrd.HeaderText = "PrevOrdrd";
            this.PrevOrdrd.IsFilteringColumn = false;
            this.PrevOrdrd.Name = "PrevOrdrd";
            this.PrevOrdrd.ReadOnly = true;
            this.PrevOrdrd.Width = 60;
            this.PrevOrdrd.xBindingProperty = "PrevOrdrd";
            this.PrevOrdrd.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.PrevOrdrd.xDisplayIndex = 0;
            this.PrevOrdrd.xIsRequired = System32.StaticInfo.YesNo.No;
            this.PrevOrdrd.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // QtyRcvd
            // 
            this.QtyRcvd.DataPropertyName = "QtyRcvd";
            this.QtyRcvd.HeaderText = "QtyRcvd";
            this.QtyRcvd.IsFilteringColumn = false;
            this.QtyRcvd.Name = "QtyRcvd";
            this.QtyRcvd.Width = 60;
            this.QtyRcvd.xBindingProperty = "QtyRcvd";
            this.QtyRcvd.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.QtyRcvd.xDisplayIndex = 0;
            this.QtyRcvd.xIsRequired = System32.StaticInfo.YesNo.No;
            this.QtyRcvd.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // PrevRcvd
            // 
            this.PrevRcvd.DataPropertyName = "PrevRcvd";
            this.PrevRcvd.HeaderText = "PrevRcvd";
            this.PrevRcvd.IsFilteringColumn = false;
            this.PrevRcvd.Name = "PrevRcvd";
            this.PrevRcvd.ReadOnly = true;
            this.PrevRcvd.Width = 60;
            this.PrevRcvd.xBindingProperty = "PrevRcvd";
            this.PrevRcvd.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.PrevRcvd.xDisplayIndex = 0;
            this.PrevRcvd.xIsRequired = System32.StaticInfo.YesNo.No;
            this.PrevRcvd.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // QtyBilled
            // 
            this.QtyBilled.DataPropertyName = "QtyBilled";
            this.QtyBilled.HeaderText = "QtyBilled";
            this.QtyBilled.IsFilteringColumn = false;
            this.QtyBilled.Name = "QtyBilled";
            this.QtyBilled.Width = 60;
            this.QtyBilled.xBindingProperty = "QtyBilled";
            this.QtyBilled.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.QtyBilled.xDisplayIndex = 0;
            this.QtyBilled.xIsRequired = System32.StaticInfo.YesNo.No;
            this.QtyBilled.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // PrevBilled
            // 
            this.PrevBilled.DataPropertyName = "PrevBilled";
            this.PrevBilled.HeaderText = "PrevBilled";
            this.PrevBilled.IsFilteringColumn = false;
            this.PrevBilled.Name = "PrevBilled";
            this.PrevBilled.ReadOnly = true;
            this.PrevBilled.Width = 60;
            this.PrevBilled.xBindingProperty = "PrevBilled";
            this.PrevBilled.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.PrevBilled.xDisplayIndex = 0;
            this.PrevBilled.xIsRequired = System32.StaticInfo.YesNo.No;
            this.PrevBilled.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Cost";
            this.Cost.IsFilteringColumn = false;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 90;
            this.Cost.xBindingProperty = "Cost";
            this.Cost.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Cost.xDisplayIndex = 0;
            this.Cost.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Cost.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // FET
            // 
            this.FET.DataPropertyName = "FET";
            this.FET.HeaderText = "FET";
            this.FET.IsFilteringColumn = false;
            this.FET.Name = "FET";
            this.FET.Width = 70;
            this.FET.xBindingProperty = "FET";
            this.FET.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.FET.xDisplayIndex = 0;
            this.FET.xIsRequired = System32.StaticInfo.YesNo.No;
            this.FET.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.IsFilteringColumn = false;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.xBindingProperty = "Amount";
            this.Amount.xColumnType = System32.StaticInfo.gColumnType.DecimalColumn;
            this.Amount.xDisplayIndex = 0;
            this.Amount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.Amount.xShowCurrency = System32.StaticInfo.YesNo.No;
            // 
            // ctrPurchaseOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrPurchaseOrderList";
            this.Size = new System.Drawing.Size(1037, 535);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPODetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVVendorList;
        public ControlLibrary.TAZSearchDataGridView DGVPurchaseOrderList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

        private ControlLibrary.TAButton btnNewLine;
        private ControlLibrary.TAButton btnPODetailSave;
        private ControlLibrary.TAButton btnProcessAllChanges;
        private ControlLibrary.TAButton btnClearBackOrders;
        private ControlLibrary.TAButton btnBillAllReceived;
        private ControlLibrary.TAButton btnPOVoid;
        private ControlLibrary.TAButton btnNewPurchaseOrder;
        private ControlLibrary.TAButton btnPrintPO;
        private ControlLibrary.TAButton btnPOSave;
        private ControlLibrary.TAButton btnPODetailCancel;
        private ControlLibrary.TAButton btnReceivedAllOrdered;

        private System.Windows.Forms.Panel panel4;
        private ControlLibrary.libDataGridView DGVPODetail;
        private ControlLibrary.TATextBox txtTotalQtyOrder;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox txtTotalQtyReceived;
        private ControlLibrary.TATextBox txtTotalQtyBilled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private ControlLibrary.TATextBox txtTotalAmountBilled;
        private ControlLibrary.TATextBox txtTotalAmountReceived;
        private ControlLibrary.TATextBox txtTotalAmountOrder;

        private System.Windows.Forms.Label label9;
        private ControlLibrary.TATextBox txtCatalog;
        private System.Windows.Forms.Label lblBackOrders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ControlLibrary.TAButton btnWarrantyClaim;
        private System.Windows.Forms.DateTimePicker dtpPO;
        private ControlLibrary.DGVTextBoxColumn ID;
        private ControlLibrary.DGVTextBoxColumn MID;
        private ControlLibrary.DGVTextBoxColumn ItemID;
        private ControlLibrary.DGVTextBoxColumn Catalog;
        private ControlLibrary.DGVTextBoxColumn Description;
        private ControlLibrary.DGVTextBoxColumn QtyOrdrd;
        private ControlLibrary.DGVTextBoxColumn PrevOrdrd;
        private ControlLibrary.DGVTextBoxColumn QtyRcvd;
        private ControlLibrary.DGVTextBoxColumn PrevRcvd;
        private ControlLibrary.DGVTextBoxColumn QtyBilled;
        private ControlLibrary.DGVTextBoxColumn PrevBilled;
        private ControlLibrary.DGVTextBoxColumn Cost;
        private ControlLibrary.DGVTextBoxColumn FET;
        private ControlLibrary.DGVTextBoxColumn Amount;
    }
}
