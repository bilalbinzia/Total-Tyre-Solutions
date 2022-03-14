using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System32;
using System.Threading.Tasks;

namespace RptModule
{
    public class RptClass
    {

        public RptClass()
        {

        }

        public string PurchaseOrderMasterQry(int ID)
        {
            string Qry = "SELECT [PO].[ID]" +

            " ,[PO].[PODate] [Date1]" +
            " ,[PO].[LastReceivedDate] [Date2]" +
            " ,[PO].[POID] [I1]" +
            " ,[PO].[TotalQtyOrder] [I2]" +
            " ,[PO].[TotalQtyReceived] [I3]" +
            " ,[PO].[TotalQtyBilled] [I4]" +
            " ,[PO].[LastReceivedBy] [I5]" +
            " ,[PO].[VendorID] [I6]" +
            " ,[PO].[WarehouseID] [I7]" +
            " ,[PO].[StoreID] [I8]" +

            " ,[PO].[Reference] [S1]" +
            " ,[PO].[Notes] [S2]" +
            " ,[Vdr].[Name] [S3]" +
            " ,[Vdr].[Address] [S4]" +
            " ,[Vdr].[Phone]  [S5]" +
            " ,[Vdr].[Fax] [S6]" +
            " ,[Vdr].[Email] [S7]" +
            //" ,[Ste].[Name] [S8]   " +
            //" ,[Cty].[Name] [S9] " +
            " ,[Vdr].[FederalNo] [S10]" +
            " ,[Wh].[CoName] [S11]" +
            " ,[Wh].[CoAddress] [S12]" +
            //" ,[Ste1].[Name] + '  ' +[Cty1].[Name] [S13] " +
            " ,[WhStr].[CoName] [S15]" +

            " ,[PO].[DiscountPer] [D1]" +
            " ,[PO].[TotalAmountOrder] [D2]" +
            " ,[PO].[TotalAmountReceived] [D3]" +
            " ,[PO].[TotalAmountBilled] [D4]" +

            //" ,[Vdr].[ZipCode] [N1]" +
            " ,[Emp].[Initial] [S16]" +

            " FROM [dbo].[PurchaseOrder] [PO]" +
            " LEFT JOIN [dbo].[Vendor] [Vdr] ON [PO].[VendorID] = [Vdr].[ID]" +
            " LEFT JOIN [dbo].[Warehouse] [Wh] ON [PO].[WarehouseID] = [Wh].[ID]" +
            " LEFT JOIN [dbo].[WarehouseStore] [WhStr] ON [PO].[StoreID] = [WhStr].[ID]" +
                //" LEFT JOIN [dbo].[State] [Ste] ON [Vdr].[StateID] = [Ste].[ID]" +
                //" LEFT JOIN [dbo].[City] [Cty] ON [Vdr].[CityID] = [Cty].[ID]" +
                //" LEFT JOIN [dbo].[State] [Ste1] ON [Wh].[StateID] = [Ste1].[ID]" +
            " LEFT JOIN [dbo].[Employee] [Emp] ON [PO].[AddUserID] = [Emp].[ID]";
            //" LEFT JOIN [dbo].[City] [Cty1] ON [Wh].[CityID] = [Cty1].[ID] where [PO].[ID]=" + ID;

            return Qry;
        }
        public string PurchaseOrderDetailQry(int ID)
        {
            string Qry = "SELECT [POD].[ID] " +
                         ",[POD].[MID] " +

                         ",[POD].[QtyOrdrd] [I1] " +
                         ",[POD].[PrevOrdrd] [I2] " +
                         ",[POD].[QtyRcvd] [I3] " +
                         ",[POD].[PrevRcvd] [I4] " +
                         ",[POD].[QtyBilled] [I5] " +
                         ",[POD].[PrevBilled] [I6] " +
                         ",[POD].[ItemID] [I7] " +

                         ",[POD].[Cost] [D1] " +
                         ",[POD].[FET] [D2] " +
                         ",[POD].[Amount] [D3] " +


                         ",itm.[Catalog] [S1] " +
                         ",itm.[Name] [S2] " +
                         ",itm.[VenderPartNo] [S3] " +

                         ",ISNULL(itm.[UnitWeight],0) [D4] " +

                         "FROM [dbo].[PurchaseOrderDetails] [POD] " +
                         "LEFT JOIN [dbo].[PurchaseOrder] [PO] ON [POD].MID = [PO].ID " +
                         "LEFT JOIN [dbo].[Item] itm ON [POD].[ItemID] = itm.ID " +
                         "WHERE [PO].[ID] = " + ID;

            return Qry;
        }                        
        public string POHistoryReportMasterQry()
        {
            string Qry = " SELECT [Po]. [ID]" +
                         " ,[Po].[VendorID]	[I1]" +
                         " ,[Po].[POID]      [I2]" +
                         " ,[Po].[Reference] [S1]" +
                         " ,[Po].[StoreID]   [I3]" +
                         " ,[Po].[WarehouseID][I4]" +
                         " ,[Po].[DiscountPer]    [D1]" +
                         " ,[Po].[AddDate]	[Date1]" +
                         " ,[Po].[AddUserID]	[I5]" +
                         " ,[Ven].[Name][S5]" +
                         " ,[Whs].[CoName][S6]" +
                         " ,[Emp].[Initial][S7]" +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " LEFT JOIN [dbo].[Warehouse] [Wh] ON [Po].[WarehouseID] = [Wh].[ID]" +
                         " LEFT JOIN [dbo].[WarehouseStore] [Whs] ON [Po].[StoreID] = [Whs].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [Po].[AddUserID] = [Emp].[ID]" +
                         //" LEFT JOIN [dbo].[State] [Sta] ON [Wh].[StateID] = [Sta].[ID]" +
                         //" LEFT JOIN [dbo].[Country] [Con] ON [Wh].[CountryID] = [Con].[ID]" +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Wh].[CityID] = [Cty].[ID]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Po].[VendorID] = [Ven].[ID]";

            return Qry;
        }
        public string POHistoryReportDetailQry()
        {
            string Qry = " SELECT   [Pod].[ID]" +
                         " ,[Pod].[MID]" +
                         " ,[Pod].[ItemID][I1]" +
                         " ,[Pod].[QtyOrdrd][I2]" +
                         " ,[Pod].[PrevOrdrd][I3]" +
                         " ,[Pod].[QtyRcvd][I4]" +
                         " ,[Pod].[PrevRcvd][I5]" +
                         " ,[Pod].[QtyBilled][I6]" +
                         " ,[Pod].[PrevBilled][I7]" +
                         " ,[Pod].[Cost][D1]" +
                         " ,[Pod].[FET][D2]" +
                         " ,[Pod].[Amount][D3]          " +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name]      [S3]" +
                         " ,[Itm].[VendorID]	[I8]" +
                         " FROM [dbo].[PurchaseOrderDetails][Pod]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID]=[Itm].[ID]";

            return Qry;
        }            
        public string POItemWiseReportMasterQry()
        {
            string Qry = " SELECT  [Po].[ID]" +
                         " ,[Po].[VendorID][I1]" +
                         " ,[Po].[POID] [I2]" +
                         " ,[Po].[DiscountPer][D1]" +
                         " ,[Po].[WarehouseID][I3]" +
                         " ,[Po].[StoreID][I4]" +
                         " ,[Po].[TotalAmountOrder][D2]" +
                         " ,[Po].[TotalAmountReceived][D3]" +
                         " ,[Po].[TotalAmountBilled][D4]" +
                         " ,[Po].[TotalQtyOrder][I5]" +
                         " ,[Po].[TotalQtyReceived][I6]" +
                         " ,[Po].[TotalQtyBilled] [I7]" +
                         " ,[Po].[AddDate][Date1]" +
                         " ,[Pod].[ItemID]    [I8]" +
                         " ,[Pod].[PrevOrdrd][I9]" +
                         " ,[Pod].[QtyRcvd][I10]" +
                         " ,[Pod].[PrevBilled][I11]" +
                         " ,[Pod].[Cost][D5]" +
                         " ,[Pod].[FET][D6]" +
                         " ,[Pod].[Amount][D7]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name]    [S3] " +
                         " ,[Itm].[VenderPartNo] [S4]" +
                         " ,[Itm].[UnitWeight][D8]" +
                         " ,[Itm].[CatalogCost]  [D9]" +
                         " ,[Itm].[FET][D10]" +
                         " ,[Ven].[Name][S8]" +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " Left join [dbo].[PurchaseOrderDetails][Pod] ON[Po].[POID]=[Pod].[MID]" +
                         " Left join [dbo].[Item][Itm] ON[Pod].[ItemID]=[Itm].[ID]" +
                         " Left join [dbo].[Vendor][Ven] ON[Po].[VendorID]=[Ven].[ID]" +
                         " Left join [dbo].[Warehouse][Wh] ON[Po].[WarehouseID]=[Wh].[ID]";
                         //" Left join [dbo].[State][Sta] ON[Wh].[StateID]=[Sta].[ID]" +
                         //" Left join [dbo].[Country][Con] ON[Wh].[CountryID]=[Con].[ID]" +
                         //" Left join [dbo].[City][Cty] ON[Wh].CityID=[Cty].[ID] order by [Itm].[ID]";

            return Qry;
        }
        public string POVendorWiseReportMasterQry()
        {
            string Qry = " SELECT  [Po].[ID]" +
                         " ,[Po].[VendorID][I1]" +
                         " ,[Po].[POID] [I2]" +
                         " ,[Po].[DiscountPer][D1]" +
                         " ,[Po].[WarehouseID][I3]" +
                         " ,[Po].[StoreID][I4]" +
                         " ,[Po].[TotalAmountOrder][D2]" +
                         " ,[Po].[TotalAmountReceived][D3]" +
                         " ,[Po].[TotalAmountBilled][D4]" +
                         " ,[Po].[TotalQtyOrder][I5]" +
                         " ,[Po].[TotalQtyReceived][I6]" +
                         " ,[Po].[TotalQtyBilled] [I7]" +
                         " ,[Po].[AddDate][Date1]" +
                         " ,[Ven].[Name][S8]" +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " Left join [dbo].[Vendor][Ven] ON[Po].[VendorID]=[Ven].[ID]" +
                         " Left join [dbo].[Warehouse][Wh] ON[Po].[WarehouseID]=[Wh].[ID]";
                         //" Left join [dbo].[State][Sta] ON[Wh].[StateID]=[Sta].[ID]" +
                         //" Left join [dbo].[Country][Con] ON[Wh].[CountryID]=[Con].[ID]" +
                         //" Left join [dbo].[City][Cty] ON[Wh].CityID=[Cty].[ID]";

            return Qry;
        }
        public string POVendorWiseReportDetailQry()
        {
            string Qry = " SELECT   [Pod].[ID]" +
                         " ,[Pod].[MID]" +
                         " ,[Pod].[ItemID]    [I1] " +
                         " ,[Pod].[PrevOrdrd][I2]     " +
                         " ,[Pod].[QtyRcvd][I3]" +
                         " ,[Pod].[PrevBilled][I4]" +
                         " ,[Pod].[Cost][D1]" +
                         " ,[Pod].[FET][D2]" +
                         " ,[Pod].[Amount][D3]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name]    [S3]" +
                         " ,[Itm].[VenderPartNo] [S4]     " +
                         " ,[Itm].[UnitWeight][D4]" +
                         " ,[Itm].[CatalogCost]  [D4]" +
                         " ,[Itm].[FET][D5]" +
                         " FROM [dbo].[PurchaseOrderDetails][Pod]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID]=[Itm].[ID]";

            return Qry;
        }
        public string EmployeeListReportMasterQry()
        {
            string Qry = " SELECT [Emp].[ID]   [I1]   " +
                         " ,[Emp].[Initial]  [S1]  " +
                         " ,[Emp].[Name]	[S2]" +
                         " ,[Emp].[Phone1][S3]" +
                         " ,[Emp].[Phone2][S4]" +
                         " ,[Emp].[Wages]     [D1] " +
                         " ,[Emp].[AddDate]      [Date1]" +
                         " FROM [dbo].[Employee] [Emp]";

            return Qry;
        }
        public string BillHistoryReportMasterQry()
        {
            string Qry = "  SELECT   [Vb].[ID] " +
                         " ,[Vb].[BillID][I1] " +
                         " ,[Vb].[VendorID][I2] " +
                         " ,[Vb].[InvoiceNo][S1]  " +
                         " ,[Vb].[POID]     [I3] " +
                         " , [D1]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " , [D2]=(Select isnull (sum(PaidAmount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " , [D3]=(Select isnull (sum(BillBalance),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " ,[Vb].[GridTotalQty]    [I4] " +
                         " ,[Vb].[GridTotalAmount][D5]  " +
                         " ,[Vb].[BillTotalAmount][D6]  " +
                         " ,[Vb].[StoreID]      [I5]  " +
                         " ,[Vb].[PaidAmount][D7] " +
                         " ,[Vb].[Balance]   [D8]  " +
                         " ,[Vb].[AddDate]   [Date1] " +
                         " ,[Ven].[Name]	[S4] " +
                         " FROM [dbo].[VendorBill] [Vb]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] ON [Vb].[VendorID]=[Ven].[ID]";
                         //" LEFT JOIN [dbo].[State] [Sta] ON [Ven].[StateID] = [Sta].[ID]" +
                         //" LEFT JOIN [dbo].[Country] [Con] ON [Ven].[CountryID] = [Con].[ID] " +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Ven].[CityID] = [Cty].[ID]  ";

            return Qry;
        }
        public string BillHistoryReportDetailQry()
        {
            string Qry = " SELECT [Vbd].[ID]" +
                         " ,[Vbd].[MID]" +
                         " ,[Vbd].[ItemID][I1]" +
                         " ,[Vbd].[Catalog][S1]" +
                         " ,[Vbd].[Name][S2]" +
                         " ,[Vbd].[BillQty][I2]" +
                         " ,[Vbd].[CatalogCost][D1]" +
                         " ,[Vbd].[BillAmount][D2]" +
                         " ,[Itm].[ItemSize][S3]" +
                         " FROM [dbo].[VendorBillDetails][Vbd]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Vbd].[ItemID]=[Itm].[ID]";

            return Qry;
        }
        public string PaymentHistoryReportMasterQry()
        {
            string Qry = " SELECT * FROM ( " +
                         " SELECT [VB].[ID] [I1],[S1]  = 'Payment', [I2] = [VB].[BillID], [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [S3] = [VB].[InvoiceNo] " +
                         " ,[S10] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[PaidAmount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name] " +
                         " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " FROM dbo.VendorPayment [VB] " +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID  " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID  " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID  " +
                         //" LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID  " +
                         " Where [VB].[PaidAmount] > 0 AND [VB].VendorID = [Ven].ID " +
                         " UNION ALL " +
                         " SELECT [VB].[ID] [I1],[S1] = 'Discount', [I2] = [VB].BillID, [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [Reference] = 'Discount' " +
                         " ,[S4] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[BillDiscount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name] " +
                         " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " FROM dbo.VendorPayment [VB] " +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID  " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID  " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID  " +
                         //" LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID  " +
                         " Where [VB].[BillDiscount] > 0 AND [VB].VendorID = [Ven].ID " +
                         " )tbl Order by [I1]";



            return Qry;
        }     
        public string BillPurchaseOderWiseMasterQry()
        {
            string Qry = " SELECT [Vb].[ID]" +
                         " ,[Vb].[BillID][I1]" +
                         " ,[Vb].[VendorID][I2]" +
                         " ,[Vb].[InvoiceNo][S1]" +
                         " ,[Vb].[POID] [I3]      " +
                         " ,[Vb].[SaleTaxDiscountPercent][D1]" +

                         " ,[Vb].[GridTotalAmount][D3]" +
                         " ,[Vb].[BillTotalAmount][D4]" +
                         " ,[Vb].[StoreID][I4]" +

                         " ,[Vb].[Balance][D6]" +
                         " ,[Vb].[AddDate][Date1]	" +
                         " ,[Ven].[Name] [S7]" +
                         " , [D2]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID)" +
                         " , [D5]=(Select isnull (sum(PaidAmount),0) from VendorPayment where VendorID = [Ven].ID)" +
                         " FROM [dbo].[VendorBill][Vb]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] On [Vb].[VendorID]=[Ven].[ID]";

            return Qry;
        }
        public string BillPurchaseOrderWiseDetailQry()
        {
            string Qry = " SELECT  [Pod]. [ID]" +
                         " ,[Pod]. [MID]" +
                         " ,[Pod]. [ItemID]	[I1]" +
                         " ,[Pod]. [QtyOrdrd][I2]" +
                         " ,[Pod]. [PrevOrdrd][I3]" +
                         " ,[Pod]. [QtyRcvd][I4]" +
                         " ,[Pod]. [PrevRcvd][I5]" +
                         " ,[Pod]. [QtyBilled][I6]" +
                         " ,[Pod]. [PrevBilled][I7]" +
                         " ,[Pod]. [Cost][D1]" +
                         " ,[Pod]. [FET][D2]" +
                         " ,[Pod]. [Amount][D3]" +
                         " ,[Itm]. [Catalog][S1]" +
                         " ,[Itm]. [Name][S2]" +
                         " ,[Ven]. [Name][S3]" +
                         " FROM [dbo].[PurchaseOrderDetails] [Pod]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Pod]. [ItemID]=[Itm]. [ID]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Itm]. [VendorID]=[Ven]. [ID]";

            return Qry;
        }
        public string BillVendorWiseMasterQry()
        {
            string Qry = " SELECT [Vb].[ID]" +
                         " ,[Vb].[BillID][I1]" +
                         " ,[Vb].[VendorID][I2]" +
                         " ,[Vb].[InvoiceNo][S1]" +
                         " ,[Vb].[POID] [I3]      " +
                         " ,[Vb].[SaleTaxDiscountPercent][D1]" +

                         " ,[Vb].[GridTotalAmount][D3]" +
                         " ,[Vb].[BillTotalAmount][D4]" +
                         " ,[Vb].[StoreID][I4]" +

                         " ,[Vb].[Balance][D6]" +
                         " ,[Vb].[AddDate][Date1]	" +
                         " ,[Ven].[Name] [S7]" +
                         " , [D2]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID)" +
                         " , [D5]=(Select isnull (sum(PaidAmount),0) from VendorPayment where VendorID = [Ven].ID)" +
                         " FROM [dbo].[VendorBill][Vb]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] On [Vb].[VendorID]=[Ven].[ID]";

            return Qry;
        }
        public string BillVendorrWiseDetailQry()
        {
            string Qry = " SELECT  [Pod]. [ID]" +
                         " ,[Pod]. [MID]" +
                         " ,[Pod]. [ItemID]	[I1]" +
                         " ,[Pod]. [QtyOrdrd][I2]" +
                         " ,[Pod]. [PrevOrdrd][I3]" +
                         " ,[Pod]. [QtyRcvd][I4]" +
                         " ,[Pod]. [PrevRcvd][I5]" +
                         " ,[Pod]. [QtyBilled][I6]" +
                         " ,[Pod]. [PrevBilled][I7]" +
                         " ,[Pod]. [Cost][D1]" +
                         " ,[Pod]. [FET][D2]" +
                         " ,[Pod]. [Amount][D3]" +
                         " ,[Itm]. [Catalog][S1]" +
                         " ,[Itm]. [Name][S2]" +
                         " ,[Ven]. [Name][S3]" +
                         " FROM [dbo].[PurchaseOrderDetails] [Pod]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Pod]. [ItemID]=[Itm]. [ID]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Itm]. [VendorID]=[Ven]. [ID]";

            return Qry;
        }
        public string VendorPayableReportMasterQry()
        {
            string Qry = " SELECT [Vb].[ID]" +
                         " ,[Vb].[BillID][I1]" +
                         " ,[Vb].[VendorID][I2]" +
                         " ,[Vb].[InvoiceNo][S1]" +
                         " ,[Vb].[POID] [I3]      " +
                         " ,[Vb].[GridTotalQty][D1]" +

                         " ,[Vb].[GridTotalAmount][D3]" +
                         " ,[Vb].[BillTotalAmount][D4]" +
                         " ,[Vb].[StoreID][I4]" +

                         " ,[Vb].[Balance][D6]" +
                         " ,[Vb].[AddDate][Date1]	" +
                         " ,[Ven].[Name] [S7]" +
                         " , [D2]=(Select isnull (sum(BillDiscount),0) from VendorPayment where BillID = [Vb].BillID)" +
                         " , [D5]=(Select isnull (sum(PaidAmount),0) from VendorPayment where BillID = [Vb].BillID)" +
                         " FROM [dbo].[VendorBill][Vb]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] On [Vb].[VendorID]=[Ven].[ID] ";

            return Qry;
        }
        public string VendorPayableReportDetailQry()
        {
            string Qry = " SELECT * FROM ( " +
                         " SELECT [VB].[ID] [I1],[S1]  = 'Payment', [I2] = [VB].[BillID], [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [S3] = [VB].[InvoiceNo]  " +
                         " ,[S10] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[PaidAmount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name]  " +
                         " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID)  " +
                         "  FROM dbo.VendorPayment [VB]  " +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID   " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID   " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID  " +
                         //"  LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID   " +
                         "  Where [VB].[PaidAmount] > 0 AND [VB].VendorID = [Ven].ID  " +
                         " UNION ALL  " +
                         "  SELECT [VB].[ID] [I1],[S1] = 'Discount', [I2] = [VB].BillID, [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [Reference] = 'Discount'  " +
                         "  ,[S4] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[BillDiscount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name]  " +
                         " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID)  " +
                         "  FROM dbo.VendorPayment [VB]  " +
                         "  LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID   " +
                         "  LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID   " +
                         "  LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID   " +
                         //"  LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID   " +
                         "  Where [VB].[BillDiscount] > 0 AND [VB].VendorID = [Ven].ID  " +
                         "  )tbl  ";

            return Qry;
        }


        //-------------------------------------------------Bill---------------------------------------------------
        public string VendorPaymentMasterQry(int ID)
        {
            string Qry = " SELECT [VB].[BillID] [I2] , [Ven].[Name] [S4]    ,[Ven].[Email]	[S3]    ,[Ven].[Phone]	[S5]    ,[Ven].[Fax]     [S7]    ,[Ven].[Address][S6]"+
                          //,[Ven].[CityID][I4]   ,[Cty].[Name] [S8]    
                         ",[VB].[BillTotalAmount] [D2]   ,[VB].[POID] [I6]   " +
                         " ,[VB].[BillDate] [Date1]       " +

                         " FROM [dbo].[Vendor] [Ven]  " +
                         //" Left Join [dbo].[City] [Cty] ON [Ven].[CityID]=[Cty].[ID] " +
                         " Left Join [dbo].[VendorBill] [VB] ON [Ven].[ID]=[VB].[VendorID] " +
                         " where [VB].[BillID] =  " + ID;
            return Qry;
        }
        public string VendorPaymentDetailQry(int ID)
        {
            string Qry = " SELECT [Vp].[ID]" +
                         " ,[Vp].[PaymentID] [I1]" +
                         " ,[Vp].[VendorID]	[I3]" +
                         " ,[Vp].[BillID]	[I2]" +
                         " ,[Vp].[InvoiceNo] [S3]  " +
                         " ,[Vp].[BillAmount] [D1]" +
                         " ,[Vp].[BillDiscount] [D2]" +
                         " ,[Vp].[PaidAmount] [D3]" +
                         " ,[Vp].[BillBalance] [D4] " +
                         " ,[Vp].[AddDate]   [Date1]" +
                         " ,[Vb].[AddDate]  [Date2]" +
                         " ,[Vb].[POID]		[I6]" +

                         " FROM [dbo].[VendorPayment] [Vp]" +
                         " LEFT JOIN [dbo].[VendorBill] [Vb] On [Vp].[BillID] = [Vb].[BillID]" +
                         "LEFT JOIN [dbo].[PurchaseOrder] [Po] On [Vb].[POID] = [Po].[ID]" +
                         " Where [Vp].[BillID]=" + ID + " Order by [I1]";
            return Qry;
        }

        public string CustomerCreditHistoryMasterQry(int ID)
        {

            string Qry = "  SELECT " +
                         "  [CCH].[ReceiptID] [I1] " +
                         " ,[CCH].[InvoiceID] [S4]  " +
                         " ,[CCH].[PaidAmount][D9]" +
                         " ,[CCHR].[PayByCash][D1]" +
                         " ,[CCHR].[PaybyCheck]   [D2]" +
                         " ,[CCHR].[PayByVisa][D4]" +
                         " ,[CCHR].[PayByMC][D5]" +
                         " ,[CCHR].[PayByAMEX][D6]" +
                         " ,[CCHR].[PayByATM][D7]" +
                         " ,[CCHR].[PayByDSCVR][D8]" +
                         " ,[CCHR].[PayByGY][D10]" +
                         " ,[CCHR].[CusCredit][D11]" +
                         " ,[C].[CompanyName] [S1] " +
                         " ,[C].[LastName]   [S2]" +
                         " ,[C].[Address]	  [S3] " +
                         " FROM [dbo].[CustomerCreditHistory][CCH] " +
                         " LEFT JOIN  [CustomerReceipt][CCHR] " +
                         " ON[CCH].[ReceiptID] = [CCHR].[ReceiptID]" +                         
                         " LEFT JOIN [dbo].[Customer] [C] ON [CCHR].[CustomerID] = [C].[ID] " +
                         " WHERE [CCH].[ReceiptID]=" + ID;
            return Qry;

        }

        public string WorkOrderMasterQry(int ID)
        {
            string Qry = "  SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate][Date1] " +
                         " ,,(Select ReceiptID from CustomerReceipt where WOID=wo.ID) [I2] " +
                         " ,[WO].[CustomerID]  [I1] " +
                         " ,[WO].[VehicleID]	  [I3] " +
                         " ,[WO].[SaleRepID]	  [I4] " +
                         " ,[WO].[MechID]	  [I5] " +
                         " ,[WO].[ReferredByID][I6]" +
                         " ,[WO].[StoreID]	  [I7] " +
                         " ,[WO].[Mileage]	  [N1] " +
                         " ,[WO].[MileageOut]  [N2] " +
                         " ,[WO].[PONo]		  [S1] " +
                         " ,[WO].[PartsPrice]  [D1] " +
                         " ,[WO].[LaborPrice]  [D2] " +
                         " ,[WO].[OtherPrice]  [D3] " +
                         " ,[WO].[FET]		  [D4] " +
                         " ,[WO].[Taxable]	  [D5] " +
                         " ,[WO].[Tax]		  [D6] " +
                         " ,[WO].[Discount]	  [D7] " +
                         " ,[WO].[PartDisPer]  [D8] " +
                         " ,[WO].[Total]		  [D9] " +
                         " ,[Cus].[Company] [S2] " +
                         " ,[Cus].[LastName]   [S3] " +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[ContactPerson][S5] " +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10] " +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]   " +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID] " +
                         " ,[Veh].[EngineSize]	[S13] " +
                         " ,[Veh].[PlateDate]    [Date2] " +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[CSA].[Address]			[S17] " +
                         " ,[Emp].[Initial]		[S18] " +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
                        " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID] " +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
                         "LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID] WHERE [WO].[ID]=" + ID;

            return Qry;
        }
        public string WorkOrderDetailQry(int ID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]	 " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18]   " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD " +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl where MID =  " + ID + " Order by [ID]";

            return Qry;
        }

        public string NegatedWorkOrderReportCustomerCopyMasterQry(int ID)
        {
            
            string Qry = "  SELECT [WON]. [ID] " +
                         " ,[WON].[AddDate][Date1] " +
                         " ,[WON].[WorkOrderNegateNo] [I2] " +
                         " ,[WON].[CustomerID]  [I1]" +
                         " ,[WON].[VehicleID]	  [I3] " +
                         " ,[WON].[SaleRepID]	  [I4]" +
                         " ,[WON].[MechID]	  [I5] " +
                         " ,[WON].[ReferredByID][I6]" +
                         " ,[WON].[StoreID]	  [I7] " +
                         " ,[WON].[Mileage]	  [N1] " +
                         " ,[WON].[MileageOut]  [N2]" +
                         " ,[WON].[PONo]		  [S1] " +
                         " ,([WON].[PartsPrice] * -1)  [D1]" +
                         " ,([WON].[LaborPrice] * -1)  [D2]" +
                         " ,([WON].[OtherPrice] * -1)  [D3]" +
                         " ,([WON].[FET] * -1)		  [D4] " +
                         " ,([WON].[Taxable] * -1)	  [D5] " +
                         " ,([WON].[Tax] * -1)		  [D6] " +
                         " ,([WON].[Discount] * -1)	  [D7] " +
                         " ,([WON].[PartDisPer] * -1)  [D8]" +
                         " ,([WON].[Total] * -1)		  [D9]" +
                         " ,[Cus].[CompanyName] [S2] " +
                         " ,[Cus].[LastName]   [S3]" +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[Email]	  [S23] " +
                         " ,[Cus].[ContactPerson][S5]" +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10]" +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]" +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID]" +
                         " ,[Veh].[EngineSize]	[S13]" +
                         " ,[Veh].[PlateDate]    [Date2]" +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[Emp].[Initial]		[S18]" +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " ,([Cp].[CusCredit] * -1)[D10]" +
                         " ,([Cp].[PayByCash] * -1)[D13]" +
                         " ,([Cp].[PaybyCheck] * -1)   [D14]" +
                         " ,([Cp].[PayByDeposit] * -1)[D15]" +
                         " ,([Cp].[PayByVisa] * -1)[D16]" +
                         " ,([Cp].[PayByMC] * -1)[D17]" +
                         " ,([Cp].[PayByAMEX] * -1)[D18]" +
                         " ,([Cp].[PayByATM] * -1)[D19]" +
                         " ,([Cp].[ChgOnAccount] * -1)[D20]" +
                         " ,([Cp].[PayByDSCVR] * -1)[D21]" +
                         " ,([Cp].[TotalReceivedAmount] * -1)[D22]" +
                         " ,[Sv].[Name][S22]" +
                         " ,[CSA].[Address][S17]" +
                         " ,[Ter].[Name][S25]" +
                         " ,((Select IsNull(Sum(CusCredit),0) from CustomerReceipt where [CustomerReceipt].[CustomerID] = [Cus].[ID]) - (Select IsNull(Sum(CusCredit),0) from CustomerPayment where [CustomerPayment].[CustomerID] = [Cus].[ID]) )[D12] " +
                         " FROM [dbo].[WorkOrderNegate][WON] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WON].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WON].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WON].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WON].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WON].[SaleTaxRateID] = [Str].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WON].[SaleRepID] = [Emp].[ID]" +
                         " LEFT JOIN [dbo].[CustomerPayment] [Cp] ON [WON].[ID] = [Cp].[WONID]" +
                         " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WON].[ShipViaID] = [Sv].[ID] " +
                         " LEFT JOIN [dbo].[Terms] [Ter] ON [WON].[SaleTermID] = [Ter].[ID] " +
                         " WHERE [WON].[ID]=" + ID;

