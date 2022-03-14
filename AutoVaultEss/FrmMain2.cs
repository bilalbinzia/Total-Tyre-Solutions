
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using ControlLibrary;
using System32;
using DBModule;
using Tulpep.NotificationWindow;

namespace AutoVaultEss
{
    public partial class FrmMain2 : Form, iFrmMain
    {
        ControlLibrary.MessageBox xMessageBox = null;
        LoginDetail objLoginDetail;
        bool PanelIsClose = false;
        bool ManuIsClose = false;
        int LastNotificationID = 0;
        PopupNotifier popup = new PopupNotifier();

        public FrmMain2()
        {
            InitializeComponent();


            //this.BackColor = StaticInfo.ctrBackColor;
            ////this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));

            //this.MainStatusStrip.BackColor = StaticInfo.ctrBackColor;
            //this.MainMenuStrip.BackColor = StaticInfo.ctrBackColor;
            //this.RecentButtonPanel.BackColor = StaticInfo.ctrBackColor;
            //this.LeftButtonPanel.BackColor = StaticInfo.ctrBackColor;

            //lblStatusCompanyName.ForeColor = StaticInfo.ctrLabelForeColor;
            //lblStatusBranchName.ForeColor = StaticInfo.ctrLabelForeColor;
            //lblStatusUserLogin.ForeColor = StaticInfo.ctrLabelForeColor;
            //lblStatusUserLevel.ForeColor = StaticInfo.ctrLabelForeColor;
            //lblStatusWorkingForm.ForeColor = StaticInfo.ctrLabelForeColor;

            //this.MainStatusStrip.BackColor = System.Drawing.SystemColors.Control;
            //this.MainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            //this.RecentButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            //this.LeftButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));

            //if (!string.IsNullOrEmpty(StaticInfo.ctrBackColor))
            //{
            //    //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(StaticInfo.ctrBackColor);
            //    //this.RecentBox.BackColor = col; this.RecentPanel.BackColor = col; this.BackColor = col;                
            //}

            xMessageBox = new ControlLibrary.MessageBox();
            objLoginDetail = new LoginDetail();
            popup.Click += Popup_Click;
            StaticInfo.LoadControl += Control_LoadControl;
            StaticInfo.LoadControl2 += Control_LoadControl2;
            StaticInfo.LoadControl3 += Control_LoadControl3;
            StaticInfo.LoadChildControl += ChildControl_LoadControl;
            StaticInfo.LoadRptReport += LoadReport_LoadRptReport;

            //this.btnPO.Click += new System.EventHandler(this.btnPO_Click);
            //this.btnGRN.Click += new System.EventHandler(this.btnGRN_Click);
            //this.btnPR.Click += new System.EventHandler(this.btnPR_Click);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);

            AutoHidePanel.Click += AutoHidePanel_Click;
            AutoHideManu.Click += AutoHideManu_Click;
            //btnPurchaseOrder.Click += new EventHandler(btnLeftButtion_Click);
            //btnPurchaseOrder.MouseClick += btnPurchaseOrder_MouseClick;

        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;

        }
        private void Popup_Click(object sender, EventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.Notifications", "Purchase", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
            popup.Hide();
        }
        void AutoHideManu_Click(object sender, EventArgs e)
        {
            if (ManuIsClose)
            {
                ManuIsClose = false;
                MainManuPanel.Height = 47;
            }
            else
            {
                ManuIsClose = true;
                MainManuPanel.Height = 25;
            }
        }
        void AutoHidePanel_Click(object sender, EventArgs e)
        {
            if (PanelIsClose)
            {
                PanelIsClose = false;
                LeftButtonPanel.Width = 170;
            }
            else
            {
                PanelIsClose = true;
                LeftButtonPanel.Width = 40;
            }
        }

