
namespace ControlLibrary.LibControls
{
    partial class Notification
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
            this.lblModule = new System.Windows.Forms.Label();
            this.lblNotification = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblModule
            // 
            this.lblModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModule.AutoSize = true;
            this.lblModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.Location = new System.Drawing.Point(4, 5);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(60, 17);
            this.lblModule.TabIndex = 0;
            this.lblModule.Text = "module";
            this.lblModule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotification
            // 
            this.lblNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNotification.Location = new System.Drawing.Point(7, 36);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(320, 45);
            this.lblNotification.TabIndex = 1;
            this.lblNotification.Text = "Notification";
            this.lblNotification.Click += new System.EventHandler(this.lblNotification_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDate.Location = new System.Drawing.Point(199, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(60, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Notification";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblID.Location = new System.Drawing.Point(124, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "label1";
            this.lblID.Visible = false;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.lblModule);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Notification";
            this.Size = new System.Drawing.Size(330, 92);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Click += new System.EventHandler(this.Notification_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblID;
    }
}
