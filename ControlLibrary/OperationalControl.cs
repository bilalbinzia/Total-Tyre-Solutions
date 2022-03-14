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
using System.Data.SqlClient;

namespace ControlLibrary
{
    using DBModule;
    using System.Collections;
    using System.Globalization;
    public interface iFrmMain
    {
        void RefreshControls();
    }
    public interface iFrmMain2
    {
        void RefreshControls2();
    }
    public partial class OperationalControl : UserControl
    {
        frmOperationMessage frmMessage;
        public System.Windows.Forms.Timer timer1;

        #region Properties
        public bool Initialize = false;
        public bool _loading = false;
        public bool _reporting = false;

        public bool _adding = false;
        public bool _editing = false;
        public bool _deleting = false;
        public bool _cancel = false;

        public bool isDeleted = false;
        public bool _edit = false;
        public bool _add = false;

        string Qry = string.Empty;
        //------------------------------------------
        private string PrefixDocNo;
        public string xPrefixDocNo
        {
            get { return PrefixDocNo; }
            set { PrefixDocNo = value; }
        }
        private string TableName;
        public string xTableName
        {
            get { return TableName; }
            set { TableName = value; }
        }
        private bool IsLoadAll = true;
        public bool xIsLoadAll
        {
            get { return IsLoadAll; }
            set { IsLoadAll = value; }
        }


        //-------------------------------------//
        public enum currentStatus
        {
            Add,
            Edit,
            Load
        };
        public currentStatus frmStatus;
        //-------------------------------------//
        public enum currentMode
        {
            AddNew,
            Position,
            Load
        };
        public currentMode frmMode;
        //-------------------------------------//

        private int recID;
        protected string DocNo = string.Empty;
        protected string issuedBy = string.Empty;
        public bool Locked { set; get; }
        public bool isSaleinGrid { set; get; }
        public string controlName { set; get; }
        public MessageBox xMessageBox = null;
        public BindingSource objBindingSource = null;
        public MainDataSet objDataSet = null;

        private System.Windows.Forms.Panel basePanel1 = null;

        //public string xTableName = "";
        //private string _ctrName = "";
        private List<childTable> childs = null;
        protected List<childTable> Childs
        {
            get
            {
                if (childs == null)
                    childs = new List<childTable>();
                return childs;
            }
        }
        List<Control> TAPictureControlList = null;
        List<Control> TAComboControlList = null;
        List<SearchDGVColumn> SearchDGVList = null;
        List<Control> TAZSearchDGVControlList = null;
        List<Control> ControlNullBindingList = null;

        #endregion
        #region OperationalControl
        public OperationalControl()
        {
            InitializeComponent();

            objBindingSource = new BindingSource();
            objDataSet = new MainDataSet();
            xMessageBox = new MessageBox();

            TAPictureControlList = new List<Control>();
            TAComboControlList = new List<Control>();
            SearchDGVList = new List<SearchDGVColumn>();
            TAZSearchDGVControlList = new List<Control>();
            ControlNullBindingList = new List<Control>();

            this.BackColor = StaticInfo.ctrBackColor;

            this.Load += new System.EventHandler(this.OperationalControl_Load);

            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

        }
        //void objBindingSource_PositionChanged(object sender, EventArgs e)
        //{
        //    //BNPositionItem.Text = Convert.ToString(this.objBindingSource.Position + 1);
        //    this.DataNavigation();
        //}
        private void OperationalControl_Load(object sender, EventArgs e)
        {

            frmStatus = currentStatus.Load;
            frmMode = currentMode.Load;


            if (!string.IsNullOrEmpty(this.xTableName))
            {
                this.objBindingSource.DataMember = this.xTableName;
                //this.BaseBindingNavigator.BindingSource = this.objBindingSource;
                this.SetSource(this.xTableName, this.Name);
                this.objBindingSource.MoveLast();
            }
        }
        #endregion
        #region SetSource
        protected void SetSource(string tableName, string ctrName)
        {
            this.Initialize = true;
            //this._ctrName = ctrName;
            //this.xTableName = tableName;
            setColumnAllowDBNull(this.xTableName);
            this.objBindingSource.DataSource = this.objDataSet.Tables[this.xTableName];

            this.onSetChild();
            this.onSetSource();

            //if (this.xTableName.Equals("POSSale"))
            //    dbClass.obj.FillTOP1(this.objDataSet.POSSale);
            //else
            //    dbClass.obj.FillAll(this.objDataSet.Tables[this.xTableName], "");

            //dbClass.obj.Fill(objDataSet.Tables[this.xTableName]);

            this.basePanel1 = this.WorkingPanel;
            this.ControlsEnableDisable("Load");

            #region "Fill by Query....."
            if (SearchDGVList.Count > 0)
            {
                string fields = "m.*";
                string mainTable = " from [dbo].[" + xTableName + "] m";
                string childTable = string.Empty;
                Qry = string.Empty;

                try
                {
                    int i = 1;
                    string sxTableName=string.Empty;
                    foreach (var item in SearchDGVList)
                    {                        
                        if (!string.IsNullOrEmpty(item.xTableName))
                        {
                            if (item.xTableName == sxTableName)
                            {
                                i++;
                                fields += ", [" + item.xTableName + i + "]." + item.xDisplayMember + " as [" + item.xTableName + i + "]";
                                childTable += " Left Join [dbo].[" + item.xTableName + "] [" + item.xTableName + i + "] On m." + item.columnBindingProperty + " = [" + item.xTableName + i + "]." + item.xValueMember + "";
                            }
                            else
                            {
                                fields += ", [" + item.xTableName + "]." + item.xDisplayMember + " as [" + item.xTableName + "]";
                                childTable += " Left Join [dbo].[" + item.xTableName + "] [" + item.xTableName + "] On m." + item.columnBindingProperty + " = [" + item.xTableName + "]." + item.xValueMember + "";
                            }
                        }                        
                        sxTableName = item.xTableName;
                    }

                    Qry = "Select " + fields + mainTable + childTable;
                }
                catch { Qry = "Select m.*" + mainTable; }

                if (xTableName == "Vendor")
                    Qry = dbClass.obj.FillVendorListWithBalances();
                if (xTableName == "Customer")
                    Qry = dbClass.obj.FillCustomerListWithBalances();
                if (xTableName == "Employee")
                    Qry += " Where m.IsDisplay = 1";

                dbClass.obj.FillByQry(objDataSet.Tables[this.xTableName], Qry);
            }
            else
            {
                if (!this.IsLoadAll)
                    dbClass.obj.FillTOP0(objDataSet.Tables[this.xTableName]);
                else
                    dbClass.obj.Fill(objDataSet.Tables[this.xTableName]);
            }
            #endregion

            this.LoadChilds();
            this.LoadTAZDGV("Load");

            this.Initialize = false;
        }
        protected virtual void onSetSource()
        {
        }
        protected virtual void onSetChild()
        {

        }

