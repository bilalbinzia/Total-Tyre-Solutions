using ControlLibrary;
using System;

namespace AppControls
{
    public partial class ctrBankVoucher : BaseControl
    {
        string vtype = "BPV";
        public ctrBankVoucher()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrBankVoucher(string status)
        {
            InitializeComponent();
            InitializeComponent1();
            this.vtype = status;
        }
        void InitializeComponent1()
        {
            this.Load += ctrBankVoucher_Load;
            this.rdoVendor.CheckedChanged += rdoVendor_CheckedChanged;
            this.rdoCustomer.CheckedChanged += rdoCustomer_CheckedChanged;
            this.rdoEmployee.CheckedChanged += rdoEmployee_CheckedChanged;
        }

        void rdoEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEmployee.Checked)
            {
                EnableDisale();

                lblEmployee.Top = 208;
                cboEmployee.Top = 204;
                btnEmployeeSearch.Top = 204;
                lblEmployee.Visible = true;
                cboEmployee.Visible = true;
                btnEmployeeSearch.Visible = true;
            }
        }
        void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustomer.Checked)
            {
                EnableDisale();

                lblCustomer.Top = 208;
                cboCustomer.Top = 204;
                btnCustomerSearch.Top = 204;
                lblCustomer.Visible = true;
                cboCustomer.Visible = true;
                btnCustomerSearch.Visible = true;
            }
        }
        void rdoVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVendor.Checked)
            {
                EnableDisale();

                lblVendor.Top = 208;
                cboVendor.Top = 204;
                btnVendorSearch.Top = 204;
                lblVendor.Visible = true;
                cboVendor.Visible = true;
                btnVendorSearch.Visible = true;
            }
        }
        void ctrBankVoucher_Load(object sender, EventArgs e)
        {
            lblVendor.Top = 208;
            cboVendor.Top = 204;
            btnVendorSearch.Top = 204;
            lblVendor.Visible = true;
            cboVendor.Visible = true;
            btnVendorSearch.Visible = true;
        }


        void EnableDisale()
        {
            lblVendor.Top = 0;
            cboVendor.Top = 0;
            btnVendorSearch.Top = 0;
            lblVendor.Visible = false;
            cboVendor.Visible = false;
            btnVendorSearch.Visible = false;

            lblCustomer.Top = 0;
            cboCustomer.Top = 0;
            btnCustomerSearch.Top = 0;
            lblCustomer.Visible = false;
            cboCustomer.Visible = false;
            btnCustomerSearch.Visible = false;

            lblEmployee.Top = 0;
            cboEmployee.Top = 0;
            btnEmployeeSearch.Top = 0;
            lblEmployee.Visible = false;
            cboEmployee.Visible = false;
            btnEmployeeSearch.Visible = false;
        }
    }
}
