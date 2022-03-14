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
using DBModule;
using System32;
using System.Globalization;

namespace AppControls
{

    public partial class ctrProfitBreakDown : UserControl
    {

        string tblName = "";
        private BindingSource bindingSource;
        DataTable dt;
        public ctrProfitBreakDown()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            this.Load += ctrProfitBreakDown_Load;
        }
        public ctrProfitBreakDown(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            bindingSource = new BindingSource();
            this.Load += ctrProfitBreakDown_Load;
        }

        void ctrProfitBreakDown_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = dt;
            searchDataGridView1.RowHeadersVisible = true;
            searchDataGridView1.DataSource = bindingSource;

            //-----------------------------------------------------------------------------------//
            foreach (DataGridViewColumn col in searchDataGridView1.Columns)
            {
                if (!string.IsNullOrEmpty(((DGVTextBoxColumn)col).xBindingProperty))
                {
                    if (((DGVTextBoxColumn)col).xShowCurrency == StaticInfo.YesNo.Yes)
                    {
                        DataGridViewCellStyle DecimalColumnCellStyle = new DataGridViewCellStyle();
                        DecimalColumnCellStyle.Format = "C2";
                        DecimalColumnCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                        DecimalColumnCellStyle.NullValue = "0.00";
                        ((DGVTextBoxColumn)col).DefaultCellStyle = DecimalColumnCellStyle;
                    }
                }
            }
            //-----------------------------------------------------------------------------------//
        }
    }
}
