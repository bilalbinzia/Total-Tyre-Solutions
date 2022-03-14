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
    public partial class ctrWarrantyClaimAndCoresList : UserControl
    {
        
        MainDataSet objDataSet;
        BindingSource ClaimAndCoresBS;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedClaimAndCoresID = 0, SelectedVendorID = 0;
        string VendorName = string.Empty;

        public ctrWarrantyClaimAndCoresList()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrWarrantyClaimAndCoresList(int selectedVendorID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.SelectedVendorID = selectedVendorID;            
        }
        void InitializeComponent1()
        {
            objDataSet = new MainDataSet();
            ClaimAndCoresBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrWarrantyClaimAndCoresList_Load;            
            btnNew.Click += btnNew_Click;
            btnShip.Click += btnShip_Click;
            btnCredit.Click += btnCredit_Click;
            btnVoid.Click += btnVoid_Click;

            DGVClaimAndCoresList.TDataGridView.CellClick += TDataGridView_CellClick;

            BindingControls();
        }
        void btnShip_Click(object sender, EventArgs e)
        {
            if (xMessageBox.Show("Ship the selected Claims....?", "Ship Claims ...!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //------------------------------------------------------//                   
                foreach (DataGridViewRow n in DGVClaimAndCoresList.TDataGridView.Rows)
                {
                    if (n.Cells["Active"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["Active"].Value) == true)
                        {
                            int ID = 0;
                            if (n.Cells["ID"].Value != null) { ID = Convert.ToInt32(n.Cells["ID"].Value); }
                            if (ID > 0)
                            {
                                if (Convert.ToString(n.Cells["Status"].Value) == "New")
                                    dbClass.obj.UpdateClaimsIsShip(ID);
                            }
                        }
                    }
                }
                //-----------------------------------------------------------------------//
                //Generate Ship Report--------------------
                //-----------------------------------------------------------------------//
                dt = dbClass.obj.FillWarrantyClaimToVendorList(this.SelectedVendorID);
                ClaimAndCoresBS.DataSource = dt;
                //-----------------------------------------------------------------------//
            }
        }
        void btnVoid_Click(object sender, EventArgs e)
        {
            if (xMessageBox.Show("Void the selected Claims....?", "Void Claims ...!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //------------------------------------------------------//                   
                foreach (DataGridViewRow n in DGVClaimAndCoresList.TDataGridView.Rows)
                {
                    if (n.Cells["Active"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["Active"].Value) == true)
                        {
                            int ID = 0;
                            if (n.Cells["ID"].Value != null) { ID = Convert.ToInt32(n.Cells["ID"].Value); }                            
                            if (ID > 0)
                            {
                                if (Convert.ToString(n.Cells["Status"].Value) == "New")                                
                                    dbClass.obj.UpdateClaimsIsVoid(ID);
                            }
                        }
                    }
                }
                //-----------------------------------------------------------------------//
                dt = dbClass.obj.FillWarrantyClaimToVendorList(this.SelectedVendorID);
                ClaimAndCoresBS.DataSource = dt;
                //-----------------------------------------------------------------------//
            }
        }
        void btnCredit_Click(object sender, EventArgs e)
        {
            string RefNo = string.Empty;
            foreach (DataGridViewRow n in DGVClaimAndCoresList.TDataGridView.Rows)
            {
                if (n.Cells["Active"].Value != System.DBNull.Value)
                {
                    if (Convert.ToBoolean(n.Cells["Active"].Value) == true)
                    {
                        if (Convert.ToString(n.Cells["Status"].Value) == "Void")
                        {
                            xMessageBox.Show("Void Claim is not be credited ...");
                            return;
                        }
                        if (n.Cells["Reference"].Value != null) { RefNo = Convert.ToString(n.Cells["Reference"].Value); }
                    }
                }
            }
            ctrClaimCredit objClaim = new ctrClaimCredit(this.SelectedVendorID, this.VendorName, RefNo);
            objClaim.claimCreditDelegate += objClaim_claimCreditDelegate;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Claim Credit ...");            
            frmCtr.Height = objClaim.Height + 20; frmCtr.Width = objClaim.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objClaim);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
            //----------------------------------------------------------------------//
            


        }
        void objClaim_claimCreditDelegate(object sender, bool IsCredited, string RefNo, DateTime? CreditDate)
        {
            if (IsCredited)
            {
                foreach (DataGridViewRow n in DGVClaimAndCoresList.TDataGridView.Rows)
                {
                    if (n.Cells["Active"].Value != System.DBNull.Value)
                    {
                        if (Convert.ToBoolean(n.Cells["Active"].Value) == true)
                        {                            
                            int ID = 0;
                            if (n.Cells["ID"].Value != null) { ID = Convert.ToInt32(n.Cells["ID"].Value); }
                            if (ID > 0)
                            {
                                if (Convert.ToString(n.Cells["Status"].Value) == "New")
                                    dbClass.obj.UpdateClaimsIsCredit(ID, RefNo, CreditDate);
                            }
                        }
                    }
                }
                xMessageBox.Show("Credit has been created ...");
                //-----------------------------------------------------------------------//
                dt = dbClass.obj.FillWarrantyClaimToVendorList(this.SelectedVendorID);
                ClaimAndCoresBS.DataSource = dt;
                //-----------------------------------------------------------------------//
            }        
        }        
        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVClaimAndCoresList.TDataGridView.DataSource).Current;
            SelectedClaimAndCoresID = Convert.ToInt32(curRow["ID"]);
            if (e.ColumnIndex >= 0)
            {
                string DGVColumnName = DGVClaimAndCoresList.TDataGridView.Columns[e.ColumnIndex].Name;
                if (DGVColumnName == "Active")
                {
                    if (DGVClaimAndCoresList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                    {
                        DGVClaimAndCoresList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        curRow["Active"] = false;
                    }
                    else
                    {
                        DGVClaimAndCoresList.TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        curRow["Active"] = true;                        
                    }
                    DGVClaimAndCoresList.TDataGridView.EndEdit();
                    ClaimAndCoresBS.EndEdit();
                }
            }
        }
        void btnNew_Click(object sender, EventArgs e)
        {
            ctrClaim objClaim = new ctrClaim(this.SelectedVendorID, this.VendorName);
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("New Claim ...");            
            frmCtr.Height = objClaim.Height + 20; frmCtr.Width = objClaim.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objClaim);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
            //-----------------------------------------------------------------------//
            dt = dbClass.obj.FillWarrantyClaimToVendorList(this.SelectedVendorID);
            ClaimAndCoresBS.DataSource = dt;
            //-----------------------------------------------------------------------//
        }              
        void BindingControls()
        {
            ClaimAndCoresBS.DataSource = objDataSet.Tables["WarrantyClaimToVendor"];
        }
        DataTable dt;
        void ctrWarrantyClaimAndCoresList_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            dt = dbClass.obj.FillWarrantyClaimToVendorList(this.SelectedVendorID);
            ClaimAndCoresBS.DataSource = dt;
            DGVClaimAndCoresList.TDataGridView.DataSource = ClaimAndCoresBS;

            DGVClaimAndCoresList.TDataGridView.AutoGenerateColumns = true;

            DGVClaimAndCoresList.TDataGridView.Columns["ID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["VendorID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["POID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["ItemID"].Visible = false;

            DGVClaimAndCoresList.TDataGridView.Columns["Active"].Width = 30;
            DGVClaimAndCoresList.TDataGridView.Columns["Part Description"].Width = 250;
            DGVClaimAndCoresList.TDataGridView.Columns["Cost"].Width = 50;
            DGVClaimAndCoresList.TDataGridView.Columns["ClaimDate"].Width = 80;
            DGVClaimAndCoresList.TDataGridView.Columns["Status"].Width = 50;

            //DGVClaimAndCoresList.TDataGridView.Columns["Active"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["AddDate"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["AddUserID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["IsLocked"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["CompanyID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["WarehouseID"].Visible = false;
            DGVClaimAndCoresList.TDataGridView.Columns["StoreID"].Visible = false;


            this.VendorName = dbClass.obj.getVendorName(this.SelectedVendorID);
            
        }

    }
}
