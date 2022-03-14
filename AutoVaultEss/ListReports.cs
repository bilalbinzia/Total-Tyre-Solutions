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
    public partial class ctrReports : Form
    {
        public ctrReports()
        {
            InitializeComponent();
        }

        private void ctrReports_Load(object sender, EventArgs e)
        {
            pnlPurchaseReports.Visible = false;
            pnlInventoryReports.Visible = false;
            pnlAccountReports.Visible = false;

            pnlSaleReports.Visible = true;
            pnlSaleReports.BringToFront();

            EnableButtons();
            btnSaleReports.Enabled = false;
        }
        private void EnableButtons()
        {
            btnSaleReports.Enabled = true;
            btnPurchaseReports.Enabled = true;
            btnInventoryReports.Enabled = true;
            btnAccountReports.Enabled = true;
        }
        private void DisableButtons()
        {
            btnSaleReports.Enabled = false;
            btnPurchaseReports.Enabled = false;
            btnInventoryReports.Enabled = false;
            btnAccountReports.Enabled = false;
        }
        private void btnSaleReports_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            pnlPurchaseReports.Visible = false;
            pnlInventoryReports.Visible = false;
            pnlAccountReports.Visible = false;

            pnlSaleReports.Visible = true;
            pnlSaleReports.BringToFront();

            EnableButtons();
            btnSaleReports.Enabled = false;
        }

        private void btnPurchaseReports_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            pnlInventoryReports.Visible = false;
            pnlAccountReports.Visible = false;
            pnlSaleReports.Visible = false;

            pnlPurchaseReports.Visible = true;
            pnlPurchaseReports.BringToFront();

            EnableButtons();
            btnPurchaseReports.Enabled = false;
        }

        private void btnInventoryReports_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            pnlAccountReports.Visible = false;
            pnlSaleReports.Visible = false;
            pnlPurchaseReports.Visible = false;

            pnlInventoryReports.Visible = true;
            pnlInventoryReports.BringToFront();
            pnlInventoryReports.Visible = true;

            EnableButtons();
            btnInventoryReports.Enabled = false;
        }

        private void btnAccountReports_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            pnlSaleReports.Visible = false;
            pnlPurchaseReports.Visible = false;
            pnlInventoryReports.Visible = false;
            pnlAccountReports.Visible = true;
            pnlAccountReports.BringToFront();

            EnableButtons();
            btnAccountReports.Enabled = false;
        }

        private void btnExit_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnClose_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnInventoryStock_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryStockReport", "Inventory Stock Report", 0);
        }

        private void btnInventoryValue_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryValueReport", "Inventory Value Report", 0);
        }

        private void btnInventoryPhysical_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryPhysicalReport", "Inventory Physical Report", 0);
        }

        private void btnInventoryVariance_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryVarianceReport", "Inventory Variance Report", 0);
        }

        private void btnInventoryExcess_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryExcessReport", "Inventory Excess Report", 0);
        }

        private void btnInventoryModel_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryModelValueReport", "Inventory Model Value Report", 0);
        }

        private void btnPriceList_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PriceListReport", "Price List Report", 0);
        }

        private void btnSpecialPrice_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.SpecialPriceListReport", "Special Price List Report", 0);
        }

        private void btnReorder_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ReOrderReport", "Inventory Reorder Report", 0);
        }

        private void btnBinReport_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryBinReport", "Bin Report", 0);
        }

        private void btnItemGroup_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ItemGroupSummaryDetailedReport", "Item Group Summary Detailed Report", 0);
        }

        private void btnItemList_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ItemListReport", "Item List Report", 0);
        }

        private void btnInventorySaleRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventorySaleReport", "Inventory Sale Report", 0);
        }

        private void btnVehicleListRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VehicleListReport", "Vehicle List Reports", 0);
        }

        private void btnCusAgingRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.AgingReport", "Customer Aging Reports", 0);
        }

        private void btnTransactionSummary_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionSummaryReport", "Customer Transaction Summary Reports", 0);
        }

        private void btnTransactionWithDate_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CustomerTransactionByDate/VehicleReport", "Customer Transaction By Date", 0);
        }

        private void btnTransSummaryDetails_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionByDateWithDetailReport", "Transaction By Date With Detail Report", 0);
        }

        private void btnInvoiceProfitDetails_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InvoiceProfitDetailReport", "Invoice Profit Detail Report", 0);
        }

        private void btnCustomerList_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CustomerListReport", "Customer List Report", 0);
        }

        private void btnPOBillwiseRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderBillWiseReport", "Purchase Orders By BillWise", 0);
        }

        private void btnPOVendorWiseRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderVendorWiseReport", "Purchase Orders By Vendor", 0);
        }

        private void btnPOItemWiseRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderItemWiseReport", "Purchase Orders By ItemWise", 0);
        }

        private void btnPOHistoryRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderHistoryReport", "Purchase Orders History Report", 0);
        }

        private void btnVendorPaidOutRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorPaidOutReport", "Vendor PaidOut Report", 0);
        }

        private void btnVendorSummaryRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorSummeryReport", "Vendor Summary Report", 0);
        }

        private void btnVendorTransactionRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorTransectionReport", "Vendor Transaction Report", 0);
        }

        private void btnVendorListRep_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorListReport", "Vendor List Report", 0);
        }
    }
}
