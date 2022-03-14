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
    public partial class ctrOnOrderList : UserControl
    {        
        BindingSource objBindingSource;
        Int32 ItemID = 0;
        public ctrOnOrderList()
        {
            InitializeComponent();

            this.Load += ctrOnOrderList_Load;
            objBindingSource = new BindingSource();
            
        }
        public ctrOnOrderList(Int32 ItemID)
        {
            InitializeComponent();

            this.Load += ctrOnOrderList_Load;
            objBindingSource = new BindingSource();
            this.ItemID = ItemID;
        }

        void ctrOnOrderList_Load(object sender, EventArgs e)
        {            
            objBindingSource.DataSource = dbClass.obj.getOnOrderInventoryInfo(ItemID);
            this.searchDataGridView1.TDataGridView.DataSource = objBindingSource;

            this.searchDataGridView1.TDataGridView.AutoGenerateColumns = true;
            this.searchDataGridView1.TDataGridView.RowHeadersVisible = true;

            this.searchDataGridView1.TDataGridView.Columns["ItemID"].Visible = false;
            this.searchDataGridView1.TDataGridView.Columns["Catalog"].Visible = false;
            this.searchDataGridView1.TDataGridView.Columns["ItemName"].Visible = false;
            this.searchDataGridView1.TDataGridView.Columns["VendorID"].Visible = false;

            this.searchDataGridView1.TDataGridView.Columns["PONo"].HeaderText = "PO #";
            this.searchDataGridView1.TDataGridView.Columns["PONo"].Width = 50;
            this.searchDataGridView1.TDataGridView.Columns["PODate"].Width = 80;
            this.searchDataGridView1.TDataGridView.Columns["BO"].Width = 60;

            this.searchDataGridView1.TDataGridView.Columns["QtyOrdrd"].HeaderText = "Ordrd";
            this.searchDataGridView1.TDataGridView.Columns["QtyOrdrd"].Width = 60;

            this.searchDataGridView1.TDataGridView.Columns["QtyRcvd"].HeaderText = "Rcvd";
            this.searchDataGridView1.TDataGridView.Columns["QtyRcvd"].Width = 60;

            this.searchDataGridView1.TDataGridView.Columns["QtyBilled"].HeaderText = "Billed";
            this.searchDataGridView1.TDataGridView.Columns["QtyBilled"].Width = 60;

            this.searchDataGridView1.TDataGridView.Columns["VendorName"].HeaderText = "Vendor Name";
            this.searchDataGridView1.TDataGridView.Columns["VendorName"].Width = 240;


            DataTable dt = (DataTable)((BindingSource)objBindingSource).DataSource;
            txtItemCatalog.Text = Convert.ToString(dt.Rows[0]["Catalog"]);
            txtItemName.Text = Convert.ToString(dt.Rows[0]["ItemName"]);

        }
        
    }
}
