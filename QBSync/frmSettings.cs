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
using CButtonLib;
using ControlLibrary;

namespace QBSync
{
    public partial class frmSettings : Form
    {
        ControlLibrary.MessageBox xMessageBox;
        public frmSettings()
        {
            InitializeComponent();
            xMessageBox = new ControlLibrary.MessageBox();
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnTest.Click += btnTest_Click;
            btnBrowseQBFile.Click += btnBrowseQBFile_Click;            

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (xMessageBox.Show("Do you want save changes?", "QuickBooks Settings..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.Yes)                    
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    if (ValidateFields())
                    {
                        Data.dsQBSync ds = new QBSync.Data.dsQBSync();
                        Data.dsQBSyncTableAdapters.SettingsTableAdapter taSetting = new QBSync.Data.dsQBSyncTableAdapters.SettingsTableAdapter();

                        taSetting.Fill(ds.Settings);
                        if (ds.Settings != null && ds.Settings.Rows.Count > 0)
                        {
                            Common.Settings = ds.Settings[0];

                            Common.Settings.QuickBooksFile = txtFilePath.Text;                           
                            //Common.Settings.SyncTimeInterval = Convert.ToInt32(String.IsNullOrEmpty(txtAutoRunMin.Text) ? "0" : txtAutoRunMin.Text);
                            Common.Settings.SyncStartDate = dtpSyncStartDate.Value;                           

                            taSetting.Update(Common.Settings);
                        }
                        else
                        {
                            Common.Settings = ds.Settings.NewSettingsRow();

                            Common.Settings.QuickBooksFile = txtFilePath.Text;                         
                            //Common.Settings.SyncTimeInterval = Convert.ToInt32(String.IsNullOrEmpty(txtAutoRunMin.Text) ? "0" : txtAutoRunMin.Text);
                            Common.Settings.SyncStartDate = dtpSyncStartDate.Value;                          

                            ds.Settings.AddSettingsRow(Common.Settings);
                            taSetting.Update(Common.Settings);

                        }
                        //MessageBox.Show("Setting saved successfully", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xMessageBox.Show("Setting saved successfully", "QuickBooks Settings..!", CCMessageBox.iMessageBoxButtons.OK);
                    }
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;             
                Data.dsQBSync ds = new QBSync.Data.dsQBSync();
                Data.dsQBSyncTableAdapters.SettingsTableAdapter taSetting = new QBSync.Data.dsQBSyncTableAdapters.SettingsTableAdapter();

                taSetting.Fill(ds.Settings);
                if (ds.Settings != null && ds.Settings.Rows.Count > 0)
                {
                    Common.Settings = ds.Settings[0];

                    txtFilePath.Text = Common.Settings.QuickBooksFile;
                    //txtAutoRunMin.Text = Common.Settings.SyncTimeInterval.ToString();
                    dtpSyncStartDate.Value = Common.Settings.IsSyncStartDateNull() ? Convert.ToDateTime("1980-01-01") : Common.Settings.SyncStartDate;  
                  
                }

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Common.ExceptionHandler(ex);                
                xMessageBox.Show(ex.Message, "QuickBooks Settings..!", CCMessageBox.iMessageBoxButtons.OK, CCMessageBox.iMessageBoxIcon.Warning);
            }
        }     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Boolean blnPathChanged;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Access Databases|*.MDB;";//*.xls;

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlgOpen.FileName;
                blnPathChanged = true;
            }
        }        
            
        private void btnBrowseQBFile_Click(object sender, EventArgs e)
        {
            dlgBrowse.FileName = "QuickBooks Company File";
            dlgBrowse.Filter = "QuickBooks Files|*.QBW;";
            if (!String.IsNullOrEmpty(txtFilePath.Text))
                dlgBrowse.FileName = txtFilePath.Text;

            if (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dlgBrowse.FileName;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                QBConnection.StartQBSession(txtFilePath.Text.Trim());                
                xMessageBox.Show("Connected Successfully", "QuickBooks Settings..!", CCMessageBox.iMessageBoxButtons.OK, CCMessageBox.iMessageBoxIcon.Information);
                QBConnection.EndQBSession();
            }
            catch (Exception ex)
            {
                QBConnection.EndQBSession();                
                xMessageBox.Show(ex.Message, "QuickBooks Settings..!", CCMessageBox.iMessageBoxButtons.OK, CCMessageBox.iMessageBoxIcon.Information);
            }
        }

        private void txtAutoRunMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.IsNumeric(e.KeyChar, txtAutoRunMin.Text, false);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ValidateFields())
            //    {
            //        MessageBox.Show("Successfully validated", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private bool ValidateFields()
        {
            bool blnResult = true;

            errPrvdr.Clear();
            //if (String.IsNullOrEmpty(txtMasjidKey.Text))
            //{
            //    errPrvdr.SetError(btnValidate, "Customer QB Key is required field");
            //    txtMasjidKey.Focus();
            //    return false;
            //}

            //WebService.MohidData mohid_webservice = new QBSync.WebService.MohidData();
            //QBSync.WebService.MasjidKey objKey = mohid_webservice.GetMasjidKey(txtMasjidKey.Text);
            //if (objKey == null)
            //{
            //    //objKey.masjid_key 
            //    blnResult = false;
            //    MessageBox.Show("Invalid Key, Provide a valid key.", Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            return blnResult;
        }

        private void btnLastSyncDates_Click(object sender, EventArgs e)
        {
            frmSyncDate frm = new frmSyncDate();
            frm.ShowDialog();
        }
    }
}
