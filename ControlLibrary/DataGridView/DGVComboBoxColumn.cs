using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControlLibrary
{
    public class DGVComboBoxColumn : DataGridViewComboBoxColumn
    {
        #region "Constructor"

        public DGVComboBoxColumn()
        {
            CellTemplate = new DGVComboBoxCell();
        }
        #endregion
        #region "Properties"

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override sealed DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a DGVComboBoxCell. 
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DGVComboBoxCell)))
                {
                    throw new InvalidCastException("Must be a DGVComboBoxCell");
                }
                base.CellTemplate = value;
            }
        }
        [Category("Design"), DefaultValue("")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Bindable(true)]
        [ParenthesizePropertyName(true)]
        [Description("Indicates the name used in code to identify the object.")]
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }


        private bool isFilteringColumn;
        public bool IsFilteringColumn
        {
            get { return isFilteringColumn; }
            set { isFilteringColumn = value; }
        }
        /// <summary>
        /// Replicates the ColumnNames property of the DGVComboBoxCell cell type.
        /// </summary>
        [Category("Data"), DefaultValue("")]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Which columns to show. Leave blank to show all. put entries in [] to rename Column Headers.")]
        public List<String> ColumnNames
        {
            get
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return MultiColumnComboBoxCellTemplate.ColumnNames;
            }
            set
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                MultiColumnComboBoxCellTemplate.ColumnNames = value;
                if (DataGridView == null) return;
                // Update all the existing DGVComboBoxCell cells in the column accordingly.
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    // Be careful not to unshare rows unnecessarily. 
                    // This could have severe performance repercussions.
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DGVComboBoxCell;
                    if (dataGridViewCell != null)
                    {
                        // Call the internal SetColumnNames method instead of the property to avoid invalidation 
                        // of each cell. The whole column is invalidated later in a single operation for better performance.
                        dataGridViewCell.SetColumnNames(rowIndex, value);
                    }
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
            }
        }

        /// <summary>
        /// Replicates the ColumnWidths property of the DGVComboBoxCell cell type.
        /// </summary>        
        [Category("Data"), DefaultValue("")]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Width of each column. Leave blank to use the defualt. Put entries in [] to rename Column Headers.")]
        public List<string> ColumnWidths
        {
            get
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return MultiColumnComboBoxCellTemplate.ColumnWidths;
            }
            set
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                MultiColumnComboBoxCellTemplate.ColumnWidths = value;
                if (DataGridView == null) return;
                // Update all the existing DGVComboBoxCell cells in the column accordingly.
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    // Be careful not to unshare rows unnecessarily. 
                    // This could have severe performance repercussions.
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DGVComboBoxCell;
                    if (dataGridViewCell != null)
                    {
                        // Call the internal SetColumnWidths method instead of the property to avoid invalidation 
                        // of each cell. The whole column is invalidated later in a single operation for better performance.
                        dataGridViewCell.SetColumnWidths(rowIndex, value);
                    }
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
            }
        }
        /// <summary>
        /// Replicates the EvenRowsBackColor property of the DGVComboBoxCell cell type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the even rows of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
        /// </returns>
        [Category("Appearance"), DefaultValue(typeof(SystemColors), "System.Drawing.SystemColors.Control"),
            Description("The background color for the even rows.")]
        public Color EvenRowsBackColor
        {
            get
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return MultiColumnComboBoxCellTemplate.EvenRowsBackColor;
            }
            set
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                MultiColumnComboBoxCellTemplate.EvenRowsBackColor = value;
                if (DataGridView == null) return;
                // Update all the existing DGVComboBoxCell cells in the column accordingly.
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    // Be careful not to unshare rows unnecessarily. 
                    // This could have severe performance repercussions.
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DGVComboBoxCell;
                    if (dataGridViewCell != null)
                    {
                        // Call the internal SetEvenRowsBackColor method instead of the property to avoid invalidation 
                        // of each cell. The whole column is invalidated later in a single operation for better performance.
                        dataGridViewCell.SetEvenRowsBackColor(rowIndex, value);
                    }
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
            }
        }

        public int xDisplayIndex
        {
            get { return MultiColumnComboBoxCellTemplate.xDisplayIndex; }
            set { MultiColumnComboBoxCellTemplate.xDisplayIndex = value; }
        }
        public string xBindingProperty
        {
            get { return MultiColumnComboBoxCellTemplate.xBindingProperty; }
            set { MultiColumnComboBoxCellTemplate.xBindingProperty = value; }
        }
        public string xBindingQuery
        {
            get { return MultiColumnComboBoxCellTemplate.xBindingQuery; }
            set { MultiColumnComboBoxCellTemplate.xBindingQuery = value; }
        }
        public string xTableName
        {
            get { return MultiColumnComboBoxCellTemplate.xTableName; }
            set { MultiColumnComboBoxCellTemplate.xTableName = value; }
        }
        public string xDisplayMember
        {
            get { return MultiColumnComboBoxCellTemplate.xDisplayMember; }
            set { MultiColumnComboBoxCellTemplate.xDisplayMember = value; }
        }
        public string xValueMember
        {
            get { return MultiColumnComboBoxCellTemplate.xValueMember; }
            set { MultiColumnComboBoxCellTemplate.xValueMember = value; }
        }
        public string xOrderBy
        {
            get { return MultiColumnComboBoxCellTemplate.xOrderBy; }
            set { MultiColumnComboBoxCellTemplate.xOrderBy = value; }
        }
        /// <summary>
        /// Replicates the OddRowsBackColor property of the DGVComboBoxCell cell type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the odd rows of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
        /// </returns>
        [Category("Appearance"), DefaultValue(typeof(SystemColors), "System.Drawing.SystemColors.Control"),
            Description("The background color for the odd rows.")]
        public Color OddRowsBackColor
        {
            get
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return MultiColumnComboBoxCellTemplate.OddRowsBackColor;
            }
            set
            {
                if (MultiColumnComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                // Update the template cell so that subsequent cloned cells use the new value.
                MultiColumnComboBoxCellTemplate.OddRowsBackColor = value;
                if (DataGridView == null) return;
                // Update all the existing DGVComboBoxCell cells in the column accordingly.
                var dataGridViewRows = DataGridView.Rows;
                var rowCount = dataGridViewRows.Count;
                for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    // Be careful not to unshare rows unnecessarily. 
                    // This could have severe performance repercussions.
                    var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                    var dataGridViewCell = dataGridViewRow.Cells[Index] as DGVComboBoxCell;
                    if (dataGridViewCell != null)
                    {
                        // Call the internal SetOddRowsBackColor method instead of the property to avoid invalidation 
                        // of each cell. The whole column is invalidated later in a single operation for better performance.
                        dataGridViewCell.SetOddRowsBackColor(rowIndex, value);
                    }
                }
                DataGridView.InvalidateColumn(Index);
                // TODO: Call the grid's autosizing methods to autosize the column, rows, column headers / row headers as needed.
            }
        }



        /// <summary>
        /// Small utility function that returns the template cell as a DGVComboBoxCell
        /// </summary>
        private DGVComboBoxCell MultiColumnComboBoxCellTemplate
        {
            get
            {
                return (DGVComboBoxCell)CellTemplate;
            }
        }

        #endregion
        #region "Methods"
        /// <summary>
        /// Creates an exact copy of this column.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the cloned <see cref="T:DGMCCBD.Controls.DGVComboBoxColumn"/>.
        /// </returns>
        public override object Clone()
        {
            var clone = (DGVComboBoxColumn)base.Clone();
            if (clone == null) return null;
            clone.ColumnNames = ColumnNames;
            clone.xBindingProperty = xBindingProperty;
            clone.xBindingQuery = xBindingQuery;
            clone.xDisplayMember = xDisplayMember;
            clone.xOrderBy = xOrderBy;
            clone.xTableName = xTableName;
            clone.xValueMember = xValueMember;
            clone.ColumnWidths = ColumnWidths;
            clone.EvenRowsBackColor = EvenRowsBackColor;
            clone.OddRowsBackColor = OddRowsBackColor;
            return clone;
        }
        /// <returns>
        /// A <see cref="T:System.String"/> that describes the column.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder(100);
            sb.Append("DGVComboBoxColumn { Name=");
            sb.Append(Name);
            sb.Append(", Index=");
            sb.Append(Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
        #endregion
    }
    public class DGVComboBoxCell : DataGridViewComboBoxCell
    {
        #region "Member Variables"
        private List<string> _columnNames = new List<string>();
        private List<string> _columnNames1 = new List<string>();
        private List<string> _columnWidths = new List<string>();
        private Color _evenRowsBackColor = SystemColors.Control;
        private Color _oddRowsBackColor = SystemColors.Control;
        private int _displayIndex = 0;
        private string _bindingProperty = string.Empty;
        private string _bindingQuery = string.Empty;
        private string _tableName = string.Empty;
        private string _displayMember = string.Empty;
        private string _valueMember = string.Empty;
        private string _orderBy = string.Empty;
        // Constants
        private const String EvenRowsBackColorErrorMsg = "The EvenRowsBackColor property cannot be null.";
        private const String OddRowsBackColorErrorMsg = "The OddRowsBackColor property cannot be null.";
        // Type of this cell's editing control
        private static Type _defaultEditType = typeof(DGVComboBoxEditingControl);

        #endregion
        #region "Properties"
        /// <summary>
        /// Define the type of the cell's editing control
        /// </summary>
        /// <returns>A Type of <see cref="DGVComboBoxEditingControl"/>.</returns>
        public override Type EditType
        {
            get { return _defaultEditType; }
        }
        /// <summary>
        /// The ColumnNames property replicates the one from the DGVComboBoxEditingControl control
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">When property is null.</exception>
        public List<String> ColumnNames
        {
            get
            {
                return _columnNames;
            }
            set
            {
                _columnNames = value ?? new List<string>();
            }
        }

        /// <summary>
        /// The ColumnWidths property replicates the one from the DGVComboBoxEditingControl control
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">When property is null.</exception>
        public List<String> ColumnWidths
        {
            get
            {
                return _columnWidths;
            }
            set
            {
                _columnWidths = value ?? new List<string>();
            }
        }
        /// <summary>
        /// Gets or sets the background color for the even rows portion of the DGVComboBoxEditingControl control.  The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the even rows portion of the DGVComboBoxEditingControl.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">When property is null.</exception>
        public Color EvenRowsBackColor
        {
            get
            {
                return _evenRowsBackColor;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(EvenRowsBackColorErrorMsg);
                }
                _evenRowsBackColor = value;
            }
        }
        /// <summary>
        /// Gets or sets the background color for the odd rows portion of the DGVComboBoxEditingControl control.  The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the odd rows portion of the DGVComboBoxEditingControl.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">When property is null.</exception>
        public Color OddRowsBackColor
        {
            get
            {
                return _oddRowsBackColor;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(OddRowsBackColorErrorMsg);
                }
                _oddRowsBackColor = value;
            }
        }
        public int xDisplayIndex
        {
            get
            {
                return _displayIndex;
            }
            set
            {
                _displayIndex = value;
            }
        }
        public string xBindingProperty
        {
            get
            {
                return _bindingProperty;
            }
            set
            {
                _bindingProperty = value;
            }
        }
        public string xBindingQuery
        {
            get
            {
                return _bindingQuery;
            }
            set
            {
                _bindingQuery = value;
            }
        }
        public string xTableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
        public string xDisplayMember
        {
            get
            {
                return _displayMember;
            }
            set
            {
                _displayMember = value;
            }
        }
        public string xValueMember
        {
            get
            {
                return _valueMember;
            }
            set
            {
                _valueMember = value;
            }
        }
        public string xOrderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                _orderBy = value;
            }
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Creates an exact copy of this cell, copies all the custom properties.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the cloned <see cref="T:DGMCCBD.Controls.DGVComboBoxCell"/>.
        /// </returns>
        public override object Clone()
        {
            var clone = (DGVComboBoxCell)base.Clone();
            // Make sure to copy added properties.
            clone.ColumnNames = ColumnNames;
            clone.ColumnWidths = ColumnWidths;
            clone.EvenRowsBackColor = EvenRowsBackColor;
            clone.OddRowsBackColor = OddRowsBackColor;
            return clone;
        }
        /// <summary>
        /// Custom implementation of the InitializeEditingControl function. This function is called by the DataGridView control 
        /// at the beginning of an editing session. It makes sure that the properties of the DGVComboBoxEditingControl editing control are 
        /// set according to the cell properties.
        /// </summary>
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            var editingControl = DataGridView.EditingControl as DGVComboBoxEditingControl;
            // Just return if editing control is null.
            if (editingControl == null) return;
            // Set custom properties of Multi Column Combo Box.
            editingControl.ColumnNames = ColumnNames;
            editingControl.ColumnWidths = ColumnWidths;
            editingControl.BackColorEven = EvenRowsBackColor;
            editingControl.BackColorOdd = OddRowsBackColor;
            editingControl.OwnerCell = this;
            if (Value != null)
                editingControl.SelectedValue = Value;
            editingControl.AutoComplete = AutoComplete;
            if (!AutoComplete) return;
            editingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            editingControl.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        /// <summary>
        /// Returns a standard textual representation of the cell.
        /// </summary>
        public override string ToString()
        {
            return string.Format("DGVComboBoxCell {{ ColumnIndex={0}, RowIndex={1} }}", ColumnIndex.ToString(CultureInfo.CurrentCulture), RowIndex.ToString(CultureInfo.CurrentCulture));
        }
        /// <summary>
        /// Utility function that sets a new value for the ColumnNames property of the cell. This function is used by
        /// the cell and column ColumnNames property. The column uses this method instead of the ColumnNames
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of 
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        internal void SetColumnNames(int rowIndex, List<string> value)
        {
            Debug.Assert(value != null);
            _columnNames = value;
            if (OwnsEditingMultiColumnComboBox(rowIndex))
            {
                EditingMultiColumnComboBox.ColumnNames = value;
            }
        }
        /// <summary>
        /// Utility function that sets a new value for the ColumnWidths property of the cell. This function is used by
        /// the cell and column ColumnWidths property. The column uses this method instead of the ColumnWidths
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of 
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        internal void SetColumnWidths(int rowIndex, List<string> value)
        {
            Debug.Assert(value != null);
            _columnWidths = value;
            if (OwnsEditingMultiColumnComboBox(rowIndex))
            {
                EditingMultiColumnComboBox.ColumnWidths = value;
            }
        }
        /// <summary>
        /// Utility function that sets a new value for the EvenRowsBackColor property of the cell. This function is used by
        /// the cell and column EvenRowsBackColor property. The column uses this method instead of the EvenRowsBackColor
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of 
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        internal void SetEvenRowsBackColor(int rowIndex, Color value)
        {
            Debug.Assert(value != null);
            _evenRowsBackColor = value;
            if (OwnsEditingMultiColumnComboBox(rowIndex))
            {
                EditingMultiColumnComboBox.BackColorEven = value;
            }
        }
        /// <summary>
        /// Utility function that sets a new value for the OddRowsBackColor property of the cell. This function is used by
        /// the cell and column OddRowsBackColor property. The column uses this method instead of the OddRowsBackColor
        /// property for performance reasons. This way the column can invalidate the entire column at once instead of 
        /// invalidating each cell of the column individually. A row index needs to be provided as a parameter because
        /// this cell may be shared among multiple rows.
        /// </summary>
        internal void SetxBindingProperty(string value)
        {
            _bindingProperty = value;
            EditingMultiColumnComboBox.xBindingProperty = value;

        }
        internal void SetxBindingQuery(string value)
        {
            _bindingQuery = value;
            EditingMultiColumnComboBox.xBindingQuery = value;

        }
        internal void SetxTableName(string value)
        {
            _tableName = value;
            EditingMultiColumnComboBox.xTableName = value;

        }
        internal void SetxDisplayMember(string value)
        {
            _displayMember = value;
            EditingMultiColumnComboBox.xDisplayMember = value;

        }
        internal void SetxValueMember(string value)
        {
            _valueMember = value;
            EditingMultiColumnComboBox.xValueMember = value;

        }
        internal void SetxOrderBy(string value)
        {
            _orderBy = value;
            EditingMultiColumnComboBox.xOrderBy = value;

        }
        internal void SetOddRowsBackColor(int rowIndex, Color value)
        {
            Debug.Assert(value != null);
            _oddRowsBackColor = value;
            if (OwnsEditingMultiColumnComboBox(rowIndex))
            {
                EditingMultiColumnComboBox.BackColorOdd = value;
            }
        }

        /// <summary>
        /// Determines whether this cell, at the given row index, shows the grid's editing control or not.
        /// The row index needs to be provided as a parameter because this cell may be shared among multiple rows.
        /// </summary>
        private bool OwnsEditingMultiColumnComboBox(int rowIndex)
        {
            if (rowIndex == -1 || DataGridView == null)
            {
                return false;
            }
            var editingControl = DataGridView.EditingControl as DGVComboBoxEditingControl;
            return editingControl != null && rowIndex == ((IDataGridViewEditingControl)editingControl).EditingControlRowIndex;
        }
        /// <summary>
        /// Returns the current DataGridView EditingControl as a DGVComboBoxEditingControl control
        /// </summary>
        private DGVComboBoxEditingControl EditingMultiColumnComboBox
        {
            get
            {
                return DataGridView.EditingControl as DGVComboBoxEditingControl;
            }
        }
        #endregion
    }
    public class DGVComboBoxEditingControl : DataGridViewComboBoxEditingControl
    {
        #region "Member Variables"
        private readonly List<Int32> _columnWidths = new List<int>();
        private List<string> _columnWidthStringList = new List<string>();
        private List<string> _columnNames = new List<string>();
        private List<string> _columnNames1 = new List<string>();
        private string _bindingProperty = string.Empty;
        private string _bindingQuery = string.Empty;
        private string _tableName = string.Empty;
        private string _displayMember = string.Empty;
        private string _valueMember = string.Empty;
        private string _orderBy = string.Empty;
        #endregion
        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DGMCCBD.Controls.DGVComboBoxEditingControl"/> class.
        /// </summary>
        public DGVComboBoxEditingControl()
        {
            // Initialize all properties.
            AutoComplete = true;
            AutoDropdown = false;
            BackColorEven = Color.White;
            BackColorOdd = Color.White;
            ColumnWidths = new List<string>();
            ColumnWidthDefault = 75;
            TotalWidth = 0;
            xBindingProperty = string.Empty;
            xBindingQuery = string.Empty;
            xTableName = string.Empty;
            xDisplayMember = string.Empty;
            xValueMember = string.Empty;
            xOrderBy = string.Empty;
            ColumnNames = new List<string>();
            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownStyle = ComboBoxStyle.DropDown;
            OwnerCell = null;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ContextMenu = new ContextMenu();
            EditingControlValueChanged = false;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
        #endregion
        #region "Properties"


        /// <summary>
        /// Gets or sets the auto complete property.  The default is true.
        /// </summary>
        [DefaultValue(true)]
        public bool AutoComplete { get; set; }
        /// <summary>
        /// Gets or sets the auto drop down property.  The default is false.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoDropdown { get; set; }
        /// <summary>
        /// Gets or sets the background color for the even rows portion.  The default is White.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public Color BackColorEven { get; set; }

        public string xTableName { get; set; }
        public string xDisplayMember { get; set; }
        public string xValueMember { get; set; }
        public string xOrderBy { get; set; }
        /// <summary>
        /// Gets or sets the background color for the odd rows portion.  The default is White.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public Color BackColorOdd { get; set; }
        /// <summary>
        /// Gets or sets the width of the columns to display.
        /// The default is <see cref="System.Collections.ObjectModel.Collection&lt;Int32&gt;"/>.
        /// </summary>
        public List<String> ColumnWidths
        {
            get
            {
                return _columnWidthStringList;
            }
            set
            {
                if (value == null) value = new List<string>();
                var invalidValue = "";
                var invalidIndex = -1;
                var idx = 0;
                // iterate through the strings and check that they're all integers
                // or blanks
                foreach (var s in value)
                {
                    // If it has length, test if it's an integer
                    if (!String.IsNullOrWhiteSpace(s))
                    {
                        // It's not an integer. Flag the offending value.
                        int intValue;
                        if (!int.TryParse(s, out intValue))
                        {
                            invalidIndex = idx;
                            invalidValue = s;
                        }
                        else // The value was okay. Increment the item index.
                        {
                            idx++;
                        }
                    }
                    else // The value is a space. Use the default width.
                    {
                        idx++;
                    }
                }
                // If an invalid value was found, raise an exception.
                if (invalidIndex > -1)
                {
                    var errMsg = "Invalid column width '" + invalidValue + "' located at column " + invalidIndex;
                    throw new ArgumentOutOfRangeException(errMsg);
                }
                _columnWidthStringList = value;
                // Only set the values of the collections at runtime.
                // Setting them at design time doesn't accomplish 
                // anything and causes errors since the collections 
                // don't exist at design time.
                if (DesignMode) return;
                _columnWidths.Clear();
                foreach (var s in value)
                {
                    // Initialize a column width to an integer
                    _columnWidths.Add(Convert.ToBoolean(s.Trim().Length)
                        ? Convert.ToInt32(s)
                        : ColumnWidthDefault);
                }
                // If the column is bound to data, set the column widths
                // for any columns that aren't explicitly set by the 
                // string value entered by the programmer
                if (DataManager != null)
                {
                    InitializeColumns();
                }
            }
        }
        /// <summary>
        /// Gets or sets the default column width.  The default is 75.
        /// </summary>
        [DefaultValue(75)]
        public int ColumnWidthDefault { get; set; }
        /// <summary>
        /// Gets or sets the total width of the drop down. The default is 0.
        /// </summary>
        [DefaultValue(0)]
        public int TotalWidth { get; private set; }
        /// <summary>
        /// Gets or sets the names of the columns to display.  The default is <see cref="System.Collections.ObjectModel.Collection&lt;String&gt;"/>.
        /// </summary>
        public List<String> ColumnNames
        {
            get
            {
                return _columnNames;
            }
            set
            {
                if (value == null) value = new List<string>();
                if (value.Any(String.IsNullOrWhiteSpace))
                    throw new NotSupportedException("Column name cannot be blank.");
                var columnNames = value.ToList();
                if (!DesignMode)
                {
                    _columnNames.Clear();
                }
                _columnNames = columnNames.Select(cn => cn.Trim()).ToList();
            }
        }


        public string xBindingProperty
        {
            get
            {
                return _bindingProperty;
            }
            set
            {
                _bindingProperty = value;
            }
        }
        public string xBindingQuery
        {
            get
            {
                return _bindingQuery;
            }
            set
            {
                _bindingQuery = value;
            }
        }
        /// <summary>
        /// Gets a value indicating your code will handle drawing of elements in the list.
        /// </summary>
        /// 
        /// <returns>
        /// The default is <see cref="F:System.Windows.Forms.DrawMode.OwnerDrawVariable"/>.
        /// </returns>
        [DefaultValue(DrawMode.OwnerDrawVariable)]
        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            private set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }
        /// <summary>
        /// Gets a value specifying the style of the combo box to be DropDown.
        /// </summary>
        /// 
        /// <returns>
        /// The only value is DropDown.
        /// </returns>
        [DefaultValue(ComboBoxStyle.DropDown)]
        public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            private set
            {
                if (value != ComboBoxStyle.DropDown)
                {
                    throw new NotSupportedException("ComboBoxStyle.DropDown is the only supported style");
                }
                base.DropDownStyle = value;
            }
        }
        /// <summary>
        /// Gets or sets a value specifying the owner of this control.
        /// </summary>
        public DGVComboBoxCell OwnerCell { get; set; }
        #endregion
        #region "Event Handlers"
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            InitializeColumns();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs"/> that contains the event data. </param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index < 0) return;
            if (DesignMode)
                return;
            e.DrawBackground();
            var boundsRect = e.Bounds;
            var lastRight = 0;
            Color brushForeColor;
            if ((e.State & DrawItemState.Selected) == 0)
            {
                // Item is not selected. Use BackColorOdd & BackColorEven
                var backColor = Convert.ToBoolean(e.Index % 2) ? BackColorOdd : BackColorEven;
                using (var brushBackColor = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brushBackColor, e.Bounds);
                }
                brushForeColor = Color.Black;
            }
            else
            {
                // Item is selected. Use ForeColor = White
                brushForeColor = Color.White;
            }
            using (var linePen = new Pen(SystemColors.GrayText))
            {
                using (var brush = new SolidBrush(brushForeColor))
                {
                    if (ColumnNames.Count == 0)
                    {
                        e.Graphics.DrawString(Convert.ToString(Items[e.Index]), Font, brush, boundsRect);
                    }
                    else
                    {
                        // If the ComboBox is displaying a RightToLeft language, draw it this way.
                        if (RightToLeft.Equals(RightToLeft.Yes))
                        {
                            // Define a StringFormat object to make the string display RTL.
                            var rtl = new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                FormatFlags = StringFormatFlags.DirectionRightToLeft
                            };
                            // Draw the strings in reverse order from high column index to zero column index.
                            for (var colIndex = ColumnNames.Count - 1; colIndex >= 0; colIndex--)
                            {
                                if (!Convert.ToBoolean(ColumnWidths[colIndex])) continue;
                                var item = Convert.ToString(FilterItemOnProperty(Items[e.Index], ColumnNames[colIndex]));
                                boundsRect.X = lastRight;
                                boundsRect.Width = _columnWidths[colIndex];
                                lastRight = boundsRect.Right;
                                // Draw the string with the RTL object.
                                e.Graphics.DrawString(item, Font, brush, boundsRect, rtl);
                                if (colIndex > 0)
                                {
                                    e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                }
                            }
                        }
                        // If the ComboBox is displaying a LeftToRight language, draw it this way.
                        else
                        {
                            // Display the strings in ascending order from zero to the highest column.
                            for (var colIndex = 0; colIndex < ColumnNames.Count; colIndex++)
                            {
                                if (Convert.ToBoolean(_columnWidths[colIndex]))
                                {
                                    var item = Convert.ToString(FilterItemOnProperty(Items[e.Index], ColumnNames[colIndex]));
                                    boundsRect.X = lastRight;
                                    boundsRect.Width = _columnWidths[colIndex];
                                    lastRight = boundsRect.Right;
                                    e.Graphics.DrawString(item, Font, brush, boundsRect);
                                    if (colIndex < ColumnNames.Count - 1)
                                    {
                                        e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            e.DrawFocusRectangle();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DropDown"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnDropDown(EventArgs e)
        {
            if (TotalWidth <= 0) return;
            if (Items.Count > MaxDropDownItems)
            {
                // The vertical scrollbar is present. Add its width to the total.
                // If you don't then RightToLeft languages will have a few characters obscured.
                DropDownWidth = TotalWidth + SystemInformation.VerticalScrollBarWidth;
            }
            else
            {
                DropDownWidth = TotalWidth;
            }
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"/> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int idx;
            string toFind;
            try
            {
                DroppedDown = AutoDropdown;
                if (!Char.IsControl(e.KeyChar))
                {
                    if (AutoComplete)
                    {
                        toFind = Text.Substring(0, SelectionStart) + e.KeyChar;
                        idx = FindStringExact(toFind);
                        if (idx == -1)
                        {
                            // An exact match for the whole string was not found
                            // Find a substring instead.
                            idx = FindString(toFind);
                        }
                        else
                        {
                            // An exact match was found. Close the dropdown.
                            DroppedDown = false;
                        }
                        if (idx != -1) // The substring was found.
                        {
                            SelectedIndex = idx;
                            SelectionStart = toFind.Length;
                            SelectionLength = Text.Length - SelectionStart;
                        }
                        else // The last keystroke did not create a valid substring.
                        {
                            // If the substring is not found, cancel the keypress
                            e.KeyChar = (char)0;
                        }
                    }
                    else // AutoComplete = false. Treat it like a DropDownList by finding the
                    // KeyChar that was struck starting from the current index
                    {
                        idx = FindString(e.KeyChar.ToString(CultureInfo.InvariantCulture), SelectedIndex);
                        if (idx != -1)
                        {
                            SelectedIndex = idx;
                        }
                    }
                }
                // Do no allow the user to backspace over characters. Treat it like
                // a left arrow instead. The user must not be allowed to change the 
                // value in the ComboBox. 
                if ((e.KeyChar == (char)(Keys.Back)) &&  // A Backspace Key is hit
                    (AutoComplete) &&                   // AutoComplete = true
                    (Convert.ToBoolean(SelectionStart))) // And the SelectionStart is positive
                {
                    // Find a substring that is one character less the the current selection.
                    // This mimicks moving back one space with an arrow key. This substring should
                    // always exist since we don't allow invalid selections to be typed. If you're
                    // on the 3rd character of a valid code, then the first two characters have to 
                    // be valid. Moving back to them and finding the 1st occurrence should never fail.
                    toFind = Text.Substring(0, SelectionStart - 1);
                    idx = FindString(toFind);
                    if (idx != -1)
                    {
                        SelectedIndex = idx;
                        SelectionStart = toFind.Length;
                        SelectionLength = Text.Length - SelectionStart;
                    }
                }
                // e.Handled is always true. We handle every keystroke programatically.
                e.Handled = true;
            }
            catch { }
        }
        #endregion
        #region "Methods"
        /// <summary>
        /// Sets what columns to be displayed and calculates the width to use to display them.
        /// </summary>
        private void InitializeColumns()
        {
            if (ColumnNames.Count == 0)
            {
                var propertyDescriptorCollection = DataManager.GetItemProperties();
                TotalWidth = 0;
                ColumnNames.Clear();
                for (var colIndex = 1; colIndex < propertyDescriptorCollection.Count; colIndex++)
                {
                    ColumnNames.Add(propertyDescriptorCollection[colIndex].Name);
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= ColumnWidths.Count)
                    {
                        _columnWidths.Add(ColumnWidthDefault);
                    }
                    //TotalWidth += _columnWidths[colIndex];
                    TotalWidth += ColumnWidthDefault;
                }
            }
            else
            {
                TotalWidth = 0;
                for (var colIndex = 0; colIndex < ColumnNames.Count; colIndex++)
                {
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= ColumnWidths.Count)
                    {
                        _columnWidths.Add(ColumnWidthDefault);
                    }
                    TotalWidth += _columnWidths[colIndex];
                }
            }
        }
        #endregion
    }
}
