using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TADateTimePicker : DateTimePicker
    {
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
        private StaticInfo.YesNo showCurrentDate;
        public StaticInfo.YesNo xIsShowCurrentDate
        {
            get { return showCurrentDate; }
            set { showCurrentDate = value; }
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

        BindingSource bindingSource = null;
        string dataMember = null;

        private System.ComponentModel.Container components = null;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //if (e.Control && e.KeyCode == Keys.F)
            //    if (this.Enabled) { Search search = new Search(this.bindingSource, this.dataMember, typeof(DateTime), this.Parent); search.Show(); }
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void BindControl(object bindingSource, string dataMember)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.dataMember = dataMember;

            this.DataBindings.Add("Text", bindingSource, dataMember, true);
            ////this.DataBindings.Add("Value", bindingSource, dataMember, true);
        }
        public TADateTimePicker()
        {
            this.CustomFormat = "dd-MMM-yyyy";
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Value = DateTime.Now;

        }


    }
}
