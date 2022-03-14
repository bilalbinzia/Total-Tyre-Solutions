using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QBSync
{
    public partial class frmApplicationLog : Form
    {
        public frmApplicationLog()
        {
            InitializeComponent();

            dtpFrom.Value = System.DateTime.Now;
            dtpTo.Value = System.DateTime.Now;

            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                Data.dsQBSync ds = new Data.dsQBSync();
                Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter taAppLog = new QBSync.Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter();

                taAppLog.Search(ds.ApplicationLog, dtpFrom.Value.Date, dtpTo.Value.AddDays(1).Date);

                grdAppLog.AutoGenerateColumns = false;
                grdAppLog.DataSource = ds.ApplicationLog;

            }
            catch (Exception ex)
            {
                Common.ExceptionHandler(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to clear All Log", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter taAppLog = new QBSync.Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter();
                    taAppLog.DeleteAll();
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                Common.ExceptionHandler(ex);
            }
        }
    }
}