            return Qry;

        }

        public string NegatedWorkOrderReportCustomerCopyDetailQry(int ID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOND.[ID] ,[WOND].[MID]	 " +
                         " ,[WOND].[ItemID]	[I2] " +
                         " ,[WOND].[FeeID]	[I3] " +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4] " +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)	[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOND].[Ctype]		[S18] " +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND  " +
                         " Left Join [dbo].[Item] itm on WOND.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOND.[ID] " +
                         " ,[WOND].[MID]	  " +
                         " ,[WOND].[ItemID]	[I2] " +
                         " ,[WOND].[FeeID]	[I3] " +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4] " +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOND].[Ctype]		[S18]" +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND  " +
                         " Left Join [dbo].[Fees] itm on WOND.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOND.[ID] " +
                         " ,[WOND].[MID]	    " +
                         " ,[WOND].[ItemID]	[I2] " +
                         " ,[WOND].[FeeID]	[I3]" +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4] " +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOND].[Ctype]		[S18] " +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND  " +
                         " Left Join [dbo].[Labor] itm on WOND.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOND.[ID] " +
                         " ,[WOND].[MID]	    " +
                         " ,[WOND].[ItemID]	[I2] " +
                         " ,[WOND].[FeeID]	[I3] " +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4] " +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOND].[Ctype]		[S18] " +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOND.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.PackageID is not null AND WOND.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOND.[ID] ,[WOND].[MID]	  " +
                         " ,[WOND].[ItemID]	[I2] " +
                         " ,[WOND].[FeeID]	[I3] " +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4] " +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOND].[Ctype]		[S18]   " +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND  " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.VehicleInspectionID is not null AND WOND.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOND.[ID] " +
                         " ,[WOND].[MID]	  " +
                         " ,[WOND].[ItemID]	[I2]" +
                         " ,[WOND].[FeeID]	[I3] " +
                         " ,[WOND].[LaborID]	[I4] " +
                         " ,[WOND].[VehicleInspectionID]	[I8] " +
                         " ,[WOND].[InspectionHeadID]	[I5]      " +
                         " ,[WOND].[MechanicID]   [I6]   " +
                         " ,([WOND].[Qty] * -1)		[I7] " +
                         " ,[WOND].[Price]	[D1] " +
                         " ,[WOND].[Cost]		[D2] " +
                         " ,([WOND].[Amount] * -1)	[D3] " +
                         " ,([WOND].[DiscPer] * -1)	[D4]" +
                         " ,([WOND].[DiscAmount] * -1)	[D5] " +
                         " ,([WOND].[FET] * -1)		[D6] " +
                         " ,([WOND].[Total] * -1)	[D7] " +
                         " ,([WOND].[SaleTaxRate] * -1)	[D8] " +
                         " ,([WOND].[Tax] * -1)		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOND].[Ctype]		[S18] " +
                         " ,[WOND].[Comments]	[S19] " +
                         " FROM [dbo].[WorkOrderNegateDetail] WOND " +
                         " Left Join [dbo].[Labor] itm on WOND.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on WOND.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on WOND.RepID = emp1.id where WOND.InspectionHeadID is not null  ) tbl where MID =  " + ID + " Order by [ID]";

            return Qry;
        }


        public string CustomerInvoiceReportMasterQry(int ID)
        {
            
            string Qry = "  SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate][Date1] " +
                         " ,IsNull([Csr].[InvoiceNo],0) [I8] " +
                         " ,[WO].[WorkOrderNo] [I2] " +
                         " ,[WO].[CustomerID]  [I1]" +
                         " ,[WO].[VehicleID]	  [I3] " +
                         " ,[WO].[SaleRepID]	  [I4]" +
                         " ,[WO].[MechID]	  [I5] " +
                         " ,[WO].[ReferredByID][I6]" +
                         " ,[WO].[StoreID]	  [I7] " +
                         " ,[WO].[Mileage]	  [N1] " +
                         " ,[WO].[MileageOut]  [N2]" +
                         " ,[WO].[PONo]		  [S1] " +
                         " ,[WO].[PartsPrice]  [D1]" +
                         " ,[WO].[LaborPrice]  [D2]" +
                         " ,[WO].[OtherPrice]  [D3]" +
                         " ,[WO].[FET]		  [D4] " +
                         " ,[WO].[Taxable]	  [D5] " +
                         " ,[WO].[Tax]		  [D6] " +
                         " ,[WO].[Discount]	  [D7] " +
                         " ,[WO].[PartDisPer]  [D21]" +
                         " ,[WO].[Total]		  [D9]" +
                         " ,[Cus].[CompanyName] [S2] " +
                         " ,[Cus].[LastName]   [S3]" +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[Email]	  [S23] " +
                         " ,[Cus].[ContactPerson][S5]" +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10]" +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]" +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID]" +
                         " ,[Veh].[EngineSize]	[S13]" +
                         " ,[Veh].[PlateDate]    [Date2]" +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[Emp].[Initial]		[S18]" +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " ,[Csr].[CusCredit][D10]" +
                         " ,[Csr].[PayByCash][D13]" +
                         " ,[Csr].[PaybyCheck]   [D14]" +
                         " ,[Csr].[PayByGY][D15]" +
                         " ,[Csr].[PayByVisa][D16]" +
                         " ,[Csr].[PayByMC][D17]" +
                         " ,[Csr].[PayByAMEX][D18]" +
                         " ,[Csr].[PayByATM][D19]" +
                         " ,[Csr].[ChgOnAccount][D20]" +
                         " ,[Csr].[PayByDSCVR][D8]" +
                         " ,[Csr].[TotalReceivedAmount][D22]" +
                         " ,[Sv].[Name][S22]" +
                         " ,[CSA].[Address][S17]" +
                         " ,[Ter].[Name][S25]" +
                         " ,((Select IsNull(Sum(CusCredit),0) from CustomerReceipt where [CustomerReceipt].[CustomerID] = [Cus].[ID]) - (Select IsNull(Sum(CusCredit),0) from CustomerPayment where [CustomerPayment].[CustomerID] = [Cus].[ID]) )[D12] " +
                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
                         " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
                         " LEFT JOIN [dbo].[Terms] [Ter] ON [WO].[SaleTermID] = [Ter].[ID] " +
                         " WHERE [WO].[ID]=" + ID;

            return Qry;

        }



        public string WorkOrderReportCustomerCopyMasterQry(int ID)
        {
            //string Qry = "  SELECT [WO]. [ID] " +
            //             " ,[WO].[AddDate][Date1] " +
            //             " ,(Select ReceiptID from CustomerReceipt where WOID=wo.ID) [I2] " +
            //             " ,[WO].[CustomerID]  [I1]" +
            //             " ,[WO].[VehicleID]	  [I3] " +
            //             " ,[WO].[SaleRepID]	  [I4]" +
            //             " ,[WO].[MechID]	  [I5] " +
            //             " ,[WO].[ReferredByID][I6]" +
            //             " ,[WO].[StoreID]	  [I7] " +
            //             " ,[WO].[Mileage]	  [N1] " +
            //             " ,[WO].[MileageOut]  [N2]" +
            //             " ,[WO].[PONo]		  [S1] " +
            //             " ,[WO].[PartsPrice]  [D1]" +
            //             " ,[WO].[LaborPrice]  [D2]" +
            //             " ,[WO].[OtherPrice]  [D3]" +
            //             " ,[WO].[FET]		  [D4] " +
            //             " ,[WO].[Taxable]	  [D5] " +
            //             " ,[WO].[Tax]		  [D6] " +
            //             " ,[WO].[Discount]	  [D7] " +
            //             " ,[WO].[PartDisPer]  [D8]" +
            //             " ,[WO].[Total]		  [D9]" +
            //             " ,[Cus].[CompanyName] [S2] " +
            //             " ,[Cus].[LastName]   [S3]" +
            //             " ,[Cus].[Address]	  [S4] " +
            //             " ,[Cus].[Email]	  [S23] " +
            //             " ,[Cus].[ContactPerson][S5]" +
            //             " ,[Sca].[WorkorderMessage]	[S6] " +
            //             " ,[Veh].[LicensePlate] [S10]" +
            //             " ,[Veh].[VIN]			[S11] " +
            //             " ,[Veh].[FleetNumber]  [S12]" +
            //             " ,[Veh].[VehicleModelID][I13] " +
            //             " ,[Veh].[VehicleColorID][I14] " +
            //             " ,[Veh].[VehicleTransmissionID]" +
            //             " ,[Veh].[EngineSize]	[S13]" +
            //             " ,[Veh].[PlateDate]    [Date2]" +
            //             " ,[Veh].[Torque]		[S14] " +
            //             " ,[Vmo].[Name]			[S15] " +
            //             " ,[Vco].[Name]			[S16] " +
            //             " ,[Emp].[Initial]		[S18]" +
            //             " ,[Emp].[Name]			[S19] " +
            //             " ,[Str].[PartsRate]		[D11] " +
            //             " ,[Str].[Description]	[S21] " +
            //             " ,[CPH].[CusCredit][D10]" +
            //             " ,[CPH].[PayByCash][D13]" +
            //             " ,[CPH].[PaybyCheck]   [D14]" +
            //             " ,[CPH].[PayByDeposit][D15]" +
            //             " ,[CPH].[PayByVisa][D16]" +
            //             " ,[CPH].[PayByMC][D17]" +
            //             " ,[CPH].[PayByAMEX][D18]" +
            //             " ,[CPH].[PayByATM][D19]" +
            //             " ,[CPH].[ChgOnAccount][D20]" +
            //             " ,[CPH].[PayByDSCVR][D21]" +
            //             " ,[CPH].[PaidAmount][D22]" +
            //             " ,[Sv].[Name][S22]" +
            //             " ,[CSA].[Address][S17]" +
            //             " ,[Ter].[Name][S25]" +
            //             " FROM [dbo].[CustomerPaymentHistory][CPH] " +
            //             " LEFT JOIN [dbo].[CustomerPaymentTemp][CPT] ON [CPH].[ReceiptID] = [CPT].[ReceiptID] " +
            //             " LEFT JOIN [dbo].[WorkOrder][WO] ON [CPT].[WOID] = [WO].[ID] " +
            //             " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
            //             " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
            //             " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
            //             " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
            //             " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
            //             " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
            //             " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
            //             " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
            //             " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
            //             " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
            //             " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
            //             " LEFT JOIN [dbo].[Terms] [Ter] ON [WO].[SaleTermID] = [Ter].[ID] " +
            //             " WHERE [CPH].[ReceiptID]=" + ID;
            string Qry = "  SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate][Date1] " +
                         " ,IsNull([Csr].[InvoiceNo],0) [I8] " +
                         " ,[WO].[WorkOrderNo] [I2] " +                         
                         " ,[WO].[CustomerID]  [I1]" +
                         " ,[WO].[VehicleID]	  [I3] " +
                         " ,[WO].[SaleRepID]	  [I4]" +
                         " ,[WO].[MechID]	  [I5] " +
                         " ,[WO].[ReferredByID][I6]" +
                         " ,[WO].[StoreID]	  [I7] " +
                         " ,[WO].[Mileage]	  [N1] " +
                         " ,[WO].[MileageOut]  [N2]" +
                         " ,[WO].[PONo]		  [S1] " +
                         " ,[WO].[PartsPrice]  [D1]" +
                         " ,[WO].[LaborPrice]  [D2]" +
                         " ,[WO].[OtherPrice]  [D3]" +
                         " ,[WO].[FET]		  [D4] " +
                         " ,[WO].[Taxable]	  [D5] " +
                         " ,[WO].[Tax]		  [D6] " +
                         " ,[WO].[Discount]	  [D7] " +
                         " ,[WO].[PartDisPer]  [D21]" +
                         " ,[WO].[Total]		  [D9]" +
                         " ,[Cus].[CompanyName] [S2] " +
                         " ,[Cus].[LastName]   [S3]" +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[Email]	  [S23] " +
                         " ,[Cus].[ContactPerson][S5]" +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10]" +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]" +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID]" +
                         " ,[Veh].[EngineSize]	[S13]" +
                         " ,[Veh].[PlateDate]    [Date2]" +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[Emp].[Initial]		[S18]" +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " ,[Csr].[CusCredit][D10]" +
                         " ,[Csr].[PayByCash][D13]" +
                         " ,[Csr].[PaybyCheck]   [D14]" +
                         " ,[Csr].[PayByGY][D15]" +
                         " ,[Csr].[PayByVisa][D16]" +
                         " ,[Csr].[PayByMC][D17]" +
                         " ,[Csr].[PayByAMEX][D18]" +
                         " ,[Csr].[PayByATM][D19]" +
                         " ,[Csr].[ChgOnAccount][D20]" +
                         " ,[Csr].[PayByDSCVR][D8]" +
                         " ,[Csr].[TotalReceivedAmount][D22]" +
                         " ,[Sv].[Name][S22]" +
                         " ,[CSA].[Address][S17]" +
                         " ,[Ter].[Name][S25]" +
                         " ,((Select IsNull(Sum(CusCredit),0) from CustomerReceipt where [CustomerReceipt].[CustomerID] = [Cus].[ID]) - (Select IsNull(Sum(CusCredit),0) from CustomerPayment where [CustomerPayment].[CustomerID] = [Cus].[ID]) )[D12] " +
                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
                         " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
                         " LEFT JOIN [dbo].[Terms] [Ter] ON [WO].[SaleTermID] = [Ter].[ID] " +
                         " WHERE [WO].[ID]=" + ID;

            return Qry;

        }

        //public string WorkOrderReportCustomerCopyMasterQry(int ID)
        //{
        //    string Qry = "  SELECT [WO]. [ID] " +
        //                 " ,[WO].[AddDate][Date1] " +
        //                 " ,(Select ReceiptID from CustomerReceipt where WOID=wo.ID) [I2] " +
        //                 " ,[WO].[CustomerID]  [I1]" +
        //                 " ,[WO].[VehicleID]	  [I3] " +
        //                 " ,[WO].[SaleRepID]	  [I4]" +
        //                 " ,[WO].[MechID]	  [I5] " +
        //                 " ,[WO].[ReferredByID][I6]" +
        //                 " ,[WO].[StoreID]	  [I7] " +
        //                 " ,[WO].[Mileage]	  [N1] " +
        //                 " ,[WO].[MileageOut]  [N2]" +
        //                 " ,[WO].[PONo]		  [S1] " +
        //                 " ,[WO].[PartsPrice]  [D1]" +
        //                 " ,[WO].[LaborPrice]  [D2]" +
        //                 " ,[WO].[OtherPrice]  [D3]" +
        //                 " ,[WO].[FET]		  [D4] " +
        //                 " ,[WO].[Taxable]	  [D5] " +
        //                 " ,[WO].[Tax]		  [D6] " +
        //                 " ,[WO].[Discount]	  [D7] " +
        //                 " ,[WO].[PartDisPer]  [D8]" +
        //                 " ,[WO].[Total]		  [D9]" +
        //                 " ,[Cus].[CompanyName] [S2] " +
        //                 " ,[Cus].[LastName]   [S3]" +
        //                 " ,[Cus].[Address]	  [S4] " +
        //                 " ,[Cus].[Email]	  [S23] " +
        //                 " ,[Cus].[ContactPerson][S5]" +
        //                 " ,[Sca].[WorkorderMessage]	[S6] " +
        //                 " ,[Veh].[LicensePlate] [S10]" +
        //                 " ,[Veh].[VIN]			[S11] " +
        //                 " ,[Veh].[FleetNumber]  [S12]" +
        //                 " ,[Veh].[VehicleModelID][I13] " +
        //                 " ,[Veh].[VehicleColorID][I14] " +
        //                 " ,[Veh].[VehicleTransmissionID]" +
        //                 " ,[Veh].[EngineSize]	[S13]" +
        //                 " ,[Veh].[PlateDate]    [Date2]" +
        //                 " ,[Veh].[Torque]		[S14] " +
        //                 " ,[Vmo].[Name]			[S15] " +
        //                 " ,[Vco].[Name]			[S16] " +
        //                 " ,[Emp].[Initial]		[S18]" +
        //                 " ,[Emp].[Name]			[S19] " +
        //                 " ,[Str].[PartsRate]		[D11] " +
        //                 " ,[Str].[Description]	[S21] " +
        //                 " ,[Csr].[PayByCash][D13]" +
        //                 " ,[Csr].[PaybyCheck]   [D14]" +
        //                 " ,[Csr].[PayByDeposit][D15]" +
        //                 " ,[Csr].[PayByVisa][D16]" +
        //                 " ,[Csr].[PayByMC][D17]" +
        //                 " ,[Csr].[PayByAMEX][D18]" +
        //                 " ,[Csr].[PayByATM][D19]" +
        //                 " ,[Csr].[ChgOnAccount][D20]" +
        //                 " ,[Csr].[PayByDSCVR][D21]" +
        //                 " ,[Csr].[TotalReceivedAmount][D22]" +
        //                 " ,[Sv].[Name][S22]" +
        //                 " ,[CSA].[Address][S17]" +
        //                 " ,[Ter].[Name][S25]" +
        //                 " FROM [dbo].[WorkOrder][WO] " +
        //                 " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
        //                 " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
        //                 " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
        //                 " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
        //                 " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
        //                 " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
        //                 " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
        //                 " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
        //                 " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
        //                 " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
        //                 " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
        //                 " LEFT JOIN [dbo].[Terms] [Ter] ON [WO].[SaleTermID] = [Ter].[ID] " +
        //                 " WHERE [WO].[ID]=" + ID;

        //    return Qry;

        //public string WorkOrderReportCustomerCopyDetailQry(string IDs)
        //{
        //    string Qry = " SELECT * FROM (" +
        //                 " SELECT WOD.[ID] ,[WOD].[MID]	 " +
        //                 " ,[WOD].[ItemID]	[I2] " +
        //                 " ,[WOD].[FeeID]	[I3] " +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4] " +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +


        //                 " ,emp.Initial [S13] " +
        //                 " ,emp1.Initial [S14]  " +
        //                 " ,itm.[Catalog] [S11] " +
        //                 " ,itm.[Name] [S12] " +
        //                 " ,[WOD].[Ctype]		[S18] " +
        //                 " FROM [dbo].[WorkOrderDetail] WOD  " +
        //                 " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
        //                 " UNION ALL" +
        //                 " SELECT WOD.[ID] " +
        //                 " ,[WOD].[MID]	  " +
        //                 " ,[WOD].[ItemID]	[I2] " +
        //                 " ,[WOD].[FeeID]	[I3] " +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4] " +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +
        //                 " ,emp.Initial [S13] " +
        //                 " ,emp1.Initial [S14]  " +
        //                 " ,itm.[Catalog] [S11] " +
        //                 " ,itm.[Name] [S12]  " +
        //                 " ,[WOD].[Ctype]		[S18]" +
        //                 " FROM [dbo].[WorkOrderDetail] WOD  " +
        //                 " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
        //                 " UNION ALL" +
        //                 " SELECT WOD.[ID] " +
        //                 " ,[WOD].[MID]	    " +
        //                 " ,[WOD].[ItemID]	[I2] " +
        //                 " ,[WOD].[FeeID]	[I3]" +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4] " +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +
        //                 " ,emp.Initial [S13] " +
        //                 " ,emp1.Initial [S14]  " +
        //                 " ,itm.[Catalog] [S11] " +
        //                 " ,itm.[Name] [S12] " +
        //                 " ,[WOD].[Ctype]		[S18] " +
        //                 " FROM [dbo].[WorkOrderDetail] WOD  " +
        //                 " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
        //                 " UNION ALL  " +
        //                 " SELECT WOD.[ID] " +
        //                 " ,[WOD].[MID]	    " +
        //                 " ,[WOD].[ItemID]	[I2] " +
        //                 " ,[WOD].[FeeID]	[I3] " +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4] " +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +
        //                 " ,emp.Initial [S13] " +
        //                 " ,emp1.Initial [S14]  " +
        //                 " ,itm.[Catalog] [S11] " +
        //                 " ,itm.[Name] [S12] " +
        //                 " ,[WOD].[Ctype]		[S18] " +
        //                 " FROM [dbo].[WorkOrderDetail] WOD  " +
        //                 " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
        //                 " UNION ALL  " +
        //                 " SELECT WOD.[ID] ,[WOD].[MID]	  " +
        //                 " ,[WOD].[ItemID]	[I2] " +
        //                 " ,[WOD].[FeeID]	[I3] " +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4] " +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +
        //                 " ,emp.Initial [S13]" +
        //                 " ,emp1.Initial [S14] " +
        //                 " ,[S11] = 'Inspection Head' " +
        //                 " ,[S12] = 'Inspection Head'" +
        //                 " ,[WOD].[Ctype]		[S18]   " +
        //                 " FROM [dbo].[WorkOrderDetail] WOD  " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
        //                 " UNION ALL " +
        //                 " SELECT WOD.[ID] " +
        //                 " ,[WOD].[MID]	  " +
        //                 " ,[WOD].[ItemID]	[I2]" +
        //                 " ,[WOD].[FeeID]	[I3] " +
        //                 " ,[WOD].[LaborID]	[I4] " +
        //                 " ,[WOD].[VehicleInspectionID]	[I8] " +
        //                 " ,[WOD].[InspectionHeadID]	[I5]      " +
        //                 " ,[WOD].[MechanicID]   [I6]   " +
        //                 " ,[WOD].[Qty]		[I7] " +
        //                 " ,[WOD].[Price]	[D1] " +
        //                 " ,[WOD].[Cost]		[D2] " +
        //                 " ,[WOD].[Amount]	[D3] " +
        //                 " ,[WOD].[DiscPer]	[D4]" +
        //                 " ,[WOD].[DiscAmount]	[D5] " +
        //                 " ,[WOD].[FET]		[D6] " +
        //                 " ,[WOD].[Total]	[D7] " +
        //                 " ,[WOD].[SaleTaxRate]	[D8] " +
        //                 " ,[WOD].[Tax]		[D9] " +
        //                 " ,emp.Initial [S13] " +
        //                 " ,emp1.Initial [S14]  " +
        //                 " ,itm.[Catalog] [S11] " +
        //                 " ,itm.[Name] [S12]  " +
        //                 " ,[WOD].[Ctype]		[S18] " +
        //                 " FROM [dbo].[WorkOrderDetail] WOD " +
        //                 " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
        //                 " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
        //                 " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl " +
        //                 " Where CHARINDEX(',' + cast(MID as varchar(20)) + ',' , '" + IDs + "') > 0" +
        //                 //"MID =  " + ID +
        //                 " Order by [ID]";

        //    return Qry;
        //}

        //}
        public string WorkOrderReportCustomerCopyDetailQry(int ID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]	 " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18]   " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD " +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl where MID =  " + ID + " Order by [ID]";

            return Qry;
        }
        public string WorkOrderReportStoreCopyMasterQry(int ID)
        {
            string Qry = "  SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate][Date1] " +
                         " ,(Select ReceiptID from CustomerReceipt where WOID=wo.ID) [I2] " +
                         " ,[WO].[CustomerID]  [I1]" +
                         " ,[WO].[VehicleID]	  [I3] " +
                         " ,[WO].[SaleRepID]	  [I4]" +
                         " ,[WO].[MechID]	  [I5] " +
                         " ,[WO].[ReferredByID][I6]" +
                         " ,[WO].[StoreID]	  [I7] " +
                         " ,[WO].[Mileage]	  [N1] " +
                         " ,[WO].[MileageOut]  [N2]" +
                         " ,[WO].[PONo]		  [S1] " +
                         " ,[WO].[PartsPrice]  [D1]" +
                         " ,[WO].[LaborPrice]  [D2]" +
                         " ,[WO].[OtherPrice]  [D3]" +
                         " ,[WO].[FET]		  [D4] " +
                         " ,[WO].[Taxable]	  [D5] " +
                         " ,[WO].[Tax]		  [D6] " +
                         " ,[WO].[Discount]	  [D7] " +
                         " ,[WO].[PartDisPer]  [D8]" +
                         " ,[WO].[Total]		  [D9]" +
                         " ,[Cus].[CompanyName] [S2] " +
                         " ,[Cus].[LastName]   [S3]" +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[Email]	  [S23] " +
                         " ,[Cus].[ShippingAddress]	  [S24] " +
                         " ,[Cus].[ContactPerson][S5]" +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10]" +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]" +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID]" +
                         " ,[Veh].[EngineSize]	[S13]" +
                         " ,[Veh].[PlateDate]    [Date2]" +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[CSA].[Address][S17]" +
                         " ,[Emp].[Initial]		[S18]" +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " ,[Csr].[PayByCash][D13]" +
                         " ,[Csr].[PaybyCheck]   [D14]" +
                         " ,[Csr].[PayByDeposit][D15]" +
                         " ,[Csr].[PayByVisa][D16]" +
                         " ,[Csr].[PayByMC][D17]" +
                         " ,[Csr].[PayByAMEX][D18]" +
                         " ,[Csr].[PayByATM][D19]" +
                         " ,[Csr].[ChgOnAccount][D20]" +
                         " ,[Csr].[PayByDSCVR][D21]" +
                         " ,[Csr].[TotalReceivedAmount][D22]" +
                         " ,[Sv].[Name][S22]" +
                         " ,[Ter].[Name][S25]" +
                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID]" +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
                         " LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
                         " LEFT JOIN [dbo].[Terms] [Ter] ON [WO].[SaleTermID] = [Ter].[ID] " +
                         " WHERE [WO].[ID]=" + ID;

            return Qry;
        }
        public string WorkOrderReportStoreCopyDetailQry(int ID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]	 " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18]   " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD " +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl where MID =  " + ID;

            return Qry;
        }
        public string WorkOrderReportWareHouseCopyMasterQry(int ID)
        {
            string Qry = "  SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate][Date1] " +
                         " ,(Select ReceiptID from CustomerReceipt where WOID=wo.ID) [I2] " +
                         " ,[WO].[CustomerID]  [I1] " +
                         " ,[WO].[VehicleID]	  [I3] " +
                         " ,[WO].[SaleRepID]	  [I4] " +
                         " ,[WO].[MechID]	  [I5] " +
                         " ,[WO].[ReferredByID][I6]" +
                         " ,[WO].[StoreID]	  [I7] " +
                         " ,[WO].[Mileage]	  [N1] " +
                         " ,[WO].[MileageOut]  [N2] " +
                         " ,[WO].[PONo]		  [S1] " +
                         " ,[WO].[PartsPrice]  [D1] " +
                         " ,[WO].[LaborPrice]  [D2] " +
                         " ,[WO].[OtherPrice]  [D3] " +
                         " ,[WO].[FET]		  [D4] " +
                         " ,[WO].[Taxable]	  [D5] " +
                         " ,[WO].[Tax]		  [D6] " +
                         " ,[WO].[Discount]	  [D7] " +
                         " ,[WO].[PartDisPer]  [D8] " +
                         " ,[WO].[Total]		  [D9] " +
                         " ,[Cus].[CompanyName] [S2] " +
                         " ,[Cus].[LastName]   [S3] " +
                         " ,[Cus].[Address]	  [S4] " +
                         " ,[Cus].[ContactPerson][S5] " +
                         " ,[Sca].[WorkorderMessage]	[S6] " +
                         " ,[Veh].[LicensePlate] [S10] " +
                         " ,[Veh].[VIN]			[S11] " +
                         " ,[Veh].[FleetNumber]  [S12]   " +
                         " ,[Veh].[VehicleModelID][I13] " +
                         " ,[Veh].[VehicleColorID][I14] " +
                         " ,[Veh].[VehicleTransmissionID] " +
                         " ,[Veh].[EngineSize]	[S13] " +
                         " ,[Veh].[PlateDate]    [Date2] " +
                         " ,[Veh].[Torque]		[S14] " +
                         " ,[Vmo].[Name]			[S15] " +
                         " ,[Vco].[Name]			[S16] " +
                         " ,[CSA].[Address][S17]" +
                         " ,[Emp].[Initial]		[S18] " +
                         " ,[Emp].[Name]			[S19] " +
                         " ,[Str].[PartsRate]		[D11] " +
                         " ,[Str].[Description]	[S21] " +
                         " ,[CPH].[PayByCash][D13]" +
                         " ,[CPH].[PaybyCheck]   [D14] " +
                         " ,[CPH].[PayByDeposit][D15]" +
                         " ,[CPH].[PayByVisa][D16]" +
                         " ,[CPH].[PayByMC][D17]" +
                         " ,[CPH].[PayByAMEX][D18]" +
                         " ,[CPH].[PayByATM][D19]" +
                         " ,[CPH].[ChgOnAccount][D20]" +
                         " ,[CPH].[PayByDSCVR][D21]" +
                         " ,[CPH].[TotalReceivedAmount][D22]" +
                         " ,[Sv].[Name][S22]" +
                         " ,[WStr].[CoName][S26]" +
                         " FROM [dbo].[CustomerPaymentHistory][CPH] " +
                         " LEFT JOIN [dbo].[CustomerPaymentTemp][CPT] ON [CPH].[ReceiptID] = [CPT].[ReceiptID] " +
                         " LEFT JOIN [dbo].[WorkOrder][WO] ON [CPT].[WOID] = [WO].[ID] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[CustomerShippingAddresses] [CSA] ON [WO].[CustomerID] = [Cus].[ID] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[VehicleModel] [Vmo] ON [Veh].[VehicleModelID] = [Vmo].[ID] " +
                         " LEFT JOIN [dbo].[VehicleColor] [Vco] ON [Veh].[VehicleColorID] = [Vco].[ID] " +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxCategory] [Sca] ON [WO].[SaleCategoryID] = [Sca].[ID]" +
                         " LEFT JOIN [dbo].[SaleTaxRates] [Str] ON [WO].[SaleTaxRateID] = [Str].[ID]" +
                         "LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         "LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
                         "LEFT JOIN [dbo].[ShipVia] [Sv] ON [WO].[ShipViaID] = [Sv].[ID] " +
                         "LEFT JOIN [dbo].[WarehouseStore] [WStr] ON [WO].[StoreID] = [WStr].[ID] " +
                         " WHERE [CPH].[ReceiptID]=" + ID;
                         //"WHERE [WO].[ID]=" + ID;

            return Qry;
        }

        public string WorkOrderReportWareHouseCopyDetailQry(string IDs)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]	 " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18]   " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD " +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl " +
                         " Where CHARINDEX(',' + cast(MID as varchar(20)) + ',' , '" + IDs + "') > 0 ";
                         

            return Qry;
        }

        public string WorkOrderReportWareHouseCopyDetailQry(int ID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]	 " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +


                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18]   " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH' " +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD " +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl where MID =  " + ID;

            return Qry;
        }     
        public string VendorBillMasterQry(int ID)
        {
            string Qry = "SELECT [Vb].[ID] , [Vb].[BillID][I11]	 , [Vb].[VendorID]	[I1] , [Vb].[InvoiceNo]	[S1] , [Vb].[POID]		[I2] , [Vb].[BillDate]	[Date1] , [Vb].[DueDate]	[Date2] , [Vb].[Discount]   [D2]    , [Vb].[BillTotalAmount]	[D4] , [Vb].[SaleTaxDiscountPrice]	[D9] ,[Ven].[Name]    [S5] , [Ven].[Email]	[S6] , [Ven].[Phone]	[S7] , [Ven].[Fax]		[S8] , [Ven].[Address]	[S9]"+
                         //, [Ven].[CityID]	[I8] , [Cty].[Name]	[S14] 
                         " ,[Vb].[PaidAmount]	[D11],  [D5]=(Select isnull (sum(BillDiscount),0) from VendorPayment where BillID = [Vb].BillID) ,[D3]=(Select isnull (sum(PaidAmount),0) from VendorPayment where BillID = [Vb].BillID) ,[D1] = (Select SUM(ISNULL(BillTotalAmount,0)) - (Select (SUM(ISNULL(BillDiscount,0))  + SUM(ISNULL(PaidAmount,0))) from VendorPayment where vendorID = [Ven].ID) from VendorBill where vendorID = [Ven].ID) " +
                         " FROM [dbo].[VendorBill] [Vb]  LEFT JOIN [dbo].[Vendor] [Ven] ON [Vb].[VendorID] = [Ven].[ID]  " +
                         " LEFT JOIN [dbo].[WarehouseStore] [Wst] ON [Vb].[StoreID] = [Wst].[ID] " +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Ven].[CityID] = [Cty].[ID]"+
                         " WHERE [Vb].[BillID] =" + ID;
            return Qry;
        }
        public string VendorBillDetailQry(int ID)
        {
            string Qry = "SELECT  [Vbd].[ID]" +
                         " ,[Vbd].[MID]" +
                         " ,[Vbd].[ItemID][I1]" +
                         " ,[Vbd].[Catalog][S1]" +
                         " ,[Vbd].[Name]	[S2]" +
                         " ,[Vbd].[BillQty][I2]" +
                         " ,[Vbd].[CatalogCost][D1]" +
                         " ,[Vbd].[BillAmount] [D2]     " +
                         " ,[Itm].[ItemSize]	[S3]" +

                         " FROM [dbo].[VendorBillDetails] [Vbd]" +
                         " Left join [VendorBill] [VB] ON [Vbd].[MID] = [VB].[ID]" +
                         " Left join [Item][Itm]on [Vbd].[ItemID] = [Itm].[ID]" +

                         " WHERE [Vb].[BillID] = " + ID;
            return Qry;
        }
        public string VendorLedgerReportMasterQry(int ID)
        {
            string Qry = " SELECT [Vb].[ID] " +
                         " , [Vb].[BillID] [I1]" +
                         " , [Vb].[VendorID][I2]" +
                         " , [Vb].[InvoiceNo][S1]" +
                         " , [Vb].[POID]	[I3]" +
                         " , [Vb].[BillDate][Date1]" +
                         " , [Vb].[DueDate][Date2]" +
                         " , [Vb].[BillTotalAmount][D1]" +
                         " , [Vb].[GridTotalAmount][D2]" +
                         " , [Vb].[SaleTaxDiscountPrice][D3]" +
                         " ,[Ven].[Name][S3]" +
                         " , [Ven].[Email][S8]" +
                         " , [Ven].[Phone][S4]" +
                         " , [Ven].[Fax][S6]" +
                         " , [Ven].[Address][S5]" +
                          //" , [Ven].[CityID][I4]" +
                          //" , [Cty].[Name]	[S7]" +
                          " , [Vb].[PaidAmount]	[D11]" +
                          " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where BillID = [Vb].BillID) " +
                          " ,[D5] = (Select SUM(ISNULL(BillTotalAmount,0)) - (Select (SUM(ISNULL(BillDiscount,0))  + SUM(ISNULL(PaidAmount,0))) from VendorPayment where vendorID = [Ven].ID) from VendorBill where vendorID = [Ven].ID) " +
                         " FROM [dbo].[VendorBill] [Vb]  " +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Vb].[VendorID] = [Ven].[ID] " +
                         " LEFT JOIN [dbo].[WarehouseStore] [Wst] ON [Vb].[StoreID] = [Wst].[ID] " +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Ven].[CityID] = [Cty].[ID]  "
                         " WHERE [Vb].[vendorID] = " + ID;


            return Qry;
        }
        public string VendorLedgerReportDetailQry(int ID)
        {
            string Qry = " SELECT  [VP].[ID]  ,[VP].[PaymentID][I1]  ,[VP].[VendorID][I2]  ,[VP].[BillID][I3] " +
                         " ,[VP].[InvoiceNo][S1]  ,[VP].[BillAmount][D1]  ,[VP].[BillDiscount][D2] " +
                         " ,[VP].[PaidAmount][D3]  ,[VP].[BillBalance]  [D4]  ,[VP].[AddDate][Date1] from [dbo].[VendorPayment][VP]   LEFT JOIN [dbo].[VendorBill][VB] ON [VB].[BillID] = [VP].[BillID]  where [VB].[VendorID]=" + ID;
            return Qry;
        }                  
        //-----------------------------------------------------------------------------------------------------

        public string CustomerTransactionCompleteReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT [Wo].[ID]" +
                         " ,[Csr].[InvoiceNo] [I1]" +
                         " ,[Wo].[CustomerID] [I2]" +
                         " ,[Wo].[VehicleID] [I3]" +
                         " ,[Wo].[SaleRepID] [I4]" +
                         " ,[Wo].[AddDate] [Date1]" +
                         " ,[Wo].[Total] [D1]" +
                         " ,[Cus].[CompanyName] [S1]" +
                         " ,[Cus].[LastName] [S2]" +
                         " ,[Veh].[LicensePlate] [S3]" +
                         " ,[Veh].[FleetNumber] [S4]" +
                         " ,[Emp].[Initial] [S5]" +
                         " ,[Csr].[TotalReceivedAmount] [D2]" +
                         " ,[Csr].[TotalReceivedAmount] [D3]" +
                         " FROM [dbo].[WorkOrder] [Wo]" +
                         " LEFT JOIN [dbo].[Customer] [Cus] On [Wo].[CustomerID] = [Cus].[ID]" +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] On [Wo].[VehicleID] = [Veh].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] On [Wo].[SaleRepID] = [Emp].[ID]" +
                         " inner JOIN [dbo].[CustomerReceipt] [Csr] On [Wo].[ID] = [Csr].[WOID]" +
                         " WHERE [Csr].[CompanyID]= " + StaticInfo.CompanyID + " And ([Csr].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Csr].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
                        if(CustomerID > 0)
                            Qry += "AND [Wo].[CustomerID] = "+CustomerID;

            return Qry;
        }
        public string CustomerTransactionCompleteReportDetailQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]" +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +

                         "  ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         "  ,[WOD].[MechanicID]   [I6]   " +
                         "  ,[WOD].[Qty]		[I7] " +
                         "  ,[WOD].[Price]	[D1] " +
                         "  ,[WOD].[Cost]		[D2] " +
                         "  ,[WOD].[Amount]	[D3] " +
                         "  ,[WOD].[DiscPer]	[D4] " +
                         "  ,[WOD].[DiscAmount]	[D5] " +
                         "  ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6] " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH'" +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8]" +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl"+
                         " Left Join [dbo].[WorkOrder] [Wo] on [Wo].ID = tbl.MID"+
                         " WHERE [WO].[CompanyID]= " + StaticInfo.CompanyID + " And ([WO].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [WO].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [Wo].[CustomerID] = " + CustomerID;

            return Qry;
        }       
      
        public string InventoryTransectionReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Wo].[ID]" +
                         " ,[Wo].[WorkOrderNo][I1] " +
                         " ,[Wo].[CustomerID][I2]" +
                         " ,[Wod].[MID] [I3]  " +
                         " ,[Wod].[LaborID][I4]  " +
                         " ,[Wod].[Qty] [I5]    " +
                         " ,[Wod].[Price]  [D1]   " +
                         " ,[Wod].[Amount] [D2]  " +
                         " ,[Wod].[FET] [D3]  " +
                         " ,[Wod].[AddDate]  [Date1]" +
                         " ,[Cus].[CompanyName]  [S1]" +
                         " ,[Lab].[Catalog]  [S2]" +
                         " ,[Lab].[Name]  [S3]" +
                         " FROM [dbo].[WorkOrder] [Wo]" +
                         " LEFT JOIN [dbo].[WorkOrderDetail] [Wod] ON [Wo].[ID] = [Wod].[MID]" +
                         "  LEFT JOIN [dbo].[Labor] [Lab] ON [Wod].[LaborID] = [Lab].[ID] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [Wo].[CustomerID] = [Cus].[ID]" +
                         " WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') AND [Wod].[LaborID] IS NOT NULL";
                         

            return Qry;
        }
        public string InventoryTransectionByVendorReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Po].[ID]" +
                         " ,[Po].[VendorID][I1]" +
                         " ,[Po].[POID]     [I2]" +
                         " ,[Po].[AddDate] [Date1]" +
                         " ,[Ven].[Name] [S1]" +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] ON [Po].[VendorID] = [Ven].[ID]"+
                          " WHERE ([Po].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            return Qry;
        }
        public string InventoryTransectionByVendorReportDetailQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Pod].[ID]" +
                         " ,[Pod].[MID]" +
                         " ,[Pod].[ItemID][I1]" +
                         " ,[Pod].[PrevRcvd][I2]" +
                         " ,[Pod].[Cost][D1]" +
                         " ,[Pod].[FET][D2]" +
                         " ,[Pod].[Amount][D3]" +
                         " ,[Itm].[Catalog][S1]" +
                         " ,[Itm].[Name][S2]" +
                         " FROM [dbo].[PurchaseOrderDetails][Pod]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID] = [Itm].[ID]"+
                         " LEFT JOIN [dbo].[PurchaseOrder][Po] ON [Po].[ID] = [Pod].[MID]"+
                          " WHERE ([Po].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            return Qry;
        }     

        //---------------------------------------------
        public string PurchaseOrderHistoryReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Po]. [ID]" +
                         " ,[Po].[VendorID]	[I1]" +
                         " ,[Po].[POID]      [I2]" +
                         " ,[Po].[Reference] [S1]" +
                         " ,[Po].[StoreID]   [I3]" +
                         " ,[Po].[WarehouseID][I4]" +
                         " ,[Po].[DiscountPer]    [D1]" +
                         " ,[Po].[PODate]	[Date1]" +
                         " ,[Po].[AddUserID]	[I5]" +
                         " ,[Ven].[Name][S5]" +
                         " ,[Whs].[CoName][S6]" +
                         " ,[Emp].[Initial][S7]" +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " LEFT JOIN [dbo].[Warehouse] [Wh] ON [Po].[WarehouseID] = [Wh].[ID]" +
                         " LEFT JOIN [dbo].[WarehouseStore] [Whs] ON [Po].[StoreID] = [Whs].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [Po].[AddUserID] = [Emp].[ID]" +
                         //" LEFT JOIN [dbo].[State] [Sta] ON [Wh].[StateID] = [Sta].[ID]" +
                         //" LEFT JOIN [dbo].[Country] [Con] ON [Wh].[CountryID] = [Con].[ID]" +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Wh].[CityID] = [Cty].[ID]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Po].[VendorID] = [Ven].[ID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND ([Po].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";

            return Qry;
        }
        public string PurchaseOrderHistoryReportDetailQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT   [Pod].[ID]" +
                         " ,[Pod].[MID]" +
                         " ,[Pod].[ItemID][I1]" +
                         " ,[Pod].[QtyOrdrd][I2]" +
                         " ,[Pod].[PrevOrdrd][I3]" +
                         " ,[Pod].[QtyRcvd][I4]" +
                         " ,[Pod].[PrevRcvd][I5]" +
                         " ,[Pod].[QtyBilled][I6]" +
                         " ,[Pod].[PrevBilled][I7]" +
                         " ,[Pod].[Cost][D1]" +
                         " ,[Pod].[FET][D2]" +
                         " ,[Pod].[Amount][D3]          " +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name]      [S3]" +
                         " ,[Itm].[VendorID]	[I8]" +
                         " FROM [dbo].[PurchaseOrderDetails][Pod]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID]=[Itm].[ID]" +
                         " LEFT JOIN [dbo].[PurchaseOrder][Po] ON [Po].[ID] = [Pod].[MID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND ([Po].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";

              return Qry;
        }
        //---------------------------------------------
        public string PurchaseOrderVendorWiseReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = "  SELECT  [Po].[ID] " +
                         " ,[Po].[VendorID][I1] " +
                         " ,[Po].[POID] [I2] " +
                         " ,[Po].[DiscountPer][D1] " +
                         " ,[Po].[WarehouseID][I3] " +
                         " ,[Po].[StoreID][I4] " +
                         " ,[Po].[TotalAmountOrder][D2]" +
                         " ,[Po].[Reference][S2]" +
                         " ,[Po].[TotalAmountReceived][D3] " +
                         " ,[Po].[TotalAmountBilled][D4] " +
                         " ,[Po].[TotalQtyOrder][I5] " +
                         " ,[Po].[TotalQtyReceived][I6]" +
                         " ,[Po].[TotalQtyBilled] [I7] " +
                         " ,[Po].[PODate][Date1] " +
                         " ,[Ven].[Name][S8]" +
                         " ,[Emp].[Initial][S9] " +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " Left join [dbo].[Vendor][Ven] ON[Po].[VendorID]=[Ven].[ID]" +
                         " Left join [dbo].[Employee][Emp] ON[Po].[AddUserID]=[Emp].[ID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND (Po.PODate  >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND  Po.PODate <='" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (VendorID > 0)
                Qry += "AND [Po].[VendorID] = " + VendorID;

            return Qry;
        }
        public string PurchaseOrderVendorWiseReportDetailQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = "  SELECT   [Pod].[ID] " +
                         " ,[Pod].[MID] " +
                         " ,[Pod].[ItemID]    [I1] " +
                         " ,[Pod].[PrevOrdrd][I2]     " +
                         " ,[Pod].[PrevRcvd][I3] " +
                         " ,[Pod].[PrevBilled][I4] " +
                         " ,[Pod].[Cost][D1] " +
                         " ,[Pod].[FET][D2] " +
                         " ,[Pod].[Amount][D3] " +
                         " ,[Itm].[ItemSize][S1] " +
                         " ,[Itm].[Catalog][S2] " +
                         " ,[Itm].[Name]    [S3] " +
                         " ,[Itm].[VenderPartNo] [S4]      " +
                         " ,[Itm].[UnitWeight][D4] " +
                         " ,[Itm].[CatalogCost]  [D5] " +
                         " ,[Itm].[FET][D6] " +
                         " FROM [dbo].[PurchaseOrderDetails][Pod] " +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID]=[Itm].[ID]" +
                         " LEFT JOIN [dbo].[PurchaseOrder][Po] ON [Po].[ID]=[Pod].[MID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND (Po.PODate >=  '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND Po.PODate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (VendorID > 0)
                Qry += "AND [Po].[VendorID] = " + VendorID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string PurchaseOderBillWiseReportMasterQry(DateTime datefrom, DateTime dateto, Int32 BillIDF, Int32 BillIDT)
        {
            string Qry = "  SELECT [Vb].[ID] " +
                         " ,[Vb].[BillID][I1] " +
                         " ,[Vb].[VendorID][I2] " +
                         " ,[Vb].[InvoiceNo][S1] " +
                         " ,[Vb].[POID] [I3]      " +
                         " ,[Vb].[SaleTaxDiscountPercent][D1] " +
                         " ,[Vb].[GridTotalAmount][D3] " +
                         " ,[Vb].[BillTotalAmount][D4] " +
                         " ,[Vb].[StoreID][I4] " +
                         " ,[Vb].[Balance][D6] " +
                         " ,[Vb].[AddDate][Date1]" +
                         " ,[Ven].[Name] [S7] " +
                         " , [D2]=(Select isnull (sum(BillDiscount),0) from VendorPayment where BillID = [Vb].BillID) " +
                         " , [D5]=(Select isnull (sum(PaidAmount),0) from VendorPayment where BillID = [Vb].BillID)" +
                         " FROM [dbo].[VendorBill][Vb] " +
                         " LEFT JOIN [dbo].[Vendor][Ven] On [Vb].[VendorID]=[Ven].[ID]" +
                         " WHERE [Vb].[CompanyID]= " + StaticInfo.CompanyID + " AND (Vb.BillDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND Vb.BillDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (BillIDF > 0)
                Qry += "AND ([Vb].[BillID] >= '" + BillIDF + "'" +
                         " AND [Vb].[BillID] <= '" + BillIDT + "') ";

            return Qry;
        }
        public string PurchaseOrderBillWiseReportDetailQry(DateTime datefrom, DateTime dateto, Int32 BillIDF, Int32 BillIDT)
        {
            string Qry = "  SELECT  [Vbd]. [ID] " +
                         " ,[Vbd]. [MID] " +
                         " ,[Vbd]. [ItemID]	[I1] " +
                         " ,[Vbd]. [BillQty][I2] " +
                         " ,[Vbd]. [CatalogCost][D1] " +
                         " ,[Vbd]. [BillAmount][D2]  " +
                         " ,[Itm]. [Catalog][S1] " +
                         " ,[Itm]. [Name][S2] " +

                         " FROM [dbo].[VendorBillDetails] [Vbd] " +
                         " LEFT JOIN [dbo].[VendorBill] [Vb] ON [Vb]. [ID] = [Vbd].[MID] " +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Vbd]. [ItemID]=[Itm].[ID] " +
                         " WHERE [Vb].[CompanyID]= " + StaticInfo.CompanyID + " AND (Vb.BillDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND Vb.BillDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (BillIDF > 0)
                Qry += "AND ([Vb].[BillID] >= '" + BillIDF + "'" +
                         " AND [Vb].[BillID] <= '" + BillIDT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string PurchaseOrderItemWiseReportMasterQry(DateTime datefrom, DateTime dateto, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = "  SELECT  [Po].[ID] " +
                         " ,[Po].[VendorID][I1] " +
                         " ,[Po].[POID] [I2] " +
                         " ,[Po].[DiscountPer][D1] " +
                         " ,[Po].[WarehouseID][I3] " +
                         " ,[Po].[StoreID][I4] " +
                         " ,[Po].[TotalAmountOrder][D2]" +
                         " ,[Po].[Reference][S2]" +
                         " ,[Po].[TotalAmountReceived][D3] " +
                         " ,[Po].[TotalAmountBilled][D4] " +
                         " ,[Po].[TotalQtyOrder][I5] " +
                         " ,[Po].[TotalQtyReceived][I6]" +
                         " ,[Po].[TotalQtyBilled] [I7] " +
                         " ,[Po].[PODate][Date1] " +
                         " ,[Ven].[Name][S8]" +
                         " ,[Emp].[Initial][S9] " +
                         " FROM [dbo].[PurchaseOrder][Po]" +
                         " Left join [dbo].[Vendor][Ven] ON[Po].[VendorID]=[Ven].[ID]" +
                         " Left join [dbo].[Employee][Emp] ON[Po].[AddUserID]=[Emp].[ID]" +
                         " Left join [dbo].[PurchaseOrderDetails][Pod] On [Po].[ID] = [Pod].[MID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND ([Po].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Pod].[ItemID] <= '" + ItemIDT + "') ";


            return Qry;
        }
        public string PurchaseOrderItemWiseReportDetailQry(DateTime datefrom, DateTime dateto, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = "  SELECT   [Pod].[ID] " +
                         " ,[Pod].[MID] " +
                         " ,[Pod].[ItemID]    [I1] " +
                         " ,[Pod].[PrevOrdrd][I2]     " +
                         " ,[Pod].[PrevRcvd][I3] " +
                         " ,[Pod].[PrevBilled][I4] " +
                         " ,[Pod].[Cost][D1] " +
                         " ,[Pod].[FET][D2] " +
                         " ,[Pod].[Amount][D3] " +
                         " ,[Itm].[ItemSize][S1] " +
                         " ,[Itm].[Catalog][S2] " +
                         " ,[Itm].[Name]    [S3] " +
                         " ,[Itm].[VenderPartNo] [S4]      " +
                         " ,[Itm].[UnitWeight][D4] " +
                         " ,[Itm].[CatalogCost]  [D4] " +
                         " ,[Itm].[FET][D5] " +
                         " FROM [dbo].[PurchaseOrderDetails][Pod] " +
                         " LEFT JOIN [dbo].[Item][Itm] ON [Pod].[ItemID]=[Itm].[ID]" +
                         " LEFT JOIN [dbo].[PurchaseOrder][Po] ON [Po].[ID]=[Pod].[MID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND ([Po].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Pod].[ItemID] <= '" + ItemIDT + "') ";

            return Qry;
        }
        //----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorAgingTransactionReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = " SELECT [Vb]. [ID] " +
                         " ,[Vb]. [BillID]	[I1] " +
                         " ,[Vb]. [VendorID]	[I2]  " +
                         " ,[Vb]. [BillDate]	[Date1] " +
                         " ,[Vb]. [DueDate]	[Date2] " +
                         " ,[Vb]. [DueDate]	[Date3] " +
                         " ,[Vb]. [BillTotalAmount]	[D1] " +
                         " ,[Ven]. [TermsID]	[I3] " +
                         " ,[Trm]. [Name]	[S1] " +
                         " ,[Vb]. [InvoiceNo][S2] " +
                         " ,[Ven]. [Name]	[S3] " +

                         " FROM [dbo].[VendorBill] [Vb] " +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Vb]. [VendorID]=[Ven]. [ID] " +
                         " LEFT JOIN [dbo].[Terms] [Trm] ON [Ven]. [TermsID]=[Trm]. [ID]" +
                         " WHERE ([Vb].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Vb].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (VendorID > 0)
                Qry += "AND [Vb].[VendorID] = " + VendorID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorCheckPreparationReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = " SELECT [Vb]. [ID] " +
                         " ,[Vb]. [BillID]  [I1] " +
                         " ,[Vb]. [VendorID][I2] " +
                         " ,[Vb]. [AddDate][Date1] " +
                         " ,[Vb]. [DueDate]	[Date2] " +
                         " ,[Vb]. [DueDate]	[Date3] " +
                         " ,[Vb]. [BillTotalAmount][D1] " +
                         " , [D2]=(Select isnull (sum(BillDiscount),0) from VendorPayment where BillID = [Vb].BillID)" +
                         " , [D3]=(Select isnull (sum(PaidAmount),0) from VendorPayment where BillID = [Vb].BillID)" +
                         " ,[Ven]. [TermsID]	[I3] " +
                         " ,[Trm]. [Name][S1] " +
                         " ,[Vb]. [InvoiceNo][S2] " +
                         " ,[Ven]. [Name][S3] " +
                         //" ,[Cty]. [Name][S4] " +
                         " FROM [dbo].[VendorBill] [Vb] " +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Vb]. [VendorID]=[Ven]. [ID] " +
                         " LEFT JOIN [dbo].[Terms] [Trm] ON [Ven]. [TermsID]=[Trm]. [ID] " +
                         //" LEFT JOIN [dbo].[City] [cty] ON [Ven]. [CityID]=[cty]. [ID]" +
                         " WHERE ([Vb].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Vb].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (VendorID > 0)
                Qry += "AND [Vb].[VendorID] = " + VendorID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string WorkOrderOutSidepartByDateMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Wo].[ID]" +
                    " ,[Wo].[WorkOrderNo][I1]" +
                    " ,[Wo].[Notes]  [S1]	  " +
                    " ,[Wod].[MID]      [I2]" +
                    " ,[Wod].[ItemID]   [I3]" +
                    " ,[Wod].[Qty][I4]" +
                    " ,[Wod].[Price][D1]" +
                    " ,[Wod].[Cost][D2]" +
                    " ,[Wod].[Amount][D3]" +
                    " ,[Wod].[FET][D4]" +
                    " ,[Wod].[Total]  [D5]   " +
                    " ,[Wod].[AddDate]	  [Date1]" +
                    " ,[Itm].[Name][S2]" +
                    " ,[Ven].[Name][S3]" +

                    " FROM [dbo].[WorkOrder] [Wo]" +
                    " Left join [dbo].[WorkOrderDetail] [Wod] ON [Wo].[ID] = [Wod].[MID]" +
                    " Left join [dbo].[Item] [Itm] ON [Wod].[ItemID] = [Itm].[ID]" +
                    " Left join [dbo].[Vendor] [Ven] ON [Itm].[VendorID] = [Ven].[ID]" +
                    " WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                    " AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') AND [Itm].[IsOutsideItem]=1";


            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorPaidOutReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = " SELECT * FROM ( " +
                         " SELECT [VB].[ID] [I1], [VBB].[InvoiceNo][S2],[S1]  = 'Payment', [I2] = [VB].[BillID], [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [S3] = [VB].[InvoiceNo] " +
                         " ,[S10] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[PaidAmount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name] " +
                         " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         " FROM dbo.VendorPayment [VB] " +
                         " LEFT JOIN dbo.VendorBill [VBB] ON [VB].BillID = [VBB].BillID" +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID  " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID  " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID  " +
                         //"  LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID  " +
                         "  Where [VB].[PaidAmount] > 0 AND [VB].VendorID = [Ven].ID AND [VB].[IsPaid]=1" +
                         "  UNION ALL " +
                         "  SELECT [VB].[ID] [I1], [VBB].[InvoiceNo][S2],[S1] = 'Discount', [I2] = [VB].BillID, [Date1] = [VB].[TrnsDate], [Date2] = [VB].[TrnsDate], [Reference] = 'Discount' " +
                         "  ,[S4] = [trms].Name , [D1] = [VB].[BillAmount], [D2] = [VB].[BillDiscount], [D3] = [VB].[BillBalance], [S4] = [Ven].[Name], [S6] = [Ven].[Address], [S5] = [Ven].[Phone], [S7] = [Ven].[Fax]"+
                         //", [S8] = [cty].[Name] " +
                        " ,[D4]=(Select isnull (sum(BillDiscount),0) from VendorPayment where VendorID = [Ven].ID) " +
                         "  FROM dbo.VendorPayment [VB] " +
                         "  LEFT JOIN dbo.VendorBill [VBB] ON [VB].BillID = [VBB].BillID" +
                         "  LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID  " +
                         "  LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID " +
                         "  LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID  " +
                         //"  LEFT JOIN dbo.City [cty] ON [Ven].CityID = [cty].ID  " +
                         "  Where [VB].[BillDiscount] > 0 AND [VB].VendorID = [Ven].ID AND [VB].[IsPaid]=1" +
                         "  )tbl " +
                         "Left Join [dbo].[VendorPayment] [VP] on [VP].ID = tbl.I1" +
                         " Where ([VP].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [VP].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (VendorID > 0)
                Qry += "AND [VP].[VendorID] = " + VendorID;


            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorSummeryReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = " SELECT [Ven].[Name] [S1] ,[Ven].[Phone] [S2] ,[Ven].[Address] [S3] ," +
                         " [Date1]=(Select  (Max(AddDate)) from VendorPayment where VendorID = [Ven].ID AND CompanyID=" + StaticInfo.CompanyID +") ," +
                         " [Date2]=(Select  (Max(BillDate)) from VendorBill where VendorID = [Ven].ID AND CompanyID=" + StaticInfo.CompanyID + ") ," +
                         " [D1]=(Select isnull (sum(BillTotalAmount),0) from VendorBill where VendorID = [Ven].ID AND CompanyID=" + StaticInfo.CompanyID +
                         " AND VendorBill.[BillDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND VendorBill.[BillDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "' ) ," +
                         " [D2]=(Select isnull (sum(PaidAmount),0) from VendorPayment where VendorID = [Ven].ID AND IsPaid=1 AND Active=1 AND CompanyID=" + StaticInfo.CompanyID +
                         " AND VendorPayment.[TrnsDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND VendorPayment.[TrnsDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') " +
                         " FROM [dbo].[Vendor] [Ven] " +
                         " Where 1=1 ";

            if (VendorID > 0)
                Qry += " AND [Ven].[ID] = " + VendorID;



            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorTransectionReportMasterQry(DateTime datefrom, DateTime dateto, Int32 VendorID)
        {
            string Qry = " SELECT [Vb]. [ID] " +
                         " ,[Vb].[BillID]	[I1] " +
                         " ,[Vb].[VendorID]	[I2] " +
                         " ,[Vb].[BillDate]	[Date1]" +
                         " ,[Vb].[DueDate]	[Date2]  " +
                         " ,[Vb].[BillTotalAmount]	[D1] " +
                         " ,[D2]= (Select Sum([PaidAmount]) From VendorPayment Where IsPaid=1 AND Active=1 AND BillID=[Vb].[BillID]) " +
                         " ,[Ven].[TermsID]	[I3] " +
                         " ,[Trm].[Name]	[S1] " +
                         " ,[Vb].[InvoiceNo][S2] " +
                         " ,[Ven].[Name]	[S3] " +
                         " ,[Vb].[BillNotes][S4]" +
                         " ,[Vb].[BillType][S5]" +
                         " ,[Vb].[InvoiceNo][S6]" +

                         " FROM [dbo].[VendorBill] [Vb] " +                         
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Vb].[VendorID] = [Ven]. [ID] " +
                         " LEFT JOIN [dbo].[Terms] [Trm] ON [Ven].[TermsID] = [Trm]. [ID]" +
                         " Where [Vb].[CompanyID]=" + StaticInfo.CompanyID +
                         " AND ([Vb].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Vb].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";

            if (VendorID > 0)
                Qry += "AND [Vb].[VendorID] = " + VendorID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VendorListReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Ven].[ID]" +
                         " ,[Ven].[Code][S1]" +
                         " ,[Ven].[Name][S2]  " +
                         " ,[Ven].[Email][S3]" +
                         " ,[Ven].[Phone][S4]" +
                         " ,[Ven].[Fax]  [S5] " +
                         " ,[Ven].[Address][S6]" +
                         " ,[Ven].[FederalNo]  [S7]" +
                         " ,[Ven].[AddDate]      [Date1]" +                         
                         " FROM [dbo].[Vendor] [Ven]" +                         
                         " Where ([Ven].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Ven].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') order by [Ven].[Name]";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventorySaleReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I5]" +
                         " ,[Itm].[Catalog] [S1]" +
                         " ,[Igro].[Name]   [S2]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Itm].[ReOrderMin][I1]" +
                         " ,[I2]=(Select isnull ((sum(QtyOrdrd) + sum(PrevOrdrd)-(sum(QtyRcvd)+sum(PrevRcvd))),0) from PurchaseOrderDetails pod Left join PurchaseOrder po On pod.MID=po.ID where ItemID = [Ist].[ItemID] And po.CompanyID= " + StaticInfo.CompanyID + " and po.LastReceivedDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "' AND po.LastReceivedDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
                         " ,[I3]=(Select isnull (sum(Qty),0) from CustomerReceipt cr Left Join Workorder wo on cr.WOID=wo.ID Left Join WorkOrderDetail wod on wo.ID=wod.MID Where ItemID = [Ist].[ItemID] And wo.CompanyID= " + StaticInfo.CompanyID + " and cr.[ModifyDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "' AND cr.[ModifyDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
                         " ,[D1]=(Select isnull (sum(Amount),0) from CustomerReceipt cr Left Join Workorder wo on cr.WOID=wo.ID Left Join WorkOrderDetail wod on wo.ID=wod.MID where ItemID = [Ist].[ItemID] And wo.CompanyID= " + StaticInfo.CompanyID + " and cr.[ModifyDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "' AND cr.[ModifyDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
                         " ,[D2]=(Select isnull (sum(Amount),0) from PurchaseOrderDetails pod Left join PurchaseOrder po On pod.MID=po.ID where ItemID = [Ist].[ItemID] And po.CompanyID= " + StaticInfo.CompanyID + " and po.LastReceivedDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "' AND po.LastReceivedDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
                         " ,[Ist].[Qty]  [I4]" +
                         " ,[Itm].[CatalogCost]  [D3]" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]" +
                         " WHERE ([Ist].[ModifyDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Ist].[ModifyDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventorySaleTransectionReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Pod].[ID]" +
                         " ,[Pod].[MID][I1]" +
                         " ,[Pod].[ItemID][I2]" +
                         " ,[Pod].[QtyOrdrd][I3]" +
                         " ,[Pod].[PrevOrdrd][I4]" +
                         " ,[Pod].[QtyRcvd][I5]" +
                         " ,[Pod].[PrevRcvd][I6]" +
                         " ,[Pod].[QtyBilled][I7]" +
                         " ,[Pod].[PrevBilled]  [I8] " +
                         " ,[Pod].[FET][D1]" +
                         " ,[Pod].[Amount][D2]      " +
                         " ,[Pod].[AddDate][Date1]" +
                         " ,[Po].[POID][I9]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Ven].[Name][S4]" +

                         " FROM [dbo].[PurchaseOrderDetails] [Pod]" +
                         " LEFT JOIN [dbo].[PurchaseOrder] [Po] ON [Pod].[MID] = [Po].[ID]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Pod].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Po].[VendorID] = [Ven].[ID]" +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " And [Pod].[CompanyID]= " + StaticInfo.CompanyID + " And ([Po].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Pod].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Pod].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryMovementReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Itm].[Catalog] [S1]" +
                         " ,[Igro].[Name]   [S2]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Ist].[Qty]  [I2]" +
                         " ,[I3]=(Select isnull (sum(Qty),0) from WorkOrderDetail where ItemID = [Ist].[ItemID] And CompanyID= " + StaticInfo.CompanyID +")" + 
                         " ,[I4]=(Select isnull (sum(QtyOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID] And CompanyID= " + StaticInfo.CompanyID +")" +
                         " ,[Date1]=(Select  (MAX(AddDate)) from WorkOrderDetail where ItemID = [Ist].[ItemID] And CompanyID= " + StaticInfo.CompanyID + ")" +
                         " ,[Date2]=(Select (MAX(AddDate)) from PurchaseOrderDetails where ItemID = [Ist].[ItemID] And CompanyID= " + StaticInfo.CompanyID + ")" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]" +
                         " WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string VehicleListReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Veh].[ID]  " +
                         " ,[Veh].[CustomerID] [I1]" +
                         " ,[Veh].[VehicleModelID][I2]" +
                         " ,[Veh].[VehicleColorID][I3]" +
                         " ,[Veh].[VehicleSubModelID][I4]" +
                         " ,[Veh].[VehicleTransmissionID][I5]  " +
                         " ,[Veh].[LicensePlate][S1]" +
                         " ,[Veh].[VIN][S2]" +
                         " ,[Veh].[FleetNumber][S3]      " +
                         " ,[Veh].[EngineSize] [S4] " +
                         " ,[Veh].[AddDate]    [Date1]" +
                         " ,[Cus].[CompanyName][S5]" +
                         " ,[Cus].[LastName] [S6]" +
                         " ,[Cus].[Address]   [S7]" +

                         " FROM [dbo].[Vehicle] [Veh]" +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [Veh].[CustomerID] = [Cus].[ID]" +
                         " LEFT JOIN [dbo].[VehicleModel] [VMod] ON [Veh].[VehicleModelID] = [VMod].[ID]" +
                         " LEFT JOIN [dbo].[VehicleColor] [VCol] ON [Veh].[VehicleColorID] = [VCol].[ID]" +
                         " LEFT JOIN [dbo].[VehicleSubModel] [Vsub] ON [Veh].[VehicleSubModelID] = [Vsub].[ID]" +
                         " LEFT JOIN [dbo].[VehicleTransmission] [Vta] ON [Veh].[VehicleTransmissionID] = [Vta].[ID]" +
                         " WHERE ([Veh].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Veh].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string CustomerTransactionReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate] [Date1]" +
                         " ,[WO].[WorkOrderNo] [I1]" +
                         " ,[WO].[Total]		  [D1]" +
                         " ,[Cus].[CompanyName]  	[S1]" +
                         " ,[Cus].[ContactPerson]  	[S7] " +
                         " ,[Emp].[Initial]		 [S2]" +
                         " ,[Emp].[Name]			 [S3]" +
                         " ,[Veh].[LicensePlate]  [S6]   " +
                         " ,[Veh].[FleetNumber]  [S8]   " +
                         " ,[Csr].[PayByCash][D2]" +
                         " ,[Csr].[PaybyCheck]   [D3]         " +
                         " ,[Csr].[PayByDeposit][D4]" +
                         " ,[Csr].[PayByVisa][D5]" +
                         " ,[Csr].[PayByMC][D6]" +
                         " ,[Csr].[PayByAMEX][D7]" +
                         " ,[Csr].[PayByATM][D8]" +
                         " ,[Csr].[PayByGY][D9]" +
                         " ,[Csr].[PayByDSCVR][D10]" +
                         " ,[Csr].[TotalReceivedAmount][D11]" +

                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID]  " +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         " LEFT JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID]" +
                         " WHERE ([WO].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [WO].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string CustomerTransactionDetailReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT [WO]. [ID] " +
                         " ,[WO].[AddDate] [Date1]" +
                         " ,[Csr].[InvoiceNo] [I1]" +
                         " ,[WO].[Total]		  [D1]" +
                         " ,[Cus].[CompanyName]  	[S1]" +
                         " ,[Cus].[ContactPerson]  	[S7] " +
                         " ,[Emp].[Initial]		 [S2]" +
                         " ,[Emp].[Name]			 [S3]" +
                         " ,[Veh].[LicensePlate]  [S6]   " +
                         " ,[Veh].[FleetNumber]  [S8]   " +
                         " ,[Csr].[PayByCash][D2]" +
                         " ,[Csr].[PaybyCheck]   [D3]         " +
                         " ,[Csr].[PayByDeposit][D4]" +
                         " ,[Csr].[PayByVisa][D5]" +
                         " ,[Csr].[PayByMC][D6]" +
                         " ,[Csr].[PayByAMEX][D7]" +
                         " ,[Csr].[PayByATM][D8]" +
                         " ,[Csr].[PayByGY][D9]" +
                         " ,[Csr].[PayByDSCVR][D10]" +
                         " ,[Csr].[TotalReceivedAmount][D11]" +

                         " FROM [dbo].[WorkOrder][WO] " +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] ON [WO].[VehicleID] = [Veh].[ID] " +
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [WO].[CustomerID] = [Cus].[ID]  " +
                         " LEFT JOIN [dbo].[Employee] [Emp] ON [WO].[SaleRepID] = [Emp].[ID]" +
                         " inner JOIN [dbo].[CustomerReceipt] [Csr] ON [WO].[ID] = [Csr].[WOID] " +
                         " WHERE [Csr].[CompanyID]= " + StaticInfo.CompanyID + " And ([Csr].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Csr].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID;

            return Qry;
        }
        public string CustomerTransactionDetailReportDetailQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT [WOD].[ID]" +
                         " ,[WOD].[MID]" +
                         " ,[WOD].[ItemID] [I6] " +
                         " ,[WOD].[Qty] [I7]" +
                         " ,[WOD].[Price][D1]" +
                         " ,[WOD].[Cost][D2]" +
                         " ,[WOD].[Amount][D3]" +
                         " ,[WOD].[DiscPer][D8]" +
                         " ,[WOD].[DiscAmount][D5]" +
                         " ,[WOD].[FET][D6]" +
                         " ,[WOD].[Total][D7]" +
                         " ,[Itm].[Catalog][S11]" +
                         " ,[Itm].[Name][S12]" +
                         " FROM [dbo].[WorkOrderDetail] [WOD]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [WOD].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[WorkOrder] [Wo] ON [WO].[ID] = [WOD].[MID]" +
                         " WHERE ItemID is not null and [WO].[CompanyID]= " + StaticInfo.CompanyID + " And ([WO].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [WO].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID + "AND [Itm].[Catalog] is NOT NULL";
            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string TransactionSummeryReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = "SELECT [CR].[ID] ,[CR].[CustomerID][I1] ,[CR].[InvoiceNo][I5] ,0 AS [I2] ,[CR].[AddUserID][I3] ," +
                         " [WO].[PartsPrice][D1],[WO].[LaborPrice] [D2] ,[WO].[OtherPrice] [D3] ,[WO].[FET] [D4] ,0.00 as [D5] ,[WO].[Tax] [D6] ,[WO].[Discount][D7] ,0.00[D8] ,0.00[D9] ,[CR].[TotalReceivedAmount][D10],[Emp].[Initial][S8],[CR].[TrnsDate][Date1],[Cus].[CompanyName][S1] ,[Cus].[LastName][S2] ,[Cus].[ContactPerson][S3] ,wo.TotalProfit as [D11],''[S4] ,''[S5] ,''[S6] ,''[S7] FROM CustomerReceipt CR INNER join WorkOrder WO ON CR.WOID = WO.ID" +
                         " LEFT JOIN[dbo].[Customer][Cus] ON[CR].[CustomerID] = [Cus].[ID] LEFT JOIN[dbo].[Employee][Emp] ON[CR].[AddUserID] = [Emp].[ID] " +
                         " WHERE [CR].[CompanyID]= " + StaticInfo.CompanyID + " And ([CR].[TrnsDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [CR].[TrnsDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [CR].[CustomerID] = " + CustomerID;
            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InvoiceProfitDetailReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT [Wo].[ID]" +
                         " ,[Csr].[InvoiceNo][I1]" +
                         " ,[Wo].[CustomerID][I2]" +
                         " ,[Wo].[VehicleID][I3]" +
                         " ,[Wo].[SaleRepID][I4]" +
                         " ,[Csr].[AddDate][Date1]" +
                         " ,[Wo].[LaborPrice][D4]" +
                         " ,[Wo].[Total][D1]" +
                         " ,[Cus].[CompanyName][S1]" +
                         " ,[Cus].[LastName][S2]" +
                         " ,[Veh].[LicensePlate][S3]" +
                         " ,[Veh].[FleetNumber][S4]" +
                         " ,[Emp].[Initial][S5]" +
                         " ,[Csr].[TotalReceivedAmount][D2]" +
                         " ,[Csr].[TotalReceivedAmount][D3]" +
                         " FROM [dbo].[WorkOrder] [Wo]" +
                         " LEFT JOIN [dbo].[Customer] [Cus] On [Wo].[CustomerID] = [Cus].[ID]" +
                         " LEFT JOIN [dbo].[Vehicle] [Veh] On [Wo].[VehicleID] = [Veh].[ID]" +
                         " LEFT JOIN [dbo].[Employee] [Emp] On [Wo].[SaleRepID] = [Emp].[ID]" +
                         " inner JOIN [dbo].[CustomerReceipt] [Csr] On [Wo].[ID] = [Csr].[WOID]" +
                         " WHERE [Csr].[CompanyID]= " + StaticInfo.CompanyID + " And ([Csr].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Csr].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID;

            return Qry;
        }
        public string InvoiceProfitDetailReportDetailQry(DateTime datefrom, DateTime dateto, Int32 CustomerID)
        {
            string Qry = " SELECT tbl.ID,MID,I2,I7,D1,D2,D3,D5,D7,S11,S12,S18,(D1-D2)*I7 as D8 FROM (" +
                         " SELECT WOD.[ID] ,[WOD].[MID]" +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +

                         "  ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.ItemID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         "  ,[WOD].[MechanicID]   [I6]   " +
                         "  ,[WOD].[Qty]		[I7] " +
                         "  ,[WOD].[Price]	[D1] " +
                         "  ,[WOD].[Cost]		[D2] " +
                         "  ,[WOD].[Amount]	[D3] " +
                         "  ,[WOD].[DiscPer]	[D4] " +
                         "  ,[WOD].[DiscAmount]	[D5] " +
                         "  ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14]  " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18]" +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.FeeID is not null  " +
                         " UNION ALL" +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.LaborID is not null " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	    " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12] " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.PackageID is not null AND WOD.Ctype = 'S'  " +
                         " UNION ALL  " +
                         " SELECT WOD.[ID] ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2] " +
                         " ,[WOD].[FeeID]	[I3] " +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8] " +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6] " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4] " +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13]" +
                         " ,emp1.Initial [S14] " +
                         " ,[S11] = 'Inspection Head' " +
                         " ,[S12] = 'Inspection Head'" +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD  " +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH'" +
                         " UNION ALL " +
                         " SELECT WOD.[ID] " +
                         " ,[WOD].[MID]	  " +
                         " ,[WOD].[ItemID]	[I2]" +
                         " ,[WOD].[FeeID]	[I3]" +
                         " ,[WOD].[LaborID]	[I4] " +
                         " ,[WOD].[VehicleInspectionID]	[I8]" +
                         " ,[WOD].[InspectionHeadID]	[I5]      " +
                         " ,[WOD].[MechanicID]   [I6]   " +
                         " ,[WOD].[Qty]		[I7] " +
                         " ,[WOD].[Price]	[D1] " +
                         " ,[WOD].[Cost]		[D2] " +
                         " ,[WOD].[Amount]	[D3] " +
                         " ,[WOD].[DiscPer]	[D4]" +
                         " ,[WOD].[DiscAmount]	[D5] " +
                         " ,[WOD].[FET]		[D6] " +
                         " ,[WOD].[Total]	[D7] " +
                         " ,[WOD].[SaleTaxRate]	[D8] " +
                         " ,[WOD].[Tax]		[D9] " +
                         " ,emp.Initial [S13] " +
                         " ,emp1.Initial [S14] " +
                         " ,itm.[Catalog] [S11] " +
                         " ,itm.[Name] [S12]  " +
                         " ,[WOD].[Ctype]		[S18] " +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id  " +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id where WOD.InspectionHeadID is not null  ) tbl" +
                         " Left Join [dbo].[WorkOrder] [Wo] on [Wo].ID = tbl.MID inner join CustomerReceipt cr on tbl.MID=cr.WOID" +
                         " WHERE [cr].[CompanyID]= " + StaticInfo.CompanyID + " And ([cr].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [cr].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID;

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string CustomerListReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT  [Cus].[ID]  " +
                         " ,[Cus].[Code] [S1]" +
                         " ,[Cus].[CompanyName][S2]" +
                         " ,[Cus].[LastName]    [S3]       " +
                         " ,[Cus].[Address][S4]" +
                         " ,[Cus].[ContactPerson][S5]" +
                         " ,[Cus].[Email][S6]" +
                         //" ,[Cus].[CountryID][I1]" +
                         //" ,[Cus].[StateID][I2]" +
                         //" ,[Cus].[CityID][I3]" +
                         " ,[Cus].[AddDate][Date1]" +
                         //" ,[Sta].[Name][S7]" +
                         //" ,[Cou].[Name][S8]" +
                         //" ,[Cty].[Name][S9]" +

                         " FROM [dbo].[Customer] [Cus]" +
                         //" LEFT JOIN [dbo].[State] [Sta] ON [Cus].[StateID] = [Sta].[ID]" +
                         //" LEFT JOIN [dbo].[Country] [Cou] ON [Cus].[CountryID] = [Cou].[ID] " +
                         //" LEFT JOIN [dbo].[City] [Cty] ON [Cus].[CityID] = [Cty].[ID]" +
                         " WHERE [Cus].[CompanyID]= " + StaticInfo.CompanyID + " And ([Cus].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Cus].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryStockReportQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = "SELECT [stk].[ID]" +
                         ",[stk].[ItemID] [I1]" +
                         ",[stk].[StoreID] [I2]" +
                         ",[stk].[WarehouseID] [I3]" +
                         ",[stk].[Qty] [I4]" +
                         ",[stk].[AddDate] [Date1]" +
                         " ,[Itm].[ItemSize] [S4]" +
                         " ,[Itm].[Catalog] [S5]" +
                         " ,[Itm].[Name] [S6]" +
                         " ,[Itm].[ItemTypeID] [I5]" +
                         " ,[Itm].[ItemGroupID] [I6]" +
                         " ,[Itm].[UnitWeight] [D1]" +
                         " ,[Itm].[CatalogCost] [D2] " +
                         " ,[Itm].[FET] [D3]" +
                         " ,[Itm].[RetailPricePercent] [D5]" +
                         " ,[Itm].[RetailPrice] [D6]" +
                         " FROM [dbo].[ItemStock][stk]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [stk].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[WarehouseStore] [Wst] ON [stk].[StoreID] = [Wst].[ID]";
                         //" Where ([Stk].[ModifyDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Stk].[ModifyDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Stk].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Stk].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Stk].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Stk].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryValueReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID] " +
                         " ,[Ist].[ItemID] [I1] " +
                         " ,[Ist].[StoreID] [I2] " +
                         " ,[Ist].[WarehouseID] [I3] " +
                         " ,[Ist].[Qty]  [I4] " +
                         " ,[Ist].[AddDate] [Date1] " +
                         " ,[Itm].[Catalog] [S1] " +
                         " ,[Itm].[Name] [S2] " +
                         " ,[Itm].[CatalogCost] [D1] " +
                         " ,[Itm].[FET] [D2] " +
                         " ,[I5]=(Select isnull (sum(QtyOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID]) " +
                         "  FROM [dbo].[ItemStock] [Ist] " +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID] " +
                         " LEFT JOIN [dbo].[ItemType] [Itmty] ON [Itm].[ItemTypeID] = [Itmty].[ID] " +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Itm].[VendorID] = [Ven].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igr] ON [Itm].[ItemGroupID] = [Igr].[ID] ";
                         //" WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryPhysicalReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Ist].[StoreID][I2]" +
                         " ,[Ist].[WarehouseID][I3]" +
                         " ,[Ist].[Qty]  	 [I4]" +
                         " ,[Itm].[Catalog]  [S1]" +
                         " ,[Ist].[QtyOnHand]  [I5]" +
                         " ,[Itm].[Name][S2]" +
                         " ,[Itm].[CatalogCost][D1]" +
                         " ,[Itm].[FET]    [D2]" +
                         " ,[Itm].[AverageCost][D3]" +
                         " ,[Itm].[RetailPrice][D4]	" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]";
                         //" WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryVarianceReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Po].[ID] " +
                         " ,[Po].[VendorID] [I1]" +
                         " ,[Po].[POID]   [I2]   " +
                         " ,[Po].[AddDate] [Date1]" +
                         " ,[Ven].[Name]  [S1] " +
                         " FROM [dbo].[PurchaseOrder] [Po]" +
                         " LEFT JOIN [dbo].[Vendor] [Ven] ON [Po].[VendorID] = [Ven].[ID] " +
                         " WHERE [Po].[CompanyID]= " + StaticInfo.CompanyID + " AND ([Po].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            return Qry;
        }
        public string InventoryVarianceReportDetailQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Pod].[ID]" +
                         " ,[Pod].[MID]" +
                         " ,[Pod].[ItemID][I1]" +
                         " ,[Pod].[PrevOrdrd][I2]" +
                         " ,[Pod].[Cost][D1]" +
                         " ,[Pod].[FET][D2]" +
                         " ,[Pod].[Amount][D3]" +
                         " ,[Itm].[Catalog][S1]" +
                         " ,[Itm].[Name][S2]" +
                         " FROM [dbo].[PurchaseOrderDetails] [Pod]" +
                         " LEFT JOIN [dbo].[Item] [Itm] On [Pod].[ItemID] = [Itm].[ID] " +
                         " Left Join [dbo].[PurchaseOrder] [Po] on [Po].ID = [Pod].MID" +
                         " WHERE [Po].[CompanyID]= "+ StaticInfo.CompanyID  + " AND ([Po].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Po].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Pod].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Pod].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Pod].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryExcessReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Ist].[StoreID][I2]" +
                         " ,[Ist].[WarehouseID][I3]" +
                         " ,[Ist].[Qty]  	 [I4]" +
                         " ,[Itm].[Catalog]  [S1]" +
                         " ,[Itm].[Name][S2]" +
                         " ,[Itm].[CatalogCost][D1]" +
                         " ,[Itm].[FET]    [D2]" +
                         " ,[Igro].[Name]    [S3]" +
                         " ,[I5]=(Select isnull (sum(QtyOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID])" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]";
                         //" WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryModelValueReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Ist].[StoreID][I2]" +
                         " ,[Ist].[WarehouseID][I3]" +
                         " ,[Ist].[Qty]  	 [I4]" +
                         " ,[Itm].[Catalog]  [S1]" +
                         " ,[Itm].[Name][S2]" +
                         " ,[Itm].[CatalogCost][D1]" +
                         " ,[Itm].[RetailPrice]    [D2]" +
                         " ,[Igro].[Name]    [S3]" +
                         " ,[I5]=(Select isnull (sum(QtyOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID])" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]" +
                         " WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string PriceListReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Ist].[Qty]  [I2]" +
                         " ,[Itm].[Catalog][S1]" +
                         " ,[Itm].[Name] [S2]" +
                         " ,[Ity].[Name] [S3]" +
                         " ,[Igro].[Name][S4]  " +
                         " ,[Igty].[Name][S5]  " +
                         " ,[Itm].[RetailPrice][D1]" +
                         " ,[Itm].[WholeSalePrice][D2]" +
                         " ,[Itm].[SpecialPrice][D3]" +
                         " ,[Itm].[FET][D4]" +
                         " ,[Itm].[AverageCost][D5]" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemType] [Ity] ON [Itm].[ItemTypeID] = [Ity].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroupType] [Igty] ON [Igro].[GroupTypeID] = [Igty].[ID]";
                         //" WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') ";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string SpecialPriceListReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Itm].[ID]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Itm].[ItemTypeID][I1]" +
                         " ,[Itm].[ItemGroupID][I2]" +
                         " ,[Itm].[FET] [D1]" +
                         " ,[Itm].[SpecialPrice] [D2]" +
                         " ,[Ity].[Name] [S4]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " LEFT JOIN [dbo].[ItemType] [Ity] ON [Itm].[ItemTypeID] = [Ity].[ID]";
                         //" WHERE ([Itm].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Itm].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') and [Itm].[SpecialPrice] != 0";
            if (CatalogF > 0)
                Qry += "AND ([Itm].[ID] >= '" + CatalogF + "'" +
                         " AND [Itm].[ID] <= '" + CatalogT + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Itm].[ID] >= '" + ItemIDF + "'" +
                         " AND [Itm].[ID] <= '" + ItemIDT + "') order by ID";
            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryReorderReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Itm].[Catalog][S1] " +
                         " ,[Itm].[Name][S2]" +
                         " ,[Igro].[Name][S3]" +
                         " ,[Ist].[Qty]  [I2]" +
                         " ,[Itm].[ReOrderMin][I3]" +
                         " ,[Itm].[UnitWeight][D1]" +
                         " ,[Itm].[CatalogCost][D2]" +
                         " ,[Itm].[FET][D3]" +
                         " ,[I4]=(Select isnull (sum(QtyOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID])" +
                         " ,[I5]=(Select isnull (sum(PrevOrdrd),0) from PurchaseOrderDetails where ItemID = [Ist].[ItemID])" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igro] ON [Itm].[ItemGroupID] = [Igro].[ID]";
                         //" WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') order by ID";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string InventoryBinReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CatalogF, Int32 CatalogT, Int32 ItemIDF, Int32 ItemIDT)
        {
            string Qry = " SELECT [Ist].[ID]" +
                         " ,[Ist].[ItemID][I1]" +
                         " ,[Ist].[Qty][I2]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name][S3]" +
                         " FROM [dbo].[ItemStock] [Ist]" +
                         " LEFT JOIN [dbo].[Item] [Itm] ON [Ist].[ItemID] = [Itm].[ID]" +
                         " WHERE ([Ist].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Ist].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            if (CatalogF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + CatalogF + "'" +
                         " AND [Ist].[ItemID] <= '" + CatalogT + "') ";
            if (ItemIDF > 0)
                Qry += "AND ([Ist].[ItemID] >= '" + ItemIDF + "'" +
                         " AND [Ist].[ItemID] <= '" + ItemIDT + "') order by ID";

            return Qry;
        }
        //-----------------------------------------------------/-/
        //---------------------------------------------
        public string ItemListReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Itm].[ID]" +
                         " ,[Itm].[ItemCode]   [S1]" +
                         " ,[Itm].[ItemSize]	[S2]" +
                         " ,[Itm].[Catalog]	[S3]" +
                         " ,[Itm].[Name]	[S4]" +
                         " ,[Itm].[ItemTypeID]	[I1]" +
                         " ,[Itm].[ItemGroupID] [I2]" +
                         " ,[Itm].[UnitWeight]	[D1]" +
                         " ,[Itm].[CatalogCost] [D2]  " +
                         " ,[Itm].[AddDate]	[Date1]" +
                         " ,[Ityp].[Name]	[S5]" +
                         " ,[Igr].[Code]	[S6]" +
                         " ,[Igr].[Name]	[S7]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " LEFT JOIN [dbo].[ItemType] [Ityp] ON [Itm].[ItemTypeID] = [Ityp].[ID]" +
                         " LEFT JOIN [dbo].[ItemGroup] [Igr] ON [Itm].[ItemGroupID] = [Igr].[ID]";
                         //" WHERE ([Itm].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //" AND [Itm].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";

            return Qry;
        }
        
        //-----------------------------------------------------/-/
        public string ItemGroupSummaryDetailedReportQry(DateTime currentDate)
        {
            DateTime LastMonth = currentDate.AddMonths(-1);

            string Qry = "Select 'Fee' as S1, * From (Select IsNull(Sum(WorkOrderDetail.Qty),0) as N1, IsNull(Sum(WorkOrderDetail.Total),0) as N2, IsNull(Sum(WorkOrderDetail.Profit),0) as N3 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Fee' And CustomerReceipt.TrnsDate ='" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempA , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N4, IsNull(Sum(WorkOrderDetail.Total),0) as N5, IsNull(Sum(WorkOrderDetail.Profit),0) as N6 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Fee' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempB ," +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N7, IsNull(Sum(WorkOrderDetail.Total),0) as N8,IsNull(Sum(WorkOrderDetail.Profit),0) as N9 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Fee' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.AddMonths(-1).Month + "-" + DateTime.DaysInMonth(LastMonth.Year, LastMonth.Month)) + "'" + ") as TempC , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N10, IsNull(Sum(WorkOrderDetail.Total),0) as N11, IsNull(Sum(WorkOrderDetail.Profit),0) as N12 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Fee' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Month + "-" + currentDate.Date.Day) + "'" + ") as TempD " +

                " Union All " +

                "Select 'Misc. Parts' as S1, * From (Select IsNull(Sum(WorkOrderDetail.Qty),0) as N1, IsNull(Sum(WorkOrderDetail.Total),0) as N2, IsNull(Sum(WorkOrderDetail.Profit),0) as N3 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Par' And CustomerReceipt.TrnsDate ='" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempA , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N4, IsNull(Sum(WorkOrderDetail.Total),0) as N5, IsNull(Sum(WorkOrderDetail.Profit),0) as N6 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Par' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempB ," +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N7, IsNull(Sum(WorkOrderDetail.Total),0) as N8,IsNull(Sum(WorkOrderDetail.Profit),0) as N9 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Par' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.AddMonths(-1).Month + "-" + DateTime.DaysInMonth(LastMonth.Year, LastMonth.Month)) + "'" + ") as TempC , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N10, IsNull(Sum(WorkOrderDetail.Total),0) as N11, IsNull(Sum(WorkOrderDetail.Profit),0) as N12 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Par' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Month + "-" + currentDate.Date.Day) + "'" + ") as TempD " +

                " Union All " +

                "Select 'Misc. Tires' as S1, * From (Select IsNull(Sum(WorkOrderDetail.Qty),0) as N1, IsNull(Sum(WorkOrderDetail.Total),0) as N2, IsNull(Sum(WorkOrderDetail.Profit),0) as N3 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Tir' And CustomerReceipt.TrnsDate ='" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempA , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N4, IsNull(Sum(WorkOrderDetail.Total),0) as N5, IsNull(Sum(WorkOrderDetail.Profit),0) as N6 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Tir' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempB ," +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N7, IsNull(Sum(WorkOrderDetail.Total),0) as N8,IsNull(Sum(WorkOrderDetail.Profit),0) as N9 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Tir' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.AddMonths(-1).Month + "-" + DateTime.DaysInMonth(LastMonth.Year, LastMonth.Month)) + "'" + ") as TempC , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N10, IsNull(Sum(WorkOrderDetail.Total),0) as N11, IsNull(Sum(WorkOrderDetail.Profit),0) as N12 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Tir' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Month + "-" + currentDate.Date.Day) + "'" + ") as TempD " +

                " Union All " +

                "Select 'Wheels & Accs.' as S1, * From (Select IsNull(Sum(WorkOrderDetail.Qty),0) as N1, IsNull(Sum(WorkOrderDetail.Total),0) as N2, IsNull(Sum(WorkOrderDetail.Profit),0) as N3 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Whe' And CustomerReceipt.TrnsDate ='" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempA , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N4, IsNull(Sum(WorkOrderDetail.Total),0) as N5, IsNull(Sum(WorkOrderDetail.Profit),0) as N6 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Whe' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Date.Month + "-" + currentDate.Date.Day) + "'" + ") as TempB ," +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N7, IsNull(Sum(WorkOrderDetail.Total),0) as N8,IsNull(Sum(WorkOrderDetail.Profit),0) as N9 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Whe' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.AddMonths(-1).Month + "-" + DateTime.DaysInMonth(LastMonth.Year, LastMonth.Month)) + "'" + ") as TempC , " +

                "(Select IsNull(Sum(WorkOrderDetail.Qty),0) as N10, IsNull(Sum(WorkOrderDetail.Total),0) as N11, IsNull(Sum(WorkOrderDetail.Profit),0) as N12 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID=WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID=WorkOrder.ID " +
                "Where [CustomerReceipt].[CompanyID]= " + StaticInfo.CompanyID + " AND Ctype='Whe' And CustomerReceipt.TrnsDate between '" + Convert.ToString(currentDate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(currentDate.Date.Year + "-" + currentDate.Month + "-" + currentDate.Date.Day) + "'" + ") as TempD ";

            return Qry;
        }

        public string VendorPaymentHistoryReportQry(int PaymentID)
        {
            string Qry = "Select Vendor.Name As S1, Vendor.Address as S2, Vendor.ZipCode as S3, VendorBill.BillID as S4, VendorPaymentHistory.PaymentID as I1, VendorPayment.BillAmount as D1, VendorPayment.PaidAmount as D2, VendorPayment.BillBalance as D3, VendorPayment.TrnsDate as Date1," +
                " VendorPaymentHistory.PayByAMEX as D4, VendorPaymentHistory.PayByATM as D5, VendorPaymentHistory.PayByCash as D6,  VendorPaymentHistory.PayByDSCVR as D8,"+
                " VendorPaymentHistory.PayByGY as D9, VendorPaymentHistory.PayByMC as D10, VendorPaymentHistory.PayByVisa as D11,  VendorPaymentHistory.PaybyCheck as D13," +
                " D14 = ((Select SUM(ISNULL(BillTotalAmount,0)) from VendorBill where VendorID = [Vendor].[ID]) - (Select SUM(ISNULL(BillDiscount,0)) from VendorPayment where VendorID = [Vendor].[ID])-(select SUM(ISNULL(PaidAmount,0)) from VendorPayment where VendorID = [Vendor].[ID]))  From VendorPayment left outer join Vendor ON VendorPayment.VendorID = Vendor.ID" +
                " left join VendorBill ON VendorPayment.BillID = VendorBill.BillID left outer join VendorPaymentHistory ON VendorPayment.PaymentID = VendorPaymentHistory.PaymentID" +                
                " Where VendorPayment.PaymentID = " + PaymentID;
                 
            return Qry;
        }
        //-----------------------------------------------------/-/
        //public string PurchaseOrderMasterQry()
        //{
        //    string Qry = "";

        //    return Qry;
        //}
        //public string PurchaseOrderDetailQry()
        //{
        //    string Qry = "";

        //    return Qry;
        //}
        public string DailyTransactionReportMasterQry(string date)
        {
            string SelectDate = "";
            //string[] DateList = date.ToString().Split('/');
            //date = DateList[0] + "/" + DateList[1] + "/" + DateList[2];
            string Qry = "select row_number() over(order by CAST(cr.TrnsDate AS DATE))AS ID," +
                        "CAST(cr.TrnsDate AS DATE) as [S1] ," +
                        "(SUM(wo.TotalProfit)-(select ISNULL(SUM(WorkOrderNegate.TotalProfit),0) from WorkOrderNegate inner join CustomerPayment on WorkOrderNegate.ID=CustomerPayment.WONID where CAST(TrnsDate AS DATE) = '" + date + "' and CustomerPayment.CompanyID = " + StaticInfo.CompanyID + ")) as [S2]," +
                        "CONVERT(varchar, sum(Total) - SUM(cr.ChgOnAccount)) as [S3]," +
                        "ISNULL(SUM(CR.PayByCash),0) - (select ISNULL(Sum(PayByCash),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "' and CompanyID = " + StaticInfo.CompanyID + ")AS[D1]," +
                        "ISNULL(SUM(CR.ChgOnAccount),0) - (select ISNULL(Sum(ChgOnAccount),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D10]," +
                        "ISNULL(SUM(CR.PaybyCheck),0) - (select ISNULL(Sum(PaybyCheck),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D2]," +
                        "ISNULL(SUM(CR.PayByVisa),0) - (select ISNULL(Sum(PayByVisa),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D3]," +
                        "ISNULL(SUM(CR.PayByMC),0) - (select ISNULL(Sum(PayByMC),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D4]," +
                        "ISNULL(SUM(CR.PayByAMEX),0) - (select ISNULL(Sum(PayByAMEX),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D5]," +
                        "ISNULL(SUM(CR.PayByATM),0) - (select ISNULL(Sum(PayByATM),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D6]," +
                        "ISNULL(SUM(CR.PayByGY),0) - (select ISNULL(Sum(PayByGY),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D7]," +
                        "ISNULL(SUM(CR.PayByDSCVR),0) - (select ISNULL(Sum(PayByDSCVR),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[D8]," +
                        "(select ISNULL(SUM(CR.PayByCash),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D11]," +
                        "(select ISNULL(SUM(CR.PaybyCheck),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D12]," +
                        "(select ISNULL(SUM(CR.PayByVisa),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D13]," +
                        "(select ISNULL(SUM(CR.PayByMC),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D14]," +
                        "(select ISNULL(SUM(CR.PayByAMEX),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D15]," +
                        "(select ISNULL(SUM(CR.PayByATM),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D16]," +
                        "(select ISNULL(SUM(CR.PayByGY),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D17]," +
                        "(select ISNULL(SUM(CR.PayByDSCVR),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[D18]," +
                        "sum(Total) - (select ISNULL(Sum(TotalReceivedAmount),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "') as S15," +
                        "ISNULL((select Top(1) Itemcontrol from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0) as S11," +
                        "ISNULL((select Top(1) CustomerControl from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0)as S12," +
                        "ISNULL((select Top(1) VendorControl from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0)as S13" +
                        " from[WorkOrder] wo Inner join CustomerReceipt cr on wo.ID = cr.WOID" +
                        " WHERE CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + "" +
                        " group by CAST(cr.TrnsDate AS DATE)," +
                        "wo.IsLocked order by row_number()over(order by CAST(cr.TrnsDate AS DATE)) Desc";
            return Qry;
        }
        public string DailyTransactionMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Wo].[ID]"+
                         " ,[Wo].[RegDate][Date1]"+
                         " ,[Wo].[WorkOrderNo] [I2]"+     
                         " ,[Wo].[CustomerID]   [I11]"+ 
                         " ,[Wo].[SaleRepID][I12]"+
                         " ,[Wo].[SaleCategoryID][I13]"+
                         " ,[Wo].[Total]     [D8]"+
                         " ,[Wo].[PartsPrice][D1]"+
                         " ,[Wo].[LaborPrice][D2]"+
                         " ,[Wo].[OtherPrice][D11]"+
                         " ,[Wo].[PartDisPer][D12]"+
                         " ,[Wo].[LaborDisPer][D13]"+
                         " ,[Wo].[FET][D4]"+
                         " ,[Wo].[Taxable][D5]"+
                         " ,[Wo].[Tax][D6]"+
                         " ,[Wo].[Discount] [D7]"+
                         " ,[Wo].[AddDate][Date2]"+
                         " ,[Cus].[CompanyName][S1]"+
                         " ,[Cus].[LastName][S11]"+
                         " ,[Cus].[CompanyName][S12]"+
                         " ,[Emp].[Initial][S2]"+
                         " ,[SC].[Code][S3]"+
                         " ,[D9]=(Select isnull (sum(Cost),0) from WorkOrderDetail where MID = [WO].[ID])"+
                         " ,[D10]=(Select isnull (sum(Price),0) from WorkOrderDetail where MID = [WO].[ID])"+
                         " FROM [dbo].[WorkOrder][Wo]"+
                         " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID]  = [Cus].[ID]"+
                         " LEFT JOIN [dbo].[Employee][Emp] ON [Wo].[SaleRepID]  = [Emp].[ID]"+
                         " LEFT JOIN [dbo].[SaleTaxCategory][SC] ON [Wo].[SaleCategoryID]  = [SC].[ID] " +
                         " WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        public string DailyTransactionDetailsMasterQry(string date)
        {
            string SelectDate = date;



            //string[] DateList = date.ToString().Split('/');
            //SelectDate = DateList[0] + "/" + DateList[1] + "/" + DateList[2];
            string Qry = " (SELECT [Wo].[ID] , " +
                        "[S14]=CR.TrnsNotes," +
                        "CAST(cr.TrnsDate as date) [Date1] ," +
                        "CR.InvoiceNo [I2] ," +
                        "[Wo].[CustomerID][I11] , " +
                        "wo.TotalProfit as [D5]," +
                        "[D14]=(Select SUM(TotalReceivedAmount) FROM CustomerPayment WHERE TrnsDate=CR.TrnsDate) ," +
                        "[Wo].[SaleRepID][I12] ," +
                        "[Wo].[SaleCategoryID][I13] ," +
                        "[wo].[total]    [D8] ," +
                        "([Wo].[PartsPrice]) [D1] ," +
                        "[Wo].[LaborPrice][D18] ," +
                        "[Wo].[OtherPrice][D11] ," +
                        "[Wo].[PartDisPer][D12] ," +
                        "[Wo].[LaborDisPer][D13] ," +
                        "[Wo].[FET][D4] ," +
                        "0 as [D2] ," +
                        "[Wo].[Tax][D6] ," +
                        "[Wo].[Discount] [D7] ," +
                        "[Wo].[AddDate][Date2] ," +
                        "[Cus].[CompanyName][S1] ," +
                        "[Cus].[LastName][S11] ," +
                        "[Cus].[CompanyName][S12] ," +
                        "[Emp].[Initial][S2] ," +
                        "[SC].[Code][S3] ," +
                        "[D9]=(Select isnull (sum(Cost),0) from WorkOrderDetail where MID = [WO].[ID]) ," +
                        "[D10]=(Select isnull (sum(Price),0) from WorkOrderDetail where MID = [WO].[ID])" +
                        " FROM [dbo].[WorkOrder][Wo] INNER JOIN [dbo].[CustomerReceipt][CR] ON [wo].[ID] = [CR].[WOID]" +
                        " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID]  = [Cus].[ID] " +
                        "LEFT JOIN [dbo].[Employee][Emp] ON [Wo].[SaleRepID]  = [Emp].[ID] " +
                        "LEFT JOIN [dbo].[SaleTaxCategory][SC] ON [Wo].[SaleCategoryID]  = [SC].[ID] " +
                        " WHERE cr.CompanyID=" + StaticInfo.CompanyID+" and CAST(CR.TrnsDate as DATE) = '" + SelectDate + "')" +
                        " UNION ALL" +
                        "(SELECT [Wo].[ID] ," +
                        "[S14]=CR.TrnsNotes," +
                        "CAST(cr.TrnsDate as date) [Date1] ," +
                        "CR.InvoiceNo [I2] ," +
                        "[Wo].[CustomerID][I11]," +
                        "0-[Wo].[TotalProfit] as [D5]," +
                        "[D14]=(Select SUM(TotalReceivedAmount) FROM CustomerPayment WHERE TrnsDate=CR.TrnsDate) ," +
                        "[Wo].[SaleRepID][I12] ," +
                        "[Wo].[SaleCategoryID][I13] ," +
                        "0-[wo].[total]    [D8] ," +
                        "[Wo].[PartsPrice] [D1] ," +
                        "[Wo].[LaborPrice][D18] ," +
                        "[Wo].[OtherPrice][D11] ," +
                        "[Wo].[PartDisPer][D12] ," +
                        "[Wo].[LaborDisPer][D13] ," +
                        "[Wo].[FET][D4] ," +
                        "[Wo].[Taxable] as [D2] ," +
                        "[Wo].[Tax][D6] ," +
                        "[Wo].[Discount] [D7] ," +
                        "[Wo].[AddDate][Date2] ," +
                        "[Cus].[CompanyName][S1] ," +
                        "[Cus].[LastName][S11] ," +
                        "[Cus].[CompanyName][S12] ," +
                        "[Emp].[Initial][S2] ," +
                        "[SC].[Code][S3] ," +
                        "[D9]=(Select isnull (sum(Cost),0) from WorkOrderNegateDetail where MID = [WO].[ID]) ," +
                        "[D10]=(Select isnull (sum(Price),0) from WorkOrderNegateDetail where MID = [WO].[ID])" +
                        " FROM [dbo].[WorkOrderNegate][Wo] INNER JOIN [dbo].[CustomerPayment][CR] ON [wo].[ID] = [CR].[WONID]" +
                        " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID]  = [Cus].[ID] " +
                        "LEFT JOIN [dbo].[Employee][Emp] ON [Wo].[SaleRepID]  = [Emp].[ID]" +
                        " LEFT JOIN [dbo].[SaleTaxCategory][SC] ON [Wo].[SaleCategoryID]  = [SC].[ID] " +
                        "WHERE cr.CompanyID=" + StaticInfo.CompanyID + " and CAST(CR.TrnsDate as DATE) = '" + SelectDate + "')";
            //string Qry = " SELECT [Wo].[ID]" +
            //             " ,[Wo].[RegDate][Date1]" +
            //             " ,[Wo].[WorkOrderNo] [I2]" +
            //             " ,[Wo].[CustomerID]   [I11]" +
            //             " ,[Wo].[SaleRepID][I12]" +
            //             " ,[Wo].[SaleCategoryID][I13]" +
            //             " ,[Wo].[Total]     [D8]" +
            //             " ,[Wo].[PartsPrice][D1]" +
            //             " ,[Wo].[LaborPrice][D2]" +
            //             " ,[Wo].[OtherPrice][D11]" +
            //             " ,[Wo].[PartDisPer][D12]" +
            //             " ,[Wo].[LaborDisPer][D13]" +
            //             " ,[Wo].[FET][D4]" +
            //             " ,[Wo].[Taxable][D5]" +
            //             " ,[Wo].[Tax][D6]" +
            //             " ,[Wo].[Discount] [D7]" +
            //             " ,[Wo].[AddDate][Date2]" +
            //             " ,[Cus].[CompanyName][S1]" +
            //             " ,[Cus].[LastName][S11]" +
            //             " ,[Cus].[CompanyName][S12]" +
            //             " ,[Emp].[Initial][S2]" +
            //             " ,[SC].[Code][S3]" +
            //             " ,[D9]=(Select isnull (sum(Cost),0) from WorkOrderDetail where MID = [WO].[ID])" +
            //             " ,[D10]=(Select isnull (sum(Price),0) from WorkOrderDetail where MID = [WO].[ID])" +
            //             " FROM [dbo].[WorkOrder][Wo]" +
            //             " INNER JOIN [dbo].[CustomerReceipt][CR] ON [wo].[ID] = [CR].[WOID]" +
            //             " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID]  = [Cus].[ID]" +
            //             " LEFT JOIN [dbo].[Employee][Emp] ON [Wo].[SaleRepID]  = [Emp].[ID]" +
            //             " LEFT JOIN [dbo].[SaleTaxCategory][SC] ON [Wo].[SaleCategoryID]  = [SC].[ID] " +
            //             " WHERE CAST(wo.RegDate as DATE) = '" + SelectDate + "'";
            return Qry;
        }
        public string SaleCategoriesMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = "  SELECT [SC].[ID] " +
                         " ,[SC].[Name] [S2]" +
                         " ,[SC].[AddDate] [Date1]" +
                         " ,[D1]=(Select isnull (sum(Total),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D2]=(Select isnull (sum(PartsPrice),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D3]=(Select isnull (sum(LaborPrice),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D4]=(Select isnull (sum(Discount),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D5]=(Select isnull (sum(FET),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D6]=(Select isnull (sum(Tax),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                         " ,[D7]=(Select isnull (sum(Taxable),0) from WorkOrder where SaleCategoryID = [SC].[ID]) " +
                //" ,[D8]=(Select isnull (sum(Price),0) from WorkOrderDetail where MID = [Wo].[ID]) "+
                //" ,[D9]=(Select isnull (sum(Cost),0) from WorkOrderDetail where MID = [Wo].[ID]) "+
                         " FROM [dbo].[SaleTaxCategory][SC]";
                         //" LEFT JOIN [dbo].[WorkOrder][Wo] ON [SC].[ID] = [Wo].[SaleCategoryID]" +
                         //"  WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         //"  AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string ItemGroupSummeryMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = "  SELECT [IG].[ID]"+
                         " ,[IG].[Code][S1]"+
                         " ,[IG].[Name][S2]  "+    
                         " ,[IG].[AddDate][Date1]"+
                         " ,[Itm].[Name][S3]"+
                         " ,[Itm].[Catalog][S4]"+
                         " ,[Itm].[ItemSize]  [S5]    "+
                         " ,[wod].[AddDate][Date2]"+
                         " ,[D1]=(Select isnull (sum(Cost),0) from WorkOrderDetail where ItemID = [Itm].[ID])"+
                         " ,[I1]=(Select isnull (sum(Qty),0) from WorkOrderDetail where ItemID = [Itm].[ID])"+
                         " ,[D3]=(Select isnull (sum(Price),0) from WorkOrderDetail where ItemID = [Itm].[ID])"+ 
                         " FROM [dbo].[ItemGroup][IG]"+
                         " LEFT JOIN [dbo].[Item][Itm] ON [IG].[ID] = [Itm].[ItemGroupID]"+
                         " LEFT JOIN [dbo].[WorkOrderDetail][wod] ON [Itm].[ID] = [wod].[ItemID]"+
                         " WHERE ([Wod].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Wod].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string SalesREPSummeryMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Emp].[ID] ,"+
                         " [Emp].[Initial][S1] ,"+
                         " [Emp].[RegDate][Date1] ,"+
                         " [Emp].[Name][S2] ,"+
                         " [I1]=(Select isnull (Count(WorkOrderNo),0) from WorkOrder where SaleRepID = [Emp].[ID]) ,"+
                         " [D1]=(Select isnull (Sum(Total),0) from WorkOrder where SaleRepID = [Emp].[ID]) ,"+
                         " [D2]=(Select isnull (Sum(Price),0)-isnull (Sum(Cost),0) from WorkOrderDetail where RepID = [Emp].[ID])"+
                         " FROM [dbo].[Employee][Emp]" +
                         "  WHERE ([Emp].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [Emp].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        public string CustDailyReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Cus].[ID]" +
                         " ,[Cus].[RegDate]   [Date1]" +
                         " ,[Cus].[CompanyName][S1]" +
                         " ,[Cus].[LastName]  [S2]  " +
                         " ,[Cus].[Address]	[S3]" +
                         " ,[Cus].[ContactPerson][S4]  " +
                         " ,[Cus].[ReferredByID] [I1]  " +
                         " ,[Cus].[CreditLimits] [D1] " +
                         " ,[Cus].[AddDate][Date2]" +
                         " ,[Ref].[Name][S5]" +
                         " ,[Wo].[Total][D2]" +
                         " ,[Wo].[AddDate][Date3]" +
                         " FROM [dbo].[Customer][Cus]" +
                         " LEFT JOIN [dbo].[ReferredBy][Ref] ON [Cus].[ReferredByID]=[Ref].[ID]" +
                         " LEFT JOIN [dbo].[WorkOrder][Wo] ON [WO].[CustomerID]=[Cus].[ID]" +
                         "  WHERE ([Cus].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [Cus].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        public string VendorBillDatailMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [VB].[ID]" +
                         " ,[VB].[BillID][I1]" +
                         " ,[VB].[VendorID][I2]" +
                         " ,[VB].[InvoiceNo][S1]" +
                         " ,[VB].[POID][I3]" +
                         " ,[VB].[BillDate][Date1]" +
                         " ,[VB].[BillNotes][S2]" +
                         " ,[VB].[GridTotalQty][I4]" +
                         " ,[VB].[GridTotalAmount][D1]" +
                         " ,[VB].[BillTotalAmount][D2]" +
                         " ,[VB].[BillStatus][S3]" +
                         " ,[VB].[BillType][S4]" +
                         " ,[VB].[PaidAmount][D3]" +
                         " ,[VB].[Balance][D4]" +
                         " ,[VB].[AddDate][Date2]" +
                         " ,[Ven].[Name][S5]" +
                         " FROM [dbo].[VendorBill][VB]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] ON [VB].[VendorID]=[Ven].[ID]" +
                         "  WHERE ([VB].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [VB].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        public string VendorBillDatailDetailQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [VBD].[ID]" +
                         " ,[VBD].[MID]" +
                         " ,[VBD].[ItemID][I1]" +
                         " ,[VBD].[Catalog][S1]" +
                         " ,[VBD].[Name][S2]" +
                         " ,[VBD].[BillQty][I2]" +
                         " ,[VBD].[CatalogCost][D1]" +
                         " ,[VBD].[BillAmount] [D2] " +
                         " ,[VBD].[AddDate][Date1]" +
                         " ,[ity].[Name][S3]" +
                         " FROM [dbo].[VendorBillDetails][VBD]" +
                         " LEFT  JOIN [dbo].[Item][Itm] ON [VBD].[ItemID]=[Itm].[ID]" +
                         " LEFT  JOIN [dbo].[ItemType][ity] ON [Itm].[ItemTypeID]=[ity].[ID]" +
                         " LEFT  JOIN [dbo].[VendorBill][VB] ON [VBD].[MID]=[VB].[ID]" +
                         "  WHERE ([VB].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [VB].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        public string CheckReceiptReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT  [CR].[ID]" +
                         " ,[CR].[ReceiptID]  [I1]    " +
                         " ,[CR].[InvoiceNo][S1]" +
                         " ,[CR].[TrnsDate]	[Date1]" +
                         " ,[CR].[PaybyCheck][D1]" +
                         " ,[CR].[CheckNo]   [S2]" +
                         " ,[CR].[AddDate]	[Date2]" +
                         "  FROM [dbo].[CustomerReceipt][CR]" +
                         "  WHERE ([CR].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [CR].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') AND [PaybyCheck] > 0  ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string PaidInsReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [CR].[ID]" +
                         " ,[CR].[ReceiptID][I1]" +
                         " ,[CR].[CustomerID][I2]" +
                         " ,[CR].[WOID][I3]" +
                         " ,[CR].[InvoiceNo][S1]" +
                         " ,[CR].[TrnsDate][Date1]" +
                         " ,[CR].[TrnsNotes][S2]" +
                         " ,[CR].[ChgOnAccount][D1]" +
                         " ,[CR].[PayByCash][D2]" +
                         " ,[CR].[PaybyCheck][D3]" +
                         " ,[CR].[CheckNo][S4]" +
                         " ,[CR].[LicNo][S5]" +
                         " ,[CR].[PayByDeposit][D4]" +
                         " ,[CR].[PayByVisa][D5]" +
                         " ,[CR].[PayByMC][D6]" +
                         " ,[CR].[PayByAMEX][D7]" +
                         " ,[CR].[PayByATM][D8]" +
                         " ,[CR].[PayByGY][D9]" +
                         " ,[CR].[PayByDSCVR][D10]" +
                         " ,[CR].[TotalReceivedAmount][D11]      " +
                         " ,[CR].[AddDate][Date2]      " +
                         " ,[Cus].[CompanyName][S6]" +
                         " FROM [dbo].[CustomerReceipt][CR]" +
                         " LEFT JOIN [dbo].[Customer][Cus] ON [CR].[CustomerID] = [Cus].[ID]" +
                         "  WHERE ([CR].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [CR].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string PaidOutReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [VP].[ID]" +
                         " ,[VP].[PaymentID][I1]" +
                         " ,[VP].[VendorID][I2]" +
                         " ,[VP].[BillID][I3]" +
                         " ,[VP].[InvoiceNo][S1]" +
                         " ,[VP].[TrnsDate][Date1]" +
                         " ,[VP].[TrnsNotes][S2]" +
                         " ,[VP].[TrnsType] [S3]  " +
                         " ,[VP].[BillAmount][D1]" +
                         " ,[VP].[BillDiscount][D2]" +
                         " ,[VP].[PaidAmount][D3]" +
                         " ,[VP].[BillBalance]  [D4]    " +
                         " ,[VP].[AddDate][Date2]" +
                         " ,[Ven].[Name][S4]" +
                         " FROM [dbo].[VendorPayment][VP]" +
                         " LEFT JOIN [dbo].[Vendor][Ven] ON [VP].[VendorID] = [Ven].[ID]" +
                         "  WHERE ([VP].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [VP].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string TireSizeReportMasterQry(DateTime datefrom, DateTime dateto, Int32 TireSizeID)
        {
            string Qry = " SELECT [Itm].[ID]" +
                         " ,[TS].[TSize][S1]" +
                         " ,[TS].[WType][S2]  " +
                         " ,[Itm].[AddDate][Date1]" +
                         " ,[Itm].[Catalog][S3]" +
                         " ,[Itm].[Name][S4]" +
                         " ,[Ist].[Qty][I1]" +
                         " FROM [dbo].[item][Itm]" +
                         " LEFT JOIN [dbo].[TireSize][TS] ON [Itm].[ItemSize] = [TS].[TSize]" +
                         " LEFT JOIN [dbo].[ItemStock][Ist] ON [Itm].[ID] = [Ist].[ItemID]" +
                         "  WHERE ([Itm].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [Itm].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') AND [TS].[TSize] IS NOT NULL ";
            if (TireSizeID > 0)
                Qry += "AND [TS].[ID] = " + TireSizeID + " AND [TS].[TSize] IS NOT NULL ";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string ReOrderReportMasterQry()
        {
            string Qry = " SELECT [Itm].[ID]" +
                         " ,[Itm].[ItemSize][S1]" +
                         " ,[Itm].[Catalog][S2]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Itm].[AddDate][Date1]" +
                         " ,[Stk].[Qty][I1]" +
                         " FROM [dbo].[Item][Itm]" +
                         " LEFT JOIN [dbo].[ItemStock][Stk] ON [Itm].[ID] = [Stk].[ItemID]" +
                         " Where [Stk].[Qty] <= 10";
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string TireSizeSaleReportMasterQry(DateTime datefrom, DateTime dateto, Int32 TireSizeID)
        {
            string Qry = " SELECT [WOD].[ID]" +
                         " ,[WOD].[MID]   [I1]" +
                         " ,[WOD].[ItemID][I3]" +
                         " ,[WOD].[Qty] [I2]" +
                         " ,[WOD].[AddDate][Date1]" +
                         " ,[Itm].[Name][S3]" +
                         " ,[Itm].[Catalog][S4]   " +
                         " ,[TS].[ID] " +
                         " ,[TS].[TSize][S1]" +
                         " FROM [dbo].[WorkOrderDetail][WOD]" +
                         " LEFT JOIN [dbo].[Item][Itm] ON [WOD].[ItemID] = [Itm].[ID]" +
                         " LEFT JOIN [dbo].[TireSize][TS] ON [Itm].[ItemSize] = [TS].[TSize]" +
                         "  WHERE ([WOD].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [WOD].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') AND [TS].[TSize] IS NOT NULL";
            if (TireSizeID > 0)
                Qry += " AND [TS].[ID] = " + TireSizeID + " AND [TS].[TSize] IS NOT NULL ";
            return Qry;

        }
        //-----------------------------------------------------------------------//
        public string VendorDailyReportMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [PO].[ID]"+
                         " ,[PO].[VendorID][I1]"+
                         " ,[PO].[POID][I2]"+
                         " ,[PO].[PODate]  [Date1]    "+
                         " ,[PO].[DiscountPer] [D1]     "+
                         " ,[PO].[TotalAmountOrder][D2]   "+   
                         " ,[PO].[TotalQtyOrder]  [I3]"+
                         " ,[PO].[AddDate][Date1]"+
                         " ,[Ven].[Name][S1]"+                                            
      
                         " FROM [dbo].[PurchaseOrder][PO]"+
                         " LEFT JOIN [dbo].[Vendor][Ven] ON [PO].[VendorID] = [Ven].[ID]"+
                         "  WHERE ([PO].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         "  AND [PO].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";          
            return Qry;

        }
        //-----------------------------------------------------------------------//
        public string VendorDailyReportDetailQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [VB].[ID]"+
                         " ,[VB].[BillID][I1] "+
                         " ,[VB].[POID][I2]"+
                         " ,[VB].[BillDate]  [Date1]"+
                         " ,[VB].[GridTotalQty] [I3] "+
                         " ,[VB].[BillTotalAmount] [D1]"+     
                         " ,[VB].[BillType][S1]"+
                         " ,[VB].[Discount]  [D2]"+    
                         " ,[VB].[AddDate][Date2]"+
                         " ,[VP].[PaymentID][I4]"+
                         " ,[VP].[BillID]  [I5]"+
                         " ,[VP].[TrnsDate][Date3]"+
                         " ,[VP].[TrnsNotes]  [S3]"+
                         " ,[VP].[BillAmount][D4]"+
                         " ,[VP].[BillDiscount][D5]"+
                         " ,[VP].[PaidAmount][D6]"+
                         " ,[VP].[BillBalance]  [D7]   "+
                         " ,[VP].[AddDate]  [Date4]"+
                         " FROM [dbo].[VendorBill][VB]"+
                         " LEFT JOIN [dbo].[VendorPayment][VP] ON [VB].[BillID] = [VP].[BillID]" +
                         " LEFT JOIN [dbo].[PurchaseOrder][Po] ON [VB].[POID] = [Po].[POID]" +
                         " WHERE ([PO].[PODate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [PO].[PODate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') ";
            return Qry;

        }
        //-----------------------------------------------------------------------//
        public string PriceLevelSaleReportMasterQry(DateTime datefrom, DateTime dateto, Int32 priceLevelID)
        {
            string Qry = " SELECT [Wo].[ID]"+
                         " ,[Wo].[RegDate][Date1]"+
                         " ,[Wo].[WorkOrderNo][I1]"+
                         " ,[Wo].[Notes][S1]"+
                         " ,[Wo].[CustomerID][I2]"+
                         " ,[Wo].[SaleRepID][I3]"+
                         " ,[Wo].[ReferredByID][I4]      "+
                         " ,[Wo].[PriceLevelID]   [I5]"+
                         " ,[Wo].[PartsPrice][D1]"+
                         " ,[Wo].[LaborPrice][D2]"+
                         " ,[Wo].[OtherPrice][D3]"+
                         " ,[Wo].[FET][D4]"+
                         " ,[Wo].[Taxable][D5]"+
                         " ,[Wo].[Tax][D6]"+
                         " ,[Wo].[Discount][D7]"+
                         " ,[Wo].[Total][D8]"+
                         " ,[Wo].[AddDate][Date2]"+
                         " ,[Cus].[CompanyName][S2]"+
                         " ,[Cus].[LastName][S3]"+
                         " ,[Cus].[CompanyName][S4]"+
                         " ,[IPri].[Name][S5]"+
                         " ,[emp].[Initial][S6]"+
                         " FROM [dbo].[WorkOrder][Wo]"+
                         " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID] = [Cus].[ID]"+
                         " LEFT JOIN [dbo].[ItemPriceLevel][IPri] ON [Wo].[PriceLevelID] = [IPri].[ID]"+
                         " LEFT JOIN [dbo].[Employee][emp] ON [Wo].[SaleRepID] = [Emp].[ID]" +
                         " WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            if (priceLevelID > 0)
                Qry += " AND [Wo].[PriceLevelID] = " + priceLevelID;
            return Qry;
        }
        //-----------------------------------------------------------------------//
        public string CustomerLedgerReportMasterQry(DateTime datefrom, DateTime dateto, Int32 CustID)
        {
            string Qry = " SELECT [Wo].[ID]  , [Wo].[WorkOrderNo] [I1] ,"+
                         " [Wo].[CustomerID][I2] , [Wo].[Notes][S1] ,"+
                         " [Wo].[RegDate][Date1] , [Wo].[AddDate][Date2] ,"+
                         " [Wo].[Total][D1] , [Wo].[Discount][D2] ,"+
                         " [Wo].[FET][D3] , [Wo].[Tax][D4] ,"+
                         " [Wo].[PartsPrice][D5] , [Wo].[LaborPrice][D6] ,"+
                         " [Wo].[OtherPrice][D7] , [Cus].[CompanyName][S3] ,"+
                         " [Cus].[CompanyName][S4] , [Cus].[LastName][S5] ,"+
                         " [Cus].[Email][S6] , [Cus].[Address][S7] ,"+
                         " [D8]=(Select isnull (sum(TotalReceivedAmount),0) from CustomerReceipt where WOID = [Wo].[WorkOrderNo])  ,"+
                         " [CR].[ReceiptID][I3]   ,"+
                         " [CR].[CustomerID][I4]   ,"+
                         " [CR].[WOID][I5]  ,"+
                         " [CR].[InvoiceNo][S8]   ,"+
                         " [CR].[ChgOnAccount][D9]  ,"+
                         " [CR].[PayByCash][D10]  ,"+
                         " [CR].[PaybyCheck][D11]  ,"+
                         " [CR].[PayByDeposit]  [D12]   ,"+
                         " [CR].[PayByVisa]  [D13]   ,"+
                         " [CR].[TotalReceivedAmount]  [D14]   ,"+
                         " [CR].[AddDate][Date3]  "+
                         " FROM [dbo].[WorkOrder] [Wo]   "+
                         " LEFT JOIN [dbo].[Customer] [Cus] ON [Wo].[CustomerID] = [Cus].[ID] "+
                         " LEFT JOIN [dbo].[CustomerReceipt] [CR] ON [Wo].[ID] = [CR].[WOID]" +
                         " WHERE ([Wo].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [Wo].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')  ";
            if (CustID > 0)
                Qry += " AND [Wo].[CustomerID] = " + CustID;
            return Qry;
        }
        public string AgingReportMasterQry(int CustomerID, DateTime datefrom)
        {
            string Qry = "";
            DateTime first30enddate = datefrom;
            DateTime first30startdate = datefrom.AddDays(-30);
            DateTime first60enddate = first30startdate;
            DateTime first60startdate = datefrom.AddDays(-60);
            DateTime first90enddate = first60startdate;
            DateTime first90startdate = datefrom.AddDays(-90);
            DateTime first120enddate = first90startdate;
            DateTime first120startdate = datefrom.AddDays(-120);
            DateTime Above120startdate = datefrom.AddDays(-1825);
            if (CustomerID == 0)
            {
                Qry = @"  Select 
                          [Cus].[ID] ,
                          [Cus].[CompanyName] [S1],
                          [Cus].[ContactPerson] [S2],
                          [Cus].[CreditLimits] [D1]  ,
                          [D2]=(select Sum(Balance) from (select cr.ChgOnAccount-ISNULL(SUM(cch.PaidAmount),0) -ISNULL(SUM(cp.ChgOnAccount),0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and cr.CustomerID = Cus.ID group by InvoiceID,cr.ID,cr.ChgOnAccount) tbl)  ,
                          [Date1]=(Select Max(TrnsDate) from CustomerReceipt where CustomerID= [Cus].[ID])  ,
                          [Date2]=(Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID])  ,
                          [D3]=(select Sum(Balance) from (select cr.ChgOnAccount-ISNULL(SUM(cch.PaidAmount),0) -ISNULL(SUM(cp.ChgOnAccount),0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and (cr.TrnsDate between '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "' and '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID,cr.ID,cr.ChgOnAccount) tbl)," +
                          "[D4] = (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "' and '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D5]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "' and '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D6]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "' and '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D7]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(Above120startdate.Date.Year + "-" + Above120startdate.Date.Month + "-" + Above120startdate.Date.Day) + "' and '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  " +
                          " from[Customer][Cus]" +
                          " Where[Cus].CompanyID = " + StaticInfo.CompanyID;
            }
            else
            {
                Qry = @"  Select " +
                          "[Cus].[ID] ," +
                          "[Cus].[CompanyName] [S1]," +
                          "[Cus].[ContactPerson] [S2]," +
                          "[Cus].[CreditLimits] [D1]  ," +
                          "[D2]=(select Sum(Balance) from (select cr.ChgOnAccount-ISNULL(SUM(cch.PaidAmount),0) -ISNULL(SUM(cp.ChgOnAccount),0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and cr.CustomerID = Cus.ID group by InvoiceID,cr.ID,cr.ChgOnAccount) tbl)  ," +
                          "[Date1]=(Select Max(TrnsDate) from CustomerReceipt where CustomerID= [Cus].[ID])  ," +
                          "[Date2]=(Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID])  ," +
                          "[D3]=(select Sum(Balance) from (select cr.ChgOnAccount-ISNULL(SUM(cch.PaidAmount),0) -ISNULL(SUM(cp.ChgOnAccount),0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and (cr.TrnsDate between '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "' and '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID,cr.ID,cr.ChgOnAccount) tbl)," +
                          "[D4] = (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "' and '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D5]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "' and '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D6]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "' and '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  ," +
                          "[D7]= (select Sum(Balance) from(select cr.ChgOnAccount - ISNULL(SUM(cch.PaidAmount), 0) - ISNULL(SUM(cp.ChgOnAccount), 0) as Balance from CustomerReceipt cr left join CustomerCreditHistory cch on cr.ID = cch.InvoiceID left join WorkOrder wo on cr.WOID = wo.ID left join WorkOrderNegate won on won.WorkOrderID = wo.ID left join CustomerPayment cp on won.ID = cp.WONID where cr.ChgOnAccount != 0 and(cr.TrnsDate between '" + Convert.ToString(Above120startdate.Date.Year + "-" + Above120startdate.Date.Month + "-" + Above120startdate.Date.Day) + "' and '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "') and cr.CustomerID = Cus.ID group by InvoiceID, cr.ID, cr.ChgOnAccount) tbl)  " +
                          " from[Customer][Cus]" +
                          " Where[Cus].CompanyID = " + StaticInfo.CompanyID + " And[Cus].[ID] = " + CustomerID;
                    //"  Select [Cus].[ID]" +
                    //         " ,[Cus].[CompanyName] [S1],[Cus].[ContactPerson] [S2],[Cus].[CreditLimits] [D1] " +
                    //         " ,[D2]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where CustomerID = [Cus].[ID])-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID])-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID]) " +
                    //         " ,[Date1]=(Select Max(TrnsDate) from CustomerReceipt where CustomerID= [Cus].[ID]) " +
                    //         " ,[Date2]=(Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID]) " +
                    //         " ,[D3]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where  CustomerID = [Cus].[ID] and TrnsDate >= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "') " +
                    //         " ,[D4]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where  CustomerID = [Cus].[ID] and TrnsDate >= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.AddDays(-1).Day) + "') " +
                    //         " ,[D5]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where  CustomerID = [Cus].[ID] and TrnsDate >= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.AddDays(-1).Day) + "') " +
                    //         " ,[D6]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where  CustomerID = [Cus].[ID] and TrnsDate >= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.AddDays(-1).Day) + "') " +
                    //         " ,[D7]=(Select ISNULL((SUM (ChgOnAccount)),0) from CustomerReceipt where  CustomerID = [Cus].[ID] and TrnsDate >= '" + Convert.ToString(Above120startdate.Date.Year + "-" + Above120startdate.Date.Month + "-" + Above120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (ChgOnAccount),0) from CustomerPayment where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(Above120startdate.Date.Year + "-" + Above120startdate.Date.Month + "-" + Above120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.AddDays(-1).Day) + "')-(Select ISNULL(SUM (PaidAmount),0) from CustomerCreditHistory where CustomerID=[Cus].[ID] and TrnsDate >= '" + Convert.ToString(Above120startdate.Date.Year + "-" + Above120startdate.Date.Month + "-" + Above120startdate.Date.Day) + "'  and TrnsDate <= '" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.AddDays(-1).Day) + "') " +
                    //         //" ,[D4]=(Select ISNULL((SUM (Total)),0) from WorkOrder where CustomerID = [Cus].[ID] and RegDate >= '2020-02-01'  and RegDate <= '2020-02-19')-(Select ISNULL(SUM (TotalReceivedAmount),0) from CustomerReceipt where CustomerID=[Cus].[ID] and AddDate >= '2020-02-01'  and AddDate <= '2020-02-19') 
                    //         //" ,[D5]=(Select ISNULL((SUM (Total)),0) from WorkOrder where CustomerID = [Cus].[ID] and RegDate >= '2020-02-01'  and RegDate <= '2020-02-19')-(Select ISNULL(SUM (TotalReceivedAmount),0) from CustomerReceipt where CustomerID=[Cus].[ID] and AddDate >= '2020-02-01'  and AddDate <= '2020-02-19') 
                    //         " from [Customer] [Cus] " +
                    //          " Where [Cus].CompanyID= " + StaticInfo.CompanyID + " And [Cus].[ID]=" + CustomerID;
            }


            //String Qry = " If 0=" + CustomerID +

            //              " Begin" +
            //                  " Select[Cus].[ID] ,[Cus].[CompanyName][S1],[Cus].[ContactPerson][S2],[Cus].[CreditLimits][D1]" +
            //                  " ,[D2]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt where CustomerID =[Cus].[ID])" +
            //                  " -(Select ISNULL(SUM(ChgOnAccount), 0) from CustomerPayment where CustomerID =[Cus].[ID])" +
            //                  " -(Select ISNULL(SUM(PaidAmount), 0) from CustomerCreditHistory where CustomerID =[Cus].[ID])" +
            //                  " ,[Date1]= (Select Max(TrnsDate) from CustomerReceipt where CustomerID = [Cus].[ID])  ,[Date2]= (Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID])  " +
            //                  " ,[D3]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and CustomerReceipt.TrnsDate >=" +
            //                  "   (select(cast(DATEADD(day, -1 * Terms.DueByDaysD1," +                                 
            //                     "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
            //                     ") as date)))  and CustomerReceipt.TrnsDate <=" +                                 
            //                      "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')" +
            //                      " -(Select ISNULL(SUM(ChgOnAccount), 0) from CustomerPayment left Join Customer ON CustomerPayment.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and CustomerPayment.TrnsDate >=" +
            //                  "   (select(cast(DATEADD(day, -1 * Terms.DueByDaysD1," +
            //                     "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
            //                     ") as date)))  and CustomerPayment.TrnsDate <=" +
            //                      "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')" +
            //                  " ,[D4]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 = 30" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  //"'2020-12-21'"+
            //                  "'" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first30enddate.Date.Year + "-" + first30enddate.Date.Month + "-" + first30enddate.Date.Day) + "')" +
            //                  //"'" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'"+
            //                  // "and CustomerReceipt.TrnsDate <=" +
            //                  //"'2021-01-20') "+
            //                  //"'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
            //                  " ,[D5]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 <= 60" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  //"'2020-11-21'"+
            //                  "'" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first60enddate.Date.Year + "-" + first60enddate.Date.Month + "-" + first60enddate.Date.Day) + "')" +
            //                  //"'" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'"+
            //                  //"and CustomerReceipt.TrnsDate <=" +
            //                  //"'2020-12-21')"+
            //                  //"'" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'" +
            //                  " ,[D6]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 <= 90" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  //"'2020-10-22'"+
            //                  "'" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first90enddate.Date.Year + "-" + first90enddate.Date.Month + "-" + first90enddate.Date.Day) + "')" +
            //                  //"'" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'" +
            //                  //"and CustomerReceipt.TrnsDate <=" +
            //                  //"'2020-11-21')"+  		
            //                  //"'" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'" +
            //                  " ,[D7]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 < 90" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  "'" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first120enddate.Date.Year + "-" + first120enddate.Date.Month + "-" + first120enddate.Date.Day) + "')" +
            //                   //"'2016-1-22'"+
            //                   //"and CustomerReceipt.TrnsDate <="+
            //                   //"'2020-10-22')"+  		  
            //                   " From[Customer][Cus]" +
            //                   " Where [Cus].CompanyID= " + StaticInfo.CompanyID +
            //              " End" +
            //        " Else" +

            //              " Begin" +
            //                  " Select[Cus].[ID] ,[Cus].[CompanyName][S1],[Cus].[ContactPerson][S2],[Cus].[CreditLimits][D1]" +
            //                  " ,[D2]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt where CustomerID =[Cus].[ID])" +
            //                  " ,[Date1]= (Select Max(TrnsDate) from CustomerReceipt where CustomerID = [Cus].[ID])  ,[Date2]= (Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID])  " +
            //                  " ,[D3]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and CustomerReceipt.TrnsDate >=" +
            //                  " (select(cast(DATEADD(day, -1 * Terms.DueByDaysD1, " +
            //                     //"'2021-01-18'"+
            //                     "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
            //                     ") as date)))  and CustomerReceipt.TrnsDate <=" +
            //                      //"'2021-01-18')  "+
            //                      "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')" +
            //                  " ,[D4]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 = 30" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  "'" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first30enddate.Date.Year + "-" + first30enddate.Date.Month + "-" + first30enddate.Date.Day) + "')" +
            //                  //"'2020-12-21'"+
            //                  //"and CustomerReceipt.TrnsDate <="+
            //                  //"'2021-01-20') "+		  
            //                  " ,[D5]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 <= 60" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  "'" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first60enddate.Date.Year + "-" + first60enddate.Date.Month + "-" + first60enddate.Date.Day) + "')" +
            //                  //"'2020-11-21'"+
            //                  //"and CustomerReceipt.TrnsDate <="+
            //                  //"'2020-12-21')  "+		  
            //                  " ,[D6]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 <= 90" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  "'" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first90enddate.Date.Year + "-" + first90enddate.Date.Month + "-" + first90enddate.Date.Day) + "')" +
            //                  //"'2020-10-22'"+
            //                  //"and CustomerReceipt.TrnsDate <="+
            //                  //"'2020-11-21')  "+		  
            //                  " ,[D7]= (Select ISNULL(SUM(ChgOnAccount), 0) from CustomerReceipt left Join Customer ON CustomerReceipt.CustomerID = Customer.ID" +
            //                  " left Join Terms on Customer.SaleTermID = Terms.ID where CustomerID =[Cus].[ID] and Terms.DueByDaysD1 < 90" +
            //                  " and CustomerReceipt.TrnsDate >=" +
            //                  "'" + Convert.ToString(first120startdate.Date.Year + "-" + first120startdate.Date.Month + "-" + first120startdate.Date.Day) + "'  and CustomerReceipt.TrnsDate <= '" + Convert.ToString(first120enddate.Date.Year + "-" + first120enddate.Date.Month + "-" + first120enddate.Date.Day) + "')" +
            //                  //"'2016-1-22'"+
            //                  //"and CustomerReceipt.TrnsDate <=" +
            //                  //"'2020-10-22')  " +
            //                  "  From [Customer][Cus]" +
            //                  "  Where [Cus].CompanyID= " + StaticInfo.CompanyID + " And [Cus].ID = " + CustomerID +
            //            " End";

            return Qry;
        }
        public string VendorAgingReportMasterQry(DateTime datefrom)
        {
            DateTime first30enddate = datefrom;
            DateTime first30startdate = datefrom.AddDays(-30);
            DateTime first60enddate = first30startdate.AddDays(-1);
            DateTime first60startdate = datefrom.AddDays(-60);
            DateTime first90enddate = first60startdate.AddDays(-1);
            DateTime first90startdate = datefrom.AddDays(-1825);
            string Qry ="Select [Cus].[ID] ," +
                        "[Cus].[Name][S1]," +
                        "[Cus].[ContactName] [S2]   ," +
                        "[D2]= (Select Sum(Balance) from(select Sum(BillTotalAmount - PaidAmount) as Balance from VendorBill where VendorID = cus.ID and CompanyID = Cus.CompanyID group by BillDate) tbl)," +
                        "[Date1]= (Select Max(TrnsDate) from CustomerReceipt where CustomerID = [Cus].[ID])   ," +
                        "[Date2]= (Select Max(RegDate) from WorkOrder where CustomerID = [Cus].[ID])  ," +
                        "[D3]= (Select Sum(Balance) from(select Sum(BillTotalAmount - PaidAmount) as Balance from VendorBill where VendorID = cus.ID and CompanyID = cus.CompanyID and BillDate between '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "' and '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "') tbl)  ," +
                        "[D4]= (Select Sum(Balance) from(select Sum(BillTotalAmount - PaidAmount) as Balance from VendorBill where VendorID = cus.ID and CompanyID = cus.CompanyID and BillDate between '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "' and '" + Convert.ToString(first30enddate.Date.Year + "-" + first30enddate.Date.Month + "-" + first30enddate.Date.Day) + "') tbl)  ," +
                        "[D5]= (Select Sum(Balance) from(select Sum(BillTotalAmount - PaidAmount) as Balance from VendorBill where VendorID = cus.ID and CompanyID = cus.CompanyID and BillDate between '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "' and '" + Convert.ToString(first60enddate.Date.Year + "-" + first60enddate.Date.Month + "-" + first60enddate.Date.Day) + "') tbl)  ," +
                        "[D6]= (Select Sum(Balance) from(select Sum(BillTotalAmount - PaidAmount) as Balance from VendorBill where VendorID = cus.ID and CompanyID = cus.CompanyID and BillDate between '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "' and '" + Convert.ToString(first90enddate.Date.Year + "-" + first90enddate.Date.Month + "-" + first90enddate.Date.Day) + "') tbl)  " +
                        "from [Vendor][Cus]";

            return Qry;
        }
        public string CTransactionAgingReportDetailQry(DateTime datefrom, DateTime dateto , Int32 CustomerID)
        {
            DateTime first30enddate = datefrom;
            DateTime first30startdate = datefrom.AddDays(-30);
            DateTime first60enddate = first30startdate;
            DateTime first60startdate = datefrom.AddDays(-60);
            DateTime first90enddate = first60startdate;
            DateTime first90startdate = datefrom.AddDays(-100);

            //DateTime first30enddate = dateto;
            //DateTime first30startdate = datefrom.AddDays(-30);
            //DateTime first60enddate = first30startdate;
            //DateTime first60startdate = datefrom.AddDays(-60);
            //DateTime first90enddate = first60startdate;
            //DateTime first90startdate = datefrom.AddDays(-100);

            //string Qry = "   SELECT [Wo].[ID] " +
            //             " ,[Wo].[RegDate][Date1] " +
            //             " ,[Wo].[WorkOrderNo][I1] " +
            //             " ,[Wo].[Notes]     [S1] " +
            //             " ,[Wo].[CustomerID][I2] " +
            //             " ,[Wo].[SaleRepID]     [I3]  " +
            //             " ,[Wo].[SaleTermID][I4] " +
            //             " ,[Wo].[Total]  [D1] " +
            //             " ,[Wo].[AddDate]    [Date1] " +
            //             " ,[Cus].[CompanyName]   [S2]  " +
            //             " ,[Cus].[ContactPerson][S3] " +
            //             " ,[Cus].[CreditLimits]    [D2]" +
            //             " ,[D3]=(Select ISNULL((SUM (Total)),0) from WorkOrder where WorkOrderNo = [Wo].[WorkOrderNo] and RegDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'  and RegDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
            //             " ,[D4]=(Select ISNULL((SUM (Total)),0) from WorkOrder where WorkOrderNo = [Wo].[WorkOrderNo] and RegDate >= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and RegDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
            //             " ,[D5]=(Select ISNULL((SUM (Total)),0) from WorkOrder where WorkOrderNo = [Wo].[WorkOrderNo] and RegDate >= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and RegDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
            //             " ,[D6]=(Select ISNULL((SUM (Total)),0) from WorkOrder where WorkOrderNo = [Wo].[WorkOrderNo] and RegDate >= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and RegDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')" +
            //             " FROM [dbo].[WorkOrder][Wo] " +
            //             " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID] = [Cus].[ID]";
            string Qry = "SELECT [Wo].[ID]  ,[Wo].[AddDate] [Date]  ,[Wo].[WOID]  ,[Wo].Comments     [S1]  ,[Wo].[CustomerID][I2]  ,[Wo].CustomerID     [I3]   ,[Wo].[CustomerID][I4]  ,[Wo].[TotalReceivedAmount]  [D1]  ,[Wo].[AddDate]    [Date1]  ,[Cus].[CompanyName]   [S2]   ,[Cus].[ContactPerson][S3]  ,[Cus].[CreditLimits]    [D2] ,[D3]=(Select ISNULL((SUM (TotalReceivedAmount)),0) from CustomerReceipt " +
                "where WOID = [Wo].[WOID] and WO.AddDate >= '2021-1-14'  and WO.AddDate <= '2021-1-14') ,[D4]= (Select ISNULL((SUM(TotalReceivedAmount)), 0) from CustomerReceipt where WOID = [Wo].[WOID] and" +
                " AddDate >= " +
                "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
//                "'2020-12-15'  " +
                "and AddDate <= " +
                "'" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "'" +
                //"'2021-1-14'" +
                ") ,[D5]= (Select ISNULL((SUM(TotalReceivedAmount)), 0) from CustomerReceipt where WOID = [Wo].WOID and " +
                "AddDate >= " +
                "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                //"'2020-11-15'  " +
                "and AddDate <= " +
                "'" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "'" +
                //"'2021-1-14'" +
                ") ,[D6]= (Select ISNULL((SUM(TotalReceivedAmount)), 0) from CustomerReceipt where WOID = [Wo].[WOID] and " +
                "AddDate >= " +
                "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                //"'2020-10-6'" +
                "  and AddDate <= " +
                "'" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "'" +
                //"'2021-1-14'" +
                ") FROM[dbo].[CustomerReceipt][Wo]  LEFT JOIN[dbo].[Customer][Cus] ON[Wo].[CustomerID] = [Cus].[ID]" +
                "Where (WOID = [Wo].[WOID] and " +
                "WO.AddDate >= " +
                "'" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                //"'2020-10-6'" +
                "  and WO.AddDate <= " +
                "'" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";

            if (CustomerID > 0)
                Qry += "AND [WO].[CustomerID] = " + CustomerID;
            Qry += "Order by [Wo].[ID] Desc";
            return Qry;
        }
        public string VTransactionAgingReportDetailQry(DateTime datefrom, Int32 CustomerID)
        {
            DateTime first30enddate = datefrom;
            DateTime first30startdate = datefrom.AddDays(-30);
            DateTime first60enddate = first30startdate;
            DateTime first60startdate = datefrom.AddDays(-60);
            DateTime first90enddate = first60startdate;
            DateTime first90startdate = datefrom.AddDays(-100);
            string Qry = "   SELECT [Wo].[ID] " +
                         " ,[Wo].[BillDate][Date1] " +
                         " ,[Wo].[BillID][I1] " +
                         " ,[Wo].[BillNotes]     [S1] " +
                         " ,[Wo].[VendorID][I2] " +
                         " ,[Cus].[TermsID][I4] " +
                         " ,[Wo].[BillTotalAmount]  [D1] " +
                         " ,[Wo].[AddDate]    [Date1] " +
                         " ,[Cus].[Name]   [S2]  " +
                         " ,[Cus].[Phone][S3] " +
                         " ,[D3]=(Select ISNULL((SUM (BillTotalAmount)),0) from VendorBill where BillID = [Wo].[BillID] and BillDate >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'  and BillDate <= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "')" +
                         " ,[D4]=(Select ISNULL((SUM (BillTotalAmount)),0) from VendorBill where BillID = [Wo].[BillID] and BillDate >= '" + Convert.ToString(first30startdate.Date.Year + "-" + first30startdate.Date.Month + "-" + first30startdate.Date.Day) + "'  and BillDate <= '" + Convert.ToString(first30enddate.Date.Year + "-" + first30enddate.Date.Month + "-" + first30enddate.Date.Day) + "')" +
                         " ,[D5]=(Select ISNULL((SUM (BillTotalAmount)),0) from VendorBill where BillID = [Wo].[BillID] and BillDate >= '" + Convert.ToString(first60startdate.Date.Year + "-" + first60startdate.Date.Month + "-" + first60startdate.Date.Day) + "'  and BillDate <= '" + Convert.ToString(first60enddate.Date.Year + "-" + first60enddate.Date.Month + "-" + first60enddate.Date.Day) + "')" +
                         " ,[D6]=(Select ISNULL((SUM (BillTotalAmount)),0) from VendorBill where BillID = [Wo].[BillID] and BillDate >= '" + Convert.ToString(first90startdate.Date.Year + "-" + first90startdate.Date.Month + "-" + first90startdate.Date.Day) + "'  and BillDate <= '" + Convert.ToString(first90enddate.Date.Year + "-" + first90enddate.Date.Month + "-" + first90enddate.Date.Day) + "')" +
                         " FROM [dbo].[VendorBill][Wo] " +
                         " LEFT JOIN [dbo].[Vendor][Cus] ON [Wo].[VendorID] = [Cus].[ID]";
            if (CustomerID > 0)
                Qry += "Where [WO].[VendorID] = " + CustomerID;

            return Qry;
        }
        public string InvoiceBillingReportMasterQry(int ID)
        {
            string Qry = " SELECT [Wo].[ID]" +
                         " ,[Wo].[RegDate][Date1]" +
                         " ,[Wo].[WorkOrderNo][I1]" +
                         " ,[Wo].[BookingNo][D1]    " +
                         " ,[Wo].[BookingInsuranceRate][N1]" +
                         " ,[Wo].[CustomerID][I2]" +
                         " ,[Wo].[ShipToCustomerID][I3]" +
                         " ,[Wo].[BookingTotalQty][I4]" +
                         " ,[Wo].[BookingTotalWeight][D2]" +
                         " ,[Wo].[BookingTotalInsurance][D3]" +
                         " ,[Wo].[Notes] [S1]" +
                         " ,[Wo].[PickupDate][Date2]    " +
                         " ,[Wo].[Status][S2]" +
                         " ,[Wo].[AddDate][Date3]" +
                         " ,[Cus].[FirstName][S4]" +
                         " ,[Cus].[LastName] [S5]  " +
                         " ,[Cus].[CompanyName][S6]" +
                         " ,[Cus].[Address][S7]" +
                         " ,[Cus].[ContactPerson][S8]" +
                         " ,[Cus].[Email][S9]" +
                         " ,[Cus].[State][S10]" +
                         " ,[Cus].[City][S11]" +
                         " ,[Cus].[ZipCode][I5]" +
                         " ,[Cus].[Phone1][S12]" +
                         " ,[Cus].[Phone2][S13]  " +
                         " ,[Cus1].[FirstName][S14]" +
                         " ,[Cus1].[LastName] [S15]  " +
                         " ,[Cus1].[CompanyName][S16]" +
                         " ,[Cus1].[Address][S17]" +
                         " ,[Cus1].[ContactPerson][S18]" +
                         " ,[Cus1].[Email][S19]" +
                         " ,[Cus1].[State][S20]" +
                         " ,[Cus1].[City][S21]" +
                         " ,[Cus1].[ZipCode][I6]" +
                         " ,[Cus1].[Phone1][S22]" +
                         " ,[Cus1].[Phone2][S23]" +
                         " ,[Cus1].[Phone3][S24]" +
                         " ,[Cus1].[Phone4][S25]" +

                         " FROM [dbo].[WorkOrder][Wo]" +
                         " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID] = [Cus].[ID]" +
                         " LEFT JOIN [dbo].[Customer][Cus1] ON [Wo].[ShipToCustomerID] = [Cus1].[ID]" +
                         " where [Wo].[ID] =  " + ID;
            return Qry;
        }
        public string InvoiceBillingReportDetailQry(int ID)
        {
            string Qry = " SELECT [Wod].[ID]" +
                         " ,[Wod].[MID]    " +
                         " ,[Wod].[Catalog][S1]" +
                         " ,[Wod].[itemValue][D1]" +
                         " ,[Wod].[itemWeight][D2]" +
                         " ,[Wod].[PkgSize][S2]" +
                         " ,[Wod].[PkgCharges][D3]" +
                         " ,[Wod].[IsInsured][I1]" +
                         " ,[Wod].[InsAmt][D10]" +
                         " ,[Wod].[Qty]   [I2]" +
                         " ,[Wod].[Price][D4]" +
                         " ,[Wod].[Cost][D5]" +
                         " ,[Wod].[Amount][D6]" +
                         " ,[Wod].[DiscPer][D6]" +
                         " ,[Wod].[DiscAmount][D7]" +
                         " ,[Wod].[FET][D8]" +
                         " ,[Wod].[Total] [D9]     " +
                         " ,[Wod].[RepID]  [I3]  " +
                         " ,[Wod].[AddDate]   [Date1]   " +
                         " FROM [dbo].[WorkOrderDetail][Wod]" +
                         " where [wod].[MID] =  " + ID;
            return Qry;
        }
        public string InvoiceBillingReportDetailMasterQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Wo].[ID]" +
                         " ,[Wo].[RegDate][Date1]" +
                         " ,[Wo].[WorkOrderNo][I1]" +
                         " ,[Wo].[BookingNo][D1]    " +
                         " ,[Wo].[BookingInsuranceRate][N1]" +
                         " ,[Wo].[CustomerID][I2]" +
                         " ,[Wo].[ShipToCustomerID][I3]" +
                         " ,[Wo].[BookingTotalQty][I4]" +
                         " ,[Wo].[BookingTotalWeight][D2]" +
                         " ,[Wo].[BookingTotalInsurance][D3]" +
                         " ,[Wo].[Notes] [S1]" +
                         " ,[Wo].[PickupDate][Date2]    " +
                         " ,[Wo].[Status][S2]" +
                         " ,[Wo].[AddDate][Date3]" +
                         " ,[Cus].[FirstName][S4]" +
                         " ,[Cus].[LastName] [S5]  " +
                         " ,[Cus].[CompanyName][S6]" +
                         " ,[Cus].[Address][S7]" +
                         " ,[Cus].[ContactPerson][S8]" +
                         " ,[Cus].[Email][S9]" +
                         " ,[Cus].[State][S10]" +
                         " ,[Cus].[City][S11]" +
                         " ,[Cus].[ZipCode][I5]" +
                         " ,[Cus].[Phone1][S12]" +
                         " ,[Cus].[Phone2][S13]  " +
                         " ,[Cus1].[FirstName][S14]" +
                         " ,[Cus1].[LastName] [S15]  " +
                         " ,[Cus1].[CompanyName][S16]" +
                         " ,[Cus1].[Address][S17]" +
                         " ,[Cus1].[ContactPerson][S18]" +
                         " ,[Cus1].[Email][S19]" +
                         " ,[Cus1].[State][S20]" +
                         " ,[Cus1].[City][S21]" +
                         " ,[Cus1].[ZipCode][I6]" +
                         " ,[Cus1].[Phone1][S22]" +
                         " ,[Cus1].[Phone2][S23]" +
                         " ,[Cus1].[Phone3][S24]" +
                         " ,[Cus1].[Phone4][S25]" +

                         " FROM [dbo].[WorkOrder][Wo]" +
                         " LEFT JOIN [dbo].[Customer][Cus] ON [Wo].[CustomerID] = [Cus].[ID]" +
                         " LEFT JOIN [dbo].[Customer][Cus1] ON [Wo].[ShipToCustomerID] = [Cus1].[ID]" +
                         " WHERE ([WO].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [WO].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            return Qry;
        }
        public string InvoiceBillingReportDetailDetailQry(DateTime datefrom, DateTime dateto)
        {
            string Qry = " SELECT [Wod].[ID]" +
                         " ,[Wod].[MID]    " +
                         " ,[Wod].[Catalog][S1]" +
                         " ,[Wod].[itemValue][D1]" +
                         " ,[Wod].[itemWeight][D2]" +
                         " ,[Wod].[PkgSize][S2]" +
                         " ,[Wod].[PkgCharges][D3]" +
                         " ,[Wod].[IsInsured][I1]" +
                         " ,[Wod].[InsAmt][D10]" +
                         " ,[Wod].[Qty]   [I2]" +
                         " ,[Wod].[Price][D4]" +
                         " ,[Wod].[Cost][D5]" +
                         " ,[Wod].[Amount][D6]" +
                         " ,[Wod].[DiscPer][D6]" +
                         " ,[Wod].[DiscAmount][D7]" +
                         " ,[Wod].[FET][D8]" +
                         " ,[Wod].[Total] [D9]     " +
                         " ,[Wod].[RepID]  [I3]  " +
                         " ,[Wod].[AddDate]   [Date1]   " +
                         " FROM [dbo].[WorkOrderDetail][Wod]" +
                         " LEFT JOIN [dbo].[WorkOrder][Wo] ON [Wod].[MID] = [WO].[ID]" +
                         " WHERE ([WO].[AddDate] >= '" + Convert.ToString(datefrom.Date.Year + "-" + datefrom.Date.Month + "-" + datefrom.Date.Day) + "'" +
                         " AND [WO].[AddDate] <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "')";
            return Qry;
        }

        public string SalesREPSummaryDetailedReportQry(DateTime Fromdate, DateTime Todate)
        {
            DateTime LastMonth = Fromdate.AddMonths(-1);

            string Qry = "Select TempX.S1, IsNull(TempB.N1,0) As N1, IsNull(TempA.N2,0) as N2, IsNull(TempA.N3,0) as N3, IsNull(TempD.N4,0) as N4, IsNull(TempC.N5,0) as N5, IsNull(TempC.N6,0) as N6, IsNull(TempF.N7,0) as N7, IsNull(TempE.N8,0) as N8, "+
                "IsNull(TempE.N9, 0) as N9, IsNull(TempH.N10, 0) as N10, IsNull(TempG.N11, 0) as N11, IsNull(TempG.N12, 0) as N12 "+
                "From " +
                "(Select Customer.FirstName as S1, Customer.ID from CustomerReceipt Left Outer Join Customer On Customer.ID = CustomerReceipt.CustomerID group by Customer.ID, Customer.FirstName) as TempX " +
                "Full join " +
                "(Select Customer.ID, IsNull(Sum(WorkOrderDetail.Total),0) as N2, IsNull(Sum(WorkOrderDetail.Profit), 0) as N3 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID = WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID = WorkOrder.ID Left Outer Join Customer On Customer.ID = CustomerReceipt.CustomerID " +
                "Where CustomerReceipt.TrnsDate " +
                " between '" + Convert.ToString(Fromdate.Date.Year + "-" + Fromdate.Date.Month + "-" + Fromdate.Date.Day) + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Date.Month + "-" + Todate.Date.Day) + "'" +
                "group by Customer.ID) as TempA " +
                "on TempX.ID = TempA.ID Full join " +

                "(Select IsNull(count(CustomerID),0) as N1, CustomerID from CustomerReceipt where CustomerReceipt.TrnsDate " +
                " between '" + Convert.ToString(Fromdate.Date.Year + "-" + Fromdate.Date.Month + "-" + Fromdate.Date.Day) + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Date.Month + "-" + Todate.Date.Day) + "'" +
                "group by CustomerID) as TempB " +
                "On TempX.ID = TempB.CustomerID Full join " +

                "(Select Customer.ID, IsNull(Sum(WorkOrderDetail.Total),0) as N5, IsNull(Sum(WorkOrderDetail.Profit), 0) as N6 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID = WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID = WorkOrder.ID Left Outer Join Customer On Customer.ID = CustomerReceipt.CustomerID " +
                "Where CustomerReceipt.TrnsDate " +
                "between '" + Convert.ToString(Fromdate.Date.Year + "-" + Fromdate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Date.Month + "-" + Todate.Date.Day) + "'" +
                "group by Customer.ID, Customer.FirstName ) as TempC " +
                "On TempX.ID = TempC.ID Full join " +

                "(Select IsNull(count(CustomerID),0) as N4, CustomerID from CustomerReceipt where CustomerReceipt.TrnsDate " +
                "between '" + Convert.ToString(Fromdate.Date.Year + "-" + Fromdate.Date.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Date.Month + "-" + Todate.Date.Day) + "'" +
                "group by CustomerID) as TempD " +
                "On TempX.ID = TempD.CustomerID Full join " +

                "(Select Customer.ID, IsNull(Sum(WorkOrderDetail.Total),0) as N8, IsNull(Sum(WorkOrderDetail.Profit), 0) as N9 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID = WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID = WorkOrder.ID Left Outer Join Customer On Customer.ID = CustomerReceipt.CustomerID " +
                "Where CustomerReceipt.TrnsDate " +
                "between '" + Convert.ToString(Fromdate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Fromdate.Date.Year + "-" + LastMonth.Month + "-" + LastMonth.AddMonths(1).AddDays(-1).Day) + "'" +
                "group by Customer.ID, Customer.FirstName ) as TempE " +
                "On TempX.ID = TempE.ID Full join " +

                "(Select IsNull(count(CustomerID),0) as N7, CustomerID from CustomerReceipt where CustomerReceipt.TrnsDate " +
                "between '" + Convert.ToString(Fromdate.Date.Year + "-" + LastMonth.Month + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Fromdate.Date.Year + "-" + LastMonth.Month + "-" + LastMonth.AddMonths(1).AddDays(-1).Day) + "'" +
                "group by CustomerID) as TempF " +
                "On TempX.ID = TempF.CustomerID Full join " +

                "(Select Customer.ID, IsNull(Sum(WorkOrderDetail.Total), 0) as N11, IsNull(Sum(WorkOrderDetail.Profit), 0) as N12 " +
                "From CustomerReceipt Left Outer Join WorkOrder On CustomerReceipt.WOID = WorkOrder.ID Left Outer Join WorkOrderDetail On WorkOrderDetail.MID = WorkOrder.ID Left Outer Join Customer On Customer.ID = CustomerReceipt.CustomerID " +
                "Where CustomerReceipt.TrnsDate " +
                 "between '" + Convert.ToString(Fromdate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Month + "-" + Todate.Date.Day) + "'" +
                "group by Customer.ID, Customer.FirstName ) as TempG " +
                "On TempX.ID = TempG.ID Full join " +

                "(Select IsNull(count(CustomerID),0) as N10, CustomerID from CustomerReceipt where CustomerReceipt.TrnsDate " +
                 "between '" + Convert.ToString(Fromdate.Date.Year + "-" + "01" + "-" + "01") + "'" + " And " + "'" + Convert.ToString(Todate.Date.Year + "-" + Todate.Month + "-" + Todate.Date.Day) + "'" +
                "group by CustomerID) as TempH " +
                "On TempX.ID = TempH.CustomerID " +

                "Order by TempX.S1 ";
            
            return Qry;
        }

    }
}
