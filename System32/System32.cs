using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Net.NetworkInformation;
using System.Data;

namespace System32
{
    public static class StaticInfo
    {
        public enum YesNo { No, Yes };
        public enum Mask { None, DateOnly, PhoneWithArea, MobileNo, MaskMobileNoCC, PhoneNo, IpAddress, SSN, Decimal, Digit, eMail, CNIC };
        public enum gColumnType { TextBoxColumn, CheckBoxColumn, ComboBoxColumn, DecimalColumn, NumberColumn, TimeColumn, DateColumn, PrintColumn, DelColumn, LoadCtrColumn, OpenColorDialog, SaveColumn, AutoNoColumn }

        public static bool SystemLock = false;
        public static bool userActive = false;
        public static int userid = 0;
        public static int userGroupID = 0;
        public static string userName = string.Empty;
        public static string EmployeeName = string.Empty;
        public static int POSID = 0;
        public static int CompanyID = 0;
        public static int WarehouseID = 0;
        public static int StoreID = 0;
        public static bool CanApplicationExit = true;
        public static bool IsLoginForWarehouse = false;
        public static bool IsLoginForStore = false;
        public static int LoginWarehouseID = 0;
        public static int LoginStoreID = 0;
        public static int SaleTaxCategoryID = 0;
        public static decimal SaleTaxPartsRate = 0;
        public static string CompanyCode = string.Empty; 
        public static string CompanyName = string.Empty; 
        public static string CompanyType = string.Empty; 
        public static string CompanyAddress = string.Empty;
        public static string CompanyPhone = string.Empty;
        public static int CoFinYearStrMonth = 0;
        public static int CoFinEndYear = 0;
        public static int UserLoginDetailID = 0;
        public static List<SearchData> SearchList = new List<SearchData>();
        public static DateTime UserLoginEndTime; 

        public static int BrID = 0;
        public static string BranchName = string.Empty;
        public static string WarehouseName = string.Empty;
        public static int userLevel = 0;

        public static string MainCurrencySign = string.Empty;
        public static string SecCurrencySign = string.Empty;
        public static string MainCurrencyCulture = string.Empty;
        public static string SecCurrencyCulture = string.Empty;
        public static string MainCurSign = string.Empty;
        public static string SecCurSign = string.Empty;
        public static string MainCurName = string.Empty;
        public static string SecCurName = string.Empty;
        public static int MainCSign = 0;
        public static int SecCSign = 0;

        public static Color ctrBackColor;
        public static Color ctrLabelForeColor;
        public static DataTable UserRights = new DataTable();
                

        //public static Color ctrBackColor = System.Drawing.Color.LightSteelBlue;
        //public static Color ctrLabelForeColor = System.Drawing.Color.Black;

        //public static Color ctrBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
        //public static Color ctrLabelForeColor = System.Drawing.Color.White;

        //public static Color ctrBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123)))));
        //public static Color ctrLabelForeColor = System.Drawing.Color.White;

        //public static Color ctrBackColor = System.Drawing.Color.Black;
        //public static Color ctrLabelForeColor = System.Drawing.Color.White;

        public delegate void LoadChildInterface(string MAssemblyName, string ChildName, string TableName);
        public static event LoadChildInterface LoadChildControl;

        public delegate void LoadControlInterface(string MAssemblyName, string ctrName, int id, int qid = 0);
        public static event LoadControlInterface LoadControl;

        public delegate void LoadControlInterface2(string MAssemblyName, string ctrName, string date, int id, int qid = 0);
        public static event LoadControlInterface2 LoadControl2;

        public delegate void LoadControlInterface3(string MAssemblyName, string ctrName, DataTable dt, int id, int qid = 0);
        public static event LoadControlInterface3 LoadControl3;

        public delegate void LoadReportInterface(string MAssemblyName, string ReportName, string status, int id = 0);
        public static event LoadReportInterface LoadRptReport;

        //public delegate void LoadReportInterface2(string MAssemblyName, string ReportName,string status, int id = 0);
        //public static event LoadReportInterface2 LoadRptReport2;

        //public delegate void LoadReportInterface(string tblName, string MAssemblyName, string ReportName, string status, int id = 0);
        //public static event LoadReportInterface LoadRptReport;

        public delegate void CalculateTotalInterface(decimal amount = 0);
        public static event CalculateTotalInterface CalculateTotalAmount;

