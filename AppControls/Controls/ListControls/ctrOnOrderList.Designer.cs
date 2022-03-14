namespace AppControls
{
    partial class ctrOnOrderList
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
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.txtItemCatalog = new ControlLibrary.TATextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemName = new ControlLibrary.TATextBox();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.txtItemCatalog);
            this.WorkingPanel.Controls.Add(this.label10);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Controls.Add(this.txtItemName);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(625, 282);
            this.WorkingPanel.TabIndex = 1;
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 32);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(625, 250);
            this.searchDataGridView1.TabIndex = 0;
            // 
            // txtItemCatalog
            // 
            this.txtItemCatalog.Location = new System.Drawing.Point(67, 6);
            this.txtItemCatalog.MaxLength = 150;
            this.txtItemCatalog.Name = "txtItemCatalog";
            this.txtItemCatalog.ReadOnly = true;
            this.txtItemCatalog.Size = new System.Drawing.Size(164, 20);
            this.txtItemCatalog.TabIndex = 11544;
            this.txtItemCatalog.xBindingProperty = "Catalog";
            this.txtItemCatalog.xColumnName = "Catalog";
            this.txtItemCatalog.xColumnWidth = 80;
            this.txtItemCatalog.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtItemCatalog.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtItemCatalog.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtItemCatalog.xMasked = System32.StaticInfo.Mask.None;
            this.txtItemCatalog.xReadOnly = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 11545;
            this.label10.Text = "Catalog";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11543;
            this.label8.Text = "Description";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(301, 6);
            this.txtItemName.MaxLength = 150;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(298, 20);
            this.txtItemName.TabIndex = 11542;
            this.txtItemName.xBindingProperty = "Name";
            this.txtItemName.xColumnName = "Name";
            this.txtItemName.xColumnWidth = 120;
            this.txtItemName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtItemName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtItemName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtItemName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtItemName.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtItemName.xMasked = System32.StaticInfo.Mask.None;
            this.txtItemName.xReadOnly = false;
            // 
            // ctrOnOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrOnOrderList";
            this.Size = new System.Drawing.Size(625, 282);
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkingPanel;
        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private ControlLibrary.TATextBox txtItemCatalog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private ControlLibrary.TATextBox txtItemName;

        
    }
}
