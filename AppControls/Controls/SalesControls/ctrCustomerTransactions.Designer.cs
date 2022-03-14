namespace AppControls
{
    partial class ctrCustomerTransactions
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
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGVCustomerList = new ControlLibrary.TAZSearchDataGridView();
            this.DGVWorkOrderList = new ControlLibrary.TAZSearchDataGridView();
            this.btnVoidPayment = new ControlLibrary.TAButton();
            this.WorkingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.tableLayoutPanel1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(1037, 535);
            this.WorkingPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.DGVCustomerList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVWorkOrderList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnVoidPayment, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 535);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 510);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1037, 25);
            this.panel3.TabIndex = 8;
            // 
            // DGVCustomerList
            // 
            this.DGVCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCustomerList.Location = new System.Drawing.Point(0, 25);
            this.DGVCustomerList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVCustomerList.Name = "DGVCustomerList";
            this.DGVCustomerList.Size = new System.Drawing.Size(1037, 230);
            this.DGVCustomerList.TabIndex = 3;
            // 
            // DGVWorkOrderList
            // 
            this.DGVWorkOrderList.BackColor = System.Drawing.SystemColors.Control;
            this.DGVWorkOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVWorkOrderList.Location = new System.Drawing.Point(0, 280);
            this.DGVWorkOrderList.Margin = new System.Windows.Forms.Padding(0);
            this.DGVWorkOrderList.Name = "DGVWorkOrderList";
            this.DGVWorkOrderList.Size = new System.Drawing.Size(1037, 230);
            this.DGVWorkOrderList.TabIndex = 4;
            // 
            // btnVoidPayment
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnVoidPayment.ColorFillBlend = cBlendItems1;
            this.btnVoidPayment.DesignerSelected = false;
            this.btnVoidPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVoidPayment.ImageIndex = 0;
            this.btnVoidPayment.Location = new System.Drawing.Point(3, 258);
            this.btnVoidPayment.Name = "btnVoidPayment";
            this.btnVoidPayment.Size = new System.Drawing.Size(115, 19);
            this.btnVoidPayment.TabIndex = 11662;
            this.btnVoidPayment.Text = "Void Payment";
            this.btnVoidPayment.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // ctrCustomerTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ctrCustomerTransactions";
            this.Size = new System.Drawing.Size(1037, 535);
            this.WorkingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel WorkingPanel;
        public ControlLibrary.TAZSearchDataGridView DGVCustomerList;
        public ControlLibrary.TAZSearchDataGridView DGVWorkOrderList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private ControlLibrary.TAButton btnVoidPayment;
    }
}
