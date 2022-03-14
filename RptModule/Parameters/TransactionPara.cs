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

namespace RptModule.Parameters
{
    public partial class TransactionPara : UserControl
    {
        string rptName;
        public TransactionPara()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public TransactionPara(string rptname)
        {
            InitializeComponent();
            //btnLoadReport.Click += btnLoadReport_Click;
            this.rptName = rptname;
            
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
            this.chkAllCustomer.CheckedChanged += chkAllCustomer_CheckedChanged;
            this.cboCustomer.KeyPress += cboCustomer_KeyPress;
            this.Load += TransactionPara_Load;
        }

        void chkAllCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllCustomer.Checked)
            {
                cboCustomer.Enabled = false;                
            }
            else
            {
                cboCustomer.SelectedIndex = 0;
                cboCustomer.Enabled = true;
            }
        }

       

        void cboCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboCustomer.DroppedDown = false;
        }
        void TransactionPara_Load(object sender, EventArgs e)
        {
            cboCriteria.SelectedIndex = 0;
            switch (this.rptName)
            {

                case "TransactionByDateWithDetailReport":
                    
                    cboCriteria.Visible = true;

                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;

                    lblDateTo.Visible = true;
                    DateTo.Visible = true;

                    
                    chkAllCustomer.Visible = true;
                    chkAllCustomer.Checked = true;
                    lblCustomer.Visible = true;
                    cboCustomer.Visible = true;


                    DataTable dtCustomer = dbClass.obj.getCustomerList();
                    cboCustomer.DisplayMember = "FirstName";
                    cboCustomer.ValueMember = "ID";
                    cboCustomer.DataSource = dtCustomer;

                    break;
                case "InvoiceBillingDetailReport":

                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCustomer.Visible = true;
                    chkAllCustomer.Checked = true;
                    lblCustomer.Visible = true;
                    cboCustomer.Visible = true;
                    break;
            }
        }

        private void cboCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria.SelectedItem == "Today")
                ComboSetting(false, DateTime.Now, DateTime.Now);
            if (cboCriteria.SelectedItem == "Yesterday")
                ComboSetting(false, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
            if (cboCriteria.SelectedItem == "This Week")
            {
                DateTime dtFrom = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                DateTime dtTo = dtFrom.Date.AddDays(+6);
                ComboSetting(false, dtFrom.Date, dtTo.Date);
            }
            if (cboCriteria.SelectedItem == "This Month")
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                ComboSetting(false, startDate.Date, endDate.Date);
            }
            if (cboCriteria.SelectedItem == "This Calender Year")
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);
                ComboSetting(false, startDate, endDate);
            }

            if (cboCriteria.SelectedItem == "This Financial Year")
            {
                Int32 coFinYearStrMonth = StaticInfo.CoFinYearStrMonth;
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;

                if (coFinYearStrMonth > DateTime.Now.Month)
                {
                    startDate = new DateTime(DateTime.Now.Year - 1, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                else
                {
                    startDate = new DateTime(DateTime.Now.Year, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                ComboSetting(false, startDate, endDate);
            }
            if (cboCriteria.SelectedItem == "Last Week")
            {
                DateTime dtFrom = DateTime.Now.AddDays(-7).StartOfWeek(DayOfWeek.Monday);
                DateTime dtTo = dtFrom.Date.AddDays(+6);
                ComboSetting(false, dtFrom.Date, dtTo.Date);
            }
            if (cboCriteria.SelectedItem == "Last Month")
            {
                try
                {
                    var today = DateTime.Today;
                    var month = new DateTime(today.Year, today.Month, 1);
                    var first = month.AddMonths(-1);
                    var last = month.AddDays(-1);
                    ComboSetting(false, first.Date, last.Date);
                }
                catch { }
            }
            if (cboCriteria.SelectedItem == "Last Calender Year")
            {
                int year = Convert.ToInt32(DateTime.Now.Year - 1);
                DateTime startDate = new DateTime(year, 1, 1);
                DateTime endDate = new DateTime(year, 12, 31);
                ComboSetting(false, startDate, endDate);
            }
            if (cboCriteria.SelectedItem == "Last Financial Year")
            {
                Int32 coFinYearStrMonth = StaticInfo.CoFinYearStrMonth;
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;

                if (coFinYearStrMonth > DateTime.Now.Month)
                {
                    startDate = new DateTime(DateTime.Now.Year - 2, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                else
                {
                    startDate = new DateTime(DateTime.Now.Year - 1, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                ComboSetting(false, startDate, endDate);
            }
            //if (cboCriteria.SelectedItem == "Custom")
            //    ComboSetting(true, DateTime.Now, DateTime.Now);

        }
        void ComboSetting(bool enable, DateTime dateFrom, DateTime dateTo)
        {
            //DateFrom.Enabled = enable;
            DateFrom.DateTimePicker1.Value = dateFrom.Date;
            //DateTo.Enabled = enable;
            DateTo.DateTimePicker1.Value = dateTo.Date;
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
