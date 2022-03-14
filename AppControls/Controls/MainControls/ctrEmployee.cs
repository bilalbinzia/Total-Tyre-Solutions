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
    public partial class ctrEmployee : BaseControl
    {

        public ctrEmployee()
        {
            InitializeComponent();

            this.Load += ctrEmployee_Load;
            this.ctrIsLoginForWarehouse.CheckedChanged += ctrIsLoginForWarehouse_CheckedChanged;
            this.ctrIsLoginForStore.CheckedChanged += ctrIsLoginForStore_CheckedChanged;
        }

        void ctrIsLoginForStore_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.frmStatus == currentStatus.Add) || (this.frmStatus == currentStatus.Edit))
            {
                if (ctrIsLoginForStore.Checked)
                {
                    this.ctrLoginWarehouseID.Enabled = false;
                    this.ctrLoginStoreID.Enabled = true;

                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["LoginWarehouseID"] = DBNull.Value;
                    curRow["IsLoginForWarehouse"] = false;
                    curRow["IsLoginForStore"] = true;
                    curRow.EndEdit();
                }
            }
        }

        void ctrIsLoginForWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.frmStatus == currentStatus.Add) || (this.frmStatus == currentStatus.Edit))
            {
                if (ctrIsLoginForWarehouse.Checked)
                {
                    this.ctrLoginWarehouseID.Enabled = true;
                    this.ctrLoginStoreID.Enabled = false;

                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();                    
                    curRow["LoginStoreID"] = DBNull.Value;
                    curRow["IsLoginForWarehouse"] = true;
                    curRow["IsLoginForStore"] = false;
                    curRow.EndEdit();
                }
            }
        }

        void ctrEmployee_Load(object sender, EventArgs e)
        {

        }
        protected override void DataNavigation()
        {
            base.DataNavigation();
            LoginSettings();
        }
        void LoginSettings()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                try {
                    DataTable dt = dbClass.obj.getUserLoginDetail(objDataSet.Tables["UserLogin"].Copy(), Convert.ToInt32(curRow["ID"]));
                    if (dt.Rows.Count > 0)
                    {
                        chkboxIsLogin.Checked = Convert.ToBoolean(dt.Rows[0]["Active"]);

                        txtUserName.Text = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginName"]));
                        txtPassword.Text = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["Password"]));

                        dtLoginStartTime.Value = Convert.ToDateTime(System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginStartTime"])));
                        dtLoginEndTime.Value = Convert.ToDateTime(System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginEndTime"])));

                        NumUserGroupID.Value = Convert.ToInt32(dt.Rows[0]["UserGroupID"]);
                    }
                    else
                    {
                        chkboxIsLogin.Checked = false;

                        txtUserName.Text = "";
                        txtPassword.Text = "";

                        dtLoginStartTime.Value = DateTime.Now;
                        dtLoginEndTime.Value = DateTime.Now;

                        NumUserGroupID.Value = 6;

                        ctrIsLoginForWarehouse.Checked = false;
                        ctrIsLoginForStore.Checked = false;
                    }
                }
                catch { }
            }
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            int UserLoginID = Convert.ToInt32(curRow["ID"]);
            bool isUserNameDuplicate = false;
            isUserNameDuplicate = dbClass.obj.isUserNameDuplicate(System32.EncryptDecrypt.Encrypt(Convert.ToString(txtUserName.Text.Trim())), UserLoginID);
            if (!isUserNameDuplicate)
            {
                errorProvider1.SetError(this.txtUserName, "");

                base.bindingNavigatorSaveItem_Click(sender, e);
                if (UserLoginID < 0)
                    UserLoginID = dbClass.obj.GetEmployeeIDByUserName(Convert.ToString(txtUserName.Text.Trim()));


                //DataRowView curRow = (DataRowView)objBindingSource.Current;
                //int UserLoginID = Convert.ToInt32(curRow["ID"]);
                if (UserLoginID > 0)
                {
                    DataTable dt = objDataSet.Tables["UserLogin"].Copy();
                    DataRow dtnRow = dt.NewRow();

                    dtnRow["UserLoginID"] = UserLoginID;
                    dtnRow["UserGroupID"] = NumUserGroupID.Value;
                    if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
                        dtnRow["LoginName"] = System32.EncryptDecrypt.Encrypt(Convert.ToString(txtUserName.Text.Trim()));
                    else
                        dtnRow["LoginName"] = DBNull.Value;

                    if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                        dtnRow["Password"] = System32.EncryptDecrypt.Encrypt(Convert.ToString(txtPassword.Text.Trim()));
                    else
                        dtnRow["Password"] = DBNull.Value;

                    dtnRow["LoginStartDate"] = "rp9ZpMzSu1p/yQ0QpjVY8kHQV5knbDyGok867GUehdc=";
                    dtnRow["LoginEndDate"] = "UGwid1TC9DVy/wWk2h4vgWitgBMe9sQnsQTzLBq2I8U=";

                    dtnRow["LoginStartTime"] = System32.EncryptDecrypt.Encrypt(Convert.ToString(dtLoginStartTime.Value));
                    dtnRow["LoginEndTime"] = System32.EncryptDecrypt.Encrypt(Convert.ToString(dtLoginEndTime.Value));

                    dtnRow["Active"] = chkboxIsLogin.Checked;
                    dtnRow["AddDate"] = DateTime.Now;
                    dtnRow["AddUserID"] = StaticInfo.userid;

                    dtnRow["ModifyDate"] = DateTime.Now;
                    dtnRow["ModifyUserID"] = StaticInfo.userid;

                    dtnRow["IsLocked"] = false;

                    dt.Rows.Add(dtnRow);

                    if (dbClass.obj.isExist("UserLogin", "UserLoginID", UserLoginID))
                        dbClass.obj.UpdateUserLogin(dt);
                    else
                        dbClass.obj.AddUserLogin(dt);
                }
            }
            else
            {                
                errorProvider1.SetError(this.txtUserName, "User Name Already Exist..!");                
            }
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                curRow.BeginEdit();
                curRow["IsDisplay"] = true;
                curRow.EndEdit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void taComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
