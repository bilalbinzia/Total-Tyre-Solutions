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
    public partial class ctrChartofAccounts : BaseControl
    {
        int AccID = 0;
        int AccLevel = 0;
        int AccTypeID = 0;
        bool isError = false;

        public ctrChartofAccounts()
        {
            InitializeComponent();

            this.Load += ctrChartofAccounts_Load;
            this.txtBoxAccID.Leave += new System.EventHandler(this.txtBoxAccID_Leave);
            this.txtBoxAccID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxAccID_KeyDown);
            this.txtBoxAccID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxAccID_KeyPress);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }

        void ctrChartofAccounts_Load(object sender, EventArgs e)
        {
            this.LoadTreeView();
        }
        public override void btnBNRefresh_Click(object sender, EventArgs e)
        {
            dbClass.obj.Fill(objDataSet.Tables["Account"]);
            this.LoadTreeView();
        }
        private void LoadTreeView()
        {
            try
            {
                treeView1.Nodes.Clear();

                DataRow[] datarows = (((DataTable)this.objBindingSource.DataSource).Select("[AccLevel] = 0"));
                DataTable dt = (DataTable)datarows.CopyToDataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode root = new TreeNode(dr["AccName"].ToString());
                    root.Name = dr["AccID"].ToString();
                    root.ToolTipText = dr["AccLevel"].ToString();
                    root.Tag = dr["AccTypeID"].ToString();
                    CreateNode(root);
                    treeView1.Nodes.Add(root);
                }
            }
            catch (Exception ex)
            { }
        }
        void CreateNode(TreeNode node)
        {
            try
            {
                DataRow[] datarows = (((DataTable)this.objBindingSource.DataSource).Select("[AccTypeID] = " + node.Name));
                if (datarows.Count() == 0)
                    return;
                DataTable dt = (DataTable)datarows.CopyToDataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode root = new TreeNode(dr["AccName"].ToString());
                    root.Name = dr["AccID"].ToString();
                    root.ToolTipText = dr["AccLevel"].ToString();
                    root.Tag = dr["AccTypeID"].ToString();
                    node.Nodes.Add(root);
                    //CreateNode(root);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        void UpdateTreeView()
        {
            try
            {
                dbClass.obj.Fill(objDataSet.Tables["Account"]);
                this.LoadTreeView();

                //if (frmStatus == currentStatus.Add)
                //{
                //    TreeNode newNode = new TreeNode(this.txtBoxAccName.Text.Trim());
                //    newNode.Name = this.txtBoxAccID.Text.Trim();
                //    newNode.ToolTipText = Convert.ToString(AccLevel + 1);
                //    newNode.Tag = this.txtBoxAccTypeID.Text.Trim();
                //    treeView1.SelectedNode.Nodes.Add(newNode);
                //}
                //if (frmStatus == currentStatus.Edit)
                //{
                //    treeView1.SelectedNode.Text = this.txtBoxAccName.Text.Trim();
                //}
            }
            catch { }
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if ((AccID >= 0) && (AccLevel >= 0) && (AccLevel < 3) && (AccTypeID >= 0))
                //{
                base.bindingNavigatorAddNewItem_Click(sender, e);
                this.AddNewItem();
                
                this.DataNavigation();
                isError = false;

                txtBoxAccID.Enabled = true;
                txtBoxAccID.ReadOnly = false;

                txtBoxAccNo.Enabled = true;
                txtBoxAccNo.ReadOnly = false;

                txtBoxAccName.Enabled = true;
                txtBoxAccName.ReadOnly = false;

                txtBoxAccName.Focus();
                this.treeView1.Enabled = false;
                //}
            }
            catch { }
        }
        void AddNewItem()
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["AccID"] = dbClass.obj.getAccID();
            //curRow["AccName"] = System.DBNull.Value;
            curRow["AccTypeID"] = AccID;
            curRow["AccLevel"] = AccLevel + 1;

            curRow["RelatedToPNL"] = false;
            curRow["TransferAllowed"] = false;
            curRow["CannotDelete"] = false;
            curRow["CannotDirectEntry"] = false;
            //curRow["Remarks"] = System.DBNull.Value;
            curRow["CoFinEndYear"] = StaticInfo.CoFinEndYear;
            curRow["TrnsVrNo"] = System.DBNull.Value;
            curRow["TrnsJrRef"] = System.DBNull.Value;
            curRow["AddDate"] = DateTime.Now;
            curRow["AddUserID"] = StaticInfo.userid;

            curRow["IsLocked"] = false;
            curRow.EndEdit();
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            try
            {
                base.bindingNavigatorEditItem_Click(sender, e);

                txtBoxAccID.Enabled = true;
                txtBoxAccID.ReadOnly = false;

                txtBoxAccNo.Enabled = true;
                txtBoxAccNo.ReadOnly = false;

                txtBoxAccName.Enabled = true;
                txtBoxAccName.ReadOnly = false;

                isError = false;
                this.treeView1.Enabled = false;
            }
            catch { }
        }
        protected override void bindingNavigatorDelete_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)this.objBindingSource.Current;
            //if (!Convert.ToBoolean(curRow["CannotDelete"]))
            //{
            int AcID = Convert.ToInt32(curRow["ID"]);
            DataTable dt = dbClass.obj.IsAccExist(AcID);
            if (dt.Rows.Count > 1)
            {
                string messageStr = "";
                foreach (DataRow row in dt.Rows)
                    messageStr += "\n This Account exist in " + Convert.ToString(row.ItemArray[0]);

                xMessageBox.Show(messageStr, "Can not be Deleted this Account...");
            }
            else
            {
                int AccID = Convert.ToInt32(curRow["AccID"]);
                if (dbClass.obj.isChildExist(AccID))
                {
                    xMessageBox.Show("First Remove Child Node...!", "Can not be Deleted this Account...");
                    return;
                }
                else
                {
                    base.bindingNavigatorDelete_Click(sender, e);
                    if (base.isDeleted)
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                }
            }
            //}
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isError)
                {                    
                    base.bindingNavigatorSaveItem_Click(sender, e);
                    this.UpdateTreeView();
                    AccID = 0; AccLevel = 0; AccTypeID = 0;
                    this.treeView1.Enabled = true;
                }
            }
            catch { }
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorCancelItem_Click(sender, e);
            this.treeView1.Enabled = true;
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode root = e.Node;
                this.objBindingSource.Position = ((BindingSource)this.objBindingSource).Find("AccID", root.Name);
                //--------------------------
                AccID = Convert.ToInt32(root.Name);
                AccLevel = Convert.ToInt32(root.ToolTipText);
                AccTypeID = Convert.ToInt32(root.Tag);

                if (AccID > 0)
                {
                    txtBoxAccNo.Text = AccID.ToString();
                    txtBoxAccNo.Enabled = false;
                }
                else
                {
                    txtBoxAccNo.Text = AccID.ToString();
                    txtBoxAccNo.Enabled = false;
                }
            }
            catch { }
        }
        private void txtBoxAccID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != (char)8)
            //{
            //    int tmp1 = AccID.ToString().Length;
            //    int tmp2 = txtBoxAccID.Text.Trim().Length;
            //    if (((tmp1 == 1) && (tmp2 == 2)) || ((tmp1 == 2) && (tmp2 == 4)) || ((tmp1 == 4) && (tmp2 == 7)))
            //        e.Handled = true;
            //    else
            //        e.Handled = false;
            //}
            //else
            //{
            //    int tmp1 = Convert.ToInt32(this.txtBoxAccID.Text.Trim()).ToString().Length;
            //    int tmp2 = AccID.ToString().Length;
            //    int tmp3 = this.txtBoxAccID.SelectedText.Length;
            //    if (tmp3 <= 0)
            //    {
            //        if (tmp1 > tmp2)
            //            e.Handled = false;
            //        else
            //            e.Handled = true;
            //    }
            //    else
            //        e.Handled = true;
            //}
        }
        private void txtBoxAccID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    try
                    {
                        DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                        if (dbClass.obj.IsAccIDExist(Convert.ToInt32(this.txtBoxAccID.Text.Trim()), Convert.ToInt32(curRow["ID"])))
                        { errorProvider1.SetError(this.txtBoxAccID, "Account ID Already Exist..!"); isError = true; }
                        else
                        { errorProvider1.SetError(this.txtBoxAccID, ""); isError = false; }
                    }
                    catch { }
                }
            }
        }
        private void txtBoxAccID_Leave(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    if (dbClass.obj.IsAccIDExist(Convert.ToInt32(this.txtBoxAccID.Text.Trim()), Convert.ToInt32(curRow["ID"])))
                    { errorProvider1.SetError(this.txtBoxAccID, "Account ID Already Exist..!"); isError = true; }
                    else
                    { errorProvider1.SetError(this.txtBoxAccID, ""); isError = false; }
                }
                catch { }
            }
        }
    }
}
