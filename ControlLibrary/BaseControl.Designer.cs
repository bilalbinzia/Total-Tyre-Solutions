namespace ControlLibrary
{
    partial class BaseControl
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
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems7 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseControl));
            this.BaseBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnBNAddItem1 = new System.Windows.Forms.ToolStripButton();
            this.BNCountItem = new System.Windows.Forms.ToolStripLabel();
            this.btnBNMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.btnBNMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.BNSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.BNPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.BNSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBNMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.btnBNMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BNSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBNEditItem1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNSaveItem1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNCancelItem1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNRefresh1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNPrint1 = new System.Windows.Forms.ToolStripButton();
            this.btnBNProcess = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSMItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBNAddItem = new CButtonLib.CButton();
            this.btnBNEditItem = new CButtonLib.CButton();
            this.btnBNDeleteItem = new CButtonLib.CButton();
            this.btnBNSaveItem = new CButtonLib.CButton();
            this.btnBNCancelItem = new CButtonLib.CButton();
            this.btnBNRefresh = new CButtonLib.CButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBindingNavigator)).BeginInit();
            this.BaseBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.btnBNSaveItem);
            this.WorkingPanel.Controls.Add(this.btnBNRefresh);
            this.WorkingPanel.Controls.Add(this.btnBNCancelItem);
            this.WorkingPanel.Controls.Add(this.btnBNDeleteItem);
            this.WorkingPanel.Controls.Add(this.btnBNEditItem);
            this.WorkingPanel.Controls.Add(this.btnBNAddItem);
            this.WorkingPanel.Controls.Add(this.bindingNavigator1);
            this.WorkingPanel.Controls.Add(this.BaseBindingNavigator);
            this.WorkingPanel.Size = new System.Drawing.Size(849, 514);
            // 
            // BaseBindingNavigator
            // 
            this.BaseBindingNavigator.AddNewItem = this.btnBNAddItem1;
            this.BaseBindingNavigator.CountItem = this.BNCountItem;
            this.BaseBindingNavigator.DeleteItem = null;
            this.BaseBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BaseBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBNMoveFirstItem,
            this.btnBNMovePreviousItem,
            this.BNSeparator,
            this.BNPositionItem,
            this.BNCountItem,
            this.BNSeparator1,
            this.btnBNMoveNextItem,
            this.btnBNMoveLastItem,
            this.BNSeparator2,
            this.btnBNAddItem1,
            this.btnBNEditItem1,
            this.btnBNDeleteItem1,
            this.btnBNSaveItem1,
            this.btnBNCancelItem1,
            this.btnBNRefresh1,
            this.btnBNPrint1,
            this.btnBNProcess});
            this.BaseBindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.BaseBindingNavigator.Location = new System.Drawing.Point(0, 494);
            this.BaseBindingNavigator.MoveFirstItem = this.btnBNMoveFirstItem;
            this.BaseBindingNavigator.MoveLastItem = this.btnBNMoveLastItem;
            this.BaseBindingNavigator.MoveNextItem = this.btnBNMoveNextItem;
            this.BaseBindingNavigator.MovePreviousItem = this.btnBNMovePreviousItem;
            this.BaseBindingNavigator.Name = "BaseBindingNavigator";
            this.BaseBindingNavigator.PositionItem = this.BNPositionItem;
            this.BaseBindingNavigator.Size = new System.Drawing.Size(849, 20);
            this.BaseBindingNavigator.TabIndex = 0;
            this.BaseBindingNavigator.Text = "bindingNavigator1";
            // 
            // btnBNAddItem1
            // 
            this.btnBNAddItem1.AutoSize = false;
            this.btnBNAddItem1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNAddItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNAddItem1.ForeColor = System.Drawing.Color.Black;
            this.btnBNAddItem1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNAddItem1.Name = "btnBNAddItem1";
            this.btnBNAddItem1.Size = new System.Drawing.Size(60, 20);
            this.btnBNAddItem1.Visible = false;
            // 
            // BNCountItem
            // 
            this.BNCountItem.AutoSize = false;
            this.BNCountItem.BackColor = System.Drawing.SystemColors.Control;
            this.BNCountItem.ForeColor = System.Drawing.Color.Black;
            this.BNCountItem.Margin = new System.Windows.Forms.Padding(0);
            this.BNCountItem.Name = "BNCountItem";
            this.BNCountItem.Size = new System.Drawing.Size(35, 20);
            this.BNCountItem.Text = "of {0}";
            this.BNCountItem.ToolTipText = "Total number of items";
            // 
            // btnBNMoveFirstItem
            // 
            this.btnBNMoveFirstItem.AutoSize = false;
            this.btnBNMoveFirstItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBNMoveFirstItem.ForeColor = System.Drawing.Color.Black;
            this.btnBNMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNMoveFirstItem.Image")));
            this.btnBNMoveFirstItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNMoveFirstItem.Name = "btnBNMoveFirstItem";
            this.btnBNMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.btnBNMoveFirstItem.Size = new System.Drawing.Size(30, 20);
            this.btnBNMoveFirstItem.Text = "Move first";
            // 
            // btnBNMovePreviousItem
            // 
            this.btnBNMovePreviousItem.AutoSize = false;
            this.btnBNMovePreviousItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBNMovePreviousItem.ForeColor = System.Drawing.Color.Black;
            this.btnBNMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNMovePreviousItem.Image")));
            this.btnBNMovePreviousItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNMovePreviousItem.Name = "btnBNMovePreviousItem";
            this.btnBNMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.btnBNMovePreviousItem.Size = new System.Drawing.Size(30, 20);
            this.btnBNMovePreviousItem.Text = "Move previous";
            // 
            // BNSeparator
            // 
            this.BNSeparator.AutoSize = false;
            this.BNSeparator.Name = "BNSeparator";
            this.BNSeparator.Size = new System.Drawing.Size(6, 20);
            // 
            // BNPositionItem
            // 
            this.BNPositionItem.AccessibleName = "Position";
            this.BNPositionItem.AutoSize = false;
            this.BNPositionItem.BackColor = System.Drawing.SystemColors.Control;
            this.BNPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BNPositionItem.ForeColor = System.Drawing.Color.Black;
            this.BNPositionItem.Margin = new System.Windows.Forms.Padding(0);
            this.BNPositionItem.Name = "BNPositionItem";
            this.BNPositionItem.Size = new System.Drawing.Size(50, 20);
            this.BNPositionItem.Text = "0";
            this.BNPositionItem.ToolTipText = "Current position";
            // 
            // BNSeparator1
            // 
            this.BNSeparator1.AutoSize = false;
            this.BNSeparator1.Name = "BNSeparator1";
            this.BNSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // btnBNMoveNextItem
            // 
            this.btnBNMoveNextItem.AutoSize = false;
            this.btnBNMoveNextItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBNMoveNextItem.ForeColor = System.Drawing.Color.Black;
            this.btnBNMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNMoveNextItem.Image")));
            this.btnBNMoveNextItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNMoveNextItem.Name = "btnBNMoveNextItem";
            this.btnBNMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.btnBNMoveNextItem.Size = new System.Drawing.Size(30, 20);
            this.btnBNMoveNextItem.Text = "Move next";
            // 
            // btnBNMoveLastItem
            // 
            this.btnBNMoveLastItem.AutoSize = false;
            this.btnBNMoveLastItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBNMoveLastItem.ForeColor = System.Drawing.Color.Black;
            this.btnBNMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNMoveLastItem.Image")));
            this.btnBNMoveLastItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNMoveLastItem.Name = "btnBNMoveLastItem";
            this.btnBNMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.btnBNMoveLastItem.Size = new System.Drawing.Size(30, 20);
            this.btnBNMoveLastItem.Text = "Move last";
            // 
            // BNSeparator2
            // 
            this.BNSeparator2.AutoSize = false;
            this.BNSeparator2.Name = "BNSeparator2";
            this.BNSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // btnBNEditItem1
            // 
            this.btnBNEditItem1.AutoSize = false;
            this.btnBNEditItem1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNEditItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNEditItem1.ForeColor = System.Drawing.Color.Black;
            this.btnBNEditItem1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNEditItem1.Name = "btnBNEditItem1";
            this.btnBNEditItem1.Size = new System.Drawing.Size(60, 20);
            this.btnBNEditItem1.Visible = false;
            // 
            // btnBNDeleteItem1
            // 
            this.btnBNDeleteItem1.AutoSize = false;
            this.btnBNDeleteItem1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNDeleteItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNDeleteItem1.ForeColor = System.Drawing.Color.Black;
            this.btnBNDeleteItem1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNDeleteItem1.Name = "btnBNDeleteItem1";
            this.btnBNDeleteItem1.Size = new System.Drawing.Size(60, 20);
            this.btnBNDeleteItem1.Visible = false;
            // 
            // btnBNSaveItem1
            // 
            this.btnBNSaveItem1.AutoSize = false;
            this.btnBNSaveItem1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNSaveItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNSaveItem1.ForeColor = System.Drawing.Color.Black;
            this.btnBNSaveItem1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNSaveItem1.Name = "btnBNSaveItem1";
            this.btnBNSaveItem1.Size = new System.Drawing.Size(60, 20);
            this.btnBNSaveItem1.Visible = false;
            // 
            // btnBNCancelItem1
            // 
            this.btnBNCancelItem1.AutoSize = false;
            this.btnBNCancelItem1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNCancelItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNCancelItem1.ForeColor = System.Drawing.Color.Black;
            this.btnBNCancelItem1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNCancelItem1.Name = "btnBNCancelItem1";
            this.btnBNCancelItem1.Size = new System.Drawing.Size(60, 20);
            this.btnBNCancelItem1.Visible = false;
            // 
            // btnBNRefresh1
            // 
            this.btnBNRefresh1.AutoSize = false;
            this.btnBNRefresh1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNRefresh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNRefresh1.ForeColor = System.Drawing.Color.Black;
            this.btnBNRefresh1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNRefresh1.Name = "btnBNRefresh1";
            this.btnBNRefresh1.Size = new System.Drawing.Size(60, 20);
            this.btnBNRefresh1.Visible = false;
            // 
            // btnBNPrint1
            // 
            this.btnBNPrint1.AutoSize = false;
            this.btnBNPrint1.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNPrint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNPrint1.ForeColor = System.Drawing.Color.Black;
            this.btnBNPrint1.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNPrint1.Name = "btnBNPrint1";
            this.btnBNPrint1.Size = new System.Drawing.Size(60, 20);
            this.btnBNPrint1.Visible = false;
            // 
            // btnBNProcess
            // 
            this.btnBNProcess.AutoSize = false;
            this.btnBNProcess.BackColor = System.Drawing.SystemColors.Control;
            this.btnBNProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMItem1,
            this.TSMItem2,
            this.TSMItem3,
            this.TSMItem4,
            this.TSMItem5});
            this.btnBNProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBNProcess.ForeColor = System.Drawing.Color.Black;
            this.btnBNProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBNProcess.Margin = new System.Windows.Forms.Padding(0);
            this.btnBNProcess.Name = "btnBNProcess";
            this.btnBNProcess.Size = new System.Drawing.Size(60, 20);
            this.btnBNProcess.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBNProcess.Visible = false;
            // 
            // TSMItem1
            // 
            this.TSMItem1.Name = "TSMItem1";
            this.TSMItem1.Size = new System.Drawing.Size(105, 22);
            this.TSMItem1.Text = "item1";
            this.TSMItem1.Visible = false;
            // 
            // TSMItem2
            // 
            this.TSMItem2.Name = "TSMItem2";
            this.TSMItem2.Size = new System.Drawing.Size(105, 22);
            this.TSMItem2.Text = "item2";
            this.TSMItem2.Visible = false;
            // 
            // TSMItem3
            // 
            this.TSMItem3.Name = "TSMItem3";
            this.TSMItem3.Size = new System.Drawing.Size(105, 22);
            this.TSMItem3.Text = "item3";
            this.TSMItem3.Visible = false;
            // 
            // TSMItem4
            // 
            this.TSMItem4.Name = "TSMItem4";
            this.TSMItem4.Size = new System.Drawing.Size(105, 22);
            this.TSMItem4.Text = "item4";
            this.TSMItem4.Visible = false;
            // 
            // TSMItem5
            // 
            this.TSMItem5.Name = "TSMItem5";
            this.TSMItem5.Size = new System.Drawing.Size(105, 22);
            this.TSMItem5.Text = "item5";
            this.TSMItem5.Visible = false;
            // 
            // btnBNAddItem
            // 
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNAddItem.ColorFillBlend = cBlendItems5;
            this.btnBNAddItem.DesignerSelected = false;
            this.btnBNAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNAddItem.Image = global::ControlLibrary.Properties.Resources.add;
            this.btnBNAddItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNAddItem.ImageIndex = 0;
            this.btnBNAddItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNAddItem.Location = new System.Drawing.Point(15, 2);
            this.btnBNAddItem.Name = "btnBNAddItem";
            this.btnBNAddItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNAddItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNAddItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNAddItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNAddItem.TabIndex = 11665;
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
            this.btnBNEditItem.Image = global::ControlLibrary.Properties.Resources.Edit;
            this.btnBNEditItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNEditItem.ImageIndex = 0;
            this.btnBNEditItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNEditItem.Location = new System.Drawing.Point(80, 2);
            this.btnBNEditItem.Name = "btnBNEditItem";
            this.btnBNEditItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNEditItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNEditItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNEditItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNEditItem.TabIndex = 11666;
            this.btnBNEditItem.Text = "Edit";
            this.btnBNEditItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNEditItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNDeleteItem
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNDeleteItem.ColorFillBlend = cBlendItems3;
            this.btnBNDeleteItem.DesignerSelected = false;
            this.btnBNDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnBNDeleteItem.Image")));
            this.btnBNDeleteItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNDeleteItem.ImageIndex = 0;
            this.btnBNDeleteItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNDeleteItem.Location = new System.Drawing.Point(145, 2);
            this.btnBNDeleteItem.Name = "btnBNDeleteItem";
            this.btnBNDeleteItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNDeleteItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNDeleteItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNDeleteItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNDeleteItem.TabIndex = 11667;
            this.btnBNDeleteItem.Text = "Delete";
            this.btnBNDeleteItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNDeleteItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNSaveItem
            // 
            cBlendItems7.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems7.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNSaveItem.ColorFillBlend = cBlendItems7;
            this.btnBNSaveItem.DesignerSelected = false;
            this.btnBNSaveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNSaveItem.Image = global::ControlLibrary.Properties.Resources.Save;
            this.btnBNSaveItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNSaveItem.ImageIndex = 0;
            this.btnBNSaveItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNSaveItem.Location = new System.Drawing.Point(210, 2);
            this.btnBNSaveItem.Name = "btnBNSaveItem";
            this.btnBNSaveItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNSaveItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNSaveItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNSaveItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNSaveItem.TabIndex = 11668;
            this.btnBNSaveItem.Text = "Save";
            this.btnBNSaveItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNSaveItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNCancelItem
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNCancelItem.ColorFillBlend = cBlendItems2;
            this.btnBNCancelItem.DesignerSelected = false;
            this.btnBNCancelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNCancelItem.Image = global::ControlLibrary.Properties.Resources.cancel;
            this.btnBNCancelItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNCancelItem.ImageIndex = 0;
            this.btnBNCancelItem.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNCancelItem.Location = new System.Drawing.Point(275, 2);
            this.btnBNCancelItem.Name = "btnBNCancelItem";
            this.btnBNCancelItem.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNCancelItem.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNCancelItem.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNCancelItem.Size = new System.Drawing.Size(60, 45);
            this.btnBNCancelItem.TabIndex = 11669;
            this.btnBNCancelItem.Text = "Cancel";
            this.btnBNCancelItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNCancelItem.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBNRefresh
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBNRefresh.ColorFillBlend = cBlendItems1;
            this.btnBNRefresh.DesignerSelected = false;
            this.btnBNRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnBNRefresh.Image")));
            this.btnBNRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBNRefresh.ImageIndex = 0;
            this.btnBNRefresh.ImageSize = new System.Drawing.Size(18, 18);
            this.btnBNRefresh.Location = new System.Drawing.Point(340, 2);
            this.btnBNRefresh.Name = "btnBNRefresh";
            this.btnBNRefresh.Padding = new System.Windows.Forms.Padding(1);
            this.btnBNRefresh.SideImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBNRefresh.SideImageSize = new System.Drawing.Size(17, 17);
            this.btnBNRefresh.Size = new System.Drawing.Size(60, 45);
            this.btnBNRefresh.TabIndex = 11670;
            this.btnBNRefresh.Text = "Refresh";
            this.btnBNRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBNRefresh.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(849, 47);
            this.bindingNavigator1.TabIndex = 11671;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AutoSize = false;
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 47);
            // 
            // BaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(849, 514);
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBindingNavigator)).EndInit();
            this.BaseBindingNavigator.ResumeLayout(false);
            this.BaseBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
                
        public System.Windows.Forms.ToolStripLabel BNCountItem;
        public System.Windows.Forms.ToolStripButton btnBNMoveFirstItem;
        public System.Windows.Forms.ToolStripButton btnBNMovePreviousItem;
        public System.Windows.Forms.ToolStripSeparator BNSeparator;
        public System.Windows.Forms.ToolStripTextBox BNPositionItem;
        public System.Windows.Forms.ToolStripSeparator BNSeparator1;
        public System.Windows.Forms.ToolStripButton btnBNMoveNextItem;
        public System.Windows.Forms.ToolStripButton btnBNMoveLastItem;
        public System.Windows.Forms.ToolStripSeparator BNSeparator2;
        public System.Windows.Forms.BindingNavigator BaseBindingNavigator;

        public System.Windows.Forms.ToolStripButton btnBNAddItem1;
        public System.Windows.Forms.ToolStripButton btnBNEditItem1;
        public System.Windows.Forms.ToolStripButton btnBNDeleteItem1;
        public System.Windows.Forms.ToolStripButton btnBNSaveItem1;
        public System.Windows.Forms.ToolStripButton btnBNCancelItem1;
        public System.Windows.Forms.ToolStripButton btnBNRefresh1;

        public System.Windows.Forms.ToolStripButton btnBNPrint1;
        
        public System.Windows.Forms.ToolStripDropDownButton btnBNProcess;
        public System.Windows.Forms.ToolStripMenuItem TSMItem1;
        public System.Windows.Forms.ToolStripMenuItem TSMItem2;
        public System.Windows.Forms.ToolStripMenuItem TSMItem3;
        public System.Windows.Forms.ToolStripMenuItem TSMItem4;
        public System.Windows.Forms.ToolStripMenuItem TSMItem5;

        public CButtonLib.CButton btnBNAddItem;
        public CButtonLib.CButton btnBNSaveItem;
        public CButtonLib.CButton btnBNDeleteItem;
        public CButtonLib.CButton btnBNEditItem;
        public CButtonLib.CButton btnBNRefresh;
        public CButtonLib.CButton btnBNCancelItem;
        //public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;

    }
}
