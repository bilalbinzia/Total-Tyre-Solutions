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
using DBModule;
using System32;
using System.Globalization;
using RptModule;
using Tulpep.NotificationWindow;

namespace AppControls
{
    public partial class ctrCustomerReceipt : BaseControl
    {
        Int32 CustomerID = 0;
        Int32 WorkOrderID = 0;
        Int32 ReceiptID = 0;
        decimal WOAmount = 0;
        decimal TotalWOAmount = 0;
        decimal CreditAvail = 0;
        decimal CusCredit = 0;
        decimal SelectCusCredit = 0;
        decimal AvailableDeposit = 0;
        decimal CreditLimit = 0;
        decimal AvailableCredit = 0;
        decimal SelectAvailableCredit = 0;
        bool InvoiceForCredit = false;
        bool EditInvoice = false;
        bool MultiWorkOrders = false;
        bool Focus = true;
        bool OverrideCreditLimit = false;
        string InvoiceIDs = "";
        decimal ExtraAmount = 0;
        DataTable TempPayment = new DataTable();
        Decimal PastDue = 0;
        bool AllowPastDue = false;
        PopupNotifier popup = new PopupNotifier();

        public ctrCustomerReceipt()
        {
            InvoiceForCredit = true;
            EditInvoice = false;
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrCustomerReceipt(int WOID, int CustID)
        {
            InvoiceForCredit = false;
            InitializeComponent();
            InitializeComponent1();

            this.CustomerID = CustID;
            this.WorkOrderID = WOID;
        }
        public ctrCustomerReceipt(string InvoiceIDs, int CustID, decimal Amount, DataTable dtPayment)
        {
            InvoiceForCredit = true;
            EditInvoice = false;
            InitializeComponent();
            InitializeComponent1();

            this.CustomerID = CustID;
            //this.ReceiptID = RecID;
            this.WOAmount = Amount;
            this.InvoiceIDs = InvoiceIDs;
            this.TempPayment = dtPayment;
            //this.ExtraAmount = ExtraAmount;
            this.MultiWorkOrders = true;
        }
        void InitializeComponent1()
        {
            this.Load += ctrCustomerReceipt_Load;
            popup.Click += Popup_OnClick;
            btnCustomerList.Click += btnCustomerList_Click;
            btnWorkOrderList.Click += btnWorkOrderList_Click;
            btnCustomerTerms.Click += btnCustomerTerms_Click;
            btnAdminRights.Click += btnAdminRights_Click;
            btnSubmit.Click += btnSubmit_Click;

            btnClearCreditBalance.Click += btnClear_Click;
            btnClearChgOnAccount.Click += btnClear_Click;
            btnClearPayByCash.Click += btnClear_Click;
            btnClearPayByCheck.Click += btnClear_Click;
            btnClearPayByDeposit.Click += btnClear_Click;
            btnClearPayByVISA.Click += btnClear_Click;
            btnClearPayByMC.Click += btnClear_Click;
            btnClearPayByAMEX.Click += btnClear_Click;
            btnClearPayByATM.Click += btnClear_Click;
            btnClearPayByGY.Click += btnClear_Click;
            btnClearPayByDSCVR.Click += btnClear_Click;

            //txtChgOnAccount.KeyDown += textBox_KeyDown;
            //txtPayByCash.KeyDown += textBox_KeyDown;
            //txtPayByCheck.KeyDown += textBox_KeyDown;
            //txtPayByDeposit.KeyDown += textBox_KeyDown;
            //txtPayByVISA.KeyDown += textBox_KeyDown;
            //txtPayByMC.KeyDown += textBox_KeyDown;
            //txtPayByAMEX.KeyDown += textBox_KeyDown;
            //txtPayByATM.KeyDown += textBox_KeyDown;
            //txtPayByGY.KeyDown += textBox_KeyDown;
            //txtPayByDSCVR.KeyDown += textBox_KeyDown;

            btnCreditBalance.Click += btnClick_Click;
            btnChgOnAccount.Click += btnClick_Click;
            btnPayByCash.Click += btnClick_Click;
            btnPayByCheck.Click += btnClick_Click;
            btnPayByDeposit.Click += btnClick_Click;
            btnPayByVISA.Click += btnClick_Click;
            btnPayByMC.Click += btnClick_Click;
            btnPayByAMEX.Click += btnClick_Click;
            btnPayByATM.Click += btnClick_Click;
            btnPayByGY.Click += btnClick_Click;
            btnPayByDSCVR.Click += btnClick_Click;

            txtCreditBalance.LostFocus += textBox_LostFocus;
            txtChgOnAccount.LostFocus += textBox_LostFocus;
            txtPayByCash.LostFocus += textBox_LostFocus;
            txtPayByCheck.LostFocus += textBox_LostFocus;
            txtPayByDeposit.LostFocus += textBox_LostFocus;
            txtPayByVISA.LostFocus += textBox_LostFocus;
            txtPayByMC.LostFocus += textBox_LostFocus;
            txtPayByAMEX.LostFocus += textBox_LostFocus;
            txtPayByATM.LostFocus += textBox_LostFocus;
            txtPayByGY.LostFocus += textBox_LostFocus;
            txtPayByDSCVR.LostFocus += textBox_LostFocus;
        }
        private void Popup_OnClick(object sender, EventArgs e)
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
        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if (Focus) { }
            else
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                string senderText = ((TextBox)sender).Name.ToString().Trim();
                string txtName = senderText.Substring(3, senderText.Length - 3);

                if (txtName == "CreditBalance")
                {
                    if (txtCreditBalance.Text != "$0.00")
                    {
                        decimal creditBalance = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                                          NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                        //decimal creditBalance = Convert.ToDecimal(txtCreditBalance.Text.Replace("$", ""));
                        CusCredit = CusCredit - SelectCusCredit;
                        SelectCusCredit = 0;
                        if (creditBalance > (-1 * CusCredit))
                        {
                            txtCreditBalance.Text = "$0.00";
                            curRow["CusCredit"] = 0;
                            txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit;
                            xMessageBox.Show("Not Enough Credit Balance...");
                        }
                        else
                        {
                            if (CusCredit != 0)
                            {
                                decimal _value1 = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                                          NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                                //decimal _value1 = Convert.ToDecimal(txtCreditBalance.Text.Replace("$", ""));
                                if ((-1 * CusCredit) >= _value1)
                                {
                                    curRow["CusCredit"] = _value1.ToString();
                                    txtCreditBalance.Text = "$" + _value1;
                                    CusCredit = CusCredit + _value1;
                                    SelectCusCredit = _value1;
                                    txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit;
                                }
                            }
                        }
                    }
                }
                if (txtName == "ChgOnAccount")
                {
                    if (AllowPastDue || PastDue <= 0)
                    {
                        if (txtChgOnAccount.Text != "$0.00")
                        {
                            decimal ChgOnAcc = Convert.ToDecimal(txtChgOnAccount.Text.Replace("$", ""));
                            AvailableCredit = CreditLimit - CreditAvail;
                            if (OverrideCreditLimit)
                            {
                                decimal _value1 = Convert.ToDecimal(txtChgOnAccount.Text.Replace("$", ""));
                                curRow["ChgOnAccount"] = _value1.ToString();
                                txtChgOnAccount.Text = "$" + _value1;
                                AvailableCredit = AvailableCredit - _value1;
                                SelectAvailableCredit = _value1;
                                txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                            }
                            else
                            {
                                if (ChgOnAcc > AvailableCredit)
                                {
                                    txtChgOnAccount.Text = "$0.00";
                                    curRow["ChgOnAccount"] = 0;
                                    AvailableCredit = CreditLimit - CreditAvail;
                                    txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                                    xMessageBox.Show("Not Enough Credit...");
                                }
                                else
                                {
                                    if (AvailableCredit >= 0)
                                    {
                                        decimal _value1 = Convert.ToDecimal(txtChgOnAccount.Text.Replace("$", ""));
                                        if (AvailableCredit >= _value1)
                                        {
                                            curRow["ChgOnAccount"] = _value1.ToString();
                                            txtChgOnAccount.Text = "$" + _value1;
                                            AvailableCredit = AvailableCredit - _value1;
                                            SelectAvailableCredit = _value1;
                                            txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        xMessageBox.Show("Sorry! You can't ChgOnAccount when Past Due.");
                        txtChgOnAccount.Text = "$0.00";
                        curRow["ChgOnAccount"] = 0;
                    }
                }
                CalculateTotalAmount();
            }
        }
        void ClearControls()
        {
            txtChgOnAccount.Text = "$0.00";
            txtPayByCash.Text = "$0.00";
            txtPayByCheck.Text = "$0.00";
            txtPayByDeposit.Text = "$0.00";
            txtPayByVISA.Text = "$0.00";
            txtPayByMC.Text = "$0.00";
            txtPayByAMEX.Text = "$0.00";
            txtPayByATM.Text = "$0.00";
            txtPayByGY.Text = "$0.00";
            txtPayByDSCVR.Text = "$0.00";

            txtInvoiceBalance.Text = "$0.00";
            txtTotalAmount.Text = "$0.00";

            WOAmount = 0;
            TotalWOAmount = 0;
            AvailableDeposit = 0;
            CreditLimit = 0;
            InvoiceForCredit = false;

            btnPayByCheck.Enabled = true;
            txtCheckNo.Enabled = true;
            txtDriversLic.Enabled = true;
        }
        private void btnCustomerTerms_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrCustomer", "Customer Details", 0);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbAdminRights.Text.ToString().Trim()))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text.ToString().Trim()))
                    {
                        //ErrorProvider.SetError(txtPassword.Text, "");
                        this.Cursor = Cursors.WaitCursor;

                        string userName = cmbAdminRights.Text.ToLower().ToString().Trim();
                        string password = txtPassword.Text.ToLower().ToString().Trim();
                        userName = System32.EncryptDecrypt.Encrypt(userName);
                        password = System32.EncryptDecrypt.Encrypt(password);

                        dbClass.obj.GetLoginAuthonticatioin(objDataSet.UserLogin, userName);
                        if (objDataSet.UserLogin.Rows.Count > 0)
                        {
                            if (!password.Equals(Convert.ToString(objDataSet.UserLogin.Rows[0]["password"])))
                            {
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                if (Convert.ToBoolean(objDataSet.UserLogin.Rows[0]["Active"]))
                                {
                                    DataTable dt = new DataTable();
                                    dt.Columns.Add("WOID", typeof(string));
                                    dt.Columns.Add("InvoiceNo", typeof(decimal));
                                    dt.Columns.Add("TrnsDate", typeof(DateTime));
                                    dt.Columns.Add("TrnsNotes", typeof(string));

                                    dt.Columns.Add("ChgOnAccount", typeof(decimal));
                                    dt.Columns.Add("PayByCash", typeof(decimal));
                                    dt.Columns.Add("PaybyCheck", typeof(decimal));
                                    dt.Columns.Add("CheckNo", typeof(string));
                                    dt.Columns.Add("LicNo", typeof(string));
                                    dt.Columns.Add("PayByDeposit", typeof(decimal));
                                    dt.Columns.Add("PayByVisa", typeof(decimal));
                                    dt.Columns.Add("PayByMC", typeof(decimal));
                                    dt.Columns.Add("PayByAMEX", typeof(decimal));
                                    dt.Columns.Add("PayByATM", typeof(decimal));
                                    dt.Columns.Add("PayByGY", typeof(decimal));
                                    dt.Columns.Add("PayByDSCVR", typeof(decimal));

                                    dt.Columns.Add("PaidAmount", typeof(decimal));
                                    dt.Columns.Add("TotalReceivedAmount", typeof(decimal));
                                    dt.Columns.Add("Active", typeof(bool));
                                    dt.Columns.Add("AddDate", typeof(DateTime));
                                    dt.Columns.Add("AddUserID", typeof(string));
                                    dt.Columns.Add("ModifyUserID", typeof(string));
                                    dt.Columns.Add("ModifyDate", typeof(DateTime));
                                    dt.Columns.Add("Comments", typeof(string));
                                    dt.Columns.Add("IsLocked", typeof(bool));
                                    dt.Columns.Add("DocNo", typeof(string));
                                    dt.Columns.Add("Remarks", typeof(string));
                                    dt.Columns.Add("CompanyID", typeof(string));
                                    dt.Columns.Add("WarehouseID", typeof(string));
                                    dt.Columns.Add("StoreID", typeof(string));

                                    DataRow dtrow = dt.NewRow();
                                    dtrow["WOID"] = this.WorkOrderID;
                                    dtrow["InvoiceNo"] = Convert.ToDecimal(txtInvoiceNo.Text);
                                    dtrow["TrnsDate"] = DateTime.Now;
                                    dtrow["TrnsNotes"] = txtTrnsNotes.Text;

                                    dtrow["ChgOnAccount"] = Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                                    dtrow["PayByCash"] = Convert.ToDecimal(txtPayByCash.Text.Substring(1));
                                    dtrow["PaybyCheck"] = Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
                                    dtrow["CheckNo"] = txtCheckNo.Text;
                                    dtrow["LicNo"] = txtDriversLic.Text;
                                    dtrow["PayByDeposit"] = Convert.ToDecimal(txtPayByDeposit.Text);
                                    dtrow["PayByVisa"] = Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
                                    dtrow["PayByMC"] = Convert.ToDecimal(txtPayByMC.Text.Substring(1));
                                    dtrow["PayByAMEX"] = Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
                                    dtrow["PayByATM"] = Convert.ToDecimal(txtPayByATM.Text.Substring(1));
                                    dtrow["PayByGY"] = Convert.ToDecimal(txtPayByGY.Text.Substring(1));
                                    dtrow["PayByDSCVR"] = Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));

                                    dtrow["PaidAmount"] = this.WOAmount;
                                    dtrow["TotalReceivedAmount"] = this.WOAmount;
                                    dtrow["Active"] = 1;
                                    dtrow["AddDate"] = DateTime.Now;
                                    dtrow["AddUserID"] = StaticInfo.userid;
                                    dtrow["ModifyUserID"] = StaticInfo.userid;
                                    dtrow["ModifyDate"] = DateTime.Now;
                                    dtrow["Comments"] = "";
                                    dtrow["IsLocked"] = 0;
                                    dtrow["DocNo"] = this.DocNo;
                                    dtrow["Remarks"] = "";
                                    dtrow["companyid"] = StaticInfo.CompanyID;
                                    dtrow["warehouseid"] = StaticInfo.WarehouseID;
                                    dtrow["storeid"] = StaticInfo.StoreID;

                                    dt.Rows.Add(dtrow);
                                    bool status = dbClass.obj.AddCustomerPaymentByAdmin(dt, this.CustomerID);
                                    if (status == true)
                                    {
                                        CreditLimit = (WOAmount - TotalWOAmount) + 100;
                                        ShowControls();
                                        if (InvoiceForCredit == true)
                                        {
                                            btnChgOnAccount.Enabled = false;
                                            txtChgOnAccount.Enabled = false;
                                            //btnCreditBalance.Enabled = false;
                                            //txtCreditBalance.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        xMessageBox.Show("Admin is not Active .....");
                                    }
                                    this.Cursor = Cursors.Default;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    xMessageBox.Show("Admin is not Active .....");
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            xMessageBox.Show("Invalid Username or password!");
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        txtPassword.Focus();
                    }
                }
                else
                {
                    cmbAdminRights.Focus();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                xMessageBox.Show(ex.Message.ToString());
            }
        }
        void ShowControls()
        {
            if (EditInvoice == false)
            {
                txtCreditBalance.Enabled = true;
                txtCusCredit.Enabled = true;

                cmbAdminRights.Visible = false;
                txtPassword.Visible = false;
                txtPassword.Text = "";
                btnSubmit.Visible = false;

                btnChgOnAccount.Enabled = true;
                //txtChgOnAccount.Enabled = true;
                txtChgOnAccount.Enabled = true;

                btnPayByCheck.Enabled = true;
                txtPayByCheck.Enabled = true;
                txtCheckNo.Enabled = true;
                txtDriversLic.Enabled = true;

                btnPayByDeposit.Enabled = true;
                txtPayByDeposit.Enabled = true;

                btnPayByVISA.Enabled = true;
                txtPayByVISA.Enabled = true;

                btnPayByMC.Enabled = true;
                txtPayByMC.Enabled = true;

                btnPayByAMEX.Enabled = true;
                txtPayByAMEX.Enabled = true;

                btnPayByATM.Enabled = true;
                txtPayByATM.Enabled = true;

                btnPayByGY.Enabled = true;
                txtPayByGY.Enabled = true;

                btnPayByDSCVR.Enabled = true;
                txtPayByDSCVR.Enabled = true;
            }
            else
            {
                //txtChgOnAccount.Enabled = true;
                txtChgOnAccount.Enabled = true;
                txtCreditBalance.Enabled = true;
                txtCusCredit.Enabled = true;
            }
        }
        void HideControls()
        {
            txtCreditBalance.Enabled = false;
            txtCusCredit.Enabled = false;
            cmbAdminRights.Visible = false;
            txtPassword.Visible = false;
            btnSubmit.Visible = false;

            btnChgOnAccount.Enabled = false;
            txtChgOnAccount.Enabled = false;

            btnPayByCheck.Enabled = false;
            txtPayByCheck.Enabled = false;
            txtCheckNo.Enabled = false;
            txtDriversLic.Enabled = false;

            //btnPayByVISA.Enabled = false;
            //txtPayByVISA.Enabled = false;

            //btnPayByMC.Enabled = false;
            //txtPayByMC.Enabled = false;

            //btnPayByAMEX.Enabled = false;
            //txtPayByAMEX.Enabled = false;

            //btnPayByATM.Enabled = false;
            //txtPayByATM.Enabled = false;

            //btnPayByGY.Enabled = false;
            //txtPayByGY.Enabled = false;

            //btnPayByDSCVR.Enabled = false;
            //txtPayByDSCVR.Enabled = false;
        }
        private void btnAdminRights_Click(object sender, EventArgs e)
        {
            if (rdoPaid.Checked == true)
            {
                if (this.CustomerID != 0 && this.WOAmount != 0 && WorkOrderID != 0)
                {
                    PaymentByAdmin();
                }
                else
                {
                    xMessageBox.Show("Work Order amount is empty...");
                }
            }
            //else if (rdoPaid.Checked == false && rdoCredit.Checked == true)
            //{
            //    PaymentByAdmin();
            //}
            else { }
        }
        bool Adminrights = false;
        void ctrCustomerReceipt_Load(object sender, EventArgs e)
        {
            bool ChangeDate = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '011'");
            if (row[0]["CanView"] != DBNull.Value)
                ChangeDate = Convert.ToBoolean(row[0]["CanView"]);

            if (ChangeDate)
                tpInvoiceDate.Enabled = true;
            else
                tpInvoiceDate.Enabled = false;

            //OverrideCreditLimit = false;
            DataRow[] row2 = StaticInfo.UserRights.Select("Code = '018'");
            if (row2[0]["CanView"] != DBNull.Value)
                OverrideCreditLimit = Convert.ToBoolean(row2[0]["CanView"]);

            WarehouseCopy.Checked = true;
            CustomerCpy.Checked = true;
            StoreCopy.Checked = true;

            cmbAdminRights.Visible = false;
            txtPassword.Visible = false;
            btnSubmit.Visible = false;
            if ((this.CustomerID > 0) && (this.WorkOrderID > 0))
            {
                DataTable dt = dbClass.obj.getReceiptByCustomerIDAndWorkOrderID(objDataSet.Tables["CustomerReceipt"], this.CustomerID, this.WorkOrderID);
                this.objBindingSource.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    Adminrights = false;
                    if (this.CustomerID > 0)
                        this.getCustomer(this.CustomerID);

                    if (this.WorkOrderID > 0)
                        this.getWorkOrder(this.WorkOrderID);
                    CalculateTotalAmount();
                }
                else
                {
                    Adminrights = true;
                    bindingNavigatorAddNewItem_Click(sender, e);

                    //bindingNavigatorEditItem_Click(sender, e);
                }
            }
            else
            {
                bindingNavigatorAddNewItem_Click(sender, e);
            }
        }
        void btnClick_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            //if (InvoiceForCredit == false)
            //{
            if (txtChgOnAccount.Text != "" || txtPayByCash.Text != "" || txtPayByCheck.Text != "" || txtPayByVISA.Text != "")
            {
                TotalWOAmount = 0;
                if (txtCreditBalance.Text != "$0.00")
                {
                    decimal creditBalancetxt = decimal.Parse(txtCreditBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                                      NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                    //TotalWOAmount += Convert.ToDecimal(txtCreditBalance.Text.Substring(1));
                    TotalWOAmount += creditBalancetxt;
                }
                if (txtChgOnAccount.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                }
                if (txtPayByCash.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByCash.Text.Substring(1));
                }
                if (txtPayByCheck.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
                }
                if (txtPayByVISA.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
                }
                if (txtPayByMC.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByMC.Text.Substring(1));
                }
                if (txtPayByAMEX.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
                }
                if (txtPayByATM.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByATM.Text.Substring(1));
                }
                if (txtPayByGY.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByGY.Text.Substring(1));
                }
                if (txtPayByDSCVR.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));
                }
            }
            if (WOAmount > 0 && TotalWOAmount < WOAmount)
            {
                string btnName = ((TAButton)sender).Name.Trim();
                //if (btnName == "btnChgOnAccount")
                //{
                //    if (txtChgOnAccount.Text != "$0.00")
                //    {
                //        if (Convert.ToDecimal(txtChgOnAccount.Text.Substring(1)) > WOAmount && Convert.ToDecimal(txtAvailableCredit.Text.Substring(1)) >= WOAmount)
                //        {
                //            txtInvoiceBalance.Text = String.Format("{0:c}", WOAmount - TotalWOAmount);
                //            txtChgOnAccount.Text = "$" + WOAmount.ToString();
                //        }
                //        else if (Convert.ToDecimal(txtChgOnAccount.Text.Substring(1)) < WOAmount && Convert.ToDecimal(txtAvailableCredit.Text.Substring(1)) < WOAmount)
                //        {
                //            txtInvoiceBalance.Text = String.Format("{0:c}", TotalWOAmount - WOAmount);
                //            txtChgOnAccount.Text = "$" + WOAmount.ToString();
                //        }
                //    }
                //}
                //else
                //{
                //    txtTotalAmount.Text = "$" + TotalWOAmount.ToString();
                //    txtInvoiceBalance.Text = "$" + (WOAmount - TotalWOAmount).ToString();
                //    txtInvoiceBalance.Text = String.Format("{0:c}", WOAmount - TotalWOAmount);

                //}
                switch (btnName)
                {
                    case "btnCreditBalance":
                        if (txtCreditBalance.Text == "$0.00")
                        {
                            decimal _value1 = WOAmount - TotalWOAmount;
                            if (CusCredit != 0)
                            {
                                if ((-1 * CusCredit) <= _value1)
                                {
                                    SelectCusCredit = (-1 * CusCredit);
                                    curRow["CusCredit"] = SelectCusCredit;
                                    CusCredit = 0;
                                    txtCusCredit.Text = StaticInfo.MainCurSign + 0;
                                    txtCreditBalance.Text = StaticInfo.MainCurSign + SelectCusCredit;
                                }
                                else if ((-1 * CusCredit) > _value1)
                                {
                                    SelectCusCredit = _value1;
                                    CusCredit = CusCredit + _value1;
                                    curRow["CusCredit"] = SelectCusCredit;
                                    txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit;
                                    txtCreditBalance.Text = StaticInfo.MainCurSign + SelectCusCredit;
                                }
                            }
                        }
                        break;
                    case "btnChgOnAccount":                        
                        if (AllowPastDue || PastDue <= 0)
                        {
                            if (txtChgOnAccount.Text == "$0.00")
                            {
                                if (OverrideCreditLimit)
                                {
                                    decimal _value1 = WOAmount - TotalWOAmount;
                                    curRow["ChgOnAccount"] = _value1.ToString();
                                    txtChgOnAccount.Text = "$" + Convert.ToString(_value1);
                                    AvailableCredit = AvailableCredit - _value1;
                                    SelectAvailableCredit = _value1;
                                    txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                                }
                                else
                                {
                                    if (AvailableCredit >= 0)
                                    {
                                        decimal _value1 = WOAmount - TotalWOAmount;
                                        if (AvailableCredit >= _value1)
                                        {
                                            //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                            curRow["ChgOnAccount"] = _value1.ToString();
                                            txtChgOnAccount.Text = "$" + Convert.ToString(_value1);
                                            AvailableCredit = AvailableCredit - _value1;
                                            SelectAvailableCredit = _value1;
                                            //txtAvailableCredit.Text = String.Format("{0:c}", AvailableCredit);
                                            txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                                        }
                                        else if (AvailableCredit < _value1)
                                        {
                                            curRow["ChgOnAccount"] = AvailableCredit.ToString();
                                            txtChgOnAccount.Text = "$" + Convert.ToString(AvailableCredit);
                                            SelectAvailableCredit = AvailableCredit;
                                            AvailableCredit = 0;
                                            txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                curRow.BeginEdit();
                                AvailableCredit = CreditLimit - CreditAvail;
                                decimal _value1 = Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                                if (AvailableCredit > _value1)
                                {
                                    decimal _value2 = AvailableCredit - _value1;
                                    //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                    curRow["ChgOnAccount"] = _value1.ToString();
                                    txtChgOnAccount.Text = _value1.ToString();
                                    AvailableCredit = _value2;
                                    txtAvailableCredit.Text = StaticInfo.MainCurSign + _value2;
                                    SelectAvailableCredit = _value1;
                                }
                                else
                                {
                                    //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                    curRow["ChgOnAccount"] = _value1.ToString();
                                    txtChgOnAccount.Text = _value1.ToString();
                                    SelectAvailableCredit = _value1;
                                    AvailableCredit = 0;
                                    txtAvailableCredit.Text = StaticInfo.MainCurSign + 0;
                                }
                                curRow.EndEdit();
                            }
                        }
                        else
                            xMessageBox.Show("Sorry! You can't ChgOnAccount when Past Due.");
                        break;
                    case "btnPayByCash":
                        if (txtPayByCash.Text == "$0.00")
                        {
                            txtPayByCash.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByCash"] = txtPayByCash.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByCheck":
                        //txtPayByCheck.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByCheck.Text == "$0.00")
                        {
                            txtPayByCheck.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByCheck"] = txtPayByCheck.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByDeposit":
                        //txtPayByDeposit.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByDeposit.Text == "$0.00")
                        {
                            txtPayByDeposit.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByDeposit"] = txtPayByDeposit.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByVISA":
                        //txtPayByVISA.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByVISA.Text == "$0.00")
                        {
                            txtPayByVISA.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByVISA"] = txtPayByVISA.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByMC":
                        //txtPayByMC.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByMC.Text == "$0.00")
                        {
                            txtPayByMC.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByMC"] = txtPayByMC.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByAMEX":
                        //txtPayByAMEX.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByAMEX.Text == "$0.00")
                        {
                            txtPayByAMEX.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByAMEX"] = txtPayByAMEX.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByATM":
                        //txtPayByATM.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByATM.Text == "$0.00")
                        {
                            txtPayByATM.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByATM"] = txtPayByATM.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByGY":
                        //txtPayByGY.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByGY.Text == "$0.00")
                        {
                            txtPayByGY.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByGY"] = txtPayByGY.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                    case "btnPayByDSCVR":
                        //txtPayByDSCVR.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        if (txtPayByDSCVR.Text == "$0.00")
                        {
                            txtPayByDSCVR.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByDSCVR"] = txtPayByDSCVR.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        break;
                }
                CalculateTotalAmount();
            }
            //else
            //{
            //    if (TotalWOAmount == WOAmount) { }
            //    else
            //    {
            //        xMessageBox.Show("Invalid Amount...!", "Warning");
            //    }
            //}
            //}
            //else if (InvoiceForCredit == true)
            //{
            //    if (txtChgOnAccount.Text != "" || txtPayByCash.Text != "" || txtPayByCheck.Text != "" || txtPayByVISA.Text != "")
            //    {
            //        TotalWOAmount = 0;
            //        if (txtChgOnAccount.Text != "$0.00")
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
            //        }
            //        if (txtPayByCash.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByCash.Text.Substring(1));
            //        }
            //        if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
            //        }
            //        if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
            //        }
            //        if (txtPayByVISA.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
            //        }
            //        if (txtPayByMC.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByMC.Text.Substring(1));
            //        }
            //        if (txtPayByAMEX.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
            //        }
            //        if (txtPayByATM.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByATM.Text.Substring(1));
            //        }
            //        if (txtPayByGY.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByGY.Text.Substring(1));
            //        }
            //        if (txtPayByDSCVR.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= CreditAvail)
            //        {
            //            TotalWOAmount += Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));
            //        }
            //    }
            //    if (TotalWOAmount < CreditAvail)
            //    {
            //        txtTotalAmount.Text = "$" + TotalWOAmount.ToString();
            //        //txtInvoiceBalance.Text = "$" + (CreditAvail - TotalWOAmount).ToString();
            //        txtInvoiceBalance.Text = String.Format("{0:c}", CreditAvail - TotalWOAmount);

            //        string btnName = ((TAButton)sender).Name.Trim();
            //        switch (btnName)
            //        {
            //            case "btnCreditBalance":
            //                if (txtCreditBalance.Text == "$0.00")
            //                {
            //                    txtCreditBalance.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["CusCredit"] = txtCreditBalance.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                //txtChgOnAccount.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                break;
            //            case "btnChgOnAccount":
            //                if (txtChgOnAccount.Text == "$0.00")
            //                {
            //                    txtChgOnAccount.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["ChgOnAccount"] = txtChgOnAccount.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                //txtChgOnAccount.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                break;
            //            case "btnPayByCash":
            //                if (txtPayByCash.Text == "$0.00")
            //                {
            //                    txtPayByCash.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByCash"] = txtPayByCash.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByCheck":
            //                //txtPayByCheck.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByCheck.Text == "$0.00")
            //                {
            //                    txtPayByCheck.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByCheck"] = txtPayByCheck.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByDeposit":
            //                //txtPayByDeposit.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByDeposit.Text == "$0.00")
            //                {
            //                    txtPayByDeposit.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByDeposit"] = txtPayByDeposit.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByVISA":
            //                //txtPayByVISA.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByVISA.Text == "$0.00")
            //                {
            //                    txtPayByVISA.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByVISA"] = txtPayByVISA.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByMC":
            //                //txtPayByMC.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByMC.Text == "$0.00")
            //                {
            //                    txtPayByMC.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByMC"] = txtPayByMC.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByAMEX":
            //                //txtPayByAMEX.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByAMEX.Text == "$0.00")
            //                {
            //                    txtPayByAMEX.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByAMEX"] = txtPayByAMEX.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByATM":
            //                //txtPayByATM.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByATM.Text == "$0.00")
            //                {
            //                    txtPayByATM.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByATM"] = txtPayByATM.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByGY":
            //                //txtPayByGY.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByGY.Text == "$0.00")
            //                {
            //                    txtPayByGY.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByGY"] = txtPayByGY.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByDSCVR":
            //                //txtPayByDSCVR.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
            //                if (txtPayByDSCVR.Text == "$0.00")
            //                {
            //                    txtPayByDSCVR.Text = "$" + Convert.ToString(CreditAvail - TotalWOAmount);
            //                    TotalWOAmount += CreditAvail - TotalWOAmount;
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByDSCVR"] = txtPayByDSCVR.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //        }
            //        CalculateTotalAmount();
            //    }
            //    else
            //    {
            //        //if (TotalWOAmount == CreditAvail) { }
            //        //else
            //        //{
            //            xMessageBox.Show("Invalid Amount...!", "Warning");
            //        //}
            //    }
            //}
            //else
            //{ }
        }
        bool CalculateTotalAmount(decimal _amount = 0)
        {
            bool status = false;
            //if (InvoiceForCredit == false)
            //{
            if (WOAmount >= _amount)
            {
                objBindingSource.EndEdit();

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                decimal CusCredit = Convert.ToDecimal(curRow["CusCredit"]);
                decimal ChgOnAccount = Convert.ToDecimal(curRow["ChgOnAccount"]);
                decimal PayByCash = Convert.ToDecimal(curRow["PayByCash"]);
                decimal PaybyCheck = Convert.ToDecimal(curRow["PaybyCheck"]);
                decimal PayByDeposit = Convert.ToDecimal(curRow["PayByDeposit"]);
                decimal PayByVisa = Convert.ToDecimal(curRow["PayByVisa"]);
                decimal PayByMC = Convert.ToDecimal(curRow["PayByMC"]);
                decimal PayByAMEX = Convert.ToDecimal(curRow["PayByAMEX"]);
                decimal PayByATM = Convert.ToDecimal(curRow["PayByATM"]);
                decimal PayByGY = Convert.ToDecimal(curRow["PayByGY"]);
                decimal PayByDSCVR = Convert.ToDecimal(curRow["PayByDSCVR"]);

                curRow.BeginEdit();
                curRow["TotalReceivedAmount"] = CusCredit + ChgOnAccount + PayByCash + PaybyCheck + PayByDeposit + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
                TotalWOAmount = Convert.ToDecimal(curRow["TotalReceivedAmount"]);
                txtTotalAmount.Text = StaticInfo.MainCurSign + TotalWOAmount;
                curRow.EndEdit();
                //txtInvoiceBalance.Text = "$" + (WOAmount - TotalWOAmount).ToString();
                txtInvoiceBalance.Text = StaticInfo.MainCurSign +  (WOAmount - TotalWOAmount).ToString();
                //decimal InvBalance = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                //                  NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                //if (InvBalance == 0) 
                //{
                //    if (CusCredit > 0) 
                //    {
                //        txtInvoiceBalance.Text = String.Format("{0:c}", (CusCredit * -1));
                //    }
                //}

                status = true;
            }
            else
            {
                status = false;
            }
            //}
            //else
            //{
            //    if (CreditAvail >= _amount)
            //    {
            //        if (_amount > 0)
            //        {
            //            if (CreditAvail == _amount)
            //            {
            //                txtInvoiceBalance.Text = "$" + "0.00";
            //                txtTotalAmount.Text = "$" + _amount.ToString();
            //                TotalWOAmount = _amount;
            //                status = true;
            //            }
            //            else if ((CreditAvail - TotalWOAmount) != CreditAvail)
            //            {
            //                //txtInvoiceBalance.Text = "$" + (CreditAvail - (TotalWOAmount + _amount)).ToString();
            //                txtInvoiceBalance.Text = String.Format("{0:c}", CreditAvail - (TotalWOAmount + _amount));

            //                TotalWOAmount = TotalWOAmount + _amount;
            //                txtTotalAmount.Text = "$" + TotalWOAmount.ToString();
            //                status = true;
            //            }
            //            else
            //            {
            //                //txtInvoiceBalance.Text = "$" + (CreditAvail - _amount).ToString();
            //                txtInvoiceBalance.Text = String.Format("{0:c}", CreditAvail - _amount);

            //                txtTotalAmount.Text = "$" + _amount.ToString();
            //                TotalWOAmount = _amount;
            //                status = true;
            //            }
            //        }
            //        else
            //        {
            //            if (CreditAvail == TotalWOAmount)
            //            {
            //                txtInvoiceBalance.Text = "$" + "0.00";
            //                txtTotalAmount.Text = "$" + TotalWOAmount.ToString();
            //                status = true;
            //            }
            //            else
            //            {
            //                txtInvoiceBalance.Text = "$" + (CreditAvail - TotalWOAmount).ToString();
            //                txtTotalAmount.Text = "$" + TotalWOAmount.ToString();
            //                status = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        status = false;
            //    }
            //}
            return status;
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            Focus = true;
            base.bindingNavigatorCancelItem_Click(sender, e);
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);

            if (this.CustomerID > 0)
                this.getCustomer(this.CustomerID);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            //EnablePaymentMethods();

            //if (this.MultiWorkOrders)
            //{
            //    if (this.ReceiptID > 0)
            //        this.setMultiWorkOrder(this.ReceiptID);

            //    curRow["ReceiptID"] = this.ReceiptID;
            //    curRow["InvoiceNo"] = this.ReceiptID;
            //    // curRow["CusCredit"] = this.ExtraAmount;

            //    btnCustomerList.Enabled = false;
            //    btnWorkOrderList.Enabled = false;

            //}
            //else
            //{
            if (this.WorkOrderID > 0)
                this.getWorkOrder(this.WorkOrderID);

            this.ReceiptID = dbClass.obj.getNextCustomerReceiptAutoNo();
            curRow["ReceiptID"] = this.ReceiptID;
            curRow["InvoiceNo"] = this.ReceiptID;
            // }
            curRow["TrnsDate"] = DateTime.Now;

            if (this.CustomerID > 0)
                curRow["CustomerID"] = this.CustomerID;
            else
                curRow["CustomerID"] = DBNull.Value;

            //if (this.WorkOrderID > 0)
            //    curRow["WOID"] = this.WorkOrderID;
            //else
            //    curRow["WOID"] = DBNull.Value;

            curRow["IsPaid"] = true;
            curRow["IsDeposit"] = false;
            curRow["IsCredit"] = false;

            curRow["PayByDeposit"] = 0;
            curRow["PayByVisa"] = 0;
            curRow["PayByMC"] = 0;
            curRow["PayByAMEX"] = 0;
            curRow["PayByATM"] = 0;
            curRow["PayByGY"] = 0;
            curRow["PayByDSCVR"] = 0;
            curRow["TotalReceivedAmount"] = 0;

            curRow.EndEdit();
            //------------------------------------
            base.DataNavigation();
            
            Focus = false;
            if (SelectCusCredit != 0)
            {
                //txtCusCredit.Text = StaticInfo.MainCurSign + SelectCusCredit.ToString();
                txtCusCredit.Text = StaticInfo.MainCurSign + SelectCusCredit;
            }
            
            bool AllowCash = false;
            bool AllowChgOnAcc = false;            

            DataRow[] row = StaticInfo.UserRights.Select("Code = '013'");
            if (row[0]["CanView"] != DBNull.Value)
                AllowCash = Convert.ToBoolean(row[0]["CanView"]);
            

            if (AllowCash)
            {
                btnPayByCash.Enabled = true;
                txtPayByCash.Enabled = true;
            }
            else
            {
                btnPayByCash.Enabled = false;
                txtPayByCash.Enabled = false;
            }

            //DataRow[] row2 = StaticInfo.UserRights.Select("Code = '016'");
            //if (row2[0]["CanView"] != DBNull.Value)
            //    PastDue = Convert.ToBoolean(row2[0]["CanView"]);

            //if (PastDue)
            //{
            //    btnChgOnAccount.Enabled = true;
            //    txtChgOnAccount.Enabled = true;
            //}
            //else
            //{
            //    btnChgOnAccount.Enabled = false;
            //    txtChgOnAccount.Enabled = false;
            //}

            DataRow[] row3 = StaticInfo.UserRights.Select("Code = '014'");
            if (row3[0]["CanView"] != DBNull.Value)
                AllowChgOnAcc = Convert.ToBoolean(row3[0]["CanView"]);

            if (AllowChgOnAcc)
            {
                btnChgOnAccount.Enabled = true;
                txtChgOnAccount.Enabled = true;
            }
            else
            {
                btnChgOnAccount.Enabled = false;
                txtChgOnAccount.Enabled = false;
            }
            PastDue = dbClass.obj.getPastDueAmountbyCustomerID(Convert.ToInt32(curRow["CustomerID"]));
            
            DataRow[] row2 = StaticInfo.UserRights.Select("Code = '015'");
            if (row2[0]["CanView"] != DBNull.Value)
                AllowPastDue = Convert.ToBoolean(row2[0]["CanView"]);

            if (InvoiceForCredit == true)
            {
                //rdoCredit.Checked = true;
                rdoPaid.Checked = false;
                btnWorkOrderList.Enabled = false;
                btnChgOnAccount.Enabled = false;
                txtChgOnAccount.Enabled = false;
                //btnCreditBalance.Enabled = false;
                //txtCreditBalance.Enabled = false;
            }
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            decimal balance = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                                      NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);

            if (balance == 0)
            {
                if (txtPayByCheck.Text != "$0.00" && txtCheckNo.Text == "")
                {
                    xMessageBox.Show("Cheque No is missing!");
                    txtCheckNo.Focus();
                }
                else
                {
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow["CusCredit"] = SelectCusCredit;
                    if ((curRow["CustomerID"] == DBNull.Value) || (Convert.ToInt32(curRow["CustomerID"]) <= 0))
                    {
                        xMessageBox.Show("Add Customer for this Customer Receipt ...");
                        return;
                    }
                    //if (InvoiceForCredit == false)
                    //{
                    if ((curRow["WOID"] == DBNull.Value) || (string.IsNullOrEmpty(curRow["WOID"].ToString())))
                    {
                        if (xMessageBox.Show("Do you save this receipt without Workorder....?", "Customer Receipt..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    if (Convert.ToDecimal(curRow["TotalReceivedAmount"]) <= 0)
                    {
                        xMessageBox.Show("Receipt amount must be greater then 0 ...");
                        return;
                    }
                    decimal totalCreditAvail = Convert.ToDecimal(curRow["ChgOnAccount"]);
                    curRow["ReceiptID"] = curRow["ReceiptID"];
                    //curRow["CusCredit"] = ExtraAmount - SelectCusCredit;
                    if (totalCreditAvail > 0)
                    {
                        curRow["IsCredit"] = true;
                        save(sender, e);
                        DataTable dt = dbClass.obj.GetNotifications();
                        int a = 1;
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    popup.TitleColor = Color.DarkRed;
                                    popup.HeaderColor = Color.DarkRed;
                                    popup.Size = new Size(450, 100);
                                    //popup.AnimationDuration = 5000;
                                    //popup.AnimationInterval = 5000;
                                    popup.TitleText = "New Notification (" + a + ")";
                                    popup.TitleFont = new Font("Calibri", 18.0F, System.Drawing.FontStyle.Bold);
                                    popup.TitlePadding = new Padding(10, 0, 10, 0);
                                    popup.ContentText = "" + a + " products in your inventory are less then Re-Order level." + Environment.NewLine + "Click for more details";
                                    popup.ContentPadding = new Padding(10, 0, 10, 0);
                                    popup.ContentFont = new Font("Calibri", 12.0F, System.Drawing.FontStyle.Regular);
                                    popup.Popup();// show 
                                    a++;
                                    dbClass.obj.UpdateDisplayedNotifications(Convert.ToInt32(dr["ID"]));
                                }
                            }
                        }
                        //if (CusCredit < totalCreditAvail)
                        //{
                        //    //curRow["ChgOnAccount"] = totalCreditAvail - CusCredit;
                        //    //curRow["CusCredit"] = ExtraAmount-SelectCusCredit;
                        //    save(sender, e);
                        //}
                        //else if (CusCredit > totalCreditAvail)
                        //{
                        //    //curRow["ChgOnAccount"] = "0.00";
                        //    // curRow["CusCredit"] = ExtraAmount - SelectCusCredit;
                        //    save(sender, e);
                        //}
                        //else
                        //{
                        //    //curRow["ChgOnAccount"] = "0.00";
                        //    //curRow["CusCredit"] = ExtraAmount - SelectCusCredit;
                        //    save(sender, e);
                        //}
                    }
                    else
                    {
                        save(sender, e);
                        DataTable dt = dbClass.obj.GetNotifications();
                        int a = 1;
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    popup.TitleColor = Color.DarkRed;
                                    popup.HeaderColor = Color.DarkRed;
                                    popup.Size = new Size(450, 100);
                                    //popup.AnimationDuration = 5000;
                                    //popup.AnimationInterval = 5000;
                                    popup.TitleText = "New Notification (" + a + ")";
                                    popup.TitleFont = new Font("Calibri", 18.0F, System.Drawing.FontStyle.Bold);
                                    popup.TitlePadding = new Padding(10, 0, 10, 0);
                                    popup.ContentText = "" + a + " products in your inventory are less then Re-Order level." + Environment.NewLine + "Click for more details";
                                    popup.ContentPadding = new Padding(10, 0, 10, 0);
                                    popup.ContentFont = new Font("Calibri", 12.0F, System.Drawing.FontStyle.Regular);
                                    popup.Popup();// show 
                                    a++;
                                    dbClass.obj.UpdateDisplayedNotifications(Convert.ToInt32(dr["ID"]));
                                }
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    DataTable dt = dbClass.obj.getCreditAvailListbyCustomerID(this.CustomerID);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        decimal _ChgOnAccountValue = 0;
                    //        decimal _RemainingCredit = Convert.ToDecimal(txtTotalAmount.Text.Substring(1));
                    //        bool _Status = false;
                    //        try
                    //        {
                    //            for (int i = 0; i < dt.Rows.Count; i++)
                    //            {
                    //                _ChgOnAccountValue = Convert.ToDecimal(dt.Rows[i]["ChgOnAccount"]);
                    //                if (_ChgOnAccountValue <= _RemainingCredit)
                    //                {
                    //                    _RemainingCredit -= _ChgOnAccountValue;
                    //                    if (_RemainingCredit >= 0)
                    //                    {
                    //                        _Status = dbClass.obj.UpdateCreditAvailbyID(Convert.ToInt32(dt.Rows[i]["ID"]));
                    //                        if (_Status == true)
                    //                        {
                    //                            continue;
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        break;
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    continue;
                    //                }
                    //            }
                    //            if (_RemainingCredit == 0)
                    //            {
                    //                xMessageBox.Show("Invoice Saved Successfully...");

                    //                ClearControls();

                    //                ctrCustomer.Text = "";
                    //                //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                    //                txtInvoiceNo.Text = "";
                    //                CreditAvail = 0;
                    //            }
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            xMessageBox.Show(ex.Message);
                    //        }
                    //    }
                    //}
                }
            }
            else if (balance < 0)
            {
                if (txtPayByCheck.Text != "$0.00" && txtCheckNo.Text == "")
                {
                    xMessageBox.Show("Cheque No is missing!");
                    txtCheckNo.Focus();
                }
                else
                {
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    //decimal balance = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |NumberStyles.AllowLeadingSign |
                    //                  NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);

                    //curRow["CusCredit"] = (-1* balance) - SelectCusCredit;
                    curRow["CusCredit"] = SelectCusCredit + balance;
                    //curRow["CusCredit"] = -1 * (Convert.ToDecimal(txtInvoiceBalance.Text.Substring(1)));
                    if ((curRow["CustomerID"] == DBNull.Value) || (Convert.ToInt32(curRow["CustomerID"]) <= 0))
                    {
                        xMessageBox.Show("Add Customer for this Customer Receipt ...");
                        return;
                    }
                    //if (InvoiceForCredit == false)
                    //{
                    if (curRow["WOID"] == DBNull.Value)
                    {
                        if (xMessageBox.Show("Do you save this receipt without Workorder....?", "Customer Receipt..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    if (Convert.ToDecimal(curRow["TotalReceivedAmount"]) <= 0)
                    {
                        xMessageBox.Show("Receipt amount must be greater then 0 ...");
                        return;
                    }
                    decimal totalCreditAvail = Convert.ToDecimal(curRow["ChgOnAccount"]);
                    curRow["InvoiceNo"] = curRow["ReceiptID"];
                    if (totalCreditAvail > 0)
                    {
                        curRow["IsCredit"] = true;
                        save(sender, e);
                        DataTable dt = dbClass.obj.GetNotifications();
                        int a = 1;
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    popup.TitleColor = Color.DarkRed;
                                    popup.HeaderColor = Color.DarkRed;
                                    popup.Size = new Size(450, 100);
                                    //popup.AnimationDuration = 5000;
                                    //popup.AnimationInterval = 5000;
                                    popup.TitleText = "New Notification (" + a + ")";
                                    popup.TitleFont = new Font("Calibri", 18.0F, System.Drawing.FontStyle.Bold);
                                    popup.TitlePadding = new Padding(10, 0, 10, 0);
                                    popup.ContentText = "" + a + " products in your inventory are less then Re-Order level." + Environment.NewLine + "Click for more details";
                                    popup.ContentPadding = new Padding(10, 0, 10, 0);
                                    popup.ContentFont = new Font("Calibri", 12.0F, System.Drawing.FontStyle.Regular);
                                    popup.Popup();// show 
                                    a++;
                                    dbClass.obj.UpdateDisplayedNotifications(Convert.ToInt32(dr["ID"]));
                                }
                            }
                        }
                        //if (CusCredit < totalCreditAvail)
                        //{
                        //    curRow["ChgOnAccount"] = totalCreditAvail - CusCredit;
                        //    //curRow["CusCredit"] = -1 * (CusCredit);
                        //    save(sender, e);
                        //}
                        //else if (CusCredit > totalCreditAvail)
                        //{
                        //    curRow["ChgOnAccount"] = "0.00";
                        //    // curRow["CusCredit"] = -1 * (totalCreditAvail);
                        //    save(sender, e);
                        //}
                        //else
                        //{
                        //    curRow["ChgOnAccount"] = "0.00";
                        //    //curRow["CusCredit"] = -1 * (CusCredit);
                        //    save(sender, e);
                        //}
                    }
                    else
                    {
                        save(sender, e);
                        DataTable dt = dbClass.obj.GetNotifications();
                        int a = 1;
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    popup.TitleColor = Color.DarkRed;
                                    popup.HeaderColor = Color.DarkRed;
                                    popup.Size = new Size(450, 100);
                                    //popup.AnimationDuration = 5000;
                                    //popup.AnimationInterval = 5000;
                                    popup.TitleText = "New Notification (" + a + ")";
                                    popup.TitleFont = new Font("Calibri", 18.0F, System.Drawing.FontStyle.Bold);
                                    popup.TitlePadding = new Padding(10, 0, 10, 0);
                                    popup.ContentText = "" + a + " products in your inventory are less then Re-Order level." + Environment.NewLine + "Click for more details";
                                    popup.ContentPadding = new Padding(10, 0, 10, 0);
                                    popup.ContentFont = new Font("Calibri", 12.0F, System.Drawing.FontStyle.Regular);
                                    popup.Popup();// show 
                                    a++;
                                    dbClass.obj.UpdateDisplayedNotifications(Convert.ToInt32(dr["ID"]));
                                }
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    DataTable dt = dbClass.obj.getCreditAvailListbyCustomerID(this.CustomerID);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        decimal _ChgOnAccountValue = 0;
                    //        decimal _RemainingCredit = Convert.ToDecimal(txtTotalAmount.Text.Substring(1));
                    //        bool _Status = false;
                    //        try
                    //        {
                    //            for (int i = 0; i < dt.Rows.Count; i++)
                    //            {
                    //                _ChgOnAccountValue = Convert.ToDecimal(dt.Rows[i]["ChgOnAccount"]);
                    //                if (_ChgOnAccountValue <= _RemainingCredit)
                    //                {
                    //                    _RemainingCredit -= _ChgOnAccountValue;
                    //                    if (_RemainingCredit >= 0)
                    //                    {
                    //                        _Status = dbClass.obj.UpdateCreditAvailbyID(Convert.ToInt32(dt.Rows[i]["ID"]));
                    //                        if (_Status == true)
                    //                        {
                    //                            continue;
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        break;
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    continue;
                    //                }
                    //            }
                    //            if (_RemainingCredit == 0)
                    //            {
                    //                xMessageBox.Show("Invoice Saved Successfully...");

                    //                ClearControls();

                    //                ctrCustomer.Text = "";
                    //                //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                    //                txtInvoiceNo.Text = "";
                    //                CreditAvail = 0;
                    //            }
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            xMessageBox.Show(ex.Message);
                    //        }
                    //    }
                    //}
                }
            }
            else
            {
                xMessageBox.Show("Invoice Balance must be zero!");
            }
            //else if (Convert.ToDecimal(txtInvoiceBalance.Text.Substring(1)) < 0) 
            //{
            //    DataRowView curRow = (DataRowView)objBindingSource.Current;
            //    curRow.BeginEdit();                
            //    decimal TempChg = Convert.ToDecimal(curRow["ChgOnAccount"]);
            //    decimal TempChgFinal = -1 * (Convert.ToDecimal(txtInvoiceBalance.Text.Substring(1)));
            //    curRow["ChgOnAccount"] = (TempChg + TempChgFinal).ToString();
            //    curRow.EndEdit();

            //    save(sender, e);

            //}
        }
        void save(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            string PaidBy = "";
            
            //if (MultiWorkOrders)
            //    curRow["WOID"] = this.WOIDs;
            //else
            // curRow["WOID"] = "," + this.WorkOrderID + ",";
            //curRow["WOID"] = this.WorkOrderID;

            if (curRow["CusCredit"] != null)
            {
                if (Convert.ToDecimal(curRow["CusCredit"]) > 0)
                    PaidBy += " Credit Balance $" + Convert.ToDecimal(curRow["CusCredit"]);
            }
            if (curRow["ChgOnAccount"] != null) 
            {
                if (Convert.ToDecimal(curRow["ChgOnAccount"]) != 0)
                    PaidBy += " Account $" + curRow["ChgOnAccount"];
            }
            if (curRow["PayByCash"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByCash"]) != 0)
                    PaidBy += " Cash $" + curRow["PayByCash"];
            }
            if (curRow["PaybyCheck"] != null)
            {
                if (Convert.ToDecimal(curRow["PaybyCheck"]) != 0)
                    PaidBy += " Check $" + curRow["PaybyCheck"];
            }
            if (curRow["PayByVisa"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByVisa"]) != 0)
                    PaidBy += " Visa $" + curRow["PayByVisa"];
            }
            if (curRow["PayByMC"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByMC"]) != 0)
                    PaidBy += " MC $" + curRow["PayByMC"];
            }
            if (curRow["PayByAMEX"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByAMEX"]) != 0)
                    PaidBy += " AMEX $" + curRow["PayByAMEX"];
            }
            if (curRow["PayByATM"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByATM"]) != 0)
                    PaidBy += " ATM $" + curRow["PayByATM"];
            }
            if (curRow["PayByGY"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByGY"]) != 0)
                    PaidBy += " GY $" + curRow["PayByGY"];
            }
            if (curRow["PayByDSCVR"] != null)
            {
                if (Convert.ToDecimal(curRow["PayByDSCVR"]) != 0)
                    PaidBy += " DSCVR $" + curRow["PayByDSCVR"];
            }
            
            curRow["TrnsNotes"] = PaidBy;

            base.bindingNavigatorSaveItem_Click(sender, e);

            this.ParentForm.Close();
            if (CustomValidation(true))
            {
                int WOID = 0;
                decimal PaidAmount = 0, Blnc = 0;

                if (InvoiceForCredit == true)
                {
                    int InvID = 0;
                    string Ids = "";
                    foreach (DataRow dr in TempPayment.Rows)
                    {
                        InvID = Convert.ToInt32(dr["InvoiceID"]);
                        PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                        dbClass.obj.AddCustomerCreditHistory(this.ReceiptID, InvID, PaidAmount, CustomerID);
                        Blnc = Convert.ToDecimal(dr["Balance"]);
                        if (Blnc == 0)
                            Ids += "," + InvID + ",";
                    }

                    dbClass.obj.UpdateCustomerReceiptCredit(Ids);

                    StaticInfo.LoadToReport("RptModule", "Reports.CustomerCreditHistoryReport", "byID", this.ReceiptID);
                    bool status = UpdateLedgerDetails();
                    if (status == false)
                    {
                        xMessageBox.Show("Ledger is not updated successfully....!");
                    }
                }
                else
                {

                    //if (MultiWorkOrders)
                    //{
                    //    this.ReceiptID = Convert.ToInt32(curRow["ReceiptID"]);

                    //    DataTable dt = dbClass.obj.getCustomerPaymentTempByCustomerIDAndPaymentID(this.CustomerID, this.ReceiptID);
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        WOID = Convert.ToInt32(dr["WOID"]);
                    //        PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);

                    //        dbClass.obj.AddCustomerReceipt(ReceiptID, this.CustomerID, WOID, ReceiptID.ToString(), DateTime.Now, PaidAmount);

                    //    }

                    //    dbClass.obj.UpdateVendorPaymentTemp(ReceiptID);
                    //}
                    //else
                    //{
                    //    this.WOIDs = "," + this.WorkOrderID + ",";
                    //    dbClass.obj.AddCustomerPaymentTemp(this.ReceiptID, this.CustomerID, this.WorkOrderID, DateTime.Now, Convert.ToDecimal(curRow["InvoiceAmount"]), Convert.ToDecimal(curRow["InvoiceAmount"]), 0, true);
                    //    dbClass.obj.AddCustomerReceipt(this.ReceiptID, this.CustomerID, this.WorkOrderID, ReceiptID.ToString(), DateTime.Now, Convert.ToDecimal(curRow["InvoiceAmount"]));
                    //}

                    if (WarehouseCopy.Checked)
                    {
                        //frmRpt obj = new frmRpt("Reports.WorkOrderReportWareHouse", "", this.WOIDs, this.ReceiptID);
                        ////ctrWorkOrderListing objWorkOrder = new ctrWorkOrderListing(this.CustomerID);
                        ////objWorkOrder.WorkOrderSelected += objWorkOrder_WorkOrderSelected;
                        //frmCtr frmCtr = new frmCtr("WorkOrder ...");
                        //frmCtr.Height = obj.Height + 20; frmCtr.Width = obj.Width + 20;
                        //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        //frmCtr.frmPnl.Controls.Add(obj);
                        //frmCtr.BringToFront();
                        //frmCtr.ShowDialog();
                        if (this.WorkOrderID > 0)
                        {
                            StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportWareHouse", "byID", WorkOrderID);
                        }
                    }
                    if (CustomerCpy.Checked)
                    {
                        //frmRpt obj = new frmRpt("Reports.WorkOrderReportCustomerCopy", "", this.WOIDs, this.ReceiptID);
                        ////ctrWorkOrderListing objWorkOrder = new ctrWorkOrderListing(this.CustomerID);
                        ////objWorkOrder.WorkOrderSelected += objWorkOrder_WorkOrderSelected;
                        //frmCtr frmCtr = new frmCtr("WorkOrder ...");
                        //frmCtr.Height = obj.Height + 20; frmCtr.Width = obj.Width + 20;
                        //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        //frmCtr.frmPnl.Controls.Add(obj);
                        //frmCtr.BringToFront();
                        //frmCtr.ShowDialog();
                        if (this.WorkOrderID > 0)
                        {
                            StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportCustomerCopy", "byID", WorkOrderID);
                        }
                    }
                    if (StoreCopy.Checked)
                    {
                        //frmRpt obj = new frmRpt("Reports.WorkOrderReportStoreCopy", "", this.WOIDs, this.ReceiptID);
                        ////ctrWorkOrderListing objWorkOrder = new ctrWorkOrderListing(this.CustomerID);
                        ////objWorkOrder.WorkOrderSelected += objWorkOrder_WorkOrderSelected;
                        //frmCtr frmCtr = new frmCtr("WorkOrder ...");
                        //frmCtr.Height = obj.Height + 20; frmCtr.Width = obj.Width + 20;
                        //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        //frmCtr.frmPnl.Controls.Add(obj);
                        //frmCtr.BringToFront();
                        //frmCtr.ShowDialog();
                        if (this.WorkOrderID > 0)
                        {
                            StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportStoreCopy", "byID", WorkOrderID);
                        }
                    }

                    bool status = UpdateLedgerDetails();
                    if (status == false)
                    {
                        xMessageBox.Show("Ledger is not updated successfully....!");
                    }
                }
            }
        }
        bool UpdateLedgerDetails()
        {
            bool status = false;
            dbClass db = new dbClass();
            string vID = db.getNextVoucherNo();

            DataTable Receiptdt = db.GetCustomerRecieptForVoucher(this.ReceiptID);
            DataTable dtSaleAccounts = db.GetAccountsList(4, 9);
            DataTable vdt = objDataSet.Tables["AccountVoucher"].Copy();

            try
            {
                if (Receiptdt.Rows.Count == 1)
                {
                    DataRow dtnRow = vdt.NewRow();
                    dtnRow["vNo"] = vID;
                    dtnRow["vTypeID"] = Convert.ToInt32(Receiptdt.Rows[0]["vTypeID"]);
                    dtnRow["vDate"] = Convert.ToDateTime(Receiptdt.Rows[0]["TrnsDate"]);
                    dtnRow["AccountID"] = 4;
                    dtnRow["InvoiceID"] = Convert.ToInt32(Receiptdt.Rows[0]["ID"]);
                    if (Receiptdt.Rows[0]["WOID"] != System.DBNull.Value)
                    {
                        dtnRow["WOID"] = Convert.ToInt32(Receiptdt.Rows[0]["WOID"]);
                    }
                    dtnRow["vforVendor"] = 0;
                    dtnRow["vforCustomer"] = 1;
                    dtnRow["vforEmployee"] = 0;
                    dtnRow["CustomerID"] = this.CustomerID;
                    dtnRow["EmployeeID"] = StaticInfo.userid;
                    dtnRow["Narration"] = "Sale Voucher";
                    dtnRow["TPAmount"] = Receiptdt.Rows[0]["PartsPrice"];
                    dtnRow["TLAmount"] = Receiptdt.Rows[0]["LaborPrice"];
                    dtnRow["TFET"] = Receiptdt.Rows[0]["FET"];
                    dtnRow["TTaxable"] = Receiptdt.Rows[0]["Taxable"];
                    dtnRow["TTax"] = Receiptdt.Rows[0]["Tax"];
                    dtnRow["TDiscount"] = Receiptdt.Rows[0]["Discount"];
                    dtnRow["TotalAmount"] = Receiptdt.Rows[0]["TotalReceivedAmount"];
                    dtnRow["TotalProfit"] = Receiptdt.Rows[0]["TotalProfit"];
                    dtnRow["AmountIn"] = 1;
                    dtnRow["AmountOut"] = 0;
                    dtnRow["TrnsNotes"] = Receiptdt.Rows[0]["TrnsNotes"];
                    dtnRow["PayByCash"] = Convert.ToDecimal(Receiptdt.Rows[0]["PayByCash"]);
                    dtnRow["PaybyBank"] = Convert.ToDecimal(Receiptdt.Rows[0]["PaybyCheck"]) + Convert.ToDecimal(Receiptdt.Rows[0]["PayByVisa"]) + Convert.ToDecimal(Receiptdt.Rows[0]["PayByAMEX"]) + Convert.ToDecimal(Receiptdt.Rows[0]["PayByATM"]) + Convert.ToDecimal(Receiptdt.Rows[0]["PayByDSCVR"]) + Convert.ToDecimal(Receiptdt.Rows[0]["PayByMC"]);
                    dtnRow["Receivable"] = Receiptdt.Rows[0]["ChgOnAccount"];
                    dtnRow["AddDate"] = DateTime.Now;
                    dtnRow["AddUserID"] = StaticInfo.userid;
                    dtnRow["Comments"] = "";
                    dtnRow["IsLocked"] = 0;
                    dtnRow["Active"] = 1;
                    vdt.Rows.Add(dtnRow);
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.ToString());
                return status;
            }

            DataTable ReceiptDdt = new DataTable();
            DataTable vddt = new DataTable();
            decimal TotalAmount = 0;
            decimal TotalTire = 0;
            decimal TotalParts = 0;
            decimal TotalOutsideParts = 0;
            decimal TotalWheels = 0;
            decimal TotalLabour = 0;
            decimal TotalFEE = 0;
            decimal TotalOthers = 0;
            decimal TotalFET = 0;
            decimal TotalTax = 0;
            try
            {
                ReceiptDdt = db.GetLatestCustomerRecieptDetails(this.WorkOrderID, this.ReceiptID);
                vddt = objDataSet.Tables["AccountVoucherDetails"].Copy();
                DataRow PartRow = vddt.NewRow();
                DataRow WheelRow = vddt.NewRow();
                DataRow TireRow = vddt.NewRow();
                DataRow LabRow = vddt.NewRow();
                DataRow FeesRow = vddt.NewRow();
                DataRow OtherRow = vddt.NewRow();

                int PartQty = 0; decimal PartPrice = 0; decimal PartCost = 0; decimal PartAmount = 0; decimal PartDiscAmount = 0; decimal PartProfit = 0; decimal PartFET = 0; decimal PartTax = 0;
                decimal PartTotal = 0;

                int WhQty = 0; decimal WhPrice = 0; decimal WhCost = 0; decimal WhAmount = 0; decimal WhDiscAmount = 0; decimal WhProfit = 0; decimal WhFET = 0; decimal WhTax = 0;
                decimal WhTotal = 0;

                int TirQty = 0; decimal TirPrice = 0; decimal TirCost = 0; decimal TirAmount = 0; decimal TirDiscAmount = 0; decimal TirProfit = 0; decimal TirFET = 0; decimal TirTax = 0;
                decimal TirTotal = 0;

                int LabQty = 0; decimal LabPrice = 0; decimal LabCost = 0; decimal LabAmount = 0; decimal LabDiscAmount = 0; decimal LabProfit = 0; decimal LabFET = 0; decimal LabTax = 0;
                decimal LabTotal = 0;

                int FeeQty = 0; decimal FeePrice = 0; decimal FeeCost = 0; decimal FeeAmount = 0; decimal FeeDiscAmount = 0; decimal FeeProfit = 0; decimal FeeFET = 0; decimal FeeTax = 0;
                decimal FeeTotal = 0;

                int OthQty = 0; decimal OthPrice = 0; decimal OthCost = 0; decimal OthAmount = 0; decimal OthDiscAmount = 0; decimal OthProfit = 0; decimal OthFET = 0; decimal OthTax = 0;
                decimal OthTotal = 0;
                if (ReceiptDdt.Rows.Count > 0)
                {
                    for (int i = 0; i < ReceiptDdt.Rows.Count; i++)
                    {
                        //Get Total Values against product
                        //---------------------------------------------------------------------------------       
                        if (ReceiptDdt.Rows[i]["Ctype"].ToString() == "Par" || ReceiptDdt.Rows[i]["Ctype"].ToString() == "Lub")
                        {
                            PartRow["MID"] = vID;
                            PartRow["vTypeID"] = 4;
                            PartRow["vDate"] = DateTime.Now;
                            PartRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            PartRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            PartRow["vforVendor"] = 0;
                            PartRow["vforCustomer"] = 1;
                            PartRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    PartRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    PartRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                PartQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                PartRow["Qty"] = PartQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                PartPrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                PartRow["Price"] = PartPrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                PartCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                PartRow["Cost"] = PartCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                PartAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                PartRow["Amount"] = PartAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                PartDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                PartRow["DiscAmount"] = PartDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                PartFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                PartRow["FET"] = PartFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                PartProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                PartRow["Profit"] = PartProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                PartTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                PartRow["Tax"] = PartTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                PartTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                PartRow["Total"] = PartTotal;
                            }
                            PartRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //PartRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalParts += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            PartRow["vforVendor"] = 0;
                            PartRow["vforCustomer"] = 1;
                            PartRow["vforEmployee"] = 0;

                            PartRow["AmountIn"] = 1;
                            PartRow["AmountOut"] = 0;
                            PartRow["Remarks"] = "";

                            PartRow["AddDate"] = DateTime.Now;
                            PartRow["AddUserID"] = StaticInfo.userid;
                            PartRow["Comments"] = "";
                            PartRow["IsLocked"] = 0;
                            PartRow["Active"] = 1;
                            PartRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                        }
                        else if (ReceiptDdt.Rows[i]["Ctype"].ToString() == "Whe")
                        {
                            WheelRow["MID"] = vID;
                            WheelRow["vTypeID"] = 4;
                            WheelRow["vDate"] = DateTime.Now;
                            WheelRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            WheelRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            WheelRow["vforVendor"] = 0;
                            WheelRow["vforCustomer"] = 1;
                            WheelRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    WheelRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    WheelRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                WhQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                WheelRow["Qty"] = WhQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                WhPrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                WheelRow["Price"] = WhPrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                WhCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                WheelRow["Cost"] = WhCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                WhAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                WheelRow["Amount"] = WhAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                WhDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                WheelRow["DiscAmount"] = WhDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                WhFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                WheelRow["FET"] = WhFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                WhProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                WheelRow["Profit"] = WhProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                WhTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                WheelRow["Tax"] = WhTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                WhTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                WheelRow["Total"] = WhTotal;
                            }
                            WheelRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //WheelRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalWheels += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            WheelRow["vforVendor"] = 0;
                            WheelRow["vforCustomer"] = 1;
                            WheelRow["vforEmployee"] = 0;

                            WheelRow["AmountIn"] = 1;
                            WheelRow["AmountOut"] = 0;
                            WheelRow["Remarks"] = "";

                            WheelRow["AddDate"] = DateTime.Now;
                            WheelRow["AddUserID"] = StaticInfo.userid;
                            WheelRow["Comments"] = "";
                            WheelRow["IsLocked"] = 0;
                            WheelRow["Active"] = 1;
                            WheelRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                        }
                        else if (ReceiptDdt.Rows[i]["Ctype"].ToString() == "Tir")
                        {
                            TireRow["MID"] = vID;
                            TireRow["vTypeID"] = 4;
                            TireRow["vDate"] = DateTime.Now;
                            TireRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            TireRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            TireRow["vforVendor"] = 0;
                            TireRow["vforCustomer"] = 1;
                            TireRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    TireRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    TireRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                TirQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                TireRow["Qty"] = TirQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                TirPrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                TireRow["Price"] = TirPrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                TirCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                TireRow["Cost"] = TirCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                TirAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                TireRow["Amount"] = TirAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                TirDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                TireRow["DiscAmount"] = TirDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                TirFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                TireRow["FET"] = TirFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                TirProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                TireRow["Profit"] = TirProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                TirTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                TireRow["Tax"] = TirTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                TirTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                TireRow["Total"] = TirTotal;
                            }
                            TireRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //TireRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalTire += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            TireRow["vforVendor"] = 0;
                            TireRow["vforCustomer"] = 1;
                            TireRow["vforEmployee"] = 0;

                            TireRow["AmountIn"] = 1;
                            TireRow["AmountOut"] = 0;
                            TireRow["Remarks"] = "";

                            TireRow["AddDate"] = DateTime.Now;
                            TireRow["AddUserID"] = StaticInfo.userid;
                            TireRow["Comments"] = "";
                            TireRow["IsLocked"] = 0;
                            TireRow["Active"] = 1;
                            TireRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                        }
                        else if (ReceiptDdt.Rows[i]["Ctype"].ToString() == "Lab")
                        {
                            LabRow["MID"] = vID;
                            LabRow["vTypeID"] = 4;
                            LabRow["vDate"] = DateTime.Now;
                            LabRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            LabRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            LabRow["vforVendor"] = 0;
                            LabRow["vforCustomer"] = 1;
                            LabRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    LabRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    LabRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                LabQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                LabRow["Qty"] = LabQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                LabPrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                LabRow["Price"] = LabPrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                LabCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                LabRow["Cost"] = LabCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                LabAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                LabRow["Amount"] = LabAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                LabDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                LabRow["DiscAmount"] = LabDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                LabFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                LabRow["FET"] = LabFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                LabProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                LabRow["Profit"] = LabProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                LabTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                LabRow["Tax"] = LabTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                LabTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                LabRow["Total"] = LabTotal;
                            }
                            LabRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //LabRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalLabour += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            LabRow["vforVendor"] = 0;
                            LabRow["vforCustomer"] = 1;
                            LabRow["vforEmployee"] = 0;

                            LabRow["AmountIn"] = 1;
                            LabRow["AmountOut"] = 0;
                            LabRow["Remarks"] = "";

                            LabRow["AddDate"] = DateTime.Now;
                            LabRow["AddUserID"] = StaticInfo.userid;
                            LabRow["Comments"] = "";
                            LabRow["IsLocked"] = 0;
                            LabRow["Active"] = 1;
                            LabRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                        }
                        else if (ReceiptDdt.Rows[i]["Ctype"].ToString() == "Fees")
                        {
                            FeesRow["MID"] = vID;
                            FeesRow["vTypeID"] = 4;
                            FeesRow["vDate"] = DateTime.Now;
                            FeesRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            FeesRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            FeesRow["vforVendor"] = 0;
                            FeesRow["vforCustomer"] = 1;
                            FeesRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    WheelRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    WheelRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                FeeQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                FeesRow["Qty"] = FeeQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                FeePrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                FeesRow["Price"] = FeePrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                FeeCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                FeesRow["Cost"] = FeeCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                FeeAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                FeesRow["Amount"] = FeeAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                FeeDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                FeesRow["DiscAmount"] = FeeDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                FeeFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                FeesRow["FET"] = FeeFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                FeeProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                FeesRow["Profit"] = FeeProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                FeeTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                FeesRow["Tax"] = FeeTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                FeeTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                FeesRow["Total"] = FeeTotal;
                            }
                            FeesRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //WheelRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalFEE += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            FeesRow["vforVendor"] = 0;
                            FeesRow["vforCustomer"] = 1;
                            FeesRow["vforEmployee"] = 0;

                            FeesRow["AmountIn"] = 1;
                            FeesRow["AmountOut"] = 0;
                            FeesRow["Remarks"] = "";

                            FeesRow["AddDate"] = DateTime.Now;
                            FeesRow["AddUserID"] = StaticInfo.userid;
                            FeesRow["Comments"] = "";
                            FeesRow["IsLocked"] = 0;
                            FeesRow["Active"] = 1;
                            FeesRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                        }
                        else
                        {
                            OtherRow["MID"] = vID;
                            OtherRow["vTypeID"] = 4;
                            OtherRow["vDate"] = DateTime.Now;
                            OtherRow["InvoiceID"] = Receiptdt.Rows[0]["ID"];
                            OtherRow["WOID"] = ReceiptDdt.Rows[i]["MID"];
                            OtherRow["vforVendor"] = 0;
                            OtherRow["vforCustomer"] = 1;
                            OtherRow["vforEmployee"] = 0;
                            //if (ReceiptDdt.Rows[i]["ItemID"] != null)
                            //{
                            //    WheelRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            //}
                            //if (ReceiptDdt.Rows[i]["Available"] != null)
                            //{
                            //    WheelRow["Available"] = ReceiptDdt.Rows[i]["Available"];
                            //}
                            if (ReceiptDdt.Rows[i]["Qty"] != System.DBNull.Value)
                            {
                                OthQty += Convert.ToInt32(ReceiptDdt.Rows[i]["Qty"]);
                                OtherRow["Qty"] = OthQty;
                            }
                            if (ReceiptDdt.Rows[i]["Price"] != System.DBNull.Value)
                            {
                                OthPrice += Convert.ToDecimal(ReceiptDdt.Rows[i]["Price"]);
                                OtherRow["Price"] = OthPrice;
                            }
                            if (ReceiptDdt.Rows[i]["Cost"] != System.DBNull.Value)
                            {
                                OthCost += Convert.ToDecimal(ReceiptDdt.Rows[i]["Cost"]);
                                OtherRow["Cost"] = OthCost;
                            }
                            if (ReceiptDdt.Rows[i]["Amount"] != System.DBNull.Value)
                            {
                                OthAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                                OtherRow["Amount"] = OthAmount;
                                TotalAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);
                            }
                            if (ReceiptDdt.Rows[i]["DiscAmount"] != System.DBNull.Value)
                            {
                                OthDiscAmount += Convert.ToDecimal(ReceiptDdt.Rows[i]["DiscAmount"]);
                                OtherRow["DiscAmount"] = OthDiscAmount;
                            }
                            if (ReceiptDdt.Rows[i]["FET"] != System.DBNull.Value)
                            {
                                OthFET += Convert.ToDecimal(ReceiptDdt.Rows[i]["FET"]);
                                OtherRow["FET"] = OthFET;
                            }
                            if (ReceiptDdt.Rows[i]["Profit"] != System.DBNull.Value)
                            {
                                OthProfit += Convert.ToDecimal(ReceiptDdt.Rows[i]["Profit"]);
                                OtherRow["Profit"] = OthProfit;
                            }
                            if (ReceiptDdt.Rows[i]["Tax"] != System.DBNull.Value)
                            {
                                OthTax += Convert.ToDecimal(ReceiptDdt.Rows[i]["Tax"]);
                                OtherRow["Tax"] = OthTax;
                            }
                            if (ReceiptDdt.Rows[i]["Total"] != System.DBNull.Value)
                            {
                                OthTotal += Convert.ToDecimal(ReceiptDdt.Rows[i]["Total"]);
                                OtherRow["Total"] = OthTotal;
                            }
                            OtherRow["TrnsNotes"] = dtSaleAccounts.Rows[4]["AccName"].ToString();
                            //OtherRow["ItemID"] = ReceiptDdt.Rows[i]["ItemID"];
                            TotalWheels += Convert.ToDecimal(ReceiptDdt.Rows[i]["Amount"]);

                            OtherRow["vforVendor"] = 0;
                            OtherRow["vforCustomer"] = 1;
                            OtherRow["vforEmployee"] = 0;

                            OtherRow["AmountIn"] = 1;
                            OtherRow["AmountOut"] = 0;
                            OtherRow["Remarks"] = "";

                            OtherRow["AddDate"] = DateTime.Now;
                            OtherRow["AddUserID"] = StaticInfo.userid;
                            OtherRow["Comments"] = "";
                            OtherRow["IsLocked"] = 0;
                            OtherRow["Active"] = 1;
                            if(ReceiptDdt.Rows[i]["ctype"].ToString()!= "0")
                            {
                                OtherRow["Ctype"] = ReceiptDdt.Rows[i]["ctype"].ToString();
                            }
                            else
                            {
                                OtherRow["Ctype"] = "Payment";
                            }
                            
                        }
                    }
                }
                if (PartRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(PartRow);
                }
                if (WheelRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(WheelRow);
                }
                if (TireRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(TireRow);
                }
                if (LabRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(LabRow);
                }
                if (FeesRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(FeesRow);
                }
                if (OtherRow["InvoiceID"] != System.DBNull.Value)
                {
                    vddt.Rows.Add(OtherRow);
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.ToString());
                return status;
            }
            status = db.UpdateLedger(vdt, vddt, dtSaleAccounts, TotalAmount, TotalParts, TotalWheels, TotalTire, TotalLabour, TotalFET, TotalFEE, TotalOutsideParts, TotalOthers, TotalTax);
            return status;
        }
        void btnWorkOrderList_Click(object sender, EventArgs e)
        {
            if (this.CustomerID > 0)
            {
                ctrWorkOrderListing objWorkOrder = new ctrWorkOrderListing(this.CustomerID);
                objWorkOrder.WorkOrderSelected += objWorkOrder_WorkOrderSelected;
                frmCtr frmCtr = new frmCtr("WorkOrder ...");
                frmCtr.Height = objWorkOrder.Height + 20; frmCtr.Width = objWorkOrder.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objWorkOrder);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
            else
                xMessageBox.Show("Select Customer for Customer Receipt ....");
        }
        void objWorkOrder_WorkOrderSelected(object sender, DataRow dataRow)
        {
            SetWorkOrder(dataRow);
        }
        void objCustomer_CustomerSelected(object sender, DataRow dataRow)
        {
            Adminrights = true;
            SetCustomer(dataRow);
            if (this.WorkOrderID > 0)
                this.getWorkOrder(this.WorkOrderID);
        }
        void btnCustomerList_Click(object sender, EventArgs e)
        {
            ctrCustomerList objCustomer = new ctrCustomerList();
            objCustomer.CustomerSelected += objCustomer_CustomerSelected;
            frmCtr frmCtr = new frmCtr("Customer ...");
            frmCtr.Height = objCustomer.Height + 20; frmCtr.Width = objCustomer.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objCustomer);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void getCustomer(int CustID)
        {
            DataRow CurrentRow = dbClass.obj.getCustomerByID(CustID);
            SetCustomer(CurrentRow);
        }
        void PaymentByAdmin()
        {
            DataTable dt = dbClass.obj.GetAdmins();
            cmbAdminRights.DataSource = dt;
            cmbAdminRights.DisplayMember = "Name";
            cmbAdminRights.ValueMember = "ID";
            cmbAdminRights.Visible = true;
            txtPassword.Visible = true;
            btnSubmit.Visible = true;
        }
        void SetCustomer(DataRow SelectedRow)
        {
            if (SelectedRow != null)
            {
                this.CustomerID = Convert.ToInt32(SelectedRow["ID"]);
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["CustomerID"] = Convert.ToInt32(SelectedRow["ID"]);
                curRow.EndEdit();

                ctrCustomer.Text = Convert.ToString(SelectedRow["FirstName"]) + " " + Convert.ToString(SelectedRow["LastName"]);
                CusCredit = dbClass.obj.GetCustomerCreditbyCustomerID(this.CustomerID);
                AvailableDeposit = dbClass.obj.getAvailableDepositbyCustomerID(this.CustomerID);
                txtAvailableDeposit.Text = Convert.ToString(AvailableDeposit);

                CreditLimit = dbClass.obj.getCreditLimitbyCustomerID(this.CustomerID);
                CreditAvail = dbClass.obj.getCreditAvailbyCustomerID(this.CustomerID);
                //txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit.ToString();
                txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit;


                //curRow["CusCredit"] = CusCredit;
                //SelectCusCredit = CusCredit;
                AvailableCredit = CreditLimit - CreditAvail;
                //if (AvailableCredit >= 0)
                //{
                    txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                //}
                lblCreditLimits.Text = "of $" + Convert.ToString(CreditLimit);
                if (InvoiceForCredit == true)
                {
                    //rdoCredit.Checked = true;
                    rdoPaid.Checked = false;
                    //rdoCredit.Enabled = false;
                    rdoPaid.Enabled = false;
                    //ClearControls();
                    //if (CreditAvail != 0)
                    //{
                    //    //txtInvoiceBalance.Text = "$" + CreditAvail;
                    //    txtInvoiceBalance.Text = String.Format("{0:c}", CreditAvail);

                    //}
                    //else
                    //{
                    //    txtInvoiceBalance.Text = "$0.00";
                    //}
                    txtInvoiceBalance.Text = StaticInfo.MainCurSign + this.WOAmount;
                    InvoiceForCredit = true;
                    Adminrights = true;
                }
                else if (InvoiceForCredit == false)
                {
                    if (txtWOAmount.Text != "")
                    {
                        //txtInvoiceBalance.Text = "$" + txtWOAmount.Text.Substring(1);
                        txtInvoiceBalance.Text = StaticInfo.MainCurSign + txtWOAmount.Text.Substring(1);

                    }
                    else
                    {
                        txtInvoiceBalance.Text = "$0.00";
                    }
                    //rdoCredit.Enabled = false;
                    rdoPaid.Enabled = false;
                }
                if (CreditLimit > 0 && EditInvoice == false && OverrideCreditLimit)
                {
                    btnChgOnAccount.Enabled = true;
                    //txtChgOnAccount.Enabled = true;
                    txtChgOnAccount.Enabled = false;
                }
                else
                {
                    btnChgOnAccount.Enabled = false;
                    txtChgOnAccount.Enabled = false;
                    //btnCreditBalance.Enabled = false;
                    //txtCreditBalance.Enabled = false;
                    Adminrights = true;
                    btnAdminRights.Visible = true;
                }
                //For Cheque Accepted OR Not
                if (!String.IsNullOrEmpty(Convert.ToString(SelectedRow["IsCheckAccepted"])))
                {
                    if (Adminrights == true && EditInvoice == false)
                    {
                        btnPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                        txtPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                        txtCheckNo.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                        txtDriversLic.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                    }
                }
                else
                {
                    btnAdminRights.Visible = true;
                }
                if (InvoiceForCredit == true)
                {
                    btnWorkOrderList.Enabled = false;
                    btnChgOnAccount.Enabled = false;
                    txtChgOnAccount.Enabled = false;
                    //btnCreditBalance.Enabled = false;
                    //txtCreditBalance.Enabled = false;
                    //rdoCredit.Checked = true;
                    rdoPaid.Checked = false;
                }
                //if (StaticInfo.EmployeeName == "Admin")
                //{
                //    ShowControls();
                //}
            }
        }
        void getWorkOrder(int WorkOrderID)
        {
            DataRow CurrentRow = dbClass.obj.getWorkOrderByID(WorkOrderID);
            SetWorkOrder(CurrentRow);
            if ((WOAmount - TotalWOAmount) > CreditLimit)
            {
                //if (StaticInfo.EmployeeName == "Admin")
                //    ShowControls();
                //else
                //    HideControls();
            }
        }
        //void setMultiWorkOrder(int ReceiptID)
        //{
        //    DataRowView curRow = (DataRowView)objBindingSource.Current;
        //    curRow.BeginEdit();
        //    curRow["WOIDs"] = WOIDs;
        //    curRow["InvoiceAmount"] = WOAmount;
        //    curRow["InvoiceBalance"] = WOAmount;
        //    curRow.EndEdit();

        //    txtWOAmount.Text = string.Format("{0:C}", WOAmount);
        //    txtWorkOrderID.Text = WOIDs.Remove(WOIDs.Length - 1, 1).Remove(0, 1);

        //    if (InvoiceForCredit == true)
        //    {
        //        txtInvoiceBalance.Text = "$" + Convert.ToString(Convert.ToDecimal(txtWOAmount.Text.Substring(1)) + CreditAvail);
        //    }
        //    else if (InvoiceForCredit == false)
        //    {
        //        txtInvoiceBalance.Text = "$" + txtWOAmount.Text.Substring(1);
        //    }
        //    txtTotalAmount.Text = txtWOAmount.Text;

        //    if ((WOAmount - TotalWOAmount) > CreditLimit)
        //    {
        //        if (StaticInfo.EmployeeName == "Admin")
        //            ShowControls();
        //        else
        //            HideControls();
        //    }
        //}
        void SetWorkOrder(DataRow SelectedRow)
        {
            if (SelectedRow != null && SelectedRow["ID"] != null)
            {
                if (Convert.ToInt32(SelectedRow["CustomerID"]) == this.CustomerID)
                {
                    //txtCusCredit.Text = SelectedRow["CusCredit"].ToString();
                    this.WorkOrderID = Convert.ToInt32(SelectedRow["ID"]);
                    txtWorkOrderID.Text = Convert.ToString(SelectedRow["WorkOrderNo"]);
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["WOID"] = WorkOrderID;
                    curRow["TotalReceivedAmount"] = Convert.ToString(SelectedRow["Total"]);
                    curRow.EndEdit();
                    WOAmount = Convert.ToDecimal(SelectedRow["Total"]);
                    txtWOAmount.Text = "$" + Convert.ToString(SelectedRow["Total"]);
                    WODate.DateTimePicker1.Value = Convert.ToDateTime(SelectedRow["RegDate"]);
                    if (InvoiceForCredit == true)
                    {
                        //txtInvoiceBalance.Text = "$" + Convert.ToString(Convert.ToDecimal(txtWOAmount.Text.Substring(1)) + CreditAvail);
                        txtInvoiceBalance.Text = StaticInfo.MainCurSign + Convert.ToString(Convert.ToDecimal(txtWOAmount.Text.Substring(1)) + CreditAvail);

                    }
                    else if (InvoiceForCredit == false)
                    {
                        //txtInvoiceBalance.Text = "$" + txtWOAmount.Text.Substring(1);
                        txtInvoiceBalance.Text = StaticInfo.MainCurSign + txtWOAmount.Text.Substring(1);

                    }
                    // txtTotalAmount.Text = txtWOAmount.Text;
                }
                else
                {
                    this.WorkOrderID = 0;
                    txtWorkOrderID.Text = "";
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["WOID"] = 0;
                    curRow.EndEdit();
                    WOAmount = 0;
                    txtWOAmount.Text = "";
                    WODate.DateTimePicker1.Value = DateTime.Now;
                }
            }
        }
        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string senderText = ((TATextBox)sender).Name.ToString().Trim();
                string txtName = senderText.Substring(3, senderText.Length - 3);
                objBindingSource.EndEdit();
                if (txtName == "ChgOnAccount")
                {
                    if (txtChgOnAccount.Text == "$0.00")
                    {
                        decimal _value1 = WOAmount - TotalWOAmount;
                        if (AvailableCredit > 0)
                        {
                            decimal _value2 = AvailableCredit - _value1;
                            if (_value2 > 0)
                            {
                                //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                //curRow["ChgOnAccount"] = StaticInfo.MainCurrencySign + _value2.ToString();
                                txtChgOnAccount.Text = "$" + Convert.ToString(_value2);
                                AvailableCredit = 0;
                            }
                            else
                            {
                                //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                                //curRow["ChgOnAccount"] = StaticInfo.MainCurrencySign + CreditAvail.ToString();
                                txtChgOnAccount.Text = "$" + Convert.ToString(AvailableCredit);
                                AvailableCredit = 0;
                            }
                        }
                    }
                    else
                    {
                        AvailableCredit = CreditLimit - CreditAvail;
                        decimal _value1 = Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                        if (AvailableCredit > _value1)
                        {
                            decimal _value2 = AvailableCredit - _value1;
                            //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                            //curRow["ChgOnAccount"] = StaticInfo.MainCurrencySign + _value1.ToString();
                            txtChgOnAccount.Text = _value1.ToString();
                            AvailableCredit = _value2;
                        }
                        else
                        {
                            //txtAvailableCredit.Text = StaticInfo.MainCurSign + "0";
                            //curRow["ChgOnAccount"] = StaticInfo.MainCurrencySign + AvailableCredit.ToString();
                            txtChgOnAccount.Text = AvailableCredit.ToString();
                            AvailableCredit = 0;
                        }
                        //curRow.EndEdit();
                    }
                }
                if (CalculateTotalAmount(Convert.ToDecimal(((TATextBox)sender).Text.Trim().Substring(1))) == false)
                {
                    //xMessageBox.Show("Invalid Amount...!","Warning");
                }
            }
        }
        void btnClear_Click(object sender, EventArgs e)
        {
            string senderText = ((TAButton)sender).Name.ToString().Trim();
            string txtName = senderText.Substring(8, senderText.Length - 8);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            if (txtName != "CreditBalance")
                curRow[txtName] = 0;
            if (txtName == "PayByCheck")
            {
                curRow["CheckNo"] = "";
                curRow["LicNo"] = "";
            }
            if (txtName == "CreditBalance")
            {
                decimal CusCreditUsed = 0;
                if (curRow["CusCredit"] != DBNull.Value)
                    CusCreditUsed = Convert.ToDecimal(curRow["CusCredit"]);
                CusCredit = CusCredit - CusCreditUsed;
                txtCusCredit.Text = StaticInfo.MainCurSign + CusCredit;
                //txtCusCredit.Text = String.Format("{0:c}", CusCredit);
                SelectCusCredit = 0;
                curRow["CusCredit"] = SelectCusCredit;
                //txtUsedCustomerCredit.Text = "$" + SelectCusCredit;                  
                txtCreditBalance.Text = StaticInfo.MainCurSign + SelectCusCredit;
            }
            if (txtName == "ChgOnAccount")
            {
                if (txtChgOnAccount.Text == "$0.00")
                {
                    AvailableCredit = CreditLimit - CreditAvail;
                    txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                }
                else
                {
                    AvailableCredit += SelectAvailableCredit;
                    //AvailableCredit += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                    txtAvailableCredit.Text = StaticInfo.MainCurSign + AvailableCredit;
                    CreditAvail = CreditLimit - AvailableCredit;
                }
            }
            curRow.EndEdit();
            if (InvoiceForCredit == true)
            {
                //decimal balance  = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                //                          NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
                //txtInvoiceBalance.Text = "$" + (CreditAvail - Convert.ToDecimal(txtTotalAmount.Text.Substring(1))).ToString();
                //txtInvoiceBalance.Text = String.Format("{0:c}", (CreditAvail - Convert.ToDecimal(txtTotalAmount.Text.Substring(1))));
                //txtInvoiceBalance.Text = String.Format("{0:c}", WOAmount);
                //txtTotalAmount.Text = String.Format("{0:c}", WOAmount - balance);
                txtInvoiceBalance.Text = StaticInfo.MainCurSign + txtWOAmount.Text.Substring(1);
                CalculateTotalAmount();
            }
            else if (InvoiceForCredit == false)
            {
                //txtInvoiceBalance.Text = "$" + txtWOAmount.Text.Substring(1);
                txtInvoiceBalance.Text = StaticInfo.MainCurSign + txtWOAmount.Text.Substring(1);

                CalculateTotalAmount();
            }
        }
    }
}
