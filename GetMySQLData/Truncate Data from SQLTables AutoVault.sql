
UPDATE [dbo].[Company] SET [CoCode] = '101' ,[CoName] = 'Your Comany Name' ,[CoAddress] = 'Your Comany Address' ,[CoPhone] = '1234567654' ,[CoFax] = '1234567654' ,[CoEmail] = 'ComapnyEmail@email.com' ,[BarNo] = NULL ,[LicenceNo] = NULL ,[ZipCode] = 85043,[AreaCode] = NULL ,[AreaCode1] = NULL ,[AreaCode2] = NULL ,[CompanyLogo] = NULL ,[IsSingleWarehouse] = 1 ,[IsSingleStore] = 1 ,[IsMultiStore] = 0 ,[Active] = 1 ,[AddDate] = GETDATE() ,[AddUserID] = -2 ,[ModifyUserID] = NULL ,[ModifyDate] = NULL ,[Comments] = 'Default Company' ,[IsLocked] = 1 ,[DocNo] = NULL ,[Remarks] = 'Default Company' ,[TrnsVrNo] = NULL ,[TrnsJrRef] = NULL;
UPDATE [dbo].[Warehouse] SET [CompanyID] = 1 ,[CoCode] = '10101' ,[CoName] = 'Your Warehouse Name' ,[CoAddress] = 'Your Warehouse Address' ,[CoPhone] = '1234567654' ,[CoFax] = '1234567654' ,[CoEmail] = 'WarehouseEmail@email.com' ,[CoType] = NULL ,[BarNo] = NULL ,[ZipCode] = 85043 ,[AreaCode] = NULL ,[AreaCode1] = NULL ,[AreaCode2] = NULL ,[After8hrsRegular] = 0 ,[After8hrsTime] = 1 ,[After8hrsDTime] = 0 ,[After10hrsRegular] = 0 ,[After10hrsTime] = 1 ,[After10hrsDTime] = 0 ,[After12hrsRegular] = 0 ,[After12hrsTime] = 0 ,[After12hrsDTime] = 1 ,[AfterhrsADay] = 40 ,[AfterhrsADayRegular] = 0 ,[AfterhrsADayTime] = 1 ,[AfterhrsADayDTime] = 0 ,[HolidayhrsRegular] = 0 ,[HolidayhrsTime] = 1 ,[HolidayhrsDTime] = 0 ,[PayWeekStartOn] = 1 ,[RoundPunchesTo] = 1 ,[PickupVehicleTime] = NULL ,[NoOfBays] = NULL ,[IsOverTime] = NULL ,[OverTimerHrs] = 0 ,[IsHolidayPaid] = NULL ,[IsMonday] = 1 ,[MondayTimeStart] = '08:00:00.0000000' ,[MondayTimeEnd] = '17:00:00.0000000' ,[MondayHrs] = 9 ,[IsTuesday] = 1 ,[TuesdayTimeStart] = '08:00:00.0000000' ,[TuesdayTimeEnd] = '17:00:00.0000000' ,[TuesdayHrs] = 9 ,[IsWednesday] = 1 ,[WednesdayTimeStart] = '08:00:00.0000000' ,[WednesdayTimeEnd] = '17:00:00.0000000' ,[WednesdayHrs] = 9 ,[IsThursday] = 1 ,[ThursdayTimeStart] = '08:00:00.0000000' ,[ThursdayTimeEnd] = '17:00:00.0000000' ,[ThursdayHrs] = 9 ,[IsFriday] = 1 ,[FridayTimeStart] = '08:00:00.0000000' ,[FridayTimeEnd] = '17:00:00.0000000' ,[FridayHrs] = 9 ,[IsSaturday] = 1 ,[SaturdayTimeStart] = '08:00:00.0000000' ,[SaturdayTimeEnd] = '16:00:00.0000000' ,[SaturdayHrs] = 8 ,[IsSunday] = 0 ,[SundayTimeStart] = NULL ,[SundayTimeEnd] = NULL ,[SundayHrs] = 0 ,[Active] = 1 ,[AddDate] = GETDATE() ,[AddUserID] = -2 ,[ModifyUserID] = NULL ,[ModifyDate] = NULL ,[Comments] = 'Default Warehouse' ,[IsLocked] = 1 ,[CompanyLogo] = NULL ,[Remarks] = 'Default Warehouse';
UPDATE [dbo].[WarehouseStore] SET [CompanyID] = 1 ,[WarehouseID] = 1 ,[CoCode] = '1010101' ,[CoName] = 'Your Warehouse Store Name' ,[CoAddress] = 'Your Warehouse Store Address' ,[CoPhone] = '1234567654' ,[CoFax] = '1234567654' ,[CoEmail] = 'WarehouseStoreEmail@email.com' ,[CoType] = NULL ,[BarNo] = NULL ,[ZipCode] = 85043 ,[AreaCode] = NULL ,[AreaCode1] = NULL ,[AreaCode2] = NULL,[After8hrsRegular] = 0 ,[After8hrsTime] = 1 ,[After8hrsDTime] = 0 ,[After10hrsRegular] = 0 ,[After10hrsTime] = 1 ,[After10hrsDTime] = 0 ,[After12hrsRegular] = 0 ,[After12hrsTime] = 0 ,[After12hrsDTime] = 1 ,[AfterhrsADay] = 40 ,[AfterhrsADayRegular] = 0 ,[AfterhrsADayTime] = 1 ,[AfterhrsADayDTime] = 0 ,[HolidayhrsRegular] = 0 ,[HolidayhrsTime] = 1 ,[HolidayhrsDTime] = 0 ,[PayWeekStartOn] = 1 ,[RoundPunchesTo] = 1 ,[PickupVehicleTime] = NULL ,[NoOfBays] = NULL ,[IsOverTime] = NULL ,[OverTimerHrs] = 0 ,[IsHolidayPaid] = NULL ,[IsMonday] = 1 ,[MondayTimeStart] = '08:00:00.0000000' ,[MondayTimeEnd] = '17:00:00.0000000' ,[MondayHrs] = 9 ,[IsTuesday] = 1 ,[TuesdayTimeStart] = '08:00:00.0000000' ,[TuesdayTimeEnd] = '17:00:00.0000000' ,[TuesdayHrs] = 9 ,[IsWednesday] = 1 ,[WednesdayTimeStart] = '08:00:00.0000000' ,[WednesdayTimeEnd] = '17:00:00.0000000' ,[WednesdayHrs] = 9 ,[IsThursday] = 1 ,[ThursdayTimeStart] = '08:00:00.0000000' ,[ThursdayTimeEnd] = '17:00:00.0000000' ,[ThursdayHrs] = 9 ,[IsFriday] = 1 ,[FridayTimeStart] = '08:00:00.0000000' ,[FridayTimeEnd] = '17:00:00.0000000' ,[FridayHrs] = 9 ,[IsSaturday] = 1 ,[SaturdayTimeStart] = '08:00:00.0000000' ,[SaturdayTimeEnd] = '16:00:00.0000000' ,[SaturdayHrs] = 8 ,[IsSunday] = 0 ,[SundayTimeStart] = NULL ,[SundayTimeEnd] = NULL ,[SundayHrs] = 0 ,[Active] = 1 ,[AddDate] = GETDATE() ,[AddUserID] = -2 ,[ModifyUserID] = NULL ,[ModifyDate] = NULL ,[Comments] = 'Default Warehouse Store' ,[IsLocked] = 1 ,[CompanyLogo] = NULL ,[Remarks] = 'Default Warehouse Store';
GO
--//----------------------------------------------------------//--
DELETE FROM [BankAccounts] DBCC CHECKIDENT (BankAccounts,RESEED,0);
DELETE FROM [WarehouseChores] DBCC CHECKIDENT (WarehouseChores,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [CustomerPayment] DBCC CHECKIDENT (CustomerPayment,RESEED,0);
DELETE FROM [CustomerPaymentAutoNo] DBCC CHECKIDENT (CustomerPaymentAutoNo,RESEED,0);
GO
DELETE FROM [WorkOrderNegateDetail] DBCC CHECKIDENT (WorkOrderNegateDetail,RESEED,0);
DELETE FROM [WorkOrderNegate] DBCC CHECKIDENT (WorkOrderNegate,RESEED,0); 
DELETE FROM [WorkOrderNegateAutoNo] DBCC CHECKIDENT (WorkOrderNegateAutoNo,RESEED,0);
GO
DELETE FROM [CustomerReceipt] DBCC CHECKIDENT (CustomerReceipt,RESEED,0);
DELETE FROM [CustomerReceiptAutoNo] DBCC CHECKIDENT (CustomerReceiptAutoNo,RESEED,0);
GO
DELETE FROM [WorkOrderDetail] DBCC CHECKIDENT (WorkOrderDetail,RESEED,0);
DELETE FROM [WorkOrder] DBCC CHECKIDENT (WorkOrder,RESEED,0);
DELETE FROM [WorkOrderAutoNo] DBCC CHECKIDENT (WorkOrderAutoNo,RESEED,0);
GO
DELETE FROM [VendorPayment] DBCC CHECKIDENT (VendorPayment,RESEED,0);
DELETE FROM [VendorPaymentAutoNo] DBCC CHECKIDENT (VendorPaymentAutoNo,RESEED,0);
DELETE FROM [VendorBillDetails] DBCC CHECKIDENT (VendorBillDetails,RESEED,0);
DELETE FROM [VendorBill] DBCC CHECKIDENT (VendorBill,RESEED,0);
DELETE FROM [VendorBillAutoNo] DBCC CHECKIDENT (VendorBillAutoNo,RESEED,0);
GO
DELETE FROM [PurchaseOrderDetails] DBCC CHECKIDENT (PurchaseOrderDetails,RESEED,0);
DELETE FROM [PurchaseOrder] DBCC CHECKIDENT (PurchaseOrder,RESEED,0);
DELETE FROM [PurchaseOrderAutoNo] DBCC CHECKIDENT (PurchaseOrderAutoNo,RESEED,0);
GO
DELETE FROM [ItemStock] DBCC CHECKIDENT (ItemStock,RESEED,0);
--DELETE FROM [Item] DBCC CHECKIDENT (Item,RESEED,0);
GO
--//-------------------Customer----------------------------//---
DELETE FROM [CustomerContacts] DBCC CHECKIDENT (CustomerContacts,RESEED,0);
DELETE FROM [CustomerShippingAddresses] DBCC CHECKIDENT (CustomerShippingAddresses,RESEED,0);
DELETE FROM [Customer] DBCC CHECKIDENT (Customer,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [UserLogin] where ID > 6 DBCC CHECKIDENT (UserLogin,RESEED,6);
GO
--//----------------------------------------------------------//--
--//---------------------Sales-------------------------------//--
DELETE FROM [WorkOrderDetail] DBCC CHECKIDENT (WorkOrderDetail,RESEED,0);
DELETE FROM [CustomerReceipt] DBCC CHECKIDENT (CustomerReceipt,RESEED,0);
DELETE FROM [WorkOrderNegateDetail] DBCC CHECKIDENT (WorkOrderNegateDetail,RESEED,0);
DELETE FROM [CustomerPayment] DBCC CHECKIDENT (CustomerPayment,RESEED,0);
DELETE FROM [WorkOrderNegate] DBCC CHECKIDENT (WorkOrderNegate,RESEED,0);
DELETE FROM [WorkOrder] DBCC CHECKIDENT (WorkOrder,RESEED,0);
DELETE FROM [WorkOrderNegateAutoNo] DBCC CHECKIDENT (WorkOrderNegateAutoNo,RESEED,0);
DELETE FROM [CustomerPaymentAutoNo] DBCC CHECKIDENT (CustomerPaymentAutoNo,RESEED,0);
DELETE FROM [CustomerReceiptAutoNo] DBCC CHECKIDENT (CustomerReceiptAutoNo,RESEED,0);
DELETE FROM [WorkOrderAutoNo] DBCC CHECKIDENT (WorkOrderAutoNo,RESEED,0);
DELETE FROM [SpiffsType] DBCC CHECKIDENT (SpiffsType,RESEED,0);
GO
--//------------PurchaseOrder--------------------------------//--
DELETE FROM [PurchaseOrderDetails] DBCC CHECKIDENT (PurchaseOrderDetails,RESEED,0);
DELETE FROM [PurchaseOrder] DBCC CHECKIDENT (PurchaseOrder,RESEED,0);
DELETE FROM [PurchaseOrderAutoNo] DBCC CHECKIDENT (PurchaseOrderAutoNo,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [VendorPayment] DBCC CHECKIDENT (VendorPayment,RESEED,0);
DELETE FROM [VendorPaymentAutoNo] DBCC CHECKIDENT (VendorPaymentAutoNo,RESEED,0);
DELETE FROM [WarrantyClaimToVendor] DBCC CHECKIDENT (WarrantyClaimToVendor,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [VendorBillDetails] DBCC CHECKIDENT (VendorBillDetails,RESEED,0);
DELETE FROM [VendorBillAccountDetails] DBCC CHECKIDENT (VendorBillAccountDetails,RESEED,0);
DELETE FROM [VendorBill] DBCC CHECKIDENT (VendorBill,RESEED,0);
DELETE FROM [VendorBillAutoNo] DBCC CHECKIDENT (VendorBillAutoNo,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [WarehouseDepartmentManager] DBCC CHECKIDENT (WarehouseDepartmentManager,RESEED,0);
DELETE FROM [EmployeePic] where ID > 0 DBCC CHECKIDENT (EmployeePic,RESEED,0);
DELETE FROM [EmployeeLeave] where ID > 0 DBCC CHECKIDENT (EmployeeLeave,RESEED,0);
DELETE FROM [EmployeeAttendance] where ID > 0 DBCC CHECKIDENT (EmployeeAttendance,RESEED,0);
DELETE FROM [Employee] where ID > 0 DBCC CHECKIDENT (Employee,RESEED,0);
GO
--//----------------------------------------------------------//--
Update [Item] set VendorID = NULL;
DELETE FROM [ItemVendors] DBCC CHECKIDENT (ItemVendors,RESEED,0);
DELETE FROM [Fees] where ID > 39 DBCC CHECKIDENT (Fees,RESEED,39);
DELETE FROM [Labor] where ID > 9 DBCC CHECKIDENT (Labor,RESEED,9);
GO
DELETE FROM [WarehousePackagesDetail] where MID > 23
declare @WPDMaxID int; set @WPDMaxID = (Select ISNULL(MAX(ID),1) FROM [WarehousePackagesDetail])
DBCC CHECKIDENT (WarehousePackagesDetail,RESEED,@WPDMaxID);
GO
DELETE FROM [WarehousePackages] where ID > 23
declare @WPMaxID int; set @WPMaxID = (Select ISNULL(MAX(ID),1) FROM [WarehousePackages])
DBCC CHECKIDENT (WarehousePackages,RESEED,@WPMaxID);
GO
DELETE FROM [LaborDepartment] where ID > 6 DBCC CHECKIDENT (LaborDepartment,RESEED,6);
GO
--//----------------------------------------------------------//--
DELETE FROM [VehicleInspectionDetail] DBCC CHECKIDENT (VehicleInspectionDetail,RESEED,0);
DELETE FROM [VehicleInspection] DBCC CHECKIDENT (VehicleInspection,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [VehicleSpecification] DBCC CHECKIDENT (VehicleSpecification,RESEED,0);
DELETE FROM [Vehicle] DBCC CHECKIDENT (Vehicle,RESEED,0);
DELETE FROM [Vendor] DBCC CHECKIDENT (Vendor,RESEED,0);
DELETE FROM [VendorContacts] DBCC CHECKIDENT (VendorContacts,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [ItemPriceHistory] DBCC CHECKIDENT (ItemPriceHistory,RESEED,0);
DELETE FROM [OPHistory] DBCC CHECKIDENT (OPHistory,RESEED,0);
DELETE FROM [ItemStock] DBCC CHECKIDENT (ItemStock,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [SaleTaxCategory] where ID > 3 DBCC CHECKIDENT (SaleTaxCategory,RESEED,3);
DELETE FROM [DailyCash] DBCC CHECKIDENT (DailyCash,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [GeneralJournal] DBCC CHECKIDENT (GeneralJournal,RESEED,0);
DELETE FROM [GeneralJournalDetail] DBCC CHECKIDENT (GeneralJournalDetail,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [AccTransaction] DBCC CHECKIDENT (AccTransaction,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [LogActivity] DBCC CHECKIDENT (LogActivity,RESEED,0);
DELETE FROM [LoginActivity] DBCC CHECKIDENT (LoginActivity,RESEED,0);
GO
--//----------------------------------------------------------//--
DELETE FROM [POSDetail] DBCC CHECKIDENT (POSDetail,RESEED,0);
DELETE FROM [UserLoginDetail] DBCC CHECKIDENT (UserLoginDetail,RESEED,0);
GO
--//----------------------------------------------------------//--
----------------UPDATE workorder partsprice and total ----------------------
--SELECT * INTO #TempWOD FROM (SELECT [MID],SUM(Total) PartsPrice,SUM(Total) Total  
--FROM [AutoVault].[dbo].[WorkOrderdetail] 
--group by [MID] having SUM(Total) > 0) tbl 

--UPDATE [AutoVault].[dbo].[WorkOrder] 
--SET [AutoVault].[dbo].[WorkOrder].PartsPrice = #TempWOD.PartsPrice, 
--[AutoVault].[dbo].[WorkOrder].Total = #TempWOD.Total
--FROM #TempWOD, [AutoVault].[dbo].[WorkOrder] 
--WHERE #TempWOD.MID = [AutoVault].[dbo].[WorkOrder].ID
--//----------------------------------------------------------//--
----------------UPDATE WorkorderNegate partsprice and total ----------------------
----drop table #TempWOND
--SELECT * INTO #TempWOND FROM (SELECT [MID],SUM(Total) PartsPrice,SUM(Total) Total  
--FROM [AutoVault].[dbo].[WorkOrderNegateDetail] 
--group by [MID]) tbl 

--UPDATE [AutoVault].[dbo].[WorkOrderNegate] 
--SET [AutoVault].[dbo].[WorkOrderNegate].PartsPrice = #TempWOND.PartsPrice, 
--[AutoVault].[dbo].[WorkOrderNegate].Total = #TempWOND.Total
--FROM #TempWOND, [AutoVault].[dbo].[WorkOrderNegate] 
--WHERE #TempWOND.MID = [AutoVault].[dbo].[WorkOrderNegate].ID

--//----------------------------------------------------------//--
----------------UPDATE ItemStock Qty----------------------
--SELECT * INTO #TempPOD FROM (SELECT ItemID, SUM(PrevRcvd) Rcvd from AutoVault.dbo.PurchaseOrderDetails group by ItemID) Rcvd
--SELECT * INTO #TempWOD FROM (SELECT ItemID, SUM(Qty) Sale from AutoVault.dbo.WorkOrderDetail group by ItemID) sale
--SELECT * INTO #TempWOND FROM (SELECT ItemID, SUM(Qty)*-1 Rtn from AutoVault.dbo.WorkOrderNegateDetail group by ItemID) Rtn

--SELECT * INTO #TempSTK FROM
--(SELECT pur.ItemID, isnull((Isnull(pur.Rcvd,0) - isnull(sale.Sale,0) + isnull(trn.Rtn,0)),0) qty
--FROM #TempPOD pur
--Left Join #TempWOD sale on pur.ItemID = sale.ItemID
--Left Join #TempWOND trn on pur.ItemID = trn.ItemID) stk

--UPDATE AutoVault.dbo.ItemStock set Qty = 0;

--UPDATE AutoVault.dbo.ItemStock 
--SET AutoVault.dbo.ItemStock.Qty = #TempSTK.qty
--FROM #TempSTK, AutoVault.dbo.ItemStock 
--WHERE #TempSTK.ItemID = AutoVault.dbo.ItemStock.ItemID
----////-----------------------------------------------------------
--SELECT * FROM [AutoVault].[dbo].[PurchaseOrder]
--SELECT * FROM [AutoVault].[dbo].[PurchaseOrderDetails]

--SELECT * FROM [AutoVault].[dbo].[VendorBill] 
--SELECT * FROM [AutoVault].[dbo].[VendorBillDetails]
--SELECT * FROM [AutoVault].[dbo].[VendorPayment] 

--SELECT * FROM [AutoVault].[dbo].[WorkOrder] 
--SELECT * FROM [AutoVault].[dbo].[WorkOrderDetail]
--SELECT * FROM [AutoVault].[dbo].[CustomerReceipt]

--SELECT * FROM [AutoVault].[dbo].[WorkOrderNegate] 
--SELECT * FROM [AutoVault].[dbo].[WorkOrderNegateDetail]
--SELECT * FROM [AutoVault].[dbo].[CustomerPayment]
----////-----------------------------------------------------------
--SELECT * FROM [AutoVault].[dbo].[PurchaseOrder]
--SELECT * FROM [AutoVault].[dbo].[PurchaseOrderDetails]

--SELECT * FROM [AutoVault].[dbo].[VendorBill] 
--SELECT * FROM [AutoVault].[dbo].[VendorBillDetails]
--SELECT * FROM [AutoVault].[dbo].[VendorPayment] 

--SELECT * FROM [AutoVault].[dbo].[WorkOrder] --Taxable,Tax,Total,Remarks
--SELECT * FROM [AutoVault].[dbo].[WorkOrderDetail] --SaleTaxRate,IsTax,Tax,MarginPer,MarginAmount 
--SELECT * FROM [AutoVault].[dbo].[CustomerReceipt]

--SELECT * FROM [AutoVault].[dbo].[Customer] where CreditLimits > 0
--SELECT * FROM [Tempab].[dbo].[Cust] where CreditLimit > 0

--SELECT * FROM [AutoVault].[dbo].[SaleCategory]

----[WorkOrder]
--SELECT * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet])
----[WorkOrderDetail]
--SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] = ''
----[CustomerReceipt]
--SELECT * FROM [TempAB].[dbo].[appliedto] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice])

--SELECT * FROM [AutoVault].[dbo].[WorkOrderNegate] 
--SELECT * FROM [AutoVault].[dbo].[WorkOrderNegateDetail]
--SELECT * FROM [AutoVault].[dbo].[CustomerPayment]

----[WorkOrderNegate]
--SELECT * FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet]))
----[WorkOrderNegateDetail]
--SELECT * FROM [TempAB].[dbo].[invoicedet] where [Amount] < 0 
--SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet]))) and Amount < 0
----[CustomerPayment]
--SELECT * FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet]))

--SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID = 34550
--SELECT * FROM [TempAB].dbo.invoicedet where [Catalog] = '' and ItemType = 'Comment'
--SELECT * FROM [TempAB].dbo.invoicedet where [Catalog] = '' and description like 'Invoice%'


--SELECT * FROM TempAB.dbo.appliedto where InvID = 34550 --Invnum = 6340 ---3000.0000
--SELECT SUM(Applied) from TempAB.dbo.appliedto where InvID = 34550

--////----------------------------------------------//----------------
--SELECT name FROM sys.tables   --AutoVault --106
--SELECT name FROM sys.tables   --TempAB --155

----////----------------------------------------------------------  
--DELETE FROM [dbo].[Customer] where ID >= 1000000000;
--select MAX(ID) FROM [dbo].[Customer]  
--DBCC checkident(Customer,reseed,431);

--update [dbo].[PurchaseOrder] set VendorID = 100 where VendorID = 1000000;
--update [dbo].[VendorBill] set VendorID = 100 where VendorID = 1000000;
--DELETE [dbo].[Vendor] where ID > 1000000;
--select MAX(ID) FROM [dbo].[Vendor]  
--DBCC checkident(Vendor,reseed,258);
--update dbo.VendorBill set Balance = BillTotalAmount - PaidAmount;

