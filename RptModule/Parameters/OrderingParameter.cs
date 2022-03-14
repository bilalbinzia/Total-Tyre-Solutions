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

namespace RptModule.OrderingParameter
{
    public partial class OrderingParameter : UserControl
    {
        string rptName;
        public OrderingParameter()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
        }
        public OrderingParameter(string rptname)
        {
            InitializeComponent();
            
            this.rptName = rptname;
            this.chkAllCriteria.CheckedChanged += chkAllCriteria_CheckedChanged;
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);                   
      
        }        

        void chkAllCriteria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllCriteria.Checked)
            {
                cboCriteria.Enabled = false;
                DateFrom.Enabled = false;
                DateTo.Enabled = false; 
            }
            else
            {
                cboCriteria.SelectedIndex = 0;
                cboCriteria.Enabled = true;
                DateFrom.Enabled = true;
                DateTo.Enabled = true;
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
            DateFrom.DateTimePicker1.Value = dateFrom.Date;            
            DateTo.DateTimePicker1.Value = dateTo.Date;
        }    
        private void ValueParameters_Load(object sender, EventArgs e)
        {
            cboCriteria.SelectedIndex = 0;
            switch (this.rptName)
            {

                case "InventoryReorderReport":
                    chkAllCriteria.Visible = true;
                    chkAllCriteria.Checked = true;
                    lblCriteria.Visible = true;
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;


                    //chkAllCatalog.Visible = true;
                    //chkAllCatalog.Checked = true;
                    //lblCatalog.Visible = true;

                    //lblCatalogFrom.Visible = true;
                    //lblCatalogTo.Visible = true;
                    //cboCatalogFrom.Visible = true;
                    //cboCatalogTo.Visible = true;                    
                     
                    //chkAllSize.Visible = true;
                    //chkAllSize.Checked = true;
                    //lblSize.Visible = true;
                    //lblSizeFrom.Visible = true;
                    //lblSizeTo.Visible = true;
                    //txtSizeFrom.Visible = true;
                    //txtSizeTo.Visible = true;
                    //lblItemType.Visible = true;
                    //cboItemType.Visible = true;
                    //lblVendor.Visible = true;
                    //cboVendor.Visible = true;
                    //lblItemGroups.Visible = true;
                    //cboItemGroups.Visible = true;
                    
                    
                    
                    //DataTable dtItemTypes = dbClass.obj.getItemTypes();
                    //cboItemType.DisplayMember = "Name";
                    //cboItemType.ValueMember = "ID";
                    //cboItemType.DataSource = dtItemTypes;

                    //DataTable dtCatalog = dbClass.obj.getCatalogList();
                    //cboCatalogFrom.DisplayMember = "Catalog";
                    //cboCatalogFrom.ValueMember = "ID";
                    //cboCatalogFrom.DataSource = dtCatalog;

                    //DataTable dtCatalogt = dbClass.obj.getCatalogList();
                    //cboCatalogTo.DisplayMember = "Catalog";
                    //cboCatalogTo.ValueMember = "ID";
                    //cboCatalogTo.DataSource = dtCatalogt;
                    

                    //DataTable dtVendor = dbClass.obj.getVendorList();
                    //cboVendor.DisplayMember = "Name";
                    //cboVendor.ValueMember = "ID";
                    //cboVendor.DataSource = dtVendor;
                    
                    //DataTable dtItemGroups = dbClass.obj.getItemGroupsList();
                    //cboItemGroups.DisplayMember = "Name";
                    //cboItemGroups.ValueMember = "ID";
                    //cboItemGroups.DataSource = dtCatalog;          

                    break;
                case "InventoryTransactionReport":
                    chkAllCriteria.Visible = true;
                    chkAllCriteria.Checked = true;
                    lblCriteria.Visible = true;
                    cboCriteria.Visible = true;
                    lblDateFrom.Visible = true;
                    DateFrom.Visible = true;
                    lblDateTo.Visible = true;
                    DateTo.Visible = true;
                        break;
                case "InventoryTransactionByVendorReport":
                        chkAllCriteria.Visible = true;
                        chkAllCriteria.Checked = true;
                        lblCriteria.Visible = true;
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                case "InventoryBinReport":
                        chkAllCriteria.Visible = true;
                        chkAllCriteria.Checked = true;
                        lblCriteria.Visible = true;
                        cboCriteria.Visible = true;
                        lblDateFrom.Visible = true;
                        DateFrom.Visible = true;
                        lblDateTo.Visible = true;
                        DateTo.Visible = true;
                        break;
                    case "InventoryModelValueReport":
                        chkAllCriteria.Visible = true;
                        chkAllCriteria.Checked = true;
                        lblCriteria.Visible = true;
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

        private void chkAllCriteria_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAllCriteria.Checked)
            {
                cboCriteria.Enabled = false;
                DateFrom.Enabled = false;
                DateTo.Enabled = false;
            }
            else
            {
                cboCriteria.SelectedIndex = 0;
                cboCriteria.Enabled = true;
                DateFrom.Enabled = true;
                DateTo.Enabled = true;
            }
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
                cboCatalogFrom.SelectedIndex = 0; 
                cboCatalogTo.SelectedIndex = 0;                
                cboCatalogFrom.Enabled = true;
                cboCatalogTo.Enabled = true;                
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
