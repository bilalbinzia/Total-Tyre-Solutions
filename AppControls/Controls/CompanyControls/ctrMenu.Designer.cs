
namespace AppControls
{
    partial class ctrMenu
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
            this.lblSelectModule = new System.Windows.Forms.Label();
            this.CMB_ModuleList = new ControlLibrary.TAComboBox();
            this.DGV_Menu = new ControlLibrary.TAZSearchDataGridView();
            this.lblMenuCode = new System.Windows.Forms.Label();
            this.txtCode = new ControlLibrary.TATextBox();
            this.CB_Active = new ControlLibrary.TACheckBox();
            this.txtName = new ControlLibrary.TATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new ControlLibrary.TATextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelectModule
            // 
            this.lblSelectModule.AutoSize = true;
            this.lblSelectModule.Location = new System.Drawing.Point(6, 67);
            this.lblSelectModule.Name = "lblSelectModule";
            this.lblSelectModule.Size = new System.Drawing.Size(75, 13);
            this.lblSelectModule.TabIndex = 1;
            this.lblSelectModule.Text = "Select Module";
            // 
            // CMB_ModuleList
            // 
            this.CMB_ModuleList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CMB_ModuleList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMB_ModuleList.FormattingEnabled = true;
            this.CMB_ModuleList.Location = new System.Drawing.Point(87, 64);
            this.CMB_ModuleList.Name = "CMB_ModuleList";
            this.CMB_ModuleList.Size = new System.Drawing.Size(145, 21);
            this.CMB_ModuleList.TabIndex = 2;
            this.CMB_ModuleList.xBindingProperty = null;
            this.CMB_ModuleList.xColumnName = null;
            this.CMB_ModuleList.xColumnWidth = 60;
            this.CMB_ModuleList.xDisplayMember = null;
            this.CMB_ModuleList.xFillByFieldID = null;
            this.CMB_ModuleList.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.CMB_ModuleList.xIsRequired = System32.StaticInfo.YesNo.No;
            this.CMB_ModuleList.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.CMB_ModuleList.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.CMB_ModuleList.xOrderBy = null;
            this.CMB_ModuleList.xReadOnly = false;
            this.CMB_ModuleList.xTableName = null;
            this.CMB_ModuleList.SelectedValueChanged += new System.EventHandler(this.CMB_ModuleList_SelectedValueChanged);
            // 
            // DGV_Menu
            // 
            this.DGV_Menu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_Menu.Location = new System.Drawing.Point(0, 165);
            this.DGV_Menu.Name = "DGV_Menu";
            this.DGV_Menu.Size = new System.Drawing.Size(560, 247);
            this.DGV_Menu.TabIndex = 0;
            // 
            // lblMenuCode
            // 
            this.lblMenuCode.AutoSize = true;
            this.lblMenuCode.Location = new System.Drawing.Point(254, 67);
            this.lblMenuCode.Name = "lblMenuCode";
            this.lblMenuCode.Size = new System.Drawing.Size(32, 13);
            this.lblMenuCode.TabIndex = 3;
            this.lblMenuCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(292, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(93, 20);
            this.txtCode.TabIndex = 4;
            this.txtCode.xBindingProperty = null;
            this.txtCode.xColumnName = null;
            this.txtCode.xColumnWidth = 60;
            this.txtCode.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtCode.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtCode.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtCode.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtCode.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtCode.xMasked = System32.StaticInfo.Mask.None;
            this.txtCode.xReadOnly = false;
            // 
            // CB_Active
            // 
            this.CB_Active.AutoSize = true;
            this.CB_Active.Location = new System.Drawing.Point(420, 66);
            this.CB_Active.Name = "CB_Active";
            this.CB_Active.Size = new System.Drawing.Size(56, 17);
            this.CB_Active.TabIndex = 5;
            this.CB_Active.Text = "Active";
            this.CB_Active.ToolTipText = null;
            this.CB_Active.UseVisualStyleBackColor = true;
            this.CB_Active.xBindingProperty = null;
            this.CB_Active.xColumnName = null;
            this.CB_Active.xColumnWidth = 60;
            this.CB_Active.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.CB_Active.xIsRequired = System32.StaticInfo.YesNo.No;
            this.CB_Active.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 99);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 20);
            this.txtName.TabIndex = 7;
            this.txtName.xBindingProperty = null;
            this.txtName.xColumnName = null;
            this.txtName.xColumnWidth = 60;
            this.txtName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtName.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtName.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtName.xMasked = System32.StaticInfo.Mask.None;
            this.txtName.xReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(45, 133);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(378, 20);
            this.txtNotes.TabIndex = 9;
            this.txtNotes.xBindingProperty = null;
            this.txtNotes.xColumnName = null;
            this.txtNotes.xColumnWidth = 60;
            this.txtNotes.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtNotes.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtNotes.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtNotes.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtNotes.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtNotes.xMasked = System32.StaticInfo.Mask.None;
            this.txtNotes.xReadOnly = false;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(4, 136);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notes";
            // 
            // ctrMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Active);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblMenuCode);
            this.Controls.Add(this.CMB_ModuleList);
            this.Controls.Add(this.lblSelectModule);
            this.Controls.Add(this.DGV_Menu);
            this.Name = "ctrMenu";
            this.Size = new System.Drawing.Size(560, 412);
            this.Load += new System.EventHandler(this.ctrMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView DGV_Menu;
        private System.Windows.Forms.Label lblSelectModule;
        private ControlLibrary.TAComboBox CMB_ModuleList;
        private System.Windows.Forms.Label lblMenuCode;
        private ControlLibrary.TATextBox txtCode;
        private ControlLibrary.TACheckBox CB_Active;
        private ControlLibrary.TATextBox txtName;
        private System.Windows.Forms.Label label1;
        private ControlLibrary.TATextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
    }
}
