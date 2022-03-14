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
    public partial class TADecimalControl : UserControl
    {
        BindingSource bindingSource = null;
        public string dataMember = null;
        //private System.Windows.Forms.ErrorProvider errorProvider1;

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

        private int ivalue;
        public int Ivalue
        {
            get { return ivalue; }
            set
            {
                ivalue = value;
                this.lblBox.Text = "Note of " + ivalue;
            }
        }

        public TADecimalControl()
        {
            InitializeComponent();

        }

        private void txtBoxN0_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxN0.Text.Trim()))
                {
                    this.txtBoxN1.Text = Convert.ToString((StaticInfo.StrToDec(txtBoxN0.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture))) * this.ivalue);
                    StaticInfo.CalculateTotal(Convert.ToDecimal(this.txtBoxN1.Text.Trim()));
                }
            }
        }

        private void txtBoxN0_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxN0.Text.Trim()))
            {
                this.txtBoxN1.Text = Convert.ToString((StaticInfo.StrToDec(txtBoxN0.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture))) * this.ivalue);
                StaticInfo.CalculateTotal(Convert.ToDecimal(this.txtBoxN1.Text.Trim()));
            }
            else
                this.txtBoxN0.Text = Convert.ToString("0.0");
        }

        public void BindControl(object bindingSource, string dataMember)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.dataMember = dataMember;

            this.txtBoxN0.DataBindings.Add("Text", bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void onLoad()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBoxN0.Text.Trim()))
                {
                    this.txtBoxN1.Text = Convert.ToString((StaticInfo.StrToDec(txtBoxN0.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture))) * this.ivalue);
                    StaticInfo.CalculateTotal(Convert.ToDecimal(this.txtBoxN1.Text.Trim()));
                }
                else
                    this.txtBoxN0.Text = Convert.ToString("0.0");
            }
            catch { }
        }

    }
}
