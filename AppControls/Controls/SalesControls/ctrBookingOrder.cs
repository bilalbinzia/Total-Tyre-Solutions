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
using System32;
using DBModule;

namespace AppControls
{
    public partial class ctrBookingOrder : BaseControl
    {
        int BookingOrderID = 0;
        int CustID = 0;
        int ShipToCustID = 0;

        int ctrMode = 0;
        string CustomerPriceLevel;
        public ctrBookingOrder()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrBookingOrder(int ctrMode)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
        }
        public ctrBookingOrder(int ctrMode, int SelectedCustID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
            this.CustID = SelectedCustID;
        }
        public ctrBookingOrder(int ctrMode, int iID, int SelectedCustID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
            this.CustID = SelectedCustID;
            this.BookingOrderID = iID;
        }
        void InitializeComponent1()
        {
            this.Load += ctrBookingOrder_Load;
                        
            this.DGVBookingOrder.CellEndEdit += DGVBookingOrder_CellEndEdit;
            
            this.btnCustomerInvoice.Click += TSMItem1_Click;
            this.btnPrintInvoice.Click += TSMItem2_Click;

            this.ctrShipFromCustomer.SelectionChangeCommitted += ctrShipFromCustomer_SelectionChangeCommitted;
            this.btnSearchCustomer.Click += btnSearchCustomer_Click;

            this.ctrShipToCustomer.SelectionChangeCommitted += ctrShipToCustomer_SelectionChangeCommitted;
            this.btnSearchCustomer1.Click += btnSearchCustomer1_Click;
        }

