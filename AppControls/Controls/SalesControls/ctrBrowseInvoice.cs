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
using System32;
using System.Globalization;

namespace AppControls
{
    public partial class ctrBrowseInvoice : UserControl
    {
        private string SaleDate;
        MainDataSet objDataSet;
        BindingSource ItemBS;
        ControlLibrary.MessageBox xMessageBox = null;
        string SelectSaleDate = "";
        int ReportID;
        public object objBindingSource { get; private set; }

        public ctrBrowseInvoice()
        {
            InitializeComponent();
            ItemBS = new BindingSource();
            btnDetails.Click += btnDetails_Click;
            //BindingControls();
        }
        public ctrBrowseInvoice(string SaleDate, int id)
        {
            InitializeComponent();
            InitializeComponent1();
            this.SaleDate = SaleDate;
            lblSaleID.Text = id.ToString();
        }
        void InitializeComponent1()
        {
            btnDetails.Click += btnDetails_Click;
            DGVSaleList.CellClick += TDataGridView_CellClick;
            DGVSaleList.MouseDoubleClick += TDataGridView_MouseDoubleClick;
            btnPreview.Click += TSMItem2_Click;
            //DateTime oDate = DateTime.ParseExact(SaleDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);
            this.Load += ctrBrowseInvoice_Load;
        }

        protected void TSMItem2_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionSummaryReport", "Customer Transaction Summary Reports", 0);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (ReportID != 0)
            {
                StaticInfo.LoadToControl2("AppControls.ctrInvoiceDetails", "Invoice Details", SaleDate, ReportID, 1);
            }
            else
            {
                //xMessageBox.Show("Please select Invoice for details... ");
            }
        }

        private void TDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ReportID != 0)
            {
                StaticInfo.LoadToControl2("AppControls.ctrInvoiceDetails", "Invoice Details", SaleDate, ReportID, 1);
            }
            else
            {
                xMessageBox.Show("Please select Invoice for details... ");
            }
        }

        private void ctrBrowseInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.SaleDate != null)
                {
                    //---fill item History------------------
                    //BindingSource ItemBS = new BindingSource();
                    //DataTable dt = dbClass.obj.GetDailyInvoicesListbyDate(SaleDate);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    string Margin = "";
                    //    Margin = Convert.ToString(dt.Rows[i]["Margin"]);
                    //    string[] DateList = Margin.Split('.');
                    //    dt.Rows[i]["Margin"] = DateList[0].ToString()+"%";

                    //    string Profit = "";
                    //    Profit = Convert.ToString(dt.Rows[i]["Profit"]);
                    //    dt.Rows[i]["Profit"] = "$"+Profit.ToString();

                    //    string Amount = "";
                    //    Amount = Convert.ToString(dt.Rows[i]["TotalAmount"]);
                    //    dt.Rows[i]["TotalAmount"] = "$" + Amount.ToString();
                    //}
                    ////ItemBS.DataSource = dt;
                    //DGVSaleList.BackgroundColor = StaticInfo.ctrBackColor;

                    //DGVSaleList.DataSource = dt;
                    //DGVSaleList.AutoGenerateColumns = true;
                    //DGVSaleList.AllowUserToAddRows = false;
                    //DGVSaleList.Columns["Rep"].Width = 50;
                    //DGVSaleList.Columns["Profit"].Width = 50;
                    //DGVSaleList.Columns["Margin"].Width = 50;

                    //DGVSaleList.Columns["Cost"].Visible = false;
                    //DGVSaleList.Columns["Price"].Visible = false;
                    
                    //DGVSaleList.Columns["Trans#"].Width = 50;
                    //DGVSaleList.Columns["WO#"].Width = 50;
                    //DGVSaleList.Columns["PaidBy"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
        void BindingControls()
        {
            DataTable dt = dbClass.obj.GetDailyInvoicesListbyDate(SaleDate);
            ItemBS.DataSource = dt;
            //DGVSaleList.DataSource = ItemBS;
        }

        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVSaleList.DataSource).Current;
            ReportID = Convert.ToInt32(curRow[2]);
            //SelectSaleDate = Convert.ToString(curRow[2]);
            //string[] DateList = SelectSaleDate.Split('/');

            //SelectDate = DateList[1] + "/" + DateList[0] + "/" + DateList[2];
            //SelectSaleDate = SelectDate;
        }

        private void DGVSaleList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                DGVSaleList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
            }
            else
            {
                DGVSaleList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }
        }
    }
}
