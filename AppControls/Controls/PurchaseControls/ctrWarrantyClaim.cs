using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;

namespace AppControls
{
    public partial class ctrWarrantyClaim : UserControl
    {
        int SelectedVendorID = 0, SelectedPOID = 0, SelectedItemID = 0;
        public ctrWarrantyClaim()
        {
            InitializeComponent();
            btnCancel.Click += btnCancel_Click;
        }
        public ctrWarrantyClaim(int selectedVendorID, int selectedPOID, int selectedItemID)
        {
            InitializeComponent();

            this.SelectedVendorID = selectedVendorID;
            this.SelectedPOID = selectedPOID;
            this.SelectedItemID = selectedItemID;

            this.Load += ctrWarrantyClaim_Load;
            btnCancel.Click += btnCancel_Click;
            btnWarrantyClaim.Click += btnWarrantyClaim_Click;
        }

        void btnWarrantyClaim_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ClaimDate = ctrClaimDate.DateTimePicker1.Value.Date;
                int ClaimQty = Convert.ToInt32(numReturnQty.Value);
                bool IsShipped = chkIsShipped.Checked;
                DateTime ShipingDate = ctrShipDate.DateTimePicker1.Value.Date;
                string CustomerClaimNumber = txtCustomerInvoice.Text.Trim();
                string Comments = txtComment.Text.Trim();

                dbClass.obj.AddWarrantyClaim(SelectedVendorID, SelectedPOID, SelectedItemID, ClaimDate, ClaimQty, IsShipped, ShipingDate, CustomerClaimNumber, Comments, false, "Returned");

                this.ParentForm.Dispose();
            }
            catch { }
        }

        void ctrWarrantyClaim_Load(object sender, EventArgs e)
        {
            DataRow dr = dbClass.obj.FillItemByID(this.SelectedItemID);
            txtItemCatalog.Text = Convert.ToString(dr["Catalog"]);
            txtItemDescription.Text = Convert.ToString(dr["Name"]);
            ctrClaimDate.DateTimePicker1.Value = DateTime.Now;

        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Dispose();
        }
    }
}
