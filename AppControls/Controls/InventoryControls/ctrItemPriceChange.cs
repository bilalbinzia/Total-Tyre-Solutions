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
    public partial class ctrItemPriceChange : UserControl
    {
        Int32 ItemID = 0;
        BindingSource ItemPriceBS;
        MainDataSet objDataSet;
        public ctrItemPriceChange()
        {
            InitializeComponent();
        }

        public ctrItemPriceChange(Int32 ItemID)
        {
            InitializeComponent();

            objDataSet = new MainDataSet();
            ItemPriceBS = new BindingSource();
            this.Load += ctrItemPriceChange_Load;

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;

            txtCatalogCost.KeyDown += txtCatalogCost_KeyDown;

            //NumPriceAPercent.ValueChanged += NumPriceAPercent_ValueChanged;
            //NumPriceBPercent.ValueChanged += NumPriceBPercent_ValueChanged;
            //NumPriceCPercent.ValueChanged += NumPriceCPercent_ValueChanged;

            //txtPriceA.KeyDown += txtPriceA_KeyDown;
            //txtPriceB.KeyDown += txtPriceB_KeyDown;
            //txtPriceC.KeyDown += txtPriceC_KeyDown;

            this.ItemID = ItemID;
        }
        void txtCatalogCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.ItemPriceBS.EndEdit();
                    DataRowView curRow = (DataRowView)ItemPriceBS.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPriceAPercent = Convert.ToInt32(curRow["RetailPricePercent"]);
                        curRow.BeginEdit();
                        curRow["RetailPrice"] = dCatalogCost;
                        curRow.EndEdit();
                        if (iPriceAPercent > 0)
                        {
                            curRow.BeginEdit();
                            curRow["RetailPrice"] = (dCatalogCost * iPriceAPercent / 100) + dCatalogCost;
                            curRow.EndEdit();
                        }

                        int iPriceBPercent = Convert.ToInt32(curRow["WholeSalePricePercent"]);
                        curRow.BeginEdit();
                        curRow["WholeSalePrice"] = dCatalogCost;
                        curRow.EndEdit();
                        if (iPriceBPercent > 0)
                        {
                            curRow.BeginEdit();
                            curRow["WholeSalePrice"] = (dCatalogCost * iPriceBPercent / 100) + dCatalogCost;
                            curRow.EndEdit();
                        }

                        int iPriceCPercent = Convert.ToInt32(curRow["SpecialPricePercent"]);
                        curRow.BeginEdit();
                        curRow["SpecialPrice"] = dCatalogCost;
                        curRow.EndEdit();
                        if (iPriceCPercent > 0)
                        {
                            curRow.BeginEdit();
                            curRow["SpecialPrice"] = (dCatalogCost * iPriceCPercent / 100) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        //void NumPriceCPercent_ValueChanged(object sender, EventArgs e)
        //{
            
        //        try
        //        {
        //            this.ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            if (dCatalogCost > 0)
        //            {
        //                int iPriceCPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
        //                if (iPriceCPercent >= 0)
        //                {
        //                    curRow.BeginEdit();
        //                    curRow["SpecialPricePercent"] = iPriceCPercent;
        //                    curRow["SpecialPrice"] = Math.Round((dCatalogCost * iPriceCPercent / 100), 2) + dCatalogCost;
        //                    curRow.EndEdit();
        //                }
        //            }
        //        }
        //        catch { }
            
        //}
        //void NumPriceBPercent_ValueChanged(object sender, EventArgs e)
        //{
            
        //        try
        //        {
        //            this.ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            if (dCatalogCost > 0)
        //            {
        //                int iPriceBPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
        //                if (iPriceBPercent >= 0)
        //                {
        //                    curRow.BeginEdit();
        //                    curRow["WholeSalePricePercent"] = iPriceBPercent;
        //                    curRow["WholeSalePrice"] = Math.Round((dCatalogCost * iPriceBPercent / 100), 2) + dCatalogCost;
        //                    curRow.EndEdit();
        //                }
        //            }
        //        }
        //        catch { }
            
        //}
        //void NumPriceAPercent_ValueChanged(object sender, EventArgs e)
        //{
            
        //        try
        //        {
        //            this.ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            if (dCatalogCost > 0)
        //            {
        //                int iPriceAPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
        //                if (iPriceAPercent >= 0)
        //                {
        //                    curRow.BeginEdit();
        //                    curRow["RetailPricePercent"] = iPriceAPercent;
        //                    curRow["RetailPrice"] = Math.Round((dCatalogCost * iPriceAPercent / 100), 2) + dCatalogCost;
        //                    curRow.EndEdit();
        //                }
        //            }
        //        }
        //        catch { }
            
        //}
        //void txtPriceC_KeyDown(object sender, KeyEventArgs e)
        //{
            
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            curRow.BeginEdit();
        //            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            decimal PriceC = Convert.ToDecimal(curRow["SpecialPrice"]);
        //            decimal PriceCPercent = 0;

        //            if ((catalogCost > 0) && (PriceC >= 0))
        //                PriceCPercent = ((PriceC - catalogCost) / catalogCost) * 100;

        //            curRow["SpecialPricePercent"] = PriceCPercent;
        //            curRow.EndEdit();
        //        }
            
        //}
        //void txtPriceB_KeyDown(object sender, KeyEventArgs e)
        //{
            
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            curRow.BeginEdit();
        //            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            decimal PriceB = Convert.ToDecimal(curRow["WholeSalePrice"]);
        //            decimal PriceBPercent = 0;

        //            if ((catalogCost > 0) && (PriceB >= 0))
        //                PriceBPercent = ((PriceB - catalogCost) / catalogCost) * 100;

        //            curRow["WholeSalePricePercent"] = PriceBPercent;
        //            curRow.EndEdit();
        //        }
           
        //}
        //void txtPriceA_KeyDown(object sender, KeyEventArgs e)
        //{
            
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            ItemPriceBS.EndEdit();
        //            DataRowView curRow = (DataRowView)ItemPriceBS.Current;
        //            curRow.BeginEdit();
        //            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
        //            decimal PriceA = Convert.ToDecimal(curRow["RetailPrice"]);
        //            decimal PriceAPercent = 0;

        //            if ((catalogCost > 0) && (PriceA >= 0))
        //                PriceAPercent = ((PriceA - catalogCost) / catalogCost) * 100;

        //            curRow["RetailPricePercent"] = PriceAPercent;
        //            curRow.EndEdit();
        //        }
            
        //}

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemPriceBS.EndEdit();
            dbClass.obj.UpdateTable(objDataSet.Tables["Item"]);
            this.ParentForm.Close();
        }
        void ctrItemPriceChange_Load(object sender, EventArgs e)
        {
            dbClass.obj.getItemPriceforPriceChange(objDataSet.Tables["Item"], this.ItemID);
            if (objDataSet.Tables["Item"].Rows.Count > 0)
            {
                BindingControls(objDataSet.Tables["Item"]);

            }

        }
        void BindingControls(DataTable dt)
        {
            ItemPriceBS.DataSource = dt;

            if ((txtCatalog.xBindingProperty != "") && (txtCatalog.xBindingProperty != null))
                txtCatalog.BindControl(ItemPriceBS, txtCatalog.xBindingProperty);

            if ((txtItemName.xBindingProperty != "") && (txtItemName.xBindingProperty != null))
                txtItemName.BindControl(ItemPriceBS, txtItemName.xBindingProperty);
            
            if ((txtCatalogCost.xBindingProperty != "") && (txtCatalogCost.xBindingProperty != null))
                txtCatalogCost.BindControl(ItemPriceBS, txtCatalogCost.xBindingProperty);

            if ((txtLastCost.xBindingProperty != "") && (txtLastCost.xBindingProperty != null))
                txtLastCost.BindControl(ItemPriceBS, txtLastCost.xBindingProperty);

            if ((txtAverageCost.xBindingProperty != "") && (txtAverageCost.xBindingProperty != null))
                txtAverageCost.BindControl(ItemPriceBS, txtAverageCost.xBindingProperty);

            if ((txtFET.xBindingProperty != "") && (txtFET.xBindingProperty != null))
                txtFET.BindControl(ItemPriceBS, txtFET.xBindingProperty);

            //if ((NumPriceAPercent.xBindingProperty != "") && (NumPriceAPercent.xBindingProperty != null))
            //    NumPriceAPercent.BindControl(ItemPriceBS, NumPriceAPercent.xBindingProperty);
            //if ((txtPriceA.xBindingProperty != "") && (txtPriceA.xBindingProperty != null))
            //    txtPriceA.BindControl(ItemPriceBS, txtPriceA.xBindingProperty);

            //if ((NumPriceBPercent.xBindingProperty != "") && (NumPriceBPercent.xBindingProperty != null))
            //    NumPriceBPercent.BindControl(ItemPriceBS, NumPriceBPercent.xBindingProperty);
            //if ((txtPriceB.xBindingProperty != "") && (txtPriceB.xBindingProperty != null))
            //    txtPriceB.BindControl(ItemPriceBS, txtPriceB.xBindingProperty);

            //if ((NumPriceCPercent.xBindingProperty != "") && (NumPriceCPercent.xBindingProperty != null))
            //    NumPriceCPercent.BindControl(ItemPriceBS, NumPriceCPercent.xBindingProperty);
            //if ((txtPriceC.xBindingProperty != "") && (txtPriceC.xBindingProperty != null))
            //    txtPriceC.BindControl(ItemPriceBS, txtPriceC.xBindingProperty);

        }

    }
}
