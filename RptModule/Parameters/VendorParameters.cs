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

namespace RptModule.VendorParameters
{
    public partial class VendorParameters : UserControl
    {
        string rptName;
        public VendorParameters()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public VendorParameters(string rptname)
        {
            InitializeComponent();
            
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

                case "VendorAgingTransactionReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked= true;
                    cboVendor.Visible = true;
                    lblVendor.Visible = true;

                    DataTable dtVendor = dbClass.obj.getVendorList();
                    cboVendor.DisplayMember = "Name";
                    cboVendor.ValueMember = "ID";
                    cboVendor.DataSource = dtVendor; 
                    break;
                case "VendorCheckPreparationReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked= true;
                    cboVendor.Visible = true;
                    lblVendor.Visible = true;

                    DataTable dtVendor2 = dbClass.obj.getVendorList();
                    cboVendor.DisplayMember = "Name";
                    cboVendor.ValueMember = "ID";
                    cboVendor.DataSource = dtVendor2;
                    cboVendor.SelectedIndex =0;
                        break;
                case "WorkOrderOutSidepartByDate":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "PurchaseOrderBillWiseReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;                        
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        txtSizeFrom.Visible = true;
                        txtSizeFrom.Enabled = false;
                        txtSizeTo.Visible = true;
                        txtSizeTo.Enabled = false;
                        lblSizeFrom.Visible = true;
                        lblSizeTo.Visible = true;
                        break;
                case "PurchaseOrderVendorWiseReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        cboVendor.Visible = true;
                        lblVendor.Visible = true;

                      DataTable dtVendor1 = dbClass.obj.getVendorList();
                    cboVendor.DisplayMember = "Name";
                    cboVendor.ValueMember = "ID";
                    cboVendor.DataSource = dtVendor1;

                        break;
                case "PurchaseOrderItemWiseReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemTo.Visible = true;

                      DataTable dtItemF = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = dtItemF;

                      DataTable dtItemT = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = dtItemT;
                        break;
                case "PurchaseOrderHistoryReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "VendorPaidOutReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        cboVendor.Visible = true;
                        lblVendor.Visible = true;

                        DataTable dtVendor3 = dbClass.obj.getVendorList();
                        cboVendor.DisplayMember = "Name";
                        cboVendor.ValueMember = "ID";
                        cboVendor.DataSource = dtVendor3;
                        break;
                case "VendorSummeryReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        cboVendor.Visible = true;
                        lblVendor.Visible = true;

                        DataTable dtVendor4 = dbClass.obj.getVendorList();
                        cboVendor.DisplayMember = "Name";
                        cboVendor.ValueMember = "ID";
                        cboVendor.DataSource = dtVendor4;
                        break;
                case "VendorTransectionReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked= true;
                        cboVendor.Visible = true;
                        lblVendor.Visible = true;

                        DataTable dtVendor5 = dbClass.obj.getVendorList();
                        cboVendor.DisplayMember = "Name";
                        cboVendor.ValueMember = "ID";
                        cboVendor.DataSource = dtVendor5;
                        break;
                case "PackingListForClaimReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "VendorListReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
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
                cboCatalogFrom.Enabled = false;
                cboCatalogTo.Enabled = false;
                cboVendor.Enabled = false;
                cboItemFrom.Enabled = false;
                cboItemTo.Enabled = false;
                txtSizeFrom.Enabled = false;
                txtSizeTo.Enabled = false; 
            }
            else
            {                          
                cboCatalogFrom.Enabled = true;
                cboCatalogTo.Enabled = true;                
                cboVendor.Enabled = true;
                cboItemFrom.Enabled = true;
                cboItemTo.Enabled = true;
                txtSizeFrom.Enabled = true;
                txtSizeTo.Enabled = true; 
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
