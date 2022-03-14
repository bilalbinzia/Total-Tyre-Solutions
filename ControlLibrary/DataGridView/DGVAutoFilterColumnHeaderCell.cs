using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Collections;
using System.Reflection;
using System.Collections.Specialized;

namespace ControlLibrary
{
    //public class DGVAutoFilterColumnHeaderCell : DataGridViewColumnHeaderCell
    //{        
    //    private static FilterListBox dropDownListBox = new FilterListBox();
    //    private OrderedDictionary filters = new OrderedDictionary();                
    //    private String selectedFilterValue = String.Empty;        
    //    private String currentColumnFilter = String.Empty;                
    //    private Boolean filtered;

    //    public DGVAutoFilterColumnHeaderCell(DataGridViewColumnHeaderCell oldHeaderCell)
    //    {
    //        this.ContextMenuStrip = oldHeaderCell.ContextMenuStrip;
    //        this.ErrorText = oldHeaderCell.ErrorText;
    //        this.Tag = oldHeaderCell.Tag;
    //        this.ToolTipText = oldHeaderCell.ToolTipText;
    //        this.Value = oldHeaderCell.Value;
    //        this.ValueType = oldHeaderCell.ValueType;

    //        if (oldHeaderCell.HasStyle)
    //        {
    //            this.Style = oldHeaderCell.Style;
    //        }

    //        DGVAutoFilterColumnHeaderCell filterCell =
    //            oldHeaderCell as DGVAutoFilterColumnHeaderCell;
    //        if (filterCell != null)
    //        {
    //            this.FilteringEnabled = filterCell.FilteringEnabled;
    //            this.AutomaticSortingEnabled = filterCell.AutomaticSortingEnabled;
    //            this.DropDownListBoxMaxLines = filterCell.DropDownListBoxMaxLines;
    //            this.currentDropDownButtonPaddingOffset =
    //                filterCell.currentDropDownButtonPaddingOffset;
    //        }
    //    }

    //    public DGVAutoFilterColumnHeaderCell()
    //    {
    //    }

    //    public override object Clone()
    //    {
    //        return new DGVAutoFilterColumnHeaderCell(this);
    //    }

    //    protected override void OnDataGridViewChanged()
    //    {

    //        if (this.DataGridView == null)
    //        {
    //            return;
    //        }

    //        if (OwningColumn != null)
    //        {
    //            if (OwningColumn is DataGridViewImageColumn ||
    //            (OwningColumn is DataGridViewButtonColumn &&
    //            ((DataGridViewButtonColumn)OwningColumn).UseColumnTextForButtonValue) ||
    //            (OwningColumn is DataGridViewLinkColumn &&
    //            ((DataGridViewLinkColumn)OwningColumn).UseColumnTextForLinkValue))
    //            {
    //                AutomaticSortingEnabled = false;
    //                FilteringEnabled = false;
    //            }

    //            if (OwningColumn.SortMode == DataGridViewColumnSortMode.Automatic)
    //            {
    //                OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
    //            }
    //        }

    //        VerifyDataSource();            
    //        HandleDataGridViewEvents();            
    //        SetDropDownButtonBounds();            
    //        base.OnDataGridViewChanged();
    //    }

    //    private void VerifyDataSource()
    //    {

    //        if (this.DataGridView == null || this.DataGridView.DataSource == null)
    //        {
    //            return;
    //        }

    //        BindingSource data = this.DataGridView.DataSource as BindingSource;
    //        if (data == null)
    //        {
    //            throw new NotSupportedException(
    //                "The DataSource property of the containing DataGridView control " +
    //                "must be set to a BindingSource.");
    //        }
    //    }
    //    #region DataGridView events: HandleDataGridViewEvents, DataGridView event handlers, ResetDropDown, ResetFilter

    //    private void HandleDataGridViewEvents()
    //    {
    //        this.DataGridView.Scroll += new ScrollEventHandler(DataGridView_Scroll);
    //        this.DataGridView.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnDisplayIndexChanged);
    //        this.DataGridView.ColumnWidthChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnWidthChanged);
    //        this.DataGridView.ColumnHeadersHeightChanged += new EventHandler(DataGridView_ColumnHeadersHeightChanged);
    //        this.DataGridView.SizeChanged += new EventHandler(DataGridView_SizeChanged);
    //        this.DataGridView.DataSourceChanged += new EventHandler(DataGridView_DataSourceChanged);
    //        this.DataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView_DataBindingComplete);

    //        this.DataGridView.ColumnSortModeChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnSortModeChanged);
    //    }

