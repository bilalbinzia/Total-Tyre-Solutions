namespace AppControls
{
    partial class ctrOilViscosities
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
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.txtBoxName);
            this.WorkingPanel.Controls.Add(this.label4);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Size = new System.Drawing.Size(564, 393);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.searchDataGridView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label4, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxName, 0);
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 115);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(564, 258);
            this.searchDataGridView1.TabIndex = 3;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(163, 72);
            this.txtBoxName.MaxLength = 150;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(120, 20);
            this.txtBoxName.TabIndex = 11597;
            this.txtBoxName.xBindingProperty = "Name";
            this.txtBoxName.xColumnName = "Name";
            this.txtBoxName.xColumnWidth = 120;
            this.txtBoxName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtBoxName.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.txtBoxName.xMasked = System32.StaticInfo.Mask.None;
            this.txtBoxName.xReadOnly = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11598;
            this.label4.Text = "Viscosity";
            // 
            // ctrOilViscosities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrOilViscosities";
            this.Size = new System.Drawing.Size(564, 393);
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
            this.xPrefixDocNo = "Oil";
            this.xTableName = "OilViscosities";
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private ControlLibrary.TATextBox txtBoxName;
        private System.Windows.Forms.Label label4;
    }
}
