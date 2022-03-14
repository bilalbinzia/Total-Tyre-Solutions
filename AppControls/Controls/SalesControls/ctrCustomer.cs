using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using System32;
using DBModule;
using System.Data.SqlClient;
using RptModule;

namespace AppControls
{
    public partial class ctrCustomer : BaseControl
    {
        public int CusID = 0;
        string Mode = "";
        BindingSource CustomerBS;
        public ctrCustomer()
        {
            InitializeComponent();
            CustomerBS = new BindingSource();

            this.Load += ctrCustomer_Load;

            this.txtZipCode.Leave += txtZipCode_Leave;
            this.txtZipCode.KeyDown += txtZipCode_KeyDown;
            btnPrint.Click += btnPrint_Click;
        }

        void txtZipCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtZipCode.Text))
                loadCountryByZipCode(Convert.ToInt32(txtZipCode.Text));
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("Reports.CustomerLedger", "Customer Ledger Report", this.CusID);
        }
        public ctrCustomer(int cusID, string mode)
        {
            InitializeComponent();
            this.CusID = cusID;
            this.Mode = mode;
            this.Load += ctrCustomer_Load;

            this.txtZipCode.KeyDown += txtZipCode_KeyDown;
            //this.txtZipCode2.KeyDown += txtZipCode2_KeyDown;
        }
        void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtZipCode.Text))
                    loadCountryByZipCode(Convert.ToInt32(txtZipCode.Text));
            }
        }
        //void txtZipCode2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        loadCountryByZipCode2();
        //    }
        //}
        void loadCountryByZipCode(int zipcode)
        {
            if (zipcode > 0)
            {
                DataRow dr = dbClass.obj.getRowByZipCode(zipcode);
                if (dr != null)
                {
                    txtCountry.Text = Convert.ToString(dr["Country"]);
                    txtStateName.Text = Convert.ToString(dr["StateName"]);
                    txtStateInitial.Text = Convert.ToString(dr["StateInitial"]);
                    txtCityName.Text = Convert.ToString(dr["CityName"]);
                }
                else
                {
                    txtCountry.Text = "";
                    txtStateName.Text = "";
                    txtStateInitial.Text = "";
                    txtCityName.Text = "";
                }
            }
            else
            {
                txtCountry.Text = "";
                txtStateName.Text = "";
                txtStateInitial.Text = "";
                txtCityName.Text = "";
            }
        }
        
        protected override void DataNavigation()
        {
            base.DataNavigation();
            
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                DataTable dt = dbClass.obj.FillCustomerHistoryList(Convert.ToInt32(curRow["ID"]));
                fillSalesData();
                FillAging();
                CustomerBS.DataSource = dt;
                DGVCustomerHistory.SetSource(CustomerBS);
                if (!string.IsNullOrEmpty(curRow["ZipCode"].ToString()))
                {
                    loadCountryByZipCode(Convert.ToInt32(curRow["ZipCode"]));
                }
            }                
        }
        void ctrCustomer_Load(object sender, EventArgs e)
        {
            if (this.Mode == "Add")
            {
                this.objBindingSource.AddNew();
                this.bindingNavigatorAddNewItem_Click(sender, e);
            }
            if (this.Mode == "Edit")
            {
                int index = this.objBindingSource.Find("ID", this.CusID);
                if (index > 0)
                    this.objBindingSource.Position = index;
                base.bindingNavigatorEditItem_Click(sender, e);                                
            }            
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bool AddPermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '032'");
            if (row[0]["CanView"] != DBNull.Value)
                AddPermission = Convert.ToBoolean(row[0]["CanView"]);
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add.");
            }
            else
            {
                base.bindingNavigatorAddNewItem_Click(sender, e);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["IsCustomer"] = true;
                //curRow["CountryID"] = 1;
                curRow["StoreID"] = StaticInfo.StoreID;
                curRow["ReferredByID"] = 1;
                curRow["SaleTermID"] = 2;
                curRow["RegDate"] = DateTime.Now;
                curRow["SaleCategoryID"] = 1;
                curRow["PriceLevelID"] = 1;
                curRow["SaleTaxRateID"] = 1;
                curRow["ShipViaID"] = 9;

                curRow.EndEdit();
                this.DataNavigation();
            }
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            
            bool CustomerEdit = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '005'");
            if (row[0]["CanView"] != DBNull.Value)
                CustomerEdit = Convert.ToBoolean(row[0]["CanView"]);

            if (CustomerEdit)
                base.bindingNavigatorEditItem_Click(sender, e);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Edit the Customer.");
                base.bindingNavigatorCancelItem_Click(sender, e);
            }
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorSaveItem_Click(sender, e);
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            this.CusID = Convert.ToInt32(curRow["ID"]);
        }
        protected override void bindingNavigatorDelete_Click(object sender, EventArgs e)
        {
            bool DeletePermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '034'");
            if (row[0]["CanView"] != DBNull.Value)
                DeletePermission = Convert.ToBoolean(row[0]["CanView"]);
            if (!DeletePermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Delete.");
            }
            else
            {
                base.bindingNavigatorDelete_Click(sender, e);
            }
        }
        public void FillAging()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            this.CusID = Convert.ToInt32(curRow["ID"]);
            RptClass rptClass = new RptClass();
            string connectionString = dbClass.obj.connectionString;
            string queryString = rptClass.AgingReportMasterQry(this.CusID, DateTime.Now.Date);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(queryString, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taTextBox13.Text = (reader["D3"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D3"]);
                            taTextBox22.Text = (reader["D4"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D4"]);
                            taTextBox15.Text = (reader["D5"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D5"]);
                            taTextBox16.Text = (reader["D6"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D6"]);
                            taTextBox17.Text = (reader["D7"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D7"]);
                            taTextBox19.Text = (reader["D2"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D2"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message.ToString(), "Error Message");
            }
        }
        public void fillSalesData()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            this.CusID = Convert.ToInt32(curRow["ID"]);
            string connectionString = dbClass.obj.connectionString;
            string queryString = "SELECT " +
                                    "(select top(1)TrnsDate from CustomerReceipt where CustomerID="+this.CusID+ ") as FirstPurchase," +
                                    "(select top(1)TrnsDate from CustomerReceipt where CustomerID= "+this.CusID+ " order by TrnsDate desc) as LastPurchase," +
                                    "(select top(1)TrnsDate from CustomerPayment where CustomerID= " + this.CusID+ " order by TrnsDate desc) as LastPaid," +
                                    "(select ModifyDate from Customer where ID= " + this.CusID+ ") as LastModified," +
                                    "(select Name from Employee where ID = (select ModifyUserID from Customer where ID= " + this.CusID+")) as ModifiedBy," +
                                    "(select sum(TotalReceivedAmount) from CustomerReceipt where CustomerID= "+this.CusID+") as TotalSales";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(queryString, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FirstPurchase.Text = (reader["FirstPurchase"]==DBNull.Value)?"":reader["FirstPurchase"].ToString().Split(' ')[0];
                            LastPurchase.Text = (reader["LastPurchase"] == DBNull.Value) ? "" : reader["LastPurchase"].ToString().Split(' ')[0];
                            LastPaid.Text = (reader["LastPaid"] == DBNull.Value) ? "" : reader["LastPaid"].ToString().Split(' ')[0];
                            LastModified.Text = (reader["LastModified"] == DBNull.Value) ? "" : reader["LastModified"].ToString().Split(' ')[0];
                            ModifiedBy.Text = (reader["ModifiedBy"] == DBNull.Value) ? "" : (string)reader["ModifiedBy"];
                            TotalSales.Text = (reader["TotalSales"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["TotalSales"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message.ToString(), "Error Message");
            }
        }
    }
}
