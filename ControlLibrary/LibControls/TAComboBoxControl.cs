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
    public partial class TAComboBoxControl : UserControl
    {

        private string valueMember;
        public string xValueMember
        {
            get { return valueMember; }
            set { valueMember = value; }
        }
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
        public TAComboBoxControl()
        {
            InitializeComponent();
            btnClear.Click += btnClear_Click;

            this.Load += TAComboBoxControl_Load;
        }

        void TAComboBoxControl_Load(object sender, EventArgs e)
        {
            this.taComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taComboBox1.DisplayMember = xDisplayMember;
            this.taComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taComboBox1.FormattingEnabled = true;
            this.taComboBox1.Location = new System.Drawing.Point(97, 105);
            this.taComboBox1.Name = "taComboBox1";
            this.taComboBox1.Size = new System.Drawing.Size(136, 21);
            this.taComboBox1.TabIndex = 8;
            this.taComboBox1.ValueMember = xValueMember;
            this.taComboBox1.xBindingProperty = xBindingProperty;
            this.taComboBox1.xColumnName = null;
            this.taComboBox1.xColumnWidth = 0;
            this.taComboBox1.xDisplayMember = xDisplayMember;
            this.taComboBox1.xFillByFieldID = null;
            this.taComboBox1.xIsAllowDuplicate = System32.StaticInfo.YesNo.Yes;
            this.taComboBox1.xIsRequired = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowDefault = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xIsShowInGrid = System32.StaticInfo.YesNo.No;
            this.taComboBox1.xOrderBy = xOrderBy;
            this.taComboBox1.xReadOnly = xReadOnly;
            this.taComboBox1.xTableName = xTableName;
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            this.taComboBox1.SelectedIndex = -1;
        }
    }
}
