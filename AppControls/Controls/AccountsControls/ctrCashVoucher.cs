using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using DBModule;

namespace AppControls
{
    public partial class ctrCashVoucher : BaseControl
    {
        string vtype = "CPV";
        public ctrCashVoucher()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrCashVoucher(string status)
        {
            InitializeComponent();
            InitializeComponent1();
            this.vtype = status;            
        }
        void InitializeComponent1()
        {
            this.Load += ctrCashVoucher_Load;

            this.rdoVendor.CheckedChanged += rdoVendor_CheckedChanged;
            this.rdoCustomer.CheckedChanged += rdoCustomer_CheckedChanged;
            this.rdoEmployee.CheckedChanged += rdoEmployee_CheckedChanged;

            chkboxIsAuto.CheckedChanged += chkboxIsAuto_CheckedChanged;
        }
        void chkboxIsAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add)
            {
                if (chkboxIsAuto.Checked)
                {
                    txtVoucherNo.Enabled = false;
                    txtVoucherNo.ReadOnly = true;
                    string ItemCode = dbClass.obj.getNextVoucherNo();
                    txtVoucherNo.Text = ItemCode;
                }
                else
                {
                    txtVoucherNo.Text = "";
                    txtVoucherNo.Enabled = true;
                    txtVoucherNo.ReadOnly = false;
                }
            }
        }        
        void ctrCashVoucher_Load(object sender, EventArgs e)
        {
            if (vtype == "CRV")
            {
                lblMode.Text = "Received From";
                lblMode.Left = 76;
            }


            lblVendor.Top = 208;
            cboVendor.Top = 204;
            btnVendorSearch.Top = 204;
            lblVendor.Visible = true;
            cboVendor.Visible = true;
            btnVendorSearch.Visible = true;

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
