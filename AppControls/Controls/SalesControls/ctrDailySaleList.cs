using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBModule;
using System32;
using ControlLibrary;
using System.Globalization;
using QBSync;

namespace AppControls
{
    public partial class ctrDailySaleList : UserControl
    {
        MainDataSet objDataSet;
        BindingSource ItemBS;
        ControlLibrary.MessageBox xMessageBox = null;
        int ctrMode = 0;
        string SelectSaleDate = "";
        int ReportID;
        DataTable dt = new DataTable();

        public object objBindingSource { get; private set; }

        public ctrDailySaleList()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();
            ItemBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            DGVDailySale.TDataGridView.CellClick += TDataGridView_CellClick;
            DGVDailySale.TDataGridView.MouseDoubleClick += TDataGridView_MouseDoubleClick;
            this.Load += ctrDailySaleList_Load;
            //btnMechanicTracking.Click += btnMechanicTracking_Click;
            btnBrowseInvoices.Click += btnBrowseInvoices_Click;
            btnSelect.Click += btnSelect_Click;
            btnAudit.Click += btnAudit_Click;
            btnCheckAll.Click += btnCheckAll_Click;
            btnUncheckAll.Click += btnUncheckAll_Click;
            btnPost.Click += btnPost_Click;
            btnQBPost.Click += btnQBPost_Click;
            btnQbSettings.Click += btnQbSettings_Click;
            //btnSummaryDetailsrpt.Click += btnSummaryDetailsrpt_Click;

            BindingControls();
        }
        public ctrDailySaleList(int ctrMode)
        {
            InitializeComponent();
            this.ctrMode = ctrMode;
            this.Load += ctrDailySaleList_Load;
        }