    //    private void DataGridView_Scroll(object sender, ScrollEventArgs e)
    //    {
    //        if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
    //        {
    //            ResetDropDown();
    //        }
    //    }

    //    private void DataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    //    {
    //        ResetDropDown();
    //    }

    //    private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    //    {
    //        ResetDropDown();
    //    }

    //    private void DataGridView_ColumnHeadersHeightChanged(object sender, EventArgs e)
    //    {
    //        ResetDropDown();
    //    }

    //    private void DataGridView_SizeChanged(object sender, EventArgs e)
    //    {
    //        ResetDropDown();
    //    }

    //    private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    //    {
    //        if (e.ListChangedType == ListChangedType.Reset)
    //        {
    //            ResetDropDown();
    //            ResetFilter();
    //        }
    //    }

    //    private void DataGridView_DataSourceChanged(object sender, EventArgs e)
    //    {
    //        VerifyDataSource();
    //        ResetDropDown();
    //        ResetFilter();
    //    }

    //    private void ResetDropDown()
    //    {
    //        InvalidateDropDownButtonBounds();
    //        if (dropDownListBoxShowing)
    //        {
    //            HideDropDownList();
    //        }
    //    }

    //    private void ResetFilter()
    //    {
    //        if (this.DataGridView == null) return;
    //        BindingSource source = this.DataGridView.DataSource as BindingSource;
    //        if (source == null || String.IsNullOrEmpty(source.Filter))
    //        {
    //            filtered = false;
    //            selectedFilterValue = "(All)";
    //            currentColumnFilter = String.Empty;
    //        }
    //    }

    //    private void DataGridView_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
    //    {
    //        if (e.Column == OwningColumn &&
    //            e.Column.SortMode == DataGridViewColumnSortMode.Automatic)
    //        {
    //            throw new InvalidOperationException(
    //                "A SortMode value of Automatic is incompatible with " +
    //                "the DGVAutoFilterColumnHeaderCell type. " +
    //                "Use the AutomaticSortingEnabled property instead.");
    //        }
    //    }
    //    #endregion DataGridView events

    //    protected override void Paint(
    //        Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
    //        int rowIndex, DataGridViewElementStates cellState,
    //        object value, object formattedValue, string errorText,
    //        DataGridViewCellStyle cellStyle,
    //        DataGridViewAdvancedBorderStyle advancedBorderStyle,
    //        DataGridViewPaintParts paintParts)
    //    {            
    //        base.Paint(graphics, clipBounds, cellBounds, rowIndex,
    //            cellState, value, formattedValue,
    //            errorText, cellStyle, advancedBorderStyle, paintParts);

    //        if (!FilteringEnabled || (paintParts & DataGridViewPaintParts.ContentBackground) == 0)
    //        {
    //            return;
    //        }

    //        Rectangle buttonBounds = DropDownButtonBounds;

    //        if (buttonBounds.Width < 1 || buttonBounds.Height < 1) return;

    //        if (Application.RenderWithVisualStyles)
    //        {
    //            ComboBoxState state = ComboBoxState.Normal;
    //            if (dropDownListBoxShowing)
    //            {
    //                state = ComboBoxState.Pressed;
    //            }
    //            else if (filtered)
    //            {
    //                state = ComboBoxState.Hot;
    //            }
    //            ComboBoxRenderer.DrawDropDownButton(
    //                graphics, buttonBounds, state);
    //        }
    //        else
    //        {                
    //            Int32 pressedOffset = 0;
    //            PushButtonState state = PushButtonState.Normal;
    //            if (dropDownListBoxShowing)
    //            {
    //                state = PushButtonState.Pressed;
    //                pressedOffset = 1;
    //            }
    //            ButtonRenderer.DrawButton(graphics, buttonBounds, state);

