namespace AppControls
{
    partial class ctrToggleWOColumns
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOAvailableQtyToggleColumn",
            "Available Qty",
            "Show / Hide Available Qty Column",
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Bisque, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOHoursQtyToggleColumn",
            "Hours",
            "Show / Hide Hours Column",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOCostQtyToggleColumn",
            "Cost",
            "Show / Hide Cost Column",
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Bisque, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            " WODiscPerQtyToggleColumn",
            "Discount %",
            "Show / Hide Discount Percent Column",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            " WODiscAmountQtyToggleColumn",
            "Discount Amount",
            "Show / Hide Discount Amount Column",
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Bisque, null);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOIsDoneQtyToggleColumn",
            "Done",
            "Show / Hide Done Column",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOIsTaxQtyToggleColumn",
            "Taxable",
            "Show / Hide Taxable Column",
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Bisque, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            " WOMarginPerQtyToggleColumn",
            "Margin %",
            "Show / Hide Margin Percent Column",
            ""}, -1);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReturnToDefaultSettings = new ControlLibrary.TAButton();
            this.btnCancel = new ControlLibrary.TAButton();
            this.btnDone = new ControlLibrary.TAButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.GridLines = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(401, 166);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sh";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Column";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 270;
            // 
            // btnReturnToDefaultSettings
            // 
            this.btnReturnToDefaultSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;            
            this.btnReturnToDefaultSettings.Location = new System.Drawing.Point(203, 174);
            this.btnReturnToDefaultSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnReturnToDefaultSettings.Name = "btnReturnToDefaultSettings";
            this.btnReturnToDefaultSettings.Size = new System.Drawing.Size(174, 25);
            this.btnReturnToDefaultSettings.TabIndex = 11660;
            this.btnReturnToDefaultSettings.Text = "Return to Default Settings";
            this.btnReturnToDefaultSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            
            this.btnCancel.Location = new System.Drawing.Point(117, 174);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 11659;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            
            this.btnDone.Location = new System.Drawing.Point(31, 174);
            this.btnDone.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(80, 25);
            this.btnDone.TabIndex = 11658;
            this.btnDone.Text = "Done";
            this.btnDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            
            // 
            // ctrToggleWOColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturnToDefaultSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.listView1);
            this.Name = "ctrToggleWOColumns";
            this.Size = new System.Drawing.Size(401, 222);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private ControlLibrary.TAButton btnDone;
        private ControlLibrary.TAButton btnCancel;
        private ControlLibrary.TAButton btnReturnToDefaultSettings;
    }
}
