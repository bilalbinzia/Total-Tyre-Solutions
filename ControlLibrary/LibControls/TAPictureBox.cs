using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TAPictureBox : PictureBox
    {

        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }

        private StaticInfo.YesNo showInGrid;
        public StaticInfo.YesNo xIsShowInGrid
        {
            get { return showInGrid; }
            set { showInGrid = value; }
        }

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }

        private string displayMember;
        public string xDisplayMember
        {
            get { return displayMember; }
            set { displayMember = value; }
        }

        private string valueMember;
        public string xValueMember
        {
            get { return valueMember; }
            set { valueMember = value; }
        }

        private string tableName;
        public string xTableName
        {
            get { return tableName; }
            set { tableName = value; }
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
        public TAPictureBox()
        {
            InitializeComponent();

            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.toolTip1.IsBalloon = true;
            this.toolTip1.SetToolTip(this, toolTipText);
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
            //this.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, dataMember, true));
        }

    }
}
