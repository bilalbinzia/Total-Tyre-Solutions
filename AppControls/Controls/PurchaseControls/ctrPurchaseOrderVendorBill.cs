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
    public delegate void VendorBillDetailsDelegate(object sender, DataRow dataRow);
    public partial class ctrPurchaseOrderVendorBill : OperationalControl
    {
        public event VendorBillDetailsDelegate vendorBillDetailsDelegate;
        
        DataTable dtPO;
        DataTable dtPOD;
        
        public ctrPurchaseOrderVendorBill()
        {
            InitializeComponent();
            InitializeComponent1();
        }
        public ctrPurchaseOrderVendorBill(DataTable dtPO, DataTable dtPOD)
        {
            InitializeComponent();
            InitializeComponent1();

            this.dtPO = dtPO;
            this.dtPOD = dtPOD;
        }
        void InitializeComponent1()
        {            
            this.Load += ctrPurchaseOrderVendorBill_Load;

            btnVendorList.Click += btnVendorList_Click;
            txtBillFreight.KeyDown += txtBillFreight_KeyDown;
            txtSaleTaxAmount.KeyDown += txtSaleTaxAmount_KeyDown;
            txtSaleTaxDiscountPrice.KeyDown += txtSaleTaxDiscountPrice_KeyDown;
            txtSaleTaxSurchargePrice.KeyDown += txtSaleTaxSurchargePrice_KeyDown;

            NumSaleTaxPercent.ValueChanged += NumSaleTaxPercent_ValueChanged;
            NumSaleTaxDiscountPercent.ValueChanged += NumSaleTaxDiscountPercent_ValueChanged;
            NumSaleTaxSurchargePercent.ValueChanged += NumSaleTaxSurchargePercent_ValueChanged;

            btnCancel.Click += btnCancel_Click;
            btnCreateVendorBill.Click += btnCreateVendorBill_Click;

        }                
        void btnCreateVendorBill_Click(object sender, EventArgs e)
        {
            //---------------------------------
            //Save Vendor Bill-----------------
            if (CustomValidation(true))
            {
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                curRow.BeginEdit();
                curRow["Balance"] = curRow["BillTotalAmount"];              
                curRow.EndEdit();
                //-------------------------------------------------------
                base.bindingNavigatorSaveItemClick(sender, e);
                //-------------------------------------------------------

                //-------------------------------------------------------
                //DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                if (vendorBillDetailsDelegate != null)
                    vendorBillDetailsDelegate(this, curRow.Row);

                this.ParentForm.Close();
            }
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (vendorBillDetailsDelegate != null)
                vendorBillDetailsDelegate(this, null);

            this.ParentForm.Close();
                        
        }
        void btnVendorList_Click(object sender, EventArgs e)
        {
            ctrVendorList objList = new ctrVendorList();
            objList.VendorSelected += objList_VendorSelected;
            //----------------------------------------------------------------------//
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

                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                curRow.BeginEdit();
                curRow["VendorID"] = dataRow["ID"];
                txtBillPayFreightTo.Text = Convert.ToString(dataRow["Name"]);
                curRow.EndEdit();
            }
        }

        void txtBillFreight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.objBindingSource.EndEdit();
                try
                {
                    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                    decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                    decimal SaleTaxAmount = Convert.ToDecimal(curRow["SaleTaxAmount"]);
                    decimal SaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                    decimal SaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);

                    curRow.BeginEdit();
                    curRow["BillTotalAmount"] = Math.Round(((dGridTotalAmount + BillFreight + SaleTaxAmount + SaleTaxSurchargePrice) - SaleTaxDiscountPrice), 2);
                    curRow.EndEdit();
                }
                catch { }
            }
        }
        void txtSaleTaxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                    decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                    decimal SaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                    decimal SaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);
                    if (dGridTotalAmount > 0)
                    {
                        decimal iSaleTaxAmount = Convert.ToDecimal(curRow["SaleTaxAmount"]);
                        if (iSaleTaxAmount >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["SaleTaxPercent"] = Math.Round((iSaleTaxAmount / dGridTotalAmount) * 100, 2);
                            curRow["SaleTaxAmount"] = Math.Round(iSaleTaxAmount, 2);
                            curRow["BillTotalAmount"] = Math.Round(((dGridTotalAmount + SaleTaxSurchargePrice + BillFreight) - SaleTaxDiscountPrice) + Convert.ToDecimal(curRow["SaleTaxAmount"]), 2);
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void txtSaleTaxSurchargePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                    decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                    decimal SaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                    if (dGridTotalAmount > 0)
                    {
                        decimal iSaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);
                        if (iSaleTaxSurchargePrice >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["SaleTaxSurchargePercent"] = Math.Round((iSaleTaxSurchargePrice / dGridTotalAmount) * 100,2);
                            curRow["SaleTaxSurchargePrice"] = Math.Round(iSaleTaxSurchargePrice,2);
                            curRow["BillTotalAmount"] = Math.Round((dGridTotalAmount + BillFreight - SaleTaxDiscountPrice) + Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]),2);
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }
        void txtSaleTaxDiscountPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.objBindingSource.EndEdit();
                    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                    decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                    decimal SaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);
                    if (dGridTotalAmount > 0)
                    {
                        decimal iSaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                        if (iSaleTaxDiscountPrice >= 0)
                        {
                            curRow.BeginEdit();
                            curRow["SaleTaxDiscountPercent"] = Math.Round((iSaleTaxDiscountPrice / dGridTotalAmount) * 100,2);
                            curRow["SaleTaxDiscountPrice"] = Math.Round(iSaleTaxDiscountPrice,2);
                            curRow["BillTotalAmount"] = Math.Round((dGridTotalAmount + BillFreight + SaleTaxSurchargePrice) - Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]),2);
                            curRow.EndEdit();
                        }
                    }
                }
                catch { }
            }
        }

        void NumSaleTaxPercent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                decimal SaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                decimal SaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);
                if (dGridTotalAmount > 0)
                {
                    Decimal iSaleTaxPercent = Convert.ToDecimal(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                    if (iSaleTaxPercent >= 0)
                    {
                        curRow.BeginEdit();
                        curRow["SaleTaxPercent"] = iSaleTaxPercent;
                        curRow["SaleTaxAmount"] = (dGridTotalAmount * iSaleTaxPercent / 100);
                        curRow["BillTotalAmount"] = Math.Round(((dGridTotalAmount + BillFreight + SaleTaxSurchargePrice) - SaleTaxDiscountPrice) + Convert.ToDecimal(curRow["SaleTaxAmount"]), 2);
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        void NumSaleTaxSurchargePercent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);
                decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                decimal SaleTaxDiscountPrice = Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]);
                decimal SaleTaxAmount = Convert.ToDecimal(curRow["SaleTaxAmount"]);
                if (dGridTotalAmount > 0)
                {
                    Decimal iSaleTaxSurchargePercent = Convert.ToDecimal(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                    if (iSaleTaxSurchargePercent >= 0)
                    {
                        curRow.BeginEdit();
                        curRow["SaleTaxSurchargePercent"] = iSaleTaxSurchargePercent;
                        curRow["SaleTaxSurchargePrice"] = (dGridTotalAmount * iSaleTaxSurchargePercent / 100);
                        curRow["BillTotalAmount"] = Math.Round(((dGridTotalAmount + BillFreight + SaleTaxAmount)- SaleTaxDiscountPrice) + Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]), 2);
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        void NumSaleTaxDiscountPercent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.objBindingSource.EndEdit();
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                decimal dGridTotalAmount = Convert.ToDecimal(curRow["GridTotalAmount"]);                
                decimal BillFreight = Convert.ToDecimal(curRow["BillFreight"]);
                decimal SaleTaxSurchargePrice = Convert.ToDecimal(curRow["SaleTaxSurchargePrice"]);
                decimal SaleTaxAmount = Convert.ToDecimal(curRow["SaleTaxAmount"]);
                if (dGridTotalAmount > 0)
                {
                    Decimal iSaleTaxDiscountPercent = Convert.ToDecimal(((System.Windows.Forms.NumericUpDown)(sender)).Value);
                    if (iSaleTaxDiscountPercent >= 0)
                    {
                        curRow.BeginEdit();
                        curRow["SaleTaxDiscountPercent"] = iSaleTaxDiscountPercent;
                        curRow["SaleTaxDiscountPrice"] = (dGridTotalAmount * iSaleTaxDiscountPercent / 100);
                        curRow["BillTotalAmount"] = Math.Round((dGridTotalAmount + BillFreight + SaleTaxSurchargePrice + SaleTaxAmount) - Convert.ToDecimal(curRow["SaleTaxDiscountPrice"]), 2);
                        curRow.EndEdit();
                    }
                }
            }
            catch { }
        }
        

        void ctrPurchaseOrderVendorBill_Load(object sender, EventArgs e)
        {
            this.objBindingSource.AddNew();
            base.bindingNavigatorAddNewItemClick(sender, e);
            //-------------------------
            DGVPOBillDetails.Columns[0].Visible = false;
            fillTables();
            //-------------------------
        }
        void fillTables()
        {
            int iDueByDaysD1 = 0;
            DataRow DR = dtPO.Rows[0];
            DataRow trmdr = dbClass.obj.getVendorterm(Convert.ToInt32(DR["VendorID"]));            
            if(trmdr["DueByDaysD1"]!=DBNull.Value)
                iDueByDaysD1 = Convert.ToInt32(trmdr["DueByDaysD1"]);
            txtDueByDaysD1.Text = Convert.ToString(trmdr["Name"]);
            decimal DiscountPrice = 0;

            int totalgridQty = 0; decimal toalgridAmount = 0;
            foreach (DataRow PODRow in dtPOD.Rows)
            {                
                totalgridQty += Convert.ToInt32(PODRow["QtyBilled"]);
                toalgridAmount += Convert.ToInt32(PODRow["QtyBilled"]) * Convert.ToDecimal(PODRow["Cost"]);
            }

            int NewVendorBill = dbClass.obj.getNextVendorBillAutoNo();
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();
            curRow["BillID"] = NewVendorBill;
            curRow["VendorID"] = DR["VendorID"];
            curRow["POID"] = DR["POID"];
            curRow["InvoiceNo"] = DR["Reference"];
            curRow["BillNotes"] = DR["Notes"];
            curRow["BillDate"] = DateTime.Now;
            curRow["DueDate"] = DateTime.Now.AddDays(iDueByDaysD1);
            curRow["BillFreight"] = 0;
            curRow["BillPayFreightToID"] = DR["VendorID"];
            txtBillPayFreightTo.Text = dbClass.obj.getVendorName(Convert.ToInt32(DR["VendorID"]));
            curRow["SaleTaxDiscountPercent"] = DR["DiscountPer"];
            DiscountPrice = (toalgridAmount * (Convert.ToDecimal(DR["DiscountPer"]) / 100));
            curRow["SaleTaxDiscountPrice"] = DiscountPrice;
            curRow["SaleTaxSurchargePercent"] = 0;
            curRow["SaleTaxSurchargePrice"] = 0;
            curRow["StoreID"] = StaticInfo.StoreID;
            curRow["BillType"] = "B";
            curRow["BillStatus"] = "R";            
            curRow.EndEdit();

            //---------------------------------------------------------------
            
            foreach (DataRow PODRow in dtPOD.Rows)
            {
                if (Convert.ToInt32(PODRow["QtyBilled"]) > 0)
                {
                    DataRowView detailRow = (DataRowView)DGVPOBillDetails.objBindingSource.AddNew();
                    detailRow.BeginEdit();
                    detailRow["ItemID"] = PODRow["ItemID"];
                    detailRow["Catalog"] = PODRow["Catalog"];
                    detailRow["Name"] = PODRow["Description"];

                    detailRow["BillQty"] = PODRow["QtyBilled"];                    
                    detailRow["CatalogCost"] = PODRow["Cost"];
                    detailRow["BillAmount"] = Convert.ToInt32(PODRow["QtyBilled"]) * Convert.ToDecimal(PODRow["Cost"]);

                    detailRow["Active"] = true;
                    detailRow["AddDate"] = DateTime.Now;
                    detailRow["AddUserID"] = StaticInfo.userid;
                    detailRow["IsLocked"] = true;
                    detailRow.EndEdit();
                }
            }
            //------------------------------------------------
            curRow.BeginEdit();
            curRow["GridTotalQty"] = totalgridQty;
            curRow["GridTotalAmount"] = toalgridAmount;
            curRow["BillTotalAmount"] = toalgridAmount - DiscountPrice;
            curRow.EndEdit();
        }
    }
}
