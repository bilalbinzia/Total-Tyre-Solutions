namespace AppControls
{
    partial class ctrManufacturers
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
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.taPictureBoxControl1 = new ControlLibrary.TAPictureBoxControl();
            this.tarbtIsWheel = new ControlLibrary.TARadioButton();
            this.tarbtIsTire = new ControlLibrary.TARadioButton();
            this.tarbtIsParts = new ControlLibrary.TARadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.objBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tarbtIsParts);
            this.WorkingPanel.Controls.Add(this.tarbtIsTire);
            this.WorkingPanel.Controls.Add(this.tarbtIsWheel);
            this.WorkingPanel.Controls.Add(this.taPictureBoxControl1);
            this.WorkingPanel.Controls.Add(this.taTextBox1);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Controls.Add(this.txtBoxName);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Size = new System.Drawing.Size(570, 486);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNAddItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNEditItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNDeleteItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNCancelItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNRefresh, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.btnBNSaveItem, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label8, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.txtBoxName, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.searchDataGridView1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.label1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taTextBox1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.taPictureBoxControl1, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.tarbtIsWheel, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.tarbtIsTire, 0);
            this.WorkingPanel.Controls.SetChildIndex(this.tarbtIsParts, 0);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(118, 108);
            this.txtBoxName.MaxLength = 150;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(264, 20);
            this.txtBoxName.TabIndex = 11511;
            this.txtBoxName.xBindingProperty = "Description";
            this.txtBoxName.xColumnName = "Description";
            this.txtBoxName.xColumnWidth = 120;
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
            this.label8.Location = new System.Drawing.Point(50, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 11514;
            this.label8.Text = "Description:";
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 250);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(570, 216);
            this.searchDataGridView1.TabIndex = 11519;
            // 
            // taTextBox1
            // 
            this.taTextBox1.Location = new System.Drawing.Point(118, 82);
            this.taTextBox1.MaxLength = 150;
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(178, 20);
            this.taTextBox1.TabIndex = 11672;
            this.taTextBox1.xBindingProperty = "Name";
            this.taTextBox1.xColumnName = "Name";
            this.taTextBox1.xColumnWidth = 120;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.taTextBox1.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.Yes;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            this.taTextBox1.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 11673;
            this.label1.Text = "Manufacturer:";
            // 
            // taPictureBoxControl1
            // 
            this.taPictureBoxControl1.Location = new System.Drawing.Point(396, 71);
            this.taPictureBoxControl1.Margin = new System.Windows.Forms.Padding(0);
            this.taPictureBoxControl1.Name = "taPictureBoxControl1";
            this.taPictureBoxControl1.Size = new System.Drawing.Size(133, 170);
            this.taPictureBoxControl1.TabIndex = 11676;
            this.taPictureBoxControl1.xBindingProperty = "Pic";
            this.taPictureBoxControl1.xDisplayMember = "Pic";
            this.taPictureBoxControl1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taPictureBoxControl1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taPictureBoxControl1.xTableName = "ItemManufacturer";
            this.taPictureBoxControl1.xValueMember = "ID";
            // 
            // tarbtIsWheel
            // 
            this.tarbtIsWheel.AutoSize = true;
            this.tarbtIsWheel.Checked = true;
            this.tarbtIsWheel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tarbtIsWheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarbtIsWheel.Location = new System.Drawing.Point(143, 145);
            this.tarbtIsWheel.Name = "tarbtIsWheel";
            this.tarbtIsWheel.Size = new System.Drawing.Size(67, 18);
            this.tarbtIsWheel.TabIndex = 11677;
            this.tarbtIsWheel.Text = "Wheel";
            this.tarbtIsWheel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tarbtIsWheel.ToolTipText = null;
            this.tarbtIsWheel.UseVisualStyleBackColor = true;
            this.tarbtIsWheel.xBindingProperty = "IsWheel";
            this.tarbtIsWheel.xColumnName = null;
            this.tarbtIsWheel.xColumnWidth = 60;
            this.tarbtIsWheel.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.tarbtIsWheel.xIsRequired = System32.StaticInfo.YesNo.No;
            this.tarbtIsWheel.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.tarbtIsWheel.xReadOnly = false;
            // 
            // tarbtIsTire
            // 
            this.tarbtIsTire.AutoSize = true;
            this.tarbtIsTire.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tarbtIsTire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarbtIsTire.Location = new System.Drawing.Point(216, 145);
            this.tarbtIsTire.Name = "tarbtIsTire";
            this.tarbtIsTire.Size = new System.Drawing.Size(53, 18);
            this.tarbtIsTire.TabIndex = 11678;
            this.tarbtIsTire.Text = "Tire";
            this.tarbtIsTire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tarbtIsTire.ToolTipText = null;
            this.tarbtIsTire.UseVisualStyleBackColor = true;
            this.tarbtIsTire.xBindingProperty = "IsTire";
            this.tarbtIsTire.xColumnName = null;
            this.tarbtIsTire.xColumnWidth = 60;
            this.tarbtIsTire.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.tarbtIsTire.xIsRequired = System32.StaticInfo.YesNo.No;
            this.tarbtIsTire.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.tarbtIsTire.xReadOnly = false;
            // 
            // tarbtIsParts
            // 
            this.tarbtIsParts.AutoSize = true;
            this.tarbtIsParts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tarbtIsParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarbtIsParts.Location = new System.Drawing.Point(275, 145);
            this.tarbtIsParts.Name = "tarbtIsParts";
            this.tarbtIsParts.Size = new System.Drawing.Size(60, 18);
            this.tarbtIsParts.TabIndex = 11679;
            this.tarbtIsParts.Text = "Parts";
            this.tarbtIsParts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tarbtIsParts.ToolTipText = null;
            this.tarbtIsParts.UseVisualStyleBackColor = true;
            this.tarbtIsParts.xBindingProperty = "IsParts";
            this.tarbtIsParts.xColumnName = null;
            this.tarbtIsParts.xColumnWidth = 60;
            this.tarbtIsParts.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.tarbtIsParts.xIsRequired = System32.StaticInfo.YesNo.No;
            this.tarbtIsParts.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.tarbtIsParts.xReadOnly = false;
            // 
            // ctrManufacturers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.controlName = "ctrManufacturers";
            this.Name = "ctrManufacturers";
            this.Size = new System.Drawing.Size(570, 486);
            this.xbtnBNListReportIsVisible = false;
            this.xbtnBNPrintIsVisible = false;
            this.xbtnBNRefreshIsVisible = false;
            this.xbtnBNRegisterIsVisible = false;
            this.xPrefixDocNo = "itm";
            this.xTableName = "ItemManufacturer";
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
        private ControlLibrary.TATextBox taTextBox1;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TAPictureBoxControl taPictureBoxControl1;
        private ControlLibrary.TARadioButton tarbtIsParts;
        private ControlLibrary.TARadioButton tarbtIsTire;
        private ControlLibrary.TARadioButton tarbtIsWheel;
    }
}
