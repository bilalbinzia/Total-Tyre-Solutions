namespace AppControls
{
    partial class ctrClaimCredit
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
            this.components = new System.ComponentModel.Container();
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.txtVendorReferenceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new CButtonLib.CButton();
            this.btnSave = new CButtonLib.CButton();
            this.ClaimDate = new ControlLibrary.TADateControl();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVendor
            // 
            this.txtVendor.Enabled = false;
            this.txtVendor.Location = new System.Drawing.Point(113, 37);
            this.txtVendor.MaxLength = 20;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(312, 20);
            this.txtVendor.TabIndex = 11466;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 11455;
            this.label8.Text = "Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 11454;
            this.label10.Text = "Vendor:";
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.txtVendorReferenceNo);
            this.WorkingPanel.Controls.Add(this.label1);
            this.WorkingPanel.Controls.Add(this.btnCancel);
            this.WorkingPanel.Controls.Add(this.btnSave);
            this.WorkingPanel.Controls.Add(this.txtVendor);
            this.WorkingPanel.Controls.Add(this.label8);
            this.WorkingPanel.Controls.Add(this.label10);
            this.WorkingPanel.Controls.Add(this.ClaimDate);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(440, 128);
            this.WorkingPanel.TabIndex = 0;
            // 
            // txtVendorReferenceNo
            // 
            this.txtVendorReferenceNo.Location = new System.Drawing.Point(113, 61);
            this.txtVendorReferenceNo.MaxLength = 20;
            this.txtVendorReferenceNo.Name = "txtVendorReferenceNo";
            this.txtVendorReferenceNo.Size = new System.Drawing.Size(163, 20);
            this.txtVendorReferenceNo.TabIndex = 11670;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11669;
            this.label1.Text = "Vendor Reference";
            // 
            // btnCancel
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCancel.ColorFillBlend = cBlendItems1;
            this.btnCancel.DesignerSelected = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(233, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 11668;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnSave
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSave.ColorFillBlend = cBlendItems2;
            this.btnSave.DesignerSelected = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ImageIndex = 0;
            this.btnSave.Location = new System.Drawing.Point(113, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 11667;
            this.btnSave.Text = "Create Credit";
            this.btnSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ClaimDate
            // 
            this.ClaimDate.Location = new System.Drawing.Point(113, 15);
            this.ClaimDate.Margin = new System.Windows.Forms.Padding(0);
            this.ClaimDate.Name = "ClaimDate";
            this.ClaimDate.Size = new System.Drawing.Size(99, 20);
            this.ClaimDate.TabIndex = 11453;
            this.ClaimDate.xBindingProperty = "PRDate";
            this.ClaimDate.xColumnName = "";
            this.ClaimDate.xColumnWidth = 60;
            this.ClaimDate.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsRequired = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowCurrentDate = System32.StaticInfo.YesNo.Yes;
            this.ClaimDate.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // ctrClaimCredit
            // 
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrClaimCredit";
            this.Size = new System.Drawing.Size(440, 128);
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        protected ControlLibrary.TADateControl ClaimDate;
        private System.Windows.Forms.Panel WorkingPanel;
        private System.Windows.Forms.TextBox txtVendorReferenceNo;
        private System.Windows.Forms.Label label1;
        private CButtonLib.CButton btnCancel;
        private CButtonLib.CButton btnSave;

        
        
    }
}
