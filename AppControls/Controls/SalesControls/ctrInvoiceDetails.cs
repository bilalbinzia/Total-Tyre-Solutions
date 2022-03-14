using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System.Globalization;

namespace AppControls
{
    public partial class ctrInvoiceDetails : UserControl
    {
        private string SaleDate;
        private int InvoiceID;
        MainDataSet objDataSet;
        BindingSource ItemBS;
        ControlLibrary.MessageBox xMessageBox = null;

        public object objBindingSource { get; private set; }
        public ctrInvoiceDetails()
        {
            InitializeComponent();
            this.Load += ctrInvoiceDetails_Load;
        }
        public ctrInvoiceDetails(int ID, string SaleDate)
        {
            InitializeComponent();
            ItemBS = new BindingSource();
            DGVInvoiceDetails.CellClick += DGVInvoiceDetails_CellClick;
            this.Load += ctrInvoiceDetails_Load;
            //lblSaleID.Text = id.ToString();
            //DateTime oDate = DateTime.ParseExact(SaleDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);
            this.SaleDate = SaleDate;
            this.InvoiceID = ID;
            lblInvoiceNo.Text = ID.ToString();
            ClearFields();
            BindingControls();
        }
        void ClearFields()
        {
            txtCatalogName.Text = "";
            txtCost.Text = "";
            txtDiscount.Text = "";
            txtGroup.Text = "";
            txtHours.Text = "";
            txtMargin.Text = "";
            txtMarkup.Text = "";
            txtPlusFET.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
            txtTotalProfit.Text = "";
            txtType.Text = "";
            
        }
        
        void DGVInvoiceDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCatalogName.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["Catalog"].Value.ToString();
                txtDesc.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                txtQuantity.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                txtHours.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["Hours"].Value.ToString();
                txtType.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["CType"].Value.ToString();
                txtGroup.Text = DGVInvoiceDetails.Rows[e.RowIndex].Cells["Group"].Value.ToString();

                txtPrice.Text = "$"+DGVInvoiceDetails.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                txtPlusFET.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["FET"].Value.ToString();
                txtSubtotal.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["Total"].Value.ToString();
                txtDiscount.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
                txtTotal.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["Total"].Value.ToString();

                txtCost.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["Cost"].Value.ToString();
                if (txtType.Text != "F" && txtType.Text != "L")
                {
                    string Price = txtPrice.Text;
                    string Cost = txtCost.Text;
                    string Qty = txtQuantity.Text;
                    if (Price != "")
                    {
                        Price = Price.Substring(1);
                    }
                    else { Price = "0"; };
                    if (Cost != "")
                    {
                        Cost = Cost.Substring(1);
                    }
                    else { Cost = "0"; }
                    Decimal Profit = (Convert.ToDecimal(Price) - Convert.ToDecimal(Cost))*Convert.ToDecimal(Qty);
                     
                    txtTotalProfit.Text = "$" + Profit.ToString();
                    txtMargin.Text = "$" + DGVInvoiceDetails.Rows[e.RowIndex].Cells["Margin"].Value.ToString();
                }
                else
                {
                    txtTotalProfit.Text = "$" + "0.00";
                    txtMargin.Text= "$" + "0.00";
                }
                
