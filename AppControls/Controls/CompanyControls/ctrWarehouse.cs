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

namespace AppControls
{
    public partial class ctrWarehouse : BaseControl
    {
        BindingSource WarehouseStoreBS;
        public ctrWarehouse()
        {
            InitializeComponent();
            WarehouseStoreBS = new BindingSource();

            this.Load += ctrWarehouse_Load;
            this.btnAddRacks.Click += btnAddRacks_Click;
            this.cboCompany.SelectedIndexChanged += cboCompany_SelectedIndexChanged;
            this.txtZipCode.KeyDown += txtZipCode_KeyDown;
        }
        void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadCountryByZipCode();
            }
        }
        void loadCountryByZipCode()
        {
            if (!string.IsNullOrEmpty(txtZipCode.Text.Trim()))
            {
                int zipcode = Convert.ToInt32(txtZipCode.Text.Trim());
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
            else
            {
                txtCountry.Text = "";
                txtStateName.Text = "";
                txtStateInitial.Text = "";
                txtCityName.Text = "";
            }
        }
        void btnAddRacks_Click(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (curRow != null)
                {
                    if ((Convert.ToInt32(curRow["CompanyID"]) > 0) && (Convert.ToInt32(curRow["ID"]) > 0))
                    {
                        ctrRacks ctrRacks = new ctrRacks(Convert.ToInt32(curRow["CompanyID"]), Convert.ToInt32(curRow["ID"]));
                        //----------------------------------------------------------------------//
                        frmCtr frmCtr = new frmCtr("Manage Racks ...");
                        frmCtr.Height = ctrRacks.Height + 30; frmCtr.Width = ctrRacks.Width + 20;
                        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        frmCtr.frmPnl.Controls.Add(ctrRacks);
                        frmCtr.BringToFront();
                        frmCtr.ShowDialog();
                        LoadWarehouseStores();
                    }
                }
            }
        }

        void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefaultSettings();
        }
        void DefaultSettings()
        {
            if (frmStatus == currentStatus.Add)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (StaticInfo.CompanyID > 0)
                {
                    DataTable dt = dbClass.obj.getWarehouseInfo(StaticInfo.WarehouseID);
                    if (dt.Rows.Count > 0)
                        curRow["CoCode"] = dt.Rows[0]["CoCode"];
                    if (dt.Rows.Count <= 0)
                        dt = dbClass.obj.getCompanyInfoByID(StaticInfo.CompanyID);

                    if (dt.Rows.Count > 0)
                    {
                        curRow["CoName"] = dt.Rows[0]["CoName"];
                        curRow["CoAddress"] = dt.Rows[0]["CoAddress"];
                        curRow["CoPhone"] = dt.Rows[0]["CoPhone"];
                        curRow["CoFax"] = dt.Rows[0]["CoFax"];
                        curRow["CoEmail"] = dt.Rows[0]["CoEmail"];
                        curRow["CoFinYearStrMonth"] = dt.Rows[0]["CoFinYearStrMonth"];
                        curRow["BarNo"] = dt.Rows[0]["BarNo"];
                        curRow["ZipCode"] = dt.Rows[0]["ZipCode"];
                        curRow["AreaCode"] = dt.Rows[0]["AreaCode"];
                        curRow["AreaCode1"] = dt.Rows[0]["AreaCode1"];
                        curRow["AreaCode2"] = dt.Rows[0]["AreaCode2"];
                        curRow["CompanyLogo"] = dt.Rows[0]["CompanyLogo"];
                        if (dt.Rows[0]["CompanyLogo"] != DBNull.Value)
                            this.ctrCompanyLogo.imagePictureBox.BackgroundImage = StaticInfo.byteArrayToImage((byte[])dt.Rows[0]["CompanyLogo"]);
                    }
                }
            }
        }
        protected override void DataNavigation()
        {
            base.DataNavigation();
            LoadWarehouseStores();
        }
        void ctrWarehouse_Load(object sender, EventArgs e)
        {
            if (StaticInfo.userLevel <= 2)
            {
                this.btnBNMoveFirstItem.Visible = true;
                this.btnBNMovePreviousItem.Visible = true;
                this.BNSeparator.Visible = true;
                this.BNPositionItem.Visible = true;
                this.BNCountItem.Visible = true;
                this.BNSeparator1.Visible = true;
                this.btnBNMoveNextItem.Visible = true;
                this.btnBNMoveLastItem.Visible = true;
                this.BNSeparator2.Visible = true;

                this.btnBNAddItem.Visible = true;
                this.btnBNEditItem.Visible = true;
                this.btnBNSaveItem.Visible = true;
                this.btnBNCancelItem.Visible = true;
            }
            else
            {
                this.btnBNAddItem.Enabled = false;
                this.btnBNEditItem.Enabled = false;
                this.btnBNDeleteItem.Enabled = false;
                this.btnBNSaveItem.Enabled = false;
                this.btnBNCancelItem.Enabled = false;
                this.btnBNRefresh.Enabled = false;
            }

            loadCountryByZipCode();
        }
        void LoadWarehouseStores()
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (curRow != null)
                {
                    if (Convert.ToInt32(curRow["ID"]) > 0)
                    {
                        DataTable dt = dbClass.obj.FillWarehouseRacksList(Convert.ToInt32(curRow["ID"]));
                        WarehouseStoreBS.DataSource = dt;
                        DGVStoreList.TDataGridView.DataSource = WarehouseStoreBS;

                        DGVStoreList.TDataGridView.AutoGenerateColumns = true;
                        DGVStoreList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        DGVStoreList.TDataGridView.Columns["ID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["CompanyID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["WarehouseID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["StoreID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["Code"].Width = 350;
                        DGVStoreList.TDataGridView.Columns["Active"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["AddDate"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["AddUserID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["ModifyUserID"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["ModifyDate"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["Comments"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["IsLocked"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["DocNo"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["Remarks"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["CoFinEndYear"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["TrnsVrNo"].Visible = false;
                        DGVStoreList.TDataGridView.Columns["TrnsJrRef"].Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            //DGVWarehouseList.TDataGridView.Columns["Name"].Width = 240;
            //DGVWarehouseList.TDataGridView.Columns["City"].Width = 120;
            //DGVWarehouseList.TDataGridView.Columns["Phone"].Width = 120;
            //DGVWarehouseList.TDataGridView.Columns["Cont Person"].Width = 240;
            //DGVWarehouseList.TDataGridView.Columns["Cont Person Phone"].Width = 120;
            //DGVWarehouseList.TDataGridView.Columns["Balance"].Width = 100;
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            DefaultSettings();
        }
    }
}
