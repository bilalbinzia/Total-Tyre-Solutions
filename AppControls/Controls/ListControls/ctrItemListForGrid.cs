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

namespace AppControls
{
    public delegate void ObjectSelectedDelegate(object sender, DataRow dataRow, int packageID);
    //public delegate void ItemGroupItemsDelegate(object sender, DataRow dataRow);
    public partial class ctrItemListForGrid : UserControl
    {        
        public event ObjectSelectedDelegate ObjectSelected;
        string tblName = "";
        private BindingSource bindingSource;
        int CusID = 0;
        string CustomerPriceLevel;
        public ctrItemListForGrid()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            this.Load += ctrItemListForGrid_Load;
            cboBoxItmType.SelectedIndexChanged += cboBoxItmType_SelectedIndexChanged;
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }
        public ctrItemListForGrid(string tblName)
        {
            InitializeComponent();
            this.tblName = tblName;
            bindingSource = new BindingSource();
            this.Load += ctrItemListForGrid_Load;
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }
        public ctrItemListForGrid(int cusID, string customerPriceLevel)
        {
            InitializeComponent();
            this.CusID = cusID;
            this.CustomerPriceLevel = customerPriceLevel;

            bindingSource = new BindingSource();
            this.Load += ctrItemListForGrid_Load;
            cboBoxItmType.SelectedIndexChanged += cboBoxItmType_SelectedIndexChanged;
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }
        void cboBoxItmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itmType = cboBoxItmType.SelectedItem.ToString();
            searchDataGridView1.SearchtxtBox.Text = itmType;
            searchDataGridView1.FilterOnDataSource();
        }        

        void ctrItemListForGrid_Load(object sender, EventArgs e)
        {
            if (this.tblName == "")
            {
                DataTable dt;
                if(this.CusID > 0)
                    dt = dbClass.obj.getItemsForGridByCustomerID(this.CusID, this.CustomerPriceLevel);
                else
                    dt = dbClass.obj.getItemsForGrid();
                dt.TableName = "Item";
                bindingSource.DataSource = dt;
            }
            else if (this.tblName == "Item")
            {
                DataTable dt = dbClass.obj.getItemsForPackageGrid();
                dt.TableName = "Item";
                bindingSource.DataSource = dt;
            }
            else if (this.tblName == "Fee")
            {
                DataTable dt = dbClass.obj.getFeesForGrid();
                dt.TableName = "Fee";
                bindingSource.DataSource = dt;
            }
            else if (this.tblName == "Labor")
            {
                DataTable dt = dbClass.obj.getLaborsForGrid();
                dt.TableName = "Labor";
                bindingSource.DataSource = dt;
            }
            searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            searchDataGridView1.TDataGridView.RowHeadersVisible = true;
            searchDataGridView1.TDataGridView.DataSource = bindingSource;

            foreach (DataGridViewColumn gridColumn in searchDataGridView1.TDataGridView.Columns)
            { gridColumn.Visible = false; gridColumn.ReadOnly = true; }

            //searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
            //searchDataGridView1.TDataGridView.Columns["Catalog"].Visible = true;
            try
            {
                if (this.tblName == "")
                {
                    searchDataGridView1.TDataGridView.Columns["ItmType"].Width = 80;
                    searchDataGridView1.TDataGridView.Columns["ItmType"].Visible = true;
                    cboBoxItmType.Visible = true;
                }
            }
            catch { }
            searchDataGridView1.TDataGridView.Columns["ItemSize"].Visible = true;
            searchDataGridView1.TDataGridView.Columns["ItemSize"].Width = 100;

            searchDataGridView1.TDataGridView.Columns["Catalog"].Visible = true;
            searchDataGridView1.TDataGridView.Columns["Catalog"].Width = 250;

            searchDataGridView1.TDataGridView.Columns["Name"].Visible = true;
            searchDataGridView1.TDataGridView.Columns["Name"].Width = 400;
            
            searchDataGridView1.TDataGridView.Columns["Price"].Visible = true;
            searchDataGridView1.TDataGridView.Columns["Price"].HeaderText = "Price";

            
            //searchDataGridView1.TDataGridView.Columns["ItemType"].Visible = true;
            //searchDataGridView1.TDataGridView.Columns["BoltPattern"].Visible = true;
            //searchDataGridView1.TDataGridView.Columns["ManufacturerNo"].Visible = true;
            //searchDataGridView1.TDataGridView.Columns["VenderPartNo"].Visible = true;
            //searchDataGridView1.TDataGridView.Columns["UnitWeight"].Visible = true;
            //searchDataGridView1.TDataGridView.Columns["CatalogCost"].Visible = true;
        }
                
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {                
                DataRowView curRow = (DataRowView)((BindingSource)(((System.Windows.Forms.DataGridView)(searchDataGridView1.TDataGridView)).DataSource)).Current;
                if (ObjectSelected != null)
                    ObjectSelected(this, curRow.Row,0);

                this.Parent.Parent.Parent.Dispose();
                
            }
            catch { }
        }
    }
}
