
namespace AppControls
{
    partial class ctrModule
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
            CButtonLib.cBlendItems cBlendItems5 = new CButtonLib.cBlendItems();
            this.lblModuleName = new System.Windows.Forms.Label();
            this.btnDelete = new ControlLibrary.TAButton();
            this.btnUpdateModule = new ControlLibrary.TAButton();
            this.btnAddModule = new ControlLibrary.TAButton();
            this.CB_Active = new ControlLibrary.TACheckBox();
            this.txtModuleName = new ControlLibrary.TATextBox();
            this.DGV_Module = new ControlLibrary.TAZSearchDataGridView();
            this.btnClearScreen = new ControlLibrary.TAButton();
            this.btnRefresh = new ControlLibrary.TAButton();
            this.SuspendLayout();
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Location = new System.Drawing.Point(3, 76);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(73, 13);
            this.lblModuleName.TabIndex = 2;
            this.lblModuleName.Text = "Module Name";
            // 
            // btnDelete
            // 
            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnDelete.ColorFillBlend = cBlendItems1;
            this.btnDelete.DesignerSelected = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.Location = new System.Drawing.Point(178, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.TabIndex = 11664;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnDelete_ClickButtonArea);
            // 
            // btnUpdateModule
            // 
            cBlendItems2.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems2.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnUpdateModule.ColorFillBlend = cBlendItems2;
            this.btnUpdateModule.DesignerSelected = false;
            this.btnUpdateModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUpdateModule.ImageIndex = 0;
            this.btnUpdateModule.Location = new System.Drawing.Point(92, 12);
            this.btnUpdateModule.Name = "btnUpdateModule";
            this.btnUpdateModule.Size = new System.Drawing.Size(80, 35);
            this.btnUpdateModule.TabIndex = 11663;
            this.btnUpdateModule.Text = "Update";
            this.btnUpdateModule.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateModule.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnUpdateModule_ClickButtonArea);
            // 
            // btnAddModule
            // 
            cBlendItems3.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems3.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnAddModule.ColorFillBlend = cBlendItems3;
            this.btnAddModule.DesignerSelected = false;
            this.btnAddModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddModule.ImageIndex = 0;
            this.btnAddModule.Location = new System.Drawing.Point(6, 12);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(80, 35);
            this.btnAddModule.TabIndex = 11662;
            this.btnAddModule.Text = "Add New";
            this.btnAddModule.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddModule.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnAddModule_ClickButtonArea);
            // 
            // CB_Active
            // 
            this.CB_Active.AutoSize = true;
            this.CB_Active.Location = new System.Drawing.Point(282, 75);
            this.CB_Active.Name = "CB_Active";
            this.CB_Active.Size = new System.Drawing.Size(56, 17);
            this.CB_Active.TabIndex = 3;
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
            // txtModuleName
            // 
            this.txtModuleName.Location = new System.Drawing.Point(82, 73);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.Size = new System.Drawing.Size(183, 20);
            this.txtModuleName.TabIndex = 1;
            this.txtModuleName.xBindingProperty = null;
            this.txtModuleName.xColumnName = null;
            this.txtModuleName.xColumnWidth = 60;
            this.txtModuleName.xIsAllowDuplicate = System32.StaticInfo.YesNo.No;
            this.txtModuleName.xIsEncrypt = System32.StaticInfo.YesNo.No;
            this.txtModuleName.xIsRequired = System32.StaticInfo.YesNo.No;
            this.txtModuleName.xIsShowCashSymbol = System32.StaticInfo.YesNo.No;
            this.txtModuleName.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.txtModuleName.xMasked = System32.StaticInfo.Mask.None;
            this.txtModuleName.xReadOnly = false;
            // 
            // DGV_Module
            // 
            this.DGV_Module.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_Module.Location = new System.Drawing.Point(0, 103);
            this.DGV_Module.Name = "DGV_Module";
            this.DGV_Module.Size = new System.Drawing.Size(510, 247);
            this.DGV_Module.TabIndex = 0;
            // 
            // btnClearScreen
            // 
            cBlendItems4.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems4.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnClearScreen.ColorFillBlend = cBlendItems4;
            this.btnClearScreen.DesignerSelected = false;
            this.btnClearScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearScreen.ImageIndex = 0;
            this.btnClearScreen.Location = new System.Drawing.Point(264, 12);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(80, 35);
            this.btnClearScreen.TabIndex = 11665;
            this.btnClearScreen.Text = "Clear Fields";
            this.btnClearScreen.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearScreen.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnClearScreen_ClickButtonArea);
            // 
            // btnRefresh
            // 
            cBlendItems5.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems5.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.btnRefresh.ColorFillBlend = cBlendItems5;
            this.btnRefresh.DesignerSelected = false;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(350, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 35);
            this.btnRefresh.TabIndex = 11666;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRefresh.ClickButtonArea += new CButtonLib.CButton.ClickButtonAreaEventHandler(this.btnRefresh_ClickButtonArea);
            // 
            // ctrModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateModule);
            this.Controls.Add(this.btnAddModule);
            this.Controls.Add(this.CB_Active);
            this.Controls.Add(this.lblModuleName);
            this.Controls.Add(this.txtModuleName);
            this.Controls.Add(this.DGV_Module);
            this.Name = "ctrModule";
            this.Size = new System.Drawing.Size(510, 350);
            this.Load += new System.EventHandler(this.ctrModule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLibrary.TAZSearchDataGridView DGV_Module;
        private ControlLibrary.TATextBox txtModuleName;
        private System.Windows.Forms.Label lblModuleName;
        private ControlLibrary.TACheckBox CB_Active;
        private ControlLibrary.TAButton btnAddModule;
        private ControlLibrary.TAButton btnUpdateModule;
        private ControlLibrary.TAButton btnDelete;
        private ControlLibrary.TAButton btnClearScreen;
        private ControlLibrary.TAButton btnRefresh;
    }
}
