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
using RptModule;

namespace AppControls
{
    public partial class ctrVendorPaymentList : UserControl
    {
        MainDataSet objDataSet;

        BindingSource VendorBS;
        BindingSource VendorBillBS;
        //BindingSource VendorBillDetailsBS;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedBillID = 0;
        int SelectedVendorID = 0;
        int SelectedVBID = 0;

        public ctrVendorPaymentList()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();

            VendorBS = new BindingSource();
            VendorBillBS = new BindingSource();
            //VendorBillDetailsBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrVendorPaymentList_Load;
            //btnNewVendorBill.Click += btnNewVendorBill_Click;
            //btnBillVoid.Click += btnPOVoid_Click;
            //this.rbtnCheck.CheckedChanged += rbtnCheck_CheckedChanged;
            DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorBillList.TDataGridView.CellEndEdit += DGVVendorBillList_TDataGridView_CellEndEdit;
            DGVVendorBillList.TDataGridView.CellClick += DGVVendorBillList_TDataGridView_CellClick;
            DGVVendorBillList.SearchtxtBox.KeyUp += DGVVendorBillList_SearchtxtBox_KeyUp;

            btnVoidTransactions.Click += btnVoidTransaction_Click;
            btnNewVendorBill.Click += btnNewVendorBill_Click;
            btnPrintPayment.Click += btnPrintPayment_Click;
            btnProceedPayment.Click += btnProceedPayment_Click;
            chkboxShowClosedTransactions.CheckedChanged += chkboxShowClosedTransactions_CheckedChanged;
            txtTotalToPay.LostFocus += txtTotalToPay_TextChanged;
            //txtTotalDiscount.LostFocus += txtTotalDiscount_TextChanged;

