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
using RptModule;
using System.Data.SqlClient;

namespace AppControls
{
    public partial class ctrVendor : BaseControl
    {
        BindingSource VendorBS;
        public ctrVendor()
        {
            InitializeComponent();
            VendorBS = new BindingSource();

            this.Load += ctrVendor_Load;
            btnPrintLedger.Click += btnPrintLedger_Click;
            btnClaimsCores.Click += btnClaimsCores_Click;

            this.txtZipCode.Leave += txtZipCode_Leave;
            this.txtZipCode.KeyDown += txtZipCode_KeyDown;
            this.txtZipCode2.Leave += txtZipCode2_Leave;
            this.txtZipCode2.KeyDown += txtZipCode2_KeyDown;
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bool AddPermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '038'");
            if (row[0]["CanView"] != DBNull.Value)
                AddPermission = Convert.ToBoolean(row[0]["CanView"]);
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add.");
            }
            else
            {
                base.bindingNavigatorAddNewItem_Click(sender, e);
                //-------------------------------            
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();

                curRow["RegDate"] = DateTime.Now;
                curRow["Code"] = dbClass.obj.getNextVendorCode();

                curRow.EndEdit();

                this.DataNavigation();
            }
        }
        void txtZipCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtZipCode.Text))
                loadCountryByZipCode(Convert.ToInt32(txtZipCode.Text));
        }
        void txtZipCode2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtZipCode2.Text))
                loadCountryByZipCode2(Convert.ToInt32(txtZipCode2.Text));
        }
        void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtZipCode.Text))
                    loadCountryByZipCode(Convert.ToInt32(txtZipCode.Text));
            }
        }
        void txtZipCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtZipCode2.Text))
                    loadCountryByZipCode2(Convert.ToInt32(txtZipCode2.Text));
            }
        }
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
        void loadCountryByZipCode2(int zipcode)
        {
            if (zipcode > 0)
            {
                DataRow dr = dbClass.obj.getRowByZipCode(zipcode);
                if (dr != null)
                {
                    txtCountry2.Text = Convert.ToString(dr["Country"]);
                    txtStateName2.Text = Convert.ToString(dr["StateName"]);
                    txtStateInitial2.Text = Convert.ToString(dr["StateInitial"]);
                    txtCityName2.Text = Convert.ToString(dr["CityName"]);
                }
                else
                {
                    txtCountry2.Text = "";
                    txtStateName2.Text = "";
                    txtStateInitial2.Text = "";
                    txtCityName2.Text = "";
                }
            }
            else
            {
                txtCountry2.Text = "";
                txtStateName2.Text = "";
                txtStateInitial2.Text = "";
                txtCityName2.Text = "";
            }
        }
        void btnClaimsCores_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
                StaticInfo.LoadToControl("AppControls.ctrWarrantyClaimAndCoresList", "Warranty Claims And Cores List", -1, Convert.ToInt32(curRow["ID"]));
        }
        void btnPrintLedger_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) >= 1)
                StaticInfo.LoadToReport("RptModule", "Reports.VendorLedgerReport", "byID", Convert.ToInt32(curRow["ID"]));
        }
        void ctrVendor_Load(object sender, EventArgs e)
        {

        }
        protected override void DataNavigation()
        {
            base.DataNavigation();

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                DataTable dt = dbClass.obj.FillVendorHistoryList(Convert.ToInt32(curRow["ID"]));
                VendorBS.DataSource = dt;
                DGVVendorHistory.SetSource(VendorBS);
                int VendorID = Convert.ToInt32(curRow["ID"]);
                RptClass rptClass = new RptClass();
                string connectionString = dbClass.obj.connectionString;
                string queryString = rptClass.VendorAgingReportMasterQry(DateTime.Now.Date);
                queryString = queryString + " where Cus.ID=" + VendorID + " and Cus.CompanyID=" + StaticInfo.CompanyID;
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
                                taTextBox6.Text = (reader["D3"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D3"]);
                                taTextBox11.Text = (reader["D4"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D4"]);
                                taTextBox13.Text = (reader["D5"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D5"]);
                                taTextBox14.Text = (reader["D6"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D6"]);
                                taTextBox15.Text = (reader["D2"] == DBNull.Value) ? "" : string.Format("{0:C}", reader["D2"]);
                                //taTextBox11.Text = (reader["D4"] == DBNull.Value) ? "" : reader["D4"].ToString().Split(' ')[0];
                                //taTextBox13.Text = (reader["D5"] == DBNull.Value) ? "" : reader["D5"].ToString().Split(' ')[0];
                                //taTextBox14.Text = (reader["D6"] == DBNull.Value) ? "" : reader["D6"].ToString().Split(' ')[0];
                                //taTextBox15.Text = (reader["D2"] == DBNull.Value) ? "" : reader["D2"].ToString().Split(' ')[0];
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

        private void btnPurchaseOrder_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                int VendorId = Convert.ToInt32(curRow["ID"]);
                StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase", VendorId,VendorId);
            }
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

        private void btnBills_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                int VendorId = Convert.ToInt32(curRow["ID"]);
                StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Payments", VendorId,VendorId);
            }
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

    }
}
