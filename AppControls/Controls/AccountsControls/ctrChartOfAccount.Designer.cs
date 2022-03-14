namespace Accounts.Parameter
{
    partial class ctrChartOfAccount
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
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCriteria
            // 
            this.cboCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "Complete",
            "1st Level",
            "2nd Level",
            "3rd Level"});
            this.cboCriteria.Location = new System.Drawing.Point(13, 56);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(205, 21);
            this.cboCriteria.TabIndex = 0;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(143, 117);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(75, 23);
            this.btnLoadReport.TabIndex = 5;
            this.btnLoadReport.Text = "Load Report";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            // 
            // ctrChartOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.cboCriteria);
            this.Name = "ctrChartOfAccount";
            this.Size = new System.Drawing.Size(221, 203);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnLoadReport;
        public System.Windows.Forms.ComboBox cboCriteria;
    }
}
