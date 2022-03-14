using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data;
using QBSync.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using QBSync.QuickBooks;
using System.Text.RegularExpressions;
using System.Configuration;

namespace QBSync
{
    public static class Common
    {        
        public static string ApplicationName = "QBSync Synchronization Utility";
        public static string QuickBookVersion = "13.0";
        public static string XMLEncoding = "iso-8859-1";
        public static string SubVersion = " Ver-1.0";
        public static string MaxRecordReturn = "500";
        public static Data.dsQBSync.SettingsRow Settings;
        public static bool UseQBQueryToDate = false;
        public static int BranchID = 0;
        //public static Data.dsQBSyncSQL.QBSettingsRow Settings;
        //public static Data.dsQBSync.MySQLConnectionsRow MySQLConnection;
        //public static string ConnectionString = "";
        //public static string DataBaseFile = "";
        //public static Int32 iDatabaseType = 1;
        //public static string LogFileName = "";
        //public static QBPreferences Prefrences;
        //public static DataTable QBAccounts;
        //public static DataTable QBTaxCodes;       
        //public static List<MdlVendor> QBVendors;

        public static void ExceptionHandler(Exception ex)
        {
            ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            MessageBox.Show(ex.Message, Common.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool IsNumeric(char pch, string strControlText, bool scale)
        {
            Int16 Ascii;
            try
            {
                Ascii = Convert.ToInt16(pch);

                if (scale == true)
                {
                    if (Ascii >= 48 && Ascii <= 57 || Ascii == 46 || Ascii == 13 || Ascii == 8 || Ascii == 45)
                    {
                        if (strControlText.IndexOf(".") > 0 && Ascii == 46)
                            return true;
                        else if (strControlText.Contains("-") && Ascii == 45)
                            return true;
                        else
                            return false;
                    }
                    else return true;
                }
                else
                    if (Ascii >= 48 && Ascii <= 57 || Ascii == 13 || Ascii == 8)
                        return false;
                    else
                        return true;
            }
            catch (Exception ex)
            {
                //General.ErrorLog(ex, "IsNumeric");
            }
            return false;
        }

        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        public static void ApplicationLog(String LogMessage, String StackTrace, String LogType)
        {
            try
            {
                Data.dsQBSync ds = new dsQBSync();
                Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter taAppLog = new QBSync.Data.dsQBSyncTableAdapters.ApplicationLogTableAdapter();

                var oRow = ds.ApplicationLog.NewApplicationLogRow() as Data.dsQBSync.ApplicationLogRow;

                oRow.OnDateTime = System.DateTime.Now;
                oRow.Message = LogMessage;
                oRow.StackTrace = StackTrace;
                oRow.LogType = LogType;
                ds.ApplicationLog.AddApplicationLogRow(oRow);
                taAppLog.Update(oRow);

            }
            catch (Exception)
            {
                ;
            }
        }
        public static void GradientNavBar(Control sender, PaintEventArgs e)
        {
            if (sender.Height == 0 && sender.Width == 0) return;

            //get the graphics object of the control 
            Graphics g = e.Graphics;

            //The drawing gradient brush 
            LinearGradientBrush brush = new LinearGradientBrush(sender.ClientRectangle, Color.FromArgb(224, 237, 243), Color.FromArgb(163, 199, 218), LinearGradientMode.Vertical);

            //Fill the client area with the gradient brush using the control's graphics object 
            g.FillRectangle(brush, sender.ClientRectangle);
        }
        public static void FormBackground(Form pfrm)
        {
            pfrm.BackColor = Color.FromArgb(217, 232, 240);
        }

        public static string GetPaymentMethod(int payment_method)
        {
            string strResult = "";
            switch (payment_method)
            {
                case 1:
                    strResult = "CASH";
                    break;
                case 2:
                    strResult = "CHECK";
                    break;
                case 3:
                    strResult = "VISA";
                    break;
                case 4:
                    strResult = "PayPal";
                    break;
                default:
                    strResult = "";
                    break;
            }
            return strResult;
        }

        //public static string GetAccountType(string accountHead)
        //{
        //    string strResult = "";
        //    switch (accountHead)
        //    {
        //        case "Income":
        //            strResult = "Income";
        //            break;
        //        case "Other Current Assets":
        //            strResult = "OtherCurrentAsset";
        //            break;
        //        case "Bank":
        //            strResult = "Bank";
        //            break;
        //        case "Equities":
        //            strResult = "Equity";
        //            break;
        //        default:
        //            strResult = "OtherIncome";
        //            break;
        //    }
        //    return strResult;
        //}
        public static string GetAccountType(string accountSubType, string accountType, string accountHead)
        {
            string strResult = "";

            if (accountHead.Replace(" ", "").ToUpper().StartsWith("ASSET") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("CURRENTASSET") &&
                accountSubType.Replace(" ", "").ToUpper().StartsWith("CHECKINGACCOUNT"))
            {
                strResult = "Bank";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("ASSET") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("CURRENTASSET") &&
                !accountSubType.Replace(" ", "").ToUpper().StartsWith("CHECKINGACCOUNT"))
            {
                strResult = "OtherAsset";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("ASSET") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("OTHERCURRENTASSET"))
            {
                strResult = "OtherCurrentAsset";
            }
            //else if (accountHead.Replace(" ", "").ToUpper().Contains("ASSET") &&
            //    accountType.Replace(" ", "").ToUpper().Contains("CURRENTASSETS"))
            //{
            //    strResult = "OtherAsset";
            //}
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("ASSET") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("FIXEDASSET"))
            {
                strResult = "FixedAsset";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("INCOME") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("OTHERINCOME"))
            {
                strResult = "OtherIncome";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("INCOME"))
            {
                strResult = "Income";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("EXPENSE") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("OTHEREXPENSE"))
            {
                strResult = "OtherExpense";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("EXPENSE"))
            {
                strResult = "Expense";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("LIABILIT") &&
                accountSubType.Replace(" ", "").ToUpper().StartsWith("ACCOUNTSPAYABLE"))
            {
                strResult = "AccountsPayable";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("LIABILIT") &&
                accountSubType.Replace(" ", "").ToUpper().StartsWith("OTHERCURRENTLIABILIT"))
            {
                strResult = "OtherCurrentLiability";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("LIABILIT") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("LONGTERMLIABILIT"))
            {
                strResult = "LongTermLiability";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("LIABILIT") &&
                accountType.Replace(" ", "").ToUpper().StartsWith("OTHERCURRENTLIABILIT"))
            {
                strResult = "OtherCurrentLiability";
            }
            else if (accountHead.Replace(" ", "").ToUpper().StartsWith("EQUIT"))
            {
                strResult = "Equity";
            }
            return strResult;
        }


        public static string GetAccountHead(string accountType)
        {
            string strResult = "";

            if (accountType == "FixedAsset" || accountType == "OtherAsset" || accountType == "OtherCurrentAsset" || accountType == "Bank" || accountType == "AccountsReceivable")
            {
                strResult = "Assets";
            }
            else if (accountType == "Income" || accountType == "OtherIncome")
            {
                strResult = "Income";
            }
            else if (accountType == "Expense" || accountType == "OtherExpense" || accountType == "CostOfGoodsSold")
            {
                strResult = "Expense";
            }
            else if (accountType == "CreditCard" || accountType == "AccountsPayable" || accountType == "LongTermLiability" || accountType == "OtherCurrentLiability")
            {
                strResult = "Liabilities";
            }
            else if (accountType == "Equity")
            {
                strResult = "Equities";
            }
            else if (accountType == "Equity")
            {
                strResult = "Equities";
            }
            else
            {
                strResult = "Others";
            }

            return strResult;
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool isValidName(string input)
        {
            string strRegex = @"^[a-zA-Z0-9\s\&\.]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isValidAddress(string input)
        {
            string strRegex = @"^[a-zA-Z0-9\s\&\.\,\#\(\)\-]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isValidCity(string input)
        {
            string strRegex = @"^[a-zA-Z\.\,\-]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isValidZipCode(string input)
        {
            string strRegex = @"^[a-zA-Z0-9\.\,\(\)\-\/\:]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isValidStateCountry(string input)
        {
            string strRegex = @"^[A-Za-z0-9]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isValidPhone(string input)
        {
            string strRegex = @"^[0-9\-\(\)]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }
    }

}
