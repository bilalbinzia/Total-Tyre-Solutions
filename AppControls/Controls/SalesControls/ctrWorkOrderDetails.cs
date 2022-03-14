using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;

namespace AppControls
{
    public partial class ctrWorkOrderDetails : UserControl
    {
        int WorkOrderID = 0;
        public ctrWorkOrderDetails()
        {
            InitializeComponent();
            this.Load += ctrWorkOrderDetails_Load;
        }
        public ctrWorkOrderDetails(int OrderID)
        {
            InitializeComponent();
            this.WorkOrderID = OrderID;
            LoadWorkOrderDetails(WorkOrderID);
            this.Load += ctrWorkOrderDetails_Load;
        }
        private void ctrWorkOrderDetails_Load(object sender, EventArgs e)
        {
            
        }
        void LoadWorkOrderDetails(int WorkOrderID)
        {
            DataTable dt = dbClass.obj.FillSelectedWorkOrderByID(WorkOrderID);
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    lblComputerIP.Text = dt.Rows[i]["ComputerIP"].ToString();
                    txtCustomerAddress.Text = dt.Rows[i]["CustomerAddress"].ToString();
                    lblOrderDate.Text = dt.Rows[i]["Date"].ToString();
                }
            }
        }
    }
}
