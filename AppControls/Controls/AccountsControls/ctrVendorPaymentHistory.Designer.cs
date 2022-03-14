namespace AppControls
{
    partial class ctrVendorPaymentHistory
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
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVoidPayment = new ControlLibrary.TAButton();
            this.chkboxShowAll = new ControlLibrary.TACheckBox();
            this.DGVVendorPaymentList = new ControlLibrary.TAZSearchDataGridView();
            this.chkboxShowVoid = new ControlLibrary.TACheckBox();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVVendorPaymentList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.672897F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.3271F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 535);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 25);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.65767F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.65767F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.109489F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.85053F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.81485F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.835766F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.33577F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Controls.Add(this.btnVoidPayment, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkboxShowAll, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkboxShowVoid, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1037, 25);
            this.tableLayoutPanel3.TabIndex = 11569;
            // 
            // btnVoidPayment
            // 
            this.btnVoidPayment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnVoidPayment.ColorFillBlend = cBlendItems2;
            this.btnVoidPayment.DesignerSelected = false;
            this.btnVoidPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVoidPayment.ImageIndex = 0;
            this.btnVoidPayment.Location = new System.Drawing.Point(214, 0);
            this.btnVoidPayment.Margin = new System.Windows.Forms.Padding(0);
            this.btnVoidPayment.Name = "btnVoidPayment";
            this.btnVoidPayment.Size = new System.Drawing.Size(90, 25);
            this.btnVoidPayment.TabIndex = 10;
            this.btnVoidPayment.Text = "Void Payment";
            this.btnVoidPayment.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // chkboxShowAll
            // 
            this.chkboxShowAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowAll.AutoSize = true;
            this.chkboxShowAll.Location = new System.Drawing.Point(357, 4);
            this.chkboxShowAll.Margin = new System.Windows.Forms.Padding(0);
            this.chkboxShowAll.Name = "chkboxShowAll";
            this.chkboxShowAll.Size = new System.Drawing.Size(67, 17);
            this.chkboxShowAll.TabIndex = 14;
            this.chkboxShowAll.Text = "Show All";
            this.chkboxShowAll.ToolTipText = null;
            this.chkboxShowAll.UseVisualStyleBackColor = true;
            this.chkboxShowAll.xBindingProperty = null;
            this.chkboxShowAll.xColumnName = null;
            this.chkboxShowAll.xColumnWidth = 60;
            this.chkboxShowAll.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkboxShowAll.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkboxShowAll.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // DGVVendorPaymentList
            // 
            this.DGVVendorPaymentList.AutoScroll = true;
            this.DGVVendorPaymentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVendorPaymentList.Location = new System.Drawing.Point(4, 29);
            this.DGVVendorPaymentList.Margin = new System.Windows.Forms.Padding(4);
            this.DGVVendorPaymentList.Name = "DGVVendorPaymentList";
            this.DGVVendorPaymentList.Size = new System.Drawing.Size(1029, 502);
            this.DGVVendorPaymentList.TabIndex = 4;
            // 
            // chkboxShowVoid
            // 
            this.chkboxShowVoid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkboxShowVoid.AutoSize = true;
            this.chkboxShowVoid.Location = new System.Drawing.Point(511, 4);
            this.chkboxShowVoid.Margin = new System.Windows.Forms.Padding(0);
            this.chkboxShowVoid.Name = "chkboxShowVoid";
            this.chkboxShowVoid.Size = new System.Drawing.Size(77, 17);
            this.chkboxShowVoid.TabIndex = 15;
            this.chkboxShowVoid.Text = "Show Void";
            this.chkboxShowVoid.ToolTipText = null;
            this.chkboxShowVoid.UseVisualStyleBackColor = true;
            this.chkboxShowVoid.xBindingProperty = null;
            this.chkboxShowVoid.xColumnName = null;
            this.chkboxShowVoid.xColumnWidth = 60;
            this.chkboxShowVoid.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.chkboxShowVoid.xIsRequired = System32.StaticInfo.YesNo.No;
            this.chkboxShowVoid.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrVendorPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ctrVendorPaymentHistory";
            this.Size = new System.Drawing.Size(1037, 535);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ControlLibrary.TAButton btnVoidPayment;
        public ControlLibrary.TAZSearchDataGridView DGVVendorPaymentList;
        private ControlLibrary.TACheckBox chkboxShowAll;
        private ControlLibrary.TACheckBox chkboxShowVoid;
    }
}
