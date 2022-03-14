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
    public partial class ctrWorkOrder : BaseControl
    {
        int WorkOrderID = 0;
        int CustID = 1;
        int VehicleID = 0;
        int ctrMode = 0;
        string CustomerPriceLevel;
        public ctrWorkOrder()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrWorkOrder(int ctrMode)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
        }
        public ctrWorkOrder(int ctrMode, int SelectedCustID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
            this.CustID = SelectedCustID;
        }
        public ctrWorkOrder(int ctrMode, int iID, int SelectedCustID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ctrMode = ctrMode;
            this.CustID = SelectedCustID;
            this.WorkOrderID = iID;
        }
        void InitializeComponent1()
        {
            this.Load += ctrWorkOrder_Load;


            this.DGVWorkOrder.CellClick += new DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGVWorkOrder.CellEndEdit += DGVWorkOrder_CellEndEdit;
            this.DGVWorkOrder.CellFormatting += DGVWorkOrder_CellFormatting;

            this.btnChangeCust.Click += btnChangeCust_Click;
            this.btnNewCust.Click += btnNewCust_Click;
            this.btnEditCust.Click += btnEditCust_Click;

            this.ctrNoVehicle.CheckedChanged += ctrNoVehicle_CheckedChanged;
            this.btnVehicles.Click += btnVehicles_Click;
            this.btnNewVehicle.Click += btnNewVehicle_Click;
            this.btnVehicleEdit.Click += btnVehicleEdit_Click;

            this.btnClickServices.Click += btnClickServices_Click;
            this.btnRecommendedServices.Click += btnRecommendedServices_Click;
            this.btnAddCatalog.Click += btnAddCatalog_Click;
            this.btnAddPackage.Click += btnAddPackage_Click;
            //this.objBindingSource.PositionChanged += objBindingSource_PositionChanged;
            this.txtCatalog.KeyDown += txtCatalog_KeyDown;

            this.ctrPartDisPer.ValueChanged += ctrPartDisPer_ValueChanged;
            this.ctrLaborDisPer.ValueChanged += ctrPartDisPer_ValueChanged;

            this.ctrSaleCategoryID.SelectionChangeCommitted += new System.EventHandler(this.ctrSaleCategoryID_SelectionChangeCommitted);
            this.ctrPriceLevelID.SelectionChangeCommitted += new System.EventHandler(this.ctrPriceLevelID_SelectionChangeCommitted);
            this.ctrSaleTaxRateID.SelectionChangeCommitted += ctrSaleTaxRateID_SelectionChangeCommitted;
            this.ctrSaleRepID.SelectionChangeCommitted += ctrSaleRepID_SelectionChangeCommitted;
            this.ctrMechID.SelectionChangeCommitted += ctrMechID_SelectionChangeCommitted;

            this.btnProfitMargin.Click += btnProfitMargin_Click;
            this.btnToggleColumns.Click += btnToggleColumns_Click;

            this.btnShopLabor.Click += btnShopLabor_Click;
            this.btnOutsidePart.Click += btnOutsidePart_Click;
            this.rdoQuotation.CheckedChanged += rdoQuotation_Changed;
            this.rdoWorkOrder.CheckedChanged += rdoWorkOrder_Changed;
            this.rdoCusOrder.CheckedChanged += rdoCusOrder_Changed;

            btnCustomerInvoice.Click += TSMItem1_Click;
            btnPrintInvoice.Click += TSMItem2_Click;
            StaticInfo.SaleTaxPartsRate = dbClass.obj.getSaleTaxRateFromSaleTaxCategorybyID(3);
        }
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            //LoadPackage_CellClick();
        }
        void DGVWorkOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangePackageHeader();
        }
        void rdoQuotation_Changed(object sender, EventArgs e)
        {
            if (rdoQuotation.Checked)
                btnCustomerInvoice.Enabled = false;
            else
                btnCustomerInvoice.Enabled = true;
        }
        void rdoWorkOrder_Changed(object sender, EventArgs e)
        {
            if (rdoQuotation.Checked)
                btnCustomerInvoice.Enabled = false;
            else
                btnCustomerInvoice.Enabled = true;
        }
        void rdoCusOrder_Changed(object sender, EventArgs e)
        {
            if (rdoQuotation.Checked)
                btnCustomerInvoice.Enabled = false;
            else
                btnCustomerInvoice.Enabled = true;
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
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("RowHeader", typeof(string));
                    dt.Columns.Add("Cost", typeof(decimal));
                    dt.Columns.Add("Qty", typeof(int));
                    dt.Columns.Add("Price", typeof(decimal));
                    dt.Columns.Add("FET", typeof(decimal));
                    dt.Columns.Add("Profit", typeof(decimal));
                    dt.Columns.Add("Margin", typeof(decimal));
                    dt.Columns.Add("Markup", typeof(decimal));

                    decimal Price = 0, FET = 0, TPrice = 0, Cost = 0, Profit = 0, Margin = 0, Markup = 0;
                    int Qty = 0;
                    string rowHeader = "Item";

                    DataTable dtiTypes = new DataTable();
                    dtiTypes = dbClass.obj.getItemTypes();

                    foreach (DataRow dr in dtiTypes.Rows)
                    {
                        string cInitial = Convert.ToString(dr["Initial"]);
                        string cName = Convert.ToString(dr["Name"]);
                        foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                        {
                            if (n.Cells["CType"].Value != null)
                            {
                                if (Convert.ToString(n.Cells["CType"].Value) == cInitial)
                                {
                                    rowHeader = cName;
                                    if (n.Cells["Amount"].Value != null)
                                    {
                                        Price = Convert.ToDecimal(n.Cells["Amount"].Value);
                                    }
                                    if (n.Cells["FET"].Value != null)
                                    {
                                        FET = Convert.ToDecimal(n.Cells["FET"].Value);
                                    }
                                    TPrice = Price + FET;
                                    if (n.Cells["Qty"].Value != null)
                                    {
                                        Qty = Convert.ToInt32(n.Cells["Qty"].Value);
                                    }
                                    if (n.Cells["Cost"].Value != null)
                                    {
                                        Cost = (Convert.ToDecimal(n.Cells["Cost"].Value) * Convert.ToDecimal(n.Cells["Qty"].Value));
                                    }
                                    Profit = (Price - Cost);
                                    if (TPrice > 0)
                                        Margin = ((TPrice - Cost) / TPrice) * 100;
                                    if (Cost > 0)
                                        Markup = ((TPrice - Cost) / Cost) * 100;

                                    if (Price > 0)
                                    {
                                        DataRow dtnRow = dt.NewRow();
                                        dtnRow["RowHeader"] = cName;
                                        dtnRow["Cost"] = Math.Round(Cost);
                                        dtnRow["Qty"] = Qty;
                                        dtnRow["Price"] = Math.Round(Price, 2);
                                        dtnRow["FET"] = Math.Round(FET);
                                        dtnRow["Profit"] = Math.Round(Profit, 2);
                                        dtnRow["Margin"] = Math.Round(Margin);
                                        //dtnRow["Markup"] = Math.Round(Markup);
                                        dt.Rows.Add(dtnRow);
                                    }
                                }
                            }
                        }
                    }
                    decimal _Price = 0, _FET = 0, _Cost = 0, _Profit = 0, _Margin = 0, _Markup = 0;
                    int _TQty = 0;
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Cost"] != null)
                            {
                                _Cost += Convert.ToDecimal(dt.Rows[i]["Cost"]);
                            }
                            if (dt.Rows[i]["Qty"] != null)
                            {
                                _TQty += Convert.ToInt32(dt.Rows[i]["Qty"]);
                            }
                            if (dt.Rows[i]["Price"] != null)
                            {
                                _Price += Convert.ToDecimal(dt.Rows[i]["Price"]);
                            }
                            if (dt.Rows[i]["FET"] != null)
                            {
                                _FET += Convert.ToDecimal(dt.Rows[i]["FET"]);
                            }
                            if (dt.Rows[i]["Profit"] != null)
                            {
                                _Profit += Convert.ToDecimal(dt.Rows[i]["Profit"]);
                            }
                            if (dt.Rows[i]["Margin"] != null)
                            {
                                _Margin += Convert.ToDecimal(dt.Rows[i]["Margin"]);
                            }
                        }

                        DataRow dtnRow = dt.NewRow();
                        dtnRow["RowHeader"] = "Total";
                        dtnRow["Cost"] = Math.Round(_Cost);
                        dtnRow["Qty"] = _TQty;
                        dtnRow["Price"] = Math.Round(_Price, 2);
                        dtnRow["FET"] = Math.Round(_FET);
                        dtnRow["Profit"] = Math.Round(_Profit, 2);
                        dtnRow["Margin"] = Math.Round(_Margin);
                        //dtnRow["Markup"] = Math.Round(Markup);
                        dt.Rows.Add(dtnRow);

                        ctrProfitBreakDown ctrProfitBreakDown = new ctrProfitBreakDown(dt);
                        frmCtr frmCtr = new frmCtr("Profit Break Down ...");
                        frmCtr.Height = ctrProfitBreakDown.Height + 20; frmCtr.Width = ctrProfitBreakDown.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(ctrProfitBreakDown);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    xMessageBox.Show(ex.Message);
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
                CustomerPriceLevel = priceLevel;
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
        void btnVehicleEdit_Click(object sender, EventArgs e)
        {
            int VehicleID = 0;
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["VehicleID"] != DBNull.Value)
                VehicleID = Convert.ToInt32(curRow["VehicleID"]);

            if (VehicleID > 0)
            {
                ctrVehicle EditVehicle = new ctrVehicle(VehicleID, CustID, "Edit");
                frmCtr frmCtr = new frmCtr("Edit Selected Vehicle ...");
                frmCtr.Height = EditVehicle.Height - 220; frmCtr.Width = EditVehicle.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(EditVehicle);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();

                SetVehicle(VehicleID);
            }

        }
        void btnAddCatalog_Click(object sender, EventArgs e)
        {
            LoadCatalog_CellClick();
        }
        void txtCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.CustID > 0)
                {
                    if (!string.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    {
                        DataTable dt;
                        //---------------------------------------------------------------
                        int ItemID = dbClass.obj.getItemIDByCatalog(txtCatalog.Text.Trim());
                        if (ItemID > 0)
                        {
                            dt = dbClass.obj.getItemForGridByItemID(ItemID, this.CustID, this.CustomerPriceLevel);
                            if (dt != null)
                            {
                                DataRow dataRow = dt.Rows[0];
                                if (dataRow != null)
                                {
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                    txtCatalog.Text = "";
                                }
                            }
                        }
                        else
                        {
                            int FeeID = dbClass.obj.getFeeIDByCatalog(txtCatalog.Text.Trim());
                            if (FeeID > 0)
                            {
                                dt = dbClass.obj.getFeeForGridByFeeID(FeeID, this.CustID);
                                if (dt != null)
                                {
                                    DataRow dataRow = dt.Rows[0];
                                    if (dataRow != null)
                                    {
                                        AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                        txtCatalog.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                int LaborID = dbClass.obj.getLaborIDByCatalog(txtCatalog.Text.Trim());
                                if (LaborID > 0)
                                {
                                    dt = dbClass.obj.getLaborForGridByLaborID(LaborID, this.CustID);
                                    if (dt != null)
                                    {
                                        DataRow dataRow = dt.Rows[0];
                                        if (dataRow != null)
                                        {
                                            AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                            txtCatalog.Text = "";
                                        }
                                    }
                                }
                                else
                                {
                                    int PackageID = dbClass.obj.getPackageIDByCatalog(txtCatalog.Text.Trim());
                                    if (PackageID > 0)
                                    {
                                        dt = dbClass.obj.getPackageForGridByPackageID(PackageID);
                                        if (dt != null)
                                        {
                                            DataRow dataRow = dt.Rows[0];
                                            if (dataRow != null)
                                            {
                                                AddServiceInGrid_ObjectSelected(sender, dataRow);
                                                txtCatalog.Text = "";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        xMessageBox.Show("Catalog not Matched ...");
                                        txtCatalog.Focus();
                                    }
                                }
                            }
                        }

                    }
                }
                txtCatalog.Focus();
            }
        }
        void btnRecommendedServices_Click(object sender, EventArgs e)
        {
            if (this.CustID <= 0)
            {
                xMessageBox.Show("Select Customer for Workorder..");
                return;
            }
            if (this.VehicleID <= 0)
            {
                xMessageBox.Show("Select Vehicle for Workorder..");
                return;
            }

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            ctrVehicleInspection objList = new ctrVehicleInspection(curRow);
            objList.SelectVehicleInspectionDetail += objList_SelectVehicleInspectionDetail;
            frmCtr frmCtr = new frmCtr("Vehicle Inspection ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void objList_SelectVehicleInspectionDetail(object sender, DataTable dataTable)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        decimal PackageTotal = 0;
                        Int32 VehicleInspectionID = 0;
                        //--------------------------------------------------------------------------------//
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            VehicleInspectionID = Convert.ToInt32(dataRow["MID"]);
                            PackageTotal += Convert.ToDecimal(dataRow["TotalPrice"]);
                        }
                        //----------------------Add Inspection Header-------------------------------------//
                        DataRowView newRow = (DataRowView)DGVWorkOrder.objBindingSource.AddNew();
                        newRow.BeginEdit();
                        newRow["VehicleInspectionID"] = VehicleInspectionID;

                        newRow["Catalog"] = "Inspection Head";
                        newRow["Name"] = "Inspection Head";
                        newRow["Ctype"] = "IH";
                        newRow["Available"] = 0;
                        newRow["Qty"] = 1;

                        newRow["Price"] = PackageTotal;
                        newRow["Cost"] = PackageTotal;
                        newRow["Amount"] = PackageTotal;
                        newRow["DiscPer"] = 0;
                        newRow["DiscAmount"] = 0;
                        newRow["FET"] = 0;
                        newRow["Total"] = PackageTotal;
                        newRow["MarginPer"] = 0;

                        newRow["Active"] = true;
                        newRow["AddDate"] = DateTime.Now;
                        newRow["AddUserID"] = StaticInfo.userid;
                        newRow["IsLocked"] = false;
                        newRow.EndEdit();
                        //----------------------Add Inspection Items-------------------------------------//
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            DataRowView newItemRow = (DataRowView)DGVWorkOrder.objBindingSource.AddNew();
                            newItemRow.BeginEdit();
                            if (dataRow["InspectionHeadID"] != DBNull.Value)
                            {
                                newItemRow["InspectionHeadID"] = dataRow["InspectionHeadID"];
                                newItemRow["VehicleInspectionID"] = VehicleInspectionID;
                            }
                            newItemRow["Ctype"] = "P";

                            newItemRow["Catalog"] = dataRow["Catalog"];
                            newItemRow["Name"] = dataRow["CategoryItem"];

                            newItemRow["Available"] = 0;
                            newItemRow["Qty"] = 1;
                            newItemRow["Hours"] = 0;
                            newItemRow["IsDiscountable"] = false;
                            newItemRow["Price"] = dataRow["TotalPrice"];
                            newItemRow["Cost"] = dataRow["TotalPrice"];
                            newItemRow["Amount"] = dataRow["TotalPrice"];
                            newItemRow["DiscPer"] = 0;
                            newItemRow["DiscAmount"] = 0;
                            newItemRow["FET"] = 0;
                            newItemRow["Total"] = dataRow["TotalPrice"];

                            newItemRow["IsMechComm"] = 0;

                            newItemRow["MarginPer"] = 0;
                            newItemRow["MarginAmount"] = 0;

                            newItemRow["IsRepComm"] = 0;

                            newItemRow["Rep"] = dbClass.obj.getUserInitial(StaticInfo.userid);
                            newItemRow["IsDone"] = false;
                            newItemRow["IsTax"] = false;
                            newItemRow["SaleTaxRate"] = StaticInfo.SaleTaxPartsRate;
                            if (Convert.ToBoolean(newItemRow["IsTax"]))
                                newItemRow["Tax"] = Math.Round((Convert.ToDecimal(dataRow["TotalPrice"]) * StaticInfo.SaleTaxPartsRate) / 100, 2);
                            else
                                newItemRow["Tax"] = 0;

                            newItemRow["Active"] = true;
                            newItemRow["AddDate"] = DateTime.Now;
                            newItemRow["AddUserID"] = StaticInfo.userid;
                            newItemRow["IsLocked"] = false;
                            newItemRow.EndEdit();
                        }
                        //ChangePackageHeader();
                    }
                }
            }
            catch { }
        }
        void btnClickServices_Click(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                LoadService_CellClick();
        }
        void btnNewVehicle_Click(object sender, EventArgs e)
        {
            ctrVehicle EditVehicle = new ctrVehicle(this.CustID, "Add");
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("New Vehicle ...");
            frmCtr.Height = EditVehicle.Height - 220; frmCtr.Width = EditVehicle.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(EditVehicle);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();

            this.VehicleID = EditVehicle.VehID;

            if (this.VehicleID > 0)
                SetVehicle(this.VehicleID);
        }
        void btnVehicles_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["CustomerID"] != DBNull.Value)
                this.CustID = Convert.ToInt32(curRow["CustomerID"]);

            if (this.CustID > 1)
            {
                frmCtr ctrfrmCtr;
                ctrVehicleList ctrVehicleList = new ctrVehicleList(this.CustID);
                ctrVehicleList.VehicleSelected += AddVehicleDetail_ObjectSelected;
                ctrfrmCtr = new frmCtr("Select Vehicle ...");
                ctrfrmCtr.Height = ctrVehicleList.Height + 40; ctrfrmCtr.Width = ctrVehicleList.Width + 20;
                ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                ctrfrmCtr.frmPnl.Controls.Add(ctrVehicleList);
                ctrfrmCtr.BringToFront();
                ctrfrmCtr.ShowDialog();
            }
            else
                xMessageBox.Show("First Select Customer for Vehicle.....");
        }
        void ctrNoVehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)// 
            {
                if (ctrNoVehicle.Checked)
                {
                    btnNewVehicle.Enabled = false;
                    btnVehicles.Enabled = false;
                    btnVehicleEdit.Enabled = false;
                    SetVehicle(0);
                }
                else
                {
                    btnNewVehicle.Enabled = true;
                    btnVehicles.Enabled = true;
                    btnVehicleEdit.Enabled = true;
                }
            }
        }
        void btnEditCust_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["CustomerID"] != DBNull.Value)
                CustID = Convert.ToInt32(curRow["CustomerID"]);

            if (CustID > 1)
            {
                //this.IsNewCustomer = false;
                //CustomerPanel.Enabled = false;
                ctrCustomer EditCustomer = new ctrCustomer(CustID, "Edit");
                frmCtr frmCtr = new frmCtr("Edit Selected Customer ...");
                frmCtr.Height = EditCustomer.Height - 220; frmCtr.Width = EditCustomer.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(EditCustomer);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();

                SetCustomer(CustID);
            }
            else
                xMessageBox.Show("This customer is not editable ...");
        }
        void btnNewCust_Click(object sender, EventArgs e)
        {
            //this.SetCustomer(0);
            //CustomerPanel.Enabled = false;
            frmCtr ctrfrmCtr;
            ctrCustomer ctrCustomer = new ctrCustomer();
            //ctrCustomerList.CustomerSelected += AddCustomerDetail_ObjectSelected;
            ctrfrmCtr = new frmCtr();
            ctrfrmCtr.Height = ctrCustomer.Height + 40; ctrfrmCtr.Width = ctrCustomer.Width + 20;
            ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ctrfrmCtr.frmPnl.Controls.Add(ctrCustomer);
            ctrfrmCtr.BringToFront();
            ctrfrmCtr.ShowDialog();
        }
        void ctrWorkOrder_Load(object sender, EventArgs e)
        {
            DGVWorkOrder.Columns["Price"].ReadOnly = true;
            bool AccessSales = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '008'");
            if (row.Count() > 0)
            {
                if (row[0]["CanView"] != DBNull.Value)
                    AccessSales = Convert.ToBoolean(row[0]["CanView"]);
            }
            DataRow[] rowPriceLevel = StaticInfo.UserRights.Select("Code = '048'");

            if (rowPriceLevel.Count() > 0)
            {
                if (rowPriceLevel[0]["CanView"] != DBNull.Value)
                {
                    ctrPriceLevelID.Enabled = Convert.ToBoolean(rowPriceLevel[0]["CanView"]);
                }
            }
            DataRow[] rowPriceChange = StaticInfo.UserRights.Select("Code = '049'");

            if (rowPriceChange.Count() > 0)
            {
                if (rowPriceChange[0]["CanView"] != DBNull.Value)
                {
                    DGVWorkOrder.Columns["Price"].ReadOnly = !Convert.ToBoolean(rowPriceChange[0]["CanView"]);
                }
            }

            if (!AccessSales)
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Sales.");
                //this.Parent.Dispose();                                
                this.BeginInvoke(new MethodInvoker(this.ParentForm.Close));
            }
            else
            {
                if ((this.WorkOrderID <= 0) && (this.ctrMode > 0))
                {
                    bindingNavigatorAddNewItem_Click(sender, e);
                }
                else if (this.WorkOrderID > 0)
                {
                    dbClass.obj.fillTablesByIDOrderBy(objDataSet.Tables[this.xTableName], objDataSet.Tables[this.DGVWorkOrder.xTableName], this.DGVWorkOrder.xTableQuery, this.WorkOrderID, this.DGVWorkOrder.xOrderBy);
                    int VehicleID = dbClass.obj.getVehicleIDByWorkOrder(this.WorkOrderID);

                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    if (curRow["CustomerID"] != DBNull.Value)
                        this.SetCustomer(Convert.ToInt32(curRow["CustomerID"]));
                    if (VehicleID > 0)
                        this.SetVehicle(VehicleID);
                }
                //----------------------------------------------------------//
                TSMItem1.Visible = true;
                TSMItem1.Text = "Customer Invoice";

                TSMItem2.Visible = true;
                TSMItem2.Text = "Print Invoice";

                TSMItem3.Visible = true;
                TSMItem3.Text = "Void";

                TSMItem4.Visible = true;
                TSMItem4.Text = "Deposit";
                //----------------------------------------------------------//
                setWOToggleColumns();
            }
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
        void btnChangeCust_Click(object sender, EventArgs e)
        {
            frmCtr ctrfrmCtr;
            ctrCustomerList ctrCustomerList = new ctrCustomerList();
            ctrCustomerList.CustomerSelected += AddCustomerDetail_ObjectSelected;
            ctrfrmCtr = new frmCtr("Select Customer ...");
            ctrfrmCtr.Height = ctrCustomerList.Height + 40; ctrfrmCtr.Width = ctrCustomerList.Width + 20;
            ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ctrfrmCtr.frmPnl.Controls.Add(ctrCustomerList);
            ctrfrmCtr.BringToFront();
            ctrfrmCtr.ShowDialog();

        }
        void SetCustomer(int CustID)
        {
            DataRow CustomerRow = dbClass.obj.getCustomerByID(CustID);
            if (CustomerRow == null)
                CustomerRow = dbClass.obj.getTop1Customer();

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
                decimal CreditAvail = dbClass.obj.getCreditAvailbyCustomerID(this.CustID);
                if (CustomerRow["CreditLimits"] != DBNull.Value)
                {
                    if (Convert.ToDecimal(CustomerRow["CreditLimits"]) > 0)
                    {
                        decimal AvailableCredit = Convert.ToDecimal(CustomerRow["CreditLimits"]) - CreditAvail;
                        lblCreditAvailable.Text = "Available Credit: " + String.Format("{0:c}", AvailableCredit);
                        lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                    }
                    else
                    {
                        lblCreditAvailable.Text = "Available Credit: " + String.Format("{0:c}", -1 * CreditAvail);
                        lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                    }
                }
                else
                {
                    lblCreditAvailable.Text = "Available Credit: " + String.Format("{0:c}", -1 * CreditAvail);
                    lblCreditLimit.Text = "Credit Limit:  " + StaticInfo.MainCurSign + Convert.ToDecimal(CustomerRow["CreditLimits"]);
                }

                curRow.EndEdit();
            }

            if (this.CustID <= 1)
            {
                ctrNoVehicle.Enabled = false;
                btnVehicles.Enabled = false;
                btnNewVehicle.Enabled = false;
                btnVehicleEdit.Enabled = false;
            }
            else
            {
                ctrNoVehicle.Enabled = true;
                btnVehicles.Enabled = true;
                btnNewVehicle.Enabled = true;
                btnVehicleEdit.Enabled = true;
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
        void ShowCost()
        {
            bool CostShow = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '004'");
            if (row[0]["CanView"] != DBNull.Value)
                CostShow = Convert.ToBoolean(row[0]["CanView"]);
            if (CostShow)
                DGVWorkOrder.Columns["Cost"].Visible = true;
            else
                DGVWorkOrder.Columns["Cost"].Visible = false;
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int NextAutoNo = dbClass.obj.getNextWorkOrderAutoNo();

            base.bindingNavigatorAddNewItem_Click(sender, e);

            if (this.ctrMode < 0)
            {
                this.ctrMode = 0;
                this.CustID = 1;
                this.WorkOrderID = 0;
            }
            this.SetCustomer(this.CustID);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["WorkOrderNo"] = NextAutoNo;

            curRow["RegDate"] = DateTime.Now;

            curRow["CreatedByID"] = StaticInfo.userid;
            curRow["SaleRepID"] = StaticInfo.userid;
            curRow["IsWorkOrder"] = false;
            curRow["IsQutation"] = false;
            curRow["IsCustomerOrder"] = false;

            if ((this.ctrMode == 0) || (this.ctrMode == 1) || (this.ctrMode == 3))
                curRow["IsWorkOrder"] = true;
            else if ((this.ctrMode == 2) || (this.ctrMode == 4))
                curRow["IsQutation"] = true;

            curRow["Status"] = "W/O";
            curRow["IsNegated"] = false;
            curRow.EndEdit();
            //------------------------------------
            base.DataNavigation();
            //------------------------------------
            txtCatalog.Enabled = true; txtCatalog.ReadOnly = false;
            btnCustomerInvoice.Enabled = true;
            btnPrintInvoice.Enabled = true;
            ShowCost();
            //------------------------------------
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorEditItem_Click(sender, e);
            ctrNoVehicle_CheckedChanged(sender, e);
            //------------------------------------
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

            txtCatalog.Enabled = true; txtCatalog.ReadOnly = false;
            if (rdoQuotation.Checked)
                btnCustomerInvoice.Enabled = false;
            else
                btnCustomerInvoice.Enabled = true;
            ShowCost();
            //------------------------------------
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["CustomerID"] == null)
            {
                xMessageBox.Show("Add Customer for this Workorder ...");
                return;
            }
            if (Convert.ToDecimal(curRow["Total"]) <= 0)
            {
                xMessageBox.Show("Add Items in Workorder ...");
                return;
            }

            base.bindingNavigatorSaveItem_Click(sender, e);
            if (CustomValidation(true))
            {
                //this.ctrMode = 0; this.CustID = 1;
                //if (Convert.ToInt32(curRow["ID"]) >= 1)
                //{
                //    if(StaticInfo.IsLoginForWarehouse)
                //        StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportWareHouseCopy", "byID", Convert.ToInt32(curRow["ID"]));
                //}
            }
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorCancelItem_Click(sender, e);
            this.ctrMode = 0; this.CustID = 1;

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                btnCustomerInvoice.Enabled = true;
                btnPrintInvoice.Enabled = true;
            }
            else
            {
                btnCustomerInvoice.Enabled = false;
                btnPrintInvoice.Enabled = false;
            }
        }
        protected override void TSMItem1_Click(object sender, EventArgs e)
        {
            //btnCustomerInvoice.Enabled = false;
            //DataRowView curRow1 = (DataRowView)objBindingSource.Current;
            //if (curRow1["CustomerID"] == null)
            //{
            //    xMessageBox.Show("Add Customer for this Workorder ...");
            //    return;
            //}
            //if (Convert.ToDecimal(curRow1["Total"]) <= 0)
            //{
            //    xMessageBox.Show("Add Items in Workorder ...");
            //    return;
            //}
            this.frmStatus = currentStatus.Load;
            this.objBindingSource.EndEdit();

            if (base.bindingNavigatorSaveItemClick(sender, e))
            {
                this.BaseEnableDisble(this.frmStatus);
            }
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
            {
                DataTable dt = new DataTable();

                bool NoStock = false;
                dt = dbClass.obj.getItemStockStatusByWOID(Convert.ToInt32(curRow["ID"]));
                Decimal PastDue = dbClass.obj.getPastDueAmountbyCustomerID(Convert.ToInt32(curRow["CustomerID"]));

                foreach (DataRow Stock in dt.Rows)
                {
                    if (Stock["QtyOnHand"] != DBNull.Value)
                    {
                        int a = Convert.ToInt32(Stock["QtyOnHand"]);
                        if (a <= 0)
                            NoStock = false;
                        else
                            NoStock = true;
                    }
                }

                bool AllowNoStock = false;
                DataRow[] row = StaticInfo.UserRights.Select("Code = '017'");
                if (row[0]["CanView"] != DBNull.Value)
                    AllowNoStock = Convert.ToBoolean(row[0]["CanView"]);

                bool AllowPastDue = false;
                DataRow[] row2 = StaticInfo.UserRights.Select("Code = '016'");
                if (row2[0]["CanView"] != DBNull.Value)
                    AllowPastDue = Convert.ToBoolean(row2[0]["CanView"]);

                if (AllowNoStock || NoStock)
                {
                    if (AllowPastDue || PastDue <= 0)
                    {
                        this.ParentForm.Close();
                        ctrCustomerReceipt objList = new ctrCustomerReceipt(Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        //objList.ObjectSelected += AddCatalogInGrid_ObjectSelected;
                        frmCtr frmCtr = new frmCtr("Customer Receipt ...");
                        frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(objList);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                    }
                    else
                        xMessageBox.Show("You can't Invoice with Past Due.");
                }
                else
                    xMessageBox.Show("You can't Invoice with not enough Stock.");
            }
        }
        protected override void TSMItem2_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToBoolean(curRow["IsQutation"]))
            {
                if (Convert.ToInt32(curRow["ID"]) > 0)
                    StaticInfo.LoadToReport("RptModule", "Reports.QuotationReport", "byID", Convert.ToInt32(curRow["ID"]));
            }
            else
            {
                if (Convert.ToInt32(curRow["ID"]) >= 1)
                    StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReport", "byID", Convert.ToInt32(curRow["ID"]));
            }
        }
        //bool UpdateVoucherMaster()
        //{
        //    bool status = false;
        //    dbClass db = new dbClass();
        //    string vID = db.getNextVoucherNo();
        //    int WID = db.getLatestWorkOrderNo();
        //    DataTable dt = objDataSet.Tables["AccountVoucher"].Copy();

        //    //dt.Columns.Add(new DataColumn("woID", typeof(Int32)));
        //    try
        //    {
        //        //decimal PartsPrice = 0, LaborPrice = 0, OtherPrice = 0, FETA = 0, Taxable = 0, TaxA = 0, Discount = 0, TotalA = 0;
        //        DataRow dtnRow = dt.NewRow();

        //        dtnRow["vNo"] = vID;
        //        dtnRow["vtype"] = "Sales";
        //        dtnRow["vDate"] = DateTime.Now;
        //        dtnRow["IsVoid"] = 0;

        //        dtnRow["AccountID"] = 21;
        //        dtnRow["Remarks"] = "W/O";

        //        dtnRow["WOID"] = WID;
        //        //dtnRow["POID"] = null;
        //        dtnRow["vforVendor"] = 0;
        //        dtnRow["vforCustomer"] = 1;
        //        dtnRow["vforEmployee"] = 0;


        //        dtnRow["CustomerID"] = this.CustID;
        //        dtnRow["EmployeeID"] = StaticInfo.userid;
        //        dtnRow["Narration"] = "";

        //        dtnRow["PAmount"] = txtParts.Text;
        //        dtnRow["LAmount"] = txtLabour.Text;
        //        dtnRow["FAmount"] = txtFEE.Text;
        //        dtnRow["FET"] = txtFET.Text;
        //        dtnRow["Taxable"] = txtTaxable.Text;
        //        dtnRow["Tax"] = txtTax.Text;
        //        dtnRow["Discount"] = txtDiscount.Text;
        //        dtnRow["Total"] = txtTotal.Text;
        //        dtnRow["vAmount"] = txtTotal.Text;
        //        dtnRow["AddDate"] = DateTime.Now;
        //        dtnRow["AddUserID"] = StaticInfo.userid;
        //        dtnRow["Comments"] = "";
        //        dtnRow["IsLocked"] = 0;
        //        dtnRow["DocNo"] = dtnRow["vtype"] + ":" + dtnRow["Remarks"];
        //        dtnRow["CoFinEndYear"] = DateTime.Now.Year;
        //        dtnRow["Active"] = 1;
        //        dt.Rows.Add(dtnRow);
        //        //status = db.AddNewVoucher(dt);
        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        xMessageBox.Show(ex.ToString());
        //        return status;
        //    }
        //}
        //void UpdateVoucherDetails()
        //{
        //    dbClass db = new dbClass();
        //    int WID = db.getLatestWorkOrderNo();
        //    int vID = db.getLatestVoucherNo();
        //    DataTable dt = objDataSet.Tables["AccountVoucherDetails"].Copy();

        //    decimal TotalAmount = 0;
        //    decimal TotalTire = 0;
        //    decimal TotalParts = 0;
        //    decimal TotalOutsideParts = 0;
        //    decimal TotalWheels = 0;
        //    decimal TotalLabour = 0;
        //    decimal TotalFEE = 0;
        //    decimal TotalOthers = 0;
        //    decimal TotalFET = 0;
        //    decimal TotalTax = 0;
        //    //dt.Columns.Add(new DataColumn("woID", typeof(Int32)));
        //    try
        //    {
        //        foreach (DataGridViewRow n in DGVWorkOrder.Rows)
        //        {
        //            if (n.Cells["CType"].Value != null)
        //            {
        //                DataRow dtnRow = dt.NewRow();
        //                dtnRow["vNo"] = WID;
        //                dtnRow["MID"] = vID;
        //                dtnRow["vtype"] = "Sales";
        //                dtnRow["vDate"] = DateTime.Now;
        //                if (n.Cells["Price"].Value != null)
        //                {
        //                    dtnRow["Price"] = n.Cells["Price"].Value;
        //                }
        //                if (n.Cells["Cost"].Value != null)
        //                {
        //                    dtnRow["Cost"] = n.Cells["Cost"].Value;
        //                }
        //                if (n.Cells["Amount"].Value != null)
        //                {
        //                    dtnRow["Amount"] = n.Cells["Amount"].Value;
        //                }
        //                if (n.Cells["DiscAmount"].Value != null)
        //                {
        //                    dtnRow["Discount"] = n.Cells["DiscAmount"].Value;
        //                }

        //                if (n.Cells["Tax"].Value != null)
        //                {
        //                    dtnRow["Tax"] = n.Cells["Tax"].Value;
        //                    TotalTax += Convert.ToDecimal(n.Cells["Tax"].Value);
        //                }
        //                if (n.Cells["FET"].Value != null)
        //                {
        //                    dtnRow["FET"] = n.Cells["FET"].Value;
        //                    TotalFET += Convert.ToInt32(n.Cells["FET"].Value);
        //                }
        //                if (n.Cells["Total"].Value != null)
        //                {
        //                    dtnRow["Total"] = n.Cells["Total"].Value;
        //                }
        //                if (n.Cells["CType"].Value.ToString() == "P")
        //                {
        //                    dtnRow["Narration"] = "Sales:Parts";
        //                    dtnRow["ItemID"] = n.Cells["ItemID"].Value;
        //                    TotalParts += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else if (n.Cells["CType"].Value.ToString() == "W")
        //                {
        //                    dtnRow["Narration"] = "Sales:Parts";
        //                    dtnRow["ItemID"] = n.Cells["ItemID"].Value;
        //                    TotalWheels += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else if (n.Cells["CType"].Value.ToString() == "T")
        //                {
        //                    dtnRow["Narration"] = "Sales:Auto Tires";
        //                    dtnRow["ItemID"] = n.Cells["ItemID"].Value;
        //                    TotalTire += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else if (n.Cells["CType"].Value.ToString() == "L")
        //                {
        //                    dtnRow["Narration"] = "Sales:Labour";
        //                    dtnRow["LabourID"] = n.Cells["ItemID"].Value;
        //                    TotalLabour += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else if (n.Cells["CType"].Value.ToString() == "F")
        //                {
        //                    dtnRow["Narration"] = "Sales:Fee";
        //                    dtnRow["FeeID"] = n.Cells["ItemID"].Value;
        //                    TotalFEE += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else if (n.Cells["CType"].Value.ToString() == "OP")
        //                {
        //                    dtnRow["Narration"] = "Sales:Outside Parts";
        //                    dtnRow["ItemID"] = n.Cells["ItemID"].Value;
        //                    TotalOutsideParts += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }
        //                else
        //                {
        //                    dtnRow["Narration"] = "Sales:Others";
        //                    dtnRow["ItemID"] = n.Cells["ItemID"].Value;
        //                    TotalOthers += Convert.ToDecimal(n.Cells["Price"].Value);
        //                }

        //                dtnRow["Qty"] = n.Cells["Qty"].Value;
        //                dtnRow["Hours"] = n.Cells["Hours"].Value;
        //                dtnRow["vforVendor"] = 0;
        //                dtnRow["vforCustomer"] = 1;
        //                dtnRow["vforEmployee"] = 0;
        //                dtnRow["VendorID"] = 0;
        //                dtnRow["CustomerID"] = this.CustID;
        //                dtnRow["EmployeeID"] = StaticInfo.userid;

        //                dtnRow["SubAccount"] = dtnRow["Narration"];
        //                dtnRow["AmountIn"] = n.Cells["Amount"].Value;
        //                dtnRow["AmountOut"] = 0.00;
        //                dtnRow["Remarks"] = "";
        //                dtnRow["vAmount"] = n.Cells["Amount"].Value;
        //                dtnRow["AddDate"] = DateTime.Now;
        //                dtnRow["AddUserID"] = StaticInfo.userid;
        //                dtnRow["Comments"] = "";
        //                dtnRow["IsLocked"] = 0;
        //                dtnRow["CoFinEndYear"] = DateTime.Now.Year;
        //                dtnRow["Active"] = 1;

        //                dt.Rows.Add(dtnRow);
        //            }
        //            TotalAmount = Convert.ToDecimal(txtTotal.Text);
        //        }
        //        db.AddVoucherDetails(dt, TotalAmount, TotalParts, TotalOutsideParts, TotalTire, TotalWheels, TotalFEE, TotalFET, TotalLabour, TotalOthers, TotalTax);
        //    }
        //    catch (Exception ex)
        //    {
        //        xMessageBox.Show(ex.ToString());
        //    }
        //    ////if ((Convert.ToString(n.Cells["CType"].Value) == "T")
        //    ////     || (Convert.ToString(n.Cells["CType"].Value) == "P")
        //    ////     || (Convert.ToString(n.Cells["CType"].Value) == "M")
        //    ////     || (Convert.ToString(n.Cells["CType"].Value) == "OP")
        //    ////     || (Convert.ToString(n.Cells["CType"].Value) == "OT")
        //    ////     || (Convert.ToString(n.Cells["CType"].Value) == "R")
        //    ////    || (Convert.ToString(n.Cells["CType"].Value) == "U"))
        //}
        protected override void TSMItem3_Click(object sender, EventArgs e)
        {

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
                    string DGVColumnName = DGVWorkOrder.Columns[e.ColumnIndex].DataPropertyName;
                    switch (DGVColumnName)
                    {
                        case "Catalog":
                            break;
                        case "MechanicID":
                            this.Mechanic.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
                            break;
                        case "":
                            if (DGVWorkOrder.Columns[e.ColumnIndex].Name.Equals("DelColumn"))
                            {
                                if (((DGVWorkOrder.Rows[e.RowIndex].Cells["PackageID"].Value) == DBNull.Value) && ((DGVWorkOrder.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value) == DBNull.Value))
                                {
                                    if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        DGVWorkOrder.objBindingSource.Remove(DGVWorkOrder.objBindingSource.Current);
                                        DGVWorkOrder.objBindingSource.EndEdit();
                                    }
                                }
                                else
                                {
                                    if (xMessageBox.Show("Do you want to delete this Package..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        if ((DGVWorkOrder.Rows[e.RowIndex].Cells["PackageID"].Value) != DBNull.Value)
                                        {
                                            int packageID = Convert.ToInt32(DGVWorkOrder.Rows[e.RowIndex].Cells["PackageID"].Value);
                                            if (packageID > 0)
                                                DeletePackageItemsFromGrid(packageID);
                                        }
                                        else if ((DGVWorkOrder.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value) != DBNull.Value)
                                        {
                                            int VehicleInspectionID = Convert.ToInt32(DGVWorkOrder.Rows[e.RowIndex].Cells["VehicleInspectionID"].Value);
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
                for (int j = DGVWorkOrder.Rows.Count; j > 0; j--)
                {
                    if (DGVWorkOrder.Rows[j - 1].Cells["PackageID"].Value != DBNull.Value)
                    {
                        if (Convert.ToInt32(DGVWorkOrder.Rows[j - 1].Cells["PackageID"].Value) == packageID)
                            DGVWorkOrder.Rows[j - 1].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in DGVWorkOrder.SelectedRows)
                {
                    DGVWorkOrder.Rows.Remove(row);
                }
            }
            catch { }
        }
        void DeleteInspectionItemsFromGrid(int VehicleInspectionID)
        {
            try
            {
                for (int j = DGVWorkOrder.Rows.Count; j > 0; j--)
                {
                    if (DGVWorkOrder.Rows[j - 1].Cells["VehicleInspectionID"].Value != DBNull.Value)
                    {
                        if (Convert.ToInt32(DGVWorkOrder.Rows[j - 1].Cells["VehicleInspectionID"].Value) == VehicleInspectionID)
                            DGVWorkOrder.Rows[j - 1].Selected = true;
                    }
                }
                foreach (DataGridViewRow row in DGVWorkOrder.SelectedRows)
                {
                    DGVWorkOrder.Rows.Remove(row);
                }
            }
            catch { }
        }
        void DGVWorkOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
                        if (DGVColumnName.Equals("Qty") || DGVColumnName.Equals("Price"))
                            curRow["Amount"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Price"]), 2);
                        if (DGVColumnName.Equals("Amount"))
                            curRow["Price"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Amount"]), 2);
                        if (DGVColumnName.Equals("DiscAmount"))
                        {
                            if (String.IsNullOrEmpty(curRow["DiscAmount"].ToString()))
                            {
                                curRow["DiscAmount"] = 0.00;
                            }
                            curRow["DiscPer"] = Math.Round((Convert.ToDecimal(curRow["DiscAmount"]) / Convert.ToDecimal(curRow["Amount"]) * 100), 0);
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(curRow["DiscPer"].ToString()))
                            {
                                curRow["DiscPer"] = 0.00;
                            }
                            curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);
                        }
                        if (curRow["DiscPer"].ToString() == "0")
                        {
                            curRow["DiscPer"] = 0.00;
                        }
                        if (curRow["DiscAmount"].ToString() == "0")
                        {
                            curRow["DiscAmount"] = 0.00;
                        }
                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                        if ((Convert.ToDecimal(curRow["Price"]) > 0) && (Convert.ToDecimal(curRow["Cost"]) > 0))
                            curRow["MarginPer"] = Math.Round((((Convert.ToDecimal(curRow["Price"]) - Convert.ToDecimal(curRow["Cost"])) * 100) / Convert.ToDecimal(curRow["Cost"])), 2);
                        if ((Convert.ToDecimal(curRow["MarginPer"]) > 0) && (Convert.ToDecimal(curRow["Cost"]) > 0))
                            curRow["MarginAmount"] = Math.Round((((Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"])) / 100) + Convert.ToDecimal(curRow["Cost"])), 2);
                        //if (curRow["IsTax"] != DBNull.Value)
                        //{
                        //    if (Convert.ToBoolean(curRow["IsTax"]))
                        //    {
                        //        if (StaticInfo.SaleTaxPartsRate > 0)
                        //        {
                        //            curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                        //            curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                        //        }
                        //    }
                        //}
                    }
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
                                if (StaticInfo.SaleTaxPartsRate > 0)
                                {
                                    curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                    curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
                                }
                            }
                        }
                    }
                }
                //----------------------------------------------
                curRow.EndEdit();
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
            //---------------------------------------------
            CalculateColumns2();
        }
        void LoadCatalog_CellClick()
        {
            ctrItemListForGrid objList = new ctrItemListForGrid(this.CustID, this.CustomerPriceLevel);
            objList.ObjectSelected += AddCatalogInGrid_ObjectSelected;
            frmCtr frmCtr = new frmCtr("Select Item ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
            //btnCustomerInvoice.Enabled = true;
            //btnPrintInvoice.Enabled = true;
        }
        void LoadPackage_CellClick()
        {
            ctrPackageListForGrid objList = new ctrPackageListForGrid();
            objList.ObjectSelected += AddPackageInGrid_ObjectSelected;
            frmCtr frmCtr = new frmCtr("Select Package ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
            //btnCustomerInvoice.Enabled = true;
            //btnPrintInvoice.Enabled = true;
        }
        void LoadService_CellClick()
        {
            if (this.CustID <= 0)
            {
                xMessageBox.Show("Select Customer for Work order..");
                return;
            }
            if (this.VehicleID <= 0)
            {
                xMessageBox.Show("Select Vehicle for Work order..");
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
        void AddPackageInGrid_ObjectSelected(object sender, DataSet Sdt, int packageID = 0)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    foreach (DataRow sdataRow in Sdt.Tables[1].Rows)
                    {
                        if (sdataRow != null)
                        {
                            DataTable dt = new DataTable();
                            DataRow dataRow = null;
                            if (sdataRow["ItemID"] != null && sdataRow["ItemID"].ToString() != "")
                            {
                                dataRow = dbClass.obj.GetItemByItemID(Convert.ToInt32(sdataRow["ItemID"]), Convert.ToInt32(sdataRow["Qty"]));
                                if (dataRow != null)
                                {
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                }
                            }
                            else if (sdataRow["FeeID"] != null && sdataRow["FeeID"].ToString() != "")
                            {
                                dataRow = dbClass.obj.GetItemByFeeID(Convert.ToInt32(sdataRow["FeeID"]), Convert.ToInt32(sdataRow["Qty"]));
                                if (dataRow != null)
                                {
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                }
                            }
                            else if (sdataRow["LaborID"] != null && sdataRow["LaborID"].ToString() != "")
                            {
                                dataRow = dbClass.obj.GetItemByLaborID(Convert.ToInt32(sdataRow["LaborID"]), Convert.ToInt32(sdataRow["Qty"]));
                                if (dataRow != null)
                                {
                                    AddCatalogInGrid_ObjectSelected(sender, dataRow);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }

        void AddCatalogInGrid_ObjectSelected(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                DataTable dt = new DataTable();
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
                            //string strQry = "Select * from Fees where ItemGroupID='"+ dataRow[] + "'";
                            //DataTable strCode = dbClass.obj.FillByQry(dt,strQry);
                            DataRowView newItemRow = (DataRowView)DGVWorkOrder.objBindingSource.AddNew();
                            newItemRow.BeginEdit();
                            if (packageID > 0)
                                newItemRow["PackageID"] = packageID;
                            if (dataRow["ItemID"] != DBNull.Value)
                                newItemRow["Cost"] = dataRow["CatalogCost"];
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
                            newItemRow["Qty"] = dataRow["Qty"];
                            newItemRow["Hours"] = dataRow["Hours"];
                            newItemRow["IsDiscountable"] = dataRow["IsDiscountable"];
                            //newItemRow["Price"] = dataRow["Price"];
                            newItemRow["Price"] = dataRow["Price"];

                            newItemRow["Amount"] = dataRow["Amount"];
                            newItemRow["DiscPer"] = dataRow["PartDisPer"];
                            newItemRow["DiscAmount"] = dataRow["PartDis"];
                            newItemRow["FET"] = dataRow["FET"];
                            decimal PartDis = 0;
                            if (dataRow["PartDis"] != DBNull.Value)
                                PartDis = Convert.ToDecimal(dataRow["PartDis"]);
                            decimal PartTax = 0;
                            if (dataRow["PartTax"] != DBNull.Value)
                                PartTax = Convert.ToDecimal(dataRow["PartTax"]);

                            newItemRow["Total"] = Convert.ToDecimal(dataRow["Total"]) - PartDis + PartTax;
                            newItemRow["Profit"] = Convert.ToDecimal(dataRow["Price"]) - Convert.ToDecimal(dataRow["CatalogCost"]) - PartDis;
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
                            if (ctrSaleCategoryID.Items.Count > 0)
                            {
                                if(ctrSaleTaxRateID.SelectedValue != null)
                                {
                                    if (ctrSaleTaxRateID.SelectedValue.ToString() == "1" && Convert.ToBoolean(dataRow["IsTaxable"]) && dataRow["Ctype"].ToString() != "L" && dataRow["Ctype"].ToString() != "F")
                                    {
                                        newItemRow["SaleTaxRate"] = StaticInfo.SaleTaxPartsRate;
                                        newItemRow["Tax"] = Math.Round((Convert.ToDecimal(dataRow["Price"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                    }
                                    else
                                    {
                                        newItemRow["SaleTaxRate"] = 0;
                                        newItemRow["Tax"] = 0;
                                    }
                                }
                            }
                            newItemRow["Active"] = true;
                            newItemRow["AddDate"] = DateTime.Now;
                            newItemRow["AddUserID"] = StaticInfo.userid;
                            newItemRow["IsLocked"] = false;
                            if(dataRow["IsTemporaryDiscount"] != DBNull.Value)
                            {
                                if (Convert.ToBoolean(dataRow["IsTemporaryDiscount"]))
                                {
                                    if (Convert.ToDateTime(dataRow["TemporaryDiscountDateFrom"]) < DateTime.Now && DateTime.Now < Convert.ToDateTime(dataRow["TemporaryDiscountDateTo"]))
                                    {
                                        newItemRow["DiscAmount"] = dataRow["TemporaryDiscountedPriceB"];
                                    }
                                }

                            }
                            if(dataRow["SpiffsDateFrom"] != DBNull.Value)
                            {
                                if (Convert.ToDateTime(dataRow["SpiffsDateFrom"]) < DateTime.Now && DateTime.Now < Convert.ToDateTime(dataRow["SpiffsDateTo"]))
                                {
                                    newItemRow["DiscAmount"] = dataRow["SpiffsDollarAmount"];
                                }
                            }
                            newItemRow.EndEdit();

                            btnCustomerInvoice.Enabled = true;
                            btnPrintInvoice.Enabled = true;
                            CalculatColumns();
                        }
                    }
                }
            }
            catch (Exception ex) { }
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
                            DataRowView newRow = (DataRowView)DGVWorkOrder.objBindingSource.AddNew();
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

                        }
                    }
                }
            }
            catch { }
        }
        void ChangePackageHeader()
        {
            //-------------------------------------------------------------------
            foreach (DataGridViewRow n in DGVWorkOrder.Rows)
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal price = 0;
                decimal discAmt = 0;
                decimal available = 0;
                if (n.Cells["CType"].Value != null)
                {
                    if ((Convert.ToString(n.Cells["CType"].Value) == "S") || (Convert.ToString(n.Cells["CType"].Value) == "IH"))
                    {
                        n.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                        n.DefaultCellStyle.BackColor = Color.Green;
                    }
                }

                if (n.Cells["Total"].Value != null)
                {
                    if (Convert.ToDecimal(n.Cells["Total"].Value) < 0)
                    {
                        n.Cells["Total"].Style.BackColor = Color.Red;
                    }
                }
                if (n.Cells["Available"].Value != DBNull.Value)
                    available = Convert.ToDecimal(n.Cells["Available"].Value);
                if (available < 0)
                {
                    n.Cells["Qty"].Style.BackColor = Color.Red;
                }
                if (n.Cells["Qty"].Value != DBNull.Value)
                    qty = Convert.ToDecimal(n.Cells["Qty"].Value);
                if (qty > available)
                {
                    n.Cells["Qty"].Style.BackColor = Color.Red;
                }

                if (n.Cells["Cost"].Value != DBNull.Value)
                    cost = Convert.ToDecimal(n.Cells["Cost"].Value);
                if (n.Cells["Price"].Value != DBNull.Value)
                    price = Convert.ToDecimal(n.Cells["Price"].Value);
                if (n.Cells["DiscAmount"].Value != DBNull.Value)
                    discAmt = Convert.ToDecimal(n.Cells["DiscAmount"].Value);

                if (cost > price)
                {
                    n.Cells["Price"].Style.BackColor = Color.Red;
                }
                if (cost < discAmt)
                {
                    n.Cells["DiscAmount"].Style.BackColor = Color.Red;
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
            decimal TotalDiscount = 0;
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                decimal PartDiscount = 0;
                decimal LaborDiscount = 0;
                int PartDisPer = Convert.ToInt32(ctrPartDisPer.Value);
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) != "L")
                        {
                            PartDiscount = 0;
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value == System.DBNull.Value)
                                {
                                    n.Cells["DiscPer"].Value = 0.00;
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] =  PartDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);

                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                }
                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] =  PartDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);

                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                }
                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                            }
                        }
                        if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        {
                            LaborDiscount = 0;
                            int LaborDisPer = Convert.ToInt32(ctrLaborDisPer.Value);
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value != System.DBNull.Value)
                                {
                                    n.Cells["DiscPer"].Value = 0.00;
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = LaborDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                }

                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = LaborDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
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
                TotalDiscount += PartDiscount;
                txtDiscount.Text = TotalDiscount.ToString();
            }
        }

        void ctrLaborDisPer_ValueChanged(object sender, EventArgs e)
        {
            //decimal LaborDiscount = 0;
            //if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            //{
            //    int LaborDisPer = Convert.ToInt32(ctrLaborDisPer.Value);
            //    foreach (DataGridViewRow n in DGVWorkOrder.Rows)
            //    {
            //        if (n.Cells["CType"].Value != null)
            //        {
            //            if (Convert.ToString(n.Cells["CType"].Value) == "L")
            //            {
            //                if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
            //                {
            //                    if (n.Cells["DiscPer"].Value != null)
            //                    {
            //                        if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
            //                        {
            //                            DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
            //                            editedRow.BeginEdit();
            //                            editedRow["DiscPer"] = LaborDisPer;
            //                            editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
            //                            editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);
            //                            TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);

            //                            if (editedRow["IsTax"] != DBNull.Value)
            //                            {
            //                                if (Convert.ToBoolean(editedRow["IsTax"]))
            //                                {                                                
            //                                        if (StaticInfo.SaleTaxPartsRate > 0)
            //                                        {
            //                                            editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
            //                                            editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
            //                                        }
            //                                }
            //                            }
            //                            editedRow.EndEdit();
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    TotalDiscount += LaborDiscount;
            //    txtDiscount.Text = TotalDiscount.ToString();
            //}
        }
        void CalculateColumns2()
        {
            //-------------------------------------------------------------            
            decimal PartsPrice = 0, TProfit = 0, LaborPrice = 0, OtherPrice = 0, FET = 0, Taxable = 0, Tax = 0, Discount = 0;
            foreach (DataGridViewRow n in DGVWorkOrder.Rows)
            {
                try
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        //if ((Convert.ToString(n.Cells["CType"].Value) == "T")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "P")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "M")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "OP")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "OT")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "R")
                        //    || (Convert.ToString(n.Cells["CType"].Value) == "U"))

                        if ((Convert.ToString(n.Cells["CType"].Value) != "L") && (Convert.ToString(n.Cells["CType"].Value) != "F"))
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                PartsPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                                TProfit += (Convert.ToDecimal(n.Cells["Price"].Value) - Convert.ToDecimal(n.Cells["Cost"].Value)) * Convert.ToInt32(n.Cells["Qty"].Value);
                            }
                        }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                LaborPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                            }
                        }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "F")
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                OtherPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                            }
                        }

                        if ((Convert.ToString(n.Cells["CType"].Value) != "S") && (Convert.ToString(n.Cells["CType"].Value) != "L"))
                        {
                            if (n.Cells["FET"].Value != null)
                            {
                                FET += Convert.ToDecimal(n.Cells["FET"].Value);
                            }
                            if (ctrSaleCategoryID.Items.Count > 0)
                            {
                                if (ctrSaleTaxRateID.SelectedValue != null)
                                {
                                    if (ctrSaleTaxRateID.SelectedValue.ToString() == "1")
                                    {
                                        if (Convert.ToBoolean(n.Cells["IsTax"].Value))
                                        {
                                            Taxable += Convert.ToDecimal(n.Cells["Amount"].Value);
                                            double amount = Convert.ToDouble(n.Cells["Amount"].Value);
                                            Tax += Math.Round(Convert.ToDecimal((amount / 100) * 8.6), 2);
                                        }
                                    }
                                }
                            }
                            //if (ctrSaleTaxRateID.SelectedValue.ToString() == "1")
                            //{
                            //    if (Convert.ToBoolean(n.Cells["IsTax"].Value))
                            //    {
                            //        double amount = Convert.ToDouble(n.Cells["Amount"].Value);
                            //        Tax += Math.Round(Convert.ToDecimal((amount / 100) * 8.6), 2);
                            //    }
                            //}
                            if (n.Cells["DiscAmount"].Value != null)
                            {
                                Discount += Convert.ToDecimal(n.Cells["DiscAmount"].Value);
                            }
                        }
                        else
                        {
                            if (n.Cells["DiscAmount"].Value != null)
                            {
                                Discount += Convert.ToDecimal(n.Cells["DiscAmount"].Value);
                            }
                        }
                    }
                }
                catch { }
            }
            if (DGVWorkOrder.Rows.Count > 0)
            {
                btnChangeCust.Enabled = false;
                btnNewCust.Enabled = false;
            }
            else
            {
                ctrPartDisPer.Value = 0;
                ctrLaborDisPer.Value = 0;

                btnChangeCust.Enabled = true;
                btnNewCust.Enabled = true;
            }

            //-------------------------------------------------------------
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["PartsPrice"] = PartsPrice;
            curRow["TotalProfit"] = TProfit;
            curRow["LaborPrice"] = LaborPrice;
            curRow["OtherPrice"] = OtherPrice;
            curRow["FET"] = FET;

            curRow["Taxable"] = Taxable;
            curRow["Tax"] = Tax;
            curRow["Discount"] = Discount;

            curRow["Total"] = (PartsPrice + LaborPrice + OtherPrice + FET + Tax) - Discount;

            curRow.EndEdit();
        }
        void CalculatColumns()
        {
            //-------------------------------------------------------------            
            decimal PartsPrice = 0, TProfit = 0, LaborPrice = 0, OtherPrice = 0, FET = 0, Taxable = 0, Tax = 0, Discount = 0;
            foreach (DataGridViewRow n in DGVWorkOrder.Rows)
            {
                try
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        //if ((Convert.ToString(n.Cells["CType"].Value) == "T")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "P")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "M")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "OP")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "OT")
                        //     || (Convert.ToString(n.Cells["CType"].Value) == "R")
                        //    || (Convert.ToString(n.Cells["CType"].Value) == "U"))

                        if ((Convert.ToString(n.Cells["CType"].Value) != "L") && (Convert.ToString(n.Cells["CType"].Value) != "F"))
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                PartsPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                                TProfit += (Convert.ToDecimal(n.Cells["Price"].Value) - Convert.ToDecimal(n.Cells["Cost"].Value)) * Convert.ToInt32(n.Cells["Qty"].Value);
                            }
                        }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                LaborPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                            }
                        }
                        else if (Convert.ToString(n.Cells["CType"].Value) == "F")
                        {
                            if (n.Cells["Amount"].Value != null)
                            {
                                OtherPrice += Convert.ToDecimal(n.Cells["Amount"].Value);
                            }
                        }

                        if ((Convert.ToString(n.Cells["CType"].Value) != "S") && (Convert.ToString(n.Cells["CType"].Value) != "L"))
                        {
                            if (n.Cells["FET"].Value != null)
                            {
                                FET += Convert.ToDecimal(n.Cells["FET"].Value);
                            }
                            if (ctrSaleCategoryID.Items.Count > 0)
                            {
                                if(ctrSaleTaxRateID.SelectedValue != null)
                                {
                                    if (ctrSaleTaxRateID.SelectedValue.ToString() == "1")
                                    {
                                        if (Convert.ToBoolean(n.Cells["IsTax"].Value))
                                        {
                                            Taxable += Convert.ToDecimal(n.Cells["Amount"].Value);
                                            double amount = Convert.ToDouble(n.Cells["Amount"].Value);
                                            Tax += Math.Round(Convert.ToDecimal((amount / 100) * 8.6), 2);
                                        }
                                    }
                                }
                            }
                            //if (ctrSaleTaxRateID.SelectedValue.ToString() == "1")
                            //{
                            //    if (Convert.ToBoolean(n.Cells["IsTax"].Value))
                            //    {
                            //        double amount = Convert.ToDouble(n.Cells["Amount"].Value);
                            //        Tax += Math.Round(Convert.ToDecimal((amount / 100) * 8.6), 2);
                            //    }
                            //}
                            if (n.Cells["DiscAmount"].Value != null)
                            {
                                Discount += Convert.ToDecimal(n.Cells["DiscAmount"].Value);
                            }
                        }
                        else
                        {
                            if (n.Cells["DiscAmount"].Value != null)
                            {
                                Discount += Convert.ToDecimal(n.Cells["DiscAmount"].Value);
                            }
                        }
                    }
                }
                catch { }
            }
            if (DGVWorkOrder.Rows.Count > 0)
            {
                btnChangeCust.Enabled = false;
                btnNewCust.Enabled = false;
            }
            else
            {
                ctrPartDisPer.Value = 0;
                ctrLaborDisPer.Value = 0;

                btnChangeCust.Enabled = true;
                btnNewCust.Enabled = true;
            }

            //-------------------------------------------------------------
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["PartsPrice"] = PartsPrice;
            curRow["TotalProfit"] = TProfit;
            curRow["LaborPrice"] = LaborPrice;
            curRow["OtherPrice"] = OtherPrice;
            curRow["FET"] = FET;

            curRow["Taxable"] = Taxable;
            curRow["Tax"] = Tax;
            curRow["Discount"] = Discount;

            curRow["Total"] = (PartsPrice + LaborPrice + OtherPrice + FET + Tax) - Discount;

            curRow.EndEdit();
            decimal TotalDiscount = 0;
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                decimal PartDiscount = 0;
                decimal LaborDiscount = 0;
                int PartDisPer = Convert.ToInt32(ctrPartDisPer.Value);
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) != "L")
                        {
                            PartDiscount = 0;
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value != DBNull.Value)
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = PartDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);
                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
                                                }
                                            }
                                        }
                                        editedRow.EndEdit();
                                    }
                                }
                            }
                        }
                        if (Convert.ToString(n.Cells["CType"].Value) == "L")
                        {
                            LaborDiscount = 0;
                            int LaborDisPer = Convert.ToInt32(ctrLaborDisPer.Value);
                            if (Convert.ToBoolean(n.Cells["IsDiscountable"].Value))
                            {
                                if (n.Cells["DiscPer"].Value != DBNull.Value)
                                {
                                    if (Convert.ToDecimal(n.Cells["DiscPer"].Value) >= 0)
                                    {
                                        DataRowView editedRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                        editedRow.BeginEdit();
                                        editedRow["DiscPer"] = LaborDisPer;
                                        editedRow["DiscAmount"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * Convert.ToDecimal(editedRow["DiscPer"]) / 100), 2);
                                        editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) - Convert.ToDecimal(editedRow["DiscAmount"])), 2);
                                        TotalDiscount += Convert.ToDecimal(editedRow["DiscAmount"]);
                                        if (editedRow["IsTax"] != DBNull.Value)
                                        {
                                            if (Convert.ToBoolean(editedRow["IsTax"]))
                                            {
                                                if (StaticInfo.SaleTaxPartsRate > 0)
                                                {
                                                    editedRow["Tax"] = Math.Round((Convert.ToDecimal(editedRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                                    editedRow["Total"] = Math.Round((Convert.ToDecimal(editedRow["Total"]) + Convert.ToDecimal(editedRow["Tax"])), 2);
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
                TotalDiscount += PartDiscount;
                txtDiscount.Text = TotalDiscount.ToString();
            }
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
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                {
                    if (n.Cells["CType"].Value != null)
                    {
                        if (Convert.ToString(n.Cells["CType"].Value) == "Par" || Convert.ToString(n.Cells["CType"].Value) == "Tir" || Convert.ToString(n.Cells["CType"].Value) == "Whe")
                        {
                            DataRowView curRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                            decimal itemPrice = dbClass.obj.getItemPrice(priceLevel, Convert.ToInt32(curRow["ItemID"]));
                            curRow.BeginEdit();
                            curRow["Price"] = itemPrice;
                            //------------------------------------------------------------------------------//
                            curRow["Amount"] = Math.Round(Convert.ToInt32(curRow["Qty"]) * Convert.ToDecimal(curRow["Price"]), 2);
                            if (curRow["DiscPer"] != DBNull.Value)
                            {
                                curRow["DiscAmount"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * Convert.ToDecimal(curRow["DiscPer"]) / 100), 2);
                                curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                            }
                            else
                            {
                                curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"])), 2);
                            }
                            
                            curRow["MarginPer"] = Math.Round((((Convert.ToDecimal(curRow["Price"]) - Convert.ToDecimal(curRow["Cost"])) * 100) / Convert.ToDecimal(curRow["Cost"])), 2);
                            curRow["MarginAmount"] = Math.Round((((Convert.ToDecimal(curRow["Cost"]) * Convert.ToDecimal(curRow["MarginPer"])) / 100) + Convert.ToDecimal(curRow["Cost"])), 2);
                            //------------------------------------------------------------------------------//
                            if (curRow["IsTax"] != DBNull.Value)
                            {
                                if (Convert.ToBoolean(curRow["IsTax"]))
                                {
                                    if (StaticInfo.SaleTaxPartsRate > 0)
                                    {
                                        curRow["Tax"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) * StaticInfo.SaleTaxPartsRate / 100), 2);
                                        curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Total"]) + Convert.ToDecimal(curRow["Tax"])), 2);
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
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
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

                            DataRowView curRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                            curRow.BeginEdit();
                            if (curRow["DiscAmount"] != DBNull.Value)
                            {
                                curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"]) - Convert.ToDecimal(curRow["DiscAmount"])), 2);
                            }
                            else
                            {
                                curRow["Total"] = Math.Round((Convert.ToDecimal(curRow["Amount"])), 2);
                            }
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
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                {
                    if (n.Cells["IsRepComm"].Value != null)
                    {
                        try
                        {
                            if (Convert.ToBoolean(n.Cells["IsRepComm"].Value))
                            {
                                DataRowView curRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
                                curRow.BeginEdit();
                                curRow["RepID"] = saleRepID;
                                curRow["Rep"] = Initial;
                                curRow.EndEdit();
                            }
                        }
                        catch { }
                    }
                }
            }
        }
        void setGridMech(int MechID, string Initial)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                foreach (DataGridViewRow n in DGVWorkOrder.Rows)
                {
                    if (n.Cells["IsMechComm"].Value != null)
                    {
                        if (Convert.ToBoolean(n.Cells["IsMechComm"].Value))
                        {
                            DataRowView curRow = (DataRowView)DGVWorkOrder.objBindingSource[n.Index];
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

            DGVWorkOrder.Columns["Available"].Visible = Convert.ToBoolean(dt.Rows[0]["WOAvailableQtyToggleColumn"]);
            DGVWorkOrder.Columns["Hours"].Visible = Convert.ToBoolean(dt.Rows[0]["WOHoursQtyToggleColumn"]);
            DGVWorkOrder.Columns["Cost"].Visible = true;
            //DGVWorkOrder.Columns["Cost"].Visible = Convert.ToBoolean(dt.Rows[0]["WOCostQtyToggleColumn"]);
            //Convert.ToBoolean(dt.Rows[0]["WODiscPerQtyToggleColumn"]);
            DGVWorkOrder.Columns["DiscPer"].Visible = Convert.ToBoolean(dt.Rows[0]["WODiscPerQtyToggleColumn"]); ;
            DGVWorkOrder.Columns["DiscAmount"].Visible = Convert.ToBoolean(dt.Rows[0]["WODiscAmountQtyToggleColumn"]);
            DGVWorkOrder.Columns["IsDone"].Visible = Convert.ToBoolean(dt.Rows[0]["WOIsDoneQtyToggleColumn"]);
            //DGVWorkOrder.Columns["IsTax"].Visible = Convert.ToBoolean(dt.Rows[0]["WOIsTaxQtyToggleColumn"]);
            DGVWorkOrder.Columns["IsTax"].Visible = false;
            DGVWorkOrder.Columns["MarginPer"].Visible = Convert.ToBoolean(dt.Rows[0]["WOMarginPerQtyToggleColumn"]);
            ShowCost();
        }
    }
}