    //            if (filtered)
    //            {
    //                graphics.DrawPolygon(SystemPens.ControlText, new Point[] {
    //                    new Point(
    //                        buttonBounds.Width / 2 + 
    //                            buttonBounds.Left - 1 + pressedOffset, 
    //                        buttonBounds.Height * 3 / 4 + 
    //                            buttonBounds.Top - 1 + pressedOffset),
    //                    new Point(
    //                        buttonBounds.Width / 4 + 
    //                            buttonBounds.Left + pressedOffset,
    //                        buttonBounds.Height / 2 + 
    //                            buttonBounds.Top - 1 + pressedOffset),
    //                    new Point(
    //                        buttonBounds.Width * 3 / 4 + 
    //                            buttonBounds.Left - 1 + pressedOffset,
    //                        buttonBounds.Height / 2 + 
    //                            buttonBounds.Top - 1 + pressedOffset)
    //                });
    //            }
    //            else
    //            {
    //                graphics.FillPolygon(SystemBrushes.ControlText, new Point[] {
    //                    new Point(
    //                        buttonBounds.Width / 2 + 
    //                            buttonBounds.Left - 1 + pressedOffset, 
    //                        buttonBounds.Height * 3 / 4 + 
    //                            buttonBounds.Top - 1 + pressedOffset),
    //                    new Point(
    //                        buttonBounds.Width / 4 + 
    //                            buttonBounds.Left + pressedOffset,
    //                        buttonBounds.Height / 2 + 
    //                            buttonBounds.Top - 1 + pressedOffset),
    //                    new Point(
    //                        buttonBounds.Width * 3 / 4 + 
    //                            buttonBounds.Left - 1 + pressedOffset,
    //                        buttonBounds.Height / 2 + 
    //                            buttonBounds.Top - 1 + pressedOffset)
    //                });
    //            }
    //        }
    //    }

    //    protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
    //    {
    //        Debug.Assert(this.DataGridView != null, "DataGridView is null");

    //        if (lostFocusOnDropDownButtonClick)
    //        {
    //            lostFocusOnDropDownButtonClick = false;
    //            return;
    //        }

    //        Rectangle cellBounds = this.DataGridView.GetCellDisplayRectangle(e.ColumnIndex, -1, false);

    //        if (this.OwningColumn.Resizable == DataGridViewTriState.True &&
    //            ((this.DataGridView.RightToLeft == RightToLeft.No &&
    //            cellBounds.Width - e.X < 6) || e.X < 6))
    //        {
    //            return;
    //        }

    //        Int32 scrollingOffset = 0;
    //        if (this.DataGridView.RightToLeft == RightToLeft.No &&
    //            this.DataGridView.FirstDisplayedScrollingColumnIndex ==
    //            this.ColumnIndex)
    //        {
    //            scrollingOffset =
    //                this.DataGridView.FirstDisplayedScrollingColumnHiddenWidth;
    //        }

    //        if (FilteringEnabled &&
    //            DropDownButtonBounds.Contains(
    //            e.X + cellBounds.Left - scrollingOffset, e.Y + cellBounds.Top))
    //        {

    //            if (this.DataGridView.IsCurrentCellInEditMode)
    //            {                    
    //                this.DataGridView.EndEdit();

    //                BindingSource source =
    //                    this.DataGridView.DataSource as BindingSource;
    //                if (source != null)
    //                {
    //                    source.EndEdit();
    //                }
    //            }
    //            ShowDropDownList(e.ColumnIndex);
    //        }
    //        else if (AutomaticSortingEnabled &&
    //            this.DataGridView.SelectionMode !=
    //            DataGridViewSelectionMode.ColumnHeaderSelect)
    //        {
    //            SortByColumn();
    //        }
    //        base.OnMouseDown(e);
    //    }

    //    private void SortByColumn()
    //    {
    //        Debug.Assert(this.DataGridView != null && OwningColumn != null, "DataGridView or OwningColumn is null");

    //        IBindingList sortList = this.DataGridView.DataSource as IBindingList;
    //        if (sortList == null ||
    //            !sortList.SupportsSorting ||
    //            !AutomaticSortingEnabled)
    //        {
    //            return;
    //        }

    //        ListSortDirection direction = ListSortDirection.Ascending;
    //        if (this.DataGridView.SortedColumn == OwningColumn &&
    //            this.DataGridView.SortOrder == SortOrder.Ascending)
    //        {
    //            direction = ListSortDirection.Descending;
    //        }
    //        this.DataGridView.Sort(OwningColumn, direction);
    //    }
    //    #region drop-down list: Show/HideDropDownListBox, SetDropDownListBoxBounds, DropDownListBoxMaxHeightInternal

    //    private bool dropDownListBoxShowing;                
    //    public void ShowDropDownList(int columnIndex)
    //    {
    //        Debug.Assert(this.DataGridView != null, "DataGridView is null");

    //        if (this.DataGridView.CurrentRow != null &&
    //            this.DataGridView.CurrentRow.IsNewRow)
    //        {
    //            this.DataGridView.CurrentCell = null;
    //        }

    //        PopulateFilters(columnIndex);
    //        String[] filterArray = new String[filters.Count];
    //        filters.Keys.CopyTo(filterArray, 0);
    //        dropDownListBox.Items.Clear();
    //        dropDownListBox.Items.AddRange(filterArray);
    //        dropDownListBox.SelectedItem = selectedFilterValue;

