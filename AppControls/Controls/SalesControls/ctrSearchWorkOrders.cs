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
    public delegate void SearchWorkOrderDelegate(object sender, DataTable dataTable);
    public partial class ctrSearchWorkOrders : UserControl
    {
        public event SearchWorkOrderDelegate SearchWorkOrder;
        ControlLibrary.MessageBox xMessageBox = null;
        int WorkOrderID = 0;
        public ctrSearchWorkOrders()
        {
            InitializeComponent();
            xMessageBox = new ControlLibrary.MessageBox();

            //this.Load += ctrSearchWorkOrders_Load;
                        
            this.btnCancel.Click += btnCancel_Click;
            btnWorkOrders.Click += btnWorkorder_Click;
            btnInvoice.Click += btnInvoices_Click;
            btnNegate.Click += btnNegatedInvoice_Click;
        }        

        void btnNegatedInvoice_Click(object sender, EventArgs e)
        {
            string NegateNo = txtNegateNo.Text;
            if (!string.IsNullOrEmpty(NegateNo))
            {
                DataTable NegatedInvoice = dbClass.obj.getNegatedInvoicesBySearch(NegateNo);
                if (SearchWorkOrder != null)
                {
                    SearchWorkOrder(this, NegatedInvoice);
                    this.Parent.Parent.Parent.Dispose();
                }
            }
            else
                xMessageBox.Show("Enter Negate No ...");
        }
        void btnWorkorder_Click(object sender, EventArgs e)
        {
            string WorkOrderNo = txtWorkOrder.Text;
            if (!string.IsNullOrEmpty(WorkOrderNo))
            {
                DataTable Workorders = dbClass.obj.getWorkOrderBySearch(WorkOrderNo);
                if (SearchWorkOrder != null)
                {
                    SearchWorkOrder(this, Workorders);
                    this.Parent.Parent.Parent.Dispose();
                }
            }
            else
                xMessageBox.Show("Enter WorkOrder No ...");
        }
        void btnInvoices_Click(object sender, EventArgs e)
        {
            string InvoiceNo = txtInvoiceNo.Text;
            if (!string.IsNullOrEmpty(InvoiceNo))
            {
                DataTable Invoices = dbClass.obj.getInvoicesBySearch(InvoiceNo);
                if (SearchWorkOrder != null)
                {
                    SearchWorkOrder(this, Invoices);
                    this.Parent.Parent.Parent.Dispose();
                }
            }
            else
                xMessageBox.Show("Enter Invoice No ...");
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            //this.Parent.Dispose();
        }        
        
    }
}
