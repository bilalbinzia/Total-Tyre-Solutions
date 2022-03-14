using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;
using DBModule;

namespace AppControls
{
    public partial class ctrVendorBillDetail : UserControl
    {
        MainDataSet objDataSet;
        BindingSource VendorBillBS;
        //BindingSource VendorBillDetailsBS;
        int SelectedVBID = 0;
        public ctrVendorBillDetail()
        {
            InitializeComponent();
        }
        public ctrVendorBillDetail(int ID, MainDataSet mobjDataSet, BindingSource mVendorBillBS)
        {
            InitializeComponent();
            objDataSet = mobjDataSet;
            VendorBillBS = mVendorBillBS;

            this.SelectedVBID = ID;

            this.Load += ctrVendorBillDetail_Load;
            DGVPOBillDetails.AddGridColumn(StaticInfo.gColumnType.AutoNoColumn, "No", "No", 30, 3, "", 1);
            DGVPOBillDetails.DataSource = null;

            BindingControls();
        }

        void ctrVendorBillDetail_Load(object sender, EventArgs e)
        {
            if (SelectedVBID > 0)
            {
                dbClass.obj.FillVendorBillDetailsByVBID(objDataSet.Tables["VendorBillDetails"], SelectedVBID);
                DGVPOBillDetails.DataSource = objDataSet.Tables["VendorBillDetails"];
            }           
        }
        void BindingControls()
        {
            //VendorBillBS.DataSource = objDataSet.Tables["VendorBill"];

            if ((txtInvoiceNo.xBindingProperty != "") && (txtInvoiceNo.xBindingProperty != null))
                txtInvoiceNo.BindControl(VendorBillBS, txtInvoiceNo.xBindingProperty);
            if ((txtBillID.xBindingProperty != "") && (txtBillID.xBindingProperty != null))
                txtBillID.BindControl(VendorBillBS, txtBillID.xBindingProperty);
            if ((txtBillNotes.xBindingProperty != "") && (txtBillNotes.xBindingProperty != null))
                txtBillNotes.BindControl(VendorBillBS, txtBillNotes.xBindingProperty);
            if ((txtPOID.xBindingProperty != "") && (txtPOID.xBindingProperty != null))
                txtPOID.BindControl(VendorBillBS, txtPOID.xBindingProperty);
            if ((txtBillFreight.xBindingProperty != "") && (txtBillFreight.xBindingProperty != null))
                txtBillFreight.BindControl(VendorBillBS, txtBillFreight.xBindingProperty);
            if ((txtVendorTerms.xBindingProperty != "") && (txtVendorTerms.xBindingProperty != null))
                txtVendorTerms.BindControl(VendorBillBS, txtVendorTerms.xBindingProperty);
            if ((txtBillPayFreightTo.xBindingProperty != "") && (txtBillPayFreightTo.xBindingProperty != null))
                txtBillPayFreightTo.BindControl(VendorBillBS, txtBillPayFreightTo.xBindingProperty);
            if ((txtSaleTaxAmount.xBindingProperty != "") && (txtSaleTaxAmount.xBindingProperty != null))
                txtSaleTaxAmount.BindControl(VendorBillBS, txtSaleTaxAmount.xBindingProperty);
            if ((txtSaleTaxDiscountPrice.xBindingProperty != "") && (txtSaleTaxDiscountPrice.xBindingProperty != null))
                txtSaleTaxDiscountPrice.BindControl(VendorBillBS, txtSaleTaxDiscountPrice.xBindingProperty);
            if ((txtSaleTaxSurchargePrice.xBindingProperty != "") && (txtSaleTaxSurchargePrice.xBindingProperty != null))
                txtSaleTaxSurchargePrice.BindControl(VendorBillBS, txtSaleTaxSurchargePrice.xBindingProperty);
            if ((txtBillTotalAmount.xBindingProperty != "") && (txtBillTotalAmount.xBindingProperty != null))
                txtBillTotalAmount.BindControl(VendorBillBS, txtBillTotalAmount.xBindingProperty);
            if ((txtGridTotalQty.xBindingProperty != "") && (txtGridTotalQty.xBindingProperty != null))
                txtGridTotalQty.BindControl(VendorBillBS, txtGridTotalQty.xBindingProperty);
            if ((txtGridTotalAmount.xBindingProperty != "") && (txtGridTotalAmount.xBindingProperty != null))
                txtGridTotalAmount.BindControl(VendorBillBS, txtGridTotalAmount.xBindingProperty);

            if ((ctrBillDate.xBindingProperty != "") && (ctrBillDate.xBindingProperty != null))
                ctrBillDate.BindControl(VendorBillBS, ctrBillDate.xBindingProperty);
            if ((ctrDueDate.xBindingProperty != "") && (ctrDueDate.xBindingProperty != null))
                ctrDueDate.BindControl(VendorBillBS, ctrDueDate.xBindingProperty);

            if ((NumSaleTaxPercent.xBindingProperty != "") && (NumSaleTaxPercent.xBindingProperty != null))
                NumSaleTaxPercent.BindControl(VendorBillBS, NumSaleTaxPercent.xBindingProperty);
            if ((NumSaleTaxDiscountPercent.xBindingProperty != "") && (NumSaleTaxDiscountPercent.xBindingProperty != null))
                NumSaleTaxDiscountPercent.BindControl(VendorBillBS, NumSaleTaxDiscountPercent.xBindingProperty);
            if ((NumSaleTaxSurchargePercent.xBindingProperty != "") && (NumSaleTaxSurchargePercent.xBindingProperty != null))
                NumSaleTaxSurchargePercent.BindControl(VendorBillBS, NumSaleTaxSurchargePercent.xBindingProperty);

        }

    }
}
