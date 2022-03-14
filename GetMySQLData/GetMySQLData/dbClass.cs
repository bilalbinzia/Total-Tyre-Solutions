using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace GetMySQLData
{
    public class dbClass
    {

        DataSet1 objdataSet = new DataSet1();

        public string SqlConnectionString = "";
        public string MySqlConnectionString = "datasource=127.0.0.1; port=3306; username=tabsuser; password=lD1h8Fmt; database=demo;";
        public string TempABSqlConnectionString = "Data Source=.\\sqlexpress; Initial Catalog = TempAB; Persist Security Info=True; User ID=sa; Password=abc@123";
        public string dbName = "";
        public dbClass()
        {
            try
            {
                Helper csHelper = new Helper();
                this.SqlConnectionString = csHelper.GetConnectionString();
                IDbConnection connection = new SqlConnection(this.SqlConnectionString);
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

        //------------------------------------------------------//
        public void CreateDataBase()
        {

            string str1 = "USE [master] " +

                         " \nCREATE DATABASE [TempAB] ON  PRIMARY \n" +
                         " ( NAME = N'TempAB', FILENAME = N'c:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.SQLEXPRESS\\MSSQL\\DATA\\TempAB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )\n" +
                         " LOG ON \n" +
                         " ( NAME = N'TempAB_log', FILENAME = N'c:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.SQLEXPRESS\\MSSQL\\DATA\\TempAB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%) \n" +

                         " \nALTER DATABASE [TempAB] SET COMPATIBILITY_LEVEL = 100" +

                         " \nIF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))\n" +
                         " begin\n" +
                         " EXEC [TempAB].[dbo].[sp_fulltext_database] @action = 'enable'\n" +
                         " end ";


            using (SqlConnection sqlCon = new SqlConnection("Data Source=.\\sqlexpress; Initial Catalog = master; Persist Security Info=True; User ID=sa; Password=abc@123"))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(str1, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();

            }
        }
        public void RunDataBaseScript(string DataBaseScript)
        {
            using (SqlConnection sqlCon = new SqlConnection(TempABSqlConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(DataBaseScript, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }
        public void InsertDataIntoTempAB(string DataBaseScript)
        {
            using (SqlConnection sqlCon = new SqlConnection(TempABSqlConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(DataBaseScript, sqlCon);
                object xResult = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
        }
        public void InsertDataIntoAutoVault(string DataBaseScript)
        {
            using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(DataBaseScript, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
                catch { sqlCon.Close(); }
            }
        }
        //------------------------------------------------------//
        public DataTable getDataFromMySQLTable(DataTable dt)
        {
            DataTable MySqldatatable = objdataSet.Tables[dt.TableName].Clone();
            MySqldatatable.Constraints.Clear();

            string query = "SELECT * FROM " + dt.TableName;

            try
            {
                objdataSet.Tables[dt.TableName].Clear();
                objdataSet.EnforceConstraints = false;
                MySqlDataAdapter sDA = new MySqlDataAdapter(query, MySqlConnectionString);
                sDA.Fill(MySqldatatable);


                if (MySqldatatable.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow dr in MySqldatatable.Rows)
                        {
                            DataRow newRow = dt.NewRow();
                            newRow.ItemArray = dr.ItemArray;
                            dt.Rows.Add(newRow);
                        }

                        if (dt.Rows.Count > 0)
                            UpdateTable(dt);
                    }
                    catch { }
                }
            }
            catch { }

            return dt;
        }
        void UpdateTable(DataTable dataTable)
        {
            //---------------------------------------
            try
            {
                string connetionString = this.SqlConnectionString;
                SqlConnection SqlCnn = new SqlConnection(connetionString);
                SqlDataAdapter sDA;
                SqlCnn.Open();
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
                            throw ex;
                        }

                    }
                }
                catch { }
                finally
                {
                    sDA.Dispose();
                    SqlCnn.Close();
                }

                ///-------------------------------------------
            }
            catch { }

        }
        public void getItems(DataTable dsdt)
        {

            string query = "SELECT * FROM " + dsdt.TableName;

            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                try
                                {
                                    DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
                                    newRow.ItemArray = dr.ItemArray;
                                    objdataSet.Tables[dsdt.TableName].Rows.Add(newRow);
                                }
                                catch { }
                            }

                            if (objdataSet.Tables[dsdt.TableName].Rows.Count > 0)
                                UpdateTable(objdataSet.Tables[dsdt.TableName]);
                        }
                        catch { }
                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch { }

        }
        string getInfoByZipCode(string fname, int zipCode)
        {
            string getResult = string.Empty;
            try
            {
                string qry = "SELECT [" + fname + "] FROM [dbo].[ZipCode] WHERE [Zip] = " + zipCode;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    getResult = Convert.ToString(xResult);
                }
            }
            catch { }
            return getResult;
        }
        public void UpdateDataBase(DataTable dsdt)
        {

            string query = "SELECT * FROM " + dsdt.TableName;

            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                try
                                {
                                    DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
                                    newRow.ItemArray = dr.ItemArray;
                                    objdataSet.Tables[dsdt.TableName].Rows.Add(newRow);
                                }
                                catch { }
                            }

                            if (objdataSet.Tables[dsdt.TableName].Rows.Count > 0)
                                UpdateTable(objdataSet.Tables[dsdt.TableName]);
                        }
                        catch { }
                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch { }

        }

        //------------------------------------------------------//
        public void UpdateCompanyTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[comp]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }

            try
            {
                if (dt.Rows.Count > 0)
                {
                    string comName = Convert.ToString(dt.Rows[0]["dfltCompanyName"]);
                    string comAddress = Convert.ToString(dt.Rows[0]["dfltAddr1"]);
                    string coPhoneAndFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);

                    string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]);
                    string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);
                    //string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(4, 14);   //Phone: from [dfltPhones]
                    //string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(23);   //Fax: from [dfltPhones]
                    string comBarNo = Convert.ToString(dt.Rows[0]["dfltBarNum"]);

                    int zipCode = Convert.ToInt32(dt.Rows[0]["dfltZip"]);


                    string updateQuery = "update [AutoVault].[dbo].[Company] " +
                                         "set [CoName] = '" + comName + "'" +
                                         ", [CoAddress] = '" + comAddress + "'" +
                                         ", [CoPhone] = '" + comPhone + "'" +
                                         ", [CoFax] = '" + comFax + "'" +
                                         ", [BarNo] = '" + comBarNo + "'" +
                                         ", [ZipCode] = " + zipCode;

                    SqlConnection databaseConnection = new SqlConnection(SqlConnectionString);
                    SqlCommand commandDatabase = new SqlCommand(updateQuery, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    databaseConnection.Open();
                    SqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
            }
            catch { }

        }
        public void UpdateWarehouseTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[comp]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }

            try
            {
                if (dt.Rows.Count > 0)
                {
                    string comName = Convert.ToString(dt.Rows[0]["dfltCompanyName"]);
                    string comAddress = Convert.ToString(dt.Rows[0]["dfltAddr1"]);
                    string coPhoneAndFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);
                    string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]);
                    string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);

                    //string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(4, 14);   //Phone: from [dfltPhones]
                    //string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(23);   //Fax: from [dfltPhones]
                    string comBarNo = Convert.ToString(dt.Rows[0]["dfltBarNum"]);

                    int zipCode = Convert.ToInt32(dt.Rows[0]["dfltZip"]);


                    string updateQuery = "update [AutoVault].[dbo].[Warehouse] " +
                                         "set [CoName] = '" + comName + "'" +
                                         ", [CoAddress] = '" + comAddress + "'" +
                                         ", [CoPhone] = '" + comPhone + "'" +
                                         ", [CoFax] = '" + comFax + "'" +
                                         ", [BarNo] = '" + comBarNo + "'" +
                                         ", [ZipCode] = " + zipCode;


                    SqlConnection databaseConnection = new SqlConnection(SqlConnectionString);
                    SqlCommand commandDatabase = new SqlCommand(updateQuery, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    databaseConnection.Open();
                    SqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
            }
            catch { }

        }
        public void UpdateWarehouseStoreTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[comp]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }

            try
            {
                if (dt.Rows.Count > 0)
                {
                    string comName = Convert.ToString(dt.Rows[0]["dfltCompanyName"]);
                    string comAddress = Convert.ToString(dt.Rows[0]["dfltAddr1"]);
                    string coPhoneAndFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);

                    string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]);
                    string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]);

                    //string comPhone = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(4, 14);   //Phone: from [dfltPhones]
                    //string comFax = Convert.ToString(dt.Rows[0]["dfltPhones"]).Substring(23);   //Fax: from [dfltPhones]
                    string comBarNo = Convert.ToString(dt.Rows[0]["dfltBarNum"]);

                    int zipCode = Convert.ToInt32(dt.Rows[0]["dfltZip"]);


                    string updateQuery = "update [AutoVault].[dbo].[WarehouseStore] " +
                                         "set [CoName] = '" + comName + "'" +
                                         ", [CoAddress] = '" + comAddress + "'" +
                                         ", [CoPhone] = '" + comPhone + "'" +
                                         ", [CoFax] = '" + comFax + "'" +
                                         ", [BarNo] = '" + comBarNo + "'" +
                                         ", [ZipCode] = " + zipCode;

                    SqlConnection databaseConnection = new SqlConnection(SqlConnectionString);
                    SqlCommand commandDatabase = new SqlCommand(updateQuery, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    databaseConnection.Open();
                    SqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
            }
            catch { }

        }
        public void InsertHolidaysTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[clockholiday]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }


            if (dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {

                            DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
                            int HolidayID = 0;
                            if ((dr["holiday"] != DBNull.Value) && (dr["holiday"] != ""))
                            {
                                string SName = Convert.ToString(dr["holiday"]);
                                HolidayID = getHolidaysIdByName(SName);
                            }
                            if (HolidayID == 0)
                            {
                                if ((dr["holiday"] != DBNull.Value) && (dr["holiday"] != ""))
                                    newRow["Name"] = Convert.ToString(dr["holiday"]);
                                if ((dr["description"] != DBNull.Value) && (dr["description"] != ""))
                                    newRow["HolidayDate"] = Convert.ToString(dr["description"]);
                                newRow["Active"] = 1;
                                newRow["AddDate"] = DateTime.Now;
                                newRow["AddUserID"] = 1;
                                newRow["IsLocked"] = 0;
                                objdataSet.Tables[dsdt.TableName].Rows.Add(newRow);
                            }
                        }
                        catch { }
                    }

                    if (objdataSet.Tables[dsdt.TableName].Rows.Count > 0)
                        UpdateTable(objdataSet.Tables[dsdt.TableName]);
                }
                catch { }
            }


        }
        public void InsertWarehouseHolidaysTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[clockholiday]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int HolidayID = 0;
                        if ((dr["holiday"] != DBNull.Value) && (dr["holiday"] != ""))
                        {
                            string HolidayName = Convert.ToString(dr["holiday"]);
                            HolidayID = getHolidayID(HolidayName);
                        }
                        int wiID = 0;
                        if ((dr["holiday"] != DBNull.Value) && (dr["holiday"] != ""))
                        {
                            string HolidayName = Convert.ToString(dr["holiday"]);
                            wiID = getHolidaydateID(HolidayName);
                        }
                        DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
                        newRow["MID"] = HolidayID;
                        if ((dr["description"] != DBNull.Value))
                            newRow["description"] = Convert.ToString(dr["Name"]);
                        newRow["MID"] = HolidayID;
                        newRow["HolidayDate"] = HolidayID;
                        if ((dr["Paid"] != DBNull.Value))
                            newRow["IsPaid"] = Convert.ToBoolean(dr["Paid"]);
                        if ((dr["Closed"] != DBNull.Value))
                            newRow["IsClosed"] = Convert.ToBoolean(dr["Closed"]);
                        newRow["Active"] = 1;
                        newRow["AddDate"] = DateTime.Now;
                        newRow["AddUserID"] = 1;
                        newRow["IsLocked"] = 0;
                        newRow["CompanyID"] = 1;
                        newRow["WarehouseID"] = 1;
                        newRow["StoreID"] = 1;
                        objdataSet.Tables[dsdt.TableName].Rows.Add(newRow);
                    }
                    catch { }
                }

                if (objdataSet.Tables[dsdt.TableName].Rows.Count > 0)
                    UpdateTable(objdataSet.Tables[dsdt.TableName]);

            }



        }

        public void InsertEmployeeTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[salesrep]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int BaseOnid = 0;
                        if ((dr["BaseOn"] != DBNull.Value) && (dr["BaseOn"] != ""))
                        {
                            string BaseOnName = Convert.ToString(dr["BaseOn"]);
                            BaseOnid = getBasebyname(BaseOnName);
                        }
                        int @DepartmentID,@IsSalRep,@CommisionBaseOn,@IsLogin,@IsMonday,@IsTuesday,@IsWednesday,@IsThursday,@IsFriday;
                        int @IsSaturday,@IsSunday,@IsDisplay,@Active,@AddUserID,@ModifyUserID,@IsLocked,@CoFinEndYear,@CompanyID,@WarehouseID,@StoreID;
                        decimal @LaborCommPer,@PartsCommPer,@Wages,@MondayHrs,@TuesdayHrs,@WednesdayHrs,@ThursdayHrs,@FridayHrs;
                        decimal @SaturdayHrs,@SundayHrs;
                        string @Initial,@Name,@Phone1,@Phone2,@Comments,@DocNo,@Remarks,@TrnsVrNo,@TrnsJrRef;
                        DateTime @RegDate;
                        string @MondayTimeStart,@MondayTimeEnd,@TuesdayTimeStart,@TuesdayTimeEnd,@WednesdayTimeStart,@WednesdayTimeEnd;
                        string @ThursdayTimeStart,@ThursdayTimeEnd,@FridayTimeStart,@FridayTimeEnd,@SaturdayTimeStart,@SaturdayTimeEnd,@SundayTimeStart,@SundayTimeEnd;
                        DateTime @AddDate,@ModifyDate;                                                  
                        
                        @DepartmentID=1;
                        if (dr["RepID"] != DBNull.Value && dr["RepID"] != "")
                                @Initial = Convert.ToString(dr["RepID"]);
                            else
                                @Initial = "";
                        @RegDate=DateTime.Now.Date;
                        if (dr["NAME"] != DBNull.Value && dr["NAME"] != "")
                                @Name = Convert.ToString(dr["NAME"]);
                            else
                                @Name = "";
                         if (dr["Phone1"] != DBNull.Value && dr["Phone1"] != "")
                                @Phone1 = Convert.ToString(dr["Phone1"]);
                            else
                                @Phone1 = "";
                         if (dr["Phone2"] != DBNull.Value && dr["Phone2"] != "")
                                @Phone2 = Convert.ToString(dr["Phone2"]);
                            else
                                @Phone2 = "";
                        if (dr["IsRep"] != DBNull.Value && dr["IsRep"] != "")
                                @IsSalRep = Convert.ToInt32(dr["IsRep"]);
                            else
                                @IsSalRep = 0;
                            if (dr["LaborPercent"] != DBNull.Value && dr["LaborPercent"] != "")
                                @LaborCommPer = Convert.ToDecimal(dr["LaborPercent"]);
                            else
                                @LaborCommPer = 0;
                        if (dr["partspercent"] != DBNull.Value && dr["partspercent"] != "")
                                @PartsCommPer = Convert.ToDecimal(dr["partspercent"]);
                            else
                                @PartsCommPer = 0;
                        @CommisionBaseOn = BaseOnid;
                        if (dr["Wage"] != DBNull.Value && dr["Wage"] != "")
                                @Wages = Convert.ToDecimal(dr["Wage"]);
                            else
                                @Wages = 0;
                        @IsLogin = 0;
                        @IsMonday = 1;
                        @MondayTimeStart = "08:00";
                        @MondayTimeEnd = "17:00";
                        @MondayHrs = 9;
                        @IsTuesday = 1;
                        @TuesdayTimeStart = "08:00";
                        @TuesdayTimeEnd = "17:00";
                        @TuesdayHrs = 9;
                        @IsWednesday = 1;
                        @WednesdayTimeStart = "08:00";
                        @WednesdayTimeEnd = "17:00";
                        @WednesdayHrs = 9;
                        @IsThursday = 1;
                        @ThursdayTimeStart = "08:00";
                        @ThursdayTimeEnd = "17:00";
                        @ThursdayHrs = 9;
                        @IsFriday = 1;
                        @FridayTimeStart = "08:00";
                        @FridayTimeEnd = "17:00";
                        @FridayHrs = 9;
                        @IsSaturday = 1;
                        @SaturdayTimeStart = "08:00";
                        @SaturdayTimeEnd = "17:00";
                        @SaturdayHrs = 9;
                        @IsSunday = 0;                        
                        @SundayHrs = 0;
                        @IsDisplay = 1;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Employee]" +
                                                    "([DepartmentID],[Initial],[RegDate],[Name],[Phone1],[Phone2],[IsSalRep],[LaborCommPer],[PartsCommPer],[CommisionBaseOn],[Wages],[IsLogin],[IsMonday],[MondayTimeStart],[MondayTimeEnd],[MondayHrs],[IsTuesday],[TuesdayTimeStart],[TuesdayTimeEnd],[TuesdayHrs],[IsWednesday],[WednesdayTimeStart],[WednesdayTimeEnd],[WednesdayHrs],[IsThursday],[ThursdayTimeStart],[ThursdayTimeEnd],[ThursdayHrs],[IsFriday],[FridayTimeStart],[FridayTimeEnd],[FridayHrs],[IsSaturday],[SaturdayTimeStart],[SaturdayTimeEnd],[SaturdayHrs],[IsSunday],[SundayHrs],[IsDisplay],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +   
                                                "VALUES" +
                                                "(" + @DepartmentID + ",'" + @Initial + "','" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @Name + "','" + @Phone1 + "','" + @Phone2 + "'," + @IsSalRep + "," + @LaborCommPer + "," + @PartsCommPer + "," + @CommisionBaseOn + "," + @Wages + "," + @IsLogin + "," + @IsMonday + ",'" + @MondayTimeStart + "','" + @MondayTimeEnd + "'," + @MondayHrs + "," + @IsTuesday + ",'" + @TuesdayTimeStart + "','" + @TuesdayTimeEnd + "'," + @TuesdayHrs + "," + @IsWednesday + ",'" + @WednesdayTimeStart + "','" + @WednesdayTimeEnd + "'," + @WednesdayHrs + "," + @IsThursday + ",'" + @ThursdayTimeStart + "','" + @ThursdayTimeEnd + "'," + @ThursdayHrs + "," + @IsFriday + ",'" + @FridayTimeStart + "','" + @FridayTimeEnd + "'," + @FridayHrs + "," + @IsSaturday + ",'" + @SaturdayTimeStart + "','" + @SaturdayTimeEnd + "'," + @SaturdayHrs + "," + @IsSunday + "," + @SundayHrs + "," + @IsDisplay + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";                
                            string InsertQuery = "\n" + Qry1 + "\n" ;
                            InsertDataIntoAutoVault(InsertQuery);

                        }
                    
                    catch { }
                }
            }
        }
        //------------------------------------------------------


        //------------------------------------------------------//
        //public void InsertEmployeeTable1(DataTable dsdt)
        //{

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        string query = "SELECT * FROM [TempAB].[dbo].[salesrep]";

        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();

        //    }
        //    catch { }

        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int BaseOnID = 1;
        //                if ((dr["BaseOn"] != DBNull.Value) && (dr["BaseOn"] != ""))
        //                {
        //                    string BaseOn = Convert.ToString(dr["BaseOn"]);
        //                    BaseOnID = getBaseOnID(BaseOn);
        //                }
        //                DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
        //                //newRow["DepartmentID"] = DBNull.Value;
        //                //newRow["LaborDepID"] = DBNull.Value;
        //                if ((dr["RepID"] != DBNull.Value) && (dr["RepID"] != ""))
        //                    newRow["Initial"] = Convert.ToString(dr["RepID"]);
        //                newRow["RegDate"] = DateTime.Now;
        //                if ((dr["Name"] != DBNull.Value) && (dr["Name"] != ""))
        //                    newRow["Name"] = Convert.ToString(dr["Name"]);
        //                if ((dr["Phone1"] != DBNull.Value) && (dr["Phone1"] != ""))
        //                    newRow["Phone1"] = Convert.ToString(dr["Phone1"]);
        //                if ((dr["Phone2"] != DBNull.Value) && (dr["Phone2"] != ""))
        //                    newRow["Phone2"] = Convert.ToString(dr["Phone2"]);
        //                if ((dr["IsTech"] != DBNull.Value) && (dr["IsTech"] != ""))
        //                    newRow["IsMech"] = Convert.ToInt32(dr["IsTech"]);
        //                if ((dr["IsRep"] != DBNull.Value) && (dr["IsRep"] != ""))
        //                    newRow["IsSalRep"] = Convert.ToInt32(dr["IsRep"]);
        //                if ((dr["partspercent"] != DBNull.Value) && (Convert.ToDouble(dr["partspercent"]) > 0))
        //                    newRow["PartsCommPer"] = Convert.ToDouble(dr["partspercent"]);
        //                if ((dr["LaborPercent"] != DBNull.Value) && (Convert.ToDouble(dr["LaborPercent"]) > 0))
        //                    newRow["LaborCommPer"] = Convert.ToDouble(dr["LaborPercent"]);
        //                newRow["CommisionBaseOn"] = BaseOnID;
        //                if ((dr["Wage"] != DBNull.Value) && (dr["Wage"] != ""))
        //                    newRow["Wages"] = Convert.ToString(dr["Wage"]);
        //                newRow["IsLogin"] = 0;
        //                newRow["IsOverTime"] = 0;
        //                newRow["OverTimerHrs"] = 0;
        //                newRow["IsHolidayPaid"] = 0;
        //                newRow["IsMonday"] = 1;
        //                newRow["MondayTimeStart"] = "08:00";
        //                newRow["MondayTimeEnd"] = "17:00";
        //                newRow["MondayHrs"] = 9;
        //                newRow["IsTuesday"] = 1;
        //                newRow["TuesdayTimeStart"] = "08:00";
        //                newRow["TuesdayTimeEnd"] = "17:00";
        //                newRow["TuesdayHrs"] = 9;
        //                newRow["IsWednesday"] = 1;
        //                newRow["WednesdayTimeStart"] = "08:00";
        //                newRow["WednesdayTimeEnd"] = "17:00";
        //                newRow["WednesdayHrs"] = 9;
        //                newRow["IsThursday"] = 1;
        //                newRow["ThursdayTimeStart"] = "08:00";
        //                newRow["ThursdayTimeEnd"] = "17:00";
        //                newRow["ThursdayHrs"] = 9;
        //                newRow["IsFriday"] = 1;
        //                newRow["FridayTimeStart"] = "08:00";
        //                newRow["FridayTimeEnd"] = "17:00";
        //                newRow["FridayHrs"] = 9;
        //                newRow["IsSaturday"] = 1;
        //                newRow["SaturdayTimeStart"] = "08:00";
        //                newRow["SaturdayTimeEnd"] = "16:00";
        //                newRow["SaturdayHrs"] = 8;
        //                newRow["IsSunday"] = 0;
        //                //newRow["SundayTimeStart"] = DBNull.Value;
        //                //newRow["SundayTimeEnd"] = DBNull.Value;
        //                newRow["SundayHrs"] = 0;
        //                newRow["IsDisplay"] = 1;
        //                newRow["Active"] = 1;
        //                newRow["AddDate"] = DateTime.Now;
        //                newRow["AddUserID"] = 1;
        //                newRow["IsLocked"] = 0;
        //                newRow["CompanyID"] = 1;
        //                newRow["WarehouseID"] = 1;
        //                newRow["StoreID"] = 1;

        //                //--insert Employee into table-----------------

        //            }
        //            catch { }
        //        }

        //    }

        //}
        public void InsertWarehouseDepartmentManagerTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[clockdept]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int EmployeeID = 0;
                        if ((dr["Name"] != DBNull.Value) && (dr["Name"] != ""))
                        {
                            string EmployeeName = Convert.ToString(dr["Name"]);
                            EmployeeID = getEmployeeID(EmployeeName);
                        }
                        int DeptID = 0;
                        if ((dr["DeptCode"] != DBNull.Value) && (dr["DeptCode"] != ""))
                        {
                            string DeptName = Convert.ToString(dr["DeptCode"]);
                            DeptID = getDeptID(DeptName);
                        }
                        DataRow newRow = objdataSet.Tables[dsdt.TableName].NewRow();
                        newRow["EmployeeID"] = EmployeeID;
                        newRow["DepartmentID"] = DeptID;
                        newRow["Active"] = 1;
                        newRow["AddDate"] = DateTime.Now;
                        newRow["AddUserID"] = 1;
                        newRow["IsLocked"] = 0;
                        newRow["CompanyID"] = 1;
                        newRow["WarehouseID"] = 1;
                        newRow["StoreID"] = 1;
                        objdataSet.Tables[dsdt.TableName].Rows.Add(newRow);
                    }
                    catch { }
                }

                if (objdataSet.Tables[dsdt.TableName].Rows.Count > 0)
                    UpdateTable(objdataSet.Tables[dsdt.TableName]);

            }



        }
        //------------------------------------------------------//
        public void InsertRefByTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[refby]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int RefByid = 0;
                        if ((dr["Msg"] != DBNull.Value) && (dr["Msg"] != ""))
                        {
                            string RefByName = Convert.ToString(dr["Msg"]);
                            RefByid = getRefByidbyname(RefByName);
                        }

                        int @ID, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        DateTime @AddDate, @ModifyDate;
                        if (RefByid == 0)
                        {
                            @ID = Convert.ToInt32(dr["ID"]);
                            if (dr["Msg"] != DBNull.Value && dr["Msg"] != "")
                                @Name = Convert.ToString(dr["Msg"]);
                            else
                                @Name = "";
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;

                            string Qry0 = "SET IDENTITY_INSERT [dbo].[ReferredBy] ON";
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[ReferredBy]" +
                                                    "([ID],[Name],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef])" +
                                                "VALUES" +
                                                "(" + @ID + ",'" + @Name + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "');";

                            string Qry2 = "SET IDENTITY_INSERT [dbo].[ReferredBy] OFF";
                            //-------------------------------------------------------------------//
                            string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                            InsertDataIntoAutoVault(InsertQuery);

                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertCustomerTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[cust]";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int SaleCatID = 0;
                        if ((dr["custsalecatid"] != DBNull.Value) && (dr["custsalecatid"] != ""))
                        {
                            string SaleCatName = Convert.ToString(dr["custsalecatid"]);
                            SaleCatID = getSaleCatID(SaleCatName);
                        }
                        int SaleTexID = 1;
                        if ((dr["custtaxid"] != DBNull.Value) && (dr["custtaxid"] != ""))
                        {
                            string SaleTexName = Convert.ToString(dr["custtaxid"]);
                            SaleTexID = getSaleTexID(SaleTexName);
                        }
                        int PriceLevelID = 0;
                        if ((dr["custsalecatid"] != DBNull.Value) && (dr["custsalecatid"] != ""))
                        {
                            string PriceLevelName = Convert.ToString(dr["custsalecatid"]);
                            PriceLevelID = getPriceLevelID(PriceLevelName);
                        }
                        int RefByID = 0;
                        if ((dr["ReferredBy"] != DBNull.Value) && (dr["ReferredBy"] != ""))
                        {
                            string RefByName = Convert.ToString(dr["ReferredBy"]);
                            RefByID = getRefByID(RefByName);
                        }
                        int SaleTermID = 0;
                        if ((dr["custtermsid"] != DBNull.Value) && (dr["custtermsid"] != ""))
                        {
                            string SaleTermName = Convert.ToString(dr["custtermsid"]);
                            SaleTermID = getSaleTermID(SaleTermName);
                        }
                        int ModifiedID = 0;
                        if ((dr["ModifiedBy"] != DBNull.Value) && (dr["ModifiedBy"] != ""))
                        {
                            string ModifiedName = Convert.ToString(dr["ModifiedBy"]);
                            ModifiedID = getModifiedID(ModifiedName);
                        }

                        //---------------------------------------------------------------------------------//
                        int @ID, @SaleCategoryID, @SaleTaxRateID, @PriceLvlID, @ReferredByID, @ZipCode = 0, @SaleTrmID, @AddUserID, @CompanyID, @WarehouseID, @StoreID, @ShipViaID, @ModifyUserID;
                        string @FirstName, @LastName, @CompanyName, @Address, @ContactPerson, @Email, @Phone1, @Phone2, @Phone3, @Phone4, @Notes, @WOMsg, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @IsShowMsgOnInvoice, @IsReqPONo, @IsPayFET, @IsCheckAccepted, @IsMail, @IsNoAutomaticSupplies, @IsFinanceCharges, @IsBadDebt, @IsPrintStatement, @IsNeverReAge, @IsNationalAccount, @IsDelete, @Active, @IsLocked, @IsCustomer, @IsCompany;
                        decimal @PartDisPer, @LaborDisPer, @Deposit, @CreditLimits, @Resale = 0;
                        DateTime @AddDate, @RegDate, @ModifyDate, @ResaleDate;

                        @ID = Convert.ToInt32(dr["CustID"]);
                        @RegDate = DateTime.Now.Date;

                        if (dr["firstname"] != DBNull.Value && dr["firstname"] != "")
                            @FirstName = Convert.ToString(dr["firstname"]);
                        else
                            @FirstName = "";
                        if (dr["lastname"] != DBNull.Value && dr["lastname"] != "")
                            @LastName = Convert.ToString(dr["lastname"]);
                        else
                            @LastName = "";
                        if (dr["companyname"] != DBNull.Value && dr["companyname"] != "")
                            @CompanyName = Convert.ToString(dr["companyname"]);
                        else
                            @CompanyName = "";
                        if (string.IsNullOrEmpty(@CompanyName))
                        {
                            @IsCustomer = 1;
                            @IsCompany = 0;
                        }
                        else
                        {
                            @IsCustomer = 0;
                            @IsCompany = 1;
                        }
                        if (dr["addr1"] != DBNull.Value && dr["addr1"] != "")
                            @Address = Convert.ToString(dr["addr1"]);
                        else
                            @Address = "";
                        if (dr["phone"] != DBNull.Value && dr["phone"] != "")
                            @ContactPerson = Convert.ToString(dr["phone"]);
                        else
                            @ContactPerson = "";
                        if (dr["email"] != DBNull.Value && dr["email"] != "")
                            @Email = Convert.ToString(dr["email"]);
                        else
                            @Email = "";
                        string postalcode = "";

                        if (dr["postalcode"] != DBNull.Value && dr["postalcode"] != "")
                            postalcode = Convert.ToString(dr["postalcode"]);
                        if (postalcode.Contains("-"))
                        {
                            postalcode = postalcode.Replace("-", "");
                        }
                        else
                        {
                            if (postalcode == "")
                                @ZipCode = 0;
                            else
                                @ZipCode = Convert.ToInt32(dr["postalcode"]);
                        }
                        if (dr["cellphone"] != DBNull.Value && dr["cellphone"] != "")
                            @Phone1 = Convert.ToString(dr["cellphone"]);
                        else
                            @Phone1 = "";
                        if (dr["altphone"] != DBNull.Value && dr["altphone"] != "")
                            @Phone2 = Convert.ToString(dr["altphone"]);
                        else
                            @Phone2 = "";
                        if (dr["altcontact"] != DBNull.Value && dr["altcontact"] != "")
                            @Phone3 = Convert.ToString(dr["altcontact"]);
                        else
                            @Phone3 = "";
                        @Phone4 = "";
                        if (dr["Notes"] != DBNull.Value && dr["Notes"] != "")
                            @Notes = Convert.ToString(dr["Notes"]);
                        else
                            @Notes = "";
                        if (dr["WoNotes"] != DBNull.Value && dr["WoNotes"] != "")
                            @WOMsg = Convert.ToString(dr["WoNotes"]);
                        else
                            @WOMsg = "";
                        if (dr["ShowWoMsg"] != DBNull.Value && dr["ShowWoMsg"] != "")
                            @IsShowMsgOnInvoice = Convert.ToInt32(dr["ShowWoMsg"]);
                        else
                            @IsShowMsgOnInvoice = 0;
                        if (dr["PORequired"] != DBNull.Value && dr["PORequired"] != "")
                            @IsReqPONo = Convert.ToInt32(dr["PORequired"]);
                        else
                            @IsReqPONo = 0;
                        if (dr["PayFET"] != DBNull.Value && dr["PayFET"] != "")
                            @IsPayFET = Convert.ToInt32(dr["PayFET"]);
                        else
                            @IsPayFET = 0;
                        @IsCheckAccepted = 0;
                        @IsNoAutomaticSupplies = 0;
                        if (dr["Postcards"] != DBNull.Value && dr["Postcards"] != "")
                            @IsMail = Convert.ToInt32(dr["Postcards"]);
                        else
                            @IsMail = 0;
                        if (dr["CustPartsDiscount"] != DBNull.Value && dr["CustPartsDiscount"] != "")
                            @PartDisPer = Convert.ToDecimal(dr["CustPartsDiscount"]);
                        else
                            @PartDisPer = 0;
                        if (dr["CustLaborDiscount"] != DBNull.Value && dr["CustLaborDiscount"] != "")
                            @LaborDisPer = Convert.ToDecimal(dr["CustLaborDiscount"]);
                        else
                            @LaborDisPer = 0;
                        if (dr["Deposit"] != DBNull.Value && dr["Deposit"] != "")
                            @Deposit = Convert.ToDecimal(dr["Deposit"]);
                        else
                            @Deposit = 0;

                        string resalenumber = "";

                        if (dr["resalenumber"] != DBNull.Value && dr["resalenumber"] != "")
                            resalenumber = Convert.ToString(dr["resalenumber"]);
                        if (resalenumber.Contains("-"))
                        {
                            resalenumber = resalenumber.Replace("-", "");
                        }
                        else
                        {
                            if (resalenumber == "")
                                @Resale = 0;
                            else
                                @Resale = Convert.ToDecimal(resalenumber);
                        }



                        @ResaleDate = DateTime.Now.Date;
                        @ShipViaID = 9;
                        if (dr["FinanceCharges"] != DBNull.Value && dr["FinanceCharges"] != "")
                            @IsFinanceCharges = Convert.ToInt32(dr["FinanceCharges"]);
                        else
                            @IsFinanceCharges = 0;
                        if (dr["BadDebt"] != DBNull.Value && dr["BadDebt"] != "")
                            @IsBadDebt = Convert.ToInt32(dr["BadDebt"]);
                        else
                            @IsBadDebt = 0;
                        if (dr["PrintStatement"] != DBNull.Value && dr["PrintStatement"] != "")
                            @IsPrintStatement = Convert.ToInt32(dr["PrintStatement"]);
                        else
                            @IsPrintStatement = 0;
                        if (dr["NeverReage"] != DBNull.Value && dr["NeverReage"] != "")
                            @IsNeverReAge = Convert.ToInt32(dr["NeverReage"]);
                        else
                            @IsNeverReAge = 0;
                        @IsNationalAccount = 0;
                        @IsDelete = 0;
                        if (ModifiedID > 0)
                            @ModifyUserID = ModifiedID;
                        else
                            @ModifyUserID = 1;
                        if (dr["Modified"] != DBNull.Value && dr["Modified"] != "")
                            @ModifyDate = Convert.ToDateTime(dr["Modified"]);
                        else
                            @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        if (SaleCatID > 0)
                            @SaleCategoryID = SaleCatID;
                        else
                            @SaleCategoryID = 1;

                        if (SaleTexID > 0)
                            @SaleTaxRateID = SaleTexID;
                        else
                            @SaleTaxRateID = 1;
                        
                        if (dr["pricelevel"] != DBNull.Value && dr["pricelevel"] != "")
                            @PriceLvlID =  getPriceLvlID(Convert.ToString(dr["pricelevel"]));
                        else
                            @PriceLvlID = 3;

                        if (RefByID > 0)
                            @ReferredByID = RefByID;
                        else
                            @ReferredByID = 1;
                        if (SaleTermID > 0)
                            @SaleTrmID = SaleTermID;
                        else
                            @SaleTrmID = 1;
                        
                        @CreditLimits = 0; //----?

                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @IsLocked = 0;
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;

                        string Qry0 = "SET IDENTITY_INSERT [dbo].[Customer] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Customer]" +
                                                "([ID],[RegDate],[Code],[FirstName],[LastName],[IsCustomer],[IsCompany],[CompanyName],[Address],[ContactPerson],[Email],[ZipCode],[Phone1],[Phone2],[Phone3],[Phone4],[Notes],[WOMsg],[IsShowMsgOnInvoice],[IsReqPONo],[IsPayFET],[IsCheckAccepted],[IsMail],[IsNoAutomaticSupplies],[PartDisPer],[LaborDisPer],[Deposit],[Resale],[ResaleDate],[SaleCategoryID],[SaleTaxRateID],[PriceLevelID],[ReferredByID],[SaleTermID],[CreditLimits],[ShipViaID],[IsFinanceCharges],[IsBadDebt],[IsPrintStatement],[IsNeverReAge],[IsNationalAccount],[IsDelete],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                                "(" + @ID + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @ID + "','" + @FirstName + "','" + @LastName + "'," + @IsCustomer + "," + @IsCompany + ",'" + @CompanyName + "','" + @Address + "','" + @ContactPerson + "','" + @Email + "'," + @ZipCode + ",'" + @Phone1 + "','" + @Phone2 + "','" + @Phone3 + "','" + @Phone4 + "','" + @Notes + "','" + @WOMsg + "'," + @IsShowMsgOnInvoice + "," + @IsReqPONo + "," + @IsPayFET + "," + @IsCheckAccepted + "," + @IsMail + "," + @IsNoAutomaticSupplies + "," + @PartDisPer + "," + @LaborDisPer + "," + @Deposit + "," + @Resale + ",'" + @ResaleDate.Year + "-" + @ResaleDate.Month + "-" + @ResaleDate.Day + "'," + SaleCategoryID + "," + @SaleTaxRateID + "," + @PriceLvlID + "," + @ReferredByID + "," + @SaleTrmID + "," + @CreditLimits + "," + @ShipViaID + "," + @IsFinanceCharges + "," + @IsBadDebt + "," + @IsPrintStatement + "," + @IsNeverReAge + "," + @IsNationalAccount + "," + @IsDelete + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[Customer] OFF";

                        //-------------------------------------------------------------------//
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

                        InsertDataIntoAutoVault(InsertQuery);
                        //-------------------------------------------------------------------//
                    }
                    catch { }
                }

            }



        }
        public void InsertCustomerContactsTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[custcontact]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int Custid = 0;
                        if ((dr["CustID"] != DBNull.Value) && (dr["CustID"] != ""))
                        {
                            int CustID1 = Convert.ToInt32(dr["CustID"]);
                            Custid = getCustIDContact(CustID1);
                        }



                        int @MID, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Phone, @AltPhone, @Email, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        DateTime @AddDate, @ModifyDate;
                        if (Custid != 0)
                        {
                            @MID = Convert.ToInt32(dr["CustID"]);
                            if (dr["NAME"] != DBNull.Value && dr["NAME"] != "")
                                @Name = Convert.ToString(dr["NAME"]);
                            else
                                @Name = "";
                            if (dr["phone"] != DBNull.Value && dr["phone"] != "")
                                @Phone = Convert.ToString(dr["phone"]);
                            else
                                @Phone = "";
                            if (dr["AltPhone"] != DBNull.Value && dr["AltPhone"] != "")
                                @AltPhone = Convert.ToString(dr["AltPhone"]);
                            else
                                @AltPhone = "";
                            if (dr["email"] != DBNull.Value && dr["email"] != "")
                                @Email = Convert.ToString(dr["email"]);
                            else
                                @Email = "";
                            @Active = 1;
                            if (dr["TimeModified"] != DBNull.Value && dr["TimeModified"] != "")
                                @AddDate = Convert.ToDateTime(dr["TimeModified"]);
                            else
                                @AddDate = DateTime.Now;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[CustomerContacts]" +
                                                    "([MID],[Name],[phone],[AltPhone],[Email],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WareHouseID],[StoreID])" +
                                                "VALUES" +
                                                "(" + @MID + ",'" + @Name + "','" + @Phone + "','" + @AltPhone + "','" + @Email + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        //------------------------------------------------------//
        //------------------------------------------------------//
        public void InsertCustomerShippingAddressesTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[custshipping]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int @MID, @ZipCode, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @StoreID, @WarehouseID;
                        string @Name, @Address, @Comments, @DocNo, @TrnsJrRef, @TrnsVrNo;
                        DateTime @AddDate, @ModifyDate;
                        if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
                            @MID = Convert.ToInt32(dr["CustID"]);
                        else
                            @MID = 0;
                        if (dr["Addr1"] != DBNull.Value && dr["Addr1"] != "")
                            @Address = Convert.ToString(dr["Addr1"]);
                        else
                            @Address = "";
                        if (dr["Name"] != DBNull.Value && dr["Name"] != "")
                            @Name = Convert.ToString(dr["Name"]);
                        else
                            @Name = "";
                        if (dr["PostalCode"] != DBNull.Value && dr["PostalCode"] != "")
                            @ZipCode = Convert.ToInt32(dr["PostalCode"]);
                        else
                            @ZipCode = 0;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @IsLocked = 0;
                        CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        @ModifyUserID = 1;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        
                        @TrnsJrRef = "";
                        @TrnsVrNo = "";
                        @DocNo = "";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[CustomerShippingAddresses]" +
                                                "([MID],[Name],[Address],[ZipCode],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[TrnsVrNo],[TrnsJrRef],[DocNo],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @MID + ",'" + @Name + "','" + @Address + "'," + @ZipCode + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "','" + @DocNo + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertcreditcardsTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[creditcards]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int CCID = 0;
                        if ((dr["CreditCardID"] != DBNull.Value) && (dr["CreditCardID"] != ""))
                        {
                            string SName = Convert.ToString(dr["CreditCardID"]);
                            CCID = getcreaditCName(SName);
                        }
                        int @ID, @CustomerID, @CCTerms, @Delayed1, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Company, @GLAcct, @GLFeeAcct, @XCharge, @CardType, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        decimal @Fee, @FeeAmt;
                        DateTime @AddDate, @ModifyDate;
                        if (CCID == 0)
                        {
                            if (dr["CreditCardID"] != DBNull.Value && dr["CreditCardID"] != "")
                                @Name = Convert.ToString(dr["CreditCardID"]);
                            else
                                @Name = "";
                            if (dr["CCTerms"] != DBNull.Value && dr["CCTerms"] != "")
                                @CCTerms = Convert.ToInt32(dr["CCTerms"]);
                            else
                                @CCTerms = 0;
                            if (dr["Company"] != DBNull.Value && dr["Company"] != "")
                                @Company = Convert.ToString(dr["Company"]);
                            else
                                @Company = "";
                            if (dr["Delayed1"] != DBNull.Value && dr["Delayed1"] != "")
                                @Delayed1 = Convert.ToInt32(dr["Delayed1"]);
                            else
                                @Delayed1 = 0;
                            @AddDate = DateTime.Now.Date;
                            if (dr["Fee"] != DBNull.Value && dr["Fee"] != "")
                                @Fee = Convert.ToDecimal(dr["Fee"]);
                            else
                                @Fee = 0;
                            if (dr["GLAcct"] != DBNull.Value && dr["GLAcct"] != "")
                                @GLAcct = Convert.ToString(dr["GLAcct"]);
                            else
                                @GLAcct = "";
                            if (dr["GLFeeAcct"] != DBNull.Value && dr["GLFeeAcct"] != "")
                                @GLFeeAcct = Convert.ToString(dr["GLFeeAcct"]);
                            else
                                @GLFeeAcct = "";
                            if (dr["XCharge"] != DBNull.Value && dr["XCharge"] != "")
                                @XCharge = Convert.ToString(dr["XCharge"]);
                            else
                                @XCharge = "";
                            if (dr["CardType"] != DBNull.Value && dr["CardType"] != "")
                                @CardType = Convert.ToString(dr["CardType"]);
                            else
                                @CardType = "";
                            if (dr["FeeAmt"] != DBNull.Value && dr["FeeAmt"] != "")
                                @FeeAmt = Convert.ToDecimal(dr["FeeAmt"]);
                            else
                                @FeeAmt = 0;
                            @Active = 1;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsJrRef = "";
                            @TrnsVrNo = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[CreditCards]" +
                                                    "([Name] ,[Delayed1],[AddDate] ,[Fee] ,[GLAcct] ,[ModifyDate] ,[XCharge] ,[CardType] ,[FeeAmt] ,[Active]  ,[AddUserID] ,[ModifyUserID]  ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                                "VALUES" +
                                                "('" + @Name + "'," + @Delayed1 + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @Fee + ",'" + @GLAcct + "','" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @XCharge + "','" + @CardType + "'," + @FeeAmt + "," + @Active + "," + @AddUserID + "," + @ModifyUserID + ",'" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertTermsTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[terms]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int termsid = 0;
                        if ((dr["TermsID"] != DBNull.Value) && (dr["TermsID"] != ""))
                        {
                            string termsName = Convert.ToString(dr["TermsID"]);
                            termsid = getTermsidbyname(termsName);
                        }
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @IsDefault, @IsCash, @IsVendorOnly, @DiscountTypeID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @DueByDescription;
                        DateTime @AddDate, @ModifyDate;
                        if (termsid == 0)
                        {
                            if (dr["TermsID"] != DBNull.Value && dr["TermsID"] != "")
                                @Name = Convert.ToString(dr["TermsID"]);
                            else
                                @Name = "";
                            if (dr["Cash"] != DBNull.Value && dr["Cash"] != "")
                                @IsCash = Convert.ToInt32(dr["Cash"]);
                            else
                                @IsCash = 0;
                            @IsVendorOnly = 0;
                            DiscountTypeID = 1;
                            @IsDefault = 1;
                            if (dr["DueByText"] != DBNull.Value && dr["DueByText"] != "")
                                @DueByDescription = Convert.ToString(dr["DueByText"]);
                            else
                                @DueByDescription = "";
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "Tr/0/100001";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[Terms]" +
                                                    "([Name] ,[IsCash] ,[IsVendorOnly] ,[DiscountTypeID]  ,[DueByDescription] ,[IsDefault] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef])" +
                                                "VALUES" +
                                                "('" + @Name + "'," + @IsCash + "," + @IsVendorOnly + "," + @DiscountTypeID + ",'" + @DueByDescription + "'," + @IsDefault + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertVendorTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendor]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int @ID, @ZipCode = 0, @TermsID = 0, @CutOffDayID, @BillingZipCode = 0, @IsBillingAddressForCheque, @IsOutsidePartPurchases, @IsUseTheseMarkupsMargins, @Adjustment, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        string @Code, @Name, @Email, @Phone, @Fax, @AlterPhone, @Address, @FederalNo, @BillingAddress, @AccountNo, @Notes, @ContactName, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        decimal @RetailMarkup, @CommercialMarkup, @WholesaleMarkup, @RetailMargin, @CommercialMargin, @WholesaleMargin, @Balance;
                        DateTime @RegDate, @AddDate, @ModifyDate;

                        @ID = Convert.ToInt32(dr["vendorid"]);
                        if (dr["vendorid"] != DBNull.Value && dr["vendorid"] != "")
                            @Code = Convert.ToString(dr["vendorid"]);
                        else
                            @Code = "";
                        if (dr["CompanyName"] != DBNull.Value && dr["CompanyName"] != "")
                            @Name = Convert.ToString(dr["CompanyName"]);
                        else
                            @Name = "";
                        @RegDate = DateTime.Now.Date;
                        if (dr["Email"] != DBNull.Value && dr["Email"] != "")
                            @Email = Convert.ToString(dr["Email"]);
                        else
                            @Email = "";
                        if (dr["Phone"] != DBNull.Value && dr["Phone"] != "")
                            @Phone = Convert.ToString(dr["Phone"]);
                        else
                            @Phone = "";
                        if (dr["Fax"] != DBNull.Value && dr["Fax"] != "")
                            @Fax = Convert.ToString(dr["Fax"]);
                        else
                            @Fax = "";
                        if (dr["AltPhone"] != DBNull.Value && dr["AltPhone"] != "")
                            @AlterPhone = Convert.ToString(dr["AltPhone"]);
                        else
                            @AlterPhone = "";
                        if (dr["Addr1"] != DBNull.Value && dr["Addr1"] != "")
                            @Address = Convert.ToString(dr["Addr1"]);
                        else
                            @Address = "";
                        string Zip = "";

                        if (dr["Zip"] != DBNull.Value && dr["Zip"] != "")
                            Zip = Convert.ToString(dr["Zip"]);
                        if (Zip.Contains("-"))
                        {
                            Zip = Zip.Replace("-", "");
                        }
                        else
                        {
                            if (Zip == "")
                                @ZipCode = 0;
                            else
                                @ZipCode = Convert.ToInt32(dr["Zip"]);
                        }
                        if (dr["FederalID"] != DBNull.Value && dr["FederalID"] != "")
                            @FederalNo = Convert.ToString(dr["FederalID"]);
                        else
                            @FederalNo = "";
                        @TermsID = 1;
                        @CutOffDayID = 1;
                        if (dr["rAddr1"] != DBNull.Value && dr["rAddr1"] != "")
                            @BillingAddress = Convert.ToString(dr["rAddr1"]);
                        else
                            @BillingAddress = "";
                        @BillingZipCode = 85001;
                        @IsBillingAddressForCheque = 0;
                        if (dr["Notes"] != DBNull.Value && dr["Notes"] != "")
                            @Notes = Convert.ToString(dr["Notes"]);
                        else
                            @Notes = "";
                        if (dr["Contact"] != DBNull.Value && dr["Contact"] != "")
                            @ContactName = Convert.ToString(dr["Contact"]);
                        else
                            @ContactName = "";
                        @IsOutsidePartPurchases = 0;
                        @RetailMarkup = 0;
                        @CommercialMarkup = 0;
                        @WholesaleMarkup = 0;
                        @RetailMargin = 0;
                        @CommercialMargin = 0;
                        @WholesaleMargin = 0;
                        @IsUseTheseMarkupsMargins = 0;
                        if (dr["Balance"] != DBNull.Value && dr["Balance"] != "")
                            @Balance = Convert.ToDecimal(dr["Balance"]);
                        else
                            @Balance = 0;
                        if (dr["Adjustment"] != DBNull.Value && dr["Adjustment"] != "")
                            @Adjustment = Convert.ToInt32(dr["Adjustment"]);
                        else
                            @Adjustment = 0;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[Vendor] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Vendor]" +
                                                "([ID],[Code] ,[Name] ,[RegDate] ,[Email] ,[Phone] ,[Fax] ,[AlterPhone] ,[Address] ,[ZipCode] ,[FederalNo] ,[TermsID] ,[CutOffDayID] ,[BillingAddress] ,[BillingZipCode] ,[IsBillingAddressForCheque]  ,[Notes] ,[ContactName] ,[IsOutsidePartPurchases] ,[RetailMarkup] ,[CommercialMarkup] ,[WholesaleMarkup] ,[RetailMargin] ,[CommercialMargin] ,[WholesaleMargin] ,[IsUseTheseMarkupsMargins] ,[Balance] ,[Adjustment] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + ",'" + @Code + "','" + @Name + "','" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @Email + "','" + @Phone + "','" + @Fax + "','" + @AlterPhone + "','" + @Address + "'," + @ZipCode + ",'" + @FederalNo + "'," + @TermsID + "," + @CutOffDayID + ",'" + @BillingAddress + "'," + @BillingZipCode + "," + @IsBillingAddressForCheque + ",'" + @Notes + "','" + @ContactName + "'," + @IsOutsidePartPurchases + "," + @RetailMarkup + "," + @CommercialMarkup + "," + @WholesaleMarkup + "," + @RetailMargin + "," + @CommercialMargin + "," + @WholesaleMargin + "," + @IsUseTheseMarkupsMargins + "," + @Balance + "," + @Adjustment + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[CreditCards] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);

                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertVendorContactTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendorcontact]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int MEID = 0;
                        if ((dr["VendorID"] != DBNull.Value) && (dr["VendorID"] != ""))
                        {
                            string MIDName = Convert.ToString(dr["VendorID"]);
                            MEID = getVendorMID(MIDName);
                        }
                        DateTime @AddDate, @ModifyDate;
                        string @Name, @Phone, @Email, @Comments, @DocNo, @Remarks, @TrnsJrRef, @TrnsVrNo;
                        int @MID = 0, @Active, @AddUserID, @ModifyUserID, @IsLocked;
                        if (@MID > 0)
                            @MID = MEID;
                        else
                            @MID = 1;
                        if (dr["Name"] != DBNull.Value && dr["Name"] != "")
                            @Name = Convert.ToString(dr["Name"]);
                        else
                            @Name = "";
                        if (dr["Phone"] != DBNull.Value && dr["Phone"] != "")
                            @Phone = Convert.ToString(dr["Phone"]);
                        else
                            @Phone = "";
                        if (dr["Email"] != DBNull.Value && dr["Email"] != "")
                            @Email = Convert.ToString(dr["Email"]);
                        else
                            @Email = "";
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 1;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsJrRef = "";
                        @TrnsVrNo = "";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[vendorcontact]" +
                                                "([MID] ,[Name] ,[Phone] ,[Email] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef])" +
                                            "VALUES" +
                                                "(" + @MID + ",'" + @Name + "','" + @Phone + "','" + @Email + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }

            }
        }
        //------------------------------------------------------//        
        public void InsertVehicleTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vehicle]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        DateTime @RegDate, @ProdDate, @DateProduced, @PlateDate, @AddDate, @ModifyDate;
                        string @LicensePlate, @VIN, @FleetNumber, @Make, @SModel, @VehicleModel, @vehicleTransmission, @EngineSize, @TireSize1, @TireSize2, @RimWidth, @Torque, @LugPattern, @FrontPSI, @RearPSI, @InvoiceHeading1, @InvoiceValue1, @InvoiceHeading2, @InvoiceValue2, @InvoiceHeading3, @InvoiceValue3, @InvoiceHeading4, @InvoiceValue4, @InvoiceHeading5, @InvoiceValue5, @InvoiceHeading6, @InvoiceValue6, @Notes, @LicenseState, @Color, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @ID, @IsOwner, @Year, @Mileage, @StateID, @CustomerID, @VehicleYearID, @VehicleMakeID, @VehicleModelID, @VehicleColorID, @VehicleSubModelID, @VehicleTransmissionID, @IsNotesToWO, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        @ID = Convert.ToInt32(dr["VehId"]);
                        @RegDate = DateTime.Now.Date;
                        @IsOwner = 1;
                        if (dr["LicensePlate"] != DBNull.Value && dr["LicensePlate"] != "")
                            @LicensePlate = Convert.ToString(dr["LicensePlate"]);
                        else
                            @LicensePlate = "";
                        if (dr["VIN"] != DBNull.Value && dr["VIN"] != "")
                            @VIN = Convert.ToString(dr["VIN"]);
                        else
                            @VIN = "";
                        if (dr["Fleet"] != DBNull.Value && dr["Fleet"] != "")
                            @FleetNumber = Convert.ToString(dr["Fleet"]);
                        else
                            @FleetNumber = "";
                        @Year = 0;
                        if (dr["make"] != DBNull.Value && dr["make"] != "")
                            @Make = Convert.ToString(dr["make"]);
                        else
                            @Make = "";
                        if (dr["Model"] != DBNull.Value && dr["Model"] != "")
                            @SModel = Convert.ToString(dr["Model"]);
                        else
                            @SModel = "";
                        if (dr["Mileage"] != DBNull.Value && dr["Mileage"] != "")
                            @Mileage = Convert.ToInt32(dr["Mileage"]);
                        else
                            @Mileage = 0;
                        @ProdDate = DateTime.Now.Date;
                        if (dr["CustId"] != DBNull.Value && dr["CustId"] != "")
                            @CustomerID = Convert.ToInt32(dr["CustId"]);
                        else
                            @CustomerID = 0;
                        @VehicleModel = "";
                        if (dr["Transmission"] != DBNull.Value && dr["Transmission"] != "")
                            @vehicleTransmission = Convert.ToString(dr["Transmission"]);
                        else
                            @vehicleTransmission = "";
                        if (dr["EngineSize"] != DBNull.Value && dr["EngineSize"] != "")
                            @EngineSize = Convert.ToString(dr["EngineSize"]);
                        else
                            @EngineSize = "";
                        @DateProduced = DateTime.Now.Date;
                        @PlateDate = DateTime.Now.Date;
                        if (dr["imSize"] != DBNull.Value && dr["imSize"] != "")
                            @TireSize1 = Convert.ToString(dr["imSize"]);
                        else
                            @TireSize1 = "";
                        if (dr["imSize2"] != DBNull.Value && dr["imSize2"] != "")
                            @TireSize2 = Convert.ToString(dr["imSize2"]);
                        else
                            @TireSize2 = "";
                        if (dr["RimWidth"] != DBNull.Value && dr["RimWidth"] != "")
                            @RimWidth = Convert.ToString(dr["RimWidth"]);
                        else
                            @RimWidth = "";
                        if (dr["Torque"] != DBNull.Value && dr["Torque"] != "")
                            @Torque = Convert.ToString(dr["Torque"]);
                        else
                            @Torque = "";
                        @LugPattern = "";
                        if (dr["FrontPSI"] != DBNull.Value && dr["FrontPSI"] != "")
                            @FrontPSI = Convert.ToString(dr["FrontPSI"]);
                        else
                            @FrontPSI = "";
                        if (dr["RearPSI"] != DBNull.Value && dr["RearPSI"] != "")
                            @RearPSI = Convert.ToString(dr["RearPSI"]);
                        else
                            @RearPSI = "";
                        @InvoiceHeading1 = "";
                        @InvoiceValue1 = "";
                        @InvoiceHeading2 = "";
                        @InvoiceValue2 = "";
                        @InvoiceHeading3 = "";
                        @InvoiceValue3 = "";
                        @InvoiceHeading4 = "";
                        @InvoiceValue4 = "";
                        @InvoiceHeading5 = "";
                        @InvoiceValue5 = "";
                        @InvoiceHeading6 = "";
                        @InvoiceValue6 = "";
                        if (dr["Notes"] != DBNull.Value && dr["Notes"] != "")
                            @Notes = Convert.ToString(dr["Notes"]);
                        else
                            @Notes = "";
                        if (dr["State"] != DBNull.Value && dr["State"] != "")
                            @LicenseState = Convert.ToString(dr["State"]);
                        else
                            @LicenseState = "";
                        if (dr["Color"] != DBNull.Value && dr["Color"] != "")
                            @Color = Convert.ToString(dr["Color"]);
                        else
                            @Color = "";
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 1;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsJrRef = "";
                        @TrnsVrNo = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[vehicle] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[vehicle]" +
                                                "([ID],[RegDate] ,[IsOwner] ,[LicensePlate] ,[VIN] ,[FleetNumber] ,[Year] ,[Make] ,[SModel] ,[Mileage] ,[ProdDate]  ,[CustomerID] ,[VehicleModel] ,[vehicleTransmission] ,[EngineSize] ,[DateProduced] ,[PlateDate] ,[TireSize1] ,[TireSize2] ,[RimWidth] ,[Torque] ,[LugPattern] ,[FrontPSI] ,[RearPSI] ,[InvoiceHeading1] ,[InvoiceValue1] ,[InvoiceHeading2] ,[InvoiceValue2] ,[InvoiceHeading3] ,[InvoiceValue3] ,[InvoiceHeading4] ,[InvoiceValue4] ,[InvoiceHeading5] ,[InvoiceValue5] ,[InvoiceHeading6] ,[InvoiceValue6] ,[Notes] ,[LicenseState] ,[Color] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                                "(" + @ID + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "'," + @IsOwner + ",'" + @LicensePlate + "','" + @VIN + "','" + @FleetNumber + "'," + @Year + ",'" + @Make + "','" + @SModel + "'," + @Mileage + ",'" + @ProdDate.Year + "-" + @ProdDate.Month + "-" + @ProdDate.Day + "'," + @CustomerID + ",'" + @VehicleModel + "','" + @vehicleTransmission + "','" + @EngineSize + "','" + @DateProduced.Year + "-" + @DateProduced.Month + "-" + @DateProduced.Day + "','" + @PlateDate.Year + "-" + @PlateDate.Month + "-" + @PlateDate.Day + "','" + @TireSize1 + "','" + @TireSize2 + "','" + @RimWidth + "','" + @Torque + "','" + @LugPattern + "','" + @FrontPSI + "','" + @RearPSI + "','" + @InvoiceHeading1 + "','" + @InvoiceValue1 + "','" + @InvoiceHeading2 + "','" + @InvoiceValue2 + "','" + @InvoiceHeading3 + "','" + @InvoiceValue3 + "','" + @InvoiceHeading4 + "','" + @InvoiceValue4 + "','" + @InvoiceHeading5 + "','" + @InvoiceValue5 + "','" + @InvoiceHeading6 + "','" + @InvoiceValue6 + "','" + @Notes + "','" + @LicenseState + "','" + @Color + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[vehicle] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }

            }
        }
        //------------------------------------------------------//

        //------------------------------------------------------//
        //public void InsertItemTypeTable(DataTable dsdt)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string query = "SELECT * FROM itemtype";
        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();
        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int itmtypeid = 0;
        //                if ((dr["ItemTypeID"] != DBNull.Value) && (dr["ItemTypeID"] != ""))
        //                {
        //                    string ItemTypeName = Convert.ToString(dr["ItemTypeID"]);
        //                    itmtypeid = getItemTypeidbyname(ItemTypeName);
        //                }
        //                string @Initial, Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
        //                int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear;
        //                DateTime @AddDate, @ModifyDate;
        //                if (itmtypeid == 0)
        //                {
        //                    if (dr["ItemType"] != DBNull.Value && dr["ItemType"] != "")
        //                        @Initial = Convert.ToString(dr["ItemType"]);
        //                    else
        //                        @Initial = "";
        //                    if (dr["ItemTypeID"] != DBNull.Value && dr["ItemTypeID"] != "")
        //                        @Name = Convert.ToString(dr["ItemTypeID"]);
        //                    else
        //                        @Name = "";
        //                    @Active = 1;
        //                    @AddDate = DateTime.Now.Date;
        //                    @AddUserID = -2;
        //                    @ModifyUserID = 0;
        //                    @ModifyDate = DateTime.Now.Date;
        //                    @Comments = "";
        //                    @IsLocked = 0;
        //                    @DocNo = "";
        //                    @Remarks = "";
        //                    @CoFinEndYear = 0;
        //                    @TrnsVrNo = "";
        //                    @TrnsJrRef = "";
        //                    string Qry1 = "INSERT INTO [AutoVault].[dbo].[ItemType]" +
        //                                            "([Initial],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[CoFinEndYear] ,[TrnsVrNo] ,[TrnsJrRef])" +
        //                                        "VALUES" +
        //                                        "('" + @Initial + "','" + @Name + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
        //                    string InsertQuery = "\n" + Qry1 + "\n";
        //                    InsertDataIntoAutoVault(InsertQuery);
        //                }
        //            }
        //            catch { }
        //        }
        //    }
        //}
        public void InsertItemGroupTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[itemgroup]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int groupid = 0;
                        if ((dr["Name"] != DBNull.Value) && (dr["Name"] != ""))
                        {
                            string ItemGroupName = Convert.ToString(dr["Name"]);
                            groupid = getItemGroupidbyname(ItemGroupName);
                        }
                        int itmtypeID = 0;
                        if ((dr["gritemtype"] != DBNull.Value) && (dr["gritemtype"] != ""))
                        {
                            string ItemTypeName = Convert.ToString(dr["gritemtype"]);
                            itmtypeID = getitemtypeID(ItemTypeName);
                        }
                        string @Code, @Name;
                        int @GroupTypeID, @IsCosted, @RoundingMethodID, @AssetAcctID, @SalesAcctID, @CGSAcctID, @OutsidePartMarkupsFrom1, @OutsidePartMarkupsFrom2, @OutsidePartMarkupsFrom3, @OutsidePartMarkupsFrom4, @OutsidePartMarkupsFrom5, @OutsidePartMarkupsFrom6, @OutsidePartMarkupsFrom7, @OutsidePartMarkupsFrom8;
                        Decimal @MinimumMarkups, @RetailMarkup, @CommercialMarkup, @WholesaleMarkup, @OutsidePartMarkups1, @OutsidePartMarkups2, @OutsidePartMarkups3, @OutsidePartMarkups4, @OutsidePartMarkups5, @OutsidePartMarkups6, @OutsidePartMarkups7, @OutsidePartMarkups8;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        DateTime @AddDate, @ModifyDate;
                        if (groupid == 0)
                        {
                            if (dr["groupid"] != DBNull.Value && dr["groupid"] != "")
                                @Code = Convert.ToString(dr["groupid"]);
                            else
                                @Code = "";
                            if (dr["Name"] != DBNull.Value && dr["Name"] != "")
                                @Name = Convert.ToString(dr["Name"]);
                            else
                                @Name = "";
                            if (itmtypeID > 0)
                                @GroupTypeID = itmtypeID;
                            else
                                @GroupTypeID = 1;
                            @IsCosted = 1;
                            @RoundingMethodID = 1;
                            @MinimumMarkups = 0;
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[ItemGroup]" +
                                                    "([Code],[Name],[GroupTypeID],[IsCosted],[RoundingMethodID],[MinimumMarkups],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "('" + @Code + "','" + @Name + "'," + @GroupTypeID + "," + @IsCosted + "," + @RoundingMethodID + "," + @MinimumMarkups + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        public void InsertItemManufatureTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "Select distinct(brand) from TempAB.dbo.item order by brand";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int Brandid = 0;
                        if ((dr["brand"] != DBNull.Value) && (dr["brand"] != ""))
                        {
                            string BrandName = Convert.ToString(dr["brand"]);
                            Brandid = getItemManufactureidbyname(BrandName);
                        }
                        string @Description, @Name;
                        int @mType;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        DateTime @AddDate, @ModifyDate;
                        if (Brandid == 0)
                        {
                            if (dr["brand"] != DBNull.Value && dr["brand"] != "")
                                @Name = Convert.ToString(dr["brand"]);
                            else
                                @Name = "";
                            @Description = "";
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[ItemManufacturer]" +
                                                    "([Name],[Description],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "('" + @Name + "','" + @Description + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        public void InsertItemTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[item]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int itmtypeID = 0;
                        if ((dr["ItemTypeID"] != DBNull.Value) && (dr["ItemTypeID"] != ""))
                        {
                            string ItemTypeName = Convert.ToString(dr["ItemTypeID"]);
                            itmtypeID = getitemtypeID(ItemTypeName);
                        }
                        int itmgroupID = 0;
                        if ((dr["GroupID"] != DBNull.Value) && (dr["GroupID"] != ""))
                        {
                            string ItemgroupName = Convert.ToString(dr["GroupID"]);
                            itmgroupID = getitemgroupID(ItemgroupName);
                        }
                        int ManufactureID = 0;
                        if ((dr["Brand"] != DBNull.Value) && (dr["Brand"] != ""))
                        {
                            string ManuName = Convert.ToString(dr["Brand"]);
                            ManufactureID = getManuID(ManuName);
                        }
                        int @ID, @IsAuto, @ItemTypeID, @ItemGroupID, @VendorID, @ManufacturerID, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem;
                        int @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET, @ReOrderMin, @ReOrderMax, @IsSpiffsTemporary, @SpiffsTypeID, @SpiffsPercent;
                        int @IsTemporaryDiscount;
                        string @ItemCode, @ItemSize, @Catalog, @Name, @Location, @BoltPattern, @ManufacturerNo, @VenderPartNo, @DataKeywords, @NAPAKeywords;
                        string @UPCCode, @PostCard, @WebSize, @WebTireSizeA, @WebTireSizeB, @WebTireSizeC, @WebWheelBoltCircle, @WebWheelBoltCircle2, @WebWheelOffset, @WebWheelDiameter, @WebWheelWidth, @WebWheelCenterBore;
                        string @WebWheelFinish, @AutoWareCode;
                        decimal @UnitWeight = 0, @CatalogCost = 0, @LastCost = 0, @TemporaryDiscountedPriceA = 0, @TemporaryDiscountedPriceB = 0, @TemporaryDiscountedPriceC = 0, @TemporaryDiscountedPriceD = 0, @TemporaryDiscountedPriceE = 0, @TemporaryDiscountedPriceF = 0, @TemporaryDiscountedPriceG = 0, @TemporaryDiscountedPriceH = 0, @AverageCost = 0, @FET = 0, @PriceA = 0, @PriceB = 0, @PriceC, @PriceD, @PriceE, @PriceF, @PriceG, @PriceH, @PriceI, @PriceJ, @PriceK, @PriceL, @SpiffsDollarAmount;
                        DateTime @RegDate;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID, @RackID;
                        DateTime @AddDate, @ModifyDate;
                        @ID = Convert.ToInt32(dr["imid"]);
                        @ItemCode = Convert.ToString(dr["imid"]);
                        @IsAuto = 1;
                        @RegDate = DateTime.Now.Date;
                        if (dr["imsize"] != DBNull.Value && dr["imsize"] != "")
                            @ItemSize = Convert.ToString(dr["imsize"]);
                        else
                            @ItemSize = "";
                        if (dr["catalog"] != DBNull.Value && dr["catalog"] != "")
                            @Catalog = Convert.ToString(dr["catalog"]);
                        else
                            @Catalog = "";
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @Name = Convert.ToString(dr["Description"]);
                        else
                            @Name = "";
                        if (itmtypeID > 0)
                            @ItemTypeID = itmtypeID;
                        else
                            @ItemTypeID = 1;
                        if (itmgroupID > 0)
                            @ItemGroupID = itmgroupID;
                        else
                            @ItemGroupID = 1;
                        
                        if (ManufactureID > 0)
                            @ManufacturerID = ManufactureID;
                        else
                            @ManufacturerID = 1;
                        @Location = "";
                        @BoltPattern = "";
                        @ManufacturerNo = "";
                        @VenderPartNo = "";
                        @IsVendorManufacture = 0;
                        if (dr["NoDiscount"] != DBNull.Value && dr["NoDiscount"] != "")
                            @IsDiscountable = Convert.ToInt32(dr["NoDiscount"]);
                        else
                            @IsDiscountable = 0;
                        @IsNotShared = 0;
                        if (dr["Obsolete"] != DBNull.Value && dr["Obsolete"] != "")
                            @IsObsolete = Convert.ToInt32(dr["Obsolete"]);
                        else
                            @IsObsolete = 0;
                        if (dr["RepComm"] != DBNull.Value && dr["RepComm"] != "")
                            @IsRepComm = Convert.ToInt32(dr["RepComm"]);
                        else
                            @IsRepComm = 0;
                        if (dr["Outside"] != DBNull.Value && dr["Outside"] != "")
                            @IsOutsideItem = Convert.ToInt32(dr["Outside"]);
                        else
                            @IsOutsideItem = 0;
                        if (dr["commission"] != DBNull.Value && dr["commission"] != "")
                            @IsMechComm = Convert.ToInt32(dr["commission"]);
                        else
                            @IsMechComm = 0;
                        if (dr["Costable"] != DBNull.Value && dr["Costable"] != "")
                            @IsCosted = Convert.ToInt32(dr["Costable"]);
                        else
                            @IsCosted = 0;
                        if (dr["taxable"] != DBNull.Value && dr["taxable"] != "")
                            @IsTaxable = Convert.ToInt32(dr["taxable"]);
                        else
                            @IsTaxable = 0;
                        if (dr["retread"] != DBNull.Value && dr["retread"] != "")
                            @IsRetread = Convert.ToInt32(dr["retread"]);
                        else
                            @IsRetread = 0;
                        if (dr["stock"] != DBNull.Value && dr["stock"] != "")
                            @IsStocked = Convert.ToInt32(dr["stock"]);
                        else
                            @IsStocked = 0;
                        if (dr["UseFET"] != DBNull.Value && dr["UseFET"] != "")
                            @IsUseFET = Convert.ToInt32(dr["UseFET"]);
                        else
                            @IsUseFET = 0;
                        if (dr["weight"] != DBNull.Value && dr["weight"] != "")
                            @UnitWeight = Convert.ToDecimal(dr["weight"]);
                        else
                            @UnitWeight = 0;
                        if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                            @FET = Convert.ToDecimal(dr["FET"]);
                        else
                            @FET = 0;

                        if (dr["PriceA"] != DBNull.Value && dr["PriceA"] != "")
                            @CatalogCost = Convert.ToDecimal(dr["PriceA"]);
                        else @CatalogCost = 0;
                        if (dr["PriceA"] != DBNull.Value && dr["PriceA"] != "")
                            @LastCost = Convert.ToDecimal(dr["PriceA"]);
                        else @LastCost = 0;                            
                        if (dr["PriceA"] != DBNull.Value && dr["PriceA"] != "")
                            @AverageCost = Convert.ToDecimal(dr["PriceA"]);
                        else @AverageCost = 0;                            
                                                
                        if (dr["PriceA"] != DBNull.Value && dr["PriceA"] != "")
                            @PriceA = Convert.ToDecimal(dr["PriceA"]);
                        else @PriceA = 0;
                        if (dr["PriceB"] != DBNull.Value && dr["PriceB"] != "")
                            @PriceB = Convert.ToDecimal(dr["PriceB"]);
                        else @PriceB = 0;
                        if (dr["PriceC"] != DBNull.Value && dr["PriceC"] != "")
                            @PriceC = Convert.ToDecimal(dr["PriceC"]);
                        else @PriceC = 0;
                        if (dr["PriceD"] != DBNull.Value && dr["PriceD"] != "")
                            @PriceD= Convert.ToDecimal(dr["PriceD"]);
                        else @PriceD = 0;
                        if (dr["PriceE"] != DBNull.Value && dr["PriceE"] != "")
                            @PriceE = Convert.ToDecimal(dr["PriceE"]);
                        else @PriceE = 0;
                        if (dr["PriceF"] != DBNull.Value && dr["PriceF"] != "")
                            @PriceF = Convert.ToDecimal(dr["PriceF"]);
                        else @PriceF = 0;
                        if (dr["PriceG"] != DBNull.Value && dr["PriceG"] != "")
                            @PriceG = Convert.ToDecimal(dr["PriceG"]);
                        else @PriceG = 0;
                        if (dr["PriceH"] != DBNull.Value && dr["PriceH"] != "")
                            @PriceH = Convert.ToDecimal(dr["PriceH"]);
                        else @PriceH = 0;

                        if (dr["PriceI"] != DBNull.Value && dr["PriceI"] != "")
                            @PriceI = Convert.ToDecimal(dr["PriceI"]);
                        else @PriceI = 0;

                        if (dr["PriceJ"] != DBNull.Value && dr["PriceJ"] != "")
                            @PriceJ = Convert.ToDecimal(dr["PriceJ"]);
                        else @PriceJ = 0;

                        if (dr["PriceK"] != DBNull.Value && dr["PriceK"] != "")
                            @PriceK = Convert.ToDecimal(dr["PriceK"]);
                        else @PriceK = 0;

                        if (dr["PriceL"] != DBNull.Value && dr["PriceL"] != "")
                            @PriceL = Convert.ToDecimal(dr["PriceL"]);
                        else @PriceL = 0;

                        if (@CatalogCost <= 0)
                        {
                            Decimal @dprice = 0;
                            if ((@dprice == 0) && (@PriceA > 0)) @dprice = @PriceA;
                            if ((@dprice == 0) && (@PriceB > 0)) @dprice = @PriceB;
                            if ((@dprice == 0) && (@PriceC > 0)) @dprice = @PriceC;
                            if ((@dprice == 0) && (@PriceD > 0)) @dprice = @PriceD;
                            if ((@dprice == 0) && (@PriceE > 0)) @dprice = @PriceE;
                            if ((@dprice == 0) && (@PriceF > 0)) @dprice = @PriceF;
                            if ((@dprice == 0) && (@PriceG > 0)) @dprice = @PriceG;
                            if ((@dprice == 0) && (@PriceH > 0)) @dprice = @PriceH;

                            @CatalogCost = @dprice;
                            @LastCost = @dprice;
                            @AverageCost = @dprice;
                        }

                        if (dr["MinQty"] != DBNull.Value && dr["MinQty"] != "")
                            @ReOrderMin = Convert.ToInt32(dr["MinQty"]);
                        else
                            @ReOrderMin = 0;
                        @ReOrderMax = 0;

                        @DataKeywords = "";
                        @NAPAKeywords = "";
                        @AutoWareCode = "";
                        @IsSpiffsTemporary = 0;
                        @SpiffsDollarAmount = 0;
                        @SpiffsPercent = 0;
                        
                        @UPCCode = "";
                        @IsTemporaryDiscount = 0;
                        
                        if (dr["DiscPriceA"] != DBNull.Value && dr["DiscPriceA"] != "")
                            @TemporaryDiscountedPriceA = Convert.ToDecimal(dr["DiscPriceA"]);
                        else @TemporaryDiscountedPriceA = 0;
                        if (dr["DiscPriceB"] != DBNull.Value && dr["DiscPriceB"] != "")
                            @TemporaryDiscountedPriceB = Convert.ToDecimal(dr["DiscPriceB"]);
                        else @TemporaryDiscountedPriceB = 0;
                        if (dr["DiscPriceC"] != DBNull.Value && dr["DiscPriceC"] != "")
                            @TemporaryDiscountedPriceC = Convert.ToDecimal(dr["DiscPriceC"]);
                        else @TemporaryDiscountedPriceC = 0;
                        if (dr["DiscPriceD"] != DBNull.Value && dr["DiscPriceD"] != "")
                            @TemporaryDiscountedPriceD = Convert.ToDecimal(dr["DiscPriceD"]);
                        else @TemporaryDiscountedPriceD = 0;
                        if (dr["DiscPriceE"] != DBNull.Value && dr["DiscPriceE"] != "")
                            @TemporaryDiscountedPriceE = Convert.ToDecimal(dr["DiscPriceE"]);
                        else @TemporaryDiscountedPriceE = 0;
                        if (dr["DiscPriceF"] != DBNull.Value && dr["DiscPriceF"] != "")
                            @TemporaryDiscountedPriceF = Convert.ToDecimal(dr["DiscPriceF"]);
                        else @TemporaryDiscountedPriceF = 0;
                        
                        
                       
                        @PostCard = "";
                        if (dr["WebSize"] != DBNull.Value && dr["WebSize"] != "")
                            @WebSize = Convert.ToString(dr["WebSize"]);
                        else
                            @WebSize = "";
                        if (dr["WebTireSizeA"] != DBNull.Value && dr["WebTireSizeA"] != "")
                            @WebTireSizeA = Convert.ToString(dr["WebTireSizeA"]);
                        else
                            @WebTireSizeA = "";
                        if (dr["WebTireSizeB"] != DBNull.Value && dr["WebTireSizeB"] != "")
                            @WebTireSizeB = Convert.ToString(dr["WebTireSizeB"]);
                        else
                            @WebTireSizeB = "";
                        if (dr["WebTireSizeC"] != DBNull.Value && dr["WebTireSizeC"] != "")
                            @WebTireSizeC = Convert.ToString(dr["WebTireSizeC"]);
                        else
                            @WebTireSizeC = "";
                        if (dr["WebWheelBoltCircle"] != DBNull.Value && dr["WebWheelBoltCircle"] != "")
                            @WebWheelBoltCircle = Convert.ToString(dr["WebWheelBoltCircle"]);
                        else
                            @WebWheelBoltCircle = "";
                        if (dr["WebWheelBoltCircle2"] != DBNull.Value && dr["WebWheelBoltCircle2"] != "")
                            @WebWheelBoltCircle2 = Convert.ToString(dr["WebWheelBoltCircle2"]);
                        else
                            @WebWheelBoltCircle2 = "";
                        if (dr["WebWheelOffset"] != DBNull.Value && dr["WebWheelOffset"] != "")
                            @WebWheelOffset = Convert.ToString(dr["WebWheelOffset"]);
                        else
                            @WebWheelOffset = "";
                        if (dr["WebWheelDiameter"] != DBNull.Value && dr["WebWheelDiameter"] != "")
                            @WebWheelDiameter = Convert.ToString(dr["WebWheelDiameter"]);
                        else
                            @WebWheelDiameter = "";
                        if (dr["WebWheelWidth"] != DBNull.Value && dr["WebWheelWidth"] != "")
                            @WebWheelWidth = Convert.ToString(dr["WebWheelWidth"]);
                        else
                            @WebWheelWidth = "";
                        if (dr["WebWheelCenterBore"] != DBNull.Value && dr["WebWheelCenterBore"] != "")
                            @WebWheelCenterBore = Convert.ToString(dr["WebWheelCenterBore"]);
                        else
                            @WebWheelCenterBore = "";
                        if (dr["WebWheelFinish"] != DBNull.Value && dr["WebWheelFinish"] != "")
                            @WebWheelFinish = Convert.ToString(dr["WebWheelFinish"]);
                        else
                            @WebWheelFinish = "";
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @RackID = 1;
                        @StoreID = 1;
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[Item] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Item]" +
                                            "([ID],[ItemCode] ,[IsAuto] ,[RegDate] ,[ItemSize] ,[Catalog] ,[Name] ,[ItemTypeID] ,[ItemGroupID] ,[ManufacturerID] ,[Location] ,[BoltPattern] ,[ManufacturerNo] ,[VenderPartNo] ,[IsVendorManufacture] ,[IsDiscountable] ,[IsNotShared] ,[IsObsolete] ,[IsRepComm] ,[IsOutsideItem] ,[IsMechComm] ,[IsCosted] ,[IsTaxable] ,[IsRetread] ,[IsStocked] ,[IsUseFET] ,[UnitWeight] ,[CatalogCost] ,[LastCost] ,[AverageCost] ,[FET] ,[PriceA] ,[PriceB] ,[PriceC] ,[PriceD] ,[PriceE] ,[PriceF] ,[PriceG] ,[PriceH],[PriceI] ,[PriceJ] ,[PriceK] ,[PriceL] ,[ReOrderMin] ,[ReOrderMax] ,[DataKeywords] ,[NAPAKeywords] ,[AutoWareCode] ,[IsSpiffsTemporary] ,[SpiffsDollarAmount] ,[SpiffsPercent] ,[UPCCode] ,[IsTemporaryDiscount] ,[TemporaryDiscountedPriceA] ,[TemporaryDiscountedPriceB] ,[TemporaryDiscountedPriceC] ,[TemporaryDiscountedPriceD] ,[TemporaryDiscountedPriceE] ,[TemporaryDiscountedPriceF] ,[TemporaryDiscountedPriceG] ,[TemporaryDiscountedPriceH] ,[PostCard] ,[WebSize] ,[WebTireSizeA] ,[WebTireSizeB] ,[WebTireSizeC] ,[WebWheelBoltCircle] ,[WebWheelBoltCircle2] ,[WebWheelOffset] ,[WebWheelDiameter] ,[WebWheelWidth] ,[WebWheelCenterBore] ,[WebWheelFinish] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID],[RackID] )" +
                                        "VALUES" +
                                            "(" + @ID + ",'" + @ItemCode + "'," + @IsAuto + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @ItemSize + "','" + @Catalog + "','" + @Name + "'," + @ItemTypeID + "," + @ItemGroupID + "," + @ManufacturerID + ",'" + @Location + "','" + @BoltPattern + "','" + @ManufacturerNo + "','" + @VenderPartNo + "'," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @UnitWeight + "," + @CatalogCost + "," + @LastCost + "," + @AverageCost + "," + @FET + "," + @PriceA + "," + @PriceB + "," + @PriceC + "," + @PriceD + "," + @PriceE + "," + @PriceF + "," + @PriceG + "," + @PriceH + "  ," + @PriceI + "," + @PriceJ + "," + @PriceK + "," + @PriceL + "  ," + @ReOrderMin + "," + @ReOrderMax + ",'" + @DataKeywords + "','" + @NAPAKeywords + "','" + @AutoWareCode + "'," + @IsSpiffsTemporary + "," + @SpiffsDollarAmount + "," + @SpiffsPercent + ",'" + @UPCCode + "'," + @IsTemporaryDiscount + "," + @TemporaryDiscountedPriceA + "," + @TemporaryDiscountedPriceB + "," + @TemporaryDiscountedPriceC + "," + @TemporaryDiscountedPriceD + "," + @TemporaryDiscountedPriceE + "," + @TemporaryDiscountedPriceF + "," + @TemporaryDiscountedPriceG + "," + @TemporaryDiscountedPriceH + ",'" + @PostCard + "','" + @WebSize + "','" + @WebTireSizeA + "','" + @WebTireSizeB + "','" + @WebTireSizeC + "','" + @WebWheelBoltCircle + "','" + @WebWheelBoltCircle2 + "','" + @WebWheelOffset + "','" + @WebWheelDiameter + "','" + @WebWheelWidth + "','" + @WebWheelCenterBore + "','" + @WebWheelFinish + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + "," + @RackID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[Item] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertWareHousePackageTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[itempackage]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int @ID, @ShowInButton, @Color, @PackageTypeID, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID;
                        string @Catalog, @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        decimal @PackageWithTax;
                        DateTime @AddDate, @ModifyDate;
                        @ID = Convert.ToInt32(dr["ipid"]);
                        if (dr["Catalog"] != DBNull.Value && dr["Catalog"] != "")
                            @Catalog = Convert.ToString(dr["Catalog"]);
                        else
                            @Catalog = "";
                        if (dr["pkdescription"] != DBNull.Value && dr["pkdescription"] != "")
                            @Name = Convert.ToString(dr["pkdescription"]);
                        else
                            @Name = "";
                        if (dr["pkPrice"] != DBNull.Value && dr["pkPrice"] != "")
                            @PackageWithTax = Convert.ToDecimal(dr["pkPrice"]);
                        else
                            @PackageWithTax = 0;
                        @ShowInButton = 1;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[WarehousePackages] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[WarehousePackages]" +
                                                "([ID],[Catalog] ,[Name] ,[PackageWithTax] ,[ShowInButton] ,[Color]  ,[PackageTypeID] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + ",'" + @Catalog + "','" + @Name + "'," + @PackageWithTax + "," + @ShowInButton + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[WarehousePackages] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertItemGetFromInvoiceDetailsTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            List<DataColumn> listCols = null;
            try
            {
                string query = "Select distinct[Catalog] as [Catalog] from TempAB.dbo.invoicedet where [Catalog] in (Select  [Catalog] from TempAB.dbo.invoicedet where [Catalog] is not null and [Catalog] <> '' and [Catalog] not in (Select [Catalog] from TempAB.dbo.item) and [Catalog] != 'FEUL' )order by [Catalog]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string itemCatalog = Convert.ToString(dr["Catalog"]);
                    if (!string.IsNullOrEmpty(itemCatalog))
                    {
                        string query = "Select TOP(1) * from TempAB.dbo.invoicedet where [Catalog] = '" + itemCatalog + "'";
                        SqlConnection conn = new SqlConnection(TempABSqlConnectionString);
                        SqlCommand cmd = new SqlCommand(query, conn);
                        conn.Open();
                        SqlDataReader dr1 = cmd.ExecuteReader();
                        DataTable dtSchema = dr1.GetSchemaTable();
                        if (dtSchema != null)
                        {
                            if (dt1.Rows.Count <= 0)
                            {
                                listCols = new List<DataColumn>();
                                foreach (DataRow drow in dtSchema.Rows)
                                {
                                    string columnName = System.Convert.ToString(drow["ColumnName"]);
                                    DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                                    column.Unique = (bool)drow["IsUnique"];
                                    column.AllowDBNull = (bool)drow["AllowDBNull"];
                                    column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                                    listCols.Add(column);
                                    dt1.Columns.Add(column);
                                }
                            }
                        }
                        while (dr1.Read())
                        {
                            DataRow dataRow = dt1.NewRow();
                            for (int i = 0; i < listCols.Count; i++)
                            {
                                dataRow[((DataColumn)listCols[i])] = dr1[i];
                            }
                            dt1.Rows.Add(dataRow);
                        }
                    }
                }
            }
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    try
                    {
                        int itmCode = getitemMaxID();
                        int itmtypeID = 0;
                        if ((dr["ItemType"] != DBNull.Value) && (dr["ItemType"] != ""))
                        {
                            string ItemTypeName = Convert.ToString(dr["ItemType"]);
                            itmtypeID = getitemtypeID(ItemTypeName);
                        }
                        int itmgroupID = 0;
                        if ((dr["GroupID"] != DBNull.Value) && (dr["GroupID"] != ""))
                        {
                            string ItemgroupName = Convert.ToString(dr["GroupID"]);
                            itmgroupID = getitemgroupID(ItemgroupName);
                        }
                        int ManufactureID = 0;
                        if ((dr["brand"] != DBNull.Value) && (dr["brand"] != ""))
                        {
                            string ManuName = Convert.ToString(dr["brand"]);
                            ManufactureID = getManuID(ManuName);
                        }
                        int @IsAuto, @ItemTypeID, @ItemGroupID, @ManufacturerID, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem;
                        int @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET, @ReOrderMin, @ReOrderMax, @IsSpiffsTemporary, @SpiffsTypeID, @SpiffsPercent;
                        int @IsTemporaryDiscount;
                        string @ItemCode, @ItemSize, @Catalog, @Name, @Location, @BoltPattern, @ManufacturerNo, @VenderPartNo, @DataKeywords, @NAPAKeywords;
                        string @UPCCode, @PostCard, @WebSize, @WebTireSizeA, @WebTireSizeB, @WebTireSizeC, @WebWheelBoltCircle, @WebWheelBoltCircle2, @WebWheelOffset, @WebWheelDiameter, @WebWheelWidth, @WebWheelCenterBore;
                        string @WebWheelFinish, @AutoWareCode;
                        decimal @UnitWeight, @CatalogCost, @LastCost, @AverageCost, @FET, @RetailPercent, @PriceA, @PriceB, @PriceC, @PriceD, @PriceE, @PriceF, @PriceG, @PriceH, @PriceI, @PriceJ, @PriceK, @PriceL, @CommercialPercent, @CommercialPrice, @WholesalePercent, @WholesalePrice, @TemporaryDiscountedRetail, @TemporaryDiscountedCommercial, @TemporaryDiscountedWholesale, @SpiffsDollarAmount;
                        DateTime @RegDate, @SpiffsDateFrom, @SpiffsDateTo, @TemporaryDiscountDateFrom, @TemporaryDiscountDateTo;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CompanyID, @WarehouseID, @StoreID, @RackID;
                        DateTime @AddDate, @ModifyDate;
                        @IsAuto = 1;
                        @ItemCode = Convert.ToString(itmCode);
                        @RegDate = DateTime.Now.Date;
                        if (dr["catalog"] != DBNull.Value && dr["catalog"] != "")
                            @Catalog = Convert.ToString(dr["catalog"]);
                        else
                            @Catalog = "";
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @Name = Convert.ToString(dr["Description"]);
                        else
                            @Name = "";
                        if (itmtypeID > 0)
                            @ItemTypeID = itmtypeID;
                        else
                            @ItemTypeID = 1;
                        if (itmgroupID > 0)
                            @ItemGroupID = itmgroupID;
                        else
                            @ItemGroupID = 1;
                        if (dr["NoDiscount"] != DBNull.Value && dr["NoDiscount"] != "")
                            @IsDiscountable = Convert.ToInt32(dr["NoDiscount"]);
                        else
                            @IsDiscountable = 0;
                        if (dr["RepComm"] != DBNull.Value && dr["RepComm"] != "")
                            @IsRepComm = Convert.ToInt32(dr["RepComm"]);
                        else
                            @IsRepComm = 0;
                        if (dr["Outside"] != DBNull.Value && dr["Outside"] != "")
                            @IsOutsideItem = Convert.ToInt32(dr["Outside"]);
                        else
                            @IsOutsideItem = 0;
                        if (dr["Commission"] != DBNull.Value && dr["Commission"] != "")
                            @IsMechComm = Convert.ToInt32(dr["Commission"]);
                        else
                            @IsMechComm = 0;
                        if (dr["Costable"] != DBNull.Value && dr["Costable"] != "")
                            @IsCosted = Convert.ToInt32(dr["Costable"]);
                        else
                            @IsCosted = 0;
                        if (dr["taxable"] != DBNull.Value && dr["taxable"] != "")
                            @IsTaxable = Convert.ToInt32(dr["taxable"]);
                        else
                            @IsTaxable = 0;
                        if (dr["retread"] != DBNull.Value && dr["retread"] != "")
                            @IsRetread = Convert.ToInt32(dr["retread"]);
                        else
                            @IsRetread = 0;
                        if (dr["stock"] != DBNull.Value && dr["stock"] != "")
                            @IsStocked = Convert.ToInt32(dr["stock"]);
                        else
                            @IsStocked = 0;
                        if (dr["UseFET"] != DBNull.Value && dr["UseFET"] != "")
                            @IsUseFET = Convert.ToInt32(dr["UseFET"]);
                        else
                            @IsUseFET = 0;
                        @UnitWeight = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @CatalogCost = Convert.ToInt32(dr["Cost"]);
                        else
                            @CatalogCost = 0;
                        if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                            @FET = Convert.ToDecimal(dr["FET"]);
                        else
                            @FET = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @LastCost = Convert.ToInt32(dr["Cost"]);
                        else
                            @LastCost = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @AverageCost = Convert.ToInt32(dr["Cost"]);
                        else
                            @AverageCost = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceA = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceA = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceB = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceB = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceC = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceC = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @CommercialPrice = Convert.ToInt32(dr["Price"]);
                        else
                            @CommercialPrice = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceD = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceD = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceE = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceE = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceF = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceF = 0;
                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceG = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceG = 0;

                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceH = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceH = 0;

                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceI = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceI = 0;

                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceJ = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceJ = 0;

                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceK = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceK = 0;

                        if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                            @PriceL = Convert.ToInt32(dr["Price"]);
                        else
                            @PriceL = 0;

                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @IsLocked = 0;
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        @RackID = 1;

                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Item]" +
                                            "([ItemCode], [IsAuto],[RegDate],[Catalog],[Name],[ItemTypeID],[ItemGroupID],[IsDiscountable],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[UnitWeight],[CatalogCost],[LastCost],[AverageCost],[FET],[PriceA],[PriceB],[PriceC],[PriceD],[PriceE],[PriceF],[PriceG],[PriceH],[PriceI],[PriceJ],[PriceK],[PriceL],[Active],[AddDate],[AddUserID],[ModifyUserID],[IsLocked],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID],[RackID])" +
                                        "VALUES" +
                                            "('" + @ItemCode + "'," + @IsAuto + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @Catalog + "','" + @Name + "'," + @ItemTypeID + "," + @ItemGroupID + "," + @IsDiscountable + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @UnitWeight + "," + @CatalogCost + "," + @LastCost + "," + @AverageCost + "," + @FET + "," + @PriceA + "," + @PriceB + "," + @PriceC + "," + @PriceD + "," + @PriceE + "," + @PriceF + "," + @PriceG + "," + @PriceH + "," + @PriceI + "," + @PriceJ + "," + @PriceK + "," + @PriceL + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + "," + @IsLocked + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + "," + @RackID + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertWorkOrderTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoice] order by invid";
                //string query = "SELECT * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '')";
                string query = "select * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '') and [Status] in ('Invoice','W/O') and [PONum] not like 'NEGATE%' ";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int RepId = 0;
                        if ((dr["RepID"] != DBNull.Value) && (dr["RepID"] != ""))
                        {
                            string RepName = Convert.ToString(dr["RepID"]);
                            RepId = getRepIDID(RepName);
                        }
                        int SaleCatId = 3;
                        if ((dr["SaleCatID"] != DBNull.Value) && (dr["SaleCatID"] != ""))
                        {
                            string SaleCatName = Convert.ToString(dr["SaleCatID"]);
                            SaleCatId = getSaleCatID(SaleCatName);
                        }
                        int SaleTerID = 2;
                        if ((dr["TermsID"] != DBNull.Value) && (dr["TermsID"] != ""))
                        {
                            string SaleTermName = Convert.ToString(dr["TermsID"]);
                            SaleTerID = getSaleTermID(SaleTermName);
                        }
                        int @ID, @WorkOrderNo, @IsQutation, @IsWorkOrder, @IsCustomerOrder, @CustomerID, @IsNoVehicle, @VehicleID, @SaleRepID = 0, @MechID, @ReferredByID, @SaleCategoryID, @PriceLevelID, @SaleTaxRateID, @SaleTermID = 0, @ShipViaID, @WarehouseBayID, @CreatedByID;
                        int @IsNegated, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        string @Notes, @PONo, @Status, @DocNo, @Remarks, @TrnsVrNo, @Comments, @TrnsJrRef;
                        decimal @Mileage, @MileageOut, @PartsPrice, @LaborPrice, @OtherPrice, @FET, @Taxable, @Tax, @Discount, @PartDisPer, @LaborDisPer, @Total;
                        DateTime @AddDate, @ModifyDate, @RegDate, @PickupDate, @PickupTime;

                        @ID = Convert.ToInt32(dr["invid"]);
                        if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                            @RegDate = Convert.ToDateTime(dr["InvDate"]);
                        else
                            @RegDate = DateTime.Now;

                        @CoFinEndYear = @RegDate.Year;
                        if (dr["invid"] != DBNull.Value && dr["invid"] != "")
                            @WorkOrderNo = Convert.ToInt32(dr["invid"]);
                        else
                            @WorkOrderNo = 0;
                        if (dr["InvNum"] != DBNull.Value && dr["InvNum"] != "")
                            @Notes = Convert.ToString(dr["InvNum"]);
                        else
                            @Notes = "";

                        @IsQutation = 0;
                        @IsWorkOrder = 1;
                        @IsCustomerOrder = 0;

                        if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
                            @CustomerID = Convert.ToInt32(dr["CustID"]);
                        else
                            @CustomerID = 0;
                        if (dr["VehId"] != DBNull.Value && dr["VehId"] != "")
                            @VehicleID = Convert.ToInt32(dr["VehId"]);
                        else
                            @VehicleID = 0;

                        //if (@VehicleID != 0)
                        //    @IsNoVehicle = 1;
                        //else
                        //    @IsNoVehicle = 0;
                        @IsNoVehicle = 1;

                        if (dr["Mileage"] != DBNull.Value && dr["Mileage"] != "")
                            @Mileage = Convert.ToDecimal(dr["Mileage"]);
                        else
                            @Mileage = 0;
                        if (dr["RecMiles"] != DBNull.Value && dr["RecMiles"] != "")
                            @MileageOut = Convert.ToDecimal(dr["RecMiles"]);
                        else
                            @MileageOut = 0;

                        //if (dr["PONum"] != DBNull.Value && dr["PONum"] != "")
                        //    @PONo = Convert.ToString(dr["PONum"]);
                        //else
                        //    @PONo = "";

                        if (RepId > 0)
                            @SaleRepID = RepId;
                        else
                            @SaleRepID = -2;

                        if (dr["MechID"] != DBNull.Value && dr["MechID"] != "")
                            @MechID = Convert.ToInt32(dr["MechID"]);
                        

                        @ReferredByID = 7;
                        if (SaleCatId > 0)
                            @SaleCategoryID = SaleCatId;
                        else
                            @SaleCategoryID = 3;

                        @PriceLevelID = 1; //--?? [PriceLevel]
                        //--Profit--?? [Profit]
                        @SaleTaxRateID = 1;

                        if (SaleTerID > 0)
                            @SaleTermID = SaleTerID;
                        else
                            @SaleTermID = 2;

                        @ShipViaID = 9;
                        @WarehouseBayID = 1;

                        @CreatedByID = -2;

                        if (dr["TaxableParts"] != DBNull.Value && dr["TaxableParts"] != "")
                            @PartsPrice = Convert.ToDecimal(dr["TaxableParts"]);
                        else
                            @PartsPrice = 0;

                        if (dr["TaxableLabor"] != DBNull.Value && dr["TaxableLabor"] != "")
                            @LaborPrice = Convert.ToDecimal(dr["TaxableLabor"]);
                        else
                            @LaborPrice = 0;

                        @OtherPrice = 0;
                        if (dr["FETTotal"] != DBNull.Value && dr["FETTotal"] != "")
                            @FET = Convert.ToDecimal(dr["FETTotal"]);
                        else
                            @FET = 0;

                        if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
                            @Taxable = Convert.ToDecimal(dr["Taxable"]);
                        else
                            @Taxable = 0;

                        if (dr["Tax"] != DBNull.Value && dr["Tax"] != "")
                            @Tax = Convert.ToDecimal(dr["Tax"]);
                        else
                            @Tax = 0;
                        
                        if (dr["DiscountAmt"] != DBNull.Value && dr["DiscountAmt"] != "")
                            @Discount = Convert.ToDecimal(dr["DiscountAmt"]);
                        else
                            @Discount = 0;
                                                
                        if (dr["SDiscountParts"] != DBNull.Value && dr["SDiscountParts"] != "")
                            @PartDisPer = Convert.ToDecimal(dr["SDiscountParts"]);
                        else
                            @PartDisPer = 0;

                        if (dr["SDiscountLabor"] != DBNull.Value && dr["SDiscountLabor"] != "")
                            @LaborDisPer = Convert.ToDecimal(dr["SDiscountLabor"]);
                        else
                            @LaborDisPer = 0;

                        if (dr["InvTotal"] != DBNull.Value && dr["InvTotal"] != "")
                            @Total = Convert.ToDecimal(dr["InvTotal"]);
                        else
                            @Total = 0;

                        if (dr["WoDate"] != DBNull.Value && dr["WoDate"] != "")
                            @PickupDate = Convert.ToDateTime(dr["WoDate"]);
                        else
                            @PickupDate = DateTime.Now;

                        if (dr["Status"] != DBNull.Value && dr["Status"] != "")
                            @Status = Convert.ToString(dr["Status"]);
                        else
                            @Status = "";

                        if (dr["NegatedInvID"] != DBNull.Value && dr["NegatedInvID"] != "")
                            @IsNegated = Convert.ToInt32(dr["NegatedInvID"]);
                        else
                            @IsNegated = 0;

                        @Active = 1;

                        if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                            @AddDate = Convert.ToDateTime(dr["InvDate"]);
                        else
                            @AddDate = DateTime.Now;

                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        if (dr["PaidBy"] != DBNull.Value && dr["PaidBy"] != "")
                            @Comments = Convert.ToString(dr["PaidBy"]);
                        else
                            @Comments = "";

                        @IsLocked = 0;

                        if (dr["SchedStatus"] != DBNull.Value && dr["SchedStatus"] != "")
                            @DocNo = Convert.ToString(dr["SchedStatus"]);
                        else
                            @DocNo = "";

                        if (dr["WoNum"] != DBNull.Value && dr["WoNum"] != "")
                            @Remarks = Convert.ToString(dr["WoNum"]);
                        else
                            @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;

                        getWOAutoNO(Convert.ToInt32(dr["invid"]));

                        string Qry0 = "SET IDENTITY_INSERT [dbo].[WorkOrder] ON";
                        
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrder]" +
                                            "([ID],[RegDate] ,[WorkOrderNo] ,[Notes] ,[IsQutation] ,[IsWorkOrder] ,[IsCustomerOrder] ,[CustomerID] ,[IsNoVehicle] ,[Mileage] ,[MileageOut] ,[SaleRepID] ,[ReferredByID] ,[SaleCategoryID] ,[PriceLevelID] ,[SaleTaxRateID] ,[SaleTermID] ,[ShipViaID] ,[WarehouseBayID] ,[CreatedByID] ,[PartsPrice] ,[LaborPrice] ,[OtherPrice] ,[FET] ,[Taxable] ,[Tax] ,[Discount] ,[PartDisPer] ,[LaborDisPer] ,[Total] ,[PickupDate]  ,[Status] ,[IsNegated] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[CoFinEndYear] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "'," + @WorkOrderNo + ",'" + @Notes + "'," + @IsQutation + "," + @IsWorkOrder + "," + @IsCustomerOrder + "," + @CustomerID + "," + @IsNoVehicle + "," + @Mileage + "," + @MileageOut + "," + @SaleRepID + "," + @ReferredByID + "," + @SaleCategoryID + "," + @PriceLevelID + "," + @SaleTaxRateID + "," + @SaleTermID + "," + @ShipViaID + "," + @WarehouseBayID + "," + @CreatedByID + "," + @PartsPrice + "," + @LaborPrice + "," + @OtherPrice + "," + @FET + "," + @Taxable + "," + @Tax + "," + @Discount + "," + @PartDisPer + "," + @LaborDisPer + "," + @Total + ",'" + @PickupDate.Year + "-" + @PickupDate.Month + "-" + @PickupDate.Day + "','" + @Status + "'," + @IsNegated + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[WorkOrder] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
       
        //public void InsertWorkOrderTable2(DataTable dsdt)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        //string query = "SELECT * FROM [TempAB].[dbo].[invoice] order by invid";
        //        //string query = "SELECT * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '')";
        //        string query = "select * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '') and [Status] in ('Invoice','W/O') and [PONum] like 'NEGATE%'";
        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();
        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int RepId = 0;
        //                if ((dr["RepID"] != DBNull.Value) && (dr["RepID"] != ""))
        //                {
        //                    string RepName = Convert.ToString(dr["RepID"]);
        //                    RepId = getRepIDID(RepName);
        //                }
        //                int SaleCatId = 3;
        //                if ((dr["SaleCatID"] != DBNull.Value) && (dr["SaleCatID"] != ""))
        //                {
        //                    string SaleCatName = Convert.ToString(dr["SaleCatID"]);
        //                    SaleCatId = getSaleCatID(SaleCatName);
        //                }
        //                int SaleTerID = 2;
        //                if ((dr["TermsID"] != DBNull.Value) && (dr["TermsID"] != ""))
        //                {
        //                    string SaleTermName = Convert.ToString(dr["TermsID"]);
        //                    SaleTerID = getSaleTermID(SaleTermName);
        //                }
        //                int @ID, @WorkOrderNo, @IsQutation, @IsWorkOrder, @IsCustomerOrder, @CustomerID, @IsNoVehicle, @VehicleID, @SaleRepID = 0, @MechID, @ReferredByID, @SaleCategoryID, @PriceLevelID, @SaleTaxRateID, @SaleTermID = 0, @ShipViaID, @WarehouseBayID, @CreatedByID;
        //                int @IsNegated, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
        //                string @Notes, @PONo, @Status, @DocNo, @Remarks, @TrnsVrNo, @Comments, @TrnsJrRef;
        //                decimal @Mileage, @MileageOut, @PartsPrice, @LaborPrice, @OtherPrice, @FET, @Taxable, @Tax, @Discount, @PartDisPer, @LaborDisPer, @Total;
        //                DateTime @AddDate, @ModifyDate, @RegDate, @PickupDate, @PickupTime;

        //                @ID = Convert.ToInt32(dr["invid"]);
        //                if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
        //                    @RegDate = Convert.ToDateTime(dr["InvDate"]);
        //                else
        //                    @RegDate = DateTime.Now;

        //                @CoFinEndYear = @RegDate.Year;
        //                if (dr["invid"] != DBNull.Value && dr["invid"] != "")
        //                    @WorkOrderNo = Convert.ToInt32(dr["invid"]);
        //                else
        //                    @WorkOrderNo = 0;
        //                if (dr["InvNum"] != DBNull.Value && dr["InvNum"] != "")
        //                    @Notes = Convert.ToString(dr["InvNum"]);
        //                else
        //                    @Notes = "";

        //                @IsQutation = 0;
        //                @IsWorkOrder = 1;
        //                @IsCustomerOrder = 0;

        //                if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
        //                    @CustomerID = Convert.ToInt32(dr["CustID"]);
        //                else
        //                    @CustomerID = 0;
        //                if (dr["VehId"] != DBNull.Value && dr["VehId"] != "")
        //                    @VehicleID = Convert.ToInt32(dr["VehId"]);
        //                else
        //                    @VehicleID = 0;

        //                //if (@VehicleID != 0)
        //                //    @IsNoVehicle = 1;
        //                //else
        //                //    @IsNoVehicle = 0;
        //                @IsNoVehicle = 1;

        //                if (dr["Mileage"] != DBNull.Value && dr["Mileage"] != "")
        //                    @Mileage = Convert.ToDecimal(dr["Mileage"]);
        //                else
        //                    @Mileage = 0;
        //                if (dr["RecMiles"] != DBNull.Value && dr["RecMiles"] != "")
        //                    @MileageOut = Convert.ToDecimal(dr["RecMiles"]);
        //                else
        //                    @MileageOut = 0;

        //                //if (dr["PONum"] != DBNull.Value && dr["PONum"] != "")
        //                //    @PONo = Convert.ToString(dr["PONum"]);
        //                //else
        //                //    @PONo = "";

        //                if (RepId > 0)
        //                    @SaleRepID = RepId;
        //                else
        //                    @SaleRepID = -2;

        //                if (dr["MechID"] != DBNull.Value && dr["MechID"] != "")
        //                    @MechID = Convert.ToInt32(dr["MechID"]);


        //                @ReferredByID = 7;
        //                if (SaleCatId > 0)
        //                    @SaleCategoryID = SaleCatId;
        //                else
        //                    @SaleCategoryID = 3;

        //                @PriceLevelID = 1; //--?? [PriceLevel]
        //                //--Profit--?? [Profit]
        //                @SaleTaxRateID = 1;

        //                if (SaleTerID > 0)
        //                    @SaleTermID = SaleTerID;
        //                else
        //                    @SaleTermID = 2;

        //                @ShipViaID = 9;
        //                @WarehouseBayID = 1;

        //                @CreatedByID = -2;

        //                if (dr["TaxableParts"] != DBNull.Value && dr["TaxableParts"] != "")
        //                    @PartsPrice = Convert.ToDecimal(dr["TaxableParts"]);
        //                else
        //                    @PartsPrice = 0;

        //                if (dr["TaxableLabor"] != DBNull.Value && dr["TaxableLabor"] != "")
        //                    @LaborPrice = Convert.ToDecimal(dr["TaxableLabor"]);
        //                else
        //                    @LaborPrice = 0;

        //                @OtherPrice = 0;
        //                if (dr["FETTotal"] != DBNull.Value && dr["FETTotal"] != "")
        //                    @FET = Convert.ToDecimal(dr["FETTotal"]);
        //                else
        //                    @FET = 0;

        //                if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
        //                    @Taxable = Convert.ToDecimal(dr["Taxable"]);
        //                else
        //                    @Taxable = 0;

        //                if (dr["Tax"] != DBNull.Value && dr["Tax"] != "")
        //                    @Tax = Convert.ToDecimal(dr["Tax"]);
        //                else
        //                    @Tax = 0;

        //                if (dr["DiscountAmt"] != DBNull.Value && dr["DiscountAmt"] != "")
        //                    @Discount = Convert.ToDecimal(dr["DiscountAmt"]);
        //                else
        //                    @Discount = 0;

        //                if (dr["SDiscountParts"] != DBNull.Value && dr["SDiscountParts"] != "")
        //                    @PartDisPer = Convert.ToDecimal(dr["SDiscountParts"]);
        //                else
        //                    @PartDisPer = 0;

        //                if (dr["SDiscountLabor"] != DBNull.Value && dr["SDiscountLabor"] != "")
        //                    @LaborDisPer = Convert.ToDecimal(dr["SDiscountLabor"]);
        //                else
        //                    @LaborDisPer = 0;

        //                if (dr["InvTotal"] != DBNull.Value && dr["InvTotal"] != "")
        //                    @Total = Convert.ToDecimal(dr["InvTotal"]);
        //                else
        //                    @Total = 0;

        //                if (dr["WoDate"] != DBNull.Value && dr["WoDate"] != "")
        //                    @PickupDate = Convert.ToDateTime(dr["WoDate"]);
        //                else
        //                    @PickupDate = DateTime.Now;

        //                if (dr["Status"] != DBNull.Value && dr["Status"] != "")
        //                    @Status = Convert.ToString(dr["Status"]);
        //                else
        //                    @Status = "";

        //                if (dr["NegatedInvID"] != DBNull.Value && dr["NegatedInvID"] != "")
        //                    @IsNegated = Convert.ToInt32(dr["NegatedInvID"]);
        //                else
        //                    @IsNegated = 0;

        //                @Active = 1;

        //                if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
        //                    @AddDate = Convert.ToDateTime(dr["InvDate"]);
        //                else
        //                    @AddDate = DateTime.Now;

        //                @AddUserID = -2;
        //                @ModifyUserID = 0;
        //                @ModifyDate = DateTime.Now.Date;
        //                if (dr["PaidBy"] != DBNull.Value && dr["PaidBy"] != "")
        //                    @Comments = Convert.ToString(dr["PaidBy"]);
        //                else
        //                    @Comments = "";

        //                @IsLocked = 0;

        //                if (dr["SchedStatus"] != DBNull.Value && dr["SchedStatus"] != "")
        //                    @DocNo = Convert.ToString(dr["SchedStatus"]);
        //                else
        //                    @DocNo = "";

        //                if (dr["WoNum"] != DBNull.Value && dr["WoNum"] != "")
        //                    @Remarks = Convert.ToString(dr["WoNum"]);
        //                else
        //                    @Remarks = "";

        //                @TrnsVrNo = "";
        //                @TrnsJrRef = "";
        //                @CompanyID = 1;
        //                @WarehouseID = 1;
        //                @StoreID = 1;

        //                getWOAutoNO(Convert.ToInt32(dr["invid"]));

        //                string Qry0 = "SET IDENTITY_INSERT [dbo].[WorkOrder] ON";

        //                string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrder]" +
        //                                    "([ID],[RegDate] ,[WorkOrderNo] ,[Notes] ,[IsQutation] ,[IsWorkOrder] ,[IsCustomerOrder] ,[CustomerID] ,[IsNoVehicle] ,[Mileage] ,[MileageOut] ,[SaleRepID] ,[ReferredByID] ,[SaleCategoryID] ,[PriceLevelID] ,[SaleTaxRateID] ,[SaleTermID] ,[ShipViaID] ,[WarehouseBayID] ,[CreatedByID] ,[PartsPrice] ,[LaborPrice] ,[OtherPrice] ,[FET] ,[Taxable] ,[Tax] ,[Discount] ,[PartDisPer] ,[LaborDisPer] ,[Total] ,[PickupDate]  ,[Status] ,[IsNegated] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[CoFinEndYear] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
        //                                    "VALUES" +
        //                                    "(" + @ID + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "'," + @WorkOrderNo + ",'" + @Notes + "'," + @IsQutation + "," + @IsWorkOrder + "," + @IsCustomerOrder + "," + @CustomerID + "," + @IsNoVehicle + "," + @Mileage + "," + @MileageOut + "," + @SaleRepID + "," + @ReferredByID + "," + @SaleCategoryID + "," + @PriceLevelID + "," + @SaleTaxRateID + "," + @SaleTermID + "," + @ShipViaID + "," + @WarehouseBayID + "," + @CreatedByID + "," + @PartsPrice + "," + @LaborPrice + "," + @OtherPrice + "," + @FET + "," + @Taxable + "," + @Tax + "," + @Discount + "," + @PartDisPer + "," + @LaborDisPer + "," + @Total + ",'" + @PickupDate.Year + "-" + @PickupDate.Month + "-" + @PickupDate.Day + "','" + @Status + "'," + @IsNegated + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
        //                string Qry2 = "SET IDENTITY_INSERT [dbo].[WorkOrder] OFF";
        //                string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

        //                InsertDataIntoAutoVault(InsertQuery);
        //            }
        //            catch { }
        //        }
        //    }
        //}
        //------------------------------------------------------//
        public void InsertWorkOrderDetailTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where [Catalog] != ''";
                string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT [invid] FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '')) and [Catalog] <> ''";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {                        
                        if (Convert.ToInt32(dr["InvID"]) > 0)
                        {
                            int CustomerID = getCustomerIDByInvID(Convert.ToInt32(dr["InvID"]));
                            int itmID = 0;
                            if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                            {
                                string ItemName = Convert.ToString(dr["Catalog"]);
                                if (ItemName == "FEUL")
                                    itmID = getitemIDForWordOrderDetail("FUEL");
                                else
                                    itmID = getitemIDForWordOrderDetail(ItemName); // Like Query
                                if (itmID == 0)
                                    itmID = getitemID(ItemName); // isequl Query
                            }
                            int RepId = 0;
                            if ((dr["sRepID"] != DBNull.Value) && (dr["sRepID"] != ""))
                            {
                                string RepName = Convert.ToString(dr["sRepID"]);
                                RepId = getRepIDID(RepName);
                            }
                            string CtypeID = "";
                            if ((dr["ItemTypeID"] != DBNull.Value) && (dr["ItemTypeID"] != ""))
                            {
                                string CtypeName = Convert.ToString(dr["ItemTypeID"]);
                                CtypeID = getCtypeID(CtypeName);
                            }
                            int @MechanicID, @RepID, @IsDone, @IsTax;
                            int @MID, @PackageID, @ItemID, @FeeID, @LaborID, @VehicleInspectionID, @InspectionHeadID, @Available, @Qty, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem, @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET;
                            decimal @Hours, @Price, @Cost, @Amount, @DiscPer, @DiscAmount, @FET, @Total, @MarginPer, @MarginAmount, @Tax, @SaleTaxRate;
                            int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                            string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
                            DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

                            if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                                @MID = Convert.ToInt32(dr["InvID"]);
                            else
                                @MID = 0;
                            if (itmID >= 1)
                                @ItemID = itmID;
                            else
                                @ItemID = 0;
                            @Ctype = CtypeID;
                            @Available = 0;
                            if (dr["Qty"] != DBNull.Value && dr["Qty"] != "")
                                @Qty = Convert.ToInt32(dr["Qty"]);
                            else
                                @Qty = 0;
                            if (dr["Hours"] != DBNull.Value && dr["Hours"] != "")
                                @Hours = Convert.ToDecimal(dr["Hours"]);
                            else
                                @Hours = 0;
                            @IsVendorManufacture = 0;
                            if (dr["NoDiscount"] != DBNull.Value && dr["NoDiscount"] != "")
                                @IsDiscountable = Convert.ToInt32(dr["NoDiscount"]);
                            else
                                @IsDiscountable = 0;
                            @IsNotShared = 0;
                            @IsObsolete = 0;
                            if (dr["RepComm"] != DBNull.Value && dr["RepComm"] != "")
                                @IsRepComm = Convert.ToInt32(dr["RepComm"]);
                            else
                                @IsRepComm = 0;
                            if (dr["Outside"] != DBNull.Value && dr["Outside"] != "")
                                @IsOutsideItem = Convert.ToInt32(dr["Outside"]);
                            else
                                @IsOutsideItem = 0;
                            if (dr["Commission"] != DBNull.Value && dr["Commission"] != "")
                                @IsMechComm = Convert.ToInt32(dr["Commission"]);
                            else
                                @IsMechComm = 0;
                            if (dr["Costable"] != DBNull.Value && dr["Costable"] != "")
                                @IsCosted = Convert.ToInt32(dr["Costable"]);
                            else
                                @IsCosted = 0;
                            if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
                                @IsTaxable = Convert.ToInt32(dr["Taxable"]);
                            else
                                @IsTaxable = 0;
                            if (dr["Retread"] != DBNull.Value && dr["Retread"] != "")
                                @IsRetread = Convert.ToInt32(dr["Retread"]);
                            else
                                @IsRetread = 0;
                            if (dr["Stock"] != DBNull.Value && dr["Stock"] != "")
                                @IsStocked = Convert.ToInt32(dr["Stock"]);
                            else
                                @IsStocked = 0;
                            if (dr["UseFet"] != DBNull.Value && dr["UseFet"] != "")
                                @IsUseFET = Convert.ToInt32(dr["UseFet"]);
                            else
                                @IsUseFET = 0;
                            if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                                @Price = Convert.ToDecimal(dr["Price"]);
                            else
                                @Price = 0;
                            if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                                @Cost = Convert.ToDecimal(dr["Cost"]);
                            else
                                @Cost = 0;
                            if (dr["Amount"] != DBNull.Value && dr["Amount"] != "")
                                @Amount = Convert.ToDecimal(dr["Amount"]);
                            else
                                @Amount = 0;
                            @DiscPer = 0;
                            if (dr["SDiscount"] != DBNull.Value && dr["SDiscount"] != "")
                                @DiscAmount = Convert.ToDecimal(dr["SDiscount"]);
                            else
                                @DiscAmount = 0;
                            if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                                @FET = Convert.ToDecimal(dr["FET"]);
                            else
                                @FET = 0;

                            
                            //@MechanicID = -2;
                            if (RepId > 0)
                                @RepID = RepId;
                            else
                                @RepID = -2;

                            @IsDone = 0;
                            @SaleTaxRate = 0;  //getSaleTaxRateByID(CustomerID);

                            @IsTax = 0;
                            @Tax = 0;  //Math.Round((Convert.ToDecimal(dr["Price"]) * @SaleTaxRate)/100,2);

                            @MarginPer = 0;
                            @MarginAmount = 0;
                            @Total =  Math.Round((Convert.ToDecimal(dr["Price"])+@Tax),2) * Convert.ToDecimal(dr["Qty"]);

                            @Active = 1;
                            @AddDate = getWorkOrderDate(Convert.ToInt32(dr["InvID"]));
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                                @Comments = Convert.ToString(dr["Description"]);
                            else
                                @Comments = "";
                            @IsLocked = 0;
                            if (dr["GroupID"] != DBNull.Value && dr["GroupID"] != "")
                                @DocNo = Convert.ToString(dr["GroupID"]);
                            else
                                @DocNo = "";

                            if (dr["ItemType"] != DBNull.Value && dr["ItemType"] != "")
                                @Remarks = Convert.ToString(dr["ItemType"]);
                            else
                                @Remarks = "";

                            
                            if (dr["ItemTypeID"] != DBNull.Value && dr["ItemTypeID"] != "")
                                @TrnsVrNo = Convert.ToString(dr["ItemTypeID"]);
                            else
                                @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            //string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
                            //                        "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[MechanicID],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                            //                    "VALUES" +
                            //                    "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @MechanicID + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";

                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
                                                    "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";

                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        public void InsertWorkOrderDetailTable2(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where [Catalog] != ''";
                string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where Amount < 0 ";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        if (Convert.ToInt32(dr["InvID"]) > 0)
                        {
                            int CustomerID = getCustomerIDByInvID(Convert.ToInt32(dr["InvID"]));
                            int itmID = 0;
                            if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                            {
                                string ItemName = Convert.ToString(dr["Catalog"]);
                                if (ItemName == "FEUL")
                                    itmID = getitemIDForWordOrderDetail("FUEL");
                                else
                                    itmID = getitemIDForWordOrderDetail(ItemName); // Like Query
                                if (itmID == 0)
                                    itmID = getitemID(ItemName); // isequl Query
                            }
                            int RepId = 0;
                            if ((dr["sRepID"] != DBNull.Value) && (dr["sRepID"] != ""))
                            {
                                string RepName = Convert.ToString(dr["sRepID"]);
                                RepId = getRepIDID(RepName);
                            }
                            string CtypeID = "";
                            if ((dr["ItemTypeID"] != DBNull.Value) && (dr["ItemTypeID"] != ""))
                            {
                                string CtypeName = Convert.ToString(dr["ItemTypeID"]);
                                CtypeID = getCtypeID(CtypeName);
                            }
                            int @MechanicID, @RepID, @IsDone, @IsTax;
                            int @MID, @PackageID, @ItemID, @FeeID, @LaborID, @VehicleInspectionID, @InspectionHeadID, @Available, @Qty, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem, @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET;
                            decimal @Hours, @Price, @Cost, @Amount, @DiscPer, @DiscAmount, @FET, @Total, @MarginPer, @MarginAmount, @Tax, @SaleTaxRate;
                            int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                            string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
                            DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

                            if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                                @MID = Convert.ToInt32(dr["InvID"]);
                            else
                                @MID = 0;
                            if (itmID >= 1)
                                @ItemID = itmID;
                            else
                                @ItemID = 0;
                            @Ctype = CtypeID;
                            @Available = 0;
                            if (dr["Qty"] != DBNull.Value && dr["Qty"] != "")
                                @Qty = Convert.ToInt32(dr["Qty"]);
                            else
                                @Qty = 0;
                            if (dr["Hours"] != DBNull.Value && dr["Hours"] != "")
                                @Hours = Convert.ToDecimal(dr["Hours"]);
                            else
                                @Hours = 0;
                            @IsVendorManufacture = 0;
                            if (dr["NoDiscount"] != DBNull.Value && dr["NoDiscount"] != "")
                                @IsDiscountable = Convert.ToInt32(dr["NoDiscount"]);
                            else
                                @IsDiscountable = 0;
                            @IsNotShared = 0;
                            @IsObsolete = 0;
                            if (dr["RepComm"] != DBNull.Value && dr["RepComm"] != "")
                                @IsRepComm = Convert.ToInt32(dr["RepComm"]);
                            else
                                @IsRepComm = 0;
                            if (dr["Outside"] != DBNull.Value && dr["Outside"] != "")
                                @IsOutsideItem = Convert.ToInt32(dr["Outside"]);
                            else
                                @IsOutsideItem = 0;
                            if (dr["Commission"] != DBNull.Value && dr["Commission"] != "")
                                @IsMechComm = Convert.ToInt32(dr["Commission"]);
                            else
                                @IsMechComm = 0;
                            if (dr["Costable"] != DBNull.Value && dr["Costable"] != "")
                                @IsCosted = Convert.ToInt32(dr["Costable"]);
                            else
                                @IsCosted = 0;
                            if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
                                @IsTaxable = Convert.ToInt32(dr["Taxable"]);
                            else
                                @IsTaxable = 0;
                            if (dr["Retread"] != DBNull.Value && dr["Retread"] != "")
                                @IsRetread = Convert.ToInt32(dr["Retread"]);
                            else
                                @IsRetread = 0;
                            if (dr["Stock"] != DBNull.Value && dr["Stock"] != "")
                                @IsStocked = Convert.ToInt32(dr["Stock"]);
                            else
                                @IsStocked = 0;
                            if (dr["UseFet"] != DBNull.Value && dr["UseFet"] != "")
                                @IsUseFET = Convert.ToInt32(dr["UseFet"]);
                            else
                                @IsUseFET = 0;
                            if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                                @Price = Convert.ToDecimal(dr["Price"]);
                            else
                                @Price = 0;
                            if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                                @Cost = Convert.ToDecimal(dr["Cost"]);
                            else
                                @Cost = 0;
                            if (dr["Amount"] != DBNull.Value && dr["Amount"] != "")
                                @Amount = Convert.ToDecimal(dr["Amount"]);
                            else
                                @Amount = 0;
                            @DiscPer = 0;
                            if (dr["SDiscount"] != DBNull.Value && dr["SDiscount"] != "")
                                @DiscAmount = Convert.ToDecimal(dr["SDiscount"]);
                            else
                                @DiscAmount = 0;
                            if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                                @FET = Convert.ToDecimal(dr["FET"]);
                            else
                                @FET = 0;


                            //@MechanicID = -2;
                            if (RepId > 0)
                                @RepID = RepId;
                            else
                                @RepID = -2;

                            @IsDone = 0;
                            @SaleTaxRate = 0;  //getSaleTaxRateByID(CustomerID);

                            @IsTax = 0;
                            @Tax = 0;  //Math.Round((Convert.ToDecimal(dr["Price"]) * @SaleTaxRate)/100,2);

                            @MarginPer = 0;
                            @MarginAmount = 0;
                            @Total = Math.Round((Convert.ToDecimal(dr["Price"]) + @Tax), 2) * Convert.ToDecimal(dr["Qty"]);

                            @Active = 1;
                            @AddDate = getWorkOrderDate(Convert.ToInt32(dr["InvID"]));
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                                @Comments = Convert.ToString(dr["Description"]);
                            else
                                @Comments = "";
                            @IsLocked = 0;
                            if (dr["GroupID"] != DBNull.Value && dr["GroupID"] != "")
                                @DocNo = Convert.ToString(dr["GroupID"]);
                            else
                                @DocNo = "";

                            if (dr["ItemType"] != DBNull.Value && dr["ItemType"] != "")
                                @Remarks = Convert.ToString(dr["ItemType"]);
                            else
                                @Remarks = "";


                            if (dr["ItemTypeID"] != DBNull.Value && dr["ItemTypeID"] != "")
                                @TrnsVrNo = Convert.ToString(dr["ItemTypeID"]);
                            else
                                @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            //string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
                            //                        "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[MechanicID],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                            //                    "VALUES" +
                            //                    "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @MechanicID + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";

                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
                                                    "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";

                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        //public void UpdateWorkOrderAsPerDetailTable()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string query = "SELECT MID,sum(Qty) Qty ,SUM(price) price ,SUM(Cost) Cost ,SUM(Amount) Amount ,SUM(Tax) Tax FROM [AutoVault].[dbo].[WorkOrderDetail] group by MID order by MID";
        //        SqlConnection databaseConnection = new SqlConnection(SqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();
        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                if (Convert.ToInt32(dr["MID"]) > 0)
        //                {
                                                        
        //                    int @MechanicID, @RepID, @IsDone, @IsTax;
        //                    int @MID, @PackageID, @ItemID, @FeeID, @LaborID, @VehicleInspectionID, @InspectionHeadID, @Available, @Qty, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem, @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET;
        //                    decimal @Hours, @Price, @Cost, @Amount, @DiscPer, @DiscAmount, @FET, @Total, @MarginPer, @MarginAmount, @Tax, @SaleTaxRate;
        //                    int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
        //                    string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
        //                    DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

        //                    if (dr["MID"] != DBNull.Value && dr["MID"] != "")
        //                        @ID = Convert.ToInt32(dr["MID"]);
        //                    else
        //                        @ID = 0;
                                                        
        //                    if (dr["Qty"] != DBNull.Value && dr["Qty"] != "")
        //                        @Qty = Convert.ToInt32(dr["Qty"]);
        //                    else
        //                        @Qty = 0;
                            
                            
        //                    if (dr["Price"] != DBNull.Value && dr["Price"] != "")
        //                        @Price = Convert.ToDecimal(dr["Price"]);
        //                    else
        //                        @Price = 0;
        //                    if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
        //                        @Cost = Convert.ToDecimal(dr["Cost"]);
        //                    else
        //                        @Cost = 0;
        //                    if (dr["Amount"] != DBNull.Value && dr["Amount"] != "")
        //                        @Amount = Convert.ToDecimal(dr["Amount"]);
        //                    else
        //                        @Amount = 0;
                            
        //                    if (dr["FET"] != DBNull.Value && dr["FET"] != "")
        //                        @FET = Convert.ToDecimal(dr["FET"]);
        //                    else
        //                        @FET = 0;


        //                    //@MechanicID = -2;
        //                    if (RepId > 0)
        //                        @RepID = RepId;
        //                    else
        //                        @RepID = -2;

        //                    @IsDone = 0;
        //                    @SaleTaxRate = getSaleTaxRateByID(CustomerID);

        //                    @IsTax = 1;
        //                    @Tax = Math.Round((Convert.ToDecimal(dr["Price"]) * @SaleTaxRate) / 100, 2);

        //                    @MarginPer = 0;
        //                    @MarginAmount = 0;
        //                    @Total = Math.Round((Convert.ToDecimal(dr["Price"]) + @Tax), 2) * Convert.ToDecimal(dr["Qty"]);

        //                    @Active = 1;
        //                    @AddDate = getWorkOrderDate(Convert.ToInt32(dr["InvID"]));
        //                    @AddUserID = -2;
        //                    @ModifyUserID = 0;
        //                    @ModifyDate = DateTime.Now.Date;
        //                    if (dr["Description"] != DBNull.Value && dr["Description"] != "")
        //                        @Comments = Convert.ToString(dr["Description"]);
        //                    else
        //                        @Comments = "";
        //                    @IsLocked = 0;
        //                    if (dr["GroupID"] != DBNull.Value && dr["GroupID"] != "")
        //                        @DocNo = Convert.ToString(dr["GroupID"]);
        //                    else
        //                        @DocNo = "";

        //                    if (dr["ItemType"] != DBNull.Value && dr["ItemType"] != "")
        //                        @Remarks = Convert.ToString(dr["ItemType"]);
        //                    else
        //                        @Remarks = "";


        //                    if (dr["ItemTypeID"] != DBNull.Value && dr["ItemTypeID"] != "")
        //                        @TrnsVrNo = Convert.ToString(dr["ItemTypeID"]);
        //                    else
        //                        @TrnsVrNo = "";
        //                    @TrnsJrRef = "";
        //                    @CompanyID = 1;
        //                    @WarehouseID = 1;
        //                    @StoreID = 1;
        //                    //string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
        //                    //                        "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[MechanicID],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
        //                    //                    "VALUES" +
        //                    //                    "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @MechanicID + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";

        //                    string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
        //                                            "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CompanyID],[WarehouseID],[StoreID])" +
        //                                        "VALUES" +
        //                                        "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
        //                    string InsertQuery = "\n" + Qry1 + "\n";

        //                    InsertDataIntoAutoVault(InsertQuery);
        //                }
        //            }
        //            catch { }
        //        }
        //    }
        //}
        //------------------------------------------------------//
        public void InsertWorkOrderDetail1Table(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where [Catalog] = ''";
                string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] = '' and ItemType = 'Comment' and [description] is not null and [description] <> ''";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        if (Convert.ToInt32(dr["InvID"]) > 0)
                        {                            

                            int @MID, @PackageID, @ItemID, @FeeID, @LaborID, @VehicleInspectionID, @InspectionHeadID, @Available, @Qty, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem, @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET;
                            decimal @Hours, @Price, @Cost, @Amount, @DiscPer, @DiscAmount, @FET, @Total, @MarginPer, @MarginAmount, @Tax, @SaleTaxRate;

                            int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                            string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
                            DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

                            if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                                @MID = Convert.ToInt32(dr["InvID"]);
                            else
                                @MID = 0;
                                                                                    
                            @Ctype = "Co";
                            @Available = 0;
                            
                            
                            @Active = 1;
                            @AddDate = getWorkOrderDate(Convert.ToInt32(dr["InvID"]));
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                                @Comments = Convert.ToString(dr["Description"]);
                            else
                                @Comments = "";
                            @IsLocked = 0;
                                                        
                            @Remarks = "W/O Comments";
                                                        
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;

                            string InsertQuery = "INSERT INTO [AutoVault].[dbo].[WorkOrderDetail]" +
                                                "([MID],[Ctype],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[Remarks],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @MID + ",'" + @Ctype + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @Remarks + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertSaleCategoryTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[salecat]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int salecatid = 0;
                        if ((dr["NAME"] != DBNull.Value) && (dr["NAME"] != ""))
                        {
                            string termsName = Convert.ToString(dr["NAME"]);
                            salecatid = getSalecatidbyname(termsName);
                        }
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @ItemPriceLevelID, @SaleTaxRateID, @IsDefault;
                        string @Code, @Name, @WorkorderMessage, @InvoiceMessage, @StatementMessage, @ThankYouEmail, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        DateTime @AddDate, @ModifyDate;
                        if (salecatid == 0)
                        {
                            if (dr["SaleCatID"] != DBNull.Value && dr["SaleCatID"] != "")
                                @Code = Convert.ToString(dr["SaleCatID"]);
                            else
                                @Code = "";
                            if (dr["NAME"] != DBNull.Value && dr["NAME"] != "")
                                @Name = Convert.ToString(dr["NAME"]);
                            else
                                @Name = "";
                            @ItemPriceLevelID = 1;
                            @SaleTaxRateID = 1;
                            @IsDefault = 1;
                            @WorkorderMessage = "Welcome to Master Tire Professionals, We appreciate your business.";
                            @StatementMessage = "Thank you for letting Master Tire Professional serve you.";
                            @InvoiceMessage = "Thank you for letting Master Tire Professional serve you.";
                            @ThankYouEmail = "";
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[SaleTaxCategory]" +
                                                    "([Code] ,[Name] ,[ItemPriceLevelID] ,[SaleTaxRateID]  ,[IsDefault] ,[WorkorderMessage] ,[StatementMessage] ,[InvoiceMessage] ,[ThankYouEmail] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef])" +
                                                "VALUES" +
                                                "('" + @Code + "','" + @Name + "'," + @ItemPriceLevelID + "," + @SaleTaxRateID + "," + @IsDefault + ",'" + @WorkorderMessage + "','" + @StatementMessage + "','" + @InvoiceMessage + "','" + @ThankYouEmail + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //--------------------- ItemGroup---------------------------------//
        //public void InsertItemGroupTable(DataTable dsdt)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string query = "SELECT * FROM itemgroup";

        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();

        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @ItemPriceLevelID, @SaleTaxRateID, @IsDefault;
        //                string @Code, @Name, @WorkorderMessage, @InvoiceMessage, @StatementMessage, @ThankYouEmail, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
        //                DateTime @AddDate, @ModifyDate;

        //                if (dr["SaleCatID"] != DBNull.Value && dr["SaleCatID"] != "")
        //                    @Code = Convert.ToString(dr["SaleCatID"]);
        //                else
        //                    @Code = "";
        //                if (dr["NAME"] != DBNull.Value && dr["NAME"] != "")
        //                    @Name = Convert.ToString(dr["NAME"]);
        //                else
        //                    @Name = "";
        //                @ItemPriceLevelID = 1;
        //                @SaleTaxRateID = 1;
        //                @IsDefault = 1;
        //                @WorkorderMessage = "Welcome to Master Tire Professionals, We appreciate your business.";
        //                @StatementMessage = "Thank you for letting Master Tire Professional serve you.";
        //                @InvoiceMessage = "Thank you for letting Master Tire Professional serve you.";
        //                @ThankYouEmail = "";
        //                @Active = 1;
        //                @AddDate = DateTime.Now.Date;
        //                @AddUserID = -2;
        //                @ModifyUserID = 0;
        //                @ModifyDate = DateTime.Now.Date;
        //                @Comments = "";
        //                @IsLocked = 0;
        //                @DocNo = "";
        //                @Remarks = "";
        //                @CoFinEndYear = 0;
        //                @TrnsVrNo = "";
        //                @TrnsJrRef = "";



        //                string Qry0 = "SET IDENTITY_INSERT [dbo].[SaleCategory] OFF";
        //                string Qry1 = "INSERT INTO [AutoVault].[dbo].[SaleCategory]" +
        //                                        "([Code] ,[Name] ,[ItemPriceLevelID] ,[SaleTaxRateID]  ,[IsDefault] ,[WorkorderMessage] ,[StatementMessage] ,[InvoiceMessage] ,[ThankYouEmail] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[CoFinEndYear] ,[TrnsVrNo] ,[TrnsJrRef])" +
        //                                    "VALUES" +
        //                                    "('" + @Code + "','" + @Name + "'," + @ItemPriceLevelID + "," + @SaleTaxRateID + "," + @IsDefault + ",'" + @WorkorderMessage + "','" + @StatementMessage + "','" + @InvoiceMessage + "','" + @ThankYouEmail + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
        //                string Qry2 = "SET IDENTITY_INSERT [dbo].[SaleCategory] ON";
        //                //-------------------------------------------------------------------//
        //                string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
        //                InsertDataIntoAutoVault(InsertQuery);

        //            }
        //            catch { }
        //        }
        //    }
        //}
        //------------------------------------------------------//
        public void InsertPOTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendorpo] order by POID";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int LastRBy = -2;
                        if ((dr["RepID"] != DBNull.Value) && (dr["RepID"] != "") || (dr["RepID"] == ""))
                        {
                            string RepName = Convert.ToString(dr["RepID"]);
                            LastRBy = getRepIDID(RepName);                            
                        }
                        int @ID, @VendorID, @POID, @LastReceivedBy, @IsDone, @TotalQtyOrder, @TotalQtyReceived, @TotalQtyBilled, @IsProcessed;
                        decimal @TotalAmountOrder, @TotalAmountReceived, @TotalAmountBilled, @DiscountPer;
                        string @Reference, @Notes;
                        DateTime @PODate, @LastReceivedDate;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        DateTime @AddDate, @ModifyDate;
                        @ID = Convert.ToInt32(dr["POID"]);
                        if (dr["vendorID"] != DBNull.Value && dr["vendorID"] != "")
                            @VendorID = Convert.ToInt32(dr["vendorID"]);
                        else
                            @VendorID = 0;
                        @POID = Convert.ToInt32(dr["POID"]);
                        @PODate = Convert.ToDateTime(dr["TranDate"]);
                        @CoFinEndYear = @PODate.Year;

                        if (dr["Reference"] != DBNull.Value && dr["Reference"] != "")
                            @Reference = Convert.ToString(dr["Reference"]);
                        else
                            @Reference = "";
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @Notes = Convert.ToString(dr["Description"]);
                        else
                            @Notes = "";
                        if (dr["DiscountPercent"] != DBNull.Value && dr["DiscountPercent"] != "")
                            @DiscountPer = Convert.ToDecimal(dr["DiscountPercent"]);
                        else
                            @DiscountPer = 0;
                        if (dr["LastReceived"] != DBNull.Value && dr["LastReceived"] != "")
                            @LastReceivedDate = Convert.ToDateTime(dr["LastReceived"]);
                        else
                            @LastReceivedDate = DateTime.Now.Date;
                        if (LastRBy >= 1)
                            @LastReceivedBy = LastRBy;
                        else
                            @LastReceivedBy = -2;
                        if (dr["Done"] != DBNull.Value && dr["Done"] != "")
                            @IsDone = Convert.ToInt32(dr["Done"]);
                        else
                            @IsDone = 0;
                        @TotalAmountOrder = getTotalAmountOrder(Convert.ToInt32(dr["POID"]));
                        @TotalAmountReceived = getTotalAmountOrder(Convert.ToInt32(dr["POID"]));
                        @TotalAmountBilled = getTotalAmountOrder(Convert.ToInt32(dr["POID"]));

                        @TotalQtyOrder = getTotalQtyOrder(Convert.ToInt32(dr["POID"]));
                        @TotalQtyReceived = getTotalQtyOrder(Convert.ToInt32(dr["POID"]));
                        @TotalQtyBilled = getTotalQtyOrder(Convert.ToInt32(dr["POID"]));
                        @IsProcessed = 0;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        if (dr["TabsID"] != DBNull.Value && dr["TabsID"] != "")
                            @Remarks = Convert.ToString(dr["TabsID"]);
                        else
                            @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                                               
                        getPOAutoNO(Convert.ToInt32(dr["POID"]));
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[PurchaseOrder] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[PurchaseOrder]" +
                                                "([ID],[VendorID] ,[POID] ,[PODate] ,[Reference] ,[Notes] ,[DiscountPer] ,[LastReceivedDate] ,[LastReceivedBy] ,[IsDone] ,[TotalAmountOrder] ,[TotalAmountReceived] ,[TotalAmountBilled] ,[TotalQtyOrder] ,[TotalQtyReceived] ,[TotalQtyBilled] ,[IsProcessed] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[CoFinEndYear] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + "," + @VendorID + "," + @POID + ",'" + @PODate.Year + "-" + @PODate.Month + "-" + @PODate.Day + "','" + @Reference + "','" + @Notes + "'," + @DiscountPer + ",'" + @LastReceivedDate.Year + "-" + @LastReceivedDate.Month + "-" + @LastReceivedDate.Day + "' ," + @LastReceivedBy + "," + @IsDone + "," + @TotalAmountOrder + "," + @TotalAmountReceived + "," + @TotalAmountBilled + "," + @TotalQtyOrder + "," + @TotalQtyReceived + "," + @TotalQtyBilled + "," + @IsProcessed + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[PurchaseOrder] OFF";
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

                        if (!string.IsNullOrEmpty(InsertQuery))
                            InsertDataIntoAutoVault(InsertQuery);
                        
                    }
                    catch { }
                }                
            }
        }
        //------------------------------------------------------//
        public void InsertPODetailTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendorpodet]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int itmID = 0;
                        if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                        {
                            string ItemName = Convert.ToString(dr["Catalog"]);
                            itmID = getitemID(ItemName);
                        }
                        int @MID, @ItemID, @QtyOrdrd, @PrevOrdrd, @QtyRcvd, @PrevRcvd, @QtyBilled, @PrevBilled;
                        decimal @Cost, @FET, @Amount;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        DateTime @AddDate, @ModifyDate;

                        @MID = Convert.ToInt32(dr["POID"]);
                        if (itmID >= 1)
                            @ItemID = itmID;
                        else
                            @ItemID = 0;
                        if (dr["PrevOrdered"] != DBNull.Value && dr["PrevOrdered"] != "")
                            @QtyOrdrd = Convert.ToInt32(dr["PrevOrdered"]);
                        else
                            @QtyOrdrd = 0;
                        if (dr["PrevOrdered"] != DBNull.Value && dr["PrevOrdered"] != "")
                            @PrevOrdrd = Convert.ToInt32(dr["PrevOrdered"]);
                        else
                            @PrevOrdrd = 0;
                        if (dr["PrevReceived"] != DBNull.Value && dr["PrevReceived"] != "")
                            @QtyRcvd = Convert.ToInt32(dr["PrevReceived"]);
                        else
                            @QtyRcvd = 0;
                        if (dr["PrevReceived"] != DBNull.Value && dr["PrevReceived"] != "")
                            @PrevRcvd = Convert.ToInt32(dr["PrevReceived"]);
                        else
                            @PrevRcvd = 0;
                        if (dr["PrevInvoiced"] != DBNull.Value && dr["PrevInvoiced"] != "")
                            @QtyBilled = Convert.ToInt32(dr["PrevInvoiced"]);
                        else
                            @QtyBilled = 0;
                        if (dr["PrevInvoiced"] != DBNull.Value && dr["PrevInvoiced"] != "")
                            @PrevBilled = Convert.ToInt32(dr["PrevInvoiced"]);
                        else
                            @PrevBilled = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @Cost = Convert.ToDecimal(dr["Cost"]);
                        else
                            @Cost = 0;
                        if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                            @FET = Convert.ToDecimal(dr["FET"]);
                        else
                            @FET = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @Amount = Convert.ToDecimal(dr["Cost"]) * Convert.ToInt32(dr["PrevInvoiced"]);
                        else
                            @Amount = 0;
                        @Active = 1;
                        if (dr["Linedate"] != DBNull.Value && dr["Linedate"] != "")
                            @AddDate = Convert.ToDateTime(dr["Linedate"]);
                        else
                            @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        if (dr["TabsID"] != DBNull.Value && dr["TabsID"] != "")
                            @Remarks = Convert.ToString(dr["TabsID"]);
                        else
                            @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;

                        if (@PrevOrdrd > 0) { @QtyOrdrd = 0; }
                        if (@PrevRcvd > 0) { @QtyRcvd = 0; }
                        if (@PrevBilled > 0) { @QtyBilled = 0; }

                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[PurchaseOrderDetails]" +
                                                "([MID] ,[ItemID] ,[QtyOrdrd] ,[PrevOrdrd] ,[QtyRcvd] ,[PrevRcvd] ,[QtyBilled] ,[PrevBilled] ,[Cost] ,[FET] ,[Amount] ,[Active] ,[AddDate] ,[AddUserID] ,[ModifyUserID] ,[ModifyDate] ,[Comments] ,[IsLocked] ,[DocNo] ,[Remarks] ,[TrnsVrNo] ,[TrnsJrRef] ,[CompanyID] ,[WarehouseID] ,[StoreID])" +
                                            "VALUES" +
                                            "(" + @MID + "," + @ItemID + "," + @QtyOrdrd + "," + @PrevOrdrd + "," + @QtyRcvd + "," + @PrevRcvd + "," + @QtyBilled + "," + @PrevBilled + "," + @Cost + "," + @FET + "," + @Amount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertVendorBillTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendorinv] where TranType = 'Bill' and OpenAmount >= 0";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int @AutoBillNo, @ID, @BillID, @VendorID, @POID, @BillPayFreightToID, @IsAdjustInvCosts, @QtyBilled, @PrevBilled, @IsPaid;
                        decimal @BillFreight, @FET, @Amount, @SaleTaxPercent, @SaleTaxAmount, @SaleTaxDiscountPercent, @SaleTaxDiscountPrice, @SaleTaxSurchargePercent, @SaleTaxSurchargePrice, @GridTotalQty, @GridTotalAmount, @BillTotalAmount, @Discount, @PaidAmount, @Balance;

                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID, @AutoBillID;
                        string @Name, @InvoiceNo, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @BillNotes, @BillStatus, @BillType;
                        DateTime @AddDate, @ModifyDate, @BillDate, @DueDate;
                        @ID = Convert.ToInt32(dr["InvoiceID"]);
                        @BillID = Convert.ToInt32(dr["InvoiceID"]);
                        string Description = Convert.ToString(dr["Description"]);
                        string[] paidbysplit;
                        paidbysplit = Description.Split(new Char[] { '#' });
                        @POID =Convert.ToInt32(paidbysplit[1]);  
                        if (dr["VendorID"] != DBNull.Value && dr["VendorID"] != "")
                            @VendorID = Convert.ToInt32(dr["VendorID"]);
                        else
                            @VendorID = 0;
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @InvoiceNo = Convert.ToString(dr["Description"]);
                        else
                            InvoiceNo = "";
                        if (dr["Date1"] != DBNull.Value && dr["Date1"] != "")
                            @BillDate = Convert.ToDateTime(dr["Date1"]);
                        else
                            @BillDate = DateTime.Now;

                        @CoFinEndYear = @BillDate.Year;

                        if (dr["DueDate"] != DBNull.Value && dr["DueDate"] != "")
                            @DueDate = Convert.ToDateTime(dr["DueDate"]);
                        else
                            @DueDate = DateTime.Now;
                        if (dr["Reference"] != DBNull.Value && dr["Reference"] != "")
                            @BillNotes = Convert.ToString(dr["Reference"]);
                        else
                            @BillNotes = "";
                        //if (dr["TranType"] != DBNull.Value && dr["TranType"] != "")
                        //    @BillStatus = Convert.ToString(dr["TranType"]);
                        //else
                            @BillStatus = "R";
                        //if (dr["TranType"] != DBNull.Value && dr["TranType"] != "")
                        //    @BillType = Convert.ToString(dr["TranType"]);
                        //else
                            @BillType = "B";
                        if (dr["DiscountPerc"] != DBNull.Value && dr["DiscountPerc"] != "")
                            @SaleTaxDiscountPercent = Convert.ToDecimal(dr["DiscountPerc"]);
                        else
                            @SaleTaxDiscountPercent = 0;
                        if (dr["ToDiscount"] != DBNull.Value && dr["ToDiscount"] != "")
                            @SaleTaxDiscountPrice = Convert.ToDecimal(dr["ToDiscount"]);
                        else
                            @SaleTaxDiscountPrice = 0;
                        @GridTotalQty = getPOQty(@BillID);
                        @GridTotalAmount = getTotalAmountOrder(@BillID);
                        @BillTotalAmount = getBillTotalAmount(@BillID);
                        if (dr["Status"] == "Locked")
                            @IsPaid =1;
                        else
                            @IsPaid = 0;
                        if (dr["ToDiscount"] != DBNull.Value && dr["ToDiscount"] != "")
                            @Discount = Convert.ToInt32(dr["ToDiscount"]);
                        else
                            @Discount = 0;
                        @PaidAmount = getTotalPayVendorBill(@BillID);
                        @Balance = Convert.ToDecimal(@BillTotalAmount - @PaidAmount);

                        @Active = 1;
                        if (dr["TranDate"] != DBNull.Value && dr["TranDate"] != "")
                            @AddDate = Convert.ToDateTime(dr["TranDate"]);
                        else
                            @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        if (dr["TermsID"] != DBNull.Value && dr["TermsID"] != "")
                            @DocNo = Convert.ToString(dr["TermsID"]);
                        else
                            @DocNo = "";
                        if (dr["TabsID"] != DBNull.Value && dr["TabsID"] != "")
                            @Remarks = Convert.ToString(dr["TabsID"]);
                        else
                            @Remarks = "";
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        int poAutoNo = 0;
                        poAutoNo = getBillAutoNO(Convert.ToInt32(dr["InvoiceID"]));
                        string Qry0 = "SET IDENTITY_INSERT [dbo].[VendorBill] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[VendorBill]" +
                                                "([ID],[BillID],[VendorID],[InvoiceNo],[POID],[BillDate],[DueDate],[BillNotes],[SaleTaxDiscountPercent],[SaleTaxDiscountPrice],[GridTotalQty],[GridTotalAmount],[BillTotalAmount],[BillStatus],[BillType],[IsPaid],[Discount],[PaidAmount],[Balance],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + "," + @BillID + "," + @VendorID + ",'" + @InvoiceNo + "'," + @POID + ",'" + @BillDate.Year + "-" + @BillDate.Month + "-" + @BillDate.Day + "','" + @DueDate.Year + "-" + @DueDate.Month + "-" + @DueDate.Day + "','" + @BillNotes + "'," + @SaleTaxDiscountPercent + "," + @SaleTaxDiscountPrice + "," + @GridTotalQty + "," + @GridTotalAmount + "," + @BillTotalAmount + ",'" + @BillStatus + "','" + @BillType + "'," + @IsPaid + "," + @Discount + "," + @PaidAmount + "," + @Balance + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[VendorBill] OFF";
                        //-------------------------------------------------------------------//
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertVendorBillDetailsTable(DataTable dsdt)
        {
            DataTable dtVendorBill = new DataTable();
            try
            {
                string query = "SELECT * FROM [VendorBill]";
                SqlConnection databaseConnection = new SqlConnection(SqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dtVendorBill.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }

            if (dtVendorBill.Rows.Count > 0)
            {
                foreach (DataRow dr in dtVendorBill.Rows)
                {
                    int iPOID = Convert.ToInt32(dr["POID"]);
                    int iBillID = Convert.ToInt32(dr["BillID"]);
                    int iMID = Convert.ToInt32(dr["ID"]);
                    if ((iPOID > 0) && (iMID > 0))
                    {
                        InsertVendorBillDetailbyPO(iPOID, iMID,iBillID);
                    }
                }
            }
            
        }
        void InsertVendorBillDetailbyPO(int iPOID, int @MID, int billID)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[vendorpodet] where POID = " + iPOID;
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int itmID = 0;
                        if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                        {
                            string ItemName = Convert.ToString(dr["Catalog"]);
                            itmID = getitemID(ItemName);
                        }
                        int @ID, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @ItemID, @IsVendorOnly, @DiscountTypeID, @BillQty, @CompanyID, @WarehouseID, @StoreID;
                        string @Catalog, @Name, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Comments;
                        DateTime @AddDate, @ModifyDate;
                        decimal @CatalogCost, @BillAmount;
                                              
                        
                        if (itmID >= 1)
                            @ItemID = itmID;
                        else
                            @ItemID = 0;
                        if (dr["Catalog"] != DBNull.Value && dr["Catalog"] != "")
                            @Catalog = Convert.ToString(dr["Catalog"]);
                        else
                            @Catalog = "";
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @Name = Convert.ToString(dr["Description"]);
                        else
                            @Name = "";
                        if (dr["PrevInvoiced"] != DBNull.Value && dr["PrevInvoiced"] != "")
                            @BillQty = Convert.ToInt32(dr["PrevInvoiced"]);
                        else
                            @BillQty = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @CatalogCost = Convert.ToDecimal(dr["Cost"]);
                        else
                            @CatalogCost = 0;
                        if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                            @BillAmount = Convert.ToDecimal(dr["Cost"]) * Convert.ToInt32(dr["PrevInvoiced"]);
                        else
                            @BillAmount = 0;
                        @Active = 1;
                        if (dr["LineDate"] != DBNull.Value && dr["LineDate"] != "")
                            @AddDate = Convert.ToDateTime(dr["LineDate"]);
                        else
                            @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = Convert.ToString(dr["GroupID"]);
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = Convert.ToString(dr["TabsID"]);
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        //string Qry0 = "SET IDENTITY_INSERT [dbo].[VendorBillDetails] ON";
                        string InsertQuery = "INSERT INTO [AutoVault].[dbo].[VendorBillDetails]" +
                                                "([MID],[ItemID],[Catalog],[Name],[BillQty],[CatalogCost],[BillAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @MID + "," + @ItemID + ",'" + @Catalog + "','" + @Name + "'," + @BillQty + "," + @CatalogCost + "," + @BillAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        //string Qry2 = "SET IDENTITY_INSERT [dbo].[VendorBillDetails] OFF";
                        //-------------------------------------------------------------------//
                        //string InsertQuery = "\n" + Qry1 + "\n" ;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertVendorPaymentTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[billappliedto]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int @PaymentID, @VendorID, @BillID;
                        decimal @BillAmount, @BillDiscount, @PaidAmount, @BillBalance;

                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID, @AutoPaymentNo, @IsPaid;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @BillNotes, @BillStatus, @BillType, @TrnsNotes, @TrnsType, @InvoiceNo;
                        DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;
                        if (dr["PmtInvoiceID"] != DBNull.Value && dr["PmtInvoiceID"] != "")
                            @PaymentID = Convert.ToInt32(dr["PmtInvoiceID"]);
                        else
                            @PaymentID = 0;
                        @VendorID = getVendorIdForInvoice(Convert.ToInt32(dr["PmtInvoiceID"]));
                        if (dr["BillInvoiceID"] != DBNull.Value && dr["BillInvoiceID"] != "")
                            @BillID = Convert.ToInt32(dr["BillInvoiceID"]);
                        else
                            @BillID = 0;
                        //if (dr["PmtInvoiceID"] != DBNull.Value && dr["PmtInvoiceID"] != "")
                        //    @InvoiceNo = Convert.ToString(dr["PmtInvoiceID"]);
                        //else

                        
                        @TrnsDate = getVendorPaymentTrnsDate(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @CoFinEndYear = @TrnsDate.Year;
                        @TrnsNotes = getVendorPaymentTrnsNotes(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @TrnsType = "C"; // getVendorPaymentTrnsType(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @IsPaid = 1;
                        @BillAmount = getBillTotalAmount(Convert.ToInt32(dr["BillInvoiceID"]));
                        @BillDiscount = 0;
                        if (dr["Applied"] != DBNull.Value && dr["Applied"] != "")
                            @PaidAmount = Convert.ToDecimal(dr["Applied"]);
                        else
                            @PaidAmount = 0;
                        @BillBalance = 0;
                        @Active = 1;
                        @AddDate = getVendorPaymentTimeCreated(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = getVendorPaymentAppliedTo(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @IsLocked = 0;
                        @DocNo = getVendorPaymentTermsID(Convert.ToInt32(dr["PmtInvoiceID"]));
                        @InvoiceNo = @DocNo;
                        @Remarks = getVendorPaymentTabsID(Convert.ToInt32(dr["PmtInvoiceID"]));
                        
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;

                       // getVendorPaymentAutoNo(Convert.ToInt32(dr["BillInvoiceID"]));

                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[VendorPayment]" +
                                                "([PaymentID],[VendorID],[BillID],[InvoiceNo],[TrnsDate],[TrnsNotes],[TrnsType],[IsPaid],[BillAmount],[BillDiscount],[PaidAmount],[BillBalance],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @PaymentID + "," + @VendorID + "," + @BillID + ",'" + @InvoiceNo + "','" + @TrnsDate.Year + "-" + @TrnsDate.Month + "-" + @TrnsDate.Day + "','" + @TrnsNotes + "','" + @TrnsType + "'," + @IsPaid + "," + @BillAmount + "," + @BillDiscount + "," + @PaidAmount + "," + @BillBalance + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";

                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertLaboreDepartmentTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[labordept]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int Labordeptid = 0;
                        if ((dr["NAME"] != DBNull.Value) && (dr["NAME"] != ""))
                        {
                            string LaborDeptName = Convert.ToString(dr["NAME"]);
                            Labordeptid = getLaborDeptmentidbyname(LaborDeptName);
                        }
                        string @DepartmentColor, @Name;
                        int @MID, @DfltHrs, @SortingOrder;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        DateTime @AddDate, @ModifyDate;
                        if (Labordeptid == 0)
                        {
                            @MID = 1;
                            if (dr["NAME"] != DBNull.Value && dr["NAME"] != "")
                                @Name = Convert.ToString(dr["NAME"]);
                            else
                                @Name = "";
                            if (dr["ForeColor"] != DBNull.Value && dr["ForeColor"] != "")
                                @DepartmentColor = Convert.ToString(dr["ForeColor"]);
                            else
                                @DepartmentColor = "";
                            if (dr["Hours"] != DBNull.Value && dr["Hours"] != "")
                                @DfltHrs = Convert.ToInt32(dr["Hours"]);
                            else
                                @DfltHrs = 0;
                            if (dr["SortOrder"] != DBNull.Value && dr["SortOrder"] != "")
                                @SortingOrder = Convert.ToInt32(dr["SortOrder"]);
                            else
                                @SortingOrder = 0;
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[LaborDepartment]" +
                                                    "([MID],[Name],[DepartmentColor],[DfltHrs],[SortingOrder],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[TrnsVrNo],[TrnsJrRef])" +
                                                "VALUES" +
                                                "(" + @MID + ",'" + @Name + "','" + @DepartmentColor + "'," + @DfltHrs + "," + @SortingOrder + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "','" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);

                        }
                    }
                    catch { }
                }
            }
        }
        public void InsertLaborTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[item] where ItemType='Labor'";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {

                        int laborid = 0;
                        if ((dr["Description"] != DBNull.Value) && (dr["Description"] != ""))
                        {
                            string laborname = Convert.ToString(dr["Description"]);
                            laborid = getFeeidbyname(laborname);
                        }
                        int itmgroupID = 0;
                        if ((dr["GroupID"] != DBNull.Value) && (dr["GroupID"] != ""))
                        {
                            string ItemgroupName = Convert.ToString(dr["GroupID"]);
                            itmgroupID = getitemgroupID(ItemgroupName);
                        }
                        //int ManufactureID = 0;
                        //if ((dr["Brand"] != DBNull.Value) && (dr["Brand"] != ""))
                        //{
                        //    string ManuName = Convert.ToString(dr["Brand"]);
                        //    ManufactureID = getManuID(ManuName);
                        //}

                        //---------------------------------------------------------------------------------//
                        int @ID, @IsAuto, @ItemTypeID, @ItemGroupID, @NextLinkItemID, @VendorID, @ManufacturerID, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem;
                        int @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET, @ReOrderMin, @ReOrderMax, @IsSpiffsTemporary, @SpiffsTypeID, @SpiffsPercent;
                        int @IsTemporaryDiscount, @LaborDeptID;
                        string @ItemCode, @ItemSize, @Catalog, @Name, @Location, @BoltPattern, @ManufacturerNo, @VenderPartNo, @DataKeywords, @NAPAKeywords;
                        string @UPCCode, @PostCard, @WebSize, @WebTireSizeA, @WebTireSizeB, @WebTireSizeC, @WebWheelBoltCircle, @WebWheelBoltCircle2, @WebWheelOffset, @WebWheelDiameter, @WebWheelWidth, @WebWheelCenterBore;
                        string @WebWheelFinish, @AutoWareCode;
                        decimal @LaborHours = 0, @LaborFees = 0;
                        decimal @UnitWeight, @CatalogCost, @LastCost, @AverageCost, @FET, @RetailPercent, @RetailPrice, @CommercialPercent, @CommercialPrice, @WholesalePercent, @WholesalePrice, @TemporaryDiscountedRetail, @TemporaryDiscountedCommercial, @TemporaryDiscountedWholesale, @SpiffsDollarAmount;
                        DateTime @RegDate, @SpiffsDateFrom, @SpiffsDateTo, @TemporaryDiscountDateFrom, @TemporaryDiscountDateTo;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID, @RackID;
                        DateTime @AddDate, @ModifyDate;

                        if (dr["catalog"] != DBNull.Value && dr["catalog"] != "")
                            @Catalog = Convert.ToString(dr["catalog"]);
                        else
                            @Catalog = "";
                        if (itmgroupID > 0)
                            @ItemGroupID = itmgroupID;
                        else
                            @ItemGroupID = 1;
                        if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                            @Name = Convert.ToString(dr["Description"]);
                        else
                            @Name = "";
                        @LaborDeptID = 1;
                        @LaborHours = 0;
                        @LaborFees = 0;
                        @IsDiscountable = 1;
                        @IsObsolete = 0;
                        @IsRepComm = 0;
                        @IsOutsideItem = 0;
                        @IsMechComm = 0;
                        @IsCosted = 0;
                        @IsTaxable = 0;


                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        @CoFinEndYear = 0;
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";

                        string Qry0 = "SET IDENTITY_INSERT [dbo].[Labor] OFF";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[Labor]" +
                                            "([Catalog],[ItemGroupID],[Name],[LaborDeptID],[LaborHours],[LaborFees],[IsDiscountable],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef])" +
                                        "VALUES" +
                                            "('" + @Catalog + "'," + @ItemGroupID + ",'" + @Name + "'," + @LaborDeptID + "," + @LaborHours + "," + @LaborFees + "," + @IsDiscountable + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "');";

                        string Qry2 = "SET IDENTITY_INSERT [dbo].[Labor] ON";

                        //-------------------------------------------------------------------//
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

                        InsertDataIntoAutoVault(InsertQuery);
                        //-------------------------------------------------------------------//
                    }
                    catch { }
                }

            }



        }
        //------------------------------------------------------//
        public void InsertFeesTable(DataTable dsdt)
        {

            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[item] where ItemType='Fee'";

                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();

            }
            catch { }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int feeID = 0;
                        if ((dr["GroupID"] != DBNull.Value) && (dr["GroupID"] != ""))
                        {
                            string Feename = Convert.ToString(dr["GroupID"]);
                            feeID = getFeeidbyname(Feename);
                        }
                        //int itmtypeID = 0;
                        //if ((dr["ItemTypeID"] != DBNull.Value) && (dr["ItemTypeID"] != ""))
                        //{
                        //    string ItemTypeName = Convert.ToString(dr["ItemTypeID"]);
                        //    itmtypeID = getitemtypeID(ItemTypeName);
                        //}
                        int itmgroupID = 0;
                        if ((dr["GroupID"] != DBNull.Value) && (dr["GroupID"] != ""))
                        {
                            string ItemgroupName = Convert.ToString(dr["GroupID"]);
                            itmgroupID = getitemgroupID(ItemgroupName);
                        }



                        //---------------------------------------------------------------------------------//
                        int @ID, @IsAuto, @ItemTypeID, @ItemGroupID, @NextLinkItemID, @VendorID, @ManufacturerID, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem;
                        int @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET, @ReOrderMin, @ReOrderMax, @IsSpiffsTemporary, @SpiffsTypeID, @SpiffsPercent;
                        int @IsTemporaryDiscount, @LaborDeptID;
                        string @ItemCode, @ItemSize, @Catalog, @Name, @Location, @BoltPattern, @ManufacturerNo, @VenderPartNo, @DataKeywords, @NAPAKeywords;
                        string @UPCCode, @PostCard, @WebSize, @WebTireSizeA, @WebTireSizeB, @WebTireSizeC, @WebWheelBoltCircle, @WebWheelBoltCircle2, @WebWheelOffset, @WebWheelDiameter, @WebWheelWidth, @WebWheelCenterBore;
                        string @WebWheelFinish, @AutoWareCode;
                        decimal @FeePrice = 0;
                        decimal @UnitWeight, @CatalogCost, @LastCost, @AverageCost, @FET, @RetailPercent, @RetailPrice, @CommercialPercent, @CommercialPrice, @WholesalePercent, @WholesalePrice, @TemporaryDiscountedRetail, @TemporaryDiscountedCommercial, @TemporaryDiscountedWholesale, @SpiffsDollarAmount;
                        DateTime @RegDate, @SpiffsDateFrom, @SpiffsDateTo, @TemporaryDiscountDateFrom, @TemporaryDiscountDateTo;
                        string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID, @RackID;
                        DateTime @AddDate, @ModifyDate;
                        if (feeID == 0)
                        {
                            if (dr["catalog"] != DBNull.Value && dr["catalog"] != "")
                                @Catalog = Convert.ToString(dr["catalog"]);
                            else
                                @Catalog = "";
                            if (itmgroupID > 0)
                                @ItemGroupID = itmgroupID;
                            else
                                @ItemGroupID = 1;
                            if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                                @Name = Convert.ToString(dr["Description"]);
                            else
                                @Name = "";

                            @FeePrice = 0;
                            @IsDiscountable = 1;
                            @IsObsolete = 0;
                            @IsRepComm = 0;
                            @IsOutsideItem = 0;
                            @IsMechComm = 0;
                            @IsCosted = 0;
                            @IsTaxable = 0;


                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;

                            string Qry0 = "SET IDENTITY_INSERT [dbo].[Fees] OFF";
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[Fees]" +
                                                "([Catalog],[ItemGroupID],[Name],[FeePrice],[IsDiscountable],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                                "('" + @Catalog + "'," + @ItemGroupID + ",'" + @Name + "'," + @FeePrice + "," + @IsDiscountable + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";

                            string Qry2 = "SET IDENTITY_INSERT [dbo].[Fees] ON";

                            //-------------------------------------------------------------------//
                            string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;

                            InsertDataIntoAutoVault(InsertQuery);
                            //-------------------------------------------------------------------//
                        }
                    }
                    catch { }
                }

            }



        }
        //------------------------------------------------------//
        public void InsertCustomerReciptTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[appliedto] order by ID";
                //string query = "SELECT * FROM [TempAB].[dbo].[appliedto] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice])";
                string query = "select * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '') and [Status] in ('Invoice') and [PONum] not like 'NEGATE%'";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int CustID = 0;
                        if ((dr["InvID"] != DBNull.Value) && (dr["InvID"] != ""))
                        {
                            int CustmrID = Convert.ToInt32(dr["InvID"]);
                            CustID = getCustID(CustmrID);
                        }
                        int WoID = 0;
                        if ((dr["Invnum"] != DBNull.Value) && (dr["Invnum"] != ""))
                        {
                            string WorkID = Convert.ToString(dr["Invnum"]);
                            WoID = getWoID(WorkID);
                        }
                        int @ID, @ReceiptID, @CustomerID, @WOID, @IsDeposit, @IsCredit;
                        decimal @PayByCash = 0, @ChgOnAccount = 0, @PayByCheck = 0, @PayByDeposit, @PayByVisa = 0, @PayByMC, @PayByAMEX, @PayByATM, @PayByGY, @PayByDSCVR, @TotalReceivedAmount;
                        string @InvoiceNo, @CheckNo = "", @LicNo;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID, @AutoPaymentNo, @IsPaid;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @BillNotes, @BillStatus, @BillType, @TrnsNotes, @TrnsType;
                        DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;
                        
                        if (WoID > 0)
                        {

                            if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                                @ReceiptID = Convert.ToInt32(dr["InvID"]);
                            else
                                @ReceiptID = 0;
                            if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
                                @CustomerID = Convert.ToInt32(dr["CustID"]);
                            else
                                @CustomerID = 8;

                            @WOID = WoID;
                            if (dr["Invnum"] != DBNull.Value && dr["Invnum"] != "")
                                @InvoiceNo = Convert.ToString(dr["Invnum"]);
                            else
                                @InvoiceNo = "";
                            if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                                @TrnsDate = Convert.ToDateTime(dr["InvDate"]);
                            else
                                @TrnsDate = DateTime.Now.Date;

                            if (dr["PaidBy"] != DBNull.Value && dr["PaidBy"] != "")
                                @TrnsNotes = Convert.ToString(dr["PaidBy"]);
                            else
                                @TrnsNotes = "";


                            string paidby = (Convert.ToString(dr["PaidBy"]));
                            string[] PaidbySplit;
                            PaidbySplit = paidby.Split(new Char[] { '$' });
                            string[] PaidbySplitf;
                            //PaidbySplit = paidby.Split(new Char[] { '$' });
                            if (PaidbySplit[0] == "")
                            {
                                @PayByCash = 0;
                                @PayByCheck = 0;
                                @CheckNo = "";
                                @ChgOnAccount = 0;
                                @PayByDeposit = 0;
                            }
                            else
                            {
                                if (PaidbySplit[0].Contains("Account "))
                                {
                                    if (PaidbySplit[1].Contains("\\rCash "))
                                    {
                                        string[] AccountSplit;
                                        AccountSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @ChgOnAccount = (Convert.ToDecimal(AccountSplit[0]));
                                    }
                                    else if (PaidbySplit[1].Contains("\\rChk "))
                                    {
                                        string[] checkSplit;
                                        checkSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @ChgOnAccount = (Convert.ToDecimal(checkSplit[0]));
                                    }
                                    else if (PaidbySplit[1].Contains("\\rVISA-M/C "))
                                    {
                                        string[] VIsaMcSplit;
                                        VIsaMcSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @ChgOnAccount = (Convert.ToDecimal(VIsaMcSplit[0]));
                                    }
                                    else if (PaidbySplit[1].Contains("\\rDebit "))
                                    {
                                        string[] DrcSplit;
                                        DrcSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @ChgOnAccount = (Convert.ToDecimal(DrcSplit[0]));
                                    }
                                    else if (PaidbySplit[0] == "Account ")
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[1]));
                                    }
                                    else if (PaidbySplit[0] == "Account -")
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[1]));
                                    }
                                    else
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[2]));
                                    }
                                }
                                if (PaidbySplit[0].Contains("Cash "))
                                {
                                    if (PaidbySplit[1] == "650.00\\rCash ")
                                    {
                                        @PayByCash = (Convert.ToDecimal(PaidbySplit[2]));
                                    }
                                    else if (PaidbySplit[1].Contains("VISA-M/C "))
                                    {
                                        string[] VisaSplit;
                                        VisaSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @PayByCash = (Convert.ToDecimal(VisaSplit[0]));
                                    }
                                    else if (PaidbySplit[1].Contains("Debit "))
                                    {
                                        string[] DebitSplit;
                                        DebitSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @PayByCash = (Convert.ToDecimal(DebitSplit[0]));
                                    }
                                    else if (PaidbySplit[0] == "Cash ")
                                    {
                                        @PayByCash = (Convert.ToDecimal(PaidbySplit[1]));
                                    }
                                    else
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[2]));
                                    }

                                }
                                if (PaidbySplit[1].Contains("Cash "))
                                {
                                    if (PaidbySplit[1].Contains("\\rCash "))
                                    {
                                        string[] DiscoverSplit;
                                        DiscoverSplit = PaidbySplit[2].Split(new Char[] { '\\' });
                                        @PayByCash = (Convert.ToDecimal(DiscoverSplit[0]));
                                    }
                                    else if (PaidbySplit[0] == "Account ")
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[1]));
                                    }
                                    else
                                    {
                                        @ChgOnAccount = (Convert.ToDecimal(PaidbySplit[2]));
                                    }

                                }
                                if (PaidbySplit[0].Contains("Chk "))
                                {
                                    if (PaidbySplit[1].Contains("\\rCash "))
                                    {
                                        string[] chkSplit;
                                        chkSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @PayByCheck = (Convert.ToDecimal(chkSplit[0]));
                                    }
                                    else if (PaidbySplit[1].Contains("\\rVISA-M/C "))
                                    {
                                        string[] VIsaMcchkSplit;
                                        VIsaMcchkSplit = PaidbySplit[1].Split(new Char[] { '\\' });
                                        @PayByCheck = (Convert.ToDecimal(VIsaMcchkSplit[0]));
                                    }
                                    else if (PaidbySplit[0].Contains("Chk "))
                                    {
                                        @PayByCheck = (Convert.ToDecimal(PaidbySplit[1]));
                                    }
                                    else
                                    {
                                        @PayByCheck = (Convert.ToDecimal(PaidbySplit[2]));
                                    }
                                }
                                if (PaidbySplit[0].Contains("Chk "))
                                {
                                    @CheckNo = (Convert.ToString(PaidbySplit[0]));
                                }
                                if (PaidbySplit[0].Contains("VISA"))
                                {
                                    @PayByVisa = (Convert.ToDecimal(PaidbySplit[1]));
                                }
                            }                    
                                @LicNo = "";
                                @PayByDeposit = 0; 
                           
                            @PayByMC = 0;
                            @PayByAMEX = 0;
                            @PayByATM = 0;
                            @PayByGY = 0;
                                @PayByDSCVR = 0;
                            @PayByDSCVR = 0;
                            @TotalReceivedAmount = Convert.ToDecimal(dr["InvTotal"]);
                            @IsDeposit = 0;
                            @IsPaid = 1;
                            @IsCredit = 0;
                            @Active = 1;
                            DateTime datetime;
                            datetime = getCustomerReceiptTrnsDate(Convert.ToInt32(dr["InvID"]));
                            if (Convert.ToString(datetime) == "01/01/0001 12:00:00 AM")
                            {
                                datetime = DateTime.Now.Date;
                            }
                            @AddDate = datetime;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;

                            getCustReceiptAutoNO(Convert.ToInt32(dr["InvID"]));

                            string InsertQuery = "INSERT INTO [AutoVault].[dbo].[CustomerReceipt]" +
                                                    "([ReceiptID],[CustomerID],[WOID],[InvoiceNo],[TrnsDate],[TrnsNotes],[ChgOnAccount],[PayByCash],[PaybyCheck],[CheckNo],[LicNo],[PayByDeposit],[PayByVisa],[PayByMC],[PayByAMEX],[PayByATM],[PayByGY],[PayByDSCVR],[TotalReceivedAmount],[IsDeposit],[IsPaid],[IsCredit],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "(" + @ReceiptID + "," + @CustomerID + "," + @WOID + ",'" + @InvoiceNo + "','" + @TrnsDate.Year + "-" + @TrnsDate.Month + "-" + @TrnsDate.Day + "','" + @TrnsNotes + "'," + @ChgOnAccount + "," + @PayByCash + "," + @PayByCheck + ",'" + @CheckNo + "','" + @LicNo + "'," + @PayByDeposit + "," + @PayByVisa + "," + @PayByMC + "," + @PayByAMEX + "," + @PayByATM + "," + @PayByGY + "," + @PayByDSCVR + "," + @TotalReceivedAmount + "," + @IsDeposit + "," + @IsPaid + "," + @IsCredit + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            //-------------------------------------------------------------------//                            
                            InsertDataIntoAutoVault(InsertQuery);

                        }
                        
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        //public void InsertCustomerReciptTable1(DataTable dsdt)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        //string query = "SELECT * FROM [TempAB].[dbo].[appliedto] order by ID";
        //        //string query = "SELECT * FROM [TempAB].[dbo].[appliedto] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice])";
        //        string query = "select * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '') and [Status] in ('Invoice') and [PONum] not like 'NEGATE%'";
        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();
        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int CustID = 0;
        //                if ((dr["InvID"] != DBNull.Value) && (dr["InvID"] != ""))
        //                {
        //                    int CustmrID = Convert.ToInt32(dr["InvID"]);
        //                    CustID = getCustID(CustmrID);
        //                }
        //                int WoID = 0;
        //                if ((dr["Invnum"] != DBNull.Value) && (dr["Invnum"] != ""))
        //                {
        //                    string WorkID = Convert.ToString(dr["Invnum"]);
        //                    WoID = getWoID(WorkID);
        //                }
        //                int @ID, @ReceiptID, @CustomerID, @WOID, @IsDeposit, @IsCredit;
        //                decimal @PayByCash = 0, @ChgOnAccount = 0, @PayByCheck = 0, @PayByDeposit, @PayByVisa = 0, @PayByMC, @PayByAMEX, @PayByATM, @PayByGY, @PayByDSCVR, @TotalReceivedAmount;
        //                string @InvoiceNo, @CheckNo = "", @LicNo;
        //                int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID, @AutoPaymentNo, @IsPaid;
        //                string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @BillNotes, @BillStatus, @BillType, @TrnsNotes, @TrnsType;
        //                DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

        //                if (WoID > 0)
        //                {

        //                    if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
        //                        @ReceiptID = Convert.ToInt32(dr["InvID"]);
        //                    else
        //                        @ReceiptID = 0;
        //                    if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
        //                        @CustomerID = Convert.ToInt32(dr["CustID"]);
        //                    else
        //                        @CustomerID = 8;

        //                    @WOID = WoID;
        //                    if (dr["Invnum"] != DBNull.Value && dr["Invnum"] != "")
        //                        @InvoiceNo = Convert.ToString(dr["Invnum"]);
        //                    else
        //                        @InvoiceNo = "";
        //                    @TrnsDate = getCustomerReceiptTrnsDate(Convert.ToInt32(dr["InvID"]));
        //                    if (dr["STATUS"] != DBNull.Value && dr["STATUS"] != "")
        //                        @TrnsNotes = Convert.ToString(dr["STATUS"]);
        //                    else
        //                        @TrnsNotes = "";

        //                    string PaidBy = getCustReciptPaidby(Convert.ToInt32(dr["InvID"]));
        //                    string[] paidbysplit;
        //                    paidbysplit = PaidBy.Split(new Char[] { ' ' });


        //                    if (paidbysplit[0] == "Chk")
        //                    {
        //                        string chkno = paidbysplit[1];
        //                    }
        //                    else
        //                    {
        //                        string cash = paidbysplit[0];
        //                    }
        //                    @PaidBy = paidbysplit[0];
        //                    if (paidbysplit[0] == "Cash")
        //                    {
        //                        @PayByCash = Convert.ToDecimal(dr["PaidBy"]);
        //                    }
        //                    if (paidbysplit[0] == "chk")
        //                    {
        //                        @PayByCheck = Convert.ToDecimal(dr["PaidBy"]);
        //                    }
        //                    if (paidbysplit[0] == "chk")
        //                    {
        //                        @CheckNo = paidbysplit[1];
        //                    }
        //                    @LicNo = "";
        //                    @PayByDeposit = 0;
        //                    if (paidbysplit[0] == "VISA-M/C")
        //                    {
        //                        @PayByVisa = Convert.ToDecimal(dr["PaidBy"]);
        //                    }
        //                    if (paidbysplit[0] == "Account")
        //                    {
        //                        @ChgOnAccount = Convert.ToDecimal(dr["PaidBy"]);
        //                    }
        //                    @PayByMC = 0;
        //                    @PayByAMEX = 0;
        //                    @PayByATM = 0;
        //                    @PayByGY = 0;
        //                    @PayByDSCVR = 0;
        //                    @TotalReceivedAmount = Convert.ToDecimal(dr["PaidBy"]);
        //                    @IsDeposit = 0;
        //                    @IsPaid = 1;
        //                    @IsCredit = 0;

        //                    @Active = 1;
        //                    DateTime datetime;
        //                    datetime = getCustomerReceiptTrnsDate(Convert.ToInt32(dr["InvID"]));
        //                    if (Convert.ToString(datetime) == "01/01/0001 12:00:00 AM")
        //                    {
        //                        datetime = DateTime.Now.Date;
        //                    }
        //                    @AddDate = datetime;
        //                    @AddUserID = -2;
        //                    @ModifyUserID = 0;
        //                    @ModifyDate = DateTime.Now.Date;
        //                    @Comments = "";
        //                    @IsLocked = 0;
        //                    @DocNo = "";
        //                    @Remarks = "";
        //                    @CoFinEndYear = 0;
        //                    @TrnsVrNo = "";
        //                    @TrnsJrRef = "";
        //                    @CompanyID = 1;
        //                    @WarehouseID = 1;
        //                    @StoreID = 1;

        //                    getCustReceiptAutoNO(Convert.ToInt32(dr["ID"]));

        //                    string InsertQuery = "INSERT INTO [AutoVault].[dbo].[CustomerReceipt]" +
        //                                            "([ReceiptID],[CustomerID],[WOID],[InvoiceNo],[TrnsDate],[TrnsNotes],[ChgOnAccount],[PayByCash],[PaybyCheck],[CheckNo],[LicNo],[PayByDeposit],[PayByVisa],[PayByMC],[PayByAMEX],[PayByATM],[PayByGY],[PayByDSCVR],[TotalReceivedAmount],[IsDeposit],[IsPaid],[IsCredit],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
        //                                        "VALUES" +
        //                                        "(" + @ReceiptID + "," + @CustomerID + "," + @WOID + ",'" + @InvoiceNo + "','" + @TrnsDate.Year + "-" + @TrnsDate.Month + "-" + @TrnsDate.Day + "','" + @TrnsNotes + "'," + @ChgOnAccount + "," + @PayByCash + "," + @PayByCheck + ",'" + @CheckNo + "','" + @LicNo + "'," + @PayByDeposit + "," + @PayByVisa + "," + @PayByMC + "," + @PayByAMEX + "," + @PayByATM + "," + @PayByGY + "," + @PayByDSCVR + "," + @TotalReceivedAmount + "," + @IsDeposit + "," + @IsPaid + "," + @IsCredit + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
        //                    //-------------------------------------------------------------------//                            
        //                    InsertDataIntoAutoVault(InsertQuery);

        //                }

        //            }
        //            catch { }
        //        }
        //    }
        //}
        ////------------------------------------------------------//
        public void InsertAccountsTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[accttypes]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int AcID = 0;
                        if ((dr["TypeName"] != DBNull.Value) && (dr["TypeName"] != ""))
                        {
                            string SName = Convert.ToString(dr["TypeName"]);
                            AcID = getAccountIdByName(SName);
                        }
                        int @AccID, @AccNo, @AccTypeID, @AccLevel, @RelatedToPNL, @TransferAllowed, @CannotDelete, @CannotDirectEntry, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        string @AccName, @Company, @GLAcct, @GLFeeAcct, @XCharge, @CardType, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        decimal @Fee, @FeeAmt;
                        DateTime @AddDate, @ModifyDate;
                        if (AcID == 0)
                        {
                            if (dr["PTType"] != DBNull.Value && dr["PTType"] != "")
                                @AccID = Convert.ToInt32(dr["PTType"]);
                            else
                                @AccID = 0;
                            @AccNo = 0;
                            if (dr["TypeName"] != DBNull.Value && dr["TypeName"] != "")
                                @AccName = Convert.ToString(dr["TypeName"]);
                            else
                                @AccName = "";
                            if (dr["AcctType"] != DBNull.Value && dr["AcctType"] != "")
                                @AccTypeID = Convert.ToInt32(dr["AcctType"]);
                            else
                                @AccTypeID = 0;
                            @AccLevel = 0;
                            @RelatedToPNL = 0;
                            @TransferAllowed = 0;
                            @CannotDelete = 0;
                            @CannotDirectEntry = 0;
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsJrRef = "";
                            @TrnsVrNo = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[Account]" +
                                                    "([AccID],[AccName],[AccTypeID],[AccLevel],[RelatedToPNL],[TransferAllowed],[CannotDelete],[CannotDirectEntry],[Remarks],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef])" +
                                                "VALUES" +
                                                "(" + @AccID + ",'" + @AccName + "'," + @AccTypeID + "," + @AccLevel + "," + @RelatedToPNL + "," + @TransferAllowed + "," + @CannotDelete + "," + @CannotDirectEntry + ",'" + @Remarks + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + "," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertItemGroupTypeTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "Select distinct(gritemtype) From TempAB.dbo.itemgroup order by gritemtype";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int itmtypeid = 0;
                        if ((dr["gritemtype"] != DBNull.Value) && (dr["gritemtype"] != ""))
                        {
                            string GroupName = Convert.ToString(dr["gritemtype"]);
                            itmtypeid = getItemgroupTypeidbyname(GroupName);
                        }
                        int @ID, @CustomerID, @CCTerms, @Delayed1, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
                        decimal @Fee, @FeeAmt;
                        DateTime @AddDate, @ModifyDate;
                        if (itmtypeid == 0)
                        {
                            if (dr["gritemtype"] != DBNull.Value && dr["gritemtype"] != "")
                                @Name = Convert.ToString(dr["gritemtype"]);
                            else
                                @Name = "";
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsJrRef = "";
                            @TrnsVrNo = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[ItemGroupType]" +
                                                    "([Name],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "('" + @Name + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertBankAccountTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[bankacct]";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int bankid = 0;
                        if ((dr["bankname"] != DBNull.Value) && (dr["bankname"] != ""))
                        {
                            string bankName = Convert.ToString(dr["bankname"]);
                            bankid = getBankAccountidbyname(bankName);
                        }
                        int @AccountID, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @IsCash, @IsVendorOnly, @DiscountTypeID, @CompanyID, @WarehouseID, @StoreID;
                        string @BankName, @AccNo, @Description, @AccTitle, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @DueByDescription;
                        DateTime @AddDate, @ModifyDate, @RegDate, @LastReconciled;
                        decimal @BankSMTBeginning, @BankSMTEnding;
                        if (bankid == 0)
                        {
                            @RegDate = DateTime.Now.Date;
                            if (dr["bankname"] != DBNull.Value && dr["bankname"] != "")
                                @BankName = Convert.ToString(dr["bankname"]);
                            else
                                @BankName = "";
                            if (dr["BankAcctID"] != DBNull.Value && dr["BankAcctID"] != "")
                                @AccNo = Convert.ToString(dr["BankAcctID"]);
                            else
                                @AccNo = "";
                            @AccTitle = "";
                            @Description = "";
                            @LastReconciled = DateTime.Now.Date;
                            if (dr["BegBalance"] != DBNull.Value && dr["BegBalance"] != "")
                                @BankSMTBeginning = Convert.ToDecimal(dr["BegBalance"]);
                            else
                                @BankSMTBeginning = 0;
                            if (dr["EndBalance"] != DBNull.Value && dr["EndBalance"] != "")
                                @BankSMTEnding = Convert.ToDecimal(dr["EndBalance"]);
                            else
                                @BankSMTEnding = 0;
                            @Active = 1;
                            @AddDate = DateTime.Now.Date;
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;
                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[BankAccounts]" +
                                                    "([RegDate],[BankName],[AccNo],[AccTitle],[Description],[LastReconciled],[BankSMTBeginning],[BankSMTEnding],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                "VALUES" +
                                                "('" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "','" + @BankName + "','" + @AccNo + "','" + @AccTitle + "','" + @Description + "','" + @LastReconciled.Year + "-" + @LastReconciled.Month + "-" + @LastReconciled.Day + "'," + @BankSMTBeginning + "," + @BankSMTEnding + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        //public void InsertTireSizeTable(DataTable dsdt)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string query = "select * from TempAB.dbo.tiresize";
        //        SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
        //        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
        //        commandDatabase.CommandTimeout = 60;
        //        SqlDataReader reader;
        //        databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //        databaseConnection.Close();
        //    }
        //    catch { }
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            try
        //            {
        //                int TireSizeid = 0;
        //                if ((dr["imsize"] != DBNull.Value) && (dr["imsize"] != ""))
        //                {
        //                    string TireSize = Convert.ToString(dr["imsize"]);
        //                    TireSizeid = getTireSizeidbyname(TireSize);
        //                }
        //                string @WType, @TSize;
        //                int @IsDefault;
        //                string @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef;
        //                int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
        //                DateTime @AddDate, @ModifyDate;
        //                if (TireSizeid == 0)
        //                {
        //                    if (dr["imsize"] != DBNull.Value && dr["imsize"] != "")
        //                        @TSize = Convert.ToString(dr["imsize"]);
        //                    else
        //                        @TSize = "";
        //                    if (dr["wtype"] != DBNull.Value && dr["wtype"] != "")
        //                        @WType = Convert.ToString(dr["wtype"]);
        //                    else
        //                        @WType = "";
        //                    @IsDefault = 1;
        //                    @Active = 1;
        //                    @AddDate = DateTime.Now.Date;
        //                    @AddUserID = -2;
        //                    @ModifyUserID = 0;
        //                    @ModifyDate = DateTime.Now.Date;
        //                    @Comments = "";
        //                    @IsLocked = 0;
        //                    @DocNo = "";
        //                    @Remarks = "";
        //                    @CoFinEndYear = 0;
        //                    @TrnsVrNo = "";
        //                    @TrnsJrRef = "";
        //                    string Qry1 = "INSERT INTO [AutoVault].[dbo].[TireSize]" +
        //                                            "([TSize],[WType],[IsDefault],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef])" +
        //                                        "VALUES" +
        //                                        "('" + @TSize + "','" + @WType + "'," + @IsDefault + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "');";
        //                    string InsertQuery =  "\n" + Qry1 + "\n" ;
        //                    InsertDataIntoAutoVault(InsertQuery);
        //                }
        //            }
        //            catch { }
        //        }
        //    }
        //}
        //------------------------------------------------------//
        public void InsertWorkOrderNegateTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet]))";
                string query = "select * FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice]) and [Catalog] <> '') and [Status] in ('Invoice','W/O') and [PONum] like 'NEGATE%'";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int RepId = 0;
                        if ((dr["RepID"] != DBNull.Value) && (dr["RepID"] != ""))
                        {
                            string RepName = Convert.ToString(dr["RepID"]);
                            RepId = getRepIDID(RepName);
                        }
                        int SaleCatId = 4;
                        if ((dr["SaleCatID"] != DBNull.Value) && (dr["SaleCatID"] != ""))
                        {
                            string SaleCatName = Convert.ToString(dr["SaleCatID"]);
                            SaleCatId = getSaleCatID(SaleCatName);
                        }
                        int SaleTerID = 2;
                        if ((dr["TermsID"] != DBNull.Value) && (dr["TermsID"] != ""))
                        {
                            string SaleTermName = Convert.ToString(dr["TermsID"]);
                            SaleTerID = getSaleTermID(SaleTermName);
                        }
                        int @ID, @WorkOrderID, @WorkOrderNegateNo, @WorkOrderNo, @IsQutation, @IsWorkOrderNegate, @IsCustomerOrder, @CustomerID, @IsNoVehicle, @VehicleID, @SaleRepID = 0, @MechID, @ReferredByID, @SaleCategoryID, @PriceLevelID, @SaleTaxRateID, @SaleTermID = 0, @ShipViaID, @WarehouseBayID, @CreatedByID;
                        int @IsNegated, @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        string @Notes, @PONo, @Status, @DocNo, @Remarks, @TrnsVrNo, @Comments, @TrnsJrRef;
                        decimal @Mileage, @MileageOut, @PartsPrice, @LaborPrice, @OtherPrice, @FET, @Taxable, @Tax, @Discount, @PartDisPer, @LaborDisPer, @Total;
                        DateTime @AddDate, @ModifyDate, @RegDate, @PickupDate, @PickupTime;

                        @ID = Convert.ToInt32(dr["invid"]);
                        if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                            @RegDate = Convert.ToDateTime(dr["InvDate"]);
                        else
                            @RegDate = DateTime.Now;
                        string WorkId = (Convert.ToString(dr["PONum"]));
                        string[] WorkIdSplit;
                        WorkIdSplit = WorkId.Split(new Char[] { '#' });
                        int workida = getWorkNegateId(Convert.ToInt32(WorkIdSplit[1]));
                        @WorkOrderID = workida;
                        if (dr["invid"] != DBNull.Value && dr["invid"] != "")
                            @WorkOrderNegateNo = Convert.ToInt32(dr["invid"]);
                        else
                            @WorkOrderNegateNo = 0;
                        if (dr["InvNum"] != DBNull.Value && dr["InvNum"] != "")
                            @Notes = Convert.ToString(dr["InvNum"]);
                        else
                            @Notes = "";
                        @IsQutation = 0;
                        @IsWorkOrderNegate = 1;
                        @IsCustomerOrder = 1;
                        if (dr["CustID"] != DBNull.Value && dr["CustID"] != "")
                            @CustomerID = Convert.ToInt32(dr["CustID"]);
                        else
                            @CustomerID = 0;
                        if (dr["VehId"] != DBNull.Value && dr["VehId"] != "")
                            @VehicleID = Convert.ToInt32(dr["VehId"]);
                        else
                            @VehicleID = 0;
                        if (@VehicleID != 0)
                            @IsNoVehicle = 1;
                        else
                            @IsNoVehicle = 0;
                        if (dr["Mileage"] != DBNull.Value && dr["Mileage"] != "")
                            @Mileage = Convert.ToDecimal(dr["Mileage"]);
                        else
                            @Mileage = 0;
                        if (dr["MilesOut"] != DBNull.Value && dr["MilesOut"] != "")
                            @MileageOut = Convert.ToDecimal(dr["MilesOut"]);
                        else
                            @MileageOut = 0;
                        if (dr["PONum"] != DBNull.Value && dr["PONum"] != "")
                            @PONo = Convert.ToString(dr["PONum"]);
                        else
                            @PONo = "";
                        if (RepId > 0)
                            @SaleRepID = RepId;
                        else
                            @SaleRepID = 2;
                        @ReferredByID = 7;
                        if (SaleCatId > 0)
                            @SaleCategoryID = SaleCatId;
                        else
                            @SaleCategoryID = 3;

                        @PriceLevelID = 1;
                        @SaleTaxRateID = 1;
                        if (SaleTerID > 0)
                            @SaleTermID = SaleTerID;
                        else
                            @SaleTerID = 2;
                        @ShipViaID = 9;
                        @WarehouseBayID = 1;
                        @CreatedByID = 2;
                        if (dr["TaxableParts"] != DBNull.Value && dr["TaxableParts"] != "")
                            @PartsPrice = Convert.ToDecimal(dr["TaxableParts"]);
                        else
                            @PartsPrice = 0;
                        if (dr["TaxableLabor"] != DBNull.Value && dr["TaxableLabor"] != "")
                            @LaborPrice = Convert.ToDecimal(dr["TaxableLabor"]);
                        else
                            @LaborPrice = 0;
                        @OtherPrice = 0;
                        if (dr["FETTotal"] != DBNull.Value && dr["FETTotal"] != "")
                            @FET = Convert.ToDecimal(dr["FETTotal"]);
                        else
                            @FET = 0;
                        if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
                            @Taxable = Convert.ToDecimal(dr["Taxable"]);
                        else
                            @Taxable = 0;
                        if (dr["Tax"] != DBNull.Value && dr["Tax"] != "")
                            @Tax = Convert.ToDecimal(dr["Tax"]);
                        else
                            @Tax = 0;
                        if (dr["Tax"] != DBNull.Value && dr["Tax"] != "")
                            @Tax = Convert.ToDecimal(dr["Tax"]);
                        else
                            @Tax = 0;
                        if (dr["DiscountAmt"] != DBNull.Value && dr["DiscountAmt"] != "")
                            @Discount = Convert.ToDecimal(dr["DiscountAmt"]);
                        else
                            @Discount = 0;

                        if (dr["SDiscountParts"] != DBNull.Value && dr["SDiscountParts"] != "")
                            @PartDisPer = Convert.ToDecimal(dr["SDiscountParts"]);
                        else
                            @PartDisPer = 0;
                        if (dr["SDiscountLabor"] != DBNull.Value && dr["SDiscountLabor"] != "")
                            @LaborDisPer = Convert.ToDecimal(dr["SDiscountLabor"]);
                        else
                            @LaborDisPer = 0;
                        if (dr["InvTotal"] != DBNull.Value && dr["InvTotal"] != "")
                            @Total = Convert.ToDecimal(dr["InvTotal"]);
                        else
                            @Total = 0;
                        if (dr["WoDate"] != DBNull.Value && dr["WoDate"] != "")
                            @PickupDate = Convert.ToDateTime(dr["WoDate"]);
                        else
                            @PickupDate = DateTime.Now;
                        if (dr["Status"] != DBNull.Value && dr["Status"] != "")
                            @Status = Convert.ToString(dr["Status"]);
                        else
                            @Status = "";
                        @Active = 1;
                        if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                            @AddDate = Convert.ToDateTime(dr["InvDate"]);
                        else
                            @AddDate = DateTime.Now;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        if (dr["PaidBy"] != DBNull.Value && dr["PaidBy"] != "")
                            @Comments = Convert.ToString(dr["PaidBy"]);
                        else
                            @Comments = "";
                        @IsLocked = 0;
                        if (dr["SchedStatus"] != DBNull.Value && dr["SchedStatus"] != "")
                            @DocNo = Convert.ToString(dr["SchedStatus"]);
                        else
                            @DocNo = "";
                        if (dr["WoNum"] != DBNull.Value && dr["WoNum"] != "")
                            @Remarks = Convert.ToString(dr["WoNum"]);
                        else
                            @Remarks = "";
                        @CoFinEndYear = 0;
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        
                        getWONegateAutoNO(Convert.ToInt32(dr["InvID"]));

                        string Qry0 = "SET IDENTITY_INSERT [dbo].[WorkOrderNegate] ON";
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderNegate]" +
                                                "([ID],[WorkOrderID],[RegDate],[WorkOrderNegateNo],[Notes],[IsQutation],[IsWorkOrderNegate],[IsCustomerOrder],[CustomerID],[IsNoVehicle],[VehicleID],[Mileage],[MileageOut],[PONo],[SaleRepID],[ReferredByID],[SaleCategoryID],[PriceLevelID],[SaleTaxRateID],[SaleTermID],[ShipViaID],[WarehouseBayID],[CreatedByID],[PartsPrice],[LaborPrice],[OtherPrice],[FET],[Taxable],[Tax],[Discount],[PartDisPer],[LaborDisPer],[Total],[PickupDate],[Status],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @ID + "," + @WorkOrderID + ",'" + @RegDate.Year + "-" + @RegDate.Month + "-" + @RegDate.Day + "'," + @WorkOrderNegateNo + ",'" + @Notes + "'," + @IsQutation + "," + @IsWorkOrderNegate + "," + @IsCustomerOrder + "," + @CustomerID + "," + @IsNoVehicle + "," + @VehicleID + "," + @Mileage + "," + @MileageOut + ",'" + @PONo + "'," + @SaleRepID + "," + @ReferredByID + "," + @SaleCategoryID + "," + @PriceLevelID + "," + @SaleTaxRateID + "," + @SaleTermID + "," + @ShipViaID + "," + @WarehouseBayID + "," + @CreatedByID + "," + @PartsPrice + "," + @LaborPrice + "," + @OtherPrice + "," + @FET + "," + @Taxable + "," + @Tax + "," + @Discount + "," + @PartDisPer + "," + @LaborDisPer + "," + @Total + ",'" + @PickupDate.Year + "-" + @PickupDate.Month + "-" + @PickupDate.Day + "','" + @Status + "'," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string Qry2 = "SET IDENTITY_INSERT [dbo].[WorkOrderNegate] OFF";
                        //-------------------------------------------------------------------//
                        string InsertQuery = Qry0 + "\n" + Qry1 + "\n" + Qry2;
                        InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertWorkOrderNegateDetailTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where [Amount] < 0 ";
                string query = "SELECT * FROM [TempAB].[dbo].[invoicedet] where InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet]))) and Amount < 0";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int WoNID = 0;
                        if ((dr["InvID"] != DBNull.Value) && (dr["InvID"] != ""))
                        {
                            int WorkID = Convert.ToInt32(dr["InvID"]);
                            WoNID = getWorkNegateID(WorkID);
                        }
                        if (Convert.ToInt32(dr["InvID"]) > 0)
                        {
                            int itmID = 0;
                            if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                            {
                                string ItemName = Convert.ToString(dr["Catalog"]);
                                if (ItemName == "FEUL")
                                    itmID = getitemIDForWordOrderDetail("FUEL");
                                else
                                    itmID = getitemIDForWordOrderDetail(ItemName); // Like Query
                                if (itmID == 0)
                                    itmID = getitemID(ItemName); // isequal Query
                            }
                            int RepId = 0;
                            if ((dr["sRepID"] != DBNull.Value) && (dr["sRepID"] != ""))
                            {
                                string RepName = Convert.ToString(dr["sRepID"]);
                                RepId = getRepIDID(RepName);
                            }
                            int @MechanicID, @RepID, @IsDone, @IsTax;
                            int @MID, @PackageID, @ItemID, @FeeID, @LaborID, @VehicleInspectionID, @InspectionHeadID, @Available, @Qty, @IsVendorManufacture, @IsDiscountable, @IsNotShared, @IsObsolete, @IsRepComm, @IsOutsideItem, @IsMechComm, @IsCosted, @IsTaxable, @IsRetread, @IsStocked, @IsUseFET;
                            decimal @Hours, @Price, @Cost, @Amount, @DiscPer, @DiscAmount, @FET, @Total, @MarginPer, @MarginAmount, @Tax, @SaleTaxRate;

                            int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                            string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
                            DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;
                            if (WoNID > 0)
                            {
                                if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                                    @MID = Convert.ToInt32(dr["InvID"]);
                                else
                                    @MID = 0;
                                if (itmID >= 1)
                                    @ItemID = itmID;
                                else
                                    @ItemID = 0;
                                @Ctype = "";
                                @Available = 0;
                                if (dr["Qty"] != DBNull.Value && dr["Qty"] != "")
                                    @Qty = Convert.ToInt32(dr["Qty"]);
                                else
                                    @Qty = 0;
                                if (dr["Hours"] != DBNull.Value && dr["Hours"] != "")
                                    @Hours = Convert.ToDecimal(dr["Hours"]);
                                else
                                    @Hours = 0;
                                @IsVendorManufacture = 0;
                                if (dr["NoDiscount"] != DBNull.Value && dr["NoDiscount"] != "")
                                    @IsDiscountable = Convert.ToInt32(dr["NoDiscount"]);
                                else
                                    @IsDiscountable = 0;
                                @IsNotShared = 0;
                                @IsObsolete = 0;
                                if (dr["RepComm"] != DBNull.Value && dr["RepComm"] != "")
                                    @IsRepComm = Convert.ToInt32(dr["RepComm"]);
                                else
                                    @IsRepComm = 0;
                                if (dr["Outside"] != DBNull.Value && dr["Outside"] != "")
                                    @IsOutsideItem = Convert.ToInt32(dr["Outside"]);
                                else
                                    @IsOutsideItem = 0;
                                if (dr["Commission"] != DBNull.Value && dr["Commission"] != "")
                                    @IsMechComm = Convert.ToInt32(dr["Commission"]);
                                else
                                    @IsMechComm = 0;
                                if (dr["Costable"] != DBNull.Value && dr["Costable"] != "")
                                    @IsCosted = Convert.ToInt32(dr["Costable"]);
                                else
                                    @IsCosted = 0;
                                if (dr["Taxable"] != DBNull.Value && dr["Taxable"] != "")
                                    @IsTaxable = Convert.ToInt32(dr["Taxable"]);
                                else
                                    @IsTaxable = 0;
                                if (dr["Retread"] != DBNull.Value && dr["Retread"] != "")
                                    @IsRetread = Convert.ToInt32(dr["Retread"]);
                                else
                                    @IsRetread = 0;
                                if (dr["Stock"] != DBNull.Value && dr["Stock"] != "")
                                    @IsStocked = Convert.ToInt32(dr["Stock"]);
                                else
                                    @IsStocked = 0;
                                if (dr["UseFet"] != DBNull.Value && dr["UseFet"] != "")
                                    @IsUseFET = Convert.ToInt32(dr["UseFet"]);
                                else
                                    @IsUseFET = 0;
                                if (dr["Price"] != DBNull.Value && dr["Price"] != "")
                                    @Price = Convert.ToDecimal(dr["Price"]);
                                else
                                    @Price = 0;
                                if (dr["Cost"] != DBNull.Value && dr["Cost"] != "")
                                    @Cost = Convert.ToDecimal(dr["Cost"]);
                                else
                                    @Cost = 0;
                                if (dr["Amount"] != DBNull.Value && dr["Amount"] != "")
                                    @Amount = Convert.ToDecimal(dr["Amount"]);
                                else
                                    @Amount = 0;
                                @DiscPer = 0;
                                if (dr["SDiscount"] != DBNull.Value && dr["SDiscount"] != "")
                                    @DiscAmount = Convert.ToDecimal(dr["SDiscount"]);
                                else
                                    @DiscAmount = 0;
                                if (dr["FET"] != DBNull.Value && dr["FET"] != "")
                                    @FET = Convert.ToDecimal(dr["FET"]);
                                else
                                    @FET = 0;
                                @Total = Convert.ToDecimal(dr["Amount"]);
                                @MechanicID = -2;

                                if (RepId > 0)
                                    @RepID = RepId;
                                else
                                    @RepID = 2;
                                @IsDone = 0;
                                @SaleTaxRate = 1;
                                @IsTax = 1;
                                @Tax = 0;
                                @MarginPer = 0;
                                @MarginAmount = 0;
                                @Active = 1;
                                @AddDate = getWorkOrderDate(Convert.ToInt32(dr["InvID"]));
                                @AddUserID = -2;
                                @ModifyUserID = 0;
                                @ModifyDate = DateTime.Now.Date;
                                if (dr["Description"] != DBNull.Value && dr["Description"] != "")
                                    @Comments = Convert.ToString(dr["Description"]);
                                else
                                    @Comments = "";
                                @IsLocked = 0;
                                if (dr["GroupID"] != DBNull.Value && dr["GroupID"] != "")
                                    @DocNo = Convert.ToString(dr["GroupID"]);
                                else
                                    @DocNo = "";
                                if (dr["ItemType"] != DBNull.Value && dr["ItemType"] != "")
                                    @Remarks = Convert.ToString(dr["ItemType"]);
                                else
                                    @Remarks = "";
                                @CoFinEndYear = 0;
                                if (dr["ItemTypeID"] != DBNull.Value && dr["ItemTypeID"] != "")
                                    @TrnsVrNo = Convert.ToString(dr["ItemTypeID"]);
                                else
                                    @TrnsVrNo = "";
                                @TrnsJrRef = "";
                                @CompanyID = 1;
                                @WarehouseID = 1;
                                @StoreID = 1;
                                
                                string Qry1 = "INSERT INTO [AutoVault].[dbo].[WorkOrderNegateDetail]" +
                                                        "([MID],[ItemID],[Ctype],[Available],[Qty],[Hours],[IsVendorManufacture],[IsDiscountable],[IsNotShared],[IsObsolete],[IsRepComm],[IsOutsideItem],[IsMechComm],[IsCosted],[IsTaxable],[IsRetread],[IsStocked],[IsUseFET],[Price],[Cost],[Amount],[DiscPer],[DiscAmount],[FET],[Total],[MechanicID],[RepID],[IsDone],[SaleTaxRate],[IsTax],[Tax],[MarginPer],[MarginAmount],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                                    "VALUES" +
                                                    "(" + @MID + "," + @ItemID + ",'" + @Ctype + "'," + @Available + "," + @Qty + "," + @Hours + "," + @IsVendorManufacture + "," + @IsDiscountable + "," + @IsNotShared + "," + @IsObsolete + "," + @IsRepComm + "," + @IsOutsideItem + "," + @IsMechComm + "," + @IsCosted + "," + @IsTaxable + "," + @IsRetread + "," + @IsStocked + "," + @IsUseFET + "," + @Price + "," + @Cost + "," + @Amount + "," + @DiscPer + "," + @DiscAmount + "," + @FET + "," + @Total + "," + @MechanicID + "," + @RepID + "," + @IsDone + "," + @SaleTaxRate + "," + @IsTax + "," + @Tax + "," + @MarginPer + "," + @MarginAmount + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                                string InsertQuery = "\n" + Qry1 + "\n";
                                InsertDataIntoAutoVault(InsertQuery);
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        public void InsertCustomerPaymentTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                //string query = "SELECT * FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' ";
                string query = "SELECT * FROM [TempAB].[dbo].[invoice] where PONum like '%NEGATE%' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoice] where PONum <> 'Del' and InvID in (SELECT InvID FROM [TempAB].[dbo].[invoicedet])) AND InvNum is not null";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int CustID = 0;
                        if ((dr["CustID"] != DBNull.Value) && (dr["CustID"] != ""))
                        {
                            int CustmrID = Convert.ToInt32(dr["CustID"]);
                            CustID = getCustID(CustmrID);
                        }
                        int @ID, @PaymentID, @CustomerID, @WONID=0, @IsDeposit, @IsCredit;
                        decimal @PayByCash = 0, @ChgOnAccount = 0, @PayByCheck = 0, @PayByDeposit, @PayByVisa = 0, @PayByMC, @PayByAMEX, @PayByATM, @PayByGY, @PayByDSCVR, @TotalReceivedAmount;
                        string @InvoiceNo, @CheckNo = "", @LicNo;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @IsDefault, @CompanyID, @WarehouseID, @StoreID, @AutoPaymentNo, @IsPaid;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @BillNotes, @BillStatus, @BillType, @TrnsNotes, @TrnsType;
                        DateTime @AddDate, @ModifyDate, @BillDate, @DueDate, @TrnsDate;

                        if (dr["InvID"] != DBNull.Value && dr["InvID"] != "")
                            @PaymentID = Convert.ToInt32(dr["InvID"]);
                        else
                            @PaymentID = 0;
                        if (CustID > 0)
                            @CustomerID = CustID;
                        else
                            @CustomerID = 1;

                        if ((dr["InvID"] != DBNull.Value) && (dr["InvID"] != ""))
                        {
                            int WorkNagetID = Convert.ToInt32(dr["InvID"]);
                            @WONID = getWONID(WorkNagetID);
                        }

                        if (dr["PONum"] != DBNull.Value && dr["PONum"] != "")
                            @InvoiceNo = Convert.ToString(dr["PONum"]);
                        else
                            @InvoiceNo = "";
                        if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                            @TrnsDate = Convert.ToDateTime(dr["InvDate"]);
                        else
                            @TrnsDate = DateTime.Now.Date;
                        if (dr["PaidBy"] != DBNull.Value && dr["PaidBy"] != "")
                            @TrnsNotes = Convert.ToString(dr["PaidBy"]);
                        else
                            @TrnsNotes = "";
                        string paidby = (Convert.ToString(dr["PaidBy"]));
                        string[] PaidbySplit;
                        PaidbySplit = paidby.Split(new Char[] { '-' });

                        if (PaidbySplit[0].Contains("Account "))
                        {
                            @ChgOnAccount = Convert.ToDecimal(dr["InvTotal"]);
                        }
                        if (PaidbySplit[0].Contains("Cash "))
                        {
                            @PayByCash = Convert.ToDecimal(dr["InvTotal"]);
                        }   
                                               
                            @PayByCheck = 0;                        
                            @CheckNo = "";                        
                            @LicNo = "";
                            @PayByDeposit = 0;                        
                            @PayByVisa = 0;                        
                            @PayByMC = 0;
                            @PayByAMEX = 0;
                            @PayByATM = 0;
                            @PayByGY = 0;
                            @PayByDSCVR = 0;
                            @TotalReceivedAmount = Convert.ToDecimal(dr["InvTotal"]);
                            @IsDeposit = 1;
                            @IsPaid = 0;
                            @IsCredit = 0;
                            @Active = 1;
                            if (dr["InvDate"] != DBNull.Value && dr["InvDate"] != "")
                                @AddDate = Convert.ToDateTime(dr["InvDate"]);
                            else
                                @AddDate = DateTime.Now.Date;                         
                            @AddUserID = -2;
                            @ModifyUserID = 0;
                            @ModifyDate = DateTime.Now.Date;
                            @Comments = "";
                            @IsLocked = 0;
                            @DocNo = "";
                            @Remarks = "";
                            @CoFinEndYear = 0;
                            @TrnsVrNo = "";
                            @TrnsJrRef = "";
                            @CompanyID = 1;
                            @WarehouseID = 1;
                            @StoreID = 1;

                            getcustPaymentAutoNO(Convert.ToInt32(dr["InvID"]));

                            string Qry1 = "INSERT INTO [AutoVault].[dbo].[CustomerPayment]" +
                                                "([PaymentID],[CustomerID],[WONID],[InvoiceNo],[TrnsDate],[TrnsNotes],[ChgOnAccount],[PayByCash],[PaybyCheck],[CheckNo],[LicNo],[PayByDeposit],[PayByVisa],[PayByMC],[PayByAMEX],[PayByATM],[PayByGY],[PayByDSCVR],[TotalReceivedAmount],[IsDeposit],[IsPaid],[IsCredit],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @PaymentID + "," + @CustomerID + "," + @WONID + ",'" + @InvoiceNo + "','" + @TrnsDate.Year + "-" + @TrnsDate.Month + "-" + @TrnsDate.Day + "','" + @TrnsNotes + "'," + @ChgOnAccount + "," + @PayByCash + "," + @PayByCheck + ",'" + @CheckNo + "','" + @LicNo + "'," + @PayByDeposit + "," + @PayByVisa + "," + @PayByMC + "," + @PayByAMEX + "," + @PayByATM + "," + @PayByGY + "," + @PayByDSCVR + "," + @TotalReceivedAmount + "," + @IsDeposit + "," + @IsPaid + "," + @IsCredit + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                            string InsertQuery = "\n" + Qry1 + "\n";
                            InsertDataIntoAutoVault(InsertQuery);
                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------// 
        public void InsertItemStockTable(DataTable dsdt)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM [TempAB].[dbo].[item] where avail1122731 <> 0";
                SqlConnection databaseConnection = new SqlConnection(TempABSqlConnectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                databaseConnection.Close();
            }
            catch { }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        int ItemId = 0;
                        if ((dr["Catalog"] != DBNull.Value) && (dr["Catalog"] != ""))
                        {
                            string ItemName = Convert.ToString(dr["Catalog"]);
                            ItemId = getitemID(ItemName);
                        }
                        int @Qty, @ItemID;
                        int @Active, @AddUserID, @ModifyUserID, @IsLocked, @CoFinEndYear, @CompanyID, @WarehouseID, @StoreID;
                        string @Name, @Comments, @DocNo, @Remarks, @TrnsVrNo, @TrnsJrRef, @Ctype;
                        DateTime @AddDate, @ModifyDate;
                        if (ItemId > 0)
                            @ItemID = ItemId;
                        else
                            @ItemID = 1;
                        if (dr["avail1122731"] != DBNull.Value && dr["avail1122731"] != "")
                            @Qty = Convert.ToInt32(dr["avail1122731"]);
                        else
                            @Qty = 0;
                        @Active = 1;
                        @AddDate = DateTime.Now.Date;
                        @AddUserID = -2;
                        @ModifyUserID = 0;
                        @ModifyDate = DateTime.Now.Date;
                        @Comments = "";
                        @IsLocked = 0;
                        @DocNo = "";
                        @Remarks = "";
                        @CoFinEndYear = 0;
                        @TrnsVrNo = "";
                        @TrnsJrRef = "";
                        @CompanyID = 1;
                        @WarehouseID = 1;
                        @StoreID = 1;
                        string Qry1 = "INSERT INTO [AutoVault].[dbo].[ItemStock]" +
                                                "([ItemID],[Qty],[Active],[AddDate],[AddUserID],[ModifyUserID],[ModifyDate],[Comments],[IsLocked],[DocNo],[Remarks],[CoFinEndYear],[TrnsVrNo],[TrnsJrRef],[CompanyID],[WarehouseID],[StoreID])" +
                                            "VALUES" +
                                            "(" + @ItemID + "," + @Qty + "," + @Active + ",'" + @AddDate.Year + "-" + @AddDate.Month + "-" + @AddDate.Day + "'," + @AddUserID + "," + @ModifyUserID + ",'" + @ModifyDate.Year + "-" + @ModifyDate.Month + "-" + @ModifyDate.Day + "','" + @Comments + "'," + @IsLocked + ",'" + @DocNo + "','" + @Remarks + "'," + @CoFinEndYear + ",'" + @TrnsVrNo + "','" + @TrnsJrRef + "'," + @CompanyID + "," + @WarehouseID + "," + @StoreID + ");";
                        string InsertQuery = "\n" + Qry1 + "\n";
                        InsertDataIntoAutoVault(InsertQuery);

                    }
                    catch { }
                }
            }
        }
        //------------------------------------------------------//
        DateTime getWorkOrderDate(int InvoiceID)
        {
            DateTime InvDate = DateTime.Now;
            try
            {
                string qry = "Select InvDate from TempAB.dbo.invoice  where InvID = " + InvoiceID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if(xResult != DBNull.Value)
                        InvDate = Convert.ToDateTime(xResult);
                }
            }
            catch { }
            return InvDate;
        }
        decimal getSaleTaxRateByID(int CustomerID)
        {
            decimal taxRate = 0;
            try
            {
                string qry = "select PartsRate from SaleTaxRates where ID = (select SaleTaxRateID from Customer where ID = "+ CustomerID +")";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (xResult != DBNull.Value)
                        taxRate = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return taxRate;
        }
        string getVendorPaymentTabsID(int InvoiceID)
        {
            string TabsID = "";
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);
                string qry = "select VendorID from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TabsID = Convert.ToString(xResult);
                }
            }
            catch { }
            return TabsID;
        }
        string getVendorPaymentTermsID(int InvoiceID)
        {
            string TermsID = "";
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName); mera dil tha k abhi jawab d

                string qry = "select TermsID from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    TermsID = Convert.ToString(xResult);
                }
            }
            catch { }
            return TermsID;
        }
        string getVendorPaymentAppliedTo(int InvoiceID)
        {
            string TrnsType = "";
            try
            {
                string qry = "select AppliedTo from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    TrnsType = Convert.ToString(xResult);
                }
            }
            catch { }
            return TrnsType;
        }
        DateTime getVendorPaymentTimeCreated(int InvoiceID)
        {
            DateTime TrnsDate = DateTime.Now;
            try
            {
                string qry = "select TimeCreated from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    TrnsDate = Convert.ToDateTime(xResult);
                }
            }
            catch { }
            return TrnsDate;
        }
        string getVendorPaymentTrnsType(int InvoiceID)
        {
            string TrnsType = "";
            try
            {
                string qry = "select TranType from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    TrnsType = Convert.ToString(xResult);
                }
            }
            catch { }
            return TrnsType;
        }
        string getVendorPaymentTrnsNotes(int InvoiceID)
        {
            string TrnsNotes = "";
            try
            {
                string qry = "select Description from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    //if (Convert.ToString(xResult) > 0)
                    TrnsNotes = Convert.ToString(xResult);
                }
            }
            catch { }
            return TrnsNotes;
        }
        DateTime getVendorPaymentTrnsDate(int InvoiceID)
        {
            DateTime TrnsDate = DateTime.Now;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "select PaidDate from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    //if (Convert.ToDateTime(xResult) > 0)
                    TrnsDate = Convert.ToDateTime(xResult);
                }
            }
            catch { }
            return TrnsDate;
        }
        int getVendorIdForInvoice(int InvoiceID)
        {
            int VendorID = 0;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "select VendorID from TempAB.dbo.vendorinv  where InvoiceID =" + InvoiceID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        VendorID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return VendorID;
        }
        decimal getBillTotalAmount(int POID)
        {
            Decimal TotalQtyOrder = 0;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "select SUM(Cost*PrevInvoiced) from TempAB.dbo.vendorpodet where POID = " + POID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TotalQtyOrder = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return TotalQtyOrder;
        }
        int getPOQty(int POID)
        {
            int TotalQtyOrder = 0;
            try
            {
                string qry = "Select SUM(PrevInvoiced) From TempAB.dbo.vendorpodet Where POID = " + POID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TotalQtyOrder = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return TotalQtyOrder;
        }
        int getTotalQtyOrder(int POID)
        {
            int TotalQtyOrder = 0;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "SELECT sum(PrevReceived) FROM [TempAB].[dbo].[vendorpodet] where POID =" + POID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TotalQtyOrder = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return TotalQtyOrder;
        }        
       decimal getTotalPayVendorBill(int POID)
        {
            decimal TotalAmountOrder = 0;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "SELECT Sum(Applied) FROM TempAB.dbo.[billappliedto] where BillInvoiceID= " + POID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TotalAmountOrder = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return TotalAmountOrder;
        }
        decimal getTotalAmountOrder(int POID)
        {
            decimal TotalAmountOrder = 0;
            try
            {
                //string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "SELECT sum(Cost*PrevReceived) FROM [TempAB].[dbo].[vendorpodet] where POID = " + POID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                        TotalAmountOrder = Convert.ToDecimal(xResult);
                }
            }
            catch { }
            return TotalAmountOrder;
        }
        int getHolidayID(string HolidayName)
        {
            int holidayID = 0;
            try
            {
                string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "SELECT ID FROM Holidays WHERE Name = '" + sHolidayName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        holidayID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return holidayID;
        }
        int getBaseOnID(string BaseOn)
        {
            int BaseOnID = 1;
            try
            {
                string SBaseOn = RemoveSpecialCharacters(BaseOn);

                string qry = "SELECT ID FROM EmployeeComBaseOn WHERE Name = '" + SBaseOn + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        BaseOnID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return BaseOnID;
        }
        int getEmployeeID(string EmployeeName)
        {
            int EmployeeID = 0;
            try
            {
                string sEmployeeName = RemoveSpecialCharacters(EmployeeName);

                string qry = "SELECT ID FROM Employee WHERE Name = '" + sEmployeeName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        EmployeeID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return EmployeeID;
        }
        int getDeptID(string DeptName)
        {
            int DeptID = 0;
            try
            {
                string sDeptName = RemoveSpecialCharacters(DeptName);

                string qry = "SELECT ID FROM WarehouseDepartment WHERE Name = '" + sDeptName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        DeptID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return DeptID;
        }
        int getZipCodeID(string ZipCodeName)
        {
            int ZipCodeID = 0;
            try
            {
                string sZipCodeN = RemoveSpecialCharacters(ZipCodeName);

                string qry = "SELECT Zip FROM ZipCode WHERE city = '" + sZipCodeN + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ZipCodeID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ZipCodeID;
        }
        int getSaleCatID(string SaleCatName)
        {
            int SaleCatID = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(SaleCatName);

                string qry = "SELECT ID FROM SaleTaxCategory WHERE Name like '%" + sSaleCat + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        SaleCatID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return SaleCatID;
        }
        int getSaleTexID(string SaleTexName)
        {
            int SaleTexID = 1;
            try
            {
                string sSaletex = RemoveSpecialCharacters(SaleTexName);

                string qry = "SELECT ID FROM SaleTaxRates WHERE TaxCode like '%" + sSaletex + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        SaleTexID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return SaleTexID;
        }
        int getPriceLevelID(string PriceLevelName)
        {
            int PriceLevelID = 0;
            try
            {
                string sPriceLevelName = RemoveSpecialCharacters(PriceLevelName);

                string qry = "SELECT ID FROM ItemPriceLevel WHERE Name like '%" + sPriceLevelName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        PriceLevelID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return PriceLevelID;
        }
        int getRefByID(string RefByName)
        {
            int RefByID = 0;
            try
            {
                string sRefByName = RemoveSpecialCharacters(RefByName);

                string qry = "SELECT ID FROM ReferredBy WHERE Name like '%" + sRefByName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        RefByID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return RefByID;
        }
        int getPriceLvlID(string pricelevel)
        {
            int PriceLvlID = 0;
            try
            {
                string qry = "SELECT ID FROM ItemPriceLevel WHERE Name like '" + pricelevel + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                    PriceLvlID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return PriceLvlID;
        }
        int getSaleTermID(string SaleTermName)
        {
            int SaleTermID = 0;
            try
            {
                string sSaleTerm = RemoveSpecialCharacters(SaleTermName);

                string qry = "SELECT ID FROM Terms WHERE Name like '%" + sSaleTerm + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        SaleTermID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return SaleTermID;
        }
        string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "'", "''", RegexOptions.Compiled);
        }
        string RemoveStringCharacters(string str)
        {
            return Regex.Replace(str, "P/O #", "", RegexOptions.Compiled);
        }
        int getVendorTermID(string TermName)
        {
            int TermID = 0;
            try
            {
                string sTerm = RemoveSpecialCharacters(TermName);

                string qry = "select ID from Terms where Name = '" + sTerm + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TermID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return TermID;
        }
        int getVendorMID(string MIDName)
        {
            int MIDID = 0;
            try
            {
                string sMIDName = RemoveSpecialCharacters(MIDName);

                string qry = "SELECT * FROM [AutoVault].[dbo].[Vendor] where Name = SELECT top(1) CompanyName FROM [TempAB].[dbo].[vendor] where VendorID = '" + sMIDName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        MIDID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return MIDID;
        }
        int getCustomerID(int CustID)
        {
            int CustomerID = 0;
            try
            {
                string qry = "select ID from AutoVault.dbo.Customer  where FirstName = (select firstname from [TempAB].[dbo].[cust]  where CustID = " + CustID + ")";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        CustomerID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return CustomerID;
        }
        int getCustomerIDByInvID(int CustID)
        {
            int CustomerID = 0;
            try
            {
                string qry = "SELECT CustID FROM [TempAB].[dbo].[invoice] where InvID = " + CustID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        CustomerID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return CustomerID;
        }
        int getModifiedID(string ModifiedName)
        {
            int ModifiedID = 0;
            try
            {
                string sModifiedTerm = RemoveSpecialCharacters(ModifiedName);

                string qry = "SELECT ID FROM Employee WHERE Initial like '%" + sModifiedTerm + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ModifiedID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ModifiedID;
        }
        int getitemtypeID(string ItemtypeName)
        {
            int ItmTypeID = 0;
            try
            {
                string sTypeName = RemoveSpecialCharacters(ItemtypeName);

                string qry = "SELECT ID FROM ItemType WHERE Name = '" + sTypeName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ItmTypeID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItmTypeID;
        }
        int getitemMaxID()
        {
            int ItmID = 0;
            try
            {
                string qry = "SELECT MAX(ID)+1 FROM Item";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    ItmID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItmID;
        }
        int getitemgroupID(string ItemgroupName)
        {
            int ItmGroupID = 0;
            try
            {
                string sItemGroupName = RemoveSpecialCharacters(ItemgroupName);

                string qry = "SELECT ID FROM ItemGroup WHERE Name like '%" + sItemGroupName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ItmGroupID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItmGroupID;
        }
        int getManuID(string ManuName)
        {
            int MenuID = 0;
            try
            {
                string sManuName = RemoveSpecialCharacters(ManuName);

                string qry = "SELECT ID FROM ItemManufacturer WHERE Name like '%" + sManuName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        MenuID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return MenuID;
        }
        int getRepIDID(string RepName)
        {
            int RepID = -2;
            try
            {
                string sRepName = RemoveSpecialCharacters(RepName);

                string qry = "SELECT ID FROM Employee WHERE Initial like '%" + sRepName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        RepID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return RepID;
        }
        void getPOAutoNO(int poAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[PurchaseOrderAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[PurchaseOrderAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + poAutoNo + ",'NewPurchaseOrderAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[PurchaseOrderAutoNo] OFF";
                                
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();                    
                    sqlCon.Close();         
                }
            }
            catch { }            
        }
        void getCustReceiptAutoNO(int CustReceiptAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[CustomerReceiptAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[CustomerReceiptAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + CustReceiptAutoNo + ",'NewCustomerReceiptAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[CustomerReceiptAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                }
            }
            catch { }            
        }
        void getWOAutoNO(int WoAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[WorkOrderAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[WorkOrderAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + WoAutoNo + ",'NewPurchaseOrderAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[WorkOrderAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                }
            }
            catch { }            
        }
        void getVendorPaymentAutoNo(int poAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[VendorPaymentAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[VendorPaymentAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + poAutoNo + ",'NewVendorPaymentAutoNoAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[VendorPaymentAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                }
            }
            catch { }            
        }
        int getBillAutoNO(int poAutoNo)
        {
            int AutoNo = 0;
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[VendorBillAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[VendorBillAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + poAutoNo + ",'NewVendorBillAutoNoAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[VendorBillAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    AutoNo = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return AutoNo;
        }
        int getitemID(string ItemName)
        {
            int ItmID = 0;
            try
            {
                string sItemName = RemoveSpecialCharacters(ItemName);

                string qry = "SELECT ID FROM Item WHERE Catalog ='" + sItemName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ItmID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItmID;
        }
        int getitemIDForWordOrderDetail(string ItemName)
        {
            int ItmID = 0;
            try
            {
                string sItemName = RemoveSpecialCharacters(ItemName);

                string qry = "Select  TOP(1) * from Item Where [Catalog] like '%" + sItemName + "%'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ItmID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItmID;
        }
        int getPOID(string DescriptionName)
        {
            int POID = 0;
            try
            {
                string sDescription = RemoveStringCharacters(DescriptionName);

                POID = Convert.ToInt32(sDescription.Trim());
            }
            catch { }
            return POID;
        }
        int getWorkNegateID(int WorkId)
        {
            int WoId = 0;
            try
            {
                string qry = "SELECT ID FROM WorkOrderNegate WHERE ID =" + WorkId;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        WoId = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return WoId;
        }
        DateTime getCustomerReceiptTrnsDate(int InvID)
        {
            DateTime TrnsDate = DateTime.Now;
            try
            {
                string qry = "select InvDate from TempAB.dbo.Invoice  where Invid =" + InvID;
                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    TrnsDate = Convert.ToDateTime(xResult);
                }
            }
            catch { }
            return TrnsDate;
        }
        string getCustReciptPaidby(int InvID)
        {
            string[] paidbysplit;
            string PaidBy = "";
            try
            {
                string qry = "select PaidBy from TempAB.dbo.invoice  where InvID =" + InvID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    PaidBy = Convert.ToString(xResult);

                }
            }
            catch { }
            return PaidBy;
        }

        int getWorkNegateId(int InvID)
        {
            int worknegateid =0 ;
            try
            {
                string qry = "Select WorkOrderNo from WorkOrder where Notes ='" + InvID +"'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    worknegateid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return worknegateid;
        }



        int getcreaditCName(string SName)
        {
            int CCID = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(SName);

                string qry = "SELECT ID FROM CreditCards WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        CCID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return CCID;
        }
        int getAccountIdByName(string SName)
        {
            int AccountID = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(SName);

                string qry = "SELECT ID FROM Account WHERE AccName = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        AccountID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return AccountID;
        }
        int getHolidaysIdByName(string SName)
        {
            int HolidayID = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(SName);

                string qry = "SELECT ID FROM Holidays WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        HolidayID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return HolidayID;
        }
        int getItemgroupTypeidbyname(string GroupName)
        {
            int itmtypeid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM ItemGroupType WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        itmtypeid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return itmtypeid;
        }
        int getItemTypeidbyname(string GroupName)
        {
            int itmtypeid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM ItemType WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        itmtypeid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return itmtypeid;
        }
        int getRefByidbyname(string GroupName)
        {
            int RefByid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM ReferredBy WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        RefByid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return RefByid;
        }
        int getBasebyname(string BaseOnname)
        {
            int BaseOn = 0;
            try
            {
                string sBaseOn = RemoveSpecialCharacters(BaseOnname);

                string qry = "SELECT ID FROM EmployeeComBaseOn WHERE Name = '" + sBaseOn + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        BaseOn = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return BaseOn;
        }
        int getTermsidbyname(string GroupName)
        {
            int Termsid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM Terms WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        Termsid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return Termsid;
        }
        int getBankAccountidbyname(string GroupName)
        {
            int bankid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM BankAccounts WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        bankid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return bankid;
        }
        int getItemGroupidbyname(string GroupName)
        {
            int ItemGroupid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM ItemGroup WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        ItemGroupid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return ItemGroupid;
        }
        int getItemManufactureidbyname(string GroupName)
        {
            int Brandid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM ItemManufacturer WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        Brandid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return Brandid;
        }
        int getLaborDeptmentidbyname(string GroupName)
        {
            int LaborDeptdid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM LaborDepartment WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        LaborDeptdid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return LaborDeptdid;
        }
        int getTireSizeidbyname(string GroupName)
        {
            int TireSizeid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM TireSize WHERE TSize = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        TireSizeid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return TireSizeid;
        }
        string getCustPaymentby(int InvID)
        {
            string[] paidbysplit;
            string PaidBy = "";
            try
            {
                string qry = "select PaidBy from TempAB.dbo.invoice  where InvID =" + InvID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    PaidBy = Convert.ToString(xResult);

                }
            }
            catch { }
            return PaidBy;
        }
        int getFeeidbyname(string feename)
        {
            int feeid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(feename);

                string qry = "SELECT ID FROM Fees WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        feeid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return feeid;
        }
        int getlaboridbyname(string laborname)
        {
            int laborid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(laborname);

                string qry = "SELECT ID FROM Labor WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        laborid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return laborid;
        }
        int getHolidaydateID(string HolidayName)
        {
            int holidayID = 0;
            try
            {
                string sHolidayName = RemoveSpecialCharacters(HolidayName);

                string qry = "SELECT HolidayDate FROM Holidays WHERE Name = '" + sHolidayName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        holidayID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return holidayID;
        }
        int getSalecatidbyname(string GroupName)
        {
            int Termsid = 0;
            try
            {
                string sSaleCat = RemoveSpecialCharacters(GroupName);

                string qry = "SELECT ID FROM SaleTaxCategory WHERE Name = '" + sSaleCat + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        Termsid = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return Termsid;
        }
        int getWoID(string Invnum)
        {
            int WoID = 0;
            try
            {
                string qry = "SELECT ID FROM [AutoVault].[dbo].[WorkOrder] WHERE [Notes] ='" + Invnum + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        WoID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return WoID;
        }
        int getWONID(int InvID)
        {
            int WONID = 0;
            try
            {
                string qry = "SELECT ID FROM [AutoVault].[dbo].[WorkOrderNegate] WHERE [ID] = " + InvID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToInt32(xResult) > 0)
                        WONID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return WONID;
        }
        int getCustID(int WorkID)
        {
            int WoID = 0;
            try
            {
                string qry = "SELECT CustID FROM TempAB.dbo.invoice WHERE InvID =" + WorkID;

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        WoID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return WoID;
        }
        void getWONegateAutoNO(int WONegateAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[WorkOrderNegateAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[WorkOrderNegateAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + WONegateAutoNo + ",'NewWorkOrderNegateAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[WorkOrderNegateAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                }
            }
            catch { }            
        }
        void getcustPaymentAutoNO(int WONegateAutoNo)
        {            
            try
            {
                string Qry = "SET IDENTITY_INSERT [dbo].[CustomerPaymentAutoNo] ON";
                Qry += "\n INSERT INTO [AutoVault].[dbo].[CustomerPaymentAutoNo] ([ID],[Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES (" + WONegateAutoNo + ",'NewCustomerPaymentAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
                Qry += "\n SET IDENTITY_INSERT [dbo].[CustomerPaymentAutoNo] OFF";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(Qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();                    
                }
            }
            catch { }            
        }
        int getCustIDContact(int CustID1)
        {
            int CustID = 0;
            try
            {


                string qry = "Select CustID from TempAb.dbo.Cust where CustID=" + CustID1 + "";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    if (Convert.ToDecimal(xResult) > 0)
                        CustID = Convert.ToInt32(xResult);
                }
            }
            catch { }
            return CustID;
        }
        string getCtypeID(string CtypeName)
        {
            string RepID = "";
            try
            {
                string sRepName = RemoveSpecialCharacters(CtypeName);

                string qry = "SELECT Initial FROM ItemType WHERE Name ='" + sRepName + "'";

                using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                    object xResult = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                    RepID = Convert.ToString(xResult);
                }
            }
            catch { }
            return RepID;
        }

        //int getCustReceiptAutoNo(int InvID)
        //{
        //    int AutoNo = 0;
        //    try
        //    {
        //        string qry = "INSERT INTO [AutoVault].[dbo].[CustomerReceiptAutoNo] ([Name] ,[Active] ,[AddDate] ,[AddUserID] ,[IsLocked] ) VALUES ('NewCustomerReceiptAutoNo' ,1 ,GETDATE() ,-2 ,0 )";
        //        string qry2 = "SELECT Top(1) SCOPE_IDENTITY() from [AutoVault].[dbo].[CustomerReceiptAutoNo]";

        //        using (SqlConnection sqlCon = new SqlConnection(SqlConnectionString))
        //        {
        //            sqlCon.Open();
        //            SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
        //            object xResult = sqlCmd.ExecuteScalar();
        //            SqlCommand sqlCmd2 = new SqlCommand(qry2, sqlCon);
        //            object xResult2 = sqlCmd2.ExecuteScalar();
        //            sqlCon.Close();
        //            AutoNo = Convert.ToInt32(xResult2);
        //        }
        //    }
        //    catch { }
        //    return AutoNo;
        //}

        //------------------------------------------------------//

    }
    //SELECT * FROM TempAB.dbo.vendorinv WHERE NOT Date1='';
    public sealed class Helper
    {
        public Helper()
        {
        }
        public string GetConnectionString()
        {
            return Properties.Settings.Default.AutoBizConnectionString;
        }
    }

}