        private void btnSummaryDetailsrpt_Click(object sender, EventArgs e)
        {
            if (SelectSaleDate != "")
            {
                StaticInfo.LoadToControl2("Reports.DailyTransactionReportDetails", "Daily Transaction Report", SelectSaleDate, 0);
            }
            else
            {
                xMessageBox.Show("Please select sale for Summary...");
            }
        }
        private void btnQBPost_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            bool PostPermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '019'");
            if (row[0]["CanView"] != DBNull.Value)
                PostPermission = Convert.ToBoolean(row[0]["CanView"]);
            if (PostPermission)
            {
                if (SelectSaleDate != "")
                {
                    if (xMessageBox.Show("Do you want to post selected date....?" + Environment.NewLine + " " + SelectSaleDate + "", "Sale Post..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Boolean Status = dbClass.obj.UpdateWorkOrderDetailsPosted(this.SelectSaleDate);
                        if (Status == true)
                        {
                            xMessageBox.Show("All Transactions posted successfully..");
                            LoadDailyTransactionsList();
                        }
                    }
                }
                else
                {
                    xMessageBox.Show("Please select sale for post...");
                }
            }
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Post.");
            }
        }

        private void btnQbSettings_Click(object sender, EventArgs e)
        {                       
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }


        void TDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectSaleDate != "")
            {
                ViewInvoices.SaleDate = SelectSaleDate;
                StaticInfo.LoadToControl("AppControls.ViewInvoices", "View Invoices", 0);
            }
            else
            {
                xMessageBox.Show("Please select sale for browse invoices...");
            }
        }

        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //ReportID = Convert.ToInt32(DGVDailySale.TDataGridView.Rows[e.RowIndex].Cells[0].Value);
                //string SelectDate = "";
                //SelectSaleDate = DGVDailySale.TDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                //string[] DateList = SelectSaleDate.Split('/');
                //string[] dateyear = DateList[2].ToString().Split(' ');
                //SelectDate = DateList[1] + "/" + DateList[0] + "/" + dateyear[0];

                ////SelectSaleDate = DateTime.Parse(SelectSaleDate, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                ////SelectSaleDate = Convert.ToDateTime(SelectSaleDate, CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                //SelectSaleDate = SelectDate;
                ReportID = Convert.ToInt32(DGVDailySale.TDataGridView.Rows[e.RowIndex].Cells[0].Value);
                string SelectDate = "";
                SelectSaleDate = DGVDailySale.TDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                //string[] DateList = SelectSaleDate.Split('/');
                //SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2].Split(' ')[0];
                SelectSaleDate = Convert.ToDateTime(SelectSaleDate, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");


                // SelectSaleDate = DateList[2].Split(' ')[0] + "-" + DateList[0] + "-" + DateList[1];
                ClaimDate.DateTimePicker1.Value = Convert.ToDateTime(DGVDailySale.TDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                             
            }

            //DataRowView curRow = (DataRowView)((BindingSource)DGVDailySale.TDataGridView.DataSource).Current;
            //ReportID = Convert.ToInt32(curRow[0]);
            //SelectSaleDate = Convert.ToString(curRow[2]);
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            //chkBankSummary.Checked = true;
            //chkItemGroupSubtotals.Checked = true;
            chkItemGroupSummary.Checked = true;
            chkNewCustomers.Checked = true;
            chkPaymentsBills.Checked = true;
            //chkSaleCategories.Checked = true;
            chkSaleTransaction.Checked = true;
            chkSaleRptMech.Checked = true;
        }

        private void btnRefreshItems_Click(object sender, EventArgs e)
        {
            LoadDailyTransactionsList();
        }

        private void ctrDailySaleList_Load(object sender, EventArgs e)
        {
            taRadioButton1.Checked = true;

            LoadDailyTransactionsList();
        }

        void BindingControls()
        {
            //DataRowView curRow = (DataRowView)objBindingSource.Current;
            //curRow["ClaimDate"] = DateTime.Now.Date;
            //this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //DataTable dt = dbClass.obj.GetDailySaleList();
            //ItemBS.DataSource = dt;
        }

        void LoadDailyTransactionsList()
        {
            dt = dbClass.obj.GetDailySaleList();
            dt.Columns.Add(new DataColumn("QB", typeof(bool)));
            dt.Columns.Add(new DataColumn("Er", typeof(bool)));
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Amount = Convert.ToString(dt.Rows[i]["Total Sale"]);
                if (Amount == "") Amount = "0.00";
                dt.Rows[i]["Total Sale"] = StaticInfo.MainCurSign + Amount;

                string CAmount = Convert.ToString(dt.Rows[i]["Cheque Sale"]);
                if (CAmount == "") CAmount = "0.00";
                dt.Rows[i]["Cheque Sale"] = StaticInfo.MainCurSign + CAmount;

                string AAmount = Convert.ToString(dt.Rows[i]["Account Sale"]);
                if (AAmount == "") AAmount = "0.00";
                dt.Rows[i]["Account Sale"] = StaticInfo.MainCurSign + AAmount;
            }
            
            ItemBS.DataSource = dt;

            //DGVItemList.SetSource(ItemBS);
            DGVDailySale.TDataGridView.DataSource = ItemBS;
            DGVDailySale.TDataGridView.AutoGenerateColumns = true;
            DGVDailySale.TDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DGVDailySale.TDataGridView.Columns["Report Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVDailySale.TDataGridView.Columns["From Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVDailySale.TDataGridView.Columns["To Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVDailySale.TDataGridView.Columns["Posted"].Width = 60;
            DGVDailySale.TDataGridView.Columns["QB"].Width = 60;
            DGVDailySale.TDataGridView.Columns["Er"].Width = 60;
            DGVDailySale.TDataGridView.Columns["QB"].Visible = false;
            DGVDailySale.TDataGridView.Columns["Er"].Visible = false;
        }

        private void btnMechanicTracking_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrMechanicTrack", "Mechanic Track", 0);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            //chkBankSummary.Checked = false;
            //chkItemGroupSubtotals.Checked = false;
            chkItemGroupSummary.Checked = false;
            chkNewCustomers.Checked = false;
            chkPaymentsBills.Checked = false;
            //chkSaleCategories.Checked = false;
            chkSaleTransaction.Checked = false;
            chkSaleRptMech.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckAll_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBrowseInvoices_Click(object sender, EventArgs e)
        {
            if (SelectSaleDate != "")
            {
                //StaticInfo.LoadToControl2("AppControls.ctrBrowseInvoice", "Browse Invoice", SelectSaleDate,ReportID, 1);
                ViewInvoices.SaleDate = SelectSaleDate;
                StaticInfo.LoadToControl("AppControls.ViewInvoices","View Invoices",0);
            }
            else
            {
                xMessageBox.Show("Please select sale for browse invoices...");
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
             StaticInfo.LoadToControl("AppControls.ctrGenLedger", "General Ledger", 1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectSaleDate != "")
            {
                //StaticInfo.LoadToControl2("Reports.DailyDepositReport", "Daily Deposit Report", SelectSaleDate, 0);
                //CultureInfo provider = CultureInfo.InvariantCulture;
                //ctrDailySummary.date = DateTime.ParseExact(SelectSaleDate, "M/d/yyyy", provider).ToString();
                SelectSaleDate = ClaimDate.DateTimePicker1.Value.ToString();
                //string[] DateList = SelectSaleDate.Split('/');
                //string SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2].Split(' ')[0];
                ////DateTime date = DateTime.Parse(SelectSaleDate, System.Globalization.CultureInfo.InvariantCulture);
                //SelectSaleDate = DateList[2].Split(' ')[0] + "-" + DateList[1] + "-" + DateList[0];
              
                SelectSaleDate = Convert.ToDateTime(SelectSaleDate, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");

                ctrDailySummary.date = SelectSaleDate;
                DataTable dtM = new DataTable();
                ctrDailySummary.dtm = dbClass.obj.tblMasterRpt(dtM, dtM, ctrDailySummary.GetDailySaleQuery(ctrDailySummary.date));
                if (ctrDailySummary.dtm == null || ctrDailySummary.dtm.Rows.Count == 0)
                {
                    xMessageBox.Show("There are no transactions for today, yet!", "No Transactions Today", ControlLibrary.CCMessageBox.iMessageBoxButtons.OK, ControlLibrary.CCMessageBox.iMessageBoxIcon.Information);
                }
                else
                {
                    StaticInfo.LoadToControl("AppControls.ctrDailySummary", "Daily Analysis", 0);
                }
            }
            else
            {
                xMessageBox.Show("Please Select Sale for Summary...");
            }
        }

        private void DGVDailySale_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVDailySale.TDataGridView.DataSource).Current;
            SelectSaleDate = Convert.ToString(curRow["AddDate"]);
            ReportID = Convert.ToInt32(curRow["Rpt#"]);
        }

        private void cBtnSalesREPSummaryReport_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl2("Reports.SalesREPSummaryDetailedReport", "Sales REP Summary DetailedReport", "" , 0);
        }

        private void btnItemGroupSummaryDetailed_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.ItemGroupSummaryDetailedReport", "Item Group Summary Detailed Report", 0);
        }

        private void DGVDailySale_Load(object sender, EventArgs e)
        {

        }

        private void taCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void taButton1_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            bool PrintPermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '021'");
            if (row[0]["CanView"] != DBNull.Value)
                PrintPermission = Convert.ToBoolean(row[0]["CanView"]);
            if (PrintPermission)
            {
                if (SelectSaleDate != "")
                {
                    if (chkSaleTransaction.Checked)
                    {
                        StaticInfo.LoadToControl2("Reports.DailyTransactionReportDetails", "Daily Transaction Report", SelectSaleDate, 0);
                    }
                    if (chkSaleCategories.Checked)
                    {
                        StaticInfo.LoadToControl2("Reports.SaleCategoriesReport", "Sale Categories Report", SelectSaleDate, 0);
                    }
                    if (chkItemGroupSummary.Checked)
                    {
                        StaticInfo.LoadToControl("Reports.ItemGroupSummaryDetailedReport", "Item Group Summary Detailed Report", 0);
                    }
                    if (chkItemGroupSubtotals.Checked)
                    {

                    }
                    if (chkSaleRptMech.Checked)
                    {
                        StaticInfo.LoadToControl2("Reports.SalesREPSummaryReport", "Sales REP Summary Report", SelectSaleDate, 0);
                    }
                    if (chkPaymentsBills.Checked)
                    {
                        StaticInfo.LoadToControl2("Reports.DailyDepositReport", "Daily Deposit Report", SelectSaleDate, 0);
                    }
                    if (chkNewCustomers.Checked)
                    {
                        StaticInfo.LoadToControl2("Reports.CustomerListReport", "Customers List", SelectSaleDate, 0);
                    }
                    if (chkBankSummary.Checked)
                    {

                    }
                }
                else
                {
                    xMessageBox.Show("Please select sale for Report...");
                }
            }
            else 
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Reports.");
            }
        }
    }
}
