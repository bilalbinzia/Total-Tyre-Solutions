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

namespace AppControls
{
    public partial class ctrToggleWOColumns : UserControl
    {
        DataTable dt;
        public ctrToggleWOColumns()
        {
            InitializeComponent();
            this.Load += ctrToggleWOColumns_Load;

            this.btnDone.Click += btnDone_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnReturnToDefaultSettings.Click += btnReturnToDefaultSettings_Click;
        }

        void btnReturnToDefaultSettings_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item != null)
                {
                    Item.Checked = false;
                    dt.Rows[0][Item.SubItems[0].Text.Trim()] = false;
                }
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {            
            this.ParentForm.Close();
        }

        void btnDone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item != null)
                {
                    dt.Rows[0][Item.SubItems[0].Text.Trim()] = Convert.ToBoolean(Item.Checked);
                }
            }
            dbClass.obj.UpdateWOToggleColumns(dt);

            this.Parent.Parent.Parent.Dispose();
        }

        void ctrToggleWOColumns_Load(object sender, EventArgs e)
        {
            dt = dbClass.obj.getWOToggleColumns();

            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item != null)
                {
                    Item.Checked = Convert.ToBoolean(dt.Rows[0][Item.SubItems[0].Text.Trim()]);
                }
            }
        }


    }
}
