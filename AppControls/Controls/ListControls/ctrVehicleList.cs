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
    public delegate void VehicleSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrVehicleList : UserControl
    {
        public event VehicleSelectedDelegate VehicleSelected;
        int CustID = 0;
        BindingSource objBindingSource;
        public ctrVehicleList()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        void InitializeComponent1()
        {
            this.Load += ctrVehicleList_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }
        public ctrVehicleList(int CustID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.CustID = CustID;
        }
        void ctrVehicleList_Load(object sender, EventArgs e)
        {
            if (this.CustID > 0)
            {
                objBindingSource.DataSource = dbClass.obj.FillVehiclesByCustomerID(this.CustID);
                this.searchDataGridView1.SetSource(objBindingSource);

                //this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

                //this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
                ////this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;
                //this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
                                
            }
        }
                
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (VehicleSelected != null)
                    VehicleSelected(this, curRow.Row);

                this.Parent.Dispose();
            }
            catch { }
        }

    }
}
