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
using System32;
using DBModule;

namespace AppControls
{
    public partial class ctrMechanicTrack : BaseControl
    {
        BindingSource MechanicBS;
        public ctrMechanicTrack()
        {
            InitializeComponent();
            MechanicBS = new BindingSource();
            
            this.Load += ctrMechanicTrack_Load;
            //btnBNAddItem.Click += btnBNAddItem_Click;
           
            DGVMechanics.TDataGridView.CellClick += TDataGridView_CellClick;
            DGVMechanics.TDataGridView.MouseDoubleClick += TDataGridView_MouseDoubleClick;

            

            LoadCmbMechanics();
            txtBoxCreatedBy.Text = "";
        }

        private void LoadCmbMechanics()
        {
            DataTable dt = new DataTable();
            string Qry = "Select ID,Name from Employee where IsMech=1";

            comboBox2.DataSource = dbClass.obj.FillByQry(dt,Qry);
            comboBox2.DisplayMember = dt.Columns["Name"].ToString();
            comboBox2.ValueMember = dt.Columns["ID"].ToString();

            comboBox3.DataSource = dbClass.obj.FillByQry(dt, Qry);
            comboBox3.DisplayMember = dt.Columns["Name"].ToString();
            comboBox3.ValueMember = dt.Columns["ID"].ToString();

            comboBox4.DataSource = dbClass.obj.FillByQry(dt, Qry);
            comboBox4.DisplayMember = dt.Columns["Name"].ToString();
            comboBox4.ValueMember = dt.Columns["ID"].ToString();
        }                     

        private void TDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void ctrMechanicTrack_Load(object sender, EventArgs e)
        {   
            LoadAllWorkOrders();
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            //-------------------------------                        
            objBindingSource.AddNew();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            
            curRow["AddDate"] = DateTime.Now;
            curRow["RegDate"] = DateTime.Now;
            //curRow["Code"] = StaticInfo.;
            curRow["Name"] = StaticInfo.EmployeeName;
            //curRow["Address"] = StaticInfo.CompanyAddress;
            curRow["ID"] = StaticInfo.CompanyCode;
            //curRow["ContactName"] = StaticInfo.CompanyPhone;
            
            curRow.EndEdit();

            this.DataNavigation();
        }
        protected override void DataNavigation()
        {
            DataTable datatable = new DataTable();
            base.DataNavigation();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow != null)
            {
                DataTable dt = dbClass.obj.FillEmployeeList(datatable);
                MechanicBS.DataSource = dt;
                DGVMechanics.SetSource(MechanicBS);
            }
        }
        void LoadAllWorkOrders()
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select ID, Name, RegDate, LaborCommPer, PartsCommPer, CommisionBaseOn, Wages, IsHolidayPaid, MondayHrs, TuesdayHrs, WednesdayHrs, ThursdayHrs, FridayHrs, SaturdayHrs  from Employee where IsMech = 1 Order By AddDate DESC";
            DataTable dt = dbClass.obj.FillByQry(dataTable, Qry);
            MechanicBS.DataSource = dt;
            DGVMechanics.SetSource(MechanicBS);
        }
    }
}
