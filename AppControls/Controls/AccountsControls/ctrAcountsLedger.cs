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
using Configuration;

namespace Accounts.Parameter
{
    public partial class ctrAcountsLedger : UserControl
    {
        TAAMSDataSet objDataSet = null;
        BindingSource objBindingSource = null;
        //dbClass.obj dbClass.obj = null;
        string ledtype = string.Empty;
        
        public ctrAcountsLedger()
        {
            InitializeComponent();
            objDataSet = new TAAMSDataSet();
            objBindingSource = new BindingSource();
            //dbClass.obj = new dbClass.obj();
                       
        }

        //void txtDate_TextChanged(object sender, EventArgs e)
        //{
        //    this.cboCriteria.SelectedIndex = 10;
        //}
        public ctrAcountsLedger(string LedgerType)
        {
            InitializeComponent();
            objDataSet = new TAAMSDataSet();
            objBindingSource = new BindingSource();
            //dbClass.obj = new dbClass.obj();
            this.ledtype = LedgerType;

            
        }        
        private void ctrAcountsLedger_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAccountFrom = objDataSet.Tables["Account"].Copy();
                DataTable dtAccountTo = objDataSet.Tables["Account"].Copy();

                DataTable dtCustomerFrom = objDataSet.Tables["Customer"].Copy();
                DataTable dtCustomerTo = objDataSet.Tables["Customer"].Copy();

                DataTable dtSupplierFrom = objDataSet.Tables["Supplier"].Copy();
                DataTable dtSupplierTo = objDataSet.Tables["Supplier"].Copy();

