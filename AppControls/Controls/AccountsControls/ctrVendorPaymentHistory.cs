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
using RptModule;

namespace AppControls
{
    public partial class ctrVendorPaymentHistory : UserControl
    {
        MainDataSet objDataSet;

       // BindingSource VendorBS;
        BindingSource VendorPaymentHistoryBS;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedPaymentID = 0;
        int SelectedVendorID = 0;

        public ctrVendorPaymentHistory()
        {
            Initialize();
        }
        public ctrVendorPaymentHistory(int VendorID)
        {
            this.SelectedVendorID = VendorID;
            Initialize();
        }
        void Initialize()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();

           // VendorBS = new BindingSource();
            VendorPaymentHistoryBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrVendorPaymentList_Load;
            //DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorPaymentList.TDataGridView.CellClick += DGVVendorPaymentList_TDataGridView_CellClick;
            DGVVendorPaymentList.TDataGridView.DoubleClick += DGVVendorPaymentList_TDataGridView_CellDoubleClick;
            btnVoidPayment.Click += btnVoidPayment_Click;
            chkboxShowAll.CheckedChanged += chkboxShowAll_CheckedChanged;
            chkboxShowVoid.CheckedChanged += chkboxShowVoid_CheckedChanged;
        }

        //void btnPrintPayment_Click(object sender, EventArgs e)
        //{
        //    if (SelectedPaymentID > 0)
        //        StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentReport", "byID", SelectedPaymentID);

