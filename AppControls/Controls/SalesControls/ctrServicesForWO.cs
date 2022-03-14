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

namespace AppControls
{
    public delegate void ServiceSelectedDelegate(object sender, DataRow dataRow);
    public delegate void SLSelectedDelegate(object sender, string ShopLabor);
    public delegate void OPSelectedDelegate(object sender, string OutsidePart);
    public partial class ctrServicesForWO : OperationalControl
    {
        public event ServiceSelectedDelegate ServiceSelected;
        public event SLSelectedDelegate ShopLabor;
        public event OPSelectedDelegate OutsidePart;

        DataTable dt;
        
        public ctrServicesForWO()
        {
            InitializeComponent();
            this.Load += ctrServicesForWO_Load;
            this.searchDataGridView1.TDataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGrid_CellMouseDoubleClick);

            this.btnShopLabor.Click += btnShopLabor_Click;
            this.btnOutsidePart.Click += btnOutsidePart_Click;
        }

        void btnOutsidePart_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (OutsidePart != null)
                OutsidePart(this, "OP");
        }

        void btnShopLabor_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (ShopLabor != null)
                ShopLabor(this, "SL");
        }

        void ctrServicesForWO_Load(object sender, EventArgs e)
        {
            this.btnShopLabor.Enabled = true;
            this.btnOutsidePart.Enabled = true;

            searchDataGridView1.TDataGridView.Columns[2].Width = 235;

            dt = (DataTable)this.objBindingSource.DataSource;
            int x = 2;
            foreach (DataRow row in dt.Rows)
            {                
                if(Convert.ToBoolean(row["ShowInButton"]))
                {
                    ControlLibrary.TAButton btnService = new ControlLibrary.TAButton();
                    btnService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    btnService.ForeColor = System.Drawing.Color.White;
                    btnService.Location = new System.Drawing.Point(4, x);
                    btnService.Name = Convert.ToString(row["ID"]);
                    btnService.Tag = Convert.ToString(row["ID"]);
                    btnService.Size = new System.Drawing.Size(152, 40);
                    btnService.TabIndex = 8;
                    btnService.Text = Convert.ToString(row["Name"]);
                    
                    btnService.Click += btnService_Click;
                    this.panel2.Controls.Add(btnService);
                    x += 40;
                }
            }
        }

        void btnService_Click(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt32(((TAButton)sender).Tag);
            DataRow curRow = dt.AsEnumerable().SingleOrDefault(r => r.Field<int>("ID") == serviceID);
            if (ServiceSelected != null)
                ServiceSelected(this, curRow);
        }
                
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (ServiceSelected != null)
                    ServiceSelected(this, curRow.Row);
            }
            catch { }
        }

    }
}
