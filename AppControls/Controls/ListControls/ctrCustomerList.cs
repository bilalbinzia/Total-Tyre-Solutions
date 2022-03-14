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
    public delegate void CustomerSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrCustomerList : UserControl
    {
        public event CustomerSelectedDelegate CustomerSelected;
        BindingSource objBindingSource;
        public ctrCustomerList()
        {
            InitializeComponent();

            this.Load += ctrCustomerList_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

        }

        void ctrCustomerList_Load(object sender, EventArgs e)
        {

            objBindingSource.DataSource = dbClass.obj.FillCustomerList();
            this.searchDataGridView1.SetSource(objBindingSource);

            //this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

            //this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            //this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;
            //this.searchDataGridView1.TDataGridView.Columns["ID"].Visible = false;
            
        }
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (CustomerSelected != null)
                    CustomerSelected(this, curRow.Row);

                this.Parent.Parent.Parent.Dispose();
            }
            catch { }
        }

    }
}
