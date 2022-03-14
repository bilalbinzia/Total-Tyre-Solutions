using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CrystalDecisions.Shared;
using System32;
using DBModule;


namespace RptModule
{
    public partial class frmRpt : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = new ControlLibrary.MessageBox();
        RptDataSet objDataSet = null;
        RptClass rptClass = null;

        private string RptName;
        private string Status;
        //private string IDs;
        private Int32 ID;
        private Int32 MAccID;
        private DateTime MDate;
        private string strDate;

        public frmRpt()
        {
            InitializeComponent();
            objDataSet = new RptDataSet();
            rptClass = new RptClass();
        }
        private void frmRpt_Load(object sender, EventArgs e)
        {
            try
            {
                dbClass.obj.getWarehouseInfo(objDataSet.RptDetail);
                switch (this.RptName)
                {
                    //----------Item Reports----------------------------//
                    

                    //----------Purchase Reports-------------------------//
                    case "Reports.PurchaseOrderReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderDetailQry(ID));
                        LoadReport(null, new Reports.PurchaseOrderReport());
                        break;
                    case "Reports.VendorBillReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorBillMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorBillDetailQry(ID));
                        LoadReport(null, new Reports.VendorBillReport());
                        break;
                    case "Reports.VendorPaymentReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPaymentMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorPaymentDetailQry(ID));
                        LoadReport(null, new Reports.VendorPaymentReport());
                        break;
                    case "Reports.VendorLedgerReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorLedgerReportMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorLedgerReportDetailQry(ID));
                        LoadReport(null, new Reports.VendorLedgerReport());
                        break;
                    
                    case "Reports.BillHistoryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.BillHistoryReportMasterQry());
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.BillHistoryReportDetailQry());
                        LoadReport(null, new Reports.BillHistoryReport());
                        break;
                    case "Reports.PaymentHistoryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PaymentHistoryReportMasterQry());
                        LoadReport(null, new Reports.PaymentHistoryReport());
                        break;
                    
                    case "Reports.BillPurchaseOrderWiseReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.BillPurchaseOderWiseMasterQry());
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.BillPurchaseOrderWiseDetailQry());
                        LoadReport(null, new Reports.BillPurchaseOrderWiseReport());
                        break;

                    case "Reports.BillVendorWiseReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.BillVendorWiseMasterQry());
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.BillVendorrWiseDetailQry());
                        LoadReport(null, new Reports.BillVendorWiseReport());
                        break;