    //        HandleDropDownListBoxEvents();

    //        SetDropDownListBoxBounds();
    //        dropDownListBox.Visible = true;
    //        dropDownListBoxShowing = true;
    //        Debug.Assert(dropDownListBox.Parent == null,
    //            "ShowDropDownListBox has been called multiple times before HideDropDownListBox");

    //        this.DataGridView.Controls.Add(dropDownListBox);                        
    //        dropDownListBox.Focus();            
    //        this.DataGridView.InvalidateCell(this);
    //    }

    //    public void HideDropDownList()
    //    {
    //        Debug.Assert(this.DataGridView != null, "DataGridView is null");

    //        dropDownListBoxShowing = false;
    //        dropDownListBox.Visible = false;
    //        UnhandleDropDownListBoxEvents();
    //        this.DataGridView.Controls.Remove(dropDownListBox);

    //        this.DataGridView.InvalidateCell(this);
    //    }

    //    private void SetDropDownListBoxBounds()
    //    {
    //        Debug.Assert(filters.Count > 0, "filters.Count <= 0");

    //        Int32 dropDownListBoxHeight = 2;
    //        Int32 currentWidth = 0;
    //        Int32 dropDownListBoxWidth = 0;
    //        Int32 dropDownListBoxLeft = 0;

    //        using (Graphics graphics = dropDownListBox.CreateGraphics())
    //        {
    //            foreach (String filter in filters.Keys)
    //            {
    //                SizeF stringSizeF = graphics.MeasureString(
    //                    filter, dropDownListBox.Font);
    //                dropDownListBoxHeight += (Int32)stringSizeF.Height;
    //                currentWidth = (Int32)stringSizeF.Width;
    //                if (dropDownListBoxWidth < currentWidth)
    //                {
    //                    dropDownListBoxWidth = currentWidth;
    //                }
    //            }
    //        }

    //        dropDownListBoxWidth += 6;

    //        if (dropDownListBoxHeight > DropDownListBoxMaxHeightInternal)
    //        {
    //            dropDownListBoxHeight = DropDownListBoxMaxHeightInternal;
    //            dropDownListBoxWidth += SystemInformation.VerticalScrollBarWidth;
    //        }

    //        if (this.DataGridView.RightToLeft == RightToLeft.No)
    //        {
    //            dropDownListBoxLeft = DropDownButtonBounds.Right -
    //                dropDownListBoxWidth + 1;
    //        }
    //        else
    //        {
    //            dropDownListBoxLeft = DropDownButtonBounds.Left - 1;
    //        }

    //        Int32 clientLeft = 1;
    //        Int32 clientRight = this.DataGridView.ClientRectangle.Right;
    //        if (this.DataGridView.DisplayedRowCount(false) <
    //            this.DataGridView.RowCount)
    //        {
    //            if (this.DataGridView.RightToLeft == RightToLeft.Yes)
    //            {
    //                clientLeft += SystemInformation.VerticalScrollBarWidth;
    //            }
    //            else
    //            {
    //                clientRight -= SystemInformation.VerticalScrollBarWidth;
    //            }
    //        }

    //        if (dropDownListBoxLeft < clientLeft)
    //        {
    //            dropDownListBoxLeft = clientLeft;
    //        }
    //        Int32 dropDownListBoxRight =
    //            dropDownListBoxLeft + dropDownListBoxWidth + 1;
    //        if (dropDownListBoxRight > clientRight)
    //        {
    //            if (dropDownListBoxLeft == clientLeft)
    //            {
    //                dropDownListBoxWidth -=
    //                    dropDownListBoxRight - clientRight;
    //            }
    //            else
    //            {
    //                dropDownListBoxLeft -=
    //                    dropDownListBoxRight - clientRight;
    //                if (dropDownListBoxLeft < clientLeft)
    //                {
    //                    dropDownListBoxWidth -= clientLeft - dropDownListBoxLeft;
    //                    dropDownListBoxLeft = clientLeft;
    //                }
    //            }
    //        }

    //        dropDownListBox.Bounds = new Rectangle(dropDownListBoxLeft,
    //            DropDownButtonBounds.Bottom, 
    //            dropDownListBoxWidth, dropDownListBoxHeight);
    //    }

    //    protected Int32 DropDownListBoxMaxHeightInternal
    //    {
    //        get
    //        {

