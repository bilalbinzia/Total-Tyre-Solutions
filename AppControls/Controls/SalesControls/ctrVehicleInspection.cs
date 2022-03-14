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
    public delegate void SelectVehicleInspectionDetailDelegate(object sender, DataTable dataTable);
    public partial class ctrVehicleInspection : BaseControl
    {
        public event SelectVehicleInspectionDetailDelegate SelectVehicleInspectionDetail;
        int WorkOrderID = 0, VehicleID = 0, CustID = 0;
        DataRowView drv;
        public ctrVehicleInspection()
        {
            InitializeComponent();
        }
        public ctrVehicleInspection(DataRowView drv)
        {
            InitializeComponent();
            //this.DGVInspactionDetail.xTableQuery = dbClass.obj.DGVInspactionDetailQry();

            this.WorkOrderID = Convert.ToInt32(drv["ID"]);
            this.VehicleID = Convert.ToInt32(drv["VehicleID"]);
            this.CustID = Convert.ToInt32(drv["CustomerID"]);
            this.drv = drv;

            this.Load += ctrVehicleInspection_Load;
            this.btnInspectionItems.Click += btnInspectionItems_Click;
            this.DGVInspactionDetail.CellPainting += DGVInspactionDetail_CellPainting;
            this.DGVInspactionDetail.CellClick += DGVInspactionDetail_CellClick;
            this.DGVInspactionDetail.CellEndEdit += DGVInspactionDetail_CellEndEdit;

            this.btnAddServices.Click += btnAddServices_Click;
            this.btnPrintCustomerCopy.Click += btnPrintCustomerCopy_Click;
            this.btnPrintMechanicCopy.Click += btnPrintMechanicCopy_Click;
        }

        void btnPrintMechanicCopy_Click(object sender, EventArgs e)
        {
            
        }
        void btnPrintCustomerCopy_Click(object sender, EventArgs e)
        {
            
        }
        void btnAddServices_Click(object sender, EventArgs e)
        {
            DataTable dataTable = objDataSet.Tables[DGVInspactionDetail.xTableName].Copy();            
            try
            {
                if (SelectVehicleInspectionDetail != null)
                    SelectVehicleInspectionDetail(this, dataTable);

                this.Parent.Dispose();
            }
            catch { }
        }
        void DGVInspactionDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            libDataGridView DGV = (libDataGridView)sender;
            DataRowView curRow = (DataRowView)DGV.objBindingSource.Current;
            string DGVColumnName = DGV.Columns[e.ColumnIndex].Name;

            curRow.BeginEdit();
            if (DGVColumnName.Equals("ItemPrice") || DGVColumnName.Equals("LaborPrice") || DGVColumnName.Equals("FeePrice") )
            {
                curRow["TotalPrice"] = Math.Round(Convert.ToInt32(curRow["ItemPrice"]) + Convert.ToDecimal(curRow["LaborPrice"]) + Convert.ToDecimal(curRow["FeePrice"]), 2);
            }
            curRow.EndEdit();
            //-------------------//
            CalculatColumns();
        }
        void CalculatColumns()
        {
            //-------------------------------------------------------------            
            decimal ItemPrice = 0, LaborPrice = 0, FeePrice = 0;
            foreach (DataGridViewRow n in DGVInspactionDetail.Rows)
            {
                { if (n.Cells["ItemPrice"].Value != null) { ItemPrice += Convert.ToDecimal(n.Cells["ItemPrice"].Value); } }
                { if (n.Cells["LaborPrice"].Value != null) { LaborPrice += Convert.ToDecimal(n.Cells["LaborPrice"].Value); } }
                { if (n.Cells["FeePrice"].Value != null) { FeePrice += Convert.ToDecimal(n.Cells["FeePrice"].Value); } }
                
            }

            //-------------------------------------------------------------
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            curRow.BeginEdit();

            curRow["TotalParts"] = ItemPrice;
            curRow["TotalLabor"] = LaborPrice;
            curRow["TotalFees"] = FeePrice;
            curRow["TotalTax"] = 0;
            curRow["TotalAmount"] = (ItemPrice + LaborPrice + FeePrice);
            curRow.EndEdit();            
            //------------------------------
        }
        void DGVInspactionDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewCheckBoxCell cell4 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[4];
                cell4.Value = true;
                DataGridViewCheckBoxCell cell5 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[5];
                cell5.Value = false;
            }
            if (e.ColumnIndex == 5)
            {
                DataGridViewCheckBoxCell cell4 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[4];
                cell4.Value = false;
                DataGridViewCheckBoxCell cell5 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[5];
                cell5.Value = true;
            }
            if (e.ColumnIndex == 6)
            {
                DataGridViewCheckBoxCell cell6 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[6];
                cell6.Value = true;
                DataGridViewCheckBoxCell cell7 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[7];
                cell7.Value = false;
                DataGridViewCheckBoxCell cell8 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[8];
                cell8.Value = false;
            }
            if (e.ColumnIndex == 7)
            {
                DataGridViewCheckBoxCell cell6 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[6];
                cell6.Value = false;
                DataGridViewCheckBoxCell cell7 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[7];
                cell7.Value = true;
                DataGridViewCheckBoxCell cell8 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[8];
                cell8.Value = false;
            }
            if (e.ColumnIndex == 8)
            {
                DataGridViewCheckBoxCell cell6 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[6];
                cell6.Value = false;
                DataGridViewCheckBoxCell cell7 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[7];
                cell7.Value = false;
                DataGridViewCheckBoxCell cell8 = (DataGridViewCheckBoxCell)DGVInspactionDetail.Rows[e.RowIndex].Cells[8];
                cell8.Value = true;
            }
        }
        void DGVInspactionDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (((e.ColumnIndex == 4) || (e.ColumnIndex == 5) || (e.ColumnIndex == 6) || (e.ColumnIndex == 7) || (e.ColumnIndex == 8)))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    Rectangle rectRadioButton = new Rectangle();

                    rectRadioButton.Width = 14;
                    rectRadioButton.Height = 14;
                    rectRadioButton.X = e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2;
                    rectRadioButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2;

                    ButtonState buttonState;
                    try
                    {
                        if (e.Value == DBNull.Value || (bool)(e.Value) == false)
                            buttonState = ButtonState.Normal;
                        else
                            buttonState = ButtonState.Checked;


                    }
                    catch { buttonState = ButtonState.Normal; }

                    ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, buttonState);
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);
                    e.Handled = true;
                }
            }
        }
        void btnInspectionItems_Click(object sender, EventArgs e)
        {
            ctrVehicleInspectionItems objList = new ctrVehicleInspectionItems();
            objList.SelectedInspectionItems += objList_SelectedInspectionItems;
            //----------------------------------------------------------------------//
            frmCtr frmCtr = new frmCtr("Inspected Items ...");            
            frmCtr.Height = objList.Height + 40; frmCtr.Width = objList.Width + 20;
            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frmCtr.frmPnl.Controls.Add(objList);
            frmCtr.BringToFront();
            frmCtr.ShowDialog();
        }
        void objList_SelectedInspectionItems(object sender, DataTable dataTable)
        {
            try
            {
                if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            DataRowView newItemRow = (DataRowView)DGVInspactionDetail.objBindingSource.AddNew();
                            newItemRow.BeginEdit();
                            newItemRow["InspectionHeadID"] = dataRow["InspectionHeadID"];
                            newItemRow["Catalog"] = dataRow["Catalog"];
                            newItemRow["CategoryItem"] = dataRow["CategoryItem"];

                            newItemRow["IsRepair"] = dataRow["IsRepair"];
                            newItemRow["IsChange"] = dataRow["IsChange"];

                            newItemRow["IsAccept"] = true;
                            newItemRow["IsDecline"] = false;
                            newItemRow["IsIgnore"] = false;

                            newItemRow["Notes"] = "";

                            newItemRow["ItemPrice"] = 0;
                            newItemRow["LaborPrice"] = 0;
                            newItemRow["FeePrice"] = 0;
                            newItemRow["TotalPrice"] = 0;

                            newItemRow["Active"] = true;
                            newItemRow["AddDate"] = DateTime.Now;
                            newItemRow["AddUserID"] = StaticInfo.userid;
                            newItemRow["IsLocked"] = false;
                            newItemRow.EndEdit();
                        }
                    }
                }
            }
            catch { }
        }
        void ctrVehicleInspection_Load(object sender, EventArgs e)
        {
            if (dbClass.obj.IsExistWorkOrderInVehicleInspection(this.WorkOrderID))
            {
                //int index = objBindingSource.Find("WorkOrderID", this.WorkOrderID);
                //this.objBindingSource.Position = index;

                //bindingNavigatorEditItem_Click(sender, e);
                int VehicleInspectionID = dbClass.obj.getID(objDataSet.Tables[this.xTableName], "WorkOrderID",this.WorkOrderID);
                dbClass.obj.fillTablesByID(objDataSet.Tables[this.xTableName], objDataSet.Tables[this.DGVInspactionDetail.xTableName], this.DGVInspactionDetail.xTableQuery, VehicleInspectionID);
                //-----------------------------------------------------------//
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                if (Convert.ToInt32(curRow["CustomerID"]) > 0)
                    ctrCustomerID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrCustomerID.xTableName].Copy(), Convert.ToInt32(curRow["CustomerID"]));
                if (Convert.ToInt32(curRow["VehicleID"]) > 0)
                {
                    DataRow VehicleRow = dbClass.obj.FillVehicleID(VehicleID);
                    if (VehicleRow != null)
                    {
                        string VehicleYearMakeModel = Convert.ToString(VehicleRow["Year"]) + " - " + Convert.ToString(VehicleRow["Make"]) + " - " + Convert.ToString(VehicleRow["Model"]);
                        ctrVehicleYearMakeModel.Text = Convert.ToString(VehicleYearMakeModel);
                        ctrVIN.Text = Convert.ToString(VehicleRow["VIN"]);
                        ctrLicensePlate.Text = Convert.ToString(VehicleRow["LicensePlate"]);
                    }
                }
                //-----------------------------------------------------------//
            }
            else
            {
                this.objBindingSource.AddNew();
                base.bindingNavigatorAddNewItem_Click(sender, e);
                //----------------------------------------------------------------//
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                curRow["CustomerID"] = drv["CustomerID"];
                curRow["WorkOrderID"] = drv["ID"];
                curRow["WorkOrderNo"] = drv["WorkOrderNo"];
                curRow["VehicleID"] = drv["VehicleID"];
                curRow.EndEdit();

                if (Convert.ToInt32(curRow["CustomerID"]) > 0)
                    ctrCustomerID.DataSource = dbClass.obj.FillByID(objDataSet.Tables[ctrCustomerID.xTableName].Copy(), Convert.ToInt32(curRow["CustomerID"]));

                if (Convert.ToInt32(curRow["VehicleID"]) > 0)
                {
                    DataRow VehicleRow = dbClass.obj.FillVehicleID(VehicleID);
                    if (VehicleRow != null)
                    {
                        string VehicleYearMakeModel = Convert.ToString(VehicleRow["Year"]) + " - " + Convert.ToString(VehicleRow["Make"]) + " - " + Convert.ToString(VehicleRow["Model"]);
                        ctrVehicleYearMakeModel.Text = Convert.ToString(VehicleYearMakeModel);
                        ctrVIN.Text = Convert.ToString(VehicleRow["VIN"]);
                        ctrLicensePlate.Text = Convert.ToString(VehicleRow["LicensePlate"]);
                    }
                }
                //----------------------------------------------------------------//
            }
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataRowView curRow = (DataRowView)objBindingSource.Current;
            if (Convert.ToDecimal(curRow["TotalAmount"]) <= 0)
            {
                xMessageBox.Show("Set item Prices ...");
                return;
            }
            else
            {
                base.bindingNavigatorSaveItem_Click(sender, e);
            }           
        }

    }

}
