using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ControlLibrary
{
    public class CalendarColumn : DataGridViewTextBoxColumn
    {
        private int displayOrder;

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }

        public CalendarColumn()
        {

        }

    }
}
