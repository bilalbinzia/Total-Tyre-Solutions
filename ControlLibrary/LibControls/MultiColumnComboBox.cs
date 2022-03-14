using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Data;
using System.Drawing;
using DBModule;
using System32;

namespace ControlLibrary
{
    public class MultiColumnComboBox : System.Windows.Forms.ComboBox
    {

        BindingSource bindingSource = null;
        //DbClass dbClass.obj = null;

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }
        private string bindingQuery;
        public string xBindingQuery
        {
            get { return bindingQuery; }
            set { bindingQuery = value; }
        }

        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
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

        private String[] columns;

        public String[] xColumns
        {
            get { return columns; }
            set { columns = value; }
        }


        private System.ComponentModel.Container components = null;

        public MultiColumnComboBox()
        {
            InitializeComponent();
            //dbClass.obj = new DbClass();
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
            this.SuspendLayout();

            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;

            //this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_DrawItem);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyDown);

        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                DataRowView drv = (DataRowView)this.Items[e.Index];
                int i = 1;
                int preCol = 0;
                int ileft = 5;
                int icolumns = xColumns.Count();

                foreach (var icolumn in drv.Row.Table.Columns)
                {
                    foreach (var item in xColumns)
                    {
                        string[] columnParts = item.Split(',');
                        if (((System.Data.DataColumn)(icolumn)).Caption == columnParts[0].ToString())
                        {
                            string columnData = Convert.ToString(drv[((System.Data.DataColumn)(icolumn)).Ordinal]);
                            int columnWidth = Convert.ToInt32(columnParts[1]);
                            Rectangle Rec = e.Bounds;
                            Rec.X = preCol + 5;
                            Rec.Width = columnWidth;
                            preCol = columnWidth;
                            using (SolidBrush sb = new SolidBrush(e.ForeColor))
                            { e.Graphics.DrawString(columnData, e.Font, sb, ileft, Rec.Y); }
                            if (i < icolumns)
                            {
                                using (Pen p = new Pen(Color.Black))
                                { e.Graphics.DrawLine(p, Rec.Right, 0, Rec.Right, Rec.Bottom); }
                            }
                            i++; ileft += preCol + 5;
                        }
                    }
                }
            }
            catch { }
        }

        public void BindControl(object bindingSource, DataTable dataSource)
        {
            try
            {
                dbClass.obj.FillByActive(dataSource, this.xOrderBy);
                this.bindingSource = (BindingSource)bindingSource;
                this.DataSource = dataSource;
                this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.xBindingProperty, true));
            }
            catch { }
        }

    }
}