            BindingControls();


        }
        public ctrVendorPaymentList(int VendorID)
        {
            this.SelectedVendorID = VendorID;
            InitializeComponent();

            objDataSet = new MainDataSet();

            VendorBS = new BindingSource();
            VendorBillBS = new BindingSource();
            //VendorBillDetailsBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrVendorPaymentList_Load;
            //btnNewVendorBill.Click += btnNewVendorBill_Click;
            //btnBillVoid.Click += btnPOVoid_Click;
            //this.rbtnCheck.CheckedChanged += rbtnCheck_CheckedChanged;
            DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorBillList.TDataGridView.CellEndEdit += DGVVendorBillList_TDataGridView_CellEndEdit;
            DGVVendorBillList.TDataGridView.CellClick += DGVVendorBillList_TDataGridView_CellClick;
            DGVVendorBillList.SearchtxtBox.KeyUp += DGVVendorBillList_SearchtxtBox_KeyUp;

            btnVoidTransactions.Click += btnVoidTransaction_Click;
            btnNewVendorBill.Click += btnNewVendorBill_Click;
            btnPrintPayment.Click += btnPrintPayment_Click;
            btnProceedPayment.Click += btnProceedPayment_Click;
            chkboxShowClosedTransactions.CheckedChanged += chkboxShowClosedTransactions_CheckedChanged;
            txtTotalToPay.LostFocus += txtTotalToPay_TextChanged;
            //txtTotalDiscount.LostFocus += txtTotalDiscount_TextChanged;

            BindingControls();
        }
        void chkboxShowClosedTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxShowClosedTransactions.Checked)
            {
                //if (SelectedVendorID > 0)
                //LoadSelectedVendorClosedBills();
            }
            else
            {
                if (SelectedVendorID > 0)
                    LoadSelectedVendorVendorBills();
            }
        }
        void btnVoidTransaction_Click(object sender, EventArgs e)
        {
            if (SelectedVendorID > 0)
            {
                ctrVendorPaymentHistory objList = new ctrVendorPaymentHistory(this.SelectedVendorID);
                frmCtr frmCtr = new frmCtr("Vendor Transactions");
                frmCtr.Height = Parent.Height; frmCtr.Width = Parent.Width;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
            else
            {
                xMessageBox.Show("Please select any Vendor ....");
            }
            //StaticInfo.LoadToControl("AppControls.ctrVendorPaymentHistory", "Vendor Payment History", 0);
        }

        void btnNewVendorBill_Click(object sender, EventArgs e)
        {
            ctrPurchaseOrderList objList = new ctrPurchaseOrderList(this.SelectedVendorID);
            frmCtr frmCtr = new frmCtr("Purchase Order");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();

            //StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase Details", SelectedVendorID);
        }
        void btnPrintPayment_Click(object sender, EventArgs e)
        {
            if (SelectedBillID > 0)
            {
                DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
                string Type = curRow["Type"].ToString();
                if (Type == "Payment")
                {

                    frmRpt objList = new frmRpt("Reports.VendorPaymentReport", "byID", SelectedBillID);
                    frmCtr frmCtr = new frmCtr("Vendor Payment Report");
                    frmCtr.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                    frmCtr.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                    frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmCtr.frmPnl.Controls.Add(objList);
                    frmCtr.BringToFront();
                    frmCtr.ShowDialog();
                    //StaticInfo.LoadToReport("RptModule", "Reports.VendorPaymentReport", "byID", SelectedBillID);
                }
                else if (Type == "Bill") 
                {
                    frmRpt objList = new frmRpt("Reports.VendorBillReport", "byID", SelectedBillID);
                    frmCtr frmCtr = new frmCtr("Vendor Bill");
                    frmCtr.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                    frmCtr.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                    frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmCtr.frmPnl.Controls.Add(objList);
                    frmCtr.BringToFront();
                    frmCtr.ShowDialog();
                }                               
            }

            else if (SelectedVendorID > 0)
            {
                frmRpt objList = new frmRpt("Reports.VendorLedgerReport", "byID", SelectedVendorID);
                frmCtr frmCtr = new frmCtr("Vendor Ledger Report");
                frmCtr.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                frmCtr.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
                //StaticInfo.LoadToReport("RptModule", "Reports.VendorLedgerReport", "byID", SelectedVendorID);
            }
        }
        //void rbtnCheck_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbtnCheck.Checked)
        //        txtCheckNo.Enabled = true;
        //    else
        //        txtCheckNo.Enabled = false;
        //}
        void btnProceedPayment_Click(object sender, EventArgs e)
        {
            bool BillsSelected = false;
            if (SelectedVendorID > 0)
            {

                //--------------------------------------------------------------
                DataTable DtPayment = new DataTable();
                DtPayment.Columns.Add("ID", typeof(int));
                DtPayment.Columns.Add("VendorID", typeof(int));
                DtPayment.Columns.Add("BillID", typeof(int));
                DtPayment.Columns.Add("Discount", typeof(decimal));
                DtPayment.Columns.Add("BillAmount", typeof(decimal));
                DtPayment.Columns.Add("PaidAmount", typeof(decimal));
                DtPayment.Columns.Add("BillBalance", typeof(decimal));

                
                
                string BillIDs = "";
               // int PaymentID = dbClass.obj.getNextVendorPaymentAutoNo();
                int VendorID = SelectedVendorID;
               // string InvoiceNo = (PaymentID + 1000).ToString();
                //if (rbtnCheck.Checked)
                //    InvoiceNo = txtCheckNo.Text.Trim();

                //DateTime TrnsDate = ctrPaymentDate.DateTimePicker1.Value;
                //string TrnsNotes = txtNotes.Text.Trim();
                //string TrnsType = "";
                //if (rbtnCash.Checked) TrnsType = "C";
                //if (rbtnCheck.Checked) TrnsType = "Q";
                //int StoreID = StaticInfo.StoreID;
                
                //dbClass.obj.DeleteVendorPaymentTemp(VendorID, PaymentID);
                
                //------------------------------------------------------//                   
                foreach (DataGridViewRow n in DGVVendorBillList.TDataGridView.Rows)
                {
                    DataRow dr = DtPayment.NewRow();
                    dr["VendorID"] = VendorID;
                    if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["IsPaid"].Value) == true)
                        {
                            int ID = 0, BillID = 0;
                            decimal BillAmount = 0, BillDiscount = 0, PaidAmount = 0, BillBalance = 0;

                            if (n.Cells["ID"].Value != null)
                            {
                                ID = Convert.ToInt32(n.Cells["ID"].Value);
                                dr["ID"] = ID;
                            }
                            if (n.Cells["BillID"].Value != null)
                            {
                                BillID = Convert.ToInt32(n.Cells["BillID"].Value);
                                dr["BillID"] = BillID;
                            }
                            if (n.Cells["Payable"].Value != null)
                            {
                                BillAmount = Convert.ToDecimal(n.Cells["Payable"].Value);
                                dr["BillAmount"] = BillAmount;
                            }
                            if (n.Cells["Discount"].Value != null)
                            {
                                BillDiscount = Convert.ToDecimal(n.Cells["Discount"].Value);
                                dr["Discount"] = BillAmount;
                            }
                            if (n.Cells["To Pay"].Value != null)
                            {
                                PaidAmount = Convert.ToDecimal(n.Cells["To Pay"].Value);
                                dr["PaidAmount"] = PaidAmount;
                            }
                            if (n.Cells["Balance"].Value != null)
                            {
                                BillBalance = Convert.ToDecimal(n.Cells["Balance"].Value);
                                dr["BillBalance"] = BillBalance;
                            }

                            if (ID > 0 && BillID > 0)
                            {
                                BillIDs += "," + BillID + ",";
                                BillsSelected = true;
                                DtPayment.Rows.Add(dr);
                                //dbClass.obj.AddVendorPaymentTemp(PaymentID, VendorID, BillID, InvoiceNo, DateTime.Now, "", TrnsType, BillAmount, BillDiscount, PaidAmount, BillBalance, false);
                                //if (Convert.ToDecimal(n.Cells["Balance"].Value) == 0)
                                //{
                                //dbClass.obj.AddVendorPayment(PaymentID, VendorID, BillID, InvoiceNo, TrnsDate, TrnsNotes, TrnsType, BillAmount, BillDiscount, PaidAmount, BillBalance);
                                //dbClass.obj.AddVendorPaymentHistory(VendorID, BillID, BillAmount, PaidAmount, BillBalance, true);
                                //dbClass.obj.UpdateVendorBill(ID, BillDiscount, PaidAmount, BillBalance, true);
                                //}
                                // else {
                                //dbClass.obj.AddVendorPaymentHistory(VendorID, BillID,BillAmount,PaidAmount,BillBalance, false);
                                //dbClass.obj.UpdateVendorBill(ID, BillDiscount, PaidAmount, BillBalance, false);
                                // }


                                // dbClass.obj.UpdateVendorBill(ID, BillDiscount, PaidAmount, BillBalance);
                            }
                        }
                    }
                }

                // xMessageBox.Show("Payment has been Processed...");
                //---------------------------------------------------------//
                //if (SelectedVendorID > 0)
                //LoadSelectedVendorVendorBills();
                //StaticInfo.LoadToControl("AppControls.ctrCustomerReceipt", "Vendor Payment", SelectedVendorID, 0);

                //ctrVendorPayment objList = new ctrVendorPayment (SelectedVendorID, 0);
                if (BillsSelected)
                {
                    ctrVendorPayment objList = new ctrVendorPayment(BillIDs, VendorID, DtPayment);
                    frmCtr frmCtr = new frmCtr("Vendor Payment");
                    frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                    frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmCtr.frmPnl.Controls.Add(objList);
                    frmCtr.BringToFront();
                    frmCtr.ShowDialog();
                    //this.Parent.Parent.Parent.Dispose();

                    LoadSelectedVendorVendorBills();
                }
                else
                {
                    xMessageBox.Show("Please Select any Bill .....");
                }
            }
            else {
                xMessageBox.Show("Please Select any Vendor .....");
            }
        }
        void BindingControls()
        {
            dbClass.obj.FillVendorBillsByVendorID(objDataSet.Tables["VendorBill"], SelectedVendorID);
            VendorBillBS.DataSource = objDataSet.Tables["VendorBill"];

            //if ((txtInvoiceNo.xBindingProperty != "") && (txtInvoiceNo.xBindingProperty != null))
            //    txtInvoiceNo.BindControl(VendorBillBS, txtInvoiceNo.xBindingProperty);
            //if ((txtBillID.xBindingProperty != "") && (txtBillID.xBindingProperty != null))
            //    txtBillID.BindControl(VendorBillBS, txtBillID.xBindingProperty);
            //if ((txtBillNotes.xBindingProperty != "") && (txtBillNotes.xBindingProperty != null))
            //    txtBillNotes.BindControl(VendorBillBS, txtBillNotes.xBindingProperty);
            //if ((txtPOID.xBindingProperty != "") && (txtPOID.xBindingProperty != null))
            //    txtPOID.BindControl(VendorBillBS, txtPOID.xBindingProperty);
            //if ((txtBillFreight.xBindingProperty != "") && (txtBillFreight.xBindingProperty != null))
            //    txtBillFreight.BindControl(VendorBillBS, txtBillFreight.xBindingProperty);
            //if ((txtVendorTerms.xBindingProperty != "") && (txtVendorTerms.xBindingProperty != null))
            //    txtVendorTerms.BindControl(VendorBillBS, txtVendorTerms.xBindingProperty);
            //if ((txtBillPayFreightTo.xBindingProperty != "") && (txtBillPayFreightTo.xBindingProperty != null))
            //    txtBillPayFreightTo.BindControl(VendorBillBS, txtBillPayFreightTo.xBindingProperty);
            //if ((txtSaleTaxAmount.xBindingProperty != "") && (txtSaleTaxAmount.xBindingProperty != null))
            //    txtSaleTaxAmount.BindControl(VendorBillBS, txtSaleTaxAmount.xBindingProperty);
            //if ((txtSaleTaxDiscountPrice.xBindingProperty != "") && (txtSaleTaxDiscountPrice.xBindingProperty != null))
            //    txtSaleTaxDiscountPrice.BindControl(VendorBillBS, txtSaleTaxDiscountPrice.xBindingProperty);
            //if ((txtSaleTaxSurchargePrice.xBindingProperty != "") && (txtSaleTaxSurchargePrice.xBindingProperty != null))
            //    txtSaleTaxSurchargePrice.BindControl(VendorBillBS, txtSaleTaxSurchargePrice.xBindingProperty);
            //if ((txtBillTotalAmount.xBindingProperty != "") && (txtBillTotalAmount.xBindingProperty != null))
            //    txtBillTotalAmount.BindControl(VendorBillBS, txtBillTotalAmount.xBindingProperty);


            //if ((ctrBillDate.xBindingProperty != "") && (ctrBillDate.xBindingProperty != null))
            //    ctrBillDate.BindControl(VendorBillBS, ctrBillDate.xBindingProperty);
            //if ((ctrDueDate.xBindingProperty != "") && (ctrDueDate.xBindingProperty != null))
            //    ctrDueDate.BindControl(VendorBillBS, ctrDueDate.xBindingProperty);

            //if ((NumSaleTaxPercent.xBindingProperty != "") && (NumSaleTaxPercent.xBindingProperty != null))
            //    NumSaleTaxPercent.BindControl(VendorBillBS, NumSaleTaxPercent.xBindingProperty);
            //if ((NumSaleTaxDiscountPercent.xBindingProperty != "") && (NumSaleTaxDiscountPercent.xBindingProperty != null))
            //    NumSaleTaxDiscountPercent.BindControl(VendorBillBS, NumSaleTaxDiscountPercent.xBindingProperty);
            //if ((NumSaleTaxSurchargePercent.xBindingProperty != "") && (NumSaleTaxSurchargePercent.xBindingProperty != null))
            //    NumSaleTaxSurchargePercent.BindControl(VendorBillBS, NumSaleTaxSurchargePercent.xBindingProperty);

            //-----------------------------------------------------------------

        }
        void DGVVendorBillList_SearchtxtBox_KeyUp(object sender,EventArgs e) 
        {
            foreach (DataGridViewRow gridView in DGVVendorBillList.TDataGridView.Rows)
            {
                string Type = gridView.Cells["Type"].Value.ToString();
                var check = gridView.Cells["IsPaid"].Value;
                if (Type == "Payment")
                {
                    gridView.Cells["IsPaid"].ReadOnly = true;
                    gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
                }
            }
        }
        void DGVVendorBillList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVVendorBillList.TDataGridView.Rows.Count > 0)
            {
                DataRowView curRow1 = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
                SelectedBillID = Convert.ToInt32(curRow1["BillID"]);

                if (e.ColumnIndex >= 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        string Type = DGVVendorBillList.TDataGridView.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                        if (Type == "Bill")
                        {
                            string DGVColumnName = DGVVendorBillList.TDataGridView.Columns[e.ColumnIndex].Name;
                            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
                            curRow.BeginEdit();
                            if (DGVColumnName == "IsPaid")
                            {
                                if (DGVVendorBillList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                                {
                                    DGVVendorBillList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                                    curRow["IsPaid"] = false;

                                    DGVVendorBillList.TDataGridView.Columns["Discount"].ReadOnly = true;
                                    DGVVendorBillList.TDataGridView.Columns["To Pay"].ReadOnly = true;
                                }
                                else
                                {
                                    DGVVendorBillList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                                    curRow["IsPaid"] = true;
                                    //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
                                    DGVVendorBillList.TDataGridView.Columns["Discount"].ReadOnly = false;
                                    DGVVendorBillList.TDataGridView.Columns["To Pay"].ReadOnly = false;
                                }
                                DGVVendorBillList.TDataGridView.EndEdit();
                                VendorBillBS.EndEdit();
                            }
                            curRow.EndEdit();
                        }
                    }
                }
            }
        }
        void DGVVendorBillList_TDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagrid = (DataGridView)sender;
            string columnName = datagrid.Columns[e.ColumnIndex].Name.ToString();
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
            curRow.BeginEdit();

            decimal BillTotalAmount = Convert.ToDecimal(curRow["BillTotalAmount"]);
            decimal Discount = Convert.ToDecimal(curRow["BillDiscount"]) + Convert.ToDecimal(curRow["Discount"]);
            decimal PaidAmount = Convert.ToDecimal(curRow["TotalPaidAmount"]);
            decimal ToPay = 0;

            curRow["Payable"] = BillTotalAmount - Discount - PaidAmount;

            if (columnName == "Discount")
            {
                ToPay = BillTotalAmount - Discount - PaidAmount;

                if (curRow["IsPaid"] != DBNull.Value)
                {
                    if (!Convert.ToBoolean(curRow["IsPaid"]))
                    {
                        curRow["To Pay"] = 0;
                        curRow["Balance"] = BillTotalAmount - Discount - PaidAmount;
                    }
                    else
                    {
                        curRow["Balance"] = BillTotalAmount - Discount - PaidAmount - ToPay;
                        curRow["To Pay"] = ToPay;
                    }
                }
                else
                    curRow["Balance"] = BillTotalAmount - Discount - PaidAmount - ToPay;

            }
            else if (columnName == "To Pay")
            {
                ToPay = Convert.ToDecimal(curRow["To Pay"]);

                if (curRow["IsPaid"] != DBNull.Value)
                {
                    if (!Convert.ToBoolean(curRow["IsPaid"]))
                    {
                        curRow["To Pay"] = 0;
                        curRow["Balance"] = BillTotalAmount - Discount - PaidAmount;
                    }
                    else
                    {
                        curRow["Balance"] = BillTotalAmount - Discount - PaidAmount - ToPay;
                    }
                }
                else
                    curRow["Balance"] = BillTotalAmount - Discount - PaidAmount - ToPay;
            }
            else
            {
                if (curRow["IsPaid"]!=DBNull.Value)
                {
                    if (Convert.ToBoolean(curRow["IsPaid"]))
                        curRow["To Pay"] = Convert.ToDecimal(curRow["Payable"]);
                    else
                        curRow["To Pay"] = 0;

                    curRow["Balance"] = Convert.ToDecimal(curRow["BillTotalAmount"]) - Convert.ToDecimal(curRow["BillDiscount"]) - Convert.ToDecimal(curRow["Discount"]) - Convert.ToDecimal(curRow["TotalPaidAmount"]) - Convert.ToDecimal(curRow["To Pay"]);

                }
            }

            curRow["ModifyUserID"] = StaticInfo.userid;
            curRow["ModifyDate"] = DateTime.Now;

            curRow.EndEdit();

            DGVVendorBillListCalculatColumns();
        }
        void DGVVendorList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorList.TDataGridView.DataSource).Current;
            SelectedVendorID = Convert.ToInt32(curRow["ID"]);
            if (SelectedVendorID > 0)
            {
                SelectedBillID = 0;
                LoadSelectedVendorVendorBills();
            }
        }
        void ctrVendorPaymentList_Load(object sender, EventArgs e)
        {
            chkboxShowClosedTransactions.Checked = false;
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            DataTable dt = dbClass.obj.FillVendorList();
            VendorBS.DataSource = dt;
            DGVVendorList.SetSource(VendorBS);

            //DGVVendorList.TDataGridView.DataSource = VendorBS;
            //DGVVendorList.TDataGridView.AutoGenerateColumns = true;            
            //DGVVendorList.TDataGridView.Columns["ID"].Visible = false;

            DGVVendorList.TDataGridView.Columns["Name"].Width = 350;
            DGVVendorList.TDataGridView.Columns["Phone"].Width = 120;
            DGVVendorList.TDataGridView.Columns["ContactPerson"].Width = 240;
            ////DGVVendorList.TDataGridView.Columns["Cont Person Phone"].Width = 120;
            DGVVendorList.TDataGridView.Columns["Balance"].Width = 100;
            if (SelectedVendorID > 0)
            {
                LoadSelectedVendorVendorBills();
                int rowIndex = -1;
                foreach (DataGridViewRow row in DGVVendorList.TDataGridView.Rows)
                {
                    string ID = row.Cells["ID"].Value.ToString();
                    if (ID.Equals(SelectedVendorID.ToString()))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                DGVVendorList.TDataGridView.Rows[rowIndex].Cells[0].Selected = true;
            }
        }
        void LoadSelectedVendorVendorBills()
        {
            dbClass.obj.FillVendorBillsByVendorIDforPayments(objDataSet.Tables["VendorBill"], SelectedVendorID);
            VendorBillBS.DataSource = objDataSet.Tables["VendorBill"];
            DGVVendorBillList.TDataGridView.AutoGenerateColumns = true;
            DGVVendorBillList.TDataGridView.Enabled = true;
            DGVVendorBillList.TDataGridView.ReadOnly = false;

            DGVVendorBillList.TDataGridView.DataSource = VendorBillBS;
            DGVVendorBillList.TDataGridView.Sort(DGVVendorBillList.TDataGridView.Columns["BillDate"], ListSortDirection.Ascending);

            foreach (DataGridViewColumn gridColumn in DGVVendorBillList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }

            //---------------------------------------------------------
            DGVVendorBillList.TDataGridView.Columns["BillID"].Width = 40;
            DGVVendorBillList.TDataGridView.Columns["BillID"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillID"].HeaderText = "TransNo";
            DGVVendorBillList.TDataGridView.Columns["BillID"].DisplayIndex = 1;

            DGVVendorBillList.TDataGridView.Columns["BillDate"].Width = 70;
            DGVVendorBillList.TDataGridView.Columns["BillDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVVendorBillList.TDataGridView.Columns["BillDate"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillDate"].HeaderText = "Date";
            DGVVendorBillList.TDataGridView.Columns["BillDate"].DisplayIndex = 2;

            DGVVendorBillList.TDataGridView.Columns["DueDate"].Width = 70;
            DGVVendorBillList.TDataGridView.Columns["DueDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVVendorBillList.TDataGridView.Columns["DueDate"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["DueDate"].HeaderText = "Date Due";
            DGVVendorBillList.TDataGridView.Columns["DueDate"].DisplayIndex = 3;

            DGVVendorBillList.TDataGridView.Columns["Type"].Width = 70;
            DGVVendorBillList.TDataGridView.Columns["Type"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Type"].HeaderText = "Type";
            DGVVendorBillList.TDataGridView.Columns["Type"].DisplayIndex = 4;

            DGVVendorBillList.TDataGridView.Columns["Reference"].Width = 120;
            DGVVendorBillList.TDataGridView.Columns["Reference"].Visible = true;
            //DGVVendorBillList.TDataGridView.Columns["InvoiceNo"].HeaderText = "Reference";
            DGVVendorBillList.TDataGridView.Columns["Reference"].DisplayIndex = 5;

           
            DGVVendorBillList.TDataGridView.Columns["Terms"].Width = 110;
            DGVVendorBillList.TDataGridView.Columns["Terms"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Terms"].DisplayIndex = 6;

            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].HeaderText = "BillTotal";
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].DisplayIndex = 7;

            DGVVendorBillList.TDataGridView.Columns["BillDiscount"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["BillDiscount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillDiscount"].HeaderText = "BillDiscount";
            DGVVendorBillList.TDataGridView.Columns["BillDiscount"].DisplayIndex = 8;

            DGVVendorBillList.TDataGridView.Columns["TotalPaidAmount"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["TotalPaidAmount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["TotalPaidAmount"].HeaderText = "TotalPaid";
            DGVVendorBillList.TDataGridView.Columns["TotalPaidAmount"].DisplayIndex = 9;


            DGVVendorBillList.TDataGridView.Columns["Payable"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["Payable"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Payable"].DisplayIndex = 10;

            DGVVendorBillList.TDataGridView.Columns["Discount"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["Discount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Discount"].DisplayIndex = 11;

            DGVVendorBillList.TDataGridView.Columns["To Pay"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["To Pay"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["To Pay"].DisplayIndex = 12;

            DGVVendorBillList.TDataGridView.Columns["IsPaid"].Width = 30;
            DGVVendorBillList.TDataGridView.Columns["IsPaid"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["IsPaid"].DisplayIndex = 13;
            DGVVendorBillList.TDataGridView.Columns["IsPaid"].ReadOnly = false;

            DGVVendorBillList.TDataGridView.Columns["Balance"].Width = 70;
            DGVVendorBillList.TDataGridView.Columns["Balance"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Balance"].DisplayIndex = 14;

            DGVVendorBillList.TDataGridView.Columns["Notes"].Width = 120;
            DGVVendorBillList.TDataGridView.Columns["Notes"].Visible = true;
            //DGVVendorBillList.TDataGridView.Columns["BillNotes"].HeaderText = "Notes";
            DGVVendorBillList.TDataGridView.Columns["Notes"].DisplayIndex = 15;

            DGVVendorBillList.TDataGridView.Columns["Rep"].Width = 30;
            DGVVendorBillList.TDataGridView.Columns["Rep"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Rep"].DisplayIndex = 16;

            DGVVendorBillList.TDataGridView.Columns["Store"].Width = 150;
            DGVVendorBillList.TDataGridView.Columns["Store"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Store"].DisplayIndex = 17;
            //---------------------------------------------------------
            //chkboxShowBillsOnHold.Checked = false;
            chkboxShowClosedTransactions.Checked = false;
            txtTotalToPay.Text = "";
            txtTotalDiscount.Text = "";
            txtTotalApplied.Text = "";
            //rbtnCash.Checked = true;
            //rbtnCheck.Checked = false;
            //txtCheckNo.Text = "";
            //txtCheckNo.Enabled = false;
            //ctrPaymentDate.DateTimePicker1.Value = DateTime.Now;
            //chkboxPrint.Checked = false;
            //txtNotes.Text = "";
            //---------------------------------------------------------
            foreach (DataGridViewRow gridView in DGVVendorBillList.TDataGridView.Rows)
            {
                string Type = gridView.Cells["Type"].Value.ToString();
                var check = gridView.Cells["IsPaid"].Value;
                if (Type == "Payment")
                {
                    gridView.Cells["IsPaid"].ReadOnly = true;
                    gridView.Cells["IsPaid"].Style.BackColor = Color.LightGreen;
                }
            }

        }
        void DGVVendorBillListCalculatColumns()
        {
            //-------------------------------------------------------------                        
            decimal TotalApplied = 0, TotalDiscount = 0, TotalToPay = 0;
            decimal Payable = 0, billDiscount = 0, ToPay = 0, Balance = 0;

            foreach (DataGridViewRow n in DGVVendorBillList.TDataGridView.Rows)
            {
                if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                {
                    if (Convert.ToBoolean(n.Cells["IsPaid"].Value) == true)
                    {
                        if (n.Cells["Payable"].Value != null) { Payable = Convert.ToDecimal(n.Cells["Payable"].Value); }
                        if (n.Cells["Discount"].Value != null) { billDiscount = Convert.ToDecimal(n.Cells["Discount"].Value); }
                        if (n.Cells["To Pay"].Value != null) { ToPay = Convert.ToDecimal(n.Cells["To Pay"].Value); }

                        TotalApplied += (Payable + billDiscount);
                        TotalDiscount += billDiscount;
                        TotalToPay += ToPay;
                    }
                }
            }

            txtTotalApplied.Text = StaticInfo.SecCurSign + Convert.ToDouble(TotalApplied);
            txtTotalDiscount.Text = StaticInfo.SecCurSign + Convert.ToDouble(TotalDiscount);
            txtTotalToPay.Text = StaticInfo.SecCurSign + Convert.ToDouble(TotalToPay);

        }

        void txtTotalToPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // decimal TotalToPay = 0;


                //if (txtTotalDiscount.Text != "")
                //{
                //    if (Convert.ToDouble(txtTotalDiscount.Text.Replace("$", "")) > 0)
                //        txtTotalApplied.Text = string.Format("{0:C}", Convert.ToDouble(txtTotalToPay.Text.Replace("$", "")) - Convert.ToDouble(txtTotalDiscount.Text.Replace("$", "")));
                //}
                //else
                //{
                //    txtTotalApplied.Text = string.Format("{0:C}", Convert.ToDouble(txtTotalToPay.Text.Replace("$", "")));
                //    txtTotalDiscount.Text = string.Format("{0:C}", 0);
                //}

                txtTotalToPay.Text = StaticInfo.SecCurSign + Convert.ToDouble(txtTotalToPay.Text.Replace("$", ""));
                txtTotalDiscount.Text = StaticInfo.SecCurSign + 0.00;
                txtTotalApplied.Text = StaticInfo.SecCurSign + Convert.ToDouble(txtTotalToPay.Text.Replace("$", ""));

                // TotalToPay = Convert.ToDecimal(txtTotalToPay.Text.Replace("$", ""));

                //foreach (DataGridViewRow n in DGVVendorBillList.TDataGridView.Rows)
                //{
                //    if (Convert.ToDecimal(n.Cells["Payable"].Value) < TotalToPay)
                //    {
                //        //if (Convert.ToBoolean(n.Cells["IsPaid"].Value) == true)
                //        //{
                //        TotalToPay = TotalToPay - Convert.ToDecimal(n.Cells["Balance"].Value);
                //        n.Cells["To Pay"].Value =  Convert.ToDecimal(n.Cells["Balance"].Value);                        
                //        n.Cells["Balance"].Value = 0.0;
                //        n.Cells["IsPaid"].Value = true;
                //    }
                //    else if (Convert.ToDecimal(n.Cells["Payable"].Value) > TotalToPay && TotalToPay > 0)
                //    {
                //        //TotalToPay = TotalToPay - Convert.ToDecimal(n.Cells["Payable"].Value);
                //        n.Cells["To Pay"].Value = TotalToPay;
                //        n.Cells["Balance"].Value = Convert.ToDecimal(n.Cells["Balance"].Value) - TotalToPay;                        
                //        TotalToPay = 0;
                //        n.Cells["IsPaid"].Value = true;
                //    }                        
                //}

            }
            catch (Exception ex){ throw ex; }
        }

        private void btnClearSelected_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            ClearAmount();
        }

        private void ClearAmount() 
        {
            string Type = "";
            foreach (DataGridViewRow n in DGVVendorBillList.TDataGridView.Rows)
            {
                Type = n.Cells["Type"].Value.ToString();
                if (Type == "Bill")
                {
                    if (n.Cells["IsPaid"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["IsPaid"].Value))
                        {
                            n.Cells["IsPaid"].Value = false;
                            //decimal balance = Convert.ToDecimal(n.Cells["Balance"].Value);
                            n.Cells["Balance"].Value = Convert.ToDecimal(n.Cells["Balance"].Value) + Convert.ToDecimal(n.Cells["To Pay"].Value);
                            n.Cells["To Pay"].Value = 0.0.ToString();
                        }

                        //DGVVendorBillList_TDataGridView_CellClick(null, null);
                        //DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
                        //curRow.BeginEdit();
                        //curRow["IsPaid"] = false;
                        //curRow.EndEdit();
                    }
                }
            }
            // txtTotalToPay.Text = "$0.00";
            txtTotalDiscount.Text = "$0.00";
            txtTotalApplied.Text = "$0.00";
        }

        private void btnAutoSelect_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            bool IsPaid = false;
            decimal TotalToPay = 0;
            string Type = "";
            if (!string.IsNullOrEmpty(txtTotalToPay.Text))
            {
                ClearAmount();
                TotalToPay = Convert.ToDecimal(txtTotalToPay.Text.Replace("$", ""));

                txtTotalDiscount.Text = StaticInfo.SecCurSign + 0.00;
                txtTotalApplied.Text = StaticInfo.SecCurSign + Convert.ToDouble(txtTotalToPay.Text.Replace("$", ""));

                foreach (DataGridViewRow n in DGVVendorBillList.TDataGridView.Rows)
                {
                    Type = n.Cells["Type"].Value.ToString();
                    if (Type == "Bill")
                    {
                        if (Convert.ToDecimal(n.Cells["Payable"].Value) <= TotalToPay)
                        {
                            TotalToPay = TotalToPay - Convert.ToDecimal(n.Cells["Balance"].Value);
                            n.Cells["To Pay"].Value = Convert.ToDecimal(n.Cells["Balance"].Value);
                            n.Cells["Balance"].Value = 0.0.ToString();
                            n.Cells["IsPaid"].Value = true;
                        }
                        else if (Convert.ToDecimal(n.Cells["Payable"].Value) > TotalToPay && TotalToPay > 0)
                        {
                            //TotalToPay = TotalToPay - Convert.ToDecimal(n.Cells["Payable"].Value);
                            n.Cells["To Pay"].Value = TotalToPay;
                            n.Cells["Balance"].Value = Convert.ToDecimal(n.Cells["Balance"].Value) - TotalToPay;
                            TotalToPay = 0;
                            n.Cells["IsPaid"].Value = true;
                        }
                        // }
                    }
                }
            }
            else
                xMessageBox.Show("Please Enter amount .....");
        }

        //void txtTotalDiscount_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtTotalDiscount.Text != "")
        //        {
        //            if (Convert.ToDouble(txtTotalDiscount.Text.Replace("$", "")) > 0)
        //                txtTotalApplied.Text = string.Format("{0:C}", Convert.ToDouble(txtTotalToPay.Text.Replace("$", "")) - Convert.ToDouble(txtTotalDiscount.Text.Replace("$", "")));
        //        }
        //        else
        //        {
        //            txtTotalApplied.Text = string.Format("{0:C}", Convert.ToDouble(txtTotalToPay.Text.Replace("$", "")));
        //            txtTotalDiscount.Text = string.Format("{0:C}", 0);
        //        }

        //        txtTotalDiscount.Text = string.Format("{0:C}", Convert.ToDouble(txtTotalDiscount.Text.Replace("$", "")));
        //    }
        //    catch { }
        //}
    }
}
