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
using System32;

namespace AppControls
{
    public partial class ctrNegateWindow : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = null;
        int WorkOrderID = 0;
        public ctrNegateWindow()
        {
            InitializeComponent();
            xMessageBox = new ControlLibrary.MessageBox();

            this.Load += ctrNegateWindow_Load;
                        
            this.btnCancel.Click += btnCancel_Click;
            btnNegateInvoice.Click += btnNegateInvoice_Click;
        }
        public ctrNegateWindow(int WOID)
        {
            InitializeComponent();
            xMessageBox = new ControlLibrary.MessageBox();
            this.WorkOrderID = WOID;

            this.Load += ctrNegateWindow_Load;

            btnCancel.Click += btnCancel_Click;
            btnNegateInvoice.Click += btnNegateInvoice_Click;
        }

        void btnNegateInvoice_Click(object sender, EventArgs e)
        {
            DataRow WorkOrder = dbClass.obj.getWorkOrderByID(this.WorkOrderID);
            if (WorkOrder != null)
            {
                int WorkOrderNegateNo = dbClass.obj.getNextWorkOrderNegateAutoNo();
                xMessageBox.Show("Workorder # " + Convert.ToString(this.WorkOrderID) + " has been created, which is a reverse of the invoice.");                
                //------------------------------------------------------------------//                
                int WorkOrderID = Convert.ToInt32(WorkOrder["ID"]);
                if (WorkOrderID > 0)
                    StaticInfo.LoadToControl("AppControls.ctrWorkOrderNegate", "WorkOrderNegate", this.WorkOrderID, WorkOrderNegateNo);
                //------------------------------------------------------------------//
                this.ParentForm.Close();
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            //this.Parent.Dispose();
        }

        void ctrNegateWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
