using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AutoVaultEss
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();

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
            
            this.Load += frmDashBoard_Load;

            this.btnLogout.MouseLeave += new System.EventHandler(this.btnLogout_MouseLeave);
            this.btnLogout.MouseHover += new System.EventHandler(this.btnLogout_MouseHover);
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
            this.btnPurchaseOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPurchaseOrder_LinkClicked);
            this.btnVendorBills.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorBills_LinkClicked);
            this.btnVendorPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnVendorPayment_LinkClicked);
            this.btnClaimCores.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClaimCores_LinkClicked);
            this.btnAdjustmentReplace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdjustmentReplace_LinkClicked);
            this.btnWorkOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnWorkOrder_LinkClicked);
            this.btnCustomerInvoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCustomerInvoice_LinkClicked);

            this.btnDailySaleList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDailySaleList_LinkClicked);
            this.btnCustomerPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCustomerPayment_LinkClicked);
            this.btnWarrantyClaim.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnWarrantyClaim_LinkClicked);
            this.btnItemStock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnItemStock_LinkClicked);
            this.btnInventoryAdjustment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnInventoryAdjustment_LinkClicked);
            this.btnPriceChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPriceChange_LinkClicked);
            this.btnPrintLableBarcode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPrintLableBarcode_LinkClicked);
            this.btnItemAlternates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnItemAlternates_LinkClicked);
            this.btnCashPaymentVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCashPaymentVoucher_LinkClicked);
            this.btnBankPaymentVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBankPaymentVoucher_LinkClicked);
            this.btnCashReciptVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCashReciptVoucher_LinkClicked);
            this.btnBankReciptVoucher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBankReciptVoucher_LinkClicked);
            this.btnGeneralJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnGeneralJournal_LinkClicked);
        }

        private void btnDailySaleList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Sale", 0);
        }

        void frmDashBoard_Load(object sender, EventArgs e)
        {
            this.lblUserName.Text = StaticInfo.EmployeeName;
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
        void btnWorkOrder_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "WorkOrder Details", 0);
        }
        void btnPurchaseReports_Click(object sender, EventArgs e)
        {

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
        
        private void ctrSaleDashBoard_Load(object sender, EventArgs e)
        {
            //this.lblUserName.Text = StaticInfo.EmployeeName;

            //cboCriteria.SelectedIndex = 0;
            //DateTime datefrom = DateFrom.DateTimePicker1.Value;
            //DateTime dateto = DateTo.DateTimePicker1.Value;

            //getTodayPOSActivities(datefrom, dateto);
            //fillChart();
        }
        
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

        private void btnVendorBills_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendorBillList", "Vendor Bill List", 0);
        }

        private void btnVendorPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Vendor Payment List", 0);
        }

        private void btnClaimCores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnAdjustmentReplace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnWorkOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrderList", "WorkOrder List", 0);
        }

        private void btnCustomerInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnCustomerPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnWarrantyClaim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnItemStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnInventoryAdjustment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnPriceChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnPrintLableBarcode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnItemAlternates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnCashPaymentVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnBankPaymentVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnCashReciptVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnBankReciptVoucher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnGeneralJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void btnVendorBills_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnDailySaleList_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
