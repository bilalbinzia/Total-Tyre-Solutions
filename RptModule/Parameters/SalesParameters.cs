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

namespace RptModule.SalesParameters
{
    public partial class SalesParameters : UserControl
    {
        string rptName;
        public SalesParameters()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public SalesParameters(string rptname)
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

                case "InventorySaleReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    cboCatalogFrom.Visible = true;  
                    lblCatalogTo.Visible = true;
                    cboCatalogTo.Visible = true; 
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    cboItemFrom.Visible = true;  
                    lblItemTo.Visible = true;
                    cboItemTo.Visible = true; 
                    
                    DataTable dtcatalog1 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtcatalog1;

                    DataTable Catalog2 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = Catalog2;

                    DataTable ItemF = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = ItemF;
                    
                    DataTable Itemt = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = Itemt;         

                    break;
                case "InventorySaleTransactionReport":
                    
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    cboCatalogFrom.Visible = true;  
                    lblCatalogTo.Visible = true;
                    cboCatalogTo.Visible = true; 
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    cboItemFrom.Visible = true;  
                    lblItemTo.Visible = true;
                    cboItemTo.Visible = true; 
                    
                    DataTable dtcatalog2 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtcatalog2;

                    DataTable Catalog3 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = Catalog3;

                    DataTable ItemF1 = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = ItemF1;
                    
                    DataTable Itemt2 = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = Itemt2;  


                        break;
                case "InventoryMovementReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    cboCatalogFrom.Visible = true;  
                    lblCatalogTo.Visible = true;
                    cboCatalogTo.Visible = true; 
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    cboItemFrom.Visible = true;  
                    lblItemTo.Visible = true;
                    cboItemTo.Visible = true; 
                    
                    DataTable dtcatalog3 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtcatalog3;

                    DataTable Catalog4 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = Catalog4;

                    DataTable ItemF2 = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = ItemF2;
                    
                    DataTable Itemt3 = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = Itemt3;
                        break;
                case "InventoryExcessReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "VehicleListReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "DailyTransactionReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "SaleCategoriesReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "SalesREPSummaryReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "CustomerDailyReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "VendorBillDetailReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "CheckReceiptReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "PaidInsReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "PaidOutsReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "TireSizeReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkTireSize.Visible = true;
                        chkTireSize.Checked = true;
                        lblSizeFrom.Visible = true;
                        cbxTireSize.Visible = true;

                    DataTable dtcatalog4 = dbClass.obj.getTireSizeList();
                    cbxTireSize.DisplayMember = "TSize";
                    cbxTireSize.ValueMember = "ID";
                    cbxTireSize.DataSource = dtcatalog4;
                        break;
                    case "ReOrderReport":
                        btnLoadReport.Visible = false;
                        break;
                    case "TireSizeSaleReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkTireSize.Visible = true;
                        chkTireSize.Checked = true;
                        lblSizeFrom.Visible = true;
                        cbxTireSize.Visible = true;

                    DataTable dtcatalog5 = dbClass.obj.getTireSizeList();
                    cbxTireSize.DisplayMember = "TSize";
                    cbxTireSize.ValueMember = "ID";
                    cbxTireSize.DataSource = dtcatalog5;
                        break;
                    
                    case "ItemGroupSummery":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "VendorDailyReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "PriceLevelSaleReport":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;

                        chkPriceLevel.Visible = true;
                        chkPriceLevel.Checked = true;
                        lblPriceLevel.Visible = true;
                        cbxPriceLevel.Visible = true;

                        DataTable dtcatalog6 = dbClass.obj.getPriceLevelList();
                        cbxPriceLevel.DisplayMember = "Name";
                        cbxPriceLevel.ValueMember = "ID";
                        cbxPriceLevel.DataSource = dtcatalog6;
                        break;
                    case "CustomerLedger":
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;

                        chkPriceLevel.Visible = true;
                        chkPriceLevel.Checked = true;
                        chkPriceLevel.Text = "All Customer";
                        lblPriceLevel.Visible = true;
                        lblPriceLevel.Text = "Customer";
                        cbxPriceLevel.Visible = true;

                        DataTable dtcatalog7 = dbClass.obj.getCustomerList();
                        cbxPriceLevel.DisplayMember = "CompanyName";
                        cbxPriceLevel.ValueMember = "ID";
                        cbxPriceLevel.DataSource = dtcatalog7;
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
            }
            else
            {                                
                cboCatalogFrom.Enabled = true;
                cboCatalogTo.Enabled = true;                
            }
        }

        private void chkAllSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSize.Checked)
            {
                cboItemFrom.Enabled = false;
                cboItemTo.Enabled = false;
            }
            else
            {
                cboItemFrom.Enabled = true;
                cboItemTo.Enabled = true;

            }
        }
       
        private void chkTireSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTireSize.Checked)
            {
                cbxTireSize.Enabled = false;
                txtTireSize.Enabled = false;
            }
            else
            {
                cbxTireSize.Enabled = true;
                txtTireSize.Enabled = true;

            }
        }

        private void chkTireSize_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkTireSize.Checked)
            {
                cbxTireSize.Enabled = false;
                txtTireSize.Enabled = false;
            }
            else
            {
                cbxTireSize.Enabled = true;
                txtTireSize.Enabled = true;
            }
        }

        private void chkPriceLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPriceLevel.Checked)
            {
                cbxPriceLevel.Enabled = false;
                //txtp.Enabled = false;
            }
            else
            {
                cbxPriceLevel.Enabled = true;
                //txtTireSize.Enabled = true;
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
