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

namespace AppControls
{
    public partial class ctrItemGroup : BaseControl
    {
        bool IsSalesAcctID = false;
        bool IsAssetAcctID = false;
        bool IsCGSAcctID = false;

        public ctrItemGroup()
        {
            InitializeComponent();

            this.Load += ctrItemGroup_Load;
            btnGroupItems.Click += btnGroupItems_Click;

            btnAssetAcct.Click += btnAssetAcct_Click;
            btnSalesAcct.Click += btnSalesAcct_Click;
            btnCGSAcct.Click += btnCGSAcct_Click;

            btnAssetAcctClear.Click += btnAssetAcctClear_Click;
            btnSalesAcctClear.Click += btnSalesAcctClear_Click;
            btnCGSAcctClear.Click += btnCGSAcctClear_Click;
        }

        void btnCGSAcctClear_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();            
            curRow["CGSAcctID"] = DBNull.Value;
            curRow["CGSAcct"] = DBNull.Value;
            curRow.EndEdit();    
        }

        void btnSalesAcctClear_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["SalesAcctID"] = DBNull.Value;
            curRow["SalesAcct"] = DBNull.Value;
            curRow.EndEdit();
        }

        void btnAssetAcctClear_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["AssetAcctID"] = DBNull.Value;
            curRow["AssetAcct"] = DBNull.Value;
            curRow.EndEdit();
        }
        
        void btnCGSAcct_Click(object sender, EventArgs e)
        {
            IsAssetAcctID = false; IsSalesAcctID = false; IsCGSAcctID = true;
            int AccID = dbClass.obj.getAccID("Cost of Goods Sold");
            LoadAccountsList(AccID);
        }

        void btnAssetAcct_Click(object sender, EventArgs e)
        {
            IsAssetAcctID = true; IsSalesAcctID = false; IsCGSAcctID = false;
            int AccID = dbClass.obj.getAccID("Other Current Asset");
            LoadAccountsList(AccID);
        }

        void ctrItemGroup_Load(object sender, EventArgs e)
        {
            this.objBindingSource.DataSource = dbClass.obj.FillItemGroup(this.objDataSet.Tables["ItemGroup"]);

            txtAssetAcctID.BindControl(this.objBindingSource, txtAssetAcctID.xBindingProperty);
            txtSalesAcctID.BindControl(this.objBindingSource, txtSalesAcctID.xBindingProperty);
            txtCGSAcctID.BindControl(this.objBindingSource, txtCGSAcctID.xBindingProperty);

            this.objBindingSource.MoveLast();
        }

        void btnSalesAcct_Click(object sender, EventArgs e)
        {
            IsAssetAcctID = false; IsSalesAcctID = true; IsCGSAcctID = false;            
            int AccID = dbClass.obj.getAccID("Income");
            LoadAccountsList(AccID);
        }
        void LoadAccountsList(int AccID)
        {            
            ctrAccountList objList = new ctrAccountList(AccID);
            objList.AccountSelected += objList_AccountSelected;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Select an Account ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void objList_AccountSelected(object sender, DataRow dataRow)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            if (IsAssetAcctID)
            {
                curRow["AssetAcctID"] = Convert.ToInt32(dataRow["ID"]);
                curRow["AssetAcct"] = dbClass.obj.getAccountTitle(Convert.ToInt32(dataRow["ID"]));
            }
            if (IsSalesAcctID)
            {
                curRow["SalesAcctID"] = Convert.ToInt32(dataRow["ID"]);
                curRow["SalesAcct"] = dbClass.obj.getAccountTitle(Convert.ToInt32(dataRow["ID"]));
            }            
            if (IsCGSAcctID)
            {
                curRow["CGSAcctID"] = Convert.ToInt32(dataRow["ID"]);
                curRow["CGSAcct"] = dbClass.obj.getAccountTitle(Convert.ToInt32(dataRow["ID"]));
            }
            curRow.EndEdit();
                        
        }

        void btnGroupItems_Click(object sender, EventArgs e)
        {
            this.objBindingSource.EndEdit();
            dbClass.obj.Update((DataTable)this.objBindingSource.DataSource);

            int ID = 0;
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (curRow["ID"] != DBNull.Value)
                ID = Convert.ToInt32(curRow["ID"]);
            if (ID > 0)
            {
                ctrItemGroupItems objList = new ctrItemGroupItems(ID);
                //----------------------------------------------------------------------//
                frmCtr frmCtr = new frmCtr("Items for Item-Group ...");                
                frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
                frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmCtr.frmPnl.Controls.Add(objList);
                frmCtr.BringToFront();
                frmCtr.ShowDialog();
            }
        }

        

    }
}
