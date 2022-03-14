namespace AppControls
{
    partial class ctrItemType
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
            this.txtBoxName = new ControlLibrary.TATextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Controls.Add(this.txtBoxName);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Size = new System.Drawing.Size(570, 420);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label8, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxName, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.searchDataGridView1, 0);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(184, 70);
            this.txtBoxName.MaxLength = 150;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(151, 20);
            this.txtBoxName.TabIndex = 11511;
            this.txtBoxName.xBindingProperty = "Name";
            this.txtBoxName.xColumnName = "Name";
            this.txtBoxName.xColumnWidth = 150;
            this.txtBoxName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxName.xReadOnly = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11514;
            this.label8.Text = "Description";
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 130);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(570, 270);
            this.searchDataGridView1.TabIndex = 11519;
            // 
            // ctrItemType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.controlName = "ctrItemType";
            this.Name = "ctrItemType";
            this.Size = new System.Drawing.Size(570, 420);
            this.xBNCountItemIsVisible = false;
            this.xBNPositionItemIsVisible = false;
            this.xBNSeparator1IsVisible = false;
            this.xBNSeparator2IsVisible = false;
            this.xBNSeparatorIsVisible = false;
            this.xbtnBNDeleteItemIsVisible = false;
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNMoveFirstItemIsVisible = false;
            this.xbtnBNMoveLastItemIsVisible = false;
            this.xbtnBNMoveNextItemIsVisible = false;
            this.xbtnBNMovePreviousItemIsVisible = false;
            this.xbtnBNPrintIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "itt";
            this.xTableName = "ItemType";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TATextBox txtBoxName;
        private System.Windows.Forms.Label label8;
        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
    }
}