        //void AddTable()
        //{
        //    try
        //    {                
        //        //objDataSet.Tables.Add(new AccountDataTable1());
        //    }
        //    catch { }
        //}
        void LoadChilds()
        {
            foreach (childTable child in this.Childs)
            {
                if (!string.IsNullOrEmpty(child.tblName))
                {
                    if (!this.IsLoadAll)
                        dbClass.obj.FillChildTOP1(this.objDataSet.Tables[child.tblName], child.tblQry);
                    else
                        dbClass.obj.FillChild(this.objDataSet.Tables[child.tblName], child.tblQry);
                }
            }
        }
        protected void AddChild(string tblName)
        {
            childTable objchildTable = new childTable();
            objchildTable.tblName = tblName;
            objchildTable.tblQry = "";
            this.Childs.Add(objchildTable);
        }
        protected void AddChild(string tblMaster, string tblDetail, string tblRelation, string tblQuery)
        {
            setColumnAllowDBNull(tblDetail);
            childTable objchildTable = new childTable();
            objchildTable.tblName = tblDetail;
            objchildTable.tblQry = tblQuery;
            this.Childs.Add(objchildTable);
            this.AddRelation(tblMaster, tblDetail, tblRelation);
        }
        void setColumnAllowDBNull(string tableName)
        {
            try
            {
                foreach (DataColumn xDataColumn in this.objDataSet.Tables[tableName].Columns)
                {
                    if ((xDataColumn.DataType).FullName.Equals("System.Decimal"))
                        xDataColumn.DefaultValue = ((decimal)(0.0m));

                    if (xDataColumn.ColumnName == "ID" || xDataColumn.ColumnName == "MID")
                        xDataColumn.AllowDBNull = false;
                    else
                        xDataColumn.AllowDBNull = true;
                }
            }
            catch { }
        }
        void AddRelation(string tblMaster, string tblDetail, string tblRelation)
        {

            try
            {
                this.DeleteRelationFromSchema(tblRelation, this.objDataSet);
                //------------------------------------------------------------
                global::System.Data.ForeignKeyConstraint fkcMasterDetail;
                fkcMasterDetail = new global::System.Data.ForeignKeyConstraint(tblRelation, new global::System.Data.DataColumn[] {
                        this.objDataSet.Tables[tblMaster].Columns["ID"]}, new global::System.Data.DataColumn[] {
                        this.objDataSet.Tables[tblDetail].Columns["MID"]});
                this.objDataSet.Tables[tblDetail].Constraints.Add(fkcMasterDetail);
                fkcMasterDetail.AcceptRejectRule = global::System.Data.AcceptRejectRule.None;
                fkcMasterDetail.DeleteRule = global::System.Data.Rule.Cascade;
                fkcMasterDetail.UpdateRule = global::System.Data.Rule.Cascade;
                //------------------------------------------------------------
                System.Data.DataRelation relationMasterDetail;
                relationMasterDetail = new global::System.Data.DataRelation(tblRelation, new global::System.Data.DataColumn[] {
                        this.objDataSet.Tables[tblMaster].Columns["ID"]}, new global::System.Data.DataColumn[] {
                        this.objDataSet.Tables[tblDetail].Columns["MID"]}, false);
                this.objDataSet.Relations.Add(relationMasterDetail);
                //--------------------------------------------------------------    
            }
            catch { }
        }
        private void DeleteRelationFromSchema(string relationName, DataSet schemaAsDs)
        {
            try
            {
                foreach (DataRelation dr in schemaAsDs.Relations)
                {
                    if (dr.RelationName.ToLower() == relationName.ToLower())
                    {
                        DataRelation removedRelation = dr;

                        if (schemaAsDs.Relations.CanRemove(removedRelation))
                        {
                            if (removedRelation.ChildTable.Constraints.Contains(relationName))
                            {
                                removedRelation.ChildTable.Constraints.Remove(relationName);
                                schemaAsDs.Relations.Remove(removedRelation);
                            }
                            else
                                schemaAsDs.Relations.Remove(removedRelation);
                        }
                        break;
                    }
                }
            }
            catch { }
        }
        void RejectChilds()
        {
            try
            {
                foreach (childTable child in this.Childs)
                    this.objDataSet.Tables[child.tblName].RejectChanges();
            }
            catch { }
        }
        //protected virtual void OnParentUpdate(DataRow pDataRow, string tblName)
        //{
        //}
        #endregion
        #region Commit
        protected bool Commit(string tblName)
        {
            try
            {
                this.OnCommit(tblName);
                try
                {
                    DataRow pDataRow = ((DataRowView)this.objBindingSource.Current).Row;
                    foreach (childTable child in this.Childs)
                    {
                        //this.OnParentUpdate(pDataRow, child);
                        if (child.tblName != null && !string.IsNullOrEmpty(child.tblName))
                            this.OnCommit(child.tblName);
                    }
                }
                catch { }
                //------------------------------------------
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected virtual void OnCommit(string tblName)
        {
            this.Validate();
            this.objBindingSource.EndEdit();
            if (this.objDataSet.Tables[tblName].GetChanges() != null)
            {
                dbClass.obj.Update(this.objDataSet.Tables[tblName]);
            }
            this.Locked = false;
        }
        private void OnCommit()
        {
            ////xMessageBox.Show("Save Successfully...!");
            this._add = false;
            this._edit = false;
            this._adding = false;
            this._editing = false;
            this._loading = true;

            frmStatus = currentStatus.Load;
            frmMode = currentMode.Load;
            ////this.EnableDisableByUserLevel();

        }
        protected bool Delete()
        {
            if (xMessageBox.Show("Are you sure to delete current record?", "Delete", CCMessageBox.iMessageBoxButtons.YesNo, CCMessageBox.iMessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                    recID = Convert.ToInt32(curRow["ID"]);
                    DocNo = Convert.ToString(curRow["DocNo"]);

                    int pos = this.objBindingSource.Position;
                    this.objBindingSource.Remove(this.objBindingSource.Current);
                    this.objBindingSource.EndEdit();
                    try
                    {
                        dbClass.obj.Delete(this.objDataSet, this.xTableName, this.Childs);
                        Log(this.xTableName, recID, DocNo, "Delete");
                        this.isDeleted = true;

                    }
                    catch (Exception ex)
                    {
                        this.isDeleted = false;
                        this.objBindingSource.Position = pos;
                        ((DataRowView)this.objBindingSource.Current).Row.RowError = "";
                        xMessageBox.Show(ex.Message, "Error", CCMessageBox.iMessageBoxButtons.OK, CCMessageBox.iMessageBoxIcon.Error);
                    }
                    return true;
                }
                catch { this.isDeleted = false; }
            }
            return false;
        }
        private void EditItem(int recID)
        {
            //-----------------------------
            this.Locked = true;
            this._edit = true;
            this._add = false;

            frmStatus = currentStatus.Edit;

        }
        #endregion

        #region Image
        void AddImage()
        {
            DataRowView curRow = (DataRowView)this.objBindingSource.Current;
            if (Convert.ToInt32(curRow["ID"]) > 0)
            {
                foreach (Control ctr in this.WorkingPanel.Controls)
                {
                    if (ctr.GetType() == typeof(TAPictureBoxControl))
                    {
                        if ((((TAPictureBoxControl)ctr).xBindingProperty != "") && (((TAPictureBoxControl)ctr).xBindingProperty != null) && (((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage != null))
                        {
                            string bindingProperty = ((TAPictureBoxControl)ctr).xBindingProperty;
                            Image img = ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage;
                            DataTable dt = (DataTable)this.objDataSet.Tables[((TAPictureBoxControl)ctr).xTableName].Copy();
                            DataRow newRow = dt.NewRow();
                            newRow[((TAPictureBoxControl)ctr).xValueMember] = curRow["ID"];
                            newRow[bindingProperty] = StaticInfo.ImageToByteArray(img); ;
                            dt.Rows.Add(newRow);
                            dbClass.obj.Update(dt);
                        }
                    }
                }
            }
        }
        void SaveImage()
        {
            if (TAPictureControlList.Count > 0)
            {
                foreach (Control ctr in TAPictureControlList)
                {
                    if (ctr.GetType() == typeof(TAPictureBoxControl))
                    {
                        if ((((TAPictureBoxControl)ctr).xBindingProperty != "") && (((TAPictureBoxControl)ctr).xBindingProperty != null))
                        {
                            try
                            {
                                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                                if (((TAPictureBoxControl)ctr).xTableName.Equals(this.xTableName))
                                {
                                    if (((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage != null)
                                        dbClass.obj.UpdateImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xBindingProperty, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]), StaticInfo.ImageToByteArray(((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage));
                                    else
                                        dbClass.obj.RemoveImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xBindingProperty, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]));
                                }
                                else
                                {
                                    if (dbClass.obj.isIDInPicTable(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"])))
                                    {
                                        if (((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage != null)
                                        {
                                            dbClass.obj.UpdateImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xBindingProperty, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]), StaticInfo.ImageToByteArray(((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage));
                                        }
                                        else
                                            dbClass.obj.RemoveImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]));
                                    }
                                    else
                                    {
                                        if (((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage != null)
                                        {
                                            dbClass.obj.SaveImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xBindingProperty, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]), StaticInfo.ImageToByteArray(((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage));
                                        }
                                        else
                                            dbClass.obj.RemoveImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]));
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        private void LoadImage()
        {
            if (TAPictureControlList.Count > 0)
            {
                foreach (Control ctr in TAPictureControlList)
                {
                    if (ctr.GetType() == typeof(TAPictureBoxControl))
                    {
                        if ((((TAPictureBoxControl)ctr).xBindingProperty != "") && (((TAPictureBoxControl)ctr).xBindingProperty != null))
                        {
                            try
                            {
                                string bindingProperty = ((TAPictureBoxControl)ctr).xBindingProperty;
                                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                                if (curRow != null)
                                {
                                    DataTable dt = dbClass.obj.LoadImage(((TAPictureBoxControl)ctr).xTableName, ((TAPictureBoxControl)ctr).xValueMember, Convert.ToInt32(curRow["ID"]));
                                    if (dt.Rows.Count > 0)
                                        ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = StaticInfo.byteArrayToImage((byte[])dt.Rows[0][bindingProperty]);
                                    else
                                        ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = null;
                                }
                                else
                                {
                                    ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = null;
                                }
                            }
                            catch { ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = null; }
                        }
                    }
                }
            }
        }
        public void LoadTACombo()
        {
            if (TAComboControlList.Count > 0)
            {
                foreach (Control ctr in TAComboControlList)
                {
                    if (ctr.GetType() == typeof(TAComboBox))
                    {
                        if ((((TAComboBox)ctr).xBindingProperty != "") && (((TAComboBox)ctr).xBindingProperty != null))
                        {
                            try
                            {
                                string bindingProperty = ((TAComboBox)ctr).xBindingProperty;
                                DataRowView curRow = (DataRowView)this.objBindingSource.Current;

                                if (this.objDataSet.Tables[((TAComboBox)ctr).xTableName] != null && curRow!=null)
                                {
                                    ((TAComboBox)ctr).DataSource = dbClass.obj.FillByID(this.objDataSet.Tables[((TAComboBox)ctr).xTableName].Copy(), Convert.ToInt32(curRow[bindingProperty]));
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        private void LoadTAZDGV(string mode)
        {
            try
            {
                if (mode == "Load")
                {
                    if (TAZSearchDGVControlList.Count > 0)
                    {
                        foreach (Control ctr in TAZSearchDGVControlList)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(this.xTableName))
                                {
                                    if (SearchDGVList.Count > 0)
                                    {
                                        ((TAZSearchDataGridView)ctr).TDataGridView.AutoGenerateColumns = true;
                                        ((TAZSearchDataGridView)ctr).TDataGridView.RowHeadersVisible = true;

                                        ((TAZSearchDataGridView)ctr).TDataGridView.DataSource = this.objBindingSource;
                                        ((TAZSearchDataGridView)ctr).TDataGridView.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

                                        foreach (DataGridViewColumn col in ((TAZSearchDataGridView)ctr).TDataGridView.Columns)
                                        {
                                            SearchDGVColumn xcol = SearchDGVList.Find(x => x.fieldProperty.Equals(col.DataPropertyName));
                                            if (xcol != null)
                                            {
                                                col.Visible = true;
                                                col.HeaderText = xcol.columnHeaderName;
                                                col.Width = xcol.columnWidth;
                                            }
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        #region bindingNavigator
        //----------------------------------------------------------------------------------
        protected bool bindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            bool IsAdd = false;
            try
            {
                //-------------------------------
                this.Locked = true;
                this._edit = false;
                this._add = true;
                this._adding = true;
                //-------------------------------
                //int cont = Convert.ToInt32(PrefixDocNo.Length) + 2;
                //DocNo = PrefixDocNo + "/" + dbClass.obj.getInvoiceNo(this.xTableName, "DocNo", cont);
                //DocNo = PrefixDocNo + "/" + StaticInfo.CoFinEndYear + "/" + dbClass.obj.getNextDocNo(xTableName, StaticInfo.CoFinEndYear);

                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();
                //curRow["DocNo"] = DocNo;
                try
                {
                    curRow["CompanyID"] = StaticInfo.CompanyID;
                }
                catch { } try
                {
                    curRow["WarehouseID"] = StaticInfo.WarehouseID;
                }
                catch { } try
                {
                    curRow["StoreID"] = StaticInfo.StoreID;
                }
                catch { } try
                {
                    curRow["IsDefault"] = false;
                }
                catch { }
                
                curRow["Active"] = true;
                curRow["AddDate"] = DateTime.Now;
                curRow["AddUserID"] = StaticInfo.userid;

                curRow["ModifyDate"] = DateTime.Now;
                curRow["ModifyUserID"] = StaticInfo.userid;
                curRow["CoFinEndYear"] = StaticInfo.CoFinEndYear;

                curRow["IsLocked"] = false;
                curRow.EndEdit();
                //-------------------------------
                this.DataNavigation();
                //-------------------------------
                this.ClearControls();
                //-------------------------------
                frmStatus = currentStatus.Add;
                frmMode = currentMode.AddNew;
                this.ControlsEnableDisable("Add");
                //-------------------------------
                IsAdd = true;
            }
            catch { }
            return IsAdd;
        }
        protected bool bindingNavigatorEditItemClick(object sender, EventArgs e)
        {
            bool IsEdit = false;
            this._edit = true; this._add = false;
            //------------------------------------------------
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                recID = Convert.ToInt32(curRow["ID"]);
                bool IsLocked = dbClass.obj.isLocked(this.xTableName, recID);
                if (!IsLocked)
                {
                    this.EditItem(recID);
                    curRow.BeginEdit();
                    curRow["IsLocked"] = false;
                    curRow["ModifyDate"] = DateTime.Now;
                    curRow["ModifyUserID"] = StaticInfo.userid;
                    curRow.EndEdit();
                }

                frmStatus = currentStatus.Edit;
                this.ControlsEnableDisable("Edit");
                IsEdit = true;
            }
            catch { }
            return IsEdit;
        }
        protected void bindingNavigatorDeleteClick(object sender, EventArgs e)
        {
            this.Delete();
            this.ControlsEnableDisable("Load");
        }
        protected void bindingNavigatorCancelItemClick(object sender, EventArgs e)
        {
            try
            {
                this.Locked = false;
                this.CustomValidation(false);
                this.objBindingSource.CancelEdit();
                //this.objBindingSource.ResetBindings(true);
                this.RejectChilds();
                ((DataTable)this.objBindingSource.DataSource).RejectChanges();

                frmStatus = currentStatus.Load;
                frmMode = currentMode.Load;
                this.ControlsEnableDisable("Cancel");
            }
            catch { }
        }
        protected bool bindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            bool isSave = false;
            if (CustomValidation(true))
            {
                if (_edit)
                {
                    isSave = this.Commit(this.xTableName);
                    if (isSave)
                    {
                        DataRow dataRow = ((DataRowView)this.objBindingSource.Current).Row;
                        recID = Convert.ToInt32(dataRow["ID"]);
                        DocNo = Convert.ToString(dataRow["DocNo"]);
                        Log(this.xTableName, recID, DocNo, "Edit");
                        this.OnCommit();
                    }
                }
                else if (_adding)
                {
                    try
                    {
                        isSave = this.Commit(this.xTableName);
                    }
                    catch { }
                    if (isSave)
                    {
                        DataRow newDataRow = ((DataRowView)this.objBindingSource.Current).Row;
                        recID = Convert.ToInt32(newDataRow["ID"]);
                        DocNo = Convert.ToString(newDataRow["DocNo"]);
                        Log(this.xTableName, recID, DocNo, "Add");
                        this.OnCommit();
                    }
                }
                if (isSave)
                {
                    this.SaveImage();
                    frmStatus = currentStatus.Load;
                    frmMode = currentMode.Load;
                    this.ControlsEnableDisable("Save");
                }

                //--------------------------------------------------------//
                timer1.Enabled = true;
                timer1.Start();

                frmMessage = new frmOperationMessage();
                frmMessage.BringToFront();
                frmMessage.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmMessage.ShowDialog();
                //--------------------------------------------------------//
            }
            return isSave;
        }
        //----------------------------------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmMessage.Dispose();
            timer1.Enabled = false;
            timer1.Stop();
        }
        public virtual void btnBNRegister_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnBNRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                int curRecID = Convert.ToInt32(curRow["ID"]);
                foreach (childTable child in this.Childs)
                {
                    this.objDataSet.Tables[child.tblName].Clear();
                }
                if (!string.IsNullOrEmpty(Qry))
                    dbClass.obj.FillByQry(objDataSet.Tables[this.xTableName], Qry);
                else
                    dbClass.obj.Fill(objDataSet.Tables[this.xTableName]);
                this.LoadChilds();
                int index = this.objBindingSource.Find("ID", curRecID);
                if (index > 0)
                    this.objBindingSource.Position = index;
            }
            catch { }
        }
        public virtual void btnBNPrint_Click(object sender, EventArgs e)
        {
        }
        public virtual void btnBNListReport_Click(object sender, EventArgs e)
        {
        }
        //----------------------------------------------------------------------------------
        protected virtual void DataNavigation()
        {
            try
            {
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                try
                {
                    int IssuedBy = 0;
                    try { IssuedBy = StaticInfo.userid; }
                    catch { }
                    string EMPName = dbClass.obj.GetCreatedBy(IssuedBy);
                    if (!string.IsNullOrEmpty(EMPName))
                        this.issuedBy = EMPName;
                }
                catch { }
            }
            catch { }
            //------------------------------
            this.LoadTACombo();
            this.LoadImage();
            //------------------------------
        }
        public virtual void ControlRefresh()
        {
            this.DataNavigation();
        }
        public void ApplySetting()
        {
            this.ParentForm.MdiParent.BackColor = StaticInfo.ctrBackColor;

            foreach (Control ctl in this.ParentForm.MdiParent.Controls)
            {
                CtlEnableDisable(ctl, false);
                //ctl.BackColor = StaticInfo.ctrBackColor;                
            }
        }
        protected void RefreshControls()
        {
            ((iFrmMain)this.ParentForm.MdiParent).RefreshControls();
        }
        protected void RefreshControls2()
        {
            ((iFrmMain2)this.ParentForm.MdiParent).RefreshControls2();
        }
        #endregion
        #region EnableDisable
        void ControlsEnableDisable(string mode)
        {
            if (basePanel1 != null) this.ControlsEnableDisable(basePanel1, mode);
        }
        public void ControlsEnableDisable(System.Windows.Forms.Panel basePanel, string mode)
        {
            if (basePanel1 == null) basePanel1 = basePanel;
            bool ctrmode = false;
            if (mode == "Add" || mode == "Edit") ctrmode = false;
            if (mode == "Cancel" || mode == "Load" || mode == "Save") ctrmode = true;
            if (basePanel1 != null) this.CtlEnableDisable(basePanel1, ctrmode);
        }

        List<Control> controlList = new List<Control>();
        private void findControlsOfType(Type type, Control.ControlCollection formControls, ref List<Control> controls)
        {
            foreach (Control control in formControls)
            {
                if (control.GetType() == type)
                    controls.Add(control);
                if (control.Controls.Count > 0)
                    findControlsOfType(type, control.Controls, ref controls);
            }
        }
        private void CtlEnableDisable(Control control, bool mode)
        {
            if (controlList.Count <= 0)
            {
                findControlsOfType(typeof(libDataGridView), this.Controls, ref controlList);
                findControlsOfType(typeof(TAZSearchDataGridView), this.Controls, ref controlList);
                findControlsOfType(typeof(TAButton), this.Controls, ref controlList);
                findControlsOfType(typeof(TAcboButton), this.Controls, ref controlList);
                findControlsOfType(typeof(TACheckBox), this.Controls, ref controlList);
                findControlsOfType(typeof(TAComboBox), this.Controls, ref controlList);
                findControlsOfType(typeof(TADateControl), this.Controls, ref controlList);
                findControlsOfType(typeof(TADateTimePicker), this.Controls, ref controlList);
                findControlsOfType(typeof(TADecimalControl), this.Controls, ref controlList);
                findControlsOfType(typeof(TAEncryptTextBox), this.Controls, ref controlList);
                findControlsOfType(typeof(TANumericUpDown), this.Controls, ref controlList);
                findControlsOfType(typeof(TAPictureBox), this.Controls, ref controlList);
                findControlsOfType(typeof(TAPictureBoxControl), this.Controls, ref controlList);
                findControlsOfType(typeof(TARadioButton), this.Controls, ref controlList);
                findControlsOfType(typeof(TATextBox), this.Controls, ref controlList);
                findControlsOfType(typeof(Label), this.Controls, ref controlList);

                findControlsOfType(typeof(TabControl), this.Controls, ref controlList);
                findControlsOfType(typeof(TableLayoutPanel), this.Controls, ref controlList);
                findControlsOfType(typeof(GroupBox), this.Controls, ref controlList);
                findControlsOfType(typeof(TreeView), this.Controls, ref controlList);
                findControlsOfType(typeof(ListView), this.Controls, ref controlList);
                findControlsOfType(typeof(Button), this.Controls, ref controlList);
            }
            //------------------------------------------------------------------------
            foreach (Control ctr in controlList.ToList())
                CtlReadOnly(ctr, mode);

        }
        private void CtlReadOnly(Control ctr, bool mode)
        {
            try
            {
                if (ctr.GetType() == typeof(Label))
                {
                    ctr.ForeColor = StaticInfo.ctrLabelForeColor;
                }
                if (ctr.GetType() == typeof(TabControl))
                {
                    List<Control> TabPages = new List<Control>();
                    findControlsOfType(typeof(TabPage), this.Controls, ref TabPages);

                    foreach (Control page in TabPages.ToList())
                        page.BackColor = StaticInfo.ctrBackColor;
                }
                if (ctr.GetType() == typeof(Button))
                {
                    ctr.BackColor = StaticInfo.ctrBackColor;
                    ctr.ForeColor = StaticInfo.ctrLabelForeColor;

                    ((Button)ctr).Enabled = mode;
                }
                if (ctr.GetType() == typeof(TAButton))
                {
                    //ctr.BackColor = StaticInfo.ctrBackColor;
                    //ctr.ForeColor = StaticInfo.ctrLabelForeColor;

                    ((TAButton)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TATextBox))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TATextBox)ctr).xBindingProperty != "") && (((TATextBox)ctr).xBindingProperty != null))
                            {
                                ((TATextBox)ctr).BindControl(this.objBindingSource, ((TATextBox)ctr).xBindingProperty);
                                if (((TATextBox)ctr).xIsShowInGrid == StaticInfo.YesNo.Yes)
                                    if ((((TATextBox)ctr).xColumnName != "") && (((TATextBox)ctr).xColumnName != null))
                                    {
                                        SearchDGVColumn objSDGV = new SearchDGVColumn();
                                        objSDGV.columnBindingProperty = ((TATextBox)ctr).xBindingProperty;
                                        objSDGV.fieldProperty = ((TATextBox)ctr).xBindingProperty;
                                        objSDGV.columnHeaderName = ((TATextBox)ctr).xColumnName;
                                        objSDGV.columnWidth = ((TATextBox)ctr).xColumnWidth;

                                        if (!SearchDGVList.Any(x => x.columnBindingProperty == objSDGV.columnBindingProperty))
                                            SearchDGVList.Add(objSDGV);
                                    }
                            }
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                    {
                        if ((((TATextBox)ctr).xBindingProperty != "") && (((TATextBox)ctr).xBindingProperty != null))
                        {
                            if ((((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.Decimal) || (((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.Digit))
                            {
                                ((TATextBox)ctr).Text = "0";
                                DataRowView curRow = (DataRowView)objBindingSource.Current;
                                curRow.BeginEdit();
                                curRow[((TATextBox)ctr).xBindingProperty] = 0;
                                curRow.EndEdit();
                            }
                            else
                            {
                                if (((TATextBox)ctr).xBindingProperty == "Code")
                                {
                                    string NextCode = dbClass.obj.getNextCode(TableName);

                                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                                    curRow.BeginEdit();
                                    curRow[((TATextBox)ctr).xBindingProperty] = NextCode;
                                    curRow.EndEdit();
                                }
                                else
                                {
                                    ((TATextBox)ctr).Text = "";
                                    DataRowView curRow = (DataRowView)objBindingSource.Current;
                                    curRow.BeginEdit();
                                    curRow[((TATextBox)ctr).xBindingProperty] = "";
                                    curRow.EndEdit();
                                }
                            }
                        }
                    }

                    ((TATextBox)ctr).ReadOnly = mode;
                }
                if (ctr.GetType() == typeof(TACheckBox))
                {
                    ctr.ForeColor = StaticInfo.ctrLabelForeColor;
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TACheckBox)ctr).xBindingProperty != "") && (((TACheckBox)ctr).xBindingProperty != null))
                                ((TACheckBox)ctr).BindControl(this.objBindingSource, ((TACheckBox)ctr).xBindingProperty);
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                        ((TACheckBox)ctr).Checked = false;

                    ((TACheckBox)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TARadioButton))
                {
                    ctr.ForeColor = StaticInfo.ctrLabelForeColor;
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TARadioButton)ctr).xBindingProperty != "") && (((TARadioButton)ctr).xBindingProperty != null))
                                ((TARadioButton)ctr).BindControl(this.objBindingSource, ((TARadioButton)ctr).xBindingProperty);
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                        ((TARadioButton)ctr).Checked = false;

                    if (((TARadioButton)ctr).xReadOnly == false)
                        ((TARadioButton)ctr).Enabled = !mode;
                }

                if (ctr.GetType() == typeof(TANumericUpDown))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TANumericUpDown)ctr).xBindingProperty != "") && (((TANumericUpDown)ctr).xBindingProperty != null))
                                ((TANumericUpDown)ctr).BindControl(this.objBindingSource, ((TANumericUpDown)ctr).xBindingProperty);
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                        ((TANumericUpDown)ctr).Text = "0";

                    ((TANumericUpDown)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TADecimalControl))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TADecimalControl)ctr).xBindingProperty != "") && (((TADecimalControl)ctr).xBindingProperty != null))
                                ((TADecimalControl)ctr).BindControl(this.objBindingSource, ((TADecimalControl)ctr).xBindingProperty);
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                        ((TADecimalControl)ctr).Text = "0";

