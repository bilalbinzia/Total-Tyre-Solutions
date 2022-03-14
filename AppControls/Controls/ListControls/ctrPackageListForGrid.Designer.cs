namespace AppControls
{
    partial class ctrPackageListForGrid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchPackageDataGridView2 = new ControlLibrary.TAZSearchDataGridView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SearchPackageDataGridView2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 224);
            this.panel1.TabIndex = 0;
            // 
            // SearchPackageDataGridView2
            // 
            this.SearchPackageDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPackageDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.SearchPackageDataGridView2.Name = "SearchPackageDataGridView2";
            this.SearchPackageDataGridView2.Size = new System.Drawing.Size(608, 224);
            this.SearchPackageDataGridView2.TabIndex = 0;
            // 
            // ctrPackageListForGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrPackageListForGrid";
            this.Size = new System.Drawing.Size(608, 224);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.GradientPanel gradientPanel1;
        private ControlLibrary.TAZSearchDataGridView tazSearchDataGridView1;
        private System.Windows.Forms.Panel panel1;
        private ControlLibrary.TAZSearchDataGridView SearchPackageDataGridView2;
    }
}
