using DBModule;
using RptModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AppControls
{
    public partial class ctrDailySummary : UserControl
    {
        public static string date = "";
        public static DataTable dtm = new DataTable();
        RptClass rptClass = new RptClass();
        DataTable dtM = new DataTable();
        ControlLibrary.MessageBox xMessageBox = null;
        public ctrDailySummary()
        {
            InitializeComponent();
            xMessageBox = new ControlLibrary.MessageBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void DailySummary_Load(object sender, EventArgs e)
        {
            dtM = ctrDailySummary.dtm;
            string GetDate = Convert.ToDateTime(date).ToShortDateString().ToString();
            DateTime dateTime11 = Convert.ToDateTime(date);  //DateTime.ParseExact(GetDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            label124.Text = dateTime11.ToShortDateString();
            label7.Text = (dtM.Rows[0].Field<decimal>("S11") == 0) ? "N/A" : dtM.Rows[0].Field<decimal>("S11").ToString();
            label8.Text = (dtM.Rows[0].Field<decimal>("S12") == 0) ? "N/A" : dtM.Rows[0].Field<decimal>("S12").ToString();
            label9.Text = (dtM.Rows[0].Field<decimal>("S13") == 0) ? "N/A" : dtM.Rows[0].Field<decimal>("S13").ToString();
            label10.Text = dtM.Rows[0].Field<decimal>("S2").ToString();

            //=====================================================Sales===============================
            label53.Text = dtM.Rows[0].Field<decimal>("S5").ToString();
            label54.Text = dtM.Rows[0].Field<decimal>("S6").ToString();
            label55.Text = dtM.Rows[0].Field<decimal>("S7").ToString();
            label56.Text = dtM.Rows[0].Field<decimal>("S8").ToString();
            label57.Text = dtM.Rows[0].Field<decimal>("S9").ToString();
            label58.Text = dtM.Rows[0].Field<decimal>("S10").ToString();
            label59.Text = dtM.Rows[0].Field<decimal>("S16").ToString();
            label60.Text = dtM.Rows[0].Field<decimal>("S17").ToString();
            label63.Text = dtM.Rows[0].Field<decimal>("S14").ToString();
            //====================================================Payment on Acct=======================
            //dtM.Clear();
            //dtM = dbClass.obj.tblMasterRpt(dtM, dtM, "select row_number() over(order by CAST(cr.TrnsDate AS DATE))AS ID, CAST(cr.TrnsDate AS DATE) as [S1] ,SUM(wo.TotalProfit) as [S2],CONVERT(varchar, sum(Total)-SUM(cr.ChgOnAccount)) as [S3],SUM(CR.PayByCash)AS[S5],SUM(CR.ChgOnAccount)AS[S14],SUM(CR.PaybyCheck)AS[S6],SUM(CR.PayByVisa)AS[S7],SUM(CR.PayByMC)AS[S8],SUM(CR.PayByAMEX)AS[S9],SUM(CR.PayByATM)AS[S10],SUM(CR.PayByGY)AS[S16],SUM(CR.PayByDSCVR)AS[S17],sum(Total)as S15,(SELECT SUM(Price * Qty) as Totalinventory FROM[dbo].[WorkOrderDetail] WOD right Join[dbo].[Item] itm on WOD.[ItemID] = itm.ID where WOD.ItemID is not null and Ctype != 'L'and Ctype!= 'F')as S11,(Select Sum(TotalReceivedAmount) from CustomerPayment)as S12,(Select Sum(PaidAmount) from VendorPayment)as S13 from [WorkOrder] wo Inner join CustomerReceipt cr on wo.ID = cr.WOID WHERE CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID=" + StaticInfo.CompanyID + " group by CAST(cr.TrnsDate AS DATE),wo.IsLocked order by row_number()over(order by CAST(cr.TrnsDate AS DATE)) Desc");
            label65.Text = dtM.Rows[0].Field<decimal>("S20").ToString();
            label66.Text = dtM.Rows[0].Field<decimal>("S21").ToString();
            label67.Text = dtM.Rows[0].Field<decimal>("S22").ToString();
            label68.Text = dtM.Rows[0].Field<decimal>("S23").ToString();
            label69.Text = dtM.Rows[0].Field<decimal>("S24").ToString();
            label70.Text = dtM.Rows[0].Field<decimal>("S25").ToString();
            label71.Text = dtM.Rows[0].Field<decimal>("S26").ToString();
            label72.Text = dtM.Rows[0].Field<decimal>("S27").ToString();
            //====================================================deposits===================================
            decimal CashTotalDeposit = Convert.ToDecimal(label53.Text) + Convert.ToDecimal(label65.Text);
            decimal CheckTotalDeposit = Convert.ToDecimal(label54.Text) + Convert.ToDecimal(label66.Text);
            decimal VisaTotalDeposit = Convert.ToDecimal(label55.Text) + Convert.ToDecimal(label67.Text);
            decimal MCTotalDeposit = Convert.ToDecimal(label56.Text) + Convert.ToDecimal(label68.Text);
            decimal AMEXTotalDeposit = Convert.ToDecimal(label57.Text) + Convert.ToDecimal(label69.Text);
            decimal ATMTotalDeposit = Convert.ToDecimal(label58.Text) + Convert.ToDecimal(label70.Text);
            decimal GYTotalDeposit = Convert.ToDecimal(label59.Text) + Convert.ToDecimal(label71.Text);
            decimal DSCVRTotalDeposit = Convert.ToDecimal(label60.Text) + Convert.ToDecimal(label72.Text);
            label100.Text = CashTotalDeposit.ToString();
            label101.Text = CheckTotalDeposit.ToString();
            label102.Text = VisaTotalDeposit.ToString();
            label103.Text = MCTotalDeposit.ToString();
            label104.Text = AMEXTotalDeposit.ToString();
            label105.Text = ATMTotalDeposit.ToString();
            label106.Text = GYTotalDeposit.ToString();
            label107.Text = DSCVRTotalDeposit.ToString();
            //=================================================Totals=========================================
            decimal SalesTotal = Convert.ToDecimal(label53.Text) + Convert.ToDecimal(label54.Text) + Convert.ToDecimal(label55.Text) + Convert.ToDecimal(label56.Text) + Convert.ToDecimal(label57.Text) + Convert.ToDecimal(label58.Text) + Convert.ToDecimal(label59.Text) + Convert.ToDecimal(label60.Text) + Convert.ToDecimal(label63.Text);
            decimal POATotal = Convert.ToDecimal(label65.Text) + Convert.ToDecimal(label66.Text) + Convert.ToDecimal(label67.Text) + Convert.ToDecimal(label68.Text) + Convert.ToDecimal(label69.Text) + Convert.ToDecimal(label70.Text) + Convert.ToDecimal(label71.Text) + Convert.ToDecimal(label72.Text);
            decimal DepositTotal = Convert.ToDecimal(label100.Text) + Convert.ToDecimal(label101.Text) + Convert.ToDecimal(label102.Text) + Convert.ToDecimal(label103.Text) + Convert.ToDecimal(label104.Text) + Convert.ToDecimal(label105.Text) + Convert.ToDecimal(label106.Text) + Convert.ToDecimal(label107.Text);
            label27.Text = SalesTotal.ToString();
            label28.Text = POATotal.ToString();
            label29.Text = (Convert.ToDecimal(label77.Text) + Convert.ToDecimal(label78.Text) + Convert.ToDecimal(label79.Text) + Convert.ToDecimal(label80.Text) + Convert.ToDecimal(label81.Text) + Convert.ToDecimal(label82.Text) + Convert.ToDecimal(label83.Text) + Convert.ToDecimal(label84.Text)).ToString();
            label30.Text = (Convert.ToDecimal(label77.Text) + Convert.ToDecimal(label78.Text)).ToString();
            label31.Text = Convert.ToDecimal(label75.Text).ToString();
            label32.Text = DepositTotal.ToString();
            label33.Text = (Convert.ToDecimal(label112.Text) + Convert.ToDecimal(label113.Text) + Convert.ToDecimal(label114.Text) + Convert.ToDecimal(label115.Text) + Convert.ToDecimal(label116.Text) + Convert.ToDecimal(label117.Text) + Convert.ToDecimal(label118.Text) + Convert.ToDecimal(label119.Text)).ToString();
            label121.Text = SalesTotal.ToString();
            decimal perc = Convert.ToDecimal(label10.Text) / SalesTotal * 100;
            label6.Text = "Profit Total:" + " " + (Math.Round(perc, 0)).ToString() + "%";
        }

        private void label115_Click(object sender, EventArgs e)
        {

        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl2("Reports.DailyDepositReport", "Daily Deposit Report", ctrDailySummary.date, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        public static string GetDailySaleQuery(string date)
        {
            string qry = "select row_number() over(order by CAST(cr.TrnsDate AS DATE))AS ID," +
                        "CAST(cr.TrnsDate AS DATE) as [S1] ," +
                        "(SUM(wo.TotalProfit)-(select ISNULL(SUM(WorkOrderNegate.TotalProfit),0) from WorkOrderNegate inner join CustomerPayment on WorkOrderNegate.ID=CustomerPayment.WONID where CAST(TrnsDate AS DATE) = '2021-02-01' and CustomerPayment.CompanyID = 65)) as [S2]," +
                        "CONVERT(varchar, sum(Total) - SUM(cr.ChgOnAccount)) as [S3]," +
                        "SUM(CR.PayByCash) - (select ISNULL(Sum(PayByCash),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "' and CompanyID = " + StaticInfo.CompanyID + ")AS[S5]," +
                        "SUM(CR.ChgOnAccount) - (select ISNULL(Sum(ChgOnAccount),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S14]," +
                        "SUM(CR.PaybyCheck) - (select ISNULL(Sum(PaybyCheck),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S6]," +
                        "SUM(CR.PayByVisa) - (select ISNULL(Sum(PayByVisa),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S7]," +
                        "SUM(CR.PayByMC) - (select ISNULL(Sum(PayByMC),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S8]," +
                        "SUM(CR.PayByAMEX) - (select ISNULL(Sum(PayByAMEX),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S9]," +
                        "SUM(CR.PayByATM) - (select ISNULL(Sum(PayByGY),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S10]," +
                        "SUM(CR.PayByGY) - (select ISNULL(Sum(PayByCash),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S16]," +
                        "SUM(CR.PayByDSCVR) - (select ISNULL(Sum(PayByDSCVR),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "')AS[S17]," +
                        "(select ISNULL(SUM(CR.PayByCash),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S20]," +
                        "(select ISNULL(SUM(CR.PaybyCheck),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S21]," +
                        "(select ISNULL(SUM(CR.PayByVisa) ,0)from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S22]," +
                        "(select ISNULL(SUM(CR.PayByMC),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S23]," +
                        "(select ISNULL(SUM(CR.PayByAMEX),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S24]," +
                        "(select ISNULL(SUM(CR.PayByATM),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S25]," +
                        "(select ISNULL(SUM(CR.PayByGY),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S26]," +
                        "(select ISNULL(SUM(CR.PayByDSCVR),0) from CustomerReceipt cr where cr.WOID IS NULL and CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + ")AS[S27]," +
                        "sum(Total) - (select ISNULL(Sum(TotalReceivedAmount),0) from CustomerPayment where CAST(TrnsDate AS DATE) = '" + date + "') as S15," +
                        "ISNULL((select Top(1) Itemcontrol from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0) as S11," +
                        "ISNULL((select Top(1) CustomerControl from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0)as S12," +
                        "ISNULL((select Top(1) VendorControl from eod inner join CustomerReceipt on eod.ID=CustomerReceipt.EodID where CAST(CustomerReceipt.TrnsDate AS DATE)= '" + date + "' and CustomerReceipt.CompanyID = " + StaticInfo.CompanyID + "),0)as S13" +
                        " from[WorkOrder] wo Inner join CustomerReceipt cr on wo.ID = cr.WOID" +
                        " WHERE CAST(cr.TrnsDate AS DATE)= '" + date + "' and cr.CompanyID = " + StaticInfo.CompanyID + "" +
                        " group by CAST(cr.TrnsDate AS DATE)," +
                        "wo.IsLocked order by row_number()over(order by CAST(cr.TrnsDate AS DATE)) Desc";
            return qry;
        }

        private void Print_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            bool PrintPermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '021'");
            if (row[0]["CanView"] != DBNull.Value)
                PrintPermission = Convert.ToBoolean(row[0]["CanView"]);
            if (PrintPermission)
            {
                StaticInfo.LoadToControl("Reports.ItemGroupSummaryDetailedReport", "Item Group Summary Detailed Report", 0);
            StaticInfo.LoadToControl2("Reports.DailyTransactionReportDetails", "Daily Transaction Report", date, 0);
            StaticInfo.LoadToControl2("Reports.DailyDepositReport", "Daily Deposit Report", ctrDailySummary.date, 0);
            //StaticInfo.LoadToControl2("Reports.SaleCategoriesReport", "Sale Categories Report", date, 0);
            }
            else
                xMessageBox.Show("Sorry! You don't have Permissions on Reports.");
        }

        private void Cancel_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void Cancel_ClickButtonArea_1(object Sender, MouseEventArgs e)
        {
            this.ParentForm.Close();

        }
    }
}
