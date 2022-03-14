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
    public partial class ctrAdjustmentInventory : BaseControl
    {
        int ItemID = 0;
        int QtyOnHand = 0;
        bool postback = false;
        public ctrAdjustmentInventory()
        {
            InitializeComponent();
            this.Load += ctrAdjustmentInventory_Load;
        }
        public ctrAdjustmentInventory(int Item)
        {
            this.ItemID = Item;
            InitializeComponent();
            this.Load += ctrAdjustmentInventory_Load;
            ctrAdjQty.ValueChanged += ctrAdjQty_ValueChanged;
            //ctrNewQty.ValueChanged += ctrNewQty_ValueChanged;
        }
        void ctrAdjustmentInventory_Load(object sender, EventArgs e)
        {
            
            base.bindingNavigatorAddNewItem_Click(sender, e);
            int AjdNo =  dbClass.obj.getNextAdjustmentNo();
            postback = true;
            DataRowView curRow = (DataRowView)objBindingSource.Current;

            DataRow dr = dbClass.obj.getItemInfo(this.ItemID);

            curRow.BeginEdit();
            curRow["AdjNo"] = AjdNo;
            ctrAdjDate.Value = DateTime.Now;
            curRow["AdjustmentDate"] = DateTime.Now;
            //txtItemID.Text = dr["ID"].ToString();
            curRow["ItemID"] = dr["ID"];

            txtNewCatalogCost.Text = String.Format("{0:c}", Convert.ToDecimal(dr["CatalogCost"]));
            curRow["NewCost"] = Convert.ToDecimal(dr["CatalogCost"]);

            lblItem.Text = dr["ItemSize"].ToString();
            lblCatalog.Text = dr["Catalog"].ToString();
            lblDescription.Text = dr["Name"].ToString();

            txtNewQty.Text = dr["QtyOnHand"].ToString();
            QtyOnHand = Convert.ToInt32(dr["QtyOnHand"]);
            curRow["NewQty"] = QtyOnHand;
            curRow.EndEdit();

        }

        void ctrAdjQty_ValueChanged(object sender, EventArgs e)
        {

            if (postback)
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();

                //string sQty = ctrAdjQty.Value == 0 ? "0" : txtAdjQty.Text;
                string sNewQty = txtNewQty.Text == "" ? "0" : txtNewQty.Text;

                decimal AdjQty = Convert.ToDecimal(ctrAdjQty.Value);
                decimal NewQty = Convert.ToDecimal(sNewQty);
                txtNewQty.Text = (AdjQty + QtyOnHand).ToString();

                curRow["NewQty"] = (AdjQty + QtyOnHand).ToString();
                curRow.EndEdit();
            }

            //int newAdjValue = Convert.ToInt32(txtAdjQty.Text);

            //if (oldAdjValue < newAdjValue)
            //{
            //    // this is up button
            //    int AdjQty = Convert.ToInt32(ctrAdjQty.Value);
            //    int NewQty = Convert.ToInt32(ctrNewQty.Value);
            //    ctrNewQty.Value = AdjQty + NewQty;
            //}
            //else
            //{
            //    //this is down button
            //    int AdjQty = Convert.ToInt32(ctrAdjQty.Value);
            //    int NewQty = Convert.ToInt32(ctrNewQty.Value);
            //    ctrNewQty.Value = NewQty - AdjQty;
            //}
        }
        
        //void ctrNewQty_ValueChanged(object sender, EventArgs e) 
        //{
        //    //int AdjQty = Convert.ToInt32(ctrAdjQty.Value);
        //    //int NewQty = Convert.ToInt32(ctrNewQty.Value);
        //    //ctrNewQty.Value = AdjQty + NewQty;
        //    var newAdjValue = ctrAdjQty.Value;

        //    if (oldAdjValue < newAdjValue)
        //    {
        //        // this is up button
        //        int AdjQty = Convert.ToInt32(ctrAdjQty.Value);
        //        int NewQty = Convert.ToInt32(ctrNewQty.Value);
        //        ctrNewQty.Value = AdjQty + NewQty;
        //    }
        //    else
        //    {
        //        //this is down button
        //        int AdjQty = Convert.ToInt32(ctrAdjQty.Value);
        //        int NewQty = Convert.ToInt32(ctrNewQty.Value);
        //        ctrNewQty.Value = NewQty - AdjQty;
        //    }
        //}

    }
}
