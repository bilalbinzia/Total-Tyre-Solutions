using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TACheckBox : System.Windows.Forms.CheckBox
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

        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1;
        private string toolTipText = null;
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        public TACheckBox()
        {
            InitializeComponent();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.toolTip1.IsBalloon = true;
            this.toolTip1.SetToolTip(this, toolTipText);

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{TAB}");
            }
            catch { }
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
        private void InitializeComponent()
        {
        }
        public void BindControl(object bindingSource)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, this.xBindingProperty, true));
        }
        public void BindControl(object bindingSource, string xBindingProperty)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, xBindingProperty, true));
        }

    }
}