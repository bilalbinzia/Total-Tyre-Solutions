using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using Configuration;

namespace Accounts.Parameter
{
    public partial class ctrChartOfAccount : UserControl
    {

        public ctrChartOfAccount()
        {
            InitializeComponent();
            this.cboCriteria.SelectedIndex = 0;
        }
        
        
    }

}

