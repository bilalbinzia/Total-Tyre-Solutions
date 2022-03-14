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
using CrystalDecisions.Shared.Json;

namespace AppControls
{
    public partial class ctrPackage : UserControl
    {
        int PackageID = 0;
        BindingSource PackageBS;
        public BindingSource objBindingSource = null;
        MainDataSet objDataSet;

        public ctrPackage()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            PackageBS = new BindingSource();
            InitializeComponent1();
            DisableControls();

        }
        public ctrPackage(int PackageID)
        {
            objDataSet = new MainDataSet();
            PackageBS = new BindingSource();
            InitializeComponent();
            InitializeComponent1();
            this.PackageID = PackageID;
            BindingControls();
        }
        private void InitializeComponent1()
        {
            this.Load += ctrPackage_Load;
            this.txtCatalog.KeyDown += txtCatalog_KeyDown;
            this.btnAddCatalog.Click += btnAddCatalog_Click;
            this.DGVPackage.CellEndEdit += DGVPackage_CellEndEdit;
            btnBNAddItem.Click += btnBNAddItem_Click;
            btnBNEditItem.Click += btnBNEditItem_Click;
        }

        private void btnBNEditItem_Click(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void btnBNAddItem_Click(object sender, EventArgs e)
        {
            EnableControls();
        }

        void BindingControls()
        {
            PackageBS.DataSource = dbClass.obj.GetPackageDetailsByID(this.PackageID);
        }
        private void ctrPackage_Load(object sender, EventArgs e)
        {
            LoadPackage();
        }
        void LoadPackage()
        {
            if (this.PackageID > 0)
            {
                try
                {
                    DataTable Pkgdt = new DataTable();
                    DataTable Itmdt = new DataTable();
                    DataTable emptydt = new DataTable();
                    DataSet ds = new DataSet();
                    ds = dbClass.obj.GetPackageDetailsByID(this.PackageID);
                    PackageBS.DataSource = Itmdt;
                    if (Itmdt.Rows.Count == 0)
                    {
                        DGVPackage.DataSource = emptydt;
                    }
                    else
                    {
                        DGVPackage.DataSource = null;
                        DGVPackage.DataSource = PackageBS;
                    }
                    Pkgdt = dbClass.obj.FillPackageByID(this.PackageID);
                    if (Pkgdt.Rows.Count > 0)
                    {
                        TATCatalog.Text = Pkgdt.Rows[0][1].ToString();
                        TATPackage.Text = Pkgdt.Rows[0][2].ToString();
                        TATPackageCharges.Text = Pkgdt.Rows[0][3].ToString();
                    }
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
        void DisableControls()
        {
            btnBNSaveItem.Enabled = false;
            btnBNCancelItem.Enabled = false;
            btnBNEditItem.Enabled = true;
            btnBNDeleteItem.Enabled = true;
            btnBNCancelItem.Enabled = true; 

            TATCatalog.Enabled = false;
            TATPackage.Enabled = false;
            TATPackageCharges.Enabled = false;
            TATchkActive.Enabled = false;
            TATchkShowinbtn.Enabled = false;
        }
        void EnableControls()
        {
            btnBNSaveItem.Enabled = true;
            btnBNCancelItem.Enabled = true;
            TATCatalog.Enabled = true;
            TATPackage.Enabled = true;
            TATPackageCharges.Enabled = true;
            TATchkActive.Enabled = true;
            TATchkShowinbtn.Enabled = true;
        }
        private void DGVPackage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAddCatalog_Click(object sender, EventArgs e)
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
        #region Add Item In Grid
        void AddInGrid_ObjectSelected(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                if (dataRow != null)
                {
                    bool IsFound = false;

                    if (DGVPackage.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in DGVPackage.Rows)
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
                        DGVPackage.Rows.Add();
                        int i = DGVPackage.Rows.Count - 1;
                        DataGridViewRow newRow = DGVPackage.Rows[i];
                        //newRow.BeginEdit();
                        //if ((!Convert.ToString(dataRow["CType"]).Equals("L")) && (!Convert.ToString(dataRow["CType"]).Equals("F")))
                        //    newRow.Cells["ItemID"] = dataRow["ID"];
                        //if (Convert.ToString(dataRow["CType"]).Equals("L"))
                        //    newRow["LaborID"] = dataRow["ID"];
                        //if (Convert.ToString(dataRow["CType"]).Equals("F"))
                        //    newRow["FeeID"] = dataRow["ID"];
                        //newRow["Catalog"] = dataRow["Catalog"];
                        //newRow["Name"] = dataRow["Name"];
                        //newRow["Qty"] = 1;
                        //newRow["CType"] = dataRow["CType"];
                        //newRow["PriceOverride"] = dataRow["CatalogCost"];
                        //newRow["IsOverride"] = false;
                        //newRow["IsOptional"] = false;
                        //newRow["Amount"] = dataRow["CatalogCost"];

                        //newRow["Active"] = true;
                        //newRow["AddDate"] = DateTime.Now;
                        //newRow["AddUserID"] = StaticInfo.userid;
                        //newRow["IsLocked"] = false;
                        //newRow.EndEdit();
                    }
                }
                DGVPackagesCalculatColumns();
            }
            catch { }
        }

        #endregion

        private void txtCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        void DGVPackagesCalculatColumns()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            //-------------------------------------------------------------                        
            decimal TotalAmount = 0;

            foreach (DataGridViewRow n in DGVPackage.Rows)
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
            //if (Pkgdt.Rows.Count == 0)
            //{
            //    curRow["PackageWithTax"] = TotalAmount;
            //}
            //else
            //{
            //    curRow["PackageWithTax"] = Pkgdt.Rows[0][3].ToString();
            //}
            curRow.EndEdit();
        }
    }
}
