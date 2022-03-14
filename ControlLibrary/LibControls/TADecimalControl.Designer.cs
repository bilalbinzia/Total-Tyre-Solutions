namespace ControlLibrary
{
    partial class TADecimalControl
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
            this.txtBoxN0 = new ControlLibrary.TATextBox();
            this.txtBoxN1 = new ControlLibrary.TATextBox();
            this.lblBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxN0
            // 
            this.txtBoxN0.Location = new System.Drawing.Point(87, 0);
            this.txtBoxN0.MaxLength = 80;
            this.txtBoxN0.Name = "txtBoxN0";
            this.txtBoxN0.Size = new System.Drawing.Size(85, 20);
            this.txtBoxN0.TabIndex = 0;
            this.txtBoxN0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxN0_KeyDown);
            this.txtBoxN0.Leave += new System.EventHandler(this.txtBoxN0_Leave);
            // 
            // txtBoxN1
            // 
            this.txtBoxN1.Enabled = false;
            this.txtBoxN1.Location = new System.Drawing.Point(178, 0);
            this.txtBoxN1.Name = "txtBoxN1";
            this.txtBoxN1.ReadOnly = true;
            this.txtBoxN1.Size = new System.Drawing.Size(85, 20);
            this.txtBoxN1.TabIndex = 11217;
            // 
            // lblBox
            // 
            this.lblBox.AutoSize = true;
            this.lblBox.Location = new System.Drawing.Point(4, 4);
            this.lblBox.Name = "lblBox";
            this.lblBox.Size = new System.Drawing.Size(35, 13);
            this.lblBox.TabIndex = 11218;
            this.lblBox.Text = "label1";
            // 
            // TADecimalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBox);
            this.Controls.Add(this.txtBoxN0);
            this.Controls.Add(this.txtBoxN1);
            this.Name = "TADecimalControl";
            this.Size = new System.Drawing.Size(265, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBox;
        public TATextBox txtBoxN1;
        public TATextBox txtBoxN0;
    }
}
