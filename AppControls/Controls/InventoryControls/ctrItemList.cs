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
    public partial class ctrItemList : UserControl
    {
        MainDataSet objDataSet;                
        BindingSource ItemBS;
        
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedItemGroupID = 0;
        int SelectedItemID = 0;
        bool AddPermission = false;

        public ctrItemList()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();                        
            ItemBS = new BindingSource();
            
            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrItemList_Load;
            btnItemNew.Click += btnItemNew_Click;
            btnItemEdit.Click += btnItemEdit_Click;
            btnItemGroup.Click += btnItemGroup_Click;
            btnItemCatalogDetails.Click += btnItemCatalogDetails_Click; 
            btnRefreshItems.Click += btnRefreshItems_Click;
            btnCopyItem.Click += btnCopyItem_Click;
            btnAdjustment.Click += btnAdjustment_Click;
            DGVItemList.TDataGridView.CellClick += TDataGridView_CellClick;
            DGVItemList.TDataGridView.MouseDoubleClick += TDataGridView_MouseDoubleClick;

            DGVItemList.SearchtxtBox.KeyUp += DGVItemList_SearchtxtBox_KeyUp;

            BindingControls();
        }

        private void DGVItemList_SearchtxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.SelectedItemID = 0;
            LoadTransactionHistory();
        }

        void ctrItemList_Load(object sender, EventArgs e)
        {                        
            DataRow[] row = StaticInfo.UserRights.Select("Code = '027'");
            if (row[0]["CanView"] != DBNull.Value)
                AddPermission = Convert.ToBoolean(row[0]["CanView"]);                       
            //-----------------------------------------------------
            this.WorkingPanel.BackColor = StaticInfo.ctrBackColor;
            //-----------------------------------------------------
            LoadctrItemsList();
        }

        void BindingControls()
        {
            ItemBS.DataSource = objDataSet.Tables["Item"];
        }

        private void btnItemGroup_Click(object sender, EventArgs e)
        {
           StaticInfo.LoadToControl("AppControls.ctrItemGroup", "Item Group", 0,0);
        }

        private void btnItemCatalogDetails_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPackagesList", "Packages List", 0, 0);
            //if (SelectedItemGroupID > 0)
            //{
            //    StaticInfo.LoadToControl("AppControls.ctrItemCatalog", "Item Catalog", SelectedItemGroupID, 0); 
            //}
            //else
            //{
            //    xMessageBox.Show("Please select Item...");
            //}
        }

        private void btnRefreshItems_Click(object sender, EventArgs e)
        {
            LoadctrItemsList();
        }
        private void btnCopyItem_Click(object sender, EventArgs e)
        {
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add Items.");
            }
            else
            {
                if (SelectedItemID > 0)
                {
                    dbClass.obj.DuplicateItem(SelectedItemID);
                    StaticInfo.LoadToControl("AppControls.ctrItemDefination", "Item Defination", 0);
                }
                else
                    xMessageBox.Show("Please Select any Item ...");
            }            
        }
        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            //if (!AddPermission)
            //{
            //    xMessageBox.Show("Sorry! You don't have Permissions to Add Items.");
            //}
            //else
            //{
            if (SelectedItemID > 0)
            {
                StaticInfo.LoadToControl("AppControls.ctrAdjustmentInventory", "Adjustment", SelectedItemID, 1);
            }
            else
                xMessageBox.Show("Please Select any Item ...");
            //}
        }
        
        void TDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add Items.");
            }
            else
            {
                if (SelectedItemID > 0)
                    StaticInfo.LoadToControl("AppControls.ctrItemDefination", "Item Defination", SelectedItemID, 1);
            }
        }

        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVItemList.TDataGridView.DataSource).Current;
            SelectedItemGroupID = Convert.ToInt32(curRow["ItemGroupID"]);
            SelectedItemID = Convert.ToInt32(curRow["ID"]);
            LoadTransactionHistory();
        }
        void LoadTransactionHistory()
        {
            DataTable dt2 = dbClass.obj.GetItemSaleHistory(SelectedItemID);
            DataView dv = dt2.DefaultView;
            dv.Sort = "Date DESC";
            DataTable dt = dv.ToTable();            
            DGItemSaleHistory.TDataGridView.DataSource = dt;
            DGItemSaleHistory.TDataGridView.AutoGenerateColumns = true;            
            DGItemSaleHistory.TDataGridView.Columns["Date"].DefaultCellStyle.Format= "MM/dd/yyyy";
            DGItemSaleHistory.TDataGridView.Columns["Item"].Width = 500;
            DGItemSaleHistory.TDataGridView.Columns["Store"].Width = 200;
            DGItemSaleHistory.TDataGridView.Columns["Company"].Width = 200;
            DGItemSaleHistory.TDataGridView.Columns["Rep"].Width = 120;

            DGItemSaleHistory.TDataGridView.Columns["Reference"].Visible = false;
            DGItemSaleHistory.TDataGridView.Columns["Rep"].HeaderText = "Representative";
        }
        void btnItemEdit_Click(object sender, EventArgs e)
        {
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add Items.");
            }
            else
            {
                if (SelectedItemID > 0)
                    StaticInfo.LoadToControl("AppControls.ctrItemDefination", "Item Defination", SelectedItemID, 1);
            }
        }

        void btnItemNew_Click(object sender, EventArgs e)
        {           
            if (!AddPermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Add Items.");                
            }
            else
            {
                StaticInfo.LoadToControl("AppControls.ctrItemDefination", "Item Defination", 0);
            }            
        }              
        
        void LoadctrItemsList()
        {
            DataTable dt = dbClass.obj.FillItemList();
            ItemBS.DataSource = dt;
            //DGVItemList.SetSource(ItemBS);
            DGVItemList.TDataGridView.DataSource = ItemBS;
            DGVItemList.TDataGridView.AutoGenerateColumns = true;
            //DGVItemList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //DGVItemList.TDataGridView.AutoResizeColumns();
            DGVItemList.TDataGridView.Columns["ID"].Visible = false;
            DGVItemList.TDataGridView.Columns["ItemSize"].Width = 100;
            DGVItemList.TDataGridView.Columns["Catalog"].Width = 250;
            DGVItemList.TDataGridView.Columns["Name"].Width = 500;
            DGVItemList.TDataGridView.Columns["ItemGroupID"].Visible = false;
            DGVItemList.TDataGridView.Columns["InStock"].Width = 60;

            DGVItemList.TDataGridView.Columns["CatalogCost"].Width = 80;
            DGVItemList.TDataGridView.Columns["FET"].Width = 50;

            DGVItemList.TDataGridView.Columns["RetailPrice"].Width = 110;
            DGVItemList.TDataGridView.Columns["RetailPrice"].HeaderText = "Retail Price";

            DGVItemList.TDataGridView.Columns["WholeSalePrice"].Width = 110;
            DGVItemList.TDataGridView.Columns["WholeSalePrice"].HeaderText = "Wholesale Price";

            DGVItemList.TDataGridView.Columns["SpecialPrice"].Width = 110;
            DGVItemList.TDataGridView.Columns["SpecialPrice"].HeaderText = "Special Price";

            //DGVItemList.TDataGridView.Columns["ItemType"].Width = 130;
        }
    }
}
