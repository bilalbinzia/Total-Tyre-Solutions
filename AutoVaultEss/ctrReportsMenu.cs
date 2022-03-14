using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AutoVaultEss
{
    public partial class ctrReportsMenu : UserControl
    {
        public ctrReportsMenu()
        {
            InitializeComponent();             
        }
        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderBillWiseReport", "Purchase Orders By BillWise", 0);
        }
        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderVendorWiseReport", "Purchase Orders By Vendor", 0);
        }
        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderItemWiseReport", "Purchase Orders By ItemWise", 0);            
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PurchaseOrderHistoryReport", "Purchase Orders History Report", 0);            
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorAgingReport", "Vendor Aging Transaction Report", 0);  
        }
        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VAgingTransactionDetailReport", "Vendor Check Preparation Report", 0); 
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.WorkOrderOutSidepartByDate", "Outside Parts By Report", 0); 
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorPaidOutReport", "Vendor PaidOut Report", 0); 
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorSummeryReport", "Vendor Summary Report", 0); 
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorTransectionReport", "Vendor Transaction Report", 0); 
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VendorListReport", "Vendor List Report", 0); 
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventorySaleReport", "Inventory Sale Report", 0);             
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventorySaleTransactionReport", "Inventory Sale Transaction Report", 0);
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryMovementReport", "Inventory Movement Report", 0);
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.VehicleListReport", "Vehicle List Reports", 0);
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.AgingReport", "Customer Transaction Reports", 0);
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CAgingTransactionDetailReport", "Customer Transaction Detail Reports", 0);
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionSummaryReport", "Customer Transaction Summary Reports", 0);
        }
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CustomerTransactionByDate/VehicleReport", "Customer Transaction By Date", 0);
        }
        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionByDateWithDetailReport", "Transaction By Date With Detail Report", 0);            
        }
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InvoiceProfitDetailReport", "Invoice Profit Detail Report", 0);              
        }
        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CustomerListReport", "Customer List Report", 0);
        }
        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryStockReport", "Inventory Stock Report", 0);            
        }
        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryValueReport", "Inventory Value Report", 0);   
        }

        private void linkLabel28_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryPhysicalReport", "Inventory Physical Report", 0);
        }

        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryVarianceReport", "Inventory Variance Report", 0);
        }

        private void linkLabel30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryExcessReport", "Inventory Excess Report", 0);       
        }

        private void linkLabel36_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryModelValueReport", "Inventory Model Value Report", 0);
        }

        private void linkLabel37_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.PriceListReport", "Price List Report", 0);
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.SpecialPriceListReport", "Special Price List Report", 0);
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ReOrderReport", "Inventory Reorder Report", 0);
        }
        private void linkLabel40_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.InventoryBinReport", "Bin Report", 0);
        }
        private void linkLabel42_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ItemListReport", "Item List Report", 0);            
        }

        private void linkLabel41_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ItemGroupSummaryDetailedReport", "Item Group Summary Detailed Report", 0);
        }
    }
}
