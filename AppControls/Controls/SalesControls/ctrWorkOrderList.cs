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
using DBModule;
using System32;
using System.Globalization;

namespace AppControls
{

    public partial class ctrWorkOrderList : UserControl
    {

        MainDataSet objDataSet;
        BindingSource bindingSource1;
        BindingSource CustomerWorkOrdersBS;
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedCustomerID = 0;
        int SelectedWorkOrderID = 0;

        public ctrWorkOrderList()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            bindingSource1 = new BindingSource();
            CustomerWorkOrdersBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrWorkOrderList_Load;

            btnNewWorkOrder.Click += btnNewWorkOrder_Click;
            btnNewCustomerQuote.Click += btnNewCustomerQuote_Click;
            btnWOforSelectedCustomer.Click += btnWOforSelectedCustomer_Click;
            btnQuoteforSelectedCustomer.Click += btnQuoteforSelectedCustomer_Click;
            btnNegate.Click += btnNegate_Click;
            btnRefreshWorkOrders.Click += btnRefreshWorkOrders_Click;
            btnCreditedInvoices.Click += btnCreditedInvoices_Click;
            btnSearch.Click += btnSearch_Click;

            DGVCustomerList.TDataGridView.CellClick += DGVCustomerList_TDataGridView_CellClick;
            DGVCustomerList.SearchtxtBox.KeyUp += DGVCustomerList_SearchtxtBox_KeyUp;
            btnOrderDetails.Click += btnOrderDetails_Click;

            DGVWorkOrderList.TDataGridView.CellClick += TDataGridView_CellClick;
            DGVWorkOrderList.TDataGridView.DoubleClick += TDataGridView_DoubleClick;
            DGVWorkOrderList.TDataGridView.CellEndEdit += DGVWorkOrderList_TDataGridView_CellEndEdit;
            //DGVWorkOrderList.SearchtxtBox.KeyUp += DGVWorkOrderList_SearchtxtBox_KeyUp;
            btnWorkOrderPrint.Click += btnWorkOrderPrint_Click;
            btnRefundDeposit.Click += btnRefundDeposit_Click;
            btnProceed.Click += btnProceed_Click;
            txtTotalToPay.LostFocus += txtTotalToPay_LostFocus;

