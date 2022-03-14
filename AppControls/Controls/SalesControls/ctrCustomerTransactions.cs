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

namespace AppControls
{
    public partial class ctrCustomerTransactions : UserControl
    {
        MainDataSet objDataSet;        
        BindingSource bindingSource1;
        BindingSource CustomerWorkOrdersBS;
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedCustomerID = 0;
        int SelectedPaymentID = 0;

        public ctrCustomerTransactions()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            bindingSource1 = new BindingSource();
            CustomerWorkOrdersBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrWorkOrderList_Load;

            btnVoidPayment.Click += btnVoidPayment_Click;
            //btnNewCustomerQuote.Click += btnNewCustomerQuote_Click;
            //btnWOforSelectedCustomer.Click += btnWOforSelectedCustomer_Click;
            //btnQuoteforSelectedCustomer.Click += btnQuoteforSelectedCustomer_Click;
            //btnNegate.Click += btnNegate_Click;
            //btnRefreshWorkOrders.Click += btnRefreshWorkOrders_Click;

            DGVCustomerList.TDataGridView.CellClick += DGVCustomerList_TDataGridView_CellClick;
            DGVWorkOrderList.TDataGridView.CellClick += DGVWorkOrderList_TDataGridView_CellClick;

            //DGVWorkOrderList.TDataGridView.CellClick += TDataGridView_CellClick;
            //DGVWorkOrderList.TDataGridView.DoubleClick += TDataGridView_DoubleClick;
            //btnWorkOrderPrint.Click += btnWorkOrderPrint_Click;
            //btnRefundDeposit.Click += btnRefundDeposit_Click;

            //LoadNewCustomerWorkOrders();
        }

