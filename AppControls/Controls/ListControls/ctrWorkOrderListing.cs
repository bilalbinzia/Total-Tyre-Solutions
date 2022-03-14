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

    public delegate void WorkOrderSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrWorkOrderListing : UserControl
    {
        public event WorkOrderSelectedDelegate WorkOrderSelected;
        BindingSource objBindingSource;
        int CustomerID = 0;
        public ctrWorkOrderListing()
        {
            InitializeComponent();

            this.Load += ctrWorkOrderListing_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

        }
        public ctrWorkOrderListing(int CustID)
        {
            InitializeComponent();

            this.CustomerID = CustID;
            this.Load += ctrWorkOrderListing_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }

        void ctrWorkOrderListing_Load(object sender, EventArgs e)
        {
            if (this.CustomerID > 0)
            {
                objBindingSource.DataSource = dbClass.obj.FillWorkOrderListByCustID(this.CustomerID);
            }
            else
            {
                objBindingSource.DataSource = dbClass.obj.FillWorkOrderList();
            }
           
            this.searchDataGridView1.SetSource(objBindingSource);
            this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;

            //this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;
            //this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            //this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (WorkOrderSelected != null)
                    WorkOrderSelected(this, curRow.Row);

                this.Parent.Parent.Parent.Dispose();
            }
            catch { }
        }

    }
}
