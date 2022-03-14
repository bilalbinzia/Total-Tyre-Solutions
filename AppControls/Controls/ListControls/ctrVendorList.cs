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
    public delegate void VendorSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrVendorList : UserControl
    {
        public event VendorSelectedDelegate VendorSelected;
        BindingSource objBindingSource;
        public ctrVendorList()
        {
            InitializeComponent();

            this.Load += ctrVendorList_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

        }

        void ctrVendorList_Load(object sender, EventArgs e)
        {

            objBindingSource.DataSource = dbClass.obj.FillVendorList();
            this.searchDataGridView1.SetSource(objBindingSource);

            //this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

            //this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            ////this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;
            //this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
            
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                var a = curRow.Row;
                if (VendorSelected != null)
                    VendorSelected(this, curRow.Row);

                this.ParentForm.Close();
            }
            catch(Exception ex) {
                //throw new Exception(ex.Message);
            }
        }

    }
}
