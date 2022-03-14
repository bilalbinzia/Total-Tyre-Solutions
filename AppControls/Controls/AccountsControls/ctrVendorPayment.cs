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

namespace AppControls
{
    public partial class ctrVendorPayment : BaseControl
    {
        Int32 CustomerID = 0;
        Int32 VendorID = 0;
        Int32 PaymentID = 0;
        Int32 VendorBillID = 0;
        DataTable TempPayment = new DataTable();
        string VendorBillIDs = "";
        decimal VBAmount = 0;
        decimal TotalVBAmount = 0;
        decimal CreditAvail = 0;
        decimal AvailableDeposit = 0;
        decimal CreditLimit = 0;
        bool MultiBills = false;
        bool BillForCredit = false;
        bool Focus = true;
        public ctrVendorPayment()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrVendorPayment(string VBIDs, int VenID, DataTable TempPayment)
        {
            InitializeComponent();
            InitializeComponent1();

            this.TempPayment = TempPayment;
            this.MultiBills = true;
            this.VendorID = VenID;
            this.VendorBillIDs = VBIDs;
            //foreach(DataRow row in TempPayment.Rows)
            //{
            //    row["BillBalance"] = row["BillAmount"];
            //}

        }
        void InitializeComponent1()
        {
            this.Load += ctrVendorPayment_Load;

            btnVendorList.Click += btnVendorList_Click;
            btnVendorBillList.Click += btnVendorBillList_Click;
            btnVendorTerms.Click += btnVendor_Click;
            btnAdminRights.Click += btnAdminRights_Click;
            btnSubmit.Click += btnSubmit_Click;
            // btnClearChgOnAccount.Click += btnClear_Click;
            btnClearPayByCash.Click += btnClear_Click;
            btnClearPayByCheck.Click += btnClear_Click;
            // btnClearPayByDeposit.Click += btnClear_Click;
            btnClearPayByVISA.Click += btnClear_Click;
            btnClearPayByMC.Click += btnClear_Click;
            btnClearPayByAMEX.Click += btnClear_Click;
            btnClearPayByATM.Click += btnClear_Click;
            btnClearPayByGY.Click += btnClear_Click;
            btnClearPayByDSCVR.Click += btnClear_Click;

            // txtChgOnAccount.KeyDown += textBox_KeyDown;
            txtPayByCash.KeyDown += textBox_KeyDown;
            txtPayByCheck.KeyDown += textBox_KeyDown;
            // txtPayByDeposit.KeyDown += textBox_KeyDown;
            txtPayByVISA.KeyDown += textBox_KeyDown;
            txtPayByMC.KeyDown += textBox_KeyDown;
            txtPayByAMEX.KeyDown += textBox_KeyDown;
            txtPayByATM.KeyDown += textBox_KeyDown;
            txtPayByGY.KeyDown += textBox_KeyDown;
            txtPayByDSCVR.KeyDown += textBox_KeyDown;

            // txtChgOnAccount.LostFocus += textBox_LostFocus;
            txtPayByCash.LostFocus += textBox_LostFocus;
            txtPayByCheck.LostFocus += textBox_LostFocus;
            // txtPayByDeposit.LostFocus += textBox_LostFocus;
            txtPayByVISA.LostFocus += textBox_LostFocus;
            txtPayByMC.LostFocus += textBox_LostFocus;
            txtPayByAMEX.LostFocus += textBox_LostFocus;
            txtPayByATM.LostFocus += textBox_LostFocus;
            txtPayByGY.LostFocus += textBox_LostFocus;
            txtPayByDSCVR.LostFocus += textBox_LostFocus;

            //txtChgOnAccount.KeyDown += textBox_Leave;
            //txtPayByCash.KeyDown += textBox_LostFocus;
            //txtPayByCheck.KeyDown += textBox_Leave;
            //txtPayByDeposit.KeyDown += textBox_Leave;
            //txtPayByVISA.KeyDown += textBox_Leave;
            //txtPayByMC.KeyDown += textBox_Leave;
            //txtPayByAMEX.KeyDown += textBox_Leave;
            //txtPayByATM.KeyDown += textBox_Leave;
            //txtPayByGY.KeyDown += textBox_Leave;
            //txtPayByDSCVR.KeyDown += textBox_Leave;

            // btnChgOnAccount.Click += btnClick_Click;
            btnPayByCash.Click += btnClick_Click;
            btnPayByCheck.Click += btnClick_Click;
            // btnPayByDeposit.Click += btnClick_Click;
            btnPayByVISA.Click += btnClick_Click;
            btnPayByMC.Click += btnClick_Click;
            btnPayByAMEX.Click += btnClick_Click;
            btnPayByATM.Click += btnClick_Click;
            btnPayByGY.Click += btnClick_Click;
            btnPayByDSCVR.Click += btnClick_Click;
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrVendor", "Vendor Details", 0);
            ctrVendor objList = new ctrVendor();
            frmCtr frmCtr = new frmCtr("Vendor Payment");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
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

                                    //dt.Columns.Add("ChgOnAccount", typeof(decimal));
                                    dt.Columns.Add("PayByCash", typeof(decimal));
                                    dt.Columns.Add("PaybyCheck", typeof(decimal));
                                    dt.Columns.Add("CheckNo", typeof(string));
                                    dt.Columns.Add("LicNo", typeof(string));
                                    //dt.Columns.Add("PayByDeposit", typeof(decimal));
                                    dt.Columns.Add("PayByVisa", typeof(decimal));
                                    dt.Columns.Add("PayByMC", typeof(decimal));
                                    dt.Columns.Add("PayByAMEX", typeof(decimal));
                                    dt.Columns.Add("PayByATM", typeof(decimal));
                                    dt.Columns.Add("PayByGY", typeof(decimal));
                                    dt.Columns.Add("PayByDSCVR", typeof(decimal));

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
                                    dtrow["WOID"] = this.VendorBillID;
                                    dtrow["InvoiceNo"] = Convert.ToDecimal(txtInvoiceNo.Text);
                                    dtrow["TrnsDate"] = DateTime.Now;
                                    dtrow["TrnsNotes"] = txtTrnsNotes.Text;

                                    //dtrow["ChgOnAccount"] = Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                                    dtrow["PayByCash"] = Convert.ToDecimal(txtPayByCash.Text.Substring(1));
                                    dtrow["PaybyCheck"] = Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
                                    dtrow["CheckNo"] = txtCheckNo.Text;
                                    dtrow["LicNo"] = txtDriversLic.Text;
                                    //dtrow["PayByDeposit"] = Convert.ToDecimal(txtPayByDeposit.Text.Substring(1));
                                    dtrow["PayByVisa"] = Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
                                    dtrow["PayByMC"] = Convert.ToDecimal(txtPayByMC.Text.Substring(1));
                                    dtrow["PayByAMEX"] = Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
                                    dtrow["PayByATM"] = Convert.ToDecimal(txtPayByATM.Text.Substring(1));
                                    dtrow["PayByGY"] = Convert.ToDecimal(txtPayByGY.Text.Substring(1));
                                    dtrow["PayByDSCVR"] = Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));