        //}
        void btnVoidPayment_Click(object sender, EventArgs e)
        {
            bool Posted = false, Active=false;
            if (SelectedPaymentID > 0)
            {
                DataRow drPayment = dbClass.obj.getVendorPaymentByID(SelectedPaymentID);
                Posted = Convert.ToBoolean(drPayment["IsLocked"]);
                Active = Convert.ToBoolean(drPayment["Active"]); 
                if (Posted)
                {
                    xMessageBox.Show("Can't Delete Processed Payment....");
                }
                else
                {
                    if (Active)
                    {
                        if (xMessageBox.Show("Do you want to Void this payment ...?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool BIsPaid = false;
                            string BillType = "", BType = "";
                            int BillID = 0, PaymentID = 0;
                            decimal PaidAmount = 0, BillBalance = 0;
                            decimal BPaidAmount = 0, BBalance = 0;

                            DataTable dt = dbClass.obj.getVendorPaymentByVendorIDAndPaymentID(SelectedVendorID, SelectedPaymentID);

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
                            dbClass.obj.UpdateVendorPaymentHistoryActive(SelectedVendorID, SelectedPaymentID);
                            //dbClass.obj.UpdateVendorPaymentTempActive(SelectedVendorID, SelectedPaymentID);
                            LoadSelectedVendorPaymentsHistory();
                        }
                    }
                    else 
                    {
                        xMessageBox.Show("Payment already Void....");
                    }
                    
                }
            }
            else
                xMessageBox.Show("Please Select any Payment....");
        }
        void chkboxShowAll_CheckedChanged(object sender, EventArgs e) 
        {
            LoadSelectedVendorPaymentsHistory();
        }
        void chkboxShowVoid_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedVendorPaymentsHistory();
        }        
        void DGVVendorPaymentList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVVendorPaymentList.TDataGridView.Rows.Count > 0)
            {
                DataRowView curRow1 = (DataRowView)((BindingSource)DGVVendorPaymentList.TDataGridView.DataSource).Current;
                SelectedPaymentID = Convert.ToInt32(curRow1["PaymentID"]);
            }
        }
        void DGVVendorPaymentList_TDataGridView_CellDoubleClick(object sender, EventArgs e)
        {            
            DataRowView curRow1 = (DataRowView)((BindingSource)DGVVendorPaymentList.TDataGridView.DataSource).Current;
            SelectedPaymentID = Convert.ToInt32(curRow1["PaymentID"]);

            //if (curRow1["Type"].ToString() == "Payment")
            //{

                frmRpt objList = new frmRpt("Reports.VendorPaymentHistoryReportDuplicate", "byID", SelectedPaymentID);
                frmCtr frmCtr = new frmCtr("Vendor Payment Report");
                frmCtr.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                frmCtr.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            //}

           // StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentHistoryReportDuplicate", "", SelectedPaymentID;
        }

        //void DGVVendorList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataRowView curRow = (DataRowView)((BindingSource)DGVVendorList.TDataGridView.DataSource).Current;
        //    SelectedVendorID = Convert.ToInt32(curRow["ID"]);
        //    if (SelectedVendorID > 0)
        //        LoadSelectedVendorPaymentsHistory(SelectedVendorID);
        //}
        void ctrVendorPaymentList_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            //DataTable dt = dbClass.obj.FillVendorList();
            //VendorBS.DataSource = dt;
            //DGVVendorList.SetSource(VendorBS);

            //DGVVendorList.TDataGridView.Columns["Name"].Width = 350;
            //DGVVendorList.TDataGridView.Columns["Phone"].Width = 120;
            //DGVVendorList.TDataGridView.Columns["ContactPerson"].Width = 240;
            //DGVVendorList.TDataGridView.Columns["Balance"].Width = 100;

            if (SelectedVendorID > 0)
                LoadSelectedVendorPaymentsHistory();

        }
        void LoadSelectedVendorPaymentsHistory()
        {
            DataTable dt = new DataTable();
            if (SelectedVendorID > 0) 
            {
                if(chkboxShowVoid.Checked)
                    dt = dbClass.obj.FillVendorPaymentHistoryVoidByVendorID(SelectedVendorID);
                else if (chkboxShowAll.Checked)
                    dt = dbClass.obj.FillVendorPaymentHistoryAllByVendorID(SelectedVendorID);
                else
                    dt = dbClass.obj.FillVendorPaymentHistoryPaymentByVendorID(SelectedVendorID);
            }
                
            VendorPaymentHistoryBS.DataSource = dt;
            DGVVendorPaymentList.TDataGridView.AutoGenerateColumns = true;
            DGVVendorPaymentList.TDataGridView.Enabled = true;
            DGVVendorPaymentList.TDataGridView.ReadOnly = false;

            DGVVendorPaymentList.TDataGridView.DataSource = VendorPaymentHistoryBS;
            //DGVVendorPaymentList.TDataGridView.Sort(DGVVendorPaymentList.TDataGridView.Columns["PaymentID"], ListSortDirection.Descending);

            foreach (DataGridViewColumn gridColumn in DGVVendorPaymentList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }

            //---------------------------------------------------------
            DGVVendorPaymentList.TDataGridView.Columns["PaymentID"].Width = 40;
            DGVVendorPaymentList.TDataGridView.Columns["PaymentID"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["PaymentID"].HeaderText = "TransNo";
            DGVVendorPaymentList.TDataGridView.Columns["PaymentID"].DisplayIndex = 1;

            DGVVendorPaymentList.TDataGridView.Columns["TrnsDate"].Width = 70;
            DGVVendorPaymentList.TDataGridView.Columns["TrnsDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVVendorPaymentList.TDataGridView.Columns["TrnsDate"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["TrnsDate"].HeaderText = "Date";
            DGVVendorPaymentList.TDataGridView.Columns["TrnsDate"].DisplayIndex = 2;

            DGVVendorPaymentList.TDataGridView.Columns["InvoiceNo"].Width = 70;
            DGVVendorPaymentList.TDataGridView.Columns["InvoiceNo"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Payment No";
            DGVVendorPaymentList.TDataGridView.Columns["InvoiceNo"].DisplayIndex = 3;

            DGVVendorPaymentList.TDataGridView.Columns["Type"].Width = 70;
            DGVVendorPaymentList.TDataGridView.Columns["Type"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVVendorPaymentList.TDataGridView.Columns["Type"].DisplayIndex = 4;

            DGVVendorPaymentList.TDataGridView.Columns["BillIDs"].Width = 350;
            DGVVendorPaymentList.TDataGridView.Columns["BillIDs"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["BillIDs"].HeaderText = "Applied To";
            DGVVendorPaymentList.TDataGridView.Columns["BillIDs"].DisplayIndex = 5;

            DGVVendorPaymentList.TDataGridView.Columns["PaidAmount"].Width = 120;
            DGVVendorPaymentList.TDataGridView.Columns["PaidAmount"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["PaidAmount"].HeaderText = "Paid Amount";
            DGVVendorPaymentList.TDataGridView.Columns["PaidAmount"].DisplayIndex = 6;

            DGVVendorPaymentList.TDataGridView.Columns["CoName"].Width = 200;
            DGVVendorPaymentList.TDataGridView.Columns["CoName"].Visible = true;
            DGVVendorPaymentList.TDataGridView.Columns["CoName"].HeaderText = "Store";
            DGVVendorPaymentList.TDataGridView.Columns["CoName"].DisplayIndex = 7;

        }

    }
}
