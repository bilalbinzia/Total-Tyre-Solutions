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
    public partial class ctrItemCatalog : BaseControl
    {
        int ItemID = 0;
        public ctrItemCatalog()
        {
            InitializeComponent();
        }
        public ctrItemCatalog(int itemID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.Load += ctrItemCatalog_Load;
            this.ItemID = itemID;
        }

        private void ctrItemCatalog_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void InitializeComponent1()
        {
            //this.Load += ctrItemDefination_Load;
            //btnVendorList.Click += btnVendorList_Click;
            //btnAddVendor.Click += btnAddVendor_Click;
            //txtInventoryOnOrder.MouseClick += txtInventoryOnOrder_MouseClick;
            //btnInventoryOnOrder.Click += btnInventoryOnOrder_Click;

            //txtCatalogCost.KeyDown += txtCatalogCost_KeyDown;

            //NumPriceAPercent.ValueChanged += NumPriceAPercent_ValueChanged;
            //NumPriceBPercent.ValueChanged += NumPriceBPercent_ValueChanged;
            //NumPriceCPercent.ValueChanged += NumPriceCPercent_ValueChanged;

            //NumPriceDPercent.ValueChanged += NumPriceDPercent_ValueChanged;
            //NumPriceEPercent.ValueChanged += NumPriceEPercent_ValueChanged;
            //NumPriceFPercent.ValueChanged += NumPriceFPercent_ValueChanged;

            //NumPriceGPercent.ValueChanged += NumPriceGPercent_ValueChanged;
            //NumPriceHPercent.ValueChanged += NumPriceHPercent_ValueChanged;
            //NumPriceIPercent.ValueChanged += NumPriceIPercent_ValueChanged;

            //txtPriceA.KeyDown += txtPriceA_KeyDown;
            //txtPriceB.KeyDown += txtPriceB_KeyDown;
            //txtPriceC.KeyDown += txtPriceC_KeyDown;

            //txtPriceD.KeyDown += txtPriceD_KeyDown;
            //txtPriceE.KeyDown += txtPriceE_KeyDown;
            //txtPriceF.KeyDown += txtPriceF_KeyDown;

            //txtPriceG.KeyDown += txtPriceG_KeyDown;
            //txtPriceH.KeyDown += txtPriceH_KeyDown;
            //txtPriceI.KeyDown += txtPriceI_KeyDown;

            //chkboxIsAuto.CheckedChanged += chkboxIsAuto_CheckedChanged;
            //chkboxIsUseFET.CheckedChanged += chkboxIsUseFET_CheckedChanged;
        }
    }
}
