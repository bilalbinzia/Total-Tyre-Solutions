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
    public partial class ctrDBBackUp : UserControl
    {
        ControlLibrary.MessageBox xMessageBox = null;
        //string conString = string.Empty;
        string path = string.Empty;
        //string activity = string.Empty;
        //string DBName = string.Empty;
        dbClass objdbClass;
        public ctrDBBackUp()
        {
            InitializeComponent();
            objdbClass = new dbClass();
            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += ctrDBBackUp_Load;

            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

        }

        void ctrDBBackUp_Load(object sender, EventArgs e)
        {
            this.Text = "BackUp DataBase";
            this.toolTip1.SetToolTip(this.btnSelectDB, "Select Drive for BackUp");
        }

        private void btnSelectDB_Click(object sender, EventArgs e)
        {
            try
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string d1 = DateTime.Now.ToString();
                        d1 = d1.Replace("/", ""); d1 = d1.Substring(0, 8);

                        string path = folderDialog.SelectedPath;
                        this.txtDBName.Text = path + "\\" + objdbClass.dbName + "(" + d1 + ").bak";
                    }
                }

                this.txtDBName.Enabled = true;
                this.btnOK.Enabled = true;
            }
            catch (Exception ex) { xMessageBox.Show(ex.Message.ToString()); }
            finally { this.Cursor = Cursors.Arrow; }
        }

        public void DoWork(IProgress<int> progress)
        {
            for (int j = 0; j <= 1000000; j++)
            {
                if (progress != null)
                    progress.Report((j + 1) * 100 / 1000000);
            }
            Cursor.Current = Cursors.Default;
        }
        private async void btnOK_Click(object sender, EventArgs e)
        {            
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            var progress = new Progress<int>(v =>
            {             
                progressBar1.Value = v;
            });
            
            await Task.Run(() => DoWork(progress));

            objdbClass.BackUp(objdbClass.dbName, this.txtDBName.Text.Trim());

            Cursor.Current = Cursors.Default;
            this.Parent.Parent.Parent.Dispose();
        }
    }
}
