namespace AppControls
{
    partial class ctrBrowseInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel1 = new ControlLibrary.GradientPanel();
            this.lblSaleID = new System.Windows.Forms.Label();
            this.btnPreview = new ControlLibrary.TAButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetails = new ControlLibrary.TAButton();
            this.DGVSaleList = new ControlLibrary.libDataGridView();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleList)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.Empty;
            this.gradientPanel1.ColorTop = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.lblSaleID);
            this.gradientPanel1.Controls.Add(this.btnPreview);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.btnDetails);
            this.gradientPanel1.Controls.Add(this.DGVSaleList);
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(608, 403);
            this.gradientPanel1.TabIndex = 0;
            // 
            // lblSaleID
            // 
            this.lblSaleID.AutoSize = true;
            this.lblSaleID.Location = new System.Drawing.Point(224, 12);
            this.lblSaleID.Name = "lblSaleID";
            this.lblSaleID.Size = new System.Drawing.Size(19, 13);
            this.lblSaleID.TabIndex = 11673;
            this.lblSaleID.Text = "28";
            // 
            // btnPreview
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnPreview.ColorFillBlend = cBlendItems1;
            this.btnPreview.DesignerSelected = false;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPreview.ImageIndex = 0;
            this.btnPreview.Location = new System.Drawing.Point(365, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 11672;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 11670;
            this.label2.Text = "Invoices from Daily Report #";
            // 
            // btnDetails
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnDetails.ColorFillBlend = cBlendItems2;
            this.btnDetails.DesignerSelected = false;
            this.btnDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDetails.ImageIndex = 0;
            this.btnDetails.Location = new System.Drawing.Point(286, 7);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 11671;
            this.btnDetails.Text = "Details";
            this.btnDetails.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // DGVSaleList
            // 
            this.DGVSaleList.AllowUserToDeleteRows = false;
            this.DGVSaleList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DGVSaleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSaleList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSaleList.Location = new System.Drawing.Point(16, 36);
            this.DGVSaleList.Name = "DGVSaleList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSaleList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSaleList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.DGVSaleList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSaleList.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.DGVSaleList.ShowRowErrors = false;
            this.DGVSaleList.Size = new System.Drawing.Size(572, 352);
            this.DGVSaleList.TabIndex = 0;
            this.DGVSaleList.VirtualMode = true;
            this.DGVSaleList.xIsAutoNo = true;
            this.DGVSaleList.xIsDeleteColumn = true;
            this.DGVSaleList.xOrderBy = null;
            this.DGVSaleList.xTableName = null;
            this.DGVSaleList.xTableQuery = null;
            this.DGVSaleList.xTableRelation = null;
            this.DGVSaleList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DGVSaleList_RowPrePaint);
            // 
            // ctrBrowseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gradientPanel1);
            this.Name = "ctrBrowseInvoice";
            this.Size = new System.Drawing.Size(611, 406);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlLibrary.libDataGridView DGVSaleList;
        private ControlLibrary.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label lblSaleID;
        private ControlLibrary.TAButton btnPreview;
        private System.Windows.Forms.Label label2;
        private ControlLibrary.TAButton btnDetails;
    }
}
