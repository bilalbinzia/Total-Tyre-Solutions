using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ControlLibrary
{
    public partial class TAZSearchDataGridView : UserControl
    {
        public TAZSearchDataGridView()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.TAZSearchDataGridView_Load);

            this.SearchtxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchtxtBox_KeyDown);
            this.SearchtxtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchtxtBox_KeyUp);
            this.TDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TDataGridView_DataBindingComplete);
            this.TDataGridView.BindingContextChanged += new System.EventHandler(this.TDataGridView_BindingContextChanged);
            this.TDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TDataGridView_KeyDown);
            
            this.showAllLabel.Click += new System.EventHandler(this.showAllLabel_Click);
            this.TDataGridView.SelectionChanged+=TDataGridView_SelectionChanged;
            this.TDataGridView.AutoGenerateColumns = false;
            this.TDataGridView.ReadOnly = true;
            this.TDataGridView.RowHeadersVisible = true;
            this.TDataGridView.RowPrePaint += TDataGridView_RowPrePaint;
        }
        void TDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            this.TDataGridView.RowHeadersWidth = 20;
        }
        private void SearchtxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
           // {
                if (!string.IsNullOrEmpty(this.SearchtxtBox.Text.Trim()))
                {
                    this.FilterOnEnterDataSource();
                }
                else
                {
                    try
                    {
                        //DGVAutoFilterColumnHeaderCell.RemoveFilter(this.TDataGridView);
                        Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                        string bs1DataTypeName1 = bs1DataType1.Name;
                        if (bs1DataType1.Name.Equals("BindingSource"))
                            ((BindingSource)this.TDataGridView.DataSource).RemoveFilter();
                        if (bs1DataType1.Name.Equals("DataTable"))
                            ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = null;

                        showAllLabel.Visible = false;
                        this.SearchtxtBox.Text = string.Empty;
                        filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                    }
                    catch { }
                }
            //}
        }
        private void SearchtxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            if (!string.IsNullOrEmpty(this.SearchtxtBox.Text.Trim()))
            {
                this.FilterOnDataSource();
            }
            else
            {
                try
                {
                    //DGVAutoFilterColumnHeaderCell.RemoveFilter(this.TDataGridView);
                    Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                    string bs1DataTypeName1 = bs1DataType1.Name;
                    if (bs1DataType1.Name.Equals("BindingSource"))
                        ((BindingSource)this.TDataGridView.DataSource).RemoveFilter();
                    if (bs1DataType1.Name.Equals("DataTable"))
                        ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = null;

                    showAllLabel.Visible = false;
                    this.SearchtxtBox.Text = string.Empty;
                    filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                }
                catch { }
            }
            //}
        }
        public void FilterOnDataSource()
        {
            try
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                coli = 0;
                string[] searArray = this.SearchtxtBox.Text.Trim().Split(' ');
                string SearchtxtBox = searArray[0].ToString();

                Type bs1DataType = this.TDataGridView.DataSource.GetType();
                string bs1DataTypeName = bs1DataType.Name;
                if (bs1DataType.Name.Equals("BindingSource"))
                {
                    bs = (BindingSource)TDataGridView.DataSource;
                    dt = ((DataTable)bs.DataSource);
                }
                if (bs1DataType.Name.Equals("DataTable"))
                    dt = (DataTable)this.TDataGridView.DataSource;

                string SearchingString = string.Empty;
                for (int i = 0; i < searArray.Length; i++)
                {
                    coli = 0;
                    if (i > 0) if (SearchingString != string.Empty) SearchingString += ") AND ";
                    SearchtxtBox = searArray[i].ToString();
                    foreach (var item in ((System.Windows.Forms.DataGridView)(TDataGridView)).Columns)
                    {
                        string dataPropertyName = ((System.Windows.Forms.DataGridViewColumn)(item)).DataPropertyName;
                        if (!string.IsNullOrEmpty(dataPropertyName))
                        {
                            string dataPropertyDataType = dt.Columns[dataPropertyName].DataType.FullName;
                            SearchingString = SearchingQryWithoutDate(SearchingString, dataPropertyName, dataPropertyDataType, SearchtxtBox, i);
                        }                        
                    }
                }
                SearchingString += " )";

                Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                string bs1DataTypeName1 = bs1DataType1.Name;
                if (bs1DataType1.Name.Equals("BindingSource"))
                    ((BindingSource)this.TDataGridView.DataSource).Filter = SearchingString;
                if (bs1DataType1.Name.Equals("DataTable"))
                    ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = SearchingString;

                showAllLabel.Visible = true;
                filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
            }
            catch
            {
                try
                {
                    //DGVAutoFilterColumnHeaderCell.RemoveFilter(this.TDataGridView);
                    Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                    string bs1DataTypeName1 = bs1DataType1.Name;
                    if (bs1DataType1.Name.Equals("BindingSource"))
                        ((BindingSource)this.TDataGridView.DataSource).RemoveFilter();
                    if (bs1DataType1.Name.Equals("DataTable"))
                        ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = null;

                    showAllLabel.Visible = false;
                    this.SearchtxtBox.Text = string.Empty;
                    filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                }
                catch { }
            }
        }
        public void FilterOnEnterDataSource()
        {
            try
            {
                DataTable dt = new DataTable();
                BindingSource bs = new BindingSource();
                coli = 0;
                string[] searArray = this.SearchtxtBox.Text.Trim().Split(' ');
                string SearchtxtBox = searArray[0].ToString();

                Type bs1DataType = this.TDataGridView.DataSource.GetType();
                string bs1DataTypeName = bs1DataType.Name;
                if (bs1DataType.Name.Equals("BindingSource"))
                {
                    bs = (BindingSource)TDataGridView.DataSource;
                    dt = ((DataTable)bs.DataSource);
                }
                if (bs1DataType.Name.Equals("DataTable"))
                    dt = (DataTable)this.TDataGridView.DataSource;

                string SearchingString = string.Empty;
                for (int i = 0; i < searArray.Length; i++)
                {
                    coli = 0;
                    if (i > 0) if (SearchingString != string.Empty) SearchingString += ") AND ";
                    SearchtxtBox = searArray[i].ToString();
                    foreach (var item in ((System.Windows.Forms.DataGridView)(TDataGridView)).Columns)
                    {
                        string dataPropertyName = ((System.Windows.Forms.DataGridViewColumn)(item)).DataPropertyName;
                        if (!string.IsNullOrEmpty(dataPropertyName))
                        {
                            string dataPropertyDataType = dt.Columns[dataPropertyName].DataType.FullName;
                            SearchingString = SearchingQry(SearchingString, dataPropertyName, dataPropertyDataType, SearchtxtBox, i);
                        }
                    }
                }
                SearchingString += " )";

                Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                string bs1DataTypeName1 = bs1DataType1.Name;
                if (bs1DataType1.Name.Equals("BindingSource"))
                    ((BindingSource)this.TDataGridView.DataSource).Filter = SearchingString;
                if (bs1DataType1.Name.Equals("DataTable"))
                    ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = SearchingString;

                showAllLabel.Visible = true;
                filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
            }
            catch
            {
                try
                {
                    //DGVAutoFilterColumnHeaderCell.RemoveFilter(this.TDataGridView);
                    Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                    string bs1DataTypeName1 = bs1DataType1.Name;
                    if (bs1DataType1.Name.Equals("BindingSource"))
                        ((BindingSource)this.TDataGridView.DataSource).RemoveFilter();
                    if (bs1DataType1.Name.Equals("DataTable"))
                        ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = null;

                    showAllLabel.Visible = false;
                    this.SearchtxtBox.Text = string.Empty;
                    filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                }
                catch { }
            }
        }
        int coli = 0;
        private string SearchingQry(string SearchingString, string dataPropertyName, string dataPropertyDataType, string SearchtxtBox, int i)
        {
            if (dataPropertyDataType == "System.String")
            {
                coli += 1;
                try
                {
                    if (!string.IsNullOrEmpty(SearchingString.Trim()))
                        if (coli > 1)
                        {
                            string lastWord = SearchingString.Trim().Split(' ').Last();
                            if (lastWord != "(")
                                if (lastWord == "AND")
                                    SearchingString += " ( ";
                                else SearchingString += " OR ";
                        }
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "["+dataPropertyName + "] LIKE '%" + SearchtxtBox + "%'";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.DateTime")
            {
                coli += 1;
                try
                {
                    DateTime date = Convert.ToDateTime(SearchtxtBox);
                    string searchDate = date.ToString("yyyy-MM-dd");
                    if (coli > 1) if (string.IsNullOrEmpty(SearchingString.Trim())) SearchingString += "("; else SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] >= '" + searchDate + "' AND [" + dataPropertyName + "] <= '" + searchDate + "'";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.Int32")
            {
                coli += 1;
                try
                {
                    int idata = Convert.ToInt32(SearchtxtBox);
                    if (coli > 1) SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] = " + idata + "";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.Decimal")
            {
                coli += 1;
                try
                {
                    Decimal idata = Convert.ToDecimal(SearchtxtBox);
                    if (coli > 1) SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] = " + idata + "";
                }
                catch { coli -= 1; }
            }
            return SearchingString;
        }
        private string SearchingQryWithoutDate(string SearchingString, string dataPropertyName, string dataPropertyDataType, string SearchtxtBox, int i)
        {
            if (dataPropertyDataType == "System.String")
            {
                coli += 1;
                try
                {
                    if (!string.IsNullOrEmpty(SearchingString.Trim()))
                        if (coli > 1)
                        {
                            string lastWord = SearchingString.Trim().Split(' ').Last();
                            if (lastWord != "(")
                                if (lastWord == "AND")
                                    SearchingString += " ( ";
                                else SearchingString += " OR ";
                        }
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] LIKE '%" + SearchtxtBox + "%'";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.DateTime")
            {
                coli += 1;
                try
                {
                    DateTime date = Convert.ToDateTime(SearchtxtBox);
                    string searchDate = date.ToString("yyyy-MM-dd");
                    if (coli > 1) if (string.IsNullOrEmpty(SearchingString.Trim())) SearchingString += "("; else SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] >= '" + searchDate + "' AND [" + dataPropertyName + "] <= '" + searchDate + "'";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.Int32")
            {
                coli += 1;
                try
                {
                    int idata = Convert.ToInt32(SearchtxtBox);
                    if (coli > 1) SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] = " + idata + "";
                }
                catch { coli -= 1; }
            }
            if (dataPropertyDataType == "System.Decimal")
            {
                coli += 1;
                try
                {
                    Decimal idata = Convert.ToDecimal(SearchtxtBox);
                    if (coli > 1) SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] = " + idata + "";
                }
                catch { coli -= 1; }
            }
            return SearchingString;
        }
        private string SearchingQry(string SearchingString, string dataPropertyName, string dataPropertyDataType, int SearchtxtBox, int i)
        {
            if (dataPropertyDataType == "System.Int32")
            {
                coli += 1;
                try
                {
                    int idata = Convert.ToInt32(SearchtxtBox);
                    if (coli > 1) SearchingString += " OR ";
                    if (coli == 1) SearchingString += "(";
                    SearchingString += "[" + dataPropertyName + "] = " + idata + "";
                }
                catch { coli -= 1; }
            }
            return SearchingString;
        }
        private void TAZSearchDataGridView_Load(object sender, EventArgs e)
        {
        }
        public void SetSource(BindingSource bindingSource)
        {
            this.TDataGridView.DataSource = bindingSource;

            this.TDataGridView.AutoGenerateColumns = true;
            this.TDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.TDataGridView.AutoResizeColumns();

            try
            {
                this.TDataGridView.Columns["ID"].Visible = false;
            }
            catch { }
        }
        private void TDataGridView_BindingContextChanged(object sender, EventArgs e)
        {
            if (TDataGridView.DataSource == null) return;
            //foreach (DataGridViewColumn col in TDataGridView.Columns)
            //{
            //    //try
            //    //{
            //    //    if (col.Tag.Equals("TextBoxColumn"))
            //    //        if (((ControlLibrary.DGVTextBoxColumn)(col)).IsFilteringColumn)
            //    //            col.HeaderCell = new DGVAutoFilterColumnHeaderCell(col.HeaderCell);
            //    //    if ((col.Tag.Equals("ComboBoxColumn")) || (col.Tag.Equals("MCComboBoxColumn")))
            //    //        if (((ControlLibrary.DGVMCComboBoxColumn)(col)).IsFilteringColumn)
            //    //            col.HeaderCell = new DGVAutoFilterColumnHeaderCell(col.HeaderCell);
            //    //}
            //    //catch { }
            //}
            //// Format the OrderTotal column as currency. 
            ////TDataGridView.Columns["OrderTotal"].DefaultCellStyle.Format = "c";
            ////TDataGridView.AutoResizeColumns();
            try
            {
                if (TDataGridView.CurrentCell != null)
                {
                    int index = TDataGridView.CurrentCell.RowIndex + 1;
                    filterStatusLabel.Text = index + " of " + TDataGridView.RowCount + " records";
                }
                else
                {
                    filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                }
            }
            catch { filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records"; }
        }
        private void TDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up))
            {
                //DGVAutoFilterColumnHeaderCell filterCell = this.TDataGridView.CurrentCell.OwningColumn.HeaderCell as DGVAutoFilterColumnHeaderCell;
                //if (filterCell != null)
                //{
                //    filterCell.ShowDropDownList(filterCell.ColumnIndex);
                //    e.Handled = true;
                //}
            }
        }
        private void TDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                showAllLabel.Visible = false;

                ////String filterStatus = DGVAutoFilterColumnHeaderCell.GetFilterStatus(this.TDataGridView);
                ////if (String.IsNullOrEmpty(filterStatus))
                //if (TDataGridView.RowCount <= 0)
                //{
                //    showAllLabel.Visible = false;
                //    //filterStatusLabel.Visible = true;
                //    filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
                //}
                //else
                //{
                //    showAllLabel.Visible = true;
                //    //filterStatusLabel.Visible = true;
                //    //filterStatusLabel.Text = filterStatus;
                //}

                
            }
            catch { }
        }
        private void showAllLabel_Click(object sender, EventArgs e)
        {
            try
            {
                Type bs1DataType1 = this.TDataGridView.DataSource.GetType();
                string bs1DataTypeName1 = bs1DataType1.Name;
                if (bs1DataType1.Name.Equals("BindingSource"))
                    ((BindingSource)this.TDataGridView.DataSource).RemoveFilter();
                if (bs1DataType1.Name.Equals("DataTable"))
                    ((DataTable)this.TDataGridView.DataSource).DefaultView.RowFilter = null;

                this.SearchtxtBox.Text = string.Empty;
                filterStatusLabel.Text = "1 of " + TDataGridView.RowCount + " records";
            }
            catch { }
        }
        private void TDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (TDataGridView.CurrentCell != null)
                {
                    int index = TDataGridView.CurrentCell.RowIndex + 1;
                    filterStatusLabel.Text = index + " of " + TDataGridView.RowCount + " records";
                }
            }
            catch { }            
        }

    }
}