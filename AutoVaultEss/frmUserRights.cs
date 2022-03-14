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
using AppControls;
using System32;
using ControlLibrary;

namespace AutoVaultEss
{
    public partial class frmUserRights : UserControl
    {
        MainDataSet objDataSet;
        BindingSource ItemBS;
        int EmployeeID = 0;
        public System.Windows.Forms.Timer timer1;
        frmOperationMessage frmMessage;

        ControlLibrary.MessageBox xMessageBox = null;
        int SelectedItemGroupID = 0;
        int SelectedItemID = 0;
        public frmUserRights()
        {
            InitializeComponent();
            objDataSet = new MainDataSet();
            ItemBS = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += frmUserRights_Load;

            DGVEmployeeList.TDataGridView.CellClick += DGVEmployeeList_TDataGridView_CellClick;
            DGVWorkOrdersRightsList.CellClick += DGVWorkOrdersRightsList_CellClick;
            DGVWorkOrdersRightsList.CellEndEdit += DGVWorkOrdersRightsList_CellEndEdit;
            DGVInvoicingRightsList.CellClick += DGVInvoicingRightsList_CellClick;
            DGVInvoicingRightsList.CellEndEdit += DGVInvoicingRightsList_CellEndEdit;
            DGVAccountingRightsList.CellClick += DGVAccountingRightsList_CellClick;
            DGVAccountingRightsList.CellEndEdit += DGVAccountingRightsList_CellEndEdit;
            DGVInventoryRightsList.CellClick += DGVInventoryRightsList_CellClick;
            DGVInventoryRightsList.CellEndEdit += DGVInventoryRightsList_CellEndEdit;
            DGVCustomersRightsList.CellClick += DGVCustomersRightsList_CellClick;
            DGVCustomersRightsList.CellEndEdit += DGVCustomersRightsList_CellEndEdit;
            DGVVendorsRightsList.CellClick += DGVVendorRightsList_CellClick;
            DGVVendorsRightsList.CellEndEdit += DGVVendorRightsList_CellEndEdit;
            DGVSystemRightsList.CellClick += DGVSystemRightsList_CellClick;
            DGVSystemRightsList.CellEndEdit += DGVSystemRightsList_CellEndEdit;

            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;
            btnCheckAll.Click += btnCheckAll_Click;
            btnUnCheckAll.Click += btnUnCheckAll_Click;

            //BindingControls();
        }

        private void frmUserRights_Load(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dt = new DataTable();
            dt = dbClass.obj.FillEmployeeList(dt);
            bindingSource.DataSource = dt;
            DGVEmployeeList.SetSource(bindingSource);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            StaticInfo.LoadToControl("AppControls.ctrEmployee", "Employee Details", 0);
        }
        void DGVEmployeeList_TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtRights = new DataTable();
            BindingSource bindingSource1 = new BindingSource();
            BindingSource bindingSource2 = new BindingSource();
            BindingSource bindingSource3 = new BindingSource();
            BindingSource bindingSource4 = new BindingSource();
            BindingSource bindingSource5 = new BindingSource();
            BindingSource bindingSource6 = new BindingSource();
            BindingSource bindingSource7 = new BindingSource();

            DataRowView curRow = (DataRowView)((BindingSource)DGVEmployeeList.TDataGridView.DataSource).Current;

            this.EmployeeID = Convert.ToInt32(curRow["ID"]);

            dtRights = dbClass.obj.getUserRights(this.EmployeeID);

            DataView dv = new DataView(dtRights);
            dv.RowFilter = "ModuleName='WorkOrders'";

            DataView dv2 = new DataView(dtRights);
            dv2.RowFilter = "ModuleName='Invoicing'";

            DataView dv3 = new DataView(dtRights);
            dv3.RowFilter = "ModuleName='Accounting'";

            DataView dv4 = new DataView(dtRights);
            dv4.RowFilter = "ModuleName='Inventory'";

