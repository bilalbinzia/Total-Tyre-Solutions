using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System32;

namespace ControlLibrary
{
    public class libDataGridView : DataGridView
    {
        private MainDataSet objDataSet = null;
        public BindingSource objBindingSource = null;

        private MessageBox xMessageBox = null;
        private ErrorProvider errorProvider1;

        private System.ComponentModel.IContainer components = null;
        static List<string> tableList = new List<string>();

        private DataGridViewCellStyle DateColumnCellStyle;
        private DataGridViewCellStyle TimeColumnCellStyle;
        private DataGridViewCellStyle DecimalColumnCellStyle;
        private DataGridViewCellStyle NumberColumnCellStyle;


        private bool isAutoNo = true;
        public bool xIsAutoNo
        {
            get { return isAutoNo; }
            set { isAutoNo = value; }
        }

        private bool deleteColumn = true;
        public bool xIsDeleteColumn
        {
            get { return deleteColumn; }
            set { deleteColumn = value; }
        }

        private string tableName;
        public string xTableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        private string tableRelation;
        public string xTableRelation
        {
            get { return tableRelation; }
            set { tableRelation = value; }
        }
        private string tableQuery;
        public string xTableQuery
        {
            get { return tableQuery; }
            set { tableQuery = value; }
        }
        private string orderBy;
        public string xOrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }
        public libDataGridView()
        {
            InitializeComponent();
            xMessageBox = new MessageBox();
        }