    //            Int32 dataGridViewMaxHeight = this.DataGridView.Height -
    //                this.DataGridView.ColumnHeadersHeight - 1;
    //            if (this.DataGridView.DisplayedColumnCount(false) <
    //                this.DataGridView.ColumnCount)
    //            {
    //                dataGridViewMaxHeight -=
    //                    SystemInformation.HorizontalScrollBarHeight;
    //            }

    //            Int32 listMaxHeight = dropDownListBoxMaxLinesValue * dropDownListBox.ItemHeight + 2;

    //            if (listMaxHeight < dataGridViewMaxHeight)
    //            {
    //                return listMaxHeight;
    //            }
    //            else
    //            {
    //                return dataGridViewMaxHeight;
    //            }
    //        }
    //    }
    //    #endregion drop-down list
    //    #region ListBox events: HandleDropDownListBoxEvents, UnhandleDropDownListBoxEvents, ListBox event handlers

    //    private void HandleDropDownListBoxEvents()
    //    {
    //        dropDownListBox.MouseClick += new MouseEventHandler(DropDownListBox_MouseClick);
    //        dropDownListBox.LostFocus += new EventHandler(DropDownListBox_LostFocus);
    //        dropDownListBox.KeyDown += new KeyEventHandler(DropDownListBox_KeyDown);
    //    }

    //    private void UnhandleDropDownListBoxEvents()
    //    {
    //        dropDownListBox.MouseClick -= new MouseEventHandler(DropDownListBox_MouseClick);
    //        dropDownListBox.LostFocus -= new EventHandler(DropDownListBox_LostFocus);
    //        dropDownListBox.KeyDown -= new KeyEventHandler(DropDownListBox_KeyDown);
    //    }

    //    private void DropDownListBox_MouseClick(object sender, MouseEventArgs e)
    //    {
    //        Debug.Assert(this.DataGridView != null, "DataGridView is null");

    //        if (!dropDownListBox.DisplayRectangle.Contains(e.X, e.Y))
    //        {
    //            return;
    //        }
    //        UpdateFilter();
    //        HideDropDownList();
    //    }

    //    private Boolean lostFocusOnDropDownButtonClick;                
    //    private void DropDownListBox_LostFocus(object sender, EventArgs e)
    //    {            
    //        if (DropDownButtonBounds.Contains(
    //            this.DataGridView.PointToClient(new Point(
    //            Control.MousePosition.X, Control.MousePosition.Y))))
    //        {
    //            lostFocusOnDropDownButtonClick = true;
    //        }
    //        HideDropDownList();
    //    }                
    //    void DropDownListBox_KeyDown(object sender, KeyEventArgs e)
    //    {
    //        switch (e.KeyCode)
    //        {
    //            case Keys.Enter:
    //                UpdateFilter();
    //                HideDropDownList();
    //                break;
    //            case Keys.Escape:
    //                HideDropDownList();
    //                break;
    //        }
    //    }
    //    #endregion ListBox events
    //    #region filtering: PopulateFilters, FilterWithoutCurrentColumn, UpdateFilter, RemoveFilter, AvoidNewRowWhenFiltering, GetFilterStatus

    //    private void PopulateFilters(int columnIndex)
    //    {

    //        if (this.DataGridView == null)
    //        {
    //            return;
    //        }
    //        BindingSource data = null;
    //        if (this.DataGridView.Columns[columnIndex].GetType() is DataGridViewTextBoxColumn)
    //        {
    //            data = this.DataGridView.DataSource as BindingSource;

    //        }
    //        else if (this.DataGridView.Columns[columnIndex].GetType() == typeof(DGVMCComboBoxColumn))
    //        {
    //            DGVMCComboBoxColumn t = this.DataGridView.Columns[columnIndex] as DGVMCComboBoxColumn;
    //            data = new BindingSource(((System.Windows.Forms.DataGridViewComboBoxColumn)(t)).DataSource, "");
    //            //data = ;
    //            //data = t.DataSource as BindingSource;
    //        }
    //        //BindingSource data = this.DataGridView.DataSource as BindingSource;
    //        //BindingSource data = t.DataSource as BindingSource;
    //        Debug.Assert(data != null && data.SupportsFiltering && OwningColumn != null,
    //            "DataSource is not a BindingSource, or does not support filtering, or OwningColumn is null");

    //        data.RaiseListChangedEvents = false;

    //        String oldFilter = data.Filter;
    //        data.Filter = FilterWithoutCurrentColumn(oldFilter);

    //        filters.Clear();
    //        Boolean containsBlanks = false;
    //        Boolean containsNonBlanks = false;

    //        ArrayList list = new ArrayList(data.Count);
    //        ArrayList listKey = new ArrayList(data.Count);

