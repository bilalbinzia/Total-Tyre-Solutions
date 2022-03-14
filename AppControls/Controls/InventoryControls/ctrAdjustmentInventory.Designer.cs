namespace AppControls
{
    partial class ctrAdjustmentInventory
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewQty = new ControlLibrary.TATextBox();
            this.ctrAdjQty = new ControlLibrary.TANumericUpDown();
            this.txtNewCatalogCost = new ControlLibrary.TATextBox();
            this.ctrAdjDate = new ControlLibrary.TADateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrAdjQty)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.ctrAdjDate);
            this.WorkingPanel.Controls.Add(this.txtNewCatalogCost);
            this.WorkingPanel.Controls.Add(this.ctrAdjQty);
            this.WorkingPanel.Controls.Add(this.txtNewQty);
            this.WorkingPanel.Controls.Add(this.label2);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.label17);
            this.WorkingPanel.Controls.Add(this.label15);
            this.WorkingPanel.Controls.Add(this.lblCatalog);
            this.WorkingPanel.Controls.Add(this.lblDescription);
            this.WorkingPanel.Controls.Add(this.lblItem);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Controls.Add(this.label7);
            this.WorkingPanel.Controls.Add(this.label5);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.label6);
            this.WorkingPanel.Controls.Add(this.label3);
            this.WorkingPanel.Size = new System.Drawing.Size(599, 410);
            this.WorkingPanel.Controls.SetChildIndex(this.label3, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label6, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label5, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label7, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label8, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.lblItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.lblDescription, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.lblCatalog, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label15, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label17, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label2, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtNewQty, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrAdjQty, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtNewCatalogCost, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.ctrAdjDate, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11672;
            this.label3.Text = "Item / Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(14, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11672;
            this.label4.Text = "Catalog";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(-98, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11672;
            this.label5.Text = "Adjustment Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(14, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11672;
            this.label6.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(-101, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 11672;
            this.label7.Text = "Adjustment Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(-209, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 11672;
            this.label8.Text = "Adjustment Date";
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCatalog.Location = new System.Drawing.Point(89, 86);
            this.lblCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(16, 13);
            this.lblCatalog.TabIndex = 11684;
            this.lblCatalog.Text = "...";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription.Location = new System.Drawing.Point(89, 106);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(16, 13);
            this.lblDescription.TabIndex = 11685;
            this.lblDescription.Text = "...";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItem.Location = new System.Drawing.Point(89, 64);
            this.lblItem.Margin = new System.Windows.Forms.Padding(0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(16, 13);
            this.lblItem.TabIndex = 11686;
            this.lblItem.Text = "...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Location = new System.Drawing.Point(12, 139);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 11672;
            this.label15.Text = "Adjustment Date";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Location = new System.Drawing.Point(12, 163);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 11676;
            this.label17.Text = "Quantity to Adjust";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11678;
            this.label1.Text = "New Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11681;
            this.label2.Text = "New Cost";
            // 
            // txtNewQty
            // 
            this.txtNewQty.Enabled = false;
            this.txtNewQty.Location = new System.Drawing.Point(106, 186);
            this.txtNewQty.MaxLength = 150;
            this.txtNewQty.Name = "txtNewQty";
            this.txtNewQty.Size = new System.Drawing.Size(60, 20);
            this.txtNewQty.TabIndex = 11683;
            this.txtNewQty.xBindingProperty = "NewQty";
            this.txtNewQty.xColumnName = "NewQty";
            this.txtNewQty.xColumnWidth = 60;
            this.txtNewQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtNewQty.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtNewQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtNewQty.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtNewQty.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtNewQty.xMasked = System32.StaticInfo.Mask.Digit;
            this.txtNewQty.xReadOnly = false;
            // 
            // ctrAdjQty
            // 
            this.ctrAdjQty.Location = new System.Drawing.Point(106, 161);
            this.ctrAdjQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctrAdjQty.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ctrAdjQty.Name = "ctrAdjQty";
            this.ctrAdjQty.Size = new System.Drawing.Size(60, 20);
            this.ctrAdjQty.TabIndex = 11684;
            this.ctrAdjQty.xBindingProperty = "Qty";
            this.ctrAdjQty.xColumnName = "Qty";
            this.ctrAdjQty.xColumnWidth = 60;
            this.ctrAdjQty.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrAdjQty.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrAdjQty.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // txtNewCatalogCost
            // 
            this.txtNewCatalogCost.Location = new System.Drawing.Point(106, 211);
            this.txtNewCatalogCost.MaxLength = 150;
            this.txtNewCatalogCost.Name = "txtNewCatalogCost";
            this.txtNewCatalogCost.Size = new System.Drawing.Size(60, 20);
            this.txtNewCatalogCost.TabIndex = 11685;
            this.txtNewCatalogCost.xBindingProperty = "NewCost";
            this.txtNewCatalogCost.xColumnName = "NewQty";
            this.txtNewCatalogCost.xColumnWidth = 60;
            this.txtNewCatalogCost.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtNewCatalogCost.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtNewCatalogCost.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtNewCatalogCost.xIsShowCashSymbol = System32.StaticInfo.YesNo.Yes;
            this.txtNewCatalogCost.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtNewCatalogCost.xMasked = System32.StaticInfo.Mask.Decimal;
            this.txtNewCatalogCost.xReadOnly = false;
            // 
            // ctrAdjDate
            // 
            this.ctrAdjDate.CustomFormat = "MM-dd-yyyy hh:ss tt";
            this.ctrAdjDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctrAdjDate.Location = new System.Drawing.Point(106, 135);
            this.ctrAdjDate.Name = "ctrAdjDate";
            this.ctrAdjDate.Size = new System.Drawing.Size(160, 20);
            this.ctrAdjDate.TabIndex = 11686;
            this.ctrAdjDate.Value = new System.DateTime(2019, 9, 12, 0, 0, 0, 0);
            this.ctrAdjDate.xBindingProperty = "AdjustmentDate";
            this.ctrAdjDate.xColumnName = "AdjustmentDate";
            this.ctrAdjDate.xColumnWidth = 60;
            this.ctrAdjDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.ctrAdjDate.xIsRequired = System32.StaticInfo.YesNo.No;
            this.ctrAdjDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.No;
            this.ctrAdjDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrAdjustmentInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrAdjustmentInventory";
            this.Size = new System.Drawing.Size(599, 410);
            this.xTableName = "InventoryAdjustment";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrAdjQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItem;
        private ControlLibrary.TADateTimePicker ctrAdjDate;
        private ControlLibrary.TATextBox txtNewCatalogCost;
        private ControlLibrary.TANumericUpDown ctrAdjQty;
        private ControlLibrary.TATextBox txtNewQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
    }
}