--SELECT name FROM sys.tables order by name 

--other then that --insert into
--dbo.Account
--dbo.CreditCards
--dbo.Fees
--dbo.Item
--dbo.ItemGroup
--dbo.ItemGroupType
--dbo.ItemManufacturer
--dbo.ItemPriceLevel
--dbo.ItemType
--dbo.Labor
--dbo.LaborDepartment
--dbo.SaleCategory
--dbo.ShipVia
--dbo.Terms
--dbo.OilViscosities
--dbo.ReferredBy
--dbo.TireSize


--//-----------------//--
--dbo.VehicleColor
--dbo.VehicleYear
--dbo.VehicleMake
--dbo.VehicleModel
--dbo.VehicleSubModel
--dbo.VehicleTransmission

--dbo.CutOffDay
--dbo.DiscountDayOfThe
--dbo.DiscountMonth
--dbo.DiscountTypes

--dbo.EmployeeComBaseOn
--dbo.InspectionHeads
--dbo.ItemType
--dbo.PaymentMode
--dbo.PayWeekStartOn
--dbo.RoundingMethod
--dbo.SaleTaxAuthority
--dbo.SaleTaxRates
--dbo.ShippingMethods
--dbo.ShipVia
--dbo.UserGroups
--dbo.ZipCode
--//-----------------//--
--ALTER TABLE [dbo].[Item] ADD [WebWheelBoltCircle] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelBoltCircle2] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelOffset] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelDiameter2] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelWidth] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelCenterBore] varchar(50) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebWheelFinish] varchar(150) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebCategories] varchar(150) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebBlurb] varchar(150) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebDimensionH] decimal(18,0) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebDimensionW] decimal(18,0) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebDimensionL] decimal(18,0) NULL;
--ALTER TABLE [dbo].[Item] ADD [WebItemsPerPackage] decimal(18,0) NULL;
--ALTER TABLE [dbo].[Item] ADD [MainImage] image NULL;

