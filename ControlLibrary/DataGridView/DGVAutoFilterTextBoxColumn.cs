using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace ControlLibrary
{
    //public class DGVAutoFilterTextBoxColumn : DataGridViewTextBoxColumn
    //{

    //    public DGVAutoFilterTextBoxColumn()
    //        : base()
    //    {
    //        base.DefaultHeaderCellType = typeof(DGVAutoFilterColumnHeaderCell);
    //        base.SortMode = DataGridViewColumnSortMode.Programmatic;
    //    }
    //    #region public properties that hide inherited, non-virtual properties: DefaultHeaderCellType and SortMode

    //    [EditorBrowsable(EditorBrowsableState.Never), Browsable(false),
    //    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public new Type DefaultHeaderCellType
    //    {
    //        get
    //        {
    //            return typeof(DGVAutoFilterColumnHeaderCell);
    //        }
    //    }
    //    [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
    //    [DefaultValue(DataGridViewColumnSortMode.Programmatic)]
    //    public new DataGridViewColumnSortMode SortMode
    //    {
    //        get
    //        {
    //            return base.SortMode;
    //        }
    //        set
    //        {
    //            if (value == DataGridViewColumnSortMode.Automatic)
    //            {
    //                throw new InvalidOperationException(
    //                    "A SortMode value of Automatic is incompatible with " +
    //                    "the DGVAutoFilterColumnHeaderCell type. " +
    //                    "Use the AutomaticSortingEnabled property instead.");
    //            }
    //            else
    //            {
    //                base.SortMode = value;
    //            }
    //        }
    //    }
    //    #endregion
    //    #region public properties: FilteringEnabled, AutomaticSortingEnabled, DropDownListBoxMaxLines

    //    [DefaultValue(true)]
    //    public Boolean FilteringEnabled
    //    {
    //        get
    //        {                
    //            return ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .FilteringEnabled;
    //        }
    //        set
    //        {                
    //            ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .FilteringEnabled = value;
    //        }
    //    }

    //    [DefaultValue(true)]
    //    public Boolean AutomaticSortingEnabled
    //    {
    //        get
    //        {                
    //            return ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .AutomaticSortingEnabled;
    //        }
    //        set
    //        {                
    //            ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .AutomaticSortingEnabled = value;
    //        }
    //    }

    //    [DefaultValue(20)]
    //    public Int32 DropDownListBoxMaxLines
    //    {
    //        get
    //        {                
    //            return ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .DropDownListBoxMaxLines;
    //        }
    //        set
    //        {                
    //            ((DGVAutoFilterColumnHeaderCell)HeaderCell)
    //                .DropDownListBoxMaxLines = value;
    //        }
    //    }
    //    #endregion public properties
    //    #region public, static, convenience methods: RemoveFilter and GetFilterStatus

    //    public static void RemoveFilter(DataGridView dataGridView)
    //    {
    //        DGVAutoFilterColumnHeaderCell.RemoveFilter(dataGridView);
    //    }

    //    public static String GetFilterStatus(DataGridView dataGridView)
    //    {
    //        return DGVAutoFilterColumnHeaderCell.GetFilterStatus(dataGridView);
    //    }
    //    #endregion
    //}
}
