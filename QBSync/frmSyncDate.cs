using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBSync.QuickBooks;
using System.Configuration;
using System.Xml;

namespace QBSync
{
    public partial class frmSyncDate : Form
    {
        public frmSyncDate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want save changes?", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                   
                        MessageBox.Show("Setting saved successfully", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);
            }
        }

        private void frmSyncDate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                FillGrid();                

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);
            }
        }

        private void FillGrid()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                Data.dsQBSync ds = new QBSync.Data.dsQBSync();
                Data.dsQBSyncTableAdapters.QBConfigTableAdapter taQBConfig = new Data.dsQBSyncTableAdapters.QBConfigTableAdapter();

                taQBConfig.FillAll(ds.QBConfig);

                grdSyncLog.AutoGenerateColumns = false;
                grdSyncLog.DataSource = ds.QBConfig;

                grdSyncLog.Sort(this.grdSyncLog.Columns[colConfigValue.Name], ListSortDirection.Descending);


                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);                
            }
        }      
 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grdSyncLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex == colBtnReset.Index)
                {
                    string strConfigKey = Convert.ToString(grdSyncLog.Rows[e.RowIndex].Cells[colConfigKey.Name].Value);
                    string strConfigValue = Convert.ToString(grdSyncLog.Rows[e.RowIndex].Cells[colConfigValue.Name].Value);

                    if (MessageBox.Show("Do you want to reset last sync date?", Common.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Data.dsQBSyncTableAdapters.QBConfigTableAdapter taConfig = new QBSync.Data.dsQBSyncTableAdapters.QBConfigTableAdapter();
                        taConfig.DeleteByConfigKey(strConfigKey);

                        FillGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ExceptionHandler(ex);
            }
        }       
    }
}
