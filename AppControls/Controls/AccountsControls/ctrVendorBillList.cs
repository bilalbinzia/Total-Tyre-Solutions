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
    public partial class ctrVendorBillList : UserControl
    {
        MainDataSet objDataSet;

        BindingSource VendorBS;
        BindingSource VendorBillBS;
        BindingSource VendorBillDetailsBS;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedVendorID = 0;
        int SelectedVBID = 0;
        //bool IsVendorBillCreated = false;
        public ctrVendorBillList()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();

            VendorBS = new BindingSource();
            VendorBillBS = new BindingSource();
            VendorBillDetailsBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrVendorBillList_Load;
            this.btnNewVendorBill.Click += btnNewVendorBill_Click;
            //btnBillVoid.Click += btnPOVoid_Click;
            this.btnPrintBill.Click += btnPrintBill_Click;

            DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorBillList.TDataGridView.CellEndEdit += DGVVendorBillList_TDataGridView_CellEndEdit;
            DGVVendorBillList.TDataGridView.CellClick += DGVVendorBillList_TDataGridView_CellClick;


            btnShowChecksAppliedToThisBill.Click += btnPOSave_Click;
            //btnNewLine.Click += btnNewLine_Click;

            BindingControls();


        }

        public ctrVendorBillList(int VenID)
        {
            InitializeComponent();
            this.SelectedVendorID = VenID;

            objDataSet = new MainDataSet();

            VendorBS = new BindingSource();
            VendorBillBS = new BindingSource();
            VendorBillDetailsBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrVendorBillList_Load;
            this.btnNewVendorBill.Click += btnNewVendorBill_Click;
            //btnBillVoid.Click += btnPOVoid_Click;
            this.btnPrintBill.Click += btnPrintBill_Click;

            DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorBillList.TDataGridView.CellEndEdit += DGVVendorBillList_TDataGridView_CellEndEdit;
            DGVVendorBillList.TDataGridView.CellClick += DGVVendorBillList_TDataGridView_CellClick;


            btnShowChecksAppliedToThisBill.Click += btnPOSave_Click;
            //btnNewLine.Click += btnNewLine_Click;

            BindingControls();


        }

        void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (SelectedVBID > 0)
                StaticInfo.LoadToReport("RptModule", "Reports.VendorBillReport", "byID", SelectedVBID);
        }


        void btnPOVoid_Click(object sender, EventArgs e)
        {
            foreach (DataRowView BSRow in VendorBillDetailsBS)
            {
                if (Convert.ToInt32(BSRow["PrevRcvd"]) > 0)
                {
                    xMessageBox.Show("You cannot void this Purchase Order because at least part of it has been billed or received ...");
                    return;
                }
            }
            //----------------------------------------------------
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
            try
            {
                if (xMessageBox.Show("Do you want to Void this Bill ..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!Convert.ToBoolean(curRow["IsProcessed"]))
                    {
                        foreach (DataRowView BSRow in VendorBillDetailsBS)
                            BSRow.Delete();

                        dbClass.obj.UpdateTable(objDataSet.Tables["VendorBillDetails"]);

                    }
                }
            }
            catch { }
        }
        void btnPODetailCancel_Click(object sender, EventArgs e)
        {
            VendorBillDetailsBS.CancelEdit();
            ((DataTable)VendorBillDetailsBS.DataSource).RejectChanges();
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
            //if ((txtGridTotalQty.xBindingProperty != "") && (txtGridTotalQty.xBindingProperty != null))
            //    txtGridTotalQty.BindControl(VendorBillBS, txtGridTotalQty.xBindingProperty);
            //if ((txtGridTotalAmount.xBindingProperty != "") && (txtGridTotalAmount.xBindingProperty != null))
            //    txtGridTotalAmount.BindControl(VendorBillBS, txtGridTotalAmount.xBindingProperty);

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

        }

        void DGVVendorBillList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
            if (curRow != null)
                SelectedVBID = Convert.ToInt32(curRow["ID"]);

            //pnlAcc.Visible = true;
            //pnlAccTerms.Visible = true;

            LoadSelectedVendorBillsAccountsDetail(Convert.ToInt32(curRow["BillID"]));
            try
            {
                string DGVColumnName = DGVVendorBillList.TDataGridView.Columns[e.ColumnIndex].Name;
                if (DGVColumnName == "btnBillDetail")
                {
                    LoadSelectedBillDetail(curRow);                    
                }
            }
            catch { }
        }
        void DGVVendorBillList_TDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorBillList.TDataGridView.DataSource).Current;
            curRow.BeginEdit();
            curRow["ModifyUserID"] = StaticInfo.userid;
            curRow["ModifyDate"] = DateTime.Now;
            curRow.EndEdit();
        }
        void DGVPODetail_CellEndEdit(DataRowView curRow)
        {

            curRow.BeginEdit();

            if (curRow["QtyOrdrd"] == DBNull.Value) curRow["QtyOrdrd"] = 0;
            if (curRow["PrevOrdrd"] == DBNull.Value) curRow["PrevOrdrd"] = 0;

            if (curRow["QtyRcvd"] == DBNull.Value) curRow["QtyRcvd"] = 0;
            if (curRow["PrevRcvd"] == DBNull.Value) curRow["PrevRcvd"] = 0;

            if (curRow["QtyBilled"] == DBNull.Value) curRow["QtyBilled"] = 0;
            if (curRow["PrevBilled"] == DBNull.Value) curRow["PrevBilled"] = 0;

            if (curRow["Cost"] == DBNull.Value) curRow["Cost"] = 0;
            if (curRow["FET"] == DBNull.Value) curRow["FET"] = 0;
            if (curRow["Amount"] == DBNull.Value) curRow["Amount"] = 0;

            try
            {
                Int32 QtyOrdrd = 0, PrevOrdrd = 0, QtyRcvd = 0, PrevRcvd = 0, QtyBilled = 0, PrevBilled = 0;
                decimal Cost = 0, FET = 0; //, Amount = 0;

                if (curRow["QtyOrdrd"] != DBNull.Value)
                    QtyOrdrd = Convert.ToInt32(curRow["QtyOrdrd"]);
                if (curRow["PrevOrdrd"] != DBNull.Value)
                    PrevOrdrd = Convert.ToInt32(curRow["PrevOrdrd"]);
                if (curRow["QtyRcvd"] != DBNull.Value)
                    QtyRcvd = Convert.ToInt32(curRow["QtyRcvd"]);
                if (curRow["PrevRcvd"] != DBNull.Value)
                    PrevRcvd = Convert.ToInt32(curRow["PrevRcvd"]);
                if (curRow["QtyBilled"] != DBNull.Value)
                    QtyBilled = Convert.ToInt32(curRow["QtyBilled"]);
                if (curRow["PrevBilled"] != DBNull.Value)
                    PrevBilled = Convert.ToInt32(curRow["PrevBilled"]);
                if (curRow["Cost"] != DBNull.Value)
                    Cost = Convert.ToDecimal(curRow["Cost"]);
                if (curRow["FET"] != DBNull.Value)
                    FET = Convert.ToDecimal(curRow["FET"]);

                curRow["Amount"] = (QtyOrdrd + PrevOrdrd + QtyRcvd + PrevRcvd) * (Cost + FET);

                //else
                //    curRow["PendingQty"] = 0;

                //if (curRow["CurrentPrice"] != DBNull.Value)
                //    CurrentPrice = Convert.ToInt32(curRow["CurrentPrice"]);
                //if (curRow["CurrentFET"] != DBNull.Value)
                //    CurrentFET = Convert.ToInt32(curRow["CurrentFET"]);

                //if (curRow["CurrentPrice"] != DBNull.Value)
                //    curRow["BillAmount"] = (CurrentPrice + CurrentFET) * OrderQty;
                //if (ReceivedQty > 0)
                //    curRow["BillAmount"] = (CurrentPrice + CurrentFET) * ReceivedQty;

            }
            catch { }

            curRow.EndEdit();
            //-----------------------------------------------------
            //dbClass.obj.UpdateTable(objDataSet.Tables["VendorBillDetails"]);

        }
        void LoadSelectedBillDetail(DataRowView curRow)
        {
            if (curRow != null)
            {
                ctrVendorBillDetail ctrVendorBillDetails = new ctrVendorBillDetail(Convert.ToInt32(curRow["ID"]), objDataSet, VendorBillBS);
                //----------------------------------------------------------------------//
                frmCtr frmCtr = new frmCtr("Vendor Bill Detail");                
                frmCtr.Height = ctrVendorBillDetails.Height + 50; frmCtr.Width = ctrVendorBillDetails.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(ctrVendorBillDetails);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }            
        }
        void btnPOSave_Click(object sender, EventArgs e)
        {
            dbClass.obj.UpdateTable(objDataSet.Tables["VendorBill"]);
        }
        void btnNewLine_Click(object sender, EventArgs e)
        {
            if (SelectedVBID > 0)
            {
                ctrAccountList objAccountList = new ctrAccountList();
                objAccountList.AccountSelected += objAccountList_AccountSelected;
                frmCtr frmCtrVendorBillAddItem = new frmCtr("Select Account for New Line ...");                
                frmCtrVendorBillAddItem.Height = objAccountList.Height + 40;
                frmCtrVendorBillAddItem.Width = objAccountList.Width + 20;
                frmCtrVendorBillAddItem.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtrVendorBillAddItem.frmPnl.Controls.Add(objAccountList);
                frmCtrVendorBillAddItem.BringToFront();
                frmCtrVendorBillAddItem.ShowDialog();
            }
        }

        void objAccountList_AccountSelected(object sender, DataRow dataRow)
        {
            //DGVBillAccounts
        }
        void btnPODetailSave_Click(object sender, EventArgs e)
        {
            dbClass.obj.UpdateTable(objDataSet.Tables["VendorBillDetails"]);
        }
        void DGVVendorList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorList.TDataGridView.DataSource).Current;
            SelectedVendorID = Convert.ToInt32(curRow["ID"]);
            if (SelectedVendorID > 0)
            {
                LoadSelectedVendorVendorBills();                
            }
            //pnlAcc.Visible = false;
            //pnlAccTerms.Visible = false;
        }
        void btnNewVendorBill_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase Details", SelectedVendorID);
           
            //if (SelectedVendorID > 0)
            //{
            //    int NewVendorBill = dbClass.obj.getNextVendorBillAutoNo();
            //    if (NewVendorBill > 0)
            //    {
            //        //--DataRow------------------------
            //        DataRow dr = objDataSet.Tables["VendorBill"].NewRow();
            //        dr["VendorID"] = SelectedVendorID;
            //        dr["BillID"] = NewVendorBill;
            //        dr["DiscountPer"] = 0;
            //        dr["PODate"] = DateTime.Now;
            //        dr["WarehouseID"] = StaticInfo.CompanyID;
            //        dr["StoreID"] = StaticInfo.StoreID;

            //        dr["Active"] = true;
            //        dr["AddDate"] = DateTime.Now;
            //        dr["AddUserID"] = StaticInfo.userid;
            //        dr["IsLocked"] = true;
            //        //---------------------------------
            //        objDataSet.Tables["VendorBill"].Rows.Add(dr);
            //        //---------------------------------
            //        dbClass.obj.UpdateTable(objDataSet.Tables["VendorBill"]);
            //    }
            //    LoadSelectedVendorVendorBills();
            //}
            //else
            //    xMessageBox.Show("Select Vendor for New VendorBill ...");
        }

        List<Control> controlList = new List<Control>();
        void ctrVendorBillList_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            findControlsOfType(typeof(Label), this.Controls, ref controlList);
            findControlsOfType(typeof(TACheckBox), this.Controls, ref controlList);
            foreach (Control ctr in controlList.ToList())
                ctr.ForeColor = StaticInfo.ctrLabelForeColor;
            //-------------------------------------------------
            DataTable dt = dbClass.obj.FillVendorList();
            VendorBS.DataSource = dt;
            DGVVendorList.SetSource(VendorBS);

            //DGVVendorList.TDataGridView.DataSource = VendorBS;

            //DGVVendorList.TDataGridView.AutoGenerateColumns = true;
            //DGVVendorList.TDataGridView.Columns["ID"].Visible = false;

            DGVVendorList.TDataGridView.Columns["Name"].Width = 350;
            ////DGVVendorList.TDataGridView.Columns["City"].Width = 120;
            DGVVendorList.TDataGridView.Columns["Phone"].Width = 150;
            DGVVendorList.TDataGridView.Columns["ContactPerson"].Width = 240;
            ////DGVVendorList.TDataGridView.Columns["Cont Person Phone"].Width = 120;
            DGVVendorList.TDataGridView.Columns["Balance"].Width = 100;
        }
        void findControlsOfType(Type type, Control.ControlCollection formControls, ref List<Control> controls)
        {
            foreach (Control control in formControls)
            {
                if (control.GetType() == type)
                    controls.Add(control);
                if (control.Controls.Count > 0)
                    findControlsOfType(type, control.Controls, ref controls);
            }
        }
        void LoadSelectedVendorVendorBills()
        {
            dbClass.obj.FillVendorBillsByVendorID(objDataSet.Tables["VendorBill"], SelectedVendorID);
            VendorBillBS.DataSource = objDataSet.Tables["VendorBill"];
            DGVVendorBillList.TDataGridView.AutoGenerateColumns = true;
            DGVVendorBillList.TDataGridView.Enabled = true;
            DGVVendorBillList.TDataGridView.ReadOnly = false;

            DGVVendorBillList.TDataGridView.DataSource = VendorBillBS;

            foreach (DataGridViewColumn gridColumn in DGVVendorBillList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }
            
            DGVVendorBillList.TDataGridView.Columns["BillID"].Width = 50;
            DGVVendorBillList.TDataGridView.Columns["BillID"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillID"].HeaderText = "TransNo";
            DGVVendorBillList.TDataGridView.Columns["BillID"].DisplayIndex = 1;

            DGVVendorBillList.TDataGridView.Columns["Type"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["Type"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Type"].DisplayIndex = 2;
            
            DGVVendorBillList.TDataGridView.Columns["BillDate"].Width = 80;
            DGVVendorBillList.TDataGridView.Columns["BillDate"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillDate"].HeaderText = "Date";
            DGVVendorBillList.TDataGridView.Columns["BillDate"].DisplayIndex = 3;

            DGVVendorBillList.TDataGridView.Columns["DueDate"].Width = 80;
            DGVVendorBillList.TDataGridView.Columns["DueDate"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["DueDate"].HeaderText = "Date Due";
            DGVVendorBillList.TDataGridView.Columns["DueDate"].DisplayIndex = 4;

            DGVVendorBillList.TDataGridView.Columns["Reference"].Width = 220;
            DGVVendorBillList.TDataGridView.Columns["Reference"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Reference"].DisplayIndex = 5;

            DGVVendorBillList.TDataGridView.Columns["Notes"].Width = 220;
            DGVVendorBillList.TDataGridView.Columns["Notes"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Notes"].DisplayIndex = 6;

            DGVVendorBillList.TDataGridView.Columns["Terms"].Width = 80;
            DGVVendorBillList.TDataGridView.Columns["Terms"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Terms"].DisplayIndex = 7;

            DGVVendorBillList.TDataGridView.Columns["BillQty"].Width = 50;
            DGVVendorBillList.TDataGridView.Columns["BillQty"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillQty"].DisplayIndex = 8;

            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].Width = 90;
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].HeaderText = "Amount";
            DGVVendorBillList.TDataGridView.Columns["BillTotalAmount"].DisplayIndex = 9;

            DGVVendorBillList.TDataGridView.Columns["Open Amount"].Width = 90;
            DGVVendorBillList.TDataGridView.Columns["Open Amount"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Open Amount"].DisplayIndex = 10;

            DGVVendorBillList.TDataGridView.Columns["Rep"].Width = 50;
            DGVVendorBillList.TDataGridView.Columns["Rep"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Rep"].DisplayIndex = 11;

            DGVVendorBillList.TDataGridView.Columns["Status"].Width = 60;
            DGVVendorBillList.TDataGridView.Columns["Status"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Status"].DisplayIndex = 12;

            DGVVendorBillList.TDataGridView.Columns["Store"].Width = 150;
            DGVVendorBillList.TDataGridView.Columns["Store"].Visible = true;
            DGVVendorBillList.TDataGridView.Columns["Store"].DisplayIndex = 13;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Detail";
            col.Name = "btnBillDetail";
            col.HeaderText = "Detail";
            col.Width = 50;
            DGVVendorBillList.TDataGridView.Columns.Add(col);


        }
        void LoadSelectedVendorBillsAccountsDetail(int selectedVBID)
        {
            //if (selectedVBID > 0)
            //{
            //    dbClass.obj.FillVendorBillAccountDetailsByVBID(objDataSet.Tables["VendorBillAccountDetails"], selectedVBID);
            //    DGVBillAccounts.DataSource = objDataSet.Tables["VendorBillAccountDetails"];
            //    if (objDataSet.Tables["VendorBillAccountDetails"].Rows.Count > 0)
            //    {
            //        txtReference.Text = Convert.ToString(objDataSet.Tables["VendorBillAccountDetails"].Rows[0]["RefNo"]);
            //        txtNotes.Text = Convert.ToString(objDataSet.Tables["VendorBillAccountDetails"].Rows[0]["Notes"]);
            //    }
            //}   
        }

        private void DGVVendorList_Load(object sender, EventArgs e)
        {

        }

        //void LoadSelectedVBIDVendorBillDetails(DataRowView curRow)
        //{
        //    SelectedVBID = Convert.ToInt32(curRow["ID"]);
        //    if (SelectedVBID > 0)
        //    {
        //        dbClass.obj.FillVendorBillDetailsByVBID(objDataSet.Tables["VendorBillDetails"], SelectedVBID);
        //        DGVPOBillDetails.DataSource = objDataSet.Tables["VendorBillDetails"];
        //    }           
        //}


    }
}
