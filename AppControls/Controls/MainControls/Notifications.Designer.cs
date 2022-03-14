
namespace AppControls
{
    partial class Notifications
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
            this.NotificationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // NotificationPanel
            // 
            this.NotificationPanel.AutoScroll = true;
            this.NotificationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NotificationPanel.Location = new System.Drawing.Point(0, 0);
            this.NotificationPanel.Name = "NotificationPanel";
            this.NotificationPanel.Size = new System.Drawing.Size(351, 479);
            this.NotificationPanel.TabIndex = 0;
            this.NotificationPanel.WrapContents = false;
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.NotificationPanel);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(351, 479);
            this.Load += new System.EventHandler(this.Notifications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel NotificationPanel;
    }
}
