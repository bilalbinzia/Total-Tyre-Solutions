using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System.Globalization;
using System.Data.SqlClient;

namespace AppControls
{
    public partial class ctrGeneralLedger : UserControl
    {
        int TransactionID = 0;
        string ReportDate = "";
        dbClass dbObject = new dbClass();
        public ctrGeneralLedger()
        {
            InitializeComponent();
            this.Load += ctrGeneralLedger_Load;
            //DGVDailyReportTransaction.CellClick += DGVDailyReport_CellClick;
            DGVAccountsJournal.CellClick += DGVAccounts_CellClick;
            //DGVTransactions.CellClick += DGVTransactions_CellClick;

            taRdTransactionsByJournal.Click += taRdTransactionsByJournal_Click;
            taRdAccountDetails.Click += taRdAccountDetails_Click;
            taRdJournalSummaries.Click += taRdJournalSummaries_Click;
        }

        string SelectedDate = "";
        string SelectedAccount = "";
        private void ctrGeneralLedger_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            LoadDailyReport();
        }

        void LoadAccounts()
        {
            DataTable dt = GetAccounts();
            DGVAccountsJournal.DataSource = dt;
            DGVAccountsJournal.Columns["AccID"].Width=80;
            DGVAccountsJournal.Columns["AccName"].Width = 150;
            //DataTable table = new DataTable();
            //DataTable dt = dbClass.obj.FillAccountList();
            //DGVAccountsJournal.DataSource = dt;
            //DGVAccountsJournal.AutoGenerateColumns = true;
            //DGVAccountsJournal.AllowUserToAddRows = false;
            //DGVAccountsJournal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //DGVAccountsJournal.Columns["ID"].Visible = false;
            //DGVAccountsJournal.Columns["AccName"].Visible = true;
            //DGVAccountsJournal.Columns["AccName"].Width = 220;
            //DGVAccountsJournal.Columns["AccName"].HeaderText = "Journal";

            //DataTable Datedt = new DataTable();
            //Datedt.Columns.Add(new DataColumn("SDate", typeof(bool)));
            //DGVSummaryDate.DataSource = Datedt;
            //DGVSummaryDate.AutoGenerateColumns = true;
            //DGVSummaryDate.AllowUserToAddRows = false;
            //DGVSummaryDate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //DGVSummaryDate.Columns["SDate"].Visible = true;
            //DGVSummaryDate.Columns["SDate"].Width = 220;
            //DGVSummaryDate.Columns["SDate"].HeaderText = "Date";
        }

        void LoadDailyReport()
        {
            DataTable dt = dbClass.obj.GetDailySaleList();
            dt.Columns.Add(new DataColumn("QB", typeof(bool)));
            dt.Columns.Add(new DataColumn("Er", typeof(bool)));
            DRTgrid.DataSource = dt;
            ////DGVItemList.SetSource(ItemBS);
            //DGVDailyReportTransaction.DataSource = dt;
            //DGVDailyReportTransaction.AutoGenerateColumns = true;
            //DGVDailyReportTransaction.AllowUserToAddRows = false;
            //DGVDailyReportTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //foreach(DataGridViewRow row in DRTgrid.Rows)
            //{
            //    row.DefaultCellStyle.BackColor = Color.Bisque;
            //}
            DRTgrid.Columns["Posted"].Visible = false;
            DRTgrid.Columns["QB"].Width = 60;
            DRTgrid.Columns["Er"].Width = 60;
            DRTgrid.Columns["QB"].Visible = false;
            DRTgrid.Columns["Er"].Visible = false;
        }

