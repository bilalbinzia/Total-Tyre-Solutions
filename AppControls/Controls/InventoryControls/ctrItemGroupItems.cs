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
using System32;

namespace AppControls
{
    public partial class ctrItemGroupItems : UserControl
    {
        int iID = 0;
        private ControlLibrary.MessageBox xMessageBox = null;
        private BindingSource bindingSource;
        //MainDataSet ds;
        DataTable dt;
        private frmOperationMessage frmMessage;

        public ctrItemGroupItems()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrItemGroupItems(int id)
        {
            InitializeComponent();
            InitializeComponent1();
            this.iID = id;
        }
        void InitializeComponent1()
        {
            bindingSource = new BindingSource();
            xMessageBox = new ControlLibrary.MessageBox();
            dt = new DataTable();
            this.Load += ctrItemGroupItems_Load;
            btnAddItem.Click += btnAddItem_Click;
            btnSaveClose.Click += btnSaveClose_Click;
            DGVItemGroupItems.CellClick += new DataGridViewCellEventHandler(this.DGVItemGroupItems_CellClick);
        }
        void ctrItemGroupItems_Load(object sender, EventArgs e)
        {
            if (this.iID > 0)
            {
                dt = dbClass.obj.getItemGroupItemsByID(dt, this.iID);
                bindingSource.DataSource = dt;
                DGVItemGroupItems.AutoGenerateColumns = true;
                DGVItemGroupItems.DataSource = bindingSource;
                DGVItemGroupItems.Columns["ID"].Visible = false;
                DGVItemGroupItems.Columns["ItemGroupID"].Visible = false;

                //DGVItemGroupItems.Columns["ItemSize"].Selected = true;
                //DGVItemGroupItems.Columns["Active"].Visible = false;
                //DGVItemGroupItems.Columns["AddDate"].Visible = false;
                //DGVItemGroupItems.Columns["AddUserID"].Visible = false;
                //DGVItemGroupItems.Columns["ModifyUserID"].Visible = false;
                //DGVItemGroupItems.Columns["ModifyDate"].Visible = false;
                //DGVItemGroupItems.Columns["Comments"].Visible = false;
                //DGVItemGroupItems.Columns["IsLocked"].Visible = false;
                //DGVItemGroupItems.Columns["DocNo"].Visible = false;
                //DGVItemGroupItems.Columns["Remarks"].Visible = false;
                //DGVItemGroupItems.Columns["CoFinEndYear"].Visible = false;
                //DGVItemGroupItems.Columns["TrnsVrNo"].Visible = false;
                //DGVItemGroupItems.Columns["TrnsJrRef"].Visible = false;
            }
        }
        void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveItemGroupItems();
        }
        void SaveItemGroupItems()
        {
            if (this.iID > 0)
            {
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.RowState == DataRowState.Added)
                        {
                            dbClass.obj.UpdateItemGroupID(Convert.ToInt32(row["ID"]), Convert.ToInt32(row["ItemGroupID"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    xMessageBox.Show(ex.Message);
                }
            }
        }

        void btnAddItem_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objList = new ctrItemListForGrid();
            objList.ObjectSelected += objList_ItemGroupItems;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select Item ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void objList_ItemGroupItems(object sender, DataRow dataRow, int packageID = 0)
        {
            try
            {
                if (dataRow != null)
                {
                    bool IsFound = false;
                    if (DGVItemGroupItems.Rows.Count > 1)
                    {
                        foreach (DataGridViewRow row in DGVItemGroupItems.Rows)
                        {
                            try
                            {
                                int gridItemID = Convert.ToInt32(row.Cells["ID"].Value);
                                int xItemID = Convert.ToInt32(dataRow["ID"]);
                                if (gridItemID == xItemID)
                                    IsFound = true;
                            }
                            catch (Exception ex)
                            {
                                xMessageBox.Show(ex.Message);
                            }
                        }
                    }
                    if (!IsFound)
                    {
                        DataRowView newRow = (DataRowView)((BindingSource)(((System.Windows.Forms.DataGridView)(DGVItemGroupItems)).DataSource)).AddNew();
                        
                        newRow.BeginEdit();
                        newRow["ID"] = dataRow["ID"];
                        newRow["ItemGroupID"] = this.iID;
                        newRow["ItemSize"] = dataRow["ItemSize"];
                        newRow["Catalog"] = dataRow["Catalog"];
                        newRow["Name"] = dataRow["Name"];
                        //newRow["Type"] = dataRow["ItemType"];

                        //newRow["Active"] = true;
                        //newRow["AddDate"] = DateTime.Now;
                        //newRow["AddUserID"] = StaticInfo.userid;
                        //newRow["Comments"] = "Add Items in ItemGroupItems";
                        //newRow["IsLocked"] = true;

                        newRow.EndEdit();

                    }
                }
            }
            catch(Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
        private void DGVItemGroupItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)bindingSource.Current;
                int index = Convert.ToInt32(this.DGVItemGroupItems.CurrentCell.ColumnIndex);
                string ColumnName = this.DGVItemGroupItems.Columns[index].Name.ToString();
                switch (ColumnName)
                {
                    case "Delete":
                        if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataRow drDelete = drv.Row;
                            dbClass.obj.UpdateItemGroupID2(Convert.ToInt32(drDelete["ID"]));
                            dt.Rows.Remove(drDelete);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }

        }
        void DeleteGridRow()
        {
            try
            {
                if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bindingSource.RemoveCurrent();
                    bindingSource.EndEdit();
                }                
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }

        private void DGVItemGroupItems_Click(object sender, EventArgs e)
        {
            string Count = DGVItemGroupItems.SelectedRows.ToString();
        }
    }
}
