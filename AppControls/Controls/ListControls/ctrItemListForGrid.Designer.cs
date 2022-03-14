namespace AppControls
{
    partial class ctrItemListForGrid
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
            this.cboBoxItmType = new System.Windows.Forms.ComboBox();
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.SuspendLayout();
            // 
            // cboBoxItmType
            // 
            this.cboBoxItmType.FormattingEnabled = true;
            this.cboBoxItmType.Items.AddRange(new object[] {
            "Item",
            "Labor",
            "Fee"});
            this.cboBoxItmType.Location = new System.Drawing.Point(4, 36);
            this.cboBoxItmType.Name = "cboBoxItmType";
            this.cboBoxItmType.Size = new System.Drawing.Size(80, 21);
            this.cboBoxItmType.TabIndex = 1;
            this.cboBoxItmType.Visible = false;
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(625, 250);
            this.searchDataGridView1.TabIndex = 0;
            // 
            // ctrItemListForGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboBoxItmType);
            this.Controls.Add(this.searchDataGridView1);
            this.Name = "ctrItemListForGrid";
            this.Size = new System.Drawing.Size(625, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private System.Windows.Forms.ComboBox cboBoxItmType;
                
    }
}
