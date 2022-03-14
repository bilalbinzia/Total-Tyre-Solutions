using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System32;
using System.Windows;
using System.Windows.Forms;

namespace DBModule
{
    public sealed class dbClass
    {
        public string connectionString = "";
        public string dbName = "";
        public dbClass()
        {
            try
            {
                Helper csHelper = new Helper();
                this.connectionString = csHelper.GetConnectionString();
                IDbConnection connection = new SqlConnection(this.connectionString);
                this.dbName = connection.Database;
            }
            catch { }
        }
        private static dbClass Obj = null;
        public static dbClass obj
        {
            get
            {
                if (Obj == null)
                {
                    Obj = new dbClass();
                }
                return Obj;
            }
        }


        //-------Basic-------------------------------//
        public DataSet Delete(DataSet dataSet, string MtblName, List<childTable> childs)
        {
            foreach (childTable CtblName in childs)
            {
                if (dataSet.Tables[CtblName.tblName].GetChanges() != null)
                    this.Update(dataSet.Tables[CtblName.tblName]);
            }
            if (dataSet.Tables[MtblName].GetChanges() != null)
                this.Update(dataSet.Tables[MtblName]);

            return dataSet;

            //foreach (DataTable dataTable in dataSet.Tables)
            //{
            //    if (dataTable.GetChanges() != null)
            //    {
            //        string errorMessage = "";
            //        foreach (DataRow xDataRow in dataTable.Rows)
            //        {
            //            if (xDataRow.RowState == DataRowState.Modified || xDataRow.RowState == DataRowState.Added || xDataRow.RowState == DataRowState.Deleted)
            //            {
            //                foreach (DataColumn xDataColumn in dataTable.Columns)
            //                {
            //                    string xError = xDataRow.GetColumnError(xDataColumn);
            //                    if (xError.Length > 0)
            //                    {
            //                        errorMessage += xError;
            //                        errorMessage += Environment.NewLine;
            //                    }
            //                }
            //            }
            //            if (errorMessage.Length > 0)
            //                throw new Exception(errorMessage);
            //        }
            //        this.Update(dataTable);
            //    }
            //}
            //return dataSet;
        }
        public DataTable Update(DataTable dataTable)
        {

            string errorMessage = "";
            foreach (DataRow xDataRow in dataTable.Rows)
            {
                if (xDataRow.RowState == DataRowState.Modified || xDataRow.RowState == DataRowState.Added || xDataRow.RowState == DataRowState.Deleted)
                {
                    foreach (DataColumn xDataColumn in dataTable.Columns)
                    {
                        string xError = xDataRow.GetColumnError(xDataColumn);
                        if (xError.Length > 0)
                        {
                            errorMessage += xError;
                            errorMessage += Environment.NewLine;
                        }
                    }
                }
                if (errorMessage.Length > 0)
                    throw new Exception(errorMessage);
            }

            this.UpdateTable(dataTable);
            return dataTable;
        }
        public DataTable UpdateTable(DataTable dataTable)
        {
            //---------------------------------------
            try
            {
                string connetionString = this.connectionString;
                SqlConnection SqlCnn = new SqlConnection(connetionString);
                SqlDataAdapter sDA;
                SqlCnn.Open();
                if (dataTable.Rows.Count > 0 && dataTable.TableName == "CustomerReceipt")
                {
                    if (dataTable.Rows[0]["InvoiceNo"] == null || dataTable.Rows[0]["InvoiceNo"].ToString() == "")
                    {
                        dataTable.Rows[0]["InvoiceNo"] = "";
                    }
                }
                sDA = new SqlDataAdapter("SELECT * FROM [dbo].[" + dataTable.TableName + "]", SqlCnn);
                try
                {
                    using (SqlCommandBuilder sqlCB = new SqlCommandBuilder(sDA))
                    {
                        sqlCB.QuotePrefix = "[";
                        sqlCB.QuoteSuffix = "]";
                        sDA.TableMappings.Add("Table", dataTable.TableName);
                        sqlCB.ConflictOption = ConflictOption.OverwriteChanges;
                        try
                        {
                            sDA.UpdateCommand = sqlCB.GetUpdateCommand();
                            sDA.InsertCommand = sqlCB.GetInsertCommand();
                            sDA.DeleteCommand = sqlCB.GetDeleteCommand();
                            sDA.InsertCommand.CommandText = String.Concat(sDA.InsertCommand.CommandText,
                            "; SELECT * FROM [dbo].[", dataTable.TableName,
                            "] WHERE ", "ID", "=SCOPE_IDENTITY()");
                            SqlParameter identParam = new SqlParameter("@Identity", SqlDbType.BigInt, 0, "ID");
                            identParam.Direction = ParameterDirection.Output;
                            sDA.InsertCommand.Parameters.Add(identParam);
                            sDA.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
                            SqlDataAdapter daAutoNum = new SqlDataAdapter();
                            daAutoNum.DeleteCommand = sDA.DeleteCommand;
                            daAutoNum.InsertCommand = sDA.InsertCommand;
                            daAutoNum.UpdateCommand = sDA.UpdateCommand;
                            daAutoNum.Update(dataTable);
                            dataTable.AcceptChanges();
                        }
                        catch (Exception ex)
                        {
                            dataTable.RejectChanges();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dataTable.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sDA.Dispose();
                    SqlCnn.Close();
                }
            }
            catch (Exception ex)
            {
                dataTable.RejectChanges();
                MessageBox.Show(ex.Message);
            }
            //---------------------------------------
            return dataTable;
        }

        public DataTable CheckNewOrders(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] where IsVisible=false";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable Fill(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        private DataTable ExecuteSqlReaderLoadStep(DataTable dataTable, string query)
        {
            dataTable.Clear();
            using (var con = new SqlConnection(this.connectionString))
            {
                con.Open();
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }
        //-------DataBase Backup and Restore------------------//
        public void BackUp(string DBName, string backUpPath)
        {
            try
            {
                if (backUpPath.Equals(""))
                {
                    MessageBox.Show("Please choose Drive Path", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (SqlConnection sqlcon = new SqlConnection(this.connectionString))
                {
                    if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    string UseMaster = "USE master";
                    SqlCommand UseMasterCommand = new SqlCommand(UseMaster, sqlcon);
                    UseMasterCommand.ExecuteNonQuery();
                    string BackUp = @"BACKUP DATABASE [" + DBName + "] To DISK = N'" + backUpPath + "'";
                    SqlCommand BackUpCmd = new SqlCommand(BackUp, sqlcon);
                    BackUpCmd.ExecuteNonQuery();
                }
                MessageBox.Show("Backup of Database " + DBName + " successfully created", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception x)
            {
                MessageBox.Show("ERROR: An error ocurred while backing up DataBase" + x, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
        //-------System Setting-----------------------------// 
        public bool SystemRegistration()
        {
            try
            {
                string sQry = "INSERT INTO [dbo].[POSDetail]" +
                              " ([Com_port] ,[Com_port1] ,[Com_port2] ,[Active] ,[AddDate])" +
                              " VALUES" +
                              " ('" + System32.SystemRegistration.cryptString + "'" +
                              " ,'" + System32.SystemRegistration.ExpiryDate + "'" +
                              " ,'" + System32.SystemRegistration.currentDate + "'" +
                              " ,1" +
                              " ,'" + System32.SystemRegistration.AddDate + "')";

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(sQry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                return true;
            }
            catch { return false; }
        }
        public bool UpdateRegistration()
        {
            try
            {
                string sQry = "UPDATE [dbo].[POSDetail]" +
                                        " SET [Com_port1] = '" + System32.SystemRegistration.ExpiryDate + "'" +
                                        " ,[Com_port2] = '" + System32.SystemRegistration.currentDate + "'" +
                                        " ,[ModifyDate] = getdate()" +
                                        " WHERE [Com_port] = '" + System32.SystemRegistration.cryptString + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(sQry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                return true;
            }
            catch { return false; }
        }
        public DateTime GetExpiryDate()
        {
            DateTime ExpiryDate = Convert.ToDateTime("2022-10-10");
            try
            {
                string qry = "SELECT [Com_port1] FROM [dbo].[POSDetail] WHERE [Com_port] = '" + System32.SystemRegistration.cryptString + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                    {
                        ExpiryDate = Convert.ToDateTime(System32.EncryptDecrypt.Decrypt(Convert.ToString(xResult)));
                    }
                }
            }
            catch { ExpiryDate = Convert.ToDateTime("2022-10-10"); }
            return ExpiryDate;
        }
        public void UpdatePOSExpiryDate(string updateDate)
        {
            try
            {
                string qry = "UPDATE [dbo].[POSDetail] SET [Com_port1] = '" + updateDate + "' WHERE [Com_port] = '" + System32.SystemRegistration.cryptString + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public bool isPOSExist()
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT count(*) FROM [dbo].[POSDetail] WHERE [Com_port] = '" + System32.SystemRegistration.cryptString + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }
        public int getPOSID()
        {
            int ID = 0;
            try
            {
                string qry = "SELECT TOP(1)ID FROM [dbo].[POSDetail] WHERE [Com_port] = '" + System32.SystemRegistration.cryptString + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        ID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ID;
        }
        public bool IsMachineRegistered(string EncryptString)
        {
            try
            {
                string qry = string.Format("SELECT * FROM [dbo].[POSDetail] WHERE [Com_port] = '" + EncryptString + "'");
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != null)
                        return true;
                    else
                        return false;
                }
            }
            catch { return false; }
        }
        public DataTable getUserLoginDetail(DataTable dataTable, int ID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [UserLoginID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable GetAdmins()
        {
            DataTable dt = new DataTable();
            string Qry = "Select ID,Name from Employee where Name like '%Admin%'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);
            return dt;
        }

        public void AddUserLogin(DataTable dt)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[UserLogin]" +
                        " ([UserLoginID],[UserGroupID],[LoginName],[Password],[LoginStartDate],[LoginEndDate],[LoginStartTime],[LoginEndTime],[Active],[AddDate],[AddUserID],[IsLocked])" +
                        " Values (@UserLoginID,@UserGroupID,@LoginName,@Password,@LoginStartDate,@LoginEndDate,@LoginStartTime,@LoginEndTime,@Active,GETDATE(),@AddUserID,1)", SqlCnn);

                command.Parameters.Add("@UserLoginID", SqlDbType.Int);
                command.Parameters["@UserLoginID"].Value = Convert.ToInt32(dt.Rows[0]["UserLoginID"]);

                command.Parameters.Add("@UserGroupID", SqlDbType.Int);
                command.Parameters["@UserGroupID"].Value = Convert.ToInt32(dt.Rows[0]["UserGroupID"]);

                //--------------------------------------------------------
                command.Parameters.Add("@LoginName", SqlDbType.VarChar);
                command.Parameters["@LoginName"].Value = Convert.ToString(dt.Rows[0]["LoginName"]);

                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = Convert.ToString(dt.Rows[0]["Password"]);
                //--------------------------------------------------------
                command.Parameters.Add("@LoginStartDate", SqlDbType.VarChar);
                command.Parameters["@LoginStartDate"].Value = Convert.ToString(dt.Rows[0]["LoginStartDate"]);

                command.Parameters.Add("@LoginEndDate", SqlDbType.VarChar);
                command.Parameters["@LoginEndDate"].Value = Convert.ToString(dt.Rows[0]["LoginEndDate"]);
                //--------------------------------------------------------
                command.Parameters.Add("@LoginStartTime", SqlDbType.VarChar);
                command.Parameters["@LoginStartTime"].Value = Convert.ToString(dt.Rows[0]["LoginStartTime"]);

                command.Parameters.Add("@LoginEndTime", SqlDbType.VarChar);
                command.Parameters["@LoginEndTime"].Value = Convert.ToString(dt.Rows[0]["LoginEndTime"]);
                //--------------------------------------------------------
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = Convert.ToBoolean(dt.Rows[0]["Active"]);

                command.Parameters.Add("@AddUserID", SqlDbType.Int);
                command.Parameters["@AddUserID"].Value = Convert.ToInt32(dt.Rows[0]["AddUserID"]);

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public void UpdateUserLogin(DataTable dt)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[UserLogin]" +
                        " SET " +
                        " [UserGroupID] = @UserGroupID" +
                        " ,[LoginName] = @LoginName" +
                        " ,[Password] = @Password" +

                        " ,[LoginStartTime] = @LoginStartTime" +
                        " ,[LoginEndTime] = @LoginEndTime" +
                        " ,[Active] = @Active" +

                        " ,[ModifyUserID] = @ModifyUserID" +
                        " ,[ModifyDate] = GETDATE()" +

                        " WHERE [UserLoginID] = @UserLoginID", SqlCnn);

                command.Parameters.Add("@UserLoginID", SqlDbType.Int);
                command.Parameters["@UserLoginID"].Value = Convert.ToInt32(dt.Rows[0]["UserLoginID"]);

                command.Parameters.Add("@UserGroupID", SqlDbType.Int);
                command.Parameters["@UserGroupID"].Value = Convert.ToInt32(dt.Rows[0]["UserGroupID"]);

                //--------------------------------------------------------
                command.Parameters.Add("@LoginName", SqlDbType.VarChar);
                command.Parameters["@LoginName"].Value = Convert.ToString(dt.Rows[0]["LoginName"]);

                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = Convert.ToString(dt.Rows[0]["Password"]);
                //--------------------------------------------------------                
                command.Parameters.Add("@LoginStartTime", SqlDbType.VarChar);
                command.Parameters["@LoginStartTime"].Value = Convert.ToString(dt.Rows[0]["LoginStartTime"]);

                command.Parameters.Add("@LoginEndTime", SqlDbType.VarChar);
                command.Parameters["@LoginEndTime"].Value = Convert.ToString(dt.Rows[0]["LoginEndTime"]);
                //--------------------------------------------------------
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = Convert.ToBoolean(dt.Rows[0]["Active"]);

                command.Parameters.Add("@ModifyUserID", SqlDbType.Int);
                command.Parameters["@ModifyUserID"].Value = Convert.ToInt32(dt.Rows[0]["ModifyUserID"]);

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public void UpdateUserPassword(int UserID, string password)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[UserLogin]" +
                        " SET [Password] = @Password" +
                        " ,[ModifyDate] = GETDATE()" +

                        " WHERE [UserLoginID] = @UserLoginID", SqlCnn);

                command.Parameters.Add("@UserLoginID", SqlDbType.Int);
                command.Parameters["@UserLoginID"].Value = UserID;
                //-----------------------------------------------------------------------------//
                command.Parameters.Add("@Password", SqlDbType.VarChar);
                command.Parameters["@Password"].Value = password;
                //-----------------------------------------------------------------------------//

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public string getOldpassword(int UserID)
        {
            string EmpPass = string.Empty;
            try
            {
                string qry = string.Format("SELECT [Password] FROM [dbo].[UserLogin] WHERE [UserLoginID] = {0}", UserID);

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        EmpPass = Convert.ToString(xResult);
                }
            }
            catch { EmpPass = string.Empty; }
            return EmpPass;
        }
        public DataTable getTodayPOSActivities(DateTime dateFROM, DateTime dateto)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT TOP(1)" +
                         " (SELECT ISNULL(SUM([TotalAmount]),0) FROM [dbo].[POSGRN] WHERE GRNDate >= '" + Convert.ToString(dateFROM.Date.Year + "-" + dateFROM.Date.Month + "-" + dateFROM.Date.Day) + "' AND GRNDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') as Purchase" +
                         " ,(SELECT ISNULL(SUM([TotalAmount]),0) FROM [dbo].[POSPR] WHERE PRDate >= '" + Convert.ToString(dateFROM.Date.Year + "-" + dateFROM.Date.Month + "-" + dateFROM.Date.Day) + "' AND PRDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') as PurchaseReturn" +
                         " ,(SELECT ISNULL(SUM([TotalAmount]),0) FROM [dbo].[POSSale] WHERE SaleDate >= '" + Convert.ToString(dateFROM.Date.Year + "-" + dateFROM.Date.Month + "-" + dateFROM.Date.Day) + "' AND SaleDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') as Sale" +
                         " ,(SELECT ISNULL(SUM([TotalAmount]),0) FROM [dbo].[POSSR] WHERE SRDate >= '" + Convert.ToString(dateFROM.Date.Year + "-" + dateFROM.Date.Month + "-" + dateFROM.Date.Day) + "' AND SRDate <= '" + Convert.ToString(dateto.Date.Year + "-" + dateto.Date.Month + "-" + dateto.Date.Day) + "') as SaleReturn" +
                         " ,(SELECT ISNULL(SUM([TrnsCr]),0) - ISNULL(SUM([TrnsDr]),0) FROM dbo.AccTransaction WHERE TrnsAccID = '2101001') as Payable" +
                         " ,(SELECT ISNULL(SUM([TrnsDr]),0) - ISNULL(SUM([TrnsCr]),0) FROM dbo.AccTransaction WHERE TrnsAccID = '1105000') as Receivables" +
                         " ,(SELECT ISNULL(SUM([TrnsDr]),0) - ISNULL(SUM([TrnsCr]),0) FROM dbo.AccTransaction WHERE TrnsAccID = '1101010') as CashInHand" +
                         " FROM [dbo].[AccTransaction]";
            //" FROM [dbo].[AccTransaction] WHERE SaleDate >= '" + Convert.ToString(DateTime.Now.Date.Year + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day) + "' AND SaleDate <= '" + Convert.ToString(DateTime.Now.Date.Year + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day) + "'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        //-------General-------------------------------//
        public DataTable FillByQry(DataTable dataTable, string Qry)
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
                sDA.Fill(dataTable);
                return dataTable;
            }
            else
                return dataTable;
        }

        public DataTable FillByQryByID(DataTable dataTable, string Qry, int ID)
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                string qry = Qry + " WHERE [MID] = " + ID;
                SqlDataAdapter sDA = new SqlDataAdapter(qry, this.connectionString);
                sDA.Fill(dataTable);
                return dataTable;
            }
            else
                return dataTable;
        }

        public DataTable FillByQryByIDOrderBy(DataTable dataTable, string Qry, int ID, string OrderBy)
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                string qry = Qry + " WHERE [MID] = " + ID + " Order by [" + OrderBy + "]";
                SqlDataAdapter sDA = new SqlDataAdapter(qry, this.connectionString);
                sDA.Fill(dataTable);
                return dataTable;
            }
            else
                return dataTable;
        }

        public DataTable Fill(DataTable dataTable, string spName)
        {
            dataTable.Clear();
            using (var con = new SqlConnection(this.connectionString))
            using (var cmd = new SqlCommand(spName, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dataTable);
            }
            return dataTable;
        }

        public DataTable FillPrameterTable(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT *" +
                         " FROM [dbo].[" + dataTable.TableName + "]" +
                         " WHERE [Active] = 1" +
                         " Order by [Name]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillAll(DataTable dataTable, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "]";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByActive(DataTable dataTable, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByID(DataTable dataTable, int id)
        {
            dataTable.Clear();
            string Qry = "";
            if (dataTable.ToString() == "SaleTaxRates")
            {
                Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] Order by [ID] DESC";
            }
            else
            {
                Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [ID] = " + id;
            }


            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataRow FillDataRowByID(DataTable dataTable, int id)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [ID] = " + id;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public DataTable FillByMID(DataTable dataTable, int MID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [MID] = " + MID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByQryByActive(DataTable dataTable, string fields, string OrderBy = "")
        {
            dataTable.Clear();

            string Qry = "SELECT ID, " + fields + ",Active,AddDate,AddUserID,IsLocked FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (dataTable.TableName.Contains("Account"))
                Qry = "SELECT " + fields + " FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1 And [AccLevel] = 3";
            if (string.IsNullOrEmpty(fields))
                Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillDGVComboBoxColumnByActive(DataTable dataTable, string fields, string OrderBy = "")
        {
            dataTable.Clear();

            string Qry = "SELECT ID," + fields + " FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (dataTable.TableName.Contains("Account"))
                Qry = "SELECT " + fields + " FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1 And [AccLevel] = 3";
            if (string.IsNullOrEmpty(fields))
                Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillAll(DataTable dataTable, string SELECTFields, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT " + SELECTFields + " FROM [dbo].[" + dataTable.TableName + "]";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByActive(DataTable dataTable, string SELECTFields, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT " + SELECTFields + " FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillAll(DataTable dataTable, string OrderBy = "", bool DescOrder = false)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "]";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            if (DescOrder) Qry += " Desc";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByActive(DataTable dataTable, string OrderBy = "", bool DescOrder = false)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            if (DescOrder) Qry += " Desc";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByActive(string TableName, string OrderBy = "")
        {
            DataTable dt = new DataTable();
            string Qry = "SELECT * FROM [dbo].[" + TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);
            return dt;
        }

        public DataTable FillByActive(DataTable dataTable, string FieldName, int FieldID, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[" + dataTable.TableName + "] WHERE " + FieldName + "= " + FieldID + " AND [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillTOP1(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Order by [ID]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillTOP0(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(0) * FROM [dbo].[" + dataTable.TableName + "] Order by [ID]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillCitiesByStateID(DataTable dataTable, int stateID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[City] WHERE StateID = " + stateID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillComboByFieldID(DataTable dataTable, string FillByField, int fieldID, string OrderBy)
        {
            dataTable.Clear();
            string Qry = string.Empty;
            if (!string.IsNullOrEmpty(FillByField) && fieldID > 0)
            {
                Qry = "SELECT * FROM [dbo].[" + dataTable + "] WHERE " + FillByField + " = " + fieldID + " AND Active = 1";
            }
            else if (!string.IsNullOrEmpty(OrderBy))
            {
                Qry = "SELECT * FROM [dbo].[" + dataTable + "] WHERE Active = 1 order by " + OrderBy;
            }
            else
            {
                Qry = "SELECT * FROM [dbo].[" + dataTable + "] WHERE Active = 1";
            }
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillComboByIsShowDefault(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = string.Empty;
            Qry = "SELECT * FROM [dbo].[" + dataTable + "] WHERE [Active] = 1 and [IsDefault] = 1";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillChild(DataTable dataTable, string Qry = "")
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                if (!string.IsNullOrEmpty(Qry))
                    dataTable = FillChildByQuery(dataTable, Qry);
                else
                    dataTable = FillAll(dataTable, "");
            }
            return dataTable;
        }

        public DataTable FillChildTOP1(DataTable dataTable, string Qry = "")
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                dataTable = FillChildByQueryTOP1(dataTable, Qry);
            }
            return dataTable;
        }

        public DataTable FillChildByQuery(DataTable dataTable, string Qry)
        {
            try
            {
                dataTable.Clear();
                SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
                sDA.Fill(dataTable);
                //----------------------------
                return dataTable;
            }
            catch { return null; }
        }

        public DataTable FillChildByQueryTOP1(DataTable dataTable, string Qry)
        {
            dataTable.Clear();
            Qry = "SELECT TOP(1) * FROM (" + Qry + ") tbl1 order by MID ";
            try
            {
                SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
                sDA.Fill(dataTable);
            }
            catch { }
            //----------------------------
            return dataTable;
        }

        public bool SaveThemeColor(int ID, int backColor, int foreColor)
        {
            bool IsSave = false;

            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[WarehouseSettings] SET [BackColor] = @backColor, [ForeColor] = @foreColor WHERE ID = @ID", SqlCnn);
                Cmd.Parameters.Add("@backColor", SqlDbType.Int);
                Cmd.Parameters["@backColor"].Value = backColor;

                Cmd.Parameters.Add("@foreColor", SqlDbType.Int);
                Cmd.Parameters["@foreColor"].Value = foreColor;

                Cmd.Parameters.Add("@ID", SqlDbType.Int);
                Cmd.Parameters["@ID"].Value = ID;
                Cmd.ExecuteNonQuery();

                IsSave = true;
            }
            catch { IsSave = false; }
            finally
            {
                SqlCnn.Close();
            }
            return IsSave;
        }

        public bool isChildExist(int AccID)
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT TOP 1 [AccID]" +
                             " FROM [dbo].[Account]" +
                             " WHERE [AccTypeID] = " + AccID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult == null)
                        IsExist = false;
                    else if (xResult != DBNull.Value)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }

        public string GetCreatedBy(int UserID)
        {
            string EmpName = string.Empty;
            try
            {
                string qry = string.Format("SELECT [Name] FROM [Employee] WHERE [ID] = {0}", UserID);

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        EmpName = Convert.ToString(xResult);
                }
            }
            catch { EmpName = string.Empty; }
            return EmpName;
        }

        public string getNextCode(string tblName)
        {
            string NextCode = "";

            try
            {
                string qry = "SELECT isnull(Max([Code]),0) + 1 FROM [dbo].[" + tblName + "]";

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        NextCode = Convert.ToString(xResult);
                }

            }
            catch { NextCode = ""; }
            return NextCode;
        }

        public bool isLocked(string tableName, int recID)
        {
            bool locked = false;
            try
            {
                string qry = string.Format("SELECT IsLocked FROM {0} WHERE ID = {1}", "[dbo].[" + tableName + "]", recID);
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        locked = Convert.ToBoolean(xResult);
                }
            }
            catch { }
            return locked;
        }

        public bool isIDInPicTable(string tableName, string ColumnName, int ID)
        {
            try
            {
                string Qry = "SELECT * FROM [dbo].[" + tableName + "] WHERE [" + ColumnName + "] = " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != null)
                        return true;
                    else
                        return false;
                }
            }
            catch { return false; }
        }

