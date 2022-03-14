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
using System32;
using DBModule;

namespace AppControls
{
    public partial class ctrPackages : BaseControl
    {
        int PackageID = 0;
        BindingSource PackageBS = new BindingSource();
        BindingSource PackageDBS = new BindingSource();
        public ctrPackages()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrPackages(int PackageID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.PackageID = PackageID;
            BindingControls();
        }
        void InitializeComponent1()
        {
            this.Load += ctrPackages_Load;
            this.txtCatalog.KeyDown += txtCatalog_KeyDown;
            this.btnAddCatalog.Click += btnAddCatalog_Click;
            this.DGVPackages.CellEndEdit += DGVPackages_CellEndEdit;
            //btnAddItem.Click += btnAddItem_Click;
            //btnAddFee.Click += btnAddFee_Click;
            //btnAddLabor.Click += btnAddLabor_Click;
            //this.DGVPackages.CellClick += new DataGridViewCellEventHandler(this.DGVPackages_CellClick);
        }
        void BindingControls()
        {
            DataSet ds= dbClass.obj.GetPackageDetailsByID(this.PackageID);
            PackageBS.DataSource = ds.Tables[0];
            PackageDBS.DataSource = ds.Tables[1];
        }
        private void ctrPackages_Load(object sender, EventArgs e)
        {
            LoadPackage();
        }
        void LoadPackage()
        {
            if (this.PackageID > 0)
            {
                try
                {
                    DGVPackages.AutoGenerateColumns = false;
                    DGVPackages.objBindingSource = new BindingSource();

                    DGVPackages.objBindingSource.DataSource = PackageDBS;
                    DGVPackages.DataSource = this.objBindingSource;
                    this.objDataSet = new MainDataSet();
                    //Pkgdt = dbClass.obj.FillPackageByID(this.PackageID);
                    //if (Pkgdt.Rows.Count > 0)
                    //{
                    //    taTextBox2.Text = Pkgdt.Rows[0][1].ToString();
                    //    taTextBox1.Text = Pkgdt.Rows[0][2].ToString();
                    //    taTextBox5.Text = Pkgdt.Rows[0][3].ToString();
                    //}
                    //DGVPackages.TDataGridView.Columns["VendorCustomer"].HeaderText = "Vendor/Customer";
                }
                catch (Exception ex)
                {
                    //xMessageBox.Show(ex.Message);
                }
            }
            else
            {
                //dbClass.obj.fillTablesByIDOrderBy(objDataSet.Tables[this.xTableName], this.PackageID);

                //PackagesBS.DataSource = objDataSet.Tables["WarehousePackagesDetail"];
                //DGVPackages.DataSource = PackagesBS;
            }
        }
        void txtCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                    if (!string.IsNullOrEmpty(txtCatalog.Text.Trim()))
                    {
                        DataTable dt;
                        //---------------------------------------------------------------
                        int ItemID = dbClass.obj.getItemIDByCatalog(txtCatalog.Text.Trim());
                        if (ItemID > 0)
                        {
                            dt = dbClass.obj.getItemsForPackageGrid(ItemID);
                            if (dt != null)
                            {
                                DataRow dataRow = dt.Rows[0];
                                if (dataRow != null)
                                {
                                    AddInGrid_ObjectSelected(sender, dataRow);
                                    txtCatalog.Text = "";
                                }
                            }
                        }
                        else
                        {
                            int FeeID = dbClass.obj.getFeeIDByCatalog(txtCatalog.Text.Trim());
                            if (FeeID > 0)
                            {
                                dt = dbClass.obj.getFeesForGrid(FeeID);
                                if (dt != null)
                                {
                                    DataRow dataRow = dt.Rows[0];
                                    if (dataRow != null)
                                    {
                                        AddInGrid_ObjectSelected(sender, dataRow);
                                        txtCatalog.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                int LaborID = dbClass.obj.getLaborIDByCatalog(txtCatalog.Text.Trim());
                                if (LaborID > 0)
                                {
                                    dt = dbClass.obj.getLaborsForGrid(LaborID);
                                    if (dt != null)
                                    {
                                        DataRow dataRow = dt.Rows[0];
                                        if (dataRow != null)
                                        {
                                            AddInGrid_ObjectSelected(sender, dataRow);
                                            txtCatalog.Text = "";
                                        }
                                    }
                                }
                                else
                                {
                                    
                                        xMessageBox.Show("Catalog not Matched ...");
                                        txtCatalog.Focus();
                                    
                                }
                            }
                        }

                    }
                
                txtCatalog.Focus();
            }
        }

        void DGVPackages_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            libDataGridView DGV = (libDataGridView)sender;
            DataRowView curRow = (DataRowView)DGV.objBindingSource.Current;
            curRow.BeginEdit();
            if (curRow["Qty"] == DBNull.Value) curRow["Qty"] = 0;
            if (curRow["PriceOverride"] == DBNull.Value) curRow["PriceOverride"] = 0;
            try
            {
                Int32 Qty = 0; decimal PriceOverride = 0;

                if (curRow["Qty"] != DBNull.Value)
                    Qty = Convert.ToInt32(curRow["Qty"]);
                if (curRow["PriceOverride"] != DBNull.Value)
                    PriceOverride = Convert.ToDecimal(curRow["PriceOverride"]);                

                if((Qty > 0) && (PriceOverride > 0))
                    curRow["Amount"] = Qty * PriceOverride;
            }
            catch { }
            curRow.EndEdit();
            //---------------------------------------------
            DGVPackagesCalculatColumns();
        }
        void DGVPackagesCalculatColumns()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            //-------------------------------------------------------------                        
            decimal TotalAmount = 0;

