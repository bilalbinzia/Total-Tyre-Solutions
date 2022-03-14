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
    public delegate void AccountSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrAccountList : UserControl
    {
        public event AccountSelectedDelegate AccountSelected;
        BindingSource objBindingSource;
        Int32 AccID = 0;
        DataTable dt;        
        public ctrAccountList()
        {
            InitializeComponent();
            InitializeComponent1();            
        }
        public ctrAccountList(Int32 ID)
        {
            InitializeComponent();
            InitializeComponent1();
            
            this.AccID = ID;
        }
        void InitializeComponent1()
        {
            this.Load += ctrAccountList_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
            this.chkboxViewAll.CheckedChanged += chkboxViewAll_CheckedChanged;            
        }

        void chkboxViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxViewAll.Checked)
            {
                DataTable datatable = dbClass.obj.FillAccountListLevel0();
                dt = datatable.Clone();
                foreach (DataRow dr in datatable.Rows)
                {
                    int AccID1 = Convert.ToInt32(dr["AccID"]);
                    DataTable datatable1 = dbClass.obj.FillAccountList(AccID1);                    
                    foreach (DataRow dr1 in datatable1.Rows)
                    {
                        addRowInDataTable(dr1);
                    } 
                }                
            }
            else
            {
                DataTable datatable = dbClass.obj.FillAccountList(this.AccID);
                dt = datatable.Clone();
                foreach (DataRow dr in datatable.Rows)
                {
                    addRowInDataTable(dr);
                }                
            }

            LoadGrid();
        }
        void LoadDataTable() 
        {
            DataTable datatable =  dbClass.obj.FillAccountList(this.AccID);
            dt = datatable.Clone();
            foreach (DataRow dr in datatable.Rows)
            {
                addRowInDataTable(dr);
            }
        }
        void addRowInDataTable(DataRow dr)
        {            
            dt.Rows.Add(dr.ItemArray);
            int AccID = Convert.ToInt32(dr["AccID"]);
            DataTable datatable = dbClass.obj.FillAccountList2(AccID);
            foreach (DataRow dr1 in datatable.Rows)
            {                
                dt.Rows.Add(dr1.ItemArray);
            }
        }
        void ctrAccountList_Load(object sender, EventArgs e)
        {
            if (AccID == 0)
            {
                dt = dbClass.obj.FillAccountList();
            }
            else
            {
                LoadDataTable();
            }
            LoadGrid();
        }
        void LoadGrid()
        {
            objBindingSource.DataSource = dt;

            this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

            this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            //this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;

            this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
            this.searchDataGridView1.TDataGridView.Columns["AccID"].Visible = false;
            this.searchDataGridView1.TDataGridView.Columns["AccTypeID"].Visible = false;

            this.searchDataGridView1.TDataGridView.Columns["AccName"].Width = 350;
            //this.searchDataGridView1.TDataGridView.Columns["AccNo"].Width = 100;
            this.searchDataGridView1.TDataGridView.Columns["Acc.Type"].Width = 200;
            this.searchDataGridView1.TDataGridView.Columns["Active"].Width = 50;
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (AccountSelected != null)
                    AccountSelected(this, curRow.Row);

                this.ParentForm.Close();
            }
            catch { }
        }

    }
}
