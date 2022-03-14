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
    public partial class ctrClaim : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = null;
        int VendorID = 0, ItemID = 0;
        string VendorName = string.Empty;

        public ctrClaim()
        {
            InitializeComponent();
            InitializeComponent1();
        }

        public ctrClaim(int vendorID,string vendorName)
        {
            InitializeComponent();
            InitializeComponent1();
            this.VendorID = vendorID;
            this.VendorName = vendorName;
        }
        void InitializeComponent1()
        {
            xMessageBox = new ControlLibrary.MessageBox();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnAddCatalog.Click += btnAddCatalog_Click;
            this.Load += ctrClaim_Load;
        }

        void ctrClaim_Load(object sender, EventArgs e)
        {
            ClaimDate.DateTimePicker1.Value = DateTime.Now.Date;
            cboStatus.SelectedIndex = 1;
            txtVendor.Text = this.VendorName;
        }
        void btnAddCatalog_Click(object sender, EventArgs e)
        {
            LoadCatalog_CellClick();
        }
        void LoadCatalog_CellClick()
        {
            ctrItemListForGrid objList = new ctrItemListForGrid();
            objList.ObjectSelected += AddCatalogInGrid_ObjectSelected;
            frmCtr frmCtr = new frmCtr("Select Item ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Parent.Parent.Dispose();
        }

        void btnSave_Click(object sender, EventArgs e)
        {            
            dbClass.obj.AddNewClaim(this.VendorID, this.ItemID, ClaimDate.DateTimePicker1.Value.Date, Convert.ToInt32(numQty.Value), false, ClaimDate.DateTimePicker1.Value.Date, txtCustomerInvoiceNo.Text.Trim(), txtVendorReferenceNo.Text.Trim(), chkAdjustInventoryQty.Checked, cboStatus.SelectedItem.ToString());
            xMessageBox.Show("New Claim has been successfully Saved ....","New Claim");
            this.Parent.Parent.Parent.Dispose();
        }

        void AddCatalogInGrid_ObjectSelected(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                if (dataRow != null)
                {
                    this.ItemID = Convert.ToInt32(dataRow["ID"]);
                    txtCatalog.Text = Convert.ToString(dataRow["Catalog"]);
                    txtDescription.Text = Convert.ToString(dataRow["Name"]);
                    txtCatalogCost.Text = Convert.ToString(dataRow["CatalogCost"]);
                }

                ((ctrItemListForGrid)sender).Parent.Parent.Parent.Dispose();
            }
            catch { }
        }

    }
}