            DataView dv5 = new DataView(dtRights);
            dv5.RowFilter = "ModuleName='Customers'";

            DataView dv6 = new DataView(dtRights);
            dv6.RowFilter = "ModuleName='Vendors'";

            DataView dv7 = new DataView(dtRights);
            dv7.RowFilter = "ModuleName='System'";

            bindingSource1.DataSource = dv.ToTable();
            bindingSource2.DataSource = dv2.ToTable();
            bindingSource3.DataSource = dv3.ToTable();
            bindingSource4.DataSource = dv4.ToTable();
            bindingSource5.DataSource = dv5.ToTable();
            bindingSource6.DataSource = dv6.ToTable();
            bindingSource7.DataSource = dv7.ToTable();

            DGVWorkOrdersRightsList.DataSource = bindingSource1;
            DGVInvoicingRightsList.DataSource = bindingSource2;
            DGVAccountingRightsList.DataSource = bindingSource3;
            DGVInventoryRightsList.DataSource = bindingSource4;
            DGVCustomersRightsList.DataSource = bindingSource5;
            DGVVendorsRightsList.DataSource = bindingSource6;
            DGVSystemRightsList.DataSource = bindingSource7;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MenuID", typeof(Int32));
            dt.Columns.Add("EmployeeID", typeof(Int32));
            dt.Columns.Add("CanView", typeof(Boolean));