                    case "Reports.VendorPayableReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPayableReportMasterQry());
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorPayableReportDetailQry());
                        LoadReport(null, new Reports.VendorPayableReport());
                        break;

                    //----------Sale Reports----------------------------//

                    case "Reports.CustomerInvoiceReport":

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerInvoiceReportMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.CustomerInvoiceReport());
                        break;
                    case "Reports.WorkOrderReport":
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.WorkOrderReport());
                        break;
                    case "Reports.QuotationReport":

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.QuotationReport());
                        break;
                    case "Reports.NegatedWorkOrderReport":

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.NegatedWorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.NegatedWorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.NegatedWorkOrderReport());
                        break;
                    case "Reports.WorkOrderReportWareHouse":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.WorkOrderReportWareHouse());
                        break;
                    case "Reports.WorkOrderReportCustomerCopy":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.WorkOrderReportCustomerCopy());
                        break;
                    case "Reports.WorkOrderReportStoreCopy":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportCustomerCopyDetailQry(ID));
                        LoadReport(null, new Reports.WorkOrderReportStoreCopy());
                        break;
                    case "Reports.WorkOrderReportWareHouseCopy":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderReportWareHouseCopyMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.WorkOrderReportWareHouseCopyDetailQry(ID));
                        LoadReport(null, new Reports.WorkOrderReportWareHouseCopy());
                        break;
                    case "Reports.CustomerCreditHistoryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerCreditHistoryMasterQry(ID));                        
                        LoadReport(null, new Reports.CustomerCreditHistoryReport());
                        break;
                    case "Reports.CustomerCreditHistoryDuplicateReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerCreditHistoryMasterQry(ID));
                        LoadReport(null, new Reports.CustomerCreditHistoryDuplicateReport());
                        break;
                    //case "Reports.InventoryBinReport":
                    //  dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryBinReportMasterQry());
                    //  LoadReport(null, new Reports.InventoryBinReport());
                    //  break;
                    case "Reports.DailyDepositReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.DailyTransactionReportMasterQry(this.strDate));
                        LoadReport(null, new Reports.DailyDepositReport());
                        break;
                    case "Reports.DailyTransactionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.DailyTransactionMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("DailyTransactionReport"), new Reports.DailyTransactionReport());
                        break;
                    case "Reports.DailyTransactionReportDetails":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.DailyTransactionDetailsMasterQry(this.strDate));
                        LoadReport(null, new Reports.DailyTransactionReportDetails());
                        break;
                    case "Reports.SaleCategoriesReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SaleCategoriesMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("SaleCategoriesReport"), new Reports.SaleCategoriesReport());
                        break;
                    case "Reports.CheckReceiptReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CheckReceiptReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("CheckReceiptReport"), new Reports.CheckReceiptReport());
                        break;
                    case "Reports.SalesREPSummaryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SalesREPSummeryMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("SalesREPSummaryReport"), new Reports.SalesREPSummaryReport());
                        break;
                    case "Reports.CustomerDailyReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustDailyReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("CustomerDailyReport"), new Reports.CustomerDailyReport());
                        break;
                    case "Reports.VendorBillDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorBillDatailMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorBillDatailDetailQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("VendorBillDetailReport"), new Reports.VendorBillDetailReport());
                        break;
                    case "Reports.PaidOutsReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PaidOutReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("PaidOutsReport"), new Reports.PaidOutsReport());
                        break;
                    case "Reports.PaidInsReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PaidInsReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("PaidInsReport"), new Reports.PaidInsReport());
                        break;
                    case "Reports.TireSizeReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TireSizeReportMasterQry(DateTime.Now.Date, DateTime.Now.Date, 0));
                        LoadReport(new SalesParameters.SalesParameters("TireSizeReport"), new Reports.TireSizeReport());
                        break;
                    case "Reports.ReOrderReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ReOrderReportMasterQry());
                        LoadReport(new SalesParameters.SalesParameters("ReOrderReport"), new Reports.ReOrderReport());
                        break;
                    case "Reports.TireSizeSaleReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TireSizeSaleReportMasterQry(DateTime.Now.Date, DateTime.Now.Date, 0));
                        LoadReport(new SalesParameters.SalesParameters("TireSizeSaleReport"), new Reports.TireSizeSaleReport());
                        break;
                    case "Reports.ItemGroupSummery":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemGroupSummeryMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("ItemGroupSummery"), new Reports.ItemGroupSummery());
                        break;
                    case "Reports.VendorDailyReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorDailyReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorDailyReportDetailQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new SalesParameters.SalesParameters("VendorDailyReport"), new Reports.VendorDailyReport());
                        break;
                    case "Reports.PriceLevelSaleReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PriceLevelSaleReportMasterQry(DateTime.Now.Date, DateTime.Now.Date,0));
                        LoadReport(new SalesParameters.SalesParameters("PriceLevelSaleReport"), new Reports.PriceLevelSaleReport());
                        break;
                    case "Reports.CustomerLedger":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerLedgerReportMasterQry(DateTime.Now.Date, DateTime.Now.Date, 6));
                        LoadReport(new SalesParameters.SalesParameters("CustomerLedger"), new Reports.CustomerLedger());
                        break;
                    case "Reports.AgingReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.AgingReportMasterQry(0, DateTime.Now.Date));
                        LoadReport(new CustParameters.CustParameters("AgingReport"), new Reports.AgingReport());
                        break;
                    //---------
                    case "Reports.VendorAgingReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorAgingReportMasterQry(DateTime.Now.Date));
                        LoadReport(new CustParameters.CustParameters("VendorAgingReport"), new Reports.VendorAgingReport());
                        break;
                    case "Reports.CAgingTransactionDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CTransactionAgingReportDetailQry(DateTime.Now.Date, DateTime.Now.Date,0));
                        LoadReport(new CustParameters.CustParameters("CAgingTransactionDetailReport"), new Reports.CAgingTransactionDetailReport());
                        break;
                    case "Reports.VAgingTransactionDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VTransactionAgingReportDetailQry(DateTime.Now.Date, 0));
                        LoadReport(new CustParameters.CustParameters("VAgingTransactionDetailReport"), new Reports.VAgingTransactionDetailReport());
                        break;

                    case "Reports.InvoiceBillingReport":

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceBillingReportMasterQry(ID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailQry(ID));
                        LoadReport(null, new Reports.InvoiceBillingReport());
                        break;

                    case "Reports.InvoiceBillingDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new Parameters.TransactionPara("InvoiceBillingDetailReport"), new Reports.InvoiceBillingDetailReport());
                        break;

                    case "Reports.SalesREPSummaryDetailedReport":
                        //dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, rptClass.SalesREPSummaryDetailedReportQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new CustParameters.CustParameters("SalesREPSummaryDetailedReport"), new Reports.SalesREPSummaryDetailedReport());
                        break;

                    //--------------------------------Customer Report-------------------------------------//

                    //---------Transaction-----------//

                    //---------History-----------//
                    case "Reports.InventoryTransactionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryTransectionReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new OrderingParameter.OrderingParameter("InventoryTransactionReport"), new Reports.InventoryTransectionReport());
                        break;
                    case "Reports.InventoryTransactionByVendorReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryTransectionByVendorReportMasterQry(DateTime.Now.Date, DateTime.Now.Date));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InventoryTransectionByVendorReportDetailQry(DateTime.Now.Date, DateTime.Now.Date));
                        LoadReport(new OrderingParameter.OrderingParameter("InventoryTransactionByVendorReport"), new Reports.InventoryTransactionByVendorReport());
                        break;
                    
                    //------------------------------------------Lists Reports------------------------------------------------//


                    case "Reports.EmployeeListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.EmployeeListReportMasterQry());
                        LoadReport(null, new Reports.EmployeeListReport());
                        break;

                    //-------------------------------------------------------Purchase------------------------------------
                    case "Reports.PurchaseOrderVendorWiseReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderVendorWiseReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderVendorWiseReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderVendorWiseReport"), new Reports.PurchaseOrderVendorWiseReport());
                        break;
                    case "Reports.PurchaseOrderBillWiseReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOderBillWiseReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderBillWiseReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderBillWiseReport"), new Reports.PurchaseOrderBillWiseReport());
                        break;
                    case "Reports.PurchaseOrderItemWiseReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderItemWiseReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderItemWiseReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderItemWiseReport"), new Reports.PurchaseOrderItemWiseReport());
                        break;
                    case "Reports.PurchaseOrderHistoryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderHistoryReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderHistoryReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderHistoryReport"), new Reports.PurchaseOrderHistoryReport());
                        break;
                    //-------------------------------------------------------Vendor------------------------------------
                    case "Reports.VendorAgingTransactionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorAgingTransactionReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("VendorAgingTransactionReport"), new Reports.VendorAgingTransactionReport());
                        break;
                    case "Reports.VendorCheckPreparationReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorCheckPreparationReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("VendorCheckPreparationReport"), new Reports.VendorCheckPreparationReport());
                        break;
                    case "Reports.WorkOrderOutSidepartByDate":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderOutSidepartByDateMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new VendorParameters.VendorParameters("WorkOrderOutSidepartByDate"), new Reports.WorkOrderOutSidepartByDate());
                        break;
                    case "Reports.VendorPaidOutReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPaidOutReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("VendorPaidOutReport"), new Reports.VendorPaidOutReport());
                        break;
                    case "Reports.VendorSummeryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorSummeryReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("VendorSummeryReport"), new Reports.VendorSummeryReport());
                        break;
                    case "Reports.VendorTransectionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorTransectionReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new VendorParameters.VendorParameters("VendorTransectionReport"), new Reports.VendorTransectionReport());
                        break;
                    case "Reports.VendorListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new VendorParameters.VendorParameters("VendorListReport"), new Reports.VendorListReport());
                        break;
                    //-------------------------------------------------------Sale------------------------------------
                    case "Reports.InventorySaleReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventorySaleReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new SalesParameters.SalesParameters("InventorySaleReport"), new Reports.InventorySaleReport());
                        break;
                    case "Reports.InventorySaleTransactionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventorySaleTransectionReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new SalesParameters.SalesParameters("InventorySaleTransactionReport"), new Reports.InventorySaleTransectionReport());
                        break;
                    case "Reports.InventoryMovementReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryMovementReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new SalesParameters.SalesParameters("InventoryMovementReport"), new Reports.InventoryMovementReport());
                        break;
                    case "Reports.VehicleListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VehicleListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new SalesParameters.SalesParameters("VehicleListReport"), new Reports.VehicleListReport());
                        break;
                    //-------------------------------------------------------Customer--------------------------------------------------
                    case "Reports.CustomerTransactionReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionReport"), new Reports.CustomerTransactionReport());
                        break;
                    case "Reports.CustomerTransactionDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionDetailReport"), new Reports.CustomerTransactionDetailReport());
                        break;
                    case "Reports.TransactionSummaryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TransactionSummeryReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new CustParameters.CustParameters("TransactionSummaryReport"), new Reports.TransactionSummaryReport());
                        break;
                    case "Reports.CustomerTransactionByDate/VehicleReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionByDate/VehicleReport"), new Reports.CustomerTransactionDetailReport());
                        break;
                    case "Reports.TransactionByDateWithDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionCompleteReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionCompleteReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new Parameters.TransactionPara("TransactionByDateWithDetailReport"), new Reports.TransactionByDateWithDetailReport());
                        break;
                    case "Reports.InvoiceProfitDetailReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceProfitDetailReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InvoiceProfitDetailReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0));
                        LoadReport(new CustParameters.CustParameters("InvoiceProfitDetailReport"), new Reports.InvoiceProfitDetailReport());
                        break;
                    case "Reports.CustomerListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        LoadReport(new CustParameters.CustParameters("CustomerListReport"), new Reports.CustomerListReport());
                        break;
                    //-------------------------------------------------------Stock--------------------------------------------------
                    case "Reports.InventoryStockReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryStockReportQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryStockReport"), new Reports.InventoryStockReport());
                        break;
                    case "Reports.InventoryValueReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryValueReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryValueReport"), new Reports.InventoryValueReport());
                        break;
                    case "Reports.InventoryPhysicalReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryPhysicalReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryPhysicalReport"), new Reports.InventoryPhysicalReport());
                        break;
                    case "Reports.InventoryVarianceReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryVarianceReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InventoryVarianceReportDetailQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryVarianceReport"), new Reports.InventoryVarianceReport());
                        break;
                    case "Reports.InventoryExcessReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryExcessReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryExcessReport"), new Reports.InventoryExcessReport());
                        break;
                    case "Reports.InventoryModelValueReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryModelValueReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryModelValueReport"), new Reports.InventoryModelValueReport());
                        break;
                    case "Reports.PriceListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PriceListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("PriceListReport"), new Reports.PriceListReport());
                        break;
                    case "Reports.SpecialPriceListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SpecialPriceListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("SpecialPriceListReport"), new Reports.SpecialPriceListReport());
                        break;
                    case "Reports.InventoryReorderReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryReorderReportMasterQry(DateTime.Now.Date, DateTime.Now.Date, 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryReorderReport"), new Reports.InventoryReorderReport());
                        break;
                    case "Reports.InventoryBinReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryBinReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1), 0, 0, 0, 0));
                        LoadReport(new ValueParameters.ValueParameters("InventoryBinReport"), new Reports.InventoryBinReport());
                        break;
                    case "Reports.ItemListReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemListReportMasterQry(DateTime.Now.Date, DateTime.Now.AddDays(+1)));
                        //LoadReport(new ValueParameters.ValueParameters("ItemListReport"), new Reports.ItemListReport());
                        LoadReport(null, new Reports.ItemListReport());
                        break;
                    case "Reports.ItemGroupSummaryDetailedReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemGroupSummaryDetailedReportQry(DateTime.Now.Date));
                        LoadReport(null, new Reports.ItemGroupSummaryDetailed());
                        break;
                    case "Reports.VendorPaymentHistoryReport":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPaymentHistoryReportQry(ID));
                        LoadReport(null, new Reports.VendorPaymentHistoryReport());
                        break;
                    case "Reports.VendorPaymentHistoryReportDuplicate":
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPaymentHistoryReportQry(ID));
                        LoadReport(null, new Reports.VendorPaymentHistoryDuplicateReport());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); }
        }
        public frmRpt(string rptName, int id = 0)
        {
            InitializeComponent();

            this.RptName = rptName;
            this.ID = id;
            objDataSet = new RptDataSet();
            rptClass = new RptClass();
        }
        public frmRpt(string rptName, string status, int id = 0)
        {
            InitializeComponent();
            this.RptName = rptName;
            this.Status = status;
            this.ID = id;
            objDataSet = new RptDataSet();
            rptClass = new RptClass();

        }
        //public frmRpt(string rptName, string status, string IDs, int id = 0 )
        //{
        //    InitializeComponent();
        //    this.RptName = rptName;
        //    this.Status = status;
        //    this.ID = id;
        //    this.IDs = IDs;
        //    objDataSet = new RptDataSet();
        //    rptClass = new RptClass();
        //}

        public frmRpt(string rptName, Int32 id, Int32 mAccID, DateTime mDate)
        {
            InitializeComponent();
            this.RptName = rptName;
            this.ID = id;
            this.MAccID = mAccID;
            this.MDate = mDate;
            objDataSet = new RptDataSet();
            rptClass = new RptClass();
        }
        public frmRpt(string rptName, Int32 id, Int32 mAccID, string mDate)
        {
            InitializeComponent();
            this.RptName = rptName;
            this.ID = id;
            this.MAccID = mAccID;
            this.strDate = mDate;
            objDataSet = new RptDataSet();
            rptClass = new RptClass();
        }
        private void LoadReport(dynamic rptPara, dynamic rptReport)
        {
            try
            {
                if (rptPara != null)
                {
                    rptPara.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
                    this.perameterPanel.Controls.Add(rptPara);
                }
                else
                {                    
                    this.tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
                    this.tableLayoutPanel1.ColumnStyles[0].Width = 0F;                    
                }

                rptReport.SetDataSource(objDataSet);
                rptReport.VerifyDatabase();
                this.crViewer.ReportSource = rptReport;
                this.crViewer.RefreshReport();
                this.crViewer.Zoom(1);
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.ToString());            
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            DateTime datefrom = DateTime.Now.Date;
            DateTime dateto = DateTime.Now.Date.AddDays(+1);
            int CustomerID = 0;
            int priceLevelID = 0;
            int TireSizeID = 0;
            int ItemIDF = 0;
            int ItemIDT = 0;
            int CatalogF = 0;
            int CatalogT = 0;
            int VendorID = 0;
            int BillIDF = 0;
            int BillIDT = 0;
            try
            {
                dynamic rptPara = ((ControlLibrary.TAButton)(sender)).Parent;
                switch (this.RptName)
                {

                    //------------------------------------------------//
                    case "Reports.InventoryValueReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryValueReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryValueReport"), new Reports.InventoryValueReport());
                        break;
                    case "Reports.InventoryStockReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryStockReportQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryStockReport"), new Reports.InventoryStockReport());
                        break;
                    case "Reports.InventoryPhysicalReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryPhysicalReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryPhysicalReport"), new Reports.InventoryPhysicalReport());
                        break;
                    case "Reports.InventoryVarianceReport":

                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryVarianceReportMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InventoryVarianceReportDetailQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new Parameters.TransactionPara("InventoryVarianceReport"), new Reports.InventoryVarianceReport());
                        break;
                    case "Reports.InventoryExcessReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);
                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryExcessReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryExcessReport"), new Reports.InventoryExcessReport());
                        break;
                    case "Reports.InventoryModelValueReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryModelValueReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryModelValueReport"), new Reports.InventoryModelValueReport());
                        break;
                    case "Reports.InventorySaleReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventorySaleReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new SalesParameters.SalesParameters("InventorySaleReport"), new Reports.InventorySaleReport());
                        break;
                    case "Reports.InventorySaleTransactionReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventorySaleTransectionReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new SalesParameters.SalesParameters("InventorySaleTransactionReport"), new Reports.InventorySaleTransectionReport());
                        break;
                    case "Reports.InventoryMovementReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryMovementReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new SalesParameters.SalesParameters("InventoryMovementReport"), new Reports.InventoryMovementReport());
                        break;
                    case "Reports.PriceListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PriceListReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("PriceListReport"), new Reports.PriceListReport());
                        break;
                    case "Reports.SpecialPriceListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SpecialPriceListReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("SpecialPriceListReport"), new Reports.SpecialPriceListReport());
                        break;
                    case "Reports.InventoryReorderReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryReorderReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryReorderReport"), new Reports.InventoryReorderReport());
                        break;
                    case "Reports.InventoryTransactionReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryTransectionReportMasterQry(datefrom, dateto));
                        LoadReport(new OrderingParameter.OrderingParameter("InventoryTransactionReport"), new Reports.InventoryTransectionReport());
                        break;
                    case "Reports.InventoryTransactionByVendorReport":

                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryTransectionByVendorReportMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InventoryTransectionByVendorReportDetailQry(datefrom, dateto));
                        LoadReport(new OrderingParameter.OrderingParameter("InventoryTransactionByVendorReport"), new Reports.InventoryTransactionByVendorReport());
                        break;
                    case "Reports.InventoryBinReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CatalogF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            CatalogT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCatalogTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (CatalogT < CatalogF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        if (!rptPara.chkAllSize.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First & First Item Second..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InventoryBinReportMasterQry(datefrom, dateto, CatalogF, CatalogT, ItemIDF, ItemIDT));
                        LoadReport(new ValueParameters.ValueParameters("InventoryBinReport"), new Reports.InventoryBinReport());
                        break;
                    case "Reports.CustomerTransactionReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionReportMasterQry(datefrom, dateto, CustomerID));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionReport"), new Reports.CustomerTransactionReport());
                        break;
                    case "Reports.CustomerTransactionDetailReport":

                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportMasterQry(datefrom, dateto, CustomerID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportDetailQry(datefrom, dateto, CustomerID));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionDetailReport"), new Reports.CustomerTransactionDetailReport());
                        break;
                    case "Reports.TransactionSummaryReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TransactionSummeryReportMasterQry(datefrom, dateto, CustomerID));
                        LoadReport(new CustParameters.CustParameters("TransactionSummaryReport"), new Reports.TransactionSummaryReport());
                        break;
                    case "Reports.CustomerTransactionByDate/VehicleReport":

                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportMasterQry(datefrom, dateto, CustomerID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionDetailReportDetailQry(datefrom, dateto, CustomerID));
                        LoadReport(new CustParameters.CustParameters("CustomerTransactionByDate/VehicleReport"), new Reports.CustomerTransactionDetailReport());
                        break;
                    case "Reports.TransactionByDateWithDetailReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCustomer.Checked)
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerTransactionCompleteReportMasterQry(datefrom, dateto, CustomerID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.CustomerTransactionCompleteReportDetailQry(datefrom, dateto, CustomerID));
                        LoadReport(new Parameters.TransactionPara("TransactionByDateWithDetailReport"), new Reports.TransactionByDateWithDetailReport());
                        break;
                    case "Reports.InvoiceProfitDetailReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceProfitDetailReportMasterQry(datefrom, dateto, CustomerID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InvoiceProfitDetailReportDetailQry(datefrom, dateto, CustomerID));
                        LoadReport(new CustParameters.CustParameters("InvoiceProfitDetailReport"), new Reports.InvoiceProfitDetailReport());
                        break;
                    case "Reports.VendorAgingTransactionReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorAgingTransactionReportMasterQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("VendorAgingTransactionReport"), new Reports.VendorAgingTransactionReport());
                        break;
                    case "Reports.VendorCheckPreparationReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorCheckPreparationReportMasterQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("VendorCheckPreparationReport"), new Reports.VendorCheckPreparationReport());
                        break;
                    case "Reports.WorkOrderOutSidepartByDate":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.WorkOrderOutSidepartByDateMasterQry(datefrom, dateto));
                        LoadReport(new VendorParameters.VendorParameters("WorkOrderOutSidepartByDate"), new Reports.WorkOrderOutSidepartByDate());
                        break;
                    case "Reports.PurchaseOrderBillWiseReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            BillIDF = Convert.ToInt32((((rptPara.txtSizeFrom.Text))).ToString());
                            BillIDT = Convert.ToInt32((((rptPara.txtSizeTo.Text))).ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOderBillWiseReportMasterQry(datefrom, dateto, BillIDF, BillIDT));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderBillWiseReportDetailQry(datefrom, dateto, BillIDF, BillIDT));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderBillWiseReport"), new Reports.PurchaseOrderBillWiseReport());
                        break;
                    case "Reports.PurchaseOrderVendorWiseReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderVendorWiseReportMasterQry(datefrom, dateto, VendorID));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderVendorWiseReportDetailQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderVendorWiseReport"), new Reports.PurchaseOrderVendorWiseReport());
                        break;
                    case "Reports.PurchaseOrderItemWiseReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            ItemIDF = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemFrom.SelectedItem)).Row).ItemArray[0].ToString());
                            ItemIDT = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboItemTo.SelectedItem)).Row).ItemArray[0].ToString());
                            if (ItemIDT < ItemIDF)
                            { xMessageBox.Show("Select Second Item First row & First Item Second Row..!"); return; }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderItemWiseReportMasterQry(datefrom, dateto, ItemIDF, ItemIDT));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderItemWiseReportDetailQry(datefrom, dateto, ItemIDF, ItemIDT));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderItemWiseReport"), new Reports.PurchaseOrderItemWiseReport());
                        break;
                    case "Reports.PurchaseOrderHistoryReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PurchaseOrderHistoryReportMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.PurchaseOrderHistoryReportDetailQry(datefrom, dateto));
                        LoadReport(new VendorParameters.VendorParameters("PurchaseOrderHistoryReport"), new Reports.PurchaseOrderHistoryReport());
                        break;
                    case "Reports.VendorPaidOutReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorPaidOutReportMasterQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("VendorPaidOutReport"), new Reports.VendorPaidOutReport());
                        break;
                    case "Reports.VendorSummeryReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorSummeryReportMasterQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("VendorSummeryReport"), new Reports.VendorSummeryReport());
                        break;
                    case "Reports.VendorTransectionReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            VendorID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboVendor.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorTransectionReportMasterQry(datefrom, dateto, VendorID));
                        LoadReport(new VendorParameters.VendorParameters("VendorTransectionReport"), new Reports.VendorTransectionReport());
                        break;
                    //case "Reports.PackingListForClaimReport":                    
                    //        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                    //        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                    //        if (dateto.Date < datefrom.Date)
                    //        { xMessageBox.Show("Select Correct Date..!"); return; }

                    //    dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PackingListforClaimMasterQry(datefrom, dateto));
                    //    LoadReport(new VendorParameters.VendorParameters("PackingListForClaimReport"), new Reports.PackingListForClaimReport());
                    //    break;



                    case "Reports.SalesREPSummaryDetailedReport":

                        //datefrom = rptPara.DateTo.DateTimePicker1.Value;
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = datefrom.AddDays(1);

                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }                     

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, rptClass.SalesREPSummaryDetailedReportQry(datefrom, dateto));
                        LoadReport(new CustParameters.CustParameters("SalesREPSummaryDetailedReport"), new Reports.SalesREPSummaryDetailedReport());
                        break;
                        
                    case "Reports.VendorListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorListReportMasterQry(datefrom, dateto));
                        LoadReport(new VendorParameters.VendorParameters("VendorListReport"), new Reports.VendorListReport());
                        break;
                    case "Reports.VehicleListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VehicleListReportMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("VehicleListReport"), new Reports.VehicleListReport());
                        break;
                    case "Reports.CustomerListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerListReportMasterQry(datefrom, dateto));
                        LoadReport(new CustParameters.CustParameters("CustomerListReport"), new Reports.CustomerListReport());
                        break;
                    case "Reports.ItemListReport":
                        
                            datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                            dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                            if (dateto.Date < datefrom.Date)
                            { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemListReportMasterQry(datefrom, dateto));
                        LoadReport(new CustParameters.CustParameters("ItemListReport"), new Reports.ItemListReport());
                        break;

                    case "Reports.ItemGroupSummaryDetailedReport":

                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemGroupSummaryDetailedReportQry(DateTime.Now.Date));
                        LoadReport(null, new Reports.ItemGroupSummaryDetailed());
                        break;

                    case "Reports.DailyTransactionReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.DailyTransactionMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("DailyTransactionReport"), new Reports.DailyTransactionReport());
                        break;
                    case "Reports.SaleCategoriesReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SaleCategoriesMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("SaleCategoriesReport"), new Reports.SaleCategoriesReport());
                        break;
                    case "Reports.SalesREPSummaryReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.SalesREPSummeryMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("SalesREPSummaryReport"), new Reports.SalesREPSummaryReport());
                        break;
                    case "Reports.CustomerDailyReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustDailyReportMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("CustomerDailyReport"), new Reports.CustomerDailyReport());
                        break;
                    case "Reports.VendorBillDetailReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorBillDatailMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorBillDatailDetailQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("VendorBillDetailReport"), new Reports.VendorBillDetailReport());
                        break;
                    case "Reports.CheckReceiptReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CheckReceiptReportMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("CheckReceiptReport"), new Reports.CheckReceiptReport());
                        break;
                    case "Reports.PaidInsReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PaidInsReportMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("PaidInsReport"), new Reports.PaidInsReport());
                        break;
                    case "Reports.PaidOutsReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PaidOutReportMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("PaidOutsReport"), new Reports.PaidOutsReport());
                        break;
                    case "Reports.TireSizeReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        if (!rptPara.chkTireSize.Checked)
                        {
                            TireSizeID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cbxTireSize.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TireSizeReportMasterQry(datefrom, dateto, TireSizeID));
                        LoadReport(new SalesParameters.SalesParameters("TireSizeReport"), new Reports.TireSizeReport());
                        break;
                    case "Reports.ReOrderReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ReOrderReportMasterQry());
                        LoadReport(new SalesParameters.SalesParameters("ReOrderReport"), new Reports.ReOrderReport());
                        break;
                    case "Reports.TireSizeSaleReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        if (!rptPara.chkTireSize.Checked)
                        {
                            TireSizeID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cbxTireSize.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.TireSizeSaleReportMasterQry(datefrom, dateto, TireSizeID));
                        LoadReport(new SalesParameters.SalesParameters("TireSizeSaleReport"), new Reports.TireSizeSaleReport());
                        break;
                    case "Reports.ItemGroupSummery":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }                       
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.ItemGroupSummeryMasterQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("ItemGroupSummery"), new Reports.ItemGroupSummery());
                        break;
                    case "Reports.VendorDailyReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorDailyReportMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.VendorDailyReportDetailQry(datefrom, dateto));
                        LoadReport(new SalesParameters.SalesParameters("VendorDailyReport"), new Reports.VendorDailyReport());
                        break;
                    case "Reports.PriceLevelSaleReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value;
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        if (!rptPara.chkPriceLevel.Checked)
                        {
                            priceLevelID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cbxPriceLevel.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.PriceLevelSaleReportMasterQry(datefrom, dateto, priceLevelID));
                        LoadReport(new SalesParameters.SalesParameters("PriceLevelSaleReport"), new Reports.PriceLevelSaleReport());
                        break;
                    case "Reports.CustomerLedger":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);
                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }
                        if (!rptPara.chkPriceLevel.Checked)
                        {
                            priceLevelID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cbxPriceLevel.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CustomerLedgerReportMasterQry(datefrom, dateto, priceLevelID));
                        LoadReport(new SalesParameters.SalesParameters("CustomerLedger"), new Reports.CustomerLedger());
                        break;
                    case "Reports.AgingReport":
                        datefrom = rptPara.AgingDate.DateTimePicker1.Value;
                        //datefrom = rptPara.DateFrom.DateTimePicker1.Value; 
                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            CustomerID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.AgingReportMasterQry(CustomerID, datefrom));
                        LoadReport(new CustParameters.CustParameters("AgingReport"), new Reports.AgingReport());
                        break;
                    case "Reports.VendorAgingReport":
                        datefrom = rptPara.AgingDate.DateTimePicker1.Value;
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VendorAgingReportMasterQry(datefrom));
                        LoadReport(new CustParameters.CustParameters("VendorAgingReport"), new Reports.VendorAgingReport());
                        break;
                    case "Reports.CAgingTransactionDetailReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }

                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            if (rptPara.cboCustomer.SelectedItem != null)
                            {
                                priceLevelID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                            }
                            else
                            {
                                priceLevelID = 0;
                            }
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.CTransactionAgingReportDetailQry(datefrom, dateto, priceLevelID));
                        LoadReport(new CustParameters.CustParameters("CAgingTransactionDetailReport"), new Reports.CAgingTransactionDetailReport());
                        break;
                    case "Reports.VAgingTransactionDetailReport":
                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;

                        if (!rptPara.chkAllCatalog.Checked)
                        {
                            priceLevelID = Convert.ToInt32((((System.Data.DataRowView)(rptPara.cboCustomer.SelectedItem)).Row).ItemArray[0].ToString());
                        }
                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.VTransactionAgingReportDetailQry(datefrom, priceLevelID));
                        LoadReport(new CustParameters.CustParameters("VAgingTransactionDetailReport"), new Reports.VAgingTransactionDetailReport());
                        break;
                    case "Reports.InvoiceBillingDetailReport":

                        datefrom = rptPara.DateFrom.DateTimePicker1.Value;
                        dateto = rptPara.DateTo.DateTimePicker1.Value.AddDays(+1);

                        if (dateto.Date < datefrom.Date)
                        { xMessageBox.Show("Select Correct Date..!"); return; }

                        dbClass.obj.tblMasterRpt(objDataSet.tblRptM, objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailMasterQry(datefrom, dateto));
                        dbClass.obj.tblDetailRpt(objDataSet.tblRptD, rptClass.InvoiceBillingReportDetailDetailQry(datefrom, dateto));
                        LoadReport(new Parameters.TransactionPara("InvoiceBillingDetailReport"), new Reports.InvoiceBillingDetailReport());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); }
        }
    }
}