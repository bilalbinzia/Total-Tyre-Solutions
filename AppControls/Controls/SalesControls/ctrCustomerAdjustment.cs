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
    public partial class ctrCustomerAdjustment : UserControl
    {
        MainDataSet objDataSet;

        BindingSource CustomerAdjustmentBS;
       
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedCustomerID = 0;
        int SelectedPOID = 0;
        int SelectedItemID = 0;
        bool IsVendorBillCreated = false;
        public ctrCustomerAdjustment()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();

            CustomerAdjustmentBS = new BindingSource();
            
            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrCustomerAdjustment_Load;
            //btnNewPurchaseOrder.Click += btnNewPurchaseOrder_Click;
            //btnPOVoid.Click += btnPOVoid_Click;

            DGVCustomerList.TDataGridView.CellClick += DGVCustomerList_TDataGridView_CellClick;
           // DGVAdjustmentList.TDataGridView.CellEndEdit += DGVPurchaseOrderList_TDataGridView_CellEndEdit;
            DGVAdjustmentList.TDataGridView.CellClick += DGVAdjustmentList_TDataGridView_CellClick;
            btnNew.Click += NewAdjustment_click;
            btnSave.Click += SaveAdjustment_click;
            ctrAmount.LostFocus += Amount_LostFocus; 

            BindingControls();
        }

        void Amount_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ctrAmount.Text))
                {
                    var a = ctrAmount.Text.Replace("$", "").Replace("(", "").Replace(")", "");

                    ctrAmount.Text = string.Format("{0:C}", Convert.ToInt32(ctrAmount.Text.Replace("$", "").Replace("(","").Replace(")","")));
                }
            }
            catch {
                xMessageBox.Show("Please Enter correct amount .....");
            }
        }

        void BindingControls()
        {
            //PurchaseOrderBS.DataSource = objDataSet.Tables["PurchaseOrder"];

            //if ((txtTotalQtyOrder.xBindingProperty != "") && (txtTotalQtyOrder.xBindingProperty != null))
            //    txtTotalQtyOrder.BindControl(PurchaseOrderBS, txtTotalQtyOrder.xBindingProperty);
            //if ((txtTotalQtyReceived.xBindingProperty != "") && (txtTotalQtyReceived.xBindingProperty != null))
            //    txtTotalQtyReceived.BindControl(PurchaseOrderBS, txtTotalQtyReceived.xBindingProperty);
            //if ((txtTotalQtyBilled.xBindingProperty != "") && (txtTotalQtyBilled.xBindingProperty != null))
            //    txtTotalQtyBilled.BindControl(PurchaseOrderBS, txtTotalQtyBilled.xBindingProperty);

            //if ((txtTotalAmountOrder.xBindingProperty != "") && (txtTotalAmountOrder.xBindingProperty != null))
            //    txtTotalAmountOrder.BindControl(PurchaseOrderBS, txtTotalAmountOrder.xBindingProperty);
            //if ((txtTotalAmountReceived.xBindingProperty != "") && (txtTotalAmountReceived.xBindingProperty != null))
            //    txtTotalAmountReceived.BindControl(PurchaseOrderBS, txtTotalAmountReceived.xBindingProperty);
            //if ((txtTotalAmountBilled.xBindingProperty != "") && (txtTotalAmountBilled.xBindingProperty != null))
            //    txtTotalAmountBilled.BindControl(PurchaseOrderBS, txtTotalAmountBilled.xBindingProperty);
        }

        void NewAdjustment_click(object sender, EventArgs e)
        {
            dtpAdjustment.Enabled = true;
            comboBox1.Enabled = true;
            ctrAmount.Text = "";
            ctrAmount.Enabled = true;
            ctrAmount.ReadOnly = false;
            taDescription.Text = "";
            taDescription.Enabled = true;
            taDescription.ReadOnly = false;
            taDescription.ReadOnly = false;
        }
        void SaveAdjustment_click(object sender, EventArgs e)
        {

        }
        void DGVAdjustmentList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRowView curRow = (DataRowView)((BindingSource)DGVAdjustmentList.TDataGridView.DataSource).Current;
            //SelectedPOID = Convert.ToInt32(curRow["ID"]);
            
            //if (SelectedPOID > 0)
            //    LoadSelectedPOIDPurchaseOrderDetails();
        }
      
        void btnAdjustmentSave_Click(object sender, EventArgs e)
        {
            //if (SelectedPOID > 0)
            //{
            //    dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
            //}
            //else
            //{
            //    xMessageBox.Show("Please select vender for saving purchase order ...");
            //}
        }        
        
        void DGVCustomerList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVCustomerList.TDataGridView.DataSource).Current;
            SelectedCustomerID = Convert.ToInt32(curRow["ID"]);
            if (SelectedCustomerID > 0)
                LoadSelectedCustomerAdjustment();
            
                
        }
        void btnNewAdjustment_Click(object sender, EventArgs e)
        {
            //if (SelectedVendorID > 0)
            //{
            //    int NewPO = dbClass.obj.getNextPurchaseOrderAutoNo();
            //    if (NewPO > 0)
            //    {
            //        //--DataRow------------------------
            //        DataRow dr = objDataSet.Tables["PurchaseOrder"].NewRow();
            //        dr["VendorID"] = SelectedVendorID;
            //        dr["POID"] = NewPO;
            //        dr["DiscountPer"] = 0;
            //        dr["PODate"] = dtpPO.Text;
                    
            //        dr["TotalQtyOrder"] = 0;
            //        dr["TotalAmountOrder"] = 0;

            //        dr["TotalQtyReceived"] = 0;
            //        dr["TotalAmountReceived"] = 0;

            //        dr["TotalQtyBilled"] = 0;
            //        dr["TotalAmountBilled"] = 0;

                    
            //        dr["Active"] = true;
            //        dr["AddDate"] = DateTime.Now;
            //        dr["AddUserID"] = StaticInfo.userid;
                    
            //        dr["IsLocked"] = false;
            //        dr["CoFinEndYear"] = StaticInfo.CoFinEndYear;
            //        dr["CompanyID"] = StaticInfo.CompanyID;
            //        dr["WarehouseID"] = StaticInfo.WarehouseID;
            //        dr["StoreID"] = StaticInfo.StoreID;
            //        //---------------------------------
            //        objDataSet.Tables["PurchaseOrder"].Rows.Add(dr);
            //        //---------------------------------
            //        dbClass.obj.UpdateTable(objDataSet.Tables["PurchaseOrder"]);
            //    }
            //    LoadSelectedVendorPurchaseOrders();
            //}
            //else
            //    xMessageBox.Show("Select Vendor for New PurchaseOrder ...");
        }
        void ctrCustomerAdjustment_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            DataTable datatable = new DataTable();
            DataTable dtAccount = dbClass.obj.FillAccounts(datatable);
            comboBox1.DataSource = dtAccount.DefaultView;
            comboBox1.DisplayMember = "AccName1";
            comboBox1.ValueMember = "ID";
            
            DataTable dt = dbClass.obj.getCustomerList();
            CustomerAdjustmentBS.DataSource = dt;
            DGVCustomerList.TDataGridView.DataSource = CustomerAdjustmentBS;

            DGVCustomerList.TDataGridView.AutoGenerateColumns = true;
            //DGVVendorList.TDataGridView.RowHeadersVisible = true;
            //DGVVendorList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGVCustomerList.TDataGridView.Columns["ID"].Visible = false;

            DGVCustomerList.TDataGridView.Columns["FirstName"].Width = 350;
            //DGVVendorList.TDataGridView.Columns["City"].Width = 120;
            DGVCustomerList.TDataGridView.Columns["Code"].Width = 120;
            DGVCustomerList.TDataGridView.Columns["Phone1"].Width = 120;
            DGVCustomerList.TDataGridView.Columns["ContactPerson"].Width = 240;
            //DGVVendorList.TDataGridView.Columns["Cont Person Phone"].Width = 120;
            //DGVCustomerList.TDataGridView.Columns["Balance"].Width = 100;
        }
        void LoadSelectedCustomerAdjustment()
        {
            if (SelectedCustomerID > 0)
            {
                var a = SelectedCustomerID;
            }
            //dbClass.obj.FillPurchaseOrdersByVendorID(objDataSet.Tables["PurchaseOrder"], SelectedVendorID);
            //PurchaseOrderBS.DataSource = objDataSet.Tables["PurchaseOrder"];
            //DGVAdjustmentList.TDataGridView.AutoGenerateColumns = true;
            //DGVAdjustmentList.TDataGridView.Enabled = true;
            //DGVAdjustmentList.TDataGridView.ReadOnly = false;

            //DGVAdjustmentList.TDataGridView.DataSource = PurchaseOrderBS;

            //foreach (DataGridViewColumn gridColumn in DGVAdjustmentList.TDataGridView.Columns)
            //{ gridColumn.Visible = false; gridColumn.ReadOnly = true; }

            //DGVAdjustmentList.TDataGridView.Columns["POID"].Width = 40;
            //DGVAdjustmentList.TDataGridView.Columns["POID"].Visible = true;

            //DGVAdjustmentList.TDataGridView.Columns["PODate"].Width = 80;
            //DGVAdjustmentList.TDataGridView.Columns["PODate"].Visible = true;

            //DGVAdjustmentList.TDataGridView.Columns["Reference"].Width = 270;
            //DGVAdjustmentList.TDataGridView.Columns["Reference"].Visible = true;
            //DGVAdjustmentList.TDataGridView.Columns["Reference"].ReadOnly = false;

            //DGVAdjustmentList.TDataGridView.Columns["Notes"].Width = 270;
            //DGVAdjustmentList.TDataGridView.Columns["Notes"].Visible = true;
            //DGVAdjustmentList.TDataGridView.Columns["Notes"].ReadOnly = false;

            //DGVAdjustmentList.TDataGridView.Columns["Rep"].Width = 50;
            //DGVAdjustmentList.TDataGridView.Columns["Rep"].Visible = true;

            //DGVAdjustmentList.TDataGridView.Columns["DiscountPer"].HeaderText = "Disc %";
            //DGVAdjustmentList.TDataGridView.Columns["DiscountPer"].Width = 60;
            //DGVAdjustmentList.TDataGridView.Columns["DiscountPer"].Visible = true;
            //DGVAdjustmentList.TDataGridView.Columns["DiscountPer"].ReadOnly = false;

            //DGVAdjustmentList.TDataGridView.Columns["LastReceivedDate"].HeaderText = "LastReceived";
            //DGVAdjustmentList.TDataGridView.Columns["LastReceivedDate"].Width = 90;
            //DGVAdjustmentList.TDataGridView.Columns["LastReceivedDate"].Visible = true;

            //DGVAdjustmentList.TDataGridView.Columns["Status"].Width = 60;
            //DGVAdjustmentList.TDataGridView.Columns["Status"].Visible = true;

            //DGVAdjustmentList.TDataGridView.Columns["Store"].Width = 150;
            //DGVAdjustmentList.TDataGridView.Columns["Store"].Visible = true;

            //PurchaseOrderDetailsBS.DataSource = null;

            // PurchaseOrderDetailsCalculatColumns();
        }
        //void LoadSelectedPOIDPurchaseOrderDetails()
        //{
            //dbClass.obj.FillPurchaseOrderDetailsByPOID(objDataSet.Tables["PurchaseOrderDetails"], SelectedPOID);
            //PurchaseOrderDetailsBS.DataSource = objDataSet.Tables["PurchaseOrderDetails"];

            //  PurchaseOrderDetailsCalculatColumns();
        //}

    }
}
