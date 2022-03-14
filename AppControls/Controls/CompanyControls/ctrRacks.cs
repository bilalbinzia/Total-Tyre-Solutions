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
    public partial class ctrRacks : BaseControl
    {
        //BindingSource WarehouseStoreBS;
        dbClass objdbClass;
        int CompanyID = 0;
        int WarehouseID = 0;
        int StoreID = 0;
        public ctrRacks()
        {
            InitializeComponent();
            //WarehouseStoreBS = new BindingSource();
            objdbClass = new dbClass();
            this.Load += ctrRacks_Load;            
            
        }
        public ctrRacks(int CompanyID, int WarehouseID)
        {
            InitializeComponent();
            //WarehouseStoreBS = new BindingSource();
            objdbClass = new dbClass();

            this.CompanyID = CompanyID;
            this.WarehouseID = WarehouseID;

            this.Load += ctrRacks_Load;
        }
        public ctrRacks(int CompanyID, int WarehouseID, int StoreID)
        {
            InitializeComponent();
            //WarehouseStoreBS = new BindingSource();
            objdbClass = new dbClass();
            this.CompanyID = CompanyID;
            this.WarehouseID = WarehouseID;
            this.StoreID = StoreID;

            this.Load += ctrRacks_Load;
        }
        
        void ctrRacks_Load(object sender, EventArgs e)
        {
            if (StaticInfo.userLevel <= 2)
            {
                this.btnBNMoveFirstItem.Visible = true;
                this.btnBNMovePreviousItem.Visible = true;
                this.BNSeparator.Visible = true;
                this.BNPositionItem.Visible = true;
                this.BNCountItem.Visible = true;
                this.BNSeparator1.Visible = true;
                this.btnBNMoveNextItem.Visible = true;
                this.btnBNMoveLastItem.Visible = true;
                this.BNSeparator2.Visible = true;
                                
            }

            if (this.StoreID <= 0)
            {
                lblStore.Visible = false;
                cboStore.Visible = false;
            }

            if (this.StoreID > 0)
            {
                    //--WarehouseStore query
                objdbClass.FillWarehouseRacksList(objDataSet.Tables["WarehouseStoreRack"], this.StoreID);
            }
            else
            {
                //--Warehouse query
                objdbClass.FillStoreRacksList(objDataSet.Tables["WarehouseStoreRack"], this.WarehouseID);
            }

        }
        

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
            base.bindingNavigatorAddNewItem_Click(sender, e);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["CompanyID"] = CompanyID;
            curRow["WarehouseID"] = WarehouseID;

            if (StoreID > 0)
            {
                curRow["StoreID"] = StoreID;                
                cboStore.DataSource = dbClass.obj.FillAll(objDataSet.Tables["WarehouseStore"], "ID");                                
            }
            else
                curRow["StoreID"] = DBNull.Value;

            curRow["Code"] = "";
            curRow.EndEdit();
        }

    }
}
