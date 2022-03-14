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

namespace RptModule.ValueParameters
{
    public partial class ValueParameters : UserControl
    {
        string rptName;
        public ValueParameters()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public ValueParameters(string rptname)
        {
            InitializeComponent();
            //btnLoadReport.Click += btnLoadReport_Click;
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
                case "InventoryStockReport":
                    
                    cboCriteria.Visible = false;
                    lblDateFrom.Visible = false;
                    DateFrom.Visible = false;
                    lblDateTo.Visible = false;
                    DateTo.Visible = false;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    lblCatalogTo.Visible = true;
                    cboCatalogFrom.Visible = true;
                    cboCatalogFrom.SelectedIndex = -1;
                    cboCatalogTo.Visible = true;
                    cboCatalogTo.SelectedIndex = -1;
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    lblItemTo.Visible = true;
                    cboItemFrom.Visible = true;
                    cboItemFrom.SelectedIndex = -1;
                    cboItemTo.Visible = true;
                    cboItemTo.SelectedIndex = -1;

                    DataTable dtCatalogF = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtCatalogF; 

                    DataTable dtCatalogT = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = dtCatalogT; 

                    DataTable dtItemF = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = dtItemF; 

                    DataTable dtItemT = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = dtItemT; 

                    break;

                case "InventoryValueReport":
                    
                    cboCriteria.Visible = false;
                    lblDateFrom.Visible = false;
                    DateFrom.Visible = false;
                    lblDateTo.Visible = false;
                    DateTo.Visible = false;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    lblCatalogTo.Visible = true;
                    cboCatalogFrom.Visible = true;
                    cboCatalogFrom.SelectedIndex = -1;
                    cboCatalogTo.Visible = true;
                    cboCatalogTo.SelectedIndex = -1;
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    lblItemTo.Visible = true;
                    cboItemFrom.Visible = true;
                    cboItemFrom.SelectedIndex = -1;
                    cboItemTo.Visible = true;
                    cboItemTo.SelectedIndex = -1;

                    DataTable dtCatalogF1 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtCatalogF1; 

                    DataTable dtCatalogT1 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = dtCatalogT1; 

                    DataTable dtItemF1 = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = dtItemF1; 

                    DataTable dtItemT1 = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = dtItemT1; 

                    break;
                    case "InventoryPhysicalReport":
                    
                    cboCriteria.Visible = false;
                    lblDateFrom.Visible = false;
                    DateFrom.Visible = false;
                    lblDateTo.Visible = false;
                    DateTo.Visible = false;
                    chkAllCatalog.Visible = true;
                    chkAllCatalog.Checked = true;
                    lblCatalogFrom.Visible = true;
                    lblCatalogTo.Visible = true;
                    cboCatalogFrom.Visible = true;
                    cboCatalogFrom.SelectedIndex = -1;
                    cboCatalogTo.Visible = true;
                    cboCatalogTo.SelectedIndex = -1;
                    chkAllSize.Visible = true;
                    chkAllSize.Checked = true;
                    lblItemFrom.Visible = true;
                    lblItemTo.Visible = true;
                    cboItemFrom.Visible = true;
                    cboItemFrom.SelectedIndex = -1;
                    cboItemTo.Visible = true;
                    cboItemTo.SelectedIndex = -1;

                    DataTable dtCatalogF2 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtCatalogF2; 

                    DataTable dtCatalogT2 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = dtCatalogT2; 

                    DataTable dtItemF2 = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = dtItemF2; 

                    DataTable dtItemT2 = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = dtItemT2; 

                        break;
                    case "InventoryVarianceReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                    cboItemFrom.Visible = true;
                    cboItemFrom.SelectedIndex = -1;
                    cboItemTo.Visible = true;
                    cboItemTo.SelectedIndex = -1;

                    DataTable dtCatalogF3 = dbClass.obj.getItemList();
                    cboCatalogFrom.DisplayMember = "Catalog";
                    cboCatalogFrom.ValueMember = "ID";
                    cboCatalogFrom.DataSource = dtCatalogF3; 

                    DataTable dtCatalogT3 = dbClass.obj.getItemList();
                    cboCatalogTo.DisplayMember = "Catalog";
                    cboCatalogTo.ValueMember = "ID";
                    cboCatalogTo.DataSource = dtCatalogT3;

                    DataTable dtItemF3 = dbClass.obj.getItemList();
                    cboItemFrom.DisplayMember = "Name";
                    cboItemFrom.ValueMember = "ID";
                    cboItemFrom.DataSource = dtItemF3;

                    DataTable dtItemT3 = dbClass.obj.getItemList();
                    cboItemTo.DisplayMember = "Name";
                    cboItemTo.ValueMember = "ID";
                    cboItemTo.DataSource = dtItemT3;

                        break;
                    case "InventoryExcessReport":
                        
                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF4 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF4; 

                        DataTable dtCatalogT4 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT4;

                        DataTable dtItemF4 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF4;

                        DataTable dtItemT4 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT4;

                        break;
                    case "InventoryModelValueReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                    chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF5 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF5; 

                        DataTable dtCatalogT5 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT5;

                        DataTable dtItemF5 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF5;

                        DataTable dtItemT5 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT5;

                        break;
                    case "PriceListReport":
                        
                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF6 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF6;

                        DataTable dtCatalogT6 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT6;

                        DataTable dtItemF6 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF6;

                        DataTable dtItemT6 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT6;

                        break;
                    case "SpecialPriceListReport":
                        
                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF7 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF7;

                        DataTable dtCatalogT7 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT7;

                        DataTable dtItemF7 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF7;

                        DataTable dtItemT7 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT7;

                        break;
                    case "InventoryReorderReport":
                        
                        cboCriteria.Visible = false;
                        lblDateFrom.Visible = false;
                        DateFrom.Visible = false;
                        lblDateTo.Visible = false;
                        DateTo.Visible = false;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF8 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF8;

                        DataTable dtCatalogT8 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT8;

                        DataTable dtItemF8 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF8;

                        DataTable dtItemT8 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT8;

                        break;
                    case "InventoryBinReport":
                        
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        chkAllCatalog.Visible = true;
                        chkAllCatalog.Checked = true;
                        lblCatalogFrom.Visible = true;
                        lblCatalogTo.Visible = true;
                        cboCatalogFrom.Visible = true;
                        cboCatalogFrom.SelectedIndex = -1;
                        cboCatalogTo.Visible = true;
                        cboCatalogTo.SelectedIndex = -1;
                        chkAllSize.Visible = true;
                        chkAllSize.Checked = true;
                        lblItemFrom.Visible = true;
                        lblItemTo.Visible = true;
                        cboItemFrom.Visible = true;
                        cboItemFrom.SelectedIndex = -1;
                        cboItemTo.Visible = true;
                        cboItemTo.SelectedIndex = -1;

                        DataTable dtCatalogF9 = dbClass.obj.getItemList();
                        cboCatalogFrom.DisplayMember = "Catalog";
                        cboCatalogFrom.ValueMember = "ID";
                        cboCatalogFrom.DataSource = dtCatalogF9;

                        DataTable dtCatalogT9 = dbClass.obj.getItemList();
                        cboCatalogTo.DisplayMember = "Catalog";
                        cboCatalogTo.ValueMember = "ID";
                        cboCatalogTo.DataSource = dtCatalogT9;

                        DataTable dtItemF9 = dbClass.obj.getItemList();
                        cboItemFrom.DisplayMember = "Name";
                        cboItemFrom.ValueMember = "ID";
                        cboItemFrom.DataSource = dtItemF9;

                        DataTable dtItemT9 = dbClass.obj.getItemList();
                        cboItemTo.DisplayMember = "Name";
                        cboItemTo.ValueMember = "ID";
                        cboItemTo.DataSource = dtItemT9;

                        break;
                    case "ItemListReport":
                        
                        cboCriteria.Visible = false;
                        //lblDateFrom.Visible = true;
                        //DateFrom.Visible = true;
                        //lblDateTo.Visible = true;
                        //DateTo.Visible = true;                        

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
                cboCatalogFrom.SelectedIndex = -1;
                cboCatalogTo.Enabled = false;
                cboCatalogTo.SelectedIndex = -1;
            }
            else
            {
                cboCatalogFrom.Enabled = true;
                cboCatalogFrom.SelectedIndex = -1;
                cboCatalogTo.Enabled = true;
                cboCatalogTo.SelectedIndex = -1;

            }
        }

        private void chkAllSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSize.Checked)
            {
                cboItemFrom.Enabled = false;
                cboItemFrom.SelectedIndex = -1;
                cboItemTo.Enabled = false;
                cboItemTo.SelectedIndex = -1;
            }
            else
            {
                cboItemFrom.Enabled = true;
                cboItemFrom.SelectedIndex = -1;
                cboItemTo.Enabled = true;
                cboItemTo.SelectedIndex = -1;

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