    //        foreach (Object item in data)
    //        {
    //            Object value = null;
    //            Object valueKey = null;

    //            ICustomTypeDescriptor ictd = item as ICustomTypeDescriptor;
    //            if (ictd != null)
    //            {
    //                PropertyDescriptorCollection properties = ictd.GetProperties();
    //                foreach (PropertyDescriptor property in properties)
    //                {
    //                    //if (String.Compare(this.OwningColumn.DataPropertyName,
    //                    //    property.Name, true /*case insensitive*/,
    //                    //    System.Globalization.CultureInfo.InvariantCulture) == 0)
    //                    if (String.Compare("Text",
    //property.Name, true /*case insensitive*/,
    //System.Globalization.CultureInfo.InvariantCulture) == 0)
    //                    {                            
    //                        value = property.GetValue(item);
    //                        break;
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                PropertyInfo[] properties = item.GetType().GetProperties(
    //                    BindingFlags.Public | BindingFlags.Instance);
    //                foreach (PropertyInfo property in properties)
    //                {
    //                    if (String.Compare(this.OwningColumn.DataPropertyName,
    //                        property.Name, true /*case insensitive*/,
    //                        System.Globalization.CultureInfo.InvariantCulture) == 0)
    //                    {
    //                        //if (property.Name.Equals(""))
    //                        value = property.GetValue(item, null /*property index*/);

    //                        break;
    //                    }
    //                }
    //            }

    //            if (value == null || value == DBNull.Value)
    //            {
    //                containsBlanks = true;
    //                continue;
    //            }

    //            if (!list.Contains(value))
    //            {                    
    //                list.Add(value);
    //                //listKey.Add();
    //            }
    //        }

    //        list.Sort();

    //        foreach (Object value in list)
    //        {

    //            String formattedValue = null;
    //            DataGridViewCellStyle style = OwningColumn.InheritedStyle;
    //            formattedValue = (String)GetFormattedValue(value, -1, ref style,
    //                null, null, DataGridViewDataErrorContexts.Formatting);
    //            if (String.IsNullOrEmpty(formattedValue))
    //            {                    
    //                containsBlanks = true;
    //            }
    //            else if (!filters.Contains(formattedValue))
    //            {                    
    //                containsNonBlanks = true;                 
    //                filters.Add(formattedValue, value.ToString());
    //            }
    //        }

    //        if (oldFilter != null) data.Filter = oldFilter;
    //        data.RaiseListChangedEvents = true;

    //        filters.Insert(0, "(All)", null);
    //        if (containsBlanks && containsNonBlanks)
    //        {
    //            filters.Add("(Blanks)", null);
    //            filters.Add("(NonBlanks)", null);
    //        }
    //    }

    //    private String FilterWithoutCurrentColumn(String filter)
    //    {            
    //        if (String.IsNullOrEmpty(filter))
    //        {
    //            return String.Empty;
    //        }

    //        if (!filtered)
    //        {
    //            return filter;
    //        }
    //        if (filter.IndexOf(currentColumnFilter) > 0)
    //        {                
    //            return filter.Replace(
    //                " AND " + currentColumnFilter, String.Empty);
    //        }
    //        else
    //        {
    //            if (filter.Length > currentColumnFilter.Length)
    //            {                    
    //                return filter.Replace(currentColumnFilter + " AND ", String.Empty);
    //            }
    //            else
    //            {                    
    //                return String.Empty;
    //            }
    //        }
    //    }

    //    private void UpdateFilter()
    //    {            
    //        if (dropDownListBox.SelectedItem.ToString().Equals(selectedFilterValue))
    //        {
    //            return;
    //        }

    //        selectedFilterValue = dropDownListBox.SelectedItem.ToString();

    //        IBindingListView data = this.DataGridView.DataSource as IBindingListView;
    //        Debug.Assert(data != null && data.SupportsFiltering,
    //            "DataSource is not an IBindingListView or does not support filtering");

    //        if (selectedFilterValue.Equals("(All)"))
    //        {
    //            data.Filter = FilterWithoutCurrentColumn(data.Filter);
    //            filtered = false;
    //            currentColumnFilter = String.Empty;
    //            return;
    //        }

    //        String newColumnFilter = null;

    //        String columnProperty = OwningColumn.DataPropertyName.Replace("]", @"\]");

    //        switch (selectedFilterValue)
    //        {
    //            case "(Blanks)":
    //                newColumnFilter = String.Format(
    //                    "LEN(ISNULL(CONVERT([{0}],'System.String'),''))=0",
    //                    columnProperty);
    //                break;
    //            case "(NonBlanks)":
    //                newColumnFilter = String.Format(
    //                    "LEN(ISNULL(CONVERT([{0}],'System.String'),''))>0",
    //                    columnProperty);
    //                break;
    //            default:
    //                newColumnFilter = String.Format("[{0}]='{1}'",
    //                    columnProperty,
    //                    ((String)filters[selectedFilterValue])
    //                    .Replace("'", "''"));
    //                break;
    //        }

    //        String newFilter = FilterWithoutCurrentColumn(data.Filter);
    //        if (String.IsNullOrEmpty(newFilter))
    //        {
    //            newFilter += newColumnFilter;
    //        }
    //        else
    //        {
    //            newFilter += " AND " + newColumnFilter;
    //        }

    //        try
    //        {
    //            data.Filter = newFilter;
    //        }
    //        catch (InvalidExpressionException ex)
    //        {
    //            throw new NotSupportedException(
    //                "Invalid expression: " + newFilter, ex);
    //        }

    //        filtered = true;
    //        currentColumnFilter = newColumnFilter;
    //    }

    //    public static void RemoveFilter(DataGridView dataGridView)
    //    {
    //        if (dataGridView == null)
    //        {
    //            throw new ArgumentNullException("dataGridView");
    //        }

    //        BindingSource data = dataGridView.DataSource as BindingSource;

    //        if (data == null ||
    //            data.DataSource == null ||
    //            !data.SupportsFiltering)
    //        {
    //            throw new ArgumentException("The DataSource property of the " +
    //                "specified DataGridView is not set to a BindingSource " +
    //                "with a SupportsFiltering property value of true.");
    //        }

    //        if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.IsNewRow)
    //        {
    //            dataGridView.CurrentCell = null;
    //        }

    //        data.Filter = null;
    //    }

    //    public static String GetFilterStatus(DataGridView dataGridView)
    //    {
    //        try
    //        {
    //            if (dataGridView == null)
    //            {
    //                throw new ArgumentNullException("dataGridView");
    //            }

    //            BindingSource data = dataGridView.DataSource as BindingSource;

    //            if (String.IsNullOrEmpty(data.Filter) ||
    //                data == null ||
    //                data.DataSource == null ||
    //                !data.SupportsFiltering)
    //            {
    //                return String.Empty;
    //            }

    //            Int32 currentRowCount = data.Count;

    //            data.RaiseListChangedEvents = false;
    //            String oldFilter = data.Filter;
    //            data.Filter = null;
    //            Int32 unfilteredRowCount = data.Count;
    //            data.Filter = oldFilter;
    //            data.RaiseListChangedEvents = true;
    //            Debug.Assert(currentRowCount <= unfilteredRowCount,
    //                "current count is greater than unfiltered count");

    //            if (currentRowCount == unfilteredRowCount)
    //            {
    //                return String.Empty;
    //            }
    //            return String.Format("{0} of {1} records found", currentRowCount, unfilteredRowCount);
    //        }
    //        catch { return ""; }
    //    }
    //    #endregion filtering
    //    #region button bounds: DropDownButtonBounds, InvalidateDropDownButtonBounds, SetDropDownButtonBounds, AdjustPadding

    //    private Rectangle dropDownButtonBoundsValue = Rectangle.Empty;
    //    protected Rectangle DropDownButtonBounds
    //    {
    //        get
    //        {
    //            if (!FilteringEnabled)
    //            {
    //                return Rectangle.Empty;
    //            }
    //            if (dropDownButtonBoundsValue == Rectangle.Empty)
    //            {
    //                SetDropDownButtonBounds();
    //            }
    //            return dropDownButtonBoundsValue;
    //        }
    //    }
    //    private void InvalidateDropDownButtonBounds()
    //    {
    //        if (!dropDownButtonBoundsValue.IsEmpty)
    //        {
    //            dropDownButtonBoundsValue = Rectangle.Empty;
    //        }
    //    }

    //    private void SetDropDownButtonBounds()
    //    {

    //        Rectangle cellBounds =
    //            this.DataGridView.GetCellDisplayRectangle(
    //            this.ColumnIndex, -1, false);

    //        Int32 buttonEdgeLength = this.InheritedStyle.Font.Height + 5;

    //        Rectangle borderRect = BorderWidths(
    //            this.DataGridView.AdjustColumnHeaderBorderStyle(
    //            this.DataGridView.AdvancedColumnHeadersBorderStyle,
    //            new DataGridViewAdvancedBorderStyle(), false, false));
    //        Int32 borderAndPaddingHeight = 2 +
    //            borderRect.Top + borderRect.Height +
    //            this.InheritedStyle.Padding.Vertical;
    //        Boolean visualStylesEnabled =
    //            Application.RenderWithVisualStyles &&
    //            this.DataGridView.EnableHeadersVisualStyles;
    //        if (visualStylesEnabled)
    //        {
    //            borderAndPaddingHeight += 3;
    //        }

    //        if (buttonEdgeLength >
    //            this.DataGridView.ColumnHeadersHeight -
    //            borderAndPaddingHeight)
    //        {
    //            buttonEdgeLength =
    //                this.DataGridView.ColumnHeadersHeight -
    //                borderAndPaddingHeight;
    //        }

    //        if (buttonEdgeLength > cellBounds.Width - 3)
    //        {
    //            buttonEdgeLength = cellBounds.Width - 3;
    //        }

    //        Int32 topOffset = visualStylesEnabled ? 4 : 1;
    //        Int32 top = cellBounds.Bottom - buttonEdgeLength - topOffset;
    //        Int32 leftOffset = visualStylesEnabled ? 3 : 1;
    //        Int32 left = 0;
    //        if (this.DataGridView.RightToLeft == RightToLeft.No)
    //        {
    //            left = cellBounds.Right - buttonEdgeLength - leftOffset;
    //        }
    //        else
    //        {
    //            left = cellBounds.Left + leftOffset;
    //        }

    //        dropDownButtonBoundsValue = new Rectangle(left, top,
    //            buttonEdgeLength, buttonEdgeLength);
    //        AdjustPadding(buttonEdgeLength + leftOffset);
    //    }

    //    private void AdjustPadding(Int32 newDropDownButtonPaddingOffset)
    //    {            
    //        Int32 widthChange = newDropDownButtonPaddingOffset -
    //            currentDropDownButtonPaddingOffset;

    //        if (widthChange != 0)
    //        {

    //            currentDropDownButtonPaddingOffset = newDropDownButtonPaddingOffset;

    //            Padding dropDownPadding = new Padding(0, 0, widthChange, 0);
    //            this.Style.Padding = Padding.Add(
    //                this.InheritedStyle.Padding, dropDownPadding);
    //        }
    //    }

    //    private Int32 currentDropDownButtonPaddingOffset;
    //    #endregion button bounds
    //    #region public properties: FilteringEnabled, AutomaticSortingEnabled, DropDownListBoxMaxLines

    //    private Boolean filteringEnabledValue = true;        
    //    [DefaultValue(true)]
    //    public Boolean FilteringEnabled
    //    {
    //        get
    //        {                
    //            if (this.DataGridView == null ||
    //                this.DataGridView.DataSource == null)
    //            {
    //                return filteringEnabledValue;
    //            }

    //            BindingSource data = this.DataGridView.DataSource as BindingSource;
    //            Debug.Assert(data != null);
    //            return filteringEnabledValue && data.SupportsFiltering;
    //        }
    //        set
    //        {                
    //            if (!value)
    //            {
    //                AdjustPadding(0);
    //                InvalidateDropDownButtonBounds();
    //            }
    //            filteringEnabledValue = value;
    //        }
    //    }

    //    private Boolean automaticSortingEnabledValue = true;        
    //    [DefaultValue(true)]
    //    public Boolean AutomaticSortingEnabled
    //    {
    //        get
    //        {
    //            return automaticSortingEnabledValue;
    //        }
    //        set
    //        {
    //            automaticSortingEnabledValue = value;
    //            if (OwningColumn != null)
    //            {
    //                if (value)
    //                {
    //                    OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
    //                }
    //                else
    //                {
    //                    OwningColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
    //                }
    //            }
    //        }
    //    }


    //    private Int32 dropDownListBoxMaxLinesValue = 20;                
    //    [DefaultValue(20)]
    //    public Int32 DropDownListBoxMaxLines
    //    {
    //        get { return dropDownListBoxMaxLinesValue; }
    //        set { dropDownListBoxMaxLinesValue = value; }
    //    }
    //    #endregion public properties

    //    private class FilterListBox : ListBox
    //    {        
    //        public FilterListBox()
    //        {
    //            Visible = false;
    //            IntegralHeight = true;
    //            BorderStyle = BorderStyle.FixedSingle;
    //            TabStop = false;
    //        }

    //        protected override bool IsInputKey(Keys keyData)
    //        {
    //            return true;
    //        }

    //        protected override bool ProcessKeyMessage(ref Message m)
    //        {
    //            return ProcessKeyEventArgs(ref m);
    //        }
    //    }
    //}
}