                                    dtrow["TotalReceivedAmount"] = this.VBAmount;
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
                                        CreditLimit = (VBAmount - TotalVBAmount) + 100;
                                        ShowControls();
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
            cmbAdminRights.Visible = false;
            txtPassword.Visible = false;
            btnSubmit.Visible = false;

            // btnChgOnAccount.Enabled = true;
            // txtChgOnAccount.Enabled = true;

            btnPayByCheck.Enabled = true;
            txtPayByCheck.Enabled = true;
            txtCheckNo.Enabled = true;
            txtDriversLic.Enabled = true;

            //btnPayByDeposit.Enabled = true;
            //txtPayByDeposit.Enabled = true;

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
        void HideControls()
        {
            cmbAdminRights.Visible = false;
            txtPassword.Visible = false;
            btnSubmit.Visible = false;

            //btnChgOnAccount.Enabled = false;
            //txtChgOnAccount.Enabled = false;

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
            if (this.VendorID != 0 && this.VBAmount != 0)
            {
                PaymentByAdmin();
            }
            else
            {
                xMessageBox.Show("Vendor Bill amount is empty...");
            }
        }
        bool Adminrights = false;
        void ctrVendorPayment_Load(object sender, EventArgs e)
        {
            bool ChangeDate = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '011'");
            if (row[0]["CanView"] != DBNull.Value)
                ChangeDate = Convert.ToBoolean(row[0]["CanView"]);

            if (ChangeDate)
                tpPaymentDate.Enabled = true;
            else
                tpPaymentDate.Enabled = false;

            chkBoxIsAutoPrint.Checked = true;
            cmbAdminRights.Visible = false;
            txtPassword.Visible = false;
            btnSubmit.Visible = false;
            if ((this.VendorID > 0) && (TempPayment.Rows.Count > 0))
            {
                Adminrights = true;
                bindingNavigatorAddNewItem_Click(sender, e);
                Focus = false;

                //DataTable dt = dbClass.obj.getVendorPaymentTempTopByVendorIDAndBillID(objDataSet.Tables["VendorPaymentHistory"], this.VendorID, this.VendorBillIDs);
                ////foreach (System.Data.DataColumn col in dt.Columns) col.ReadOnly = false;
                ////dt.Rows[0]["ID"] = -1;
                ////dt.Rows[0]["IsLocked"] = false;

                //dt.Rows[0]["BillBalance"] = 0;
                //dt.Rows[0]["ChgOnAccount"] = 0;
                //dt.Rows[0]["PayByCash"] = 0;
                //dt.Rows[0]["PaybyCheck"] = 0;
                //dt.Rows[0]["PayByDeposit"] = 0;
                //dt.Rows[0]["PayByVisa"] = 0;
                //dt.Rows[0]["PayByMC"] = 0;
                //dt.Rows[0]["PayByAMEX"] = 0;
                //dt.Rows[0]["PayByATM"] = 0;
                //dt.Rows[0]["PayByGY"] = 0;
                //dt.Rows[0]["PayByDSCVR"] = 0;

                //base.bindingNavigatorAddNewItem_Click(sender, e);
                //this.objBindingSource.DataSource = dt; //CurrentDt;  dt.Rows[0]
                //if (dt.Rows.Count > 0)
                //{
                //    Adminrights = false;
                //    if (this.VendorID > 0)
                //        this.getVendor(this.VendorID);

                //    if (!String.IsNullOrEmpty(this.VendorBillIDs))
                //        this.getVendorBill(this.VendorBillIDs);

                //    Focus = false;

                //    //txtChgOnAccount.Enabled= true;
                //    //txtPayByCash.Enabled = true;
                //    //txtPayByCheck.Enabled = true;
                //    //txtPayByDeposit.Enabled = true;
                //    //txtPayByVISA.Enabled = true;
                //    //txtPayByMC.Enabled = true;
                //    //txtPayByAMEX.Enabled = true;
                //    //txtPayByATM.Enabled = true;
                //    //txtPayByGY.Enabled = true;
                //    //txtPayByDSCVR.Enabled = true;
                //}
                //else
                //{
                //    Adminrights = true;
                //    bindingNavigatorAddNewItem_Click(sender, e);

                //    //bindingNavigatorEditItem_Click(sender, e);
                //}
            }
        }

