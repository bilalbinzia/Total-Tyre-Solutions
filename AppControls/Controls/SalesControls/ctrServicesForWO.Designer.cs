namespace AppControls
{
    partial class ctrServicesForWO
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
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.txtBoxName = new ControlLibrary.TATextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOutsidePart = new ControlLibrary.TAButton();
            this.btnShopLabor = new ControlLibrary.TAButton();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.panel3);
            this.WorkingPanel.Controls.Add(this.panel2);
            this.WorkingPanel.Controls.Add(this.panel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Size = new System.Drawing.Size(410, 451);
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(248, 449);
            this.searchDataGridView1.TabIndex = 2;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(157, 14);
            this.txtBoxName.MaxLength = 150;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(53, 20);
            this.txtBoxName.TabIndex = 11541;
            this.txtBoxName.Visible = false;
            this.txtBoxName.xBindingProperty = "Name";
            this.txtBoxName.xColumnName = "Name";
            this.txtBoxName.xColumnWidth = 200;
            this.txtBoxName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxName.xReadOnly = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.searchDataGridView1);
            this.panel1.Controls.Add(this.txtBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 451);
            this.panel1.TabIndex = 11544;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(250, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 415);
            this.panel2.TabIndex = 11545;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnOutsidePart);
            this.panel3.Controls.Add(this.btnShopLabor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(250, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 37);
            this.panel3.TabIndex = 11545;
            // 
            // btnOutsidePart
            // 
            this.btnOutsidePart.BackColor = System.Drawing.SystemColors.Control;
            this.btnOutsidePart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOutsidePart.Location = new System.Drawing.Point(80, 7);
            this.btnOutsidePart.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnOutsidePart.Name = "btnOutsidePart";
            this.btnOutsidePart.Size = new System.Drawing.Size(76, 24);
            this.btnOutsidePart.TabIndex = 11663;
            this.btnOutsidePart.Text = "Outside Part";
            this.btnOutsidePart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnShopLabor
            // 
            this.btnShopLabor.BackColor = System.Drawing.SystemColors.Control;
            this.btnShopLabor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnShopLabor.Location = new System.Drawing.Point(4, 7);
            this.btnShopLabor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnShopLabor.Name = "btnShopLabor";
            this.btnShopLabor.Size = new System.Drawing.Size(76, 24);
            this.btnShopLabor.TabIndex = 11662;
            this.btnShopLabor.Text = "ShopLabor";
            this.btnShopLabor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // ctrServicesForWO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.controlName = "ctrServicesForWO";
            this.Name = "ctrServicesForWO";
            this.Size = new System.Drawing.Size(410, 451);
            this.xPrefixDocNo = "WS";
            this.xTableName = "WarehousePackages";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TATextBox txtBoxName;
        public ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ControlLibrary.TAButton btnOutsidePart;
        private ControlLibrary.TAButton btnShopLabor;
        
    }
}
