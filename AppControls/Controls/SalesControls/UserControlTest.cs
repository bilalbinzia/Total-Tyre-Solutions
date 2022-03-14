using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;

namespace AppControls.Controls.SalesControls
{
    public partial class UserControlTest : BaseControl
    {
        BindingSource CustomerBS;
        public UserControlTest()
        {
            InitializeComponent();
            InitializeComponent();
            //CustomerBS = new BindingSource();

            this.Load += UserControlTest_Load;
        }

        private void UserControlTest_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
