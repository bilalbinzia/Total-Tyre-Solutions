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

namespace AppControls
{
    public partial class ctrCustomerPayment : BaseControl
    {
        Int32 CustomerID = 0;
        Int32 WorkOrderNegateID = 0;
        decimal WOAmount = 0;
        decimal TotalWOAmount = 0;
        decimal CusCredit = 0;
        decimal CreditLimit = 0;
        decimal CreditAvail = 0;

        decimal AvailableCredit = 0;
        bool Adminrights = false;
        bool Focus = true;
        bool EditInvoice = false;

        public ctrCustomerPayment()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrCustomerPayment(int WONID,int CustID)
        {
            InitializeComponent();
            InitializeComponent1();

            this.CustomerID = CustID;
            this.WorkOrderNegateID = WONID;

        }
        void InitializeComponent1()
        {
            this.Load += ctrCustomerPayment_Load;

            btnCustomerList.Click += btnCustomerList_Click;
            btnWorkOrderList.Click += btnWorkOrderList_Click;

            btnClearChgOnAccount.Click += btnClear_Click;
            btnClearPayByCash.Click += btnClear_Click;
            btnClearPayByCheck.Click += btnClear_Click;
            btnClearCusCredit.Click += btnClear_Click;
            btnClearPayByVISA.Click += btnClear_Click;
            btnClearPayByMC.Click += btnClear_Click;
            btnClearPayByAMEX.Click += btnClear_Click;
            btnClearPayByATM.Click += btnClear_Click;
            btnClearPayByGY.Click += btnClear_Click;
            btnClearPayByDSCVR.Click += btnClear_Click;

            txtChgOnAccount.KeyDown += textBox_KeyDown;
            txtPayByCash.KeyDown += textBox_KeyDown;
            txtPayByCheck.KeyDown += textBox_KeyDown;
            txtCusCredit.KeyDown += textBox_KeyDown;
            txtPayByVISA.KeyDown += textBox_KeyDown;
            txtPayByMC.KeyDown += textBox_KeyDown;
            txtPayByAMEX.KeyDown += textBox_KeyDown;
            txtPayByATM.KeyDown += textBox_KeyDown;
            txtPayByGY.KeyDown += textBox_KeyDown;
            txtPayByDSCVR.KeyDown += textBox_KeyDown;

            btnChgOnAccount.Click += btnClick_Click;
            btnPayByCash.Click += btnClick_Click;
            btnPayByCheck.Click += btnClick_Click;
            btnCustomerCr.Click += btnClick_Click;
            btnPayByVISA.Click += btnClick_Click;
            btnPayByMC.Click += btnClick_Click;
            btnPayByAMEX.Click += btnClick_Click;
            btnPayByATM.Click += btnClick_Click;
            btnPayByGY.Click += btnClick_Click;
            btnPayByDSCVR.Click += btnClick_Click;

            txtPayByCash.LostFocus += textBox_LostFocus;
            txtPayByCheck.LostFocus += textBox_LostFocus;
            txtCusCredit.LostFocus += textBox_LostFocus;
            txtPayByVISA.LostFocus += textBox_LostFocus;
            txtPayByMC.LostFocus += textBox_LostFocus;
            txtPayByAMEX.LostFocus += textBox_LostFocus;
            txtPayByATM.LostFocus += textBox_LostFocus;
            txtPayByGY.LostFocus += textBox_LostFocus;
            txtPayByDSCVR.LostFocus += textBox_LostFocus;

        }
        void ctrCustomerPayment_Load(object sender, EventArgs e)
        {
            bool ChangeDate = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '011'");
            if (row[0]["CanView"] != DBNull.Value)
                ChangeDate = Convert.ToBoolean(row[0]["CanView"]);

            if (ChangeDate)
                tpInvoiceDate.Enabled = true;
            else
                tpInvoiceDate.Enabled = false;

            if ((this.CustomerID > 0) && (this.WorkOrderNegateID > 0))
            {
                dbClass.obj.getPaymentByCustomerIDAndWorkOrderNegateID(objDataSet.Tables["CustomerPayment"], this.CustomerID, this.WorkOrderNegateID);
                this.objBindingSource.DataSource = objDataSet.Tables["CustomerPayment"];

                if (objDataSet.Tables["CustomerPayment"].Rows.Count > 0)
                {
                    if (this.CustomerID > 0)
                        this.getCustomer(this.CustomerID);

                    if (this.WorkOrderNegateID > 0)
                        this.getWorkOrderNegate(this.WorkOrderNegateID);
                }
                else
                {
                    //objBindingSource.AddNew();
                    bindingNavigatorAddNewItem_Click(sender, e);                                        
                }
            }
            else if (this.CustomerID > 0)
            {
                //objBindingSource.AddNew();
                bindingNavigatorAddNewItem_Click(sender, e);
                
            }
        }
        