--ALTER TABLE [dbo].[Customer] ADD [WebLoginName] varchar(150) NULL;
--ALTER TABLE [dbo].[Customer] ADD [WebPassword] varchar(150) NULL; 
--ALTER TABLE [dbo].[Customer] ADD [WebPriceLevelID] int NULL;
--ALTER TABLE [dbo].[Customer] ADD [Balance]	decimal(18, 2) NULL;

--ALTER TABLE [dbo].[Warehouse] ADD [SaleTaxCategoryID] int NULL;
--ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_SaleTaxCategory] FOREIGN KEY([SaleTaxCategoryID])
--REFERENCES [dbo].[SaleTaxCategory] ([ID])
--GO	
--ALTER TABLE [dbo].[WarehouseStore] ADD [SaleTaxCategoryID] int NULL;
--ALTER TABLE [dbo].[WarehouseStore]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseStore_SaleTaxCategory] FOREIGN KEY([SaleTaxCategoryID])
--REFERENCES [dbo].[SaleTaxCategory] ([ID])
--GO
--ALTER TABLE [dbo].[Employee] ADD [IsLoginForWarehouse] bit NULL;
--ALTER TABLE [dbo].[Employee] ADD [LoginWarehouseID] int NULL;
--ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_Warehouse1] FOREIGN KEY([LoginWarehouseID])
--REFERENCES [dbo].[Warehouse] ([ID])
--GO
--ALTER TABLE [dbo].[Employee] ADD [IsLoginForStore] bit NULL;
--ALTER TABLE [dbo].[Employee] ADD [LoginStoreID] int NULL;
--ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_WarehouseStore1] FOREIGN KEY([LoginStoreID])
--REFERENCES [dbo].[WarehouseStore] ([ID])
--GO

--//-----------------//--