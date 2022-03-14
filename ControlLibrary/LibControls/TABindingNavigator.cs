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
    public partial class TABindingNavigator : UserControl
    {
        private bool mainBaseBindingNavigatorIsVisible = true;
        public bool xMainBaseBindingNavigatorIsVisible
        {
            get { return mainBaseBindingNavigatorIsVisible; }
            set { mainBaseBindingNavigatorIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNRefreshIsVisible = true;
        public bool xbtnBNRefreshIsVisible
        {
            get { return btnBNRefreshIsVisible; }
            set { btnBNRefreshIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNListReportIsVisible = true;
        public bool xbtnBNListReportIsVisible
        {
            get { return btnBNListReportIsVisible; }
            set { btnBNListReportIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNProcessIsVisible = false;
        public bool xbtnBNProcessIsVisible
        {
            get { return btnBNProcessIsVisible; }
            set { btnBNProcessIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNPrintIsVisible = true;
        public bool xbtnBNPrintIsVisible
        {
            get { return btnBNPrintIsVisible; }
            set { btnBNPrintIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNRegisterIsVisible = true;
        public bool xbtnBNRegisterIsVisible
        {
            get { return btnBNRegisterIsVisible; }
            set { btnBNRegisterIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNCancelItemIsVisible = true;
        public bool xbtnBNCancelItemIsVisible
        {
            get { return btnBNCancelItemIsVisible; }
            set { btnBNCancelItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNSaveItemIsVisible = true;
        public bool xbtnBNSaveItemIsVisible
        {
            get { return btnBNSaveItemIsVisible; }
            set { btnBNSaveItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNDeleteItemIsVisible = true;
        public bool xbtnBNDeleteItemIsVisible
        {
            get { return btnBNDeleteItemIsVisible; }
            set { btnBNDeleteItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNEditItemIsVisible = true;
        public bool xbtnBNEditItemIsVisible
        {
            get { return btnBNEditItemIsVisible; }
            set { btnBNEditItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNAddItemIsVisible = true;
        public bool xbtnBNAddItemIsVisible
        {
            get { return btnBNAddItemIsVisible; }
            set { btnBNAddItemIsVisible = value; }
        }
        //------------------------------------------
        private bool BNSeparatorIsVisible = true;
        public bool xBNSeparatorIsVisible
        {
            get { return BNSeparatorIsVisible; }
            set { BNSeparatorIsVisible = value; }
        }
        //------------------------------------------
        private bool BNSeparator1IsVisible = true;
        public bool xBNSeparator1IsVisible
        {
            get { return BNSeparator1IsVisible; }
            set { BNSeparator1IsVisible = value; }
        }
        //------------------------------------------
        private bool BNSeparator2IsVisible = true;
        public bool xBNSeparator2IsVisible
        {
            get { return BNSeparator2IsVisible; }
            set { BNSeparator2IsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNMoveLastItemIsVisible = true;
        public bool xbtnBNMoveLastItemIsVisible
        {
            get { return btnBNMoveLastItemIsVisible; }
            set { btnBNMoveLastItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNMoveNextItemIsVisible = true;
        public bool xbtnBNMoveNextItemIsVisible
        {
            get { return btnBNMoveNextItemIsVisible; }
            set { btnBNMoveNextItemIsVisible = value; }
        }
        //------------------------------------------
        private bool BNCountItemIsVisible = true;
        public bool xBNCountItemIsVisible
        {
            get { return BNCountItemIsVisible; }
            set { BNCountItemIsVisible = value; }
        }
        //------------------------------------------
        private bool BNPositionItemIsVisible = true;
        public bool xBNPositionItemIsVisible
        {
            get { return BNPositionItemIsVisible; }
            set { BNPositionItemIsVisible = value; }
        }
        //------------------------------------------        
        private bool btnBNMovePreviousItemIsVisible = true;
        public bool xbtnBNMovePreviousItemIsVisible
        {
            get { return btnBNMovePreviousItemIsVisible; }
            set { btnBNMovePreviousItemIsVisible = value; }
        }
        //------------------------------------------
        private bool btnBNMoveFirstItemIsVisible = true;
        public bool xbtnBNMoveFirstItemIsVisible
        {
            get { return btnBNMoveFirstItemIsVisible; }
            set { btnBNMoveFirstItemIsVisible = value; }
        }
        //------------------------------------------

        BindingSource objBindingSource;
        public TABindingNavigator()
        {
            InitializeComponent();
        }
        public TABindingNavigator(BindingSource bindingSource)
        {
            InitializeComponent();
            this.objBindingSource = bindingSource;

            this.Load += BaseControl_Load;
            this.objBindingSource.PositionChanged += objBindingSource_PositionChanged;
            this.BaseBindingNavigator.BindingSource = this.objBindingSource;

            btnBNMoveFirstItem.Click += btnBNMoveFirstItem_Click;
            btnBNMovePreviousItem.Click += btnBNMovePreviousItem_Click;
            btnBNMoveNextItem.Click += btnBNMoveNextItem_Click;
            btnBNMoveLastItem.Click += btnBNMoveLastItem_Click;

            btnBNAddItem.Click += bindingNavigatorAddNewItem_Click;
            btnBNEditItem.Click += bindingNavigatorEditItem_Click;
            btnBNDeleteItem.Click += bindingNavigatorDelete_Click;
            btnBNSaveItem.Click += bindingNavigatorSaveItem_Click;
            btnBNCancelItem.Click += bindingNavigatorCancelItem_Click;

            //btnBNRefresh.Click += btnBNRefresh_Click;
            //btnBNRegister.Click += btnBNRegister_Click;
            //btnBNPrint.Click += btnBNPrint_Click;
            //btnBNListReport.Click += btnBNListReport_Click;

            this.TSMItem1.Click += new System.EventHandler(this.TSMItem1_Click);
            this.TSMItem2.Click += new System.EventHandler(this.TSMItem2_Click);
            this.TSMItem3.Click += new System.EventHandler(this.TSMItem3_Click);
            this.TSMItem4.Click += new System.EventHandler(this.TSMItem4_Click);
            this.TSMItem5.Click += new System.EventHandler(this.TSMItem5_Click);
        }
        void BaseControl_Load(object sender, EventArgs e)
        {

            this.BaseBindingNavigator.Visible = this.mainBaseBindingNavigatorIsVisible;
            this.btnBNMoveFirstItem.Visible = this.btnBNMoveFirstItemIsVisible;
            this.btnBNMovePreviousItem.Visible = this.btnBNMovePreviousItemIsVisible;
            this.BNSeparator.Visible = this.BNSeparatorIsVisible;
            this.BNPositionItem.Visible = this.BNPositionItemIsVisible;
            this.BNCountItem.Visible = this.BNCountItemIsVisible;
            this.BNSeparator1.Visible = this.BNSeparator1IsVisible;
            this.btnBNMoveNextItem.Visible = this.btnBNMoveNextItemIsVisible;
            this.btnBNMoveLastItem.Visible = this.btnBNMoveLastItemIsVisible;
            this.BNSeparator2.Visible = this.BNSeparator2IsVisible;
            this.btnBNAddItem.Visible = this.btnBNAddItemIsVisible;
            this.btnBNEditItem.Visible = this.btnBNEditItemIsVisible;
            this.btnBNDeleteItem.Visible = this.btnBNDeleteItemIsVisible;
            this.btnBNSaveItem.Visible = this.btnBNSaveItemIsVisible;
            this.btnBNCancelItem.Visible = this.btnBNCancelItemIsVisible;
            this.btnBNRegister.Visible = this.btnBNRegisterIsVisible;
            this.btnBNPrint.Visible = this.btnBNPrintIsVisible;
            this.btnBNListReport.Visible = this.btnBNListReportIsVisible;
            this.btnBNRefresh.Visible = this.btnBNRefreshIsVisible;
            this.btnBNProcess.Visible = this.btnBNProcessIsVisible;
                        
            this.BaseEnableDisble("Load");

            this.EnableDisable();

        }
        //------------------------------------------------------------
        
        void objBindingSource_PositionChanged(object sender, EventArgs e)
        {
            //this.DataNavigation();
        }
        //protected override void DataNavigation()
        //{
        //    //base.DataNavigation();
        //    this.fnDisplayPosition();
        //}
        private void fnDisplayPosition()
        {
            BNCountItem.Text = "of " + Convert.ToString(this.objBindingSource.Count);
            this.BNPositionItem.Text = Convert.ToString(this.objBindingSource.Position + 1);
        }
        //--------------------------------------------------------------------        
        void btnBNMoveFirstItem_Click(object sender, EventArgs e)
        {
            //this.DataNavigation();
        }
        void btnBNMovePreviousItem_Click(object sender, EventArgs e)
        {
            //this.DataNavigation();
        }
        void btnBNMoveNextItem_Click(object sender, EventArgs e)
        {
            //this.DataNavigation();
        }
        void btnBNMoveLastItem_Click(object sender, EventArgs e)
        {
            //this.DataNavigation();
        }
        //--------------------------------------------------------------------
        protected virtual void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //if (base.bindingNavigatorAddNewItemClick(sender, e))
            //    this.BaseEnableDisble("Add");
        }
        protected virtual void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {            
            this.objBindingSource.EndEdit();
            //if (base.bindingNavigatorEditItemClick(sender, e))
            //    this.BaseEnableDisble("Edit");

        }
        protected virtual void bindingNavigatorDelete_Click(object sender, EventArgs e)
        {
            //base.bindingNavigatorDeleteClick(sender, e);
        }
        protected virtual void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {            
            this.objBindingSource.EndEdit();
            //if (base.bindingNavigatorSaveItemClick(sender, e))
            //    this.BaseEnableDisble("Load");
        }
        protected virtual void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            //base.bindingNavigatorCancelItemClick(sender, e);
            this.BaseEnableDisble("Load");
        }
        //public override void btnBNRefresh_Click(object sender, EventArgs e)
        //{
        //    //base.btnBNRefresh_Click(sender, e);
        //}
        ////--------------------------------------------------------------------
        //public override void btnBNListReport_Click(object sender, EventArgs e)
        //{
        //    //base.btnBNListReport_Click(sender, e);
        //}
        //public override void btnBNPrint_Click(object sender, EventArgs e)
        //{
        //    //base.btnBNPrint_Click(sender, e);
        //}
        //public override void btnBNRegister_Click(object sender, EventArgs e)
        //{
        //    //base.btnBNRegister_Click(sender, e);
        //}
        //--------------------------------------------------------------------
        protected virtual void EnableDisable()
        {
            //this.EnableDisableByUserLevel();
        }
        //private void EnableDisableByUserLevel()
        //{
        //    if (StaticInfo.userLevel == 5) { _loading = true; _reporting = false; _adding = false; _editing = false; _deleting = false; }
        //    else if (StaticInfo.userLevel == 4) { _loading = true; _reporting = true; _adding = false; _editing = false; _deleting = false; }
        //    else if (StaticInfo.userLevel == 3) { _loading = true; _reporting = true; _adding = true; _editing = false; _deleting = false; }
        //    else if (StaticInfo.userLevel == 2) { _loading = true; _reporting = true; _adding = true; _editing = true; _deleting = false; }
        //    else if (StaticInfo.userLevel == 1) { _loading = true; _reporting = true; _adding = true; _editing = true; _deleting = true; }
        //    if ((_loading) && (!_reporting) && (!_adding) && (!_editing) && (!_deleting))
        //    {
        //        //------------------------------------------------
        //        this.btnBNMoveFirstItem.Enabled = true;
        //        this.btnBNMovePreviousItem.Enabled = true;
        //        this.BNPositionItem.Enabled = true;
        //        this.btnBNMoveNextItem.Enabled = true;
        //        this.btnBNMoveLastItem.Enabled = true;
        //        this.btnBNAddItem.Enabled = false;
        //        this.btnBNDeleteItem.Enabled = false;
        //        this.btnBNEditItem.Enabled = false;
        //        this.btnBNSaveItem.Enabled = false;
        //        this.btnBNCancelItem.Enabled = false;
        //        //------------------------------------------------
        //        this.btnBNPrint.Enabled = false;
        //        this.btnBNListReport.Enabled = false;
        //        this.btnBNProcess.Enabled = false;
        //        //-----------------------------
        //        this.btnBNRefresh.Enabled = true;
        //    }
        //    else if ((_loading) && (_reporting) && (!_adding) && (!_editing) && (!_deleting))
        //    {
        //        //------------------------------------------------
        //        this.btnBNMoveFirstItem.Enabled = true;
        //        this.btnBNMovePreviousItem.Enabled = true;
        //        this.BNPositionItem.Enabled = true;
        //        this.btnBNMoveNextItem.Enabled = true;
        //        this.btnBNMoveLastItem.Enabled = true;
        //        this.btnBNAddItem.Enabled = false;
        //        this.btnBNDeleteItem.Enabled = false;
        //        this.btnBNEditItem.Enabled = false;
        //        this.btnBNSaveItem.Enabled = false;
        //        this.btnBNCancelItem.Enabled = false;
        //        //------------------------------------------------
        //        this.btnBNPrint.Enabled = true;
        //        this.btnBNListReport.Enabled = true;
        //        this.btnBNProcess.Enabled = true;
        //        //------------------------------------------------      
        //        this.btnBNRefresh.Enabled = true;
        //    }
        //    else if ((_loading) && (_reporting) && (_adding) && (!_editing) && (!_deleting))
        //    {
        //        //------------------------------------------------
        //        this.btnBNMoveFirstItem.Enabled = true;
        //        this.btnBNMovePreviousItem.Enabled = true;
        //        this.BNPositionItem.Enabled = true;
        //        this.btnBNMoveNextItem.Enabled = true;
        //        this.btnBNMoveLastItem.Enabled = true;
        //        this.btnBNAddItem.Enabled = true;
        //        this.btnBNDeleteItem.Enabled = false;
        //        this.btnBNEditItem.Enabled = false;
        //        this.btnBNSaveItem.Enabled = false;
        //        this.btnBNCancelItem.Enabled = false;
        //        //------------------------------------------------
        //        this.btnBNPrint.Enabled = true;
        //        this.btnBNListReport.Enabled = true;
        //        this.btnBNProcess.Enabled = true;
        //        //------------------------------------------------                
        //        this.btnBNRefresh.Enabled = true;
        //    }
        //    else if ((_loading) && (_reporting) && (_adding) && (_editing) && (!_deleting))
        //    {
        //        //------------------------------------------------
        //        this.btnBNMoveFirstItem.Enabled = true;
        //        this.btnBNMovePreviousItem.Enabled = true;
        //        this.BNPositionItem.Enabled = true;
        //        this.btnBNMoveNextItem.Enabled = true;
        //        this.btnBNMoveLastItem.Enabled = true;
        //        this.btnBNAddItem.Enabled = true;
        //        this.btnBNDeleteItem.Enabled = true;
        //        this.btnBNEditItem.Enabled = true;
        //        this.btnBNSaveItem.Enabled = false;
        //        this.btnBNCancelItem.Enabled = false;
        //        //------------------------------------------------
        //        this.btnBNPrint.Enabled = true;
        //        this.btnBNListReport.Enabled = true;
        //        this.btnBNProcess.Enabled = true;
        //        //------------------------------------------------                
        //        this.btnBNRefresh.Enabled = true;
        //    }
        //    else if ((_loading) && (_reporting) && (_adding) && (_editing) && (_deleting))
        //    {
        //        //------------------------------------------------
        //        this.btnBNMoveFirstItem.Enabled = true;
        //        this.btnBNMovePreviousItem.Enabled = true;
        //        this.btnBNMoveNextItem.Enabled = true;
        //        this.btnBNMoveLastItem.Enabled = true;
        //        this.btnBNAddItem.Enabled = true;
        //        this.btnBNDeleteItem.Enabled = true;
        //        this.btnBNEditItem.Enabled = true;
        //        this.btnBNSaveItem.Enabled = false;
        //        this.btnBNCancelItem.Enabled = false;
        //        //------------------------------------------------
        //        this.btnBNPrint.Enabled = true;
        //        this.btnBNListReport.Enabled = true;
        //        this.btnBNProcess.Enabled = true;
        //        //------------------------------------------------                
        //        this.btnBNRefresh.Enabled = true;
        //    }

        //}
        public void BaseEnableDisble(string frmCS)
        {
            if (frmCS == "Add" || frmCS == "Edit")
            {
                //------------------------------------------------
                this.btnBNMoveFirstItem.Enabled = false;
                this.btnBNMovePreviousItem.Enabled = false;
                this.BNPositionItem.Enabled = false;
                this.btnBNMoveNextItem.Enabled = false;
                this.btnBNMoveLastItem.Enabled = false;
                this.btnBNAddItem.Enabled = false;
                this.btnBNDeleteItem.Enabled = false;
                this.btnBNEditItem.Enabled = false;
                this.btnBNSaveItem.Enabled = true;
                this.btnBNCancelItem.Enabled = true;
                //------------------------------------------------
                this.btnBNPrint.Enabled = false;
                this.btnBNListReport.Enabled = false;
                this.btnBNProcess.Enabled = false;
                //------------------------------------------------
                this.btnBNRefresh.Enabled = false;

            }
            if (frmCS == "Load")
            {
                //------------------------------------------------
                this.btnBNMoveFirstItem.Enabled = true;
                this.btnBNMovePreviousItem.Enabled = true;
                this.BNPositionItem.Enabled = true;
                this.btnBNMoveNextItem.Enabled = true;
                this.btnBNMoveLastItem.Enabled = true;
                this.btnBNAddItem.Enabled = true;
                this.btnBNDeleteItem.Enabled = true;
                this.btnBNEditItem.Enabled = true;
                this.btnBNSaveItem.Enabled = false;
                this.btnBNCancelItem.Enabled = false;
                //------------------------------------------------
                this.btnBNPrint.Enabled = true;
                this.btnBNListReport.Enabled = true;
                this.btnBNProcess.Enabled = true;
                //------------------------------------------------
                this.btnBNRefresh.Enabled = true;

            }
        }

        protected virtual void TSMItem1_Click(object sender, EventArgs e)
        {

        }
        protected virtual void TSMItem2_Click(object sender, EventArgs e)
        {

        }
        protected virtual void TSMItem3_Click(object sender, EventArgs e)
        {

        }
        protected virtual void TSMItem4_Click(object sender, EventArgs e)
        {

        }
        protected virtual void TSMItem5_Click(object sender, EventArgs e)
        {

        }


        //---------------------------------------------------------------------


    }
}