        void ctrShipFromCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ctrShipFromCustomer.SelectedItem;
            if (drv["ID"] != DBNull.Value)
            {
                this.CustID = Convert.ToInt32(drv["ID"]);
                DataRow CustomerRow = SetCustomer(CustID);
                AddCustomerDetail_ObjectSelected(null, CustomerRow);
            }
        }
        void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            frmCtr ctrfrmCtr;
            ctrCustomerList ctrCustomerList = new ctrCustomerList();
            ctrCustomerList.CustomerSelected += AddCustomerDetail_ObjectSelected;
            ctrfrmCtr = new frmCtr("Select Customer ...");
            ctrfrmCtr.Height = ctrCustomerList.Height + 40; ctrfrmCtr.Width = ctrCustomerList.Width + 20;
            ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ctrfrmCtr.frmPnl.Controls.Add(ctrCustomerList);
            ctrfrmCtr.BringToFront();
            ctrfrmCtr.ShowDialog();
        }
        void AddCustomerDetail_ObjectSelected(object sender, DataRow CustomerRow)
        {
            try
            {
                if (CustomerRow != null)
                {

                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["CustomerID"] = CustomerRow["ID"];
                    curRow.EndEdit();

                    this.CustID = Convert.ToInt32(CustomerRow["ID"]);

                    if (CustomerRow["FirstName"] != DBNull.Value) { ctrFirstNameShipFrom.Text = Convert.ToString(CustomerRow["FirstName"]); } else { ctrFirstNameShipFrom.Text = string.Empty; }
                    if (CustomerRow["LastName"] != DBNull.Value) { ctrLastNameShipFrom.Text = Convert.ToString(CustomerRow["LastName"]); } else { ctrLastNameShipFrom.Text = string.Empty; }
                    if (CustomerRow["Address"] != DBNull.Value) { ctrAddressShipFrom.Text = Convert.ToString(CustomerRow["Address"]); } else { ctrAddressShipFrom.Text = string.Empty; }
                    if (CustomerRow["Email"] != DBNull.Value) { ctrEmailShipFrom.Text = Convert.ToString(CustomerRow["Email"]); } else { ctrEmailShipFrom.Text = string.Empty; }

                    if (CustomerRow["Phone1"] != DBNull.Value) { ctrPhone1ShipFrom.Text = Convert.ToString(CustomerRow["Phone1"]); } else { ctrPhone1ShipFrom.Text = string.Empty; }
                    if (CustomerRow["Phone2"] != DBNull.Value) { ctrPhone2ShipFrom.Text = Convert.ToString(CustomerRow["Phone2"]); } else { ctrPhone2ShipFrom.Text = string.Empty; }
                    if (CustomerRow["State"] != DBNull.Value) { ctrStateShipFrom.Text = Convert.ToString(CustomerRow["State"]); } else { ctrStateShipFrom.Text = string.Empty; }
                    if (CustomerRow["City"] != DBNull.Value) { ctrCityShipFrom.Text = Convert.ToString(CustomerRow["City"]); } else { ctrCityShipFrom.Text = string.Empty; }
                    if (CustomerRow["ZipCode"] != DBNull.Value) { ctrZipCodeShipFrom.Text = Convert.ToString(CustomerRow["ZipCode"]); } else { ctrZipCodeShipFrom.Text = string.Empty; }
                }
            }
            catch { }
        }
        void ctrShipToCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ctrShipToCustomer.SelectedItem;
            if (drv["ID"] != DBNull.Value)
            {
                this.ShipToCustID = Convert.ToInt32(drv["ID"]);
                DataRow CustomerRow = SetCustomer(ShipToCustID);
                AddCustomer1Detail_ObjectSelected(null, CustomerRow);
            }
        }
        void btnSearchCustomer1_Click(object sender, EventArgs e)
        {
            frmCtr ctrfrmCtr;
            ctrCustomerList ctrCustomerList = new ctrCustomerList();
            ctrCustomerList.CustomerSelected += AddCustomer1Detail_ObjectSelected;
            ctrfrmCtr = new frmCtr("Select Customer ...");
            ctrfrmCtr.Height = ctrCustomerList.Height + 40; ctrfrmCtr.Width = ctrCustomerList.Width + 20;
            ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ctrfrmCtr.frmPnl.Controls.Add(ctrCustomerList);
            ctrfrmCtr.BringToFront();
            ctrfrmCtr.ShowDialog();
        }
        void AddCustomer1Detail_ObjectSelected(object sender, DataRow CustomerRow)
        {
            try
            {
                if (CustomerRow != null)
                {

                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["ShipToCustomerID"] = CustomerRow["ID"];
                    curRow.EndEdit();
                    this.ShipToCustID = Convert.ToInt32(CustomerRow["ID"]);

                    if (CustomerRow["FirstName"] != DBNull.Value) { ctrFirstNameShipTo.Text = Convert.ToString(CustomerRow["FirstName"]); } else { ctrFirstNameShipTo.Text = string.Empty; }
                    if (CustomerRow["LastName"] != DBNull.Value) { ctrLastNameShipTo.Text = Convert.ToString(CustomerRow["LastName"]); } else { ctrLastNameShipTo.Text = string.Empty; }
                    if (CustomerRow["Address"] != DBNull.Value) { ctrAddressShipTo.Text = Convert.ToString(CustomerRow["Address"]); } else { ctrAddressShipTo.Text = string.Empty; }
                    if (CustomerRow["Email"] != DBNull.Value) { ctrEmailShipTo.Text = Convert.ToString(CustomerRow["Email"]); } else { ctrEmailShipTo.Text = string.Empty; }
                    if (CustomerRow["Phone1"] != DBNull.Value) { ctrPhone1ShipTo.Text = Convert.ToString(CustomerRow["Phone1"]); } else { ctrPhone1ShipTo.Text = string.Empty; }
                    if (CustomerRow["Phone2"] != DBNull.Value) { ctrPhone2ShipTo.Text = Convert.ToString(CustomerRow["Phone2"]); } else { ctrPhone2ShipTo.Text = string.Empty; }
                    if (CustomerRow["State"] != DBNull.Value) { ctrStateShipTo.Text = Convert.ToString(CustomerRow["State"]); } else { ctrStateShipTo.Text = string.Empty; }
                    if (CustomerRow["City"] != DBNull.Value) { ctrCityShipTo.Text = Convert.ToString(CustomerRow["City"]); } else { ctrCityShipTo.Text = string.Empty; }
                    if (CustomerRow["ZipCode"] != DBNull.Value) { ctrZipCodeShipTo.Text = Convert.ToString(CustomerRow["ZipCode"]); } else { ctrZipCodeShipTo.Text = string.Empty; }
                }
            }
            catch { }
        }                
        void ctrBookingOrder_Load(object sender, EventArgs e)
        {
            if ((this.BookingOrderID <= 0) && (this.ctrMode > 0))
            {
                bindingNavigatorAddNewItem_Click(sender, e);
            }
            
            //----------------------------------------------------------//
            TSMItem1.Visible = true;
            TSMItem1.Text = "Customer Invoice";
            TSMItem2.Visible = true;
            TSMItem2.Text = "Print Invoice";
            TSMItem3.Visible = true;
            TSMItem3.Text = "Void";                        
            //----------------------------------------------------------//            
        }
        protected override void DataNavigation()
        {
            base.DataNavigation();                        
        }
        DataRow SetCustomer(int CustID)
        {
            DataRow CustomerRow = dbClass.obj.getCustomerByID(CustID);
            return CustomerRow;                       
        }        
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int NextAutoNo = dbClass.obj.getNextWorkOrderAutoNo();
            base.bindingNavigatorAddNewItem_Click(sender, e);
            if (this.ctrMode < 0)
            {
                this.ctrMode = 0;
                this.CustID = 1;
                this.BookingOrderID = 0;
            }
            
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["WorkOrderNo"] = NextAutoNo;
            //--7year8month6day
            string sBookingNo = "7" + Convert.ToString(DateTime.Now.Year) + "8" + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + "6" + Convert.ToString(NextAutoNo);
            curRow["BookingNo"] = Convert.ToInt64(sBookingNo);
            curRow["RegDate"] = DateTime.Now;
            curRow["CreatedByID"] = StaticInfo.userid;
            curRow["SaleRepID"] = StaticInfo.userid;

            curRow["IsBookingOrder"] = false;
            curRow["IsQutation"] = false;
            if ((this.ctrMode == 0) || (this.ctrMode == 1) || (this.ctrMode == 3))
                curRow["IsBookingOrder"] = true;
            else if ((this.ctrMode == 2) || (this.ctrMode == 4))
                curRow["IsQutation"] = true;
            curRow["Status"] = "B/O";
            curRow["IsNegated"] = false;
            curRow["BookingInsuranceRate"] = 2.25;

            curRow.EndEdit();
            //------------------------------------ 
            base.DataNavigation();            
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorEditItem_Click(sender, e);
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["CustomerID"] == null)
            {
                xMessageBox.Show("Add Customer for this BookingOrder ...");
                return;
            }
            if (Convert.ToDecimal(curRow["Total"]) <= 0)            
            {
                xMessageBox.Show("Add Items in BookingOrder ...");
                return;
            }
            base.bindingNavigatorSaveItem_Click(sender, e);
            if (CustomValidation(true))
            {
                this.ctrMode = 0; this.CustID = 1;
                if (Convert.ToInt32(curRow["ID"]) >= 1)
                {
                    if(StaticInfo.IsLoginForWarehouse)
                        StaticInfo.LoadToReport("RptModule", "Reports.InvoiceBillingReport", "byID", Convert.ToInt32(curRow["ID"]));
                }
            }                        
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorCancelItem_Click(sender, e);
            this.ctrMode = 0; this.CustID = 1;
        }
        protected override void TSMItem1_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
            {
                ctrCustomerReceipt objList = new ctrCustomerReceipt(Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                frmCtr frmCtr = new frmCtr("Customer Receipt ...");               
                frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
        }
        protected override void TSMItem2_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
                StaticInfo.LoadToReport("RptModule", "Reports.InvoiceBillingReport", "byID", Convert.ToInt32(curRow["ID"]));
        }
        protected override void TSMItem3_Click(object sender, EventArgs e)
        {

        }
        protected override void TSMItem4_Click(object sender, EventArgs e)
        {

        }        
        void DGVBookingOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            libDataGridView DGV = (libDataGridView)sender;
            DataRowView curRow = (DataRowView)DGV.objBindingSource.Current;
            string DGVColumnName = DGV.Columns[e.ColumnIndex].Name;

            try
            {
                DataRowView BOcurRow = (DataRowView)objBindingSource.Current;
                if (BOcurRow["BookingInsuranceRate"] == DBNull.Value)
                {
                    BOcurRow.BeginEdit();
                    BOcurRow["BookingInsuranceRate"] = 0;
                    BOcurRow.EndEdit();
                }
                curRow.BeginEdit();
                //----------------------------------------------
                if (DGVColumnName.Equals("itemValue") || DGVColumnName.Equals("IsInsured") || DGVColumnName.Equals("PkgCharges"))
                {
                    if (curRow["itemValue"] == DBNull.Value) curRow["itemValue"] = 0;
                    if (curRow["PkgCharges"] == DBNull.Value) curRow["PkgCharges"] = 0;
                    if (curRow["IsInsured"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(curRow["IsInsured"]) == true)
                            curRow["InsAmt"] = Math.Round(Convert.ToDecimal(curRow["itemValue"]) * Convert.ToDecimal(BOcurRow["BookingInsuranceRate"]) / 100, 2);
                        else
                            curRow["InsAmt"] = 0;
                    }
                    else
                        curRow["InsAmt"] = 0;

                    curRow["Total"] = Math.Round(Convert.ToDecimal(curRow["PkgCharges"]) + Convert.ToDecimal(curRow["InsAmt"]), 2);
                }
                //----------------------------------------------
                curRow.EndEdit();
            }
            catch { }       
            //---------------------------------------------
            CalculatColumns();
        }           
        
        void CalculatColumns()
        {
            int totalQty = -1;
            decimal totalWeight = 0, totalInsurance = 0, totalAmount = 0;
            foreach (DataGridViewRow n in DGVBookingOrder.Rows)
            {
                try
                {
                    totalQty += 1;
                    if (n.Cells["itemWeight"].Value != null) { totalWeight += Convert.ToDecimal(n.Cells["itemWeight"].Value); }
                    if (n.Cells["InsAmt"].Value != null) { totalInsurance += Convert.ToDecimal(n.Cells["InsAmt"].Value); }
                    if (n.Cells["Total"].Value != null) { totalAmount += Convert.ToDecimal(n.Cells["Total"].Value); }
                }
                catch { }
            }
            //-------------------------------------------------------------//
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["BookingTotalQty"] = totalQty;
            curRow["BookingTotalWeight"] = totalWeight;
            curRow["BookingTotalInsurance"] = totalInsurance;
            curRow["Total"] = totalAmount;

            curRow.EndEdit();            
            //------------------------------------------------------------//
            this.btnBNMoveFirstItem.Enabled = false;
            this.btnBNMovePreviousItem.Enabled = false;
            //------------------------------------------------------------//
        }
    }
}
