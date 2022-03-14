using System32;
namespace ControlLibrary
{
    partial class TADateControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DateTimePicker1 = new ControlLibrary.TADateTimePicker();
            this.txtDate = new ControlLibrary.TATextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.DateTimePicker1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(99, 20);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.DateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(79, 0);
            this.DateTimePicker1.Margin = new System.Windows.Forms.Padding(0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.xIsRequired = StaticInfo.YesNo.No;
            this.DateTimePicker1.Size = new System.Drawing.Size(20, 20);
            this.DateTimePicker1.TabIndex = 1;
            this.DateTimePicker1.TabStop = false;            
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // txtDate
            // 

            this.txtDate.xBindingProperty = null;
            this.txtDate.xColumnName = null;
            this.txtDate.xColumnWidth = 40;
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Fill;

            this.txtDate.Location = new System.Drawing.Point(0, 0);
            this.txtDate.Margin = new System.Windows.Forms.Padding(0);
            this.txtDate.xMasked = StaticInfo.Mask.DateOnly;
            this.txtDate.MaxLength = 8;
            this.txtDate.Name = "txtDate";

            this.txtDate.Size = new System.Drawing.Size(79, 20);
            this.txtDate.TabIndex = 2;
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // TADateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TADateControl";
            this.Size = new System.Drawing.Size(99, 20);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public ControlLibrary.TATextBox txtDate;
        public TADateTimePicker DateTimePicker1;
    }
}