        void btnClick_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (BillForCredit == false)
            {
                //string.IsNullOrEmpty(txtChgOnAccount.Text) ||
                if (string.IsNullOrEmpty(txtPayByCash.Text) || string.IsNullOrEmpty(txtPayByCheck.Text) || string.IsNullOrEmpty(txtPayByVISA.Text))
                {
                    TotalVBAmount = 0;
                    //if (txtChgOnAccount.Text != "$0.00")
                    //{
                    //    TotalVBAmount += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
                    //}
                    if (txtPayByCash.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByCash.Text.Substring(1));
                    }
                    if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
                    }
                    if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
                    }
                    if (txtPayByVISA.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
                    }
                    if (txtPayByMC.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByMC.Text.Substring(1));
                    }
                    if (txtPayByAMEX.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
                    }
                    if (txtPayByATM.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByATM.Text.Substring(1));
                    }
                    if (txtPayByGY.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByGY.Text.Substring(1));
                    }
                    if (txtPayByDSCVR.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
                    {
                        TotalVBAmount += Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));
                    }
                }
                if (VBAmount > 0 && TotalVBAmount < VBAmount)
                {
                    txtTotalAmount.Text = "$" + TotalVBAmount.ToString();
                    txtTotalBalance.Text = "$" + (VBAmount - TotalVBAmount).ToString();
                    string btnName = ((TAButton)sender).Name.Trim();
                    switch (btnName)
                    {
                        //case "btnChgOnAccount":
                        //    if (txtChgOnAccount.Text == "$0.00")
                        //    {
                        //        txtChgOnAccount.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                        //    }
                        //    else
                        //    {
                        //        curRow.BeginEdit();
                        //        curRow["ChgOnAccount"] = txtChgOnAccount.Text.Substring(1);
                        //        curRow.EndEdit();
                        //    }
                        //    //txtChgOnAccount.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                        //    break;
                        case "btnPayByCash":
                            if (txtPayByCash.Text == "$0.00")
                            {
                                txtPayByCash.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByCash"] = txtPayByCash.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByCheck":
                            //txtPayByCheck.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByCheck.Text == "$0.00")
                            {
                                txtPayByCheck.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByCheck"] = txtPayByCheck.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        //case "btnPayByDeposit":
                        //    //txtPayByDeposit.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                        //    if (txtPayByDeposit.Text == "$0.00")
                        //    {
                        //        txtPayByDeposit.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                        //    }
                        //    else
                        //    {
                        //        curRow.BeginEdit();
                        //        curRow["PayByDeposit"] = txtPayByDeposit.Text.Substring(1);
                        //        curRow.EndEdit();
                        //    }
                        //    break;
                        case "btnPayByVISA":
                            //txtPayByVISA.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByVISA.Text == "$0.00")
                            {
                                txtPayByVISA.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByVISA"] = txtPayByVISA.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByMC":
                            //txtPayByMC.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByMC.Text == "$0.00")
                            {
                                txtPayByMC.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByMC"] = txtPayByMC.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByAMEX":
                            //txtPayByAMEX.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByAMEX.Text == "$0.00")
                            {
                                txtPayByAMEX.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByAMEX"] = txtPayByAMEX.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByATM":
                            //txtPayByATM.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByATM.Text == "$0.00")
                            {
                                txtPayByATM.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByATM"] = txtPayByATM.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByGY":
                            //txtPayByGY.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByGY.Text == "$0.00")
                            {
                                txtPayByGY.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            }
                            else
                            {
                                curRow.BeginEdit();
                                curRow["PayByGY"] = txtPayByGY.Text.Substring(1);
                                curRow.EndEdit();
                            }
                            break;
                        case "btnPayByDSCVR":
                            //txtPayByDSCVR.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
                            if (txtPayByDSCVR.Text == "$0.00")
                            {
                                txtPayByDSCVR.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
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
                else
                {
                    if (TotalVBAmount == VBAmount)
                    {

                    }
                    else
                    {
                        xMessageBox.Show("Invalid Amount...!", "Warning");
                    }
                }
            }
            //else if (InvoiceForCredit == true)
            //{
            //    if (txtChgOnAccount.Text != "" || txtPayByCash.Text != "" || txtPayByCheck.Text != "" || txtPayByVISA.Text != "")
            //    {
            //        TotalVBAmount = 0;
            //        if (txtChgOnAccount.Text != "$0.00")
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
            //        }
            //        if (txtPayByCash.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByCash.Text.Substring(1));
            //        }
            //        if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
            //        }
            //        if (txtPayByCheck.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
            //        }
            //        if (txtPayByVISA.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
            //        }
            //        if (txtPayByMC.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByMC.Text.Substring(1));
            //        }
            //        if (txtPayByAMEX.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByAMEX.Text.Substring(1));
            //        }
            //        if (txtPayByATM.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByATM.Text.Substring(1));
            //        }
            //        if (txtPayByGY.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByGY.Text.Substring(1));
            //        }
            //        if (txtPayByDSCVR.Text != "$0.00" && Convert.ToDecimal(txtTotalAmount.Text.Substring(1)) <= VBAmount)
            //        {
            //            TotalVBAmount += Convert.ToDecimal(txtPayByDSCVR.Text.Substring(1));
            //        }
            //    }
            //    if (VBAmount > 0 && TotalVBAmount < VBAmount)
            //    {
            //        txtTotalAmount.Text = "$" + TotalVBAmount.ToString();
            //        txtTotalBalance.Text = "$" + (VBAmount - TotalVBAmount).ToString();
            //        string btnName = ((TAButton)sender).Name.Trim();
            //        switch (btnName)
            //        {
            //            case "btnChgOnAccount":
            //                if (txtChgOnAccount.Text == "$0.00")
            //                {
            //                    txtChgOnAccount.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["ChgOnAccount"] = txtChgOnAccount.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                //txtChgOnAccount.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                break;
            //            case "btnPayByCash":
            //                if (txtPayByCash.Text == "$0.00")
            //                {
            //                    txtPayByCash.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByCash"] = txtPayByCash.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByCheck":
            //                //txtPayByCheck.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByCheck.Text == "$0.00")
            //                {
            //                    txtPayByCheck.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByCheck"] = txtPayByCheck.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByDeposit":
            //                //txtPayByDeposit.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByDeposit.Text == "$0.00")
            //                {
            //                    txtPayByDeposit.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByDeposit"] = txtPayByDeposit.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByVISA":
            //                //txtPayByVISA.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByVISA.Text == "$0.00")
            //                {
            //                    txtPayByVISA.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByVISA"] = txtPayByVISA.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByMC":
            //                //txtPayByMC.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByMC.Text == "$0.00")
            //                {
            //                    txtPayByMC.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByMC"] = txtPayByMC.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByAMEX":
            //                //txtPayByAMEX.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByAMEX.Text == "$0.00")
            //                {
            //                    txtPayByAMEX.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByAMEX"] = txtPayByAMEX.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByATM":
            //                //txtPayByATM.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByATM.Text == "$0.00")
            //                {
            //                    txtPayByATM.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByATM"] = txtPayByATM.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByGY":
            //                //txtPayByGY.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByGY.Text == "$0.00")
            //                {
            //                    txtPayByGY.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                }
            //                else
            //                {
            //                    curRow.BeginEdit();
            //                    curRow["PayByGY"] = txtPayByGY.Text.Substring(1);
            //                    curRow.EndEdit();
            //                }
            //                break;
            //            case "btnPayByDSCVR":
            //                //txtPayByDSCVR.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
            //                if (txtPayByDSCVR.Text == "$0.00")
            //                {
            //                    txtPayByDSCVR.Text = "$" + Convert.ToString(VBAmount - TotalVBAmount);
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
            //        if (TotalVBAmount == VBAmount) { }
            //        else
            //        {
            //            xMessageBox.Show("Invalid Amount...!", "Warning");
            //        }
            //    }
            //}
        }

        //void btnClick_Click(object sender, EventArgs e)
        //{
        //    if (txtChgOnAccount.Text != "" || txtPayByCash.Text != "" || txtPayByCheck.Text != "" || txtPayByVISA.Text != "")
        //    {
        //        if (Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //        {
        //            if (txtChgOnAccount.Text != "")
        //            {
        //                TotalVBAmount += Convert.ToDecimal(txtChgOnAccount.Text.Substring(1));
        //            }
        //            if (txtPayByCash.Text != "" && Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //            {
        //                TotalVBAmount += Convert.ToDecimal(txtPayByCash.Text.Substring(1));
        //            }
        //            if (txtPayByCheck.Text != "" && Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //            {
        //                TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
        //            }
        //            if (txtPayByCheck.Text != "" && Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //            {
        //                TotalVBAmount += Convert.ToDecimal(txtPayByCheck.Text.Substring(1));
        //            }
        //            if (txtPayByVISA.Text != "" && Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //            {
        //                TotalVBAmount += Convert.ToDecimal(txtPayByVISA.Text.Substring(1));
        //            }
        //        }
        //    }
        //    //TotalVBAmount = VBAmount - Convert.ToDecimal(txtTotalAmount.Text);
        //    if (VBAmount > 0 && Convert.ToDecimal(txtTotalBalance.Text.Substring(1)) != VBAmount)
        //    {
        //        string btnName = ((TAButton)sender).Name.Trim();
        //        switch (btnName)
        //        {
        //            case "btnChgOnAccount":
        //                if ((VBAmount - TotalVBAmount) > CreditLimit)
        //                {
        //                    PaymentByAdmin();
        //                    cmbAdminRights.Focus();
        //                    HideControls();
        //                }
        //                else
        //                {
        //                    cmbAdminRights.Visible = false;
        //                    txtPassword.Visible = false;
        //                    btnSubmit.Visible = false;

        //                    ShowControls();
        //                    txtChgOnAccount.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                }
        //                if (AvailableDeposit > VBAmount)
        //                {
        //                    btnPayByDeposit.Enabled = true;
        //                    txtPayByDeposit.Enabled = true;
        //                }
        //                else
        //                {
        //                    btnPayByDeposit.Enabled = true;
        //                    txtPayByDeposit.Enabled = true;
        //                }
        //                break;
        //            case "btnPayByCash":
        //                txtPayByCash.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByCheck":
        //                if ((VBAmount - TotalVBAmount) > CreditLimit)
        //                {
        //                    PaymentByAdmin();
        //                    cmbAdminRights.Focus();
        //                    HideControls();
        //                }
        //                else
        //                {
        //                    cmbAdminRights.Visible = false;
        //                    txtPassword.Visible = false;
        //                    btnSubmit.Visible = false;

        //                    ShowControls();
        //                    txtPayByCheck.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                }
        //                break;
        //            case "btnPayByDeposit":
        //                txtPayByDeposit.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByVISA":
        //                txtPayByVISA.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByMC":
        //                txtPayByMC.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByAMEX":
        //                txtPayByAMEX.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByATM":
        //                txtPayByATM.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByGY":
        //                txtPayByGY.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //            case "btnPayByDSCVR":
        //                txtPayByDSCVR.Text = Convert.ToString(VBAmount - TotalVBAmount);
        //                break;
        //        }
        //        CalculateTotalAmount();
        //    }
        //}

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);

            if (this.VendorID > 0)
                this.getVendor(this.VendorID);

            if (TempPayment.Rows.Count > 0)
                this.getVendorBill();

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            //EnablePaymentMethods();

            int NextAutoNo = dbClass.obj.getNextVendorPaymentAutoNo();
            curRow["PaymentID"] = NextAutoNo;
            curRow["InvoiceNo"] = NextAutoNo + 1000;

            if (this.MultiBills)
            {
                //curRow["PaymentID"] = this.PaymentID;               
                //curRow["InvoiceNo"] = this.PaymentID + 1000;

                btnVendorBillList.Enabled = false;
                btnVendorList.Enabled = false;

            }
            else
            {
                if (this.VendorBillID > 0)
                    curRow["BillIDs"] = this.VendorBillID;
                else
                    curRow["BillIDs"] = DBNull.Value;
            }

            curRow["TrnsDate"] = DateTime.Now;
            if (this.VendorID > 0)
                curRow["VendorID"] = this.VendorID;
            else
                curRow["VendorID"] = DBNull.Value;


            curRow["IsPaid"] = true;
            //curRow["IsDeposit"] = false;
            //curRow["IsCredit"] = false;

            //curRow["PayByDeposit"] = 0;
            //curRow["PayByVisa"] = 0;
            //curRow["PayByMC"] = 0;
            //curRow["PayByAMEX"] = 0;
            //curRow["PayByATM"] = 0;
            //curRow["PayByGY"] = 0;
            //curRow["PayByDSCVR"] = 0;
            curRow["PaidAmount"] = 0;

            curRow.EndEdit();

            txtDriversLic.Enabled = false;
            txtCheckNo.Enabled = false;
            //txtChgOnAccount.Enabled = true;
            txtPayByCheck.Enabled = true;
            //txtPayByDeposit.Enabled = true;
            //btnPayByDeposit.Enabled = true;
            //btnClearPayByDeposit.Enabled = true;
            //------------------------------------
            base.DataNavigation();
            Focus = false;
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {

            base.bindingNavigatorEditItem_Click(sender, e);

            if (MultiBills)
            {
                btnVendorBillList.Enabled = false;
                btnVendorList.Enabled = false;
                // txtChgOnAccount.Enabled = true;
                txtPayByCheck.Enabled = true;
                // txtPayByDeposit.Enabled = false;
                // btnPayByDeposit.Enabled = false;
                //btnClearPayByDeposit.Enabled = false;

                //txtChgOnAccount.Text = "$0.00";
                txtPayByCash.Text = "$0.00";
                txtPayByCheck.Text = "$0.00";
                // txtPayByDeposit.Text = "$0.00";
                txtPayByVISA.Text = "$0.00";
                txtPayByMC.Text = "$0.00";
                txtPayByAMEX.Text = "$0.00";
                txtPayByATM.Text = "$0.00";
                txtPayByGY.Text = "$0.00";
                txtPayByDSCVR.Text = "$0.00";

                Focus = false;
            }

        }

        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            Focus = true;
            base.bindingNavigatorCancelItem_Click(sender, e);
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (MultiBills)
            {
                if (TotalVBAmount < VBAmount)
                {
                    xMessageBox.Show("Multiple Bills can't be processed with open amount ...");
                    return;
                }
            }
            //curRow[]
            if ((curRow["VendorID"] == DBNull.Value) || (Convert.ToInt32(curRow["VendorID"]) <= 0))
            {
                xMessageBox.Show("Add Vendor for this Vendor Bill ...");
                return;
            }
            //if ((curRow["BillIDs"] == DBNull.Value) || (Convert.ToInt32(curRow["BillIDs"]) <= 0))
            //{
            //    if (xMessageBox.Show("Do you save this receipt without Bill....?", "Vendor Payment..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
            //        return;
            //}
            if (Convert.ToDecimal(curRow["BillAmount"]) <= 0)
            {
                xMessageBox.Show("Bill amount must be greater then 0 ...");
                return;
            }
            //decimal totalCreditAvail = Convert.ToDecimal(curRow["ChgOnAccount"]) + CreditAvail;
            //if (txtPayByCash.Text == "")
            //{
            //    if (totalCreditAvail > CreditLimit)
            //    {
            //        if (xMessageBox.Show("this will take them over their credit limit by $" + totalCreditAvail + ". Are you sure.?", "Vendor Payment..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
            //            save(sender, e);
            //    }
            //    else
            //    {
            //        save(sender, e);
            //    }
            //}
            //else
            //{
            save(sender, e);
            //}
        }
        void save(object sender, EventArgs e)
        {
            bool Paid = false;
            string BillType = "";
            int BillID = 0;
            decimal PaidAmount = 0, BillBalance = 0, BillAmount = 0;
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            //int PaymentID = dbClass.obj.getNextVendorPaymentAutoNo();

            if (MultiBills)
            {
                //curRow["ID"] = -1;
                curRow["BillIDs"] = this.VendorBillIDs;
                this.PaymentID = Convert.ToInt32(curRow["PaymentID"]);
                base.bindingNavigatorSaveItem_Click(sender, e);
                if (CustomValidation(true))
                {
                    //DataTable dt = dbClass.obj.getVendorPaymentTempByVendorIDAndPaymentID(objDataSet.Tables["VendorPaymentHistory"], this.VendorID, this.PaymentID);
                    foreach (DataRow dr in TempPayment.Rows)
                    {
                        BillID = Convert.ToInt32(dr["BillID"]);
                        PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                        BillBalance = Convert.ToDecimal(dr["BillBalance"]);
                        BillAmount = Convert.ToDecimal(dr["BillAmount"]);

                        if (BillAmount > PaidAmount)
                        {
                            BillType = "B";
                            Paid = false;
                        }
                        else
                        {
                            BillType = "P";
                            Paid = true;
                        }
                        dbClass.obj.AddVendorPayment(PaymentID, this.VendorID, BillID, (PaymentID + 1000).ToString(), DateTime.Now, "", "", BillAmount, 0, PaidAmount, BillBalance, Paid);

                        //dbClass.obj.UpdateVendorBill(BillID, 0, PaidAmount, BillBalance, true, BillType);
                    }

                    StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentHistoryReport", "", this.PaymentID);
                    //dbClass.obj.UpdateVendorPaymentTemp(PaymentID);
                    //dbClass.obj.DeleteVendorPaymentTemp(this.VendorID, this.VendorBillIDs);

                    bool status = UpdateLedgerDetails();
                    if (status == false)
                    {
                        xMessageBox.Show("Ledger is not updated successfully....!");
                    }

                    //this.Parent.Parent.Parent.Dispose();
                    this.ParentForm.Close();

                }

            }
            else
            {
                PaidAmount = TotalVBAmount;
                if (curRow["PaymentID"] != DBNull.Value)
                    PaymentID = Convert.ToInt32(curRow["PaymentID"]);

                curRow["BillIDs"] = "," + this.VendorBillID + ",";
                BillAmount = VBAmount;
                BillBalance = VBAmount - TotalVBAmount;

                if (TotalVBAmount < VBAmount)
                {
                    BillType = "B";
                    Paid = false;
                }
                else
                {
                    BillType = "P";
                    Paid = true;
                }

                base.bindingNavigatorSaveItem_Click(sender, e);

                if (CustomValidation(true))
                {
                    //dbClass.obj.AddVendorPaymentTemp(PaymentID, this.VendorID, this.VendorBillID, (PaymentID + 1000).ToString(), DateTime.Now, "", "", BillAmount, 0, PaidAmount, BillBalance, true);                    
                    dbClass.obj.AddVendorPayment(PaymentID, this.VendorID, this.VendorBillID, (PaymentID + 1000).ToString(), DateTime.Now, "", "", BillAmount, 0, PaidAmount, BillBalance, Paid);
                    //dbClass.obj.UpdateVendorBill(this.VendorBillID, 0, PaidAmount, BillBalance, true, BillType);
                    StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentHistoryReport", "", this.PaymentID);

                    bool status = UpdateLedgerDetails();
                    if (status == false)
                    {
                        xMessageBox.Show("Ledger is not updated successfully....!");
                    }
                    //xMessageBox.Show("Data Saved Successfully ...");
                    //this.Parent.Parent.Parent.Dispose();
                    this.ParentForm.Close();
                }
            }

            //if (CustomValidation(true))
            //{
            //if (chkBoxIsAutoPrint.Checked)
            //{
            //    if (this.VendorBillID > 0)
            //    {
            //        StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportCustomerCopy", "byID", VendorBillID);
            //        StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportStoreCopy", "byID", VendorBillID);
            //        StaticInfo.LoadToReport("RptModule", "Reports.WorkOrderReportWareHouse", "byID", VendorBillID);
            //    }
            //}
            // this.Parent.Parent.Parent.Dispose();
            // xMessageBox.Show("Data Saved Successfully ...");
            // }
        }

        bool UpdateLedgerDetails()
        {
            bool status = false;
            dbClass db = new dbClass();
            string vID = db.getNextVoucherNo();
            DataTable Paymentdt = db.GetVendorPaymentHistorForVoucher(this.PaymentID);
            DataTable dtSaleAccounts = db.GetAccountsList(2, 0);
            DataTable vdt = objDataSet.Tables["AccountVoucher"].Copy();

            try
            {
                if (Paymentdt.Rows.Count == 1)
                {
                    DataRow dtnRow = vdt.NewRow();
                    dtnRow["vNo"] = vID;
                    dtnRow["vTypeID"] = Convert.ToInt32(Paymentdt.Rows[0]["vTypeID"]);
                    dtnRow["vDate"] = Convert.ToDateTime(Paymentdt.Rows[0]["TrnsDate"]);
                    dtnRow["AccountID"] = 2;
                    dtnRow["InvoiceID"] = Convert.ToInt32(Paymentdt.Rows[0]["PaymentID"]);
                    dtnRow["PID"] = Convert.ToInt32(Paymentdt.Rows[0]["InvoiceNo"]);
                    dtnRow["vforVendor"] = 1;
                    dtnRow["vforCustomer"] = 0;
                    dtnRow["vforEmployee"] = 0;
                    dtnRow["CustomerID"] = this.CustomerID;
                    //dtnRow["CustomerID"] = this.CustomerID;
                    dtnRow["VendorID"] = this.VendorID;
                    dtnRow["Narration"] = "Purchase Voucher";
                    dtnRow["TPAmount"] = Paymentdt.Rows[0]["PaidAmount"];
                    //dtnRow["TLAmount"] =;
                    //dtnRow["TFET"] = Paymentdt.Rows[0]["FET"];
                    //dtnRow["TTaxable"] = Paymentdt.Rows[0]["Taxable"];
                    //dtnRow["TTax"] = Paymentdt.Rows[0]["Tax"];
                    dtnRow["TDiscount"] = Paymentdt.Rows[0]["BillDiscount"];
                    dtnRow["TotalAmount"] = Paymentdt.Rows[0]["PaidAmount"];
                    dtnRow["PaidAmount"] = Paymentdt.Rows[0]["PaidAmount"];
                    dtnRow["BillBalance"] = Paymentdt.Rows[0]["BillBalance"];
                    dtnRow["AmountIn"] = 0;
                    dtnRow["AmountOut"] = 1;
                    dtnRow["TrnsNotes"] = Paymentdt.Rows[0]["TrnsNotes"];
                    dtnRow["PayByCash"] = Convert.ToDecimal(Paymentdt.Rows[0]["PayByCash"]);
                    dtnRow["PaybyBank"] = Convert.ToDecimal(Paymentdt.Rows[0]["PaybyCheck"]) + Convert.ToDecimal(Paymentdt.Rows[0]["PayByVisa"]) + Convert.ToDecimal(Paymentdt.Rows[0]["PayByAMEX"]) + Convert.ToDecimal(Paymentdt.Rows[0]["PayByATM"]) + Convert.ToDecimal(Paymentdt.Rows[0]["PayByDSCVR"]) + Convert.ToDecimal(Paymentdt.Rows[0]["PayByMC"]);
                    dtnRow["Payable"] = Paymentdt.Rows[0]["BillBalance"];
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

            DataTable PaymentDdt = new DataTable();
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

            PaymentDdt = db.GetVendorPaymentForVoucherDetails(this.PaymentID);
            vddt = objDataSet.Tables["AccountVoucherDetails"].Copy();

            DataRow PartRow = vddt.NewRow();
            DataRow WheelRow = vddt.NewRow();
            DataRow TireRow = vddt.NewRow();
            DataRow LabRow = vddt.NewRow();
            DataRow FeesRow = vddt.NewRow();
            DataRow OtherRow = vddt.NewRow();

            int PartQty = 0; decimal PartAmount = 0; decimal PartDiscAmount = 0; decimal PartProfit = 0; decimal PartFET = 0; decimal PartTax = 0;
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
            try
            {
                for (int i = 0; i < PaymentDdt.Rows.Count; i++)
                {
                    if (PaymentDdt.Rows[i]["Initial"].ToString() == "Par" || PaymentDdt.Rows[i]["Initial"].ToString() == "Lub")
                    {
                        PartRow["MID"] = vID;
                        PartRow["vTypeID"] = 2;
                        PartRow["vDate"] = DateTime.Now;
                        PartRow["InvoiceID"] = Paymentdt.Rows[0]["InvoiceNo"];
                        PartRow["PID"] = PaymentDdt.Rows[i]["PaymentID"];
                        PartRow["vforVendor"] = 1;
                        PartRow["vforCustomer"] = 0;
                        PartRow["vforEmployee"] = 0;

                        if (PaymentDdt.Rows[i]["BillQty"] != null)
                        {
                            PartQty += Convert.ToInt32(PaymentDdt.Rows[i]["BillQty"]);
                            PartRow["Qty"] = PartQty;
                        }
                        //if (PaymentDdt.Rows[i]["Price"] != null)
                        //{
                        //    PartRow["Price"] = PaymentDdt.Rows[i]["Price"];
                        //}
                        //if (PaymentDdt.Rows[i]["Cost"] != null)
                        //{
                        //    PartRow["Cost"] = PaymentDdt.Rows[i]["Cost"];
                        //}
                        if (PaymentDdt.Rows[i]["BillAmount"] != null)
                        {
                            PartAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            PartRow["Amount"] = PartAmount;
                            TotalAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            TotalParts += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                        }
                        if (PaymentDdt.Rows[i]["Discount"] != null)
                        {
                            PartDiscAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["Discount"]);
                            PartRow["DiscAmount"] = PartDiscAmount;
                        }
                        PartRow["vforVendor"] = 1;
                        PartRow["vforCustomer"] = 0;
                        PartRow["vforEmployee"] = 0;

                        PartRow["AmountIn"] = 0;
                        PartRow["AmountOut"] = 1;
                        PartRow["Remarks"] = "";

                        PartRow["AddDate"] = DateTime.Now;
                        PartRow["AddUserID"] = StaticInfo.userid;
                        PartRow["Comments"] = "";
                        PartRow["IsLocked"] = 0;
                        PartRow["Active"] = 1;
                        PartRow["Ctype"] = PaymentDdt.Rows[i]["Initial"].ToString();

                        //---------------------------------------------------------------------------------       
                    }
                    else if (PaymentDdt.Rows[i]["Initial"].ToString() == "Whe")
                    {
                        WheelRow["MID"] = vID;
                        WheelRow["vTypeID"] = 2;
                        WheelRow["vDate"] = DateTime.Now;
                        WheelRow["InvoiceID"] = Paymentdt.Rows[0]["InvoiceNo"];
                        WheelRow["PID"] = PaymentDdt.Rows[i]["PaymentID"];
                        WheelRow["vforVendor"] = 1;
                        WheelRow["vforCustomer"] = 0;
                        WheelRow["vforEmployee"] = 0;

                        if (PaymentDdt.Rows[i]["BillQty"] != null)
                        {
                            WhQty += Convert.ToInt32(PaymentDdt.Rows[i]["BillQty"]);
                            WheelRow["Qty"] = WhQty;
                        }
                        //if (PaymentDdt.Rows[i]["Price"] != null)
                        //{
                        //    WheelRow["Price"] = PaymentDdt.Rows[i]["Price"];
                        //}
                        //if (PaymentDdt.Rows[i]["Cost"] != null)
                        //{
                        //    WheelRow["Cost"] = PaymentDdt.Rows[i]["Cost"];
                        //}
                        if (PaymentDdt.Rows[i]["BillAmount"] != null)
                        {
                            WhAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            WheelRow["Amount"] = WhAmount;
                            TotalAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            TotalWheels += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                        }
                        if (PaymentDdt.Rows[i]["Discount"] != null)
                        {
                            WhDiscAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["Discount"]);
                            WheelRow["DiscAmount"] = WhDiscAmount;
                        }
                        WheelRow["vforVendor"] = 1;
                        WheelRow["vforCustomer"] = 0;
                        WheelRow["vforEmployee"] = 0;

                        WheelRow["AmountIn"] = 0;
                        WheelRow["AmountOut"] = 1;
                        WheelRow["Remarks"] = "";

                        WheelRow["AddDate"] = DateTime.Now;
                        WheelRow["AddUserID"] = StaticInfo.userid;
                        WheelRow["Comments"] = "";
                        WheelRow["IsLocked"] = 0;
                        WheelRow["Active"] = 1;
                        WheelRow["Ctype"] = PaymentDdt.Rows[i]["Initial"].ToString();
                    }
                    else if (PaymentDdt.Rows[i]["Initial"].ToString() == "Tir")
                    {
                        TireRow["MID"] = vID;
                        TireRow["vTypeID"] = 2;
                        TireRow["vDate"] = DateTime.Now;
                        TireRow["InvoiceID"] = Paymentdt.Rows[0]["InvoiceNo"];
                        TireRow["PID"] = PaymentDdt.Rows[i]["PaymentID"];
                        TireRow["vforVendor"] = 1;
                        TireRow["vforCustomer"] = 0;
                        TireRow["vforEmployee"] = 0;

                        if (PaymentDdt.Rows[i]["BillQty"] != null)
                        {
                            TirQty += Convert.ToInt32(PaymentDdt.Rows[i]["BillQty"]);
                            TireRow["Qty"] = TirQty;
                        }
                        //if (PaymentDdt.Rows[i]["Price"] != null)
                        //{
                        //    TireRow["Price"] = PaymentDdt.Rows[i]["Price"];
                        //}
                        //if (PaymentDdt.Rows[i]["Cost"] != null)
                        //{
                        //    TireRow["Cost"] = PaymentDdt.Rows[i]["Cost"];
                        //}
                        if (PaymentDdt.Rows[i]["BillAmount"] != null)
                        {
                            TirAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            TireRow["Amount"] = TirAmount;
                            TotalAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            TotalTire += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                        }
                        if (PaymentDdt.Rows[i]["Discount"] != null)
                        {
                            TirDiscAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["Discount"]);
                            TireRow["DiscAmount"] = TirDiscAmount;
                        }
                        TireRow["vforVendor"] = 1;
                        TireRow["vforCustomer"] = 0;
                        TireRow["vforEmployee"] = 0;

                        TireRow["AmountIn"] = 0;
                        TireRow["AmountOut"] = 1;
                        TireRow["Remarks"] = "";

                        TireRow["AddDate"] = DateTime.Now;
                        TireRow["AddUserID"] = StaticInfo.userid;
                        TireRow["Comments"] = "";
                        TireRow["IsLocked"] = 0;
                        TireRow["Active"] = 1;
                        TireRow["Ctype"] = PaymentDdt.Rows[i]["Initial"].ToString();
                    }
                    else
                    {
                        OtherRow["MID"] = vID;
                        OtherRow["vTypeID"] = 2;
                        OtherRow["vDate"] = DateTime.Now;
                        OtherRow["InvoiceID"] = Paymentdt.Rows[0]["InvoiceNo"];
                        OtherRow["PID"] = PaymentDdt.Rows[i]["PaymentID"];
                        OtherRow["vforVendor"] = 1;
                        OtherRow["vforCustomer"] = 0;
                        OtherRow["vforEmployee"] = 0;

                        if (PaymentDdt.Rows[i]["BillQty"] != null)
                        {
                            OthQty += Convert.ToInt32(PaymentDdt.Rows[i]["BillQty"]);
                            OtherRow["Qty"] = OthQty;
                        }
                        //if (PaymentDdt.Rows[i]["Price"] != null)
                        //{
                        //    TireRow["Price"] = PaymentDdt.Rows[i]["Price"];
                        //}
                        //if (PaymentDdt.Rows[i]["Cost"] != null)
                        //{
                        //    TireRow["Cost"] = PaymentDdt.Rows[i]["Cost"];
                        //}
                        if (PaymentDdt.Rows[i]["BillAmount"] != null)
                        {
                            OthAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            OtherRow["Amount"] = OthAmount;
                            TotalAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                            TotalOthers += Convert.ToDecimal(PaymentDdt.Rows[i]["BillAmount"]);
                        }
                        if (PaymentDdt.Rows[i]["Discount"] != null)
                        {
                            OthDiscAmount += Convert.ToDecimal(PaymentDdt.Rows[i]["Discount"]);
                            OtherRow["DiscAmount"] = OthDiscAmount;
                        }
                        OtherRow["vforVendor"] = 1;
                        OtherRow["vforCustomer"] = 0;
                        OtherRow["vforEmployee"] = 0;

                        OtherRow["AmountIn"] = 0;
                        OtherRow["AmountOut"] = 1;
                        OtherRow["Remarks"] = "";

                        OtherRow["AddDate"] = DateTime.Now;
                        OtherRow["AddUserID"] = StaticInfo.userid;
                        OtherRow["Comments"] = "";
                        OtherRow["IsLocked"] = 0;
                        OtherRow["Active"] = 1;
                        OtherRow["Ctype"] = PaymentDdt.Rows[i]["Initial"].ToString();
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
        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                objBindingSource.EndEdit();
                if (CalculateTotalAmount(Convert.ToDecimal(((TATextBox)sender).Text.Trim().Substring(1))) == false)
                {
                    xMessageBox.Show("Invalid Amount...!", "Warning");
                }
            }
        }
        void btnClear_Click(object sender, EventArgs e)
        {
            string senderText = ((TAButton)sender).Name.ToString().Trim();
            string txtName = senderText.Substring(8, senderText.Length - 8);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow[txtName] = 0;
            //if (txtName == "PayByCheck")
            //{
            //    curRow["CheckNo"] = "";
            //    curRow["LicNo"] = "";
            //}
            txtTotalBalance.Text = "$" + txtVBAmount.Text.Substring(1);
            CalculateTotalAmount();
        }
        //void CalculateTotalAmount()
        //{
        //    objBindingSource.EndEdit();

        //    DataRowView curRow = (DataRowView)objBindingSource.Current;
        //    decimal ChgOnAccount = Convert.ToDecimal(curRow["ChgOnAccount"]);
        //    decimal PayByCash = Convert.ToDecimal(curRow["PayByCash"]);
        //    decimal PaybyCheck = Convert.ToDecimal(curRow["PaybyCheck"]);
        //    decimal PayByDeposit = Convert.ToDecimal(curRow["PayByDeposit"]);
        //    decimal PayByVisa = Convert.ToDecimal(curRow["PayByVisa"]);
        //    decimal PayByMC = Convert.ToDecimal(curRow["PayByMC"]);
        //    decimal PayByAMEX = Convert.ToDecimal(curRow["PayByAMEX"]);
        //    decimal PayByATM = Convert.ToDecimal(curRow["PayByATM"]);
        //    decimal PayByGY = Convert.ToDecimal(curRow["PayByGY"]);
        //    decimal PayByDSCVR = Convert.ToDecimal(curRow["PayByDSCVR"]);

        //    curRow.BeginEdit();
        //    VBAmount =  ChgOnAccount + PayByCash + PaybyCheck + PayByDeposit + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
        //    curRow["PaidAmount"] = VBAmount;
        //    TotalVBAmount = Convert.ToDecimal(curRow["PaidAmount"]);
        //    curRow.EndEdit();
        //}

        bool CalculateTotalAmount(decimal _amount = 0)
        {
            bool status = false;
            if (VBAmount >= _amount)
            {
                objBindingSource.EndEdit();

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                // decimal ChgOnAccount = Convert.ToDecimal(curRow["ChgOnAccount"]);
                decimal PayByCash = Convert.ToDecimal(curRow["PayByCash"]);
                decimal PaybyCheck = Convert.ToDecimal(curRow["PaybyCheck"]);
                // decimal PayByDeposit = Convert.ToDecimal(curRow["PayByDeposit"]);
                decimal PayByVisa = Convert.ToDecimal(curRow["PayByVisa"]);
                decimal PayByMC = Convert.ToDecimal(curRow["PayByMC"]);
                decimal PayByAMEX = Convert.ToDecimal(curRow["PayByAMEX"]);
                decimal PayByATM = Convert.ToDecimal(curRow["PayByATM"]);
                decimal PayByGY = Convert.ToDecimal(curRow["PayByGY"]);
                decimal PayByDSCVR = Convert.ToDecimal(curRow["PayByDSCVR"]);

                curRow.BeginEdit();
                //ChgOnAccount + PayByDeposit
                curRow["BillAmount"] = PayByCash + PaybyCheck + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
                TotalVBAmount = Convert.ToDecimal(curRow["BillAmount"]);
                curRow["PaidAmount"] = TotalVBAmount;
                curRow.BeginEdit();

                //VBAmount = ChgOnAccount + PayByCash + PaybyCheck + PayByDeposit + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
                //curRow["PaidAmount"] = VBAmount;
                //curRow["BillAmount"] = VBAmount;
                //TotalVBAmount = Convert.ToDecimal(curRow["BillAmount"]);

                //var amount = ChgOnAccount + PayByCash + PaybyCheck + PayByDeposit + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
                //curRow["PaidAmount"] = amount;
                //curRow["BillAmount"] = amount;
                //TotalVBAmount = Convert.ToDecimal(curRow["PaidAmount"]);

                curRow.EndEdit();

                //txtTotalBalance.Text = "$" + (VBAmount - TotalVBAmount).ToString();
                curRow["BillBalance"] = VBAmount - TotalVBAmount;
                status = true;

                if (!string.IsNullOrEmpty(txtPayByCheck.Text))
                {
                    if (txtPayByCheck.Text != "$0.00")
                    {
                        txtDriversLic.Enabled = true;
                        txtCheckNo.Enabled = true;
                        txtCheckNo.xIsRequired = System32.StaticInfo.YesNo.Yes;
                    }
                    else
                    {
                        txtDriversLic.Enabled = false;
                        txtCheckNo.Enabled = false;
                        txtCheckNo.xIsRequired = System32.StaticInfo.YesNo.No;
                    }
                }
            }
            else
            {
                status = false;
            }
            return status;
        }
        void btnVendorBillList_Click(object sender, EventArgs e)
        {
            if (this.VendorID > 0)
            {
                ctrVendorBillListing objVendorBillsList = new ctrVendorBillListing(this.VendorID);
                objVendorBillsList.VendorBillSelected += objVendor_VendorBillSelected;
                frmCtr frmCtr = new frmCtr("Vendor Bills ...");
                frmCtr.Height = objVendorBillsList.Height + 20; frmCtr.Width = objVendorBillsList.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objVendorBillsList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
            else
                xMessageBox.Show("Select Vendor for Vendor Bills ....");
        }
        void objVendor_VendorBillSelected(object sender, DataRow dataRow)
        {
            SetVendorBill(dataRow);
        }
        void objVendor_VendorSelected(object sender, DataRow dataRow)
        {
            Adminrights = true;
            SetVendor(dataRow);

            //if (this.VendorBillID > 0)
            //    this.getVendorBill(this.VendorBillIDs);
        }
        void btnVendorList_Click(object sender, EventArgs e)
        {
            ctrVendorList objVendor = new ctrVendorList();
            objVendor.VendorSelected += objVendor_VendorSelected;
            frmCtr frmCtr = new frmCtr("Vendor ...");
            frmCtr.Height = objVendor.Height + 20; frmCtr.Width = objVendor.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objVendor);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void getVendor(int VenID)
        {
            DataRow CurrentRow = dbClass.obj.getVendorByID(VenID);
            SetVendor(CurrentRow);
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
        void SetVendor(DataRow SelectedRow)
        {
            if (SelectedRow != null)
            {
                this.VendorID = Convert.ToInt32(SelectedRow["ID"]);
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["VendorID"] = Convert.ToInt32(SelectedRow["ID"]);
                curRow.EndEdit();

                ctrVendor.Text = Convert.ToString(SelectedRow["Name"]);
                //CreditAvail = dbClass.obj.getCreditAvailbyCustomerID(this.CustomerID);
                //txtBalance.Text = Convert.ToString(CreditAvail);
                //AvailableDeposit = dbClass.obj.getAvailableDepositbyCustomerID(this.CustomerID);
                //txtAvailableDeposit.Text = Convert.ToString(AvailableDeposit);
                //CreditLimit = dbClass.obj.getCreditLimitbyCustomerID(this.CustomerID);
                //lblCreditLimits.Text = "of $" + Convert.ToString(CreditLimit);
                Adminrights = true;
                //if (AvailableDeposit > VBAmount)
                //{
                //    btnPayByDeposit.Enabled = true;
                //    txtPayByDeposit.Enabled = true;
                //}
                //else
                //{
                //    Adminrights = true;
                //    btnPayByDeposit.Enabled = false;
                //    txtPayByDeposit.Enabled = false;
                //}
                //For Cheque Accepted OR Not
                //if (!String.IsNullOrEmpty(Convert.ToString(SelectedRow["IsCheckAccepted"])))
                //{
                //    if (Adminrights == true)
                //    {
                //        btnPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtCheckNo.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtDriversLic.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //    }
                //    if (Convert.ToBoolean(SelectedRow["IsCheckAccepted"]) == true)
                //    {
                //        btnAdminRights.Visible = false;
                //    }
                //    else
                //    {
                //        btnAdminRights.Visible = true;
                //    }
                //}
                //else
                //{
                //    btnAdminRights.Visible = true;
                //}
            }
        }

        void getVendorBill()
        {
            //DataTable CurrentTable = dbClass.obj.getVendorBillByPaymentID(PaymentID);
            DataTable CurrentTable = TempPayment;
            SetVendorBill(CurrentTable);
            //if ((VBAmount - TotalVBAmount) > CreditLimit)
            //{
            //    HideControls();
            //}
        }
        void SetVendorBill(DataTable SelectedTable)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            string InvoiceNos = "";
            foreach (DataRow SelectedRow in SelectedTable.Rows)
            {
                if (SelectedRow != null && SelectedRow["ID"] != null)
                {
                    if (Convert.ToInt32(SelectedRow["VendorID"]) == this.VendorID)
                    {
                        //this.VendorBillIDs += "," + Convert.ToInt32(SelectedRow["BillID"]) + ",";
                        InvoiceNos += Convert.ToString(SelectedRow["BillID"]) + ",";
                        VBAmount += Convert.ToDecimal(SelectedRow["PaidAmount"]);

                        curRow.BeginEdit();
                        curRow["BillIDs"] = Convert.ToInt32(SelectedRow["BillID"]);
                        //curRow["PaymentID"] = Convert.ToInt32(SelectedRow["PaymentID"]);
                        curRow.EndEdit();
                        //VBDate.DateTimePicker1.Value = Convert.ToDateTime(SelectedRow["RegDate"]);
                    }
                    else
                    {
                        this.VendorBillIDs = "";
                        txtVendorBillID.Text = "";
                        curRow.BeginEdit();
                        curRow["BillIDs"] = 0;
                        curRow.EndEdit();
                        VBAmount = 0;
                        txtVBAmount.Text = "";
                        //VBDate.DateTimePicker1.Value = DateTime.Now;
                    }
                }
            }
            //this.objBindingSource.DataSource = SelectedTable.Rows[0];

            txtVendorBillID.Text = InvoiceNos.Remove(InvoiceNos.Length - 1, 1);
            txtVBAmount.Text = StaticInfo.SecCurSign + VBAmount;
            curRow["BillBalance"] = VBAmount;
        }

        void SetVendorBill(DataRow SelectedRow)
        {
            if (SelectedRow != null && SelectedRow["ID"] != null)
            {
                if (Convert.ToInt32(SelectedRow["VendorID"]) == this.VendorID)
                {
                    this.VendorBillID = Convert.ToInt32(SelectedRow["BillID"]);
                    txtVendorBillID.Text = Convert.ToString(SelectedRow["Reference"]);
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["BillIDs"] = Convert.ToInt32(SelectedRow["BillID"]);
                    curRow.EndEdit();

                    VBAmount = Convert.ToDecimal(SelectedRow["Balance"]);
                    txtVBAmount.Text = VBAmount.ToString();
                    txtTotalBalance.Text = VBAmount.ToString();
                }
                else
                {
                    this.VendorBillIDs = "";
                    txtVendorBillID.Text = "";
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    curRow["BillIDs"] = 0;
                    curRow.EndEdit();
                    VBAmount = 0;
                    txtVBAmount.Text = "";
                    //WODate.DateTimePicker1.Value = DateTime.Now;
                }
            }
        }

        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if (Focus)
            {
            }
            else
                CalculateTotalAmount();
        }
    }
}
