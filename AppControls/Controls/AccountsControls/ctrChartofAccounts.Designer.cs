namespace AppControls
{
    partial class ctrChartofAccounts
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label accNameLabel;
            System.Windows.Forms.Label label1;
            this.txtBoxAccTypeID = new ControlLibrary.TATextBox();
            this.txtBoxAccID = new ControlLibrary.TATextBox();
            this.txtBoxAccName = new ControlLibrary.TATextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtBoxAccNo = new ControlLibrary.TATextBox();
            label4 = new System.Windows.Forms.Label();
            accNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.txtBoxAccNo);
            this.WorkingPanel.Controls.Add(label1);
            this.WorkingPanel.Controls.Add(this.txtBoxAccTypeID);
            this.WorkingPanel.Controls.Add(this.txtBoxAccID);
            this.WorkingPanel.Controls.Add(label4);
            this.WorkingPanel.Controls.Add(accNameLabel);
            this.WorkingPanel.Controls.Add(this.txtBoxAccName);
            this.WorkingPanel.Controls.Add(this.treeView1);
            this.WorkingPanel.Size = new System.Drawing.Size(711, 591);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.treeView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxAccName, 0);
            this.WorkingPanel.Controls.SetChildIndex(accNameLabel, 0);
            this.WorkingPanel.Controls.SetChildIndex(label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxAccID, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxAccTypeID, 0);
            this.WorkingPanel.Controls.SetChildIndex(label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxAccNo, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(417, 189);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 11458;
            label4.Text = "Account ID:";
            label4.Visible = false;
            // 
            // accNameLabel
            // 
            accNameLabel.AutoSize = true;
            accNameLabel.Location = new System.Drawing.Point(422, 266);
            accNameLabel.Name = "accNameLabel";
            accNameLabel.Size = new System.Drawing.Size(60, 13);
            accNameLabel.TabIndex = 11457;
            accNameLabel.Text = "Acc Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(415, 240);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 13);
            label1.TabIndex = 11461;
            label1.Text = "Account No:";
            // 
            // txtBoxAccTypeID
            // 
            this.txtBoxAccTypeID.Location = new System.Drawing.Point(487, 159);
            this.txtBoxAccTypeID.MaxLength = 9;
            this.txtBoxAccTypeID.Name = "txtBoxAccTypeID";
            this.txtBoxAccTypeID.Size = new System.Drawing.Size(92, 20);
            this.txtBoxAccTypeID.TabIndex = 11459;
            this.txtBoxAccTypeID.Visible = false;
            this.txtBoxAccTypeID.xBindingProperty = "AccTypeID";
            this.txtBoxAccTypeID.xColumnName = null;
            this.txtBoxAccTypeID.xColumnWidth = 60;
            this.txtBoxAccTypeID.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtBoxAccTypeID.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxAccTypeID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBoxAccTypeID.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxAccTypeID.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxAccTypeID.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxAccTypeID.xReadOnly = false;
            // 
            // txtBoxAccID
            // 
            this.txtBoxAccID.Location = new System.Drawing.Point(487, 185);
            this.txtBoxAccID.MaxLength = 9;
            this.txtBoxAccID.Name = "txtBoxAccID";
            this.txtBoxAccID.Size = new System.Drawing.Size(92, 20);
            this.txtBoxAccID.TabIndex = 11455;
            this.txtBoxAccID.Visible = false;
            this.txtBoxAccID.xBindingProperty = "AccID";
            this.txtBoxAccID.xColumnName = null;
            this.txtBoxAccID.xColumnWidth = 60;
            this.txtBoxAccID.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxAccID.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxAccID.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBoxAccID.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxAccID.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxAccID.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxAccID.xReadOnly = false;
            // 
            // txtBoxAccName
            // 
            this.txtBoxAccName.Location = new System.Drawing.Point(487, 263);
            this.txtBoxAccName.MaxLength = 100;
            this.txtBoxAccName.Name = "txtBoxAccName";
            this.txtBoxAccName.Size = new System.Drawing.Size(200, 20);
            this.txtBoxAccName.TabIndex = 11456;
            this.txtBoxAccName.xBindingProperty = "AccName";
            this.txtBoxAccName.xColumnName = null;
            this.txtBoxAccName.xColumnWidth = 60;
            this.txtBoxAccName.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.txtBoxAccName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxAccName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxAccName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxAccName.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxAccName.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxAccName.xReadOnly = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(380, 484);
            this.treeView1.TabIndex = 11454;
            // 
            // txtBoxAccNo
            // 
            this.txtBoxAccNo.Location = new System.Drawing.Point(487, 237);
            this.txtBoxAccNo.MaxLength = 9;
            this.txtBoxAccNo.Name = "txtBoxAccNo";
            this.txtBoxAccNo.Size = new System.Drawing.Size(92, 20);
            this.txtBoxAccNo.TabIndex = 11460;
            this.txtBoxAccNo.xBindingProperty = "AccNo";
            this.txtBoxAccNo.xColumnName = null;
            this.txtBoxAccNo.xColumnWidth = 60;
            this.txtBoxAccNo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxAccNo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxAccNo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtBoxAccNo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxAccNo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtBoxAccNo.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxAccNo.xReadOnly = false;
            // 
            // ctrChartofAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrChartofAccounts";
            this.Size = new System.Drawing.Size(711, 591);
            this.xBNCountItemIsVisible = false;
            this.xBNPositionItemIsVisible = false;
            this.xBNSeparator1IsVisible = false;
            this.xBNSeparator2IsVisible = false;
            this.xBNSeparatorIsVisible = false;
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNMoveFirstItemIsVisible = false;
            this.xbtnBNMoveLastItemIsVisible = false;
            this.xbtnBNMoveNextItemIsVisible = false;
            this.xbtnBNMovePreviousItemIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "COA";
            this.xTableName = "Account";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TATextBox txtBoxAccTypeID;
        private ControlLibrary.TATextBox txtBoxAccID;
        private ControlLibrary.TATextBox txtBoxAccName;
        private System.Windows.Forms.TreeView treeView1;
        private ControlLibrary.TATextBox txtBoxAccNo;
    }
}
