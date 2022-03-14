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
    public delegate void SelectedInspectionItemsDelegate(object sender, DataTable dataTable);
    public partial class ctrVehicleInspectionItems : UserControl
    {

        public event SelectedInspectionItemsDelegate SelectedInspectionItems;
        public ctrVehicleInspectionItems()
        {
            InitializeComponent();

            this.Load += ctrVehicleInspectionItems_Load;

            this.TDataGridView.DataError += TDataGridView_DataError;
            this.TDataGridView.CellPainting += TDataGridView_CellPainting;
            this.TDataGridView.CellClick += TDataGridView_CellClick;
                        
            this.btnClose.Click += btnClose_Click;
            this.btnAddItems.Click += btnAddItems_Click;
            this.btnUnCheckAll.Click += btnUnCheckAll_Click;
        }
                
        void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TDataGridView.Rows)
            {
                bool IsRepair = Convert.ToBoolean(row.Cells["IsRepair"].Value);
                bool IsChange = Convert.ToBoolean(row.Cells["IsChange"].Value);
                if (IsRepair)
                    row.Cells["IsRepair"].Value = false;
                if (IsChange)
                    row.Cells["IsChange"].Value = false;
            }
        }
        void btnAddItems_Click(object sender, EventArgs e)
        {
            string Qry = "SELECT sec.[ID] [InspectionHeadID],fst.AccName [Catalog] ,sec.[AccName] [CategoryItem],[VID].[IsRepair] ,[VID].[IsChange] ,[VID].[IsAccept] ,[VID].[IsDecline] ,[VID].[IsIgnore] ,[VID].[Notes] ,ISNULL([VID].[ItemPrice],0) [ItemPrice] ,ISNULL([VID].[LaborPrice],0) [LaborPrice] ,ISNULL([VID].[FeePrice],0) [FeePrice] ,ISNULL([VID].[TotalPrice],0) [TotalPrice] FROM [dbo].[InspectionHeads] sec LEFT JOIN [dbo].[InspectionHeads] fst ON sec.AccTypeID = fst.AccID LEFT JOIN [dbo].[VehicleInspectionDetail] [VID] ON [VID].[InspectionHeadID] = sec.[ID] LEFT JOIN [dbo].[VehicleInspection] [VI] ON [VI].ID = [VID].[MID] WHERE sec.AccLevel = 1 and [VID].ID = 0";
            DataTable dataTable = new DataTable();
            dataTable = dbClass.obj.FillByQry(dataTable, Qry);
            
            foreach (DataGridViewRow row in TDataGridView.Rows)
            {
                bool IsRepair = Convert.ToBoolean(row.Cells["IsRepair"].Value);
                bool IsChange = Convert.ToBoolean(row.Cells["IsChange"].Value);
                if (IsRepair == true || IsChange == true)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["InspectionHeadID"] = Convert.ToInt32(row.Cells["ID"].Value);
                    int accTypeID = Convert.ToInt32(row.Cells["AccTypeID"].Value);
                    dataRow["Catalog"] = dbClass.obj.getInspectionHead(accTypeID);                        
                    dataRow["CategoryItem"] = Convert.ToString(row.Cells["Description"].Value);
                    dataRow["IsRepair"] = IsRepair;
                    dataRow["IsChange"] = IsChange;                    
                    dataTable.Rows.Add(dataRow);
                }                
            }

            try
            {
                if (SelectedInspectionItems != null)
                    SelectedInspectionItems(this, dataTable);

                this.Parent.Dispose();
            }
            catch { }
        }
        void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        void TDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DataGridViewCheckBoxCell cell5 = (DataGridViewCheckBoxCell)TDataGridView.Rows[e.RowIndex].Cells[5];
                cell5.Value = true;
                DataGridViewCheckBoxCell cell6 = (DataGridViewCheckBoxCell)TDataGridView.Rows[e.RowIndex].Cells[6];
                cell6.Value = false;
            }
            if (e.ColumnIndex == 6)
            {
                DataGridViewCheckBoxCell cell5 = (DataGridViewCheckBoxCell)TDataGridView.Rows[e.RowIndex].Cells[5];
                cell5.Value = false;
                DataGridViewCheckBoxCell cell6 = (DataGridViewCheckBoxCell)TDataGridView.Rows[e.RowIndex].Cells[6];
                cell6.Value = true;
            }
            if (TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {                
                if (TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "-")
                {
                    int PID = Convert.ToInt32(TDataGridView.Rows[e.RowIndex].Cells[0].Value);
                    foreach (DataGridViewRow row in TDataGridView.Rows)
                    {
                        int accTypeID = Convert.ToInt32(row.Cells["AccTypeID"].Value);
                        if (accTypeID == PID)
                            row.Visible = false;
                    }

                    TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "+";
                }
                else if (TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "+")
                {
                    int PID = Convert.ToInt32(TDataGridView.Rows[e.RowIndex].Cells[0].Value);
                    foreach (DataGridViewRow row in TDataGridView.Rows)
                    {
                        int accTypeID = Convert.ToInt32(row.Cells["AccTypeID"].Value);
                        if (accTypeID == PID)
                            row.Visible = true;
                    }

                    TDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                }

            }
        }
        void TDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (TDataGridView.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    if (Convert.ToInt32(TDataGridView.Rows[e.RowIndex].Cells[3].Value) == 0)
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                    if ((Convert.ToInt32(TDataGridView.Rows[e.RowIndex].Cells[3].Value) >= 1) && (e.ColumnIndex == 2))                    
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;                        
                    
                    if ((Convert.ToInt32(TDataGridView.Rows[e.RowIndex].Cells[3].Value) >= 1) && ((e.ColumnIndex == 5) || (e.ColumnIndex == 6)))
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
        }        
        void TDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch { }
        }
        void ctrVehicleInspectionItems_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void LoadGrid()
        {
            //----------------------------------------------------------------//
            DataGridViewTextBoxColumn gridColID = new DataGridViewTextBoxColumn();
            gridColID.Name = "ID";
            gridColID.Visible = false;
            TDataGridView.Columns.Add(gridColID);

            DataGridViewTextBoxColumn gridColbtn = new DataGridViewTextBoxColumn();
            gridColbtn.Name = "ShowHide";
            gridColbtn.Width = 23;
            TDataGridView.Columns.Add(gridColbtn);

            DataGridViewTextBoxColumn gridColCategory = new DataGridViewTextBoxColumn();
            gridColCategory.Name = "Category";
            gridColCategory.HeaderText = "Category";
            gridColCategory.ReadOnly = true;
            TDataGridView.Columns.Add(gridColCategory);

            DataGridViewTextBoxColumn gridColAccTypeID = new DataGridViewTextBoxColumn();
            gridColAccTypeID.Name = "AccTypeID";
            gridColAccTypeID.Visible = false;
            TDataGridView.Columns.Add(gridColAccTypeID);

            DataGridViewTextBoxColumn gridColDescription = new DataGridViewTextBoxColumn();
            gridColDescription.Name = "Description";
            gridColDescription.HeaderText = "Description";
            gridColDescription.Width = 200;
            gridColDescription.ReadOnly = true;
            TDataGridView.Columns.Add(gridColDescription);

            DataGridViewTextBoxColumn gridColIsRepair = new DataGridViewTextBoxColumn();
            gridColIsRepair.Name = "IsRepair";
            gridColIsRepair.HeaderText = "Repair";
            gridColIsRepair.Width = 30;
            TDataGridView.Columns.Add(gridColIsRepair);

            DataGridViewTextBoxColumn gridColIsChange = new DataGridViewTextBoxColumn();
            gridColIsChange.Name = "IsChange";
            gridColIsChange.HeaderText = "Change";
            gridColIsChange.Width = 30;
            TDataGridView.Columns.Add(gridColIsChange);
            //---------------------------------------------------------------//
            DataTable dt = dbClass.obj.getInspectionHeads(0);
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow row1 = new DataGridViewRow();

                DataGridViewTextBoxCell gridCell01 = new DataGridViewTextBoxCell();
                gridCell01.Value = Convert.ToInt32(dr["ID"]);

                DataGridViewButtonCell gridCell02 = new DataGridViewButtonCell();
                gridCell02.Value = "-";
                gridCell02.Style.Padding = new Padding(1);

                DataGridViewTextBoxCell gridCell03 = new DataGridViewTextBoxCell();
                gridCell03.Value = Convert.ToString(dr["Catalog"]);

                DataGridViewTextBoxCell gridCell04 = new DataGridViewTextBoxCell();
                gridCell04.Value = Convert.ToInt32(dr["AccTypeID"]);

                DataGridViewTextBoxCell gridCell05 = new DataGridViewTextBoxCell();

                DataGridViewTextBoxCell gridCell06 = new DataGridViewTextBoxCell();

                DataGridViewTextBoxCell gridCell07 = new DataGridViewTextBoxCell();

                row1.Cells.AddRange(new DataGridViewCell[] { gridCell01, gridCell02, gridCell03, gridCell04, gridCell05, gridCell06, gridCell07 });
                TDataGridView.Rows.Add(row1);
                //---------------------------------------------------------------//
                DataTable dt1 = dbClass.obj.getInspectionHeads(Convert.ToInt32(dr["ID"]));
                foreach (DataRow dr1 in dt1.Rows)
                {
                    DataGridViewRow row11 = new DataGridViewRow();

                    DataGridViewTextBoxCell gridCell11 = new DataGridViewTextBoxCell();
                    gridCell11.Value = Convert.ToInt32(dr1["ID"]);

                    DataGridViewTextBoxCell gridCell12 = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell gridCell13 = new DataGridViewTextBoxCell();
                    
                    DataGridViewTextBoxCell gridCell14 = new DataGridViewTextBoxCell();
                    gridCell14.Value = Convert.ToInt32(dr1["AccTypeID"]);

                    DataGridViewTextBoxCell gridCell15 = new DataGridViewTextBoxCell();
                    gridCell15.Value = Convert.ToString(dr1["CategoryItem"]);
                    
                    DataGridViewCheckBoxCell gridCell16 = new DataGridViewCheckBoxCell();
                    gridCell16.Style.Padding = new Padding(5, 0, 0, 0);

                    DataGridViewCheckBoxCell gridCell17 = new DataGridViewCheckBoxCell();
                    gridCell17.Style.Padding = new Padding(5, 0, 0, 0);

                    row11.Cells.AddRange(new DataGridViewCell[] { gridCell11, gridCell12, gridCell13, gridCell14, gridCell15, gridCell16, gridCell17 });
                    TDataGridView.Rows.Add(row11);
                }
                //---------------------------------------------------------------//
            }
            //---------------------------------------------------------------//
        }

    }

}
