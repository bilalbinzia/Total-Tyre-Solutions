﻿namespace AppControls
{
    partial class ctrAccountList
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
            this.WorkingPanel = new System.Windows.Forms.Panel();
            this.searchDataGridView1 = new ControlLibrary.TAZSearchDataGridView();
            this.chkboxViewAll = new System.Windows.Forms.CheckBox();
            this.WorkingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkingPanel
            // 
            this.WorkingPanel.Controls.Add(this.chkboxViewAll);
            this.WorkingPanel.Controls.Add(this.searchDataGridView1);
            this.WorkingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingPanel.Location = new System.Drawing.Point(0, 0);
            this.WorkingPanel.Name = "WorkingPanel";
            this.WorkingPanel.Size = new System.Drawing.Size(719, 354);
            this.WorkingPanel.TabIndex = 1;
            // 
            // searchDataGridView1
            // 
            this.searchDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchDataGridView1.Name = "searchDataGridView1";
            this.searchDataGridView1.Size = new System.Drawing.Size(719, 354);
            this.searchDataGridView1.TabIndex = 0;
            // 
            // chkboxViewAll
            // 
            this.chkboxViewAll.AutoSize = true;
            this.chkboxViewAll.Location = new System.Drawing.Point(648, 7);
            this.chkboxViewAll.Name = "chkboxViewAll";
            this.chkboxViewAll.Size = new System.Drawing.Size(63, 17);
            this.chkboxViewAll.TabIndex = 1;
            this.chkboxViewAll.Text = "View All";
            this.chkboxViewAll.UseVisualStyleBackColor = true;
            // 
            // ctrAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WorkingPanel);
            this.Name = "ctrAccountList";
            this.Size = new System.Drawing.Size(719, 354);
            this.WorkingPanel.ResumeLayout(false);
            this.WorkingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkingPanel;
        private ControlLibrary.TAZSearchDataGridView searchDataGridView1;
        private System.Windows.Forms.CheckBox chkboxViewAll;

        
    }
}
