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

namespace AppControls
{
    public delegate void ObjectDelegate(object sender, DataSet ds, int packageID);
    public partial class ctrPackageListForGrid : UserControl
    {
        public event ObjectDelegate ObjectSelected;
        string tblName = "";
        private BindingSource bindingSource;
        MainDataSet objDataSet;
        BindingSource PackageBS;
        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedPackageID = 0;
        public ctrPackageListForGrid()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            bindingSource = new BindingSource();
            this.Load += ctrPackageListForGrid_Load;
            this.SearchPackageDataGridView2.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DGVPackageList_CellMouseDoubleClick);
        }
        public ctrPackageListForGrid(string tblName)
        {
            InitializeComponent();
            this.tblName = tblName;
            bindingSource = new BindingSource();
            this.Load += ctrPackageListForGrid_Load;
        }
        
        private void ctrPackageListForGrid_Load(object sender, EventArgs e)
        {
            LoadctrPackagesList();
        }
        void LoadctrPackagesList()
        {
            try
            {
                DataTable DT = new DataTable();
                DataTable dt = dbClass.obj.FillWarehousePackages(DT);
                bindingSource.DataSource = dt;
                SearchPackageDataGridView2.TDataGridView.DataSource = bindingSource;
                SearchPackageDataGridView2.TDataGridView.AutoGenerateColumns = true;
                SearchPackageDataGridView2.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                SearchPackageDataGridView2.TDataGridView.AutoResizeColumns();
                //DGVItemList.TDataGridView.Columns["ID"].Visible = false;
                //DGVItemList.TDataGridView.Columns["ItemSize"].Width = 100;
                //DGVItemList.TDataGridView.Columns["Catalog"].Width = 110;
                //DGVItemList.TDataGridView.Columns["Name"].Width = 400;
                //DGVItemList.TDataGridView.Columns["ItemGroupID"].Visible = false;
                //DGVItemList.TDataGridView.Columns["InStock"].Width = 60;
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
        
        private void DGVPackageList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)((BindingSource)(((System.Windows.Forms.DataGridView)(SearchPackageDataGridView2.TDataGridView)).DataSource)).Current;
                SelectedPackageID = Convert.ToInt32(curRow["ID"]);
                DataSet ds = dbClass.obj.GetPackageDetailsByID(SelectedPackageID);
                //DataTable dt = new DataTable();
                if (ObjectSelected != null)
                    ObjectSelected(this, ds, SelectedPackageID);
                this.Parent.Parent.Parent.Dispose();
            }
            catch(Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
    }
}
