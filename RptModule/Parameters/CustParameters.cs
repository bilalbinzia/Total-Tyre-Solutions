using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;
using DBModule;

namespace RptModule.CustParameters
{
    public partial class CustParameters : UserControl
    {
        string rptName;
        public CustParameters()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public CustParameters(string rptname)
        {
            InitializeComponent();
            btnLoadReport.Click+=btnLoadReport_Click;
            this.rptName = rptname;
            
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);                   
      
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
            DateFrom.DateTimePicker1.Value = dateFrom.Date;            
            DateTo.DateTimePicker1.Value = dateTo.Date;
        }    
        private void ValueParameters_Load(object sender, EventArgs e)
        {
            cboCriteria.SelectedIndex = 0;
            switch (this.rptName)
            {

                case "CustomerTransactionReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCustomer.Visible = true;
                    cboCustomer.Visible = true;
                    cboCustomer.SelectedIndex = -1;

                    DataTable dtCustomer = dbClass.obj.getCustomerList();
                    cboCustomer.DisplayMember = "FirstName";
                    cboCustomer.ValueMember = "ID";
                    cboCustomer.DataSource = dtCustomer; 

                    break;
                case "CustomerTransactionDetailReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCustomer.Visible = true;
                    cboCustomer.Visible = true;
                    cboCustomer.SelectedIndex = -1;

                    DataTable dtCustomer1 = dbClass.obj.getCustomerList();
                    cboCustomer.DisplayMember = "FirstName";
                    cboCustomer.ValueMember = "ID";
                    cboCustomer.DataSource = dtCustomer1; 

                    break;
                case "TransactionSummaryReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCustomer.Visible = true;
                        cboCustomer.Visible = true;
                        cboCustomer.SelectedIndex = -1;

                        DataTable dtCustomer2 = dbClass.obj.getCustomerList();
                        cboCustomer.DisplayMember = "FirstName";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomer2; 
                        break;
                case "CustomerTransactionByDate/VehicleReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCustomer.Visible = true;
                        cboCustomer.Visible = true;
                        cboCustomer.SelectedIndex = -1;

                        DataTable dtCustomer3 = dbClass.obj.getCustomerList();
                        cboCustomer.DisplayMember = "FirstName";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomer3;
                        break;
                case "InvoiceProfitDetailReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCustomer.Visible = true;
                        cboCustomer.Visible = true;
                        cboCustomer.SelectedIndex = -1;

                        DataTable dtCustomer4 = dbClass.obj.getCustomerList();
                        cboCustomer.DisplayMember = "FirstName";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomer4;

                        break;

                case "CustomerListReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "AgingReport":

                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        lblAgingDate.Visible = true;
                        AgingDate.Visible = true;
                        lblCustomer.Visible = true;
                        cboCustomer.Visible = true;

                        AgingDate.DateTimePicker1.Value = DateTime.Now;    
                        DataTable dtCustomerAging = dbClass.obj.getCustomerList();
                        DataRow dr = dtCustomerAging.NewRow();
                        dr["FirstName"] = "All";
                        dr["ID"] = 0;
                        dtCustomerAging.Rows.InsertAt(dr,0);
                        cboCustomer.DisplayMember = "FirstName";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomerAging;
                    break;
                case "VendorAgingReport":

                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        lblAgingDate.Visible = true;
                        AgingDate.Visible = true;
                        break;
                case "CAgingTransactionDetailReport":

                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = false;
                        chkAllCatalog.Checked = false;
                        lblAgingDate.Visible = false;
                        AgingDate.Visible = false;
                        lblCustomer.Visible = false;
                        cboCustomer.Visible = false;
                        cboCustomer.SelectedIndex = -1;

                        DataTable dtCustomer8 = dbClass.obj.getCustomerList();
                        cboCustomer.DisplayMember = "CompanyName";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomer8;

                        break;
                case "VAgingTransactionDetailReport":

                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblAgingDate.Visible = true;
                        AgingDate.Visible = true;
                        lblCustomer.Visible = true;
                        lblCustomer.Text = "Vendor";
                        cboCustomer.Visible = true;
                        cboCustomer.SelectedIndex = -1;

                        DataTable dtCustomer9 = dbClass.obj.getVendorList();
                        cboCustomer.DisplayMember = "Name";
                        cboCustomer.ValueMember = "ID";
                        cboCustomer.DataSource = dtCustomer9;

                        break;
                case "SalesREPSummaryDetailedReport":

                    cboCriteria.Visible = false;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = false;
                    DateTo.Visible = false;
                    chkAllCatalog.Visible = false;
                    chkAllCatalog.Checked = false;
                    lblCustomer.Visible = false;
                    cboCustomer.Visible = false;
                                    
                    //DataTable dtCustomer5 = dbClass.obj.getCustomerList();
                    //cboCustomer.DisplayMember = "FirstName";
                    //cboCustomer.ValueMember = "ID";
                    //cboCustomer.DataSource = dtCustomer5;
                    //cboCustomer.SelectedIndex = 1;

                    break;
            }
        }

        private void cboCatalogFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboCatalogFrom.DroppedDown = false;
        }
        private void cboCatalogTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboCatalogTo.DroppedDown = false;
        }
        private void cboItemType_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboItemType.DroppedDown = false;
        }
        private void cboVendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboVendor.DroppedDown = false;
        }
        private void cboItemGroups_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboItemGroups.DroppedDown = false;
        }

        

        private void chkAllCatalog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllCatalog.Checked)
            {
                cboCustomer.Enabled = false;
                cboCustomer.SelectedIndex = -1;
            }
            else
            {
                cboCustomer.Enabled = true;  
                cboCustomer.SelectedIndex = -1;                 
                             
            }
        }

        private void chkAllSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSize.Checked)
            {
                txtSizeFrom.Enabled = false;
                txtSizeTo.Enabled = false;
                cboItemType.Enabled = false;
                cboVendor.Enabled = false;
                cboItemGroups.Enabled = false;
            }
            else
            {
                cboItemGroups.SelectedIndex = 0;
                cboItemType.SelectedIndex = 0;
                cboVendor.SelectedIndex = 0;                
                txtSizeFrom.Enabled = true;
                txtSizeTo.Enabled = true;
                cboItemType.Enabled = true;
                cboVendor.Enabled = true;
                cboItemGroups.Enabled = true;

            }
        }

        private void cboItemGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblVendor_Click(object sender, EventArgs e)
        {

        }

        private void cboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblItemType_Click(object sender, EventArgs e)
        {

        }

        private void cboItemType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSizeTo_Click(object sender, EventArgs e)
        {

        }

        private void lblSizeFrom_Click(object sender, EventArgs e)
        {

        }

        private void txtSizeTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSizeFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSize_Click(object sender, EventArgs e)
        {

        }

        private void lblCatalogTo_Click(object sender, EventArgs e)
        {

        }

        private void cboCatalogTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCatalogFrom_Click(object sender, EventArgs e)
        {

        }

        private void lblItemGroups_Click(object sender, EventArgs e)
        {

        }

        private void cboCatalogFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCatalog_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {

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
