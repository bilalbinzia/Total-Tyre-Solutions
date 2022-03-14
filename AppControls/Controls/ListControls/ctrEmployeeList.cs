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
    public delegate void EmployeeSelectedDelegate(object sender, DataRow dataRow);
    public partial class ctrEmployeeList : UserControl
    {
        public event EmployeeSelectedDelegate EmployeeSelected;
        BindingSource objBindingSource;
        public ctrEmployeeList()
        {
            InitializeComponent();

            this.Load += ctrEmployeeList_Load;
            objBindingSource = new BindingSource();
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

        }

        void ctrEmployeeList_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objBindingSource.DataSource = dbClass.obj.FillEmployeeList(dt);
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
                if (EmployeeSelected != null)
                    EmployeeSelected(this, curRow.Row);

                this.Parent.Parent.Parent.Dispose();
            }
            catch (Exception ex){ }
        }

    }
}
