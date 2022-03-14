using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System32;
using System.Data.SqlClient;
using ControlLibrary;
using AppControls;

namespace AutoVaultEss
{
    public partial class FrmLogin : Form
    {
        ControlLibrary.MessageBox xMessageBox = null;
        ErrorProvider ErrorProvider;
        MainDataSet objDataSet;
        LoginDetail objLoginDetail;
        public FrmLogin()
        {
            InitializeComponent();

            this.Load += FrmLogin_Load;
            this.txtBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPassword_KeyDown);
            this.txtBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxUserName_KeyDown);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            //this.btnRegisteration.Click += new System.EventHandler(this.btnRegisteration_Click);
            
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            lblcopyrights.Text = "Powered by Total Tire Solutions; Email:info@totaltiresolutions.com";
            lblcopyrights.ForeColor = Color.White;
            //lblcopyrights.Font.Size(5);
            xMessageBox = new ControlLibrary.MessageBox();
            ErrorProvider = new ErrorProvider();
            ErrorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            objDataSet = new MainDataSet();
            objLoginDetail = new LoginDetail();
        }

        private void btnRegisteration_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrEmployee", "Employee Details", 0);
        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        //}
        void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------------
                System32.SystemRegistration.systemRegistration();
                //btnRegisteration.Visible = false;

                //bool Status = dbClass.obj.SystemRegistration();
                //if (Status == false)
                //{
                //    xMessageBox.Show("System is already Registered...!");
                //}
                if (!dbClass.obj.isPOSExist())
                {
                    xMessageBox.Show("System is Not Registered...!");
                    Environment.Exit(0);
                }
                if (!CheckDate(dbClass.obj.GetExpiryDate()))
                {
                    string POSExpiryDate = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("2022-10-10")));
                    dbClass.obj.UpdatePOSExpiryDate(POSExpiryDate);
                    xMessageBox.Show("System is Expire.....");
                    Environment.Exit(0);
                }
                if (!dbClass.obj.isCompanyInfoExist())
                {
                    xMessageBox.Show("Company is Not Registered.....");
                    Environment.Exit(0);
                }
                //-----------------------------------------------------------------------
                objLoginDetail.ColorSetting();

                DataTable dtCompany = dbClass.obj.getAllCompanyInfo();
                cboCompany.DisplayMember = "CoName";
                cboCompany.ValueMember = "ID";
                cboCompany.DataSource = dtCompany;

                //this.BackColor = StaticInfo.ctrBackColor;
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); Environment.Exit(0); }
        }
        private void btnClose_Click(object sender, EventArgs e)
        { Environment.Exit(0); }
        private void txtBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtBoxUserName.Text.ToString().Trim())) { txtBoxPassword.Focus(); }
                    else { xMessageBox.Show("Enter User Name!"); txtBoxUserName.Focus(); }
                }
            }
            catch { }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        { try { Validation(); } catch { } }
        private void Validation()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBoxUserName.Text.ToString().Trim()))
                {
                    ErrorProvider.SetError(this.txtBoxUserName, "");
                    if (!string.IsNullOrEmpty(txtBoxPassword.Text.ToString().Trim()))
                    {
                        ErrorProvider.SetError(this.txtBoxPassword, "");
                        this.Cursor = Cursors.WaitCursor;

                        string userName = txtBoxUserName.Text.ToString().Trim();
                        string password = txtBoxPassword.Text.ToString().Trim();

                        userName = System32.EncryptDecrypt.Encrypt(userName);
                        password = System32.EncryptDecrypt.Encrypt(password);

                        dbClass.obj.GetLoginAuthonticatioin(objDataSet.UserLogin, userName);
                        if (objDataSet.UserLogin.Rows.Count > 0)
                        {
                            if (!password.Equals(Convert.ToString(objDataSet.UserLogin.Rows[0]["password"])))
                            { this.Cursor = Cursors.Default; ErrorProvider.SetError(this.txtBoxPassword, "Password is Invalid..!"); txtBoxPassword.Focus(); }
                            else
                            {
                                if (Convert.ToBoolean(objDataSet.UserLogin.Rows[0]["Active"]))
                                    this.Login(userName, password);
                                else
                                { this.Cursor = Cursors.Default; xMessageBox.Show("User is not Active ....."); }
                            }
                        }
                        else { this.Cursor = Cursors.Default; ErrorProvider.SetError(this.txtBoxUserName, "User Name is Invalid!"); txtBoxUserName.Focus(); }
                    }
                    else { this.Cursor = Cursors.Default; ErrorProvider.SetError(this.txtBoxPassword, "Enter Password!"); txtBoxPassword.Focus(); }
                }
                else { this.Cursor = Cursors.Default; ErrorProvider.SetError(this.txtBoxUserName, "Enter User Name!"); txtBoxUserName.Focus(); }
            }
            catch (Exception ex) { this.Cursor = Cursors.Default; xMessageBox.Show(ex.Message.ToString()); }
        }
        private void Login(string Login, string password)
        {
            try
            {
                //if (Convert.ToInt32(objDataSet.UserLogin.Rows[0]["ID"]) > 6)
                //{
                dbClass.obj.GetEmployeeByUserLoginID(objDataSet.Employee, Convert.ToInt32(objDataSet.UserLogin.Rows[0]["UserLoginID"]));
                if (Convert.ToBoolean(objDataSet.UserLogin.Rows[0]["Active"]))
                {
                    objLoginDetail.ApplicationSetting(objDataSet.UserLogin);
                    if (objLoginDetail.IswithinDateTime(objDataSet.UserLogin))
                    {
                        //----check current date and time-----   
                        DataTable dt = new DataTable();
                        dt = objDataSet.Employee;
                        if (dt.Rows[0]["CompanyID"] != DBNull.Value)
                        {
                            //if (dt.Rows[0]["CompanyID"].ToString() == cboCompany.SelectedValue.ToString())
                            //{
                                objLoginDetail.CompanySetting(dt);
                                StaticInfo.UserRights = dbClass.obj.getUserRights(StaticInfo.userid);

                                bool LoginPermission = false;
                                DataRow[] row = StaticInfo.UserRights.Select("Code = '040'");
                                if (row[0]["CanView"] != DBNull.Value)
                                    LoginPermission = Convert.ToBoolean(row[0]["CanView"]);
                                if (LoginPermission || dt.Rows[0]["Name"].ToString() == "Admin")
                                {
                                    this.ApplicationSetting();
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    xMessageBox.Show("Sorry! You don't have Permissions to Login.");
                                }
                            //}
                            //else
                            //{
                            //    this.Cursor = Cursors.Default; xMessageBox.Show("Authentication process failed for this company...!"); cboCompany.Focus();
                            //}
                        }
                        else
                        {
                            this.Cursor = Cursors.Default; xMessageBox.Show("Please Select Company...!");
                        }
                    }
                    else
                    { this.Cursor = Cursors.Default; xMessageBox.Show("User have no Access...!"); }
                }
                else { this.Cursor = Cursors.Default; xMessageBox.Show("User have no Access...!"); }
            }
            catch { this.Cursor = Cursors.Default; xMessageBox.Show("Authentication process failed...!"); txtBoxPassword.Focus(); }
        }

        void ApplicationSetting()
        {
            this.Hide();

            FrmMain2 frmMain = new FrmMain2();            
            frmMain.IsMdiContainer = true;
            frmMain.Text = StaticInfo.CompanyName + " | " + StaticInfo.WarehouseName + " | " + StaticInfo.BranchName;
            frmMain.WindowState = FormWindowState.Maximized;
            frmMain.lblStatusCompanyName.Text += StaticInfo.CompanyName + " | ";
            frmMain.lblStatusCompanyName.Text += StaticInfo.WarehouseName + " | ";
            frmMain.lblStatusBranchName.Text += StaticInfo.BranchName + " | ";
            frmMain.lblStatusUserLogin.Text += StaticInfo.userName + " | ";
            frmMain.lblStatusUserLevel.Text += StaticInfo.userLevel + " | ";
            frmMain.lblStatusWorkingForm.Text = "";
            frmMain.Show();

            //------------------------------------------
            //-----Add DashBoard in FromMain----------//
            //frmDashBoard objDashBoard = new frmDashBoard();
            //objDashBoard.Width = this.Width - this.LeftButtonPanel.Width - 25;
            //objDashBoard.Height = this.Height - MainMenuStrip.Height - MainStatusStrip.Height - 45;
            //objDashBoard.MdiParent = this;
            //objDashBoard.Show();
            //-------------------------------------------
            //frmDashBoard objDashBoard = new frmDashBoard();
            //objDashBoard.Width = frmMain.Width - frmMain.Width - 25;
            //objDashBoard.Height = frmMain.Height - frmMain.Height - 45;
            //objDashBoard.MdiParent = frmMain;
            //objDashBoard.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            //objDashBoard.Dock = DockStyle.Fill;            
            //objDashBoard.Show();
            //objDashBoard.BackgroundImage = global::AutoVaultEss.Properties.Resources._1;
            //-------------------------------------------
            ctrDashBoard3 ctr = new ctrDashBoard3();
            ctr.Dock = DockStyle.Fill;
            frmCtr objDashBoard = new frmCtr("DashBoard");
            objDashBoard.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            objDashBoard.frmPnl.Controls.Add(ctr);
            objDashBoard.MdiParent = frmMain;
            objDashBoard.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            objDashBoard.Dock = DockStyle.Fill;
            objDashBoard.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objDashBoard.Show();
            //-------------------------------------------           
            objLoginDetail.LoginActivity();           
            this.Cursor = Cursors.Default;            
        }
        void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        { try { if (e.KeyCode == Keys.Enter) { Validation(); } } catch { } }
        bool CheckDate(DateTime d1)
        {
            dbClass.obj.FillAll(objDataSet.POSDetail, "ID");
            if (objDataSet.POSDetail.Rows.Count > 0)
            {

                DateTime UpdateUserAddDate = Convert.ToDateTime("2022-10-10");
                DateTime ExpiryDate = d1;
                DateTime UserAddDate = Convert.ToDateTime(objDataSet.POSDetail.Rows[0]["AddDate"]);
                DateTime CurrentDate = DateTime.Now;

                if (UserAddDate != UpdateUserAddDate)
                    if (ExpiryDate >= UserAddDate)
                        if (ExpiryDate > CurrentDate)
                            return true;
                        else
                            return false;
                    else
                        return false;
                else
                    return false;
            }
            else
                return false;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            xMessageBox.Show("Are you sure you want to close the form");
            BaseControl.LogOff(); Environment.Exit(0);
        }

        private void btnCross_Click_1(object sender, EventArgs e)
        {
            BaseControl.LogOff(); Environment.Exit(0);
        }
    }
}