        public static void LoadToChild(string MAssemblyName, string ChildName, string TableName)
        {
            LoadChildControl(MAssemblyName, ChildName, TableName);
        }
        public static void LoadToControl(string MAssemblyName, string ctrName, int id, int qid = 0)
        {
            LoadControl(MAssemblyName, ctrName, id, qid);
        }
        public static void LoadToControl2(string MAssemblyName, string ctrName, string date, int id, int qid = 0)
        {
            LoadControl2(MAssemblyName, ctrName, date,id, qid);
        }
        public static void LoadToControl3(string MAssemblyName, string ctrName, DataTable dt, int id, int qid = 0)
        {
            LoadControl3(MAssemblyName, ctrName,dt, id, qid);
        }
        public static void LoadToReport(string MAssemblyName, string ReportName, string status, int id = 0)
        {
            LoadRptReport(MAssemblyName, ReportName, status, id);
        }
        public static void LoadToPDFReport(string MAssemblyName, string ReportName, string status, int id = 0)
        {
            LoadToPDFReport(MAssemblyName, ReportName, status, id);
        }
        //public static void LoadReport2(string MAssemblyName, string ReportName, string status, int id = 0)
        //{
        //    LoadRptReport2(MAssemblyName, ReportName, status, id);
        //}
        public static void CalculateTotal(decimal amount = 0)
        {
            try { CalculateTotalAmount(amount); }
            catch { }
        }
        public static decimal StrToDec(string text)
        {
            try
            {
                if (text.StartsWith("$.")) { text = text.Replace("$.", ""); }
                Char[] strarr = text.ToCharArray().Where(c => Char.IsDigit(c) || Char.IsPunctuation(c)).ToArray();
                return Convert.ToDecimal(new string(strarr));
            }
            catch { return Convert.ToDecimal("0"); }
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
    public static class EncryptDecrypt
    {
        public static string Encrypt(string textToEncrypt)
        {
            var algorithm = GetAlgorithm();
            byte[] encryptedBytes;
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
                encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static bool IsTextEncrypted(string encryptedText)
        {
            try
            {
                var algorithm = GetAlgorithm();
                byte[] descryptedBytes;
                using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
                }
                return true;
            }
            catch { return false; }
        }
        public static string Decrypt(string encryptedText)
        {
            try
            {
                var algorithm = GetAlgorithm();
                byte[] descryptedBytes;
                using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
                }
                return Encoding.UTF8.GetString(descryptedBytes);
            }
            catch { return null; }
        }
        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }
            return memory.ToArray();
        }
        private static RijndaelManaged GetAlgorithm()
        {            
            byte[] salt = Encoding.ASCII.GetBytes("#@&3r your )$@ S@!& v@!u3 h#r3");
            // Create an encryption key from the encryptionPassword and salt.
            var key = new Rfc2898DeriveBytes("#@^ry6&!8@", salt);

            // Declare that we are going to use the Rijndael algorithm with the key that we've just got.    
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);

            return algorithm;
        }
    }
    public class SearchData
    {
        public string sKey { get; set; }
        public string sValue { get; set; }
        public SearchData(string ikey, string ivalue)
        {
            sKey = ikey;
            sValue = ivalue;
        }        
    }
    public static class SystemRegistration
    {
        public static string cryptString = string.Empty;
        public static string ExpiryDate = string.Empty;
        public static string currentDate = string.Empty;
        public static string AddDate = string.Empty;
        public static void systemRegistration()
        {
            try
            {
                //------------------------------
                string sProcessorID = string.Empty;
                string sProcID = "";

                sProcessorID = GetDefaultMacAddress();

                string MACID = GetMACAddress();
                string MACID1 = GetProcessorID();
                string MACID2 = GetSerialID();

                if (!string.IsNullOrEmpty(MACID1) && !string.IsNullOrEmpty(MACID2))
                {
                    sProcID = "ESS/" + MACID1 + "/USA/" + MACID2;
                                        
                    cryptString = EncryptDecrypt.Encrypt(sProcID);
                    ExpiryDate = EncryptDecrypt.Encrypt("2022/10/10");
                    currentDate = EncryptDecrypt.Encrypt(Convert.ToString(DateTime.Now));
                    //------------------------------------------------                    
                    //AddDate = Convert.ToString(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day);
                    AddDate = Convert.ToString(DateTime.Now.Year + "/" + DateTime.Now.Month+ "/" + DateTime.Now.Day);
                }
            }
            catch { }
        }
        static string getProcessorID1()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();

            foreach (ManagementObject oManagementObject in oCollection)
            { sProcessorID = (string)oManagementObject["ProcessorId"]; }
            return sProcessorID;
        }
        static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }
        static string GetProcessorID()
        {           
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }
        static string GetDefaultMacAddress()
        {
            Dictionary<string, long> macAddresses = new Dictionary<string, long>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                    macAddresses[nic.GetPhysicalAddress().ToString()] = nic.GetIPStatistics().BytesSent + nic.GetIPStatistics().BytesReceived;
            }
            long maxValue = 0;
            string mac = "";
            foreach (KeyValuePair<string, long> pair in macAddresses)
            {
                if (pair.Value > maxValue)
                {
                    mac = pair.Key;
                    maxValue = pair.Value;
                }
            }
            return mac;
        }
        static string GetSerialID()
        {
            string motherBoard = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            
            foreach (ManagementObject mo in moc)
            {
                motherBoard = (string)mo["SerialNumber"];
            }

            return motherBoard;
        }
    
    }
}
