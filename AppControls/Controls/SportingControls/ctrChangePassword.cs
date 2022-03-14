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
using System32;

namespace AppControls
{
    public partial class ctrChangePassword : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = null;
        MainDataSet objDataSet = null;        
        string dbOldpassword = string.Empty;
        dbClass objdbClass;
        public ctrChangePassword()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ctrChangePassword_Load);
            this.txtBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPassword_KeyDown);
            this.txtBoxConform.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxConform_KeyDown);
            this.txtBoxOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxOld_KeyDown);
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            

            xMessageBox = new ControlLibrary.MessageBox();
            objdbClass = new dbClass();
            objDataSet = new MainDataSet();            
        }
        private void Validation()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBoxOld.Text.ToString().Trim()))
                {
                    if (!string.IsNullOrEmpty(txtBoxPassword.Text.ToString().Trim()))
                    {
                        if (!string.IsNullOrEmpty(txtBoxConform.Text.ToString().Trim()))
                        {
                            if (txtBoxPassword.Text.ToString().Trim() != txtBoxConform.Text.ToString().Trim())
                            {
                                xMessageBox.Show("Conform Password is not same!"); txtBoxConform.Focus();
                            }
                            else
                            {
                                this.Cursor = Cursors.WaitCursor;
                                string oldpassword = System32.EncryptDecrypt.Encrypt(txtBoxOld.Text.ToString().Trim());
                                if (dbOldpassword == oldpassword)
                                {
                                    string newpassword = System32.EncryptDecrypt.Encrypt(txtBoxPassword.Text.ToString().Trim());
                                    objdbClass.UpdateUserPassword(StaticInfo.userid, newpassword);
                                    this.Cursor = Cursors.Default; xMessageBox.Show("Password Successfully Changed  ...!");
                                    this.Parent.Parent.Parent.Dispose();
                                }
                                else { this.Cursor = Cursors.Default; xMessageBox.Show("Old Password is incorrect...!"); txtBoxOld.Focus(); }
                            }
                        }
                        else { xMessageBox.Show("Enter Conform Password!"); txtBoxOld.Focus(); }
                    }
                    else { xMessageBox.Show("Enter new Password!"); txtBoxPassword.Focus(); }
                }
                else { xMessageBox.Show("Enter Old Password!"); txtBoxOld.Focus(); }
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); }
        }
        private void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtBoxPassword.Text.ToString().Trim())) { txtBoxConform.Focus(); }
                    else { xMessageBox.Show("Enter New Password!"); txtBoxOld.Focus(); }
                }
            }
            catch { }
        }
        private void btnok_Click(object sender, EventArgs e)
        { try { Validation(); } catch { } }
        private void txtBoxOld_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtBoxOld.Text.ToString().Trim())) { txtBoxPassword.Focus(); }
                    else { xMessageBox.Show("Enter Old Password!"); txtBoxOld.Focus(); }
                }
            }
            catch { }
        }
        private void txtBoxConform_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtBoxConform.Text.ToString().Trim()))
                    {
                        if (txtBoxPassword.Text.ToString().Trim() != txtBoxConform.Text.ToString().Trim())
                        {
                            xMessageBox.Show("Conform Password is not same!"); txtBoxConform.Focus();
                        }
                        else { try { Validation(); } catch { } }
                    }
                    else { xMessageBox.Show("Enter Conform Password!"); txtBoxConform.Focus(); }
                }
            }
            catch { }
        }
        private void ctrChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                dbOldpassword = objdbClass.getOldpassword(StaticInfo.userid);
            }
            catch { }
        }

    }
}