        public void SetSource(BindingSource bindingSource, DataTable dataTable, string tblRelation)
        {
            this.AutoGenerateColumns = false;
            this.objBindingSource = new BindingSource();

            this.objBindingSource.DataMember = tblRelation;
            this.objBindingSource.DataSource = bindingSource;
            this.DataSource = this.objBindingSource;
            this.objDataSet = new MainDataSet();

        }
        public void SetSource(BindingSource bindingSource)
        {
            this.AutoGenerateColumns = false;
            this.objBindingSource = new BindingSource();

            this.objBindingSource.DataMember = this.xTableRelation;
            this.objBindingSource.DataSource = bindingSource;
            this.DataSource = this.objBindingSource;
            this.objDataSet = new MainDataSet();

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // libDataGridView
            // 
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AutoGenerateColumns = false;
            this.BackgroundColor = System.Drawing.Color.White;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridColor = System.Drawing.Color.White;
            this.Name = "libDataGrid";
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.RowTemplate.DefaultHeaderCellType = typeof(ControlLibrary.CustomHeaderCell);
            this.ShowRowErrors = false;
            this.VirtualMode = true;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
            this.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            this.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellEndEdit);
            this.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellValueChanged);
            this.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGrid_CellValueNeeded);
            this.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGrid_DataError);
            this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGrid_EditingControlShowing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.Leave += new System.EventHandler(this.OnLeave);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        //protected override void OnGotFocus(EventArgs e)
        //{
        //    //MessageBox.Show("OnGotFocus");
        //    try
        //    {
        //        if (CurrentCell.OwningColumn.Name == "DelColumn")
        //        {
        //            base.ProcessTabKey(Keys.Tab);
        //            base.ProcessTabKey(Keys.Tab);
        //        }
        //        if (CurrentCell.OwningColumn.Name == "AutoNoColumn")
        //        {
        //            base.ProcessTabKey(Keys.Tab);
        //            //base.ProcessTabKey(Keys.Tab);
        //        }
        //    }
        //    catch { }
        //}
        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {
                if (keyData == Keys.Enter)
                {
                    base.ProcessTabKey(Keys.Tab);
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
            catch { return base.ProcessDialogKey(keyData); }
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        { //(CurrentCell.ColumnIndex == 1) //CurrentCell.OwningColumn.Name == "x"
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (CurrentCell.ColumnIndex == Columns.Count - 1)
                    {
                        base.ProcessTabKey(Keys.Tab);
                        base.ProcessTabKey(Keys.Tab);
                    }
                    if (CurrentCell.OwningColumn.Name == "IssDate")
                    {
                        base.ProcessTabKey(Keys.Tab);
                        base.ProcessTabKey(Keys.Tab);
                    }
                    else
                    {
                        base.ProcessTabKey(Keys.Tab);
                    }
                    return true;
                }
                catch { return false; }
            }
            return base.ProcessDataGridViewKey(e);
        }
        void libDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Rows[e.RowIndex].Cells.Count; i++)
                {
                    this[i, e.RowIndex].Style.BackColor = Color.Empty;  
                }
            }
            catch { }
        }
        void libDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int row = this.CurrentRow.Index-1;
                //int recid = Convert.ToInt32(this[1, row].Value);
                //this[1, CurrentRow.Index].Value = recid;

                //if (this.CurrentRow.Index > -1)
                //{
                //    for (int i = 0; i < this.Rows[row].Cells.Count; i++)
                //    {
                //        this[i, row].Style.BackColor = Color.LightGray;
                //    }
                //}
            }
            catch { }
        }
        //private void DataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        //if (this.Columns[e.ColumnIndex].Tag.ToString() == "DecimalColumn")
        //        //{
        //        //    if (e.Value != null)
        //        //    {
        //        //        try
        //        //        {
        //        //            //string CurrencySymbol = "$. {0:F2}";
        //        //            //string CurrencySymbol = "$.{0:F2}";
        //        //            string CurrencySymbol = "$.{0:F2}";
        //        //            //string CurrencySymbol = "{0:F2} .$";
        //        //            e.Value = String.Format(CurrencySymbol, e.Value);
        //        //            e.FormattingApplied = true;
        //        //        }
        //        //        catch (FormatException)
        //        //        {
        //        //            e.FormattingApplied = false;
        //        //        }
        //        //    }
        //        //}
        //    }
        //    catch { }
        //}
        //private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //try
        //    //{
        //    //    int index = Convert.ToInt32(this.CurrentCell.ColumnIndex);
        //    //    string dataPropertyName = this.Columns[index].DataPropertyName.ToString();
        //    //    switch (dataPropertyName)
        //    //    {                    
        //    //        case "ID":
        //    //            Load_CellClick(index, this.objBindingSource, this._datatable, dataPropertyName);
        //    //            break;
        //    //        case "CardNo":
        //    //            Load_CellClick(index, this.objBindingSource, this._datatable, dataPropertyName);
        //    //            break;
        //    //    }
        //    //}
        //    //catch { }
        //}
        //protected void ColumnValueChanged(DataColumnChangeEventArgs e)
        //{
        //    if (e.Column.AllowDBNull == false)
        //        e.Row.SetColumnError(e.Column, e.ProposedValue == null || e.ProposedValue.ToString().Length == 0 ? e.Column.Caption + " is mandatory field" : "");
        //}
        public void SetSource(BindingSource bindingSource, DataTable dataTable)
        {
            this.AutoGenerateColumns = false;
            //this._datatable = dataTable;
            this.DataSource = bindingSource;
            this.objBindingSource = bindingSource;
        }
        private void DataGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (isAutoNo)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex > 1)
                        e.Value = e.RowIndex + 1;
                    //try
                    //{
                    //    int recid = 0;
                    //    try { recid = Convert.ToInt32(this.Rows[e.RowIndex - 1].Cells[1].Value); }
                    //    catch { }
                    //    DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                    //    curRow.BeginEdit();
                    //    curRow["RecID"] = recid + 1;
                    //    curRow.EndEdit();
                    //}
                    //catch { }
                }
            }
        }
        private void DataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DGVComboBoxCell DGVCB = (DGVComboBoxCell)this.Rows[e.RowIndex].Cells[1];
                if (DGVCB.Value != null)
                {
                    // do stuff
                    //dataGridView1.Invalidate();
                }
            }
            catch { }
        }
        private void DataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if ((e.Exception).Message.Equals("String was not recognized as a valid DateTime."))
                {
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                    e.Cancel = false;
                }
                if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
                {
                    if ((e.Exception).Message.Equals("String was not recognized as a valid DateTime."))
                    {
                        this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }
            }
            catch { }
        }
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (((libDataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DGVMCComboBoxColumn))
                //{
                //    (((DGVMCComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).DataSource = dbClass.obj.FillByQryByActive(this.objDataSet.Tables[((DGVMCComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xTableName].Copy(), ((DGVMCComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xBindingQuery, ((DGVMCComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xOrderBy);
                //}
                //else if (((libDataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DGVComboBoxColumn))
                //{
                //    (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).DataSource = dbClass.obj.FillByQryByActive(this.objDataSet.Tables[((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xTableName].Copy(), ((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xBindingQuery, ((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex]).xOrderBy);
                //    (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).DataPropertyName = (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).xBindingProperty;
                //    (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).DisplayMember = (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).xDisplayMember;
                //    (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).ValueMember = (((DGVComboBoxColumn)((libDataGridView)sender).Columns[e.ColumnIndex])).xValueMember;
                //}
                //else
                //{
                if (((libDataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(ControlLibrary.DGVCheckBoxColumn))
                {
                    if (((libDataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")                    
                        ((libDataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    else
                        ((libDataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;

                    ((libDataGridView)sender).EndEdit();
                }   
                else
                {
                    try
                    {
                        int index = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                        string columnType = "";
                        if(this.Columns[index].Tag!=null)
                        {
                            columnType = this.Columns[index].Tag.ToString();
                            switch (columnType)
                            {
                                case "DelColumn":
                                    this.Delete_CellClick(index, this.objBindingSource, this.objDataSet.Tables[this.xTableName]);
                                    break;
                                case "":
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch  {   }
        }
        //private void Load_CellClick(int index, BindingSource bindingSource, DataTable dataTable, string option)
        //{
        //    //try
        //    //{
        //    //    DataRowView curRow = (DataRowView)objBindingSource.Current;
        //    //    if (dataTable.TableName == "Query")
        //    //    {
        //    //        switch(option)
        //    //        {
        //    //            case "CardNo":
        //    //                int iCardNo = Convert.ToInt32(curRow["CardNo"]);
        //    //                break;
        //    //            case "ID":
        //    //                int iID = Convert.ToInt32(curRow["ID"]);
        //    //                break;
        //    //        }
        //    //    }
        //    //}
        //    //catch { }
        //}        
        private void Delete_CellClick(int index, BindingSource bindingSource, DataTable dataTable)
        {
            try
            {
                if ((dataTable.TableName != "WorkOrderDetail") && (dataTable.TableName != "PurchaseOrderDetails"))
                {
                    if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int pos = bindingSource.Position;
                        bindingSource.Remove(bindingSource.Current);
                        bindingSource.EndEdit();
                    }
                }
            }
            catch { }
        }
        //void Delete(int index, BindingSource bindingSource, DataTable dataTable)
        //{
        //    try
        //    {
        //        if (dataTable.TableName != "CurrencyDenomination")
        //        {
        //            if (xMessageBox.Show("Do you want to delete this record..?", "Confirmation", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                int pos = bindingSource.Position;
        //                bindingSource.Remove(bindingSource.Current);
        //                bindingSource.EndEdit();
        //            }
        //        }
        //    }
        //    catch { }
        //}
        private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                curRow.BeginEdit();

                if (curRow["Active"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(curRow["Active"]) == true)
                    {
                        curRow["ModifyDate"] = DateTime.Now;
                        curRow["ModifyUserID"] = StaticInfo.userid;
                    }
                }
                else
                {
                    curRow["Active"] = true;
                    curRow["AddDate"] = DateTime.Now;
                    curRow["AddUserID"] = StaticInfo.userid;
                    curRow["IsLocked"] = false;
                }                
                curRow.EndEdit();
            }
            catch { }

            //SendKeys.Send("{TAB}");
            //SendKeys.Send("{up}");
            //SendKeys.Send("{right}");
            //if (this.CurrentCell.ColumnIndex < this.ColumnCount - 1)
            //{
            //    int col = this.CurrentCell.ColumnIndex + 1;
            //    int row = this.CurrentCell.RowIndex;
            //    this.CurrentCell = this[col, row];
            //}
            //if (this.ColumnCount - 1 == e.ColumnIndex)  //if last column
            //{
            //    KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
            //    notlastColumn = false;
            //    dataGridView1_KeyDown(this, forKeyDown);
            //}
            //else
            //{
            //    SendKeys.Send("{up}");
            //    SendKeys.Send("{right}");
            //}
        }
        //void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Enter && notlastColumn) //if not last column move to nex
        //    //{
        //    //    //SendKeys.Send("{up}");
        //    //    SendKeys.Send("{right}");
        //    //}
        //    //else 
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SendKeys.Send("{home}");//go to first column
        //        //notlastColumn = true;
        //    }
        //}
        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).EndEdit();
        }
        private void DataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumberColumn_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(DecimalColumn_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(TimeColumn_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(DateColumn_KeyPress);
                //String columnName = this.DataGVTicketSale.Columns[e.ColumnIndex].Name;
                int index = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                //string columnType = this.Columns[index].Tag.ToString();   
                StaticInfo.gColumnType columnType = ((DGVTextBoxColumn)this.Columns[index]).xColumnType;
                switch (columnType)
                {
                    case StaticInfo.gColumnType.DecimalColumn:
                        TextBox Dtb = e.Control as TextBox;
                        if (Dtb != null) { Dtb.KeyPress += new KeyPressEventHandler(DecimalColumn_KeyPress); Dtb.KeyUp += new KeyEventHandler(DecimalColumn_KeyUp); }
                        break;
                    case StaticInfo.gColumnType.NumberColumn:
                        TextBox Ntb = e.Control as TextBox;
                        if (Ntb != null) { Ntb.KeyPress += new KeyPressEventHandler(NumberColumn_KeyPress); Ntb.KeyUp += new KeyEventHandler(NumberColumn_KeyUp); }
                        break;
                    case StaticInfo.gColumnType.TimeColumn:
                        TextBox Ttb = e.Control as TextBox;
                        if (Ttb != null) { Ttb.KeyPress += new KeyPressEventHandler(TimeColumn_KeyPress); }
                        break;
                    case StaticInfo.gColumnType.DateColumn:
                        TextBox DateTxtBox = e.Control as TextBox;
                        if (DateTxtBox != null) { DateTxtBox.KeyPress += new KeyPressEventHandler(DateColumn_KeyPress); }
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void TimeColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string tmp = string.Empty;
            string tmp2 = string.Empty;
            //if (Char.IsDigit(e.KeyChar) || e.KeyChar == ':' || e.KeyChar == 8)
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = tb.Text.Length;
                        if (len.Equals(0) || len.Equals(3))
                        {
                            tb.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        if (len.Equals(1) || len.Equals(4))
                        {
                            if (len.Equals(1))
                            {
                                tmp = tb.Text + e.KeyChar.ToString();
                                if (int.Parse(tmp) < 24)
                                {
                                    tb.AppendText(e.KeyChar.ToString());
                                    tb.AppendText(":");
                                    e.Handled = true;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            if (len.Equals(4))
                            {
                                tmp = tb.Text + e.KeyChar.ToString();
                                int indx = tmp.IndexOf(":");
                                tmp2 = tmp.Substring(indx + 1, 2);
                                if (int.Parse(tmp2) < 60)
                                {
                                    //tb.AppendText(e.KeyChar.ToString());
                                    //tb.AppendText(":");
                                    e.Handled = false;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                        }
                        if (len == 5)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (len == 8)
                        {
                            //tb.Text = (e.KeyChar.ToString());
                            e.Handled = false;
                        }
                        //if (len.Equals(7))
                        //{
                        //    tb.AppendText(e.KeyChar.ToString());
                        //    e.Handled = true;
                        //}
                    }
                }
            }
            //if (Char.IsDigit(e.KeyChar) || e.KeyChar == ':' || e.KeyChar == 8)
            //{
            //    //e.Handled = false;
            //    //errorProvider1.SetError(tb, "");
            //    int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
            //    int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
            //    this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "";
            //    e.Handled = false;
            //}
            //else
            //{
            //    //e.Handled = true;
            //    //errorProvider1.SetError(gridDecimaltb, "Only valid for Digit and dot.");
            //    int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
            //    int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
            //    this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "Only valid for Time formate";
            //    e.Handled = true;
            //}
        }
        private void DecimalColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
            {
                int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
                int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "";
                e.Handled = false;
            }
            else
            {
                int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
                int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "Only valid for Digit and dot.";
                e.Handled = true;
            }
        }
        private void NumberColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
                int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "";

                e.Handled = false;
            }
            else
            {
                int RowIndex = Convert.ToInt32(this.CurrentCell.RowIndex);
                int ColumnIndex = Convert.ToInt32(this.CurrentCell.ColumnIndex);
                this.Rows[RowIndex].Cells[ColumnIndex].ErrorText = "Only valid for Digit.";
                e.Handled = true;
            }
        }
        private void NumberColumn_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Int64 val = Convert.ToInt64(((System.Windows.Forms.TextBox)(sender)).Text.Trim());
                if (val <= 0)
                {
                    ((System.Windows.Forms.TextBox)(sender)).Text = "";
                    e.Handled = true;
                }
            }
            catch { }
        }
        private void DecimalColumn_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal val = Convert.ToDecimal(((System.Windows.Forms.TextBox)(sender)).Text.Trim());
                if (val < 0)
                {
                    ((System.Windows.Forms.TextBox)(sender)).Text = "";
                    e.Handled = true;
                }
            }
            catch { }
        }
        private void DateColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string tmp = string.Empty;
            string tmp2 = string.Empty;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = tb.Text.Length;
                        if (len.Equals(0) || len.Equals(3) || len.Equals(6))
                        {
                            tb.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        if (len.Equals(1) || len.Equals(4))
                        {
                            if (len.Equals(1))
                            {
                                tmp = this.Text + e.KeyChar.ToString();
                                if (int.Parse(tmp) < 32)
                                {
                                    tb.AppendText(e.KeyChar.ToString());
                                    tb.AppendText("/");
                                    e.Handled = true;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            if (len.Equals(4))
                            {
                                tmp = tb.Text + e.KeyChar.ToString();
                                int indx = tmp.IndexOf("/");
                                tmp2 = tmp.Substring(indx + 1, 2);
                                if (int.Parse(tmp2) < 13)
                                {
                                    tb.AppendText(e.KeyChar.ToString());
                                    tb.AppendText("/");
                                    e.Handled = true;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                        }
                        if (len.Equals(7))
                        {
                            tb.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        if (len > 7)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void OnLeave(object sender, EventArgs e)
        {
        }
        //private void DataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    //if (e.Value == "Save" && e.RowIndex >= 0)
        //    //{
        //    //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
        //    //    e.Graphics.DrawImage(global::ControlLibrary.Properties.Resources.Save, Convert.ToInt32((e.CellBounds.Width / 2) - (global::ControlLibrary.Properties.Resources.Save.Width / 2)) + e.CellBounds.X, Convert.ToInt32((e.CellBounds.Height / 2) - (global::ControlLibrary.Properties.Resources.Save.Height / 2)) + e.CellBounds.Y);
        //    //    e.Handled = true;
        //    //}
        //    //if (e.Value == "Print" && e.RowIndex >= 0)
        //    //{
        //    //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
        //    //    //e.Graphics.DrawImage(global::ControlLibrary.Properties.Resources.Print, Convert.ToInt32((e.CellBounds.Width / 2) - (global::ControlLibrary.Properties.Resources.Print.Width / 2)) + e.CellBounds.X, Convert.ToInt32((e.CellBounds.Height / 2) - (global::ControlLibrary.Properties.Resources.Print.Height / 2)) + e.CellBounds.Y);
        //    //    e.Handled = true;
        //    //}
        //    //if (e.Value == "Delete" && e.RowIndex >= 0)
        //    //{
        //    //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
        //    //    //e.Graphics.DrawImage(global::ControlLibrary.Properties.Resources.Delete, Convert.ToInt32((e.CellBounds.Width / 2) - (global::ControlLibrary.Properties.Resources.Delete.Width / 2)) + e.CellBounds.X, Convert.ToInt32((e.CellBounds.Height / 2) - (global::ControlLibrary.Properties.Resources.Delete.Height / 2)) + e.CellBounds.Y);
        //    //    e.Handled = true;
        //    //}
        //}
        //protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        //{
        //    base.OnEditingControlShowing(e);
        //}
        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            //base.OnCellContentClick(e);
            //this.EndEdit();
        }
        public void AddGridColumn(StaticInfo.gColumnType columnType, string columnHeader, string columnName, int width, int maxInputLength, string dataPropertyName, int displayIndex, bool columnEnable = true, bool IsFiltering = false)
        {
            switch (columnType)
            {
                case StaticInfo.gColumnType.PrintColumn:
                    DataGridViewButtonColumn PrintColumn = new DataGridViewButtonColumn();
                    PrintColumn.HeaderText = "Print";
                    PrintColumn.Name = "PrintColumn";
                    PrintColumn.Text = "Print";
                    PrintColumn.ToolTipText = "Print";
                    PrintColumn.Tag = "PrintColumn";
                    PrintColumn.UseColumnTextForButtonValue = true;
                    PrintColumn.Width = 35;
                    PrintColumn.ReadOnly = !columnEnable;
                    Columns.Add(PrintColumn);
                    break;
                case StaticInfo.gColumnType.DelColumn:
                    DataGridViewButtonColumn DelColumn = new DataGridViewButtonColumn();
                    DelColumn.HeaderText = "X";
                    DelColumn.Name = "DelColumn";
                    DelColumn.Tag = "DelColumn";
                    DelColumn.Text = "X";
                    DelColumn.ToolTipText = "Delete";
                    DelColumn.UseColumnTextForButtonValue = true;
                    DelColumn.Width = 20;
                    DelColumn.ReadOnly = !columnEnable;
                    DelColumn.DisplayIndex = 0;
                    Columns.Add(DelColumn);
                    break;
                case StaticInfo.gColumnType.LoadCtrColumn:
                    DataGridViewButtonColumn LoadCtrColumn = new DataGridViewButtonColumn();
                    LoadCtrColumn.HeaderText = "";
                    LoadCtrColumn.Name = "LoadCtrColumn";
                    LoadCtrColumn.Tag = "LoadCtrColumn";
                    LoadCtrColumn.Text = "";
                    LoadCtrColumn.ToolTipText = "Load";
                    LoadCtrColumn.UseColumnTextForButtonValue = true;
                    LoadCtrColumn.Width = 20;
                    LoadCtrColumn.ReadOnly = !columnEnable;
                    Columns.Add(LoadCtrColumn);
                    break;
                case StaticInfo.gColumnType.OpenColorDialog:
                    DataGridViewButtonColumn openColorDialog = new DataGridViewButtonColumn();
                    openColorDialog.HeaderText = "";
                    openColorDialog.Name = "OpenColorDialog";
                    openColorDialog.Tag = "OpenColorDialog";
                    openColorDialog.Text = "";
                    openColorDialog.ToolTipText = "Open Color Dialog";
                    openColorDialog.UseColumnTextForButtonValue = true;
                    openColorDialog.Width = 20;
                    openColorDialog.ReadOnly = !columnEnable;
                    Columns.Add(openColorDialog);
                    break;
                case StaticInfo.gColumnType.SaveColumn:
                    DataGridViewButtonColumn SaveColumn = new DataGridViewButtonColumn();
                    SaveColumn.HeaderText = "";
                    SaveColumn.Name = "SaveColumn";
                    SaveColumn.Tag = "SaveColumn";
                    SaveColumn.Text = "Save";
                    SaveColumn.ToolTipText = "Save";
                    SaveColumn.UseColumnTextForButtonValue = true;
                    SaveColumn.Width = 20;
                    SaveColumn.ReadOnly = !columnEnable;
                    Columns.Add(SaveColumn);
                    break;
                case StaticInfo.gColumnType.AutoNoColumn:
                    DataGridViewTextBoxColumn NoColumn = new DataGridViewTextBoxColumn();
                    NoColumn.HeaderText = "No";
                    NoColumn.MaxInputLength = 3;
                    NoColumn.Name = "AutoNoColumn";
                    NoColumn.Tag = "AutoNoColumn";
                    NoColumn.ToolTipText = "AutoNo";
                    NoColumn.ReadOnly = true;
                    NoColumn.Width = 25;
                    NoColumn.ReadOnly = !columnEnable;
                    NoColumn.DataPropertyName = dataPropertyName;
                    NoColumn.DisplayIndex = 1;
                    Columns.Add(NoColumn);
                    break;
                case StaticInfo.gColumnType.DateColumn:
                    CalendarColumn calendarColumn = new CalendarColumn();
                    calendarColumn.ToolTipText = columnName;
                    calendarColumn.Tag = "DateColumn";
                    DateColumnCellStyle.Format = "dd-MMM-yyyy";
                    DateColumnCellStyle.NullValue = null;
                    calendarColumn.DefaultCellStyle = DateColumnCellStyle;
                    calendarColumn.HeaderText = columnHeader;
                    calendarColumn.Name = columnName;
                    calendarColumn.DataPropertyName = dataPropertyName;
                    calendarColumn.Width = 75;
                    calendarColumn.ReadOnly = !columnEnable;
                    calendarColumn.DisplayIndex = displayIndex;
                    this.Columns.Add(calendarColumn);
                    break;
                case StaticInfo.gColumnType.TimeColumn:
                    DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
                    timeColumn.ToolTipText = columnName;
                    timeColumn.Tag = "TimeColumn";
                    TimeColumnCellStyle.Format = "t";
                    TimeColumnCellStyle.NullValue = null;
                    timeColumn.DefaultCellStyle = TimeColumnCellStyle;
                    timeColumn.HeaderText = columnHeader;
                    timeColumn.Name = columnName;
                    timeColumn.DataPropertyName = dataPropertyName;
                    timeColumn.Width = 75;
                    timeColumn.ReadOnly = !columnEnable;
                    this.Columns.Add(timeColumn);
                    break;
                case StaticInfo.gColumnType.TextBoxColumn:
                    DGVTextBoxColumn DGVTextColumn = new DGVTextBoxColumn();
                    DGVTextColumn.ToolTipText = columnName;
                    DGVTextColumn.Tag = "TextBoxColumn";
                    DGVTextColumn.HeaderText = columnHeader;
                    DGVTextColumn.MaxInputLength = maxInputLength;
                    DGVTextColumn.Name = columnName;
                    DGVTextColumn.DataPropertyName = dataPropertyName;
                    DGVTextColumn.Width = width;
                    DGVTextColumn.ReadOnly = !columnEnable;
                    DGVTextColumn.IsFilteringColumn = IsFiltering;
                    DGVTextColumn.DisplayIndex = displayIndex;
                    this.Columns.Add(DGVTextColumn);
                    break;
                case StaticInfo.gColumnType.DecimalColumn:
                    DataGridViewTextBoxColumn DGVDecimalColumn = new DataGridViewTextBoxColumn();
                    DGVDecimalColumn.ToolTipText = columnName;
                    DGVDecimalColumn.Tag = "DecimalColumn";

                    DecimalColumnCellStyle.Format = "C2";
                    DecimalColumnCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    DecimalColumnCellStyle.NullValue = "0.00";
                    DGVDecimalColumn.DefaultCellStyle = DecimalColumnCellStyle;

                    //string cformat = "en-US";
                    //if (!string.IsNullOrEmpty(StaticInfo.MainCurrencySign))
                    //{ cformat = StaticInfo.MainCurrencySign; }
                    //DecimalColumnCellStyle.FormatProvider = CultureInfo.GetCultureInfo(cformat);
                    ////DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                                        
                    DGVDecimalColumn.MaxInputLength = maxInputLength;
                    DGVDecimalColumn.HeaderText = columnHeader;
                    DGVDecimalColumn.Name = columnName;
                    DGVDecimalColumn.DataPropertyName = dataPropertyName;
                    DGVDecimalColumn.Width = 60;
                    DGVDecimalColumn.ReadOnly = !columnEnable;
                    this.Columns.Add(DGVDecimalColumn);
                    break;
                case StaticInfo.gColumnType.NumberColumn:
                    DataGridViewTextBoxColumn DGVNumberColumn = new DataGridViewTextBoxColumn();
                    DGVNumberColumn.ToolTipText = columnName;
                    DGVNumberColumn.Tag = "NumberColumn";
                    NumberColumnCellStyle.Format = "N0";
                    NumberColumnCellStyle.NullValue = null;
                    DGVNumberColumn.DefaultCellStyle = NumberColumnCellStyle;
                    DGVNumberColumn.MaxInputLength = maxInputLength;
                    DGVNumberColumn.HeaderText = columnHeader;
                    DGVNumberColumn.Name = columnName;
                    DGVNumberColumn.DataPropertyName = dataPropertyName;
                    DGVNumberColumn.Width = 60;
                    DGVNumberColumn.ReadOnly = !columnEnable;
                    this.Columns.Add(DGVNumberColumn);
                    break;
                case StaticInfo.gColumnType.CheckBoxColumn:
                    DataGridViewCheckBoxColumn DGVCheckBoxColumn = new DataGridViewCheckBoxColumn();
                    DGVCheckBoxColumn.ToolTipText = columnName;
                    DGVCheckBoxColumn.Tag = "CheckBoxColumn";
                    DGVCheckBoxColumn.HeaderText = columnHeader;
                    DGVCheckBoxColumn.Name = columnName;
                    DGVCheckBoxColumn.DataPropertyName = dataPropertyName;
                    DGVCheckBoxColumn.Width = width;
                    DGVCheckBoxColumn.ReadOnly = !columnEnable;
                    this.Columns.Add(DGVCheckBoxColumn);
                    break;
                default:
                    break;
            }
        }
        public void AddGridColumn(DGVMCComboBoxColumn DGVComboBoxColumn, string columnType, string columnHeader, string columnName, int width, ComboBoxItem[] DataSource, string dataPropertyName, string displayMember, string valueMember, bool columnEnable = true, bool IsFiltering = false)
        {
            try
            {
                DGVComboBoxColumn = new DGVMCComboBoxColumn();
                DGVComboBoxColumn.ToolTipText = columnHeader;
                DGVComboBoxColumn.Tag = columnType;
                DGVComboBoxColumn.HeaderText = columnHeader; // "EmpID";
                DGVComboBoxColumn.Name = columnName; // "dataGridViewTextBoxColumn14";
                DGVComboBoxColumn.Width = width;
                DGVComboBoxColumn.DataSource = Filldt(DataSource); //this.pkgIssuedBindingSource;
                DGVComboBoxColumn.DataPropertyName = dataPropertyName; //"EmpID";                
                DGVComboBoxColumn.DisplayMember = displayMember; // "EMPName";
                DGVComboBoxColumn.ValueMember = valueMember; //"ID";                
                DGVComboBoxColumn.Resizable = DataGridViewTriState.True;
                DGVComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                DGVComboBoxColumn.ReadOnly = !columnEnable;
                DGVComboBoxColumn.IsFilteringColumn = IsFiltering;
                this.Columns.Add(DGVComboBoxColumn);
            }
            catch { }
        }
        public void AddGridColumn(DGVMCComboBoxColumn dgvMCComboBoxColumn, string columnHeader, string columnName, string columns, int width, DataTable DataSource, string dataPropertyName, string displayMember, string valueMember, bool columnEnable = true, bool IsFiltering = false, string mode = "")
        {
            try
            {
                dgvMCComboBoxColumn = new DGVMCComboBoxColumn();
                string[] colms = columns.Split(',');
                foreach (string colum in colms)
                {
                    string[] colm = colum.Split('-');
                    string sitem = colm[0].Trim();
                    string iitem = colm[1].Trim();
                    dgvMCComboBoxColumn.ColumnNames.Add(Convert.ToString(sitem));
                    dgvMCComboBoxColumn.ColumnWidths.Add(Convert.ToString(iitem));
                }
                dgvMCComboBoxColumn.DataPropertyName = dataPropertyName; // "VendorID";
                dgvMCComboBoxColumn.DataSource = FillTable(DataSource, mode);
                //dgvMCComboBoxColumn.DataSource = DataSource;
                //dgvMCComboBoxColumn.DataSource = bindingSource; // this.VendorBindingSource;
                dgvMCComboBoxColumn.DisplayMember = displayMember; // "CompanyName";
                dgvMCComboBoxColumn.EvenRowsBackColor = System.Drawing.SystemColors.GradientActiveCaption;
                dgvMCComboBoxColumn.HeaderText = columnHeader; // "Vendor";
                dgvMCComboBoxColumn.Name = columnName;
                dgvMCComboBoxColumn.Tag = "MCComboBoxColumn";
                dgvMCComboBoxColumn.OddRowsBackColor = System.Drawing.SystemColors.ControlLight;
                dgvMCComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                dgvMCComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                dgvMCComboBoxColumn.ValueMember = valueMember; // "VendorID";
                dgvMCComboBoxColumn.Width = width; // 100;
                dgvMCComboBoxColumn.ReadOnly = !columnEnable;
                dgvMCComboBoxColumn.IsFilteringColumn = IsFiltering;
                this.Columns.Add(dgvMCComboBoxColumn);
            }
            catch { }
        }
        private DataTable FillTable(DataTable datatable, string mode = "")
        {
            DataTable dt = new DataTable();
            if (!tableList.Contains(datatable.TableName.ToString()))
            {
                tableList.Add(datatable.TableName.ToString());
                dt.TableName = datatable.TableName;
            }
            else
            {
                int i = tableList.Count;
                string tblname = datatable.TableName + Convert.ToString(i);
                tableList.Add(tblname.ToString());
                dt.TableName = tblname;
            }

            return dt = dbClass.obj.FillAll(datatable, "").Copy();
        }
        private DataTable Filldt(ComboBoxItem[] items)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("key", typeof(string));
            foreach (var item in items)
                dt.Rows.Add(item.cText, item.cKey);
            return dt;
        }
    }
    public class CustomHeaderCell : DataGridViewRowHeaderCell
    {
        //protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        //{
        //    var size1 = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        //    var value = string.Format("{0}", this.DataGridView.Rows[rowIndex].HeaderCell.FormattedValue);
        //    var size2 = TextRenderer.MeasureText(value, cellStyle.Font);
        //    var padding = cellStyle.Padding;
        //    return new Size(size2.Width + padding.Left + padding.Right, size1.Height);
        //}
        //protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        //{
        //    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.Background);
        //    base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
        //    TextRenderer.DrawText(graphics, string.Format("{0}", formattedValue), cellStyle.Font, cellBounds, cellStyle.ForeColor);
        //}
    }
    public class ComboBoxItem
    {
        public string cText { get; set; }
        public string cKey { get; set; }
    }
}


//List<int> toBeDeleted = new List<int>();

//     // always follow conventions...
//     bool empty = false;


//      // dataGridView1.Rows.Count-1 due to AllowUserToAddRows = True
//      for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
//        {
//            empty = true;
//            for (int j = 0; j < dataGridView1.Columns.Count; j++)
//            {
//                if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i].Cells[j].Value.ToString() != "")
//                {
//                    empty = false;
//                    break;
//                }
//            }
//            if (empty)
//            {
//                toBeDeleted.Add(i);
//            }
//        }

//      foreach(var f in toBeDeleted)
//     {
//         dataGridView1.Rows.RemoveAt(f);
//       }