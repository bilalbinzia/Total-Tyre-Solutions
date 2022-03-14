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

namespace AppControls
{
    public partial class ctrMenu : UserControl
    {
        int MenuID = 0;
        public ctrMenu()
        {
            InitializeComponent();
            DGV_Menu.TDataGridView.CellClick += DGV_Menu_TDataGridView_CellClick;
        }
        private void DGV_Menu_TDataGridView_CellClick(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)((BindingSource)DGV_Menu.TDataGridView.DataSource).Current;
            MenuID = Convert.ToInt32(curRow["ID"]);
            CMB_ModuleList.SelectedValue = Convert.ToInt32(curRow["ModuleID"]);
            txtCode.Text = curRow["Code"].ToString();
            txtName.Text = curRow["FriendlyName"].ToString();
            txtNotes.Text = curRow["Notes"].ToString();
            CB_Active.Checked = Convert.ToBoolean(curRow["Active"]);
        }
        private void ctrMenu_Load(object sender, EventArgs e)
        {
            RefreshData(0);
            LoadModuleComboBox();
        }
        private void LoadModuleComboBox()
        {
            DataTable dt = new DataTable();
            dt = dbClass.obj.GetModules();
            CMB_ModuleList.DisplayMember = "ModuleName";
            CMB_ModuleList.ValueMember = "ID";
            CMB_ModuleList.DataSource = dt;
        }
        private void RefreshData(int ModuleID)
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dt = new DataTable();
            if (ModuleID <= 0)
            {
                dt = dbClass.obj.GetMenu();
            }
            else
            {
                dt = dbClass.obj.GetMenu(ModuleID);
            }
            bindingSource.DataSource = dt;
            DGV_Menu.SetSource(bindingSource);
            DGV_Menu.TDataGridView.Columns["ModuleID"].Visible = false;
            DGV_Menu.TDataGridView.Columns["FriendlyName"].HeaderText = "Name";
        }

        private void CMB_ModuleList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CMB_ModuleList.SelectedValue != null)
            {
                int SelectedModuleID = (int)CMB_ModuleList.SelectedValue;
                RefreshData(SelectedModuleID);
            }
        }

    }
}
