namespace ControlLibrary
{
    partial class DashBoardButton
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
            this.lblHeading1 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Pic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading1
            // 
            this.lblHeading1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeading1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblHeading1.Location = new System.Drawing.Point(35, 0);
            this.lblHeading1.Name = "lblHeading1";
            this.lblHeading1.Size = new System.Drawing.Size(100, 32);
            this.lblHeading1.TabIndex = 3;
            this.lblHeading1.TabStop = true;
            this.lblHeading1.Text = "CREATE    NEW      INQUIRY";
            this.lblHeading1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeading1.Click += new System.EventHandler(this.Pic_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.18841F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.81159F));
            this.tableLayoutPanel1.Controls.Add(this.Pic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHeading1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(138, 32);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Pic
            //             
            this.Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pic.Location = new System.Drawing.Point(3, 3);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(26, 26);
            this.Pic.TabIndex = 0;
            this.Pic.TabStop = false;
            this.Pic.Click += new System.EventHandler(this.Pic_Click);
            // 
            // DashBoardButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DashBoardButton";
            this.Size = new System.Drawing.Size(138, 32);
            this.Load += new System.EventHandler(this.DashBoardButton_Load);
            this.Click += new System.EventHandler(this.Pic_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public System.Windows.Forms.PictureBox Pic;
        public System.Windows.Forms.LinkLabel lblHeading1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
