using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QBSync.QuickBooks;
using System.Xml;
using Microsoft.Win32;
using System.Linq;
using System.IO;
using System.Reflection;

namespace QBSync
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            btnCancel.Click += btnCancel_Click;
            btnSynchronizeNow.Click += btnSynchronizeNow_Click;
            btnClose.Click += btnClose_Click;
            btnMinToSystray.Click += btnMinToSystray_Click;
        }
        Timer timer = new Timer();
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Common.ApplicationName + Common.SubVersion;
                if (true)
                {
                    Data.dsQBSync ds = new QBSync.Data.dsQBSync();
                    Data.dsQBSyncTableAdapters.SettingsTableAdapter taSetting = new QBSync.Data.dsQBSyncTableAdapters.SettingsTableAdapter();

                    taSetting.Fill(ds.Settings);
                    if (ds.Settings != null && ds.Settings.Rows.Count > 0)
                    {
                        Common.Settings = ds.Settings[0];

                        timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
                        timer.Interval = (1000) * (60) * (5000); //Common.Settings.SyncTimeInterval              // Timer will tick every second
                        timer.Enabled = true;                       // Enable the timer
                        timer.Start();
                        //this.WindowState = FormWindowState.Minimized;
                    }

                    DateTime dtLastSync = ConfigGet("LastSync");
                    if (dtLastSync > Convert.ToDateTime("1980-01-01"))
                    {
                        lblLastSync.Text = dtLastSync.ToShortDateString() + " " + dtLastSync.ToShortTimeString();
                    }
                    else
                        lblLastSync.Text = "";
                }
                else
                {
                    Application.Exit();
                    //MessageBox.Show("Database file not found!" + System.Environment.NewLine + "Contact Application vendor.", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Common.ExceptionHandler(ex);
            }
        }


        //private void ReadRegistry()
        //{
        //    getUserConnectionString();
        //}

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Common.Settings != null)
                {
                    if (bgWorker.IsBusy != true)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        btnClose.Enabled = false;
                        btnSynchronizeNow.Enabled = false;
                        txtStatus.Text = "";
                        bgWorker.RunWorkerAsync();

                    }
                }
                else
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    Common.ApplicationLog("Application settings are not defined.", "Application settings are not defined.", "System Error");
                }
            }
            catch (Exception ex)
            {
                //pgBar.Visible = false;
                //this.Cursor = System.Windows.Forms.Cursors.Default;
                //Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
                timer.Stop();
                MessageBox.Show(ex.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                timer.Start();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //if (MessageBox.Show("Do you want to close application?", Common.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //    if (System.Windows.Forms.Application.MessageLoop)
                //    {
                //        System.Windows.Forms.Application.Exit();
                //    }
                //    else
                //    {
                //        System.Environment.Exit(0);
                //    }
                //}
            }
            catch (Exception)
            {

            }
        }

        private void btnSynchronizeNow_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.Settings == null)
                {
                    MessageBox.Show("Application settings are not defined.", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (bgWorker.IsBusy != true)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    btnClose.Enabled = false;
                    btnSynchronizeNow.Enabled = false;
                    txtStatus.Text = "";
                    bgWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
                timer.Stop();
                MessageBox.Show(ex.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                timer.Start();
            }
        }

        private Boolean Sync(DoWorkEventArgs e)
        {
            Boolean blnResult = false;
            try
            {
                ConfigSet("LastSync");
                DateTime dtLastSync = ConfigGet("LastSync");
                //lblLastSync.Text = dtLastSync.ToShortDateString() + " " + dtLastSync.ToShortTimeString();

                QBConnection.StartQBSession(Common.Settings.IsQuickBooksFileNull() ? "" : Common.Settings.QuickBooksFile);
                bgWorker.ReportProgress(0, "*********  Syncing Start @ " + DateTime.Now.ToString() + "  *********");

                #region List Items

                //if (chkAccount.Checked)
                //{
                //    DateTime dtLastRun = ConfigGet("AccountQuery");
                //    DateTime dtTo = DateTime.Now;

                //    QuickBooks.Accounts objAccount = new Accounts();

                //    bgWorker.ReportProgress(0, "*********************************************************");
                //    bgWorker.ReportProgress(0, "***************** Exporting Account *******************");

                //    objAccount.AccountQuery(dtLastRun, dtTo, bgWorker);

                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");

                //    ConfigSet("AccountQuery");
                //}

                if (chkListItems.Checked)
                {
                    QuickBooks.General objGeneral = new General();

                    //    bgWorker.ReportProgress(0, "*********************************************************");

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "***************** Exporting Classes *******************");
                    //    DateTime dtLastRun = ConfigGet("ClassQuery");
                    //    objGeneral.ClassQuery(dtLastRun.ToString("s"), bgWorker);
                    //    ConfigSet("ClassQuery");

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "***************** Exporting Sales Rep *****************");
                    //    dtLastRun = ConfigGet("SalesRepQuery");
                    //    objGeneral.SalesRepQuery(dtLastRun.ToString("s"), bgWorker);
                    //    ConfigSet("SalesRepQuery");

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "***************** Exporting Ship Methods ***************");
                    DateTime dtLastRun = ConfigGet("ShipMethodQuery");
                    objGeneral.ShipMethodQuery(dtLastRun.ToString("s"), bgWorker);
                    ConfigSet("ShipMethodQuery");

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "***************** Exporting Payment Methods ***************");
                    //    dtLastRun = ConfigGet("PaymentMethodQuery");
                    //    objGeneral.PaymentMethodQuery(dtLastRun.ToString("s"), bgWorker);
                    //    ConfigSet("PaymentMethodQuery");

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "***************** Exporting Terms *******************");
                    dtLastRun = ConfigGet("TermsQuery");
                    objGeneral.TermsQuery(dtLastRun.ToString("s"), bgWorker);
                    ConfigSet("TermsQuery");

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "***************** Exporting Sales Tax Codes *******************");
                    //    dtLastRun = ConfigGet("SalesTaxCodeQuery");
                    //    objGeneral.SalesTaxCodeQuery(dtLastRun.ToString("s"), bgWorker);
                    //    ConfigSet("SalesTaxCodeQuery");

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "*********************************************************");


                }



                //if (chkVendor.Checked)
                //{
                //    DateTime dtLastRun = ConfigGet("VendorQuery");
                //    DateTime dtTo = DateTime.Now;

                //    QuickBooks.Vendors objVendor = new Vendors();

                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");
                //    bgWorker.ReportProgress(0, "***************** Exporting Vendor *******************");

                //    objVendor.VendorQuery(dtLastRun, dtTo, bgWorker);

                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");

                //    ConfigSet("VendorQuery");
                //}

                #endregion

                #region Sales Order

                if (chkSalesOrder.Checked)
                {
                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    QuickBooks.SalesOrder objSalesOrder = new SalesOrder();

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    //Data.dsQBSyncTableAdapters.OrdersTableAdapter taOrder = new Data.dsQBSyncTableAdapters.OrdersTableAdapter();


                    //DateTime dtLastRun = ConfigGet("SalesOrderQuery");
                    //DateTime dtTo = DateTime.Now;

                    //bgWorker.ReportProgress(0, "***************** Importing Sales Order *******************");

                    //taOrder.FillUnposted(ds.Orders);
                    //foreach (Data.dsQBSync.OrdersRow orderRow in ds.Orders)
                    //{
                    //    string TxnId = orderRow.IsTxnIDNull() ? "" : orderRow.TxnID;

                    //    string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                    //    if (orderRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                    //    if (orderRow.IsCustomerFullNameNull() == false) invoiceDescription += " Customer: " + orderRow.CustomerFullName;

                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, invoiceDescription);

                    //    objSalesOrder.AddSalesOrder(orderRow, TxnId, bgWorker);

                    //    System.Threading.Thread.Sleep(30);
                    //    if (bgWorker.CancellationPending)
                    //    {
                    //        e.Cancel = true;
                    //        return blnResult;
                    //    }
                    //}

                    //if (ds.Orders.Count() == 0)
                    //{
                    //    bgWorker.ReportProgress(0, "");
                    //    bgWorker.ReportProgress(0, "There is no record to import");
                    //}

                    //bgWorker.ReportProgress(0, "*********************************************************");
                    //bgWorker.ReportProgress(0, "***************** Exporting SalesOrder *******************");

                    //objSalesOrder.SalesOrderQuery(dtLastRun, dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("SalesOrderQuery");

                }

                #endregion

                #region Items Group Type

                if (chkItemsGroupType.Checked)
                {
                    Data.dsQBSyncTableAdapters.ItemGroupTypeTableAdapter taItemGroupType = new Data.dsQBSyncTableAdapters.ItemGroupTypeTableAdapter();

                    DateTime dtLastRun = ConfigGet("ItemQuery");
                    DateTime dtTo = DateTime.Now;

                    QuickBooks.Items objItemGroupType = new Items();

                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "***************** Exporting Item Group Type *******************");

                    //objItemGroupType.ItemQuery(dtLastRun.AddMinutes(-1), dtTo, bgWorker);
                    //objItem.InventoryQuery(dtLastRun.AddHours(-1), dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("ItemQuery");

                    bgWorker.ReportProgress(0, "***************** Importing Item Group Types *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.ItemGroupType.Clear();

                    taItemGroupType.FillUpPostedItemGroupTypes(ds.ItemGroupType);
                    foreach (Data.dsQBSync.ItemGroupTypeRow itemGroupTypeRow in ds.ItemGroupType)
                    {
                        string ListId = itemGroupTypeRow.IsListIDNull() ? "" : itemGroupTypeRow.ListID;

                        objItemGroupType.AddItemGroupType(itemGroupTypeRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.ItemGroupType.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }
                }

                #endregion

                #region Items Type

                if (chkItemsType.Checked)
                {
                    Data.dsQBSyncTableAdapters.ItemTypeTableAdapter taItemType = new Data.dsQBSyncTableAdapters.ItemTypeTableAdapter();

                    DateTime dtLastRun = ConfigGet("ItemQuery");
                    DateTime dtTo = DateTime.Now;

                    QuickBooks.Items objItemType = new Items();

                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "***************** Exporting Item Type *******************");

                    //objItemType.ItemQuery(dtLastRun.AddMinutes(-1), dtTo, bgWorker);
                    //objItem.InventoryQuery(dtLastRun.AddHours(-1), dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("ItemQuery");

                    bgWorker.ReportProgress(0, "***************** Importing Item Types *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.ItemType.Clear();

                    taItemType.FillUnPostedItemTypes(ds.ItemType);
                    foreach (Data.dsQBSync.ItemTypeRow ItemTypeRow in ds.ItemType)
                    {
                        string ListId = ItemTypeRow.IsListIDNull() ? "" : ItemTypeRow.ListID;

                        objItemType.AddItemType(ItemTypeRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.ItemType.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }
                }

                #endregion

                #region Items

                if (chkItems.Checked)
                {
                    Data.dsQBSyncTableAdapters.ItemTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemTableAdapter();

                    DateTime dtLastRun = ConfigGet("ItemQuery");
                    DateTime dtTo = DateTime.Now;

                    QuickBooks.Items objItem = new Items();

                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "***************** Exporting Item *******************");

                    //objItem.ItemQuery(dtLastRun.AddMinutes(-1), dtTo, bgWorker);
                    //objItem.InventoryQuery(dtLastRun.AddHours(-1), dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("ItemQuery");

                    bgWorker.ReportProgress(0, "***************** Importing Item *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.Item.Clear();

                    taItem.FillUnPostedItems(ds.Item);
                    foreach (Data.dsQBSync.ItemRow ItemRow in ds.Item)
                    {
                        string ListId = ItemRow.IsListIDNull() ? "" : ItemRow.ListID;

                        objItem.AddItem(ItemRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.Item.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }
                }

                #endregion

                #region Customer

                if (chkCustomer.Checked)
                {

                    Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();

                    QuickBooks.Customers objCustomer = new Customers();

                    DateTime dtLastRun = ConfigGet("CustomerQuery");
                    DateTime dtTo = DateTime.Now;

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "***************** Exporting Customer *******************");

                    objCustomer.CustomerQuery(dtLastRun, dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("CustomerQuery");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    bgWorker.ReportProgress(0, "***************** Importing Customers *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.Customer.Clear();

                    taCustomer.FillUnPosted(ds.Customer);
                    foreach (Data.dsQBSync.CustomerRow CustomerRow in ds.Customer)
                    {
                        string ListId = CustomerRow.IsListIDNull() ? "" : CustomerRow.ListID;

                        //string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                        //if (CustomerRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                        //if (CustomerRow.IsCustomerFullNameNull() == false) invoiceDescription += " Customer: " + orderRow.CustomerFullName;

                        //bgWorker.ReportProgress(0, "");
                        //bgWorker.ReportProgress(0, invoiceDescription);

                        objCustomer.AddCustomer(CustomerRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.Customer.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }

                    //DateTime dtLastRun = ConfigGet("CustomerQuery");
                    //DateTime dtTo = DateTime.Now;

                    // QuickBooks.Customers objCustomer = new Customers();


                }

                #endregion

                #region Vendor

                if (chkVendor.Checked)
                {

                    Data.dsQBSyncTableAdapters.VendorTableAdapter taVendor = new Data.dsQBSyncTableAdapters.VendorTableAdapter();

                    QuickBooks.Vendors objVendor = new Vendors();

                    DateTime dtLastRun = ConfigGet("VendorQuery");
                    DateTime dtTo = DateTime.Now;

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "***************** Exporting Vendor *******************");

                    objVendor.VendorQuery(dtLastRun, dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("VendorQuery");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    bgWorker.ReportProgress(0, "***************** Importing Vendors *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.Vendor.Clear();

                    taVendor.FillUnPosted(ds.Vendor);
                    foreach (Data.dsQBSync.VendorRow VendorRow in ds.Vendor)
                    {
                        string ListId = VendorRow.IsListIDNull() ? "" : VendorRow.ListID;

                        //string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                        //if (VendorRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                        //if (VendorRow.IsVendorFullNameNull() == false) invoiceDescription += " Vendor: " + orderRow.VendorFullName;

                        //bgWorker.ReportProgress(0, "");
                        //bgWorker.ReportProgress(0, invoiceDescription);

                        objVendor.AddVendor(VendorRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.Vendor.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }

                    //DateTime dtLastRun = ConfigGet("VendorQuery");
                    //DateTime dtTo = DateTime.Now;

                    // QuickBooks.Vendors objVendor = new Vendors();


                }

                #endregion

                #region VendorBills

                if (chkVendorBills.Checked)
                {

                    Data.dsQBSyncTableAdapters.VendorBillTableAdapter taVendorbill = new Data.dsQBSyncTableAdapters.VendorBillTableAdapter();

                    QuickBooks.Bill objVendorBill = new Bill();

                    DateTime dtLastRun = ConfigGet("VendorBillQuery");
                    DateTime dtTo = DateTime.Now;

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");
                    //bgWorker.ReportProgress(0, "***************** Exporting Vendor bill *******************");

                    //objVendor.VendorQuery(dtLastRun, dtTo, bgWorker);

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //ConfigSet("VendorBillQuery");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    bgWorker.ReportProgress(0, "***************** Importing Vendor Bills*******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.VendorBill.Clear();

                    taVendorbill.FillUnPostedVendorBills(ds.VendorBill);
                    foreach (Data.dsQBSync.VendorBillRow VendorBillRow in ds.VendorBill)
                    {
                        string ListId = VendorBillRow.IsListIDNull() ? "" : VendorBillRow.ListID;

                        //string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                        //if (VendorRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                        //if (VendorRow.IsVendorFullNameNull() == false) invoiceDescription += " Vendor: " + orderRow.VendorFullName;

                        //bgWorker.ReportProgress(0, "");
                        //bgWorker.ReportProgress(0, invoiceDescription);

                        objVendorBill.AddBill(VendorBillRow, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.VendorBill.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }

                    //DateTime dtLastRun = ConfigGet("VendorQuery");
                    //DateTime dtTo = DateTime.Now;

                    // QuickBooks.Vendors objVendor = new Vendors();


                }

                #endregion

                #region VendorPayments

                if (chkVendorPayments.Checked)
                {

                    Data.dsQBSyncTableAdapters.VendorPaymentHistoryTableAdapter taVendorPayments = new Data.dsQBSyncTableAdapters.VendorPaymentHistoryTableAdapter();

                    QuickBooks.BillPayments objVendorPayments = new BillPayments();

                    DateTime dtLastRun = ConfigGet("VendorPaymentQuery");
                    DateTime dtTo = DateTime.Now;

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");
                    //bgWorker.ReportProgress(0, "***************** Exporting Vendor Payments *******************");

                    //objVendor.VendorQuery(dtLastRun, dtTo, bgWorker);

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //ConfigSet("VendorBillQuery");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    bgWorker.ReportProgress(0, "***************** Importing Vendor Payments*******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.VendorPaymentHistory.Clear();

                    taVendorPayments.FillByUnPostedVendorPayments(ds.VendorPaymentHistory);
                    foreach (Data.dsQBSync.VendorPaymentHistoryRow VendorPaymentRow in ds.VendorPaymentHistory)
                    {
                        string ListId = VendorPaymentRow.IsListIDNull() ? "" : VendorPaymentRow.ListID;

                        //string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                        //if (VendorRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                        //if (VendorRow.IsVendorFullNameNull() == false) invoiceDescription += " Vendor: " + orderRow.VendorFullName;

                        //bgWorker.ReportProgress(0, "");
                        //bgWorker.ReportProgress(0, invoiceDescription);

                        objVendorPayments.AddBillPaymentCheck(VendorPaymentRow, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.VendorPaymentHistory.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }

                }

                #endregion

                #region Invoice

                if (chkInvoices.Checked)
                {
                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    QuickBooks.Invoices objInvoice = new Invoices();
                    Data.dsQBSyncTableAdapters.WorkOrderTableAdapter taWorkOrder = new Data.dsQBSyncTableAdapters.WorkOrderTableAdapter();

                    DateTime dtLastRun = ConfigGet("InvoiceQuery");
                    DateTime dtTo = DateTime.Now;

                    //bgWorker.ReportProgress(0, "***************** Exporting Invoices *******************");

                    //objInvoice.InvoiceQuery(dtLastRun, dtTo, bgWorker);

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //ConfigSet("InvoiceQuery");

                    bgWorker.ReportProgress(0, "***************** Importing Invoices *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.WorkOrder.Clear();

                    taWorkOrder.FillByUnPostedWO(ds.WorkOrder);
                    foreach (Data.dsQBSync.WorkOrderRow WorkOrderRow in ds.WorkOrder)
                    {
                        string ListId = WorkOrderRow.IsListIDNull() ? "" : WorkOrderRow.ListID;

                        //string invoiceDescription = "SalesOrder # " + (string.IsNullOrEmpty(orderRow.IsRefNumberNull() ? "" : orderRow.RefNumber) ? orderRow.OrderID.ToString() : orderRow.RefNumber);

                        //if (VendorRow.IsTxnDateNull() == false) invoiceDescription += " Date: " + orderRow.TxnDate.ToShortDateString();
                        //if (VendorRow.IsVendorFullNameNull() == false) invoiceDescription += " Vendor: " + orderRow.VendorFullName;

                        //bgWorker.ReportProgress(0, "");
                        //bgWorker.ReportProgress(0, invoiceDescription);

                        objInvoice.AddInvoice(WorkOrderRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.WorkOrder.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }
                    ConfigSet("InvoiceQuery");

                }

                //    bgWorker.ReportProgress(0, "***************** Importing Invoices *******************");

                //    using (QBSyncWebService service = new QBSyncWebService())
                //    {
                //        int startPage = 1;
                //        int NoOfRecords = 100; bool blnRecords = false;

                //        while (NoOfRecords > 0)
                //        {
                //            var lstInvoices = service.GetInvoicesUnsync(Common.BranchID == 1 ? 0 : Common.BranchID, startPage, NoOfRecords);

                //            if (lstInvoices.Count() > 0)
                //            {
                //                blnRecords = true;
                //                foreach (QBSyncDataService.MdlInvoice mdlInvoice in lstInvoices)
                //                {
                //                    string TxnId = Common.BranchID == 1 ? mdlInvoice.TxnID : mdlInvoice.BRTxnID;

                //                    string invoiceDescription = "Invoice # " + (string.IsNullOrEmpty(mdlInvoice.RefNumber) ? mdlInvoice.InvoiceID.ToString() : mdlInvoice.RefNumber);

                //                    invoiceDescription += " Date: " + mdlInvoice.TxnDate.ToShortDateString();
                //                    invoiceDescription += " Customer: " + mdlInvoice.CustomerFullName;

                //                    if (mdlInvoice.InvoiceStatus == 1)
                //                    {
                //                        bgWorker.ReportProgress(0, "");
                //                        bgWorker.ReportProgress(0, invoiceDescription);

                //                        objInvoice.AddInvoice(mdlInvoice, Common.BranchID == 1 ? mdlInvoice.TxnID : mdlInvoice.BRTxnID, bgWorker);
                //                    }
                //                    else if (mdlInvoice.InvoiceStatus == 0 && !string.IsNullOrEmpty(TxnId))
                //                    {
                //                        bgWorker.ReportProgress(0, "");
                //                        bgWorker.ReportProgress(0, invoiceDescription);

                //                        grnl.DeleteTransaction("Invoice", TxnId, bgWorker, mdlInvoice.InvoiceID);
                //                    }

                //                    System.Threading.Thread.Sleep(30);
                //                    if (bgWorker.CancellationPending)
                //                    {
                //                        e.Cancel = true;
                //                        return blnResult;
                //                    }
                //                }

                //                startPage++;
                //            }
                //            else
                //                NoOfRecords = 0;

                //            System.Threading.Thread.Sleep(50);
                //            if (bgWorker.CancellationPending)
                //            {
                //                e.Cancel = true;
                //                return blnResult;
                //            }
                //        }

                //        if (blnRecords == false)
                //        {
                //            bgWorker.ReportProgress(0, "");
                //            bgWorker.ReportProgress(0, "There is no record to import");
                //        }
                //    }

                //    {
                //        DateTime dtLastRun = ConfigGet("InvoiceDeletedQuery");
                //        grnl.GetDeletedRecords("Invoice", dtLastRun.ToString("s"), bgWorker);
                //        ConfigSet("InvoiceDeletedQuery");
                //    }

                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");

                //}

                #endregion

                #region InvoicePayment

                if (chkInvoicePayment.Checked)
                {
                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    QuickBooks.ReceivePayments objPayments = new ReceivePayments();
                    Data.dsQBSyncTableAdapters.CustomerReceiptTableAdapter taCustomerReceipt = new Data.dsQBSyncTableAdapters.CustomerReceiptTableAdapter();

                    DateTime dtLastRun = ConfigGet("ReceivePaymentQuery");
                    DateTime dtTo = DateTime.Now;

                    //bgWorker.ReportProgress(0, "***************** Exporting Invoices *******************");

                    //objInvoice.InvoiceQuery(dtLastRun, dtTo, bgWorker);

                    //bgWorker.ReportProgress(0, "");
                    //bgWorker.ReportProgress(0, "*********************************************************");

                    //ConfigSet("InvoiceQuery");

                    bgWorker.ReportProgress(0, "***************** Importing Invoice Payments *******************");

                    Data.dsQBSync ds = new Data.dsQBSync();
                    ds.EnforceConstraints = false;
                    ds.CustomerReceipt.Clear();

                    taCustomerReceipt.FillUnPostedRecepits(ds.CustomerReceipt);
                    foreach (Data.dsQBSync.CustomerReceiptRow CustomerReceiptRow in ds.CustomerReceipt)
                    {
                        string ListId = CustomerReceiptRow.IsListIDNull() ? "" : CustomerReceiptRow.ListID;

                        objPayments.AddReceivePayment(CustomerReceiptRow, ListId, bgWorker);

                        System.Threading.Thread.Sleep(30);
                        if (bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return blnResult;
                        }
                    }

                    if (ds.CustomerReceipt.Count() == 0)
                    {
                        bgWorker.ReportProgress(0, "");
                        bgWorker.ReportProgress(0, "There is no record to import");
                    }
                    ConfigSet("ReceivePaymentQuery");

                }

                #endregion

                #region CreditMemo

                if (chkCreditMemo.Checked)
                {
                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    QuickBooks.CreditMemo objCreditMemo = new CreditMemo();


                    DateTime dtLastRun = ConfigGet("CreditMemoQuery");
                    DateTime dtTo = DateTime.Now;

                    bgWorker.ReportProgress(0, "***************** Exporting CreditMemos *******************");

                    objCreditMemo.CreditMemoQuery(dtLastRun, dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("CreditMemoQuery");
                }

                #endregion

                #region ReceivePayments

                //if (chkReceivePayment.Checked)
                //{
                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");

                //    QuickBooks.General grnl = new General();
                //    QuickBooks.ReceivePayments objPayments = new ReceivePayments();

                //    if (Common.BranchID > 1)
                //    {
                //        DateTime dtLastRun = ConfigGet("ReceivePaymentQuery");
                //        DateTime dtTo = DateTime.Now;

                //        bgWorker.ReportProgress(0, "************** Exporting Customer Payment ***************");

                //        objPayments.ReceivePaymentQuery(dtLastRun, dtTo, bgWorker);

                //        bgWorker.ReportProgress(0, "");
                //        bgWorker.ReportProgress(0, "*********************************************************");

                //        ConfigSet("ReceivePaymentQuery");
                //    }

                //    bgWorker.ReportProgress(0, "************* Importing Customer Payment ****************");

                //    using (QBSyncWebService service = new QBSyncWebService())
                //    {
                //        int startPage = 1;
                //        int NoOfRecords = 100; bool blnRecords = false;

                //        while (NoOfRecords > 0)
                //        {
                //            var lstReceivePayments = service.GetReceivePaymentsUnsync(Common.BranchID == 1 ? 0 : Common.BranchID, startPage, NoOfRecords);

                //            if (lstReceivePayments.Count() > 0)
                //            {
                //                blnRecords = true;
                //                foreach (QBSyncDataService.MdlReceivePayments mdlReceivePayment in lstReceivePayments)
                //                {
                //                    string TxnId = Common.BranchID == 1 ? mdlReceivePayment.TxnID : mdlReceivePayment.BRTxnID;

                //                    string ReceivePaymentDescription = "Payment Amt. " + mdlReceivePayment.TotalAmount;

                //                    if (!string.IsNullOrEmpty(mdlReceivePayment.RefNumber))
                //                        ReceivePaymentDescription += " Ref# " + mdlReceivePayment.RefNumber;

                //                    ReceivePaymentDescription += " Date: " + mdlReceivePayment.TxnDate.ToShortDateString();
                //                    ReceivePaymentDescription += " Customer: " + mdlReceivePayment.CustomerFullName;

                //                    if (mdlReceivePayment.PaymentStatus == 1)
                //                    {
                //                        bgWorker.ReportProgress(0, "");
                //                        bgWorker.ReportProgress(0, ReceivePaymentDescription);

                //                        objPayments.AddReceivePayment(mdlReceivePayment, Common.BranchID == 1 ? mdlReceivePayment.TxnID : mdlReceivePayment.BRTxnID, bgWorker);
                //                    }
                //                    else if (mdlReceivePayment.PaymentStatus == 0 && !string.IsNullOrEmpty(TxnId))
                //                    {
                //                        bgWorker.ReportProgress(0, "");
                //                        bgWorker.ReportProgress(0, ReceivePaymentDescription);

                //                        grnl.DeleteTransaction("ReceivePayment", TxnId, bgWorker, mdlReceivePayment.ReceivePaymentID);
                //                    }

                //                    System.Threading.Thread.Sleep(30);
                //                    if (bgWorker.CancellationPending)
                //                    {
                //                        e.Cancel = true;
                //                        return blnResult;
                //                    }
                //                }

                //                startPage++;
                //            }
                //            else
                //                NoOfRecords = 0;

                //            System.Threading.Thread.Sleep(50);
                //            if (bgWorker.CancellationPending)
                //            {
                //                e.Cancel = true;
                //                return blnResult;
                //            }
                //        }

                //        if (blnRecords == false)
                //        {
                //            bgWorker.ReportProgress(0, "");
                //            bgWorker.ReportProgress(0, "There is no record to import");
                //        }
                //    }

                //    {
                //        DateTime dtLastRun = ConfigGet("ReceivePaymentDeletedQuery");
                //        grnl.GetDeletedRecords("ReceivePayment", dtLastRun.ToString("s"), bgWorker);
                //        ConfigSet("ReceivePaymentDeletedQuery");
                //    }

                //    //After Payments Updating Invoices Balance
                //    if (Common.BranchID > 1)
                //    {
                //        DateTime dtLastRun = ConfigGet("InvoiceQuery");
                //        DateTime dtTo = DateTime.Now;

                //        bgWorker.ReportProgress(0, "");
                //        QuickBooks.Invoices objInvoice = new Invoices();
                //        objInvoice.InvoiceQuery(dtLastRun, dtTo, bgWorker);

                //        ConfigSet("InvoiceQuery");
                //    }

                //    bgWorker.ReportProgress(0, "");
                //    bgWorker.ReportProgress(0, "*********************************************************");

                //}

                //if (Common.BranchID > 1)
                //{
                //    if (chkInvoices.Checked || chkReceivePayment.Checked)
                //    {
                //        DateTime dtLastRun = ConfigGet("CustomerQuery");
                //        DateTime dtTo = DateTime.Now;

                //        QuickBooks.Customers objCustomer = new Customers();

                //        bgWorker.ReportProgress(0, "");

                //        objCustomer.CustomerQuery(dtLastRun, dtTo, bgWorker);

                //        ConfigSet("CustomerQuery");
                //    }
                //}

                #endregion

                #region PurchaseOrder

                if (chkPO.Checked)
                {
                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    QuickBooks.PurchaseOrders objPurchaseOrder = new PurchaseOrders();


                    DateTime dtLastRun = ConfigGet("PurchaseOrderQuery");
                    DateTime dtTo = DateTime.Now;

                    bgWorker.ReportProgress(0, "***************** Exporting Purchase Orders *******************");

                    objPurchaseOrder.PurchaseOrderQuery(dtLastRun, dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    ConfigSet("PurchaseOrderQuery");
                }

                #endregion

                if (chkItemUpdateDD.Checked)
                {
                    DateTime dtLastRun = ConfigGet("ItemQuery");
                    DateTime dtTo = DateTime.Now;

                    QuickBooks.Items objItem = new Items();

                    bgWorker.ReportProgress(0, "*********************************************************");
                    bgWorker.ReportProgress(0, "******* Updating Item Next Delivery Date ****************");

                    objItem.ItemStockReport(dtLastRun.AddMinutes(-1), dtTo, bgWorker);

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                    //ConfigSet("ItemQuery");
                }

                if (chkSalesOrder.Checked || chkInvoices.Checked || chkCreditMemo.Checked)
                {
                    QuickBooks.General grnl = new General();
                    DateTime dtLastRunDelete = ConfigGet("DeletedQuery");
                    grnl.GetDeletedRecords(dtLastRunDelete.ToString("s"), bgWorker);
                    ConfigSet("DeletedQuery");

                    bgWorker.ReportProgress(0, "");
                    bgWorker.ReportProgress(0, "*********************************************************");

                }


                ConfigSet("LastSync");
                dtLastSync = ConfigGet("LastSync");

                QBConnection.EndQBSession();
                bgWorker.ReportProgress(0, "");
                bgWorker.ReportProgress(0, "*******  Syncing Completed  @ " + DateTime.Now.ToString() + "  *******");

            }
            catch (Exception ex)
            {
                blnResult = false;
                QBConnection.EndQBSession();
                timer.Stop();
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
                bgWorker.ReportProgress(0, "********  Application Sync Error  ********");
                bgWorker.ReportProgress(0, ex.Message);
                timer.Start();
            }
            return blnResult;
        }

        public DateTime ConfigGet(string strKey)
        {
            DateTime dtDatetime = default(DateTime);

            Data.dsQBSync ds = new QBSync.Data.dsQBSync();
            Data.dsQBSyncTableAdapters.QBConfigTableAdapter taConfig = new QBSync.Data.dsQBSyncTableAdapters.QBConfigTableAdapter();
            taConfig.Fill(ds.QBConfig, strKey);
            if (ds.QBConfig.Rows.Count > 0)
            {
                var cnfg = ds.QBConfig[0];
                dtDatetime = Convert.ToDateTime((cnfg.IsConfig_valueNull() ? (Common.Settings.IsSyncStartDateNull() ? Convert.ToDateTime("1998-01-01") : Common.Settings.SyncStartDate) : cnfg.Config_value));

                //dtDatetime = Common.Settings.IsSyncStartDateNull() ? Convert.ToDateTime("0000-01-01") : Common.Settings.SyncStartDate;
            }
            else
            {
                dtDatetime = Common.Settings.IsSyncStartDateNull() ? Convert.ToDateTime("0000-01-01") : Common.Settings.SyncStartDate;
            }

            return dtDatetime;//.ToString("s");
        }

        public void ConfigSet(string strKey)
        {
            Data.dsQBSync ds = new QBSync.Data.dsQBSync();
            Data.dsQBSyncTableAdapters.QBConfigTableAdapter taConfig = new QBSync.Data.dsQBSyncTableAdapters.QBConfigTableAdapter();
            taConfig.Fill(ds.QBConfig, strKey);
            if (ds.QBConfig.Rows.Count > 0)
            {
                var cnfg = ds.QBConfig[0];
                cnfg.Config_value = DateTime.Now;
                taConfig.Update(cnfg);
            }
            else
            {
                var cnfg = ds.QBConfig.NewQBConfigRow();
                cnfg.Config_key = strKey;
                cnfg.Config_value = DateTime.Now;
                ds.QBConfig.AddQBConfigRow(cnfg);
                taConfig.Update(cnfg);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmApplicationLog frm = new frmApplicationLog();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    if (MessageBox.Show("Do you want to close application?", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        Environment.Exit(0);
            //        Application.Exit();
            //    }
            //    else
            //        e.Cancel = true;
            //}
            //catch (Exception ex)
            //{
            //    Common.ExceptionHandler(ex);
            //}
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to close application?", Common.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
                }
            }
            catch (Exception)
            {
                //Common.ExceptionHandler(ex);
            }
        }

        private void btnMinToSystray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                //QBConnection.StartQBSession(company.IsQuickBooksFileNull() ? "" : company.QuickBooksFile);

                Sync(e);

                //QBConnection.EndQBSession();

            }
            catch (Exception ex)
            {
                //QBConnection.EndQBSession();
                e.Cancel = true;
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (txtStatus.Text.Length > 32000)
                    txtStatus.Text = (string)e.UserState + System.Environment.NewLine;
                else
                    txtStatus.Text += (string)e.UserState + System.Environment.NewLine;

                txtStatus.Focus();
                txtStatus.SelectionStart = txtStatus.Text.Length;
                txtStatus.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Common.ExceptionHandler(ex);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    btnClose.Enabled = true;
                    btnSynchronizeNow.Enabled = true;

                    if (e.Cancelled)
                    {
                        timer.Stop();
                        MessageBox.Show("Export has been cancelled!", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        timer.Start();
                    }
                    else if (e.Error != null)
                    {
                        timer.Stop();
                        MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        timer.Stop();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //MessageBox.Show("Exported successfully!", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgWorker.CancelAsync();
        }
    }
}
