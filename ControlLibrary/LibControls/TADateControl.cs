using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public partial class TADateControl : UserControl
    {

        BindingSource bindingSource = null;
        public string dataMember = null;

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }

        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }

        private StaticInfo.YesNo allowDuplicate;
        public StaticInfo.YesNo xIsAllowDuplicate
        {
            get { return allowDuplicate; }
            set { allowDuplicate = value; }
        }

        private StaticInfo.YesNo showInGrid;
        public StaticInfo.YesNo xIsShowInGrid
        {
            get { return showInGrid; }
            set { showInGrid = value; }
        }
        private StaticInfo.YesNo showCurrentDate;
        public StaticInfo.YesNo xIsShowCurrentDate
        {
            get { return showCurrentDate; }
            set { showCurrentDate = value; }
        }
        private string columnName;
        public string xColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        private int columnWidth = 60;
        public int xColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }
        
        public TADateControl()
        {
            InitializeComponent();

            this.DateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            this.DateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Value = DateTime.Now;
            
            //this.txtDate.Text = "";
        }

        


        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (e.Control && e.KeyCode == Keys.F)
        //        if (this.Enabled)
        //        {
        //            Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime));
        //            search.Show();
        //        }
        //}

        public void BindControl(object bindingSource, string dataMember)
        {            
            this.bindingSource = (BindingSource)bindingSource;
            this.dataMember = dataMember;
            this.DateTimePicker1.DataBindings.Add("Value", bindingSource, dataMember, true);
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = string.Format("{0:dd-MMM-yyyy}", this.DateTimePicker1.Value);
        }
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                //Search search = new Search(this.bindingSource, this.bindingProperty, typeof(DateTime), this.Parent);
                if (!this.bindingSource.Equals(null) && !this.dataMember.Equals(null) && !typeof(string).Equals(null))
                {
                    DataRow dataRow = ((DataRowView)bindingSource.Current).Row;
                    if (dataRow.RowState != DataRowState.Added)
                    {
                        if (this.dataMember.ToString().Contains("Date"))
                        {
                            if (this.Parent.Name.Equals("WorkingPanel"))
                            {
                                Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent);
                            }
                            else if (this.Parent.Parent.Name.Equals("WorkingPanel"))
                            {
                                Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent.Parent);
                            }
                            else if (this.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                            {
                                Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent.Parent.Parent);
                            }
                            else if (this.Parent.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                            {
                                Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent.Parent.Parent.Parent);
                            }
                            else if (this.Parent.Parent.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                            {
                                Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent.Parent.Parent.Parent.Parent);
                            }
                            //search.Show();
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string sDate = this.txtDate.Text.Trim();
                    DateTime dt = Convert.ToDateTime(sDate);
                    this.DateTimePicker1.Value = dt.Date;
                }
                catch { }
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                string sDate = this.txtDate.Text.Trim();
                DateTime dt = Convert.ToDateTime(sDate);
                this.DateTimePicker1.Value = dt.Date;
            }
            catch { }
        }
    }
}
