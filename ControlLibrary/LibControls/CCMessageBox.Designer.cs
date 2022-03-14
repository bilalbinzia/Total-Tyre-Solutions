namespace ControlLibrary
{
    partial class CCMessageBox
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
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            this.lblMessage = new System.Windows.Forms.Label();
            this.picBoxIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn1 = new CButtonLib.CButton();
            this.btn2 = new CButtonLib.CButton();
            this.gradientPanel1 = new ControlLibrary.GradientPanel();
            this.taButton1 = new ControlLibrary.TAButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new ControlLibrary.TAButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(32, 45);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(242, 32);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "label1";
            // 
            // picBoxIcon
            // 
            this.picBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.picBoxIcon.Location = new System.Drawing.Point(1, 31);
            this.picBoxIcon.Name = "picBoxIcon";
            this.picBoxIcon.Size = new System.Drawing.Size(27, 27);
            this.picBoxIcon.TabIndex = 3;
            this.picBoxIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Controls.Add(this.gradientPanel1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.picBoxIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 119);
            this.panel1.TabIndex = 23;
            // 
            // btn1
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btn1.ColorFillBlend = cBlendItems1;
            this.btn1.DesignerSelected = false;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn1.ImageIndex = 0;
            this.btn1.Location = new System.Drawing.Point(194, 83);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 25);
            this.btn1.TabIndex = 11662;
            this.btn1.Text = "OK";
            this.btn1.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btn2.ColorFillBlend = cBlendItems2;
            this.btn2.DesignerSelected = false;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn2.ImageIndex = 0;
            this.btn2.Location = new System.Drawing.Point(113, 83);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 25);
            this.btn2.TabIndex = 11661;
            this.btn2.Text = "Yes";
            this.btn2.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gradientPanel1.Controls.Add(this.taButton1);
            this.gradientPanel1.Controls.Add(this.lblTitle);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(287, 29);
            this.gradientPanel1.TabIndex = 23;
            // 
            // taButton1
            // 
            this.taButton1.BackColor = System.Drawing.Color.Transparent;
            this.taButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.taButton1.ColorFillBlend = cBlendItems3;
            this.taButton1.DesignerSelected = false;
            this.taButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.taButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.taButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taButton1.ImageIndex = 0;
            this.taButton1.Location = new System.Drawing.Point(261, 0);
            this.taButton1.Margin = new System.Windows.Forms.Padding(0);
            this.taButton1.Name = "taButton1";
            this.taButton1.Size = new System.Drawing.Size(26, 29);
            this.taButton1.TabIndex = 21;
            this.taButton1.Text = "x";
            this.taButton1.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 22);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClose.ColorFillBlend = cBlendItems4;
            this.btnClose.DesignerSelected = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageIndex = 0;
            this.btnClose.Location = new System.Drawing.Point(261, -2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 22);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "x";
            this.btnClose.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // CCMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 119);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CCMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CCMessageBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CCMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox picBoxIcon;
        private System.Windows.Forms.Label lblTitle;
        private TAButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private GradientPanel gradientPanel1;
        private TAButton taButton1;
        private CButtonLib.CButton btn2;
        private CButtonLib.CButton btn1;
        
    }
}