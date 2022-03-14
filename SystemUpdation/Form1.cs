using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

////https://www.mssqltips.com/sqlservertip/1849/backup-and-restore-sql-server-databases-programmatically-with-smo/

namespace SystemUpdation
{
    public partial class Form1 : Form
    {
        //Thread threadProgress1;
        public static String Connectionstring = "Data Source=.\\sqlexpress;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=abc@123";
        public static string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        public static string DBName = "AutoVault";
        public static string DBBackupPath = "";
        public static string DBRestorePath = "";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");
            DBBackupPath = @"C:\" + DBName + "\\" + DBName + "(" + dateTime + ").bak";
            DBRestorePath = filepath + "\\" + DBName + ".bak";
            //----------------------------------------------
            //DBBackup();
        }
        public static async Task DBBackup()
        {
            await Task.Run(() => { MyAsyncMethod(); });
        }
        static void MyAsyncMethod()
        {
            if (CreateDirectory())
            {
                if (DataBaseBackup())
                {
                    if (DeleteDataBase())
                    {
                        //if (CreateDataBase())
                        //{
                        //    if (CreateDataBaseTables())
                        //    {
                        //        MessageBox.Show("Completed..");
                        //    }
                        //}
                        if (RestoreDataBase())
                        {
                            MessageBox.Show("Completed..");
                        }
                    }
                }
            }
        }
        static bool CreateDirectory()
        {
            bool IsExist = false;

            string subdir = @"C:\" + DBName;

            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            if (Directory.Exists(subdir))
                IsExist = true;

            return IsExist;
        }
        static bool DataBaseBackup()
        {
            bool IsBackupCompleted = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Connectionstring))
                {
                    cn.Open();
                    string cmd = "BACKUP DATABASE [" + DBName + "]" +
                                 "\nTO  DISK = N'" + DBBackupPath + "'" +
                                 "\nWITH NOFORMAT, NOINIT,  NAME = N'" + DBName + "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 100";


                    using (var command = new SqlCommand(cmd, cn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                
                IsBackupCompleted = true;
            }
            catch (Exception ex)
            {
                IsBackupCompleted = false;

                if (ex.InnerException.Message.Contains("Database '" + DBName + "' does not exist."))
                    IsBackupCompleted = true;
            }

            return IsBackupCompleted;
        }
        static bool CreateDataBase()
        {
            bool IsCreated = false;

            try
            {
                string scriptPath = filepath + "\\CreateDB" + DBName + ".sql";
                string script = File.ReadAllText(scriptPath);
                //using (SqlConnection conn = new SqlConnection(Connectionstring))
                //{
                //    Server server = new Server(new ServerConnection(conn));                    
                //    server.ConnectionContext.ExecuteNonQuery(script);                    
                //}

                // split script on GO command
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                using (SqlConnection conn = new SqlConnection(Connectionstring))
                {
                    conn.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, conn))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                IsCreated = true;
            }
            catch (Exception)
            {
                throw;
            }

            return IsCreated;
        }
        static bool CreateDataBaseTables()
        {
            bool IsCreated = false;

            try
            {
                string scriptPath = filepath + "\\CreateTables" + DBName + ".sql";
                string script = File.ReadAllText(scriptPath);
                //using (SqlConnection conn = new SqlConnection(Connectionstring))
                //{
                //    Server server = new Server(new ServerConnection(conn));
                //    server.ConnectionContext.ExecuteNonQuery(script);
                //}

                // split script on GO command
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                using (SqlConnection conn = new SqlConnection(Connectionstring))
                {
                    conn.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, conn))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                IsCreated = true;
            }
            catch (Exception)
            {
                throw;
            }

            return IsCreated;
        }
        static bool DeleteDataBase()
        {
            bool IsDeleteDataBase = false;

            try
            {
                SqlConnection con = new SqlConnection(Connectionstring);

                String sqlCommandText = "DROP DATABASE [" + DBName + "]";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlConnection.ClearPool(con);
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
                    sqlCommand.ExecuteNonQuery();
                }
                con.Close();
                con.Dispose();
                //-------------------------------------------
                IsDeleteDataBase = true;
            }
            catch (Exception ex)
            {
                IsDeleteDataBase = false;

                if (ex.Message.Contains("Cannot drop the database '" + DBName + "', because it does not exist or you do not have permission."))
                    IsDeleteDataBase = true;
            }

            return IsDeleteDataBase;
        }
        static bool RestoreDataBase()
        {
            bool IsRestoreDB = false;

            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                con.Open();
                try
                {
                    string sql = "USE MASTER RESTORE DATABASE [" + DBName + "] FROM DISK='" + DBRestorePath + "' WITH REPLACE";
                    using (var command = new SqlCommand(sql, con))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "ALTER DATABASE [" + DBName + "] SET MULTI_USER";
                    using (var command = new SqlCommand(sql, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    IsRestoreDB = true;
                }
                catch (Exception)
                {
                    IsRestoreDB = false;
                    throw;                    
                }
            }
            return IsRestoreDB;
        }


        //static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        //{
        //    lblProcess1.Text = "Progress1 : - " + args.Percent + " %";
        //    progressBar1.Value = args.Percent;
        //}
        //static void Backup_Completed(object sender, ServerMessageEventArgs args)
        //{
        //    lblProcess11.Visible = true;
        //}
        //static bool IsDBFileExist()
        //{
        //    bool IsDBFileExist = false;            
        //    filepath += "\\AutoVault.bak";
        //    if (File.Exists(filepath))
        //    {
        //        IsDBFileExist = true;
        //    }
        //    return IsDBFileExist;
        //}

        //static bool IsDatabaseRestore()
        //{
        //    bool IsDatabaseRestore = false;

        //    try
        //    {
        //        //--------------------------------------------------------------

        //        //--------------------------------------------------------------
        //        //filepath += "\\AutoVault.bak";
        //        //string database = "AutoVault";
        //        //try
        //        //{
        //        //    using (SqlConnection con = new SqlConnection(Connectionstring))
        //        //    {
        //        //        con.Open();
        //        //        //string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

        //        //        //using (SqlCommand bu2 = new SqlCommand(sqlStmt2, con))
        //        //        //{
        //        //        //    bu2.ExecuteNonQuery();
        //        //        //}

        //        //        string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + filepath + "'WITH REPLACE;";

        //        //        using (SqlCommand bu3 = new SqlCommand(sqlStmt3, con))
        //        //        {
        //        //            bu3.ExecuteNonQuery();
        //        //        }

        //        //        string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");

        //        //        using (SqlCommand bu4 = new SqlCommand(sqlStmt4, con))
        //        //        {
        //        //            bu4.ExecuteNonQuery();
        //        //        }
        //        //        con.Close();

        //        //    }
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    MessageBox.Show(ex.ToString());
        //        //}

        //        //using (SqlConnection cn = new SqlConnection(Connectionstring))
        //        //{
        //        //    cn.Open();
        //        //    string cmd = "BACKUP DATABASE [Stats] TO DISK='" + fname + "'";
        //        //    using (var command = new SqlCommand(cmd, cn))
        //        //    {
        //        //        command.ExecuteNonQuery();
        //        //    }
        //        //}
        //        //--------------------------------------------------------------

        //        //---------------------------------------------------------------
        //        //string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        //        //filepath += "\\AutoVault.bak";
        //        ////-------------------------------------------------------------
        //        //Server Myserver = new Server(".\\SQLEXPRESS");
        //        //Myserver.ConnectionContext.LoginSecure = false;
        //        //Myserver.ConnectionContext.Login = "sa";
        //        //Myserver.ConnectionContext.Password = "abc@123";
        //        //Myserver.ConnectionContext.Connect();

        //        //Restore restoreDB = new Restore();
        //        //restoreDB.Database = "AutoVault";

        //        //restoreDB.Action = RestoreActionType.Database;
        //        //restoreDB.Devices.AddDevice(filepath, DeviceType.File);

        //        //restoreDB.ReplaceDatabase = true;
        //        //restoreDB.NoRecovery = true;

        //        //restoreDB.PercentComplete += RestoreCompletionStatusInPercent;
        //        //restoreDB.Complete += Restore_Completed;
        //        //restoreDB.SqlRestore(Myserver);
        //        //-------------------------------------------------------------
        //        IsDatabaseRestore = true;                
        //        lblProcess12.Visible = true;
        //        MessageBox.Show("Database Restoration Done Successefully ...");
        //    }
        //    catch (Exception)
        //    {
        //        IsDatabaseRestore = false;
        //    }

        //    return IsDatabaseRestore;
        //}
        //static void RestoreCompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        //{
        //    lblProcess2.Text = "Progress2 : - " + args.Percent + " %";
        //    progressBar2.Value = args.Percent;
        //}
        //static void Restore_Completed(object sender, ServerMessageEventArgs args)
        //{
        //    lblProcess12.Visible = true;
        //}

        //threadProgress1 = new Thread(Progress1);
        //threadProgress1.Start();

        //timer1.Enabled = true;
        //timer1.Start();
        //timer1.Interval = 50;
        //progressBar1.Maximum = 100;
        //timer1.Tick += new EventHandler(timer1_Tick);
        //Progress1();
        //}

        //void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (progressBar1.Value != 100)
        //    {
        //        progressBar1.Value++;
        //        lblProcess1.Text = "Progress1 : - " + progressBar1.Value.ToString() + " %";
        //    }
        //    else
        //    {
        //        timer1.Stop();
        //        lblProcess11.Visible = true;
        //        //------------------------------------------
        //        timer2.Enabled = true;
        //        timer2.Start();
        //        timer2.Interval = 50;
        //        progressBar2.Maximum = 100;
        //        timer2.Tick += new EventHandler(timer2_Tick);
        //        //----------------------------------------
        //    }
        //}
        //void timer2_Tick(object sender, EventArgs e)
        //{
        //    if (progressBar2.Value != 100)
        //    {
        //        progressBar2.Value++;
        //        lblProcess2.Text = "Progress2 : - " + progressBar2.Value.ToString() + " %";
        //    }
        //    else
        //    {
        //        timer2.Stop();
        //        lblProcess12.Visible = true;
        //        //----------------------------------------
        //        timer3.Enabled = true;
        //        timer3.Start();
        //        timer3.Interval = 50;
        //        progressBar3.Maximum = 100;
        //        timer3.Tick += new EventHandler(timer3_Tick);
        //        //----------------------------------------
        //    }
        //}
        //void timer3_Tick(object sender, EventArgs e)
        //{
        //    if (progressBar3.Value != 100)
        //    {
        //        progressBar3.Value++;
        //        lblProcess3.Text = "Progress3 : - " + progressBar3.Value.ToString() + " %";
        //    }
        //    else
        //    {
        //        timer3.Stop();
        //        lblProcess13.Visible = true;
        //        //----------------------------------------
        //        timer4.Enabled = true;
        //        timer4.Start();
        //        timer4.Interval = 50;
        //        progressBar4.Maximum = 100;
        //        timer4.Tick += new EventHandler(timer4_Tick);
        //        //----------------------------------------
        //    }
        //}
        //void timer4_Tick(object sender, EventArgs e)
        //{
        //    if (progressBar4.Value != 100)
        //    {
        //        progressBar4.Value++;
        //        lblProcess4.Text = "Progress4 : - " + progressBar4.Value.ToString() + " %";
        //    }
        //    else
        //    {
        //        timer4.Stop();
        //        lblProcess14.Visible = true;
        //    }
        //}


        //void Progress1()
        //{
        //    int lines = 100;

        //    //set the max value for the progress bar
        //    if (progressBar1.InvokeRequired)
        //    {
        //        Invoke(new MethodInvoker(

        //            delegate
        //            {
        //                progressBar1.Maximum = lines;

        //            }));
        //    }
        //    else
        //    {
        //        progressBar1.Maximum = lines;
        //    }


        //    //read lines and add them in the TextBox
        //    for (int line = 0; line < lines; line++)
        //    {
        //        //thread-safe call: append line in TextBox
        //        if (txtRetrievedData.InvokeRequired)
        //        {
        //            Invoke(new MethodInvoker(

        //                delegate
        //                {
        //                    txtRetrievedData.AppendText(Convert.ToString(line));
        //                }));
        //        }
        //        else
        //        {
        //            txtRetrievedData.AppendText(Convert.ToString(line));
        //        }


        //        //thread-safe call: update progress bar
        //        if (progressBar1.InvokeRequired)
        //        {
        //            Invoke(new MethodInvoker(

        //                delegate
        //                {
        //                    progressBar1.Invoke(new updateprogressBar1(this.UpdateBarProgress));

        //                }));
        //        }
        //        else
        //        {
        //            progressBar1.Invoke(new updateprogressBar1(this.UpdateBarProgress));

        //        }
        //    }
        //}
        //public delegate void updateprogressBar1();
        //private void UpdateBarProgress()
        //{
        //    if (progressBar1.Value < progressBar1.Maximum)
        //    {
        //        progressBar1.Value += 1;

        //        //thread-safe call: update lblStatus value
        //        if (lblProcess1.InvokeRequired)
        //        {
        //            Invoke(new MethodInvoker(

        //                delegate
        //                {
        //                    //lblStatus.Text = (((float)progressBar1.Value / (float)progressBar1.Maximum) * 100).ToString("0") + " %";
        //                    lblProcess1.Text = "Progress1 : - " + progressBar1.Value.ToString() + " %";
        //                }));
        //        }
        //        else
        //        {
        //            //lblStatus.Text = (((float)progressBar1.Value / (float)progressBar1.Maximum) * 100).ToString("0") + " %";
        //            lblProcess1.Text = "Progress1 : - " + progressBar1.Value.ToString() + " %";
        //        }
        //    }
        //}
        //Server Myserver = new Server(".\\SQLEXPRESS");
        //Myserver.ConnectionContext.LoginSecure = false;
        //Myserver.ConnectionContext.Login = "sa";
        //Myserver.ConnectionContext.Password = "abc@123";
        //Myserver.ConnectionContext.Connect();

        //Backup bkpDBFull = new Backup();
        //bkpDBFull.Action = BackupActionType.Database;
        //bkpDBFull.Database = "AutoVault";
        //bkpDBFull.Devices.AddDevice(@"C:\AutoVault\AutoVault.bak", DeviceType.File);
        //bkpDBFull.BackupSetName = "AutoVault database Backup";
        //bkpDBFull.BackupSetDescription = "AutoVault database - Full Backup";

        //bkpDBFull.Initialize = false;
        //bkpDBFull.PercentComplete += CompletionStatusInPercent;
        //bkpDBFull.Complete += Backup_Completed;
        //bkpDBFull.SqlBackup(Myserver);
        //-----------------------------------------------------------------
    }
}
