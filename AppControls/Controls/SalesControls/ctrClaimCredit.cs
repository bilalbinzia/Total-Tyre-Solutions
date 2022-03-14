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
    public delegate void ClaimCreditDelegate(object sender, bool IsCredited, string RefNo, DateTime? CreditDate);
    public partial class ctrClaimCredit : UserControl
    {
        public event ClaimCreditDelegate claimCreditDelegate;

        ControlLibrary.MessageBox xMessageBox = null;
        int VendorID = 0, ItemID = 0;
        string VendorName = string.Empty;
        string RefNo = string.Empty;
        public ctrClaimCredit()
        {
            InitializeComponent();
            InitializeComponent1();
        }

        public ctrClaimCredit(int vendorID, string vendorName, string refNo)
        {
            InitializeComponent();
            InitializeComponent1();
            this.VendorID = vendorID;
            this.VendorName = vendorName;
            this.RefNo = refNo;
        }
        void InitializeComponent1()
        {
            xMessageBox = new ControlLibrary.MessageBox();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            this.Load += ctrClaimCredit_Load;
        }

        void ctrClaimCredit_Load(object sender, EventArgs e)
        {
            ClaimDate.DateTimePicker1.Value = DateTime.Now.Date;
            txtVendor.Text = this.VendorName;
            txtVendorReferenceNo.Text = this.RefNo;
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (claimCreditDelegate != null)
                claimCreditDelegate(this, false, string.Empty, null);

            this.Parent.Parent.Parent.Dispose();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (xMessageBox.Show("Create a Credit for the selected Claims....?", "Credit Claims ...!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (claimCreditDelegate != null)
                    claimCreditDelegate(this, true, txtVendorReferenceNo.Text.Trim(), ClaimDate.DateTimePicker1.Value.Date);
            }
            this.Parent.Parent.Parent.Dispose();
        }

    }
}
