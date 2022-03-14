namespace QBSync
{
    partial class frmSyncDate
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.errPrvdr = new System.Windows.Forms.ErrorProvider(this.components);
            this.grdSyncLog = new System.Windows.Forms.DataGridView();
            this.colConfigKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfigValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnReset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSyncLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(281, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(362, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BackgroundImage = global::QBSync.Properties.Resources.bg_top;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 35);
            this.panel2.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sync Date Log";
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "Miracle Services";
            // 
            // dlgBrowse
            // 
            this.dlgBrowse.FileName = "QuickBooks Data File";
            // 
            // errPrvdr
            // 
            this.errPrvdr.ContainerControl = this;
            // 
            // grdSyncLog
            // 
            this.grdSyncLog.AllowUserToAddRows = false;
            this.grdSyncLog.AllowUserToDeleteRows = false;
            this.grdSyncLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSyncLog.BackgroundColor = System.Drawing.Color.White;
            this.grdSyncLog.ColumnHeadersHeight = 25;
            this.grdSyncLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConfigKey,
            this.colConfigValue,
            this.colBtnReset});
            this.grdSyncLog.Location = new System.Drawing.Point(12, 56);
            this.grdSyncLog.Name = "grdSyncLog";
            this.grdSyncLog.RowHeadersWidth = 20;
            this.grdSyncLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSyncLog.Size = new System.Drawing.Size(425, 215);
            this.grdSyncLog.TabIndex = 35;
            this.grdSyncLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSyncLog_CellContentClick);
            // 
            // colConfigKey
            // 
            this.colConfigKey.DataPropertyName = "Config_key";
            this.colConfigKey.HeaderText = "Syncing Object";
            this.colConfigKey.Name = "colConfigKey";
            this.colConfigKey.ReadOnly = true;
            this.colConfigKey.Width = 150;
            // 
            // colConfigValue
            // 
            this.colConfigValue.DataPropertyName = "Config_value";
            this.colConfigValue.HeaderText = "Last Sync Date";
            this.colConfigValue.Name = "colConfigValue";
            this.colConfigValue.ReadOnly = true;
            this.colConfigValue.Width = 150;
            // 
            // colBtnReset
            // 
            this.colBtnReset.HeaderText = "Action";
            this.colBtnReset.Name = "colBtnReset";
            this.colBtnReset.Text = "Reset";
            this.colBtnReset.ToolTipText = "Reset Sync Date";
            this.colBtnReset.UseColumnTextForButtonValue = true;
            this.colBtnReset.Width = 80;
            // 
            // frmSyncDate
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 312);
            this.Controls.Add(this.grdSyncLog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSyncDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync Date Log";
            this.Load += new System.EventHandler(this.frmSyncDate_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSyncLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.OpenFileDialog dlgBrowse;
        private System.Windows.Forms.ErrorProvider errPrvdr;
        private System.Windows.Forms.DataGridView grdSyncLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfigKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfigValue;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnReset;
    }
}