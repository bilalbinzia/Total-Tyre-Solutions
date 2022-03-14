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
    public delegate void VendorBillSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrVendorBillListing : UserControl
    {
        MainDataSet objDataSet;

        public event VendorBillSelectedDelegate VendorBillSelected;
        BindingSource objBindingSource;
        int VendorID = 0;
        public ctrVendorBillListing()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            this.Load += ctrVendorBillListing_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

        }
        public ctrVendorBillListing(int VenID)
        {
            InitializeComponent();

            objDataSet = new MainDataSet();
            this.VendorID = VenID;
            this.Load += ctrVendorBillListing_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);
        }

        void ctrVendorBillListing_Load(object sender, EventArgs e)
        {
            if(this.VendorID > 0)
                objBindingSource.DataSource = dbClass.obj.FillVendorBillsByVendorIDforPayments(objDataSet.Tables["VendorBill"], this.VendorID);
            else
                objBindingSource.DataSource = dbClass.obj.FillVendorBillsList();

            this.searchDataGridView1.SetSource(objBindingSource);

            //this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

            //this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;
            //this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
            
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (VendorBillSelected != null)
                    VendorBillSelected(this, curRow.Row);

                this.Parent.Parent.Parent.Dispose();
            }
            catch { }
        }

    }
}
