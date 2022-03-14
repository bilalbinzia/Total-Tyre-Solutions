using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System32;

namespace AppControls
{
    public partial class ctrPackagesList : UserControl
    {
        MainDataSet objDataSet;
        BindingSource PackageBS;
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedPackageID = 0;

        public ctrPackagesList()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            PackageBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrPackagesList_Load;
            btnNewPackage.Click += btnNewPackage_Click;
            btnEditPackage.Click += btnEditPackage_Click;
            btnRefreshPackages.Click += btnRefreshPackages_Click;
            DGVPackageList.TDataGridView.CellClick += TDataGridView_CellClick;
           
            BindingControls();
        }
        public ctrPackagesList(bool status)
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            PackageBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrPackagesList_Load;
            btnNewPackage.Click += btnNewPackage_Click;
            btnEditPackage.Click += btnEditPackage_Click;
            btnRefreshPackages.Click += btnRefreshPackages_Click;
            DGVPackageList.TDataGridView.CellClick += TDataGridView_CellClick;

            BindingControls();
        }
        private void btnRefreshPackages_Click(object sender, EventArgs e)
        {
            LoadctrPackagesList();
        }

        private void btnEditPackage_Click(object sender, EventArgs e)
        {
            if (SelectedPackageID > 0)
            { 
                StaticInfo.LoadToControl("AppControls.ctrPackages", "Catalog Package", SelectedPackageID, 1);
            }
            else
            {
                xMessageBox.Show("Please select package...");
            }
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrPackages","Catalog Package", 0, 0);
        }

        private void ctrPackagesList_Load(object sender, EventArgs e)
        {
            LoadctrPackagesList();
        }
        
        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGVPackageList.TDataGridView.DataSource).Current;
            SelectedPackageID = Convert.ToInt32(curRow["ID"]);
        }
        void BindingControls()
        {
            PackageBS.DataSource = objDataSet.Tables["WarehousePackages"];
        }
        void LoadctrPackagesList()
        {
            try
            {
                DataTable DT = new DataTable();
                DataTable dt = dbClass.obj.FillWarehousePackages(DT);
                PackageBS.DataSource = dt;
                DGVPackageList.TDataGridView.DataSource = PackageBS;
                DGVPackageList.TDataGridView.AutoGenerateColumns = true;
                DGVPackageList.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                DGVPackageList.TDataGridView.AutoResizeColumns();
                //DGVItemList.TDataGridView.Columns["ID"].Visible = false;
                //DGVItemList.TDataGridView.Columns["ItemSize"].Width = 100;
                //DGVItemList.TDataGridView.Columns["Catalog"].Width = 110;
                //DGVItemList.TDataGridView.Columns["Name"].Width = 400;
                //DGVItemList.TDataGridView.Columns["ItemGroupID"].Visible = false;
                //DGVItemList.TDataGridView.Columns["InStock"].Width = 60;

                //DGVItemList.TDataGridView.Columns["CatalogCost"].Width = 80;
                //DGVItemList.TDataGridView.Columns["FET"].Width = 50;

                //DGVItemList.TDataGridView.Columns["PriceA"].Width = 110;
                //DGVItemList.TDataGridView.Columns["PriceA"].HeaderText = "Retail Price";

                //DGVItemList.TDataGridView.Columns["PriceB"].Width = 110;
                //DGVItemList.TDataGridView.Columns["PriceB"].HeaderText = "Wholesale Price";

                //DGVItemList.TDataGridView.Columns["PriceC"].Width = 110;
                //DGVItemList.TDataGridView.Columns["PriceC"].HeaderText = "Special Price";

                //DGVItemList.TDataGridView.Columns["ItemType"].Width = 130;
            }
            catch(Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
    }
}