                    ((TADecimalControl)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TADateTimePicker))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TADateTimePicker)ctr).xBindingProperty != "") && (((TADateTimePicker)ctr).xBindingProperty != null))
                            {
                                ((TADateTimePicker)ctr).BindControl(this.objBindingSource, ((TADateTimePicker)ctr).xBindingProperty);
                                if (((TADateTimePicker)ctr).xIsShowInGrid == StaticInfo.YesNo.Yes)
                                    if ((((TADateTimePicker)ctr).xColumnName != "") && (((TADateTimePicker)ctr).xColumnName != null))
                                    {
                                        SearchDGVColumn objSDGV = new SearchDGVColumn();
                                        objSDGV.columnBindingProperty = ((TADateTimePicker)ctr).xBindingProperty;
                                        objSDGV.fieldProperty = ((TADateTimePicker)ctr).xBindingProperty;
                                        objSDGV.columnHeaderName = ((TADateTimePicker)ctr).xColumnName;
                                        objSDGV.columnWidth = ((TADateTimePicker)ctr).xColumnWidth;

                                        if (!SearchDGVList.Any(x => x.columnBindingProperty == objSDGV.columnBindingProperty))
                                            SearchDGVList.Add(objSDGV);
                                    }
                            }
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                    {
                        if (((TADateTimePicker)ctr).xIsShowCurrentDate == StaticInfo.YesNo.Yes)
                            if ((((TADateTimePicker)ctr).xBindingProperty != "") && (((TADateTimePicker)ctr).xBindingProperty != null))
                                ((TADateTimePicker)ctr).Value = DateTime.Now;
                    }

                    ((TADateTimePicker)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TADateControl))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TADateControl)ctr).xBindingProperty != "") && (((TADateControl)ctr).xBindingProperty != null))
                            {
                                ((TADateControl)ctr).BindControl(this.objBindingSource, ((TADateControl)ctr).xBindingProperty);
                                if (((TADateControl)ctr).xIsShowInGrid == StaticInfo.YesNo.Yes)
                                    if ((((TADateControl)ctr).xColumnName != "") && (((TADateControl)ctr).xColumnName != null))
                                    {
                                        SearchDGVColumn objSDGV = new SearchDGVColumn();
                                        objSDGV.columnBindingProperty = ((TADateControl)ctr).xBindingProperty;
                                        objSDGV.fieldProperty = ((TADateControl)ctr).xBindingProperty;
                                        objSDGV.columnHeaderName = ((TADateControl)ctr).xColumnName;
                                        objSDGV.columnWidth = ((TADateControl)ctr).xColumnWidth;

                                        if (!SearchDGVList.Any(x => x.columnBindingProperty == objSDGV.columnBindingProperty))
                                            SearchDGVList.Add(objSDGV);
                                    }
                            }
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                    {
                        if (((TADateControl)ctr).xIsShowCurrentDate == StaticInfo.YesNo.Yes)
                        {
                            if ((((TADateControl)ctr).xBindingProperty != "") && (((TADateControl)ctr).xBindingProperty != null))
                            {
                                DataRowView curRow = (DataRowView)objBindingSource.Current;
                                curRow.BeginEdit();
                                curRow[((TADateControl)ctr).xBindingProperty] = DateTime.Now;
                                curRow.EndEdit();
                            }
                        }
                    }

                    foreach (Control citem in ((TADateControl)ctr).Controls)
                        foreach (Control citm in citem.Controls)
                            CtlReadOnly(citm, mode);
                }
                if (ctr.GetType() == typeof(TAComboBox))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            ((TAComboBox)ctr).DropDown += TAComboBox_DropDown;
                            DataRowView curRow = (DataRowView)objBindingSource.Current;
                            int ID = 0;
                            if (curRow != null)
                            {
                                try { ID = Convert.ToInt32(curRow[((TAComboBox)ctr).xBindingProperty]); }
                                catch { }
                            }
                            if ((((TAComboBox)ctr).xBindingProperty != "") && (((TAComboBox)ctr).xBindingProperty != null))
                            {
                                TAComboControlList.Add(ctr);

                                if (((TAComboBox)ctr).xColumnName != null || ((TAComboBox)ctr).xColumnName == "")
                                {
                                    if (((TAComboBox)ctr).xColumnName.Contains(","))
                                        ((TAComboBox)ctr).BindControl(this.objBindingSource, this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()].Copy(), ((TAComboBox)ctr).xColumnName, ((TAComboBox)ctr).xDisplayMember);
                                    else if (this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()] != null)
                                    {
                                        ((TAComboBox)ctr).BindControl(this.objBindingSource, this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()].Copy(), ID);
                                    }
                                    else
                                    {
                                        //((TAComboBox)ctr).BindControl(this.objBindingSource, this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()].Copy(), ID);
                                    }
                                }
                                else
                                    ((TAComboBox)ctr).BindControl(this.objBindingSource, this.objDataSet.Tables[(((TAComboBox)ctr).xTableName).ToString()].Copy(), ID);
                                //-------------------------------------------------------------//         
                                if (((TAComboBox)ctr).xIsShowInGrid == StaticInfo.YesNo.Yes)
                                {
                                    if ((((TAComboBox)ctr).xColumnName != "") && (((TAComboBox)ctr).xColumnName != null))
                                    {
                                        SearchDGVColumn objSDGV = new SearchDGVColumn();
                                        objSDGV.columnBindingProperty = ((TAComboBox)ctr).xBindingProperty;
                                        objSDGV.fieldProperty = ((TAComboBox)ctr).xColumnName;
                                        objSDGV.columnHeaderName = ((TAComboBox)ctr).xColumnName;
                                        objSDGV.columnWidth = ((TAComboBox)ctr).xColumnWidth;
                                        objSDGV.xTableName = ((TAComboBox)ctr).xTableName;
                                        objSDGV.xDisplayMember = ((TAComboBox)ctr).xDisplayMember;
                                        objSDGV.xValueMember = ((TAComboBox)ctr).ValueMember;


                                        if (!SearchDGVList.Any(x => x.columnBindingProperty == objSDGV.columnBindingProperty))
                                            SearchDGVList.Add(objSDGV);
                                    }
                                }
                            }
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch(Exception ex) 
                        {
                            xMessageBox.Show(ex.Message);
                        }
                    }
                    if (frmStatus == currentStatus.Add)
                    {
                        try
                        {
                            if ((((TAComboBox)ctr).xBindingProperty != "") && (((TAComboBox)ctr).xBindingProperty != null))
                            {
                                if (((TAComboBox)ctr).xIsShowDefault == StaticInfo.YesNo.Yes)
                                {
                                    ((TAComboBox)ctr).DataSource = dbClass.obj.FillComboByIsShowDefault(objDataSet.Tables[((TAComboBox)ctr).xTableName].Copy());
                                    if (((TAComboBox)ctr).DataSource != null)
                                    {
                                        try
                                        {
                                            Int32 ID = Convert.ToInt32(((DataTable)((TAComboBox)ctr).DataSource).Rows[0]["ID"]);
                                            DataRowView curRow = (DataRowView)objBindingSource.Current;
                                            curRow.BeginEdit();
                                            curRow[((TAComboBox)ctr).xBindingProperty] = ID;
                                            curRow.EndEdit();
                                        }
                                        catch { }
                                    }
                                    ((TAComboBox)ctr).SelectedIndex = 0;
                                }
                            }
                        }
                        catch { }
                    }
                    if (((TAComboBox)ctr).xReadOnly == false)
                        ((TAComboBox)ctr).Enabled = !mode;
                }
                if (ctr.GetType() == typeof(TAPictureBoxControl))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TAPictureBoxControl)ctr).xBindingProperty != "") && (((TAPictureBoxControl)ctr).xBindingProperty != null))
                                TAPictureControlList.Add(ctr);
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    if (frmStatus == currentStatus.Add)
                        ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = null;

                    foreach (Control citem in ((TAPictureBoxControl)ctr).Controls)
                        foreach (Control citm in citem.Controls)
                            CtlReadOnly(citm, mode);
                }
                if (ctr.GetType() == typeof(TAEncryptTextBox))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if ((((TAEncryptTextBox)ctr).xBindingProperty != "") && (((TAEncryptTextBox)ctr).xBindingProperty != null))
                            {
                                if (((TAEncryptTextBox)ctr).xIsEncrypt == StaticInfo.YesNo.Yes)
                                {
                                    foreach (Control ctr1 in ctr.Controls)
                                    {
                                        if (((TATextBox)ctr1).Name == "TxtBox")
                                            ((TATextBox)ctr1).BindControl(this.objBindingSource, ((TAEncryptTextBox)ctr).xBindingProperty);
                                    }
                                }
                                if (((TAEncryptTextBox)ctr).xIsEncrypt == StaticInfo.YesNo.No)
                                {
                                    foreach (Control ctr2 in ctr.Controls)
                                    {
                                        if (((TATextBox)ctr2).Name != "TxtBox")
                                            ((TATextBox)ctr2).BindControl(this.objBindingSource, ((TAEncryptTextBox)ctr).xBindingProperty);
                                    }
                                }
                            }
                            else
                                ControlNullBindingList.Add(ctr);
                        }
                        catch { }
                    }
                    foreach (Control ctr1 in ctr.Controls)
                    {
                        if ((((TATextBox)ctr1).xBindingProperty != "") && (((TATextBox)ctr1).xBindingProperty != null))
                            ((TATextBox)ctr1).Text = "";
                    }

                    ((TAEncryptTextBox)ctr).Enabled = !mode;
                }
                #region libDataGridView
                //--------------------------------------------------------
                if (ctr.GetType() == typeof(libDataGridView))
                {
                    if (this.Initialize)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(this.xTableName))
                            {
                                this.AddChild(this.xTableName, ((libDataGridView)ctr).xTableName, ((libDataGridView)ctr).xTableRelation, ((libDataGridView)ctr).xTableQuery);

                                ((libDataGridView)ctr).SetSource(this.objBindingSource, this.objDataSet.Tables[((libDataGridView)ctr).xTableName], ((libDataGridView)ctr).xTableRelation);

                                if (((libDataGridView)ctr).xIsDeleteColumn)
                                    ((libDataGridView)ctr).AddGridColumn(StaticInfo.gColumnType.DelColumn, "X", "x", 30, 30, "", 0);
                                if (((libDataGridView)ctr).xIsAutoNo)
                                    ((libDataGridView)ctr).AddGridColumn(StaticInfo.gColumnType.AutoNoColumn, "No", "No", 30, 3, "", 1);
                                if (!string.IsNullOrEmpty(((libDataGridView)ctr).xTableRelation.ToString()))
                                {
                                    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
                                    System.Windows.Forms.DataGridViewCellStyle DecimalColumnCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

                                    foreach (DataGridViewColumn col in ((libDataGridView)ctr).Columns)
                                    {
                                        if (((((System.Reflection.MemberInfo)(col.CellType))).Name).Equals("DGVComboBoxCell"))
                                        {
                                            if (!string.IsNullOrEmpty(((DGVComboBoxColumn)col).xBindingProperty))
                                            {
                                                col.DisplayIndex = col.Index + 2;
                                                DataTable dtCombo = new DataTable(((DGVComboBoxColumn)col).xTableName);

                                                ((DGVComboBoxColumn)col).DataPropertyName = ((DGVComboBoxColumn)col).xBindingProperty;
                                                ((DGVComboBoxColumn)col).DataSource = dbClass.obj.FillDGVComboBoxColumnByActive(dtCombo, ((DGVComboBoxColumn)col).xBindingQuery, ((DGVComboBoxColumn)col).xOrderBy);
                                                ((DGVComboBoxColumn)col).DisplayMember = ((DGVComboBoxColumn)col).xDisplayMember;
                                                ((DGVComboBoxColumn)col).ValueMember = ((DGVComboBoxColumn)col).xValueMember;
                                            }
                                        }
                                        else if (((((System.Reflection.MemberInfo)(col.CellType))).Name).Equals("DGVMCComboBoxCell"))
                                        {
                                            if (!string.IsNullOrEmpty(((DGVMCComboBoxColumn)col).xBindingProperty))
                                            {
                                                col.DisplayIndex = col.Index + 2;

                                                ((DGVMCComboBoxColumn)col).DataPropertyName = ((DGVMCComboBoxColumn)col).xBindingProperty;
                                                ((DGVMCComboBoxColumn)col).DataSource = dbClass.obj.FillByQryByActive(this.objDataSet.Tables[((DGVMCComboBoxColumn)col).xTableName].Copy(), ((DGVMCComboBoxColumn)col).xBindingQuery, ((DGVMCComboBoxColumn)col).xOrderBy);
                                                ((DGVMCComboBoxColumn)col).DisplayMember = ((DGVMCComboBoxColumn)col).xDisplayMember;
                                                ((DGVMCComboBoxColumn)col).ValueMember = ((DGVMCComboBoxColumn)col).xValueMember;
                                            }
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(col.DataPropertyName))
                                            {
                                                col.DisplayIndex = col.Index + 2;

                                                if (((((System.Reflection.MemberInfo)(col.CellType))).Name).Equals("DataGridViewTextBoxCell"))
                                                {
                                                    ((DGVTextBoxColumn)col).DataPropertyName = ((DGVTextBoxColumn)col).xBindingProperty;
                                                    if ((((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.DecimalColumn)
                                                        || (((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.NumberColumn))
                                                    {
                                                        if ((((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.DecimalColumn)
                                                        && (((DGVTextBoxColumn)col).xShowCurrency == System32.StaticInfo.YesNo.Yes))
                                                        {
                                                            DecimalColumnCellStyle.Format = "C2";
                                                            DecimalColumnCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                                                            DecimalColumnCellStyle.NullValue = "0.00";
                                                            DecimalColumnCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                                                            ((DGVTextBoxColumn)col).DefaultCellStyle = DecimalColumnCellStyle;
                                                        }
                                                        else
                                                        {
                                                            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                                                            ((DGVTextBoxColumn)col).DefaultCellStyle = dataGridViewCellStyle35;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(((libDataGridView)ctr).xTableRelation.ToString()))
                                {
                                    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
                                    System.Windows.Forms.DataGridViewCellStyle DecimalColumnCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

                                    foreach (DataGridViewColumn col in ((libDataGridView)ctr).Columns)
                                    {
                                        if (!string.IsNullOrEmpty(col.DataPropertyName))
                                        {
                                            if (((((System.Reflection.MemberInfo)(col.CellType))).Name).Equals("DataGridViewTextBoxCell"))
                                            {
                                                col.DisplayIndex = ((DGVTextBoxColumn)col).xDisplayIndex;
                                                ((DGVTextBoxColumn)col).DataPropertyName = ((DGVTextBoxColumn)col).xBindingProperty;
                                                ((DGVTextBoxColumn)col).ReadOnly = true;
                                                if ((((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.DecimalColumn)
                                                    || (((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.NumberColumn))
                                                {
                                                    if ((((DGVTextBoxColumn)col).xColumnType == System32.StaticInfo.gColumnType.DecimalColumn)
                                                        && (((DGVTextBoxColumn)col).xShowCurrency == System32.StaticInfo.YesNo.Yes))
                                                    {
                                                        DecimalColumnCellStyle.Format = "C2";
                                                        DecimalColumnCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                                                        DecimalColumnCellStyle.NullValue = "0.00";
                                                        DecimalColumnCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                                                        ((DGVTextBoxColumn)col).DefaultCellStyle = DecimalColumnCellStyle;
                                                    }
                                                    else
                                                    {
                                                        dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                                                        ((DGVTextBoxColumn)col).DefaultCellStyle = dataGridViewCellStyle35;
                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    ((libDataGridView)ctr).Enabled = !mode;
                }
                #endregion
                #region TAZSearchDataGridView
                if (ctr.GetType() == typeof(TAZSearchDataGridView))
                {
                    if (this.Initialize)
                    {
                        TAZSearchDGVControlList.Add(ctr);
                    }

                    ((TAZSearchDataGridView)ctr).Enabled = mode;
                }
                #endregion
                //--------------------------------------------------------
            }
            catch { }
        }
        void ClearControls()
        {
            if (ControlNullBindingList.Count > 0)
            {
                foreach (Control ctr in ControlNullBindingList)
                {
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TATextBox))
                    {
                        if ((((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.None) || (((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.DateOnly))
                            ((TATextBox)ctr).Text = "";
                        if ((((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.Decimal) || (((TATextBox)ctr).xMasked == System32.StaticInfo.Mask.Digit))
                            ((TATextBox)ctr).Text = "0";
                    }
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TACheckBox))
                        ((TACheckBox)ctr).Checked = false;
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TARadioButton))
                        ((TARadioButton)ctr).Checked = false;
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TANumericUpDown))
                        ((TANumericUpDown)ctr).Text = "0";
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TADecimalControl))
                        ((TADecimalControl)ctr).Text = "0";
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TADateTimePicker))
                        ((TADateTimePicker)ctr).Value = DateTime.Now;
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TADateControl))
                        ((TADateControl)ctr).DateTimePicker1.Value = DateTime.Now;
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TAComboBox))
                        try { ((TAComboBox)ctr).SelectedIndex = 0; }
                        catch { }
                    //------------------------------------------
                    //if (ctr.GetType() == typeof(TAPictureBoxControl))
                    //foreach (Control citem in ((TAPictureBoxControl)ctr).Controls)
                    //                    foreach (Control citm in citem.Controls)
                    //                        CtlReadOnly(citm, mode);
                    //------------------------------------------
                    if (ctr.GetType() == typeof(TAEncryptTextBox))
                    {
                        foreach (Control ctr1 in ctr.Controls)
                            if (ctr1.GetType() == typeof(TATextBox))
                                try { ((TATextBox)ctr1).Text = ""; }
                                catch { }
                    }
                    //------------------------------------------

                }
            }
        }
        void TAComboBox_DropDown(object sender, EventArgs e)
        {
            TAComboBox TACB = (TAComboBox)sender;
            try
            {
                DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                string FillByTableName = TACB.xTableName;
                string Orderby=TACB.xDisplayMember;
                int FieldID = 0; string FillByFieldID = string.Empty;
                if (!string.IsNullOrEmpty(TACB.xFillByFieldID))
                {
                    FillByFieldID = TACB.xFillByFieldID;
                    FieldID = Convert.ToInt32(curRow[FillByFieldID]);

                    if (FillByFieldID.ToString().Equals("BillingCountryID"))
                    {
                        FillByFieldID = "CountryID";
                    }
                    if (FillByFieldID.ToString().Equals("BillingStateID"))
                    {
                        FillByFieldID = "StateID";
                    }
                    if (FillByFieldID.ToString().Equals("BillingCityID"))
                    {
                        FillByFieldID = "CityID";
                    }
                    if (FillByFieldID.ToString().Equals("ShippingCountryID"))
                    {
                        FillByFieldID = "CountryID";
                    }
                    if (FillByFieldID.ToString().Equals("ShippingStateID"))
                    {
                        FillByFieldID = "StateID";
                    }
                    if (FillByFieldID.ToString().Equals("ShippingCityID"))
                    {
                        FillByFieldID = "CityID";
                    }
                    if (FillByFieldID.ToString().Equals("WarehouseID"))
                    {       
                        FillByFieldID = "MID";
                    }
                }
                TACB.DataSource = dbClass.obj.FillComboByFieldID(objDataSet.Tables[FillByTableName].Copy(), FillByFieldID, FieldID, Orderby);
            }
            catch(Exception ex) 
            {
                string mesage= ex.Message;
            }
        }
        #endregion
        #region Log
        public static void LogOff()
        {
            try
            {
                MainDataSet objDataSet = new MainDataSet();
                //DbClass dbClass.obj = new DbClass();
                //List<SqlParameter> updateParaList = new List<SqlParameter>() { new SqlParameter() { SourceColumn = "[IsLogin]", ParameterName = "@IsLogin", SqlDbType = SqlDbType.Int, Value = 0 } };
                //List<SqlParameter> sqlParaList = new List<SqlParameter>() { new SqlParameter() { SourceColumn = "[ID]", ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = StaticInfo.userid, SourceVersion = DataRowVersion.Original } };
                //int xReturn = dbclass.Update(objDataSet.User, "User", updateParaList, sqlParaList);
                //-------------------------------------------------
                DataTable dt = objDataSet.LoginActivity.Copy();
                DataRow newRow = dt.NewRow();
                newRow["userId"] = StaticInfo.userid;
                newRow["isLogin"] = false;
                newRow["loginDate"] = DateTime.Now;
                newRow["POSID"] = StaticInfo.POSID;
                dt.Rows.Add(newRow); dbClass.obj.Update(dt);
                //-------------------------------------------------
            }
            catch { }
        }
        public static void Log(string tblName, int recID, string DocNo, string status)
        {
            try
            {
                MainDataSet objDataSet = new MainDataSet();
                //DbClass dbClass.obj = new DbClass();
                //-------------------------------------------------
                DataTable dt = objDataSet.LogActivity.Copy();
                DataRow newRow = dt.NewRow();
                newRow["userID"] = StaticInfo.userid;
                newRow["tblName"] = tblName;
                newRow["recID"] = recID;
                if (status == "Add")
                    newRow["isAdd"] = true;
                else if (status == "Edit")
                    newRow["isEdit"] = true;
                else if (status == "Delete")
                    newRow["isDelete"] = true;
                newRow["activityDate"] = DateTime.Now;
                newRow["POSID"] = StaticInfo.POSID;
                newRow["DocNo"] = DocNo;
                dt.Rows.Add(newRow); dbClass.obj.Update(dt);
                //-------------------------------------------------
            }
            catch { }
        }
        private void DisplayMessage(string DisplayMessage, int ModifyUserID)
        {
            //List<SqlParameter> sqlParaList = new List<SqlParameter>() { new SqlParameter() { SourceColumn = "[ID]", ParameterName = "@userId", SqlDbType = SqlDbType.Int, Value = ModifyUserID } };
            //dbClass.Fill(objDataSet.User, "User", sqlParaList);
            //String empName = Convert.ToString(objDataSet.User.Rows[0]["Name"]);
            //MessageBox.Show(DisplayMessage + empName);
        }
        //public DataTable searching(DataTable dt, string searchingColumn, string searcingValue)
        //{
        //    string parameterName = "@" + searchingColumn;
        //    List<SqlParameter> sqlParaList = new List<SqlParameter>() { new SqlParameter() { SourceColumn = searchingColumn, ParameterName = parameterName, SqlDbType = SqlDbType.NVarChar, Value = searcingValue } };
        //    return dbClass.Fill(dt, dt.TableName, sqlParaList);
        //}
        #endregion
        #region CustomValidation
        protected virtual bool DataValidation() { return true; }
        public bool CustomValidation(bool validation)
        {
            if (DataValidation())
            {
                blist = new List<bool>();
                this.CtlValidation(basePanel1, validation);
                return !blist.Contains(false);
            }
            else
                return false;
        }
        List<bool> blist = null;
        private void CtlValidation(Control control, bool validation)
        {
            foreach (Control ctr in controlList.ToList())
                blist.Add(Ctlvalidation1(ctr, validation));

        }
        private bool Ctlvalidation1(Control ctr, bool validation)
        {
            bool Validation = true;
            bool Duplicate = true;

            if (validation)
            {
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TATextBox))
                {
                    if (((TATextBox)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TATextBox)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TATextBox)ctr), "Required Field Validation...!"); Validation = false; }
                        else
                        { errorProvider1.SetError(((TATextBox)ctr), ""); Validation = true; }
                    if (((TATextBox)ctr).xIsAllowDuplicate == StaticInfo.YesNo.No)
                    {
                        if (!string.IsNullOrEmpty(((TATextBox)ctr).Text.Trim()))
                        {
                            DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                            if (dbClass.obj.isExist(curRow.Row.Table.TableName, ((TATextBox)ctr).xBindingProperty, ((TATextBox)ctr).Text.Trim(), Convert.ToInt32(curRow["ID"])))
                            { errorProvider1.SetError(((TATextBox)ctr), ((TATextBox)ctr).xBindingProperty + " Is Duplicate...!"); Duplicate = false; }
                            else
                            { errorProvider1.SetError(((TATextBox)ctr), ""); Duplicate = true; }
                        }
                        else
                        {
                            if (((TATextBox)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                                if (((TATextBox)ctr).Text.Trim() == string.Empty)
                                { errorProvider1.SetError(((TATextBox)ctr), "Required Field Validation...!"); Validation = false; }
                                else
                                { errorProvider1.SetError(((TATextBox)ctr), ""); Duplicate = true; }
                        }
                    }
                }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TAEncryptTextBox))
                {
                    foreach (Control ctr1 in ctr.Controls)
                    {
                        if (ctr1.GetType() == typeof(TATextBox))
                        {
                            if (((TATextBox)ctr1).Name != "TxtBox")
                            {
                                if (((TATextBox)ctr1).xIsRequired == StaticInfo.YesNo.Yes)
                                    if (((TATextBox)ctr1).Text.Trim() == string.Empty)
                                    { errorProvider1.SetError(((TAEncryptTextBox)ctr), "Required Field Validation...!"); Validation = false; }
                                    else
                                    { errorProvider1.SetError(((TAEncryptTextBox)ctr), ""); Validation = true; }
                                if (((TATextBox)ctr1).xIsAllowDuplicate == StaticInfo.YesNo.No)
                                {
                                    if (!string.IsNullOrEmpty(((TATextBox)ctr1).Text.Trim()))
                                    {
                                        DataRowView curRow = (DataRowView)this.objBindingSource.Current;
                                        if (dbClass.obj.isExist(curRow.Row.Table.TableName, ((TATextBox)ctr1).xBindingProperty, ((TATextBox)ctr1).Text.Trim(), Convert.ToInt32(curRow["ID"])))
                                        { errorProvider1.SetError(((TAEncryptTextBox)ctr), ((TATextBox)ctr1).xBindingProperty + " Is Duplicate...!"); Duplicate = false; }
                                        else
                                        { errorProvider1.SetError(((TAEncryptTextBox)ctr), ""); Duplicate = true; }
                                    }
                                    else
                                    {
                                        if (((TATextBox)ctr1).xIsRequired == StaticInfo.YesNo.Yes)
                                            if (((TATextBox)ctr1).Text.Trim() == string.Empty)
                                            { errorProvider1.SetError(((TAEncryptTextBox)ctr), "Required Field Validation...!"); Validation = false; }
                                            else
                                            { errorProvider1.SetError(((TAEncryptTextBox)ctr), ""); Duplicate = true; }
                                    }
                                }
                            }
                        }
                    }
                }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TANumericUpDown))
                    if (((TANumericUpDown)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TANumericUpDown)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TANumericUpDown)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TANumericUpDown)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TADateTimePicker))
                    if (((TADateTimePicker)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TADateTimePicker)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TADateTimePicker)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TADateTimePicker)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TADateControl))
                    if (((TADateControl)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TADateControl)ctr).txtDate.Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TADateControl)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TADateControl)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TAComboBox))
                    if (((TAComboBox)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TAComboBox)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TAComboBox)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TAComboBox)ctr), ""); Validation = true; }
                //-------------------------------------------------------------                
                if (ctr.GetType() == typeof(MultiColumnComboBox))
                    if (((MultiColumnComboBox)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((MultiColumnComboBox)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((MultiColumnComboBox)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((MultiColumnComboBox)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TADecimalControl))
                    if (((TADecimalControl)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TADecimalControl)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TADecimalControl)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TADecimalControl)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
                if (ctr.GetType() == typeof(TACheckBox))
                    if (((TACheckBox)ctr).xIsRequired == StaticInfo.YesNo.Yes)
                        if (((TACheckBox)ctr).Text.Trim() == string.Empty)
                        { errorProvider1.SetError(((TACheckBox)ctr), "Required Field Validation...!"); Validation = false; }
                        else { errorProvider1.SetError(((TACheckBox)ctr), ""); Validation = true; }
                //-------------------------------------------------------------
            }
            else
            {
                if (ctr.GetType() == typeof(TextBox)) errorProvider1.SetError(((TextBox)ctr), "");
                if (ctr.GetType() == typeof(TATextBox)) errorProvider1.SetError(((TATextBox)ctr), "");
                if (ctr.GetType() == typeof(ComboBox)) errorProvider1.SetError(((ComboBox)ctr), "");
                if (ctr.GetType() == typeof(TANumericUpDown)) errorProvider1.SetError(((TANumericUpDown)ctr), "");
                if (ctr.GetType() == typeof(TAComboBox)) errorProvider1.SetError(((TAComboBox)ctr), "");
                if (ctr.GetType() == typeof(CheckBox)) errorProvider1.SetError(((CheckBox)ctr), "");
                if (ctr.GetType() == typeof(TACheckBox)) errorProvider1.SetError(((TACheckBox)ctr), "");
                if (ctr.GetType() == typeof(TADateTimePicker)) errorProvider1.SetError(((TADateTimePicker)ctr), "");
                if (ctr.GetType() == typeof(TADateControl)) errorProvider1.SetError(((TADateControl)ctr), "");
                if (ctr.GetType() == typeof(TAEncryptTextBox)) errorProvider1.SetError(((TAEncryptTextBox)ctr), "");
                if (ctr.GetType() == typeof(MultiColumnComboBox)) errorProvider1.SetError(((MultiColumnComboBox)ctr), "");
                if (ctr.GetType() == typeof(TADecimalControl)) errorProvider1.SetError(((TADecimalControl)ctr), "");
                //if (ctr.GetType() == typeof(TADateControl)) foreach (Control citem in ((TADateControl)ctr).Controls) foreach (Control citm in citem.Controls) Ctlvalidation1(citm, validation);

            }
            if ((Validation == false) || (Duplicate == false))
                return false;
            else
                return true;
        }

        #endregion
    }
    public class MessageBox : UserControl
    {
        public DialogResult Show(string text)
        {
            ControlLibrary.CCMessageBox messageBox = new ControlLibrary.CCMessageBox(text);
            messageBox.Opacity = 0.90;
            DialogResult dr = messageBox.ShowDialog();
            return dr;
        }
        public DialogResult Show(string text, string caption)
        {
            ControlLibrary.CCMessageBox messageBox = new ControlLibrary.CCMessageBox(text, caption);
            messageBox.Opacity = 0.90;
            DialogResult dr = messageBox.ShowDialog();
            return dr;
        }
        public DialogResult Show(string text, string caption, CCMessageBox.iMessageBoxButtons button)
        {
            ControlLibrary.CCMessageBox messageBox = new ControlLibrary.CCMessageBox(text, caption, button);
            messageBox.Opacity = 0.90;
            DialogResult dr = messageBox.ShowDialog();
            return dr;
        }
        public DialogResult Show(string text, CCMessageBox.iMessageBoxButtons button, CCMessageBox.iMessageBoxIcon Icon)
        {
            ControlLibrary.CCMessageBox messageBox = new ControlLibrary.CCMessageBox(text, button, Icon);
            messageBox.Opacity = 0.90;
            DialogResult dr = messageBox.ShowDialog();
            return dr;
        }
        public DialogResult Show(string text, string caption, CCMessageBox.iMessageBoxButtons button, CCMessageBox.iMessageBoxIcon Icon)
        {
            ControlLibrary.CCMessageBox messageBox = new ControlLibrary.CCMessageBox(text, caption, button, Icon);
            messageBox.Opacity = 0.90;
            DialogResult dr = messageBox.ShowDialog();
            return dr;
        }
    }
    public class LoginDetail
    {
        MessageBox xMessageBox = new MessageBox();
        MainDataSet objDataSet = new MainDataSet();
        public void ColorSetting()
        {
            DataTable dt = dbClass.obj.FillByQryByActive(objDataSet.Tables["WarehouseSettings"], "[BackColor], [ForeColor]");
            if (dt.Rows.Count > 0)
            {
                int backColor = Convert.ToInt32(dt.Rows[0]["BackColor"]);
                int foreColor = Convert.ToInt32(dt.Rows[0]["ForeColor"]);
                StaticInfo.ctrBackColor = Color.FromArgb(backColor);
                StaticInfo.ctrLabelForeColor = Color.FromArgb(foreColor);
            }
            else
            {
                StaticInfo.ctrBackColor = System.Drawing.Color.LightSteelBlue;
                StaticInfo.ctrLabelForeColor = System.Drawing.Color.Black;
            }
        }
        public bool IswithinDateTime(DataTable dt)
        {
            bool bResult = true;
            //string LoginStartDate0 = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("2019-01-01")));
            //string LoginEndDate0 = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("2090-12-31")));
            //string LoginStartTime0 = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("01:00")));
            //string LoginEndTime0 = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("23:59")));
            //string LoginEndTime0 = System32.EncryptDecrypt.Encrypt(Convert.ToString(Convert.ToDateTime("04:30")));
            
            //Developer: Mujahid Ali Code 
            string sLoginStartDate = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginStartDate"]));
            string sLoginEndDate = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginEndDate"]));
            string sLoginStartTime = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginStartTime"]));
            string sLoginEndTime = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginEndTime"]));
            
            DateTime tLoginStartDate = Convert.ToDateTime(sLoginStartDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            DateTime tLoginEndDate = Convert.ToDateTime(sLoginEndDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            DateTime tLoginStartTime = Convert.ToDateTime(sLoginStartTime, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            DateTime tLoginEndTime = Convert.ToDateTime(sLoginEndTime, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            //DateTime tLoginStartDate = Convert.ToDateTime(sLoginStartDate).Date;
            //DateTime tLoginEndDate = Convert.ToDateTime(sLoginEndDate).Date;

            //DateTime tLoginStartTime = Convert.ToDateTime(sLoginStartTime);
            //DateTime tLoginEndTime = Convert.ToDateTime(sLoginEndTime);
            StaticInfo.UserLoginEndTime = tLoginEndTime;

            try
            {
                if ((tLoginStartDate <= DateTime.Now.Date) && (tLoginEndDate >= DateTime.Now.Date))
                {
                    if (StaticInfo.userLevel > 2)
                    {
                        if (tLoginStartTime.TimeOfDay >= DateTime.Now.TimeOfDay)
                        {
                            bResult = false;
                            Cursor.Current = Cursors.Default;
                            xMessageBox.Show("Login Time is not started.....");
                            return false;
                        }
                        if (tLoginEndTime.TimeOfDay <= DateTime.Now.TimeOfDay)
                        {
                            bResult = false;
                            Cursor.Current = Cursors.Default;
                            xMessageBox.Show("Login Time is expired.....");
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    bResult = false;
                    Cursor.Current = Cursors.Default;
                    xMessageBox.Show("Login Date is expired.....");
                    return false;
                }

                return bResult;
            }
            catch(Exception ex)
            {
                xMessageBox.Show("Dateformat is expired!", ex.Message);
                return false;
            }
        }
        public void ApplicationSetting(DataTable dt)
        {
            StaticInfo.userid = Convert.ToInt32(dt.Rows[0]["ID"]);
            StaticInfo.userName = System32.EncryptDecrypt.Decrypt(Convert.ToString(dt.Rows[0]["LoginName"]));
            StaticInfo.userGroupID = Convert.ToInt32(dt.Rows[0]["UserGroupID"]);
            StaticInfo.userLevel = Convert.ToInt32(dt.Rows[0]["UserGroupID"]);
            StaticInfo.EmployeeName = "";
            StaticInfo.CompanyID = 0;
            StaticInfo.WarehouseID = 0;
            StaticInfo.StoreID = 0;
            StaticInfo.BranchName = "";
            StaticInfo.IsLoginForWarehouse = false;
            StaticInfo.IsLoginForStore = false;
            StaticInfo.LoginWarehouseID = 0;
            StaticInfo.LoginStoreID = 0;
            StaticInfo.SaleTaxCategoryID = 0;
            StaticInfo.SaleTaxPartsRate = 0;

        }
        public void CompanySetting(DataTable dt)
        {
            StaticInfo.MainCurSign = "$";

            StaticInfo.POSID = dbClass.obj.getPOSID();
                        
            StaticInfo.userid = Convert.ToInt32(dt.Rows[0]["ID"]);
            StaticInfo.EmployeeName = Convert.ToString(dt.Rows[0]["Name"]);
            StaticInfo.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
            StaticInfo.WarehouseID = Convert.ToInt32(dt.Rows[0]["WarehouseID"]);
            if (dt.Rows[0]["StoreID"] != DBNull.Value)
                StaticInfo.StoreID = Convert.ToInt32(dt.Rows[0]["StoreID"]);
            else
                StaticInfo.StoreID = 1;

            if (dt.Rows[0]["IsLoginForWarehouse"] != DBNull.Value)
                StaticInfo.IsLoginForWarehouse = Convert.ToBoolean(dt.Rows[0]["IsLoginForWarehouse"]);
            if (dt.Rows[0]["IsLoginForStore"] != DBNull.Value)
                StaticInfo.IsLoginForStore = Convert.ToBoolean(dt.Rows[0]["IsLoginForStore"]);
            if (dt.Rows[0]["LoginWarehouseID"] != DBNull.Value)
                StaticInfo.LoginWarehouseID = Convert.ToInt32(dt.Rows[0]["LoginWarehouseID"]);
            if (dt.Rows[0]["LoginStoreID"] != DBNull.Value)
                StaticInfo.LoginStoreID = Convert.ToInt32(dt.Rows[0]["LoginStoreID"]);
                    
            dbClass.obj.GetInfo(objDataSet.Company, StaticInfo.CompanyID);
            if (StaticInfo.IsLoginForWarehouse)
            {
                if (StaticInfo.LoginWarehouseID > 0)
                {
                    dbClass.obj.GetInfo(objDataSet.Warehouse, StaticInfo.LoginWarehouseID);
                    StaticInfo.WarehouseName = Convert.ToString(objDataSet.Warehouse.Rows[0]["CoName"]);
                    StaticInfo.SaleTaxCategoryID = Convert.ToInt32(objDataSet.Warehouse.Rows[0]["SaleTaxCategoryID"]);
                    StaticInfo.SaleTaxPartsRate = dbClass.obj.getSaleTaxRateFromSaleTaxCategorybyID(StaticInfo.SaleTaxCategoryID);
                }
            }
            else if (StaticInfo.IsLoginForStore)
            {
                if (StaticInfo.LoginStoreID > 0)
                {
                    dbClass.obj.GetInfo(objDataSet.Warehouse, StaticInfo.WarehouseID);
                    StaticInfo.WarehouseName = Convert.ToString(objDataSet.Warehouse.Rows[0]["CoName"]);
                    dbClass.obj.GetInfo(objDataSet.WarehouseStore, StaticInfo.LoginStoreID);
                    StaticInfo.BranchName = Convert.ToString(objDataSet.WarehouseStore.Rows[0]["CoName"]);
                    StaticInfo.SaleTaxCategoryID = Convert.ToInt32(objDataSet.WarehouseStore.Rows[0]["SaleTaxCategoryID"]);
                    StaticInfo.SaleTaxPartsRate = dbClass.obj.getSaleTaxRateFromSaleTaxCategorybyID(StaticInfo.SaleTaxCategoryID);
                }
            }
            else if ((!StaticInfo.IsLoginForWarehouse) && (!StaticInfo.IsLoginForStore))
            {
                dbClass.obj.GetInfo(objDataSet.Warehouse, StaticInfo.WarehouseID);
                StaticInfo.WarehouseName = Convert.ToString(objDataSet.Warehouse.Rows[0]["CoName"]);
                dbClass.obj.GetInfo(objDataSet.WarehouseStore, StaticInfo.StoreID);
                StaticInfo.BranchName = Convert.ToString(objDataSet.WarehouseStore.Rows[0]["CoName"]);
            }
            StaticInfo.CompanyCode = Convert.ToString(objDataSet.Company.Rows[0]["CoCode"]);
            StaticInfo.CompanyName = Convert.ToString(objDataSet.Company.Rows[0]["CoName"]);
            StaticInfo.CompanyAddress = Convert.ToString(objDataSet.Company.Rows[0]["CoAddress"]);
            StaticInfo.CompanyPhone = Convert.ToString(objDataSet.Company.Rows[0]["CoPhone"]);
            StaticInfo.CoFinYearStrMonth = Convert.ToInt32(Convert.ToString(objDataSet.Company.Rows[0]["CoFinYearStrMonth"]));
            StaticInfo.CoFinEndYear = dbClass.obj.getFinancialYearEnd();
            //----------------------------------------------------------------------------------------------
        }
        public void LoginActivity()
        {
            try
            {
                //---------------------------------------------------//
                DataTable dt = objDataSet.LoginActivity.Copy();
                DataRow newRow = dt.NewRow();
                newRow["UserId"] = StaticInfo.userid;
                newRow["IsLogin"] = true;
                newRow["LoginDate"] = DateTime.Now;
                newRow["POSID"] = StaticInfo.POSID;
                dt.Rows.Add(newRow); dbClass.obj.Update(dt);
                //---------------------------------------------------//
                string LoginDate = System32.EncryptDecrypt.Encrypt(Convert.ToString(DateTime.Now.Date.Year) + "-" + Convert.ToString(DateTime.Now.Date.Month) + "-" + Convert.ToString(DateTime.Now.Date.Day));
                string LoginTime = System32.EncryptDecrypt.Encrypt(Convert.ToString(DateTime.Now));
                StaticInfo.UserLoginDetailID = dbClass.obj.AddUserLoginDetail(StaticInfo.userid, LoginDate, LoginTime);
                //---------------------------------------------------//
            }
            catch { }
        }

    }
    //public class Search
    //{
    //    frmCtr frmCtr = null;
    //    SearchUserControl ctr = null;
    //    BindingSource bindingSource = null;
    //    string dataMember = null;
    //    object dataType = null;
    //    public Search(object dataSource, string dataMember, object dataType, System.Windows.Forms.Control control, DataTable dataTable = null, string displayMember = "")
    //    {
    //        try
    //        {
    //            this.bindingSource = (BindingSource)dataSource;
    //            this.dataMember = dataMember;
    //            this.dataType = dataType;
    //            foreach (Control ctrPanel in control.Controls)
    //            {
    //                if (ctrPanel.GetType() == typeof(Panel))
    //                {
    //                    if (ctrPanel.Name == "WorkingPanel")
    //                    {
    //                        foreach (Control ctrSearch in ctrPanel.Controls)
    //                        {
    //                            if (ctrSearch.GetType() == typeof(SearchUserControl))
    //                            {
    //                                ctrSearch.Dispose();
    //                                break;
    //                            }
    //                        }
    //                        break;
    //                    }
    //                }
    //            }
    //            if (control.Name == "WorkingPanel")
    //            {
    //                //control.Controls.Remove(ctr);
    //                foreach (Control ctrSearch in control.Controls)
    //                {
    //                    if (ctrSearch.GetType() == typeof(SearchUserControl))
    //                    {
    //                        ctrSearch.Dispose();
    //                        break;
    //                    }
    //                }
    //            }

    //            ctr = new SearchUserControl();
    //            int ctrleft = control.Width - ctr.Width;
    //            ctr.lblDataMember.Text = this.dataMember;
    //            //ctr.Location = new System.Drawing.Point(907, 0);            
    //            ctr.Location = new System.Drawing.Point(ctrleft, 0);
    //            ctr.TabIndex = 11163;

    //            ctr.BindControl(this.bindingSource, this.dataMember, this.dataType, dataTable, displayMember);

    //            if (control.Name == "WorkingPanel")
    //            {
    //                control.Controls.Add(ctr);
    //                ctr.txtBoxSearch.Focus();
    //            }
    //        }
    //        catch { }

    //        //frmCtr = new frmCtr();            

    //    }
    //    public void Show()
    //    {
    //        try
    //        {
    //            frmCtr.Text = "Searching... ( " + this.dataMember + " )";
    //            frmCtr.Height = ctr.Height + 40; frmCtr.Width = ctr.Width + 20;
    //            frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    //            frmCtr.Controls.Add(ctr);
    //            frmCtr.BringToFront();
    //            frmCtr.Show();
    //        }
    //        catch { }

    //        //frmCtr.ShowDialog();
    //    }
    //}

    public class Search
    {
        Form frmCtr = null;
        SearchUserControl ctr = null;
        BindingSource bindingSource = null;
        string dataMember = null;
        object dataType = null;
        //public Search(object dataSource, string dataMember, object dataType)
        //{
        //    this.bindingSource = (BindingSource)dataSource;
        //    this.dataMember = dataMember;
        //    this.dataType = dataType;
        //    ctr = new SearchUserControl();
        //    ctr.BindControl(this.bindingSource, this.dataMember, this.dataType);

        //    frmCtr = new Form();
        //}
        public Search(object dataSource, string dataMember, object dataType, System.Windows.Forms.Control control, DataTable dataTable = null, string displayMember = "")
        {
            try
            {
                this.bindingSource = (BindingSource)dataSource;
                this.dataMember = dataMember;
                this.dataType = dataType;
                foreach (Control ctrPanel in control.Controls)
                {
                    if (ctrPanel.GetType() == typeof(Panel))
                    {
                        if (ctrPanel.Name == "WorkingPanel")
                        {
                            foreach (Control ctrSearch in ctrPanel.Controls)
                            {
                                if (ctrSearch.GetType() == typeof(SearchUserControl))
                                {
                                    ctrSearch.Dispose();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                if (control.Name == "WorkingPanel")
                {
                    //control.Controls.Remove(ctr);
                    foreach (Control ctrSearch in control.Controls)
                    {
                        if (ctrSearch.GetType() == typeof(SearchUserControl))
                        {
                            ctrSearch.Dispose();
                            break;
                        }
                    }
                }

                ctr = new SearchUserControl();
                int ctrleft = control.Width - ctr.Width;
                ctr.lblDataMember.Text = this.dataMember;

                ctr.Location = new System.Drawing.Point(ctrleft - 23, 2);
                ctr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                ctr.Name = "searchUserControl1";
                ctr.Size = new System.Drawing.Size(259, 49);
                ctr.TabIndex = 11672;

                ctr.BindControl(this.bindingSource, this.dataMember, this.dataType, dataTable, displayMember);

                if (control.Name == "WorkingPanel")
                {
                    control.Controls.Add(ctr);
                    control.Controls.SetChildIndex(ctr, 0);ctr.txtBoxSearch.Focus();
                }
            }
            catch { }
        }
        public void Show()
        {
            try
            {
                //frmCtr.Text = "Searching... ( " + this.dataMember + " )"; 
                //frmCtr.Height = ctr.Height + 40; frmCtr.Width = ctr.Width + 20;
                //frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //frmCtr.Controls.Add(ctr);
                //frmCtr.BringToFront();
                //frmCtr.Show();
            }
            catch { }

            //frmCtr.ShowDialog();
        }
        //public void Show(string xBindingProperty)
        //{
        //    try
        //    {
        //        frmCtr.Text = "Searching...(" + xBindingProperty + ")";
        //        frmCtr.Height = ctr.Height + 40; frmCtr.Width = ctr.Width + 20;
        //        frmCtr.FormBorderStyle = FormBorderStyle.None;
        //        frmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        //        frmCtr.Controls.Add(ctr);
        //        frmCtr.BringToFront();
        //        frmCtr.ShowDialog();
        //    }
        //    catch { }
        //}
    }
    public class SearchDGVColumn
    {
        public string columnBindingProperty { get; set; }
        public string columnHeaderName { get; set; }
        public int columnWidth { get; set; }
        public string xTableName { get; set; }
        public string xDisplayMember { get; set; }
        public string xValueMember { get; set; }
        public string fieldProperty { get; set; }
    }
}
