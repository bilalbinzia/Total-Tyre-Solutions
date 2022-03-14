namespace AppControls
{
    partial class ctrPackage
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
            CButtonLib.cBlendItems cBlendItems8 = new CButtonLib.cBlendItems();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrPackage));
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems6 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems7 = new CButtonLib.cBlendItems();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVPackage = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBNRefresh = new CButtonLib.CButton();
            this.btnBNSaveItem = new CButtonLib.CButton();
            this.btnBNAddItem = new CButtonLib.CButton();
            this.btnBNEditItem = new CButtonLib.CButton();
            this.btnBNCancelItem = new CButtonLib.CButton();
            this.btnBNDeleteItem = new CButtonLib.CButton();
            this.txtCatalog = new ControlLibrary.TATextBox();
            this.btnAddCatalog = new ControlLibrary.TAButton();
            this.TATCatalog = new ControlLibrary.TATextBox();
            this.TATchkShowinbtn = new ControlLibrary.TACheckBox();
            this.TATPackageCharges = new ControlLibrary.TATextBox();
            this.TATPackage = new ControlLibrary.TATextBox();
            this.TATchkActive = new ControlLibrary.TACheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPackage)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGVPackage);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 408);
            this.panel1.TabIndex = 0;
            // 
            // DGVPackage
            // 
            this.DGVPackage.AllowUserToAddRows = false;
            this.DGVPackage.AllowUserToDeleteRows = false;
            this.DGVPackage.AllowUserToOrderColumns = true;
            this.DGVPackage.AllowUserToResizeRows = false;
            this.DGVPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPackage.Location = new System.Drawing.Point(3, 181);
            this.DGVPackage.Name = "DGVPackage";
            this.DGVPackage.Size = new System.Drawing.Size(563, 203);
            this.DGVPackage.TabIndex = 11680;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtCatalog);
            this.panel4.Controls.Add(this.label39);
            this.panel4.Controls.Add(this.btnAddCatalog);
            this.panel4.Location = new System.Drawing.Point(3, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(563, 32);
            this.panel4.TabIndex = 11679;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(122, 8);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 13);
            this.label39.TabIndex = 11682;
            this.label39.Text = "Add Catalog";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.TATCatalog);
            this.panel3.Controls.Add(this.TATchkShowinbtn);
            this.panel3.Controls.Add(this.TATPackageCharges);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TATPackage);
            this.panel3.Controls.Add(this.TATchkActive);
            this.panel3.Location = new System.Drawing.Point(3, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(563, 77);
            this.panel3.TabIndex = 11678;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11464;
            this.label1.Text = "Catalog";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(94, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 11462;
            this.label13.Text = "Package Charges";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 11370;
            this.label8.Text = "Package Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBNRefresh);
            this.panel2.Controls.Add(this.btnBNSaveItem);
            this.panel2.Controls.Add(this.btnBNAddItem);
            this.panel2.Controls.Add(this.btnBNEditItem);
            this.panel2.Controls.Add(this.btnBNCancelItem);
            this.panel2.Controls.Add(this.btnBNDeleteItem);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 53);
            this.panel2.TabIndex = 11677;
            // 
            // btnBNRefresh
            // 
            cBlendItems8.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems8.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNRefresh.ColorFillBlend = cBlendItems8;
            this.btnBNRefresh.DesignerSelected = false;
            this.btnBNRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnBNRefresh.Image")));
            this.btnBNRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNRefresh.ImageIndex = 0;
            this.btnBNRefresh.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNRefresh.Location = new System.Drawing.Point(333, 3);
            this.btnBNRefresh.Name = "btnBNRefresh";
            this.btnBNRefresh.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNRefresh.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNRefresh.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNRefresh.Size = new System.Drawing.Size(60, 45);
            this.btnBNRefresh.TabIndex = 11676;
            this.btnBNRefresh.Text = "Refresh";
            this.btnBNRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNRefresh.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNSaveItem
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNSaveItem.ColorFillBlend = cBlendItems2;
            this.btnBNSaveItem.DesignerSelected = false;
            this.btnBNSaveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNSaveItem.Image = global::AppControls.Properties.Resources.save;
            this.btnBNSaveItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNSaveItem.ImageIndex = 0;
            this.btnBNSaveItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNSaveItem.Location = new System.Drawing.Point(203, 3);
            this.btnBNSaveItem.Name = "btnBNSaveItem";
            this.btnBNSaveItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNSaveItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNSaveItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNSaveItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNSaveItem.TabIndex = 11674;
            this.btnBNSaveItem.Text = "Save";
            this.btnBNSaveItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNSaveItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNAddItem
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNAddItem.ColorFillBlend = cBlendItems3;
            this.btnBNAddItem.DesignerSelected = false;
            this.btnBNAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNAddItem.Image = global::AppControls.Properties.Resources.add;
            this.btnBNAddItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNAddItem.ImageIndex = 0;
            this.btnBNAddItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNAddItem.Location = new System.Drawing.Point(8, 3);
            this.btnBNAddItem.Name = "btnBNAddItem";
            this.btnBNAddItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNAddItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNAddItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNAddItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNAddItem.TabIndex = 11671;
            this.btnBNAddItem.Text = "Add New";
            this.btnBNAddItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNAddItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNEditItem
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNEditItem.ColorFillBlend = cBlendItems4;
            this.btnBNEditItem.DesignerSelected = false;
            this.btnBNEditItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNEditItem.Image = global::AppControls.Properties.Resources.Edit;
            this.btnBNEditItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNEditItem.ImageIndex = 0;
            this.btnBNEditItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNEditItem.Location = new System.Drawing.Point(73, 3);
            this.btnBNEditItem.Name = "btnBNEditItem";
            this.btnBNEditItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNEditItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNEditItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNEditItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNEditItem.TabIndex = 11672;
            this.btnBNEditItem.Text = "Edit";
            this.btnBNEditItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNEditItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNCancelItem
            // 
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNCancelItem.ColorFillBlend = cBlendItems5;
            this.btnBNCancelItem.DesignerSelected = false;
            this.btnBNCancelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNCancelItem.Image = global::AppControls.Properties.Resources.cancel;
            this.btnBNCancelItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNCancelItem.ImageIndex = 0;
            this.btnBNCancelItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNCancelItem.Location = new System.Drawing.Point(268, 3);
            this.btnBNCancelItem.Name = "btnBNCancelItem";
            this.btnBNCancelItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNCancelItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNCancelItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNCancelItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNCancelItem.TabIndex = 11675;
            this.btnBNCancelItem.Text = "Cancel";
            this.btnBNCancelItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNCancelItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNDeleteItem
            // 
            cBlendItems6.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems6.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNDeleteItem.ColorFillBlend = cBlendItems6;
            this.btnBNDeleteItem.DesignerSelected = false;
            this.btnBNDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNDeleteItem.Image")));
            this.btnBNDeleteItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNDeleteItem.ImageIndex = 0;
            this.btnBNDeleteItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNDeleteItem.Location = new System.Drawing.Point(138, 3);
            this.btnBNDeleteItem.Name = "btnBNDeleteItem";
            this.btnBNDeleteItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNDeleteItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNDeleteItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNDeleteItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNDeleteItem.TabIndex = 11673;
            this.btnBNDeleteItem.Text = "Delete";
            this.btnBNDeleteItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNDeleteItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // txtCatalog
            // 
            this.txtCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatalog.Location = new System.Drawing.Point(195, 5);
            this.txtCatalog.MaxLength = 150;
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(142, 20);
            this.txtCatalog.TabIndex = 11683;
            this.txtCatalog.xBindingProperty = "";
            this.txtCatalog.xColumnName = "";
            this.txtCatalog.xColumnWidth = 80;
            this.txtCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.txtCatalog.xReadOnly = true;
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAddCatalog.ColorFillBlend = cBlendItems7;
            this.btnAddCatalog.DesignerSelected = false;
            this.btnAddCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddCatalog.ImageIndex = 0;
            this.btnAddCatalog.Location = new System.Drawing.Point(353, 3);
            this.btnAddCatalog.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(93, 25);
            this.btnAddCatalog.TabIndex = 11681;
            this.btnAddCatalog.Text = "Add Catalog";
            this.btnAddCatalog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCatalog.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // TATCatalog
            // 
            this.TATCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TATCatalog.Location = new System.Drawing.Point(194, 9);
            this.TATCatalog.Name = "TATCatalog";
            this.TATCatalog.Size = new System.Drawing.Size(102, 20);
            this.TATCatalog.TabIndex = 0;
            this.TATCatalog.xBindingProperty = "Catalog";
            this.TATCatalog.xColumnName = null;
            this.TATCatalog.xColumnWidth = 60;
            this.TATCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.TATCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.TATCatalog.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.TATCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.TATCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.TATCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.TATCatalog.xReadOnly = false;
            // 
            // TATchkShowinbtn
            // 
            this.TATchkShowinbtn.AutoSize = true;
            this.TATchkShowinbtn.Location = new System.Drawing.Point(304, 55);
            this.TATchkShowinbtn.Name = "TATchkShowinbtn";
            this.TATchkShowinbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TATchkShowinbtn.Size = new System.Drawing.Size(99, 17);
            this.TATchkShowinbtn.TabIndex = 4;
            this.TATchkShowinbtn.Text = "Show In Button";
            this.TATchkShowinbtn.ToolTipText = null;
            this.TATchkShowinbtn.UseVisualStyleBackColor = false;
            this.TATchkShowinbtn.xBindingProperty = "ShowInButton";
            this.TATchkShowinbtn.xColumnName = null;
            this.TATchkShowinbtn.xColumnWidth = 60;
            this.TATchkShowinbtn.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.TATchkShowinbtn.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.TATchkShowinbtn.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // TATPackageCharges
            // 
            this.TATPackageCharges.Location = new System.Drawing.Point(194, 53);
            this.TATPackageCharges.MaxLength = 150;
            this.TATPackageCharges.Name = "TATPackageCharges";
            this.TATPackageCharges.Size = new System.Drawing.Size(72, 20);
            this.TATPackageCharges.TabIndex = 11468;
            this.TATPackageCharges.xBindingProperty = "PackageWithTax";
            this.TATPackageCharges.xColumnName = "";
            this.TATPackageCharges.xColumnWidth = 60;
            this.TATPackageCharges.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.TATPackageCharges.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.TATPackageCharges.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.TATPackageCharges.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.TATPackageCharges.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.TATPackageCharges.xMasked = System32.StaticInfo.Mask.Decimal;
            this.TATPackageCharges.xReadOnly = false;
            // 
            // TATPackage
            // 
            this.TATPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TATPackage.Location = new System.Drawing.Point(194, 31);
            this.TATPackage.Name = "TATPackage";
            this.TATPackage.Size = new System.Drawing.Size(209, 20);
            this.TATPackage.TabIndex = 2;
            this.TATPackage.xBindingProperty = "Name";
            this.TATPackage.xColumnName = null;
            this.TATPackage.xColumnWidth = 60;
            this.TATPackage.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.TATPackage.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.TATPackage.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.TATPackage.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.TATPackage.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.TATPackage.xMasked = System32.StaticInfo.Mask.None;
            this.TATPackage.xReadOnly = false;
            // 
            // TATchkActive
            // 
            this.TATchkActive.AutoSize = true;
            this.TATchkActive.Location = new System.Drawing.Point(347, 11);
            this.TATchkActive.Name = "TATchkActive";
            this.TATchkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TATchkActive.Size = new System.Drawing.Size(56, 17);
            this.TATchkActive.TabIndex = 1;
            this.TATchkActive.Text = "Active";
            this.TATchkActive.ToolTipText = null;
            this.TATchkActive.UseVisualStyleBackColor = false;
            this.TATchkActive.xBindingProperty = "Active";
            this.TATchkActive.xColumnName = null;
            this.TATchkActive.xColumnWidth = 60;
            this.TATchkActive.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.TATchkActive.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.TATchkActive.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrPackage";
            this.Size = new System.Drawing.Size(569, 410);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPackage)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public CButtonLib.CButton btnBNSaveItem;
        public CButtonLib.CButton btnBNRefresh;
        public CButtonLib.CButton btnBNCancelItem;
        public CButtonLib.CButton btnBNDeleteItem;
        public CButtonLib.CButton btnBNEditItem;
        public CButtonLib.CButton btnBNAddItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox TATCatalog;
        private ControlLibrary.TACheckBox TATchkShowinbtn;
        private ControlLibrary.TATextBox TATPackageCharges;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private ControlLibrary.TATextBox TATPackage;
        private ControlLibrary.TACheckBox TATchkActive;
        private System.Windows.Forms.Panel panel4;
        private ControlLibrary.TATextBox txtCatalog;
        private System.Windows.Forms.Label label39;
        private ControlLibrary.TAButton btnAddCatalog;
        private System.Windows.Forms.DataGridView DGVPackage;
    }
}
