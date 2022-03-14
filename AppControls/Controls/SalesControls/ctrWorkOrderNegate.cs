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
    public partial class ctrWorkOrderNegate : BaseControl
    {
        int WorkOrderID = 0;
        int WorkOrderNegateID = 0;
        int CustID = 1;
        int VehicleID = 0;
        int ctrMode = 0;
        string CustomerPriceLevel;
        bool single = false;
        public ctrWorkOrderNegate()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        //public ctrWorkOrderNegate(int ctrMode)
        //{
        //    InitializeComponent();
        //    InitializeComponent1();
        //    this.ctrMode = ctrMode;
        //}
        //public ctrWorkOrderNegate(int ctrMode, int SelectedCustID)
        //{
        //    InitializeComponent();
        //    InitializeComponent1();
        //    this.ctrMode = ctrMode;
        //    this.CustID = SelectedCustID;
        //}
        public ctrWorkOrderNegate(int WONegateID)
        {
            InitializeComponent();
            InitializeComponent1();

            this.ctrMode = 1;
            this.WorkOrderNegateID = WONegateID;
        }
        public ctrWorkOrderNegate(int CustomerID, int WONegateID)
        {
            InitializeComponent();
            InitializeComponent1();

            this.ctrMode = 1;
            this.CustID = CustomerID;
            this.WorkOrderNegateID = WONegateID;
        }
        public ctrWorkOrderNegate(int ctrMode, int WOID, int WONegateID)
        {
            InitializeComponent();
            InitializeComponent1();

            this.ctrMode = ctrMode;
            this.WorkOrderID = WOID;
            this.WorkOrderNegateID = WONegateID;
        }
        void InitializeComponent1()
        {
            this.Load += ctrWorkOrderNegate_Load;

            this.DGVWorkOrderNegate.CellClick += new DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGVWorkOrderNegate.CellEndEdit += DGVWorkOrderNegate_CellEndEdit;
            this.DGVWorkOrderNegate.CellFormatting += DGVWorkOrderNegate_CellFormatting;

            this.ctrPartDisPer.ValueChanged += ctrPartDisPer_ValueChanged;
            this.ctrLaborDisPer.ValueChanged += ctrLaborDisPer_ValueChanged;

            this.ctrSaleCategoryID.SelectionChangeCommitted += new System.EventHandler(this.ctrSaleCategoryID_SelectionChangeCommitted);
            this.ctrPriceLevelID.SelectionChangeCommitted += new System.EventHandler(this.ctrPriceLevelID_SelectionChangeCommitted);
            this.ctrSaleTaxRateID.SelectionChangeCommitted += ctrSaleTaxRateID_SelectionChangeCommitted;
            this.ctrSaleRepID.SelectionChangeCommitted += ctrSaleRepID_SelectionChangeCommitted;
            this.ctrMechID.SelectionChangeCommitted += ctrMechID_SelectionChangeCommitted;

            this.btnProfitMargin.Click += btnProfitMargin_Click;
            this.btnToggleColumns.Click += btnToggleColumns_Click;
            this.btnAddCatalog.Click += btnAddCatalog_Click;
            this.btnAddCommetns.Click += btnAddComments_Click;

            btnCustomerInvoice.Click += btnCustomerInvoice_Click;
        }
        void ShowCost()
        {
            bool CostShow = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '004'");
            if (row[0]["CanView"] != DBNull.Value)
                CostShow = Convert.ToBoolean(row[0]["CanView"]);
            if (CostShow)
                DGVWorkOrderNegate.Columns["Cost"].Visible = true;
            else
                DGVWorkOrderNegate.Columns["Cost"].Visible = false;
        }
        void btnCustomerInvoice_Click(object sender, EventArgs e)
        {
            AddDescription();
            InverseNumbers();
            this.frmStatus = currentStatus.Load;
            this.objBindingSource.EndEdit();

            if (base.bindingNavigatorSaveItemClick(sender, e))
            {
                //bool status = UpdateVoucherMaster();
                //if (status == true)
                //{
                //    UpdateVoucherDetails();
                //}
                this.BaseEnableDisble(this.frmStatus);

                dbClass.obj.UpdateWorkOrderIsNegated(this.WorkOrderID);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (curRow["ID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(curRow["ID"]) >= 1)
                    {
                        ctrCustomerPayment objList = new ctrCustomerPayment(Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        this.ParentForm.Close();
                        //this.Parent.Parent.Parent.Dispose();
                        frmCtr frmCtr = new frmCtr("Customer Payment ...");
                        frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(objList);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                    }
                }
            }
        }

        void DGVWorkOrderNegate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangePackageHeader();
        }
        void btnAddCatalog_Click(object sender, EventArgs e)
        {
            LoadCatalog_CellClick();
        }
        void btnOutsidePart_Click(object sender, EventArgs e)
        {
            AddOutsidePartInGrid_ObjectSelected(sender, "OP");
        }
        void btnShopLabor_Click(object sender, EventArgs e)
        {
            AddShopLaborInGrid_ObjectSelected(sender, "SL");
        }
        void btnToggleColumns_Click(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                ctrToggleWOColumns ctrToggleWOColumns = new ctrToggleWOColumns();
                //----------------------------------------------------------------------//
                frmCtr frmCtr = new frmCtr("Toggle Work Order Columns ...");
                frmCtr.Height = ctrToggleWOColumns.Height + 20; frmCtr.Width = ctrToggleWOColumns.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(ctrToggleWOColumns);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();

                setWOToggleColumns();
            }
        }
        void btnProfitMargin_Click(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RowHeader", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("FET", typeof(decimal));
                dt.Columns.Add("Cost", typeof(decimal));
                dt.Columns.Add("Profit", typeof(decimal));
                dt.Columns.Add("Margin", typeof(decimal));
                dt.Columns.Add("Markup", typeof(decimal));

                decimal Price = 0, FET = 0, TPrice = 0, Cost = 0, Profit = 0, Margin = 0, Markup = 0;
                string rowHeader = "";

                DataTable dtiTypes = new DataTable();
                dtiTypes = dbClass.obj.getItemTypes();

                foreach (DataRow dr in dtiTypes.Rows)
                {
                    string cInitial = Convert.ToString(dr["Initial"]);
                    string cName = Convert.ToString(dr["Name"]);

                    foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                    {
                        if (n.Cells["CType"].Value != null)
                        {
                            if (Convert.ToString(n.Cells["CType"].Value) == cInitial)
                            {
                                rowHeader = cName;
                                if (n.Cells["Amount"].Value != null) { Price += Convert.ToDecimal(n.Cells["Amount"].Value); }
                                if (n.Cells["FET"].Value != null) { FET += Convert.ToDecimal(n.Cells["FET"].Value); }
                                TPrice += Price + FET;

                                if (n.Cells["Cost"].Value != null) { Cost += (Convert.ToDecimal(n.Cells["Cost"].Value) * Convert.ToDecimal(n.Cells["Qty"].Value)); }
                                Profit += (Price - Cost);
                                if (TPrice > 0)
                                    Margin += ((TPrice - Cost) / TPrice) * 100;
                                if (Cost > 0)
                                    Markup += ((TPrice - Cost) / Cost) * 100;
                            }
                        }
                    }
                    //----------------------------//
                    if (Price > 0)
                    {
                        DataRow dtnRow = dt.NewRow();
                        dtnRow["RowHeader"] = cName;
                        dtnRow["Price"] = Math.Round(Price, 2);
                        dtnRow["FET"] = Math.Round(FET);
                        dtnRow["Cost"] = Math.Round(Cost);
                        dtnRow["Profit"] = Math.Round(Profit);
                        dtnRow["Margin"] = Math.Round(Margin);
                        dtnRow["Markup"] = Math.Round(Markup);
                        dt.Rows.Add(dtnRow);
                    }
                    //----------------------------//
                }
                if (dt.Rows.Count > 0)
                {
                    ctrProfitBreakDown ctrProfitBreakDown = new ctrProfitBreakDown(dt);
                    //----------------------------------------------------------------------//
                    frmCtr frmCtr = new frmCtr("Profit Break Down ...");
                    frmCtr.Height = ctrProfitBreakDown.Height + 20; frmCtr.Width = ctrProfitBreakDown.Width + 20;
                    frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmCtr.frmPnl.Controls.Add(ctrProfitBreakDown);
                    frmCtr.BringToFront();
                    frmCtr.ShowDialog();
                }

            }
        }
        void ctrMechID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                DataRowView drv = (DataRowView)ctrMechID.SelectedItem;
                int MechID = Convert.ToInt32(drv["ID"]);
                string Initial = Convert.ToString(drv["Initial"]);
                //----------------------------------------------
                setGridMech(MechID, Initial);
                //----------------------------------------------                
            }
        }
        void ctrSaleRepID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                DataRowView drv = (DataRowView)ctrSaleRepID.SelectedItem;
                int saleRepID = Convert.ToInt32(drv["ID"]);
                string Initial = Convert.ToString(drv["Initial"]);
                //----------------------------------------------
                setGridSaleRep(saleRepID, Initial);
                //----------------------------------------------                
            }
        }
        void ctrSaleCategoryID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                DataRowView drv = (DataRowView)ctrSaleCategoryID.SelectedItem;
                int itemPriceLevelID = Convert.ToInt32(drv["ItemPriceLevelID"]);
                int saleCategoryID = Convert.ToInt32(drv["ID"]);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["SaleCategoryID"] = saleCategoryID;
                curRow["PriceLevelID"] = itemPriceLevelID;
                curRow.EndEdit();
                //----------------------------------------------
                ctrPriceLevelID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrPriceLevelID.xTableName].Copy(), Convert.ToInt32(drv["ItemPriceLevelID"]));
                ctrPriceLevelID_SelectionChangeCommitted(sender, e);
            }
        }
        void ctrPriceLevelID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                DataRowView drv = (DataRowView)ctrPriceLevelID.SelectedItem;
                int itemPriceLevelID = Convert.ToInt32(drv["ID"]);
                string priceLevel = Convert.ToString(drv["Name"]);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["PriceLevelID"] = itemPriceLevelID;
                curRow.EndEdit();
                //----------------------------------------------
                ctrPriceLevelID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrPriceLevelID.xTableName].Copy(), Convert.ToInt32(drv["ID"]));
                //----------------------------------------------
                setGridPrice(priceLevel);
                //----------------------------------------------                
            }
        }
        void ctrSaleTaxRateID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                DataRowView drv = (DataRowView)ctrSaleTaxRateID.SelectedItem;
                int saleTaxRateID = Convert.ToInt32(drv["ID"]);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["SaleTaxRateID"] = saleTaxRateID;
                curRow.EndEdit();
                //----------------------------------------------
                setGridTaxRate(saleTaxRateID);
            }
        }
        void ctrWorkOrderNegate_Load(object sender, EventArgs e)
        {
            bool AccessSales = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '008'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessSales = Convert.ToBoolean(row[0]["CanView"]);
            if (!AccessSales)
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Sales.");               
                this.BeginInvoke(new MethodInvoker(this.ParentForm.Close));
            }

            if ((this.WorkOrderNegateID > 0) && (this.ctrMode < 0))
            {
                this.single = true;
                //this.objBindingSource.AddNew();
                bindingNavigatorAddNewItem_Click(sender, e);
            }
            else if (this.WorkOrderNegateID > 0)
            {
                btnCustomerInvoice.Enabled = false;
                btnPrintInvoice.Enabled = false;
                this.single = true;
                dbClass.obj.fillTablesByIDOrderBy(objDataSet.Tables[this.xTableName], objDataSet.Tables[this.DGVWorkOrderNegate.xTableName], this.DGVWorkOrderNegate.xTableQuery, this.WorkOrderNegateID, this.DGVWorkOrderNegate.xOrderBy);

                //int index = objBindingSource.Find("ID", this.WorkOrderID);
                //this.objBindingSource.Position = index;

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (curRow != null)
                {
                    if (curRow["CustomerID"] != DBNull.Value)
                        this.SetCustomer(Convert.ToInt32(curRow["CustomerID"]));
                    if (curRow["VehicleID"] != DBNull.Value)
                        this.SetVehicle(Convert.ToInt32(curRow["VehicleID"]));
                }
            }
            else
            {
                bindingNavigatorAddNewItem_Click(sender, e);
            }

            //----------------------------------------------------------//
            TSMItem1.Visible = true;
            TSMItem1.Text = "Save without Printing";

            TSMItem2.Visible = true;
            TSMItem2.Text = "Save and Printing";

            TSMItem3.Visible = true;
            TSMItem3.Text = "Save and Invoice";

            //TSMItem4.Visible = true;
            //TSMItem4.Text = "Deposit";
            //----------------------------------------------------------//
            setWOToggleColumns();
            btnBNProcess.Enabled = true;
            //----------------------------------------------------------//

        }
        protected override void DataNavigation()
        {
            base.DataNavigation();

            try
            {
                if (this.ctrMode <= 0)
                {
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    if (curRow["CustomerID"] != DBNull.Value)
                    {
                        DataRow CustomerRow = dbClass.obj.FillDataRowByID(objDataSet.Tables["Customer"].Copy(), Convert.ToInt32(curRow["CustomerID"]));
                        AddCustomerDetail_ObjectSelected(null, CustomerRow);
                    }
                }
            }
            catch { }
        }

        void SetCustomer(int CustID)
        {
            DataRow CustomerRow = dbClass.obj.getCustomerByID(CustID);
            if (CustomerRow != null)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["CustomerID"] = CustomerRow["ID"];
                this.CustID = Convert.ToInt32(CustomerRow["ID"]);

                CustomerPriceLevel = dbClass.obj.getPriceLevelbyID(Convert.ToInt32(CustomerRow["PriceLevelID"]));
                if (CustomerRow["IsCustomer"] != DBNull.Value) { ctrIsCustomer.Checked = Convert.ToBoolean(CustomerRow["IsCustomer"]); }
                if (CustomerRow["IsCompany"] != DBNull.Value) { ctrIsCompany.Checked = Convert.ToBoolean(CustomerRow["IsCompany"]); }

                if (CustomerRow["FirstName"] != DBNull.Value) { ctrFirstName.Text = Convert.ToString(CustomerRow["FirstName"]); } else { ctrFirstName.Text = string.Empty; }
                if (CustomerRow["LastName"] != DBNull.Value) { ctrLastName.Text = Convert.ToString(CustomerRow["LastName"]); } else { ctrLastName.Text = string.Empty; }
                if (CustomerRow["Address"] != DBNull.Value) { ctrAddress.Text = Convert.ToString(CustomerRow["Address"]); } else { ctrAddress.Text = string.Empty; }
                if (CustomerRow["Email"] != DBNull.Value) { ctrEmailAdd.Text = Convert.ToString(CustomerRow["Email"]); } else { ctrEmailAdd.Text = string.Empty; }

                if (CustomerRow["Phone1"] != DBNull.Value) { ctrPhone1.Text = Convert.ToString(CustomerRow["Phone1"]); } else { ctrPhone1.Text = string.Empty; }
                if (CustomerRow["Phone2"] != DBNull.Value) { ctrPhone2.Text = Convert.ToString(CustomerRow["Phone2"]); } else { ctrPhone2.Text = string.Empty; }
                if (CustomerRow["Phone3"] != DBNull.Value) { ctrPhone3.Text = Convert.ToString(CustomerRow["Phone3"]); } else { ctrPhone3.Text = string.Empty; }
                if (CustomerRow["Phone4"] != DBNull.Value) { ctrPhone4.Text = Convert.ToString(CustomerRow["Phone4"]); } else { ctrPhone4.Text = string.Empty; }
                //if (CustomerRow["StateID"] != DBNull.Value)
                //{
                //    if (Convert.ToInt32(CustomerRow["StateID"]) > 0)
                //        ctrCustomerStateID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrCustomerStateID.xTableName].Copy(), Convert.ToInt32(CustomerRow["StateID"]));
                //}
                //if (CustomerRow["CityID"] != DBNull.Value)
                //{
                //    if (Convert.ToInt32(CustomerRow["CityID"]) > 0)
                //        ctrCustomerCityID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrCustomerCityID.xTableName].Copy(), Convert.ToInt32(CustomerRow["CityID"]));
                //}
                if (CustomerRow["ZipCode"] != DBNull.Value) { ctrZipCode.Text = Convert.ToString(CustomerRow["ZipCode"]); } else { ctrZipCode.Text = string.Empty; }

                curRow["PartDisPer"] = CustomerRow["PartDisPer"];
                curRow["LaborDisPer"] = CustomerRow["LaborDisPer"];


                curRow["ReferredByID"] = CustomerRow["ReferredByID"];
                if (CustomerRow["ReferredByID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["ReferredByID"]) > 0)
                        ctrReferredByID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrReferredByID.xTableName].Copy(), Convert.ToInt32(CustomerRow["ReferredByID"]));
                }
                curRow["SaleCategoryID"] = CustomerRow["SaleCategoryID"];
                if (CustomerRow["SaleCategoryID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["SaleCategoryID"]) > 0)
                        ctrSaleCategoryID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrSaleCategoryID.xTableName].Copy(), Convert.ToInt32(CustomerRow["SaleCategoryID"]));
                }
                curRow["PriceLevelID"] = CustomerRow["PriceLevelID"];
                if (CustomerRow["PriceLevelID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["PriceLevelID"]) > 0)
                        ctrPriceLevelID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrPriceLevelID.xTableName].Copy(), Convert.ToInt32(CustomerRow["PriceLevelID"]));
                }
                curRow["SaleTaxRateID"] = CustomerRow["SaleTaxRateID"];
                if (CustomerRow["SaleTaxRateID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["SaleTaxRateID"]) > 0)
                        ctrSaleTaxRateID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrSaleTaxRateID.xTableName].Copy(), Convert.ToInt32(CustomerRow["SaleTaxRateID"]));
                }
                curRow["SaleTermID"] = CustomerRow["SaleTermID"];
                if (CustomerRow["SaleTermID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["SaleTermID"]) > 0)
                        ctrSaleTermID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrSaleTermID.xTableName].Copy(), Convert.ToInt32(CustomerRow["SaleTermID"]));
                }
                curRow["ShipViaID"] = CustomerRow["ShipViaID"];
                if (CustomerRow["ShipViaID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(CustomerRow["ShipViaID"]) > 0)
                        ctrShipViaID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrShipViaID.xTableName].Copy(), Convert.ToInt32(CustomerRow["ShipViaID"]));
                }
                if (CustomerRow["CreditLimits"] != DBNull.Value)
                {
                    if (Convert.ToDecimal(CustomerRow["CreditLimits"]) > 0)
                    {
                        decimal CreditAvail = dbClass.obj.getCreditAvailbyCustomerID(this.CustID);
                        if (Convert.ToDecimal(CustomerRow["CreditLimits"]) > 0)
                        {
                            decimal AvailableCredit = Convert.ToDecimal(CustomerRow["CreditLimits"]) - CreditAvail;
                            lblCreditAvailable.Text = "Available Credit: " + StaticInfo.MainCurSign + Convert.ToString(AvailableCredit);
                            lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                        }
                        else
                        {
                            lblCreditAvailable.Text = "Available Credit: None";
                            lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                        }
                    }
                    else
                    {
                        lblCreditAvailable.Text = "Credit Avail: None";
                        lblCreditLimit.Text = "Credit Limit: " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                    }
                }
                else 
                {
                    lblCreditAvailable.Text = "Credit Avail: None";
                    lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                }
                    //lblIsCreditAvailable.Text = "Credit Avail: None";

                curRow.EndEdit();
            }
        }
        void SetVehicle(int VehicleID)
        {

            DataRow VehicleRow = dbClass.obj.FillVehicleID(VehicleID);
            if (VehicleRow != null)
            {
                AddVehicleDetail_ObjectSelected(null, VehicleRow);
            }
            else
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["VehicleID"] = DBNull.Value;
                curRow["IsNoVehicle"] = true;
                this.VehicleID = 0;
                ctrLicensePlate.Text = "";


                ctrVehicleState.DataSource = null;
                ctrVehicleYearMakeModel.Text = "";
                ctrVIN.Text = "";
                ctrLastMileage.Text = "0";

                curRow.EndEdit();
            }

        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            if (single == true)
            {
                DataRow WorkOrder = dbClass.obj.getWorkOrderByID(this.WorkOrderID);
                if (WorkOrder["CustomerID"] != DBNull.Value)
                    this.SetCustomer(Convert.ToInt32(WorkOrder["CustomerID"]));
                if (WorkOrder["VehicleID"] != DBNull.Value)
                    this.SetVehicle(Convert.ToInt32(WorkOrder["VehicleID"]));

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();

                if (StaticInfo.userid > 6)
                { curRow["CreatedByID"] = StaticInfo.userid; curRow["SaleRepID"] = StaticInfo.userid; }
                else
                { curRow["CreatedByID"] = DBNull.Value; curRow["SaleRepID"] = DBNull.Value; }

                curRow["WorkOrderID"] = this.WorkOrderID;
                curRow["RegDate"] = DateTime.Now;
                curRow["WorkOrderNegateNo"] = WorkOrderNegateID;
                curRow["Notes"] = "Negate WorkOrder # " + WorkOrder["WorkOrderNo"];

                curRow["IsQutation"] = false;
                curRow["IsWorkOrderNegate"] = true;
                curRow["IsCustomerOrder"] = false;

                curRow["Mileage"] = WorkOrder["Mileage"];
                curRow["MileageOut"] = WorkOrder["MileageOut"];
                curRow["PONo"] = "WorkOrder #" + WorkOrder["WorkOrderNo"];
                curRow["SaleRepID"] = WorkOrder["SaleRepID"];
                curRow["MechID"] = WorkOrder["MechID"];

                curRow["ReferredByID"] = WorkOrder["ReferredByID"];
                curRow["SaleCategoryID"] = WorkOrder["SaleCategoryID"];
                curRow["PriceLevelID"] = WorkOrder["PriceLevelID"];
                curRow["SaleTaxRateID"] = WorkOrder["SaleTaxRateID"];
                curRow["SaleTermID"] = WorkOrder["SaleTermID"];
                curRow["ShipViaID"] = WorkOrder["ShipViaID"];
                curRow["WarehouseBayID"] = WorkOrder["WarehouseBayID"];
                curRow["CreatedByID"] = WorkOrder["CreatedByID"];

                //curRow["PartsPrice"] = WorkOrder["PartsPrice"];
                //curRow["LaborPrice"] = WorkOrder["LaborPrice"];
                //curRow["OtherPrice"] = WorkOrder["OtherPrice"];
                //curRow["FET"] = WorkOrder["FET"];
                //curRow["Taxable"] = WorkOrder["Taxable"];
                //curRow["Tax"] = WorkOrder["Tax"];
                //curRow["Discount"] = WorkOrder["Discount"];
                //curRow["PartDisPer"] = WorkOrder["PartDisPer"];
                //curRow["LaborDisPer"] = WorkOrder["LaborDisPer"];
                //curRow["Total"] = WorkOrder["Total"];

                if (WorkOrder["PartsPrice"] != DBNull.Value)
                    curRow["PartsPrice"] = Convert.ToDecimal(WorkOrder["PartsPrice"]) * -1;

                if (WorkOrder["LaborPrice"] != DBNull.Value)
                    curRow["LaborPrice"] = Convert.ToDecimal(WorkOrder["LaborPrice"]) * -1;
                if (WorkOrder["OtherPrice"] != DBNull.Value)
                    curRow["OtherPrice"] = Convert.ToDecimal(WorkOrder["OtherPrice"]) * -1;
                if (WorkOrder["FET"] != DBNull.Value)
                    curRow["FET"] = Convert.ToDecimal(WorkOrder["FET"]) * -1;
                if (WorkOrder["Taxable"] != DBNull.Value)
                    curRow["Taxable"] = Convert.ToDecimal(WorkOrder["Taxable"]) * -1;
                if (WorkOrder["Tax"] != DBNull.Value)
                    curRow["Tax"] = Convert.ToDecimal(WorkOrder["Tax"]) * -1;
                if (WorkOrder["Discount"] != DBNull.Value)
                    curRow["Discount"] = Convert.ToDecimal(WorkOrder["Discount"]) * -1;
                if (WorkOrder["PartDisPer"] != DBNull.Value)
                    curRow["PartDisPer"] = Convert.ToDecimal(WorkOrder["PartDisPer"]) * -1;
                if (WorkOrder["LaborDisPer"] != DBNull.Value)
                    curRow["LaborDisPer"] = Convert.ToDecimal(WorkOrder["LaborDisPer"]) * -1;
                if (WorkOrder["Total"] != DBNull.Value)
                    curRow["Total"] = Convert.ToDecimal(WorkOrder["Total"]) * -1;

                curRow["Status"] = DBNull.Value;

                curRow["Active"] = true;
                curRow["AddDate"] = DateTime.Now;
                curRow["AddUserID"] = StaticInfo.userid;

                curRow["Comments"] = "WorkOrder # " + WorkOrder["WorkOrderNo"];
                curRow["IsLocked"] = true;

                curRow["CompanyID"] = WorkOrder["CompanyID"];
                curRow["WarehouseID"] = WorkOrder["WarehouseID"];
                curRow["StoreID"] = WorkOrder["StoreID"];

                curRow["Status"] = "None";

                curRow.EndEdit();
                //--------------------------------------------------------------------//
                fillWorkOrderNegateDetail();
            }
            else
            {
                int NextAutoNo = dbClass.obj.getNextWorkOrderNegateAutoNo();
                if (this.ctrMode < 0)
                {
                    this.ctrMode = 0;
                    //this.CustID = 1;
                    this.WorkOrderID = 0;
                }
                this.SetCustomer(this.CustID);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["WorkOrderNegateNo"] = NextAutoNo;

                curRow["PONo"] = "NEGATE";
                curRow["RegDate"] = DateTime.Now;

                curRow["CreatedByID"] = StaticInfo.userid;
                curRow["SaleRepID"] = StaticInfo.userid;

                curRow["IsQutation"] = false;
                curRow["IsWorkOrderNegate"] = true;
                curRow["IsCustomerOrder"] = false;

                //if ((this.ctrMode == 0) || (this.ctrMode == 1) || (this.ctrMode == 3))
                //    curRow["IsWorkOrderNegate"] = true;
                //else if ((this.ctrMode == 2) || (this.ctrMode == 4))
                //    curRow["IsQutation"] = true;

                curRow["Status"] = "None";

                curRow.EndEdit();
            }
            //--------------------------------------------------------------------//
            base.DataNavigation();
            //------------------------------------
            btnCustomerInvoice.Enabled = true;
            btnPrintInvoice.Enabled = true;
            ShowCost();
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            btnCustomerInvoice.Enabled = false;
            btnPrintInvoice.Enabled = false;
            base.bindingNavigatorCancelItem_Click(sender, e);
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e) 
        {
            base.bindingNavigatorEditItem_Click(sender, e);
            InverseNumbers();
            btnCustomerInvoice.Enabled = true;
            btnPrintInvoice.Enabled = true;

            bool ChangeCustomer = false;
            bool ChangeSalesCat = false;

            DataRow[] row = StaticInfo.UserRights.Select("Code = '002'");
            if (row[0]["CanView"] != DBNull.Value)
                ChangeCustomer = Convert.ToBoolean(row[0]["CanView"]);

            DataRow[] row2 = StaticInfo.UserRights.Select("Code = '003'");
            if (row2[0]["CanView"] != DBNull.Value)
                ChangeSalesCat = Convert.ToBoolean(row2[0]["CanView"]);

            if (ChangeCustomer)
            {
                btnChangeCust.Enabled = true;
                btnNewCust.Enabled = true;
            }
            else
            {
                btnChangeCust.Enabled = false;
                btnNewCust.Enabled = false;
            }
            if (ChangeSalesCat)
                ctrSaleCategoryID.Enabled = true;
            else
                ctrSaleCategoryID.Enabled = false;
            ShowCost();
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AddDescription();
            InverseNumbers();
            if (base.bindingNavigatorSaveItemClick(sender, e))
            {
                this.BaseEnableDisble(this.frmStatus);
                dbClass.obj.UpdateWorkOrderIsNegated(this.WorkOrderID);
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (curRow["ID"] != DBNull.Value)
                {
                    if (Convert.ToInt32(curRow["ID"]) >= 1)
                    {
                        ctrCustomerPayment objList = new ctrCustomerPayment(Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        this.ParentForm.Close();
                        //this.Parent.Parent.Parent.Dispose();
                        frmCtr frmCtr = new frmCtr("Customer Payment ...");
                        frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(objList);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                    }
                }
            }
        }
        void AddDescription() 
        {
            List<DataRow> CommentsRemove = new List<DataRow>();
            DataRowView curRowDetail = (DataRowView)DGVWorkOrderNegate.objBindingSource.Current;
            DataRow previousRow = (DataRow)curRowDetail.DataView.Table.Rows[0];
            foreach (DataRow row in curRowDetail.DataView.Table.Rows)
            {
                if (row["Catalog"] == DBNull.Value && row["Qty"] == DBNull.Value)
                {
                    if (previousRow["Qty"] != DBNull.Value)
                    {
                        previousRow["Comments"] = row["Name"];
                        CommentsRemove.Add(row);
                        //CommentsRemove.Add(Convert.ToInt32(row["rowID"]));

                    }
                    else
                        CommentsRemove.Add(row);
                }
                previousRow = row;
            }
            foreach (DataRow obj in CommentsRemove)
            {
                curRowDetail.DataView.Table.Rows.Remove(obj);
            }
        }
        void InverseNumbers() 
        {
            DataRowView curRowDetail = (DataRowView)DGVWorkOrderNegate.objBindingSource.Current;
            foreach (DataRow row in curRowDetail.DataView.Table.Rows)
            {
                if (row["Qty"] != DBNull.Value)
                {
                    if (row["Qty"] != DBNull.Value)
                        row["Qty"] = Convert.ToDecimal(row["Qty"]) * -1;
                    if (row["Amount"] != DBNull.Value)
                        row["Amount"] = Convert.ToDecimal(row["Amount"]) * -1;
                    if (row["DiscPer"] != DBNull.Value)
                        row["DiscPer"] = Convert.ToDecimal(row["DiscPer"]) * -1;
                    if (row["DiscAmount"] != DBNull.Value)
                        row["DiscAmount"] = Convert.ToDecimal(row["DiscAmount"]) * -1;
                    if (row["Total"] != DBNull.Value)
                        row["Total"] = Convert.ToDecimal(row["Total"]) * -1;
                    if (row["SaleTaxRate"] != DBNull.Value)
                        row["SaleTaxRate"] = Convert.ToDecimal(row["SaleTaxRate"]) * -1;
                    //row["MarginPer"] = Convert.ToDecimal(row["MarginPer"]) * -1;
                    //row["MarginAmount"] = Convert.ToDecimal(row["MarginAmount"]) * -1;
                }
            }
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["PartsPrice"] != DBNull.Value)
                curRow["PartsPrice"] = Convert.ToDecimal(curRow["PartsPrice"]) * -1;
            if (curRow["LaborPrice"] != DBNull.Value)
                curRow["LaborPrice"] = Convert.ToDecimal(curRow["LaborPrice"]) * -1;
            if (curRow["OtherPrice"] != DBNull.Value)
                curRow["OtherPrice"] = Convert.ToDecimal(curRow["OtherPrice"]) * -1;
            if (curRow["FET"] != DBNull.Value)
                curRow["FET"] = Convert.ToDecimal(curRow["FET"]) * -1;
            if (curRow["Taxable"] != DBNull.Value)
                curRow["Taxable"] = Convert.ToDecimal(curRow["Taxable"]) * -1;
            if (curRow["Tax"] != DBNull.Value)
                curRow["Tax"] = Convert.ToDecimal(curRow["Tax"]) * -1;
            if (curRow["Discount"] != DBNull.Value)
                curRow["Discount"] = Convert.ToDecimal(curRow["Discount"]) * -1;
            if (curRow["PartDisPer"] != DBNull.Value)
                curRow["PartDisPer"] = Convert.ToDecimal(curRow["PartDisPer"]) * -1;
            if (curRow["LaborDisPer"] != DBNull.Value)
                curRow["LaborDisPer"] = Convert.ToDecimal(curRow["LaborDisPer"]) * -1;
            if (curRow["Total"] != DBNull.Value)
                curRow["Total"] = Convert.ToDecimal(curRow["Total"]) * -1;
        }
        void fillWorkOrderNegateDetail()
        {
            DataTable dt = dbClass.obj.getWorkOrderDetailByID(this.WorkOrderID);
            if (dt != null)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    DataRowView curRow = (DataRowView)DGVWorkOrderNegate.objBindingSource.AddNew();
                    curRow.BeginEdit();

                    curRow["PackageID"] = dataRow["PackageID"];
                    curRow["ItemID"] = dataRow["ItemID"];
                    curRow["FeeID"] = dataRow["FeeID"];
                    curRow["LaborID"] = dataRow["LaborID"];

                    curRow["VehicleInspectionID"] = dataRow["VehicleInspectionID"];
                    curRow["InspectionHeadID"] = dataRow["InspectionHeadID"];
                    curRow["Ctype"] = dataRow["Ctype"];

                    curRow["Available"] = dataRow["Available"];
                    //curRow["Qty"] = dataRow["Qty"];
                    curRow["Qty"] = Convert.ToDecimal(dataRow["Qty"]) * -1;

                    curRow["Hours"] = dataRow["Hours"];

                    curRow["IsVendorManufacture"] = dataRow["IsVendorManufacture"];
                    curRow["IsDiscountable"] = dataRow["IsDiscountable"];
                    curRow["IsNotShared"] = dataRow["IsNotShared"];
                    curRow["IsObsolete"] = dataRow["IsObsolete"];
                    curRow["IsRepComm"] = dataRow["IsRepComm"];
                    curRow["IsOutsideItem"] = dataRow["IsOutsideItem"];
                    curRow["IsMechComm"] = dataRow["IsMechComm"];
                    curRow["IsCosted"] = dataRow["IsCosted"];
                    curRow["IsTaxable"] = dataRow["IsTaxable"];
                    curRow["IsRetread"] = dataRow["IsRetread"];
                    curRow["IsStocked"] = dataRow["IsStocked"];
                    curRow["IsUseFET"] = dataRow["IsUseFET"];

                    curRow["Price"] = dataRow["Price"];
                    curRow["Cost"] = dataRow["Cost"];
                    //curRow["Amount"] = dataRow["Amount"];
                    if (dataRow["Amount"] == DBNull.Value)
                    {
                        curRow["Amount"] = DBNull.Value;
                    }
                    else
                    {
                        curRow["Amount"] = Convert.ToDecimal(dataRow["Amount"]) * -1;
                    }
                    //curRow["DiscPer"] = dataRow["DiscPer"];
                    if (dataRow["DiscPer"] == DBNull.Value)
                    {
                        curRow["DiscPer"] = DBNull.Value;
                    }
                    else
                    {
                        curRow["DiscPer"] = Convert.ToDecimal(dataRow["DiscPer"]) * -1;
                    }
                    //curRow["DiscAmount"] = dataRow["DiscAmount"];
                    if (dataRow["DiscAmount"] == DBNull.Value)
                    {
                        curRow["DiscAmount"] = DBNull.Value;
                    }
                    else
                    {
                        curRow["DiscAmount"] = Convert.ToDecimal(dataRow["DiscAmount"]) * -1;
                    }
                    curRow["FET"] = dataRow["FET"];
                    //curRow["FET"] = Convert.ToDecimal(curRow["FET"]) * -1;
                    //curRow["Total"] = dataRow["Total"];
                    if (dataRow["Total"] == DBNull.Value)
                    {
                        curRow["Total"] = DBNull.Value;
                    }
                    else
                    {
                        curRow["Total"] = Convert.ToDecimal(dataRow["Total"]) * -1;
                    }
                    curRow["MechanicID"] = dataRow["MechanicID"];
                    curRow["RepID"] = dataRow["RepID"];
                    curRow["IsDone"] = dataRow["IsDone"];
                    //curRow["SaleTaxRate"] = dataRow["SaleTaxRate"];
                    if (dataRow["SaleTaxRate"] == DBNull.Value)
                    {
                        curRow["SaleTaxRate"] = DBNull.Value;
                    }
                    else
                    {
                        curRow["SaleTaxRate"] = Convert.ToDecimal(dataRow["SaleTaxRate"]) * -1;
                    }
                    curRow["IsTax"] = dataRow["IsTax"];

                    curRow["Tax"] = dataRow["Tax"];
                    //curRow["Tax"] = Convert.ToDecimal(dataRow["Tax"]) * -1;
                    curRow["MarginPer"] = dataRow["MarginPer"];
                    curRow["MarginAmount"] = dataRow["MarginAmount"];

                    curRow["Active"] = dataRow["Active"];
                    curRow["AddDate"] = dataRow["AddDate"];
                    curRow["AddUserID"] = dataRow["AddUserID"];
                    curRow["ModifyUserID"] = dataRow["ModifyUserID"];
                    curRow["ModifyDate"] = dataRow["ModifyDate"];
                    curRow["Comments"] = dataRow["Comments"];
                    curRow["IsLocked"] = dataRow["IsLocked"];
                    curRow["DocNo"] = dataRow["DocNo"];
                    curRow["Remarks"] = dataRow["Remarks"];
                    curRow["CoFinEndYear"] = dataRow["CoFinEndYear"];
                    curRow["TrnsVrNo"] = dataRow["TrnsVrNo"];
                    curRow["TrnsJrRef"] = dataRow["TrnsJrRef"];
                    curRow["CompanyID"] = dataRow["CompanyID"];
                    curRow["WarehouseID"] = dataRow["WarehouseID"];
                    curRow["StoreID"] = dataRow["StoreID"];

                    curRow["Mechanic"] = dataRow["Mechanic"];
                    curRow["Rep"] = dataRow["Rep"];
                    curRow["Catalog"] = dataRow["Catalog"];
                    curRow["Name"] = dataRow["Name"];


                    curRow.EndEdit();
                }
            }
        }
        protected override void TSMItem1_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorSaveItem_Click(sender, e);
            if (this.WorkOrderID > 0)
                dbClass.obj.UpdateWorkOrderIsNegated(this.WorkOrderID);
            this.ParentForm.Close();
        }
        protected override void TSMItem2_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorSaveItem_Click(sender, e);
            if (this.WorkOrderID > 0)
                dbClass.obj.UpdateWorkOrderIsNegated(this.WorkOrderID);
            //-----------------------------------------------//
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
                StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderNegateReport", "byID", Convert.ToInt32(curRow["ID"]));

            this.ParentForm.Close();
        }
        protected override void TSMItem3_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorSaveItem_Click(sender, e);
            if (this.WorkOrderID > 0)
                dbClass.obj.UpdateWorkOrderIsNegated(this.WorkOrderID);
            //-----------------------------------------------//
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                ctrCustomerPayment objList = new ctrCustomerPayment(Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                frmCtr frmCtr = new frmCtr("Customer Payment ...");
                frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
            this.ParentForm.Close();
        }
        protected override void TSMItem4_Click(object sender, EventArgs e)
        {

        }

        void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string DGVColumnName = DGVWorkOrderNegate.Columns[e.ColumnIndex].DataPropertyName;
                    switch (DGVColumnName)
                    {
                        case "Catalog":
                            //LoadCatalog_CellClick();
                            break;
                        case "MechanicID":
                            this.Mechanic.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
                            break;
                        case "":
                            if (DGVWorkOrderNegate.Columns[e.ColumnIndex].Name.Equals("DelColumn"))
                            {
                                if (((DGVWorkOrderNegate.Rows[e.RowIndex].Cells["PackageID"].Value) == DBNull.Value) && ((DGVWorkOrderNegate.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value) == DBNull.Value))
                                {
                                    if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        DGVWorkOrderNegate.objBindingSource.Remove(DGVWorkOrderNegate.objBindingSource.Current);
                                        DGVWorkOrderNegate.objBindingSource.EndEdit();
                                    }
                                }
                                else
                                {
                                    if (xMessageBox.Show("Do you want to delete this Package..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        if ((DGVWorkOrderNegate.Rows[e.RowIndex].Cells["PackageID"].Value) != DBNull.Value)
                                        {
                                            int packageID = Convert.ToInt32(DGVWorkOrderNegate.Rows[e.RowIndex].Cells["PackageID"].Value);
                                            if (packageID > 0)
                                                DeletePackageItemsFromGrid(packageID);
                                        }
                                        else if ((DGVWorkOrderNegate.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value) != DBNull.Value)
                                        {
                                            int VehicleInspectionID = Convert.ToInt32(DGVWorkOrderNegate.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value);
                                            if (VehicleInspectionID > 0)
                                                DeleteInspectionItemsFromGrid(VehicleInspectionID);
                                        }
                                    }
                                }
                                CalculatColumns();
                            }
                            break;
                        default:
                            this.Mechanic.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                            break;
                    }

                }
                catch { }
            }

        }
        void DeletePackageItemsFromGrid(int packageID)
        {
            try
            {
                for (int j = DGVWorkOrderNegate.Rows.Count; j > 0; j--)
                {
                    if (DGVWorkOrderNegate.Rows[j - 1].Cells["PackageID"].Value != DBNull.Value)
                    {
                        if (Convert.ToInt32(DGVWorkOrderNegate.Rows[j - 1].Cells["PackageID"].Value) == packageID)
                            DGVWorkOrderNegate.Rows[j - 1].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in DGVWorkOrderNegate.SelectedRows)
                {
                    DGVWorkOrderNegate.Rows.Remove(row);
                }
            }
            catch { }
        }
        void DeleteInspectionItemsFromGrid(int VehicleInspectionID)
        {
            try
            {
                for (int j = DGVWorkOrderNegate.Rows.Count; j > 0; j--)
                {
                    if (DGVWorkOrderNegate.Rows[j - 1].Cells["VehicleInspectionID"].Value != DBNull.Value)
                    {
                        if (Convert.ToInt32(DGVWorkOrderNegate.Rows[j - 1].Cells["VehicleInspectionID"].Value) == VehicleInspectionID)
                            DGVWorkOrderNegate.Rows[j - 1].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in DGVWorkOrderNegate.SelectedRows)
                {
                    DGVWorkOrderNegate.Rows.Remove(row);
                }
            }
            catch { }
        }
        void DGVWorkOrderNegate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            libDataGridView DGV = (libDataGridView)sender;
            DataRowView curRow = (DataRowView)DGV.objBindingSource.Current;
            string DGVColumnName = DGV.Columns[e.ColumnIndex].Name;

            curRow.BeginEdit();
            //----------------------------------------------
            if (Convert.ToString(curRow["CType"]) != "S")
            {
                if (DGVColumnName.Equals("Qty") || DGVColumnName.Equals("Price") || DGVColumnName.Equals("Amount") || DGVColumnName.Equals("DiscPer") || DGVColumnName.Equals("DiscAmount") || DGVColumnName.Equals("IsTax"))
                {
                    if (curRow["Qty"] == DBNull.Value) curRow["Qty"] = 0;
                    if (Convert.ToInt32(curRow["Qty"]) > 0)
                    {
                        curRow["Qty"] = Convert.ToInt32(curRow["Qty"]) * -1;
                    }
                        if (DGVColumnName.Equals("Qty") || DGVColumnName.Equals("Price"))
                            curRow["Amount"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Price"]), 2);
                        if (DGVColumnName.Equals("Amount"))
                            curRow["Price"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Amount"]), 2);
                        if (DGVColumnName.Equals("DiscAmount"))
                            curRow["DiscPer"] = Math.Round((Convert.ToDecimal(curRow["DiscAmount"]) / Convert.ToDecimal(curRow["Amount"]) * 100), 0);
                        else
                            curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);

                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                        if ((Convert.ToDecimal(curRow["Price"]) > 0) && (Convert.ToDecimal(curRow["Cost"]) > 0))
                            curRow["MarginPer"] = Math.Round((((Convert.ToDecimal(curRow["Price"]) - Convert.ToDecimal(curRow["Cost"])) * 100) / Convert.ToDecimal(curRow["Cost"])), 2);
                        if ((Convert.ToDecimal(curRow["MarginPer"]) > 0) && (Convert.ToDecimal(curRow["Cost"]) > 0))
                            curRow["MarginAmount"] = Math.Round((((Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"])) / 100) + Convert.ToDecimal(curRow["Cost"])), 2);

                        if (curRow["IsTax"] != DBNull.Value)
                        {
                            if (Convert.ToBoolean(curRow["IsTax"]))
                            {
                                if (curRow["SaleTaxRate"] != DBNull.Value)
                                {
                                    if (Convert.ToDecimal(curRow["SaleTaxRate"]) > 0)
                                    {
                                        curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["SaleTaxRate"]) / 100), 2);
                                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                                    }
                                }
                            }

                        }
                    //}
                }
                //----------------------------------------------
                if (DGVColumnName.Equals("MarginPer"))
                {
                    if (curRow["Qty"] == DBNull.Value) curRow["Qty"] = 0;
                    if (Convert.ToInt32(curRow["Qty"]) > 0)
                    {
                        curRow["MarginAmount"] = Math.Round((Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"]) / 100)) + Convert.ToDecimal(curRow["Cost"]);

                        curRow["Price"] = Math.Round((Convert.ToDecimal(curRow["Cost"]) + (Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"]) / 100)), 2);
                        curRow["Amount"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Price"]), 2);

                        curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);
                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);

                        if (curRow["IsTax"] != DBNull.Value)
                        {
                            if (Convert.ToBoolean(curRow["IsTax"]))
                            {
                                if (curRow["SaleTaxRate"] != DBNull.Value)
                                {
                                    if (Convert.ToDecimal(curRow["SaleTaxRate"]) > 0)
                                    {
                                        curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["SaleTaxRate"]) / 100), 2);
                                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                                    }
                                }
                            }
                        }
                    }
                }
                //----------------------------------------------
                curRow.EndEdit();
                //---------------------------------------------
                CalculatColumns();
            }
            else
            {
                if (DGVColumnName.Equals("DiscPer") || DGVColumnName.Equals("DiscAmount"))
                {
                    decimal pDiscount = 0;

                    if (DGVColumnName.Equals("DiscAmount"))
                        curRow["DiscPer"] = Math.Round((Convert.ToDecimal(curRow["DiscAmount"]) / Convert.ToDecimal(curRow["Amount"]) * 100), 0);
                    else
                        curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);

                    curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);

                    pDiscount = Convert.ToDecimal(curRow["DiscAmount"]);
                    //---------------------------------------------//
                    curRow.EndEdit();
                    //---------------------------------------------//
                    DataRowView WOcurRow = (DataRowView)objBindingSource.Current;
                    WOcurRow.BeginEdit();
                    decimal discoutAmount = Convert.ToDecimal(WOcurRow["Discount"]);
                    decimal totalAmount = Convert.ToDecimal(WOcurRow["Total"]);
                    WOcurRow["Discount"] = pDiscount + discoutAmount;
                    WOcurRow["Total"] = totalAmount - (pDiscount + discoutAmount);
                    WOcurRow.EndEdit();
                    //---------------------------------------------//                  
                    //ChangePackageHeader();
                    //---------------------------------------------//
                    this.btnBNMoveFirstItem.Enabled = false;
                    this.btnBNMovePreviousItem.Enabled = false;
                    //---------------------------------------------//
                }
            }

        }
        void LoadCatalog_CellClick()
        {
            ctrItemListForGrid objList = new ctrItemListForGrid(this.CustID, this.CustomerPriceLevel);
            objList.ObjectSelected += AddCatalogInGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Item ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();

        }
        void LoadService_CellClick()
        {
            if (this.CustID <= 0)
            {
                xMessageBox.Show("Select Customer for WorkOrderNegate..");
                return;
            }
            if (this.VehicleID <= 0)
            {
                xMessageBox.Show("Select Vehicle for WorkOrderNegate..");
                return;
            }

            ctrServicesForWO objList = new ctrServicesForWO();
            objList.ServiceSelected += AddServiceInGrid_ObjectSelected;
            objList.ShopLabor += AddShopLaborInGrid_ObjectSelected;
            objList.OutsidePart += AddOutsidePartInGrid_ObjectSelected;
            frmCtr frmCtr = new frmCtr("Select Services ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void AddCatalogInGrid_ObjectSelected(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (dataRow != null)
                    {
                        if (dataRow["CatalogCost"] == DBNull.Value)
                        {
                            xMessageBox.Show("Catalog price is not set for this Item ...");
                        }
                        else
                        {
                            //DataRowView xCurRow = (DataRowView)DGVWorkOrderNegate.objBindingSource.Current;
                            //if ((xCurRow != null) && (xCurRow.Row.RowState == DataRowState.Detached))
                            //{
                            //    xCurRow.BeginEdit();
                            //    if (packageID > 0)
                            //        xCurRow["PackageID"] = packageID;

                            //    if (dataRow["ItemID"] != DBNull.Value)
                            //        xCurRow["ItemID"] = dataRow["ItemID"];
                            //    if (dataRow["FeeID"] != DBNull.Value)
                            //        xCurRow["FeeID"] = dataRow["FeeID"];
                            //    if (dataRow["LaborID"] != DBNull.Value)
                            //        xCurRow["LaborID"] = dataRow["LaborID"];

                            //    xCurRow["Ctype"] = dataRow["Ctype"];

                            //    xCurRow["Catalog"] = dataRow["Catalog"];
                            //    xCurRow["Name"] = dataRow["Name"];

                            //    xCurRow["Available"] = dataRow["Available"];
                            //    xCurRow["Qty"] = dataRow["Qty"];
                            //    xCurRow["Hours"] = dataRow["Hours"];
                            //    xCurRow["IsDiscountable"] = dataRow["IsDiscountable"];
                            //    xCurRow["Price"] = dataRow["Price"];
                            //    xCurRow["Cost"] = dataRow["CatalogCost"];
                            //    xCurRow["Amount"] = dataRow["Amount"];
                            //    xCurRow["DiscPer"] = dataRow["PartDisPer"];
                            //    xCurRow["DiscAmount"] = dataRow["PartDis"];
                            //    xCurRow["FET"] = dataRow["FET"];
                            //    xCurRow["Total"] = Convert.ToDecimal(dataRow["Total"]) - Convert.ToDecimal(dataRow["PartDis"]) + Convert.ToDecimal(dataRow["PartTax"]);

                            //    xCurRow["IsMechComm"] = dataRow["IsMechComm"];
                            //    if (Convert.ToBoolean(dataRow["IsMechComm"]))
                            //        xCurRow["MechanicID"] = StaticInfo.userid;

                            //    xCurRow["MarginPer"] = dataRow["MarginPer"];
                            //    xCurRow["MarginAmount"] = dataRow["MarginAmount"];

                            //    xCurRow["IsRepComm"] = dataRow["IsRepComm"];
                            //    if (Convert.ToBoolean(dataRow["IsRepComm"]))
                            //        xCurRow["RepID"] = StaticInfo.userid;

                            //    xCurRow["Rep"] = dbClass.obj.getUserInitial(StaticInfo.userid);
                            //    xCurRow["IsDone"] = false;
                            //    xCurRow["IsTax"] = dataRow["IsTaxable"];
                            //    xCurRow["SaleTaxRate"] = dataRow["SaleTaxRate"];
                            //    xCurRow["Tax"] = dataRow["PartTax"];

                            //    xCurRow["Active"] = true;
                            //    xCurRow["AddDate"] = DateTime.Now;
                            //    xCurRow["AddUserID"] = StaticInfo.userid;
                            //    xCurRow["IsLocked"] = false;
                            //    xCurRow.EndEdit();
                            //}
                            //else
                            //{
                            DataRowView newItemRow = (DataRowView)DGVWorkOrderNegate.objBindingSource.AddNew();
                            newItemRow.BeginEdit();
                            if (packageID > 0)
                                newItemRow["PackageID"] = packageID;

                            if (dataRow["ItemID"] != DBNull.Value)
                                newItemRow["ItemID"] = dataRow["ItemID"];
                            if (dataRow["FeeID"] != DBNull.Value)
                                newItemRow["FeeID"] = dataRow["FeeID"];
                            if (dataRow["LaborID"] != DBNull.Value)
                                newItemRow["LaborID"] = dataRow["LaborID"];
                            try
                            {
                                if (dataRow["InspectionHeadID"] != DBNull.Value)
                                    newItemRow["InspectionHeadID"] = dataRow["InspectionHeadID"];
                            }
                            catch { }
                            newItemRow["Ctype"] = dataRow["Ctype"];

                            newItemRow["Catalog"] = dataRow["Catalog"];
                            newItemRow["Name"] = dataRow["Name"];

                            newItemRow["Available"] = dataRow["Available"];
                            //newItemRow["Qty"] = dataRow["Qty"];
                            newItemRow["Qty"] = Convert.ToDecimal(dataRow["Qty"]) * -1;

                            newItemRow["Hours"] = dataRow["Hours"];
                            newItemRow["IsDiscountable"] = dataRow["IsDiscountable"];
                            newItemRow["Price"] = dataRow["Price"];
                            newItemRow["Cost"] = dataRow["CatalogCost"];
                            //newItemRow["Amount"] = dataRow["Amount"];
                            newItemRow["Amount"] = Convert.ToDecimal(dataRow["Amount"]) * -1;
                            newItemRow["DiscPer"] = dataRow["PartDisPer"];
                            newItemRow["DiscAmount"] = dataRow["PartDis"];
                            newItemRow["FET"] = dataRow["FET"];
                            //newItemRow["Total"] = Convert.ToDecimal(dataRow["Total"]) - Convert.ToDecimal(dataRow["PartDis"]) + Convert.ToDecimal(dataRow["PartTax"]);
                            newItemRow["Total"] = (Convert.ToDecimal(dataRow["Total"]) - Convert.ToDecimal(dataRow["PartDis"]) + Convert.ToDecimal(dataRow["PartTax"])) * -1;

                            newItemRow["IsMechComm"] = dataRow["IsMechComm"];
                            if (Convert.ToBoolean(dataRow["IsMechComm"]))
                                newItemRow["MechanicID"] = StaticInfo.userid;

                            newItemRow["MarginPer"] = dataRow["MarginPer"];
                            newItemRow["MarginAmount"] = dataRow["MarginAmount"];

                            newItemRow["IsRepComm"] = dataRow["IsRepComm"];

                            if (Convert.ToBoolean(dataRow["IsRepComm"]))
                            {
                                if (StaticInfo.userid > 6)
                                { newItemRow["RepID"] = StaticInfo.userid; }
                                else
                                { newItemRow["RepID"] = DBNull.Value; }
                            }

                            newItemRow["Rep"] = dbClass.obj.getUserInitial(StaticInfo.userid);
                            newItemRow["IsDone"] = false;
                            newItemRow["IsTax"] = dataRow["IsTaxable"];
                            newItemRow["SaleTaxRate"] = dataRow["SaleTaxRate"];
                            newItemRow["Tax"] = dataRow["PartTax"];

                            newItemRow["Active"] = true;
                            newItemRow["AddDate"] = DateTime.Now;
                            newItemRow["AddUserID"] = StaticInfo.userid;
                            newItemRow["IsLocked"] = false;
                            newItemRow.EndEdit();
                            //}

                            CalculatColumns();
                        }
                    }
                }
            }
            catch { }
        }
        void AddServiceInGrid_ObjectSelected(object sender, DataRow serviceRow)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (serviceRow != null)
                    {
                        int packageID = Convert.ToInt32(serviceRow["ID"]);

                        //------------------------------------------------------------------
                        DataTable dt = dbClass.obj.FillPackageDetailByID(Convert.ToInt32(serviceRow["ID"]), this.CustID, this.CustomerPriceLevel);
                        if (dt.Rows.Count > 0)
                        {
                            decimal PackagePrice = 0;
                            decimal PackageCost = 0;
                            decimal PackageAmount = 0;
                            decimal PackageDiscAmount = 0;
                            decimal PackageFET = 0;
                            decimal PackageTotal = 0;
                            List<Boolean> IsOptionalMessage = new List<Boolean>();
                            Boolean bIsOptional = false;
                            //-------------------------------------------------------------------//
                            foreach (DataRow dataRow in dt.Rows)
                                IsOptionalMessage.Add(Convert.ToBoolean(dataRow["IsOptional"]));
                            //-------------------------------------------------------------------//
                            if (IsOptionalMessage.Contains(true))
                            {
                                if (xMessageBox.Show("Do you want to add Optional Item....?", "", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
                                    bIsOptional = true;
                            }
                            //-------------------------------------------------------------------//
                            foreach (DataRow dataRow in dt.Rows)
                            {
                                if (!bIsOptional)
                                {
                                    if (!Convert.ToBoolean(dataRow["IsOptional"]))
                                    {
                                        PackagePrice += Convert.ToDecimal(dataRow["Price"]);
                                        PackageCost += Convert.ToDecimal(dataRow["CatalogCost"]);
                                        PackageAmount += Convert.ToDecimal(dataRow["Amount"]);
                                        PackageDiscAmount += Convert.ToDecimal(dataRow["PartDis"]);
                                        PackageFET += Convert.ToDecimal(dataRow["FET"]);
                                        PackageTotal += Convert.ToDecimal(dataRow["Total"]) - Convert.ToDecimal(dataRow["PartDis"]) + Convert.ToDecimal(dataRow["PartTax"]);
                                    }
                                }
                                else
                                {
                                    PackagePrice += Convert.ToDecimal(dataRow["Price"]);
                                    PackageCost += Convert.ToDecimal(dataRow["CatalogCost"]);
                                    PackageAmount += Convert.ToDecimal(dataRow["Amount"]);
                                    PackageDiscAmount += Convert.ToDecimal(dataRow["PartDis"]);
                                    PackageFET += Convert.ToDecimal(dataRow["FET"]);
                                    PackageTotal += Convert.ToDecimal(dataRow["Total"]) - Convert.ToDecimal(dataRow["PartDis"]) + Convert.ToDecimal(dataRow["PartTax"]);
                                }
                            }
                            //-------------------------------------------------------------------//
                            DataRowView newRow = (DataRowView)DGVWorkOrderNegate.objBindingSource.AddNew();
                            newRow.BeginEdit();
                            newRow["PackageID"] = serviceRow["ID"];
                            newRow["Catalog"] = serviceRow["Catalog"];
                            newRow["Name"] = serviceRow["Name"];
                            newRow["Ctype"] = "S";
                            newRow["Available"] = 0;
                            newRow["Qty"] = 1;

                            newRow["Price"] = PackagePrice;
                            newRow["Cost"] = PackageCost;
                            newRow["Amount"] = PackageAmount;
                            newRow["DiscPer"] = Math.Round(((PackageDiscAmount / PackageAmount) * 100), 0);
                            newRow["DiscAmount"] = PackageDiscAmount;
                            newRow["FET"] = PackageFET;
                            newRow["Total"] = PackageTotal;
                            newRow["MarginPer"] = 0;

                            newRow["Active"] = true;
                            newRow["AddDate"] = DateTime.Now;
                            newRow["AddUserID"] = StaticInfo.userid;
                            newRow["IsLocked"] = false;
                            newRow.EndEdit();
                            //-------------------------------------------------------------------//
                            foreach (DataRow dataRow in dt.Rows)
                            {
                                if (!bIsOptional)
                                {
                                    if (!Convert.ToBoolean(dataRow["IsOptional"]))
                                        AddCatalogInGrid_ObjectSelected(sender, dataRow, packageID);
                                }
                                else
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow, packageID);
                            }
                            //-------------------------------------------------------------------//
                        }
                        //ChangePackageHeader();
                    }
                }
            }
            catch { }
        }
        void AddShopLaborInGrid_ObjectSelected(object sender, string ShopLabor)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (ShopLabor != null)
                    {
                        int LaborID = dbClass.obj.getLaborIDByCatalog(ShopLabor);
                        if (LaborID > 0)
                        {
                            DataTable dt = dbClass.obj.getLaborForGridByLaborID(LaborID, this.CustID);
                            if (dt != null)
                            {
                                DataRow dataRow = dt.Rows[0];
                                if (dataRow != null)
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow);
                            }
                        }
                    }
                }
            }
            catch { }
        }
        void AddOutsidePartInGrid_ObjectSelected(object sender, string OutsidePart)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (OutsidePart != null)
                    {
                        int ItemID = dbClass.obj.getItemIDByCatalog(OutsidePart);
                        if (ItemID > 0)
                        {
                            //DataTable dt = dbClass.obj.getItemForGridByItemID(ItemID, this.CustID);
                            //if (dt != null)
                            //{
                            //    DataRow dataRow = dt.Rows[0];
                            //    if (dataRow != null)
                            //        AddCatalogInGrid_ObjectSelected(sender, dataRow);

                            //}
                        }
                    }
                }
            }
            catch { }
        }
        void ChangePackageHeader()
        {
            //-------------------------------------------------------------------
            foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
            {
                if (n.Cells["CType"].Value != null)
                {
                    if ((Convert.ToString(n.Cells["CType"].Value) == "S") || (Convert.ToString(n.Cells["CType"].Value) == "IH"))
                    {
                        n.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        n.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
                if (n.Cells["Total"].Value != DBNull.Value)
                {
                    if (Convert.ToDecimal(n.Cells["Total"].Value) < 0)
                        n.Cells["Total"].Style.ForeColor = Color.Red;
                }

            }
            //-------------------------------------------------------------------
        }
        void AddCustomerDetail_ObjectSelected(object sender, DataRow CustomerRow)
        {
            this.SetCustomer(Convert.ToInt32(CustomerRow["ID"]));
            this.SetVehicle(0);
        }
        void AddVehicleDetail_ObjectSelected(object sender, DataRow VehicleRow)
        {

            //ctrLicensePlate.Text = Convert.ToString(VehicleRow["LicensePlate"]);

            //string VehicleYearMakeModel = Convert.ToString(VehicleRow["Year"]) + " - " + Convert.ToString(VehicleRow["Make"]) + " - " + Convert.ToString(VehicleRow["Model"]);
            //ctrVehicleYearMakeModel.Text = Convert.ToString(VehicleYearMakeModel);
            //ctrVIN.Text = Convert.ToString(VehicleRow["VIN"]);
            //ctrLastMileage.Text = Convert.ToString(VehicleRow["Mileage"]);

            //DataRowView curRow = (DataRowView)objBindingSource.Current;
            //curRow.BeginEdit();
            //curRow["VehicleID"] = VehicleRow["ID"];
            //curRow["VIN"] = VehicleRow["VIN"];


            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["VehicleID"] = VehicleRow["ID"];
            this.VehicleID = Convert.ToInt32(VehicleRow["ID"]);

            ctrLicensePlate.Text = Convert.ToString(VehicleRow["LicensePlate"]);
            if (VehicleRow["StateID"] != DBNull.Value)
            {
                if (Convert.ToInt32(VehicleRow["StateID"]) > 0)
                {
                    ctrVehicleState.DisplayMember = ctrVehicleState.xDisplayMember;
                    ctrVehicleState.ValueMember = ctrVehicleState.ValueMember;
                    ctrVehicleState.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrVehicleState.xTableName].Copy(), Convert.ToInt32(VehicleRow["StateID"]));
                }
            }

            string VehicleYearMakeModel = Convert.ToString(VehicleRow["Year"]) + " - " + Convert.ToString(VehicleRow["Make"]) + " - " + Convert.ToString(VehicleRow["Model"]);
            ctrVehicleYearMakeModel.Text = Convert.ToString(VehicleYearMakeModel);
            ctrVIN.Text = Convert.ToString(VehicleRow["VIN"]);
            ctrLastMileage.Text = Convert.ToString(VehicleRow["Mileage"]);

            curRow.EndEdit();

        }
        void ctrPartDisPer_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                int PartDisPer = Convert.ToInt32(ctrPartDisPer.Value);

                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) == "P")
                        {
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value != null)
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = PartDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);

                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (editedRow["SaleTaxRate"] != DBNull.Value)
                                                {
                                                    if (Convert.ToDecimal(editedRow["SaleTaxRate"]) > 0)
                                                    {
                                                        editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["SaleTaxRate"]) / 100), 2);
                                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                    }
                                                }
                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        void ctrLaborDisPer_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                int LaborDisPer = Convert.ToInt32(ctrLaborDisPer.Value);

                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        {
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value != null)
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = LaborDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);

                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (editedRow["SaleTaxRate"] != DBNull.Value)
                                                {
                                                    if (Convert.ToDecimal(editedRow["SaleTaxRate"]) > 0)
                                                    {
                                                        editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["SaleTaxRate"]) / 100), 2);
                                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                    }
                                                }
                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        void CalculatColumns()
        {
            //-------------------------------------------------------------            
            decimal PartsPrice = 0, LaborPrice = 0, OtherPrice = 0, FET = 0, Taxable = 0, Tax = 0, Discount = 0;
            foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
            {
                try
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if ((Convert.ToString(n.Cells["CType"].Value) == "T")
                             || (Convert.ToString(n.Cells["CType"].Value) == "P")
                             || (Convert.ToString(n.Cells["CType"].Value) == "M")
                             || (Convert.ToString(n.Cells["CType"].Value) == "OP")
                             || (Convert.ToString(n.Cells["CType"].Value) == "OT")
                             || (Convert.ToString(n.Cells["CType"].Value) == "R")
                            || (Convert.ToString(n.Cells["CType"].Value) == "U"))
                        { if (n.Cells["Amount"].Value != null) { PartsPrice += Convert.ToDecimal(n.Cells["Amount"].Value); } }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        { if (n.Cells["Amount"].Value != null) { LaborPrice += Convert.ToDecimal(n.Cells["Amount"].Value); } }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "F")
                        { if (n.Cells["Amount"].Value != null) { OtherPrice += Convert.ToDecimal(n.Cells["Amount"].Value); } }

                        if (Convert.ToString(n.Cells["CType"].Value) != "S")
                        {
                            if (n.Cells["FET"].Value != null) { FET += Convert.ToDecimal(n.Cells["FET"].Value); }
                            if (n.Cells["IsTax"].Value != null) { if (Convert.ToBoolean(n.Cells["IsTax"].Value)) { Taxable += Convert.ToDecimal(n.Cells["Amount"].Value); } }
                            if (n.Cells["Tax"].Value != null) { if (Convert.ToBoolean(n.Cells["IsTax"].Value)) Tax += Convert.ToDecimal(n.Cells["Tax"].Value); }
                            if (n.Cells["DiscAmount"].Value != null) { Discount += Convert.ToDecimal(n.Cells["DiscAmount"].Value); }
                        }
                    }
                }
                catch { }
            }

            //-------------------------------------------------------------
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["PartsPrice"] = PartsPrice;
            curRow["LaborPrice"] = LaborPrice;
            curRow["OtherPrice"] = OtherPrice;
            curRow["FET"] = FET;

            curRow["Taxable"] = Taxable;
            curRow["Tax"] = Tax;
            curRow["Discount"] = Discount;

            curRow["Total"] = (PartsPrice + LaborPrice + OtherPrice + FET + Tax) - Discount;

            curRow.EndEdit();
            //------------------------------
            //ChangePackageHeader();
            //------------------------------
            this.btnBNMoveFirstItem.Enabled = false;
            this.btnBNMovePreviousItem.Enabled = false;
            //------------------------------
        }
        void setGridPrice(string priceLevel)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) == "P")
                        {
                            DataRowView curRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                            decimal itemPrice = dbClass.obj.getItemPrice(priceLevel, Convert.ToInt32(curRow["ItemID"]));
                            curRow.BeginEdit();
                            curRow["Price"] = itemPrice;
                            //------------------------------------------------------------------------------
                            curRow["Amount"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Price"]), 2);
                            curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);
                            curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                            curRow["MarginPer"] = Math.Round((((Convert.ToDecimal(curRow["Price"]) - Convert.ToDecimal(curRow["Cost"])) * 100) / Convert.ToDecimal(curRow["Cost"])), 2);
                            curRow["MarginAmount"] = Math.Round((((Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"])) / 100) + Convert.ToDecimal(curRow["Cost"])), 2);
                            if (curRow["IsTax"] != DBNull.Value)
                            {
                                if (Convert.ToBoolean(curRow["IsTax"]))
                                {
                                    if (curRow["SaleTaxRate"] != DBNull.Value)
                                    {
                                        if (Convert.ToDecimal(curRow["SaleTaxRate"]) > 0)
                                        {
                                            curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["SaleTaxRate"]) / 100), 2);
                                            curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                                        }
                                    }
                                }
                            }
                            //----------------
                            curRow.EndEdit();
                            //--------------------------------------------------------------
                        }
                    }
                }
                CalculatColumns();
            }
        }
        void setGridTaxRate(int SaleTaxRateID)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["IsTax"].Value != null)
                    {
                        if (Convert.ToBoolean(n.Cells["IsTax"].Value))
                        {
                            decimal TaxRate = 0;
                            if (n.Cells["CType"].Value != null)
                            {
                                if (Convert.ToString(n.Cells["CType"].Value) == "P")
                                    TaxRate = dbClass.obj.getSaleTaxRate(SaleTaxRateID, "PartsRate");
                                if (Convert.ToString(n.Cells["CType"].Value) == "L")
                                    TaxRate = dbClass.obj.getSaleTaxRate(SaleTaxRateID, "LaborRate");
                            }

                            DataRowView curRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                            curRow.BeginEdit();
                            curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                            if (TaxRate > 0)
                                curRow["Tax"] = Math.Round(((Convert.ToDecimal(curRow["Amount"]) * TaxRate) / 100), 2);
                            else
                                curRow["Tax"] = 0;

                            curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                            curRow.EndEdit();
                            //--------------------------------------------------------------
                        }
                    }
                }
                CalculatColumns();
            }
        }
        void setGridSaleRep(int saleRepID, string Initial)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["IsRepComm"].Value != null)
                    {
                        if (Convert.ToBoolean(n.Cells["IsRepComm"].Value))
                        {
                            DataRowView curRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                            curRow.BeginEdit();
                            curRow["RepID"] = saleRepID;
                            curRow["Rep"] = Initial;
                            curRow.EndEdit();
                        }
                    }
                }

            }
        }
        void setGridMech(int MechID, string Initial)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                foreach (DataGridViewRow n in DGVWorkOrderNegate.Rows)
                {
                    if (n.Cells["IsMechComm"].Value != null)
                    {
                        if (Convert.ToBoolean(n.Cells["IsMechComm"].Value))
                        {
                            DataRowView curRow = (DataRowView)DGVWorkOrderNegate.objBindingSource[n.Index];
                            curRow.BeginEdit();
                            curRow["MechanicID"] = MechID;
                            curRow.EndEdit();
                        }
                    }
                }

            }
        }
        void setWOToggleColumns()
        {
            DataTable dt = dbClass.obj.getWOToggleColumns();

            DGVWorkOrderNegate.Columns["Available"].Visible = Convert.ToBoolean(dt.Rows[0]["WOAvailableQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["Hours"].Visible = Convert.ToBoolean(dt.Rows[0]["WOHoursQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["Cost"].Visible = Convert.ToBoolean(dt.Rows[0]["WOCostQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["DiscPer"].Visible = Convert.ToBoolean(dt.Rows[0]["WODiscPerQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["DiscAmount"].Visible = Convert.ToBoolean(dt.Rows[0]["WODiscAmountQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["IsDone"].Visible = Convert.ToBoolean(dt.Rows[0]["WOIsDoneQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["IsTax"].Visible = Convert.ToBoolean(dt.Rows[0]["WOIsTaxQtyToggleColumn"]);
            DGVWorkOrderNegate.Columns["MarginPer"].Visible = Convert.ToBoolean(dt.Rows[0]["WOMarginPerQtyToggleColumn"]);

        }
        void btnAddComments_Click(object sender, EventArgs e) 
        {
            DGVWorkOrderNegate.Columns["ItemDescription"].ReadOnly = false;
            DataRowView newItemRow = (DataRowView)DGVWorkOrderNegate.objBindingSource.AddNew();
            newItemRow.BeginEdit();           
            newItemRow["Name"] = DBNull.Value;
            newItemRow["Price"] = DBNull.Value;
            newItemRow["Amount"] = DBNull.Value;
            newItemRow["DiscPer"] = DBNull.Value;
            newItemRow["DiscAmount"] = DBNull.Value;
            newItemRow["Total"] = DBNull.Value;
            newItemRow["FET"] = DBNull.Value;
            //newItemRow["FET"] = DBNull.Value;
            //newItemRow["FET"] = DBNull.Value;

            newItemRow.EndEdit();
        }
    }
}