            foreach (DataGridViewRow n in DGVPackages.Rows)
            {
                int iQty = 0; decimal dPriceOverride = 0; decimal dTotalAmount = 0;
                if ((n.Cells["Qty"].Value != null) && (Convert.ToInt32(n.Cells["Qty"].Value) > 0))
                    iQty = Convert.ToInt32(n.Cells["Qty"].Value);
                if ((n.Cells["PriceOverride"].Value != null) && (Convert.ToInt32(n.Cells["PriceOverride"].Value) > 0))
                    dPriceOverride = Convert.ToDecimal(n.Cells["PriceOverride"].Value);
                dTotalAmount = iQty * dPriceOverride;

                TotalAmount += dTotalAmount;
            }

            curRow.BeginEdit();
            curRow["PackageWithTax"] = TotalAmount;
            curRow.EndEdit();
            
        }
        void btnAddLabor_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objList = new ctrItemListForGrid("Labor");
            objList.ObjectSelected += AddInGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Labor ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void btnAddFee_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objList = new ctrItemListForGrid("Fee");
            objList.ObjectSelected += AddInGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Fee ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void btnAddItem_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objList = new ctrItemListForGrid("Item");
            objList.ObjectSelected += AddInGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Item ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void btnAddCatalog_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objList = new ctrItemListForGrid();
            objList.ObjectSelected += AddInGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Item ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["ShowInButton"] = true;
            curRow.EndEdit();
        }
        
        //private void DGVPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        int index = Convert.ToInt32(this.DGVPackages.CurrentCell.ColumnIndex);
        //        string dataPropertyName = this.DGVPackages.Columns[index].DataPropertyName.ToString();
        //        switch (dataPropertyName)
        //        {
        //            case "Catalog":
        //                Load_CellClick();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch { }
        //}

        #region Add Item In Grid
        void AddInGrid_ObjectSelected(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (dataRow != null)
                    {
                        bool IsFound = false;
                        if (DGVPackages.Rows.Count > 1)
                        {
                            foreach (DataGridViewRow row in DGVPackages.Rows)
                            {
                                try
                                {
                                    if ((!Convert.ToString(row.Cells["CType"].Value).Equals("L")) && (!Convert.ToString(row.Cells["CType"].Value).Equals("F")))
                                    {
                                        int gridItemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                                        int xItemID = Convert.ToInt32(dataRow["ID"]);
                                        if (gridItemID == xItemID)
                                            IsFound = true;
                                    }
                                    if (Convert.ToString(row.Cells["CType"].Value).Equals("L"))
                                    {
                                        int gridItemID = Convert.ToInt32(row.Cells["LaborID"].Value);
                                        int xItemID = Convert.ToInt32(dataRow["ID"]);
                                        if (gridItemID == xItemID)
                                            IsFound = true;
                                    }
                                    if (Convert.ToString(row.Cells["CType"].Value).Equals("F"))
                                    {
                                        int gridItemID = Convert.ToInt32(row.Cells["FeeID"].Value);
                                        int xItemID = Convert.ToInt32(dataRow["ID"]);
                                        if (gridItemID == xItemID)
                                            IsFound = true;
                                    }
                                }
                                catch { }
                            }
                        }
                        if (!IsFound)
                        {
                            DataRowView newRow = (DataRowView)DGVPackages.objBindingSource.AddNew();
                            newRow.BeginEdit();
                            if ((!Convert.ToString(dataRow["CType"]).Equals("L")) && (!Convert.ToString(dataRow["CType"]).Equals("F")))
                                newRow["ItemID"] = dataRow["ID"];
                            if (Convert.ToString(dataRow["CType"]).Equals("L"))
                                newRow["LaborID"] = dataRow["ID"];
                            if (Convert.ToString(dataRow["CType"]).Equals("F"))
                                newRow["FeeID"] = dataRow["ID"];
                            newRow["Catalog"] = dataRow["Catalog"];
                            newRow["Name"] = dataRow["Name"];
                            newRow["Qty"] = 1;
                            newRow["CType"] = dataRow["CType"];
                            newRow["PriceOverride"] = dataRow["CatalogCost"];
                            newRow["IsOverride"] = false;
                            newRow["IsOptional"] = false;
                            newRow["Amount"] = dataRow["CatalogCost"];

                            newRow["Active"] = true;
                            newRow["AddDate"] = DateTime.Now;
                            newRow["AddUserID"] = StaticInfo.userid;
                            newRow["IsLocked"] = false;
                            newRow.EndEdit();

                        }
                    }
                }
                DGVPackagesCalculatColumns();
            }
            catch { }
        }
        #endregion


    }
}