                txtMarkup.Text = "$" + "0.00";
            }
        }
        private void ctrInvoiceDetails_Load(object sender, EventArgs e)
        {
            if (InvoiceID != 0 && SaleDate != "")
            {
                LoadInvoiceDetail();
            }
        }
        void BindingControls()
        {
            //DataTable dt = dbClass.obj.GetDailyInvoiceDetailsbyDate(InvoiceID, SaleDate);
            //ItemBS.DataSource = dt;
            //DGVSaleList.DataSource = ItemBS;
        }
        void LoadInvoiceDetail()
        {
            try
            {
                //DateTime dte = DateTime.ParseExact(SaleDate.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                DateTime dte = Convert.ToDateTime(SaleDate.ToString(), CultureInfo.InvariantCulture);                   

                string date = dte.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime date = DateTime.ParseExact(iString, "d/M/yyyy", CultureInfo.InvariantCulture);
                //DateTime date = DateTime.Parse(iString,"", new System.Globalization.CultureInfo("pt-BR"));
                lbldate.Text = date.ToString();

                

                DataTable dt = dbClass.obj.GetDailyInvoiceDetailsbyDate(InvoiceID, SaleDate);
                DataTable dt2 = dbClass.obj.GetInvoiceTaxbyID(InvoiceID, SaleDate);
                if (dt2.Rows.Count > 0)
                {
                    lblInvoiceTax.Text = dt2.Rows[0]["Tax"].ToString();
                    if (dt2.Rows[0]["IsLocked"].ToString() == "True")
                    {
                        lblStatus.Text = "Posted";
                    }
                    else
                    {
                        lblStatus.Text = "Not Posted";
                    }
                }
                //dt.Columns["Catalog"].SetOrdinal(0);
                DGVInvoiceDetails.DataSource = dt;
                DGVInvoiceDetails.AutoGenerateColumns = true;
                DGVInvoiceDetails.AllowUserToAddRows = false;
                DGVInvoiceDetails.Columns["Date"].Visible = false;
                DGVInvoiceDetails.Columns["Paid By"].Visible = false;
                DGVInvoiceDetails.Columns["ItemID"].Visible = false;
                DGVInvoiceDetails.Columns["ID"].Visible = false;
                DGVInvoiceDetails.Columns["LaborID"].Visible = false;
                DGVInvoiceDetails.Columns["FeeID"].Visible = false;
                DGVInvoiceDetails.Columns["Ctype"].Visible = false;
                DGVInvoiceDetails.Columns["Group"].Visible = false;

                DGVInvoiceDetails.Columns["Catalog"].DisplayIndex = 0;
                DGVInvoiceDetails.Columns["Description"].DisplayIndex = 1;
                DGVInvoiceDetails.Columns["Hours"].DisplayIndex = 2;
                DGVInvoiceDetails.Columns["Cost"].DisplayIndex = 3;
                DGVInvoiceDetails.Columns["Qty"].DisplayIndex = 4;

                DGVInvoiceDetails.Columns["Description"].Width = 200;
                DGVInvoiceDetails.Columns["Hours"].Width = 40;
                DGVInvoiceDetails.Columns["Cost"].Width = 60;
                DGVInvoiceDetails.Columns["Qty"].Width = 30;
                DGVInvoiceDetails.Columns["Margin"].Width = 40;
                DGVInvoiceDetails.Columns["Discount"].Width = 40;
                DGVInvoiceDetails.Columns["Price"].Width = 60;
                DGVInvoiceDetails.Columns["Amount"].Width = 60;
                DGVInvoiceDetails.Columns["FET"].Width = 40;
                DGVInvoiceDetails.Columns["Tax"].Width = 40;
                decimal GTotal = 0;
                decimal GAmount = 0;
                decimal GProfit = 0;
                decimal GMargin = 0;
                decimal GMarkup = 0;

                for (int i=0; i<dt.Rows.Count; i++)
                {
                    GTotal += Convert.ToDecimal(dt.Rows[i]["Total"]);
                    GAmount += Convert.ToDecimal(dt.Rows[i]["Cost"]) * Convert.ToDecimal(dt.Rows[i]["Qty"]);
                    //GProfit += Convert.ToDecimal(dt.Rows[i]["Profit"]);
                    //GMargin += Convert.ToDecimal(dt.Rows[i]["Margin"]);
                    //GMarkup += Convert.ToDecimal(dt.Rows[i]["Markup"]);
                }
                txtGTotal.Text = "$"+ GTotal.ToString();
                txtGAmount.Text = "$" + GAmount.ToString();
                txtGProfit.Text = "$" + GProfit.ToString();
                txtGMargin.Text = "$" + GMargin.ToString();
                txtGMarkup.Text = "$" + GMarkup.ToString();
            }
            catch(Exception ex)
            {
                xMessageBox.Show(ex.Message);
            }
        }
    }
}