        //private Thread thread2 = null;        
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (System32.StaticInfo.CanApplicationExit)
                {
                    if (xMessageBox.Show("Do you really want to close Application....?", "Application Exit..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BaseControl.LogOff(); Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }
        bool isLoad = false;
        //Thread AfterFiveMiniInvokeMethod;
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSessionExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        void UpdateLoginActivity()
        {
            if (StaticInfo.UserLoginDetailID > 0)
            {
                //-----------------------UpdateUserLoginDetail--------------------------//
                DateTime updatedDatetime = Convert.ToDateTime(System32.EncryptDecrypt.Decrypt(dbClass.obj.getUpdatedTime(StaticInfo.UserLoginDetailID)));
                //----------------------------------------------------------------------//
                DateTime UserEndtime = StaticInfo.UserLoginEndTime.AddMinutes(-15);
                if ((UserEndtime.TimeOfDay <= DateTime.Now.TimeOfDay) && (DateTime.Now.TimeOfDay < StaticInfo.UserLoginEndTime.TimeOfDay))
                {
                    //TimeSpan edt = StaticInfo.UserLoginEndTime.AddMinutes(-15).TimeOfDay;
                    TimeSpan diff = StaticInfo.UserLoginEndTime.TimeOfDay - DateTime.Now.TimeOfDay;
                    if (diff.Minutes <= 15)
                    {
                        this.lblStatusLoginRemainingTime.Text = "Your session will be expire within " + diff.Minutes + " Minutes";
                        this.lblStatusLoginRemainingTime.Visible = true;
                    }
                    //DateTime edt1 = edt.AddMinutes(diff.Minutes);
                    //xMessageBox.Show("Your session will be expire within " + edt1.Minute + " Minutes");
                }
                ////----------------------------------------------------------------------//
                else if (StaticInfo.UserLoginEndTime.TimeOfDay <= DateTime.Now.TimeOfDay)
                {
                    //StaticInfo.SystemLock = true;
                    //timer1.Enabled = false;
                    //timer1.Stop();
                    ////--------------------------
                    //timer2.Enabled = true;
                    //timer2.Start();
                }
                //----------------------------------------------------------------------//
                else if (updatedDatetime > DateTime.Now)
                {
                    StaticInfo.SystemLock = true;
                    xMessageBox.Show("System time is not correct ......");
                    Environment.Exit(0);
                }
                else
                {
                    string UpdateTime = System32.EncryptDecrypt.Encrypt(Convert.ToString(DateTime.Now));
                    StaticInfo.UserLoginDetailID = dbClass.obj.UpdateUserLoginDetail(StaticInfo.userid, UpdateTime);
                }
                //----------------------------------------------------------------------//                
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLoginActivity();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.LeftButtonPanel.Visible = false;
            this.MainManuPanel.Visible = false;

            this.LockPanel.Width = this.Width;
            this.LockPanel.Height = this.Height;
            this.LockPanel.Top = 0;
            this.LockPanel.Left = 0;
            this.Controls.Add(this.LockPanel);

            timer2.Enabled = false;
            timer2.Stop();
        }

        private void LogoPanel_Paint(object sender, PaintEventArgs e)
        {
            //show Dashboard
        }

        private void LbtnPurchaeOrder_MouseHover(object sender, EventArgs e)
        {
            LbtnPurchaeOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnPurchaeOrder_MouseLeave(object sender, EventArgs e)
        {
            LbtnPurchaeOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }
        private void LbtnVendorBill_MouseHover(object sender, EventArgs e)
        {
            LbtnVendorBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnVendorBill_MouseLeave(object sender, EventArgs e)
        {
            LbtnVendorBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnVendorPayment_MouseHover(object sender, EventArgs e)
        {
            LbtnVendorPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnVendorPayment_MouseLeave(object sender, EventArgs e)
        {
            LbtnVendorPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnWorkOrder_MouseHover(object sender, EventArgs e)
        {
            LbtnWorkOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnWorkOrder_MouseLeave(object sender, EventArgs e)
        {
            LbtnWorkOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnCustomerInvoice_MouseHover(object sender, EventArgs e)
        {
            LbtnCustomerInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnCustomerInvoice_MouseLeave(object sender, EventArgs e)
        {
            LbtnCustomerInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnWorkOrderNegate_MouseHover(object sender, EventArgs e)
        {
            LbtnWorkOrderNegate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnWorkOrderNegate_MouseLeave(object sender, EventArgs e)
        {
            LbtnWorkOrderNegate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnCustomerPayment_MouseHover(object sender, EventArgs e)
        {
            LbtnCustomerPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnCustomerPayment_MouseLeave(object sender, EventArgs e)
        {
            LbtnCustomerPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnWarrantyClaim_MouseHover(object sender, EventArgs e)
        {
            LbtnWarrantyClaim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnWarrantyClaim_MouseLeave(object sender, EventArgs e)
        {
            LbtnWarrantyClaim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnInventoryStock_MouseHover(object sender, EventArgs e)
        {
            LbtnInventoryStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnInventoryStock_MouseLeave(object sender, EventArgs e)
        {
            LbtnInventoryStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }

        private void LbtnReports_MouseHover(object sender, EventArgs e)
        {
            LbtnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
        }

        private void LbtnReports_MouseLeave(object sender, EventArgs e)
        {
            LbtnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        }
        private void btnPurchaseOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase Order List", 0);
        }
        private void btnVendorBill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendorBillList", "Vendor Bill List", 0);
        }

        private void btnVendorPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Vendor Payment List", 0);
        }

        private void btnWorkOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrWorkOrderList", "WorkOrder List", 0);
        }

        private void btnCustomerInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCustomerReceipt", "Customer Invoice", 0);
        }

        private void btnWorkOrderNegate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrWorkOrderNegateList", "WorkOrder Negate List", 0);
        }

        private void btnCustomerPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrCustomerPaymentList", "Customer Payment List", 0);
        }

        private void btnWarrantyClaim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //StaticInfo.LoadToControl("AppControls.ctrWarrantyClaimList", "Warranty Claim List", 0);
        }

        private void btnInventoryStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemList", "Item Details", 0);
        }

        private void btnReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrReportsMenu", "Reports Menu", 0);
        }


        private void btnSale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool AccessSales = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '008'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessSales = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessSales)
                StaticInfo.LoadToControl("AppControls.ctrWorkOrderList", "WorkOrder List", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Sales.");
            }
        }

        private void btnPurchase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

        private void btnCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCustomer", "Customers", 0);
        }

        private void btnVendor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendor", "Vendors", 0);
        }

        private void btnDailyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Analysis", 0);
        }
        Form fm = null;
        private void btnReports_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrReportsList", "Reports", 0);
            //FormCollection fc = Application.OpenForms;
            //bool _Openstate = false;
            //foreach (Form frm in fc)
            //{
            //    if (frm.Text == "Reports")
            //    {
            //        frm.Focus();
            //        _Openstate = true;
            //        break;
            //    }
            //}
            //if (_Openstate == false)
            //{
            //    ctrReports ctr = new ctrReports();
            //    ctr.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //    ctr.Show();
            //}

        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Payments", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemList", "Inventory", 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bool AccessSales = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '008'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessSales = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessSales)
                StaticInfo.LoadToControl("AppControls.ctrWorkOrderList", "WorkOrder List", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Sales.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrItemList", "Inventory", 0);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCustomer", "Customers", 0);

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendor", "Vendors", 0);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrDailySaleList", "Daily Analysis", 0);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrVendorPaymentList", "Payments", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AutoVaultEss.ctrReportsList", "Reports", 0);
        }

        private void btnSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://totaltiressolutions.com/login");
            Process.Start(sInfo);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://totaltiressolutions.com/login");
            Process.Start(sInfo);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            if (!isLoad)
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.LoadMenu();
                int width = this.Width;
                int Height = this.Height;
                //--------------------------------------------------------------------------------//
                //Thread oThread = new Thread(new ThreadStart(InvokeMethod));
                //oThread.Start();
                //oThread.IsBackground = true;

                //System.Threading.Tasks.Task.Factory.StartNew(() => { this.Invoke(new Action(() => InvokeMethod())); });
                //Task.Factory.StartNew(() => Thread.Sleep(5000)).ContinueWith((t) => { InvokeMethod(); }, TaskScheduler.FromCurrentSynchronizationContext());

                //Thread TypingThread = new Thread(delegate() { UpdateLoginActivity(); });
                //TypingThread.Start();

                //thread2 = new Thread(new ThreadStart(UpdateLoginActivity));
                //thread2.Start();


                //--------------------------------------------------------------------------------//                

                //this.LoadLeftButtons();
                try
                {
                    Controls.OfType<MdiClient>().FirstOrDefault().BackColor = StaticInfo.ctrBackColor;
                }
                catch { }
                try
                {
                    //StaticInfo.MainCurrencySign = (new CultureInfo(CultureInfo.CurrentCulture.Name, true).NumberFormat.CurrencySymbol);
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureInfo.CurrentCulture.Name, true);

                    string CurrencySign = "en-US";
                    if (!string.IsNullOrEmpty(StaticInfo.MainCurrencySign))
                        CurrencySign = StaticInfo.MainCurrencySign;
                    var culture = new CultureInfo(CurrencySign);
                    culture.NumberFormat.CurrencyPositivePattern = 2;
                    //Thread.CurrentThread.CurrentCulture = culture;

                }
                catch { }
                try
                {
                    //ctrDashBoard POSDashBoard = new ctrDashBoard();
                    //POSDashBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //POSDashBoard.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    //POSDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
                    ////POSDashBoard.Location = new System.Drawing.Point(126, 32);
                    //POSDashBoard.Name = "ctrDashBoard";
                    ////POSDashBoard.Size = new System.Drawing.Size(866, 679);


                    //////POSDashBoard.LogOffPicBoxClick += new EventHandler(TSLMenuItem_Clicked);
                    //////POSDashBoard.ExitPicBoxClick += new EventHandler(TSXMenuItem_Clicked);

                    //////POSDashBoard.DbButton1.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton2.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton3.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton4.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton5.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton6.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton7.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton8.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton9.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton10.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton11.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton12.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton13.bXClick += new EventHandler(sideBarButton1_Click);
                    //////POSDashBoard.DbButton14.bXClick += new EventHandler(sideBarButton1_Click);

                    //POSDashBoard.Width = this.Width - LeftButtonPanel.Width - 25;
                    //POSDashBoard.Height = this.Height - MainMenuStrip.Height - MainStatusStrip.Height - 45;

                    ////////POSDashBoard.Left = tableLayoutPanel1.Right;
                    ////////POSDashBoard.Top = MainMenuStrip.Bottom;

                    ////////this.Controls.Add(POSDashBoard);

                    //Form frmCtr = new Form();
                    //frmCtr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    ////frmCtr.Dock = System.Windows.Forms.DockStyle.Fill;
                    //frmCtr.Height = POSDashBoard.Height;// -50;
                    //frmCtr.Width = POSDashBoard.Width;// -50;
                    //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    ////frmCtr.Top = 32;
                    ////frmCtr.Left = 127;

                    ////frmCtr.Top = (this.Height - MainMenuStrip.Height - MainStatusStrip.Height) - 5;
                    ////frmCtr.Left = (this.Left + LeftButtonPanel.Width) + 5;

                    ////////frmCtr.Top = ((this.Height - frmCtr.Height) / 2) - 45;
                    ////////frmCtr.Left = ((this.Width - frmCtr.Width) / 2) + 25;
                    ////////frmCtr.Left = tableLayoutPanel1.Right;
                    ////////frmCtr.Top = MainMenuStrip.Bottom;
                    //frmCtr.Opacity = 0.85D;
                    //frmCtr.MdiParent = this;
                    //frmCtr.Controls.Add(POSDashBoard);
                    //frmCtr.Show();


                    //frmDashBoard objDashBoard = new frmDashBoard();                    
                    //objDashBoard.Width = this.Width - LeftButtonPanel.Width - 25;
                    //objDashBoard.Height = this.Height - MainMenuStrip.Height - MainStatusStrip.Height - 45;
                    //objDashBoard.MdiParent = this;                    
                    //objDashBoard.Show();

                    timer1.Interval = (1000 * 60 * 1);
                    timer1.Enabled = true;
                    timer1.Start();

                }
                catch { }
                isLoad = true;
            }
        }

        private void notificationCheck_Tick(object sender, EventArgs e)
        {
            //DataTable dt = dbClass.obj.GetNotifications();
            //int a = 1;
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            popup.TitleColor = Color.DarkRed;
            //            popup.HeaderColor = Color.DarkRed;
            //            popup.Size = new Size(400, 100);
            //            //popup.AnimationDuration = 5000;
            //            //popup.AnimationInterval = 5000;
            //            popup.TitleText = "Warning (!)";
            //            popup.TitleFont = new Font("Calibri", 18.0F, System.Drawing.FontStyle.Bold);
            //            popup.TitlePadding= new Padding(10, 0, 10, 0);
            //            popup.ContentText = ""+a+" products in your inventory are less then Re-Order level."+Environment.NewLine+ "Click for more details";
            //            popup.ContentPadding = new Padding(10,0,10,0);
            //            popup.ContentFont = new Font("Calibri", 12.0F, System.Drawing.FontStyle.Regular);
            //            popup.Popup();// show 
            //            a++;
            //            dbClass.obj.UpdateDisplayedNotifications(Convert.ToInt32(dr["ID"]));
            //        }
            //    }
            //}
        }






        //private void LoadLeftButtons()
        //{
        //    //LeftButtonsPOS();
        //}

        //void LeftButtonsPOS()
        //{
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnPurchaseOrder = new DashBoardButton();
        //    btnPurchaseOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        //    btnPurchaseOrder.headingColor = System.Drawing.Color.White;
        //    btnPurchaseOrder.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnPurchaseOrder.Size = new System.Drawing.Size(110, 36);
        //    btnPurchaseOrder.Location = new System.Drawing.Point(3, 30);
        //    btnPurchaseOrder.bXCode = "0501";
        //    btnPurchaseOrder.headingText = "Purchase Order";
        //    btnPurchaseOrder.Name = "btnPurchaseOrder";
        //    btnPurchaseOrder.TabIndex = 0;
        //    btnPurchaseOrder.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnPurchaseOrder);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnPurchase = new DashBoardButton();
        //    btnPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(155)))), ((int)(((byte)(30)))));
        //    btnPurchase.headingColor = System.Drawing.Color.White;
        //    btnPurchase.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnPurchase.Size = new System.Drawing.Size(110, 36);
        //    btnPurchase.Location = new System.Drawing.Point(3, 70);
        //    btnPurchase.Name = "btnPurchase";
        //    btnPurchase.Tag = "0502";
        //    btnPurchase.headingText = "Purchase";
        //    btnPurchase.TabIndex = 1;
        //    btnPurchase.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnPurchase);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnPurchaseReturn = new DashBoardButton();
        //    btnPurchaseReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        //    btnPurchaseReturn.headingColor = System.Drawing.Color.White;
        //    btnPurchaseReturn.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnPurchaseReturn.Location = new System.Drawing.Point(3, 110);
        //    btnPurchaseReturn.Name = "btnPurchaseReturn";
        //    btnPurchaseReturn.Size = new System.Drawing.Size(110, 36);
        //    btnPurchaseReturn.TabIndex = 2;
        //    btnPurchaseReturn.Tag = "0503";
        //    btnPurchaseReturn.headingText = "Purchase Return";
        //    btnPurchaseReturn.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnPurchaseReturn);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnSale = new DashBoardButton();
        //    btnSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
        //    btnSale.headingColor = System.Drawing.Color.White;
        //    btnSale.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnSale.Location = new System.Drawing.Point(3, 150);
        //    btnSale.Name = "btnSale";
        //    btnSale.Size = new System.Drawing.Size(110, 36);
        //    btnSale.TabIndex = 3;
        //    btnSale.Tag = "0601";
        //    btnSale.headingText = "Sale";
        //    btnSale.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnSale);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnSaleReturn = new DashBoardButton();
        //    btnSaleReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(173)))));
        //    btnSaleReturn.headingColor = System.Drawing.Color.White;
        //    btnSaleReturn.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnSaleReturn.Location = new System.Drawing.Point(3, 190);
        //    btnSaleReturn.Name = "btnSaleReturn";
        //    btnSaleReturn.Size = new System.Drawing.Size(110, 36);
        //    btnSaleReturn.TabIndex = 4;
        //    btnSaleReturn.Tag = "0602";
        //    btnSaleReturn.headingText = "Sale Return";
        //    btnSaleReturn.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnSaleReturn);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnCashReceipt = new DashBoardButton();
        //    btnCashReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123)))));
        //    btnCashReceipt.headingColor = System.Drawing.Color.White;
        //    btnCashReceipt.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnCashReceipt.Location = new System.Drawing.Point(3, 230);
        //    btnCashReceipt.Name = "btnCashReceipt";
        //    btnCashReceipt.Size = new System.Drawing.Size(110, 36);
        //    btnCashReceipt.TabIndex = 5;
        //    btnCashReceipt.Tag = "0404";
        //    btnCashReceipt.headingText = "Cash Receipt";
        //    btnCashReceipt.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnCashReceipt);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnCashPayment = new DashBoardButton();
        //    btnCashPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(163)))), ((int)(((byte)(156)))));
        //    btnCashPayment.headingColor = System.Drawing.Color.White;
        //    btnCashPayment.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnCashPayment.Location = new System.Drawing.Point(3, 270);
        //    btnCashPayment.Name = "btnCashPayment";
        //    btnCashPayment.Size = new System.Drawing.Size(110, 36);
        //    btnCashPayment.TabIndex = 6;
        //    btnCashPayment.Tag = "0403";
        //    btnCashPayment.headingText = "Cash Payment";
        //    btnCashPayment.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnCashPayment);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnBankReceipt = new DashBoardButton();
        //    btnBankReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(169)))), ((int)(((byte)(68)))));
        //    btnBankReceipt.headingColor = System.Drawing.Color.White;
        //    btnBankReceipt.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnBankReceipt.Location = new System.Drawing.Point(3, 310);
        //    btnBankReceipt.Name = "btnBankReceipt";
        //    btnBankReceipt.Size = new System.Drawing.Size(110, 36);
        //    btnBankReceipt.TabIndex = 7;
        //    btnBankReceipt.Tag = "0406";
        //    btnBankReceipt.headingText = "Bank Receipt";
        //    btnBankReceipt.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnBankReceipt);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnBankPayment = new DashBoardButton();
        //    btnBankPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(155)))), ((int)(((byte)(30)))));
        //    btnBankPayment.headingColor = System.Drawing.Color.White;
        //    btnBankPayment.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnBankPayment.Location = new System.Drawing.Point(3, 350);
        //    btnBankPayment.Name = "btnBankPayment";
        //    btnBankPayment.Size = new System.Drawing.Size(110, 36);
        //    btnBankPayment.TabIndex = 8;
        //    btnBankPayment.Tag = "0405";
        //    btnBankPayment.headingText = "Bank Payment";
        //    btnBankPayment.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnBankPayment);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnGeneralJournal = new DashBoardButton();
        //    btnGeneralJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        //    btnGeneralJournal.headingColor = System.Drawing.Color.White;
        //    btnGeneralJournal.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnGeneralJournal.Location = new System.Drawing.Point(3, 390);
        //    btnGeneralJournal.Name = "btnGeneralJournal";
        //    btnGeneralJournal.Size = new System.Drawing.Size(110, 36);
        //    btnGeneralJournal.TabIndex = 9;
        //    btnGeneralJournal.Tag = "0407";
        //    btnGeneralJournal.headingText = "General journal";
        //    btnGeneralJournal.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnGeneralJournal);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnDailyCash = new DashBoardButton();
        //    btnDailyCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(155)))), ((int)(((byte)(30)))));
        //    btnDailyCash.headingColor = System.Drawing.Color.White;
        //    btnDailyCash.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnDailyCash.Location = new System.Drawing.Point(3, 430);
        //    btnDailyCash.Name = "btnDailyCash";
        //    btnDailyCash.Size = new System.Drawing.Size(110, 36);
        //    btnDailyCash.TabIndex = 10;
        //    btnDailyCash.Tag = "0408";
        //    btnDailyCash.headingText = "Daily Cash";
        //    btnDailyCash.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnDailyCash);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnVendorLedger = new DashBoardButton();
        //    btnVendorLedger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        //    btnVendorLedger.headingColor = System.Drawing.Color.White;
        //    btnVendorLedger.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnVendorLedger.Location = new System.Drawing.Point(3, 470);
        //    btnVendorLedger.Name = "btnVendorLedger";
        //    btnVendorLedger.Size = new System.Drawing.Size(110, 36);
        //    btnVendorLedger.TabIndex = 11;
        //    btnVendorLedger.Tag = "180302";
        //    btnVendorLedger.headingText = "Vendor Ledger";
        //    btnVendorLedger.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnVendorLedger);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnCustomerLedger = new DashBoardButton();
        //    btnCustomerLedger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
        //    btnCustomerLedger.headingColor = System.Drawing.Color.White;
        //    btnCustomerLedger.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnCustomerLedger.Location = new System.Drawing.Point(3, 510);
        //    btnCustomerLedger.Name = "btnCustomerLedger";
        //    btnCustomerLedger.Size = new System.Drawing.Size(110, 36);
        //    btnCustomerLedger.TabIndex = 12;
        //    btnCustomerLedger.Tag = "180301";
        //    btnCustomerLedger.headingText = "Customer Ledger";
        //    btnCustomerLedger.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnCustomerLedger);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnEmployeeLedger = new DashBoardButton();
        //    btnEmployeeLedger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(173)))));
        //    btnEmployeeLedger.headingColor = System.Drawing.Color.White;
        //    btnEmployeeLedger.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnEmployeeLedger.Location = new System.Drawing.Point(3, 550);
        //    btnEmployeeLedger.Name = "btnEmployeeLedger";
        //    btnEmployeeLedger.Size = new System.Drawing.Size(110, 36);
        //    btnEmployeeLedger.TabIndex = 13;
        //    btnEmployeeLedger.Tag = "180303";
        //    btnEmployeeLedger.headingText = "Employee Ledger";
        //    btnEmployeeLedger.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnEmployeeLedger);
        //    //-----------------------------------------------------------------
        //    DashBoardButton btnAccountLedger = new DashBoardButton();
        //    btnAccountLedger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123)))));
        //    btnAccountLedger.headingColor = System.Drawing.Color.White;
        //    btnAccountLedger.bXPic = global::AutoVaultEss.Properties.Resources.Warehouseicon;
        //    btnAccountLedger.Location = new System.Drawing.Point(3, 590);
        //    btnAccountLedger.Name = "btnAccountLedger";
        //    btnAccountLedger.Size = new System.Drawing.Size(110, 36);
        //    btnAccountLedger.TabIndex = 14;
        //    btnAccountLedger.Tag = "180101";
        //    btnAccountLedger.headingText = "Account Ledger";
        //    btnAccountLedger.Click += new EventHandler(btnLeftButtion_Click);
        //    this.LeftButtonPanel.Controls.Add(btnAccountLedger);
        //    //-----------------------------------------------------------------

        //}
        //void LeftButtonsBeverageDistributor()
        //{

        //}
        //private void sideBarButton1_Click(object sender, EventArgs e)
        //{
        //    btnRecent_Click(sender, e);
        //}

        //private void ChangeBackGround()
        //{
        //    MdiClient chld;
        //    foreach (Control ctrl in this.Controls)
        //    {
        //        try
        //        {
        //            chld = (MdiClient)ctrl;
        //        }
        //        catch { }
        //    }
        //}

    }


}
