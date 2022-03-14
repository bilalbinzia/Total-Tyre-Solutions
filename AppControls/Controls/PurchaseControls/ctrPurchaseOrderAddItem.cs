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
    public delegate void ItemForPODetailsDelegate(object sender, DataRow dataRow);
    public partial class ctrPurchaseOrderAddItem : UserControl
    {
        public event ItemForPODetailsDelegate ItemForPODetails;
        ControlLibrary.MessageBox xMessageBox = null;
        MainDataSet objDataSet;
        BindingSource objBindingSource;
        bool Initialize = true;
        public ctrPurchaseOrderAddItem()
        {
            InitializeComponent();

            objDataSet = new MainDataSet();
            objBindingSource = new BindingSource();

            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrPurchaseOrderAddItem_Load;

            btnAddItem.Click += btnAddItem_Click;
            btnItemList.Click += btnItemList_Click;
            txtCatalog.KeyDown += txtCatalog_KeyDown;

            txtCatalogCost.KeyDown += txtCatalogCost_KeyDown;

            NumPriceAPercent.ValueChanged += NumPriceAPercent_ValueChanged;
            NumPriceBPercent.ValueChanged += NumPriceBPercent_ValueChanged;
            NumPriceCPercent.ValueChanged += NumPriceCPercent_ValueChanged;

            taNumericUpDown3.GotFocus += taNumericUpDown_GotFocus;
            taNumericUpDown4.GotFocus += taNumericUpDown_GotFocus;
            taNumericUpDown5.GotFocus += taNumericUpDown_GotFocus;

            taNumericUpDown5.ValueChanged += taNumericUpDown5_ValueChanged;

            txtCatalogCost.TextChanged += txtCatalogCost_TextChanged;

        }

        void txtCatalogCost_TextChanged(object sender, EventArgs e)
        {
            PriceA.Text = txtCatalogCost.Text;
            PriceB.Text = txtCatalogCost.Text;
            PriceC.Text = txtCatalogCost.Text;
        }

        void taNumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            taNumericUpDown3.Value = taNumericUpDown5.Value;
            taNumericUpDown4.Value = taNumericUpDown5.Value;
        }

        void taNumericUpDown_GotFocus(object sender, EventArgs e)
        {
            NumericUpDown curBox = sender as NumericUpDown;
            curBox.Select();
            curBox.Select(0, curBox.Text.Length);
        }
        void txtCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtCatalog.Text.Trim()))
                {                
                    int ItemID = dbClass.obj.getItemIDByCatalog(txtCatalog.Text.Trim());
                    if (ItemID > 0)
                    {
                        DataTable dt = dbClass.obj.getItemForPO(ItemID);
                        objBindingSource.DataSource = dt;
                    }
                    else
                        xMessageBox.Show("Item not Matched ...");
                }
            }
        }

        frmCtr frmCtrItemListForGrid;
        void btnItemList_Click(object sender, EventArgs e)
        {
            ctrItemListForGrid objItemListForGrid = new ctrItemListForGrid();
            objItemListForGrid.ObjectSelected += objItemListForGrid_ObjectSelected;
            //----------------------------------------------------------------------//
            frmCtrItemListForGrid = new frmCtr("Select Item for Purchase Order ...");            
            frmCtrItemListForGrid.Height = objItemListForGrid.Height + 40;
            frmCtrItemListForGrid.Width = objItemListForGrid.Width + 20;
            frmCtrItemListForGrid.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtrItemListForGrid.frmPnl.Controls.Add(objItemListForGrid);
            frmCtrItemListForGrid.BringToFront();
            frmCtrItemListForGrid.ShowDialog();
        }
        void objItemListForGrid_ObjectSelected(object sender, DataRow dataRow,int packageID=0)
        {
            try
            {                
                int ItemID = Convert.ToInt32(dataRow["ID"]);
                DataTable dt = dbClass.obj.getItemForPO(ItemID);
                objBindingSource.DataSource = dt;                

                frmCtrItemListForGrid.Dispose();
                btnAddItem.Enabled = true;
            }
            catch(Exception ex)
            { xMessageBox.Show(ex.Message); }

            //DataTable copyDt = objDataSet.Tables["Item"].Clone();
            //copyDt.ImportRow(dataRow);
            //objBindingSource.DataSource = copyDt;

        }
        void ctrPurchaseOrderAddItem_Load(object sender, EventArgs e)
        {
            DataTable dt = dbClass.obj.getItemForPO(-1);
            objBindingSource.DataSource = dt;
            CtlEnableDisable(WorkingPanel);
        }
        List<Control> controlList = new List<Control>();
        private void CtlEnableDisable(Control control)
        {
            try
            {
                control.Enabled = true;
                foreach (Control ctr in control.Controls)
                {
                    if ((ctr.GetType() == typeof(Panel)) || (ctr.GetType() == typeof(TableLayoutPanel)) || (ctr.GetType() == typeof(SplitContainer)) || (ctr.GetType() == typeof(SplitterPanel)) || (ctr.GetType() == typeof(TabControl)) || (ctr.GetType() == typeof(TabPage)) || (ctr.GetType() == typeof(GroupBox)))
                    {
                        ctr.BackColor = StaticInfo.ctrBackColor;
                        controlList.Add(ctr);
                    }
                    else
                        BindingControls(ctr);
                }
                if (controlList.Count > 0)
                {
                    foreach (var item in controlList)
                    {
                        controlList.Remove(item);
                        this.CtlEnableDisable(item);
                    }
                }
            }
            catch { }
        }
        void BindingControls(Control ctr)
        {
            if (ctr.GetType() == typeof(TATextBox))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TATextBox)ctr).xBindingProperty != "") && (((TATextBox)ctr).xBindingProperty != null))
                            ((TATextBox)ctr).BindControl(this.objBindingSource, ((TATextBox)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TACheckBox))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TACheckBox)ctr).xBindingProperty != "") && (((TACheckBox)ctr).xBindingProperty != null))
                            ((TACheckBox)ctr).BindControl(this.objBindingSource, ((TACheckBox)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TARadioButton))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TARadioButton)ctr).xBindingProperty != "") && (((TARadioButton)ctr).xBindingProperty != null))
                            ((TARadioButton)ctr).BindControl(this.objBindingSource, ((TARadioButton)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TANumericUpDown))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TANumericUpDown)ctr).xBindingProperty != "") && (((TANumericUpDown)ctr).xBindingProperty != null))
                            ((TANumericUpDown)ctr).BindControl(this.objBindingSource, ((TANumericUpDown)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TADecimalControl))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TADecimalControl)ctr).xBindingProperty != "") && (((TADecimalControl)ctr).xBindingProperty != null))
                            ((TADecimalControl)ctr).BindControl(this.objBindingSource, ((TADecimalControl)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TADateTimePicker))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TADateTimePicker)ctr).xBindingProperty != "") && (((TADateTimePicker)ctr).xBindingProperty != null))
                            ((TADateTimePicker)ctr).BindControl(this.objBindingSource, ((TADateTimePicker)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TADateControl))
            {
                if (this.Initialize)
                {
                    try
                    {
                        if ((((TADateControl)ctr).xBindingProperty != "") && (((TADateControl)ctr).xBindingProperty != null))
                            ((TADateControl)ctr).BindControl(this.objBindingSource, ((TADateControl)ctr).xBindingProperty);
                    }
                    catch { }
                }
            }
            if (ctr.GetType() == typeof(TAComboBox))
            {
                if (this.Initialize)
                {
                    try
                    {
                        DataRowView curRow = (DataRowView)objBindingSource.Current;
                        int ID = 0;
                        try { ID = Convert.ToInt32(curRow[((TAComboBox)ctr).xBindingProperty]); }
                        catch { }
                        if ((((TAComboBox)ctr).xBindingProperty != "") && (((TAComboBox)ctr).xBindingProperty != null))
                            ((TAComboBox)ctr).BindControl(this.objBindingSource, this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()].Copy(), ID);
                    }
                    catch { }
                }
            }
            //--------------------------------------------------------            
        }
        void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatalog.Text!="")
                {
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    if (Convert.ToInt32(curRow["QtyOrdrd"]) > 0)
                    {
                        if (Convert.ToInt32(curRow["QtyRcvd"]) >= Convert.ToInt32(curRow["QtyBilled"]))
                        {
                            try
                            {
                                if (Convert.ToDecimal(curRow["CatalogCost"]) > 0)
                                {
                                    dbClass.obj.UpdateItemCatalogCost((DataTable)objBindingSource.DataSource);

                                    if (ItemForPODetails != null)
                                    {
                                        ItemForPODetails(this, curRow.Row);

                                        this.Parent.Parent.Parent.Dispose();
                                    }
                                }
                                else
                                    xMessageBox.Show("Catalog Cost Must be greater then 0 ...");

                                //if (chkboxIsUpdateCost.Checked)
                                //{
                                //    if (Convert.ToDecimal(curRow["CatalogCost"]) > 0)
                                //        dbClass.obj.UpdateItemPrice((DataTable)objBindingSource.DataSource);
                                //}
                            }
                            catch { }
                        }
                        else
                        {
                            xMessageBox.Show("Bill Quantity Must be less then Received Quantity ...");
                        }
                    }
                    else
                    {
                        xMessageBox.Show("Order Quantity Must be greater then 0 ...");
                    }
                }
                else
                {
                    xMessageBox.Show("Select Catalog for Add Item ...");
                }
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString());}

        }

        void txtCatalogCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    decimal dCatalogCost = Convert.ToDecimal(curRow["CatalogCost"]);
                    if (dCatalogCost > 0)
                    {
                        int iPriceAPercent = Convert.ToInt32(curRow["RetailPricePercent"]);
                        if (iPriceAPercent > 0)
                        {
                            curRow.BeginEdit();
                            curRow["RetailPrice"] = (dCatalogCost * iPriceAPercent / 100) + dCatalogCost;
                            curRow.EndEdit();
                        }
                        int iPriceBPercent = Convert.ToInt32(curRow["WholeSalePricePercent"]);
                        if (iPriceBPercent > 0)
                        {
                            curRow.BeginEdit();
                            curRow["WholeSalePrice"] = (dCatalogCost * iPriceBPercent / 100) + dCatalogCost;
                            curRow.EndEdit();
                        }
                        int iPriceCPercent = Convert.ToInt32(curRow["SpecialPricePercent"]);
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
        void NumPriceCPercent_ValueChanged(object sender, EventArgs e)
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
                        curRow["SpecialPrice"] = (dCatalogCost * iPriceCPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        void NumPriceBPercent_ValueChanged(object sender, EventArgs e)
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
                        curRow["WholeSalePrice"] = (dCatalogCost * iPriceBPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        void NumPriceAPercent_ValueChanged(object sender, EventArgs e)
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
                        curRow["RetailPrice"] = (dCatalogCost * iPriceAPercent / 100) + dCatalogCost;
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        
    }
}