        void DGVAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedAccount = DGVAccountsJournal.Rows[e.RowIndex].Cells[1].Value.ToString();
                DataTable dt = dbClass.obj.GetDailyTransactionsListbyDate(SelectedDate, 4);
                if (dt.Rows.Count > 0)
                {
                    DTgrid.AllowUserToAddRows = false;
                    DTgrid.DataSource = dt;
                    DTgrid.Columns["Customer"].Width = 270;
                }
            }
        }

        //private void DGVDailyReport_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        string SelectDate = "";
        //        string strDate = DGVDailyReportTransaction.Rows[e.RowIndex].Cells["Report Date"].Value.ToString();
        //        string[] DateList = strDate.Split('/');
        //        SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
        //        //SelectDate = Convert.ToDateTime(SelectDate, CultureInfo.InvariantCulture).ToShortDateString();
        //        SelectDate = DateTime.ParseExact(SelectDate, "d/M/yyyy h:m:s tt", CultureInfo.InvariantCulture).ToString();
        //        DataTable dt = dbClass.obj.GetDailyTransactionsListbyDate(SelectDate, SelectedAccount);
        //        dt.Columns.Add(new DataColumn("Credit", typeof(decimal)));
        //        if (dt.Rows.Count > 0)
        //        {
        //            decimal TotalDebit = 0;
        //            decimal TotalCredit = 0;
        //            for (int i=0; i<dt.Rows.Count; i++)
        //            {
        //                dt.Rows[i]["Credit"] = ".00";
        //                TotalDebit += Convert.ToDecimal(dt.Rows[i]["Debit"]);
        //                TotalCredit += Convert.ToDecimal(dt.Rows[i]["Credit"]);
        //            }
        //            DGVTransactions.DataSource = dt;

        //            lblTotalDebit.Text = "$"+TotalDebit.ToString();
        //            lblTotalCredit.Text = "$" + TotalCredit.ToString();
        //            DGVTransactions.AutoGenerateColumns = true;
        //            DGVTransactions.AllowUserToAddRows = false;
        //            DGVTransactions.Columns["Customer"].Width = 270;
        //            DGVTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //            DGVSummaryTransactions.DataSource = dt;

        //            DGVSummaryTransactions.AutoGenerateColumns = true;
        //            DGVSummaryTransactions.AllowUserToAddRows = false;
        //            DGVSummaryTransactions.Columns["Customer"].Width = 270;
        //            DGVSummaryTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        //        }
        //    }
        //}

        //private void DGVTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataTable dt = new DataTable();
        //        TransactionID = Convert.ToInt32(DGVTransactions.Rows[e.RowIndex].Cells[1].Value);
        //        string strDate = DGVTransactions.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        string[] DateList = strDate.Split('/');
        //        ReportDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
        //        dt = dbClass.obj.GetJournalTransactions(TransactionID, ReportDate);

        //        if (dt.Rows.Count > 0)
        //        {
        //            string TotalDebit = "";
        //            decimal TotalCredit = 0;
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                DataRow dr = dt.Rows[i];
        //                if (i != 0 && dr["Credit"].ToString() == "0.00")
        //                {
        //                    dr.Delete();
        //                    continue;
        //                }
        //                if (i == 0)
        //                {
        //                    string dEBITs = "";
        //                    dEBITs = Convert.ToString(dt.Rows[i]["Debit"]);
        //                    TotalDebit = "$" + dEBITs.ToString();
        //                    //TotalDebit = dt.Rows[i]["Debit"].ToString();
        //                }
        //                string dEBIT = "";
        //                dEBIT = Convert.ToString(dt.Rows[i]["Debit"]);
        //                dt.Rows[i]["Debit"] = "$" + dEBIT.ToString();

        //                string cREDIT = "";
        //                cREDIT = Convert.ToString(dt.Rows[i]["Credit"]);
        //                dt.Rows[i]["Credit"] = "$" + cREDIT.ToString();

        //                TotalCredit += Convert.ToDecimal(cREDIT);

        //            }
        //            lblCredit.Text = "$" + TotalCredit.ToString();
        //            lblDebit.Text = TotalDebit;
        //            DGVJournalEntries.AutoGenerateColumns = true;
        //            DGVJournalEntries.AllowUserToAddRows = false;
        //            DGVJournalEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //            DGVJournalEntries.DataSource = dt;
        //            DGVJournalEntries.Columns["G/L Account"].Width = 220;
        //            DGVJournalEntries.Columns["Debit"].Width = 80;
        //            DGVJournalEntries.Columns["Credit"].Width = 80;
        //        }
        //    }
        //}

        private void taRdTransactionsByJournal_Click(object sender, EventArgs e)
        {
            if (taRdTransactionsByJournal.Checked)
            {
                //pnlAccountDetails.Visible = false;
                pnlSummaries.Visible = false;

                pnlJournal.Visible = true;
                pnlJournal.BringToFront();
            }
        }

        private void taRdAccountDetails_Click(object sender, EventArgs e)
        {
            if (taRdAccountDetails.Checked)
            {
                //pnlJournal.Visible = false;
                pnlSummaries.Visible = false;


                //pnlAccountDetails.Visible = true;
                //pnlAccountDetails.Visible = true;
                //pnlAccountDetails.BringToFront();
            }
        }

        private void taRdJournalSummaries_Click(object sender, EventArgs e)
        {
            if (taRdJournalSummaries.Checked)
            {
                //pnlJournal.Visible = false;
                pnlSummaries.Visible = true;
                pnlSummaries.BringToFront();
            }
        }

        private void DRTgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string SelectDate = "";
                string strDate = DRTgrid.Rows[e.RowIndex].Cells["Report Date"].Value.ToString();
                string[] DateList = strDate.Split('/');
                SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
                //SelectDate = Convert.ToDateTime(SelectDate, CultureInfo.InvariantCulture).ToShortDateString();
                //SelectDate = DateTime.ParseExact(SelectDate, "d/M/yyyy h:m:s tt", CultureInfo.InvariantCulture).ToString();
                DataTable dt = dbClass.obj.GetDailyTransactionsListbyDate(SelectDate, 4);
                dt.Columns.Add(new DataColumn("Credit", typeof(decimal)));
                if (dt.Rows.Count > 0)
                {
                    decimal TotalDebit = 0;
                    decimal TotalCredit = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Credit"] = ".00";
                        TotalDebit += Convert.ToDecimal(dt.Rows[i]["Debit"]);
                        TotalCredit += Convert.ToDecimal(dt.Rows[i]["Credit"]);
                    }
                    DTgrid.DataSource = dt;

                    lblTotalDebit.Text = "$" + TotalDebit.ToString();
                    lblTotalCredit.Text = "$" + TotalCredit.ToString();
                    //DGVTransactions.AutoGenerateColumns = true;
                    //DGVTransactions.AllowUserToAddRows = false;
                    DTgrid.Columns["Customer"].Width = 270;
                    DTgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    DSTgrid.DataSource = dt;

                    //DSTgrid.AutoGenerateColumns = true;
                    DSTgrid.AllowUserToAddRows = false;
                    DSTgrid.Columns["Customer"].Width = 270;
                    DSTgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                }
            }
        }

        private void DRTgrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                DRTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                DRTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void DSTgrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                DSTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                DSTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void DTgrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                DTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                DTgrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
        private DataTable GetAccounts()
        {
            DataTable DTaccounts = new DataTable();
            string GetAccountsQuery = "Select AccID,AccName from Account";
            SqlDataAdapter sDA = new SqlDataAdapter(GetAccountsQuery, dbObject.connectionString);
            sDA.Fill(DTaccounts);
            return DTaccounts;
        }

        private void DGVAccountsJournal_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                DGVAccountsJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                DGVAccountsJournal.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }
}
