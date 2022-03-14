namespace SystemUpdation
{
    partial class Form1
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
            
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);

            progressBar1 = new System.Windows.Forms.ProgressBar();
            progressBar2 = new System.Windows.Forms.ProgressBar();
            progressBar3 = new System.Windows.Forms.ProgressBar();
            progressBar4 = new System.Windows.Forms.ProgressBar();

            lblProcess1 = new System.Windows.Forms.Label();
            lblProcess2 = new System.Windows.Forms.Label();            
            lblProcess3 = new System.Windows.Forms.Label();            
            lblProcess4 = new System.Windows.Forms.Label();
            
            lblProcess11 = new System.Windows.Forms.Label();
            lblProcess12 = new System.Windows.Forms.Label();
            lblProcess13 = new System.Windows.Forms.Label();
            lblProcess14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(15, 24);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(309, 23);
            progressBar1.Step = 1;
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 0;
            // 
            // lblProcess1
            // 
            lblProcess1.AutoSize = true;
            lblProcess1.Location = new System.Drawing.Point(15, 7);
            lblProcess1.Name = "lblProcess1";
            lblProcess1.Size = new System.Drawing.Size(66, 13);
            lblProcess1.TabIndex = 1;
            lblProcess1.Text = "Process - 01";
            // 
            // lblProcess2
            // 
            lblProcess2.AutoSize = true;
            lblProcess2.Location = new System.Drawing.Point(15, 51);
            lblProcess2.Name = "lblProcess2";
            lblProcess2.Size = new System.Drawing.Size(66, 13);
            lblProcess2.TabIndex = 3;
            lblProcess2.Text = "Process - 02";
            // 
            // progressBar2
            // 
            progressBar2.Location = new System.Drawing.Point(15, 68);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new System.Drawing.Size(309, 23);
            progressBar2.Step = 1;
            progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar2.TabIndex = 2;
            // 
            // progressBar3
            // 
            progressBar3.Location = new System.Drawing.Point(15, 112);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new System.Drawing.Size(309, 23);
            progressBar3.Step = 1;
            progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar3.TabIndex = 0;
            // 
            // lblProcess3
            // 
            lblProcess3.AutoSize = true;
            lblProcess3.Location = new System.Drawing.Point(15, 95);
            lblProcess3.Name = "lblProcess3";
            lblProcess3.Size = new System.Drawing.Size(66, 13);
            lblProcess3.TabIndex = 1;
            lblProcess3.Text = "Process - 03";
            // 
            // progressBar4
            // 
            progressBar4.Location = new System.Drawing.Point(15, 156);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new System.Drawing.Size(309, 23);
            progressBar4.Step = 1;
            progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar4.TabIndex = 2;
            // 
            // lblProcess4
            // 
            lblProcess4.AutoSize = true;
            lblProcess4.Location = new System.Drawing.Point(15, 139);
            lblProcess4.Name = "lblProcess4";
            lblProcess4.Size = new System.Drawing.Size(66, 13);
            lblProcess4.TabIndex = 3;
            lblProcess4.Text = "Process - 04";
            // 
            // lblProcess11
            // 
            lblProcess11.AutoSize = true;
            lblProcess11.BackColor = System.Drawing.Color.Transparent;
            lblProcess11.Location = new System.Drawing.Point(193, 7);
            lblProcess11.Name = "lblProcess11";
            lblProcess11.Size = new System.Drawing.Size(131, 13);
            lblProcess11.TabIndex = 4;
            lblProcess11.Text = "Process - 01 Completed ...";
            lblProcess11.Visible = false;
            // 
            // lblProcess12
            // 
            lblProcess12.AutoSize = true;
            lblProcess12.BackColor = System.Drawing.Color.Transparent;
            lblProcess12.Location = new System.Drawing.Point(193, 51);
            lblProcess12.Name = "lblProcess12";
            lblProcess12.Size = new System.Drawing.Size(131, 13);
            lblProcess12.TabIndex = 5;
            lblProcess12.Text = "Process - 01 Completed ...";
            lblProcess12.Visible = false;
            // 
            // lblProcess13
            // 
            lblProcess13.AutoSize = true;
            lblProcess13.BackColor = System.Drawing.Color.Transparent;
            lblProcess13.Location = new System.Drawing.Point(193, 95);
            lblProcess13.Name = "lblProcess13";
            lblProcess13.Size = new System.Drawing.Size(131, 13);
            lblProcess13.TabIndex = 6;
            lblProcess13.Text = "Process - 01 Completed ...";
            lblProcess13.Visible = false;
            // 
            // lblProcess14
            // 
            lblProcess14.AutoSize = true;
            lblProcess14.BackColor = System.Drawing.Color.Transparent;
            lblProcess14.Location = new System.Drawing.Point(193, 139);
            lblProcess14.Name = "lblProcess14";
            lblProcess14.Size = new System.Drawing.Size(131, 13);
            lblProcess14.TabIndex = 7;
            lblProcess14.Text = "Process - 01 Completed ...";
            lblProcess14.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 191);
            this.Controls.Add(lblProcess14);
            this.Controls.Add(lblProcess13);
            this.Controls.Add(lblProcess12);
            this.Controls.Add(lblProcess11);
            this.Controls.Add(lblProcess4);
            this.Controls.Add(lblProcess2);
            this.Controls.Add(progressBar4);
            this.Controls.Add(lblProcess3);
            this.Controls.Add(progressBar2);
            this.Controls.Add(progressBar3);
            this.Controls.Add(lblProcess1);
            this.Controls.Add(progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Updation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;

        private static System.Windows.Forms.ProgressBar progressBar1;
        private static System.Windows.Forms.ProgressBar progressBar2;
        private static System.Windows.Forms.ProgressBar progressBar3;
        private static System.Windows.Forms.ProgressBar progressBar4;

        private static System.Windows.Forms.Label lblProcess1;
        private static System.Windows.Forms.Label lblProcess2;
        private static System.Windows.Forms.Label lblProcess3;
        private static System.Windows.Forms.Label lblProcess4;        

        private static System.Windows.Forms.Label lblProcess11;
        private static System.Windows.Forms.Label lblProcess12;
        private static System.Windows.Forms.Label lblProcess13;
        private static System.Windows.Forms.Label lblProcess14;
    }
}

