namespace AppControls
{
    partial class ctrSearchWorkOrders
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
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            this.btnCancel = new ControlLibrary.TAButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWorkOrder = new ControlLibrary.TATextBox();
            this.btnWorkOrders = new ControlLibrary.TAButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtInvoiceNo = new ControlLibrary.TATextBox();
            this.btnInvoice = new ControlLibrary.TAButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNegateNo = new ControlLibrary.TATextBox();
            this.btnNegate = new ControlLibrary.TAButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.btnCancel.Location = new System.Drawing.Point(217, 163);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 11659;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtWorkOrder);
            this.panel2.Controls.Add(this.btnWorkOrders);
            this.panel2.Location = new System.Drawing.Point(44, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 91);
            this.panel2.TabIndex = 11661;
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtWorkOrder.Location = new System.Drawing.Point(3, 12);
            this.txtWorkOrder.Margin = new System.Windows.Forms.Padding(0);
            this.txtWorkOrder.MaxLength = 150;
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.Size = new System.Drawing.Size(135, 20);
            this.txtWorkOrder.TabIndex = 11659;
            this.txtWorkOrder.WordWrap = false;
            this.txtWorkOrder.xBindingProperty = "Catalog";
            this.txtWorkOrder.xColumnName = "";
            this.txtWorkOrder.xColumnWidth = 80;
            this.txtWorkOrder.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtWorkOrder.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtWorkOrder.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtWorkOrder.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtWorkOrder.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtWorkOrder.xMasked = System32.StaticInfo.Mask.None;
            this.txtWorkOrder.xReadOnly = false;
            // 
            // btnWorkOrders
            // 
            this.btnWorkOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnWorkOrders.ColorFillBlend = cBlendItems2;
            this.btnWorkOrders.DesignerSelected = false;
            this.btnWorkOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnWorkOrders.ImageIndex = 0;
            this.btnWorkOrders.Location = new System.Drawing.Point(3, 46);
            this.btnWorkOrders.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnWorkOrders.Name = "btnWorkOrders";
            this.btnWorkOrders.Size = new System.Drawing.Size(135, 28);
            this.btnWorkOrders.TabIndex = 11658;
            this.btnWorkOrders.Text = "WorkOrders #";
            this.btnWorkOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWorkOrders.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtInvoiceNo);
            this.panel3.Controls.Add(this.btnInvoice);
            this.panel3.Location = new System.Drawing.Point(187, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 91);
            this.panel3.TabIndex = 11662;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInvoiceNo.Location = new System.Drawing.Point(3, 12);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtInvoiceNo.MaxLength = 150;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(135, 20);
            this.txtInvoiceNo.TabIndex = 11661;
            this.txtInvoiceNo.WordWrap = false;
            this.txtInvoiceNo.xBindingProperty = "Catalog";
            this.txtInvoiceNo.xColumnName = "";
            this.txtInvoiceNo.xColumnWidth = 80;
            this.txtInvoiceNo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtInvoiceNo.xMasked = System32.StaticInfo.Mask.None;
            this.txtInvoiceNo.xReadOnly = false;
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnInvoice.ColorFillBlend = cBlendItems3;
            this.btnInvoice.DesignerSelected = false;
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnInvoice.ImageIndex = 0;
            this.btnInvoice.Location = new System.Drawing.Point(3, 46);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(135, 28);
            this.btnInvoice.TabIndex = 11658;
            this.btnInvoice.Text = "Invoice #";
            this.btnInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoice.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtNegateNo);
            this.panel4.Controls.Add(this.btnNegate);
            this.panel4.Location = new System.Drawing.Point(330, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 91);
            this.panel4.TabIndex = 11663;
            // 
            // txtNegateNo
            // 
            this.txtNegateNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNegateNo.Location = new System.Drawing.Point(3, 12);
            this.txtNegateNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtNegateNo.MaxLength = 150;
            this.txtNegateNo.Name = "txtNegateNo";
            this.txtNegateNo.Size = new System.Drawing.Size(135, 20);
            this.txtNegateNo.TabIndex = 11660;
            this.txtNegateNo.WordWrap = false;
            this.txtNegateNo.xBindingProperty = "Catalog";
            this.txtNegateNo.xColumnName = "";
            this.txtNegateNo.xColumnWidth = 80;
            this.txtNegateNo.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtNegateNo.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtNegateNo.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtNegateNo.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtNegateNo.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtNegateNo.xMasked = System32.StaticInfo.Mask.None;
            this.txtNegateNo.xReadOnly = false;
            // 
            // btnNegate
            // 
            this.btnNegate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnNegate.ColorFillBlend = cBlendItems4;
            this.btnNegate.DesignerSelected = false;
            this.btnNegate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNegate.ImageIndex = 0;
            this.btnNegate.Location = new System.Drawing.Point(3, 46);
            this.btnNegate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnNegate.Name = "btnNegate";
            this.btnNegate.Size = new System.Drawing.Size(135, 28);
            this.btnNegate.TabIndex = 11658;
            this.btnNegate.Text = "Negate #";
            this.btnNegate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNegate.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 11664;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrSearchWorkOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Name = "ctrSearchWorkOrders";
            this.Size = new System.Drawing.Size(522, 215);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlLibrary.TAButton btnCancel;
        private System.Windows.Forms.Panel panel2;
        private ControlLibrary.TAButton btnWorkOrders;
        private System.Windows.Forms.Panel panel3;
        private ControlLibrary.TAButton btnInvoice;
        private System.Windows.Forms.Panel panel4;
        private ControlLibrary.TAButton btnNegate;
        private ControlLibrary.TATextBox txtInvoiceNo;
        private ControlLibrary.TATextBox txtNegateNo;
        private ControlLibrary.TATextBox txtWorkOrder;
        private System.Windows.Forms.Label label1;
    }
}
