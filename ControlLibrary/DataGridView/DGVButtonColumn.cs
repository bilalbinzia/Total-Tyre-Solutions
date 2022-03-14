using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary
{
    public class DGVButtonColumn : DataGridViewButtonColumn
    {
        private string buttonType;
        public string xButtonType
        {
            get { return buttonType; }
            set { buttonType = value; }
        }
    }
}
