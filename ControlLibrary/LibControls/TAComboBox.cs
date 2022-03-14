
using DBModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TAComboBox : System.Windows.Forms.ComboBox
    {

        BindingSource bindingSource = null;
        string dataMember = null;

        DataTable _dataSource = null;
        
        

        private string displayMember;
        public string xDisplayMember
        {
            get { return displayMember; }
            set { displayMember = value; }
        }
        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }
        private bool cReadOnly;
        public bool xReadOnly
        {
            get { return cReadOnly; }
            set { cReadOnly = value; }
        }
        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }

        private StaticInfo.YesNo showDefault;
        public StaticInfo.YesNo xIsShowDefault
        {
            get { return showDefault; }
            set { showDefault = value; }
        }

        private StaticInfo.YesNo allowDuplicate;
        public StaticInfo.YesNo xIsAllowDuplicate
        {
            get { return allowDuplicate; }
            set { allowDuplicate = value; }
        }

        private StaticInfo.YesNo showInGrid;
        public StaticInfo.YesNo xIsShowInGrid
        {
            get { return showInGrid; }
            set { showInGrid = value; }
        }
        private string columnName;
        public string xColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        private int columnWidth = 60;
        public int xColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }

        private string fillByFieldID;
        public string xFillByFieldID
        {
            get { return fillByFieldID; }
            set { fillByFieldID = value; }
        }

        private string tableName;
        public string xTableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        private string orderBy;
        public string xOrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

        private System.ComponentModel.Container components = null;
        public TAComboBox()
        {
            InitializeComponent();
            this.KeyPress += TAComboBox_KeyPress;
            //this.DropDown += TAComboBox_DropDown;
            //dbClass.obj = new DbClass();
        }

        void TAComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.DroppedDown = false;
        }

        //void TAComboBox_DropDown(object sender, EventArgs e)
        //{
        //    TAComboBox TACB = (TAComboBox)sender;
        //    if (!string.IsNullOrEmpty(TACB.xFillByFieldID))
        //    {
        //        string FillByTableName = TACB.xTableName;
        //        string FillByFieldID = TACB.xFillByFieldID;

        //        DataRowView curRow = (DataRowView)this.objBindingSource.Current;
        //        try
        //        {
        //            int FieldID = Convert.ToInt32(curRow[FillByFieldID]);
        //            if (FieldID != null)
        //                TACB.DataSource = dbClass.obj.fillComboByFieldID(objDataSet.Tables[FillByTableName].Copy(), FillByFieldID, FieldID);

        //        }
        //        catch { }
        //    }
        //}
        //void TAComboBox_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.DataSource != null)
        //        {
        //            if (this.xColumnName.Contains(","))
        //            {
        //                string fields = string.Empty;
        //                string[] sColumns = this.xColumnName.Split(',');
        //                foreach (string item in sColumns)
        //                {
        //                    if (string.IsNullOrEmpty(fields))
        //                        fields = "* ,(Convert(varchar(50),[" + item + "])";
        //                    else
        //                        fields += "+' - '+ Convert(varchar(50),[" + item + "])";
        //                }
        //                fields += ") [" + this.xDisplayMember + "]";

        //                //if (string.IsNullOrEmpty(xFillByFieldID))
        //                //    dbClass.obj.FillByQryByActive((DataTable)this.DataSource, fields, this.xOrderBy);
        //            }
        //            else
        //            {
        //                //if (string.IsNullOrEmpty(xFillByFieldID))
        //                //    dbClass.obj.FillByActive((DataTable)this.DataSource, this.xOrderBy);
        //            }
        //        }
        //    }
        //    catch { }
        //}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{TAB}");
            }
            catch { }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

        }
        public void BindControl(object bindingSource, string dataMember, DataTable dataSource, string displayMember, string valueMember, string Orderby)
        {
            try
            {
                this._dataSource = dataSource;
                this.orderBy = Orderby;
                //dbClass.obj.FillAll(dataSource, this.orderBy);
                this.bindingSource = (BindingSource)bindingSource;
                this.bindingProperty = dataMember;
                this.DataSource = dataSource;
                this.DisplayMember = displayMember;
                this.ValueMember = valueMember;
                this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.bindingProperty, true));
            }
            catch { }
        }
        public void BindControl(object bindingSource, DataTable dataSource, int ID)
        {
            try
            {
                //if(dataSource.TableName.Equals("BankAccount"))
                //    dbClass.obj.FillBankAccount(dataSource, this.xOrderBy);
                //else
                //    dbClass.obj.FillByActive(dataSource, this.xOrderBy);

                //dbClass.obj.FillByID(dataSource ,ID);

                this.bindingSource = (BindingSource)bindingSource;
                this.DataSource = dataSource;
                this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.xBindingProperty, true));
            }
            catch { }
        }
        public void BindControl(object bindingSource, DataTable dataSource, string ColumnName, string DisplayName)
        {
            try
            {
                //if (ColumnName.Contains(","))
                //{
                //    string fields = string.Empty;
                //    string[] sColumns = ColumnName.Split(',');
                //    foreach (string item in sColumns)
                //    {
                //        if (string.IsNullOrEmpty(fields))
                //            fields = "* ,(Convert(varchar(50),[" + item + "])";
                //        else
                //            fields += "+' - '+ Convert(varchar(50),[" + item + "])";
                //    }
                //    fields += ") [" +DisplayName +"]";
                //    dbClass.obj.FillByQryByActive(dataSource, fields, this.xOrderBy);
                //}
                //else
                //    dbClass.obj.FillByActive(dataSource, this.xOrderBy);

                this.bindingSource = (BindingSource)bindingSource;
                this.DataSource = dataSource;
                this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.xBindingProperty, true));
            }
            catch { }
        }

        public void BindControl(object bindingSource, string dataMember)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.dataMember = dataMember;
            this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.dataMember, true));
        }
    }
}