                if (this.ledtype == "AccountsLedger")
                {
                    dbClass.obj.Fill(this.objDataSet.Tables["Account"]);
                    objBindingSource.DataSource = this.objDataSet.Tables["Account"];

                    chkBoxCriteriaByCode.Visible = true;
                    lblAccountFrom.Visible = true;
                    cboBoxCriteriaByCodeAccountFrom.Visible = true;

                    lblAccountTo.Visible = true;
                    cboBoxCriteriaByCodeAccountTo.Visible = true;

                    this.cboBoxCriteriaByCodeAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts1");
                    this.cboBoxCriteriaByCodeAccountFrom.SelectedIndex = 0;
                    this.cboBoxCriteriaByCodeAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts1");
                    int last1 = this.cboBoxCriteriaByCodeAccountTo.Items.Count - 1;
                    this.cboBoxCriteriaByCodeAccountTo.SelectedIndex = last1;
                    //----------------------------------------------------------------------------

                    dtAccountFrom = dbClass.obj.FillDetailAccounts(dtAccountFrom);
                    dtAccountTo = dbClass.obj.FillDetailAccounts(dtAccountTo);

                    this.lblLedgerFrom.Text = "Account:";
                    //this.cboBoxAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts");
                    this.cboBoxAccountFrom.DataSource = dtAccountFrom;
                    this.cboBoxAccountFrom.DisplayMember = "AccName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;
                    
                    //this.label6.Text = "Account To:";
                    //this.cboBoxAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts");
                    this.cboBoxAccountTo.DataSource = dtAccountTo;
                    this.cboBoxAccountTo.DisplayMember = "AccName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;

                   
                }
                if (this.ledtype == "AccountsLedgerTrialBalance")
                {
                    dbClass.obj.Fill(this.objDataSet.Tables["Account"]);
                    objBindingSource.DataSource = this.objDataSet.Tables["Account"];                    

                    chkBoxCriteriaByCode.Visible = true;
                    lblAccountFrom.Visible = true;
                    cboBoxCriteriaByCodeAccountFrom.Visible = true;

                    lblAccountTo.Visible = true;
                    cboBoxCriteriaByCodeAccountTo.Visible = true;

                    this.cboBoxCriteriaByCodeAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts1");
                    this.cboBoxCriteriaByCodeAccountFrom.SelectedIndex = 0;
                    this.cboBoxCriteriaByCodeAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts1");
                    int last1 = this.cboBoxCriteriaByCodeAccountTo.Items.Count - 1;
                    this.cboBoxCriteriaByCodeAccountTo.SelectedIndex = last1;
                    //----------------------------------------------------------------------------

                    dtAccountFrom = dbClass.obj.FillDetailAccounts(dtAccountFrom);
                    dtAccountTo = dbClass.obj.FillDetailAccounts(dtAccountTo);

                    this.lblLedgerFrom.Text = "Account:";
                    //this.cboBoxAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts");
                    this.cboBoxAccountFrom.DataSource = dtAccountFrom;
                    this.cboBoxAccountFrom.DisplayMember = "AccName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;


                    //this.label6.Text = "Account To:";
                    //this.cboBoxAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillDetailAccounts");
                    this.cboBoxAccountTo.DataSource = dtAccountTo;
                    this.cboBoxAccountTo.DisplayMember = "AccName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;
                    this.chkBoxShowZeroBalances.Visible = true;
                }
                if (this.ledtype == "AccountsLedger2ndCurrency")
                {
                    dbClass.obj.FillAccountsforSecCurr(this.objDataSet.Tables["Account"]);
                    objBindingSource.DataSource = this.objDataSet.Tables["Account"];

                    chkBoxCriteriaByCode.Visible = true;
                    lblAccountFrom.Visible = true;
                    cboBoxCriteriaByCodeAccountFrom.Visible = true;

                    lblAccountTo.Visible = true;
                    cboBoxCriteriaByCodeAccountTo.Visible = true;

                    this.cboBoxCriteriaByCodeAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillAccountsforSecCurr");
                    this.cboBoxCriteriaByCodeAccountFrom.SelectedIndex = 0;
                    this.cboBoxCriteriaByCodeAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillAccountsforSecCurr");
                    int last1 = this.cboBoxCriteriaByCodeAccountTo.Items.Count - 1;
                    this.cboBoxCriteriaByCodeAccountTo.SelectedIndex = last1;
                    //----------------------------------------------------------------------------

                    dtAccountFrom = dbClass.obj.FillDetailAccounts(dtAccountFrom);
                    dtAccountTo = dbClass.obj.FillDetailAccounts(dtAccountTo);

                    this.lblLedgerFrom.Text = "Account:";
                    //this.cboBoxAccountFrom.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillAccountsforSecCurr");
                    this.cboBoxAccountFrom.DataSource = dtAccountFrom;
                    this.cboBoxAccountFrom.DisplayMember = "AccName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;


                    //this.label6.Text = "Account To:";
                    //this.cboBoxAccountTo.SetSource(this.objDataSet.Account, "AccName", "ID", "AccID-50, AccName-150", "FillAccountsforSecCurr");
                    this.cboBoxAccountTo.DataSource = dtAccountTo;
                    this.cboBoxAccountTo.DisplayMember = "AccName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;

                }
                if (this.ledtype == "ProfitAndLossAccount")
                {
                    this.lblLedgerFrom.Visible = false;
                    this.cboBoxAccountFrom.Visible = false;
                    this.label5.Visible = false;
                    this.label6.Visible = false;
                    this.cboBoxAccountTo.Visible = false;
                }
                if (this.ledtype == "CustomerLedger")
                {
                    //DataTable dt = new DataTable("Customer1");
                    dtCustomerFrom = dbClass.obj.FillCustomer1(dtCustomerFrom);
                    dtCustomerTo = dbClass.obj.FillCustomer1(dtCustomerTo);

                    this.lblLedgerFrom.Text = "Customer:";
                    //this.cboBoxAccountFrom.SetSource(dt, "CusName", "ID", "CusID-50, CusName-150");
                    this.cboBoxAccountFrom.DataSource = dtCustomerFrom;
                    this.cboBoxAccountFrom.DisplayMember = "CusName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;
                    
                    //this.label6.Text = "Customer To:";
                    //this.cboBoxAccountTo.SetSource(dt, "CusName", "ID", "CusID-50, CusName-150");
                    this.cboBoxAccountTo.DataSource = dtCustomerTo;
                    this.cboBoxAccountTo.DisplayMember = "CusName";
                    this.cboBoxAccountTo.ValueMember = "ID";

                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;

                    this.label6.Visible = true;
                    this.cboBoxAccountTo.Visible = true;
                }
                if (this.ledtype == "CustomerLedgerTrialBalance")
                {
                    //DataTable dt = new DataTable("Customer1");
                    dtCustomerFrom = dbClass.obj.FillCustomer1(dtCustomerFrom);
                    dtCustomerTo = dbClass.obj.FillCustomer1(dtCustomerTo);

                    this.lblLedgerFrom.Text = "Customer:";
                    //this.cboBoxAccountFrom.SetSource(dt, "CusName", "ID", "CusID-50, CusName-150");
                    this.cboBoxAccountFrom.DataSource = dtCustomerFrom;
                    this.cboBoxAccountFrom.DisplayMember = "CusName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;

                    //this.label6.Text = "Customer To:";
                    //this.cboBoxAccountTo.SetSource(dt, "CusName", "ID", "CusID-50, CusName-150");
                    this.cboBoxAccountTo.DataSource = dtCustomerTo;
                    this.cboBoxAccountTo.DisplayMember = "CusName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;
                    this.label6.Visible = true;
                    this.cboBoxAccountTo.Visible = true;

                    this.chkBoxShowZeroBalances.Visible = true;

                }
                if (this.ledtype == "SupplierLedger")
                {
                    //DataTable dt = new DataTable("Supplier1");
                    dtSupplierFrom = dbClass.obj.FillSupplier1(dtSupplierFrom);
                    dtSupplierTo = dbClass.obj.FillSupplier1(dtSupplierTo);

                    this.lblLedgerFrom.Text = "Supplier:";
                    //this.cboBoxAccountFrom.SetSource(dt, "SupName", "ID", "SupID-50, SupName-150");
                    this.cboBoxAccountFrom.DataSource = dtSupplierFrom;
                    this.cboBoxAccountFrom.DisplayMember = "SupName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;                    

                    //this.label6.Text = "Supplier To:";
                    //this.cboBoxAccountTo.SetSource(dt, "SupName", "ID", "SupID-50, SupName-150");
                    this.cboBoxAccountTo.DataSource = dtSupplierTo;
                    this.cboBoxAccountTo.DisplayMember = "SupName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;
                    this.label6.Visible = true;
                    this.cboBoxAccountTo.Visible = true;

                }                
                if (this.ledtype == "SupplierLedgerTrialBalance")
                {
                    //DataTable dt = new DataTable("Supplier1");
                    dtSupplierFrom = dbClass.obj.FillSupplier1(dtSupplierFrom);
                    dtSupplierTo = dbClass.obj.FillSupplier1(dtSupplierTo);

                    this.lblLedgerFrom.Text = "Supplier:";
                    //this.cboBoxAccountFrom.SetSource(dt, "SupName", "ID", "SupID-50, SupName-150");
                    this.cboBoxAccountFrom.DataSource = dtSupplierFrom;
                    this.cboBoxAccountFrom.DisplayMember = "SupName";
                    this.cboBoxAccountFrom.ValueMember = "ID";
                    this.cboBoxAccountFrom.SelectedIndex = 0;

                    //this.label6.Text = "Supplier To:";
                    //this.cboBoxAccountTo.SetSource(dt, "SupName", "ID", "SupID-50, SupName-150");
                    this.cboBoxAccountTo.DataSource = dtSupplierTo;
                    this.cboBoxAccountTo.DisplayMember = "SupName";
                    this.cboBoxAccountTo.ValueMember = "ID";
                    int last = this.cboBoxAccountTo.Items.Count - 1;
                    this.cboBoxAccountTo.SelectedIndex = last;
                    this.label6.Visible = true;
                    this.cboBoxAccountTo.Visible = true;
                    this.chkBoxShowZeroBalances.Visible = true;
                }
            }
            catch { }
            //---------------------------------
            this.cboCriteria.SelectedIndex = 0;
            //---------------------------------
        }
        void ComboSetting(bool enable, DateTime dateFrom, DateTime dateTo)
        {
            //DateFrom.Enabled = enable;
            DateFrom.DateTimePicker1.Value = dateFrom.Date;            
            //DateTo.Enabled = enable;
            DateTo.DateTimePicker1.Value = dateTo.Date;            
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
                    startDate = new DateTime(DateTime.Now.Year -1, coFinYearStrMonth, 1);
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
                int year = Convert.ToInt32(DateTime.Now.Year -1);
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
                    startDate = new DateTime(DateTime.Now.Year -2, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                else
                {
                    startDate = new DateTime(DateTime.Now.Year -1, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                ComboSetting(false, startDate, endDate);
            }
            //if (cboCriteria.SelectedItem == "Custom")
            //    ComboSetting(true, DateTime.Now, DateTime.Now);
            
        }

        private void chkBoxCriteriaByCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxCriteriaByCode.Checked)
            {
                cboBoxCriteriaByCodeAccountFrom.Enabled = true;
                cboBoxCriteriaByCodeAccountTo.Enabled = true;
                cboBoxAccountFrom.Enabled = false;
                cboBoxAccountTo.Enabled = false;
            }
            else
            {
                cboBoxCriteriaByCodeAccountFrom.Enabled = false;
                cboBoxCriteriaByCodeAccountTo.Enabled = false;
                cboBoxAccountFrom.Enabled = true;
                cboBoxAccountTo.Enabled = true;
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

