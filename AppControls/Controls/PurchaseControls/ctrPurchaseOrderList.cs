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
    public partial class ctrPurchaseOrderList : UserControl
    {
        MainDataSet objDataSet;

        BindingSource VendorBS;
        BindingSource PurchaseOrderBS;
        BindingSource PurchaseOrderDetailsBS;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedVendorID = 0;
        int SelectedPOID = 0;
        int SelectedItemID = 0;
        bool IsVendorBillCreated = false;
        int IsDone = 0;
        public ctrPurchaseOrderList()
        {
            Initialize();
        }
        public ctrPurchaseOrderList(int VendroID)
        {
            this.SelectedVendorID = VendroID;
            Initialize();
        }
        public void Initialize() { 
            InitializeComponent();

            objDataSet = new MainDataSet();

            VendorBS = new BindingSource();
            PurchaseOrderBS = new BindingSource();
            PurchaseOrderDetailsBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrPurchaseOrderList_Load;
            btnNewPurchaseOrder.Click += btnNewPurchaseOrder_Click;
            btnPOVoid.Click += btnPOVoid_Click;

            DGVVendorList.TDataGridView.CellClick += DGVVendorList_TDataGridView_CellClick;
            DGVVendorList.SearchtxtBox.KeyUp += DGVVendorList_SearchtxtBox_KeyUp;                
            DGVPurchaseOrderList.TDataGridView.CellEndEdit += DGVPurchaseOrderList_TDataGridView_CellEndEdit;
            DGVPurchaseOrderList.TDataGridView.CellClick += DGVPurchaseOrderList_TDataGridView_CellClick;
            DGVPurchaseOrderList.SearchtxtBox.KeyUp += DGVPurchaseOrderList_SearchtxtBox_KeyUp;

            DGVPODetail.AddGridColumn(StaticInfo.gColumnType.DelColumn, "X", "x", 30, 30, "", 0);
            DGVPODetail.SetSource(PurchaseOrderDetailsBS);
            DGVPODetail.CellEndEdit += DGVPODetail_CellEndEdit;
            DGVPODetail.CellClick += DGVPODetail_CellClick;

            txtCatalog.KeyDown += txtCatalog_KeyDown;
            btnNewLine.Click += btnNewLine_Click;
            btnPOSave.Click += btnPOSave_Click;

            btnPODetailSave.Click += btnPODetailSave_Click;
            btnPODetailCancel.Click += btnPODetailCancel_Click;

            btnProcessAllChanges.Click += btnProcessAllChanges_Click;
            btnReceivedAllOrdered.Click += btnReceivedAllOrdered_Click;
            btnClearBackOrders.Click += btnClearBackOrders_Click;
            btnBillAllReceived.Click += btnBillAllReceived_Click;

            btnPrintPO.Click += btnPrintPO_Click;
            btnWarrantyClaim.Click += btnWarrantyClaim_Click;

            BindingControls();
        }
        void btnWarrantyClaim_Click(object sender, EventArgs e)
        {
            if ((SelectedVendorID > 0) && (SelectedPOID > 0) && (SelectedItemID > 0))
            {
                ctrWarrantyClaim objctrWarrantyClaim = new ctrWarrantyClaim(SelectedVendorID, SelectedPOID, SelectedItemID);
                frmCtr frmCtrWarrantyClaim = new frmCtr("Warranty Claim ...");                                
                frmCtrWarrantyClaim.Height = objctrWarrantyClaim.Height + 40;
                frmCtrWarrantyClaim.Width = objctrWarrantyClaim.Width + 20;
                frmCtrWarrantyClaim.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtrWarrantyClaim.frmPnl.Controls.Add(objctrWarrantyClaim);
                frmCtrWarrantyClaim.BringToFront();
                frmCtrWarrantyClaim.ShowDialog();
            }
            else
            {
                xMessageBox.Show("Select PO item for warranty claim... ");
            }
        }
        void btnPrintPO_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                StaticInfo.LoadToReport("RptModule", "Reports.PurchaseOrderReport", "byID", SelectedPOID);
            }
            else
            {
                xMessageBox.Show("Select PO for report...");
            }
        }
        void btnBillAllReceived_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                List<int> IsDonelst = new List<int>();
                int rowaffectedA = 0;
                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                {
                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                    Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                    Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                    BSRow.BeginEdit();
                    if (QtyD > 0)
                    {
                        if (QtyD >= (QtyE + QtyF))
                        {
                            BSRow["QtyBilled"] = QtyD - QtyF;
                            if ((QtyD - QtyF) > 0)
                                rowaffectedA += 1;
                        }
                        else
                        {
                            xMessageBox.Show("Bill quantity is bigger then received quantity.....", "Information");
                            return;
                        }
                    }

                    BSRow.EndEdit();
                }
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                //-------------------------------------------------------------------
                if (rowaffectedA > 0)
                {
                    if (xMessageBox.Show(rowaffectedA + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
                        DataTable dtPO = objDataSet.Tables["PurchaseOrder"].Clone();
                        DataRow DR = (DataRow)curRow.Row;
                        dtPO.Rows.Add(DR.ItemArray);

                        DataTable dtPOD = objDataSet.Tables["PurchaseOrderDetails"].Clone();
                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                            Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                            Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                            BSRow.BeginEdit();
                            if (QtyD > 0)
                            {
                                if ((QtyE + QtyF) <= QtyD)
                                {
                                    if (Convert.ToDecimal(BSRow["Cost"]) > 0)
                                    {
                                        DataRow DRDetail = (DataRow)BSRow.Row;
                                        dtPOD.Rows.Add(DRDetail.ItemArray);
                                    }
                                    else
                                    {
                                        xMessageBox.Show("Bill can not be generated with 0 cost ....", "Information..");
                                        return;
                                    }
                                    if ((QtyA + QtyB) == (QtyC + QtyD) && (QtyC + QtyD) == (QtyE + QtyF))
                                        IsDonelst.Add(1);
                                    else
                                        IsDonelst.Add(0);
                                }
                            }
                            BSRow.EndEdit();
                        }
                        if (dtPOD.Rows.Count > 0)
                        {
                            IsVendorBillCreated = false;
                            //Generate bill-------form                        
                            ctrPurchaseOrderVendorBill objctrPurchaseOrderVendorBill = new ctrPurchaseOrderVendorBill(dtPO, dtPOD);
                            objctrPurchaseOrderVendorBill.vendorBillDetailsDelegate += objctrPurchaseOrderVendorBill_vendorBillDetailsDelegate;
                            //-------------------------------------------------------------------------------//
                            frmCtr frmCtrPurchaseOrderVendorBill = new frmCtr("Vendor Bill from Purchase Order ...");
                            frmCtrPurchaseOrderVendorBill.Height = objctrPurchaseOrderVendorBill.Height + 40;
                            frmCtrPurchaseOrderVendorBill.Width = objctrPurchaseOrderVendorBill.Width + 20;
                            frmCtrPurchaseOrderVendorBill.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                            frmCtrPurchaseOrderVendorBill.frmPnl.Controls.Add(objctrPurchaseOrderVendorBill);
                            frmCtrPurchaseOrderVendorBill.BringToFront();
                            frmCtrPurchaseOrderVendorBill.ShowDialog();
                            //-----------------------------------------------------------------
                            if (IsVendorBillCreated)
                            {

                                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                                {
                                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                                    Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                                    Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                                    BSRow.BeginEdit();
                                    if (QtyE > 0)
                                    {
                                        if ((QtyE + QtyF) <= QtyD)
                                        {
                                            BSRow["QtyBilled"] = 0;
                                            BSRow["PrevBilled"] = QtyF + QtyE;
                                        }
                                    }
                                    BSRow.EndEdit();
                                }

                                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                                PurchaseOrderDetailsCalculatColumns();
                            }
                            //-----------------------------------------------------------------                        
                        }
                        else
                        {
                            xMessageBox.Show("All items are updated...");
                        }
                        if (IsVendorBillCreated)
                        {
                            if (IsDonelst.Contains(0))
                                IsDone = 0;
                            else
                                IsDone = 1;
                            if (curRow["POID"] != DBNull.Value)
                            {
                                int POID = Convert.ToInt32(curRow["POID"]);
                                dbClass.obj.UpdatePurchaseOrder(POID, IsDone);
                            }
                        }
                    }
                }
                else
                {
                    xMessageBox.Show("All items are updated...");
                }
                //-------------------------------------------------------------------           
                PurchaseOrderDetailsCalculatColumns();
                LoadSelectedVendorPurchaseOrders();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
            //-------------------------------------------------------------------
        }
        void btnProcessAllChanges_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                int rowaffectedA = 0;
                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                {
                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                    Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                    Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                    BSRow.BeginEdit();                
                    //----------------------------------------------
                    BSRow["PrevOrdrd"] = QtyB + QtyA;
                    BSRow["QtyOrdrd"] = 0;
                                    
                    BSRow["PrevRcvd"] = QtyC + QtyD;
                    BSRow["QtyRcvd"] = 0;

                    QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);                
                    QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                    if (QtyD > QtyB)                
                        BSRow["PrevOrdrd"] = BSRow["PrevRcvd"];

                    //----------------------------------------------                
                    if(QtyE > 0)
                    {
                        if ((QtyE + QtyF) <= QtyD)
                            rowaffectedA += 1;
                        else
                        {
                            xMessageBox.Show("Bill quantity is bigger then received quantity.....","Information");
                            return;
                        }
                    }
                    //----------------------------------------------
                    BSRow["CompanyID"] = StaticInfo.CompanyID;
                    BSRow["WarehouseID"] = (StaticInfo.WarehouseID == 0 || string.IsNullOrWhiteSpace(StaticInfo.WarehouseID.ToString())) ? 1 : StaticInfo.WarehouseID;
                    BSRow["StoreID"] = (StaticInfo.StoreID == 0 || string.IsNullOrWhiteSpace(StaticInfo.StoreID.ToString())) ? 1 : StaticInfo.StoreID;
                    BSRow.EndEdit();
                }
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                //-------------------------------------------------------------------
                if (rowaffectedA > 0)
                {
                    List<int> IsDonelst = new List<int>();
                    if (xMessageBox.Show(rowaffectedA + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
                        DataTable dtPO = objDataSet.Tables["PurchaseOrder"].Clone();
                        DataRow DR = (DataRow)curRow.Row;
                        dtPO.Rows.Add(DR.ItemArray);

                        DataTable dtPOD = objDataSet.Tables["PurchaseOrderDetails"].Clone();

                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                            Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                            Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                            BSRow.BeginEdit();
                            if (QtyE > 0)
                            {
                                if ((QtyE + QtyF) <= QtyD)
                                {
                                    if (Convert.ToDecimal(BSRow["Cost"]) > 0)
                                    {
                                        DataRow DRDetail = (DataRow)BSRow.Row;
                                        dtPOD.Rows.Add(DRDetail.ItemArray);
                                    }
                                    else
                                    {
                                        xMessageBox.Show("Bill can not be generated with 0 cost ....", "Information..");
                                        return;
                                    }
                                }
                                if ((QtyA + QtyB) == (QtyC + QtyD) && (QtyC + QtyD) == (QtyE + QtyF))
                                    IsDonelst.Add(1);
                                else
                                    IsDonelst.Add(0);
                            }
                            BSRow.EndEdit();
                        }
                        if (dtPOD.Rows.Count > 0)
                        {
                            IsVendorBillCreated = false;
                            //Generate bill-------form                        
                            ctrPurchaseOrderVendorBill objctrPurchaseOrderVendorBill = new ctrPurchaseOrderVendorBill(dtPO, dtPOD);
                            objctrPurchaseOrderVendorBill.vendorBillDetailsDelegate += objctrPurchaseOrderVendorBill_vendorBillDetailsDelegate;
                            //----------------------------------------------------------------------//
                            frmCtr frmCtrPurchaseOrderVendorBill = new frmCtr("Vendor Bill from Purchase Order ...");
                            frmCtrPurchaseOrderVendorBill.Height = objctrPurchaseOrderVendorBill.Height + 40;
                            frmCtrPurchaseOrderVendorBill.Width = objctrPurchaseOrderVendorBill.Width + 20;
                            frmCtrPurchaseOrderVendorBill.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                            frmCtrPurchaseOrderVendorBill.frmPnl.Controls.Add(objctrPurchaseOrderVendorBill);
                            frmCtrPurchaseOrderVendorBill.BringToFront();
                            frmCtrPurchaseOrderVendorBill.ShowDialog();
                            //-----------------------------------------------------------------//
                            if (IsVendorBillCreated)
                            {
                                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                                {
                                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                                    Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                                    Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                                    BSRow.BeginEdit();
                                    if (QtyE > 0)
                                    {
                                        if ((QtyE + QtyF) <= QtyD)
                                        {
                                            BSRow["QtyBilled"] = 0;
                                            BSRow["PrevBilled"] = QtyF + QtyE;
                                        }
                                    }
                                    BSRow.EndEdit();
                                }

                                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                                PurchaseOrderDetailsCalculatColumns();
                            }
                            //-----------------------------------------------------------------                        
                        }
                        else
                        {
                            xMessageBox.Show("All items are updated...");
                        }
                        if (IsVendorBillCreated)
                        {
                            if (IsDonelst.Contains(0))
                                IsDone = 0;
                            else
                                IsDone = 1;
                            if (curRow["POID"] != DBNull.Value)
                            {
                                int POID = Convert.ToInt32(curRow["POID"]);
                                dbClass.obj.UpdatePurchaseOrder(POID, IsDone);
                            }
                        }              
                    }
                }
                else
                {
                    xMessageBox.Show("All items are updated...");
                }
                //-------------------------------------------------------------------             
                PurchaseOrderDetailsCalculatColumns();
                PurchaseOrderDetailsBS.CancelEdit();
                ((DataTable)PurchaseOrderDetailsBS.DataSource).RejectChanges();
                LoadSelectedVendorPurchaseOrders();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
        }
        void objctrPurchaseOrderVendorBill_vendorBillDetailsDelegate(object sender, DataRow dataRow)
        {
            if (dataRow != null)
                IsVendorBillCreated = true;
        }
        void btnClearBackOrders_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                int rowaffectedA = 0, rowaffectedB = 0;
                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                {
                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                    BSRow.BeginEdit();
                    if (QtyD == 0)
                    {
                        if (QtyA > 0)
                        {
                            BSRow["QtyOrdrd"] = 0;
                        }
                    }
                    if (QtyC > 0)
                    {
                        BSRow["QtyOrdrd"] = QtyC;
                        rowaffectedB += 1;                    
                    }
                    if (QtyB > 0)
                    {
                        if (QtyC == 0)
                        {
                            int backQty = QtyD - QtyB;
                            BSRow["QtyOrdrd"] = backQty;
                            if (backQty < 0)
                                rowaffectedA += 1;
                        }
                    }
                    BSRow.EndEdit();
                }
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                //-------------------------------------------------------------------
                if (rowaffectedA > 0)
                {
                    if (xMessageBox.Show(rowaffectedA + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                            BSRow.BeginEdit();
                            if (QtyA < 0)
                                BSRow["PrevOrdrd"] = QtyB + QtyA;
                            if (QtyA > 0)
                                BSRow["PrevOrdrd"] = QtyB - QtyA;
                            BSRow["QtyOrdrd"] = 0;
                            BSRow["QtyRcvd"] = 0;
                            BSRow.EndEdit();
                        }
                        dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                    }
                }
                //-------------------------------------------------------------------
                if (rowaffectedB > 0)
                {
                    if (xMessageBox.Show(rowaffectedA + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                            BSRow.BeginEdit();
                            BSRow["PrevOrdrd"] = QtyC + QtyD;
                            BSRow["PrevRcvd"] = QtyC + QtyD;
                            BSRow["QtyOrdrd"] = 0;
                            BSRow["QtyRcvd"] = 0;
                            BSRow.EndEdit();
                        }
                        dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                    }
                }
                if (rowaffectedA <= 0 && rowaffectedB <= 0)
                {
                    xMessageBox.Show("All items are updated...");
                }
                PurchaseOrderDetailsCalculatColumns();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
            //-------------------------------------------------------------------
        }
        void btnReceivedAllOrdered_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                int rowaffectedA = 0, rowaffectedB = 0;
                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                {
                    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                    BSRow.BeginEdit();
                    //if (QtyB == QtyD)
                    //{
                    //    BSRow["QtyOrdrd"] = 0;
                    //    BSRow["QtyRcvd"] = 0;
                    //}
                    if (QtyA > 0)
                    {
                        BSRow["QtyRcvd"] = QtyA;
                        rowaffectedA += 1;
                    }
                    if (QtyB > QtyD)
                    {
                        BSRow["QtyRcvd"] = QtyB - QtyD;
                        rowaffectedB += 1;
                    }
                    if ((QtyA == 0) && (QtyC > 0))
                    {
                        BSRow["QtyRcvd"] = 0;
                    }

                    BSRow.EndEdit();
                }
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                //-------------------------------------------------------------------
                if (rowaffectedA > 0)
                {
                    if (xMessageBox.Show(rowaffectedA + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                            BSRow.BeginEdit();
                            BSRow["QtyOrdrd"] = 0;
                            BSRow["QtyRcvd"] = 0;
                            BSRow["PrevOrdrd"] = QtyB + QtyA;
                            BSRow["PrevRcvd"] = QtyC + QtyD;
                            BSRow.EndEdit();
                        }
                        dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                    }
                }
                //-------------------------------------------------------------------
                if (rowaffectedB > 0)
                {
                    if (xMessageBox.Show(rowaffectedB + " line(s) were affected. Process all changes..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                        {
                            Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                            Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                            Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                            Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);

                            BSRow.BeginEdit();
                            BSRow["PrevRcvd"] = QtyD + QtyC;
                            BSRow["QtyRcvd"] = 0;
                            BSRow.EndEdit();
                        }
                        dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                    }
                }
                if (rowaffectedA <= 0 && rowaffectedB <= 0)
                {
                    xMessageBox.Show("All items are updated...");
                }
                PurchaseOrderDetailsCalculatColumns();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
            //-------------------------------------------------------------------
        }                
        void btnPOVoid_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                {
                    if (Convert.ToInt32(BSRow["PrevRcvd"]) > 0)
                    {
                        xMessageBox.Show("You cannot void this Purchase Order because at least part of it has been billed or received ...");
                        return;
                    }
                }
                //----------------------------------------------------
                DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
                try
                {
                    if (xMessageBox.Show("Do you want to Void this Purchase Order ..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (Convert.ToBoolean(curRow["Active"]))
                        {
                            foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                                BSRow.Delete();
                            dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                            curRow.Delete();
                            PurchaseOrderDetailsCalculatColumns();
                        }
                    }
                }
                catch { }
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
        }
        void btnPODetailCancel_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                PurchaseOrderDetailsBS.CancelEdit();
                ((DataTable)PurchaseOrderDetailsBS.DataSource).RejectChanges();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
        }
        void BindingControls()
        {
            PurchaseOrderBS.DataSource = objDataSet.Tables["PurchaseOrder"];

            if ((txtTotalQtyOrder.xBindingProperty != "") && (txtTotalQtyOrder.xBindingProperty != null))
                txtTotalQtyOrder.BindControl(PurchaseOrderBS, txtTotalQtyOrder.xBindingProperty);
            if ((txtTotalQtyReceived.xBindingProperty != "") && (txtTotalQtyReceived.xBindingProperty != null))
                txtTotalQtyReceived.BindControl(PurchaseOrderBS, txtTotalQtyReceived.xBindingProperty);
            if ((txtTotalQtyBilled.xBindingProperty != "") && (txtTotalQtyBilled.xBindingProperty != null))
                txtTotalQtyBilled.BindControl(PurchaseOrderBS, txtTotalQtyBilled.xBindingProperty);

            if ((txtTotalAmountOrder.xBindingProperty != "") && (txtTotalAmountOrder.xBindingProperty != null))
                txtTotalAmountOrder.BindControl(PurchaseOrderBS, txtTotalAmountOrder.xBindingProperty);
            if ((txtTotalAmountReceived.xBindingProperty != "") && (txtTotalAmountReceived.xBindingProperty != null))
                txtTotalAmountReceived.BindControl(PurchaseOrderBS, txtTotalAmountReceived.xBindingProperty);
            if ((txtTotalAmountBilled.xBindingProperty != "") && (txtTotalAmountBilled.xBindingProperty != null))
                txtTotalAmountBilled.BindControl(PurchaseOrderBS, txtTotalAmountBilled.xBindingProperty);
        }
        void DGVPODetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnType = "";
                DataRowView DRV = (DataRowView)DGVPODetail.objBindingSource.Current;
                int index = e.ColumnIndex;
                if (index == -1)
                    columnType = "RowHeader";
                else
                {
                    try
                    {
                        columnType = DGVPODetail.Columns[index].Tag.ToString();
                    }
                    catch { columnType = DGVPODetail.Columns[index].Name.ToString(); }
                }
                switch (columnType)
                {
                    case "DelColumn":                        
                        if (Convert.ToInt32(DRV["PrevBilled"]) <= 0)
                        {
                            if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DGVPODetail.objBindingSource.Remove(DGVPODetail.objBindingSource.Current);
                                DGVPODetail.objBindingSource.EndEdit();

                                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                                PurchaseOrderDetailsCalculatColumns();
                                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
                            }
                        }
                        else
                            xMessageBox.Show("Bill is generated against this item so can not be deleted..","Information..");

                        break;
                    case "Cost":
                        ShowCatalogPrice();
                        break;
                    case "RowHeader":
                        SelectedItemID = Convert.ToInt32(DRV["ItemID"]);
                        break;
                    default:                        
                        break;
                }
            }
            catch { }
        }
        void ShowCatalogPrice()
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVPODetail.DataSource).Current;
            Int32 ItemID = Convert.ToInt32(curRow["ItemID"]);
            if (ItemID > 0)
            {
                ctrItemPriceChange objctrItemPriceChange = new ctrItemPriceChange(ItemID);
                //----------------------------------------------------------------------//
                frmCtr frmctrItemPriceChange = new frmCtr("Catalog Price Change ...");                
                frmctrItemPriceChange.Height = objctrItemPriceChange.Height + 40;
                frmctrItemPriceChange.Width = objctrItemPriceChange.Width + 20;
                frmctrItemPriceChange.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmctrItemPriceChange.frmPnl.Controls.Add(objctrItemPriceChange);
                frmctrItemPriceChange.BringToFront();
                frmctrItemPriceChange.ShowDialog();

                DataTable dt = dbClass.obj.getItemForPO(ItemID);
                if (dt.Rows.Count > 0)
                {
                    curRow.BeginEdit();
                    curRow["Cost"] = dt.Rows[0]["CatalogCost"];
                    curRow["FET"] = dt.Rows[0]["FET"];
                    curRow.EndEdit();
                }
                DGVPODetail_CellEndEdit(curRow);
            }

        }
        void DGVPurchaseOrderList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
            SelectedPOID = Convert.ToInt32(curRow["ID"]);
            string status = curRow["Status"].ToString();
            if (SelectedPOID > 0)
                LoadSelectedPOIDPurchaseOrderDetails();
            if (status == "Completed")
            {
                DGVPODetail.Columns["QtyOrdrd"].ReadOnly = true;
                DGVPODetail.Columns["QtyRcvd"].ReadOnly = true;
                DGVPODetail.Columns["QtyBilled"].ReadOnly = true;

                btnNewLine.Enabled = false;
                btnPODetailSave.Enabled = false;
                btnPODetailCancel.Enabled = false;
                btnProcessAllChanges.Enabled = false;
                btnReceivedAllOrdered.Enabled = false;
                btnClearBackOrders.Enabled = false;
                btnBillAllReceived.Enabled = false;
            }
            else 
            {
                DGVPODetail.Columns["QtyOrdrd"].ReadOnly = false;
                DGVPODetail.Columns["QtyRcvd"].ReadOnly = false;
                DGVPODetail.Columns["QtyBilled"].ReadOnly = false;
                btnNewLine.Enabled = true;
                btnPODetailSave.Enabled = true;
                btnPODetailCancel.Enabled = true;
                btnProcessAllChanges.Enabled = true;
                btnReceivedAllOrdered.Enabled = true;
                btnClearBackOrders.Enabled = true;
                btnBillAllReceived.Enabled = true;
            }
        }
        void DGVPurchaseOrderList_TDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
            curRow.BeginEdit();
            curRow["ModifyUserID"] = StaticInfo.userid;
            curRow["ModifyDate"] = DateTime.Now;
            curRow.EndEdit();

            dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
        }
        void DGVPODetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVPODetail.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVPODetail.DataSource).Current;
            if (DGVColumnName == "QtyBilled")
            {
                Int32 QtyRcvd = 0, PrevRcvd = 0, QtyBilled = 0, PrevBilled = 0;

                if (curRow["QtyRcvd"] != DBNull.Value)
                    QtyRcvd = Convert.ToInt32(curRow["QtyRcvd"]);
                if (curRow["PrevRcvd"] != DBNull.Value)
                    PrevRcvd = Convert.ToInt32(curRow["PrevRcvd"]);
                if (curRow["QtyBilled"] != DBNull.Value)
                    QtyBilled = Convert.ToInt32(curRow["QtyBilled"]);
                if (curRow["PrevBilled"] != DBNull.Value)
                    PrevBilled = Convert.ToInt32(curRow["PrevBilled"]);

                if ((QtyRcvd + PrevRcvd) < (QtyBilled + PrevBilled))                
                {
                    xMessageBox.Show("Bill quantity is bigger then received quantity.....", "Information");
                    curRow.BeginEdit();
                    curRow["QtyBilled"] = 0;
                    curRow.EndEdit();
                    return;
                }
            }
            else if (DGVColumnName == "QtyRcvd")
            {
                Int32 QtyRcvd = 0, PrevRcvd = 0, QtyOrdrd = 0, PrevOrdrd = 0;

                if (curRow["QtyRcvd"] != DBNull.Value)
                    QtyRcvd = Convert.ToInt32(curRow["QtyRcvd"]);
                if (curRow["PrevRcvd"] != DBNull.Value)
                    PrevRcvd = Convert.ToInt32(curRow["PrevRcvd"]);
                if (curRow["QtyOrdrd"] != DBNull.Value)
                    QtyOrdrd = Convert.ToInt32(curRow["QtyOrdrd"]);
                if (curRow["PrevOrdrd"] != DBNull.Value)
                    PrevOrdrd = Convert.ToInt32(curRow["PrevOrdrd"]);

                if ((QtyOrdrd + PrevOrdrd) < (QtyRcvd + PrevRcvd))
                {
                    xMessageBox.Show("Receive quantity is bigger then Order quantity.....", "Information");
                    curRow.BeginEdit();
                    curRow["QtyRcvd"] = 0;
                    curRow.EndEdit();
                    return;
                }
            }
            DGVPODetail_CellEndEdit(curRow);
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

                curRow["Amount"] = (QtyRcvd + PrevRcvd) * (Cost + FET);
                //curRow["Amount"] = (QtyOrdrd + PrevOrdrd + QtyRcvd + PrevRcvd) * (Cost + FET);
                
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
            //----------------------------------------------------------------------//            
            dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);            
            PurchaseOrderDetailsCalculatColumns();            
            dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
            //----------------------------------------------------------------------//
        }
        void PurchaseOrderDetailsCalculatColumns()
        {
            //-------------------------------------------------------------            
            Int32 TotalQtyOrder = 0, TotalQtyReceived = 0, TotalQtyBilled = 0, BackOrderedQty = 0;
            decimal TotalAmountOrder = 0, TotalAmountReceived = 0, TotalAmountBilled = 0;

            Int32 gridQtyOrdrd = 0, gridPrevOrdrd = 0, gridQtyRcvd = 0, gridPrevRcvd = 0, gridQtyBilled = 0,gridPrevBilled = 0;
            decimal gridCost = 0, gridFET = 0, gridAmount = 0, gridCostFET = 0;

            foreach (DataGridViewRow n in DGVPODetail.Rows)
            {
                if (n.Cells["QtyOrdrd"].Value != null) { gridQtyOrdrd = Convert.ToInt32(n.Cells["QtyOrdrd"].Value); }
                if (n.Cells["PrevOrdrd"].Value != null) { gridPrevOrdrd = Convert.ToInt32(n.Cells["PrevOrdrd"].Value); }
                TotalQtyOrder += gridQtyOrdrd + gridPrevOrdrd;

                if (n.Cells["QtyRcvd"].Value != null) { gridQtyRcvd = Convert.ToInt32(n.Cells["QtyRcvd"].Value); }
                if (n.Cells["PrevRcvd"].Value != null) { gridPrevRcvd = Convert.ToInt32(n.Cells["PrevRcvd"].Value); }
                TotalQtyReceived += gridQtyRcvd + gridPrevRcvd;

                if (n.Cells["QtyBilled"].Value != null) { gridQtyBilled = Convert.ToInt32(n.Cells["QtyBilled"].Value); }
                if (n.Cells["PrevBilled"].Value != null) { gridPrevBilled = Convert.ToInt32(n.Cells["PrevBilled"].Value); }
                TotalQtyBilled += gridQtyBilled + gridPrevBilled;

                if (n.Cells["Cost"].Value != null) { gridCost = Convert.ToDecimal(n.Cells["Cost"].Value); }
                if (n.Cells["FET"].Value != null) { gridFET = Convert.ToDecimal(n.Cells["FET"].Value); }
                gridCostFET = gridCost + gridFET;

                TotalAmountOrder += ((gridQtyOrdrd + gridPrevOrdrd) * gridCostFET);
                TotalAmountReceived += ((gridQtyRcvd + gridPrevRcvd) * gridCostFET);
                TotalAmountBilled += ((gridQtyBilled + gridPrevBilled) * gridCostFET);

                if (n.Cells["Amount"].Value != null) { gridAmount += Convert.ToDecimal(n.Cells["Amount"].Value); }
                
                if (((gridQtyOrdrd + gridPrevOrdrd) - (gridQtyRcvd + gridPrevRcvd)) != 0)
                    BackOrderedQty += ((gridQtyOrdrd + gridPrevOrdrd) - (gridQtyRcvd + gridPrevRcvd));

            }

            try
            {
                DataRowView curRow = (DataRowView)((BindingSource)DGVPurchaseOrderList.TDataGridView.DataSource).Current;
                if (curRow != null)
                {
                    curRow.BeginEdit();

                    curRow["TotalQtyOrder"] = TotalQtyOrder;
                    curRow["TotalAmountOrder"] = TotalAmountOrder;

                    curRow["TotalQtyReceived"] = TotalQtyReceived;
                    curRow["TotalAmountReceived"] = TotalAmountReceived;

                    curRow["TotalQtyBilled"] = TotalQtyBilled;
                    curRow["TotalAmountBilled"] = TotalAmountBilled;

                    //curRow["TotalQtyOrder"] = gridQtyOrdrd + gridPrevOrdrd;
                    //curRow["TotalQtyReceived"] = gridQtyRcvd + gridPrevRcvd;
                    //curRow["TotalQtyBilled"] = gridPrevBilled;

                    //curRow["TotalAmountOrder"] = gridAmount;

                    //curRow["TotalAmountReceived"] = gridReceivedQty;
                    //curRow["TotalAmountBilled"] = gridPendingQty;

                    //curRow["DiscBillAmount"] = Convert.ToDecimal(curRow["BillAmount"]) - Convert.ToDecimal(curRow["Discount"]);
                    //curRow["PendingAmount"] = Convert.ToDecimal(curRow["DiscBillAmount"]) - Convert.ToDecimal(curRow["PaidAmount"]);

                    curRow.EndEdit();
                }
            }
            catch { }

            if (BackOrderedQty != 0)
            {
                lblBackOrders.Text = "BackOrdered: " + Convert.ToString(BackOrderedQty);
                lblBackOrders.Visible = true;
            }
            else
                lblBackOrders.Visible = false;

            //{
            //    //int backorder = gridPrevRcvd - gridPrevOrdrd;
            //    //if (backorder > 0)
            //    //{
            //    //    lblBackOrders.Text = "BackOrdered: " + backorder;
            //    //    lblBackOrders.Visible = true;
            //    //}
            //    //else
            //    lblBackOrders.Visible = false;
            //}
            //try
            //{
            //    txtBoxTotalPacks.Text = Convert.ToString(TotalPacks);
            //    txtBoxTotalUnits.Text = Convert.ToString(TotalUnits);
            //    txtBoxTotalUnitQty.Text = Convert.ToString(TotalUnitQty);
            //    txtBoxTotalAmount.Text = Convert.ToString(TotalAmount);
            //    txtBoxTotalAmount1.Text = Convert.ToString(TotalAmount);
            //}
            //catch { }

            //if (txtBoxDiscountAmount.Text.Trim() != string.Empty)
            //    TotalDiscount = StaticInfo.StrToDec(txtBoxDiscountAmount.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture));
            //txtBoxNetAmount.Text = Convert.ToString(TotalAmount - TotalDiscount);

            //if (txtBoxPayment.Text.Trim() != string.Empty)
            //{
            //    Payment = StaticInfo.StrToDec(txtBoxPayment.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture));
            //    NetAmount = StaticInfo.StrToDec(txtBoxNetAmount.Text.Trim().ToString(System.Globalization.CultureInfo.InvariantCulture));
            //    txtBoxBalance.Text = Convert.ToString(NetAmount - Payment);
            //}

            //this.txtBoxPODocNo.Text = ""; }
        }       
        void btnPOSave_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
            }
            else
            {
                xMessageBox.Show("Please select vender for saving purchase order ...");
            }
        }        
        void btnNewLine_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                ctrPurchaseOrderAddItem objPurchaseOrderDetail = new ctrPurchaseOrderAddItem();
                objPurchaseOrderDetail.ItemForPODetails += objPurchaseOrderDetail_ItemForPODetails;
                frmCtr frmCtrPurchaseOrderAddItem = new frmCtr("Select Item for Purchase Order ...");                
                frmCtrPurchaseOrderAddItem.Height = objPurchaseOrderDetail.Height + 40;
                frmCtrPurchaseOrderAddItem.Width = objPurchaseOrderDetail.Width + 20;
                frmCtrPurchaseOrderAddItem.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtrPurchaseOrderAddItem.frmPnl.Controls.Add(objPurchaseOrderDetail);
                frmCtrPurchaseOrderAddItem.BringToFront();
                frmCtrPurchaseOrderAddItem.ShowDialog();
            }
            else
            {
                xMessageBox.Show("Select Purchase Order for New Item ...");
            }
        }
        void btnPODetailSave_Click(object sender, EventArgs e)
        {
            if (SelectedPOID > 0)
            {
                //List<int> IsDonelst = new List<int>();
                //foreach (DataRowView BSRow in PurchaseOrderDetailsBS)
                //{
                //    Int32 QtyA = Convert.ToInt32(BSRow["QtyOrdrd"]);
                //    Int32 QtyB = Convert.ToInt32(BSRow["PrevOrdrd"]);
                //    Int32 QtyC = Convert.ToInt32(BSRow["QtyRcvd"]);
                //    Int32 QtyD = Convert.ToInt32(BSRow["PrevRcvd"]);
                //    Int32 QtyE = Convert.ToInt32(BSRow["QtyBilled"]);
                //    Int32 QtyF = Convert.ToInt32(BSRow["PrevBilled"]);

                //    //BSRow.BeginEdit();
                //    //if ((QtyA + QtyB) > 0)
                //    //{                        
                //    if ((QtyA + QtyB) > (QtyC + QtyD) && (QtyC + QtyD) > (QtyE + QtyF))
                //        IsDonelst.Add(1);
                //    else
                //        IsDonelst.Add(0);
                //    //}
                //    //BSRow.EndEdit();
                //}

                //if (IsDonelst.Contains(0))
                //    IsDone = 0;
                //else
                //    IsDone = 1;
                //dbClass.obj.UpdatePurchaseOrderDone(SelectedPOID, IsDone);
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                this.Cursor = Cursors.Default; xMessageBox.Show("Data saved successfully ...!");
                //LoadSelectedVendorPurchaseOrders();
            }
            else
            {
                xMessageBox.Show("Please select purchase order...");
            }
            
        }
        void objPurchaseOrderDetail_ItemForPODetails(object sender, DataRow dataRow)
        {
            if (dataRow != null)
            {
                //--DataRow------------------------
                DataRow dr = objDataSet.Tables["PurchaseOrderDetails"].NewRow();
                dr["MID"] = SelectedPOID;
                dr["ItemID"] = dataRow["ID"];
                dr["Catalog"] = dataRow["Catalog"];
                dr["Description"] = dataRow["Name"];

                dr["QtyOrdrd"] = dataRow["QtyOrdrd"];
                dr["PrevOrdrd"] = dataRow["PrevOrdrd"];
                dr["QtyRcvd"] = dataRow["QtyRcvd"];
                dr["PrevRcvd"] = dataRow["PrevRcvd"];
                dr["QtyBilled"] = dataRow["QtyBilled"];
                dr["PrevBilled"] = dataRow["PrevBilled"];
                dr["Cost"] = dataRow["CatalogCost"];
                dr["FET"] = dataRow["FET"];
                dr["Amount"] = (Convert.ToDecimal(dataRow["CatalogCost"]) + Convert.ToDecimal(dataRow["FET"])) * Convert.ToInt32(dataRow["QtyOrdrd"]);

                dr["Active"] = true;
                dr["AddDate"] = DateTime.Now;
                dr["AddUserID"] = StaticInfo.userid;
                dr["IsLocked"] = true;
                dr["CompanyID"] = StaticInfo.CompanyID;
                dr["WarehouseID"] = (StaticInfo.WarehouseID == 0 || string.IsNullOrWhiteSpace(StaticInfo.WarehouseID.ToString())) ? 1 : StaticInfo.WarehouseID;
                dr["StoreID"] = (StaticInfo.StoreID == 0 || string.IsNullOrWhiteSpace(StaticInfo.StoreID.ToString())) ? 1 : StaticInfo.StoreID;
                //-----------------------------------------------------------------
                objDataSet.Tables["PurchaseOrderDetails"].Rows.Add(dr);
                //-----------------------------------------------------------------                
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrderDetails"]);
                PurchaseOrderDetailsCalculatColumns();
                dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
                //-----------------------------------------------------------------
                LoadSelectedPOIDPurchaseOrderDetails();
            }
        }
        void DGVVendorList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorList.TDataGridView.DataSource).Current;
            SelectedVendorID = Convert.ToInt32(curRow["ID"]);
            if (SelectedVendorID > 0)
                LoadSelectedVendorPurchaseOrders();
        }
        void btnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            if (SelectedVendorID > 0)
            {
                int NewPO = dbClass.obj.getNextPurchaseOrderAutoNo();
                if (NewPO > 0)
                {
                    //--DataRow------------------------
                    DataRow dr = objDataSet.Tables["PurchaseOrder"].NewRow();
                    dr["VendorID"] = SelectedVendorID;
                    dr["POID"] = NewPO;
                    dr["DiscountPer"] = 0;
                    dr["PODate"] = dtpPO.Text;
                    
                    dr["TotalQtyOrder"] = 0;
                    dr["TotalAmountOrder"] = 0;

                    dr["TotalQtyReceived"] = 0;
                    dr["TotalAmountReceived"] = 0;

                    dr["TotalQtyBilled"] = 0;
                    dr["TotalAmountBilled"] = 0;

                    
                    dr["Active"] = true;
                    dr["AddDate"] = DateTime.Now;
                    dr["AddUserID"] = StaticInfo.userid;
                    
                    dr["IsLocked"] = false;
                    dr["CoFinEndYear"] = StaticInfo.CoFinEndYear;
                    dr["CompanyID"] = StaticInfo.CompanyID;
                    dr["WarehouseID"] = StaticInfo.WarehouseID;
                    dr["StoreID"] = StaticInfo.StoreID;
                    //---------------------------------
                    objDataSet.Tables["PurchaseOrder"].Rows.Add(dr);
                    //---------------------------------
                    dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
                }
                LoadSelectedVendorPurchaseOrders();
            }
            else
                xMessageBox.Show("Select Vendor for New PurchaseOrder ...");
        }
        void ctrPurchaseOrderList_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            DataTable dt = dbClass.obj.FillVendorList();
            VendorBS.DataSource = dt;
            DGVVendorList.TDataGridView.DataSource = VendorBS;

            DGVVendorList.TDataGridView.AutoGenerateColumns = true;
            //DGVVendorList.TDataGridView.RowHeadersVisible = true;
            //DGVVendorList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGVVendorList.TDataGridView.Columns["ID"].Visible = false;

            DGVVendorList.TDataGridView.Columns["Name"].Width = 350;
            //DGVVendorList.TDataGridView.Columns["City"].Width = 120;
            DGVVendorList.TDataGridView.Columns["Phone"].Width = 120;
            DGVVendorList.TDataGridView.Columns["ContactPerson"].Width = 240;
            //DGVVendorList.TDataGridView.Columns["Cont Person Phone"].Width = 120;
            DGVVendorList.TDataGridView.Columns["Balance"].Width = 100;

            if (SelectedVendorID > 0)
            {
                LoadSelectedVendorPurchaseOrders();
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
                DGVVendorList.TDataGridView.Rows[rowIndex].Selected = true;
            }
        }
        void LoadSelectedVendorPurchaseOrders()
        {
            dbClass.obj.FillPurchaseOrdersByVendorID(objDataSet.Tables["PurchaseOrder"], SelectedVendorID);
            PurchaseOrderBS.DataSource = objDataSet.Tables["PurchaseOrder"];
            DGVPurchaseOrderList.TDataGridView.AutoGenerateColumns = true;
            DGVPurchaseOrderList.TDataGridView.Enabled = true;
            DGVPurchaseOrderList.TDataGridView.ReadOnly = false;

            DGVPurchaseOrderList.TDataGridView.DataSource = PurchaseOrderBS;

            foreach (DataGridViewColumn gridColumn in DGVPurchaseOrderList.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }

                        
            DGVPurchaseOrderList.TDataGridView.Columns["POID"].Width = 40;
            DGVPurchaseOrderList.TDataGridView.Columns["POID"].Visible = true;

            DGVPurchaseOrderList.TDataGridView.Columns["PODate"].Width = 80;
            DGVPurchaseOrderList.TDataGridView.Columns["PODate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVPurchaseOrderList.TDataGridView.Columns["PODate"].Visible = true;

            DGVPurchaseOrderList.TDataGridView.Columns["Reference"].Width = 270;
            DGVPurchaseOrderList.TDataGridView.Columns["Reference"].Visible = true;
            DGVPurchaseOrderList.TDataGridView.Columns["Reference"].ReadOnly = false;

            DGVPurchaseOrderList.TDataGridView.Columns["Notes"].Width = 270;
            DGVPurchaseOrderList.TDataGridView.Columns["Notes"].Visible = true;
            DGVPurchaseOrderList.TDataGridView.Columns["Notes"].ReadOnly = false;

            DGVPurchaseOrderList.TDataGridView.Columns["Rep"].Width = 50;
            DGVPurchaseOrderList.TDataGridView.Columns["Rep"].Visible = true;

            DGVPurchaseOrderList.TDataGridView.Columns["DiscountPer"].HeaderText = "Disc %";
            DGVPurchaseOrderList.TDataGridView.Columns["DiscountPer"].Width = 60;
            DGVPurchaseOrderList.TDataGridView.Columns["DiscountPer"].Visible = true;
            DGVPurchaseOrderList.TDataGridView.Columns["DiscountPer"].ReadOnly = false;

            DGVPurchaseOrderList.TDataGridView.Columns["LastReceivedDate"].HeaderText = "LastReceived";
            DGVPurchaseOrderList.TDataGridView.Columns["LastReceivedDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            DGVPurchaseOrderList.TDataGridView.Columns["LastReceivedDate"].Width = 90;
            DGVPurchaseOrderList.TDataGridView.Columns["LastReceivedDate"].Visible = true;

            DGVPurchaseOrderList.TDataGridView.Columns["Status"].Width = 60;
            DGVPurchaseOrderList.TDataGridView.Columns["Status"].Visible = true;

            DGVPurchaseOrderList.TDataGridView.Columns["Store"].Width = 150;
            DGVPurchaseOrderList.TDataGridView.Columns["Store"].Visible = true;

            PurchaseOrderDetailsBS.DataSource = null;

            PurchaseOrderDetailsCalculatColumns();
        }
        void LoadSelectedPOIDPurchaseOrderDetails()
        {
            dbClass.obj.FillPurchaseOrderDetailsByPOID(objDataSet.Tables["PurchaseOrderDetails"], SelectedPOID);
            PurchaseOrderDetailsBS.DataSource = objDataSet.Tables["PurchaseOrderDetails"];

            PurchaseOrderDetailsCalculatColumns();
        }
        void txtCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedPOID > 0)
                {
                    if (!string.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    {
                        int ItemID = dbClass.obj.getItemIDByCatalog(txtCatalog.Text.Trim());
                        if (ItemID > 0)
                        {
                            DataTable dt = dbClass.obj.getItemForPO(ItemID);
                            if (dt != null)
                            {
                                DataRow dataRow = dt.Rows[0];
                                if (dataRow != null)
                                {
                                    objPurchaseOrderDetail_ItemForPODetails(sender, dataRow);
                                    txtCatalog.Text = "";
                                }
                            }
                        }
                        else
                        {
                            xMessageBox.Show("Item not Matched ...");
                            txtCatalog.Focus();
                        }
                    }
                }
                else
                    xMessageBox.Show("Selected Supplier Purchase Order ...");
            }
        }
        void DGVVendorList_SearchtxtBox_KeyUp(object sender, EventArgs e)
        {
            this.SelectedVendorID = 0;
            LoadSelectedVendorPurchaseOrders();
        }
        void DGVPurchaseOrderList_SearchtxtBox_KeyUp(object sender, EventArgs e)
        {
            this.SelectedPOID = 0;
            LoadSelectedPOIDPurchaseOrderDetails();
        }

    }
}
