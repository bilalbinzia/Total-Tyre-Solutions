
namespace AutoVaultEss
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusCompanyName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBranchName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusUserLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusUserLevel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusWorkingForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusLoginRemainingTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainManuPanel = new System.Windows.Forms.Panel();
            this.AutoHideManu = new System.Windows.Forms.Panel();
            this.LockPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSessionExit = new ControlLibrary.TAButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.LeftButtonPanel = new ControlLibrary.GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AutoHidePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.MainStatusStrip.SuspendLayout();
            this.MainManuPanel.SuspendLayout();
            this.LockPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LeftButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusCompanyName,
            this.lblStatusBranchName,
            this.lblStatusUserLogin,
            this.lblStatusUserLevel,
            this.lblStatusWorkingForm,
            this.toolStripStatusLabel1,
            this.lblPortStatus,
            this.lblStatusLoginRemainingTime});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 711);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(992, 22);
            this.MainStatusStrip.TabIndex = 5;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // lblStatusCompanyName
            // 
            this.lblStatusCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblStatusCompanyName.Name = "lblStatusCompanyName";
            this.lblStatusCompanyName.Size = new System.Drawing.Size(100, 17);
            this.lblStatusCompanyName.Text = "Company Name: ";
            // 
            // lblStatusBranchName
            // 
            this.lblStatusBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblStatusBranchName.Name = "lblStatusBranchName";
            this.lblStatusBranchName.Size = new System.Drawing.Size(40, 17);
            this.lblStatusBranchName.Text = "Store: ";
            // 
            // lblStatusUserLogin
            // 
            this.lblStatusUserLogin.ForeColor = System.Drawing.Color.Black;
            this.lblStatusUserLogin.Name = "lblStatusUserLogin";
            this.lblStatusUserLogin.Size = new System.Drawing.Size(72, 17);
            this.lblStatusUserLogin.Text = "User Login : ";
            // 
            // lblStatusUserLevel
            // 
            this.lblStatusUserLevel.ForeColor = System.Drawing.Color.Black;
            this.lblStatusUserLevel.Name = "lblStatusUserLevel";
            this.lblStatusUserLevel.Size = new System.Drawing.Size(69, 17);
            this.lblStatusUserLevel.Text = "User Level : ";
            // 
            // lblStatusWorkingForm
            // 
            this.lblStatusWorkingForm.ForeColor = System.Drawing.Color.Black;
            this.lblStatusWorkingForm.Name = "lblStatusWorkingForm";
            this.lblStatusWorkingForm.Size = new System.Drawing.Size(92, 17);
            this.lblStatusWorkingForm.Text = "Working Form : ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusLoginRemainingTime
            // 
            this.lblStatusLoginRemainingTime.BackColor = System.Drawing.Color.Red;
            this.lblStatusLoginRemainingTime.ForeColor = System.Drawing.Color.White;
            this.lblStatusLoginRemainingTime.Name = "lblStatusLoginRemainingTime";
            this.lblStatusLoginRemainingTime.Size = new System.Drawing.Size(73, 17);
            this.lblStatusLoginRemainingTime.Text = "asdfasdfasdf";
            this.lblStatusLoginRemainingTime.Visible = false;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.MainMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.ShowItemToolTips = true;
            this.MainMenuStrip.Size = new System.Drawing.Size(822, 47);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "MainMenuStrip";
            // 
            // MainManuPanel
            // 
            this.MainManuPanel.Controls.Add(this.AutoHideManu);
            this.MainManuPanel.Controls.Add(this.MainMenuStrip);
            this.MainManuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainManuPanel.Location = new System.Drawing.Point(170, 0);
            this.MainManuPanel.Name = "MainManuPanel";
            this.MainManuPanel.Size = new System.Drawing.Size(822, 47);
            this.MainManuPanel.TabIndex = 20;
            // 
            // AutoHideManu
            // 
            this.AutoHideManu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoHideManu.BackColor = System.Drawing.Color.Transparent;
            this.AutoHideManu.BackgroundImage = global::AutoVaultEss.Properties.Resources.AutoHide1;
            this.AutoHideManu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AutoHideManu.Location = new System.Drawing.Point(804, 0);
            this.AutoHideManu.Name = "AutoHideManu";
            this.AutoHideManu.Size = new System.Drawing.Size(15, 15);
            this.AutoHideManu.TabIndex = 1;
            // 
            // LockPanel
            // 
            this.LockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LockPanel.BackColor = System.Drawing.Color.Transparent;
            this.LockPanel.Controls.Add(this.panel2);
            this.LockPanel.Location = new System.Drawing.Point(82, 672);
            this.LockPanel.Name = "LockPanel";
            this.LockPanel.Size = new System.Drawing.Size(141, 36);
            this.LockPanel.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSessionExit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(314, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 118);
            this.panel2.TabIndex = 1;
            // 
            // btnSessionExit
            // 
            this.btnSessionExit.BackColor = System.Drawing.Color.Red;
            this.btnSessionExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSessionExit.ColorFillBlend = cBlendItems2;
            this.btnSessionExit.DesignerSelected = false;
            this.btnSessionExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionExit.ImageIndex = 0;
            this.btnSessionExit.Location = new System.Drawing.Point(239, 70);
            this.btnSessionExit.Name = "btnSessionExit";
            this.btnSessionExit.Size = new System.Drawing.Size(113, 32);
            this.btnSessionExit.TabIndex = 2;
            this.btnSessionExit.Text = "ok";
            this.btnSessionExit.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSessionExit.Click += new System.EventHandler(this.btnSessionExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Session is Expire .....";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 26);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Session is Expire ...........";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LeftButtonPanel
            // 
            this.LeftButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.LeftButtonPanel.ColorBottom = System.Drawing.Color.Empty;
            this.LeftButtonPanel.ColorTop = System.Drawing.Color.Empty;
            this.LeftButtonPanel.Controls.Add(this.pictureBox2);
            this.LeftButtonPanel.Controls.Add(this.lblWelcome);
            this.LeftButtonPanel.Controls.Add(this.lblUserName);
            this.LeftButtonPanel.Controls.Add(this.pictureBox1);
            this.LeftButtonPanel.Controls.Add(this.AutoHidePanel);
            this.LeftButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LeftButtonPanel.Name = "LeftButtonPanel";
            this.LeftButtonPanel.Size = new System.Drawing.Size(170, 711);
            this.LeftButtonPanel.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::AutoVaultEss.Properties.Resources.IIcooN;
            this.pictureBox2.Location = new System.Drawing.Point(3, 369);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(167, 164);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // AutoHidePanel
            // 
            this.AutoHidePanel.BackColor = System.Drawing.Color.Transparent;
            this.AutoHidePanel.BackgroundImage = global::AutoVaultEss.Properties.Resources.AutoHide1;
            this.AutoHidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AutoHidePanel.Location = new System.Drawing.Point(0, 0);
            this.AutoHidePanel.Name = "AutoHidePanel";
            this.AutoHidePanel.Size = new System.Drawing.Size(15, 15);
            this.AutoHidePanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::AutoVaultEss.Properties.Resources.avatar_round_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(40, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 85);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUserName.Font = new System.Drawing.Font("Calibri", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(22, 178);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(117, 33);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "asdfasdf";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Calibri", 19F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(22, 145);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(117, 33);
            this.lblWelcome.TabIndex = 15;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(992, 733);
            this.Controls.Add(this.MainManuPanel);
            this.Controls.Add(this.LeftButtonPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainApplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load_1);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.MainManuPanel.ResumeLayout(false);
            this.MainManuPanel.PerformLayout();
            this.LockPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LeftButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip MainStatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel lblStatusUserLogin;
        public System.Windows.Forms.ToolStripStatusLabel lblStatusUserLevel;
        public System.Windows.Forms.ToolStripStatusLabel lblStatusWorkingForm;
        public System.Windows.Forms.ToolStripStatusLabel lblStatusCompanyName;
        public System.Windows.Forms.ToolStripStatusLabel lblStatusBranchName;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblPortStatus;
        private ControlLibrary.GradientPanel LeftButtonPanel;
        private System.Windows.Forms.Panel MainManuPanel;
        private System.Windows.Forms.Panel AutoHidePanel;
        private System.Windows.Forms.Panel AutoHideManu;
        private System.Windows.Forms.Panel LockPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TAButton btnSessionExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLoginRemainingTime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