        public bool isExist(string Table, string Field, string text, int ID)
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT count([" + Field + "])" +
                             " FROM [dbo].[" + Table + "]" +
                             " WHERE [" + Field + "] = '" + text + "' and [ID] <> " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }

        public bool isExist(string Table, string Field, int ID)
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT [" + Field + "]" +
                             " FROM [dbo].[" + Table + "]" +
                             " WHERE [" + Field + "] = " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }

        public int getMax(string tableName, string fieldName)
        {
            int maxNo = 0;
            try
            {
                string qry = string.Format("SELECT Max({0}) FROM {1}", fieldName, tableName);
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        maxNo = Convert.ToInt32(xResult);
                }
                maxNo += 1;
            }
            catch { }
            return maxNo;
        }

        public int getID(DataTable dataTable, string fieldName, string Name)
        {
            int ID = 0;
            try
            {
                string qry = string.Format("SELECT TOP(1) [ID] FROM [dbo].[" + dataTable.TableName + "] WHERE [" + fieldName + "] = '" + Name + "'");
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        ID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ID;
        }

        public int getID(DataTable dataTable, string fieldName, int byID)
        {
            int ID = 0;
            try
            {
                string qry = string.Format("SELECT TOP(1) [ID] FROM [dbo].[" + dataTable.TableName + "] WHERE [" + fieldName + "] = " + byID);
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        ID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ID;
        }

        public DataTable fillTablesByID(DataTable dataTable, DataTable dataTable1, string Qry, int ID)
        {
            dataTable1.Clear();
            dataTable.Clear();

            this.FillByID(dataTable, ID);
            this.FillByQryByID(dataTable1, Qry, ID);

            return dataTable;
        }

        public DataTable fillTablesByIDOrderBy(DataTable dataTable, DataTable dataTable1, string Qry, int ID, string OrderBy)
        {
            dataTable1.Clear();
            dataTable.Clear();

            this.FillByID(dataTable, ID);
            this.FillByQryByIDOrderBy(dataTable1, Qry, ID, OrderBy);

            return dataTable;
        }

        public DataTable fillTablesByIDOrderBy(DataTable dataTable, int ID)
        {
            dataTable.Clear();
            this.FillByID(dataTable, ID);
            return dataTable;
        }

        public int getFinancialYearEnd()
        {
            int FinYearEnd = 0;// 
            try
            {
                Int32 coFinYearStrMonth = StaticInfo.CoFinYearStrMonth;
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;

                if (coFinYearStrMonth > DateTime.Now.Month)
                {
                    startDate = new DateTime(DateTime.Now.Year - 1, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                else
                {
                    startDate = new DateTime(DateTime.Now.Year, coFinYearStrMonth, 1);
                    endDate = startDate.Date.AddDays(364);
                }
                FinYearEnd = endDate.Date.Year;
            }
            catch { }
            return FinYearEnd;
        }

        public DataRow getRowByZipCode(int zipcode)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT * FROM [dbo].[ZipCode] WHERE [Zip] = " + zipcode;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        //-------Warehouse-------------------------------//
        public DataTable GetInfo(DataTable dataTable, int ID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [" + dataTable.TableName + "] WHERE [Active] = 1 and ID = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetBranchInfo(DataTable dataTable, int BrID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [Store] WHERE [ID] = '" + BrID + "' AND [Active] = 1";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetStoreInfo(DataTable dataTable, int StoreID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [WarehouseStore] WHERE [ID] = '" + StoreID + "' AND [Active] = 1";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillCompanyBranchies(DataTable dataTable, int CoID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [Store] WHERE [CoID] = '" + CoID + "' AND [Active] = 1";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillWarehouseList(int ID)
        {
            DataTable dt = new DataTable();
            string Qry = " SELECT [Ware].[ID], [Ware].[CoCode] [Code]" +
                         " ,[Ware].[CoName] [Warehouse]" +
                         " ,[Ware].[CoAddress] [Address]" +
                         " ,[Ware].[CoPhone] [Phone]" +
                         " ,[Ware].[CoFax] [Fax]" +
                         " ,[Ware].[CoEmail] [Email]" +
                         " ,[Ware].[BarNo]" +
                         " ,[Cty].[Name] [City]" +
                         " ,[Ware].ZipCode" +
                         " ,[Ware].[AreaCode]" +
                         " ,[Ware].[AreaCode1]" +
                         " ,[Ware].[AreaCode2]" +
                         " ,[Ware].[NoOfBays] [Bays]" +
                         " FROM [dbo].[Warehouse] [Ware]" +
                         " Left join [dbo].[City] [Cty] ON [Ware].[CityID] = [Cty].[ID]" +
                         " Where [Ware].[CompanyID] = " + ID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);//
            return dt;
        }

        public DataTable FillStoreList(int ID)
        {
            DataTable dt = new DataTable();
            string Qry = " SELECT *" +
                         " FROM [dbo].[WarehouseStore] " +
                         " Where [WarehouseID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillWarehouseRacksList(int ID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT *" +
                " FROM [dbo].[WarehouseStoreRack]" +
                " Where [CompanyID] = " + StaticInfo.CompanyID + " and [WarehouseID] = " + ID + " and [StoreID] is null";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillStoreRacksList(int ID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT *" +
                " FROM [dbo].[WarehouseStoreRack]" +
                " Where [CompanyID] = " + StaticInfo.CompanyID + " and [WarehouseID] = " + StaticInfo.WarehouseID + " and [StoreID] = " + ID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);
            return dt;
        }

        public DataTable FillWarehouseRacksList(DataTable dt, int ID)
        {
            dt.Clear();

            string Qry = "SELECT *" +
                " FROM [dbo].[WarehouseStoreRack]" +
                " Where [CompanyID] = " + StaticInfo.CompanyID + " and [WarehouseID] = " + ID + " and [StoreID] is null";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillStoreRacksList(DataTable dt, int ID)
        {
            dt.Clear();

            string Qry = "SELECT *" +
                " FROM [dbo].[WarehouseStoreRack]" +
                " Where [CompanyID] = " + StaticInfo.CompanyID + " and [WarehouseID] = " + StaticInfo.WarehouseID + " and [StoreID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillWarehouseHolidays(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT WH.[ID] ,WH.[MID] ,WH.[HolidayID] ,[Hday].Name Holiday, [WH].IsPaid, [WH].IsClosed, [Hday].HolidayDate" +
                         " ,WH.[Active] ,WH.[AddDate] ,WH.[AddUserID] ,WH.[ModifyUserID] ,WH.[ModifyDate] ,WH.[Comments] ,WH.[IsLocked] ,WH.[DocNo] ,WH.[Remarks] ,WH.[CoFinEndYear] ,WH.[TrnsVrNo] ,WH.[TrnsJrRef]" +
                         " FROM [dbo].[WarehouseHolidays] WH" +
                         " Join [dbo].[Holidays] [Hday] on WH.[HolidayID] = [Hday].ID";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillWarehousePackages(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "Select ID,[Catalog],Name,PackageWithTax,(SELECT GroupName FROM UserGroups where ID = AddUserID)AS [USER],ModifyDate from WarehousePackages";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //---------------------------- 
            return dataTable;
        }

        public DataTable FillWarehouseDepartments(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT dep.*, emp.Name Manager" +
                         " FROM dbo.WarehouseDepartment dep" +
                         " Left join dbo.Employee emp on dep.ManagerID = emp.ID ";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //---------------------------- 
            return dataTable;
        }

        public bool isCompanyInfoExist()
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT count(*) FROM [dbo].[Company] WHERE [Active] = 1";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }

        public decimal getSaleTaxRateFromSaleTaxCategorybyID(int ID)
        {
            decimal PartsTaxRate = 0;
            try
            {
                string qry = "select [str].[PartsRate]" +
                             " FROM [dbo].[SaleTaxCategory] [stc]" +
                             " Left join dbo.SaleTaxRates [str] on [stc].[SaleTaxRateID] = [str].ID" +
                             " where stc.id = " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        PartsTaxRate = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return PartsTaxRate;
        }

        //-------Vendor-------------------------------//
        public string FillVendorListWithBalances()
        {
            string Qry = " SELECT [Ven].[ID]" +
                         " ,[Ven].[Code],[Ven].[Name],[Ven].[RegDate],[Ven].[Email],[Ven].[Phone],[Ven].[Fax],[Ven].[AlterPhone],[Ven].[Address]" +
                         " ,[Ven].[ZipCode],[Ven].[FederalNo],[Ven].[TermsID],[Ven].[CutOffDayID],[Ven].[BillingAddress]" +
                         " ,[Ven].[BillingZipCode],[Ven].[IsBillingAddressForCheque],[Ven].[AccountNo],[Ven].[Notes],[Ven].[ContactName],[Ven].[IsOutsidePartPurchases],[Ven].[RetailMarkup]" +
                         " ,[Ven].[CommercialMarkup],[Ven].[WholesaleMarkup],[Ven].[RetailMargin],[Ven].[CommercialMargin],[Ven].[WholesaleMargin],[Ven].[IsUseTheseMarkupsMargins],[Ven].[Active]" +
                         " ,[Ven].[AddDate],[Ven].[AddUserID],[Ven].[ModifyUserID],[Ven].[ModifyDate],[Ven].[Comments],[Ven].[IsLocked],[Ven].[DocNo],[Ven].[Remarks],[Ven].[CoFinEndYear],[Ven].[TrnsVrNo],[Ven].[TrnsJrRef]" +
                         " ,[Balance] = ISNULL(" +
                         " (" +
                         " Select SUM(ISNULL(BillTotalAmount,0)) - (Select (SUM(ISNULL(BillDiscount,0)) + SUM(ISNULL(PaidAmount,0))) from VendorPayment where vendorID = [Ven].ID)" +
                         " FROM VendorBill where vendorID = [Ven].ID" +
                         " ),0)" +
                         " FROM dbo.Vendor [Ven]";

            return Qry;
        }

        public DataTable FillVendorList()
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [Ven].[ID] ,[Ven].[Name]" +
                         " ,[Ven].[Phone]" +
                         " ,[Ven].[ContactName] [ContactPerson]" +
                         " ,[Balance] = (" +
                         " (Select SUM(ISNULL(BillTotalAmount,0)) from VendorBill where VendorID = [Ven].[ID]) " +
                         " - " +
                         " (Select SUM(ISNULL(BillDiscount,0)) from VendorPayment where VendorID = [Ven].[ID])" +
                         " -" +
                         " (select SUM(ISNULL(PaidAmount,0)) from VendorPayment where VendorID = [Ven].[ID]) " +
                         " ) " +
                         " FROM [dbo].[Vendor] [Ven]" +
                         " WHERE [Ven].Active = 1 Order by [Ven].[Name]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillVendorByVendorID(int VendorID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [Ven].[ID] ,[Ven].[Name]" +
                         " ,[Ven].[Phone]" +
                         " ,[Ven].[ContactName] [ContactPerson]" +
                         " ,[Balance] = (" +
                         " (Select SUM(ISNULL(BillTotalAmount,0)) from VendorBill where VendorID = [Ven].[ID]) " +
                         " - " +
                         " (Select SUM(ISNULL(BillDiscount,0)) from VendorPayment where VendorID = [Ven].[ID])" +
                         " -" +
                         " (select SUM(ISNULL(PaidAmount,0)) from VendorPayment where VendorID = [Ven].[ID]) " +
                         " ) " +
                         " FROM [dbo].[Vendor] [Ven]" +
                         " WHERE [Ven].Active = 1 AND " +
                         " [Ven].[ID]=" + VendorID +
                         " Order by [Ven].[Name]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillVendorHistoryList(int VendorID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [VB].[ID] [Trns#],[Type] = 'Bill', [Bill#] = [VB].ID, [Date] = [VB].[BillDate], [Date Due] = [VB].[DueDate], [Reference] = [VB].[InvoiceNo]" +
                         " ,[Notes] = [VB].[BillNotes], [Terms] = [trms].Name , [Amount] = 0, [Balance] = [VB].[BillTotalAmount], [Store] = [str].CoName " +
                         " FROM dbo.VendorBill [VB]" +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID " +
                         " WHERE [VB].VendorID = " + VendorID +
                         " UNION ALL" +
                         " SELECT [VB].[ID] [Trns#],[Type] = 'Payment', [Bill#] = [VB].BillID, [Date] = [VB].[TrnsDate], [Date Due] = [VB].[TrnsDate], [Reference] = [VB].[InvoiceNo]" +
                         " ,[Notes] = [VB].[TrnsNotes], [Terms] = [trms].Name , [Amount] = [VB].[PaidAmount], [Balance] = [VB].[BillBalance], [Store] = [str].CoName " +
                         " FROM dbo.VendorPayment [VB]" +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID " +
                         " Where [VB].[PaidAmount] > 0 AND [VB].VendorID = " + VendorID +
                         " UNION ALL" +
                         " SELECT [VB].[ID] [Trns#],[Type] = 'Discount', [Bill#] = [VB].BillID, [Date] = [VB].[TrnsDate], [Date Due] = [VB].[TrnsDate], [Reference] = [VB].[InvoiceNo]" +
                         " ,[Notes] = [VB].[TrnsNotes], [Terms] = [trms].Name , [Amount] = [VB].[BillDiscount], [Balance] = 0, [Store] = [str].CoName " +
                         " FROM dbo.VendorPayment [VB]" +
                         " LEFT JOIN dbo.Vendor [Ven] ON [VB].VendorID = [Ven].ID " +
                         " LEFT JOIN dbo.Terms [trms] ON [Ven].TermsID = [trms].ID " +
                         " LEFT JOIN dbo.WarehouseStore [str] ON [VB].StoreID = [str].ID " +
                         " Where [VB].[BillDiscount] > 0 AND [VB].VendorID = " + VendorID +
                         " order by [Trns#]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable FillCustomerHistoryList(int CustomerID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [ID] , [Trans],[Date], [Type], [RecNo], [PaidBy], [Rep], [PONo], [Vehicle], [Open Amt], [Total Amt],[Store] FROM" +
                         " (SELECT Mas.ID [ID], Mas.WorkOrderNo [Trans], Mas.RegDate [Date], 'W/O' [Type], Mas.WorkOrderNo [RecNo], '' [PaidBy],emp.Initial [Rep], '' [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , [Open Amt] = ISNULL(((SELECT SUM(TotalReceivedAmount) FROM CustomerReceipt where IsPaid = 1 and CustomerID = " + CustomerID + " and WOID = Mas.ID) - Mas.Total),0)" +
                         " , Mas.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.WorkOrder Mas" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on Mas.VehicleID = Veh.ID" +
                         " WHERE Mas.CustomerID = " + CustomerID +
                         " UNION ALL" +
                         " SELECT Mas.ID [ID], Mas.ReceiptID [Trans], Mas.AddDate [Date], 'Invoice' [Type], WO.WorkOrderNo [RecNo], '' [PaidBy],emp.Initial [Rep], WO.PONo [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , ISNULL(TotalReceivedAmount,0) [Open Amt]" +
                         " , WO.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.CustomerReceipt Mas" +
                         " Left Join dbo.WorkOrder WO on Mas.WOID = WO.ID" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on WO.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on WO.VehicleID = Veh.ID" +
                         " WHERE Mas.IsPaid = 1 and Mas.CustomerID = " + CustomerID +
                         " UNION ALL" +
                         " SELECT Mas.ID [ID], Mas.ReceiptID [Trans], Mas.AddDate [Date], 'Deposit' [Type], WO.WorkOrderNo [RecNo], '' [PaidBy],emp.Initial [Rep], WO.PONo [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , ISNULL(TotalReceivedAmount,0) [Open Amt]" +
                         " , WO.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.CustomerReceipt Mas" +
                         " Left Join dbo.WorkOrder WO on Mas.WOID = WO.ID" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on WO.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on WO.VehicleID = Veh.ID" +
                         " WHERE Mas.IsDeposit = 1 and Mas.CustomerID = " + CustomerID +
                         " UNION ALL" +
                         " SELECT Mas.ID [ID], Mas.WorkOrderNegateNo [Trans], Mas.RegDate [Date], 'W/O Negate' [Type], Mas.WorkOrderNegateNo [RecNo], '' [PaidBy],emp.Initial [Rep], '' [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , [Open Amt] = ISNULL(((SELECT SUM(TotalReceivedAmount) FROM CustomerPayment where CustomerID = " + CustomerID + " and WONID = Mas.ID)),0)" +
                         " , Mas.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.WorkOrderNegate Mas" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on Mas.VehicleID = Veh.ID" +
                         " WHERE ISNULL(((SELECT SUM(TotalReceivedAmount) FROM CustomerPayment where CustomerID = " + CustomerID + " and WONID = Mas.ID)),0) = 0 and Mas.CustomerID = " + CustomerID + " and Mas.WorkOrderNegateNo = Mas.WorkOrderNegateNo" +
                         " UNION ALL" +
                         " SELECT Mas.ID [ID], Mas.WorkOrderNegateNo [Trans], Mas.RegDate [Date], 'Invoice' [Type], Mas.WorkOrderNegateNo [RecNo], '' [PaidBy],emp.Initial [Rep], '' [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , [Open Amt] = ISNULL(((SELECT SUM(TotalReceivedAmount)*-1 FROM CustomerPayment where CustomerID = " + CustomerID + " and WONID = Mas.ID)),0)" +
                         " , Mas.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.WorkOrderNegate Mas" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on Mas.VehicleID = Veh.ID" +
                         " WHERE ISNULL(((SELECT SUM(TotalReceivedAmount) FROM CustomerPayment where CustomerID = " + CustomerID + " and WONID = Mas.ID)),0) <> 0 and Mas.CustomerID = " + CustomerID + " and Mas.WorkOrderNegateNo = Mas.WorkOrderNegateNo" +
                         " UNION ALL" +
                         " SELECT Mas.ID [ID], Mas.PaymentID [Trans], Mas.AddDate [Date], 'Payment' [Type], WO.WorkOrderNegateNo [RecNo], '' [PaidBy],emp.Initial [Rep], WO.PONo [PONo]" +
                         " , Veh.YearMakeModel [Vehicle]" +
                         " , ISNULL(TotalReceivedAmount,0)*-1 [Open Amt]" +
                         " , WO.Total [Total Amt],stor.CoName [Store]" +
                         " FROM dbo.CustomerPayment Mas" +
                         " Left Join dbo.WorkOrderNegate WO on Mas.WONID = WO.ID" +
                         " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
                         " Left Join dbo.Employee emp on WO.SaleRepID = emp.ID" +
                         " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
                         " Left Join dbo.Vehicle Veh on WO.VehicleID = Veh.ID" +
                         " WHERE Mas.CustomerID = " + CustomerID + ") tbl";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataRow getVendorterm(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT Trm.*" +
                         " FROM [dbo].[Terms] [Trm]" +
                         " Left Join [dbo].[Vendor] [Ven] ON [Ven].TermsID = Trm.ID" +
                         " WHERE [Ven].[ID] =  " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public string getVendorName(int SupID)
        {
            string VendorName = "";
            string qry = "SELECT [Name] FROM [dbo].[Vendor] WHERE [ID] = " + SupID + "";
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    VendorName = Convert.ToString(xResult);
            }
            return VendorName;
        }

        public DataRow getVendorByID(int VenID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [Vendor] WHERE [ID] = " + VenID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        //-------Customer-------------------------------//
        public string FillCustomerListWithBalances()
        {
            string Qry = "Select m.[ID],m.[RegDate],m.[Code],m.[FirstName],m.[LastName],m.[IsCustomer],m.[IsCompany],m.[CompanyName]" +
                         " ,m.[Address],m.[ContactPerson],m.[Email],m.[ZipCode],m.[Phone1],m.[Phone2],m.[Phone3],m.[Phone4],m.[Notes],m.[WOMsg],m.[IsShowMsgOnInvoice]" +
                         " ,m.[IsReqPONo],m.[IsPayFET],m.[IsCheckAccepted],m.[IsMail],m.[IsNoAutomaticSupplies],m.[PartDisPer],m.[LaborDisPer],m.[Deposit],m.[Resale]" +
                         " ,m.[ResaleDate],m.[SaleCategoryID],m.[SaleTaxRateID],m.[PriceLevelID],m.[ReferredByID],m.[SaleTermID],m.[CreditLimits],m.[ShipViaID]" +
                         " ,m.[IsFinanceCharges],m.[IsBadDebt],m.[IsPrintStatement],m.[IsNeverReAge],m.[IsNationalAccount],m.[IsDelete],m.[WebEmail],m.[WebPassword]" +
                         " ,m.[WebPriceLevelID],m.[Active],m.[AddDate],m.[AddUserID],m.[ModifyUserID],m.[ModifyDate],m.[Comments],m.[IsLocked],m.[DocNo],m.[Remarks]" +
                         " ,m.[CoFinEndYear],m.[TrnsVrNo],m.[TrnsJrRef],m.[CompanyID],m.[WarehouseID],m.[StoreID]" +
                         " , [Warehouse].CoName as [Warehouse]" +
                         " ,[WarehouseStore].CoName as [WarehouseStore]" +
                         " ,[Balance] = ISNULL(" +
                         " (select SUM(ISNULL(Total,0)) from WorkOrder where [IsWorkOrder] = 1 and CustomerID = m.id)" +
                         " -" +
                         " (select ISNULL(SUM(ISNULL([TotalReceivedAmount],0)) - SUM(ISNULL([ChgOnAccount],0)),0) from CustomerReceipt where CustomerID = m.id)" +
                         " +" +
                         " (select ISNULL(SUM(ISNULL(Total,0)),0) from WorkOrderNegate where [IsWorkOrderNegate] = 1 and CustomerID = m.id)" +
                         " -" +
                         " (select ISNULL(SUM(ISNULL([TotalReceivedAmount],0)) - SUM(ISNULL([ChgOnAccount],0)),0) from CustomerPayment where CustomerID = m.id)" +
                         " ,0)" +
                         " from [dbo].[Customer] m" +
                         " Left Join [dbo].[Warehouse] [Warehouse] On m.WarehouseID = [Warehouse].ID" +
                         " Left Join [dbo].[WarehouseStore] [WarehouseStore] On m.StoreID = [WarehouseStore].ID";

            return Qry;
        }

        public DataTable FillCustomerList(DataTable dt)
        {
            string Qry = "SELECT [ID], [Name]" +
                         " FROM [dbo].[Customer]" +
                         " WHERE [Active] = 1" +
                         " Order by [Name]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        public DataTable getCustomerList()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[Code] ,[FirstName] ,[LastName],[CompanyName] ,[Address] ,[ContactPerson] ,[Email] ,[Phone1] FROM [dbo].[Customer]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataRow getCustomerByID(int CusID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [Customer] WHERE [ID] = " + CusID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public DataRow getTop1Customer()
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT TOP(1)* FROM [Customer]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public DataTable FillCustomerList()
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [ID] ,[Code] ,[FirstName] ,[LastName] ,[CompanyName],[Phone1] ,[Address] ,[ContactPerson] ,[Email],[IsCheckAccepted] " +
                         " FROM [dbo].[Customer]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable getItemList()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[Catalog],[Name] FROM [dbo].[Item]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable getVendorList()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[Name] FROM [dbo].[Vendor]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public string getPriceLevelbyID(int ID)
        {
            string PriceLevel = "";
            string qry = "SELECT [Name] FROM [dbo].[ItemPriceLevel] WHERE [ID] = " + ID + "";
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    PriceLevel = Convert.ToString(xResult);
            }
            return PriceLevel;
        }

        public DataTable getTireSizeList()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[TSize] FROM [dbo].[TireSize]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable getPriceLevelList()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[Name] FROM [dbo].[ItemPriceLevel]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        //-------Item-------------------------------//
        public DataTable FillPackageByID(int PkgID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * from WarehousePackages WHERE [ID] = " + PkgID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable FillPackageDetailByID(int MID, int CusID, string PriceColumn)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT Det.[ID]" +
                         " ,Det.[MID]" +
                         " ,Det.[ItemID]" +
                         " ,Det.[FeeID]" +
                         " ,Det.[LaborID]" +
                         " ,[CType] = (SELECT Initial FROM [dbo].[ItemType] where ID = itm.[ItemTypeID])" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = (SELECT ISNULL([Qty],0) FROM [dbo].[ItemStock] WHERE ItemID = itm.[ID])" +
                         " ,Det.[Qty]" +
                         " ,[Price] = CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.[" + PriceColumn + "] END" +
                         " ,itm.CatalogCost" +
                         " ,[Amount] = Det.[Qty] * (CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.[" + PriceColumn + "] END)" +
                         " ,Det.[IsOptional]" +
                         " ,[Total] = Det.[Qty] * (CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.[" + PriceColumn + "] END)" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.[" + PriceColumn + "] END * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = ISNULL(itm.[FET],0)" +
                         " ,itm.[IsTaxable]" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = ISNULL(itm.[" + PriceColumn + "Percent],0)" +
                         " ,[MarginAmount] =  ISNULL(itm.[" + PriceColumn + "],0)" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM [dbo].[WarehousePackagesDetail] Det" +
                         " Left Join dbo.Item itm on Det.ItemID = itm.ID" +
                         " WHERE Det.MID = " + MID + " and Det.ItemID is not null" +
                         " UNION ALL" +
                         " SELECT Det.[ID]" +
                         " ,Det.[MID]" +
                         " ,Det.[ItemID]" +
                         " ,Det.[FeeID]" +
                         " ,Det.[LaborID]" +
                         " ,Det.CType" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,Det.[Qty]" +
                         " ,[Price] = itm.FeePrice" +
                         " ,CatalogCost = 0" +
                         " ,[Amount] = Det.[Qty] * itm.FeePrice" +
                         " ,Det.[IsOptional]" +
                         " ,[Total] = Det.[Qty] * itm.FeePrice" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.FeePrice END * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM [dbo].[WarehousePackagesDetail] Det" +
                         " Left Join dbo.Fees itm on Det.FeeID = itm.ID" +
                         " WHERE Det.MID = " + MID + " and Det.FeeID is not null" +
                         " UNION ALL" +
                         " SELECT Det.[ID]" +
                         " ,Det.[MID]" +
                         " ,Det.[ItemID]" +
                         " ,Det.[FeeID]" +
                         " ,Det.[LaborID]" +
                         " ,Det.CType" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,Det.[Qty]" +
                         " ,[Price] = itm.LaborFees" +
                         " ,CatalogCost = 0" +
                         " ,[Amount] = Det.[Qty] * itm.LaborFees" +
                         " ,Det.[IsOptional]" +
                         " ,[Total] = Det.[Qty] * itm.LaborFees" +
                         " ,itm.LaborHours [Hours]" +
                         " ,itm.[IsDiscountable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(CASE Det.[IsOverride] WHEN 1 THEN Det.[PriceOverride] ELSE itm.LaborFees END * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM [dbo].[WarehousePackagesDetail] Det" +
                         " Left Join dbo.Labor itm on Det.LaborID = itm.ID" +
                         " WHERE Det.MID = " + MID + " and Det.LaborID is not null";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataRow FillItemByID(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [dbo].[Item] WHERE [ID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        //public DataTable GetItemDuplicateByID (int ID)
        //{
        //    DataTable dataTable = new DataTable();
        //    string Qry = "SELECT -1[ID],(SELECT (Isnull(max(ID),0) + 1) as ItemCode from Item) as [ItemCode] ,[IsAuto],[RegDate],[ItemSize],[Catalog],[Name],[ItemTypeID],[ItemGroupID],[NextLinkItemID],[VendorID],[ManufacturerID],[Location]" +
        //      " ,[BoltPattern],[ManufacturerNo],[VenderPartNo],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm]" +
        //      " ,[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[UnitWeight],[CatalogCost],[LastCost],[AverageCost],[FET],[RetailPricePercent]" +
        //      " ,[RetailPrice],[WholeSalePricePercent],[WholeSalePrice],[SpecialPricePercent],[SpecialPrice],[PriceDPercent],[PriceD],[PriceEPercent],[PriceE],[PriceFPercent]" +
        //      " ,[PriceF],[PriceGPercent],[PriceG],[PriceHPercent],[PriceH],[PriceIPercent],[PriceI],[PriceJPercent],[PriceJ],[PriceKPercent],[PriceK],[PriceLPercent]" +
        //      " ,[PriceL],[ReOrderMin],[ReOrderMax],[DataKeywords],[NAPAKeywords],[AutoWareCode],[IsSpiffsTemporary],[SpiffsTypeID],[SpiffsDollarAmount],[SpiffsPercent]" +
        //      " ,[SpiffsDateFrom],[SpiffsDateTo],[UPCCode],[IsTemporaryDiscount],[TemporaryDiscountDateFrom],[TemporaryDiscountDateTo],[TemporaryDiscountedPriceA]" +
        //      " ,[TemporaryDiscountedPriceB],[TemporaryDiscountedPriceC],[TemporaryDiscountedPriceD],[TemporaryDiscountedPriceE],[TemporaryDiscountedPriceF],[TemporaryDiscountedPriceG],[TemporaryDiscountedPriceH]" +
        //      " ,[TemporaryDiscountedPriceI],[PostCard],[WebSize],[WebTireSizeA],[WebTireSizeB],[WebTireSizeC],[WebWheelBoltCircle],[WebWheelBoltCircle2],[WebWheelOffset]" +
        //      " ,[WebWheelDiameter],[WebWheelDiameter2],[WebWheelWidth],[WebWheelCenterBore],[WebWheelFinish],[WebCategories],[WebBlurb],[WebDimensionH],[WebDimensionW]" +
        //      " ,[WebDimensionL],[WebItemsPerPackage],[WebPrice],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo]" +
        //      " ,[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID],[RackID]" +
        //      " FROM [dbo].[Item] WHERE [ID] = " + ID;

        //    SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
        //    sDA.Fill(dataTable);
        //    return dataTable;
        //}
        public void DuplicateItem(int ItemID) 
        {
            string Qry = "Insert Into Item(ItemCode, IsAuto, ItemSize, Catalog, Name, ItemTypeID, ItemGroupID, ManufacturerID, IsDiscountable, IsRepComm, IsCosted, IsTaxable, IsRetread, IsStocked, UnitWeight, CatalogCost, LastCost, AverageCost, FET, RetailPricePercent, RetailPrice, WholeSalePricePercent, WholeSalePrice, SpecialPricePercent, SpecialPrice, AddDate, AddUserID, CoFinEndYear, CompanyID, WarehouseID, StoreID, RackID) " +
             " Select(Select(IsNull(max(ID), 0) + 1) from Item), IsAuto, ItemSize, Catalog + ' Copy', Name + ' Copy', ItemTypeID, ItemGroupID, ManufacturerID, IsDiscountable, IsRepComm, IsCosted, IsTaxable, IsRetread, IsStocked, UnitWeight, CatalogCost, LastCost, AverageCost, FET, RetailPricePercent, RetailPrice, WholeSalePricePercent, WholeSalePrice, SpecialPricePercent, SpecialPrice, GETDATE()," +
              + StaticInfo.userid +
             " , "+ StaticInfo.CoFinEndYear +
             " , CompanyID, WarehouseID, StoreID, RackID " +
             " From Item " +
             " Where id =" + ItemID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();                
            }
        }
        
        public DataSet GetPackageDetailsByID(int PID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("sp_GetPackageDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@packageID", SqlDbType.Int).Value = Convert.ToInt32(PID);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataTable FillItemList()
        {
            DataTable dt = new DataTable();

            //string Qry = "SELECT itm.[ID]" +
            //             //" ,itm.[ItemCode]" +
            //             " ,itm.[ItemSize]" +
            //             " ,itm.[Catalog]" +
            //             " ,itm.[Name]" +
            //             //" ,itm.[UnitWeight]" +
            //             " ,itm.[CatalogCost]" +
            //             //" ,itm.[LastCost]" +
            //             //" ,itm.[AverageCost]" +
            //             " ,itm.[FET]" +
            //             //" ,itm.[RetailPercent]" +
            //             " ,itm.[RetailPrice]" +
            //             //" ,itm.[CommercialPercent]" +
            //             " ,itm.[CommercialPrice]" +
            //             //" ,itm.[WholesalePercent]" +
            //             " ,itm.[WholesalePrice]" +
            //             " ,itmType.Name [ItemType]" +
            //             //" ,itmGrp.Name [ItemGroup]" +
            //             //" ,itmManu.Name [Manufacturer]" +
            //             //" ,itm.[ManufacturerNo]" +
            //             //" ,WStore.CoName [Store]" +
            //             //" ,WRack.Code [Rack]" +
            //             " FROM [dbo].[Item] itm" +
            //             " Left Join [dbo].[ItemType] itmType on itm.[ItemTypeID] = itmType.ID" +
            //             " Left Join [dbo].[ItemGroup] itmGrp on itm.[ItemGroupID] = itmGrp.ID" +
            //             " Left Join [dbo].[ItemManufacturer] itmManu on itm.[ManufacturerID] = itmManu.ID" +
            //             " Left Join [dbo].[WarehouseStore] WStore on itm.[StoreID] = WStore.ID" +
            //             " Left Join [dbo].[WarehouseStoreRack] WRack on itm.[RackID] = WRack.ID";

            string Qry = "SELECT itm.[ID]" +
                         " ,itm.[ItemSize]" +
                         " ,itm.[Catalog]" +
                         " ,itm.[Name]" +
                         " ,itm.[ItemGroupID]" +
                         " ,[InStock] = ISNULL((SELECT ISNULL(SUM([Qty]),0) FROM [dbo].[ItemStock] WHERE [ItemID] = Itm.ID GROUP BY [ItemID]),0)" +
                         " ,itm.[CatalogCost]" +
                         " ,itm.[FET]" +
                         " ,itm.[RetailPrice]" +
                         " ,itm.[WholeSalePrice]" +
                         " ,itm.[SpecialPrice]" +

                         " FROM [dbo].[Item] itm" +
                         " Left Join [dbo].[ItemType] itmType on itm.[ItemTypeID] = itmType.ID";


            ////,itm.[PriceD]" +
            //             " ,itm.[PriceE]" +
            //             " ,itm.[PriceF]" +
            //             " ,itm.[PriceG]" +
            //             " ,itm.[PriceH]" +
            //             " ,itm.[PriceI]" +
            //" ,itmType.Name [ItemType]" +   



            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillItemHistory(int itmID)
        {
            DataTable dt = new DataTable();
            string Qry = "SELECT [ID],[Type], [VendorCustomer] as Company, [Description] as Item, [Reference], Cast([Date] as date) Date, [Qty], [Price], [Profit], [FET], [Rep], [Store] FROM ("+

                        " SELECT Mas.ID[ID],'P/O'[Type],Ven.Name[VendorCustomer],itm.Name[Description],Mas.POID[Reference],det.AddDate[Date],det.PrevRcvd[Qty],det.Cost[Price], 0[Profit], det.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.PurchaseOrder Mas Left Join dbo.PurchaseOrderDetails det  on det.MID = Mas.ID"+
                        " Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Vendor Ven on Mas.VendorID = Ven.ID Left Join dbo.Employee emp on Mas.AddUserID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID WHERE det.ItemID = " + itmID + ""+

                        " UNION ALL "+

                        " SELECT Mas.ID[ID],'Sale'[Type],Ven.[CompanyName][VendorCustomer],itm.Name[Description],Mas.MID[Reference],cr.AddDate[Date],Mas.Qty[Qty],Mas.Price[Price],Mas.Price - Mas.Cost[Profit], Mas.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.CustomerReceipt cr Left Join"+
                        " dbo.WorkOrderDetail Mas on cr.WOID = Mas.MID Left Join dbo.Item itm on Mas.ItemID = itm.ID Left Join dbo.Customer Ven on cr.CustomerID = Ven.ID Left Join dbo.Employee emp on cr.AddUserID = emp.ID Left Join dbo.WarehouseStore stor on cr.StoreID = stor.ID WHERE mas.ItemID = " + itmID + "" +

                        " UNION ALL "+

                        " SELECT Mas.ID[ID], 'Return'[Type],Ven.[CompanyName][VendorCustomer] ,itm.Name[Description],Mas.WorkOrderNegateNo[Reference],det.AddDate[Date],det.Qty[Qty],det.Price[Price],det.Price - det.Cost[Profit], det.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.CustomerPayment cp Left Join"+
                        " dbo.WorkOrderNegate Mas on cp.WONID = Mas.ID  Left join dbo.WorkOrderNegateDetail det on det.MID = Mas.ID Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID WHERE det.ItemID = " + itmID + ") tbl" +
                        " order by Date Asc";
            //string Qry = "SELECT [ID],[Type], [VendorCustomer] as Company, [Description] as Item, [Reference], Cast([Date] as date) Date, [Qty], [Price], [Profit], [FET], [Rep], [Store] FROM" +
            //             " (SELECT Mas.ID [ID],'P/O' [Type],Ven.Name [VendorCustomer],itm.Name [Description],Mas.POID [Reference],det.AddDate [Date],det.PrevRcvd [Qty],det.Cost [Price], 0 [Profit], det.FET [FET],emp.Initial [Rep],stor.CoName [Store]" +
            //             " FROM dbo.PurchaseOrderDetails det" +
            //             " Left Join dbo.PurchaseOrder Mas on det.MID = Mas.ID" +
            //             " Left Join dbo.Item itm on det.ItemID = itm.ID" +
            //             " Left Join dbo.Vendor Ven on Mas.VendorID = Ven.ID" +
            //             " Left Join dbo.Employee emp on Mas.AddUserID = emp.ID" +
            //             " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
            //             " WHERE det.ItemID = " + itmID +
            //             " UNION ALL" +
            //             " SELECT Mas.ID [ID],'Sale' [Type],Ven.[CompanyName] [VendorCustomer],itm.Name [Description],Mas.WorkOrderNo [Reference],det.AddDate [Date],det.Qty [Qty],det.Price [Price],det.Price-det.Cost [Profit], det.FET [FET],emp.Initial [Rep],stor.CoName [Store]" +
            //             " FROM dbo.WorkOrderDetail det" +
            //             " Left Join dbo.WorkOrder Mas on det.MID = Mas.ID" +
            //             " Left Join dbo.Item itm on det.ItemID = itm.ID" +
            //             " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
            //             " Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID" +
            //             " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
            //             " WHERE det.ItemID = " + itmID +
            //             " UNION ALL" +
            //             " SELECT Mas.ID [ID], 'Return' [Type],Ven.[CompanyName] [VendorCustomer]" +
            //             " ,itm.Name [Description],Mas.WorkOrderNegateNo [Reference],det.AddDate [Date],det.Qty [Qty],det.Price [Price],det.Price-det.Cost [Profit], det.FET [FET],emp.Initial [Rep],stor.CoName [Store]" +
            //             " FROM dbo.WorkOrderNegateDetail det" +
            //             " Left Join dbo.WorkOrderNegate Mas on det.MID = Mas.ID" +
            //             " Left Join dbo.Item itm on det.ItemID = itm.ID" +
            //             " Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID" +
            //             " Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID" +
            //             " Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID" +
            //             " WHERE det.ItemID = " + itmID + ") tbl";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable GetItemSaleHistory(int itmID)
        {
            DataTable dt = new DataTable();
            string Qry = "SELECT [ID],[Type], [VendorCustomer] as Company, [Description] as Item, [Reference], Cast([Date] as date) Date, [Qty], [Price], [Profit], [FET], [Rep], [Store] FROM (" +

                        " SELECT Mas.ID[ID],'P/O'[Type],Ven.Name[VendorCustomer],itm.Name[Description],Mas.POID[Reference],det.AddDate[Date],det.PrevRcvd[Qty],det.Cost[Price], 0[Profit], det.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.PurchaseOrder Mas Left Join dbo.PurchaseOrderDetails det  on det.MID = Mas.ID" +
                        " Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Vendor Ven on Mas.VendorID = Ven.ID Left Join dbo.Employee emp on Mas.AddUserID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID WHERE det.ItemID = " + itmID + "" +

                        " UNION ALL " +

                        " SELECT Mas.ID[ID],'Sale'[Type],Ven.[CompanyName][VendorCustomer],itm.Name[Description],Mas.MID[Reference],cr.AddDate[Date],Mas.Qty[Qty],Mas.Price[Price],Mas.Price - Mas.Cost[Profit], Mas.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.CustomerReceipt cr Left Join" +
                        " dbo.WorkOrderDetail Mas on cr.WOID = Mas.MID Left Join dbo.Item itm on Mas.ItemID = itm.ID Left Join dbo.Customer Ven on cr.CustomerID = Ven.ID Left Join dbo.Employee emp on cr.AddUserID = emp.ID Left Join dbo.WarehouseStore stor on cr.StoreID = stor.ID WHERE mas.ItemID = " + itmID + "" +

                        " UNION ALL " +

                        " SELECT Mas.ID[ID], 'Return'[Type],Ven.[CompanyName][VendorCustomer] ,itm.Name[Description],Mas.WorkOrderNegateNo[Reference],det.AddDate[Date],det.Qty[Qty],det.Price[Price],det.Price - det.Cost[Profit], det.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.CustomerPayment cp Left Join" +
                        " dbo.WorkOrderNegate Mas on cp.WONID = Mas.ID  Left join dbo.WorkOrderNegateDetail det on det.MID = Mas.ID Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID WHERE det.ItemID = " + itmID + ") tbl" +
                        " order by Date Asc";
            //string Qry = "SELECT [ID],[Type], [VendorCustomer] as [Company], [Description] as Item, [Reference], Cast([Date] as date) Date, [Qty],[Price], [Profit], [FET], [Rep], [Store] FROM (SELECT Mas.ID [ID],'Sale' [Type],Ven.[CompanyName] [VendorCustomer],itm.Name [Description],Mas.WOID [Reference],det.AddDate [Date],det.Qty [Qty],det.Price [Price],det.Price-det.Cost [Profit], det.FET [FET],emp.Initial [Rep],stor.CoName [Store] FROM dbo.WorkOrderDetail det Left Join dbo.CustomerReceipt Mas on det.MID = Mas.WOID Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID Left Join dbo.Employee emp on Mas.CustomerID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID " +
            //    "WHERE det.ItemID = " + itmID + ") tbl";
            //" UNION ALL " +
            //    "SELECT Mas.ID[ID], 'Return'[Type],Ven.[CompanyName] as [Company] ,itm.Name as Item,Mas.WorkOrderNegateNo[Reference],det.AddDate[Date],det.Qty[Qty],det.Price[Price],det.Price - det.Cost[Profit], det.FET[FET],emp.Initial[Rep],stor.CoName[Store] FROM dbo.WorkOrderNegateDetail det Left Join dbo.WorkOrderNegate Mas on det.MID = Mas.ID Left Join dbo.Item itm on det.ItemID = itm.ID Left Join dbo.Customer Ven on Mas.CustomerID = Ven.ID Left Join dbo.Employee emp on Mas.SaleRepID = emp.ID Left Join dbo.WarehouseStore stor on Mas.StoreID = stor.ID " +
            //    "WHERE det.ItemID = " + itmID + "
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public int getItemIDByCatalog(string ItemCatalog)
        {
            int ID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getItemIDByCatalog", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemCatalog", ItemCatalog);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@ID"].Value != System.DBNull.Value)
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                conn.Close();
            }
            return ID;
        }
        public int getFeeIDByCatalog(string ItemCatalog)
        {
            int ID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getFeeIDByCatalog", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemCatalog", ItemCatalog);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@ID"].Value != System.DBNull.Value)
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                conn.Close();
            }
            return ID;
        }
        public int getLaborIDByCatalog(string ItemCatalog)
        {
            int ID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getLaborIDByCatalog", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemCatalog", ItemCatalog);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@ID"].Value != System.DBNull.Value)
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                conn.Close();
            }
            return ID;
        }
        public int getPackageIDByCatalog(string ItemCatalog)
        {
            int ID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getPackageIDByCatalog", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemCatalog", ItemCatalog);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@ID"].Value != System.DBNull.Value)
                    ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                conn.Close();
            }
            return ID;
        }
        public decimal getItemPrice(string PriceLevel, int ItemID)
        {
            decimal price = 0;
            try
            {
                string qry = "SELECT [" + PriceLevel + "]" +
                             " FROM [dbo].[Item] itm" +
                             " WHERE itm.ID = " + ItemID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        price = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return price;
        }
        public DataTable getItemTypes()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT * FROM [dbo].[ItemType] order by Name ";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemGroupItemsByID(DataTable dataTable, int ID)
        {
            dataTable.Clear();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[ItemGroupID] ,[Itm].[ItemSize] ,[Itm].[Catalog] ,[Itm].[Name] ,[Itype].Name [Type]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " Left Join [dbo].[ItemType] [Itype] ON [Itm].ItemTypeID = [Itype].ID" +
                         " WHERE [Itm].[ItemGroupID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataRow GetItemByItemID(int ItemID, int Qty)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [ID] ,[MID],[ItemID] ,[FeeID] ,[LaborID] ,[CType],[ItmType] ,[ItemSize],[Catalog],Name ,ISNULL([Available],0) [Available],[Qty] = " + Qty + ",[CatalogCost],[Price],[Amount] = Round([Price] * " + Qty + ",2),[Total] = Round([Price] * " + Qty + ",2),[IsOptional] = 0,[Hours] = 0,[IsDiscountable],[PartDisPer],[PartDis] = CAST(ROUND(((Price * PartDisPer) / 100), 2) as numeric(32, 2)),[FET],[IsTaxable],[SaleTaxRate],[PartTax],[MarginPer],[MarginAmount] = Round(Price * " + Qty + ",2),[IsRepComm],[IsMechComm] FROM(SELECT[ID],[MID] = NULL,[ItemID] = itm.[ID],[FeeID] = NULL,[LaborID] = NULL,[CType] = (SELECT Initial FROM[dbo].[ItemType] where ID = itm.[ItemTypeID]) ,[ItmType] = 'Item' ,itm.[ItemSize][ItemSize] ,itm.[Catalog][Catalog] ,itm.Name[Name] ,[Available] = (SELECT ISNULL([Qty],0) FROM[dbo].[ItemStock] WHERE ItemID = itm.[ID]) ,[Qty] = " + Qty + " ,itm.CatalogCost ,[Price] = RetailPrice ,[Amount] = RetailPrice ,[Total] = RetailPrice ,[IsOptional] = 0 ,[Hours] = 0 ,itm.[IsDiscountable] ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN(SELECT ISNULL(PartDisPer, 0) FROM dbo.Customer WHERE ID = 4)ELSE 0 END ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.RetailPrice* ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = 4)/ 100),2) as numeric(36, 2)) ELSE 0 END ,[FET] = CASE itm.[IsUseFET] WHEN 1 THEN ISNULL(itm.[FET],0) else 0 end ,itm.[IsTaxable] ,[SaleTaxRate] = 0 ,[PartTax] = 0 ,[MarginPer] = [RetailPricePercent] ,[MarginAmount] = 0 ,ISNULL(itm.[IsRepComm], 0)[IsRepComm] ,ISNULL(itm.[IsMechComm], 0)[IsMechComm] FROM dbo.Item itm ) Itm where ID =" + ItemID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataRow GetItemByFeeID(int FeeID, int Qty)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [ID] ,[MID] = NULL,[ItemID] = NULL,[FeeID] = itm.[ID],[LaborID] = NULL,[CType] = 'F',[ItmType] = 'Fee',[ItemSize] = '', itm.[Catalog] [Catalog] , itm.Name[Name] ,[Available]=1 ,[Qty] = " + Qty + " ,[Price] = itm.FeePrice ,itm.FeePrice ,[Amount] = Round(itm.FeePrice * " + Qty + ",2) , [IsOptional] = 0 , [Total] = Round(itm.FeePrice * " + Qty + ",2) , [Hours] = 0 ,itm.[IsDiscountable] , [PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer, 0) FROM dbo.Customer WHERE ID = 4) ELSE 0 END ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.FeePrice * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = 4)/100),2) as numeric(36,2))ELSE 0 END , [FET] = 0 ,itm.[IsTaxable] ,[SaleTaxRate] = 0 ,[PartTax] = 0 ,[MarginPer] = 0 ,[MarginAmount] = 0 ,ISNULL(itm.[IsRepComm], 0)[IsRepComm] ,ISNULL(itm.[IsMechComm], 0)[IsMechComm] FROM dbo.Fees itm WHERE itm.[ID]='" + FeeID + "'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataRow GetItemByLaborID(int LaborID, int Qty)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [ID] , [MID] = NULL ,[ItemID] = NULL ,[FeeID] = NULL ,[LaborID] = itm.[ID] ,[CType] = 'L' ,[ItmType] = 'Labor' ,[ItemSize] = '' ,itm.[Catalog] [Catalog] ,itm.Name [Name] ,[Available] = 1 ,[Qty] = " + Qty + " ,[Price] = Round(itm.LaborFees * " + Qty + ",2) ,itm.LaborFees ,[Amount] = Round(itm.LaborFees * " + Qty + ",2) ,[IsOptional] = 0 ,[Total] = Round(itm.LaborFees * " + Qty + ",2) ,[Hours] = 0 ,itm.[IsDiscountable] ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = 4) ELSE 0 END , [PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.LaborFees * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = 4)/100),2) as numeric(36,2)) ELSE 0 END,  [FET] = 0 ,itm.[IsTaxable] ,[SaleTaxRate] = 0 ,[PartTax] = 0 ,[MarginPer] = 0 ,[MarginAmount] = 0 ,ISNULL(itm.[IsRepComm],0) [IsRepComm] ,ISNULL(itm.[IsMechComm],0) [IsMechComm] FROM dbo.Labor itm WHERE itm.ID='" + LaborID + "'";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataTable getItemsForGrid()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = itm.[ID]" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = 'P'" +
                         " ,[ItmType] = 'Item'" +
                         " ,itm.[ItemSize] [ItemSize]" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = (SELECT ISNULL([Qty],0) FROM [dbo].[ItemStock] WHERE ItemID = itm.[ID])" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.CatalogCost" +
                         " ,itm.CatalogCost" +
                         " ,[Amount] = itm.CatalogCost" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.CatalogCost" +
                         " ,[Hours] = 0" +
                         " ,[MarginPer] = ISNULL(itm.[RetailPricePercent],0)" +
                         " ,[MarginAmount] =  ISNULL(itm.[RetailPrice],0)" +
                         " FROM dbo.Item itm" +
                         " UNION ALL" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = itm.[ID]" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = 'F'" +
                         " ,[ItmType] = 'Fee'" +
                         " ,[ItemSize] = ''" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.FeePrice" +
                         " ,itm.FeePrice" +
                         " ,[Amount] = itm.FeePrice" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.FeePrice" +
                         " ,[Hours] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " FROM dbo.Fees itm" +
                         " UNION ALL" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = itm.[ID]" +
                         " ,[CType] = 'L'" +
                         " ,[ItmType] = 'Labor'" +
                         " ,[ItemSize] = ''" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.LaborFees" +
                         " ,itm.LaborFees" +
                         " ,[Amount] = itm.LaborFees" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.LaborFees" +
                         " ,[Hours] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " FROM dbo.Labor itm";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemForGridByItemID(int ItemID, int CusID, string PriceColumn)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID] ,[MID],[ItemID] ,[FeeID] ,[LaborID]" +
                         " ,[CType],[ItmType],[Catalog],Name ,ISNULL([Available],0) [Available],[Qty] = 1" +
                         " ,[CatalogCost] " +

                         " ,[Price]" +
                         " ,[Amount] = [Price] * [Qty]" +
                         " ,[Total] = [Price] * [Qty]" +

                         " ,[IsOptional] = 0" +
                         " ,[Hours] = 0" +
                         " ,[IsDiscountable]" +
                         " ,[PartDisPer]" +
                         " ,[PartDis] = CAST(ROUND(((Price * PartDisPer)/100),2) as numeric(32,2))" +
                         " ,[FET]" +
                         " ,[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer]" +
                         " ,[MarginAmount] =  Price" +
                         " ,[IsRepComm]" +
                         " ,[IsMechComm]" +
                         " FROM(" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = itm.[ID]" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = (SELECT Initial FROM [dbo].[ItemType] where ID = itm.[ItemTypeID])" +
                         " ,[ItmType] = 'Item'" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = (SELECT ISNULL([Qty],0) FROM [dbo].[ItemStock] WHERE ItemID = " + ItemID + ")" +
                         " ,[Qty] = 1" +
                         " ,itm.CatalogCost" +

                         " ,[Price] = itm." + PriceColumn +
                         " ,[Amount] = itm." + PriceColumn +
                         " ,[Total] = itm." + PriceColumn +

                         " ,[IsOptional] = 0" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +

                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.[" + PriceColumn + "] * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +

                         " ,[FET] = CASE itm.[IsUseFET] WHEN 1 THEN ISNULL(itm.[FET],0) else 0 end" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +

                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = [" + PriceColumn + "Percent]" +


                         " ,[MarginAmount] =  0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Item itm WHERE itm.ID = " + ItemID + ") Itm";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getFeeForGridByFeeID(int FeeID, int CusID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = itm.[ID]" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = 'F'" +
                         " ,[ItmType] = 'Fee'" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.FeePrice" +
                         " ,[CatalogCost] = itm.FeePrice" +
                         " ,[Amount] = itm.FeePrice" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.FeePrice" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.FeePrice * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Fees itm WHERE itm.ID = " + FeeID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getLaborForGridByLaborID(int LaborID, int CusID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = itm.[ID]" +
                         " ,[CType] = 'L'" +
                         " ,[ItmType] = 'Labor'" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 1" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.LaborFees" +
                         " ,[CatalogCost] = itm.LaborFees" +
                         " ,[Amount] = itm.LaborFees" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.LaborFees" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.LaborFees * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Labor itm WHERE itm.ID = " + LaborID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getPackageForGridByPackageID(int PackageID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [ID]" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " FROM dbo.[WarehousePackages] itm WHERE itm.ID = " + PackageID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemsForGridByCustomerID(int CusID, string PriceColumn)
        {
            DataTable dataTable = new DataTable();

            string Qry = " SELECT [ID] ,[MID],[ItemID] ,[FeeID] ,[LaborID]" +
                         " ,[CType],[ItmType] ,[ItemSize],[Catalog],Name ,ISNULL([Available],0) [Available],[Qty] = 1" +
                         " ,[CatalogCost] ,[Price]" +
                         " ,[Amount] = [Price] * [Qty]" +
                         " ,[Total] = [Price] * [Qty]" +
                         " ,[IsOptional] = 0" +
                         " ,[Hours] = 0" +
                         " ,[IsDiscountable]" +
                         " ,[PartDisPer]" +
                         " ,[PartDis] = CAST(ROUND(((Price * PartDisPer)/100),2) as numeric(32,2))" +
                         " ,[FET]" +
                         " ,[IsTaxable]" +
                         " ,[SaleTaxRate]" +
                         " ,[PartTax]" +
                         " ,[MarginPer]" +
                         " ,[MarginAmount] =  Price" +
                         " ,[IsRepComm]" +
                         " ,[IsMechComm]" +
                         " FROM(" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = itm.[ID]" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = (SELECT Initial FROM [dbo].[ItemType] where ID = itm.[ItemTypeID])" +
                         " ,[ItmType] = 'Item'" +
                         " ,itm.[ItemSize] [ItemSize]" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = (SELECT ISNULL([Qty],0) FROM [dbo].[ItemStock] WHERE ItemID = itm.[ID])" +
                         " ,[Qty] = 1" +
                         " ,itm.CatalogCost" +
                         " ,[Price] = " + PriceColumn +
                         " ,[Amount] = " + PriceColumn +
                         " ,[Total] = " + PriceColumn +
                         " ,[IsOptional] = 0" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm." + PriceColumn + " * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = CASE itm.[IsUseFET] WHEN 1 THEN ISNULL(itm.[FET],0) else 0 end" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = [" + PriceColumn + "Percent]" +
                         " ,[MarginAmount] =  0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Item itm ) Itm" +
                         " UNION ALL" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = itm.[ID]" +
                         " ,[LaborID] = NULL" +
                         " ,[CType] = 'F'" +
                         " ,[ItmType] = 'Fee'" +
                         " ,[ItemSize] = ''" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.FeePrice" +
                         " ,itm.FeePrice" +
                         " ,[Amount] = itm.FeePrice" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.FeePrice" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.FeePrice * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Fees itm" +
                         " UNION ALL" +
                         " SELECT [ID]" +
                         " ,[MID] = NULL" +
                         " ,[ItemID] = NULL" +
                         " ,[FeeID] = NULL" +
                         " ,[LaborID] = itm.[ID]" +
                         " ,[CType] = 'L'" +
                         " ,[ItmType] = 'Labor'" +
                         " ,[ItemSize] = ''" +
                         " ,itm.[Catalog] [Catalog]" +
                         " ,itm.Name [Name]" +
                         " ,[Available] = 0" +
                         " ,[Qty] = 1" +
                         " ,[Price] = itm.LaborFees" +
                         " ,itm.LaborFees" +
                         " ,[Amount] = itm.LaborFees" +
                         " ,[IsOptional] = 0" +
                         " ,[Total] = itm.LaborFees" +
                         " ,[Hours] = 0" +
                         " ,itm.[IsDiscountable]" +
                         " ,[PartDisPer] = CASE itm.[IsDiscountable] WHEN 1 THEN (SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ") ELSE 0 END" +
                         " ,[PartDis] = CASE itm.[IsDiscountable] WHEN 1 THEN CAST(ROUND(itm.LaborFees * ((SELECT ISNULL(PartDisPer,0) FROM dbo.Customer WHERE ID = " + CusID + ")/100),2) as numeric(36,2)) ELSE 0 END" +
                         " ,[FET] = 0" +
                         " ,itm.[IsTaxable]" +
                         " ,[SaleTaxRate] = 0" +
                         " ,[PartTax] = 0" +
                         " ,[MarginPer] = 0" +
                         " ,[MarginAmount] = 0" +
                         " ,ISNULL(itm.[IsRepComm],0) [IsRepComm]" +
                         " ,ISNULL(itm.[IsMechComm],0) [IsMechComm]" +
                         " FROM dbo.Labor itm";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemsForPackageGrid()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.[CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'P' [CType]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getFeesForGrid()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.FeePrice [CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'F' [CType]" +
                         " FROM [dbo].[Fees] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getLaborsForGrid()
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.LaborFees [CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'L' [CType]" +
                         " FROM [dbo].[Labor] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemsForPackageGrid(int ItemID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.[CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'P' [CType]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID" +
                         " Where [Itm].[ID] = " + ItemID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getFeesForGrid(int FeeID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.FeePrice [CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'F' [CType]" +
                         " FROM [dbo].[Fees] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID" +
                         " Where [Itm].[ID] = " + FeeID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getLaborsForGrid(int LaborID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].[ID] ,[Itm].[Catalog] ,[Itm].[Name], itm.LaborFees [CatalogCost]" +
                         " ,[IGroup].[Name] [ItemGroup], 'L' [CType]" +
                         " FROM [dbo].[Labor] [Itm]" +
                         " Left Join [dbo].[ItemGroup] [IGroup] ON [Itm].[ItemGroupID] = [IGroup].ID" +
                         " Where [Itm].[ID] = " + LaborID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable getItemForPO(int ItemID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [Itm].* " +
                         " ,[IType].[Name] [ItemType], 0 [IsUseGroupMargin], 0 [IsUpdateCost]" +
                         " , 0 [QtyOrdrd] ,0 [PrevOrdrd] ,0 [QtyRcvd] ,0 [PrevRcvd] ,0 [QtyBilled] ,0 [PrevBilled]" +
                         " ,0 [AvailableQty] ,0 [OnHandQty] ,0 [OnOrderQty] ,0 [ReOrderQty]" +
                         " FROM [dbo].[Item] [Itm]" +
                         " Left Join [dbo].[ItemType] [IType] ON [Itm].[ItemTypeID] = [IType].ID" +
                         " WHERE [Itm].[ID] = " + ItemID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public void UpdateItemPrice(DataTable dt)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Item]" +
                " SET [CatalogCost] = @CatalogCost" +
                " ,[RetailPricePercent] = @RetailPricePercent ,[RetailPrice] = @RetailPrice" +
                " ,[WholeSalePricePercent] = @WholeSalePricePercent ,[WholeSalePrice] = @WholeSalePrice" +
                " ,[SpecialPricePercent] = @SpecialPricePercent ,[SpecialPrice] = @SpecialPrice" +

                " ,[PriceDPercent] = @PriceDPercent ,[PriceD] = @PriceD" +
                " ,[PriceEPercent] = @PriceEPercent ,[PriceE] = @PriceE" +
                " ,[PriceFPercent] = @PriceFPercent ,[PriceF] = @PriceF" +

                " ,[PriceGPercent] = @PriceGPercent ,[PriceG] = @PriceG" +
                " ,[PriceHPercent] = @PriceHPercent ,[PriceH] = @PriceH" +
                " ,[PriceIPercent] = @PriceIPercent ,[PriceI] = @PriceI" +

                " WHERE ID = @ID", SqlCnn);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = Convert.ToInt32(dt.Rows[0]["ID"]);

                command.Parameters.Add("@CatalogCost", SqlDbType.Decimal);
                command.Parameters["@CatalogCost"].Value = Convert.ToDecimal(dt.Rows[0]["CatalogCost"]);

                //--------------------------------------------------------
                command.Parameters.Add("@RetailPricePercent", SqlDbType.Decimal);
                command.Parameters["@RetailPricePercent"].Value = Convert.ToDecimal(dt.Rows[0]["RetailPricePercent"]);

                command.Parameters.Add("@RetailPrice", SqlDbType.Decimal);
                command.Parameters["@RetailPrice"].Value = Convert.ToDecimal(dt.Rows[0]["RetailPrice"]);
                //--------------------------------------------------------
                command.Parameters.Add("@WholeSalePricePercent", SqlDbType.Decimal);
                command.Parameters["@WholeSalePricePercent"].Value = Convert.ToDecimal(dt.Rows[0]["WholeSalePricePercent"]);

                command.Parameters.Add("@WholeSalePrice", SqlDbType.Decimal);
                command.Parameters["@WholeSalePrice"].Value = Convert.ToDecimal(dt.Rows[0]["WholeSalePrice"]);
                //--------------------------------------------------------
                command.Parameters.Add("@SpecialPricePercent", SqlDbType.Decimal);
                command.Parameters["@SpecialPricePercent"].Value = Convert.ToDecimal(dt.Rows[0]["SpecialPricePercent"]);

                command.Parameters.Add("@SpecialPrice", SqlDbType.Decimal);
                command.Parameters["@SpecialPrice"].Value = Convert.ToDecimal(dt.Rows[0]["SpecialPrice"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceDPercent", SqlDbType.Decimal);
                command.Parameters["@PriceDPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceDPercent"]);

                command.Parameters.Add("@PriceD", SqlDbType.Decimal);
                command.Parameters["@PriceD"].Value = Convert.ToDecimal(dt.Rows[0]["PriceD"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceEPercent", SqlDbType.Decimal);
                command.Parameters["@PriceEPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceEPercent"]);

                command.Parameters.Add("@PriceE", SqlDbType.Decimal);
                command.Parameters["@PriceE"].Value = Convert.ToDecimal(dt.Rows[0]["PriceE"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceFPercent", SqlDbType.Decimal);
                command.Parameters["@PriceFPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceFPercent"]);

                command.Parameters.Add("@PriceF", SqlDbType.Decimal);
                command.Parameters["@PriceF"].Value = Convert.ToDecimal(dt.Rows[0]["PriceF"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceGPercent", SqlDbType.Decimal);
                command.Parameters["@PriceGPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceGPercent"]);

                command.Parameters.Add("@PriceG", SqlDbType.Decimal);
                command.Parameters["@PriceG"].Value = Convert.ToDecimal(dt.Rows[0]["PriceG"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceHPercent", SqlDbType.Decimal);
                command.Parameters["@PriceHPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceHPercent"]);

                command.Parameters.Add("@PriceH", SqlDbType.Decimal);
                command.Parameters["@PriceH"].Value = Convert.ToDecimal(dt.Rows[0]["PriceH"]);
                //--------------------------------------------------------
                command.Parameters.Add("@PriceIPercent", SqlDbType.Decimal);
                command.Parameters["@PriceIPercent"].Value = Convert.ToDecimal(dt.Rows[0]["PriceIPercent"]);

                command.Parameters.Add("@PriceI", SqlDbType.Decimal);
                command.Parameters["@PriceI"].Value = Convert.ToDecimal(dt.Rows[0]["PriceI"]);
                //--------------------------------------------------------

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public bool UpdateItemGroupID(int ID, int ItemGroupID)
        {
            bool IsSave = false;

            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Item] SET [ItemGroupID] = @ItemGroupID WHERE ID = @ID", SqlCnn);


                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = ID;

                command.Parameters.Add("@ItemGroupID", SqlDbType.Int);
                command.Parameters["@ItemGroupID"].Value = ItemGroupID;

                command.ExecuteNonQuery();

                IsSave = true;
            }
            catch { IsSave = false; }
            finally
            {
                SqlCnn.Close();
            }
            return IsSave;
        }
        public bool UpdateItemGroupID2(int ID)
        {
            bool IsSave = false;

            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("UPDATE [dbo].[Item] SET [ItemGroupID] = 1 WHERE ID = @ID", SqlCnn);

                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = ID;

                //command.Parameters.Add("@ItemGroupID", SqlDbType.Int);
                //command.Parameters["@ItemGroupID"].Value = ItemGroupID;

                command.ExecuteNonQuery();

                IsSave = true;
            }
            catch { IsSave = false; }
            finally
            {
                SqlCnn.Close();
            }
            return IsSave;
        }
        public DataTable getItemPriceforPriceChange(DataTable dataTable, int ItemID)
        {
            dataTable.Clear();

            string Qry = "SELECT *" +
                         " FROM [dbo].[Item] WHERE [ID] = " + ItemID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillItemGroup(DataTable dt)
        {
            dt.Clear();

            string QryM = "SELECT [ItmGrp].*" +
                          " ,[AssetAcct] = (SELECT [AccName] = (SELECT AccName FROM [dbo].[AutoFluentAccounts] WHERE AccID =  [Acc].AccTypeID) + ' : '+ [Acc].[AccName]" +
                          " FROM [dbo].[AutoFluentAccounts] [Acc] WHERE ID = [ItmGrp].AssetAcctID)" +
                          " ,[SalesAcct] = (SELECT [AccName] = (SELECT AccName FROM [dbo].[AutoFluentAccounts] WHERE AccID =  [Acc].AccTypeID) + ' : '+ [Acc].[AccName]" +
                          " FROM [dbo].[AutoFluentAccounts] [Acc] WHERE ID = [ItmGrp].SalesAcctID)" +
                          " ,[CGSAcct] = (SELECT [AccName] = (SELECT AccName FROM [dbo].[AutoFluentAccounts] WHERE AccID =  [Acc].AccTypeID) + ' : '+ [Acc].[AccName]" +
                          " FROM [dbo].[AutoFluentAccounts] [Acc] WHERE ID = [ItmGrp].CGSAcctID)" +
                          " FROM [dbo].[ItemGroup] [ItmGrp]";

            SqlDataAdapter sDAM = new SqlDataAdapter(QryM, this.connectionString);
            sDAM.Fill(dt);

            return dt;
        }
        public DataTable IsItemExist(string xCode, string xField, string tblName, int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT top(1) * FROM [dbo].[" + tblName + "] " +
                         " WHERE [" + xField + "] = '" + xCode + "'";
            if (ID > 0)
                Qry += "AND ID <> " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable IsItemExist(int ID, string tblName)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT top(1) * FROM [dbo].[" + tblName + "] " +
                             " WHERE [ID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }

        //-------Accounts-------------------------------//
        public DataTable FillAccounts(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT [ID] , [AccID] ,[AccName], convert(varchar(50),[AccID])+ ' - ' +convert(varchar(50),[AccName]) [AccName1]" +
                         " FROM [dbo].[Account]" +
                         " WHERE [AccLevel] = 3" +
                         " Order by [AccName]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable FillBankAccount(DataTable dataTable, string OrderBy = "")
        {
            dataTable.Clear();
            string Qry = "SELECT [ID], ([BankName]+' - '+[AccNo]) [BankName],[AccNo],[AccTitle] ,[Phone] ,[Email] ,[Address] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[TrnsVrNo] ,[DocNo] ,[DocDate] FROM [dbo].[" + dataTable.TableName + "] WHERE [Active] = 1";
            if (!string.IsNullOrEmpty(OrderBy)) Qry += " Order by [" + OrderBy + "]";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable FillVoucherByType(DataTable dataTable, string VType)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [dbo].[Voucher] WHERE [VType] = '" + VType + "'";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable FillAccountList()
        {
            DataTable dataTable = new DataTable();

            //string Qry = "SELECT [Acc].[ID],[Acc].[AccID],[Acc].[AccTypeID] ,[Acc].[AccName] as Account ,[Acc1].[AccName] as [Account Type],[Acc].[Active] FROM [dbo].[Account] [Acc] LEFT JOIN [dbo].[Account] [Acc1] ON [Acc].[AccTypeID] = [Acc1].[AccID] WHERE [Acc].[AccTypeID] > 0 ORDER BY [Acc].[AccTypeID]";
            string Qry = "Select ID,AccName from AutoFluentAccounts where Active = 1 ";
            // AND AddUserID = "+StaticInfo.userid+"
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillAccountListLevel0()
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [Acc].[ID],[Acc].[AccID],[Acc].[AccTypeID] ,[Acc].[AccName] ,[Acc].[AccNo] ,[Acc1].[AccName] [Acc.Type],[Acc].[Active]" +
                         " FROM [dbo].[Account] [Acc]" +
                         " LEFT JOIN [dbo].[Account] [Acc1] ON [Acc].[AccTypeID] = [Acc1].[AccID]" +
                         " WHERE [Acc].[AccLevel] = 0" +
                         " ORDER BY [Acc].[AccTypeID]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillAccountList(Int32 AccID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [Acc].[ID],[Acc].[AccID],[Acc].[AccTypeID] ,[Acc].[AccName] ,[Acc].[AccNo] ,[Acc1].[AccName] [Acc.Type],[Acc].[Active]" +
                         " FROM [dbo].[AutoFluentAccounts] [Acc]" +
                         " LEFT JOIN [dbo].[AutoFluentAccounts] [Acc1] ON [Acc].[AccTypeID] = [Acc1].[AccID]" +
                         " WHERE [Acc].[AccTypeID] = " + AccID +
                         " ORDER BY [Acc].[AccTypeID]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillAccountList2(Int32 AccID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT [Acc].[ID],[Acc].[AccID],[Acc].[AccTypeID] ,'    '+[Acc].[AccName] ,[Acc].[AccNo] ,[Acc1].[AccName] [Acc.Type],[Acc].[Active]" +
                         " FROM [dbo].[AutoFluentAccounts] [Acc]" +
                         " LEFT JOIN [dbo].[AutoFluentAccounts] [Acc1] ON [Acc].[AccTypeID] = [Acc1].[AccID]" +
                         " WHERE [Acc].[AccTypeID] = " + AccID +
                         " ORDER BY [Acc].[AccTypeID]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable IsAccExist(int ID)
        {
            DataTable dataTable = new DataTable();

            string Qry = " SELECT [AccountID],'AccountVoucher' as [tbl] FROM [dbo].[AccountVoucher] WHERE [AccountID] = " + ID;                      
            
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);

            //string Qry = " SELECT [SaleAccID],'CardOtherSale' as [tbl] FROM [dbo].[CardOtherSale] WHERE [SaleAccID] = " + ID +
            //             " UNION ALL" +
            //             " SELECT [PurAccID], 'CardTicketSale' as [tbl] FROM [dbo].[CardTicketSale] WHERE [PurAccID] = " + ID +
            //             " UNION ALL" +
            //             " SELECT [SaleAccID], 'CardTicketSale' as [tbl] FROM [dbo].[CardTicketSale] WHERE [SaleAccID] = " + ID +
            //             " UNION ALL" +
            //             " SELECT mAccID, 'DailyCash' as [tbl] FROM [dbo].[DailyCash] WHERE mAccID = " + ID +
            //             " UNION ALL" +
            //             " SELECT sAccID, 'DailyCash' as [tbl] FROM [dbo].[DailyCash] WHERE sAccID = " + ID +
            //             " UNION ALL" +
            //             " SELECT [Paidto], 'Expense' as [tbl] FROM [dbo].[Expense] WHERE [Paidto] = " + ID +
            //             " UNION ALL" +
            //             " SELECT [PaidFROM], 'Expense' as [tbl] FROM [dbo].[Expense] WHERE [PaidFROM] = " + ID +
            //             " UNION ALL" +
            //             " SELECT [Paidto], 'GeneralJournalDetail' as [tbl] FROM [dbo].[GeneralJournalDetail] WHERE [Paidto] = " + ID +
            //             " UNION ALL" +
            //             " SELECT AccID, 'Payment' as [tbl] FROM [dbo].[Payment] WHERE [AccID] = " + ID +
            //             " UNION ALL" +
            //             " SELECT [BankAcc], 'Receipt' as [tbl] FROM [dbo].[Receipt] WHERE [BankAcc] = " + ID +
            //             " UNION ALL" +
            //             " SELECT PaidFROM, 'Refund' as [tbl] FROM [dbo].[Refund] WHERE [PaidFROM] = " + ID +
            //             "";

            //SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            //sDA.Fill(dataTable);
            return dataTable;
        }
        public bool IsAccIDExist(int AccID, int ID)
        {
            bool IsExist = false;
            try
            {
                string qry = "SELECT TOP 1 [AccID]" +
                             " FROM [dbo].[Account]" +
                             " WHERE [AccID] = " + AccID + " AND ID <> " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult == null)
                        IsExist = false;
                    else if (xResult != DBNull.Value)
                        IsExist = true;
                }
            }
            catch { }
            return IsExist;
        }
        public string getAccountTitle(int ID)
        {
            string AccountTitle = "";
            try
            {
                string qry = "SELECT [AccName] = (SELECT AccName FROM [dbo].[AutoFluentAccounts] WHERE AccID =  [Acc].AccTypeID) + ' : '+ [Acc].[AccName]" +
                             " FROM [dbo].[AutoFluentAccounts] [Acc]" +
                             " WHERE ID = " + ID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        AccountTitle = Convert.ToString(xResult);
                }
            }
            catch { }
            return AccountTitle;
        }
        public int getAccID()
        {
            int maxNo = 0;
            try
            {
                string qry = "SELECT TOP 1 [AccID] FROM [dbo].[Account]" +
                             //" WHERE [AccTypeID] = " + AccID +
                             " Order by [AccID] Desc";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        maxNo = Convert.ToInt32(xResult);
                }
                //if (maxNo <= 0)
                //{
                //    if (AccID.ToString().Length == 1)
                //        maxNo = Convert.ToInt32(Convert.ToString(AccID) + Convert.ToString("1"));
                //    if (AccID.ToString().Length == 2)
                //        maxNo = Convert.ToInt32(Convert.ToString(AccID) + Convert.ToString("01"));
                //    if (AccID.ToString().Length == 4)
                //        maxNo = Convert.ToInt32(Convert.ToString(AccID) + Convert.ToString("001"));
                //}
                //else
                maxNo += 1;
            }
            catch { }
            return maxNo;
        }
        public int getAccID(string AccName)
        {
            int AccID = 0;
            try
            {
                string qry = "SELECT [AccID] FROM [dbo].[Account] WHERE AccTypeID = 0 and [AccName] = '" + AccName + "'";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        AccID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return AccID;
        }

        //-------Login-------------------------------//
        public DataTable GetLoginAuthonticatioin(DataTable dataTable, string LoginName)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [" + dataTable.TableName + "] WHERE [LoginName] = '" + LoginName + "'";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public int AddUserLoginDetail(int LoginID, string LoginDate, string LoginTime)
        {
            int NextID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.AddUserLoginDetail", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NextID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@LoginID", SqlDbType.Int);
                cmd.Parameters["@LoginID"].Value = LoginID;

                cmd.Parameters.Add("@LoginDate", SqlDbType.VarChar);
                cmd.Parameters["@LoginDate"].Value = LoginDate;

                cmd.Parameters.Add("@LoginTime", SqlDbType.VarChar);
                cmd.Parameters["@LoginTime"].Value = LoginTime;

                conn.Open();
                cmd.ExecuteNonQuery();

                NextID = Convert.ToInt32(cmd.Parameters["@NextID"].Value);
                conn.Close();
            }
            return NextID;
        }
        public int UpdateUserLoginDetail(int LoginID, string UpdatedTime)
        {
            int NextID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdateUserLoginDetail", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoginID", SqlDbType.Int);
                cmd.Parameters["@LoginID"].Value = LoginID;

                cmd.Parameters.Add("@UpdatedTime", SqlDbType.VarChar);
                cmd.Parameters["@UpdatedTime"].Value = UpdatedTime;

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            return NextID;
        }
        public string getUpdatedTime(int ID)
        {
            string UpdatedTime = "";
            string qry = "SELECT [UpdatedTime] FROM [dbo].[UserLoginDetail] WHERE [ID] = " + ID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    UpdatedTime = Convert.ToString(xResult);
            }
            return UpdatedTime;
        }
        public string getUserInitial(int EmpID)
        {
            string EmployeeName = "";
            string qry = "SELECT [Initial] FROM [dbo].[Employee] WHERE [ID] = " + EmpID + "";
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    EmployeeName = Convert.ToString(xResult);
            }
            return EmployeeName;
        }
        public bool isUserNameDuplicate(string userName, int userLoginID)
        {
            bool result = false;
            try
            {
                string qry = "SELECT [ID] FROM [dbo].[UserLogin] WHERE [LoginName] = '" + userName + "' and [UserLoginID] <> " + userLoginID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    result = Convert.ToBoolean(xResult);
                }
            }
            catch { }
            return result;
        }

        //-------Employee-------------------------------//
        public DataTable GetEmployeeByUserLoginID(DataTable dataTable, int UserLoginID)
        {
            dataTable.Clear();
            string Qry = "SELECT * FROM [Employee] WHERE [ID] = " + UserLoginID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable FillEmployeeList(DataTable dt)
        {
            string Qry = "SELECT [ID], [Name]" +
                         " FROM [dbo].[Employee]" +
                         " WHERE [Active] = 1" +
                         " Order by [Name]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }

        //-------Image-------------------------------//
        public DataTable LoadImage(string tableName, string ColumnName, int ID)
        {
            DataTable dt = new DataTable();
            string Qry = "SELECT * FROM [dbo].[" + tableName + "] WHERE [" + ColumnName + "] = " + ID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);
            return dt;
        }
        public void RemoveImage(string tableName, string ColumnName, int ID)
        {
            try
            {
                string Qry = "Delete FROM [dbo].[" + tableName + "] WHERE [" + ColumnName + "] = " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public void UpdateImage(string tableName, string SetColumnName, string ColumnName, int ID, byte[] Image)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    string Qry = "UPDATE [dbo].[" + tableName + "]" +
                                 " SET [" + SetColumnName + "] = @Image" +
                                 " WHERE [" + ColumnName + "] = @ID";

                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    sqlCmd.Parameters.Add(new SqlParameter("@Image", Image));
                    sqlCmd.Parameters.Add(new SqlParameter("@ID", ID));
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

            }
            catch { }
        }
        public void SaveImage(string tableName, string SetColumnName, string ColumnName, int ID, byte[] Image)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    string Qry = "INSERT INTO [dbo].[" + tableName + "]" +
                                 " ([" + ColumnName + "] ,[" + SetColumnName + "] )" +
                                 " VALUES (@ID ,@Image)";
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    sqlCmd.Parameters.Add(new SqlParameter("@Image", Image));
                    sqlCmd.Parameters.Add(new SqlParameter("@ID", ID));
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

            }
            catch { }
        }
        public void RemoveImage(string tableName, string SetColumnName, string ColumnName, int ID)
        {
            try
            {
                //string Qry = "Delete FROM [dbo].[" + tableName + "] WHERE [" + ColumnName + "] = " + ID;
                string Qry = "UPDATE [dbo].[" + tableName + "]" +
                             " SET [" + SetColumnName + "] = null" +
                             " WHERE [" + ColumnName + "] = " + ID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }

        //-------Purchase and PurchaseOrder-------------------------------//
        public DataTable FillPurchaseOrdersByVendorID(DataTable dt, int VendorID)
        {
            dt.Clear();

            //string Qry = "SELECT [PO].[ID] ,[PO].[VendorID] ,[PO].[POID] ,[PO].[PODate] ,[PO].[Reference] ,[PO].[Notes] "+
            //             " ,[PO].[AddUserID] ,[emp].[Initial] [Rep] ,[PO].[DiscountPer] ,[PO].[LastReceivedDate] "+
            //             " ,[Status] = CASE [PO].[IsDone] WHEN 1 THEN 'Completed' ELSE 'Pending' END"+
            //             " ,[PO].[StoreID] ,[str].[Name] [Store] ,[PO].[Active] ,[PO].[AddDate] ,[PO].[IsLocked] " +
            //             " FROM [dbo].[PurchaseOrder] [PO]"+
            //             " Left Join [dbo].[Employee] [emp] ON [PO].[AddUserID] = [emp].ID"+
            //             " Left Join [dbo].[WarehouseStore] [str] ON [PO].[StoreID] = [str].ID"+
            //             " WHERE [PO].[VendorID] = " + VendorID + " Order by [PO].ID desc";

            string Qry = "SELECT [PO].*" +
                         " ,[emp].[Initial] [Rep]" +
                         " ,[Status] = CASE [PO].[IsDone] WHEN 1 THEN 'Completed' ELSE 'Pending' END" +
                         " ,[str].[CoName] [Store]" +
                         " FROM [dbo].[PurchaseOrder] [PO]" +
                         " Left Join [dbo].[Employee] [emp] ON [PO].[AddUserID] = [emp].ID" +
                         " Left Join [dbo].[WarehouseStore] [str] ON [PO].[StoreID] = [str].ID" +
                         " WHERE [PO].[VendorID] = " + VendorID + " Order by [PO].ID desc";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillPurchaseOrderDetailsByPOID(DataTable dt, int POID)
        {
            dt.Clear();

            string Qry = "SELECT [PODetail].[ID] ,[PODetail].[MID] ,[PODetail].[ItemID] ,[Itm].[Catalog] [Catalog] ,[Itm].[Name] [Description] " +
                         ",[PODetail].[QtyOrdrd] ,[PODetail].[PrevOrdrd] ,[PODetail].[QtyRcvd] ,[PODetail].[PrevRcvd] ,[PODetail].[QtyBilled] " +
                         ",[PODetail].[PrevBilled] ,[PODetail].[Cost] ,[PODetail].[FET] ,[PODetail].[Amount] " +
                         ",[PODetail].[Active] ,[PODetail].[AddDate] ,[PODetail].[AddUserID] ,[PODetail].[IsLocked]" +
                         " FROM [dbo].[PurchaseOrderDetails] [PODetail]" +
                         " Left Join [dbo].[Item] [Itm] ON [PODetail].[ItemID] = [Itm].[ID]" +
                         " WHERE MID = " + POID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable getBackOrders(int ItemID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [PODetail].[ItemID]" +
                         " ,(SUM(ISNULL([PODetail].[QtyOrdrd],0) + ISNULL([PODetail].[PrevOrdrd],0)) - SUM(ISNULL([PODetail].[QtyRcvd],0) + ISNULL([PODetail].[PrevRcvd],0))) [BO]" +
                         " FROM [dbo].[PurchaseOrderDetails] [PODetail]" +
                         " WHERE [PODetail].[ItemID] = " + ItemID +
                         " Group by [PODetail].[ItemID]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable getOnOrderInventoryInfo(int ItemID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [PODetail].[MID] [PONo] ,[PO].[PODate] ,[PODetail].[ItemID]  ,[Itm].[Catalog] ,[Itm].[Name] [ItemName]" +
                         " ,(SUM(ISNULL([PODetail].[QtyOrdrd],0) + ISNULL([PODetail].[PrevOrdrd],0)) - SUM(ISNULL([PODetail].[QtyRcvd],0) + ISNULL([PODetail].[PrevRcvd],0))) [BO]" +
                         " ,SUM(ISNULL([PODetail].[QtyOrdrd],0) + ISNULL([PODetail].[PrevOrdrd],0)) [QtyOrdrd]" +
                         " ,SUM(ISNULL([PODetail].[QtyRcvd],0) + ISNULL([PODetail].[PrevRcvd],0)) [QtyRcvd]" +
                         " ,SUM(ISNULL([PODetail].[QtyBilled],0)) [QtyBilled]" +
                         " ,[PO].[VendorID] ,[Ven].[Name] [VendorName]" +
                         " FROM [dbo].[PurchaseOrderDetails] [PODetail]" +
                         " Left Join [dbo].[PurchaseOrder] [PO] ON [PODetail].[MID] = [PO].ID" +
                         " Left Join [dbo].[Vendor] [Ven] ON [PO].VendorID = [Ven].ID" +
                         " Left Join [dbo].[Item] [Itm] ON [Itm].[ID] = [PODetail].[ItemID]" +
                         " WHERE [PODetail].[ItemID] = " + ItemID +
                         " Group by [PODetail].[MID],[PO].[PODate] ,[PO].[VendorID] ,[Ven].[Name] ,[PODetail].[ItemID] ,[Itm].[Catalog],[Itm].[Name]";


            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillPurchaseOrderDetails(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT PORD.*, Itm.[ItemSize], Itm.[Catalog], Itm.[Name]" +
                         " FROM [dbo].[PORDetail] PORD" +
                         " Join [dbo].[Item] Itm on PORD.ItemID = Itm.ID";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        //-----------Vendor Bills---------------------------//
        public void UpdateVendorBill(int ID, decimal BillDiscount, decimal PaidAmount, decimal Balance, bool IsPaid, string BillType)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdateVendorBill", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = ID;

                cmd.Parameters.Add("@IsPaid", SqlDbType.Bit);
                cmd.Parameters["@IsPaid"].Value = IsPaid;

                cmd.Parameters.Add("@BillDiscount", SqlDbType.Decimal);
                cmd.Parameters["@BillDiscount"].Value = BillDiscount;

                cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
                cmd.Parameters["@PaidAmount"].Value = PaidAmount;

                cmd.Parameters.Add("@Balance", SqlDbType.Decimal);
                cmd.Parameters["@Balance"].Value = Balance;

                cmd.Parameters.Add("@ModifyUserID", SqlDbType.Int);
                cmd.Parameters["@ModifyUserID"].Value = StaticInfo.userid;

                cmd.Parameters.Add("@Type", SqlDbType.VarChar);
                cmd.Parameters["@Type"].Value = BillType;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        public DataTable FillVendorBillsByVendorID(DataTable dt, int VendorID)
        {
            dt.Clear();

            string Qry = "SELECT [VB].[ID] ,[Type] = CASE [VB].[BillType] WHEN 'B' THEN 'Bill' ELSE 'Payment' END" +
                         " ,[VB].[BillID] ,[VB].[BillDate] ,[VB].[DueDate]" +
                         " ,[VB].[InvoiceNo] [Reference] ,[VB].[BillNotes] [Notes]" +
                         " ,trm.Name [Terms] ,[VB].[GridTotalQty] [BillQty],[VB].[BillTotalAmount] ,[VB].BillTotalAmount [Open Amount]" +
                         " ,[str].[CoName] [Store] ,[emp].[Initial] [Rep]" +
                         " ,[Status] = CASE [VB].[BillStatus] WHEN 'R' THEN 'Ready' ELSE CASE [VB].[BillStatus] WHEN 'H' THEN 'Hold' ELSE CASE [VB].[BillStatus] WHEN 'P' THEN 'Posted' ELSE 'Locked' END END END" +
                         " ,[VB].[VendorID] ,[VB].[POID] ,[VB].[BillFreight] ,[VB].[BillPayFreightToID],[Frgt].Name [BillPayFreightTo] ,[VB].[IsAdjustInvCosts] ,[VB].[SaleTaxDiscountPercent] ,[VB].[SaleTaxDiscountPrice]" +
                         " ,[VB].[SaleTaxSurchargePercent] ,[VB].[SaleTaxSurchargePrice] ,[VB].[GridTotalQty] ,[VB].[GridTotalAmount]" +
                         " ,[VB].[BillStatus] ,[VB].[BillType] ,[VB].[StoreID] ,[VB].[Active] ,[VB].[AddDate] ,[VB].[AddUserID] ,[VB].[ModifyUserID]" +
                         " ,[VB].[ModifyDate] ,[VB].[Comments] ,[VB].[IsLocked] ,[VB].[DocNo] ,[VB].[Remarks] ,[VB].[CoFinEndYear] ,[VB].[TrnsVrNo] ,[VB].[TrnsJrRef]" +
                         " ,[VB].[SaleTaxPercent] ,[VB].[SaleTaxAmount]" +
                         " FROM [dbo].[VendorBill] [VB]" +
                         " Left Join [dbo].[Employee] [emp] ON [VB].[AddUserID] = [emp].ID" +
                         " Left Join [dbo].[WarehouseStore] [str] ON [VB].[StoreID] = [str].ID" +
                         " Left Join [dbo].[Vendor] [Ven] ON [VB].VendorID = Ven.ID" +
                         " Left Join [dbo].[Vendor] [Frgt] ON [VB].[BillPayFreightToID] = [Frgt].ID" +
                         " Left Join [dbo].[Terms] [trm] ON ven.TermsID = trm.ID" +
                         " WHERE [VB].[VendorID] = " + VendorID + " Order by [VB].ID desc";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorBillsListByVendorID(int VenID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT Top(10) * FROM [dbo].[VendorBill] Where IsPaid=0 [VendorID] = " + VenID + "order by ID desc";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillVendorBillsList()
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * " +
                         " FROM [dbo].[VendorBill]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillVendorBillDetailsByVBID(DataTable dt, int VBID)
        {
            dt.Clear();

            string Qry = "SELECT * FROM [dbo].[VendorBillDetails]" +
                         " WHERE MID = " + VBID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorBillsByVendorIDforPayments(DataTable dt, int VendorID)
        {
            dt.Clear();

            string Qry = "SELECT [VB].[ID] ,[VB].[BillID] ,[VB].[VendorID] ,[VB].[BillDate] ,[VB].[DueDate] ,[VB].[InvoiceNo] [Reference] ,[VB].[BillNotes] [Notes] "+
                         " , trm.Name[Terms]"+
                         " ,[BillTotalAmount]  = isnull([VB].BillTotalAmount,0) "+
                         " ,[BillDiscount]  = (SELECT isnull(SUM(ISNULL([BillDiscount], 0)),0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID])"+
                         " ,[TotalPaidAmount] = (SELECT isnull(SUM(ISNULL(PaidAmount, 0)), 0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID])"+
                         " ,[Payable] = isnull([VB].BillTotalAmount,0) -(SELECT isnull(SUM(ISNULL([BillDiscount], 0)),0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID]) -(SELECT isnull(SUM(ISNULL(PaidAmount, 0)), 0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID])"+
                         " ,[Discount] = 0"+
                         " ,0.00[To Pay]"+
                         " ,[Balance] = isnull([VB].BillTotalAmount,0) -(SELECT isnull(SUM(ISNULL([BillDiscount], 0)),0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID]) -(SELECT isnull(SUM(ISNULL(PaidAmount, 0)), 0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID])"+
						 " ,[Type] = case when(isnull([VB].BillTotalAmount, 0) - (SELECT isnull(SUM(ISNULL([BillDiscount], 0)),0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID]) -(SELECT isnull(SUM(ISNULL(PaidAmount, 0)), 0) FROM[dbo].[VendorPayment] WHERE[BillID] = [VB].[BillID])) > 0 then 'Bill' else 'Payment' end"+
                         " ,[emp].[Initial][Rep] ,[str].[CoName][Store] ,[VB].[Active] ,[VB].[AddDate] ,[VB].[AddUserID] ,[VB].[ModifyUserID] ,[VB].[ModifyDate] ,[VB].[Comments] ,[VB].[IsLocked] ,[VB].[DocNo] ,[VB].[Remarks] ,[VB].[CoFinEndYear] ,[VB].[TrnsVrNo] ,[VB].[TrnsJrRef]"+
                         " FROM[dbo].[VendorBill][VB]"+
                         " Left Join[dbo].[Employee] [emp] ON[VB].[AddUserID] = [emp].ID"+
                         " Left Join[dbo].[WarehouseStore] [str] ON[VB].[StoreID] = [str].ID"+
                         " Left Join[dbo].[Vendor] [Ven] ON[VB].VendorID = Ven.ID"+
                         " Left Join[dbo].[Vendor] [Frgt] ON[VB].[BillPayFreightToID] = [Frgt].ID"+
                         " Left Join[dbo].[Terms] [trm] ON ven.TermsID = trm.ID"+
                         " WHERE [VB].[VendorID] = " + VendorID + " Order by[VB].ID desc";

            //string Qry = "SELECT [VB].[ID] ,[VB].[BillID] ,[VB].[VendorID] ,[VB].[BillDate] ,[VB].[DueDate] ,[VB].[InvoiceNo] [Reference] ,[VB].[BillNotes] [Notes]" +
            //             " ,trm.Name [Terms]" +
            //             " ,[BillTotalAmount]  = isnull([VB].BillTotalAmount,0) " +
            //             " ,[BillDiscount]  = (SELECT isnull(SUM(ISNULL([BillDiscount],0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID])" +
            //             " ,[TotalPaidAmount] = (SELECT isnull(SUM(ISNULL(PaidAmount,0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID])" +
            //             " ,[Payable] = isnull([VB].BillTotalAmount,0) - (SELECT isnull(SUM(ISNULL([BillDiscount],0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID]) - (SELECT isnull(SUM(ISNULL(PaidAmount,0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID])" +
            //             " ,[Discount] = 0" +
            //             " ,0.00 [To Pay]" +
            //             " ,[Balance] = isnull([VB].BillTotalAmount,0) - (SELECT isnull(SUM(ISNULL([BillDiscount],0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID]) - (SELECT isnull(SUM(ISNULL(PaidAmount,0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID])" +
            //             " ,[emp].[Initial] [Rep] ,[str].[CoName] [Store] ,[VB].[Active] ,[VB].[AddDate] ,[VB].[AddUserID] ,[VB].[ModifyUserID] ,[VB].[ModifyDate] ,[VB].[Comments] ,[VB].[IsLocked] ,[VB].[DocNo] ,[VB].[Remarks] ,[VB].[CoFinEndYear] ,[VB].[TrnsVrNo] ,[VB].[TrnsJrRef]" +
            //             " FROM [dbo].[VendorBill] [VB]" +
            //             " Left Join [dbo].[Employee] [emp] ON [VB].[AddUserID] = [emp].ID" +
            //             " Left Join [dbo].[WarehouseStore] [str] ON [VB].[StoreID] = [str].ID" +
            //             " Left Join [dbo].[Vendor] [Ven] ON [VB].VendorID = Ven.ID" +
            //             " Left Join [dbo].[Vendor] [Frgt] ON [VB].[BillPayFreightToID] = [Frgt].ID" +
            //             " Left Join [dbo].[Terms] [trm] ON ven.TermsID = trm.ID" +
            //              " WHERE ( isnull([VB].BillTotalAmount,0) - (SELECT isnull(SUM(ISNULL([BillDiscount],0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID]) - (SELECT isnull(SUM(ISNULL(PaidAmount,0)),0) FROM [dbo].[VendorPayment] WHERE [BillID] = [VB].[BillID])) > 0" +
            //             //" WHERE [VB].[Balance] > 0 AND [VB].[IsProcessed]=0 " +
            //             " AND [VB].[VendorID] = " + VendorID + " Order by [VB].ID desc";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorPaymentHistoryPaymentByVendorID(int VenID)
        {
            DataTable dt = new DataTable();

            string Qry = "Select VendorPaymentHistory.ID, VendorPaymentHistory.PaymentID, VendorPaymentHistory.VendorID, VendorPaymentHistory.TrnsDate, VendorPaymentHistory.InvoiceNo, VendorPaymentHistory.PaidAmount, VendorPaymentHistory.CompanyID," +
                        " Type= Case When VendorPaymentHistory.Active=1 then 'Payment' else 'Void' End, VendorPaymentHistory.WarehouseID, VendorPaymentHistory.StoreID, VendorPaymentHistory.AddDate, VendorPaymentHistory.AddUserID, VendorPaymentHistory.IsLocked, WarehouseStore.CoName," +
                        " (Select STUFF((SELECT  ', ' + cast(VendorBill.InvoiceNo As VARCHAR) FROM  VendorBill" +
                        " Where CHARINDEX(',' + CAST(VendorBill.BillID as varchar(50)) + ',', VendorPaymentHistory.BillIDs) > 0 FOR XML PATH('')), 1, 1, '')) As BillIDs" +
                        " From VendorPaymentHistory Left Outer Join WarehouseStore ON VendorPaymentHistory.StoreID = WarehouseStore.ID" +
                        " WHERE VendorPaymentHistory.VendorID = " + VenID + " AND VendorPaymentHistory.Active=1  Order by VendorPaymentHistory.PaymentID DESC";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorPaymentHistoryVoidByVendorID(int VenID)
        {
            DataTable dt = new DataTable();

            string Qry = "Select VendorPaymentHistory.ID, VendorPaymentHistory.PaymentID, VendorPaymentHistory.VendorID, VendorPaymentHistory.TrnsDate, VendorPaymentHistory.InvoiceNo, VendorPaymentHistory.PaidAmount, VendorPaymentHistory.CompanyID," +
                        " Type= Case When VendorPaymentHistory.Active=1 then 'Payment' else 'Void' End, VendorPaymentHistory.WarehouseID, VendorPaymentHistory.StoreID, VendorPaymentHistory.AddDate, VendorPaymentHistory.AddUserID, VendorPaymentHistory.IsLocked, WarehouseStore.CoName," +
                        " (Select STUFF((SELECT  ', ' + cast(VendorBill.InvoiceNo As VARCHAR) FROM  VendorBill" +
                        " Where CHARINDEX(',' + CAST(VendorBill.BillID as varchar(50)) + ',', VendorPaymentHistory.BillIDs) > 0 FOR XML PATH('')), 1, 1, '')) As BillIDs" +
                        " From VendorPaymentHistory Left Outer Join WarehouseStore ON VendorPaymentHistory.StoreID = WarehouseStore.ID" +
                        " WHERE VendorPaymentHistory.VendorID = " + VenID + " AND VendorPaymentHistory.Active=0  Order by VendorPaymentHistory.PaymentID DESC";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorPaymentHistoryAllByVendorID(int VenID)
        {
            DataTable dt = new DataTable();

            string Qry = "Select VendorPaymentHistory.ID, VendorPaymentHistory.PaymentID, VendorPaymentHistory.VendorID, VendorPaymentHistory.TrnsDate, VendorPaymentHistory.InvoiceNo, VendorPaymentHistory.PaidAmount, VendorPaymentHistory.CompanyID," +
                        " Type= Case When VendorPaymentHistory.Active=1 then 'Payment' else 'Void' End, VendorPaymentHistory.WarehouseID, VendorPaymentHistory.StoreID, VendorPaymentHistory.AddDate, VendorPaymentHistory.AddUserID, VendorPaymentHistory.IsLocked, WarehouseStore.CoName," +
                        " (Select STUFF((SELECT  ', ' + cast(VendorBill.InvoiceNo As VARCHAR) FROM  VendorBill" +
                        " Where CHARINDEX(',' + CAST(VendorBill.BillID as varchar(50)) + ',', VendorPaymentHistory.BillIDs) > 0 FOR XML PATH('')), 1, 1, '')) As BillIDs" +
                        " From VendorPaymentHistory Left Outer Join WarehouseStore ON VendorPaymentHistory.StoreID = WarehouseStore.ID" +
                        " WHERE VendorPaymentHistory.VendorID = " + VenID + "  Order by VendorPaymentHistory.PaymentID DESC";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillVendorBillAccountDetailsByVBID(DataTable dt, int VBID)
        {
            dt.Clear();

            string Qry = " SELECT VBAcc.*, acc1.AccName+':'+acc.AccName [AccName]" +
                         " FROM [dbo].[VendorBillAccountDetails] VBAcc" +
                         " Left Join dbo.AutoFluentAccounts acc on VBAcc.AccID = acc.id" +
                         " Left Join dbo.AutoFluentAccounts acc1 on acc.AccTypeID = acc1.id" +
                         " WHERE BillID = " + VBID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }


        //----------Customer Invoice-------------------------------//
        public int AddCustomerPaymentTemp(int RecepitID, int CustomerID, int WOID, DateTime TrnsDate, decimal WOAmount, decimal ReceivedAmount, decimal WOBalance, bool IsProcessed)
        {
            int NextID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.AddCustomerPaymentTemp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NextID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                cmd.Parameters["@ReceiptID"].Value = RecepitID;

                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;

                cmd.Parameters.Add("@WOID", SqlDbType.Int);
                cmd.Parameters["@WOID"].Value = WOID;

                cmd.Parameters.Add("@TrnsDate", SqlDbType.Date);
                cmd.Parameters["@TrnsDate"].Value = TrnsDate;

                cmd.Parameters.Add("@WOAmount", SqlDbType.Decimal);
                cmd.Parameters["@WOAmount"].Value = WOAmount;

                cmd.Parameters.Add("@WOBalance", SqlDbType.Decimal);
                cmd.Parameters["@WOBalance"].Value = WOBalance;

                cmd.Parameters.Add("@ReceivedAmount", SqlDbType.Decimal);
                cmd.Parameters["@ReceivedAmount"].Value = ReceivedAmount;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                cmd.Parameters.Add("@CoFinEndYear", SqlDbType.Int);
                cmd.Parameters["@CoFinEndYear"].Value = StaticInfo.CoFinEndYear;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters["@CompanyID"].Value = StaticInfo.CompanyID;

                cmd.Parameters.Add("@WarehouseID", SqlDbType.Int);
                cmd.Parameters["@WarehouseID"].Value = StaticInfo.WarehouseID;

                cmd.Parameters.Add("@StoreID", SqlDbType.Int);
                cmd.Parameters["@StoreID"].Value = StaticInfo.StoreID;

                cmd.Parameters.Add("@IsProcessed", SqlDbType.Bit);
                cmd.Parameters["@IsProcessed"].Value = IsProcessed;

                conn.Open();
                cmd.ExecuteNonQuery();
                NextID = Convert.ToInt32(cmd.Parameters["@NextID"].Value);
                conn.Close();
            }
            return NextID;
        }

        public void AddCustomerReceipt(int RecepitID, int CustomerID, int WOID, string InvoiceNo, DateTime TrnsDate, decimal ReceivedAmount)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.AddCustomerReceipt", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReceiptID", SqlDbType.Int);
                cmd.Parameters["@ReceiptID"].Value = RecepitID;

                cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                cmd.Parameters["@CustomerID"].Value = CustomerID;

                cmd.Parameters.Add("@WOID", SqlDbType.Int);
                cmd.Parameters["@WOID"].Value = WOID;

                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar);
                cmd.Parameters["@InvoiceNo"].Value = InvoiceNo;

                cmd.Parameters.Add("@TrnsDate", SqlDbType.Date);
                cmd.Parameters["@TrnsDate"].Value = TrnsDate;

                cmd.Parameters.Add("@ReceivedAmount", SqlDbType.Decimal);
                cmd.Parameters["@ReceivedAmount"].Value = ReceivedAmount;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                cmd.Parameters.Add("@CoFinEndYear", SqlDbType.Int);
                cmd.Parameters["@CoFinEndYear"].Value = StaticInfo.CoFinEndYear;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters["@CompanyID"].Value = StaticInfo.CompanyID;

                cmd.Parameters.Add("@WarehouseID", SqlDbType.Int);
                cmd.Parameters["@WarehouseID"].Value = StaticInfo.WarehouseID;

                cmd.Parameters.Add("@StoreID", SqlDbType.Int);
                cmd.Parameters["@StoreID"].Value = StaticInfo.StoreID;

                conn.Open();
                cmd.ExecuteNonQuery();                
                conn.Close();
            }
           
        }
        public void UpdatePurchaseOrder(int POID, int IsDone)
        {
            try
            {

                string Qry = "UPDATE [dbo].[PurchaseOrder]" +
                             " SET [IsDone] = " + IsDone +
                             " , [LastReceivedDate] = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                             " , [LastReceivedBy] = " + StaticInfo.userid +
                             " WHERE [POID] = " + POID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public void UpdatePurchaseOrderDone(int POID, int IsDone)
        {
            try
            {

                string Qry = "UPDATE [dbo].[PurchaseOrder]" +
                             " SET [IsDone] = " + IsDone +
                             //" , [LastReceivedDate] = '" + DateTime.Now.ToShortDateString() + "'" +
                             //" , [LastReceivedBy] = " + StaticInfo.userid +
                             " WHERE [ID] = " + POID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public DataTable getCustomerPaymentTempByCustomerIDAndPaymentID(int CustomerID, int RecID)
        {
            DataTable dt = new DataTable();

            string Qry = " SELECT * FROM [dbo].[CustomerPaymentTemp]" +
                         " WHERE CustomerID = " + CustomerID +" AND ReceiptID=" + RecID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public void UpdateCustomerPaymentTemp(int ReceiptID)
        {
            try
            {

                string Qry = "UPDATE [dbo].[CustomerPaymentTemp]" +
                             " SET [IsProcessed] = 1" +
                             " WHERE [ReceiptID] = " + ReceiptID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        //--------------------------------------------------------//


        //----------Vendor Payments-------------------------------//
        public int AddVendorPayment(int PaymentID, int VendorID, int BillID, string InvoiceNo, DateTime TrnsDate, string TrnsNotes, string TrnsType, decimal BillAmount, decimal BillDiscount, decimal PaidAmount, decimal BillBalance, bool IsPaid)
        {
            int NextID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.AddVendorPayment", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NextID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@PaymentID", SqlDbType.Int);
                cmd.Parameters["@PaymentID"].Value = PaymentID;

                cmd.Parameters.Add("@VendorID", SqlDbType.Int);
                cmd.Parameters["@VendorID"].Value = VendorID;

                cmd.Parameters.Add("@BillID", SqlDbType.Int);
                cmd.Parameters["@BillID"].Value = BillID;

                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar);
                cmd.Parameters["@InvoiceNo"].Value = InvoiceNo;

                cmd.Parameters.Add("@TrnsDate", SqlDbType.Date);
                cmd.Parameters["@TrnsDate"].Value = TrnsDate;

                cmd.Parameters.Add("@TrnsNotes", SqlDbType.VarChar);
                cmd.Parameters["@TrnsNotes"].Value = TrnsNotes;

                cmd.Parameters.Add("@TrnsType", SqlDbType.VarChar);
                cmd.Parameters["@TrnsType"].Value = TrnsType;

                cmd.Parameters.Add("@BillAmount", SqlDbType.Decimal);
                cmd.Parameters["@BillAmount"].Value = BillAmount;

                cmd.Parameters.Add("@BillDiscount", SqlDbType.Decimal);
                cmd.Parameters["@BillDiscount"].Value = BillDiscount;

                cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
                cmd.Parameters["@PaidAmount"].Value = PaidAmount;

                cmd.Parameters.Add("@BillBalance", SqlDbType.Decimal);
                cmd.Parameters["@BillBalance"].Value = BillBalance;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                cmd.Parameters.Add("@CoFinEndYear", SqlDbType.Int);
                cmd.Parameters["@CoFinEndYear"].Value = StaticInfo.CoFinEndYear;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters["@CompanyID"].Value = StaticInfo.CompanyID;

                cmd.Parameters.Add("@WarehouseID", SqlDbType.Int);
                cmd.Parameters["@WarehouseID"].Value = StaticInfo.WarehouseID;

                cmd.Parameters.Add("@StoreID", SqlDbType.Int);
                cmd.Parameters["@StoreID"].Value = StaticInfo.StoreID;

                cmd.Parameters.Add("@IsPaid", SqlDbType.Bit);
                cmd.Parameters["@IsPaid"].Value = IsPaid;

                conn.Open();
                cmd.ExecuteNonQuery();
                NextID = Convert.ToInt32(cmd.Parameters["@NextID"].Value);
                conn.Close();
            }
            return NextID;
        }

        //public void AddVendorPaymentHistory(int VendorID, int BillID,  decimal BillAmount,  decimal PaidAmount, decimal BillBalance, bool IsPaid)
        //{

        //    using (SqlConnection conn = new SqlConnection(this.connectionString))
        //    using (SqlCommand cmd = new SqlCommand("dbo.AddVendorPaymentHistory", conn))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;


        //        cmd.Parameters.Add("@VendorID", SqlDbType.Int);
        //        cmd.Parameters["@VendorID"].Value = VendorID;

        //        cmd.Parameters.Add("@BillID", SqlDbType.Int);
        //        cmd.Parameters["@BillID"].Value = BillID;


        //        cmd.Parameters.Add("@TrnsDate", SqlDbType.Date);
        //        cmd.Parameters["@TrnsDate"].Value = DateTime.Now;

        //        cmd.Parameters.Add("@IsPaid", SqlDbType.Bit);
        //        cmd.Parameters["@IsPaid"].Value = IsPaid;

        //        cmd.Parameters.Add("@BillAmount", SqlDbType.Decimal);
        //        cmd.Parameters["@BillAmount"].Value = BillAmount;


        //        cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
        //        cmd.Parameters["@PaidAmount"].Value = PaidAmount;

        //        cmd.Parameters.Add("@BillBalance", SqlDbType.Decimal);
        //        cmd.Parameters["@BillBalance"].Value = BillBalance;

        //        cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
        //        cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;


        //        cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
        //        cmd.Parameters["@CompanyID"].Value = StaticInfo.CompanyID;

        //        cmd.Parameters.Add("@WarehouseID", SqlDbType.Int);
        //        cmd.Parameters["@WarehouseID"].Value = StaticInfo.WarehouseID;

        //        cmd.Parameters.Add("@StoreID", SqlDbType.Int);
        //        cmd.Parameters["@StoreID"].Value = StaticInfo.StoreID;
        //        conn.Open();
        //        cmd.ExecuteNonQuery();   
        //        conn.Close();
        //    }          
        //}

        public int AddVendorPaymentTemp(int PaymentID, int VendorID, int BillID, string InvoiceNo, DateTime TrnsDate, string TrnsNotes, string TrnsType, decimal BillAmount, decimal BillDiscount, decimal PaidAmount, decimal BillBalance, bool IsProcessed)
        {
            int NextID = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.AddVendorPaymentTemp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NextID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@PaymentID", SqlDbType.Int);
                cmd.Parameters["@PaymentID"].Value = PaymentID;

                cmd.Parameters.Add("@VendorID", SqlDbType.Int);
                cmd.Parameters["@VendorID"].Value = VendorID;

                cmd.Parameters.Add("@BillID", SqlDbType.Int);
                cmd.Parameters["@BillID"].Value = BillID;

                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar);
                cmd.Parameters["@InvoiceNo"].Value = InvoiceNo;

                cmd.Parameters.Add("@TrnsDate", SqlDbType.Date);
                cmd.Parameters["@TrnsDate"].Value = TrnsDate;

                cmd.Parameters.Add("@TrnsNotes", SqlDbType.VarChar);
                cmd.Parameters["@TrnsNotes"].Value = TrnsNotes;

                cmd.Parameters.Add("@TrnsType", SqlDbType.VarChar);
                cmd.Parameters["@TrnsType"].Value = TrnsType;

                cmd.Parameters.Add("@BillAmount", SqlDbType.Decimal);
                cmd.Parameters["@BillAmount"].Value = BillAmount;

                cmd.Parameters.Add("@BillDiscount", SqlDbType.Decimal);
                cmd.Parameters["@BillDiscount"].Value = BillDiscount;

                cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
                cmd.Parameters["@PaidAmount"].Value = PaidAmount;

                cmd.Parameters.Add("@BillBalance", SqlDbType.Decimal);
                cmd.Parameters["@BillBalance"].Value = BillBalance;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                cmd.Parameters.Add("@CoFinEndYear", SqlDbType.Int);
                cmd.Parameters["@CoFinEndYear"].Value = StaticInfo.CoFinEndYear;

                cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                cmd.Parameters["@CompanyID"].Value = StaticInfo.CompanyID;

                cmd.Parameters.Add("@WarehouseID", SqlDbType.Int);
                cmd.Parameters["@WarehouseID"].Value = StaticInfo.WarehouseID;

                cmd.Parameters.Add("@StoreID", SqlDbType.Int);
                cmd.Parameters["@StoreID"].Value = StaticInfo.StoreID;

                cmd.Parameters.Add("@IsProcessed", SqlDbType.Bit);
                cmd.Parameters["@IsProcessed"].Value = IsProcessed;

                conn.Open();
                cmd.ExecuteNonQuery();
                NextID = Convert.ToInt32(cmd.Parameters["@NextID"].Value);
                conn.Close();
            }
            return NextID;
        }

        public void UpdateVendorPaymentTemp(int PaymentID)
        {
            try
            {

                string Qry = "UPDATE [dbo].[VendorPaymentTemp]" +
                             " SET [IsProcessed] = 1" +
                             " WHERE [PaymentID] = " + PaymentID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch { }
        }

        public void DeleteVendorPaymentTemp(int VendorID, int PaymentID)
        {
            string Qry = "Delete FROM [dbo].[VendorPaymentTemp] " +
            "Where [VendorID] = " + VendorID +
            " AND [PaymentID] = " + PaymentID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }

        public void UpdateVendorPaymentTempActive(int VendorID, int PaymentID)
        {
            string Qry = "Update [dbo].[VendorPaymentTemp] Set Active=0, IsPaid=0" +
            "Where [VendorID] = " + VendorID +
            " AND [PaymentID]=" + PaymentID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }
        public void UpdateVendorPaymentActive(int PaymentID, int BillID)
        {
            string Qry = "Update [dbo].[VendorPayment] Set Active=0, IsPaid=0 " +
            " Where [PaymentID] = " + PaymentID +
            " AND [BillID]="+ BillID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }

        public void UpdateVendorPaymentHistoryActive(int VendorID, int PaymentID)
        {
            string Qry = "Update [dbo].[VendorPaymentHistory] Set Active=0, IsPaid=0" +
            "Where [VendorID] = " + VendorID +
            " AND [PaymentID]=" + PaymentID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }

        public DataTable getVendorPaymentTempByVendorIDAndPaymentID(DataTable dataTable, int VendorID, int PaymentID)
        {
            // MainDataSet ds = new MainDataSet();
            MainDataSetTableAdapters.VendorPaymentHistoryTableAdapter ta = new MainDataSetTableAdapters.VendorPaymentHistoryTableAdapter();
            dataTable = ta.GetDataByVendorPaymentTemp(VendorID, PaymentID);

            return dataTable;
            //dataTable.Clear();
            //string Qry = "SELECT  * FROM [dbo].[" + dataTable.TableName + "] Where [VendorID] = " + VendorID +
            //" AND CHARINDEX(',' + cast(BillID as varchar(20)) + ',' , '" + VenBillIDs + "') > 0";
            //SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            //sDA.Fill(dataTable);
            //return dataTable;
        }

        //public DataTable getVendorPaymentTempTopByVendorIDAndBillID(DataTable dataTable, int VendorID, string VenBillIDs)
        //{
        //    MainDataSetTableAdapters.VendorPaymentHistoryTableAdapter ta = new MainDataSetTableAdapters.VendorPaymentHistoryTableAdapter();
        //    dataTable = ta.GetDataByVendorPaymentTempTop(VendorID, VenBillIDs);

        //    return dataTable;
        //}


        //-------Sale Settings-------------------------------//
        public decimal getSaleTaxRate(int saleTaxRateID, string columnName)
        {
            decimal price = 0;
            try
            {
                string qry = "SELECT ISNULL([" + columnName + "],0) FROM [dbo].[SaleTaxRates] where ID = " + saleTaxRateID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        price = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return price;
        }

        //-------WorkOrder-------------------------------// 


        public DataTable FillLatestCustomerWorkOrders()
        {
            DataTable dataTable = new DataTable();
            string Qry = " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by] ,[CustomerID] ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Invoice' THEN 'Completed' ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Invoice' THEN 'ctrCustomerReceipt' ELSE 'ctrWorkOrder' END" +
                         " ,[IsNegated], [IsLocked]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' " +
                         "  ELSE CASE WO.[IsWorkOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'WorkOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END " +
                         "  ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  " +
                         "  ELSE '' END END END ,[WO].[WorkOrderNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by] ,WO.[CustomerID] ,emp.Initial [Rep] ,WO.[PONo] ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID)" +
                         " ,WO.[Total] [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],WO.[IsNegated], WO.[IsLocked]" +
                         " FROM [dbo].[WorkOrder] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE Cast(WO.AddDate as Date) = Cast(GETDATE() as date) AND" +
                         " WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt " +
                         " where WOID = WO.ID) ) tbl" +
                         " UNION ALL" +
                         " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by] ,[CustomerID] ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Invoice' THEN 'Completed' ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Invoice' THEN 'ctrCustomerPayment' ELSE 'ctrWorkOrderNegate' END" +
                         " ,[IsNegated], [IsLocked]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNegateNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' ELSE CASE WO.[IsWorkOrderNegate] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment" +
                         " where WONID = WO.ID) THEN 'WorkOrderNegate' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID)" +
                         " THEN 'Invoice' END ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  ELSE '' END END END ,[WO].[WorkOrderNegateNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by] ,WO.[CustomerID] ,emp.Initial [Rep] ,WO.[PONo] " +                         
                         //",[PONo] = 'Negate #'+(select Convert(varchar(50), WorkOrderNo) from dbo.WorkOrder where ID = wo.WorkOrderID)" +
                         " ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = (WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID))*-1" +
                         " ,(WO.[Total]*-1) [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],[IsNegated] = 0, WO.[IsLocked]" +
                         " FROM [dbo].[WorkOrderNegate] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE Cast(WO.AddDate as Date) = Cast(GETDATE() as date) AND" +
                         " WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment" +
                         " where WONID = WO.ID)) tbl1";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);

            return dataTable;
        }
        public void DeleteCustomerPaymentTemp(int CustomerID, int ReceiptID)
        {
            string Qry = "Delete FROM [dbo].[CustomerPaymentTemp] " +
            "Where [CustomerID] = " + CustomerID +
            " AND [ReceiptID] = " + ReceiptID;
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }
        public DataTable FillSelectedWorkOrderByID(int WOID)
        {
            DataTable dataTable = new DataTable();

            string Qry = " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by] ,[ComputerIP],[CustomerID],(Select [Address] from Customer where ID=CustomerID) as CustomerAddress  ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Invoice' THEN 'Completed' ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Invoice' THEN 'ctrCustomerReceipt' ELSE 'ctrWorkOrder' END" +
                         " ,[IsNegated]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' ELSE CASE WO.[IsWorkOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt" +
                         " where WOID = WO.ID) THEN 'WorkOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID)" +
                         " THEN 'Invoice' END ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  ELSE '' END END END ,[WO].[WorkOrderNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by], WO.[ComputerIP] ,WO.[CustomerID] ,emp.Initial [Rep] ,WO.[PONo] ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID)" +
                         " ,WO.[Total] [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],WO.[IsNegated]" +
                         " FROM [dbo].[WorkOrder] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE WO.ID = " + WOID + " ) tbl" +
                         " UNION ALL" +
                         " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by], [ComputerIP],[CustomerID],(Select (FirstName+LastName) from Customer where ID=CustomerID) as CustomerName  ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Invoice' THEN 'Completed' ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Invoice' THEN 'ctrCustomerPayment' ELSE 'ctrWorkOrderNegate' END" +
                         " ,[IsNegated]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNegateNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' ELSE CASE WO.[IsWorkOrderNegate] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment" +
                         " where WONID = WO.ID) THEN 'WorkOrderNegate' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID)" +
                         " THEN 'Invoice' END ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  ELSE '' END END END ,[WO].[WorkOrderNegateNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by] , WO.[ComputerIP],WO.[CustomerID] ,emp.Initial [Rep]" +
                         " ,[PONo] = 'Negate #'+(select Convert(varchar(50), WorkOrderNo) from dbo.WorkOrder where ID = wo.WorkOrderID)" +
                         " ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = (WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID))*-1" +
                         " ,(WO.[Total]*-1) [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],[IsNegated] = 0" +
                         " FROM [dbo].[WorkOrderNegate] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE WO.ID = " + WOID + " ) tbl1";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);

            return dataTable;
        }
        public DataTable GetPaymentHistoryByCustomerID(int CustomerID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * " +
                         " FROM [dbo].[CustomerPaymentHistory] where CustomerID="+ CustomerID + "";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable FillSelectedCustomerWorkOrders(int CustomerID)
        {
            DataTable dataTable = new DataTable();

            string Qry = " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by] ,[CustomerID] ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Invoice' THEN 'Completed'  ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Invoice' THEN 'ctrCustomerReceipt' ELSE 'ctrWorkOrder' END" +
                         " ,[IsNegated], [IsLocked]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' ELSE CASE WO.[IsWorkOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt" +
                         " where WOID = WO.ID) THEN 'WorkOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID)" +
                         " THEN 'Invoice' END ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  ELSE '' END END END ,[WO].[WorkOrderNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by] ,WO.[CustomerID] ,emp.Initial [Rep] ,WO.[PONo] ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID)" +
                         " ,WO.[Total] [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],WO.[IsNegated], WO.[IsLocked]" +
                         " FROM [dbo].[WorkOrder] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE WO.CustomerID = " + CustomerID + " ) tbl" +
                         " UNION ALL" +
                         " SELECT ID ,[TransNo] ,[Date] ,[Type] ,[SaleRepID] ,[Paid by] ,[CustomerID] ,[Rep] ,[PONo] ,[Mileage] ,[VehicleID] ,[Vehicle] ,[Open Amt] ,[Total Amt] ,[MechID] ,[Mech]" +
                         " ,[Status] = CASE [Type] WHEN 'Negated Invoice' THEN 'Completed' ELSE [Status] END ,[Description] ,[SaleCategoryID] ,[Category] ,[ShipViaID] ,[ShipVia] ,[Phone] ,[StoreID] ,[Store]" +
                         " ,[ctrName] = CASE [Type] WHEN 'Negated Invoice' THEN 'ctrCustomerPayment' ELSE 'ctrWorkOrderNegate' END" +
                         " ,[IsNegated], [IsLocked]" +
                         " FROM" +
                         " (SELECT WO.[ID]" +
                         " ,[WO].[WorkOrderNegateNo] [TransNo] ,WO.[RegDate] [Date]" +
                         " ,[Type] = CASE WO.[IsQutation] WHEN 1 THEN 'Qutation' ELSE CASE WO.[IsWorkOrderNegate] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment" +
                         " where WONID = WO.ID) THEN 'WorkOrderNegate' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID)" +
                         " THEN 'Negated Invoice' END ELSE CASE WO.[IsCustomerOrder] WHEN 1 THEN CASE WHEN WO.[Total] > (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'CusOrder' WHEN WO.[Total] <= (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerReceipt where WOID = WO.ID) THEN 'Invoice' END  ELSE '' END END END ,[WO].[WorkOrderNegateNo] ,WO.[SaleRepID]" +
                         " ,cus.CompanyName [Paid by] ,WO.[CustomerID] ,emp.Initial [Rep]" +
                         //" ,[PONo] = 'Negate #'+(select Convert(varchar(50), WorkOrderNo) from dbo.WorkOrder where ID = wo.WorkOrderID)" +
                         " ,[PONo] = [WO].[PONo]" +
                         " ,WO.[Mileage] ,WO.[VehicleID]" +
                         " ,[Vehicle] = vy.Name + ' ' + vmk.Name + ' ' +vmd.Name" +
                         " ,[Open Amt] = (WO.[Total] - (select ISNULL(SUM(TotalReceivedAmount),0) from dbo.CustomerPayment where WONID = WO.ID))*-1" +
                         " ,(WO.[Total]*-1) [Total Amt]" +
                         " ,WO.[MechID] ,emp1.Initial [Mech] ,WO.[Status] ,WO.Notes [Description] ,WO.[SaleCategoryID] ,sCat.Name [Category] ,WO.[ShipViaID] ,sVia.Name [ShipVia] ,cus.Phone1 [Phone] ,WO.[StoreID] ,wStr.CoName [Store],[IsNegated] = 0, WO.[IsLocked]" +
                         " FROM [dbo].[WorkOrderNegate] [WO] Left Join dbo.Customer cus on wo.CustomerID = cus.ID Left Join dbo.Employee emp on WO.[SaleRepID] = emp.ID Left Join dbo.Vehicle veh on wo.VehicleID = veh.ID Left Join dbo.VehicleYear vy on veh.VehicleYearID = vy.ID Left Join dbo.VehicleMake vmk on veh.VehicleMakeID = vmk.ID Left Join dbo.VehicleModel vmd on veh.VehicleModelID = vmd.ID Left Join dbo.Employee emp1 on WO.[MechID] = emp1.ID Left Join dbo.SaleTaxCategory sCat on WO.[SaleCategoryID] = sCat.ID Left Join dbo.ShipVia sVia on WO.[ShipViaID] = sVia.ID Left Join dbo.WarehouseStore wStr on WO.StoreID = wStr.ID" +
                         " WHERE WO.CustomerID = " + CustomerID + " ) tbl1";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);

            return dataTable;
        }
        //public DataTable getReceiptByCustomerIDAndWorkOrderID(DataTable dataTable, int CustomerID, int WorkOrderID)
        //{
        //    dataTable.Clear();
        //    string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Where [CustomerID] = " + CustomerID + " AND WOIDs = '," + WorkOrderID + ",'";
        //    SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
        //    sDA.Fill(dataTable);
        //    return dataTable;
        //}
        public DataTable getReceiptByCustomerIDAndWorkOrderID(DataTable dataTable, int CustomerID, int WorkOrderID)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Where [CustomerID] = " + CustomerID + " AND WOID =" + WorkOrderID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public bool AddCustomerPaymentByAdmin(DataTable dt, int CustomerID)
        {
            bool status = false;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    SqlConnection SqlCnn = new SqlConnection(this.connectionString);
                    SqlCnn.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO [dbo].[CustomerPaymentByAdmin] (CustomerID,WOID,InvoiceNo,TrnsDate,TrnsNotes," +
                        "ChgOnAccount,PayByCash,PaybyCheck,CheckNo,LicNo,PayByDeposit,PayByVisa,PayByMC,PayByAMEX,PayByATM,PayByGY,PayByDSCVR,TotalReceivedAmount,Active,AddDate,AddUserID,ModifyUserID,ModifyDate,Comments,IsLocked,DocNo,Remarks,CompanyID,WarehouseID,StoreID) " +
                                             "VALUES(@CustomerID,@WOID,@InvoiceNo,@TrnsDate,@TrnsNotes," +
                                             "@ChgOnAccount,@PayByCash,@PaybyCheck,@CheckNo,@LicNo,@PayByDeposit,@PayByVisa,@PayByMC,@PayByAMEX,@PayByATM,@PayByGY,@PayByDSCVR,@TotalReceivedAmount,@Active,@AddDate,@AddUserID,@ModifyUserID,@ModifyDate,@Comments,@IsLocked,@DocNo,@Remarks,@CompanyID,@WarehouseID,@StoreID)", SqlCnn);

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@WOID", dt.Rows[0]["WOID"]);
                    command.Parameters.AddWithValue("@InvoiceNo", dt.Rows[0]["InvoiceNo"]);
                    command.Parameters.AddWithValue("@TrnsDate", DateTime.Now);
                    command.Parameters.AddWithValue("@TrnsNotes", dt.Rows[0]["TrnsNotes"]);

                    command.Parameters.AddWithValue("@ChgOnAccount", dt.Rows[0]["ChgOnAccount"]);
                    command.Parameters.AddWithValue("@PayByCash", dt.Rows[0]["PayByCash"]);
                    command.Parameters.AddWithValue("@PaybyCheck", dt.Rows[0]["PaybyCheck"]);
                    command.Parameters.AddWithValue("@CheckNo", dt.Rows[0]["CheckNo"]);
                    command.Parameters.AddWithValue("@LicNo", dt.Rows[0]["LicNo"]);
                    command.Parameters.AddWithValue("@PayByDeposit", dt.Rows[0]["PayByDeposit"]);
                    command.Parameters.AddWithValue("@PayByVisa", dt.Rows[0]["PayByVisa"]);
                    command.Parameters.AddWithValue("@PayByMC", dt.Rows[0]["PayByMC"]);
                    command.Parameters.AddWithValue("@PayByAMEX", dt.Rows[0]["PayByAMEX"]);
                    command.Parameters.AddWithValue("@PayByATM", dt.Rows[0]["PayByATM"]);
                    command.Parameters.AddWithValue("@PayByGY", dt.Rows[0]["PayByGY"]);
                    command.Parameters.AddWithValue("@PayByDSCVR", dt.Rows[0]["PayByDSCVR"]);

                    command.Parameters.AddWithValue("@TotalReceivedAmount", dt.Rows[0]["TotalReceivedAmount"]);
                    command.Parameters.AddWithValue("@Active", 1);
                    command.Parameters.AddWithValue("@AddDate", DateTime.Now);
                    command.Parameters.AddWithValue("@AddUserID", dt.Rows[0]["AddUserID"]);

                    command.Parameters.AddWithValue("@ModifyUserID", dt.Rows[0]["ModifyUserID"]);
                    command.Parameters.AddWithValue("@ModifyDate", dt.Rows[0]["ModifyDate"]);
                    command.Parameters.AddWithValue("@Comments", dt.Rows[0]["Comments"]);
                    command.Parameters.AddWithValue("@IsLocked", dt.Rows[0]["IsLocked"]);
                    command.Parameters.AddWithValue("@DocNo", dt.Rows[0]["DocNo"]);
                    command.Parameters.AddWithValue("@Remarks", dt.Rows[0]["Remarks"]);
                    command.Parameters.AddWithValue("@CompanyID", dt.Rows[0]["CompanyID"]);
                    command.Parameters.AddWithValue("@WarehouseID", dt.Rows[0]["WarehouseID"]);
                    command.Parameters.AddWithValue("@StoreID", dt.Rows[0]["StoreID"]);

                    int temp = command.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                    return status;
                }
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return status;
            }
        }
        public DataTable getPaymentByCustomerIDAndWorkOrderID(DataTable dataTable, int CustomerID, int WorkOrderID)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Where [CustomerID] = " + CustomerID + " AND WONID = " + WorkOrderID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable getPaymentByCustomerIDAndWorkOrderNegateID(DataTable dataTable, int CustomerID, int WorkOrderNegateID)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Where [CustomerID] = " + CustomerID + " AND WONID = " + WorkOrderNegateID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable getInspectionHeads(int AccTypeID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [ID] ,[AccID] ,[AccName] [Catalog] ,[AccName] [CategoryItem] ,[AccTypeID] " +
                         ",[AccLevel],[IsRepair] = 0,[IsChange] = 0" +
                         " FROM [dbo].[InspectionHeads]" +
                         " where AccTypeID = " + AccTypeID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public string getInspectionHead(int AccTypeID)
        {
            string Catalog = "";

            string Qry = "SELECT [AccName] [Catalog] " +
                         " FROM [dbo].[InspectionHeads]" +
                         " where ID = " + AccTypeID;

            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    Catalog = Convert.ToString(xResult);
            }

            return Catalog;
        }
        public bool IsExistWorkOrderInVehicleInspection(int WorkOrderID)
        {
            bool result = false;
            try
            {
                string qry = "SELECT [ID] FROM [dbo].[VehicleInspection] WHERE [WorkOrderID] = " + WorkOrderID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    result = Convert.ToBoolean(xResult);
                }
            }
            catch { }
            return result;
        }
        public DataTable FillWorkOrderList()
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * " +
                         " FROM [dbo].[WorkOrder]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable GetDailySaleList()
        {
            DataTable dataTable = new DataTable();
            string Qry = "select  row_number() over(order by CAST(cr.AddDate AS DATE))AS [Sr No.]," +
                "CAST(cr.AddDate AS DATE) as [Report Date],CAST(cr.AddDate AS DATE) as [From Date]," +
                "CAST(cr.AddDate AS DATE) as [To Date],CONVERT(varchar, " +
                "sum(cr.TotalReceivedAmount)) as [Total Sale],(Select cast(sum(PaidAmount) as varchar) as [VenderAmount] from VendorPayment" +
                " where Cast(AddDate as date) = CAST(cr.AddDate AS DATE)) as [VenderPayment]," +
                "wo.IsLocked as Posted from [WorkOrder] wo Inner join CustomerReceipt cr on wo.ID=cr.WOID " +
                "group by CAST(cr.AddDate AS DATE),wo.IsLocked order by row_number()over(order by CAST(cr.AddDate AS DATE)) Desc";
            //string Qry = "select  row_number() over(order by CAST(wo.AddDate AS DATE))AS Rpt#,CAST(wo.AddDate AS DATE) as [Report Date],CAST(wo.AddDate AS DATE) as [From Date],CAST(wo.AddDate AS DATE) as [To Date],CONVERT(varchar, sum(Total)) as [Total Sale],wo.IsLocked as Posted from [WorkOrder] wo Inner join CustomerReceipt cr on wo.ID=cr.WOID group by CAST(wo.AddDate AS DATE),wo.IsLocked order by row_number()over(order by CAST(wo.AddDate AS DATE)) Desc";


            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable GetDailyTransactionsListbyDate(string date, string Account)
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select (Select FirstName + ' '+ LastName from Customer where ID=cr.CustomerID) as Customer,WOID AS Tran#,CR.TrnsDate as [Date],CR.TotalReceivedAmount AS Debit FROM CustomerReceipt CR inner join WorkOrderDetail wo on wo.ID = CR.ReceiptID where CAST(cr.TrnsDate as DATE)='" + date + "'";
            //string Qry = "Select wod.MID as Tran#,CAST(wo.AddDate as DATE) as [Date],wo.Comments as [Paid By],WOD.Qty,wod.[Hours],wod.Price,wod.Amount,wod.FET,wod.Price,wo.PartsPrice,wo.LaborPrice,wo.Tax,wod.Total from WorkOrderDetail wod inner join WorkOrder wo on wo.ID=wod.MID where CAST(wo.AddDate as DATE)= '" + date + "'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable GetDailyInvoicesListbyDate(string date)
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select cr.ID AS [Trans#],CR.TrnsDate as [Transaction Date],WOID AS WO#,TrnsNotes as PaidBy,(SELECT name from Employee WHERE ID=WO.AddUserID)as Rep,wo.Cost,wo.Price,CONVERT(varchar, wo.Profit)as Profit,CONVERT(varchar, wo.MarginPer) as Margin,CONVERT(varchar, CR.TotalReceivedAmount) AS TotalAmount FROM CustomerReceipt CR inner join WorkOrderDetail wo on wo.ID = CR.WOID where CAST(CR.AddDate as DATE)='" + date + "'";
            //string Qry = "Select wod.MID as Tran#,CAST(wo.AddDate as DATE) as [Date],wo.Comments as [Paid By],WOD.Qty,wod.[Hours],wod.Price,wod.Amount,wod.FET,wod.Price,wo.PartsPrice,wo.LaborPrice,wo.Tax,wod.Total from WorkOrderDetail wod inner join WorkOrder wo on wo.ID=wod.MID where CAST(wo.AddDate as DATE)= '" + date + "'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataTable GetDailyInvoiceDetailsbyDate(int ID, string date)
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select wod.MID as ID,wod.ItemID,wod.FeeID,wod.laborID,CAST(wod.AddDate as DATE) as [Date],cr.TrnsNotes as [Paid By],WOD.Qty,wod.Ctype,wod.[Hours],wod.Price,wod.Amount,wod.MarginPer as Margin,wod.FET,wod.Tax,wod.DiscAmount as Discount,wod.Total from WorkOrderDetail wod inner join CustomerReceipt cr on cr.WOID=wod.MID where wod.MID='" + ID + "' AND CAST(cr.TrnsDate as DATE)='" + date + "'";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            dataTable.Columns.Add("Catalog", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Cost", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            dataTable.Columns.Add("Mech", typeof(string));
            dataTable.Columns.Add("Rep", typeof(string));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];

                dr["Rep"] = StaticInfo.EmployeeName;
                if (dr["ItemID"].ToString() != "")
                {
                    DataTable dt = new DataTable();
                    string sQry = "Select Catalog,Name,LastCost as Cost,(Select Name from ItemGroup where ID=ItemGroupID)as [Group] from Item where Active=1 AND ID=" + dr["ItemID"] + "";
                    SqlDataAdapter sqDA = new SqlDataAdapter(sQry, this.connectionString);
                    sqDA.Fill(dt);
                    dr["Catalog"] = dt.Rows[0]["Catalog"];
                    dr["Description"] = dt.Rows[0]["Name"];
                    dr["Cost"] = dt.Rows[0]["Cost"];
                    dr["Group"] = dt.Rows[0]["Group"];
                }
                else if (dr["FeeID"].ToString() != "")
                {
                    DataTable dt = new DataTable();
                    string sQry = "Select ID,(Select Name from ItemGroup where ID=ItemGroupID)as [Group],Catalog,Name,FeePrice as Price from Fees WHERE ID= " + dr["FeeID"] + " and Active=1";
                    SqlDataAdapter sqDA = new SqlDataAdapter(sQry, this.connectionString);
                    sqDA.Fill(dt);
                    dr["Catalog"] = dt.Rows[0]["Catalog"];
                    dr["Description"] = dt.Rows[0]["Name"];
                    dr["Cost"] = dataTable.Rows[i]["Price"];
                    dr["Group"] = dt.Rows[0]["Group"];
                }
                else if (dr["laborID"].ToString() != "")
                {
                    DataTable dt = new DataTable();
                    string sQry = "Select ID,(Select Name from ItemGroup where ID=ItemGroupID)as [Group],Catalog,Name,LaborHours,LaborFees as Fee from Labor WHERE ID=" + dr["laborID"] + " and Active=1";
                    SqlDataAdapter sqDA = new SqlDataAdapter(sQry, this.connectionString);
                    sqDA.Fill(dt);
                    dr["Catalog"] = dt.Rows[0]["Catalog"];
                    dr["Description"] = dt.Rows[0]["Name"];
                    dr["Cost"] = dataTable.Rows[i]["Fee"];
                    dr["Group"] = dt.Rows[0]["Group"];
                }
            }
            //----------------------------
            return dataTable;
        }
        public DataTable GetJournalTransactions(int ID, string date)
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select SubAccount as [G/L Account],Debit,Credit from AccountJournalTransactions where wID=" + ID + "";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public bool AddNewVoucher(DataTable dt)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();
                int status = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountVoucher]([vNo],[IsAuto],[vtype],[vDate],[IsVoid],[AccountID],[BankAccountID]," +
                        "[WOID],[POID],[vforVendor],[vforCustomer],[vforEmployee],[VendorID],[CustomerID],[EmployeeID],[Narration],[PAmount],[LAmount],[FAmount],[FET]," +
                        "[Taxable],[Tax],[Discount],[Total],[vAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks]," +
                        "[CoFinEndYear],[CompanyID],[WarehouseID],[StoreID])" +

                        " VALUES (@vNo ,@IsAuto ,@vtype ,@vDate,@IsVoid ,@AccountID ,@BankAccountID ,@WOID,@POID,@vforVendor ,@vforCustomer ," +
                        "@vforEmployee ,@VendorID,@CustomerID ,@EmployeeID ,@Narration ,@PAmount,@LAmount,@FAmount,@FET,@Taxable,@Tax,@Discount,@Total,@vAmount ,@Active ,@AddDate,@AddUserID ," +
                        "@ModifyUserID,@ModifyDate,@Comments ,@IsLocked ,@DocNo ,@Remarks ,@CoFinEndYear," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + "  ," +
                        "" + StaticInfo.StoreID + ")", SqlCnn);

                    //,GETDATE() ," + StaticInfo.userid + ",@Comments ,0 ," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + " ," + StaticInfo.StoreID + ")
                    command.Parameters.AddWithValue("@vNo", dt.Rows[i]["vNo"]);
                    command.Parameters.AddWithValue("@IsAuto", dt.Rows[i]["IsAuto"]);
                    command.Parameters.AddWithValue("@vtype", dt.Rows[i]["vtype"]);
                    command.Parameters.AddWithValue("@vDate", dt.Rows[i]["vDate"]);
                    command.Parameters.AddWithValue("@IsVoid", dt.Rows[i]["IsVoid"]);
                    command.Parameters.AddWithValue("@AccountID", dt.Rows[i]["AccountID"]);
                    command.Parameters.AddWithValue("@BankAccountID", dt.Rows[i]["BankAccountID"]);

                    command.Parameters.AddWithValue("@WOID", dt.Rows[i]["WOID"]);
                    command.Parameters.AddWithValue("@POID", dt.Rows[i]["POID"]);

                    command.Parameters.AddWithValue("@vforVendor", dt.Rows[i]["vforVendor"]);
                    command.Parameters.AddWithValue("@vforCustomer", dt.Rows[i]["vforCustomer"]);
                    command.Parameters.AddWithValue("@vforEmployee", dt.Rows[i]["vforEmployee"]);


                    command.Parameters.AddWithValue("@VendorID", dt.Rows[i]["VendorID"]);
                    command.Parameters.AddWithValue("@CustomerID", dt.Rows[i]["CustomerID"]);
                    command.Parameters.AddWithValue("@EmployeeID", dt.Rows[i]["EmployeeID"]);
                    command.Parameters.AddWithValue("@Narration", dt.Rows[i]["Narration"]);

                    command.Parameters.AddWithValue("@PAmount", dt.Rows[i]["PAmount"]);
                    command.Parameters.AddWithValue("@LAmount", dt.Rows[i]["LAmount"]);
                    command.Parameters.AddWithValue("@FAmount", dt.Rows[i]["FAmount"]);
                    command.Parameters.AddWithValue("@FET", dt.Rows[i]["FET"]);
                    command.Parameters.AddWithValue("@Taxable", dt.Rows[i]["Taxable"]);
                    command.Parameters.AddWithValue("@Tax", dt.Rows[i]["Tax"]);
                    command.Parameters.AddWithValue("@Discount", dt.Rows[i]["Discount"]);
                    command.Parameters.AddWithValue("@Total", dt.Rows[i]["Total"]);

                    command.Parameters.AddWithValue("@vAmount", dt.Rows[i]["vAmount"]);
                    command.Parameters.AddWithValue("@Active", dt.Rows[i]["Active"]);
                    command.Parameters.AddWithValue("@AddDate", dt.Rows[i]["AddDate"]);
                    command.Parameters.AddWithValue("@AddUserID", dt.Rows[i]["AddUserID"]);

                    command.Parameters.AddWithValue("@Comments", dt.Rows[i]["Comments"]);
                    command.Parameters.AddWithValue("@IsLocked", dt.Rows[i]["IsLocked"]);
                    command.Parameters.AddWithValue("@DocNo", dt.Rows[i]["DocNo"]);
                    command.Parameters.AddWithValue("@ModifyUserID", dt.Rows[i]["ModifyUserID"]);
                    command.Parameters.AddWithValue("@ModifyDate", dt.Rows[i]["ModifyDate"]);

                    command.Parameters.AddWithValue("@Remarks", dt.Rows[i]["Remarks"]);
                    command.Parameters.AddWithValue("@CoFinEndYear", dt.Rows[i]["CoFinEndYear"]);
                    status = command.ExecuteNonQuery();
                    if (status != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (status != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                SqlCnn.Close();
            }
        }
        public bool AddVoucherDetails(DataTable dt, decimal Tamount, decimal Tparts, decimal TOparts, decimal Twheels, decimal Ttire, decimal TFET, decimal TFEE, decimal TLabour, decimal TOthers, decimal Ttax)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();
                int status = 0;
                int Vocherno = 0;
                int wID = 0;
                string Vochertype = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountVoucherDetails] ([vNo],[MID],[vtype],[vDate],[ItemID],[FeeID],[LabourID],[Qty],[Hours],[Price],[Cost],[Amount],[Discount],[FET],[Total],[Tax],[SubAccount]" +
                     ",[AmountIn],[AmountOut],[vforVendor],[vforCustomer],[vforEmployee],[VendorID],[CustomerID],[EmployeeID],[Narration],[vAmount],[Active],[AddDate],[AddUserID]" +
                     ",[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[Remarks],[CoFinEndYear],[CompanyID],[WarehouseID],[StoreID])" +

                        "VALUES(@vNo,@MID,@vtype ,@vDate,@ItemID,@FeeID,@LabourID,@Qty,@Hours,@Price,@Cost,@Amount,@Discount,@FET,@Total,@Tax,@SubAccount," +
                        "@AmountIn,@AmountOut,@vforVendor ,@vforCustomer ," +
                        "@vforEmployee ,@VendorID,@CustomerID ,@EmployeeID ,@Narration,@vAmount ,@Active ,@AddDate,@AddUserID ," +
                        "@ModifyUserID,@ModifyDate,@Comments ,@IsLocked ,@Remarks ,@CoFinEndYear," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + "  ," +
                        "" + StaticInfo.StoreID + ")", SqlCnn);
                    if (i == 0)
                    {
                        Vocherno = Convert.ToInt32(dt.Rows[i]["MID"]);
                        Vochertype = Convert.ToString(dt.Rows[i]["vtype"]);
                        wID = Convert.ToInt32(dt.Rows[i]["vNo"]);
                    }
                    //,GETDATE() ," + StaticInfo.userid + ",@Comments ,0 ," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + " ," + StaticInfo.StoreID + ")
                    command.Parameters.AddWithValue("@vNo", dt.Rows[i]["vNo"]);
                    command.Parameters.AddWithValue("@MID", dt.Rows[i]["MID"]);
                    command.Parameters.AddWithValue("@vtype", dt.Rows[i]["vtype"]);
                    command.Parameters.AddWithValue("@vDate", dt.Rows[i]["vDate"]);
                    command.Parameters.AddWithValue("@ItemID", dt.Rows[i]["ItemID"]);
                    command.Parameters.AddWithValue("@FeeID", dt.Rows[i]["FeeID"]);
                    command.Parameters.AddWithValue("@LabourID", dt.Rows[i]["LabourID"]);
                    command.Parameters.AddWithValue("@Qty", dt.Rows[i]["Qty"]);
                    command.Parameters.AddWithValue("@Hours", dt.Rows[i]["Hours"]);

                    command.Parameters.AddWithValue("@Price", dt.Rows[i]["Price"]);
                    command.Parameters.AddWithValue("@Cost", dt.Rows[i]["Cost"]);
                    command.Parameters.AddWithValue("@Amount", dt.Rows[i]["Amount"]);
                    command.Parameters.AddWithValue("@Discount", dt.Rows[i]["Discount"]);
                    command.Parameters.AddWithValue("@FET", dt.Rows[i]["FET"]);
                    //command.Parameters.AddWithValue("@Taxable", dt.Rows[i]["Taxable"]);
                    command.Parameters.AddWithValue("@Total", dt.Rows[i]["Total"]);
                    command.Parameters.AddWithValue("@Tax", dt.Rows[i]["Tax"]);
                    command.Parameters.AddWithValue("@SubAccount", dt.Rows[i]["SubAccount"]);

                    command.Parameters.AddWithValue("@AmountIn", dt.Rows[i]["AmountIn"]);
                    command.Parameters.AddWithValue("@AmountOut", dt.Rows[i]["AmountOut"]);

                    command.Parameters.AddWithValue("@vforVendor", dt.Rows[i]["vforVendor"]);
                    command.Parameters.AddWithValue("@vforCustomer", dt.Rows[i]["vforCustomer"]);
                    command.Parameters.AddWithValue("@vforEmployee", dt.Rows[i]["vforEmployee"]);

                    command.Parameters.AddWithValue("@VendorID", dt.Rows[i]["VendorID"]);
                    command.Parameters.AddWithValue("@CustomerID", dt.Rows[i]["CustomerID"]);
                    command.Parameters.AddWithValue("@EmployeeID", dt.Rows[i]["EmployeeID"]);
                    command.Parameters.AddWithValue("@Narration", dt.Rows[i]["Narration"]);

                    command.Parameters.AddWithValue("@vAmount", dt.Rows[i]["vAmount"]);
                    command.Parameters.AddWithValue("@Active", dt.Rows[i]["Active"]);
                    command.Parameters.AddWithValue("@AddDate", dt.Rows[i]["AddDate"]);
                    command.Parameters.AddWithValue("@AddUserID", dt.Rows[i]["AddUserID"]);

                    command.Parameters.AddWithValue("@ModifyUserID", dt.Rows[i]["ModifyUserID"]);
                    command.Parameters.AddWithValue("@ModifyDate", dt.Rows[i]["ModifyDate"]);
                    command.Parameters.AddWithValue("@Comments", dt.Rows[i]["Comments"]);
                    command.Parameters.AddWithValue("@IsLocked", dt.Rows[i]["IsLocked"]);
                    //command.Parameters.AddWithValue("@DocNo", dt.Rows[i]["DocNo"]);
                    command.Parameters.AddWithValue("@Remarks", dt.Rows[i]["Remarks"]);
                    command.Parameters.AddWithValue("@CoFinEndYear", dt.Rows[i]["CoFinEndYear"]);
                    status = command.ExecuteNonQuery();
                }
                if (status != 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (i == 0 && !string.IsNullOrEmpty(Convert.ToString(Tamount)) && Convert.ToString(Tamount) != "0")
                            {

                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Checking Account");
                                command.Parameters.AddWithValue("@Debit", Tamount);
                                command.Parameters.AddWithValue("@Credit", "0.00");
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 1 && !string.IsNullOrEmpty(Convert.ToString(Tparts)) && Convert.ToString(Tparts) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Parts");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", Tparts);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 2 && !string.IsNullOrEmpty(Convert.ToString(Twheels)) && Convert.ToString(Twheels) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Wheels");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", Twheels);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 3 && !string.IsNullOrEmpty(Convert.ToString(Ttire)) && Convert.ToString(Ttire) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Auto Tire");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", Ttire);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 4 && !string.IsNullOrEmpty(Convert.ToString(TFET)) && Convert.ToString(TFET) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "FET Asset");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", TFET);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 5 && !string.IsNullOrEmpty(Convert.ToString(TFEE)) && Convert.ToString(TFEE) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Environment FEE Payable");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", TFEE);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 6 && !string.IsNullOrEmpty(Convert.ToString(TLabour)) && Convert.ToString(TLabour) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Labour");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", TLabour);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 7 && !string.IsNullOrEmpty(Convert.ToString(TOthers)) && Convert.ToString(TOthers) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Other");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", TOthers);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 8 && !string.IsNullOrEmpty(Convert.ToString(TOparts)) && Convert.ToString(TOparts) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Outside Parts");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", TOparts);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else if (i == 9 && !string.IsNullOrEmpty(Convert.ToString(Ttax)) && Convert.ToString(Ttax) != "0")
                            {
                                SqlCommand command = new SqlCommand("INSERT INTO [AutoVault].[dbo].[AccountJournalTransactions] (vNo,wID,vtype,vDate,SubAccount,Debit,Credit,Remarks) " +
                                    "VALUES(@vNo,@wID,@vtype,@vDate,@SubAccount,@Debit,@Credit,@Remarks)", SqlCnn);
                                command.Parameters.AddWithValue("@vNo", Vocherno);
                                command.Parameters.AddWithValue("@wID", wID);
                                command.Parameters.AddWithValue("@vtype", Vochertype);
                                command.Parameters.AddWithValue("@vDate", DateTime.Now);
                                command.Parameters.AddWithValue("@SubAccount", "Sales:Tax Payable");
                                command.Parameters.AddWithValue("@Debit", "0.00");
                                command.Parameters.AddWithValue("@Credit", Ttax);
                                command.Parameters.AddWithValue("@Remarks", "");
                                int jstatus = command.ExecuteNonQuery();
                            }
                            else { }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                SqlCnn.Close();
            }
        }

        public DataTable GetInvoiceTaxbyID(int ID, string date)
        {
            DataTable dataTable = new DataTable();
            string Qry = "Select Top(1) wo.Tax,wo.IsLocked from workorder wo right outer join WorkOrderDetail wod on wo.ID=wod.MID where wod.MID='" + ID + "' AND CAST(wod.AddDate as DATE)='" + date + "'";
            //string Qry = "Select wod.MID as Tran#,CAST(wo.AddDate as DATE) as [Date],wo.Comments as [Paid By],WOD.Qty,wod.[Hours],wod.Price,wod.Amount,wod.FET,wo.LaborPrice,wo.Tax,wod.Total from WorkOrderDetail wod inner join WorkOrder wo on wo.ID=wod.MID where wod.MID='"+ ID + "' AND CAST(wo.AddDate as DATE)= '" + date + "'";
            //string strQry = ""; 
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }

        public DataTable FillWorkOrderListByCustID(int CustID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT Top(10) * FROM [dbo].[WorkOrder] Where [CustomerID] = " + CustID + "order by AddDate desc";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataRow getWorkOrderByID(int WOID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [WorkOrder] WHERE [ID] = " + WOID + "order by AddDate desc";
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataTable getWorkOrderByReceiptID(int ReceiptID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [CustomerPaymentTemp] " +
            "Where ReceiptID =" + ReceiptID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {                   
                    return dataTable;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public DataTable getWorkOrderDetailByID(int WOID)
        {
            DataTable dataTable = new DataTable();
            string Qry = " SELECT * FROM (" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,itm.[Catalog], itm.[Name]" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Item] itm on WOD.[ItemID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.ItemID is not null" +
                         " UNION ALL" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,itm.[Catalog], itm.[Name]" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Fees] itm on WOD.[FeeID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.FeeID is not null" +
                         " UNION ALL" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,itm.[Catalog], itm.[Name]" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Labor] itm on WOD.[LaborID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.LaborID is not null" +
                         " UNION ALL" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,itm.[Catalog], itm.[Name]" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[WarehousePackages] itm on WOD.[PackageID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.PackageID is not null AND WOD.Ctype = 'S'" +
                         " UNION ALL" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,[Catalog] = 'Inspection Head', [Name] = 'Inspection Head'" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.VehicleInspectionID is not null AND WOD.Ctype = 'IH'" +
                         " UNION ALL" +
                         " SELECT WOD.*,emp.Initial Mechanic, emp1.Initial Rep ,itm.[Catalog], itm.[Name]" +
                         " FROM [dbo].[WorkOrderDetail] WOD" +
                         " Left Join [dbo].[Labor] itm on WOD.[InspectionHeadID] = itm.ID" +
                         " Left Join [dbo].[Employee] emp on wod.MechanicID = emp.id" +
                         " Left Join [dbo].[Employee] emp1 on wod.RepID = emp1.id" +
                         " where WOD.InspectionHeadID is not null" +
                         " ) tbl where MID =" + WOID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);

            return dataTable;
        }
        public DataRow getWorkOrderNegateByID(int WONID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [WorkOrderNegate] WHERE [ID] = " + WONID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataTable getWOToggleColumns()
        {
            DataTable dt = new DataTable();

            string Qry = " SELECT [WOAvailableQtyToggleColumn]" +
                         " ,[WOHoursQtyToggleColumn]" +
                         " ,[WOCostQtyToggleColumn]" +
                         " ,[WODiscPerQtyToggleColumn]" +
                         " ,[WODiscAmountQtyToggleColumn]" +
                         " ,[WOIsDoneQtyToggleColumn]" +
                         " ,[WOIsTaxQtyToggleColumn]" +
                         " ,[WOMarginPerQtyToggleColumn]" +
                         " FROM [dbo].[WarehouseSettings]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public bool UpdateWorkOrderDetailsPosted(string SelectedDate)
        {
            bool IsSave = false;

            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();
                string strQry = "UPDATE [dbo].[WorkOrderDetail] SET [IsLocked] = 1 WHERE CAST(AddDate AS DATE) = '" + SelectedDate + "' UPDATE [dbo].[WorkOrder] SET [IsLocked] = 1 WHERE CAST(AddDate AS DATE) = '" + SelectedDate + "'";
                SqlCommand Cmd = new SqlCommand(strQry, SqlCnn);

                //Cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                //Cmd.Parameters["@Date"].Value = Convert.ToDateTime(SelectedDate);

                Cmd.ExecuteNonQuery();

                IsSave = true;
            }
            catch (Exception ex)
            {
                IsSave = false;
            }
            finally { SqlCnn.Close(); }
            return IsSave;
        }
        public bool UpdateWorkOrderIsNegated(int WOID)
        {
            bool IsSave = false;

            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[WorkOrder] SET [IsNegated] = 1 WHERE ID = @ID", SqlCnn);

                Cmd.Parameters.Add("@ID", SqlDbType.Int);
                Cmd.Parameters["@ID"].Value = WOID;

                Cmd.ExecuteNonQuery();
                IsSave = true;
            }
            catch { IsSave = false; }
            finally
            {
                SqlCnn.Close();
            }
            return IsSave;
        }
        public void UpdateWOToggleColumns(DataTable dt)
        {
            try
            {
                string qry = "UPDATE [dbo].[WarehouseSettings]" +
                             " SET [WOAvailableQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOAvailableQtyToggleColumn"] + "')" +
                             " ,[WOHoursQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOHoursQtyToggleColumn"] + "')" +
                             " ,[WOCostQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOCostQtyToggleColumn"] + "')" +
                             " ,[WODiscPerQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WODiscPerQtyToggleColumn"] + "')" +
                             " ,[WODiscAmountQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WODiscAmountQtyToggleColumn"] + "')" +
                             " ,[WOIsDoneQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOIsDoneQtyToggleColumn"] + "')" +
                             " ,[WOIsTaxQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOIsTaxQtyToggleColumn"] + "')" +
                             " ,[WOMarginPerQtyToggleColumn] = CONVERT(BIT, '" + dt.Rows[0]["WOMarginPerQtyToggleColumn"] + "')" +
                             " WHERE ID = (select top 1 [ID] from [dbo].[WarehouseSettings])";

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public decimal GetCustomerCreditbyCustomerID(int CustID)
        {
            decimal CreditAvail = 0;
            try
            {
                string qry = "Select(SELECT ISNULL(SUM(CusCredit), 0)" +
                             " FROM[dbo].[CustomerReceipt]" +
                             " WHERE CustomerID = " + CustID + " ) -" +
                             " (SELECT ISNULL(SUM(CusCredit), 0)" +
                             " FROM[dbo].[CustomerPayment]" +
                             " WHERE CustomerID = " + CustID + ") ";

                    //"SELECT ISNULL(SUM(CusCredit),0)" +
                    //         " FROM [dbo].[CustomerReceipt]" +
                    //         " WHERE CustomerID = " + CustID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) < 0)
                        CreditAvail = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return CreditAvail;
        }
        public decimal getCreditAvailbyCustomerID(int CustID)
        {
            decimal CreditAvail = 0;
            try
            {
                string qry = "Select(SELECT ISNULL(SUM(ChgOnAccount), 0)" +
                             " FROM[dbo].[CustomerReceipt]" +
                             " WHERE CustomerID = " + CustID + ") - (SELECT ISNULL(SUM(ChgOnAccount), 0)" +
                             " FROM[dbo].[CustomerPayment]" +
                             " WHERE CustomerID = " + CustID + ")";

                    //"SELECT ISNULL(SUM(ChgOnAccount),0)" +
                    //         " FROM [dbo].[CustomerReceipt]" +
                    //         " WHERE CustomerID = " + CustID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    //if (Convert.ToDecimal(xResult) > 0)
                        CreditAvail = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return CreditAvail;
        }
       
        public DataTable getCreditAvailListbyCustomerID(int CustID)
        {
            DataTable dt = new DataTable();
            try
            {
                string qry = "Select * from CustomerReceipt " +
                             " where ChgOnAccount != '0.00' AND CustomerID = " + CustID;

                SqlDataAdapter sDA = new SqlDataAdapter(qry, this.connectionString);
                sDA.Fill(dt);
            }
            catch { }
            return dt;
        }
        public bool UpdateCreditAvailbyID(int RID)
        {
            bool IsSave = false;
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();
                SqlCommand Cmd = new SqlCommand("Update CustomerReceipt set ChgOnAccount='0.00' where ID= '" + RID + "'", SqlCnn);
                //Cmd.Parameters.Add("@ID", SqlDbType.Int);
                //Cmd.Parameters["@ID"].Value = RID;
                int Temp = Cmd.ExecuteNonQuery();
                if (Temp > 0)
                {
                    IsSave = true;
                }
                else { IsSave = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                IsSave = false;
            }
            finally
            {
                SqlCnn.Close();
            }
            return IsSave;
        }
        public decimal getAvailableDepositbyCustomerID(int CustID)
        {
            decimal PayByDeposit = 0;
            try
            {
                string qry = " SELECT ISNULL(SUM(PayByDeposit),0)" +
                             " FROM [dbo].[CustomerReceipt]" +
                             " WHERE CustomerID = " + CustID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        PayByDeposit = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return PayByDeposit;
        }
        public decimal getCreditLimitbyCustomerID(int CustID)
        {
            decimal CreditLimit = 0;
            try
            {
                string qry = "SELECT ISNULL(CreditLimits,0)" +
                             " FROM [dbo].[Customer]" +
                             " WHERE ID = " + CustID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        CreditLimit = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return CreditLimit;
        }
        //---------Vehicles------------------------------//        
        public DataTable FillVehiclesByCustomerID(int CustID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT	 [Veh].[ID] ,[Veh].[LicensePlate]" +
                         " ,[VehYr].[Name] [Year],[VehMake].[Name] [Make],[VehModel].[Name] [Model] ,[VehColor].[Name] [Color]" +
                         " ,[Veh].[VIN] ,[Veh].[FleetNumber] ,[Veh].[StateID] ,[Veh].[Mileage] ,[Veh].[IsOwner]" +
                         " FROM [dbo].[Vehicle] [Veh]" +
                         " Left Join [dbo].[VehicleYear] [VehYr] on [Veh].[VehicleYearID] = [VehYr].ID" +
                         " Left Join [dbo].[VehicleMake] [VehMake] on [Veh].[VehicleMakeID] = [VehMake].ID" +
                         " Left Join [dbo].[VehicleModel] [VehModel] on [Veh].[VehicleModelID] = [VehModel].ID" +
                         " LEFT Join [dbo].[VehicleColor] [VehColor] on[Veh].[VehicleColorID] = [VehColor].ID" +
                         " WHERE [Veh].[CustomerID] = " + CustID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            return dataTable;
        }
        public DataRow FillVehicleID(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = " SELECT	 [Veh].[ID] ,[Veh].[LicensePlate]" +
                         " ,[VehYr].[Name] [Year],[VehMake].[Name] [Make],[VehModel].[Name] [Model] ,[VehColor].[Name] [Color]" +
                         " ,[Veh].[VIN] ,[Veh].[FleetNumber] ,[Veh].[Mileage] ,[Veh].[StateID] ,[Veh].[IsOwner]" +
                         " FROM [dbo].[Vehicle] [Veh]" +
                         " Left Join [dbo].[VehicleYear] [VehYr] on [Veh].[VehicleYearID] = [VehYr].ID" +
                         " Left Join [dbo].[VehicleMake] [VehMake] on [Veh].[VehicleMakeID] = [VehMake].ID" +
                         " Left Join [dbo].[VehicleModel] [VehModel] on [Veh].[VehicleModelID] = [VehModel].ID" +
                         " LEFT Join [dbo].[VehicleColor] [VehColor] on[Veh].[VehicleColorID] = [VehColor].ID" +
                         " WHERE [Veh].[ID] = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            //----------------------------
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public int getVehicleIDByWorkOrder(int WorkOrderID)
        {
            int VehicleID = 0;
            try
            {
                string qry = "SELECT VehicleID FROM [WorkOrder] where ID = " + WorkOrderID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        VehicleID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return VehicleID;
        }
        public int UpdateCustomerReceiptAutoNo()
        {
            int NextAutoNo = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextCustomerReceiptAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                conn.Open();
                cmd.ExecuteNonQuery();

                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }

        //-------getNextAutoNo-------------------------------//

        public int getNextCustomerReceiptAutoNo()
        {
            int ReceiptID = 0;
            try
            {
                string qry = "sELECT MAX(ReceiptID)+1 FROM  CustomerReceipt";
                             

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        ReceiptID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ReceiptID;
        }
        public int getNextCustomerPaymentAutoNo()
        {
            int NextAutoNo = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextCustomerPaymentAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

                conn.Open();
                cmd.ExecuteNonQuery();

                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }
        public int getNextWorkOrderAutoNo()
        {
            int NextAutoNo = 0;
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextWorkOrderAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;
                conn.Open();
                cmd.ExecuteNonQuery();
                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }

        public int getNextWorkOrderNegateAutoNo()
        {
            int NextAutoNo = 0;
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextWorkOrderNegateAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;
                conn.Open();
                cmd.ExecuteNonQuery();
                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }
        public int getNextPurchaseOrderAutoNo()
        {
            int NextAutoNo = 0;

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextPurchaseOrderAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;
                conn.Open();
                cmd.ExecuteNonQuery();
                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }

        public DataRow getVendorBillByID(int VBID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [VendorBill] WHERE [BillID] = " + VBID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public DataRow getVendorPaymentByID(int PaymentID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [VendorPaymentHistory] WHERE [PaymentID] = " + PaymentID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    return dataRow;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public DataTable getVendorBillByPaymentID(int PaymentID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT * FROM [VendorPaymentTemp] " +
            "Where PaymentID =" + PaymentID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    //DataRow dataRow = dataTable.Rows[0];
                    return dataTable;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public int getNextVendorBillAutoNo()
        {
            int NextAutoNo = 0; //

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.getNextVendorBillAutoNo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
                cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;
                conn.Open();
                cmd.ExecuteNonQuery();
                NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
                conn.Close();
            }
            return NextAutoNo;
        }
        public int getNextVendorPaymentAutoNo()
        {
            int NextAutoNo = 0;
            String Qry = " Select IsNull(max(ID),0) + 1 as MaxPaymentID from VendorPayment";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Qry,conn);
                object result = cmd.ExecuteScalar(); 
                conn.Close();
                if (result != DBNull.Value)
                    NextAutoNo = Convert.ToInt32(result);
            }
            
            //using (SqlConnection conn = new SqlConnection(this.connectionString))
            //using (SqlCommand cmd = new SqlCommand("dbo.getNextVendorPaymentAutoNo", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.Add("@AddUserID", SqlDbType.Int);
            //    cmd.Parameters.Add("@NextAutoNo", SqlDbType.Int).Direction = ParameterDirection.Output;

            //    cmd.Parameters["@AddUserID"].Value = StaticInfo.userid;

            //    conn.Open();
            //    cmd.ExecuteNonQuery();

            //    NextAutoNo = Convert.ToInt32(cmd.Parameters["@NextAutoNo"].Value);
            //    conn.Close();
            //}

            return NextAutoNo;
        }

        public DataTable getVendorBillByVendorIDAndVendorBillID(DataTable dataTable, int VendorID, int VendorBillID)
        {
            dataTable.Clear();
            string Qry = "SELECT TOP(1) * FROM [dbo].[" + dataTable.TableName + "] Where [VendorID] = " + VendorID + " AND WOID = " + VendorBillID;
            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public string getNextItemCode()
        {
            string ItemCode = "";

            try
            {
                string qry = "SELECT isnull(Max([ID]),0) + 1 FROM [dbo].[Item]";
                //" WHERE [IsAuto] = 1";

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        ItemCode = Convert.ToString(xResult);
                }

            }
            catch { ItemCode = ""; }
            return ItemCode;
        }
        public int getLatestWorkOrderNo()
        {
            int wCode = 0;
            try
            {
                string qry = "Select top(1)ID from WorkOrder ORDER BY ID DESC";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        wCode = Convert.ToInt32(xResult);
                }
            }
            catch { wCode = 0; }
            return wCode;
        }
        public int getLatestPerchaseOrderNo()
        {
            int wCode = 0;
            try
            {
                string qry = "Select top(1)ID from PerchaserOrder ORDER BY ID DESC";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        wCode = Convert.ToInt32(xResult);
                }
            }
            catch { wCode = 0; }
            return wCode;
        }
        public int getLatestVoucherNo()
        {
            int VCode = 0;
            try
            {
                string qry = "Select top(1)ID from AccountVoucher ORDER BY ID DESC";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        VCode = Convert.ToInt32(xResult);
                }
            }
            catch { VCode = 0; }
            return VCode;
        }
        public string getNextVoucherNo()
        {
            string ItemCode = "";

            try
            {
                string qry = "SELECT isnull(Max([ID]),0) + 1 FROM [dbo].[AccountVoucher]";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        ItemCode = Convert.ToString(xResult);
                }

            }
            catch { ItemCode = ""; }
            return ItemCode;
        }
        public string getNextVoucherDetailsNo()
        {
            string ItemCode = "";

            try
            {
                string qry = "SELECT isnull(Max([ID]),0) + 1 FROM AccountVoucherDetails";
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        ItemCode = Convert.ToString(xResult);
                }
            }
            catch { ItemCode = ""; }
            return ItemCode;
        }

        //-------Inventory-------------------------------//
        public DataTable getTotalInventoryInfo(int ItemID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [ItemID], SUM([Qty]) [Qty]" +
                         " FROM [dbo].[ItemStock]" +
                         " WHERE [ItemID] = " + ItemID +
                         " group by [ItemID]";


            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable getInventoryInfo(int ItemID, int WarehouseID, int StoreID)
        {
            DataTable dt = new DataTable();

            string Qry = "SELECT [ItemID] ,[StoreID] ,[WarehouseID] ,[Qty]" +
                         " FROM [dbo].[ItemStock]" +
                         " WHERE [ItemID] = " + ItemID +
                         " AND [WarehouseID] = " + WarehouseID +
                         " AND [StoreID] = " + StoreID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dt);

            return dt;
        }
        public DataTable FillStockRegister(DataTable dataTable)
        {
            dataTable.Clear();
            string Qry = "SELECT [OilProduct].ID , [OilProduct].[Name] [ItemName], ISNULL(([Stock].[Qty]),0)[Qty], 'OilProduct' [ItemType]" +
                         " FROM [dbo].[OilProduct] [OilProduct]" +
                         " Left join [dbo].[OilChangeStock] [Stock] on [OilProduct].ID = [Stock].[OilProductID]" +
                         " WHERE [OilProduct].Active = 1" +
                         " UNION ALL" +
                         " SELECT [Accessories].ID , [Accessories].[Name] [ItemName], ISNULL(([Stock].[Qty]),0)[Qty], 'Accessories' [ItemType]" +
                         " FROM [dbo].[OilChangeAccessories] [Accessories]" +
                         " Left join [dbo].[OilChangeStock] [Stock] on [Accessories].ID = [Stock].[AccessoriesID]" +
                         " WHERE [Accessories].Active = 1" +
                         " Order by [ItemType],[ItemName]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public void UpdateStock(int ItemID, string ItemType, int Qty)
        {
            try
            {
                string Field = string.Empty;
                if (ItemType.Equals("OilProduct")) Field = "OilProductID";
                if (ItemType.Equals("Accessories")) Field = "AccessoriesID";

                string cDate = Convert.ToString(DateTime.Now.Date).Substring(0, 10);
                int ID = this.IsExistInStock(ItemID, Field);
                string Qry = string.Empty;
                if (ID > 0)
                {
                    Qry = "UPDATE [dbo].[OilChangeStock]" +
                          " SET [Qty] = " + Qty +
                          " ,[ModifyUserID] = " + StaticInfo.userid +
                          " ,[ModifyDate] = '" + cDate + "'" +
                          " ,[Comments] = 'Update Stock by StockRegister'" +
                          " WHERE [ID] = " + ID;
                }
                else
                {
                    Qry = "INSERT INTO [dbo].[OilChangeStock]" +
                          "([" + Field + "],[Qty] ,[Active] ,[AddDate] ,[AddUserID] ,[Comments] )" +
                          " VALUES ( " + ItemID +
                          " ," + Qty + ",1 ,'" + cDate + "'," + StaticInfo.userid +
                          " ,'Add Stock FROM StockRegister')";
                }
                if (!string.IsNullOrEmpty(Qry))
                {
                    using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            catch { }
        }
        public int IsExistInStock(int ItemID, string Field)
        {
            int result = 0;
            try
            {
                string qry = "SELECT [ID] FROM [dbo].[OilChangeStock] WHERE [" + Field + "] = " + ItemID;
                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        result = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return result;
        }
        public string getAvailableQty(int ID)
        {
            string Qty = "";
            string qry = "SELECT [Qty] FROM [dbo].[POSStock] WHERE [POSItemID] = " + ID + "";
            using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
                if (xResult != DBNull.Value)
                    Qty = Convert.ToString(xResult);
            }
            return Qty;
        }

        //----------WarrantyClaim----------------------------------------//
        public DataTable FillWarrantyClaimToVendorList(int VendorID)
        {
            DataTable dataTable = new DataTable();

            string Qry = "SELECT [clm].[ID]" +
                         " ,[clm].[VendorID]" +
                         " ,[clm].[POID]" +
                         " ,[clm].[ItemID]" +
                         " ,[clm].[Active]" +
                         " ,[itm].[Catalog]" +
                         " ,[itm].[Name] [Part Description]" +
                         " ,[itm].[CatalogCost] [Cost]" +
                         " ,[clm].[ClaimDate]" +
                         " ,[clm].[Comments] [Reference]" +
                         " ,[clm].[CustomerClaimNumber] [Invoice#]" +
                         " ,[Status] = CASE [clm].[IsShipped] WHEN 1 THEN 'Returned' ELSE CASE [clm].[IsCredit] WHEN 1 THEN 'Credit' ELSE CASE [clm].[IsVoid] WHEN 1 THEN 'Void' ELSE 'New' END END END" +
                         //" ,[clm].[Active]"+
                         " ,[clm].[AddDate]" +
                         " ,[clm].[AddUserID]" +
                         " ,[clm].[IsLocked]" +
                         " ,[clm].[CompanyID]" +
                         " ,[clm].[WarehouseID]" +
                         " ,[clm].[StoreID]" +
                         " ,[wstr].[CoName] [Store]" +
                         " FROM [dbo].[WarrantyClaimToVendor] [clm]" +
                         " LEFT JOIN [dbo].[Item] itm on [clm].[ItemID] = itm.ID" +
                         " LEFT JOIN [dbo].[WarehouseStore] [wstr] on [clm].[StoreID] = [wstr].[ID]" +
                         " Where [clm].[IsClaim] = 1  And [clm].[VendorID] = " + VendorID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public void AddWarrantyClaim(int VendorID, int? POID, int ItemID, DateTime ClaimDate, int ClaimQty, bool IsShipped, DateTime? ShipingDate, string CustomerClaimNumber, string Comments, bool? IsAdjustInventory, string ItemStatus)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[WarrantyClaimToVendor] " +
                    "([VendorID] ,[POID] ,[ItemID] ,[ClaimDate] ,[ClaimQty] ,[IsShipped] ,[IsCredit] ,[IsVoid] ,[IsClaim] ,[IsCores] ,[ShipingDate] ,[CustomerClaimNumber] ,[ItemStatus] ,[IsAdjustInventory] " +
                    ",[Active] ,[AddDate] ,[AddUserID],[Comments] ,[IsLocked] ,[CompanyID] ,[WarehouseID] ,[StoreID]) " +
                    "VALUES (@VendorID ,@POID ,@ItemID ,@ClaimDate ,@ClaimQty ,@IsShipped ,0 ,0 ,1 , 0,@ShipingDate ,@CustomerClaimNumber ,@ItemStatus ,@IsAdjustInventory" +
                    ",0 ,GETDATE() ," + StaticInfo.userid + ",@Comments ,0 ," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + " ," + StaticInfo.StoreID + ")", SqlCnn);

                command.Parameters.Add("@VendorID", SqlDbType.Int);
                command.Parameters["@VendorID"].Value = VendorID;

                command.Parameters.Add("@POID", SqlDbType.Int);
                command.Parameters["@POID"].Value = POID;

                command.Parameters.Add("@ItemID", SqlDbType.Int);
                command.Parameters["@ItemID"].Value = ItemID;

                command.Parameters.Add("@ClaimDate", SqlDbType.DateTime);
                command.Parameters["@ClaimDate"].Value = ClaimDate;

                command.Parameters.Add("@ClaimQty", SqlDbType.Int);
                command.Parameters["@ClaimQty"].Value = ClaimQty;

                command.Parameters.Add("@IsShipped", SqlDbType.Bit);
                command.Parameters["@IsShipped"].Value = IsShipped;

                command.Parameters.Add("@ShipingDate", SqlDbType.DateTime);
                command.Parameters["@ShipingDate"].Value = ShipingDate;

                command.Parameters.Add("@CustomerClaimNumber", SqlDbType.VarChar);
                command.Parameters["@CustomerClaimNumber"].Value = CustomerClaimNumber;

                command.Parameters.Add("@Comments", SqlDbType.VarChar);
                command.Parameters["@Comments"].Value = Comments;

                command.Parameters.Add("@IsAdjustInventory", SqlDbType.Bit);
                command.Parameters["@IsAdjustInventory"].Value = IsAdjustInventory;

                command.Parameters.Add("@ItemStatus", SqlDbType.VarChar);
                command.Parameters["@ItemStatus"].Value = ItemStatus;

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public void AddNewClaim(int VendorID, int ItemID, DateTime ClaimDate, int ClaimQty, bool IsShipped, DateTime? ShipingDate, string CustomerClaimNumber, string Comments, bool? IsAdjustInventory, string ItemStatus)
        {
            SqlConnection SqlCnn = new SqlConnection(this.connectionString);
            try
            {
                SqlCnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[WarrantyClaimToVendor] " +
                    "([VendorID] ,[ItemID] ,[ClaimDate] ,[ClaimQty] ,[IsShipped] ,[IsCredit] ,[IsVoid] ,[IsClaim] ,[IsCores] ,[ShipingDate] ,[CustomerClaimNumber] ,[ItemStatus] ,[IsAdjustInventory] " +
                    ",[Active] ,[AddDate] ,[AddUserID],[Comments] ,[IsLocked] ,[CompanyID] ,[WarehouseID] ,[StoreID]) " +
                    "VALUES (@VendorID ,@ItemID ,@ClaimDate ,@ClaimQty ,@IsShipped ,0 ,0 ,1 , 0,@ShipingDate ,@CustomerClaimNumber ,@ItemStatus ,@IsAdjustInventory" +
                    ",0 ,GETDATE() ," + StaticInfo.userid + ",@Comments ,0 ," + StaticInfo.CompanyID + " ," + StaticInfo.WarehouseID + " ," + StaticInfo.StoreID + ")", SqlCnn);

                command.Parameters.Add("@VendorID", SqlDbType.Int);
                command.Parameters["@VendorID"].Value = VendorID;

                command.Parameters.Add("@ItemID", SqlDbType.Int);
                command.Parameters["@ItemID"].Value = ItemID;

                command.Parameters.Add("@ClaimDate", SqlDbType.DateTime);
                command.Parameters["@ClaimDate"].Value = ClaimDate;

                command.Parameters.Add("@ClaimQty", SqlDbType.Int);
                command.Parameters["@ClaimQty"].Value = ClaimQty;

                command.Parameters.Add("@IsShipped", SqlDbType.Bit);
                command.Parameters["@IsShipped"].Value = IsShipped;

                command.Parameters.Add("@ShipingDate", SqlDbType.DateTime);
                command.Parameters["@ShipingDate"].Value = ShipingDate;

                command.Parameters.Add("@CustomerClaimNumber", SqlDbType.VarChar);
                command.Parameters["@CustomerClaimNumber"].Value = CustomerClaimNumber;

                command.Parameters.Add("@Comments", SqlDbType.VarChar);
                command.Parameters["@Comments"].Value = Comments;

                command.Parameters.Add("@IsAdjustInventory", SqlDbType.Bit);
                command.Parameters["@IsAdjustInventory"].Value = IsAdjustInventory;

                command.Parameters.Add("@ItemStatus", SqlDbType.VarChar);
                command.Parameters["@ItemStatus"].Value = ItemStatus;

                command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                SqlCnn.Close();
            }
        }
        public void UpdateClaimsIsVoid(int ID)
        {
            try
            {
                string qry = "update [dbo].[WarrantyClaimToVendor] set [IsShipped] = 0, [IsCredit] = 0, [IsVoid] = 1 where [ID] =" + ID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public void UpdateClaimsIsShip(int ID)
        {
            try
            {
                string qry = "UPDATE [dbo].[WarrantyClaimToVendor] SET [IsShipped] = 1, [IsCredit] = 0, [IsVoid] = 0 WHERE [ID] =" + ID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch { }
        }
        public void UpdateClaimsIsCredit(int ID, string RefNo, DateTime? CreditDate)
        {
            try
            {
                DateTime cDate = CreditDate.Value;

                string qry = "UPDATE [dbo].[WarrantyClaimToVendor] SET [IsShipped] = 0, [IsCredit] = 1, [IsVoid] = 0 ,[Remarks] = '" + RefNo + "' ,[ModifyDate] = '" + Convert.ToString(cDate.Date.Year + "-" + cDate.Date.Month + "-" + cDate.Date.Day) + "' WHERE [ID] = " + ID;

                using (SqlConnection sqlCon = new SqlConnection(this.connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch { }
        }

        #region ReportingSection
        //DataTable dt = new DataTable();

        //using (SqlConnection c = new SqlConnection(cString))
        //using (SqlDataAdapter sda = new SqlDataAdapter(sql, c))
        //{
        //    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sda.SelectCommand.Parameters.AddWithValue("@parm1", val1);
        //    ...

        //    sda.Fill(dt);
        //}
        //------------------------------------Start Reporting Section--------------------------------------//        
        //public DataTable PurchaseOrderReportRpt(DataTable dtM, DataTable dtD, int ID)
        //{            
        //    dtD.Clear();
        //    dtM.Clear();
        //    //------------------------------------------------------------
        //    string QryM = "SELECT [PO].[ID] [ID]" +
        //                  " ,[PO].[PODate] [Date1]" +
        //                  " ,[PO].[LastReceivedDate] [Date2]" +
        //                  " ,[PO].[Reference] [S1]" +
        //                  " ,[PO].[Notes] [S2]" +
        //                  " ,[PO].[POID] [I1]" +
        //                  " ,[PO].[TotalQtyOrder] [I2]" +
        //                  " ,[PO].[TotalQtyReceived] [I3]" +
        //                  " ,[PO].[TotalQtyBilled] [I4]" +
        //                  " ,[PO].[LastReceivedBy] [I5]" +
        //                  " ,[PO].[DiscountPer] [D1]" +
        //                  " ,[PO].[TotalAmountOrder] [D2]" +
        //                  " ,[PO].[TotalAmountReceived] [D3]" +
        //                  " ,[PO].[TotalAmountBilled] [D4]" +
        //                  " ,[PO].[VendorID] [I6]" +
        //                  " ,[Vdr].[Name] [S3]" +
        //                  " ,[Vdr].[Address] [S4]" +
        //                  " ,[Vdr].[Phone]  [S5]" +
        //                  " ,[Vdr].[Fax] [S6]" +
        //                  " ,[Vdr].[Email] [S7]" +
        //                  " ,[Ste].[Name] [S8]   " +
        //                  " ,[Cty].[Name] [S9] " +
        //                  " ,[Vdr].[ZipCode] [N1]" +
        //                  " ,[Vdr].[FederalNo] [S10]" +
        //                  " ,[PO].[WarehouseID] [I7]" +
        //                  " ,[Wh].[CoName] [S11]" +
        //                  " ,[Wh].[CoAddress] [S12] " +
        //                  " ,[Ste1].[Name] + '  ' +[Cty1].[Name] [S13]" +                          
        //                  " ,[PO].[StoreID] [I8]" +
        //                  " ,[WhStr].[Name] [S15]" +
        //                  " FROM [dbo].[PurchaseOrder] [PO]" +
        //                  " LEFT JOIN [dbo].[Vendor] [Vdr] ON [PO].[VendorID] = [Vdr].[ID]" +
        //                  " LEFT JOIN [dbo].[Warehouse] [Wh] ON [PO].[WarehouseID] = [Wh].[ID]" +
        //                  " LEFT JOIN [dbo].[WarehouseStore] [WhStr] ON [PO].[StoreID] = [WhStr].[ID]" +
        //                  " LEFT JOIN [dbo].[State] [Ste] ON [Vdr].[StateID] = [Ste].[ID]" +
        //                  " LEFT JOIN [dbo].[City] [Cty] ON [Vdr].[CityID] = [Cty].[ID]" +
        //                  " LEFT JOIN [dbo].[State] [Ste1] ON [Wh].[StateID] = [Ste1].[ID]" +
        //                  " LEFT JOIN [dbo].[City] [Cty1] ON [Wh].[CityID] = [Cty1].[ID]" +
        //                  " WHERE [PO].[ID] = " + ID;

        //    string QryD = "SELECT [POD].[ID]"+
        //                  " ,[POD].[MID]"+      
        //                  " ,[POD].[QtyOrdrd] [I1]"+
        //                  " ,[POD].[PrevOrdrd] [I2]"+
        //                  " ,[POD].[QtyRcvd] [I3]"+
        //                  " ,[POD].[PrevRcvd] [I4]"+
        //                  " ,[POD].[QtyBilled] [I5]"+
        //                  " ,[POD].[PrevBilled] [I6]"+      
        //                  " ,[POD].[Cost] [D1]"+
        //                  " ,[POD].[FET] [D2]"+
        //                  " ,[POD].[Amount] [D3]"+      
        //                  " ,[POD].[ItemID] [I7]"+
        //                  " ,itm.[Catalog] [S1]"+
        //                  " ,itm.[Name] [S2]"+
        //                  " ,itm.[VenderPartNo] [S3]"+      
        //                  " ,ISNULL(itm.[UnitWeight],0) [D4]"+      
        //                  " FROM [dbo].[PurchaseOrderDetails] [POD]"+
        //                  " LEFT JOIN [dbo].[Item] itm ON [POD].[ItemID] = itm.ID"+
        //                  " WHERE [POD].[MID] = "+ID;

        //    this.ExecuteSqlReaderLoadStep(dtM,QryM);
        //    this.ExecuteSqlReaderLoadStep(dtD, QryD);
        //    //------------------------------------------------------------
        //    return dtM;
        //}
        //public DataTable WorkOrderReportRpt(DataTable dtM, DataTable dtD, int ID)
        //{
        //    dtD.Clear();
        //    dtM.Clear();
        //    //------------------------------------------------------------
        //    string QryM = "SELECT [WO].[ID]" +
        //                  " ,[WO].[AddDate] [Date1]" +
        //                  " ,[WO].[AddUserID]	[I1]" +
        //                  " ,[WO].[WorkOrderNo]  [I2]   	  " +
        //                  " ,[VEH].[VehicleColorID]	[I3]" +
        //                  " ,[VEH].[VehicleTransmissionID] [I4] " +
        //                  " ,[CUS].[CountryID]	[I5]" +
        //                  " ,[CUS].[StateID]	[I6]" +
        //                  " ,[CUS].[CityID]   [I7]" +
        //                  " ,[CUS].[ZipCode]	[I8]" +
        //                  " ,[VEH].[Mileage]       [I9]" +

        //                  " ,[WO].[Mileage]	[N1]" +
        //                  " ,[WO].[MileageOut]	[N2]" +

        //                  " ,[WO].[PONo]	[S1]" +
        //                  " ,[USR].[GroupName]	[S2]" +
        //                  " ,[CUS].[FirstName]	[S3]" +
        //                  " ,[CUS].[LastName]	[S4]" +
        //                  " ,[CUS].[Address]	[S5]" +
        //                  " ,[CUS].[Email]	[S6]   " +  
        //                  " ,[VEH].[LicensePlate]	[S7]" +
        //                  " ,[VEH].[VIN]	[S8]" +
        //                  " ,[VEH].[FleetNumber]	[S9]" +
        //                  " ,[VEH].[EngineSize]      [S10]" +

        //                  " ,[WO].[PartsPrice]	[D1]" +
        //                  " ,[WO].[LaborPrice]	[D2]" +
        //                  " ,[WO].[OtherPrice]	[D3]" +
        //                  " ,[WO].[FET]	[D4]" +
        //                  " ,[WO].[Taxable]	[D5]" +
        //                  " ,[WO].[Tax]	[D6]" +
        //                        " ,[WO].[Discount]	[D7]" +
        //                        " ,[WO].[PartDisPer]	[D8]" +
        //                        " ,[WO].[LaborDisPer]	[D9]" +
        //                        " ,[WO].[Total]            [D10]        " +
        //                        " ,[Wh].[CoName] [S11]" +
        //                        " ,[Wh].[CoAddress] [S12]      " +
        //                        " ,[Ste1].[Name] + '  ' +[Cty1].[Name] [S13]" +
        //                        " ,[WCO].[Name]   [S14] 	" +  
        //                        " ,[WTA].[Name]	  [S15]" +
        //                        " ,[STE].[Initial]	[S16]" +
        //                        " ,[STE].[Name]	[S17]" +
        //                        " ,[CON].[Name]	[S18]" +
        //                        " ,[CTI].[Name]	[S19]" +
        //                        " ,[VEH].[Torque]         [S20]	  " +
        //                        " ,[REF].[Name]   [S21]" +
        //                        " ,[WMO].[Name]	  [S22]	 " +

        //                  " FROM [dbo].[WorkOrder] [WO]" +
        //                  " LEFT JOIN [dbo].[UserGroups] [USR] ON [WO].[AddUserID] = [USR].[ID]" +
        //                  " LEFT JOIN [dbo].[Customer] [CUS] ON [WO].[CustomerID] = [CUS].[ID]" +
        //                  " LEFT JOIN [dbo].[Vehicle] [VEH] ON [WO].[VehicleID] = [VEH].[ID]" +
        //                  " LEFT JOIN [dbo].[ReferredBy] [REF] ON [WO].[ReferredByID] = [REF].[ID]" +
        //                  " LEFT JOIN [dbo].[VehicleModel] [WMO] ON [VEH].[VehicleModelID] = [WMO].[ID]" +
        //                  " LEFT JOIN [dbo].[VehicleColor] [WCO] ON [VEH].[VehicleColorID] = [WCO].[ID]" +
        //                  " LEFT JOIN [dbo].[VehicleTransmission] [WTA] ON [VEH].[VehicleTransmissionID] = [WTA].[ID]" +
        //                  " LEFT JOIN [dbo].[State] [Ste1] ON [CUS].[StateID] = [Ste1].[ID]" +
        //                  " LEFT JOIN [dbo].[State] [STE] ON [CUS].[StateID] = [STE].[ID]" +
        //                  " LEFT JOIN [dbo].[Country] [CON] ON [CUS].[CountryID] = [CON].[ID]" +
        //                  " LEFT JOIN [dbo].[City] [CTI] ON [CUS].[CityID] = [CTI].[ID]" +
        //                  " LEFT JOIN [dbo].[City] [Cty1] ON [CUS].[CityID] = [Cty1].[ID]" +
        //                  " LEFT JOIN [dbo].[Warehouse] [Wh] ON [WO].[WarehouseBayID] = [Wh].[ID]" +
        //                  " WHERE [WO].[ID] = " + ID;

        //    string QryD = "SELECT [WOD].[ID] " +

        //                  " ,[WOD].[AddDate]	[Date1]" +

        //                  " ,[WOD].[MID]	[I1]" +
        //                  " ,[WOD].[ItemID]	[I2]" +
        //                  " ,[WOD].[PackageID]	[I3]            " +
        //                  " ,[WOD].[FeeID]	[I4]" +
        //                  " ,[WOD].[LaborID]	[I5]" +
        //                  " ,[WOD].[VehicleInspectionID]	[I6]" +
        //                  " ,[WOD].[InspectionHeadID]	[I7]" +
        //                  " ,[WOD].[Available]	[I8]" +
        //                  " ,[WOD].[Qty]	[I9]" +
        //                  " ,[WOD].[MechanicID]	[I10]" +
        //                  " ,[WOD].[RepID]	[I11]" +

        //                  " ,[WOD].[Ctype]	[S1]" +
        //                  " ,itm.[Catalog]	[S2]" +
        //                  " ,itm.[Name]		[S3]" +
        //                  " ,itm.[VenderPartNo] [S4]" +
        //                  " ,itm.[ItemCode]    [S5]" +
        //                  " ,itm.[ItemSize]    [S6]   " + 
        //                  " ,pkg.[Catalog]	[S7]" +
        //                  " ,pkg.[Name]		[S8]" +
        //                  " ,FE.[Catalog]      [S9]" +
        //                  " ,FE.[Name]	[S10]" +
        //                  " ,Le.[Catalog]      [S11]" +
        //                  " ,Le.[Name]      [S12]" +
        //                  " ,INC.[AccName]	[S13]" +


        //                  " ,[WOD].[Price]	[D1]" +
        //                  " ,[WOD].[Cost]		[D2]" +
        //                  " ,[WOD].[Amount]	[D3]" +
        //                  " ,[WOD].[DiscPer]	[D4]" +
        //                  " ,[WOD].[DiscAmount]	[D5]" +
        //                  " ,[WOD].[FET]		[D6]" +
        //                  " ,[WOD].[Total]		[D7]" +
        //                  " ,itm.[RetailPrice]	[D8]      " +
        //                  " ,ISNULL(itm.[UnitWeight] ,0) [D9]     " +
        //                  " ,pkg.[PackageWithTax]	[D10]" +
        //                  " ,FE.[FeePrice]    [D11]" +
        //                  " ,Le.[LaborFees]  [D12]" +
        //                  " ,VI.[TotalParts]	[D13]" +
        //                  " ,VI.[TotalLabor]	[D14]" +
        //                  " ,VI.[TotalFees]	[D15]" +
        //                  " ,VI.[TotalTax]	[D16]" +
        //                  " ,VI.[TotalAmount]  [D17]" +


        //              " FROM [dbo].[WorkOrderDetail] [WOD]" +
        //              " LEFT JOIN [dbo].[Item] itm ON [WOD].[ItemID] = itm.ID " +
        //              " LEFT JOIN [dbo].[WarehousePackages] Pkg ON [WOD].[PackageID] = Pkg.ID " +
        //              " LEFT JOIN [dbo].[Fees] FE ON [WOD].[FeeID] = fe.ID " +
        //              " LEFT JOIN [dbo].[Labor] Le ON [WOD].[LaborID] = Le.ID " +
        //              " LEFT JOIN [dbo].[VehicleInspection] VI ON [WOD].[VehicleInspectionID] = VI.ID " +
        //              " LEFT JOIN [dbo].[InspectionHeads] INC ON [WOD].[InspectionHeadID] = INC.ID " +
        //                  " WHERE [WOD].[MID] = " + ID;

        //    this.ExecuteSqlReaderLoadStep(dtM, QryM);
        //    this.ExecuteSqlReaderLoadStep(dtD, QryD);
        //    //------------------------------------------------------------
        //    return dtM;
        //}
        //------------------------------------End Reporting Section--------------------------------------//
        public DataTable tblMasterRpt(DataTable dtM, DataTable dtD, string QryM)
        {
            dtD.Clear();
            dtM.Clear();
            //---------------------------------------
            this.ExecuteSqlReaderLoadStep(dtM, QryM);
            //---------------------------------------
            return dtM;
        }
        public DataTable tblMasterRpt(DataTable dtM, string QryM)
        {

            dtM.Clear();
            //---------------------------------------
            this.ExecuteSqlReaderLoadStep(dtM, QryM);
            //---------------------------------------
            return dtM;
        }
        public DataTable tblDetailRpt(DataTable dtD, string QryD)
        {
            dtD.Clear();
            //---------------------------------------
            this.ExecuteSqlReaderLoadStep(dtD, QryD);
            //---------------------------------------
            return dtD;
        }

        public DataTable getWarehouseInfo(DataTable dt)
        {
            dt.Clear();

            string Qry = "SELECT [Wh].[CoName] [CoName]" +
                         " ,[Wh].[CoAddress] [CoAddress]" +
                         //" ,[Ste1].[Name] + '  ' +[Cty1].[Name] [CoAddress1]" +
                         " FROM [dbo].[Warehouse] [Wh]" +
                         " where ID = 1 ";
            //" LEFT JOIN [dbo].[City] [Cty1] ON [wh].[CityID] = [Cty1].[ID]" +
            //" LEFT JOIN [dbo].[State] [Ste1] ON [Wh].[StateID] = [Ste1].[ID]" +
            //" LEFT JOIN [dbo].[Country] [cou1] ON [Wh].[CountryID] = [cou1].[ID]";

            this.ExecuteSqlReaderLoadStep(dt, Qry);
            return dt;
        }
        public DataTable getCompanyInfo(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT *" +
                         " FROM [dbo].[Company]";

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable getWarehouseInfo(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT *" +
                         " FROM [dbo].[Warehouse]" +
                         " Where ID = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        public DataTable getWarehouseStoreInfo(int ID)
        {
            DataTable dataTable = new DataTable();
            string Qry = "SELECT *" +
                         " FROM [dbo].[WarehouseStore]" +
                         " Where ID = " + ID;

            SqlDataAdapter sDA = new SqlDataAdapter(Qry, this.connectionString);
            sDA.Fill(dataTable);
            return dataTable;
        }
        #endregion ReportingSection
    }
    public class childTable
    {
        public string tblName { get; set; }
        public string tblQry { get; set; }
    }
    public sealed class Helper
    {
        public Helper()
        {
        }
        public string GetConnectionString()
        {
            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=AutoVault;User ID=sa;Password=abc@123";
<<<<<<< HEAD
            //return "Data Source=DESKTOP-P81FS32;Initial Catalog=AutoVault; User ID=sa;Password=abc@123";
            return "Data Source=DESKTOP-HDS0179;Initial Catalog=AutoVault; User ID=sa;Password=abc@123";

            //return "Data Source=DESKTOP-HDS0179;Initial Catalog=AutoVaultdb; User ID=sa;Password=abc@123";
=======
            return "Data Source=DESKTOP-P81FS32;Initial Catalog=AutoVaultdb; User ID=sa;Password=abc@123";
            //return "Data Source=DESKTOP-HDS0179;Initial Catalog=AutoVault; User ID=sa;Password=abc@123";
>>>>>>> 98983d2effec85fb04074a118011c36e5ff9daba

            //Live db Credentials
            //return "Data Source=216.119.113.84;Initial Catalog=AutoVault;User ID=dynamict_AutoVault;Password=Esspk@4646"; 
            //return "Data Source=104.37.185.122;Initial Catalog=AutoVault;User ID=AutoUser;Password=pakistan@123$"; 
            //return "Data Source=77.44.25.176;Initial Catalog=AutoVault;User ID=sa;Password=$@322@$";
            //return Properties.Settings.Default.AutoVaultConnectionString;
        }
    }
}