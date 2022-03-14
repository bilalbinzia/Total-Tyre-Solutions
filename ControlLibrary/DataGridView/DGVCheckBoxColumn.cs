using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary
{
    public class DGVCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }

    }
}
