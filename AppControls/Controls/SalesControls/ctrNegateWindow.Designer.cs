namespace AppControls
{
    partial class ctrNegateWindow
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
            this.btnCancel = new ControlLibrary.TAButton();
            this.btnNegateAndCopyInvoice = new ControlLibrary.TAButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNegateInvoice = new ControlLibrary.TAButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopyInvoiceUsingCurrentPrices = new ControlLibrary.TAButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyInvoiceWithOriginalPrices = new ControlLibrary.TAButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnCancel.Location = new System.Drawing.Point(260, 185);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 11659;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnNegateAndCopyInvoice
            // 
            this.btnNegateAndCopyInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNegateAndCopyInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnNegateAndCopyInvoice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnNegateAndCopyInvoice.Name = "btnNegateAndCopyInvoice";
            this.btnNegateAndCopyInvoice.Size = new System.Drawing.Size(135, 48);
            this.btnNegateAndCopyInvoice.TabIndex = 11658;
            this.btnNegateAndCopyInvoice.Text = "Negate and Copy Invoice";
            this.btnNegateAndCopyInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNegateAndCopyInvoice);
            this.panel1.Location = new System.Drawing.Point(15, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 151);
            this.panel1.TabIndex = 11660;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 84);
            this.label1.TabIndex = 11659;
            this.label1.Text = "Use this to change an existing invoice. It will negate an invoice, and then make " +
    "a copy in a Workorder that you can change.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnNegateInvoice);
            this.panel2.Location = new System.Drawing.Point(158, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 151);
            this.panel2.TabIndex = 11661;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 84);
            this.label2.TabIndex = 11659;
            this.label2.Text = "This will create a Wolorder which is the same as the selected invoice, but with n" +
    "egative quantities.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNegateInvoice
            // 
            this.btnNegateInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNegateInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnNegateInvoice.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnNegateInvoice.Name = "btnNegateInvoice";
            this.btnNegateInvoice.Size = new System.Drawing.Size(135, 48);
            this.btnNegateInvoice.TabIndex = 11658;
            this.btnNegateInvoice.Text = "Negate Invoice";
            this.btnNegateInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnCopyInvoiceUsingCurrentPrices);
            this.panel3.Location = new System.Drawing.Point(301, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 151);
            this.panel3.TabIndex = 11662;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 84);
            this.label3.TabIndex = 11659;
            this.label3.Text = "This will create a Workorder which duplicates the data of the selected Invoice, u" +
    "sing current prices.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopyInvoiceUsingCurrentPrices
            // 
            this.btnCopyInvoiceUsingCurrentPrices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyInvoiceUsingCurrentPrices.Location = new System.Drawing.Point(3, 3);
            this.btnCopyInvoiceUsingCurrentPrices.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCopyInvoiceUsingCurrentPrices.Name = "btnCopyInvoiceUsingCurrentPrices";
            this.btnCopyInvoiceUsingCurrentPrices.Size = new System.Drawing.Size(135, 48);
            this.btnCopyInvoiceUsingCurrentPrices.TabIndex = 11658;
            this.btnCopyInvoiceUsingCurrentPrices.Text = "Copy Invoice Using Current Pricess";
            this.btnCopyInvoiceUsingCurrentPrices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnCopyInvoiceWithOriginalPrices);
            this.panel4.Location = new System.Drawing.Point(444, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 151);
            this.panel4.TabIndex = 11663;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 84);
            this.label4.TabIndex = 11659;
            this.label4.Text = "This will create a Workorder which duplicates the data of the selected Invoice, u" +
    "sing the same prices as the original Invoice.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopyInvoiceWithOriginalPrices
            // 
            this.btnCopyInvoiceWithOriginalPrices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyInvoiceWithOriginalPrices.Location = new System.Drawing.Point(3, 3);
            this.btnCopyInvoiceWithOriginalPrices.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCopyInvoiceWithOriginalPrices.Name = "btnCopyInvoiceWithOriginalPrices";
            this.btnCopyInvoiceWithOriginalPrices.Size = new System.Drawing.Size(135, 48);
            this.btnCopyInvoiceWithOriginalPrices.TabIndex = 11658;
            this.btnCopyInvoiceWithOriginalPrices.Text = "Copy Invoice With Original Prices";
            this.btnCopyInvoiceWithOriginalPrices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(256, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 11664;
            this.label5.Text = "Select One";
            // 
            // ctrNegateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Name = "ctrNegateWindow";
            this.Size = new System.Drawing.Size(600, 237);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLibrary.TAButton btnNegateAndCopyInvoice;
        private ControlLibrary.TAButton btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private ControlLibrary.TAButton btnNegateInvoice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private ControlLibrary.TAButton btnCopyInvoiceUsingCurrentPrices;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private ControlLibrary.TAButton btnCopyInvoiceWithOriginalPrices;
        private System.Windows.Forms.Label label5;
    }
}
