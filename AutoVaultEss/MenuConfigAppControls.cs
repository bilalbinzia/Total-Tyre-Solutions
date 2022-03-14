using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using System32;

namespace AutoVaultEss
{
    public static partial class MenuConfig
    {
        static void AddTopMenuAppControls()
        {
            //--Add Top Menu---------------------
            AddMenu("01", "T", "Utilities", "   Utilities", "utility");
            AddMenu("02", "T", "Purchase", "   Purchase", "utility");
            AddMenu("03", "T", "Sale", "   Sale", "utility");
            AddMenu("04", "T", "Inventory", "   Inventory", "utility");
            AddMenu("05", "T", "Accounts", "   Accounts", "utility");
            
            bool SetupRights = false;
            DataRow[] row6 = StaticInfo.UserRights.Select("Code = '045'");
            if (row6[0]["CanView"] != DBNull.Value)
                SetupRights = Convert.ToBoolean(row6[0]["CanView"]);
            if (SetupRights || StaticInfo.EmployeeName == "Admin")
                AddMenu("07", "T", "Setup", "   Setup", "utility");
            AddMenu("18", "T", "Reports", "   Reports", "utility");
            AddMenu("20", "T", "About", "   About", "utility");

            //------------------------------------------------------//

            //--Add Next Menu---------------------------------------//
            //"01"--"Utilities"-------------------------------------//
            //AddMenuItem("01", "0101", "M", "Backup", "mnuBackup", "AppControls", "AppControls.ctrDBBackUp", "", "Backup-icon-16x16");
            AddMenuItem("01", "0190", "S", "-", "", "", "", "", "");
            AddMenuItem("01", "0102", "M", "ChangePassword", "mnuChangePassword", "AppControls", "AppControls.ctrChangePassword", "", "change-Password-16x16");
            AddMenuItem("01", "0103", "L", "Login", "mnuFrmLogin", "", "", "", "login_16x16");
            AddMenuItem("01", "0191", "S", "-", "", "", "", "", "");
            AddMenuItem("01", "0104", "X", "Exit", "mnuExit", "", "", "", "exit-16x16");
            //AddMenuItem("01", "0105", "M", "Reports", "mnuReports", "AutoVaultEss", "AutoVaultEss.ctrReportsMenu", "", "Backup-icon-16x16", false);
            AddMenuItem("01", "0105", "M", "ReportsList", "mnuReportsList", "AutoVaultEss", "AutoVaultEss.ctrReportsList", "", "Backup-icon-16x16", false);
            //"02"--"Setup"-----------------------            
            AddMenuItem("07", "0701", "M", "Company", "mnuCompany", "AppControls", "AppControls.ctrCompany", "", "warehouse_16x16");
            AddMenuItem("07", "0702", "M", "Warehouse", "mnuWarehouse", "AppControls", "AppControls.ctrWarehouse", "", "warehouse_16x16");
            AddMenuItem("07", "0703", "M", "Warehouse Store", "mnuWarehouseStore", "AppControls", "AppControls.ctrWarehouseStore", "", "warehouse_16x16");
            AddMenuItem("07", "0704", "M", "Employee", "mnuEmployee", "AppControls", "AppControls.ctrEmployee", "", "employee_16x16");
            AddMenuItem("101", "0733", "M", "Notifications", "mnuNotifications", "AppControls", "AppControls.Notifications", "", "warehouse_16x16");

            bool UserRightsShow = false;
            DataRow[] row5 = StaticInfo.UserRights.Select("Code = '041'");
            if (row5[0]["CanView"] != DBNull.Value)
                UserRightsShow = Convert.ToBoolean(row5[0]["CanView"]);
            if (UserRightsShow || StaticInfo.EmployeeName == "Admin")            
                AddMenuItem("07", "0705", "M", "User Rights", "mnuUserRights", "AutoVaultEss", "AutoVaultEss.frmUserRights", "", "employee_16x16");
            AddMenuItem("07", "0706", "M", "Vendor", "mnuVendor", "AppControls", "AppControls.ctrVendor", "", "vendor_16x16");
            AddMenuItem("07", "0707", "M", "Customer", "mnuCustomer", "AppControls", "AppControls.ctrCustomer", "", "customer_16x16");
            AddMenuItem("07", "0708", "M", "Vehicle", "mnuVehicle", "AppControls", "AppControls.ctrVehicle", "", "vehicle_16x16");
            AddMenuItem("07", "0709", "M", "Settings", "mnuSettings", "AppControls", "AppControls.ctrSettings", "", "setting_16x16");
            //AddMenuItem("07", "0710", "M", "Items", "mnuItems", "", "", "", "item_product_16x16");
            AddMenuItem("07", "0711", "R", "Sale", "mnuSale", "", "", "", "sale_16x16");
            AddMenuItem("07", "0712", "R", "Inventory", "mnuInventory", "", "", "", "inventory_16x16");

            AddMenuItem("04", "071001", "M", "Item/Product", "mnuItemList", "AppControls", "AppControls.ctrItemList", "", "item_product_16x16");
            //AddMenuItem("0710", "071002", "M", "Labor", "mnuLabor", "AppControls", "AppControls.ctrLabor", "", "item_product_16x16");
            //AddMenuItem("0710", "071003", "M", "Fee", "mnuFees", "AppControls", "AppControls.ctrFees", "", "item_product_16x16");
            //AddMenuItem("0710", "071004", "M", "Packages", "mnuPackages", "AppControls", "AppControls.ctrPackages", "", "service_16x16");
            //AddMenuItem("0710", "071005", "M", "Packages List", "mnuPackagesList", "AppControls", "AppControls.ctrPackagesList", "", "PackagesList_16x16");
            //AddMenuItem("0710", "071006", "M", "Package", "mnuPackage", "AppControls", "AppControls.ctrPackage", "", "service_16x16");
            //AddMenuItem("0710", "071007", "M", "Package", "mnuPackage", "AppControls", "AppControls.ctrPackage", "", "service_16x16");

            AddMenuItem("0711", "071102", "M", "Sale Tax Rates", "mnuSaleTaxRates", "AppControls", "AppControls.ctrSaleTaxRates", "", "sale-tax-rate-16x16");
            AddMenuItem("0711", "071103", "M", "Sale Categories", "mnuSaleCategories", "AppControls", "AppControls.ctrSalesCategories", "", "sale-categories-16x16");
            AddMenuItem("0711", "071104", "M", "Refered by", "mnuReferedby", "AppControls", "AppControls.ctrReferredBy", "", "refered-by-16x16");
            AddMenuItem("0711", "071105", "M", "Shipping Methods", "mnuShippingMethods", "AppControls", "AppControls.ctrShippingMethods", "", "shipping-methods-16x16");
            AddMenuItem("0711", "071106", "M", "Terms", "mnuTerms", "AppControls", "AppControls.ctrTerms", "", "terms-16x16");
            AddMenuItem("0711", "071107", "M", "Credit Cards", "mnuCreditCards", "AppControls", "AppControls.ctrCreditCards", "", "creditcards-16x16");

            AddMenuItem("0712", "071201", "M", "Item Type", "mnuItemType", "AppControls", "AppControls.ctrItemType", "", "item_product_16x16");
            AddMenuItem("0712", "071202", "M", "Item Group", "mnuItemGroup", "AppControls", "AppControls.ctrItemGroup", "", "item_product_16x16");
            AddMenuItem("0712", "071203", "M", "Price Levels", "mnuPriceLevels", "AppControls", "AppControls.ctrPriceLevels", "", "price-level-16x16");
            AddMenuItem("0712", "071204", "M", "Oil Viscosities", "mnuOilViscosities", "AppControls", "AppControls.ctrOilViscosities", "", "oil-viscosities-16x16");
            AddMenuItem("0712", "071205", "M", "Item Manufactures", "mnuManufactures", "AppControls", "AppControls.ctrManufacturers", "", "manufactures-16x16");

            //AddMenuItem("07", "0713", "R", "General", "mnuGeneral", "", "", "", "general_16x16");
            //AddMenuItem("0713", "071301", "M", "State", "mnuState", "AppControls", "AppControls.ctrState", "", "state-16x16");
            //AddMenuItem("0713", "071302", "M", "City", "mnuCity", "AppControls", "AppControls.ctrCity", "", "city-16x16");
            //AddMenuItem("0713", "071391", "S", "-", "", "", "", "", "");
            //AddMenuItem("07", "0713", "M", "Utilities", "mnuUtilities", "AppControls", "AppControls.ctrUtilities", "", "utilities-16x16");

            AddMenuItem("07", "0714", "M", "Item/Product", "mnuItemProduct", "AppControls", "AppControls.ctrItemDefination", "", "item_product_16x16", false);
            //---------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------------------------------------//
            //"02"--"Purchase"-----------------------------------------------------//      

            bool PurchaseShow = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                PurchaseShow = Convert.ToBoolean(row[0]["CanView"]);
            if (PurchaseShow)
            {
                AddMenuItem("02", "0201", "M", "Purchase Order", "mnuPurchaseOrderList", "AppControls", "AppControls.ctrPurchaseOrderList", "", "work_order_listing_16x16");
                //AddMenuItem("02", "0202", "M", "Vendor Bills List", "mnuVendorBillsList", "AppControls", "AppControls.ctrVendorBillList", "", "vendor_bill_16x16");
                AddMenuItem("02", "0202", "M", "Vendor Payments", "mnuVendorPayments", "AppControls", "AppControls.ctrVendorPaymentList", "", "vendor_payments_16x16");
                //AddMenuItem("02", "0204", "M", "Vendor Bills", "mnuVendorBills", "AppControls", "AppControls.ctrVendorPayment", "", "vendor_payment_16x16");
                //AddMenuItem("02", "0209", "M", "Vendor Payments History", "mnuVendorPaymentsHistory", "AppControls", "AppControls.ctrVendorPaymentHistory", "", "vendor_payments_16x16");
            }
            AddMenuItem("02", "0205", "M", "Warranty Claim", "mnuClaim", "AppControls", "AppControls.ctrWarrantyClaimAndCoresList", "", "warranty_claim_16x16", false);
            AddMenuItem("1901", "0206", "M", "Daily Sale Report", "mnuDailySale", "AppControls", "AppControls.ctrDailySaleList", "", "Daily_Sale_16x16");
            AddMenuItem("1901", "0211", "M", "New Module", "mnuModule", "AppControls", "AppControls.ctrModule", "", "Module_16x16");
            AddMenuItem("1901", "0212", "M", "New Menu", "mnuMenu", "AppControls", "AppControls.ctrMenu", "", "Menu_16x16");
            //AddMenuItem("02", "0207", "M", "Browse Invoice", "mnuBrowseInvoice", "AppControls", "AppControls.ctrBrowseInvoice", "", "Browse_Invoice_16x16");
            AddMenuItem("1901", "0210", "M", "View Invoices", "mnuViewInvoices", "AppControls", "AppControls.ViewInvoices", "", "Browse_Invoice_16x16");
            AddMenuItem("1901", "0208", "M", "Invoice Details", "mnuInvoiceDetails", "AppControls", "AppControls.ctrInvoiceDetails", "", "Invoice_Details_16x16");


            //AddMenuItem("07", "0708", "M", "Accounts", "mnuChartofAccounts", "AppControls", "AppControls.ctrChartofAccounts", "", "accounts_16x16");
            //AddMenuItem("02", "0202", "M", "Purchase Order/Receiving", "mnuPurchaseOrder", "AppControls", "AppControls.ctrPurchaseOrder", "", "purchase_order__receiving_16x16");
            //AddMenuItem("02", "0202", "M", "Purchase (GRN)", "mnuPurchase", "AppControls", "AppControls.ctrPurchase", "", "Purchase");
            //AddMenuItem("02", "0290", "S", "-", "", "", "", "", "");
            //AddMenuItem("02", "0203", "M", "Warranty Claim", "mnuClaim", "AppControls", "AppControls.ctrWarrantyClaim", "", "warranty_claim_16x16");
            //AddMenuItem("02", "0204", "M", "Cores", "mnuCores", "AppControls", "AppControls.ctrCores", "", "Cores");
            //AddMenuItem("02", "0291", "S", "-", "", "", "", "", "");
            //AddMenuItem("02", "0292", "S", "-", "", "", "", "", "");
            //AddMenuItem("02", "0221", "M", "Order/Receiving List", "mnuPurchaseOrderRegister", "AppControls", "AppControls.ctrPORegister", "", "order_receiving_list_16x16");
            //AddMenuItem("02", "0222", "M", "Purchase Register", "mnuGRNRegister", "AppControls", "AppControls.ctrGRNRegister", "", "Register");
            //AddMenuItem("02", "0223", "M", "Purchase Return Register", "mnuPurchaseReturn", "AppControls", "AppControls.ctrPRRegister", "", "Register");
            //AddMenuItem("02", "0291", "S", "-", "", "", "", "", "");            
            //---------------------------------------------------------------------------------------------------------------------------

            //"03"--"Sale"------------------------
            bool AccessSales = false;
            DataRow[] row3 = StaticInfo.UserRights.Select("Code = '008'");
            if (row3[0]["CanView"] != DBNull.Value)
                AccessSales = Convert.ToBoolean(row3[0]["CanView"]);
            if (AccessSales)
                AddMenuItem("03", "0301", "M", "Work-Order", "mnuWorkOrderList", "AppControls", "AppControls.ctrWorkOrderList", "", "work_order_listing_16x16");
            AddMenuItem("03", "0302", "M", "Work-Order", "mnuWorkOrder", "AppControls", "AppControls.ctrWorkOrder", "", "work_order_16x16", false);
            AddMenuItem("03", "0303", "M", "Work-OrderNegate", "mnuWorkOrderNegate", "AppControls", "AppControls.ctrWorkOrderNegate", "", "work_order_16x16", false);

            AddMenuItem("03", "0304", "M", "Customer Receipts", "mnuCustomerReceipts", "AppControls", "AppControls.ctrCustomerReceipt", "", "customer_receipts_16x16", false);
            AddMenuItem("03", "0305", "M", "Customer Payment", "mnuCustomerPayment", "AppControls", "AppControls.ctrCustomerPayment", "", "customer_refund_16x16", false);
            AddMenuItem("03", "0306", "M", "Mechanic Track", "mnuMechanicTrack", "AppControls", "AppControls.ctrMechanicTrack", "", "mechanic_track_16x16", false);
            AddMenuItem("03", "0307", "M", "Clock in Mechanic", "mnuClockInMechanic", "AppControls", "AppControls.ctrClockInMechanic", "", "clock_in_mechanic_16x16", false);
            //AddMenuItem("03", "0308", "M", "Customer Adjustment", "mnuCustomerAdjustment", "AppControls", "AppControls.ctrCustomerAdjustment", "", "adjustment_16x16");
            
            AddMenuItem("03", "0309", "M", "Booking-Order", "mnuBookingOrder", "AppControls", "AppControls.ctrBookingOrder", "", "work_order_listing_16x16",false);
            AddMenuItem("03", "0310", "M", "Booking-Order List", "mnuBookingOrderList", "AppControls", "AppControls.ctrBookingOrderList", "", "work_order_listing_16x16",false);
            AddMenuItem("03", "0311", "M", "Dispatch List", "mnuDispatchList", "AppControls", "AppControls.ctrDispatchList", "", "work_order_listing_16x16",false);
            AddMenuItem("03", "0312", "M", "Receiving List", "mnuReceivingList", "AppControls", "AppControls.ctrReceivingList", "", "work_order_listing_16x16",false);
            AddMenuItem("03", "0313", "M", "Work Order Details", "mnuWorkOrderDetails", "AppControls", "AppControls.ctrWorkOrderDetails", "", "Work_Order_Details_16x16", false);
            AddMenuItem("03", "0314", "M", "Customer Transactions", "mnuCustomerTransactions", "AppControls", "AppControls.ctrCustomerTransactions", "", "Customer_Transactions_16x16", false);
            AddMenuItem("03", "0315", "M", "Daily Summary", "mnuDailySummary", "AppControls", "AppControls.ctrDailySummary", "", "Customer_Transactions_16x16", false);
            //ctrWarehouseServices
            //AddMenuItem("03", "0390", "S", "-", "", "", "", "", "");
            //AddMenuItem("03", "0321", "M", "WO Register", "mnuWORegister", "AppControls", "AppControls.ctrWORegister", "", "work_order_register_16x16");
            //AddMenuItem("03", "0305", "M", "Sale Register Items", "mnuSaleRegisterItems", "AppControls", "AppControls.ctrSaleRegisterItems", "", "Register");
            //AddMenuItem("03", "0306", "M", "Sale Return Register", "mnuSaleReturnRegister", "AppControls", "AppControls.ctrSRRegister", "", "Register");
            //---------------------------------------------------------------------------------------------------------------------------

            //"04"--"Inventory"------------------------
            //AddMenuItem("04", "0402", "M", "Item Stock", "mnuItemStock", "AppControls", "AppControls.ctrItemStock", "", "item_stock_16x16");
            AddMenuItem("1902", "0401", "M", "Inventory Adjustment", "mnuAdjustmentInventory", "AppControls", "AppControls.ctrAdjustmentInventory", "", "inventory_adjustment_16x16");
            AddMenuItem("1902", "0402", "M", "Item Catalog", "mnuItemCatalog", "AppControls", "AppControls.ctrItemCatalog", "", "Item_Catalog_16x16");
            AddMenuItem("1902", "0402", "M", "Item Group", "mnuctrItemGroupItems", "AppControls", "AppControls.ctrItemGroupItems", "", "Item_Group_16x16");

            //AddMenuItem("04", "0403", "M", "Inventory Count", "mnuInventoryCount", "AppControls", "AppControls.ctrInventoryCount", "", "inventory_count_16x16");
            //AddMenuItem("04", "0404", "M", "Inventory Transfer", "mnuInventoryTransfer", "AppControls", "AppControls.ctrInventoryTransfer", "", "inventory_transfer_16x16");            
            //AddMenuItem("04", "0490", "S", "-", "", "", "", "", "");

            //---------------------------------------------------------------------------------------------------------------------------
            //"05"--"Accounts"------------------------            
            AddMenuItem("05", "0501", "M", "Chart of Accounts", "mnuChartOfAccount", "AppControls", "AppControls.ctrChartofAccounts", "", "accounts_16x16");
            AddMenuItem("05", "0502", "M", "General Ledger", "mnuctrGenLedger", "AppControls", "AppControls.ctrGenLedger", "", "GeneralLedger");
            //AddMenuItem("05", "0503", "M", "Cash Payment Voucher", "mnuCashPaymentVoucher", "AppControls", "AppControls.ctrCashVoucher", "CPV", "Voucher");
            //AddMenuItem("05", "0504", "M", "Cash Receipt Voucher", "mnuCashReceiptVoucher", "AppControls", "AppControls.ctrCashVoucher", "CRV", "Voucher");
            //AddMenuItem("05", "0505", "M", "Bank Payment Voucher", "mnuBankPaymentVoucher", "AppControls", "AppControls.ctrBankVoucher", "BPV", "Voucher");
            //AddMenuItem("05", "0506", "M", "Bank Receipt Voucher", "mnuBankReceiptVoucher", "AppControls", "AppControls.ctrBankVoucher", "BRV", "Voucher");
            //AddMenuItem("05", "0507", "M", "General Journal", "mnuGeneralJournalVoucher", "AppControls", "AppControls.ctrGeneralJournalVoucher", "", "GeneralJournal");
            AddMenuItem("05", "0591", "S", "-", "", "", "", "", "");

            //AddMenuItem("05", "0507", "M", "Daily Cash", "mnuDailyCash", "AppControls", "AppControls.ctrDailyCash", "", "DailyCash");
            AddMenuItem("05", "0508", "M", "Bank Account", "mnuBankAccount", "AppControls", "AppControls.ctrBankAccount", "", "bank_account_16x16");
            //AddMenuItem("05", "0509", "M", "Check Book", "mnuCheckBook", "AppControls", "AppControls.ctrCheckBook", "", "check_book_16x16");
            //---------------------------------------------------------------------------------------------------------------------------

            ////"06"--"General"------------------------
            //AddMenuItem("06", "0601", "M", "System Settings", "mnuSystemSettings", "AppControls", "AppControls.ctrSystemSettings", "", "SystemSettings");
            //AddMenuItem("06", "0602", "M", "Utilities", "mnuUtilities", "AppControls", "AppControls.ctrUtilities", "", "Utilities");
            ////AddMenuItem("06", "0603", "M", "Themes", "mnuThemes", "AppControls", "AppControls.ctrThemes", "", "Themes");
            //AddMenuItem("06", "0604", "M", "User Logged-In", "mnuUserLoggedIn", "AppControls", "AppControls.ctrUserLoggedIn", "", "UserLoggedIn");
            //AddMenuItem("06", "0605", "M", "Customer E-mail", "mnuCustomerEmail", "AppControls", "AppControls.ctrCustomerEmail", "", "CustomerEmail");
            //AddMenuItem("06", "0606", "M", "Vendor E-mail", "mnuVendorEmail", "AppControls", "AppControls.ctrVendorEmail", "", "VendorEmail");
            ////AddMenuItem("06", "0690", "S", "-", "", "", "", "", "");
            //---------------------------------------------------------------------------------------------------------------------------

            //"18"--"Reports"---------------------
            bool InventoryShow = false;
            DataRow[] row2 = StaticInfo.UserRights.Select("Code = '028'");
            if (row2[0]["CanView"] != DBNull.Value)
                InventoryShow = Convert.ToBoolean(row2[0]["CanView"]);
            
            AddMenuItem("01", "0106", "M", "Accounts", "mnuAccountsReports", "AutoVaultEss", "AutoVaultEss.ctrAccountReports", "", "Backup-icon-16x16", false);
            AddMenuItem("01", "0107", "M", "Purchase Reports", "mnuPurchaseReports", "AutoVaultEss", "AutoVaultEss.ctrPurchaseReports", "", "Backup-icon-16x16", false);
            AddMenuItem("01", "0108", "M", "Sale Reports", "mnuSaleReports", "AutoVaultEss", "AutoVaultEss.ctrSaleReports", "", "Backup-icon-16x16", false);
            AddMenuItem("01", "0112", "M", "Reports Menu", "mnuReports", "AutoVaultEss", "AutoVaultEss.ctrReports", "", "Backup-icon-16x16", false);

            if (InventoryShow)
                AddMenuItem("01", "0109", "M", "Inventory Reports", "mnuInventoryReports", "AutoVaultEss", "AutoVaultEss.ctrInventoryReports", "", "Backup-icon-16x16", false);
            //else
            //{
            //    ControlLibrary.MessageBox message = new ControlLibrary.MessageBox();
            //    message.Show("Sorry! You don't have Permissions on Inventory Reports.");               
            //}
            AddMenuItem("01", "0110", "M", "List Reports", "mnuListReports", "AutoVaultEss", "AutoVaultEss.ctrListReports", "", "Backup-icon-16x16", false);
            AddMenuItem("01", "0111", "M", "User Rights", "mnuUserRights", "AutoVaultEss", "AutoVaultEss.frmUserRights", "", "Backup-icon-16x16", false);

            AddMenuItem("18", "1801", "R", "Accounts Reports", "mnuAccountsReports", "", "", "", "reporting_16x16");
            AddMenuItem("18", "1802", "R", "Purchase Reports", "mnuFinancialReport", "", "", "", "reporting_16x16");
            AddMenuItem("18", "1803", "R", "Vendor Reports", "mnuLedgerReport", "", "", "", "reporting_16x16");            
            AddMenuItem("18", "1804", "R", "Customer Reports", "mnuPurchaseReport", "", "", "", "reporting_16x16");
            AddMenuItem("18", "1805", "R", "Sales Reports", "mnuSalesReport", "", "", "", "reporting_16x16");
            
            if (InventoryShow)
                AddMenuItem("18", "1806", "R", "Inventory Reports", "mnuInventoryReport", "", "", "", "reporting_16x16");

            AddMenuItem("18", "1807", "R", "List Reports", "mnuListReport", "", "", "", "reporting_16x16");

            //-----------------------------------
            //AddMenuItem("18", "1807", "R", "Customer Reports", "mnuCustomerReport", "", "", "", "reporting_16x16");
            //AddMenuItem("18", "1808", "R", "Vendor Reports", "mnuVendorReport", "", "", "", "reporting_16x16");
            //AddMenuItem("18", "1808", "R", "Ledger Reports", "mnuLedgerReport", "", "", "", "reporting_16x16");
            //AddMenuItem("18", "1809", "R", "Ledger Reports", "mnuLedgerReport", "", "", "", "reporting_16x16");
            //AddMenuItem("18", "1810", "R", "Ledger Reports", "mnuLedgerReport", "", "", "", "reporting_16x16");         

            //----------------------------------------------Detail Report-----------------------------------------------
            //"1801"---------"Accounts Reports"--------------------------------------------
            AddMenuItem("1801", "180101", "R", "Accounts Ledger", "mnuRptAccountsLedger", "RptModule", "Reports.RptAccountLedgerReport", "List", "reporting_16x16");
            
            AddMenuItem("1801", "180102", "R", "Accounts Ledger Summary", "mnuRptAccountsLedgerSummary", "RptModule", "Reports.RptAccountLedgerSummaryReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180103", "R", "Accounts Ledger Trial Balance", "mnuRptAccountsLedger", "RptModule", "Reports.RptAccountLedgerTrialBalanceReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180104", "R", "Bank Deposit Analysis", "mnuRptBankDepositAnalysis", "RptModule", "Reports.BankDepositAnalysisReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180105", "R", "Bank Summary", "mnuRptBankSummary", "RptModule", "Reports.BankSummaryReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180106", "R", "Payment Report", "mnuRptPaymentReport", "RptModule", "Reports.PaymentReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180107", "R", "Receivable Report", "mnuRptReceivableReport", "RptModule", "Reports.ReceivableReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180108", "R", "Journal Report", "mnuRptJournalReport", "RptModule", "Reports.JournalReport", "List", "reporting_16x16");
            AddMenuItem("1801", "180109", "R", "Accounts Ledger", "mnuRptAccountsLedger", "RptModule", "Reports.RptAccountLedgerReport", "List", "reporting_16x16");

            //"1802"---------"Purchase Reports"--------------------------------------------
            AddMenuItem("1802", "180201", "R", "Purchase Order Bill Wise Report", "mnuRptPurchaseOrderBillWise", "RptModule", "Reports.PurchaseOrderBillWiseReport", "", "reporting_16x16");
            AddMenuItem("1802", "180202", "R", "Purchase Order Vendor Wise Report", "mnuRptPurchaseOrderVendorWise", "RptModule", "Reports.PurchaseOrderVendorWiseReport", "", "reporting_16x16");
            AddMenuItem("1802", "180203", "R", "Purchase Order Item Wise Report", "mnuRptPurchaseOrderItemWise", "RptModule", "Reports.PurchaseOrderItemWiseReport", "", "reporting_16x16");
            AddMenuItem("1802", "180204", "R", "Purchase Order History Report", "mnuRptPurchaseOrderhistory", "RptModule", "Reports.PurchaseOrderHistoryReport", "", "reporting_16x16");
           
            //Reports.PurchaseOrderHistoryReport
            AddMenuItem("1802", "180205", "R", "Purchase Order Report", "mnuRptPurchaseOrder", "RptModule", "Reports.PurchaseOrderReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180206", "R", "Vendor Bill Report", "mnuRptVendorBill", "RptModule", "Reports.VendorBillReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180207", "R", "Vendor Payment Report", "mnuRptVendorPayment", "RptModule", "Reports.VendorPaymentReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180208", "R", "Vendor Ledger Report", "mnuRptVendorLedger", "RptModule", "Reports.VendorLedgerReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180209", "R", "Vendor Transection Report", "mnuRptVendorTransectionReport", "RptModule", "Reports.VendorTransectionReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180210", "R", "WorkOrder Report WareHouse Copy", "mnuRptWorkOrderReportWareHouseCopy", "RptModule", "Reports.WorkOrderReportWareHouseCopy", "", "reporting_16x16", false);
            AddMenuItem("1802", "180211", "R", "WorkOrder Report", "mnuRptWorkOrderReport", "RptModule", "Reports.WorkOrderReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180220", "R", "Quotation Report", "mnuRptQuotationReport", "RptModule", "Reports.QuotationReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180212", "R", "WorkOrder Report Customer Copy", "mnuRptWorkOrderReportCustomerCopy", "RptModule", "Reports.WorkOrderReportCustomerCopy", "", "reporting_16x16", false);
            AddMenuItem("1802", "180213", "R", "WorkOrder Report Store Copy", "mnuRptWorkOrderReportStoreCopy", "RptModule", "Reports.WorkOrderReportStoreCopy", "", "reporting_16x16", false);
            AddMenuItem("1802", "180214", "R", "WorkOrder Report WareHouse", "mnuRptWorkOrderReportWareHouse", "RptModule", "Reports.WorkOrderReportWareHouse", "", "reporting_16x16", false);
            AddMenuItem("1802", "180215", "R", "Customer Ledger Report", "mnuRptCustomerLedger", "RptModule", "Reports.CustomerLedger", "", "reporting_16x16", false);
            AddMenuItem("1802", "180216", "R", "Invoice Billing Report", "mnuRptInvoiceBillingReport", "RptModule", "Reports.InvoiceBillingReport", "", "reporting_16x16", false);

            AddMenuItem("1802", "180217", "R", "Negated WorkOrder Report", "mnuRptNegateWorkOrderReport", "RptModule", "Reports.NegatedWorkOrderReport", "", "reporting_16x16", false);
            AddMenuItem("1802", "180218", "R", "Customer Invoice Report", "mnuRptCustomerInvoiceReport", "RptModule", "Reports.CustomerInvoiceReport", "", "reporting_16x16", false);

            //"1803"---------"Vendor Reports"--------------------------------------------
            AddMenuItem("1803", "180301", "R", "Vendor Aging Transaction Report", "mnuRptVendorAgingtransaction", "RptModule", "Reports.VendorAgingTransactionReport", "", "reporting_16x16");
            AddMenuItem("1803", "180302", "R", "Vendor Preparation Report", "mnuRptVendorPreparation", "RptModule", "Reports.VendorCheckPreparationReport", "", "reporting_16x16");
            AddMenuItem("1803", "180303", "R", "Outside Parts By Vendors Report", "mnuRptOutsidePartsByVendors", "RptModule", "Reports.WorkOrderOutSidepartByDate", "", "reporting_16x16");
            AddMenuItem("1803", "180304", "R", "Vendor PaidOut Report", "mnuRptVendorPaidOut", "RptModule", "Reports.VendorPaidOutReport", "", "reporting_16x16");
            AddMenuItem("1803", "180305", "R", "Vendor Summary Report", "mnuRptVendorSummary", "RptModule", "Reports.VendorSummeryReport", "", "reporting_16x16");
            AddMenuItem("1803", "180306", "R", "Vendor Transaction Report", "mnuRptVendorTransactionReport", "RptModule", "Reports.VendorTransactionReport", "", "reporting_16x16");
            AddMenuItem("1803", "180307", "R", "Vendor List", "mnuRptVendorList", "RptModule", "Reports.VendorListReport", "", "reporting_16x16");
            AddMenuItem("1803", "180308", "R", "Vendor Payment", "mnuRptVendorPaymentHistory", "RptModule", "Reports.VendorPaymentHistoryReport", "", "reporting_16x16");
            AddMenuItem("1803", "180309", "R", "Vendor Payment History", "mnuRptVendorPaymentHistoryDuplicate", "RptModule", "Reports.VendorPaymentHistoryReportDuplicate", "", "reporting_16x16");
            

            //"1804"---------"Customers Reports"--------------------------------------------
            AddMenuItem("1804", "180401", "R", "Customer Transaction Report", "mnuRptCustomerTransaction", "RptModule", "Reports.CustomerTransactionReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180402", "R", "Customer Transaction Detail Report", "mnuRptCustomerTransactionDetail", "RptModule", "Reports.CustomerTransactionDetailReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180403", "R", "Customer Transaction Summary Report", "mnuRptCustomerTransactionSummary", "RptModule", "Reports.TransactionSummaryReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180404", "R", "Transaction By Date/Vehicle Report", "mnuRptTransactionByDate/Vehicle", "RptModule", "Reports.CustomerTransactionByDate/VehicleReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180405", "R", "Transaction By Date With Detail", "mnuRptTransactionByDateWithDetail", "RptModule", "Reports.TransactionByDateWithDetailReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180406", "R", "Invoice Profit Detail Report", "mnuRptInvoiceProfitDetailReport", "RptModule", "Reports.InvoiceProfitDetailReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180407", "R", "Customers List", "mnuRptCustomerList", "RptModule", "Reports.CustomerListReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180408", "R", "Customers Payment", "mnuRptCustomerCreditHistory", "RptModule", "Reports.CustomerCreditHistoryReport", "List", "reporting_16x16");
            AddMenuItem("1804", "180409", "R", "Customers Payment", "mnuRptCustomerCreditHistoryDuplicateReport", "RptModule", "Reports.CustomerCreditHistoryDuplicateReport", "List", "reporting_16x16");



            //"1805"---------"Sales Reports"--------------------------------------------
            AddMenuItem("1805", "180501", "R", "Invoice Billing Detail Report", "mnuRptInvoiceBillingDetailReport", "RptModule", "Reports.InvoiceBillingDetailReport", "", "reporting_16x16");
            AddMenuItem("1805", "180502", "R", "Inventory Sale Report", "mnuRptInventorySale", "RptModule", "Reports.InventorySaleReport", "", "reporting_16x16");
            AddMenuItem("1805", "180503", "R", "Inventory Sale Transaction Report", "mnuRptInventorySaleTransaction", "RptModule", "Reports.InventorySaleTransactionReport", "", "reporting_16x16");
            AddMenuItem("1805", "180504", "R", "Inventory Movement Report", "mnuRptInventoryMovement", "RptModule", "Reports.InventoryMovementReport", "", "reporting_16x16");
            AddMenuItem("1805", "180505", "R", "Vehicle List", "mnuRptVehicleList", "RptModule", "Reports.VehicleListReport", "", "reporting_16x16");
            AddMenuItem("1805", "180506", "C", "Daily Deposit", "mnuRptDailyDeposit", "RptModule", "Reports.DailyDepositReport", "", "reporting_16x16");
            AddMenuItem("1805", "180507", "R", "Sales REP Summary Detailed", "mnuSalesREPSummaryDetailed", "RptModule", "Reports.SalesREPSummaryDetailedReport", "", "reporting_16x16");            



            //"1806"---------"Inventory Reports"-----------------------------------------            
            AddMenuItem("1806", "180601", "R", "Inventory Stock Report", "mnuRptInventoryStockReport", "RptModule", "Reports.InventoryStockReport", "", "reporting_16x16");
            AddMenuItem("1806", "180602", "R", "Inventory Value Report", "mnuRptInventoryValue", "RptModule", "Reports.InventoryValueReport", "", "reporting_16x16");
            AddMenuItem("1806", "180603", "R", "Inventory Physical Report", "mnuRptInventoryPhysicalReport", "RptModule", "Reports.InventoryPhysicalReport", "", "reporting_16x16");
            AddMenuItem("1806", "180604", "R", "Inventory Variance Report", "mnuRptInventoryVarianceReport", "RptModule", "Reports.InventoryVarianceReport", "", "reporting_16x16");
            AddMenuItem("1806", "180605", "R", "Inventory Excess Report", "mnuRptInventoryExcessReport", "RptModule", "Reports.InventoryExcessReport", "", "reporting_16x16");
            AddMenuItem("1806", "180606", "R", "Inventory Model Report", "mnuRptInventoryModelValueReport", "RptModule", "Reports.InventoryModelValueReport", "", "reporting_16x16");
            AddMenuItem("1806", "180607", "R", "Price List Report", "mnuRptPriceListReport", "RptModule", "Reports.PriceListReport", "", "reporting_16x16");
            AddMenuItem("1806", "180608", "R", "Special Price List Report", "mnuRptSpecialPriceListReport", "RptModule", "Reports.SpecialPriceListReport", "", "reporting_16x16");
            AddMenuItem("1806", "180609", "R", "Inventory Reorder Report", "mnuRptInventoryReorderReport", "RptModule", "Reports.InventoryReorderReport", "", "reporting_16x16");
            AddMenuItem("1806", "180610", "R", "Barcode Report", "mnuRptBarcodeReport", "RptModule", "Reports.BarcodeReport", "", "reporting_16x16");
            AddMenuItem("1806", "180611", "R", "Bin Count Sheet Report", "mnuRptBinCountSheetReport", "RptModule", "Reports.BinCountSheetReport", "", "reporting_16x16");
            AddMenuItem("1806", "180612", "R", "Bin Label Report", "mnuRptBinLabelReport", "RptModule", "Reports.BinLabelReport", "", "reporting_16x16");
            AddMenuItem("1806", "180613", "R", "Bin Report", "mnuRptBinReport", "RptModule", "Reports.InventoryBinReport", "", "reporting_16x16");
            AddMenuItem("1806", "180614", "R", "Packages Report", "mnuRptPackagesReport", "RptModule", "Reports.PackagesReport", "", "reporting_16x16");
            AddMenuItem("1806", "180615", "R", "Item List Report", "mnuRptItemListReport", "RptModule", "Reports.ItemListReport", "", "reporting_16x16");
            AddMenuItem("1806", "180616", "R", "Item Group Summary Detailed Report", "mnuRptItemGroupSummaryDetailedReport", "RptModule", "Reports.ItemGroupSummaryDetailedReport", "", "reporting_16x16");



            //"1820"---------"List Reports"--------------------------------------------
            AddMenuItem("1807", "180701", "R", "Vendors List", "mnuRptVendorsList", "RptModule", "Reports.VendorListReport", "", "reporting_16x16");
            AddMenuItem("1807", "180702", "R", "Employees List", "mnuRptEmployeesList", "RptModule", "Reports.EmployeeListReport", "", "reporting_16x16");
            AddMenuItem("1807", "180703", "R", "Customers List", "mnuRptCustomersList", "RptModule", "Reports.CustomerListReport", "", "reporting_16x16");
            AddMenuItem("1807", "180704", "R", "Items List", "mnuRptItemsList", "RptModule", "Reports.ItemListReport", "", "reporting_16x16");
            AddMenuItem("1807", "180705", "R", "Vehicles List", "mnuRptVehiclesList", "RptModule", "Reports.VehicleListReport", "", "reporting_16x16");

            AddMenuItem("1807", "180706", "R", "Tire Size Report", "mnuRptTireSizeReport", "RptModule", "Reports.TireSizeReport", "", "reporting_16x16");
            AddMenuItem("1807", "180707", "R", "TireSize Sale Report", "mnuRptTireSizeSaleReport", "RptModule", "Reports.TireSizeSaleReport", "", "reporting_16x16");
            AddMenuItem("1807", "180708", "R", "ReOrder Report", "mnuRptReOrderReport", "RptModule", "Reports.ReOrderReport", "", "reporting_16x16");
            AddMenuItem("1807", "180709", "R", "Price Level Sale Report", "mnuRptPriceLevelSaleReport", "RptModule", "Reports.PriceLevelSaleReport", "", "reporting_16x16");
            AddMenuItem("1807", "180710", "R", "Customer Aging Report", "mnuRptCustomerAgingReport", "RptModule", "Reports.AgingReport", "", "reporting_16x16");
            AddMenuItem("1807", "180711", "R", "Vendor Aging Report", "mnuRptVendorAgingReport", "RptModule", "Reports.VendorAgingReport", "", "reporting_16x16");
            AddMenuItem("1807", "180712", "R", "Customer Aging Transaction Detail Report", "mnuRptCAgingTransactionDetailReport", "RptModule", "Reports.CAgingTransactionDetailReport", "", "reporting_16x16");
            AddMenuItem("1807", "180713", "R", "Vendor Aging Transaction Detail Report", "mnuRptVendorAgingTransactionDetailReport", "RptModule", "Reports.VAgingTransactionDetailReport", "", "reporting_16x16");
            AddMenuItem("1807", "180710", "R", "Daily Transaction Report", "mnuRptDailyTransactionReport", "RptModule", "Reports.DailyTransactionReport", "", "reporting_16x16");
            AddMenuItem("1807", "180711", "C", "Daily Transaction Report Details", "mnuRptDailyTransactionReportDetails", "RptModule", "Reports.DailyTransactionReportDetails", "", "reporting_16x16");
            AddMenuItem("1807", "180720", "R", "Sale Categories Report", "mnuRptSaleCategoriesReport", "RptModule", "Reports.SaleCategoriesReport", "", "reporting_16x16");
            //AddMenuItem("1807", "180712", "R", "Customer Daily Report", "mnuRptCustomerDailyReport", "RptModule", "Reports.CustomerDailyReport", "", "reporting_16x16");
            //AddMenuItem("1807", "180713", "R", "Vendor Bill Detail Report", "mnuRptVendorBillDetailReport", "RptModule", "Reports.VendorBillDetailReport", "", "reporting_16x16");
            //AddMenuItem("1807", "180714", "R", "Check Receipt Report", "mnuRptCheckReceiptReport", "RptModule", "Reports.CheckReceiptReport", "", "reporting_16x16");
            //AddMenuItem("1807", "180715", "R", "Paid Ins Report", "mnuRptPaidInsReport", "RptModule", "Reports.PaidInsReport", "", "reporting_16x16");
            //AddMenuItem("1807", "180716", "R", "Paid Outs Report", "mnuRptPaidOutsReport", "RptModule", "Reports.PaidOutsReport", "", "reporting_16x16");
            AddMenuItem("1807", "180711", "R", "Item Group Summery Report", "mnuRptItemGroupSummery", "RptModule", "Reports.ItemGroupSummery", "", "reporting_16x16");
            AddMenuItem("1807", "180721", "R", "Sales REP Summary Report", "mnuRptSalesREPSummaryReport", "RptModule", "Reports.SalesREPSummaryReport", "", "reporting_16x16");



            ////"19"--"Company Setup"---------------
            ////---------------------------------------------------------------------------------------------------------------------------
            //AddMenuItem("19", "1901", "M", "Company Info", "mnuCompanyInfo", "AutoVault", "AutoVault.ctrCompanyInfo", "", "CompanyInfo");
            //AddMenuItem("19", "1902", "C", "Company Branch", "mnuCompanyBranch", "ControlLibrary", "ControlLibrary.ctrCodeFiles", "Branch", "CompanyBranch");
            //AddMenuItem("19", "1991", "S", "-", "", "", "", "", "");
            //AddMenuItem("19", "1903", "M", "User Groups", "mnuUserGroups", "AutoVault", "AutoVault.ctrUserGroups", "", "UserGroups");
            //AddMenuItem("19", "1904", "M", "Form Wise Rights", "mnuFormWiseRights", "AutoVault", "AutoVault.ctrFormWiseRights", "", "FormWiseRights");
            ////---------------------------------------------------------------------------------------------------------------------------

            ////"20"--"About"-----------------------
            ////AddMenuItem("20", "2001", "M", "AboutUs", "mnuFrmAboutUs", "AutoVault", "AutoVault.ctrAbout01", "", "AboutUs");
            ////---------------------------------------------------------------------------------------------------------------------------

            //AddMenuItem("20", "2002", "M", "Workorder Cash for walking Customer", "mnuWorkorderCashForWalkingCustomer", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2003", "M", "Workorder-Sale", "mnuWorkorder-Sale", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2004", "M", "Workorder-Quote", "mnuWorkorder-Quote", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2005", "M", "Rec on Account", "mnuRecOnAccount", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2006", "M", "Paid In/Out", "mnuPaidIn/Out", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2007", "M", "Refund Dep", "mnuRefundDep", "AppControls", "AppControls.ctrAccount", "", "", false);
            //AddMenuItem("20", "2008", "M", "Scheduler", "mnuScheduler", "AppControls", "AppControls.ctrAccount", "", "", false);


            ////Left Buttons-------------------------------
            //AddLeftButton("03", "0301", "M", "Item Detail", "mnuItemDetail", "Item", "AppControls.ctrItem");
            //AddLeftButton("05", "0501", "M", "Purchase Order", "mnuPurchaseOrder", "AppControls", "AppControls.ctrPurchaseOrder");
            //AddLeftButton("05", "0502", "M", "Goods Receipt Note (GRN)", "mnuGoodsReceiptNote", "AppControls", "AppControls.ctrGoodsReceiptNote");
            //AddLeftButton("05", "0503", "M", "Purchase Return (PR)", "mnuPurchaseReturn", "AppControls", "AppControls.ctrPurchaseReturn");
            //AddLeftButton("06", "0601", "M", "Sale", "mnuSale", "AppControls", "AppControls.ctrSale");
            //AddLeftButton("06", "0602", "M", "Sale Return", "mnuSaleReturn", "AppControls", "AppControls.ctrSaleReturn");
            ////AddLeftButton("05", "0507", "M", "Stock Register", "mnuStockRegister", "AppControls", "AppControls.ctrStockRegister");
            //AddLeftButton("06", "0605", "M", "Daily Cash", "mnuDailyCash", "AppControls", "AppControls.ctrDailyCash");
            ////---------------------------------------------------------------------------------------------------------------------------

        }
    }
}
