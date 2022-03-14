namespace QBSync
{
    partial class frmSettings
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
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems2 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems4 = new CButtonLib.cBlendItems();
            CButtonLib.cBlendItems cBlendItems3 = new CButtonLib.cBlendItems();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTest = new CButtonLib.CButton();
            this.btnBrowseQBFile = new CButtonLib.CButton();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAutoRunMin = new System.Windows.Forms.TextBox();
            this.errPrvdr = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpSyncStartDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLastSyncDates = new System.Windows.Forms.Button();
            this.btnSave = new CButtonLib.CButton();
            this.btnCancel = new CButtonLib.CButton();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvdr)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Controls.Add(this.txtPath);
            this.groupBox3.Location = new System.Drawing.Point(47, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 51);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Base Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Path:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(460, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 42;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(73, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(381, 22);
            this.txtPath.TabIndex = 41;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "Miracle Services";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTest);
            this.groupBox4.Controls.Add(this.btnBrowseQBFile);
            this.groupBox4.Controls.Add(this.txtFilePath);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(24, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(601, 40);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "QuickBooks File Path";
            // 
            // btnTest
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnTest.ColorFillBlend = cBlendItems1;
            this.btnTest.DesignerSelected = false;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnTest.ImageIndex = 0;
            this.btnTest.Location = new System.Drawing.Point(505, 11);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(84, 24);
            this.btnTest.TabIndex = 11720;
            this.btnTest.Text = "Test";
            this.btnTest.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnBrowseQBFile
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnBrowseQBFile.ColorFillBlend = cBlendItems2;
            this.btnBrowseQBFile.DesignerSelected = false;
            this.btnBrowseQBFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBrowseQBFile.ImageIndex = 0;
            this.btnBrowseQBFile.Location = new System.Drawing.Point(467, 11);
            this.btnBrowseQBFile.Name = "btnBrowseQBFile";
            this.btnBrowseQBFile.Size = new System.Drawing.Size(33, 24);
            this.btnBrowseQBFile.TabIndex = 11720;
            this.btnBrowseQBFile.Text = "...";
            this.btnBrowseQBFile.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(73, 13);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(388, 22);
            this.txtFilePath.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "File";
            // 
            // dlgBrowse
            // 
            this.dlgBrowse.FileName = "QuickBooks Data File";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "min(s)";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Auto Run after every";
            this.label10.Visible = false;
            // 
            // txtAutoRunMin
            // 
            this.txtAutoRunMin.Location = new System.Drawing.Point(150, 113);
            this.txtAutoRunMin.Name = "txtAutoRunMin";
            this.txtAutoRunMin.Size = new System.Drawing.Size(57, 22);
            this.txtAutoRunMin.TabIndex = 42;
            this.txtAutoRunMin.Text = "10";
            this.txtAutoRunMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutoRunMin.Visible = false;
            this.txtAutoRunMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoRunMin_KeyPress);
            // 
            // errPrvdr
            // 
            this.errPrvdr.ContainerControl = this;
            // 
            // dtpSyncStartDate
            // 
            this.dtpSyncStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSyncStartDate.Location = new System.Drawing.Point(150, 83);
            this.dtpSyncStartDate.Name = "dtpSyncStartDate";
            this.dtpSyncStartDate.Size = new System.Drawing.Size(171, 22);
            this.dtpSyncStartDate.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "Sync Start Date";
            // 
            // btnLastSyncDates
            // 
            this.btnLastSyncDates.Location = new System.Drawing.Point(24, 147);
            this.btnLastSyncDates.Name = "btnLastSyncDates";
            this.btnLastSyncDates.Size = new System.Drawing.Size(122, 23);
            this.btnLastSyncDates.TabIndex = 51;
            this.btnLastSyncDates.Text = "Last Sync Dates";
            this.btnLastSyncDates.UseVisualStyleBackColor = true;
            this.btnLastSyncDates.Visible = false;
            this.btnLastSyncDates.Click += new System.EventHandler(this.btnLastSyncDates_Click);
            // 
            // btnSave
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnSave.ColorFillBlend = cBlendItems4;
            this.btnSave.DesignerSelected = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ImageIndex = 0;
            this.btnSave.Location = new System.Drawing.Point(447, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 24);
            this.btnSave.TabIndex = 11720;
            this.btnSave.Text = "Save";
            this.btnSave.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // btnCancel
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnCancel.ColorFillBlend = cBlendItems3;
            this.btnCancel.DesignerSelected = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(541, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 11720;
            this.btnCancel.Text = "Close";
            this.btnCancel.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLastSyncDates);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpSyncStartDate);
            this.Controls.Add(this.txtAutoRunMin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPrvdr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog dlgBrowse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAutoRunMin;
        private System.Windows.Forms.ErrorProvider errPrvdr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpSyncStartDate;
        private System.Windows.Forms.Button btnLastSyncDates;
        private CButtonLib.CButton btnSave;
        private CButtonLib.CButton btnCancel;
        private CButtonLib.CButton btnTest;
        private CButtonLib.CButton btnBrowseQBFile;
    }
}