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
    public partial class ctrItemDefination : BaseControl
    {
        int ItemID = 0;
        public ctrItemDefination()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrItemDefination(int itemID)
        {
            InitializeComponent();
            InitializeComponent1();
            this.ItemID = itemID;
        }
        void InitializeComponent1()
        {
            this.Load += ctrItemDefination_Load;
            txtInventoryOnOrder.MouseClick += txtInventoryOnOrder_MouseClick;
            btnInventoryOnOrder.Click += btnInventoryOnOrder_Click;
            //btnDuplicateItem.Click += btnDuplicateItem_Click;

            //txtCatalogCost.LostFocus += txtCatalogCost_LostFocus;

            //NumPriceAPercent.ValueChanged += NumPriceAPercent_ValueChanged;
            //NumPriceBPercent.ValueChanged += NumPriceBPercent_ValueChanged;
            //NumPriceCPercent.ValueChanged += NumPriceCPercent_ValueChanged;

            NumPriceDPercent.ValueChanged += NumPriceDPercent_ValueChanged;
            NumPriceEPercent.ValueChanged += NumPriceEPercent_ValueChanged;
            NumPriceFPercent.ValueChanged += NumPriceFPercent_ValueChanged;

            NumPriceGPercent.ValueChanged += NumPriceGPercent_ValueChanged;
            NumPriceHPercent.ValueChanged += NumPriceHPercent_ValueChanged;
            NumPriceIPercent.ValueChanged += NumPriceIPercent_ValueChanged;

            //txtPriceA.LostFocus += txtPriceA_LostFocus;
            //txtPriceB.LostFocus += txtPriceB_LostFocus;
            //txtPriceC.LostFocus += txtPriceC_LostFocus;

            txtPriceD.KeyDown += txtPriceD_KeyDown;
            txtPriceE.KeyDown += txtPriceE_KeyDown;
            txtPriceF.KeyDown += txtPriceF_KeyDown;

            txtPriceG.KeyDown += txtPriceG_KeyDown;
            txtPriceH.KeyDown += txtPriceH_KeyDown;
            txtPriceI.KeyDown += txtPriceI_KeyDown;

            chkboxIsAuto.CheckedChanged += chkboxIsAuto_CheckedChanged;
            chkboxIsUseFET.CheckedChanged += chkboxIsUseFET_CheckedChanged;
        }
        private void ctrItemDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (System32.StaticInfo.CanApplicationExit)
                {
                    if (xMessageBox.Show("Do you want to save changes....?", "Exit..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
                    { e.Cancel = true; }
                    else
                    {
                        e.Cancel = false;
                        //BaseControl.LogOff(); Environment.Exit(0);
                    }
                }
            }
            catch { }
        }
        void ctrItemDefination_Load(object sender, EventArgs e)
        {
            if (this.ItemID <= 0)
            {
                //this.objBindingSource.AddNew();
                //bindingNavigatorAddNewItem_Click(sender, e);
            }
            else if (this.ItemID > 0)
            {
                bool AvgCost = false;
                DataRow[] row = StaticInfo.UserRights.Select("Code = '023'");
                if (row[0]["CanView"] != DBNull.Value)
                    AvgCost = Convert.ToBoolean(row[0]["CanView"]);
                if (AvgCost)
                    txtAvgCost.Enabled = true;
                else
                    txtAvgCost.Enabled = false;

                dbClass.obj.fillTablesByIDOrderBy(objDataSet.Tables[this.xTableName], this.ItemID);
                try
                {
                    //---fill item Sale History------------------
                    FillItemSaleHistory();
                    //---fill item workorder History--------------
                    FillItemWorkOrderHistory();
                }
                catch { }
            }
        }

        void FillItemSaleHistory()
        {
            BindingSource ItemBS = new BindingSource();
            DataTable dt = dbClass.obj.GetItemSaleHistory(this.ItemID);

            DataView dv = dt.DefaultView;
            dv.Sort = "Date DESC";
            DataTable dt2 = dv.ToTable();
            ItemBS.DataSource = dt2;
            DGVItemHistory.SetSource(ItemBS);
            DGVItemHistory.TDataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }
        void FillItemWorkOrderHistory()
        {
            BindingSource ItemBS = new BindingSource();
            DataTable dt = dbClass.obj.FillWorkOrderHistory(this.ItemID);
            ItemBS.DataSource = dt;
            DGVWorkOrders.SetSource(ItemBS);
            DGVWorkOrders.TDataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            //DGVItemHistory.TDataGridView.Columns["VendorCustomer"].HeaderText = "Vendor/Customer";
        }

        void txtCatalogCost_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                this.objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                if (dCatalogCost > 0)
                {
                    curRow.BeginEdit();
                    curRow["RetailPricePercent"] = "0";
                    curRow["WholeSalePricePercent"] = "0";
                    curRow["SpecialPricePercent"] = "0";
                    curRow["RetailPrice"] = "0";
                    curRow["WholeSalePrice"] = "0";
                    curRow["SpecialPrice"] = "0";
                    curRow.EndEdit();
                    int iPriceAPercent = Convert.ToInt32(curRow["RetailPricePercent"]);
                    curRow.BeginEdit();
                    //curRow["RetailPrice"] = dCatalogCost;
                    curRow["RetailPrice"] = 0;
                    curRow.EndEdit();
                    if (iPriceAPercent > 0)
                    {
                        curRow.BeginEdit();
                        //curRow["RetailPrice"] = (dCatalogCost * iPriceAPercent / 100) + dCatalogCost;
                        curRow["RetailPrice"] = 0;
                        curRow.EndEdit();
                    }

                    int iPriceBPercent = Convert.ToInt32(curRow["WholeSalePricePercent"]);
                    curRow.BeginEdit();
                    //curRow["WholeSalePrice"] = dCatalogCost;
                    curRow["WholeSalePrice"] = 0;
                    curRow.EndEdit();
                    if (iPriceBPercent > 0)
                    {
                        curRow.BeginEdit();
                        //curRow["WholeSalePrice"] = (dCatalogCost * iPriceBPercent / 100) + dCatalogCost;
                        curRow["WholeSalePrice"] = 0;
                        curRow.EndEdit();
                    }

                    int iPriceCPercent = Convert.ToInt32(curRow["SpecialPricePercent"]);
                    curRow.BeginEdit();
                    //curRow["SpecialPrice"] = dCatalogCost;
                    curRow["SpecialPrice"] = 0;
                    curRow.EndEdit();
                    if (iPriceCPercent > 0)
                    {
                        curRow.BeginEdit();
                        //curRow["SpecialPrice"] = (dCatalogCost * iPriceCPercent / 100) + dCatalogCost;
                        curRow["SpecialPrice"] = 0;
                        curRow.EndEdit();
                    }

                    int iPriceDPercent = Convert.ToInt32(curRow["PriceDPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceD"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceDPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceD"] = (dCatalogCost * iPriceDPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }

                    int iPriceEPercent = Convert.ToInt32(curRow["PriceEPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceE"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceEPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceE"] = (dCatalogCost * iPriceEPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }

                    int iPriceFPercent = Convert.ToInt32(curRow["PriceFPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceF"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceFPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceF"] = (dCatalogCost * iPriceFPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }

                    int iPriceGPercent = Convert.ToInt32(curRow["PriceGPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceG"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceGPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceG"] = (dCatalogCost * iPriceGPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }

                    int iPriceHPercent = Convert.ToInt32(curRow["PriceHPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceH"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceHPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceH"] = (dCatalogCost * iPriceHPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }

                    int iPriceIPercent = Convert.ToInt32(curRow["PriceIPercent"]);
                    curRow.BeginEdit();
                    curRow["PriceI"] = dCatalogCost;
                    curRow.EndEdit();
                    if (iPriceIPercent > 0)
                    {
                        curRow.BeginEdit();
                        curRow["PriceI"] = (dCatalogCost * iPriceIPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        void NumPriceAPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPriceAPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPriceAPercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["RetailPricePercent"] = iPriceAPercent;
                            curRow["RetailPrice"] = Math.Round((dCatalogCost * iPriceAPercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceBPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPriceBPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPriceBPercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["WholeSalePricePercent"] = iPriceBPercent;
                            curRow["WholeSalePrice"] = Math.Round((dCatalogCost * iPriceBPercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceCPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPriceCPercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPriceCPercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["SpecialPricePercent"] = iPriceCPercent;
                            curRow["SpecialPrice"] = Math.Round((dCatalogCost * iPriceCPercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceDPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceDPercent"] = iPricePercent;
                            curRow["PriceD"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceEPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceEPercent"] = iPricePercent;
                            curRow["PriceE"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        } //{code39} {code3of9} if buy {EAN13}
                    }
                }
                catch { }
            }
        }
        void NumPriceFPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceFPercent"] = iPricePercent;
                            curRow["PriceF"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceGPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceGPercent"] = iPricePercent;
                            curRow["PriceG"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceHPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceHPercent"] = iPricePercent;
                            curRow["PriceH"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void NumPriceIPercent_ValueChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPricePercent = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                        if (iPricePercent >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["PriceIPercent"] = iPricePercent;
                            curRow["PriceI"] = Math.Round((dCatalogCost * iPricePercent / 100), 2) + dCatalogCost;
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void txtPriceA_LostFocus(object sender, System.EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                decimal PriceA = Convert.ToDecimal(curRow["RetailPrice"]);
                decimal PriceAPercent = 0;

                if ((catalogCost > 0) && (PriceA >= 0) && (PriceA > catalogCost))
                {
                    PriceAPercent = ((PriceA - catalogCost) / catalogCost) * 100;
                    curRow["RetailPricePercent"] = PriceAPercent;
                    curRow.EndEdit();
                }
                //else
                //{
                //    txtCatalogCost.Focus();
                //    xMessageBox.Show("Retail Price is less than catalog price...");
                //    PriceAPercent = ((PriceA - catalogCost) / catalogCost) * 100;
                //} 
            }
        }
        void txtPriceB_LostFocus(object sender, System.EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                decimal PriceB = Convert.ToDecimal(curRow["WholeSalePrice"]);
                decimal PriceBPercent = 0;

                if ((catalogCost > 0) && (PriceB >= 0) && (PriceB > catalogCost))
                {
                    PriceBPercent = ((PriceB - catalogCost) / catalogCost) * 100;
                    curRow["WholeSalePricePercent"] = PriceBPercent;
                    curRow.EndEdit();
                }
                //else
                //{
                //    xMessageBox.Show("Whole Sale Price is less than catalog price...");
                //    PriceBPercent = ((PriceB - catalogCost) / catalogCost) * 100;
                //}
                //curRow["WholeSalePricePercent"] = PriceBPercent;
                //curRow.EndEdit();
            }
        }
        void txtPriceC_LostFocus(object sender, System.EventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                decimal PriceC = Convert.ToDecimal(curRow["SpecialPrice"]);
                decimal PriceCPercent = 0;

                if ((catalogCost > 0) && (PriceC >= 0) && (PriceC > catalogCost))
                {
                    PriceCPercent = ((PriceC - catalogCost) / catalogCost) * 100;
                    curRow["SpecialPricePercent"] = PriceCPercent;
                    curRow.EndEdit();
                }
                //else
                //{
                //    xMessageBox.Show("Special Price is less than catalog price...");
                //    PriceCPercent = ((PriceC - catalogCost) / catalogCost) * 100;
                //}
            }
        }
        void txtPriceD_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceD = Convert.ToDecimal(curRow["PriceD"]);
                    decimal PriceDPercent = 0;

                    if ((catalogCost > 0) && (PriceD >= 0))
                        PriceDPercent = ((PriceD - catalogCost) / catalogCost) * 100;

                    curRow["PriceDPercent"] = PriceDPercent;
                    curRow.EndEdit();
                }
            }
        }
        void txtPriceE_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceE = Convert.ToDecimal(curRow["PriceE"]);
                    decimal PriceEPercent = 0;

                    if ((catalogCost > 0) && (PriceE >= 0))
                        PriceEPercent = ((PriceE - catalogCost) / catalogCost) * 100;

                    curRow["PriceEPercent"] = PriceEPercent;
                    curRow.EndEdit();
                }
            }
        }
        void txtPriceF_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceF = Convert.ToDecimal(curRow["PriceF"]);
                    decimal PriceFPercent = 0;

                    if ((catalogCost > 0) && (PriceF >= 0))
                        PriceFPercent = ((PriceF - catalogCost) / catalogCost) * 100;

                    curRow["PriceFPercent"] = PriceFPercent;
                    curRow.EndEdit();
                }
            }
        }
        void txtPriceG_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceG = Convert.ToDecimal(curRow["PriceG"]);
                    decimal PriceGPercent = 0;

                    if ((catalogCost > 0) && (PriceG >= 0))
                        PriceGPercent = ((PriceG - catalogCost) / catalogCost) * 100;

                    curRow["PriceGPercent"] = PriceGPercent;
                    curRow.EndEdit();
                }
            }
        }
        void txtPriceH_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceH = Convert.ToDecimal(curRow["PriceH"]);
                    decimal PriceHPercent = 0;

                    if ((catalogCost > 0) && (PriceH >= 0))
                    {
                        PriceHPercent = ((PriceH - catalogCost) / catalogCost) * 100;
                    }
                    curRow["PriceHPercent"] = PriceHPercent;
                    curRow.EndEdit();
                }
            }
        }
        void txtPriceI_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmStatus == currentStatus.Add || frmStatus == currentStatus.Edit)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    curRow.BeginEdit();
                    decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    decimal PriceI = Convert.ToDecimal(curRow["PriceI"]);
                    decimal PriceIPercent = 0;

                    if ((catalogCost > 0) && (PriceI >= 0))
                        PriceIPercent = ((PriceI - catalogCost) / catalogCost) * 100;

                    curRow["PriceIPercent"] = PriceIPercent;
                    curRow.EndEdit();
                }
            }
        }
        void chkboxIsUseFET_CheckedChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add)
            {
                if (chkboxIsUseFET.Checked)
                {
                    txtFET.Text = "0";
                    txtFET.Enabled = true;
                    txtFET.ReadOnly = false;
                }
                else
                {
                    txtFET.Text = "0";
                    txtFET.Enabled = false;
                    txtFET.ReadOnly = true;
                }
            }
        }
        void chkboxIsAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (frmStatus == currentStatus.Add)
            {
                if (chkboxIsAuto.Checked)
                {
                    txtItemCode.Enabled = false;
                    txtItemCode.ReadOnly = true;
                    string ItemCode = dbClass.obj.getNextItemCode();
                    txtItemCode.Text = ItemCode;
                }
                else
                {
                    txtItemCode.Text = "";
                    txtItemCode.Enabled = true;
                    txtItemCode.ReadOnly = false;
                }
            }
        }
        void btnInventoryOnOrder_Click(object sender, EventArgs e)
        {
            txtInventoryOnOrder_MouseClick(sender, null);
        }
        void txtInventoryOnOrder_MouseClick(object sender, MouseEventArgs e)
        {
            DataRowView CurRow = (DataRowView)this.objBindingSource.Current;
            Int32 ItemID = Convert.ToInt32(CurRow["ID"]);
            DataTable dtOnOrder = dbClass.obj.getBackOrders(ItemID);
            if (dtOnOrder.Rows.Count > 0)
            {
                txtInventoryOnOrder.Text = Convert.ToString(dtOnOrder.Rows[0]["BO"]);
                if (Convert.ToInt32(dtOnOrder.Rows[0]["BO"]) > 0)
                {
                    ctrOnOrderList objOnOrderList = new ctrOnOrderList(ItemID);
                    frmCtr frmctrOnOrderList = new frmCtr("Open Orders ...");
                    frmctrOnOrderList.Height = objOnOrderList.Height + 40;
                    frmctrOnOrderList.Width = objOnOrderList.Width + 20;
                    frmctrOnOrderList.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    frmctrOnOrderList.frmPnl.Controls.Add(objOnOrderList);
                    frmctrOnOrderList.BringToFront();
                    frmctrOnOrderList.Show();
                }
            }
            else
                txtInventoryOnOrder.Text = "0";

        }
        void ClearControls()
        {
            //txtVendorID.Text = "";
            //txtVendorName.Text = "";
            //txtVendorPartNo.Text = "";
            //txtVendorCatalogCost.Text = "";
            //txtVendorNotes.Text = "";
            //chkBoxIsMainVendor.Checked = false;
        }
        void btnAddVendor_Click(object sender, EventArgs e)
        {
            //if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            //{
            //    if (!string.IsNullOrEmpty(txtVendorID.Text.Trim()))
            //    {
            //        int VendorID = Convert.ToInt32(txtVendorID.Text.Trim());
            //        if (VendorID > 0)
            //        {
            //            bool IsFound = false;
            //            if (DGVVendorList.Rows.Count > 1)
            //            {
            //                foreach (DataGridViewRow row in DGVVendorList.Rows)
            //                {
            //                    try
            //                    {
            //                        int gridItemID = Convert.ToInt32(row.Cells["VendorID"].Value);
            //                        if (gridItemID == VendorID)
            //                            IsFound = true;
            //                    }
            //                    catch { }
            //                }
            //            }
            //            if (!IsFound)
            //            {
            //                DataRowView newRow = (DataRowView)DGVVendorList.objBindingSource.AddNew();
            //                newRow.BeginEdit();
            //                newRow["VendorID"] = VendorID;
            //                if (!string.IsNullOrEmpty(txtVendorName.Text.Trim()))
            //                    newRow["VendorName"] = txtVendorName.Text.Trim();
            //                if (!string.IsNullOrEmpty(txtVendorPartNo.Text.Trim()))
            //                    newRow["VendorPartNo"] = txtVendorPartNo.Text.Trim();
            //                if (!string.IsNullOrEmpty(txtVendorCatalogCost.Text.Trim()))
            //                    newRow["CatalogCost"] = txtVendorCatalogCost.Text.Trim();
            //                if (!string.IsNullOrEmpty(txtVendorNotes.Text.Trim()))
            //                    newRow["Notes"] = txtVendorNotes.Text.Trim();
            //                newRow["IsMainVendor"] = chkBoxIsMainVendor.Checked;

            //                newRow["Active"] = true;
            //                newRow["AddDate"] = DateTime.Now;
            //                newRow["AddUserID"] = StaticInfo.userid;
            //                newRow["IsLocked"] = true;

            //                newRow.EndEdit();
            //            }
            //        }
            //    }
            //    ClearControls();
            //}
        }
        void btnVendorList_Click(object sender, EventArgs e)
        {
            ctrVendorList objList = new ctrVendorList();
            objList.VendorSelected += objList_VendorSelected;
            frmCtr frmCtr = new frmCtr("Select Vendor ...");
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void objList_VendorSelected(object sender, DataRow dataRow)
        {
            if (dataRow != null)
            {
                //txtVendorID.Text = Convert.ToString(dataRow["ID"]);
                //txtVendorName.Text = Convert.ToString(dataRow["Name"]);
            }
        }
        //void AddVendorInGrid_ObjectSelected(object sender, DataRow dataRow)
        //{
        //    try
        //    {
        //        if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
        //        {
        //            if (dataRow != null)
        //            {
        //                bool IsFound = false;
        //                if (DGVVendorList.Rows.Count > 1)
        //                {
        //                    foreach (DataGridViewRow row in DGVVendorList.Rows)
        //                    {
        //                        try
        //                        {
        //                            int gridItemID = Convert.ToInt32(row.Cells["ItemID"].Value);
        //                            int xItemID = Convert.ToInt32(dataRow["ID"]);
        //                            if (gridItemID == xItemID)
        //                                IsFound = true;
        //                        }
        //                        catch { }
        //                    }
        //                }
        //                if (!IsFound)
        //                {
        //                    DataRowView xCurRow = (DataRowView)DGVVendorList.objBindingSource.Current;
        //                    if (xCurRow.Row.RowState == DataRowState.Detached)
        //                    {
        //                        xCurRow.BeginEdit();
        //                        xCurRow["ItemID"] = dataRow["ID"];
        //                        //xCurRow["ItemSize"] = dataRow["ItemSize"];
        //                        xCurRow["Catalog"] = dataRow["Catalog"];
        //                        xCurRow["Name"] = dataRow["Name"];

        //                        xCurRow["SaleQty"] = 1;
        //                        xCurRow["Hour"] = 0;
        //                        xCurRow["SalePrice"] = dataRow["CatalogCost"];
        //                        xCurRow["Cost"] = 0;
        //                        xCurRow["SaleAmount"] = 0;
        //                        xCurRow["DiscPer"] = 0;
        //                        xCurRow["DiscAmount"] = 0;
        //                        xCurRow["SaleFET"] = 0;
        //                        xCurRow["Total"] = 0;
        //                        xCurRow["Tax"] = false;

        //                        xCurRow["Active"] = true;
        //                        xCurRow["AddDate"] = DateTime.Now;
        //                        xCurRow["AddUserID"] = StaticInfo.userid;
        //                        xCurRow["IsLocked"] = false;
        //                        xCurRow.EndEdit();
        //                    }
        //                    else
        //                    {
        //                        DataRowView newRow = (DataRowView)DGVVendorList.objBindingSource.AddNew();
        //                        newRow.BeginEdit();
        //                        newRow["ItemID"] = dataRow["ID"];
        //                        //xCurRow["ItemSize"] = dataRow["ItemSize"];
        //                        newRow["Catalog"] = dataRow["Catalog"];
        //                        newRow["Name"] = dataRow["Name"];

        //                        xCurRow["SaleQty"] = 1;
        //                        xCurRow["Hour"] = 0;
        //                        xCurRow["SalePrice"] = dataRow["CatalogCost"];
        //                        xCurRow["Cost"] = 0;
        //                        xCurRow["SaleAmount"] = 0;
        //                        xCurRow["DiscPer"] = 0;
        //                        xCurRow["DiscAmount"] = 0;
        //                        xCurRow["SaleFET"] = 0;
        //                        xCurRow["Total"] = 0;
        //                        xCurRow["Tax"] = false;

        //                        newRow["Active"] = true;
        //                        newRow["AddDate"] = DateTime.Now;
        //                        newRow["AddUserID"] = StaticInfo.userid;
        //                        newRow["IsLocked"] = false;

        //                        newRow.EndEdit();
        //                    }

        //                }

        //                //CalculatColumns();

        //            }
        //        }
        //    }
        //    catch { }
        //}
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            //-------------------------------            
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["RegDate"] = DateTime.Now;
            curRow["IsAuto"] = true;
            curRow["StoreID"] = StaticInfo.StoreID;
            curRow["RackID"] = 1;

            curRow["IsRepComm"] = true;
            curRow["IsTaxable"] = true;
            curRow["IsStocked"] = true;
            curRow["IsCosted"] = true;
            curRow["IsRetread"] = true;
            curRow["IsDiscountable"] = true;

            curRow.EndEdit();
            this.DataNavigation();
        }
        protected override void bindingNavigatorDelete_Click(object sender, EventArgs e)
        {
            bool DeletePermission = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '024'");
            if (row[0]["CanView"] != DBNull.Value)
                DeletePermission = Convert.ToBoolean(row[0]["CanView"]);
            if (!DeletePermission)
            {
                xMessageBox.Show("Sorry! You don't have Permissions to Delete.");
            }
            else
            {
                base.bindingNavigatorDelete_Click(sender, e);
            }
        }
        public override void btnBNRefresh_Click(object sender, EventArgs e)
        {
            this.DataNavigation();
        }
        protected override void DataNavigation()
        {
            base.DataNavigation();
            try
            {
                DataRowView CurRow = (DataRowView)this.objBindingSource.Current;
                if (CurRow != null)
                {
                    Int32 ItemID = Convert.ToInt32(CurRow["ID"]);
                    DataTable dtInventory = dbClass.obj.getTotalInventoryInfo(ItemID);
                    if (dtInventory.Rows.Count > 0)
                    {
                        txtInventoryAvailable.Text = Convert.ToString(dtInventory.Rows[0]["Qty"]);
                        txtInventoryOnHand.Text = Convert.ToString(dtInventory.Rows[0]["QtyOnHand"]);
                    }
                    else
                    {
                        txtInventoryAvailable.Text = "0";
                        txtInventoryOnHand.Text = "0";
                    }

                    DataTable dtOnOrder = dbClass.obj.getBackOrders(ItemID);
                    if (dtOnOrder.Rows.Count > 0)
                        txtInventoryOnOrder.Text = Convert.ToString(dtOnOrder.Rows[0]["BO"]);
                    else
                        txtInventoryOnOrder.Text = "0";
                }

            }
            catch { }
            this.BaseEnableDisble(this.frmStatus);

        }
        //void btnDuplicateItem_Click(object sender, EventArgs e)
        //{
        //    BindingSource bindingSource = new BindingSource();
        //     DataRowView curRow = (DataRowView)objBindingSource.Current;
        //    var a = Convert.ToInt32(curRow["ID"]);
        //    if (Convert.ToInt32(curRow["ID"]) > 0)
        //    {
        //        bindingNavigatorAddNewItem_Click(sender, e);
        //        DataTable dt = dbClass.obj.GetItemDuplicateByID(Convert.ToInt32(curRow["ID"]));
        //        bindingSource.DataSource = dt;
        //        //curRow.BeginEdit();
        //        //foreach (DataRow dr in dt.Rows) 
        //        //{

        //        //    curRow["ItemCode"] = dr["ItemCode"];
        //        //    curRow["IsAuto"] = dr["IsAuto"];
        //        //    curRow["ItemSize"] = dr["ItemSize"];
        //        //    curRow["Catalog"] = dr["Catalog"];
        //        //    curRow["Name"] = dr["Name"];
        //        //    curRow["ItemTypeID"] = dr["ItemTypeID"];
        //        //    curRow["ItemGroupID"] = dr["ItemGroupID"];
        //        //    curRow["ManufacturerID"] = dr["ManufacturerID"];
        //        //    curRow["IsDiscountable"] = dr["IsDiscountable"];
        //        //    curRow["IsRepComm"] = dr["IsRepComm"];
        //        //    curRow["IsOutsideItem"] = dr["IsOutsideItem"];
        //        //    curRow["IsMechComm"] = dr["IsMechComm"];
        //        //    curRow["IsCosted"] = dr["IsCosted"];
        //        //    curRow["IsTaxable"] = dr["IsTaxable"];
        //        //    curRow["IsRetread"] = dr["IsRetread"];
        //        //    curRow["IsStocked"] = dr["IsStocked"];
        //        //    curRow["IsUseFET"] = dr["IsUseFET"];
        //        //    curRow["UnitWeight"] = dr["UnitWeight"];
        //        //    curRow["CatalogCost"] = dr["CatalogCost"];
        //        //    curRow["LastCost"] = dr["LastCost"];
        //        //    curRow["AverageCost"] = dr["AverageCost"];
        //        //    curRow["FET"] = dr["FET"];
        //        //    curRow["RetailPricePercent"] = dr["RetailPricePercent"];
        //        //    curRow["RetailPrice"] = dr["RetailPrice"];
        //        //    curRow["WholeSalePricePercent"] = dr["WholeSalePricePercent"];
        //        //    curRow["WholeSalePrice"] = dr["WholeSalePrice"];
        //        //    curRow["SpecialPricePercent"] = dr["SpecialPricePercent"];
        //        //    curRow["SpecialPrice"] = dr["SpecialPrice"];
        //        //    curRow["ReOrderMin"] = dr["ReOrderMin"];
        //        //    //curRow["ItemCode"] = dr["ItemCode"];
        //        //    //curRow["ItemCode"] = dr["ItemCode"];
        //        //    //curRow["ItemCode"] = dr["ItemCode"];

        //        //}

        //        //curRow.EndEdit();
        //    }
        //}

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCatalogCost_Leave(object sender, EventArgs e)
        {
            string Cost = txtCatalogCost.Text;
            if (Cost.Contains("$"))
            {
                Cost = Cost.Trim('$');
            }
            if (!string.IsNullOrWhiteSpace(Cost))
            {
                decimal CatalogCost = Convert.ToDecimal(Cost);
                if (CatalogCost == 0 && !btnBNDeleteItem.Enabled)
                {
                    xMessageBox.Show("Catalog Cost Can not be Zero(0)");
                    txtCatalogCost.Focus();
                }
                else
                {
                    try
                    {
                        this.objBindingSource.EndEdit();
                        DataRowView curRow = (DataRowView)objBindingSource.Current;
                        decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                        if (dCatalogCost > 0)
                        {
                            curRow.BeginEdit();
                            curRow["RetailPricePercent"] = "0";
                            curRow["WholeSalePricePercent"] = "0";
                            curRow["SpecialPricePercent"] = "0";
                            curRow["RetailPrice"] = "0";
                            curRow["WholeSalePrice"] = "0";
                            curRow["SpecialPrice"] = "0";
                            curRow.EndEdit();
                            int iPriceAPercent = Convert.ToInt32(curRow["RetailPricePercent"]);
                            curRow.BeginEdit();
                            //curRow["RetailPrice"] = dCatalogCost;
                            curRow["RetailPrice"] = 0;
                            curRow.EndEdit();
                            if (iPriceAPercent > 0)
                            {
                                curRow.BeginEdit();
                                //curRow["RetailPrice"] = (dCatalogCost * iPriceAPercent / 100) + dCatalogCost;
                                curRow["RetailPrice"] = 0;
                                curRow.EndEdit();
                            }

                            int iPriceBPercent = Convert.ToInt32(curRow["WholeSalePricePercent"]);
                            curRow.BeginEdit();
                            //curRow["WholeSalePrice"] = dCatalogCost;
                            curRow["WholeSalePrice"] = 0;
                            curRow.EndEdit();
                            if (iPriceBPercent > 0)
                            {
                                curRow.BeginEdit();
                                //curRow["WholeSalePrice"] = (dCatalogCost * iPriceBPercent / 100) + dCatalogCost;
                                curRow["WholeSalePrice"] = 0;
                                curRow.EndEdit();
                            }

                            int iPriceCPercent = Convert.ToInt32(curRow["SpecialPricePercent"]);
                            curRow.BeginEdit();
                            //curRow["SpecialPrice"] = dCatalogCost;
                            curRow["SpecialPrice"] = 0;
                            curRow.EndEdit();
                            if (iPriceCPercent > 0)
                            {
                                curRow.BeginEdit();
                                //curRow["SpecialPrice"] = (dCatalogCost * iPriceCPercent / 100) + dCatalogCost;
                                curRow["SpecialPrice"] = 0;
                                curRow.EndEdit();
                            }

                            int iPriceDPercent = Convert.ToInt32(curRow["PriceDPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceD"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceDPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceD"] = (dCatalogCost * iPriceDPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }

                            int iPriceEPercent = Convert.ToInt32(curRow["PriceEPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceE"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceEPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceE"] = (dCatalogCost * iPriceEPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }

                            int iPriceFPercent = Convert.ToInt32(curRow["PriceFPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceF"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceFPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceF"] = (dCatalogCost * iPriceFPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }

                            int iPriceGPercent = Convert.ToInt32(curRow["PriceGPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceG"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceGPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceG"] = (dCatalogCost * iPriceGPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }

                            int iPriceHPercent = Convert.ToInt32(curRow["PriceHPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceH"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceHPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceH"] = (dCatalogCost * iPriceHPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }

                            int iPriceIPercent = Convert.ToInt32(curRow["PriceIPercent"]);
                            curRow.BeginEdit();
                            curRow["PriceI"] = dCatalogCost;
                            curRow.EndEdit();
                            if (iPriceIPercent > 0)
                            {
                                curRow.BeginEdit();
                                curRow["PriceI"] = (dCatalogCost * iPriceIPercent / 100) + dCatalogCost;
                                curRow.EndEdit();
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                xMessageBox.Show("Catalog Cost Can Not be Empty");
                txtCatalogCost.Focus();
            }
        }

        private void txtPriceA_Leave(object sender, EventArgs e)
        {
            //DataRowView curRow = (DataRowView)objBindingSource.Current;
            //decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
            //decimal PriceA = Convert.ToDecimal(curRow["RetailPrice"]);

            //if ((catalogCost <= 0) || (PriceA <= 0) || (PriceA < catalogCost))
            //{
            //    txtCatalogCost.Focus();
            //    xMessageBox.Show("Retail Price is less than catalog price...");
            //}

            //objBindingSource.EndEdit();
            //DataRowView curRow = (DataRowView)objBindingSource.Current;
            objBindingSource.EndEdit();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
            decimal PriceA = Convert.ToDecimal(curRow["RetailPrice"]);
            decimal PriceAPercent = 0;

            if (catalogCost > 0)
            {
                if ((PriceA >= 0) && (PriceA >= catalogCost))
                {
                    PriceAPercent = ((PriceA - catalogCost) / catalogCost) * 100;
                    curRow["RetailPricePercent"] = PriceAPercent;
                    curRow.EndEdit();
                }
                else
                {
                    txtPriceA.Focus();
                    xMessageBox.Show("Retail Price is less than catalog price...");
                }
            }
            else
            {
                xMessageBox.Show("Catalog Price cannot be zero ...");
                //txtCatalogCost.Focus();
            }
        }

        private void txtPriceB_Leave(object sender, EventArgs e)
        {
            objBindingSource.EndEdit();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
            decimal PriceB = Convert.ToDecimal(curRow["WholeSalePrice"]);
            decimal PriceBPercent = 0;
            if (catalogCost > 0)
            {
                if ((PriceB >= 0) && (PriceB >= catalogCost))
                {
                    PriceBPercent = ((PriceB - catalogCost) / catalogCost) * 100;
                    curRow["WholeSalePricePercent"] = PriceBPercent;
                    curRow.EndEdit();
                }
                else
                {
                    txtPriceB.Focus();
                    xMessageBox.Show("WholeSale Price is less than catalog price...");
                }
            }
            else
            {
                xMessageBox.Show("Catalog Price cannot be zero ...");
            }
        }

        private void txtPriceC_Leave(object sender, EventArgs e)
        {
            objBindingSource.EndEdit();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            decimal catalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
            decimal PriceC = Convert.ToDecimal(curRow["SpecialPrice"]);
            decimal PriceCPercent = 0;
            if (catalogCost > 0)
            {
                if ((PriceC >= 0) && (PriceC >= catalogCost))
                {
                    PriceCPercent = ((PriceC - catalogCost) / catalogCost) * 100;
                    curRow["SpecialPricePercent"] = PriceCPercent;
                    curRow.EndEdit();
                }
                else
                {
                    txtPriceC.Focus();
                    xMessageBox.Show("Special Price is less than catalog price...");
                }
            }
            else
            {
                xMessageBox.Show("Catalog Price cannot be zero ...");
            }
        }
    }
}
