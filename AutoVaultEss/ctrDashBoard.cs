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
using System32;
using AppControls;
using System.Globalization;
using System.Diagnostics;

namespace AutoVaultEss
{
    public partial class ctrDashBoard : UserControl
    {
        MainDataSet objDataSet = new MainDataSet(); 
        ControlLibrary.MessageBox xMessageBox = null; 
        TimeSpan MorningStart = new TimeSpan(0, 0, 1);
        TimeSpan MorningEnd = new TimeSpan(11, 59, 59);
        TimeSpan Noon = new TimeSpan(12, 0, 0);
        TimeSpan AfternoonStart = new TimeSpan(12, 0, 1);
        TimeSpan AfternoonEnd = new TimeSpan(16, 30, 0);
        TimeSpan EveningStart = new TimeSpan(16, 30, 1);
        TimeSpan EveningEnd = new TimeSpan(19, 0, 0);
        TimeSpan NightStart = new TimeSpan(19, 0, 1);
        TimeSpan NightEnd = new TimeSpan(23, 59, 59);

        public ctrDashBoard()
        {
            InitializeComponent();
            //ChecknewOrders();
            this.BackColor = StaticInfo.ctrBackColor;
            xMessageBox = new ControlLibrary.MessageBox();
            //btnUserRights.Click += btnCatalogPackages_Click;
            btnWarehouse.Click += btnWarehouse_Click;
            btnWarehouseActivities.Click += btnWarehouseActivities_Click;
            btnEmployee.Click += btnEmployee_Click;
            btnEmployeeWorkLoad.Click += btnEmployeeWorkLoad_Click;
            btnItems.Click += btnItems_Click;
            btnItemsInventory.Click += btnItemsInventory_Click;
            btnVendors.Click += btnVendors_Click;
            btnVendorsPayables.Click += btnVendorsPayables_Click;
            btnVehicles.Click += btnVehicles_Click;
            btnVehiclesSchedules.Click += btnVehiclesSchedules_Click;
            btnCustomers.Click += btnCustomers_Click;
            btnCustomersReceivables.Click += btnCustomersReceivables_Click;
            btnAccounts.Click += btnAccounts_Click;
            btnAccountsTransactions.Click += btnAccountsTransactions_Click;
            btnReports.Click += btnReports_Click;
            lblCopyrights.Text = "Developed by Enterprise Software Solutions"+Environment.NewLine+"Email: info@esspk.com";
            lblCopyrights.ForeColor = Color.White;
            lblCopyrights.BackColor = Color.Transparent;

            this.btnSaleReports.Click += btnSaleReports_Click;
            this.btnPurchaseReports.Click += btnPurchaseReports_Click;
            this.btnInventoryReports.Click += btnInventoryReports_Click;
            this.btnListReports.Click += btnListReports_Click;
            this.btnAccountsReports.Click += btnAccountsReports_Click;
            this.btnSetting.Click += btnSetting_Click;

            this.btnLogout.MouseLeave += new System.EventHandler(this.btnLogout_MouseLeave);
            this.btnLogout.MouseHover += new System.EventHandler(this.btnLogout_MouseHover);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.saleTaxRatesToolStripMenuItem.Click += new System.EventHandler(this.saleTaxRatesToolStripMenuItem_Click);
            this.saleCategoriesToolStripMenuItem.Click += new System.EventHandler(this.saleCategoriesToolStripMenuItem_Click);
            this.referredByToolStripMenuItem.Click += new System.EventHandler(this.referredByToolStripMenuItem_Click);
            this.shippingMethodsToolStripMenuItem.Click += new System.EventHandler(this.shippingMethodsToolStripMenuItem_Click);
            this.termsToolStripMenuItem.Click += new System.EventHandler(this.termsToolStripMenuItem_Click);
            this.itemGroupToolStripMenuItem.Click += new System.EventHandler(this.itemGroupToolStripMenuItem_Click);
            this.priceLevelsToolStripMenuItem.Click += new System.EventHandler(this.priceLevelsToolStripMenuItem_Click);
            this.itemTypesToolStripMenuItem.Click += new System.EventHandler(this.itemTypesToolStripMenuItem_Click);
            this.oilViscositiesToolStripMenuItem.Click += new System.EventHandler(this.oilViscositiesToolStripMenuItem_Click);
            this.bankAccountsToolStripMenuItem1.Click += new System.EventHandler(this.bankAccountsToolStripMenuItem1_Click);
            this.systemSettingsToolStripMenuItem1.Click += new System.EventHandler(this.systemSettingsToolStripMenuItem1_Click);
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            this.utilitiesToolStripMenuItem1.Click += new System.EventHandler(this.utilitiesToolStripMenuItem1_Click);
            this.themesToolStripMenuItem1.Click += new System.EventHandler(this.themesToolStripMenuItem1_Click);
            this.btnSetting.MouseLeave += new System.EventHandler(this.btnSetting_MouseLeave);
            this.btnSetting.MouseHover += new System.EventHandler(this.btnSetting_MouseHover);
            this.btnPurchaseOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPurchaseOrder_LinkClicked);
            this.btnVendorDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorBillsList_LinkClicked);
            this.btnVendorPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorPayment_LinkClicked);
            this.btnVoidPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorBill_LinkClicked);

            
            this.btnVendorPaymentHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorPaymentHistory_LinkClicked);
            this.btnWorkOrders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnWorkOrders_LinkClicked);
            this.btnReportHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCustomerInvoice_LinkClicked);
            this.btnNewWorkorder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnNewWorkorder_LinkClicked);
            this.btnTodayReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnTodayReport_LinkClicked);
            this.btnReportHistory.LinkClicked +=new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnReportHistory_LinkClicked);

            this.btnUserRights.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUserRights_LinkClicked);
            this.btnCustomerTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCustomerTransactions_LinkClicked);
            this.btnItemStock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnItemStock_LinkClicked);
            //this.btnUserRights.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnInventoryAdjustment_LinkClicked);
            this.btnAddNewItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddNewItem_LinkClicked);
            this.btnPrintLableBarcode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPrintLableBarcode_LinkClicked);
            this.btnItemAlternates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnItemAlternates_LinkClicked);
            this.btnCashPaymentVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCashPaymentVoucher_LinkClicked);
            this.btnBankPaymentVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBankPaymentVoucher_LinkClicked);
            this.btnCashReciptVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCashReciptVoucher_LinkClicked);
            this.btnBankReciptVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBankReciptVoucher_LinkClicked);
            this.btnGeneralJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnGeneralJournal_LinkClicked);
            this.Load += new System.EventHandler(this.ctrSaleDashBoard_Load);


            //----------------------------------------------------------------//
            //sales1ToolStripMenuItem.Text = "Sale Tax Rates";
            //sales2ToolStripMenuItem.Text = "Sale Categories";
            //sales3ToolStripMenuItem.Text = "Referred By";
            //sales4ToolStripMenuItem.Text = "shipping Methods";
            //sales5ToolStripMenuItem.Text = "Terms";
            ////------------------------------------//            
            //inventory1ToolStripMenuItem.Text = "Item Group";
            //inventory2ToolStripMenuItem.Text = "Price Levels";
            //inventory3ToolStripMenuItem.Text = "Item Types";
            //inventory4ToolStripMenuItem.Text = "Oil-Viscosities";
            //inventory5ToolStripMenuItem.Text = "Manufacturers";
            ////------------------------------------//
            //accounting1ToolStripMenuItem.Text = "General Ledger";
            //accounting2ToolStripMenuItem.Text = "Bank Accounts";
            //accounting3ToolStripMenuItem.Text = "Company Credit Cards";
            ////------------------------------------//
            //general1ToolStripMenuItem.Text = "System Settings";
            //general2ToolStripMenuItem.Text = "Employees";
            //general3ToolStripMenuItem.Text = "Utilities";
            //general4ToolStripMenuItem.Text = "Themes";
            //general5ToolStripMenuItem.Text = "Users Logged In";
            //----------------------------------------------------------------//

        }

        private void aboutStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://mysite.com/");
            Process.Start(sInfo);
        }

        private void btnAddNewItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemDefination", "Item Defination", 0);
        }

        int SelectedCustomerID = 0;
        private void btnNewWorkorder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New WorkOrder", 0);
            //ctrWorkOrder objWorkOrder = new ctrWorkOrder(1, this.SelectedCustomerID);
            //frmCtr frmCtr = new frmCtr("New WorkOrder");
            //frmCtr.Height = objWorkOrder.Height + 20; frmCtr.Width = objWorkOrder.Width + 20;
            //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //frmCtr.frmPnl.Controls.Add(objWorkOrder);
            //frmCtr.BringToFront();
            //frmCtr.ShowDialog();
        }

        private void btnReportHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale List", 0);
        }

        private void btnTodayReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string SelectSaleDate = Convert.ToDateTime(DateTime.Now.ToString(), CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");

            ctrDailySummary.date = SelectSaleDate;
            DataTable dtM = new DataTable();
            ctrDailySummary.dtm = dbClass.obj.tblMasterRpt(dtM, dtM, ctrDailySummary.GetDailySaleQuery(ctrDailySummary.date));
            if (ctrDailySummary.dtm == null || ctrDailySummary.dtm.Rows.Count == 0)
            {
                xMessageBox.Show("There are no transactions for today, yet!", "No Transactions Today", ControlLibrary.CCMessageBox.iMessageBoxButtons.OK, ControlLibrary.CCMessageBox.iMessageBoxIcon.Information);
            }
            else
            {
                StaticInfo.LoadToControl("AppControls.ctrDailySummary", "Daily Summary", 0);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrSettings", "Settings", 0);
        }

        private void btnListReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrListReports", "Lists Reports", 0);
        }

        private void btnInventoryReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrInventoryReports", "Inventory Reports", 0);
        }

        private void btnCatalogPackages_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrPackagesList", "Packages List", 0, 0);
        }

        //private void btnDailySaleList_Click(object sender, EventArgs e)
        //{
        //    //StaticInfo.LoadToControl("AppControls.ctrMechanicTrack", "Mechanic Track", 0);
        //    StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale", 0);

        //    StaticInfo.LoadToControl("AppControls.ctrClockInMechanic", "Clock in Mechanic", 0);
        //}

        private void btnDailyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale List", 0);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ChecknewOrders()
        {
            dbClass db = new dbClass();
            DataTable dt = db.CheckNewOrders(objDataSet.WorkOrder);
        }

        void btnReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrReportsMenu", "Reports Menu", 0);
        }
        void btnCustomerReports_Click(object sender, EventArgs e)
        {

        }
        void btnCustomerLedger_Click(object sender, EventArgs e)
        {

        }
        void btnReceipts_Click(object sender, EventArgs e)
        {

        }
        void btnShipment_Click(object sender, EventArgs e)
        {

        }
        void btnCustomerQuotes_Click(object sender, EventArgs e)
        {

        }
        void btnCustomerOrders_Click(object sender, EventArgs e)
        {

        }
        void btnAccountsReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrAccountsReports", "Accounts Reports", 0);
        }
        void btnAccountsLedger_Click(object sender, EventArgs e)
        {

        }
        void btnDailyTransactions_Click(object sender, EventArgs e)
        {

        }
        void btnGeneralJournal_Click(object sender, EventArgs e)
        {

        }
        void btnBankReceiptVoucher_Click(object sender, EventArgs e)
        {

        }
        void btnBankPaymentVoucher_Click(object sender, EventArgs e)
        {

        }
        void btnCashReceiptVoucher_Click(object sender, EventArgs e)
        {

        }
        void btnCashPaymentVoucher_Click(object sender, EventArgs e)
        {

        }
        void btnSaleReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrSaleReports", "Sale Reports", 0);
        }
        void btnVendorLedger_Click(object sender, EventArgs e)
        {

        }
        void btnInvoices_Click(object sender, EventArgs e)
        {

        }
        void btnClaimCores_Click(object sender, EventArgs e)
        {

        }
        void btnWarranty_Click(object sender, EventArgs e)
        {

        }
        void btnWorkOrders_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "WorkOrder Details", 0);
        }
        void btnPurchaseReports_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrPurchaseReports", "Purchase Reports", 0);
        }
        void btnPurchaseLedger_Click(object sender, EventArgs e)
        {

        }
        void btnPayments_Click(object sender, EventArgs e)
        {

        }
        void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPurchaseOrder", "Purchase Details", 0);
        }
        void btnAssetsRegister_Click(object sender, EventArgs e)
        {

        }
        void btnAssets_Click(object sender, EventArgs e)
        {

        }
        void btnAccountsTransactions_Click(object sender, EventArgs e)
        {

        }
        void btnCustomersReceivables_Click(object sender, EventArgs e)
        {

        }
        void btnCustomers_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCustomer", "Customer Details", 0);
        }
        void btnVehiclesSchedules_Click(object sender, EventArgs e)
        {

        }
        void btnVehicles_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVehicle", "Vehicle Details", 0);
        }
        void btnVendorsPayables_Click(object sender, EventArgs e)
        {

        }
        void btnVendors_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendor", "Vendor Details", 0);
        }
        void btnItemsInventory_Click(object sender, EventArgs e)
        {

        }
        void btnItems_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemList", "Item Details", 0);
        }
        void btnEmployeeWorkLoad_Click(object sender, EventArgs e)
        {

        }
        void btnEmployee_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrEmployee", "Employee Details", 0);
        }
        void btnWarehouseActivities_Click(object sender, EventArgs e)
        {

        }
        void btnWarehouse_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWarehouse", "Warehouse Details", 0);
        }
        void btnAccounts_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrChartofAccounts", "Chart of Accounts", 0);
            StaticInfo.LoadToControl("AppControls.ctrBankAccount", "Bank Account", 0);
        }
        void btnCashInHand_Click(object sender, EventArgs e)
        {

        }
        void btnSaleReturn_Click(object sender, EventArgs e)
        {

        }
        void btnSale_Click(object sender, EventArgs e)
        {

        }
        void btnPurchaseReturn_Click(object sender, EventArgs e)
        {

        }
        void btnPurchase_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPurchaseOrder", "Purchase Details", 0);
        }
        void btnReceivables_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadReport("Account", "AppControls", "AppControls.RptAccountLedger", "Receivables", 0);
        }
        void btnPayables_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadReport("Account", "AppControls", "AppControls.RptAccountLedger", "Payables", 0);
        }
        //void btnPayablesLedger_Click(object sender, EventArgs e)
        //{
        //    StaticInfo.LoadReport("Account", "AppControls", "AppControls.RptAccountLedger", "Payables", 0);
        //}
        //void btnReceivablesLedger_Click(object sender, EventArgs e)
        //{
        //    StaticInfo.LoadReport("Account", "AppControls", "AppControls.RptAccountLedger", "Receivables", 0);
        //}
        void btnPrintSummery_Click(object sender, EventArgs e)
        {
            try
            {
                //StaticInfo.LoadReport("Today Activities Report", "AppControls", "AppControls.RptTodayActivities", "", 0);
                //var ctr = new AppControls.Reports.frmRpt("AppControls.RptTodayActivities", "status");
            }
            catch { }
        }
        void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime datefrom = DateFrom.DateTimePicker1.Value;
                //DateTime dateto = DateTo.DateTimePicker1.Value;
                //getTodayPOSActivities(datefrom, dateto); 
            }
            catch { }
        }
        void getTodayPOSActivities(DateTime datefrom, DateTime dateto)
        {
            DataTable dt = dbClass.obj.getTodayPOSActivities(datefrom, dateto);
            string Purchase = "$. " + Convert.ToString(dt.Rows[0]["Purchase"]);
            string PurchaseReturn = "$. " + Convert.ToString(dt.Rows[0]["PurchaseReturn"]);
            string Sale = "$. " + Convert.ToString(dt.Rows[0]["Sale"]);
            string SaleReturn = "$. " + Convert.ToString(dt.Rows[0]["SaleReturn"]);
            string Payable = "$. " + Convert.ToString(dt.Rows[0]["Payable"]);
            string Receivables = "$. " + Convert.ToString(dt.Rows[0]["Receivables"]);
            string CashInHand = "$. " + Convert.ToString(dt.Rows[0]["CashInHand"]);

            //lblPurchase.Text = Purchase;
            //lblPurchaseReturn.Text = PurchaseReturn;
            //lblSale.Text = Sale;
            //lblSaleReturn.Text = SaleReturn;
            //lblPayable.Text = Payable;
            //lblReceivable.Text = Receivables;
            //lblCashInHand.Text = CashInHand;
        }
        private void ctrSaleDashBoard_Load(object sender, EventArgs e)
        {
            //this.lblUserName.Text = StaticInfo.EmployeeName;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            DigitalClock.TextAlign = ContentAlignment.MiddleLeft;
            if (F12hr.Checked)
            {
                DigitalClock.Text = DateTime.Now.ToString("hh:mm:ss tt " + Environment.NewLine + "dddd, dd MMM yyyy");
            }
            else
            {
                DigitalClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss");
            }
            TimeSpan now = DateTime.Now.TimeOfDay;
            if (now > MorningStart && now < MorningEnd)
            {
                Greetings.Text = "\"Have a blissful Morning and Make it shine with your brilliance\"";
            }
            else if (now == Noon)
            {
                Greetings.Text = "\"Good Noon\"";
            }
            else if (now > AfternoonStart && now < AfternoonEnd)
            {
                Greetings.Text = "\"Good, better, best. Never let it rest. Good Afternoon\"";
            }
            else if (now > EveningStart && now < EveningEnd)
            {
                Greetings.Text = "\"Good Evening Dear " + StaticInfo.EmployeeName + ", Have a cup of tea and forget about your stress.\"";
            }
            else if (now > NightStart && now < NightEnd)
            {
                Greetings.Text = "\"You are doing so well with great performance. Have a wonderful night.\"";
            }
            //cboCriteria.SelectedIndex = 0;
            //DateTime datefrom = DateFrom.DateTimePicker1.Value;
            //DateTime dateto = DateTo.DateTimePicker1.Value;

            //getTodayPOSActivities(datefrom, dateto);
            //fillChart();
        }
        //private void fillChart()
        //{
        //    string CurrencySign = StaticInfo.MainCurSign;
        //    if (string.IsNullOrEmpty(CurrencySign))
        //        CurrencySign = "$.";
        //    try
        //    {
        //        //chart1.Titles.Add("Last 3 Month Sales (" + CurrencySign + ")");
        //        DataTable dt = dbClass.obj.get3MonthSale();
        //        DataTableReader dataReader = dt.CreateDataReader();

        //        //while (dataReader.Read())
        //        //{
        //        //    chart1.Series["Sales"].Points.AddXY(dataReader["Month"].ToString(), dataReader["Sale"].ToString());
        //        //}

        //        //chart1.Series["Sales"].IsValueShownAsLabel = true;

        //        //chart1.Legends[0].Enabled = true;
        //        //chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        //        //chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

        //        //chart1.Series["Sales"]["DrawingStyle"] = "Cylinder";

        //        //chart1.Series["Sales"].SmartLabelStyle.Enabled = true;

        //        //chart1.Series["Sales"].Color = System.Drawing.Color.FromArgb(46, 49, 146);

        //        //chart1.BackColor = System.Drawing.Color.FromArgb(214, 219, 233);

        //        //chart1.ChartAreas[0].BackColor = Color.White;
        //        //chart1.ChartAreas[0].BackSecondaryColor = Color.Transparent;
        //        //chart1.ChartAreas[0].BackGradientStyle = GradientStyle.DiagonalRight;

        //    }
        //    catch { }

        //}
        public event EventHandler ExitPicBoxClick;
        protected void ExitPicBox_Click(object sender, EventArgs e)
        {
            if (ExitPicBoxClick != null)
                ExitPicBoxClick(sender, e);
        }

        public event EventHandler LogOffPicBoxClick;
        protected void LogOffPicBox_Click(object sender, EventArgs e)
        {
            if (LogOffPicBoxClick != null)
                LogOffPicBoxClick(sender, e);
        }
        private void LogOffPicBox_MouseHover(object sender, EventArgs e)
        {
            //this.LogOffPicBox.Image = global::AutoVault.Properties.Resources.Login2;            
            this.Cursor = Cursors.Hand;
        }
        private void LogOffPicBox_MouseLeave(object sender, EventArgs e)
        {
            //this.LogOffPicBox.Image = global::AutoVault.Properties.Resources.Login1;
            this.Cursor = Cursors.Default;
        }

        private void btnSetting_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSetting_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPurchaseOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase Order List", 0);
        }

        private void btnVendorBillsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrVendorBillList", "Vendor Bill List", 0);
        }

        private void btnVendorPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Vendor Payment List", 0);

            //ctrVendorPaymentList objList = new ctrVendorPaymentList();
            //frmCtr frmCtr = new frmCtr("Vendor Payment List");
            //frmCtr.Height = objList.Height + 100; frmCtr.Width = objList.Width + 50;
            //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //frmCtr.frmPnl.Controls.Add(objList);
            //frmCtr.BringToFront();
            //frmCtr.ShowDialog();
        }

        private void btnVendorBill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ////StaticInfo.LoadToControl("AppControls.ctrVendorPayment", "Vendor Payment", 0);
            StaticInfo.LoadToControl("AppControls.ctrVendorPayment", "Vendor Payment", 0);

            //ctrVendorPayment objList = new ctrVendorPayment();
            //frmCtr frmCtr = new frmCtr("Vendor Payment");
            //frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //frmCtr.frmPnl.Controls.Add(objList);
            //frmCtr.BringToFront();
            //frmCtr.ShowDialog();
        }

        private void btnVendorPaymentHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrVendorPaymentHistory", "Vendor Payment History", 0);
        }

        private void btnWorkOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrderList", "WorkOrder List", 0);
        }

        private void btnCustomerInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrCustomerPayment", "Customer Payment", 0);
        }

        private void btnDailySaleList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale Report", 0);
        }

        private void btnUserRights_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.frmUserRights", "User Rights", 0);
            //StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale Report", 0);
        }

        private void btnCustomerTransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrCustomerTransactions", "Customer Transactions", 0);
        }

        private void btnItemStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemList", "Item Details", 0);
        }

        private void btnInventoryAdjustment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnGeneralLegder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrGeneralLedger", "General Ledger", 0);
        }

        private void btnPrintLableBarcode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnItemAlternates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnCashPaymentVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCashVoucher", "Cash Payment Voucher", 0);
        }

        private void btnBankPaymentVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrBankVoucher", "Bank Payment Voucher", 0);
        }

        private void btnCashReciptVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCashVoucher", "Cash Receipt Voucher", 0);
        }

        private void btnBankReciptVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCashVoucher", "Bank Receipt Voucher", 0);
        }

        private void btnGeneralJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrGeneralJournalVoucher", "General Journal", 0);
        }

        private void saleTaxRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrSaleTaxRates", "Sale Tax Rates", 0);            
        }

        private void saleCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrSalesCategories", "Sale Categories", 0);
        }

        private void referredByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrReferredBy", "Refered by", 0);
        }

        private void shippingMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrShippingMethods", "Shipping Methods", 0);
        }

        private void termsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrTerms", "Terms", 0);
        }

        private void itemGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemGroup", "Item Group", 0);
        }

        private void priceLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrPriceLevels", "Price Levels", 0);
        }

        private void itemTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemType", "Item Type", 0);
        }

        private void oilViscositiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrOilViscosities", "Oil Viscosities", 0);
        }

        private void bankAccountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrBankAccount", "Bank Account", 0);
        }

        private void systemSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrSettings", "Settings", 0);
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrEmployee", "Employee", 0);
        }

        private void utilitiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrUtilities", "Utilities", 0);
        }

        private void themesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrSettings", "Settings", 0);
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrManufacturers", "Item Manufacturer", 0);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (F12hr.Checked)
            {
                DigitalClock.Text = DateTime.Now.ToString("hh:mm:ss tt "+Environment.NewLine+"dddd, dd MMM yyyy");
            }
            else
            {
                DigitalClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss");
            }
            TimeSpan now = DateTime.Now.TimeOfDay;
            if (now > MorningStart && now < MorningEnd)
            {
                Greetings.Text = "\"Have a blissful Morning and Make it shine with your brilliance\"";
            }
            else if (now == Noon)
            {
                Greetings.Text = "\"Good Noon\"";
            }
            else if (now > AfternoonStart && now < AfternoonEnd)
            {
                Greetings.Text = "\"Good, better, best. Never let it rest. Good Afternoon\"";
            }
            else if (now > EveningStart && now < EveningEnd)
            {
                Greetings.Text = "\"Good Evening Dear " + StaticInfo.EmployeeName + ", Have a cup of tea and forget about your stress.\"";
            }
            else if (now > NightStart && now < NightEnd)
            {
                Greetings.Text = "\"You are doing so well with great performance. Have a wonderful night.\"";
            }
        }

        private void F12hr_CheckedChanged(object sender, EventArgs e)
        {
            if (F12hr.Checked)
            {
                DigitalClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy hh:mm:ss tt");
            }
            else
            {
                DigitalClock.Text = DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss");
            }
        }


        //private void cboCriteria_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboCriteria.SelectedItem == "Today")
        //        ComboSetting(false, DateTime.Now, DateTime.Now);
        //    if (cboCriteria.SelectedItem == "Yesterday")
        //        ComboSetting(false, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
        //    if (cboCriteria.SelectedItem == "This Week")
        //    {
        //        DateTime dtFrom = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        //        DateTime dtTo = dtFrom.Date.AddDays(+6);
        //        ComboSetting(false, dtFrom.Date, dtTo.Date);
        //    }
        //    if (cboCriteria.SelectedItem == "This Month")
        //    {
        //        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //        DateTime endDate = startDate.AddMonths(1).AddDays(-1);
        //        ComboSetting(false, startDate.Date, endDate.Date);
        //    }
        //    if (cboCriteria.SelectedItem == "This Calender Year")
        //    {
        //        DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
        //        DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);
        //        ComboSetting(false, startDate, endDate);
        //    }

        //    if (cboCriteria.SelectedItem == "This Financial Year")
        //    {
        //        Int32 coFinYearStrMonth = 8;
        //        //Int32 coFinYearStrMonth = StaticInfo.CoFinYearStrMonth;
        //        DateTime startDate = DateTime.Now;
        //        DateTime endDate = DateTime.Now;

        //        if (coFinYearStrMonth > DateTime.Now.Month)
        //        {
        //            startDate = new DateTime(DateTime.Now.Year - 1, coFinYearStrMonth, 1);
        //            endDate = startDate.Date.AddDays(364);
        //        }
        //        else
        //        {
        //            startDate = new DateTime(DateTime.Now.Year, coFinYearStrMonth, 1);
        //            endDate = startDate.Date.AddDays(364);
        //        }
        //        ComboSetting(false, startDate, endDate);
        //    }
        //    if (cboCriteria.SelectedItem == "Last Week")
        //    {
        //        DateTime dtFrom = DateTime.Now.AddDays(-7).StartOfWeek(DayOfWeek.Monday);
        //        DateTime dtTo = dtFrom.Date.AddDays(+6);
        //        ComboSetting(false, dtFrom.Date, dtTo.Date);
        //    }
        //    if (cboCriteria.SelectedItem == "Last Month")
        //    {
        //        try
        //        {
        //            var today = DateTime.Today;
        //            var month = new DateTime(today.Year, today.Month, 1);
        //            var first = month.AddMonths(-1);
        //            var last = month.AddDays(-1);
        //            ComboSetting(false, first.Date, last.Date);
        //        }
        //        catch { }
        //    }
        //    if (cboCriteria.SelectedItem == "Last Calender Year")
        //    {
        //        int year = Convert.ToInt32(DateTime.Now.Year - 1);
        //        DateTime startDate = new DateTime(year, 1, 1);
        //        DateTime endDate = new DateTime(year, 12, 31);
        //        ComboSetting(false, startDate, endDate);
        //    }
        //    if (cboCriteria.SelectedItem == "Last Financial Year")
        //    {
        //        Int32 coFinYearStrMonth = 8;
        //        //Int32 coFinYearStrMonth = StaticInfo.CoFinYearStrMonth;
        //        DateTime startDate = DateTime.Now;
        //        DateTime endDate = DateTime.Now;

        //        if (coFinYearStrMonth > DateTime.Now.Month)
        //        {
        //            startDate = new DateTime(DateTime.Now.Year - 2, coFinYearStrMonth, 1);
        //            endDate = startDate.Date.AddDays(364);
        //        }
        //        else
        //        {
        //            startDate = new DateTime(DateTime.Now.Year - 1, coFinYearStrMonth, 1);
        //            endDate = startDate.Date.AddDays(364);
        //        }
        //        ComboSetting(false, startDate, endDate);
        //    }
        //    //if (cboCriteria.SelectedItem == "Custom")
        //    //    ComboSetting(true, DateTime.Now, DateTime.Now);

        //}
        //void ComboSetting(bool enable, DateTime dateFrom, DateTime dateTo)
        //{
        //    //DateFrom.Enabled = enable;
        //    DateFrom.DateTimePicker1.Value = dateFrom.Date;
        //    //DateTo.Enabled = enable;
        //    DateTo.DateTimePicker1.Value = dateTo.Date;
        //}
    }
    //static class DateTimeExtensions
    //{
    //    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    //    {
    //        int diff = dt.DayOfWeek - startOfWeek;
    //        if (diff < 0)
    //        {
    //            diff += 7;
    //        }
    //        return dt.AddDays(-1 * diff).Date;
    //    }
    //}
}
