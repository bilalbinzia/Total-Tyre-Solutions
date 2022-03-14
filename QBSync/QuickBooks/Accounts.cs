using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Windows.Forms;

namespace QBSync.QuickBooks
{
    public class Accounts
    {

        public DataTable GetAccounts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("ListID", typeof(string));
            dt.Columns.Add("AccountType", typeof(string));

            try
            {
                XmlDocument inputXMLDoc = new XmlDocument();
                inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
                inputXMLDoc.AppendChild(qbXML);
                XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
                XmlElement AccountQueryRq = inputXMLDoc.CreateElement("AccountQueryRq");
                qbXMLMsgsRq.AppendChild(AccountQueryRq);
                AccountQueryRq.SetAttribute("requestID", "1");

                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "Bank"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "CreditCard"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "CostOfGoodsSold"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "OtherAsset"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "FixedAsset"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "OtherCurrentAsset"));
                AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "FullName"));
                AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "AccountType"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList AccountQueryRsList = responseXmlDoc.GetElementsByTagName("AccountQueryRs");
                if (AccountQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = AccountQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query
                        for (int i = 0; i < AccountRetList.Count; i++)
                        {
                            XmlNode AccountRet = AccountRetList.Item(i);
                            if (AccountRet != null)
                            {
                                //Get value of ListID
                                string ListID = AccountRet.SelectSingleNode("./ListID").InnerText;
                                //Get value of FullName
                                string FullName = AccountRet.SelectSingleNode("./FullName").InnerText;
                                string AccountType = AccountRet.SelectSingleNode("./AccountType").InnerText;

                                DataRow objDR = dt.NewRow();
                                objDR["ListID"] = ListID;
                                objDR["FullName"] = FullName;
                                objDR["AccountType"] = AccountType;
                                //if (AccountType == "Income" || AccountType == "OtherIncome")
                                //{
                                //    objDR["AccountType"] = "Income";
                                //}
                                //else if (AccountType == "CostOfGoodsSold" || AccountType == "")
                                //{
                                //    objDR["AccountType"] = "COGS";
                                //}
                                //else if (AccountType == "OtherAsset" || AccountType == "FixedAsset" || AccountType == "OtherCurrentAsset")
                                //{
                                //    objDR["AccountType"] = "Asset";
                                //}
                                dt.Rows.Add(objDR);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        public DataTable GetAccountsForCombos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("ListID", typeof(string));
            dt.Columns.Add("AccountType", typeof(string));

            try
            {
                XmlDocument inputXMLDoc = new XmlDocument();
                inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
                inputXMLDoc.AppendChild(qbXML);
                XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
                XmlElement AccountQueryRq = inputXMLDoc.CreateElement("AccountQueryRq");
                qbXMLMsgsRq.AppendChild(AccountQueryRq);
                AccountQueryRq.SetAttribute("requestID", "1");

                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "Income"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "OtherIncome"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "CostOfGoodsSold"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "OtherAsset"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "FixedAsset"));
                //AccountQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "AccountType", "OtherCurrentAsset"));


                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList AccountQueryRsList = responseXmlDoc.GetElementsByTagName("AccountQueryRs");
                if (AccountQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = AccountQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query
                        for (int i = 0; i < AccountRetList.Count; i++)
                        {
                            XmlNode AccountRet = AccountRetList.Item(i);
                            if (AccountRet != null)
                            {
                                //Get value of ListID
                                string ListID = AccountRet.SelectSingleNode("./ListID").InnerText;
                                //Get value of FullName
                                string FullName = AccountRet.SelectSingleNode("./FullName").InnerText;
                                string AccountType = AccountRet.SelectSingleNode("./AccountType").InnerText;

                                DataRow objDR = dt.NewRow();
                                objDR["ListID"] = ListID;
                                objDR["FullName"] = FullName;
                                if (AccountType == "Income" || AccountType == "OtherIncome")
                                {
                                    objDR["AccountType"] = "Income";
                                }
                                else if (AccountType == "CostOfGoodsSold" || AccountType == "")
                                {
                                    objDR["AccountType"] = "COGS";
                                }
                                else if (AccountType == "OtherAsset" || AccountType == "FixedAsset" || AccountType == "OtherCurrentAsset")
                                {
                                    objDR["AccountType"] = "Asset";
                                }
                                dt.Rows.Add(objDR);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        public Boolean AddAccount(String pAccountName, String pParentAccount, String pAccountType)
        {
            Boolean blnResult = false;
            try
            {
                //string[] words = pItemName.Trim().Split(':');
                //if (words.Count() > 0)
                //    pItemName = words[0];

                String AccountName = Common.Truncate(pAccountName, 31);

                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(parent);
                parent.SetAttribute("onError", "stopOnError");
                XmlElement AccountAddRq = doc.CreateElement("AccountAddRq");
                parent.AppendChild(AccountAddRq);
                XmlElement AccountAdd = doc.CreateElement("AccountAdd");
                AccountAddRq.AppendChild(AccountAdd);

                AccountAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(AccountName, 31)));
                AccountAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));

                if (!String.IsNullOrEmpty(pParentAccount))
                {
                    XmlElement ParentRef = doc.CreateElement("ParentRef");
                    AccountAdd.AppendChild(ParentRef);
                    ParentRef.AppendChild(MakeSimpleElem(doc, "FullName", pParentAccount));
                }
                //Set field value for AccountType <!-- required -->
                AccountAdd.AppendChild(MakeSimpleElem(doc, "AccountType", pAccountType));


                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList AccountAddRsList = responseXmlDoc.GetElementsByTagName("AccountAddRs");
                if (AccountAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = AccountAddRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + AccountName + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        if (statusCode == "3140")
                        {
                            if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
                            {

                            }
                        }
                        if (statusCode == "3130")
                        {
                            if (statusMessage.Contains("There is an invalid reference to a parent"))
                            {
                                string[] stringSeparators = new string[] { "\"" };
                                string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                if (result.Count() > 1)
                                {
                                    String ProductName = result[1];

                                    string account = pParentAccount;
                                    string[] words = pParentAccount.Split(':');
                                    if (words.Count() > 1)
                                        account = words[words.Length - 1];

                                    string parent_account = "";
                                    for (int i = 0; i < words.Length - 1; i++)
                                    {
                                        if (string.IsNullOrEmpty(parent_account))
                                            parent_account = words[i];
                                        else
                                            parent_account = parent_account + ":" + words[i];
                                    }


                                    Accounts objAccount = new Accounts();
                                    if (objAccount.AddAccount(account, parent_account, pAccountType))
                                        blnResult = AddAccount(pAccountName, pParentAccount, pAccountType);
                                }
                            }
                        }
                        else if (Convert.ToInt32(statusCode) == 3100)
                        {
                            blnResult = false;
                        }
                        else
                        {
                            XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query
                            for (int i = 0; i < AccountRetList.Count; i++)
                            {
                                XmlNode AccountRet = AccountRetList.Item(i);

                                String ListID = AccountRet.SelectSingleNode("./ListID").InnerText;

                                blnResult = true;
                            }
                        }
                    }
                }
                return blnResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean AddAccount(String pAccountName, String pParentAccount, String pAccountType, System.ComponentModel.BackgroundWorker bgWorker)
        {
            Boolean blnResult = false;
            try
            {
                //string[] words = pItemName.Trim().Split(':');
                //if (words.Count() > 0)
                //    pItemName = words[0];

                String AccountName = Common.Truncate(pAccountName, 31);

                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(parent);
                parent.SetAttribute("onError", "stopOnError");
                XmlElement AccountAddRq = doc.CreateElement("AccountAddRq");
                parent.AppendChild(AccountAddRq);
                XmlElement AccountAdd = doc.CreateElement("AccountAdd");
                AccountAddRq.AppendChild(AccountAdd);

                AccountAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(AccountName, 31)));
                AccountAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));

                if (!String.IsNullOrEmpty(pParentAccount))
                {
                    XmlElement ParentRef = doc.CreateElement("ParentRef");
                    AccountAdd.AppendChild(ParentRef);
                    ParentRef.AppendChild(MakeSimpleElem(doc, "FullName", pParentAccount));
                }
                //Set field value for AccountType <!-- required -->
                AccountAdd.AppendChild(MakeSimpleElem(doc, "AccountType", pAccountType));


                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList AccountAddRsList = responseXmlDoc.GetElementsByTagName("AccountAddRs");
                if (AccountAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = AccountAddRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + AccountName + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        if (statusCode == "3140")
                        {

                        }
                        if (statusCode == "3130")
                        {
                            if (statusMessage.Contains("There is an invalid reference to a parent"))
                            {
                                string[] stringSeparators = new string[] { "\"" };
                                string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                if (result.Count() > 1)
                                {
                                    String ProductName = result[1];

                                    string account = pParentAccount;
                                    string[] words = pParentAccount.Split(':');
                                    if (words.Count() > 1)
                                        account = words[words.Length - 1];

                                    string parent_account = "";
                                    for (int i = 0; i < words.Length - 1; i++)
                                    {
                                        if (string.IsNullOrEmpty(parent_account))
                                            parent_account = words[i];
                                        else
                                            parent_account = parent_account + ":" + words[i];
                                    }


                                    Accounts objAccount = new Accounts();
                                    if (objAccount.AddAccount(account, parent_account, pAccountType, bgWorker))
                                        blnResult = AddAccount(pAccountName, pParentAccount, pAccountType, bgWorker);
                                }
                            }
                        }
                        else if (Convert.ToInt32(statusCode) == 3100)
                        {
                            blnResult = false;
                        }
                        else if (Convert.ToInt32(statusCode) == 0)
                        {
                            XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query
                            for (int i = 0; i < AccountRetList.Count; i++)
                            {
                                XmlNode AccountRet = AccountRetList.Item(i);

                                String ListID = AccountRet.SelectSingleNode("./ListID").InnerText;
                                String Name = AccountRet.SelectSingleNode("./Name").InnerText;

                                bgWorker.ReportProgress(0, "'" + Name + "' account added in QuickBooks");

                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! Adding in Account");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Adding in Account");
                bgWorker.ReportProgress(0, ex.Message);
            }

            return blnResult;
        }

        public void AccountQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "stopOnError");

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement AccountQueryRq = doc.CreateElement("AccountQueryRq");
                qbXMLMsgsRq.AppendChild(AccountQueryRq);
                //custRq.SetAttribute("requestID", "1");
                AccountQueryRq.AppendChild(MakeSimpleElem(doc, "ActiveStatus", "All"));
                AccountQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                if (Common.UseQBQueryToDate)
                    AccountQueryRq.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));


                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList AccountQueryRsList = responseXmlDoc.GetElementsByTagName("AccountQueryRs");
                if (AccountQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = AccountQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) == 0)
                    {
                        XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query

                        QBLinxWebService service = new QBLinxWebService();
                        for (int i = 0; i < AccountRetList.Count; i++)
                        {
                            XmlNode AccountRet = AccountRetList.Item(i);

                            string QBListID = AccountRet.SelectSingleNode("./ListID").InnerText;
                            string AccountType = AccountRet.SelectSingleNode("./AccountType").InnerText;

                            if (AccountType == "NonPosting") continue;

                            var oAccount = new QBLinxDataService.MdlAccounts();

                            oAccount.AccountType = AccountType;
                            oAccount.ListID = QBListID;
                            oAccount.BranchID = Common.BranchID;
                            oAccount.TimeCreated = Convert.ToDateTime(AccountRet.SelectSingleNode("./TimeCreated").InnerText);
                            oAccount.TimeModified = Convert.ToDateTime(AccountRet.SelectSingleNode("./TimeModified").InnerText);
                            oAccount.FullName = AccountRet.SelectSingleNode("./FullName").InnerText;
                            oAccount.Name = AccountRet.SelectSingleNode("./Name").InnerText;

                            if (AccountRet.SelectSingleNode("./IsActive") != null)
                            {
                                oAccount.IsActive = Convert.ToBoolean(AccountRet.SelectSingleNode("./IsActive").InnerText);
                            }
                            XmlNode ParentRef = AccountRet.SelectSingleNode("./ParentRef");
                            if (ParentRef != null)
                            {
                                //Get value of ListID
                                if (AccountRet.SelectSingleNode("./ParentRef/ListID") != null)
                                {
                                    oAccount.ParentListId = AccountRet.SelectSingleNode("./ParentRef/ListID").InnerText;

                                }
                                //Get value of FullName
                                if (AccountRet.SelectSingleNode("./ParentRef/FullName") != null)
                                {
                                    oAccount.ParentName = AccountRet.SelectSingleNode("./ParentRef/FullName").InnerText;

                                }

                            }
                            //Done with field values for ParentRef aggregate

                            //Get value of Sublevel
                            oAccount.SubLevel = Convert.ToInt32(AccountRet.SelectSingleNode("./Sublevel").InnerText);

                            //Get value of SpecialAccountType
                            if (AccountRet.SelectSingleNode("./SpecialAccountType") != null)
                            {
                                oAccount.SpecialAccountType = AccountRet.SelectSingleNode("./SpecialAccountType").InnerText;

                            }

                            if (AccountRet.SelectSingleNode("./AccountNumber") != null)
                            {
                                oAccount.AccountNumber = AccountRet.SelectSingleNode("./AccountNumber").InnerText;

                            }

                            if (AccountRet.SelectSingleNode("./Desc") != null)
                            {
                                oAccount.AccountDesc = AccountRet.SelectSingleNode("./Desc").InnerText;

                            }
                            //Get value of Balance
                            if (AccountRet.SelectSingleNode("./Balance") != null)
                            {
                                oAccount.Balance = Convert.ToDouble(AccountRet.SelectSingleNode("./Balance").InnerText);

                            }

                            //Get all field values for CurrencyRef aggregate 
                            XmlNode CurrencyRef = AccountRet.SelectSingleNode("./CurrencyRef");
                            if (CurrencyRef != null)
                            {
                                //Get value of FullName
                                if (AccountRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                                {
                                    oAccount.Currency = AccountRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                                }
                            }

                            service.AccountsAddUpdate(oAccount);

                            bgWorker.ReportProgress(0, oAccount.FullName);
                            bgWorker.ReportProgress(0, "Exported to Server");
                            bgWorker.ReportProgress(0, "");
                        }

                    }
                    else
                    {
                        bgWorker.ReportProgress(0, statusMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Account Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public Boolean AddAccount(String FullName, int BranchID, System.ComponentModel.BackgroundWorker bgWorker)
        {
            bool blnResult = false;

            using (QBLinxWebService service = new QBLinxWebService())
            {
                var account = service.GetAccountByFullName(FullName, BranchID);

                if (account != null)
                {
                    blnResult = AddAccount(account.Name, account.ParentName, account.AccountType);
                }
            }

            return blnResult;
        }

        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }
    }
}