        private void DGVWorkOrderList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVWorkOrderList.TDataGridView.Rows.Count > 0)
            {
                DataRowView curRow1 = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
                SelectedPaymentID = Convert.ToInt32(curRow1["PaymentID"]);
            }
        }

        //private void btnRefreshWorkOrders_Click(object sender, EventArgs e)
        //{
        //    LoadNewCustomerWorkOrders();
        //}

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
            //if (SelectedWorkOrderID > 0)
            //{
            //    DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            //    if (curRow != null)
            //    {
            //        string ctrName = Convert.ToString(curRow["ctrName"]);
            //        string ctrType = Convert.ToString(curRow["Type"]);
            //        string ctrStatus = Convert.ToString(curRow["Status"]);
            //        Boolean isNegated = Convert.ToBoolean(curRow["IsNegated"]);

            //        if (ctrName == "ctrCustomerReceipt" && ctrType == "Invoice" && ctrStatus == "Completed" && isNegated == false)
            //        {
            //            ctrNegateWindow objNegateWindow = new ctrNegateWindow(Convert.ToInt32(curRow["ID"]));
            //            //----------------------------------------------------------------------//
            //            frmCtr frmCtr = new frmCtr("Invoice Negate ...");
            //            frmCtr.Height = objNegateWindow.Height + 20; frmCtr.Width = objNegateWindow.Width + 20;
            //            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //            frmCtr.frmPnl.Controls.Add(objNegateWindow);
            //            frmCtr.BringToFront();
            //            frmCtr.ShowDialog();
            //        }
            //    }
            //}
            //else { }
        }
        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            SelectedPaymentID = Convert.ToInt32(curRow["ID"]);
        }
        
        void TDataGridView_DoubleClick(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrderList.TDataGridView.DataSource).Current;
            if (curRow != null)
            {
                string ctrName = Convert.ToString(curRow["ctrName"]);
                switch (ctrName)
                {
                    case "ctrWorkOrder":
                        StaticInfo.LoadToControl("AppControls.ctrWorkOrder", "WorkOrderOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                        break;
                    //case "ctrCustomerReceipt":
                    //    StaticInfo.LoadToControl("AppControls.ctrCustomerReceipt", "CustomerReceiptOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                    //    break;
                    //case "ctrWorkOrderNegate":
                    //    StaticInfo.LoadToControl("AppControls.ctrWorkOrderNegate", "WorkOrderNegateOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                    //    break;
                    //case "ctrCustomerPayment":
                    //    StaticInfo.LoadToControl("AppControls.ctrCustomerPayment", "CustomerPaymentOpen", Convert.ToInt32(curRow["ID"]), Convert.ToInt32(curRow["CustomerID"]));
                    //    break;
                }                  
            }
        }        
        void DGVCustomerList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVCustomerList.TDataGridView.DataSource).Current;
            SelectedCustomerID = Convert.ToInt32(curRow["ID"]);
            if (SelectedCustomerID > 0)
                LoadSelectedCustomerWorkOrders();
        }
        void btnVoidPayment_Click(object sender, EventArgs e)
        {
            bool Posted = false;
            if (SelectedPaymentID > 0)
            {
                DataRow drPayment = dbClass.obj.getVendorPaymentByID(SelectedPaymentID);
                Posted = Convert.ToBoolean(drPayment["IsLocked"]);
                if (Posted)
                {
                    xMessageBox.Show("Can't Delete Processed Payment....");
                }
                else
                {
                    if (xMessageBox.Show("Do you want to Void this payment ...?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool BIsPaid = false;
                        string BillType = "", BType = "";
                        int BillID = 0, PaymentID = 0;
                        decimal PaidAmount = 0, BillBalance = 0;
                        decimal BPaidAmount = 0, BBalance = 0;

                        DataTable dt = dbClass.obj.getVendorPaymentByVendorIDAndPaymentID(SelectedCustomerID, SelectedPaymentID);

                        foreach (DataRow dr in dt.Rows)
                        {
                            PaymentID = Convert.ToInt32(dr["PaymentID"]);
                            BillID = Convert.ToInt32(dr["BillID"]);
                            //PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                            //BillBalance = Convert.ToDecimal(dr["BillBalance"]);

                            //DataRow drBill = dbClass.obj.getVendorBillByID(BillID);
                            //if (drBill["PaidAmount"] != DBNull.Value)
                            //{
                            //    BPaidAmount = Convert.ToDecimal(drBill["PaidAmount"]);
                            //}
                            //if (drBill["Balance"] != DBNull.Value)
                            //{
                            //    BBalance = Convert.ToDecimal(drBill["Balance"]);
                            //}
                            //BPaidAmount = BPaidAmount - PaidAmount;

                            //BBalance += PaidAmount;
                            //BIsPaid = false;
                            //BType = "B";

                            //dbClass.obj.UpdateVendorBill(BillID, 0, BPaidAmount, BBalance, false, BType);
                            dbClass.obj.UpdateVendorPaymentActive(PaymentID, BillID);
                        }
                        dbClass.obj.UpdateVendorPaymentHistoryActive(SelectedCustomerID, SelectedPaymentID);
                        //dbClass.obj.UpdateVendorPaymentTempActive(SelectedCustomerID, SelectedPaymentID);
                        LoadSelectedCustomerWorkOrders();
                    }
                }
            }
            else
                xMessageBox.Show("Please Select any Payment....");
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
            try
            {
                DataTable dt2 = dbClass.obj.GetPaymentHistoryByCustomerID(SelectedCustomerID);
                DataView dv = dt2.DefaultView;
                dv.Sort = "ID desc";
                DataTable dt = dv.ToTable();
                //CustomerWorkOrdersBS.DataSource = null;
                //CustomerWorkOrdersBS.DataSource = dt;

                //DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;


                DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
                DGVWorkOrderList.TDataGridView.Enabled = true;
                DGVWorkOrderList.TDataGridView.ReadOnly = false;

                DGVWorkOrderList.TDataGridView.DataSource = dt;
                //DGVVendorPaymentList.TDataGridView.Sort(DGVVendorPaymentList.TDataGridView.Columns["PaymentID"], ListSortDirection.Descending);

                //foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
                //{ gridColumn.Visible = false; gridColumn.ReadOnly = true; }

                //---------------------------------------------------------
                //DGVWorkOrderList.TDataGridView.Columns["PaymentID"].Width = 40;
                //DGVWorkOrderList.TDataGridView.Columns["PaymentID"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["PaymentID"].HeaderText = "TransNo";
                //DGVWorkOrderList.TDataGridView.Columns["PaymentID"].DisplayIndex = 1;

                //DGVWorkOrderList.TDataGridView.Columns["TrnsDate"].Width = 70;
                //DGVWorkOrderList.TDataGridView.Columns["TrnsDate"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["TrnsDate"].HeaderText = "Date";
                //DGVWorkOrderList.TDataGridView.Columns["TrnsDate"].DisplayIndex = 2;

                //DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Width = 70;
                //DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Payment No";
                //DGVWorkOrderList.TDataGridView.Columns["InvoiceNo"].DisplayIndex = 3;

                //DGVWorkOrderList.TDataGridView.Columns["BillIDs"].Width = 120;
                //DGVWorkOrderList.TDataGridView.Columns["BillIDs"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["BillIDs"].HeaderText = "Applied To";
                //DGVWorkOrderList.TDataGridView.Columns["BillIDs"].DisplayIndex = 4;

                //DGVWorkOrderList.TDataGridView.Columns["PaidAmount"].Width = 120;
                //DGVWorkOrderList.TDataGridView.Columns["PaidAmount"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["PaidAmount"].HeaderText = "Paid Amount";
                //DGVWorkOrderList.TDataGridView.Columns["PaidAmount"].DisplayIndex = 5;

                //DGVWorkOrderList.TDataGridView.Columns["CoName"].Width = 150;
                //DGVWorkOrderList.TDataGridView.Columns["CoName"].Visible = true;
                //DGVWorkOrderList.TDataGridView.Columns["CoName"].HeaderText = "Store";
                //DGVWorkOrderList.TDataGridView.Columns["CoName"].DisplayIndex = 6;
            }
            catch(Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
        //void LoadNewCustomerWorkOrders()
        //{
        //    DataTable dt2 = dbClass.obj.FillLatestCustomerWorkOrders();

        //    DataView dv = dt2.DefaultView;
        //    dv.Sort = "ID desc";
        //    DataTable dt = dv.ToTable();
        //    //CustomerWorkOrdersBS.DataSource = null;
        //    CustomerWorkOrdersBS.DataSource = dt;
           
        //    DGVWorkOrderList.TDataGridView.DataSource = CustomerWorkOrdersBS;
            
        //    DGVWorkOrderList.TDataGridView.AutoGenerateColumns = true;
        //    DGVWorkOrderList.TDataGridView.Enabled = true;
        //    DGVWorkOrderList.TDataGridView.ReadOnly = false;


        //    foreach (DataGridViewColumn gridColumn in DGVWorkOrderList.TDataGridView.Columns)
        //    { 
        //        gridColumn.Visible = false; 
        //        gridColumn.ReadOnly = true;
        //    }

        //    //---------------------------------------------------------
        //    DGVWorkOrderList.TDataGridView.Columns["TransNo"].Width = 50;
        //    DGVWorkOrderList.TDataGridView.Columns["TransNo"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["TransNo"].HeaderText = "Date";
        //    DGVWorkOrderList.TDataGridView.Columns["TransNo"].DisplayIndex = 1;

        //    DGVWorkOrderList.TDataGridView.Columns["Date"].Width = 80;
        //    DGVWorkOrderList.TDataGridView.Columns["Date"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "Date";
        //    DGVWorkOrderList.TDataGridView.Columns["Date"].DisplayIndex = 2;

        //    DGVWorkOrderList.TDataGridView.Columns["Type"].Width = 80;
        //    DGVWorkOrderList.TDataGridView.Columns["Type"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["Type"].HeaderText = "Type";
        //    DGVWorkOrderList.TDataGridView.Columns["Type"].DisplayIndex = 3;

        //    //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Width = 50;
        //    //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].HeaderText = "WO#";
        //    //DGVWorkOrderList.TDataGridView.Columns["WorkOrderNo"].DisplayIndex = 4;

        //    DGVWorkOrderList.TDataGridView.Columns["Paid by"].Width = 160;
        //    DGVWorkOrderList.TDataGridView.Columns["Paid by"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Paid by"].HeaderText = "Paid by (Company)";
        //    DGVWorkOrderList.TDataGridView.Columns["Paid by"].DisplayIndex = 4;

        //    DGVWorkOrderList.TDataGridView.Columns["Rep"].Width = 50;
        //    DGVWorkOrderList.TDataGridView.Columns["Rep"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Rep"].DisplayIndex = 5;

        //    DGVWorkOrderList.TDataGridView.Columns["PONo"].Width = 100;
        //    DGVWorkOrderList.TDataGridView.Columns["PONo"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["PONo"].HeaderText = "PONo";
        //    DGVWorkOrderList.TDataGridView.Columns["PONo"].DisplayIndex = 6;

        //    //DGVWorkOrderList.TDataGridView.Columns["Mileage"].Width = 50;
        //    DGVWorkOrderList.TDataGridView.Columns["Mileage"].Visible = false;
        //    //DGVWorkOrderList.TDataGridView.Columns["Mileage"].DisplayIndex = 8;
        //    //DGVWorkOrderList.TDataGridView.Columns["Mileage"].ReadOnly = false;

        //    DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Width = 100;
        //    DGVWorkOrderList.TDataGridView.Columns["Vehicle"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Vehicle"].DisplayIndex = 7;

        //    DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Width = 60;
        //    DGVWorkOrderList.TDataGridView.Columns["Open Amt"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Open Amt"].DisplayIndex = 8;
        //    DGVWorkOrderList.TDataGridView.Columns["Open Amt"].ReadOnly = false;

        //    DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Width = 60;
        //    DGVWorkOrderList.TDataGridView.Columns["Total Amt"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Total Amt"].DisplayIndex = 9;
        //    //DGVWorkOrderList.TDataGridView.Columns["Total Amt"].ReadOnly = false;

        //    //DGVWorkOrderList.TDataGridView.Columns["Mech"].Width = 30;
        //    //DGVWorkOrderList.TDataGridView.Columns["Mech"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["Mech"].DisplayIndex = 12;

        //    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
        //    col.UseColumnTextForButtonValue = true;
        //    col.Text = "";
        //    col.Name = "btnMech";
        //    col.HeaderText = "Mech";
        //    col.Width = 50;
        //    col.DisplayIndex = 10;
        //    DGVWorkOrderList.TDataGridView.Columns.Add(col);

        //    DGVWorkOrderList.TDataGridView.Columns["Status"].Width = 80;
        //    DGVWorkOrderList.TDataGridView.Columns["Status"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Status"].DisplayIndex = 11;

        //    DGVWorkOrderList.TDataGridView.Columns["Description"].Width = 150;
        //    DGVWorkOrderList.TDataGridView.Columns["Description"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Description"].DisplayIndex = 12;

        //    DGVWorkOrderList.TDataGridView.Columns["Category"].Width = 80;
        //    DGVWorkOrderList.TDataGridView.Columns["Category"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Category"].DisplayIndex = 13;

        //    DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Width = 60;
        //    DGVWorkOrderList.TDataGridView.Columns["ShipVia"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["ShipVia"].DisplayIndex = 14;

        //    DGVWorkOrderList.TDataGridView.Columns["Phone"].Width = 120;
        //    DGVWorkOrderList.TDataGridView.Columns["Phone"].Visible = true;
        //    DGVWorkOrderList.TDataGridView.Columns["Phone"].DisplayIndex = 15;

        //    //DGVWorkOrderList.TDataGridView.Columns["Store"].Width = 30;
        //    //DGVWorkOrderList.TDataGridView.Columns["Store"].Visible = true;
        //    //DGVWorkOrderList.TDataGridView.Columns["Store"].DisplayIndex = 18;
        //    ////---------------------------------------------------------
        //    //chkboxShowBillsOnHold.Checked = false;
        //    //chkboxShowClosedTransactions.Checked = false;
        //    //txtTotalToPay.Text = "";
        //    //txtTotalDiscount.Text = "";
        //    //txtTotalApplied.Text = "";
        //    //rbtnCash.Checked = true;
        //    //rbtnCheck.Checked = false;
        //    //txtCheckNo.Text = "";
        //    //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
        //    //chkboxPrint.Checked = false;
        //    //txtNotes.Text = "";
        //    ////---------------------------------------------------------

        //}
    }
}