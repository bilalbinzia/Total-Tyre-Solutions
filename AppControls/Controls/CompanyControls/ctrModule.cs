using DBModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace AppControls
{
    public partial class ctrModule : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = null;
        int ModuleID = 0;

        public ctrModule()
        {
            xMessageBox = new ControlLibrary.MessageBox();
            InitializeComponent();
            DGV_Module.TDataGridView.CellClick += DGVModule_TDataGridView_CellClick;
        }
        private void DGVModule_TDataGridView_CellClick(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGV_Module.TDataGridView.DataSource).Current;
            ModuleID = Convert.ToInt32(curRow["ID"]);
            txtModuleName.Text = curRow["ModuleName"].ToString();
            CB_Active.Checked = Convert.ToBoolean(curRow["Active"]);
        }
        private void ctrModule_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddModule_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            string ModuleName = txtModuleName.Text;
            bool Active = CB_Active.Checked;
            if (string.IsNullOrWhiteSpace(ModuleName))
            {
                xMessageBox.Show("Fill the fields and then press 'Add New' Button to add module.");
            }
            else
            {
                int result = dbClass.obj.InsertModule(ModuleName, Active);
                ClearControl();
                RefreshData();
                xMessageBox.Show(result+" Modules added");
            }
        }
        private void ClearControl()
        {
            txtModuleName.Text = "";
            CB_Active.Checked=false;
        }
        private void RefreshData()
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dt = new DataTable();
            dt = dbClass.obj.GetModules();
            bindingSource.DataSource = dt;
            DGV_Module.SetSource(bindingSource);
        }

        private void btnUpdateModule_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            if (ModuleID <= 0)
            {
                xMessageBox.Show("Select a Record from Below to update");
            }
            else
            {
                string ModuleName = txtModuleName.Text;
                bool Active = CB_Active.Checked;
                if (string.IsNullOrWhiteSpace(ModuleName))
                {
                    xMessageBox.Show("Module Name can not be empty");
                }
                else
                {
                    int result = dbClass.obj.UpdateModule(ModuleName, Active,ModuleID);
                    ClearControl();
                    RefreshData();
                    xMessageBox.Show(result + " Modules Updated");
                }
            }
        }

        private void btnDelete_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            if (ModuleID <= 0)
            {
                xMessageBox.Show("Select a Record from Below to delete");
            }
            else
            {
                int result = dbClass.obj.DeleteModule(ModuleID);
                ClearControl();
                RefreshData();
                xMessageBox.Show(result + " Modules Deleted");
            }
        }

        private void btnClearScreen_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            ClearControl();
        }

        private void btnRefresh_ClickButtonArea(object Sender, MouseEventArgs e)
        {
            RefreshData();
        }
    }
}
