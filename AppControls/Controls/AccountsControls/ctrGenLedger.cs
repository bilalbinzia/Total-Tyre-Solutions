using DBModule;
using RptModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AppControls
{
    public partial class ctrGenLedger : UserControl
    {
        int TransactionID = 0;
        string ReportDate = "";
        int AccountID;
        int WorkOrderID = 0;
        int PaymentID = 0;
        dbClass dbObject = new dbClass();
        public ctrGenLedger()
        {
            InitializeComponent();
            this.Load += ctrGeneralLedger_Load;
            DGVTByJDailyReport.CellClick += DGVTByJDailyReport_CellClick;
            DGVAccountsJournal.CellClick += DGVAccounts_CellClick;
            //DGVTransactions.CellClick += DGVTransactions_CellClick;
        }

        private void DGVTByJDailyReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string SelectDate = "";
                string strDate = DGVTByJDailyReport.Rows[e.RowIndex].Cells["Report Date"].Value.ToString();
                string[] DateList = strDate.Split('/');
                SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
                this.SelectedDate = SelectDate;
                //SelectDate = Convert.ToDateTime(SelectDate, CultureInfo.InvariantCulture).ToShortDateString();
                //SelectDate = DateTime.ParseExact(SelectDate, "d/M/yyyy h:m:s tt", CultureInfo.InvariantCulture).ToString();
                DataTable dt = dbClass.obj.GetDailyTransactionsListbyDate(this.SelectedDate, this.AccountID);
                DGVGeneralEntries.DataSource = null;
                DGVDailyRepTransactions.DataSource = null;
                GetVoucherList(dt);
            }
        }

        private void DGVAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                decimal TotalBalance=0;
                DataTable dt = new DataTable();
                SelectedAccount = DGVAccountsJournal.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.AccountID = Convert.ToInt32(DGVAccountsJournal.Rows[e.RowIndex].Cells[0].Value);
                if (this.AccountID == 2)
                {
                    dt = dbClass.obj.GetBillsForLiability(this.SelectedDate);
                    ResetControls();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TotalBalance += Convert.ToDecimal(dt.Rows[i]["Balance"]);
                    }
                    
                    DGVDailyRepTransactions.DataSource = dt;
                    DGVDailyRepTransactions.AutoGenerateColumns = true;
                    DGVDailyRepTransactions.AllowUserToAddRows = false;
                    DGVDailyRepTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    DGVDailyRepTransactions.Columns["BillID"].Visible = false;

                    lblTotalDebit.Text= "$0.00";
                    lblTotalCredit.Text = "$" + TotalBalance.ToString();
                }
                else
                {
                    dt = dbClass.obj.GetDailyTransactionsListbyDate(this.SelectedDate, this.AccountID);
                    ResetControls();
                    GetVoucherList(dt);
                }
            }
        }

        public void ResetControls()
        {
            DGVGeneralEntries.DataSource = null;
            DGVDailyRepTransactions.DataSource = null;
            lblDebit.Text = "$0.00";
            lblCredit.Text = "$0.00";
            lblTotalCredit.Text = "$0.00";
            lblTotalDebit.Text = "$0.00";
        }
        public void GetJournalSummaries(DataTable Transdt,DataTable Jsumdt)
        {
            if (Transdt.Rows.Count > 0)
            {
                decimal TotalDebit = 0;
                decimal TotalCredit = 0;
                for (int i = 0; i < Transdt.Rows.Count; i++)
                {
                    TotalDebit += Convert.ToDecimal(Transdt.Rows[i]["Debit"]);
                    TotalCredit += Convert.ToDecimal(Transdt.Rows[i]["Credit"]);
                }
                DSTgrid.DataSource = Transdt;

                lblTransactionDebit.Text = "$" + TotalDebit.ToString();
                lblTransactionCredit.Text = "$" + TotalCredit.ToString();

                DSTgrid.AllowUserToAddRows = false;
                DSTgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            }
        }

        public void GetVoucherList(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("Debit", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Credit", typeof(decimal)));
            
            if (dt.Rows.Count > 0)
            {
                decimal TotalDebit = 0;
                decimal TotalCredit = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dt.Rows[i]["AmountIn"]) == true)
                    {
                        dt.Rows[i]["Credit"] = ".00";
                        dt.Rows[i]["Debit"] = dt.Rows[i]["TotalAmount"];
                        TotalDebit += Convert.ToDecimal(dt.Rows[i]["TotalAmount"]);
                        TotalCredit += Convert.ToDecimal(dt.Rows[i]["Credit"]);
                    }
                    else 
                    {
                        dt.Rows[i]["Debit"] = ".00";
                        dt.Rows[i]["Credit"] = dt.Rows[i]["TotalAmount"];
                        TotalDebit += Convert.ToDecimal(dt.Rows[i]["Debit"]);
                        TotalCredit += Convert.ToDecimal(dt.Rows[i]["TotalAmount"]);
                    }
                }
                DGVDailyRepTransactions.DataSource = dt;

                lblTotalDebit.Text = "$" + TotalDebit.ToString();
                lblTotalCredit.Text = "$" + TotalCredit.ToString();
                //DGVTransactions.AutoGenerateColumns = true;
                //DGVTransactions.AllowUserToAddRows = false;
                //DGVDailyRepTransactions.Columns["Customer"].Width = 270;
                DGVDailyRepTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DGVDailyRepTransactions.Columns["AmountIn"].Visible = false;
                DGVDailyRepTransactions.Columns["TotalAmount"].Visible = false;
                DGVDailyRepTransactions.Columns["AccountID"].Visible = false;
                DGVDailyRepTransactions.Columns["Date"].Visible = false;
                DGVDailyRepTransactions.Columns["InvoiceID"].Visible = false;
                DGVDailyRepTransactions.Columns["WOID"].Visible = false; 
                DGVDailyRepTransactions.Columns[1].Width = 300;

                //DGVDailyRepTransactions.DataSource = dt;
                DGVDailyRepTransactions.AutoGenerateColumns = true;
                DGVDailyRepTransactions.AllowUserToAddRows = false;
                //DGVDailyRepTransactions.Columns["Customer"].Width = 270;
                DGVDailyRepTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            }
        }
        private void ctrGeneralLedger_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadDailyReport();
            LoadPanel();
            this.SelectedDate = Convert.ToDateTime(DateTime.Now, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
            DGVAccountsJournal.Rows[3].Cells[1].Selected = true;
        }

        string SelectedDate = "";
        string SelectedAccount = "";
        void LoadPanel()
        {
            if (taRdTransactionsByJournal.Checked)
            {
                pnlAccount.Visible = false;
                pnlJournalSummaries.Visible = false;

                pnlTransactionJournal.Visible = true;
                pnlTransactionJournal.BringToFront();
            }
        }
        private void taRdTransactionsByJournal_CheckedChanged(object sender, EventArgs e)
        {
            if (taRdTransactionsByJournal.Checked)
            {
                pnlAccount.Visible = false;
                pnlJournalSummaries.Visible = false;

                pnlTransactionJournal.Visible = true;
                pnlTransactionJournal.BringToFront();
            }
        }

        private void taRdJournalSummaries_CheckedChanged(object sender, EventArgs e)
        {
            if (taRdJournalSummaries.Checked)
            {
                pnlAccount.Visible = false;
                pnlTransactionJournal.Visible = false;

                pnlJournalSummaries.Visible = true;
                pnlJournalSummaries.BringToFront();
            }
        }

        private void taRdAccountDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (taRdAccountDetails.Checked)
            {
                pnlJournalSummaries.Visible = false;
                pnlTransactionJournal.Visible = false;

                pnlAccount.Visible = true;
                pnlAccount.BringToFront();
                pnlAccount.Visible = true;
            }
        }

        void LoadAccounts()
        {
            DataTable dt = GetAccounts();
            DataTable GLdt = GetGLAccounts();

            DGVAccountsJournal.DataSource = dt;
            DGVSummaryAccounts.DataSource = dt;

            DGVAccountsJournal.Columns["AccID"].Visible = false;
            DGVAccountsJournal.Columns["AccName"].Width = 150;

            DGVSummaryAccounts.Columns["AccID"].Visible = false;
            DGVSummaryAccounts.Columns["AccName"].Width = 150;

            DGVGLAccounts.DataSource = GLdt;
            DGVGLAccounts.Columns["AccID"].Visible = false;
            DGVGLAccounts.Columns["AccName"].Width = 150;


            DGVAccountsJournal.Rows[3].Cells[1].Selected = true;
        }

        void LoadDailyReport()
        {
            DataTable dt = dbClass.obj.GetDailySaleList();
            dt.Columns.Add(new DataColumn("QB", typeof(bool)));
            dt.Columns.Add(new DataColumn("Er", typeof(bool)));
            DGVTByJDailyReport.DataSource = dt;
            DGVJSDailyReport.DataSource = dt;
           
            DGVTByJDailyReport.Columns["Posted"].Visible = false;
            DGVTByJDailyReport.Columns["QB"].Width = 60;
            DGVTByJDailyReport.Columns["Er"].Width = 60;
            DGVTByJDailyReport.Columns["QB"].Visible = false;
            DGVTByJDailyReport.Columns["Er"].Visible = false;
            DGVTByJDailyReport.Columns["Cheque Sale"].Visible = false;
            DGVTByJDailyReport.Columns["Account Sale"].Visible = false;

            DGVJSDailyReport.Columns["Posted"].Visible = false;
            DGVJSDailyReport.Columns["QB"].Width = 60;
            DGVJSDailyReport.Columns["Er"].Width = 60;
            DGVJSDailyReport.Columns["QB"].Visible = false;
            DGVJSDailyReport.Columns["Er"].Visible = false;
            DGVJSDailyReport.Columns["Cheque Sale"].Visible = false;
            DGVJSDailyReport.Columns["Account Sale"].Visible = false;
        }

        private DataTable GetAccounts()
        {
            DataTable DTaccounts = new DataTable();
            string GetAccountsQuery = "Select AccID,AccName from Account where AccTypeID=0";
            SqlDataAdapter sDA = new SqlDataAdapter(GetAccountsQuery, dbObject.connectionString);
            sDA.Fill(DTaccounts);
            return DTaccounts;
        }

        private DataTable GetGLAccounts()
        {
            DataTable DTaccounts = new DataTable();
            string GetAccountsQuery = "Select AccID,AccName from Account  ORDER BY AccName ";
            SqlDataAdapter sDA = new SqlDataAdapter(GetAccountsQuery, dbObject.connectionString);
            sDA.Fill(DTaccounts);
            return DTaccounts;
        }

        private void DGVDailyRepTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //string strDate = DGVDailyRepTransactions.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                int vNo = Convert.ToInt32(DGVDailyRepTransactions.Rows[e.RowIndex].Cells["InvoiceID"].Value);
                if (DGVDailyRepTransactions.Rows[e.RowIndex].Cells["WOID"].Value != System.DBNull.Value)
                {
                    int WOID = Convert.ToInt32(DGVDailyRepTransactions.Rows[e.RowIndex].Cells["WOID"].Value);
                    this.WorkOrderID = WOID;
                    this.PaymentID = 0;
                }
                else if (DGVDailyRepTransactions.Rows[e.RowIndex].Cells["InvoiceID"].Value != System.DBNull.Value)
                {
                    int PID = Convert.ToInt32(DGVDailyRepTransactions.Rows[e.RowIndex].Cells["InvoiceID"].Value);
                    this.PaymentID = PID;
                    this.WorkOrderID = 0;
                }
                //string[] DateList = strDate.Split('/');
                //SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
                DataTable dt = dbClass.obj.GetJournalTransactions(vNo, this.AccountID);
                GetJournalTransactions(dt);
            }
        }

        public void GetJournalTransactions(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                decimal TotalDebit = 0;
                decimal TotalCredit = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TotalDebit += Convert.ToDecimal(dt.Rows[i]["Debit"]);
                    TotalCredit += Convert.ToDecimal(dt.Rows[i]["Credit"]);
                }
                DGVGeneralEntries.DataSource = dt;
                DGVGeneralEntries.Columns["G/L Account"].Width = 300; 
                lblDebit.Text = "$" + TotalDebit.ToString();
                lblCredit.Text = "$" + TotalCredit.ToString();

                DGVGeneralEntries.AllowUserToAddRows = false;
                DGVGeneralEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            }
            else
            {
                DGVGeneralEntries.DataSource = null;
                lblDebit.Text = "$0.00";
                lblCredit.Text = "$0.00";
            }
        }

        private void DGVJSDailyReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string SelectDate = "";
                string strDate = DGVJSDailyReport.Rows[e.RowIndex].Cells["Report Date"].Value.ToString();
                string[] DateList = strDate.Split('/');
                SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
                //SelectDate = Convert.ToDateTime(SelectDate, CultureInfo.InvariantCulture).ToShortDateString();
                //SelectDate = DateTime.ParseExact(SelectDate, "d/M/yyyy h:m:s tt", CultureInfo.InvariantCulture).ToString();
                DataTable dt = dbClass.obj.GetDailyTransactionsListbyDate(SelectDate, this.AccountID);
                DGVJournalSummaries.DataSource = null;
                DSTgrid.DataSource = null;
                DSTgrid.DataSource = dt;

            }
        }

        private void DGVSummaryAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedAccount = DGVSummaryAccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.AccountID = Convert.ToInt32(DGVAccountsJournal.Rows[e.RowIndex].Cells[0].Value);
                DataTable Tarnsdt = dbClass.obj.GetDailyTransactionsListbyDate(this.SelectedDate, this.AccountID);
                DataTable JSumdt = new DataTable();
                //DataTable JSumdt = dbClass.obj.GetDailySaleTransactionsListbyDate(this.SelectedDate, this.AccountID);
                DGVGeneralEntries.DataSource = null;
                DGVDailyRepTransactions.DataSource = null;

                GetJournalSummaries(Tarnsdt, JSumdt);
            }
        }

        private void btnPreviewTransactions_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            if (this.WorkOrderID > 0)
            {
                StaticInfo.LoadToReport("RptModule", "Reports.CustomerInvoiceReport", "byID", WorkOrderID);
            }
        }

        private void btnPreviewTransactions_Click(object sender, EventArgs e)
        {
            if (this.WorkOrderID > 0)
            {
                StaticInfo.LoadToReport("RptModule", "Reports.CustomerInvoiceReport", "byID", WorkOrderID);
            }
        }

        private void btnPreviewJTrans_Click(object sender, EventArgs e)
        {
            if (this.WorkOrderID > 0)
            {
                // int WOID = dbClass.obj.WorkOrderIDByCustomerReceipt(this.WorkOrderID);
                StaticInfo.LoadToReport("RptModule", "Reports.CustomerInvoiceReport", "byID", this.WorkOrderID);
            }
            else if (this.PaymentID > 0)
            {
                StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentHistoryReportDuplicate", "byID", PaymentID);
            }
        }

        private void btnPreviewJT_Click(object sender, EventArgs e)
        {
            if (this.WorkOrderID > 0)
            {
                // int WOID = dbClass.obj.WorkOrderIDByCustomerReceipt(this.WorkOrderID);
                StaticInfo.LoadToReport("RptModule", "Reports.CustomerInvoiceReport", "byID", this.WorkOrderID);
            }
            else if (this.PaymentID > 0)
            {
                StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentHistoryReportDuplicate", "byID", PaymentID);
                //frmRpt objList = new frmRpt("Reports.VendorPaymentHistoryReportDuplicate", "byID", this.PaymentID);
                //frmCtr frmCtr = new frmCtr("Vendor Payment Report");
                //frmCtr.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                //frmCtr.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //frmCtr.frmPnl.Controls.Add(objList);
                //frmCtr.BringToFront();
                //frmCtr.ShowDialog();
            }
        }
    }
}
