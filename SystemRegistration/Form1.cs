using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;
using ControlLibrary;
using DBModule;
using System32;


namespace SystemRegistration
{
    public partial class Form1 : Form
    {
        ControlLibrary.MessageBox xMessageBox = null;
        MainDataSet objDataSet = null;
        
        public Form1()
        {
            InitializeComponent();

            this.txtBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPassword_KeyDown);
            this.Load += new System.EventHandler(this.Form1_Load);

            xMessageBox = new ControlLibrary.MessageBox();
            objDataSet = new MainDataSet();
        }

        private void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxPassword.Text.Trim()))
                    SystemRegistration(txtBoxPassword.Text.Trim());
            }
        }
        private void SystemRegistration(string password)
        {
            try
            {
                if (password.Equals("EssLahore"))
                {
                    System32.SystemRegistration.systemRegistration();

                    if (this.updateNode())
                        xMessageBox.Show("Your System is Registered !");
                    else
                        xMessageBox.Show("Registration process is not completed !");


                    System.Environment.Exit(0);
                }
                else
                {
                    xMessageBox.Show("You do not have Access !");
                    System.Environment.Exit(0);
                }
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtBoxPassword.Focus();
        }

        private bool updateNode()
        {
            try
            {
                if (dbClass.obj.isPOSExist())
                    dbClass.obj.UpdateRegistration();
                else
                    dbClass.obj.SystemRegistration();

                return true;
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); return false; }
        }
    }
}
