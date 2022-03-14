namespace ControlLibrary
{
    partial class TAPictureBoxControl
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
            this.grpBoxPicture = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new ControlLibrary.TAButton();
            this.btn_Load = new ControlLibrary.TAButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imagePictureBox = new ControlLibrary.TAPictureBox();
            this.grpBoxPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxPicture
            // 
            this.grpBoxPicture.Controls.Add(this.splitContainer1);
            this.grpBoxPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxPicture.Location = new System.Drawing.Point(0, 0);
            this.grpBoxPicture.Name = "grpBoxPicture";
            this.grpBoxPicture.Size = new System.Drawing.Size(130, 170);
            this.grpBoxPicture.TabIndex = 11387;
            this.grpBoxPicture.TabStop = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(65)))), ((int)(((byte)(125)))));
            this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(67, 2);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(49, 23);
            this.btn_Clear.TabIndex = 12;
            this.btn_Clear.Text = "Clear";
            
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(65)))), ((int)(((byte)(125)))));
            this.btn_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Load.ForeColor = System.Drawing.Color.White;
            this.btn_Load.Location = new System.Drawing.Point(11, 2);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(49, 23);
            this.btn_Load.TabIndex = 11;
            this.btn_Load.Text = "Load";
            
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imagePictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Load);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Clear);
            this.splitContainer1.Size = new System.Drawing.Size(124, 151);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 148;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePictureBox.Location = new System.Drawing.Point(0, 0);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(124, 122);
            this.imagePictureBox.TabIndex = 147;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.ToolTipText = null;
            this.imagePictureBox.xBindingProperty = "Image";
            this.imagePictureBox.xDisplayMember = null;
            this.imagePictureBox.xIsRequired = System32.StaticInfo.YesNo.No;
            this.imagePictureBox.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.imagePictureBox.xTableName = null;
            this.imagePictureBox.xValueMember = null;
            // 
            // TAPictureBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxPicture);
            this.Name = "TAPictureBoxControl";
            this.Size = new System.Drawing.Size(130, 170);
            this.grpBoxPicture.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox grpBoxPicture;
        protected TAButton btn_Clear;
        protected TAButton btn_Load;
        public TAPictureBox imagePictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
