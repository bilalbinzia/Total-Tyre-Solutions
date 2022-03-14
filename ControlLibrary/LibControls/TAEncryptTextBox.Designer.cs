using System32;
namespace ControlLibrary
{
    partial class TAEncryptTextBox
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
            this.TxtBox = new ControlLibrary.TATextBox();
            this.taTextBox1 = new ControlLibrary.TATextBox();
            this.SuspendLayout();
            // 
            // TxtBox
            // 
            this.TxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBox.Location = new System.Drawing.Point(0, 0);
            this.TxtBox.Name = "TxtBox";
            this.TxtBox.Size = new System.Drawing.Size(100, 20);
            this.TxtBox.TabIndex = 0;
            this.TxtBox.xBindingProperty = null;
            this.TxtBox.xColumnName = null;
            this.TxtBox.xColumnWidth = 60;
            this.TxtBox.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.TxtBox.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.TxtBox.xIsRequired = System32.StaticInfo.YesNo.No;
            this.TxtBox.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.TxtBox.xMasked = System32.StaticInfo.Mask.None;
            // 
            // taTextBox1
            // 
            this.taTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taTextBox1.Location = new System.Drawing.Point(0, 0);
            this.taTextBox1.Name = "taTextBox1";
            this.taTextBox1.Size = new System.Drawing.Size(100, 20);
            this.taTextBox1.TabIndex = 1;
            this.taTextBox1.xBindingProperty = null;
            this.taTextBox1.xColumnName = null;
            this.taTextBox1.xColumnWidth = 60;
            this.taTextBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taTextBox1.xMasked = System32.StaticInfo.Mask.None;
            // 
            // TAEncryptTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.taTextBox1);
            this.Controls.Add(this.TxtBox);
            this.Name = "TAEncryptTextBox";
            this.Size = new System.Drawing.Size(100, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TATextBox taTextBox1;
        public TATextBox TxtBox;
    }
}
