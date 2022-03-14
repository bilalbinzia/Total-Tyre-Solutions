using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class DGVTextBoxColumn : DataGridViewTextBoxColumn
    {
        private bool isFilteringColumn;
        public bool IsFilteringColumn
        {
            get { return isFilteringColumn; }
            set { isFilteringColumn = value; }
        }

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }

        private int displayIndex;
        public int xDisplayIndex
        {
            get { return displayIndex; }
            set { displayIndex = value; }
        }

        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }
        private StaticInfo.YesNo showCurrency;
        public StaticInfo.YesNo xShowCurrency
        {
            get { return showCurrency; }
            set { showCurrency = value; }
        }

        private StaticInfo.gColumnType columnType;
        public StaticInfo.gColumnType xColumnType
        {
            get { return columnType; }
            set { columnType = value; }
        }

        public override object Clone()
        {
            var clone = (DGVTextBoxColumn)base.Clone();
            if (clone == null) return null;

            clone.xBindingProperty = xBindingProperty;
            clone.xColumnType = xColumnType;
            clone.xIsRequired = xIsRequired;
            clone.xDisplayIndex = xDisplayIndex;
            clone.xShowCurrency = xShowCurrency;

            return clone;
        }

        public DGVTextBoxColumn()
        {
            
        }

    }
}