            foreach (DataGridViewRow row in DGVWorkOrdersRightsList.Rows)
            {
                if (row.Cells["WorkOrdersCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["WorkOrdersCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["WorkOrdersID"].Value;
                        dr["CanView"] = row.Cells["WorkOrdersCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVInvoicingRightsList.Rows)
            {
                if (row.Cells["InvoicingCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["InvoicingCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["InvoicingID"].Value;
                        dr["CanView"] = row.Cells["InvoicingCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVAccountingRightsList.Rows)
            {
                if (row.Cells["AccountingCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["AccountingCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["AccountingID"].Value;
                        dr["CanView"] = row.Cells["AccountingCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVInventoryRightsList.Rows)
            {
                if (row.Cells["InventoryCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["InventoryCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["InventoryID"].Value;
                        dr["CanView"] = row.Cells["InventoryCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVCustomersRightsList.Rows)
            {
                if (row.Cells["CustomersCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["CustomersCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["CustomersID"].Value;
                        dr["CanView"] = row.Cells["CustomersCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVVendorsRightsList.Rows)
            {
                if (row.Cells["VendorsCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["VendorsCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["VendorsID"].Value;
                        dr["CanView"] = row.Cells["VendorsCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            foreach (DataGridViewRow row in DGVSystemRightsList.Rows)
            {
                if (row.Cells["SystemCanView"].Value != DBNull.Value)
                    if (Convert.ToBoolean(row.Cells["SystemCanView"].Value))
                    {
                        DataRow dr = dt.NewRow();
                        dr["EmployeeID"] = this.EmployeeID;
                        dr["MenuID"] = row.Cells["SystemID"].Value;
                        dr["CanView"] = row.Cells["SystemCanView"].Value;
                        dt.Rows.Add(dr);
                    }
            }
            if (dt.Rows.Count > 0)
                dbClass.obj.AddUserRights(dt);
            else
                dbClass.obj.DeleteUserRights(this.EmployeeID);

            TabsCtrRights.SelectedIndex = 0;

            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();

            frmMessage = new frmOperationMessage();
            frmMessage.BringToFront();
            frmMessage.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmMessage.ShowDialog();

            //xMessageBox.Show("Data Saved Successfully...");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            frmMessage.Dispose();
            timer1.Enabled = false;
            timer1.Stop();
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGVWorkOrdersRightsList.Rows)
            {
                row.Cells["WorkOrdersCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVInvoicingRightsList.Rows)
            {
                row.Cells["InvoicingCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVAccountingRightsList.Rows)
            {
                row.Cells["AccountingCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVInventoryRightsList.Rows)
            {
                row.Cells["InventoryCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVCustomersRightsList.Rows)
            {
                row.Cells["CustomersCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVVendorsRightsList.Rows)
            {
                row.Cells["VendorsCanView"].Value = true;
            }
            foreach (DataGridViewRow row in DGVSystemRightsList.Rows)
            {
                row.Cells["SystemCanView"].Value = true;
            }
        }
        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGVWorkOrdersRightsList.Rows)
            {
                row.Cells["WorkOrdersCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVInvoicingRightsList.Rows)
            {
                row.Cells["InvoicingCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVAccountingRightsList.Rows)
            {
                row.Cells["AccountingCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVInventoryRightsList.Rows)
            {
                row.Cells["InventoryCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVCustomersRightsList.Rows)
            {
                row.Cells["CustomersCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVVendorsRightsList.Rows)
            {
                row.Cells["VendorsCanView"].Value = false;
            }
            foreach (DataGridViewRow row in DGVSystemRightsList.Rows)
            {
                row.Cells["SystemCanView"].Value = false;
            }
        }

        //void BindingControls()
        //{
        //    ItemBS.DataSource = objDataSet.Tables["Employee"];
        //}        
        void DGVWorkOrdersRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string columnType = "";
                //bool CanView = false;
                //DataRowView DRV = (DataRowView)((BindingSource)DGVSaleRightsList.DataSource).Current;
                //int index = e.ColumnIndex;
                //if (index == -1)
                //    columnType = "RowHeader";
                //else
                //{
                //    try
                //    {
                //        columnType = DGVSaleRightsList.Columns[index].Tag.ToString();
                //    }
                //    catch { columnType = DGVSaleRightsList.Columns[index].Name.ToString(); }
                //}
                //switch (columnType)
                //{
                //    case "CanView":
                //        break;
                //    default:
                //        break;
                //}
                DGVWorkOrdersRightsList.BeginEdit(true);
                DGVWorkOrdersRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVWorkOrdersRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVWorkOrdersRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVWorkOrdersRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVInvoicingRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVInvoicingRightsList.BeginEdit(true);
                DGVInvoicingRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVInvoicingRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVInvoicingRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVInvoicingRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVAccountingRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVAccountingRightsList.BeginEdit(true);
                DGVAccountingRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVAccountingRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVAccountingRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVAccountingRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVInventoryRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVInventoryRightsList.BeginEdit(true);
                DGVInventoryRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVInventoryRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVInventoryRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVInventoryRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVCustomersRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVCustomersRightsList.BeginEdit(true);
                DGVCustomersRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVCustomersRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVCustomersRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVCustomersRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVVendorRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVVendorsRightsList.BeginEdit(true);
                DGVVendorsRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVVendorRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVVendorsRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVVendorsRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }
        void DGVSystemRightsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVSystemRightsList.BeginEdit(true);
                DGVSystemRightsList.EndEdit();
            }
            catch (Exception ex) { }
        }
        void DGVSystemRightsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DGVColumnName = DGVSystemRightsList.Columns[e.ColumnIndex].DataPropertyName;
            DataRowView curRow = (DataRowView)((BindingSource)DGVSystemRightsList.DataSource).Current;
            if (DGVColumnName == "CanView")
            {
                if (curRow["CanView"] != DBNull.Value)
                    if (Convert.ToBoolean(curRow["CanView"]))
                        curRow["CanView"] = false;
                    else
                        curRow["CanView"] = true;
                else
                    curRow["CanView"] = true;
            }
        }

        private void btnSaleRep_Click(object sender, EventArgs e)
        {
            if (this.EmployeeID != 0)
            {
                if (xMessageBox.Show("Do you want to add Sales Rep....?", "Sale Post..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Boolean Status = dbClass.obj.UpdateSaleRepRights(this.EmployeeID);
                    if (Status == true)
                    {
                        xMessageBox.Show("This Employee is updated as Sales Rep ..");
                    }
                }
            }
        }
    }
}
