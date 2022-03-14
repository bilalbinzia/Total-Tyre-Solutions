namespace ControlLibrary
{
    partial class frmOperationMessage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelToolTip = new ControlLibrary.GradientPanel();
            this.lblToolTip = new System.Windows.Forms.Label();
            this.panelToolTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToolTip
            // 
            this.panelToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelToolTip.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panelToolTip.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelToolTip.Controls.Add(this.lblToolTip);
            this.panelToolTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolTip.Location = new System.Drawing.Point(0, 0);
            this.panelToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.panelToolTip.Name = "panelToolTip";
            this.panelToolTip.Size = new System.Drawing.Size(226, 54);
            this.panelToolTip.TabIndex = 11672;
            // 
            // lblToolTip
            // 
            this.lblToolTip.BackColor = System.Drawing.Color.Transparent;
            this.lblToolTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTip.ForeColor = System.Drawing.Color.White;
            this.lblToolTip.Location = new System.Drawing.Point(0, 0);
            this.lblToolTip.Margin = new System.Windows.Forms.Padding(0);
            this.lblToolTip.Name = "lblToolTip";
            this.lblToolTip.Size = new System.Drawing.Size(226, 54);
            this.lblToolTip.TabIndex = 22;
            this.lblToolTip.Text = "Data Save Successfully ....";
            this.lblToolTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOperationMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 54);
            this.Controls.Add(this.panelToolTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOperationMessage";
            this.Text = "frmOperationMessage";
            this.panelToolTip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public GradientPanel panelToolTip;
        public System.Windows.Forms.Label lblToolTip;
    }
}