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
    public partial class ctrVehicle : BaseControl
    {
        int CustID = 0;
        int vehicleID = 0;
        string Mode = "";
        public int VehID;
        public ctrVehicle()
        {
            InitializeComponent();
                        
        }
        public ctrVehicle(int cusID, string mode)
        {
            InitializeComponent();

            this.CustID = cusID;
            this.Mode = mode;
            this.Load += ctrVehicle_Load;
        }
        public ctrVehicle(int vehicleID, int cusID, string mode)
        {
            InitializeComponent();

            this.CustID = cusID;
            this.vehicleID = vehicleID;
            this.Mode = mode;
            this.Load += ctrVehicle_Load;
        }
        void ctrVehicle_Load(object sender, EventArgs e)
        {
            if (this.Mode == "Add")
            {
                this.objBindingSource.AddNew();
                this.bindingNavigatorAddNewItem_Click(sender, e);
            }
            if (this.Mode == "Edit")
            {
                int index = this.objBindingSource.Find("ID", this.vehicleID);
                if (index > 0)
                    this.objBindingSource.Position = index;

                base.bindingNavigatorEditItem_Click(sender, e);

            }
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            if (this.CustID > 0)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["CustomerID"] = this.CustID;
                curRow["IsOwner"] = true;
                curRow["RegDate"] = DateTime.Now;
                curRow.EndEdit();
            }
            //------------------------------------
            base.DataNavigation();
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorSaveItem_Click(sender, e);
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            this.VehID = Convert.ToInt32(curRow["ID"]);
        }


    }
}
