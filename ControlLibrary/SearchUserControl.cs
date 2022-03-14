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


namespace ControlLibrary
{
    public partial class SearchUserControl : UserControl
    {
        BindingSource bindingSource = null;
        string dataMember = null;
        object dataType = null;
        DataTable dataTable = null;
        string displayMember = "";

        AutoCompleteStringCollection list;
        string[] arr;

        int searchIndex = -1;
        int lastIndex = 0;
        public SearchUserControl()
        {
            InitializeComponent();
            this.btnClose.Click += btnClose_Click;
            //txtBoxSearch.PreviewKeyDown += txtBoxSearch_PreviewKeyDown;
            //txtBoxSearch.KeyPress += txtBoxSearch_KeyPress;
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            this.txtBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSearch_KeyDown);

            searchIndex = -1;
            lastIndex = 0;

            list = txtBoxSearch.AutoCompleteCustomSource;
            txtBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;


        }

        //void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Up || (e.KeyChar == (char)Keys.Down))
        //        e.Handled = false;
        //    else
        //        e.Handled = true;
        //}
        //protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        //{
        //    e.IsInputKey = true;
        //    base.OnPreviewKeyDown(e);
        //}

        //void txtBoxSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
        //        e.Handled = true;
        //    else
        //        check = true;
        //}

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void BindControl(object bindingSource, string dataMember, object dataType, DataTable dataTable = null, string displayMember = "")
        {
            try
            {
                this.bindingSource = (BindingSource)bindingSource;
                this.dataMember = dataMember;
                this.dataType = dataType;
                this.dataTable = dataTable;
                this.displayMember = displayMember;

                if (this.dataType == typeof(DateTime))
                {
                    this.txtBoxSearch.Visible = false;
                    this.DatePanel.Visible = true;
                    this.lblDataMember.Text = this.dataMember;
                    //this.DatePanel.Left += 30;
                    //this.Width = 210;
                }
                else
                {
                    //this.DatePanel.Visible = false;
                    this.txtBoxSearch.Visible = true;
                    this.lblDataMember.Text = this.dataMember;
                    //this.Width = 300;
                }
            }
            catch { }
        }
        private void txtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (!string.IsNullOrEmpty(txtBoxSearch.Text.Trim()))
                    {
                        SearchData sData = new SearchData(dataMember, txtBoxSearch.Text.Trim());
                        if (!StaticInfo.SearchList.Exists(x => x.sKey == sData.sKey && x.sValue == sData.sValue))
                        {
                            try { StaticInfo.SearchList.Add(sData); }
                            catch { }
                        }
                        this.FindNext();
                        SendKeys.Send("{End}");
                    }
                }
            }
            catch { }
        }

        private void FindNext()
        {
            try
            {
                if (this.dataType == typeof(DateTime))
                {
                    DateTime date = this.dtpSearch.DateTimePicker1.Value.Date;
                    string searchDate = date.ToString("yyyy-MM-dd");
                    string rowFilter = string.Format(dataMember + " >= '{0:yyyy-MM-dd}' AND " + dataMember + " <= '{0:yyyy-MM-dd}'", searchDate);
                    //DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(String.Format("{0} >= '{1:yyyy-MM-dd}' AND {0} <= '{1:yyyy-MM-dd}'", this.dataMember, searchDate));
                    DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(rowFilter);
                    DataTable dt = (DataTable)datarows.CopyToDataTable();
                    if (searchIndex == -1 || searchIndex >= datarows.Length)
                    {
                        searchIndex = 0;
                        BindingSource BS = new BindingSource();
                        BS.DataSource = dt;
                        this.bindingNavigator1.BindingSource = BS;
                        lastIndex = datarows.Length;
                    }
                    int itemFound = ((BindingSource)this.bindingSource).Find("ID", datarows[searchIndex]["ID"]);
                    this.bindingSource.Position = itemFound;
                }
                else if (this.dataType == typeof(ComboBox))
                {
                    if (!string.IsNullOrEmpty(txtBoxSearch.Text.Trim()))
                    {
                        string searchItem = txtBoxSearch.Text.Trim();
                        DataRow[] foundRows = this.dataTable.Select(string.Format("CONVERT({0}, System.String) LIKE '{1}%'", this.displayMember, searchItem));
                        if (foundRows.Count() > 0)
                        {
                            string IDs = string.Empty;
                            foreach (var item in foundRows)
                            {
                                IDs += Convert.ToString(item.ItemArray[0].ToString()) + ",";
                            }
                            if (!string.IsNullOrEmpty(IDs))
                            {
                                IDs = IDs.Remove(IDs.Length - 1);
                                string SearchByColumn = dataMember + " In (" + IDs + ")";
                                DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(SearchByColumn);
                                DataTable dt = (DataTable)datarows.CopyToDataTable();
                                if (searchIndex == -1 || searchIndex >= datarows.Length)
                                {
                                    searchIndex = 0;
                                    BindingSource BS = new BindingSource();
                                    BS.DataSource = dt;
                                    this.bindingNavigator1.BindingSource = BS;
                                    lastIndex = datarows.Length;
                                }

                                int itemFound = ((BindingSource)this.bindingSource).Find("ID", datarows[searchIndex]["ID"]);
                                this.bindingSource.Position = itemFound;
                            }
                        }

                        //int searchItemID = -1;
                        //if(foundRows.Count() > 0)
                        //    searchItemID = Convert.ToInt32(foundRows[0]["ID"]);

                        //string SearchByColumn = "ColumnName=" + value;
                        //DataRow[] hasRows = currentDataTable.Select(SearchByColumn);



                        //DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(string.Format("CONVERT({0}, System.String) = '{1}'", dataMember, searchItemID));
                        //DataTable dt = (DataTable)datarows.CopyToDataTable();
                        //if (searchIndex == -1 || searchIndex >= datarows.Length)
                        //{
                        //    searchIndex = 0;
                        //    BindingSource BS = new BindingSource();
                        //    BS.DataSource = dt;
                        //    this.bindingNavigator1.BindingSource = BS;
                        //    lastIndex = datarows.Length;
                        //}
                        ////int itemFound = ((BindingSource)this.bindingSource).Find(this.dataMember, datarows[searchIndex][this.dataMember]);
                        //int itemFound = ((BindingSource)this.bindingSource).Find("ID", datarows[searchIndex]["ID"]);
                        //this.bindingSource.Position = itemFound;
                    }
                    else { this.bindingNavigator1.BindingSource = null; }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtBoxSearch.Text.Trim()))
                    {
                        try
                        {
                            string searchItem = txtBoxSearch.Text.Trim();
                            //DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(this.dataMember + " LIKE '%" + txtBoxSearch.Text.Trim() + "%'");
                            DataRow[] datarows = ((DataTable)this.bindingSource.DataSource).Select(string.Format("CONVERT({0}, System.String) LIKE '%{1}%'", dataMember, txtBoxSearch.Text.Trim()));
                            DataTable dt = (DataTable)datarows.CopyToDataTable();
                            //try
                            //{
                            if (searchIndex == -1 || searchIndex >= datarows.Length)
                            {
                                searchIndex = 0;
                                BindingSource BS = new BindingSource();
                                BS.DataSource = dt;
                                this.bindingNavigator1.BindingSource = BS;
                                lastIndex = datarows.Length;
                            }
                            //int itemFound = ((BindingSource)this.bindingSource).Find(this.dataMember, datarows[searchIndex][this.dataMember]);
                            //}
                            //catch { }
                            //try
                            //{
                            int itemFound = ((BindingSource)this.bindingSource).Find("ID", datarows[searchIndex]["ID"]);
                            this.bindingSource.Position = itemFound;
                            //}
                            //catch { }
                        }
                        catch { }
                    }
                    else { this.bindingNavigator1.BindingSource = null; }
                }
            }
            catch { }
        }
        String[] GetList()
        {
            try
            {
                arr = new string[10];
                var contains = StaticInfo.SearchList.FindAll(x => x.sKey == dataMember);
                arr = (from s in contains select s.sValue).ToArray();

                return arr;
            }
            catch { return arr; }
        }
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                searchIndex = -1;
                if (GetList().Length > 0)
                {
                    try
                    {
                        list.Clear();
                        list.AddRange(arr);
                    }
                    catch { }
                }
                txtBoxSearch.AutoCompleteCustomSource = list;
            }
            catch { }
        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            searchIndex += 1;
            this.FindNext();
        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            searchIndex -= 1;
            this.FindNext();
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            searchIndex = lastIndex - 1;
            this.FindNext();
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            searchIndex = 0;
            this.FindNext();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchIndex = -1;
            this.FindNext();
        }
    }
}