            LoadNewCustomerWorkOrders();
        }
        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            if (SelectedWorkOrderID > 0)
            {
                StaticInfo.LoadToControl("AppControls.ctrWorkOrderDetails", "Work Order Details", SelectedWorkOrderID, 1);
            }
        }
        private void btnRefreshWorkOrders_Click(object sender, EventArgs e)
        {
            //lblTotalToPay.Visible = false;
            //txtTotalToPay.Visible = false;
            //btnProceed.Visible = false;
            LoadNewCustomerWorkOrders();
        }
        private void btnCreditedInvoices_Click(object sender, EventArgs e)
        {
            //txtTotalToPay.Text = "";
            //lblTotalToPay.Visible = true;
            //txtTotalToPay.Visible = true;
            //btnProceed.Visible = true;
            LoadCreditedInvoices();
        }
        void btnRefundDeposit_Click(object sender, EventArgs e)
        {
            if (SelectedCustomerID >= 1)
            {
                ctrCustomerPayment objList = new ctrCustomerPayment(0, SelectedCustomerID);
                //----------------------------------------------------------------------//
                frmCtr frmCtr = new frmCtr("Customer Refund ...");
                frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
        }
        void btnNegate_Click(object sender, EventArgs e)
        {
            bool CanNegate = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '012'");
            if (row[0]["CanView"] != DBNull.Value)
                CanNegate = Convert.ToBoolean(row[0]["CanView"]);

            if (CanNegate)
            {
                if (SelectedWorkOrderID > 0)
                {
                    DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
                    if (curRow != null)
                    {
                        string ctrName = Convert.ToString(curRow["ctrName"]);
                        string ctrType = Convert.ToString(curRow["Type"]);
                        string ctrStatus = Convert.ToString(curRow["Status"]);
                        Boolean isNegated = Convert.ToBoolean(curRow["IsNegated"]);

                        if (ctrName == "ctrCustomerReceipt" && ctrType == "Invoice" && ctrStatus == "Completed" && isNegated == false)
                        {
                            if (!Convert.ToBoolean(curRow["IsNegated"]))
                            {
                                ctrNegateWindow objNegateWindow = new ctrNegateWindow(Convert.ToInt32(curRow["ID"]));
                                //----------------------------------------------------------------------//
                                frmCtr frmCtr = new frmCtr("Invoice Negate ...");
                                frmCtr.Height = objNegateWindow.Height + 20; frmCtr.Width = objNegateWindow.Width + 20;
                                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                                frmCtr.frmPnl.Controls.Add(objNegateWindow);
                                frmCtr.BringToFront();
                                frmCtr.ShowDialog();
                            }
                            else
                                xMessageBox.Show("Unable to negate this record.....");
                        }
                        else
                            xMessageBox.Show("Invoice already Negated ...");
                    }

                }
                else if (SelectedCustomerID > 0)
                {
                    ctrWorkOrderNegate objNegate = new ctrWorkOrderNegate(SelectedCustomerID, 0);
                    //----------------------------------------------------------------------//
                    frmCtr frmCtr = new frmCtr("WorkOrder Negate ...");
                    frmCtr.Height = objNegate.Height + 34; frmCtr.Width = objNegate.Width + 20;
                    frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmCtr.frmPnl.Controls.Add(objNegate);
                    frmCtr.BringToFront();
                    frmCtr.ShowDialog();

                    //StaticInfo.LoadToControl("AppControls.ctrWorkOrderNegate1", "WorkOrderNegate1", SelectedCustomerID);
                }
            }
            else
                xMessageBox.Show("Sorry! You don't have Permissions to Negate.");
        }
        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            SelectedWorkOrderID = Convert.ToInt32(curRow["ID"]);


            if (e.ColumnIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    string DGVColumnName = DGVWorkOrderList.TDataGridView.Columns[e.ColumnIndex].Name;
                    DataRowView curRow1 = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
                    curRow1.BeginEdit();
                    if (DGVColumnName == "IsPaid")
                    {
                        bool IsCredit = Convert.ToBoolean(DGVWorkOrderList.TDataGridView.Rows[e.RowIndex].Cells["IsCredit"].Value);
                        if (IsCredit)
                        {
                            if (DGVColumnName == "IsPaid")
                            {
                                if (DGVWorkOrderList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                                {
                                    DGVWorkOrderList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                                    curRow1["IsPaid"] = false;

                                    //DGVWorkOrderList.TDataGridView.Columns["Discount"].ReadOnly = true;
                                    //DGVWorkOrderList.TDataGridView.Columns["ToPay"].ReadOnly = true;
                                }
                                else
                                {
                                    DGVWorkOrderList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                                    curRow1["IsPaid"] = true;
                                    //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
                                    // DGVWorkOrderList.TDataGridView.Columns["Discount"].ReadOnly = false;
                                    //DGVWorkOrderList.TDataGridView.Columns["ToPay"].ReadOnly = false;
                                }
                                DGVWorkOrderList.TDataGridView.EndEdit();
                                // VendorBillBS.EndEdit();
                            }
                        }

                    }
                    curRow1.EndEdit();
                }


                // DGVWorkOrderListCalculatColumns();
                curRow.EndEdit();
                DGVWorkOrderList.TDataGridView.EndEdit();
            }
        }
        void btnWorkOrderPrint_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            string type = curRow["Type"].ToString();

            if (type == "Negate")
            {
                if (SelectedWorkOrderID > 0)
                    StaticInfo.LoadToReport("RptModule", "Reports.NegatedWorkOrderReport", "byID", SelectedWorkOrderID);
            }
            else if (type == "Invoice")
            {
                if (SelectedWorkOrderID > 0)
                    StaticInfo.LoadToReport("RptModule", "Reports.CustomerInvoiceReport", "byID", SelectedWorkOrderID);
            }
            else if (type == "WorkOrder")
            {
                if (SelectedWorkOrderID > 0)
                    StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReport", "byID", SelectedWorkOrderID);
            }
            else if (type == "Qutation")
            {
                if (SelectedWorkOrderID > 0)
                    StaticInfo.LoadToReport("RptModule", "Reports.QuotationReport", "byID", SelectedWorkOrderID);
            }
            else if (type == "Payment")
            {
                StaticInfo.LoadToReport("RptModule", "Reports.CustomerCreditHistoryDuplicateReport", "byID", SelectedWorkOrderID);
            }
        }
        void TDataGridView_DoubleClick(object sender, EventArgs e)
        {
            bool IsLocked = false, IsCredit = false;
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            if (curRow != null)
            {
                if (DGVWorkOrderList.TDataGridView.Columns.Contains("IsPaid"))
                {
                    IsCredit = true;
                }
                bool WorkOrderEdit = false;
                DataRow[] row = StaticInfo.UserRights.Select("Code = '006'");
                if (row[0]["CanView"] != DBNull.Value)
                    WorkOrderEdit = Convert.ToBoolean(row[0]["CanView"]);

                string ctrName = Convert.ToString(curRow["ctrName"]);
                IsLocked = Convert.ToBoolean(curRow["IsLocked"]);
                string Type = curRow["Type"].ToString();
                switch (ctrName)
                {
                    case "ctrWorkOrder":
                        if (WorkOrderEdit)
                        {
                            //ctrWorkOrder objWorkOrder = new ctrWorkOrder(1, Convert.ToInt32(curRow["ID"]), this.SelectedCustomerID);
                            //frmCtr frmCtr = new frmCtr("WorkOrder Open");
                            //frmCtr.Height = objWorkOrder.Height + 20; frmCtr.Width = objWorkOrder.Width + 20;
                            //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                            //frmCtr.frmPnl.Controls.Add(objWorkOrder);
                            //frmCtr.BringToFront();
                            //frmCtr.ShowDialog();
                            StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "WorkOrderOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        }
                        //StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "WorkOrderOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        else
                            xMessageBox.Show("Sorry! You don't have Permissions to Edit WorkOrder.");
                        break;
                    case "ctrCustomerReceipt":
                        if (!IsLocked && !IsCredit && Type != "Payment")
                            StaticInfo.LoadToControl("AppControls.ctrCustomerReceipt", "CustomerReceiptOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        else if (Type == "Payment") { }
                        else
                            xMessageBox.Show("Can't edit a Posted Invoice...");
                        break;
                    case "ctrWorkOrderNegate":
                        StaticInfo.LoadToControl("AppControls.ctrWorkOrderNegate", "WorkOrderNegateOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        break;
                    case "ctrCustomerPayment":
                        StaticInfo.LoadToControl("AppControls.ctrCustomerPayment", "CustomerPaymentOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        break;
                }
            }
        }
        void DGVCustomerList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVCustomerList.TDataGridView.DataSource).Current;
            SelectedCustomerID = Convert.ToInt32(curRow["ID"]);
            if (SelectedCustomerID > 0)
            {
                //lblTotalToPay.Visible = false;
                //txtTotalToPay.Visible = false;
                //btnProceed.Visible = false;
                LoadSelectedCustomerWorkOrders();
            }
        }
        void DGVWorkOrderList_TDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagrid = (DataGridView)sender;
            string columnName = datagrid.Columns[e.ColumnIndex].Name.ToString();
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            curRow.BeginEdit();

            decimal ChgOnAcc = Convert.ToDecimal(curRow["ChgOnAccount"]);
            decimal ToPay = Convert.ToDecimal(curRow["ToPay"]);
            if (columnName == "IsPaid")
            {
                if (curRow["IsPaid"] != DBNull.Value)
                {
                    if (!Convert.ToBoolean(curRow["IsPaid"]))
                    {
                        curRow["ToPay"] = 0;
                        curRow["ChgOnAccount"] = ChgOnAcc + ToPay;
                    }
                    else
                    {
                        curRow["ToPay"] = ChgOnAcc + ToPay;
                        curRow["ChgOnAccount"] = 0;
                        //curRow["Balance"] = BillTotalAmount - Discount - PaidAmount - ToPay;
                    }
                }
            }
            curRow.EndEdit();
            DGVWorkOrderListCalculatColumns();
        }
        void btnNewWorkOrder_Click(object sender, EventArgs e)
        {
            //ctrWorkOrder objWorkOrder = new ctrWorkOrder(1, this.SelectedCustomerID);
            //frmCtr frmCtr = new frmCtr("New WorkOrder");
            //frmCtr.Height = objWorkOrder.Height + 20; frmCtr.Width = objWorkOrder.Width + 20;
            //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //frmCtr.frmPnl.Controls.Add(objWorkOrder);
            //frmCtr.BringToFront();
            //frmCtr.ShowDialog();
            LoadSelectedCustomerWorkOrders();
            if (SelectedCustomerID > 0)
                StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New WorkOrder for Selected Customer", 1, SelectedCustomerID);
            else
                StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New Customer and New Work-Order", 0);
        }
        void btnNewCustomerQuote_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New Customer and New Quote", -1);
        }
        void btnWOforSelectedCustomer_Click(object sender, EventArgs e)
        {
            if (SelectedCustomerID > 0)
                StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New WorkOrder for Selected Customer", -1, SelectedCustomerID);
            else
                xMessageBox.Show("Select Customer for New WorkOrder ...");
        }
        void btnQuoteforSelectedCustomer_Click(object sender, EventArgs e)
        {
            if (SelectedCustomerID > 0)
                StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "New Quote for Selected Customer", -1, SelectedCustomerID);
            else
                xMessageBox.Show("Select Customer for New Quotation ...");
        }
        void ctrWorkOrderList_Load(object sender, EventArgs e)
        {
            //bool AccessSales = false;
            //DataRow[] row = StaticInfo.UserRights.Select("Code = '008'");
            //if (row[0]["CanView"] != DBNull.Value)
            //    AccessSales = Convert.ToBoolean(row[0]["CanView"]);
            //if (!AccessSales)
            //{
            //    xMessageBox.Show("Sorry! You don't have Permissions on Sales.");
            //    //this.ParentForm.Close();
            //    this.BeginInvoke(new MethodInvoker(this.ParentForm.Close));
            //}            
            //-------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-------------------------------------------------
            DataTable dt = dbClass.obj.getCustomerList();
            bindingSource1.DataSource = dt;
            DGVCustomerList.SetSource(bindingSource1);

            //DGVCustomerList.TDataGridView.AutoGenerateColumns = true;
            //DGVCustomerList.TDataGridView.DataSource = bindingSource1;
            //DGVCustomerList.TDataGridView.Columns["ID"].Visible = false;
            DGVCustomerList.TDataGridView.Columns["Code"].Visible = false;
            //DGVCustomerList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        void LoadSelectedCustomerWorkOrders()
        {
            SelectedWorkOrderID = 0;
            DataTable dt2 = dbClass.obj.FillSelectedCustomerWorkOrders(SelectedCustomerID);
            DataView dv = dt2.DefaultView;
            dv.Sort = "Date desc,TransNo desc";
            DataTable dt = dv.ToTable();

            //System.Data.DataColumn newColumnIsPaid = new System.Data.DataColumn("IsPaid", typeof(System.Boolean));
            //newColumnIsPaid.DefaultValue = false;
            //dt.Columns.Add(newColumnIsPaid);

            //System.Data.DataColumn newColumnToPay = new System.Data.DataColumn("ToPay", typeof(System.Decimal));
            //newColumnToPay.DefaultValue = 0.00;
            //dt.Columns.Add(newColumnToPay);


            //CustomerWorkOrdersBS.DataSource = null;           
            CustomerWorkOrdersBS.DataSource = dt;

            DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;

            DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
            DGVWorkOrderList.TDataGridView.Enabled = true;
            DGVWorkOrderList.TDataGridView.ReadOnly = false;


            foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }


            //---------------------------------------------------------
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["TransNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].DisplayIndex = 1;

            DGVWorkOrderList.TDataGridView.Columns["Date"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVWorkOrderList.TDataGridView.Columns["Date"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["Date"].DisplayIndex = 2;

            DGVWorkOrderList.TDataGridView.Columns["Type"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Type"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["Type"].DisplayIndex = 3;

            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Invoice No";
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].DisplayIndex = 4;

            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Width = 50;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "WO#";
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].DisplayIndex = 4;

            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Width = 260;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].HeaderText = "Paid by (Company)";
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].DisplayIndex = 5;

            DGVWorkOrderList.TDataGridView.Columns["Rep"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].DisplayIndex = 6;

            DGVWorkOrderList.TDataGridView.Columns["PONo"].Width = 570;
            DGVWorkOrderList.TDataGridView.Columns["PONo"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["PONo"].HeaderText = "Paid By";
            DGVWorkOrderList.TDataGridView.Columns["PONo"].DisplayIndex = 7;

            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Mileage"].Visible = false;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].DisplayIndex = 8;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].Width = 60;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].DisplayIndex = 7;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].ReadOnly = true;

            //// DGVWorkOrderList.TDataGridView.Columns["IsCredit"].Width = 50;
            // DGVWorkOrderList.TDataGridView.Columns["IsCredit"].Visible = false;
            //// DGVWorkOrderList.TDataGridView.Columns["IsCredit"].DisplayIndex = 8;
            // DGVWorkOrderList.TDataGridView.Columns["IsCredit"].ReadOnly = true;

            //DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].Width = 60;
            //DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].HeaderText = "Credit";
            //DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].DisplayIndex = 8;
            //DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].ReadOnly = true;

            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Width = 50;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].DisplayIndex = 9;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].DisplayIndex = 10;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].DisplayIndex = 11;


            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].DisplayIndex = 12;
            //DGVWorkOrderList.TDataGridView.Columns["Total Amt"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].DisplayIndex = 12;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "";
            col.Name = "btnMech";
            col.HeaderText = "Mech";
            col.Width = 50;
            col.DisplayIndex = 10;
            DGVWorkOrderList.TDataGridView.Columns.Add(col);

            DGVWorkOrderList.TDataGridView.Columns["Status"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Status"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Status"].DisplayIndex = 13;

            DGVWorkOrderList.TDataGridView.Columns["Description"].Width = 170;
            DGVWorkOrderList.TDataGridView.Columns["Description"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Description"].DisplayIndex = 14;

            DGVWorkOrderList.TDataGridView.Columns["Category"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Category"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Category"].DisplayIndex = 15;

            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].DisplayIndex = 16;

            DGVWorkOrderList.TDataGridView.Columns["Phone"].Width = 120;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].DisplayIndex = 17;

            //DGVWorkOrderList.TDataGridView.Columns["Store"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].DisplayIndex = 18;
            ////---------------------------------------------------------
            //chkboxShowBillsOnHold.Checked = false;
            //chkboxShowClosedTransactions.Checked = false;
            //txtTotalToPay.Text = "";
            //txtTotalDiscount.Text = "";
            //txtTotalApplied.Text = "";
            //rbtnCash.Checked = true;
            //rbtnCheck.Checked = false;
            //txtCheckNo.Text = "";
            //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
            //chkboxPrint.Checked = false;
            //txtNotes.Text = "";
            ////---------------------------------------------------------            

            //foreach (DataGridViewRow gridView in DGVWorkOrderList.TDataGridView.Rows)
            //{
            //    bool IsCredit = Convert.ToBoolean(gridView.Cells["IsCredit"].Value);
            //    if (IsCredit)
            //    {
            //        gridView.Cells["IsPaid"].ReadOnly = false;
            //       // gridView.Cells["IsPaid"].Style.BackColor = Color.DarkRed;
            //    }
            //    else
            //    {
            //        gridView.Cells["IsPaid"].ReadOnly = true;
            //        //gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
            //    }
            //}
        }
        void LoadNewCustomerWorkOrders()
        {
            DataTable dt2 = dbClass.obj.FillLatestCustomerWorkOrders();

            DataView dv = dt2.DefaultView;
            dv.Sort = "Date desc,TransNo desc";
            DataTable dt = dv.ToTable();

            //System.Data.DataColumn newColumnIsPaid = new System.Data.DataColumn("IsPaid", typeof(System.Boolean));
            //newColumnIsPaid.DefaultValue = false;
            //dt.Columns.Add(newColumnIsPaid);

            //CustomerWorkOrdersBS.DataSource = null;
            CustomerWorkOrdersBS.DataSource = dt;

            DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;

            DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
            DGVWorkOrderList.TDataGridView.Enabled = true;
            DGVWorkOrderList.TDataGridView.ReadOnly = false;


            foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
            {
                gridColumn.Visible = false;
                gridColumn.ReadOnly = true;
            }

            //---------------------------------------------------------
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["TransNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].DisplayIndex = 1;

            DGVWorkOrderList.TDataGridView.Columns["Date"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVWorkOrderList.TDataGridView.Columns["Date"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["Date"].DisplayIndex = 2;

            DGVWorkOrderList.TDataGridView.Columns["Type"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Type"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["Type"].DisplayIndex = 3;

            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Width = 50;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "WO#";
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].DisplayIndex = 4;

            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Width = 260;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].HeaderText = "Paid by (Company)";
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].DisplayIndex = 4;

            DGVWorkOrderList.TDataGridView.Columns["Rep"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].DisplayIndex = 5;

            DGVWorkOrderList.TDataGridView.Columns["PONo"].Width = 570;
            DGVWorkOrderList.TDataGridView.Columns["PONo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["PONo"].HeaderText = "PONo";
            DGVWorkOrderList.TDataGridView.Columns["PONo"].DisplayIndex = 6;

            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Mileage"].Visible = false;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].DisplayIndex = 8;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Width = 60;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].DisplayIndex = 7;
            //DGVWorkOrderList.TDataGridView.Columns["IsPaid"].ReadOnly = false;

            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].DisplayIndex = 8;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].ReadOnly = false;

            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].DisplayIndex = 9;


            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].DisplayIndex = 10;
            //DGVWorkOrderList.TDataGridView.Columns["Total Amt"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].DisplayIndex = 12;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "";
            col.Name = "btnMech";
            col.HeaderText = "Mech";
            col.Width = 50;
            col.DisplayIndex = 10;
            DGVWorkOrderList.TDataGridView.Columns.Add(col);

            DGVWorkOrderList.TDataGridView.Columns["Status"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Status"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Status"].DisplayIndex = 11;

            DGVWorkOrderList.TDataGridView.Columns["Description"].Width = 170;
            DGVWorkOrderList.TDataGridView.Columns["Description"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Description"].DisplayIndex = 12;

            DGVWorkOrderList.TDataGridView.Columns["Category"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Category"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Category"].DisplayIndex = 13;

            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].DisplayIndex = 14;

            DGVWorkOrderList.TDataGridView.Columns["Phone"].Width = 120;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].DisplayIndex = 15;

            //DGVWorkOrderList.TDataGridView.Columns["Store"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].DisplayIndex = 18;
            ////---------------------------------------------------------
            //chkboxShowBillsOnHold.Checked = false;
            //chkboxShowClosedTransactions.Checked = false;
            //txtTotalToPay.Text = "";
            //txtTotalDiscount.Text = "";
            //txtTotalApplied.Text = "";
            //rbtnCash.Checked = true;
            //rbtnCheck.Checked = false;
            //txtCheckNo.Text = "";
            //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
            //chkboxPrint.Checked = false;
            //txtNotes.Text = "";
            ////---------------------------------------------------------
            //foreach (DataGridViewRow gridView in DGVWorkOrderList.TDataGridView.Rows)
            //{
            //    string Type = gridView.Cells["Type"].Value.ToString();                
            //    if (Type == "Invoice")
            //    {
            //        gridView.Cells["IsPaid"].ReadOnly = true;
            //        //gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
            //    }
            //    else if (Type == "WorkOrderNegate")
            //    {
            //        gridView.Cells["IsPaid"].ReadOnly = true;
            //       // gridView.Cells["IsPaid"].Style.BackColor = Color.DarkRed;
            //    }
            //}

        }
        void LoadCreditedInvoices()
        {
            SelectedWorkOrderID = 0;
            DataTable dt2 = dbClass.obj.FillSelectedCustomerCreditedInvoice(SelectedCustomerID);
            DataView dv = dt2.DefaultView;
            dv.Sort = "Date asc,TransNo asc";
            DataTable dt = dv.ToTable();

            System.Data.DataColumn newColumnIsPaid = new System.Data.DataColumn("IsPaid", typeof(System.Boolean));
            newColumnIsPaid.DefaultValue = false;
            dt.Columns.Add(newColumnIsPaid);

            System.Data.DataColumn newColumnToPay = new System.Data.DataColumn("ToPay", typeof(System.Decimal));
            newColumnToPay.DefaultValue = 0.00;
            dt.Columns.Add(newColumnToPay);


            //CustomerWorkOrdersBS.DataSource = null;           
            CustomerWorkOrdersBS.DataSource = dt;

            DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;

            DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
            DGVWorkOrderList.TDataGridView.Enabled = true;
            DGVWorkOrderList.TDataGridView.ReadOnly = false;


            foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }


            //---------------------------------------------------------
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["TransNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].DisplayIndex = 1;

            DGVWorkOrderList.TDataGridView.Columns["Date"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVWorkOrderList.TDataGridView.Columns["Date"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["Date"].DisplayIndex = 2;

            DGVWorkOrderList.TDataGridView.Columns["Type"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Type"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["Type"].DisplayIndex = 3;

            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Invoice No";
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].DisplayIndex = 4;

            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Width = 50;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "WO#";
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].DisplayIndex = 4;

            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Width = 160;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].HeaderText = "Paid by (Company)";
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].DisplayIndex = 5;

            DGVWorkOrderList.TDataGridView.Columns["Rep"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].DisplayIndex = 6;

            //DGVWorkOrderList.TDataGridView.Columns["PONo"].Width = 100;
            //DGVWorkOrderList.TDataGridView.Columns["PONo"].Visible = true;
            ////DGVWorkOrderList.TDataGridView.Columns["PONo"].HeaderText = "PONo";
            //DGVWorkOrderList.TDataGridView.Columns["PONo"].DisplayIndex = 7;

            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Mileage"].Visible = false;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].DisplayIndex = 8;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].Width = 60;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].DisplayIndex = 7;
            //DGVWorkOrderList.TDataGridView.Columns["ToPay"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["IsCredit"].Visible = false;
            DGVWorkOrderList.TDataGridView.Columns["IsCredit"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["InvoiceID"].Visible = false;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceID"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].HeaderText = "Credit";
            DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].DisplayIndex = 8;
            DGVWorkOrderList.TDataGridView.Columns["ChgOnAccount"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].DisplayIndex = 9;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["ToPay"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ToPay"].HeaderText = "To Pay";
            DGVWorkOrderList.TDataGridView.Columns["ToPay"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ToPay"].DisplayIndex = 10;
            DGVWorkOrderList.TDataGridView.Columns["ToPay"].ReadOnly = true;

            //DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Width = 60;
            //DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Open Amt"].DisplayIndex = 10;
            //DGVWorkOrderList.TDataGridView.Columns["Open Amt"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].DisplayIndex = 11;


            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].DisplayIndex = 12;
            //DGVWorkOrderList.TDataGridView.Columns["Total Amt"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].DisplayIndex = 12;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "";
            col.Name = "btnMech";
            col.HeaderText = "Mech";
            col.Width = 50;
            col.DisplayIndex = 13;
            DGVWorkOrderList.TDataGridView.Columns.Add(col);

            DGVWorkOrderList.TDataGridView.Columns["Status"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Status"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Status"].DisplayIndex = 14;

            DGVWorkOrderList.TDataGridView.Columns["Description"].Width = 170;
            DGVWorkOrderList.TDataGridView.Columns["Description"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Description"].DisplayIndex = 15;

            DGVWorkOrderList.TDataGridView.Columns["Category"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Category"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Category"].DisplayIndex = 16;

            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].DisplayIndex = 17;

            DGVWorkOrderList.TDataGridView.Columns["Phone"].Width = 120;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].DisplayIndex = 18;

            //DGVWorkOrderList.TDataGridView.Columns["Store"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Store"].DisplayIndex = 18;
            ////---------------------------------------------------------
            //chkboxShowBillsOnHold.Checked = false;
            //chkboxShowClosedTransactions.Checked = false;
            //txtTotalToPay.Text = "";
            //txtTotalDiscount.Text = "";
            //txtTotalApplied.Text = "";
            //rbtnCash.Checked = true;
            //rbtnCheck.Checked = false;
            //txtCheckNo.Text = "";
            //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
            //chkboxPrint.Checked = false;
            //txtNotes.Text = "";
            ////---------------------------------------------------------            

            foreach (DataGridViewRow gridView in DGVWorkOrderList.TDataGridView.Rows)
            {
                bool IsCredit = Convert.ToBoolean(gridView.Cells["IsCredit"].Value);
                if (IsCredit)
                {
                    gridView.Cells["IsPaid"].ReadOnly = false;
                    // gridView.Cells["IsPaid"].Style.BackColor = Color.DarkRed;
                }
                else
                {
                    gridView.Cells["IsPaid"].ReadOnly = true;
                    //gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
                }
            }
        }
        void DGVWorkOrderListCalculatColumns()
        {
            //-------------------------------------------------------------                        
            decimal TotalApplied = 0, TotalDiscount = 0, TotalToPay = 0;
            decimal Credit = 0, billDiscount = 0, ToPay = 0, Balance = 0;
            if (DGVWorkOrderList.TDataGridView.Columns.Contains("IsPaid"))
            {
                foreach (DataGridViewRow n in DGVWorkOrderList.TDataGridView.Rows)
                {
                    if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["IsPaid"].Value) == true)
                        {
                            if (n.Cells["ChgOnAccount"].Value != null)
                            {
                                Credit = Convert.ToDecimal(n.Cells["ToPay"].Value);
                                n.Cells["ToPay"].Value = Credit;
                                n.Cells["ChgOnAccount"].Value = 0;
                            }
                            TotalToPay += Credit;
                        }
                    }
                }
                //txtTotalApplied.Text = string.Format("{0:C}", Convert.ToDouble(TotalApplied));
                //txtTotalDiscount.Text = string.Format("{0:C}", Convert.ToDouble(TotalDiscount));
                txtTotalToPay.Text = string.Format("{0:C}", Convert.ToDouble(TotalToPay));
            }
        }
        void txtTotalToPay_LostFocus(object sender, EventArgs e)
        {
            decimal TotalToPay = 0;
            bool IsCredit = false;
            if (SelectedCustomerID > 0)
            {
                if (!string.IsNullOrEmpty(txtTotalToPay.Text))
                    TotalToPay = Convert.ToDecimal(txtTotalToPay.Text.Replace("$", ""));
                else
                    TotalToPay = 0;
                decimal totalAmt = TotalToPay;

                ClearAmount();
                if (DGVWorkOrderList.TDataGridView.Columns.Contains("IsPaid"))
                {
                    foreach (DataGridViewRow n in DGVWorkOrderList.TDataGridView.Rows)
                    {
                        IsCredit = Convert.ToBoolean(n.Cells["IsCredit"].Value);
                        if (IsCredit)
                        {
                            if (Convert.ToDecimal(n.Cells["ChgOnAccount"].Value) <= TotalToPay)
                            {
                                //if (Convert.ToBoolean(n.Cells["IsPaid"].Value) == true)
                                //{
                                TotalToPay = TotalToPay - Convert.ToDecimal(n.Cells["ChgOnAccount"].Value);
                                n.Cells["ToPay"].Value = Convert.ToDecimal(n.Cells["ChgOnAccount"].Value);
                                n.Cells["ChgOnAccount"].Value = 0.0;
                                //n.Cells["Balance"].Value = 0.0;
                                n.Cells["IsPaid"].Value = true;
                            }
                            else if (Convert.ToDecimal(n.Cells["ChgOnAccount"].Value) > TotalToPay && TotalToPay > 0)
                            {
                                n.Cells["ToPay"].Value = TotalToPay;
                                //n.Cells["Balance"].Value = Convert.ToDecimal(n.Cells["Balance"].Value) - TotalToPay;
                                n.Cells["ChgOnAccount"].Value = Convert.ToDecimal(n.Cells["ChgOnAccount"].Value) - TotalToPay;
                                TotalToPay = 0;
                                n.Cells["IsPaid"].Value = true;
                            }
                        }
                    }
                }
                txtTotalToPay.Text = string.Format("{0:C}", totalAmt - TotalToPay);
            }
            else
            {
                txtTotalToPay.Text = "";
                xMessageBox.Show("Please Select any Customer .....");
            }
        }
        private void ClearAmount()
        {
            if (DGVWorkOrderList.TDataGridView.Columns.Contains("IsPaid"))
            {
                foreach (DataGridViewRow n in DGVWorkOrderList.TDataGridView.Rows)
                {
                    if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["IsPaid"].Value))
                        {
                            n.Cells["IsPaid"].Value = false;
                            //decimal ToPay = Convert.ToDecimal(n.Cells["ToPay"].Value);
                            n.Cells["ChgOnAccount"].Value = Convert.ToDecimal(n.Cells["ChgOnAccount"].Value) + Convert.ToDecimal(n.Cells["ToPay"].Value);
                            n.Cells["ToPay"].Value = 0.0;
                        }
                    }
                }
            }
        }
        void btnProceed_Click(object sender, EventArgs e)
        {
            if (SelectedCustomerID > 0)
            {
                int ReceiptID = 0;
                bool InvoicesSelected = false;
                bool IsCredit = false;
                decimal TotalToPay = 0, TotalAmount = 0;
                string Type = "";
                string InvoiceIDs = "";
                if (!string.IsNullOrEmpty(txtTotalToPay.Text))
                    TotalToPay = Convert.ToDecimal(txtTotalToPay.Text.Replace("$", ""));

                //TotalToPay = decimal.Parse(txtTotalToPay.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                //                          NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                if (TotalToPay > 0)
                {
                    DataTable DtPayment = new DataTable();
                    DtPayment.Columns.Add("InvoiceID", typeof(int));
                    //DtPayment.Columns.Add("CustomerID", typeof(int));                                     
                    DtPayment.Columns.Add("TotalAmount", typeof(decimal));
                    DtPayment.Columns.Add("PaidAmount", typeof(decimal));
                    DtPayment.Columns.Add("Balance", typeof(decimal));

                    //ReceiptID = dbClass.obj.getNextCustomerReceiptAutoNo();
                    //dbClass.obj.DeleteCustomerPaymentTemp(SelectedCustomerID, ReceiptID);
                    if (DGVWorkOrderList.TDataGridView.Columns.Contains("IsPaid"))
                    {
                        foreach (DataGridViewRow n in DGVWorkOrderList.TDataGridView.Rows)
                        {
                            DataRow dr = DtPayment.NewRow();
                            if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                            {
                                IsCredit = Convert.ToBoolean(n.Cells["IsPaid"].Value);
                                if (IsCredit)
                                {
                                    int InvoiceID = 0;
                                    decimal Credit = 0, ToPay = 0;

                                    if (n.Cells["InvoiceID"].Value != null)
                                    {
                                        InvoiceID = Convert.ToInt32(n.Cells["InvoiceID"].Value);
                                        dr["InvoiceID"] = InvoiceID;
                                    }
                                    if (n.Cells["ChgOnAccount"].Value != null)
                                    {
                                        Credit = Convert.ToDecimal(n.Cells["ChgOnAccount"].Value);
                                        dr["TotalAmount"] = Credit;
                                        dr["Balance"] = Convert.ToDecimal(n.Cells["ChgOnAccount"].Value);
                                        //TotalToPay -= Credit;
                                    }
                                    if (n.Cells["ToPay"].Value != null)
                                    {
                                        ToPay = Convert.ToDecimal(n.Cells["ToPay"].Value);
                                        TotalToPay -= ToPay;
                                        dr["PaidAmount"] = ToPay;
                                    }
                                    //if (n.Cells["Payable"].Value != null) { BillAmount = Convert.ToDecimal(n.Cells["Payable"].Value); }
                                    //if (n.Cells["Discount"].Value != null) { BillDiscount = Convert.ToDecimal(n.Cells["Discount"].Value); }
                                    //if (n.Cells["To Pay"].Value != null) { PaidAmount = Convert.ToDecimal(n.Cells["To Pay"].Value); }
                                    //if (n.Cells["Balance"].Value != null) { BillBalance = Convert.ToDecimal(n.Cells["Balance"].Value); }

                                    if (InvoiceID > 0)
                                    {
                                        InvoiceIDs += "," + InvoiceID + ","; ;
                                        TotalAmount += ToPay;
                                        InvoicesSelected = true;
                                        DtPayment.Rows.Add(dr);
                                        //dbClass.obj.AddCustomerPaymentTemp(ReceiptID, SelectedCustomerID, ID, DateTime.Now, OpenAmount, OpenAmount, 0, false);
                                    }
                                }
                            }
                        }
                    }

                    if (InvoicesSelected)
                    {
                        ctrCustomerReceipt objList = new ctrCustomerReceipt(InvoiceIDs, SelectedCustomerID, TotalAmount, DtPayment);
                        frmCtr frmCtr = new frmCtr("Customer Invoice");
                        frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(objList);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                        //this.Parent.Parent.Parent.Dispose();
                        if (SelectedCustomerID > 0)
                            LoadSelectedCustomerWorkOrders();
                        txtTotalToPay.Text = "";
                    }
                    else
                    {
                        xMessageBox.Show("Please Select any WorkOrder .....");
                    }
                }
                else
                {
                    xMessageBox.Show("Please Enter amount to Pay .....");
                }
            }
            else
            {
                xMessageBox.Show("Please Select Customer .....");
            }
        }
        //void DGVWorkOrderList_SearchtxtBox_KeyUp(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow gridView in DGVWorkOrderList.TDataGridView.Rows)
        //    {
        //        string Type = gridView.Cells["Type"].Value.ToString();
        //        var check = gridView.Cells["IsPaid"].Value;
        //        if (Type == "Invoice")
        //        {
        //            gridView.Cells["IsPaid"].ReadOnly = true;
        //            gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
        //        }
        //        else if (Type != "WorkOrderNegate") 
        //        {
        //            gridView.Cells["IsPaid"].ReadOnly = true;
        //            gridView.Cells["IsPaid"].Style.BackColor = Color.DarkRed;
        //        }
        //    }
        //}
        void DGVCustomerList_SearchtxtBox_KeyUp(object sender, EventArgs e)
        {
            this.SelectedCustomerID = 0;
            LoadNewCustomerWorkOrders();
        }
        void LoadSearchWorkOrders(DataTable dt)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = "Date desc,TransNo desc";
            DataTable dt2 = dv.ToTable();

            System.Data.DataColumn newColumnIsPaid = new System.Data.DataColumn("IsPaid", typeof(System.Boolean));
            newColumnIsPaid.DefaultValue = false;
            dt2.Columns.Add(newColumnIsPaid);

            CustomerWorkOrdersBS.DataSource = dt2;

            DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;

            DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
            DGVWorkOrderList.TDataGridView.Enabled = true;
            DGVWorkOrderList.TDataGridView.ReadOnly = false;


            foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
            {
                gridColumn.Visible = false;
                gridColumn.ReadOnly = true;
            }

            //---------------------------------------------------------
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["TransNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["TransNo"].DisplayIndex = 1;

            DGVWorkOrderList.TDataGridView.Columns["Date"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Date"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "Date";
            DGVWorkOrderList.TDataGridView.Columns["Date"].DisplayIndex = 2;

            DGVWorkOrderList.TDataGridView.Columns["Type"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Type"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVWorkOrderList.TDataGridView.Columns["Type"].DisplayIndex = 3;

            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Invoice No";
            DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].DisplayIndex = 4;

            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Width = 50;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "WO#";
            //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].DisplayIndex = 4;

            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Width = 160;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].HeaderText = "Paid by (Company)";
            DGVWorkOrderList.TDataGridView.Columns["Paid by"].DisplayIndex = 5;

            DGVWorkOrderList.TDataGridView.Columns["Rep"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Rep"].DisplayIndex = 6;

            DGVWorkOrderList.TDataGridView.Columns["PONo"].Width = 570;
            DGVWorkOrderList.TDataGridView.Columns["PONo"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["PONo"].HeaderText = "PONo";
            DGVWorkOrderList.TDataGridView.Columns["PONo"].DisplayIndex = 7;

            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["Mileage"].Visible = false;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].DisplayIndex = 8;
            //DGVWorkOrderList.TDataGridView.Columns["Mileage"].ReadOnly = false;

            // DGVWorkOrderList.TDataGridView.Columns["IsCredit"].Width = 50;
            DGVWorkOrderList.TDataGridView.Columns["IsCredit"].Visible = false;
            // DGVWorkOrderList.TDataGridView.Columns["IsCredit"].DisplayIndex = 8;
            DGVWorkOrderList.TDataGridView.Columns["IsCredit"].ReadOnly = true;

            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].DisplayIndex = 7;
            DGVWorkOrderList.TDataGridView.Columns["IsPaid"].ReadOnly = false;

            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].DisplayIndex = 8;
            DGVWorkOrderList.TDataGridView.Columns["Open Amt"].ReadOnly = false;

            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Width = 100;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Vehicle"].DisplayIndex = 9;

            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Total Amt"].DisplayIndex = 10;
            //DGVWorkOrderList.TDataGridView.Columns["Total Amt"].ReadOnly = false;

            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Width = 30;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].Visible = true;
            //DGVWorkOrderList.TDataGridView.Columns["Mech"].DisplayIndex = 12;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "";
            col.Name = "btnMech";
            col.HeaderText = "Mech";
            col.Width = 50;
            col.DisplayIndex = 10;
            DGVWorkOrderList.TDataGridView.Columns.Add(col);

            DGVWorkOrderList.TDataGridView.Columns["Status"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Status"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Status"].DisplayIndex = 11;

            DGVWorkOrderList.TDataGridView.Columns["Description"].Width = 170;
            DGVWorkOrderList.TDataGridView.Columns["Description"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Description"].DisplayIndex = 12;

            DGVWorkOrderList.TDataGridView.Columns["Category"].Width = 80;
            DGVWorkOrderList.TDataGridView.Columns["Category"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Category"].DisplayIndex = 13;

            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Width = 60;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["ShipVia"].DisplayIndex = 14;

            DGVWorkOrderList.TDataGridView.Columns["Phone"].Width = 120;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].Visible = true;
            DGVWorkOrderList.TDataGridView.Columns["Phone"].DisplayIndex = 15;

            foreach (DataGridViewRow gridView in DGVWorkOrderList.TDataGridView.Rows)
            {
                bool IsCredit = (bool)gridView.Cells["IsCredit"].Value;
                if (IsCredit)
                {
                    gridView.Cells["IsPaid"].ReadOnly = false;
                    // gridView.Cells["IsPaid"].Style.BackColor = Color.DarkRed;
                }
                else
                {
                    gridView.Cells["IsPaid"].ReadOnly = true;
                    // gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
                }
            }

        }
        void objSearch_SearchWorkOrder(object sender, DataTable dataTable)
        {
            if (dataTable != null)
            {
                LoadSearchWorkOrders(dataTable);
            }
            else
                xMessageBox.Show("No Records Found ...");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //lblTotalToPay.Visible = false;
            //txtTotalToPay.Visible = false;
            //btnProceed.Visible = false;

            ctrSearchWorkOrders objSearchWorkOrder = new ctrSearchWorkOrders();
            objSearchWorkOrder.SearchWorkOrder += objSearch_SearchWorkOrder;
            frmCtr frmCtrSearchWorkOrder = new frmCtr("Search ...");
            frmCtrSearchWorkOrder.Height = objSearchWorkOrder.Height + 40;
            frmCtrSearchWorkOrder.Width = objSearchWorkOrder.Width + 20;
            frmCtrSearchWorkOrder.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtrSearchWorkOrder.frmPnl.Controls.Add(objSearchWorkOrder);
            frmCtrSearchWorkOrder.BringToFront();
            frmCtrSearchWorkOrder.ShowDialog();
        }
    }
}