        void btnClick_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;

            if (txtChgOnAccount.Text != "" || txtPayByCash.Text != "" || txtPayByCheck.Text != "" || txtPayByVISA.Text != "")
            {
                TotalWOAmount = 0;
                if (txtCusCredit.Text != "$0.00")
                {
                    TotalWOAmount += Convert.ToDecimal(txtCusCredit.Text.Substring(1));
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

            if (WOAmount > 0 && TotalWOAmount <= WOAmount)
            {
                string btnName = ((TAButton)sender).Name.Trim();
                switch (btnName)
                {
                    case "btnChgOnAccount":
                        if (txtChgOnAccount.Text == "$0.00")
                        {
                            txtChgOnAccount.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["PayByCash"] = txtPayByCash.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        //txtChgOnAccount.Text = Convert.ToString(WOAmount - TotalWOAmount);
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
                        //txtPayByCash.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByCheck":
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
                        //txtPayByCheck.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnCustomerCr":
                        if (txtCusCredit.Text == "$0.00")
                        {
                            txtCusCredit.Text = "$" + Convert.ToString(WOAmount - TotalWOAmount);
                        }
                        else
                        {
                            curRow.BeginEdit();
                            curRow["CusCredit"] = txtCusCredit.Text.Substring(1);
                            curRow.EndEdit();
                        }
                        //txtPayByDeposit.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByVISA":
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
                        //txtPayByVISA.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByMC":
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
                        //txtPayByMC.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByAMEX":
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
                        //txtPayByAMEX.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByATM":
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
                        //txtPayByATM.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByGY":
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
                        //txtPayByGY.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                    case "btnPayByDSCVR":
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
                        //txtPayByDSCVR.Text = Convert.ToString(WOAmount - TotalWOAmount);
                        break;
                }
                CalculateTotalAmount();
            }
            else 
            {
                xMessageBox.Show("Invalid Amount");
            }
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int NextAutoNo = dbClass.obj.getNextCustomerPaymentAutoNo();

            base.bindingNavigatorAddNewItem_Click(sender, e);

            if (this.CustomerID > 0)
                this.getCustomer(this.CustomerID);

            if (this.WorkOrderNegateID > 0)
                this.getWorkOrderNegate(this.WorkOrderNegateID);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["PaymentID"] = NextAutoNo;
            curRow["TrnsDate"] = DateTime.Now;

            if (this.CustomerID > 0)
                curRow["CustomerID"] = this.CustomerID;
            else
                curRow["CustomerID"] = DBNull.Value;

            if (this.WorkOrderNegateID > 0)
                curRow["WONID"] = this.WorkOrderNegateID;
            else
                curRow["WONID"] = DBNull.Value;

            curRow["IsPaid"] = true;
            curRow["IsDeposit"] = false;
            curRow["IsCredit"] = false;

            curRow["CusCredit"] = 0;
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

        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            decimal balance = decimal.Parse(txtInvoiceBalance.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses |
                                      NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint);
            if ((curRow["CustomerID"] == DBNull.Value) || (Convert.ToInt32(curRow["CustomerID"]) <= 0))
            {
                xMessageBox.Show("Add Customer for this Customer Payment ...");
                return;
            }
            if ((curRow["WONID"] == DBNull.Value) || (Convert.ToInt32(curRow["WONID"]) <= 0))
            {
                if (xMessageBox.Show("Do you save this Payment without Workorder....?", "Customer Payment..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            if (Convert.ToDecimal(curRow["TotalReceivedAmount"]) < WOAmount)
            {
                xMessageBox.Show("Payment amount must be greater then 0 ...");
                return;
            }
            if (balance > 0 && balance < WOAmount)
            {
                xMessageBox.Show("Payment amount can't be greater then Negate Amount ...");
                return;
            }

            base.bindingNavigatorSaveItem_Click(sender, e);

            if (CustomValidation(true))
            {
                if (this.WorkOrderNegateID > 0)
                    dbClass.obj.UpdateCustomerRecieptCredit(this.WorkOrderNegateID);
                                
                if (chkBoxIsAutoPrint.Checked)
                {
                    if (this.WorkOrderNegateID > 0)
                    {
                        StaticInfo.LoadToReport("RptModule", "Reports.NegatedWorkOrderReport", "byID", WorkOrderNegateID);
                    }
                }                    
                this.ParentForm.Close();
            }
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            Focus = true;
            base.bindingNavigatorCancelItem_Click(sender, e);
        }
        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string senderText = ((TATextBox)sender).Name.ToString().Trim();
                //string txtName = senderText.Substring(3, senderText.Length - 3);
                objBindingSource.EndEdit();
                CalculateTotalAmount();
            }
        }
        void btnClear_Click(object sender, EventArgs e)
        {
            string senderText = ((TAButton)sender).Name.ToString().Trim();
            string txtName = senderText.Substring(8, senderText.Length - 8);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow[txtName] = 0;
            if (txtName == "PayByCheck")
            {
                curRow["CheckNo"] = "";
                curRow["LicNo"] = "";
            }
            curRow.EndEdit();

            CalculateTotalAmount();
        }
        void CalculateTotalAmount()
        {
            objBindingSource.EndEdit();

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            decimal ChgOnAccount = Convert.ToDecimal(curRow["ChgOnAccount"]);
            decimal PayByCash = Convert.ToDecimal(curRow["PayByCash"]);
            decimal PaybyCheck = Convert.ToDecimal(curRow["PaybyCheck"]);
            decimal PayByCusCredit = Convert.ToDecimal(curRow["CusCredit"]);
            decimal PayByVisa = Convert.ToDecimal(curRow["PayByVisa"]);
            decimal PayByMC = Convert.ToDecimal(curRow["PayByMC"]);
            decimal PayByAMEX = Convert.ToDecimal(curRow["PayByAMEX"]);
            decimal PayByATM = Convert.ToDecimal(curRow["PayByATM"]);
            decimal PayByGY = Convert.ToDecimal(curRow["PayByGY"]);
            decimal PayByDSCVR = Convert.ToDecimal(curRow["PayByDSCVR"]);

            curRow.BeginEdit();
            curRow["TotalReceivedAmount"] = ChgOnAccount + PayByCash + PaybyCheck + PayByCusCredit + PayByVisa + PayByMC + PayByAMEX + PayByATM + PayByGY + PayByDSCVR;
            TotalWOAmount = Convert.ToDecimal(curRow["TotalReceivedAmount"]);
            curRow.EndEdit();
            txtInvoiceBalance.Text = StaticInfo.SecCurSign + ( WOAmount - TotalWOAmount);
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
                xMessageBox.Show("Select Customer for Customer Payment ....");
        }
        void objWorkOrder_WorkOrderSelected(object sender, DataRow dataRow)
        {
            SetWorkOrderNegate(dataRow);
        }
        void objCustomer_CustomerSelected(object sender, DataRow dataRow)
        {
            SetCustomer(dataRow);
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
                //AvailableDeposit = dbClass.obj.getAvailableDepositbyCustomerID(this.CustomerID);
                //txtAvailableDeposit.Text = Convert.ToString(AvailableDeposit);

                CreditLimit = dbClass.obj.getCreditLimitbyCustomerID(this.CustomerID);
                CreditAvail = dbClass.obj.getCreditAvailbyCustomerID(this.CustomerID);
                txtCusCredit1.Text = StaticInfo.SecCurSign + CusCredit;
                AvailableCredit = CreditLimit - CreditAvail;
                if (AvailableCredit >= 0)
                {
                    txtAvailableCredit.Text = StaticInfo.SecCurSign + AvailableCredit;
                }
                lblCreditLimits.Text = "of $" + Convert.ToString(CreditLimit);                
                //if (InvoiceForCredit == true)
                //{
                //    rdoCredit.Checked = true;
                //    rdoPaid.Checked = false;
                //    rdoCredit.Enabled = false;
                //    rdoPaid.Enabled = false;
                //    //ClearControls();
                //    if (CreditAvail != 0)
                //    {
                //        //txtInvoiceBalance.Text = "$" + CreditAvail;
                //    }
                //    else
                //    {
                //        //txtInvoiceBalance.Text = "$0.00";
                //    }
                //    InvoiceForCredit = true;
                //    Adminrights = true;
                //}
                //else if (InvoiceForCredit == false)
                //{
                //    if (txtWOAmount.Text != "")
                //    {
                //        txtInvoiceBalance.Text = "$" + txtWOAmount.Text.Substring(1);
                //    }
                //    else
                //    {
                //        txtInvoiceBalance.Text = "$0.00";
                //    }
                //    rdoCredit.Enabled = false;
                //    rdoPaid.Enabled = false;
                //}
                //if (CreditLimit > 0 && EditInvoice == false && StaticInfo.EmployeeName == "Admin")
                //{
                //    btnChgOnAccount.Enabled = true;
                //    txtChgOnAccount.Enabled = true;
                //}
                //else
                //{
                //    btnChgOnAccount.Enabled = false;
                //    txtChgOnAccount.Enabled = false;
                //    Adminrights = true;
                //}
                ////For Cheque Accepted OR Not
                //if (!String.IsNullOrEmpty(Convert.ToString(SelectedRow["IsCheckAccepted"])))
                //{
                //    if (Adminrights == true && EditInvoice == false)
                //    {
                //        btnPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtPayByCheck.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtCheckNo.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //        txtDriversLic.Enabled = Convert.ToBoolean(SelectedRow["IsCheckAccepted"]);
                //    }
                //}
                //else
                //{
                //    btnAdminRights.Visible = true;
                //}
                //if (InvoiceForCredit == true)
                //{
                //    btnWorkOrderList.Enabled = false;
                //    btnChgOnAccount.Enabled = false;
                //    txtChgOnAccount.Enabled = false;
                //    rdoCredit.Checked = true;
                //    rdoPaid.Checked = false;
                //}
                //if (StaticInfo.EmployeeName == "Admin")
                //{
                //    ShowControls();
                //}
            }
        }

        void getWorkOrderNegate(int WorkOrderNegateID)
        {
            DataRow CurrentRow = dbClass.obj.getWorkOrderNegateByID(WorkOrderNegateID);
            SetWorkOrderNegate(CurrentRow);
        }
        void SetWorkOrderNegate(DataRow SelectedRow)
        {
            if (SelectedRow != null)
            {
                //this.WorkOrderNegateID = Convert.ToInt32(SelectedRow["ID"]);
                txtWorkOrderID.Text = Convert.ToString(SelectedRow["WorkOrderNegateNo"]);
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["WONID"] = Convert.ToInt32(SelectedRow["ID"]);
                curRow["InvoiceNo"] = Convert.ToInt32(SelectedRow["WorkOrderNegateNo"]);
                curRow.EndEdit();
                WOAmount = Convert.ToDecimal(SelectedRow["Total"]);
                txtWOAmount.Text = "$" + Convert.ToString(SelectedRow["Total"]);
                txtInvoiceBalance.Text = "$" + WOAmount;
                WODate.DateTimePicker1.Value = Convert.ToDateTime(SelectedRow["RegDate"]);                
                

            }
        }
        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if (Focus) { }
            else
                CalculateTotalAmount();
        }
    }
}
