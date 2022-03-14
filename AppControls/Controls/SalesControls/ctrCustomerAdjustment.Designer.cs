namespace AppControls
{
    partial class ctrCustomerAdjustment
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
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrAmount = new ControlLibrary.TATextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpAdjustment = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new ControlLibrary.TAButton();
            this.taDescription = new ControlLibrary.TATextBox();
            this.btnNew = new ControlLibrary.TAButton();
            this.DGVCustomerList = new ControlLibrary.TAZSearchDataGridView();
            this.DGVAdjustmentList = new ControlLibrary.TAZSearchDataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVCustomerList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVAdjustmentList, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 535);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 236);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 54);
            this.panel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.60271F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.480813F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.239278F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.098674F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.36632F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.746546F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.01166F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.479693F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.ctrAmount, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.label36, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpAdjustment, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.taDescription, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnNew, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1037, 54);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 11676;
            this.label2.Text = "Description";
            // 
            // ctrAmount
            // 
            this.ctrAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ctrAmount.Enabled = false;
            this.ctrAmount.Location = new System.Drawing.Point(938, 3);
            this.ctrAmount.Margin = new System.Windows.Forms.Padding(0);
            this.ctrAmount.MaxLength = 150;
            this.ctrAmount.Name = "ctrAmount";
            this.ctrAmount.ReadOnly = true;
            this.ctrAmount.Size = new System.Drawing.Size(85, 20);
            this.ctrAmount.TabIndex = 11673;
            this.ctrAmount.xBindingProperty = "";
            this.ctrAmount.xColumnName = "";
            this.ctrAmount.xColumnWidth = 60;
            this.ctrAmount.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ctrAmount.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.ctrAmount.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrAmount.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.ctrAmount.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.ctrAmount.xMasked = System32.StaticInfo.Mask.None;
            this.ctrAmount.xReadOnly = false;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(895, 7);
            this.label36.Margin = new System.Windows.Forms.Padding(0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 13);
            this.label36.TabIndex = 11672;
            this.label36.Text = "Amount";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Location = new System.Drawing.Point(652, 7);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 11593;
            this.label14.Text = "Account";
            // 
            // dtpAdjustment
            // 
            this.dtpAdjustment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAdjustment.Enabled = false;
            this.dtpAdjustment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdjustment.Location = new System.Drawing.Point(562, 3);
            this.dtpAdjustment.Name = "dtpAdjustment";
            this.dtpAdjustment.Size = new System.Drawing.Size(84, 20);
            this.dtpAdjustment.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(505, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11674;
            this.label1.Text = "Trns Date";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSave.ColorFillBlend = cBlendItems1;
            this.btnSave.DesignerSelected = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 0;
            this.btnSave.Location = new System.Drawing.Point(425, 1);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // taDescription
            // 
            this.taDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.taDescription.Enabled = false;
            this.taDescription.Location = new System.Drawing.Point(66, 30);
            this.taDescription.Margin = new System.Windows.Forms.Padding(0);
            this.taDescription.Name = "taDescription";
            this.taDescription.ReadOnly = true;
            this.taDescription.Size = new System.Drawing.Size(271, 20);
            this.taDescription.TabIndex = 11675;
            this.taDescription.xBindingProperty = "Mileage";
            this.taDescription.xColumnName = null;
            this.taDescription.xColumnWidth = 60;
            this.taDescription.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.taDescription.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taDescription.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taDescription.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taDescription.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taDescription.xMasked = System32.StaticInfo.Mask.None;
            this.taDescription.xReadOnly = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNew.ColorFillBlend = cBlendItems2;
            this.btnNew.DesignerSelected = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.ImageIndex = 0;
            this.btnNew.Location = new System.Drawing.Point(342, 1);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 25);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New";
            this.btnNew.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // DGVCustomerList
            // 
            this.DGVCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCustomerList.Location = new System.Drawing.Point(0, 0);
            this.DGVCustomerList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVCustomerList.Name = "DGVCustomerList";
            this.DGVCustomerList.Size = new System.Drawing.Size(1037, 236);
            this.DGVCustomerList.TabIndex = 3;
            // 
            // DGVAdjustmentList
            // 
            this.DGVAdjustmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAdjustmentList.Location = new System.Drawing.Point(0, 290);
            this.DGVAdjustmentList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVAdjustmentList.Name = "DGVAdjustmentList";
            this.DGVAdjustmentList.Size = new System.Drawing.Size(1037, 236);
            this.DGVAdjustmentList.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(702, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 11677;
            // 
            // ctrCustomerAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrCustomerAdjustment";
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
        private System.Windows.Forms.DateTimePicker dtpAdjustment;
        public ControlLibrary.TAZSearchDataGridView DGVCustomerList;
        public ControlLibrary.TAZSearchDataGridView DGVAdjustmentList;
        private ControlLibrary.TAButton btnNew;
        private ControlLibrary.TAButton btnSave;
        private System.Windows.Forms.Label label14;
        private ControlLibrary.TATextBox ctrAmount;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox taDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
