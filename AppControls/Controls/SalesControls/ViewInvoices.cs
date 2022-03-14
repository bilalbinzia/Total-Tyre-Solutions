using ControlLibrary;
using DBModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AppControls
{
    public partial class ViewInvoices : UserControl
    {
        public static string SaleDate;
        ControlLibrary.MessageBox xMessageBox = new ControlLibrary.MessageBox();
        int ReportID;
        public ViewInvoices()
        {
            InitializeComponent();
        }

        private void ViewInvoices_Load(object sender, EventArgs e)
        {
            try
            {
                if (SaleDate != null)
                {
                    //---fill item History------------------
                    BindingSource ItemBS = new BindingSource();
                    DataTable dt = dbClass.obj.GetDailyInvoicesListbyDate(SaleDate);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string Margin = "";
                        //Margin = Convert.ToString(dt.Rows[i]["Amount"]);
                        //string[] DateList = Margin.Split('.');
                        //dt.Rows[i]["Amount"] = DateList[0].ToString() + "%";

                        string Amount = "";
                        Amount = Convert.ToString(dt.Rows[i]["Amount"]);
                        dt.Rows[i]["Amount"] = "$" + Amount.ToString();

                        string Profit = "";
                        Profit = Convert.ToString(dt.Rows[i]["Profit"]);
                        dt.Rows[i]["Profit"] = "$" + Profit.ToString();

                        string ToatlAmount = "";
                        ToatlAmount = Convert.ToString(dt.Rows[i]["TotalAmount"]);
                        dt.Rows[i]["TotalAmount"] = "$" + ToatlAmount.ToString();
                    }
                    //ItemBS.DataSource = dt;
                    dataGridView1.BackgroundColor = StaticInfo.ctrBackColor;
                    dataGridView1.DataSource = dt;
                    //DGVSaleList.AutoGenerateColumns = true;
                    //DGVSaleList.AllowUserToAddRows = false;
                    //DGVSaleList.Columns["Rep"].Width = 50;
                    //DGVSaleList.Columns["Profit"].Width = 50;
                    //DGVSaleList.Columns["Margin"].Width = 50;

                    //DGVSaleList.Columns["Cost"].Visible = false;
                    //DGVSaleList.Columns["Price"].Visible = false;

                    //DGVSaleList.Columns["Trans#"].Width = 50;
                    dataGridView1.Columns["WO#"].Visible = false;
                    dataGridView1.Columns["PaidBy"].Width = 200;
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }

        private void btnPreview_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            StaticInfo.LoadToControl("Reports.TransactionSummaryReport", "Customer Transaction Summary Reports", 0);
        }

        private void btnDetails_ClickButtonArea(object Sender, MouseEventArgs e)
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ReportID != 0)
            {
                StaticInfo.LoadToControl2("AppControls.ctrInvoiceDetails", "Invoice Details", SaleDate, ReportID, 1);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select Invoice for details... ");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[e.RowIndex];

                ReportID = Convert.ToInt32(row.Cells[2].Value == DBNull.Value ? 0 : row.Cells[2].Value);
            }
            //DataRowView curRow = (DataRowView)((BindingSource)dataGridView1.DataSource).Current;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }
}
