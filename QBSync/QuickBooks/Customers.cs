using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QBSync.QuickBooks;
using QBSync;
//using Interop.QBXMLRP2;

namespace QBSync.QuickBooks
{
    public class Customers
    {
        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void CustomerQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                string strIterator = "Start";
                string strIteratorID = "";
                string strRemaining = "0";

                do
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                    doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
                    XmlElement parent = doc.CreateElement("QBXML");
                    doc.AppendChild(parent);
                    XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                    parent.AppendChild(qbXMLMsgsRq);
                    qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
                    XmlElement CustomerQueryRq = doc.CreateElement("CustomerQueryRq");
                    qbXMLMsgsRq.AppendChild(CustomerQueryRq);
                    CustomerQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        CustomerQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        CustomerQueryRq.SetAttribute("iteratorID", strIteratorID);

                    CustomerQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    CustomerQueryRq.AppendChild(MakeSimpleElem(doc, "ActiveStatus", "All"));
                    CustomerQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    if (Common.UseQBQueryToDate)
                        CustomerQueryRq.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Set field value for IncludeRetElement <!-- optional, may repeat -->
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Name"));
                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList CustomerQueryRsList = responseXmlDoc.GetElementsByTagName("CustomerQueryRs");
                    if (CustomerQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = CustomerQueryRsList.Item(0);
                        //Check the status code, info, and severity
                        XmlAttributeCollection rsAttributes = responseNode.Attributes;
                        string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                        string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                        string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                        strRemaining = rsAttributes.GetNamedItem("iteratorRemainingCount") == null ? "" : rsAttributes.GetNamedItem("iteratorRemainingCount").Value;
                        strIteratorID = rsAttributes.GetNamedItem("iteratorID") == null ? "" : rsAttributes.GetNamedItem("iteratorID").Value;

                        if (Convert.ToInt32(strRemaining) > 0)
                        {
                            strIterator = "Continue";
                        }

                        Common.ApplicationLog(responseNode.Name + "-" + statusCode, statusMessage, statusSeverity);
                        //status code = 0 all OK, > 0 is warning
                        if (Convert.ToInt32(statusCode) == 0)
                        {
                            XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query

                            Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();
                            //Data.dsQBSyncTableAdapters.CustomerShipToAddressTableAdapter taCustomerShipTo = new Data.dsQBSyncTableAdapters.CustomerShipToAddressTableAdapter();

                            Data.dsQBSync ds = new Data.dsQBSync();
                            ds.EnforceConstraints = false;
                            ds.Customer.Clear();

                            for (int i = 0; i < CustomerRetList.Count; i++)
                            {
                                XmlNode CustomerRet = CustomerRetList.Item(i);

                                if (CustomerRet == null) continue;

                                String QBListID = CustomerRet.SelectSingleNode("./ListID").InnerText;

                                var oCustomer = ds.Customer.NewCustomerRow();
                                taCustomer.FillByQBListID(ds.Customer, QBListID);
                                if (ds.Customer.Count > 0)
                                {
                                    oCustomer = ds.Customer[0];

                                    //taCustomerShipTo.DeleteByCustomerID(oCustomer.CustomerID);
                                }
                                else
                                {
                                    oCustomer.ListID = QBListID;
                                    ds.Customer.AddCustomerRow(oCustomer);
                                }

                                oCustomer.RegDate = Convert.ToDateTime(CustomerRet.SelectSingleNode("./TimeCreated").InnerText);
                                oCustomer.AddDate = Convert.ToDateTime(CustomerRet.SelectSingleNode("./TimeCreated").InnerText);
                                oCustomer.ModifyDate = Convert.ToDateTime(CustomerRet.SelectSingleNode("./TimeModified").InnerText);
                                oCustomer.FirstName = CustomerRet.SelectSingleNode("./Name").InnerText;
                                oCustomer.LastName = CustomerRet.SelectSingleNode("./FullName").InnerText;

                                if (CustomerRet.SelectSingleNode("./IsActive") != null)
                                {
                                    oCustomer.Active = Convert.ToBoolean(CustomerRet.SelectSingleNode("./IsActive").InnerText);
                                }
                                if (CustomerRet.SelectSingleNode("./CompanyName") != null)
                                {
                                    oCustomer.CompanyName = CustomerRet.SelectSingleNode("./CompanyName").InnerText;

                                }
                                //Get value of FirstName
                                //if (CustomerRet.SelectSingleNode("./FirstName") != null)
                                //{
                                //    oCustomer.FirstName = CustomerRet.SelectSingleNode("./FirstName").InnerText;

                                //}
                                //Get value of MiddleName
                                //if (CustomerRet.SelectSingleNode("./MiddleName") != null)
                                //{
                                //    oCustomer.MiddleName = CustomerRet.SelectSingleNode("./MiddleName").InnerText;

                                //}
                                //Get value of LastName
                                //if (CustomerRet.SelectSingleNode("./LastName") != null)
                                //{
                                //    oCustomer.LastName = CustomerRet.SelectSingleNode("./LastName").InnerText;

                                //}

                                //XmlNode BillAddress = CustomerRet.SelectSingleNode("./BillAddress");
                                //if (BillAddress != null)
                                //{
                                //    //Get value of Addr1
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/Addr1") != null)
                                //    {
                                //        oCustomer.BillAdd1 = CustomerRet.SelectSingleNode("./BillAddress/Addr1").InnerText;
                                //    }
                                //    //Get value of Addr2
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/Addr2") != null)
                                //    {
                                //        oCustomer.BillAdd2 = CustomerRet.SelectSingleNode("./BillAddress/Addr2").InnerText;
                                //    }
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/Addr3") != null)
                                //    {
                                //        oCustomer.BillAdd3 = CustomerRet.SelectSingleNode("./BillAddress/Addr3").InnerText;
                                //    }
                                //    //Get value of City
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/City") != null)
                                //    {
                                //        oCustomer.BillCity = CustomerRet.SelectSingleNode("./BillAddress/City").InnerText;
                                //    }
                                //    //Get value of State
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/State") != null)
                                //    {
                                //        oCustomer.BillState = CustomerRet.SelectSingleNode("./BillAddress/State").InnerText;

                                //    }
                                //    //Get value of PostalCode
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/PostalCode") != null)
                                //    {
                                //        oCustomer.BillPostalCode = CustomerRet.SelectSingleNode("./BillAddress/PostalCode").InnerText;

                                //    }
                                //    //Get value of Country
                                //    if (CustomerRet.SelectSingleNode("./BillAddress/Country") != null)
                                //    {
                                //        oCustomer.BillCountry = CustomerRet.SelectSingleNode("./BillAddress/Country").InnerText;
                                //    }
                                //}

                                //XmlNode ShipAddress = CustomerRet.SelectSingleNode("./ShipAddress");
                                //if (ShipAddress != null)
                                //{
                                //    //Get value of Addr1
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/Addr1") != null)
                                //    {
                                //        oCustomer.ShipAdd1 = CustomerRet.SelectSingleNode("./ShipAddress/Addr1").InnerText;
                                //    }
                                //    //Get value of Addr2
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/Addr2") != null)
                                //    {
                                //        oCustomer.ShipAdd2 = CustomerRet.SelectSingleNode("./ShipAddress/Addr2").InnerText;
                                //    }
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/Addr3") != null)
                                //    {
                                //        oCustomer.ShipAdd3 = CustomerRet.SelectSingleNode("./ShipAddress/Addr3").InnerText;
                                //    }
                                //    //Get value of City
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/City") != null)
                                //    {
                                //        oCustomer.ShipCity = CustomerRet.SelectSingleNode("./ShipAddress/City").InnerText;
                                //    }
                                //    //Get value of State
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/State") != null)
                                //    {
                                //        oCustomer.ShipState = CustomerRet.SelectSingleNode("./ShipAddress/State").InnerText;

                                //    }
                                //    //Get value of PostalCode
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/PostalCode") != null)
                                //    {
                                //        oCustomer.ShipPostalCode = CustomerRet.SelectSingleNode("./ShipAddress/PostalCode").InnerText;

                                //    }
                                //    //Get value of Country
                                //    if (CustomerRet.SelectSingleNode("./ShipAddress/Country") != null)
                                //    {
                                //        oCustomer.ShipCountry = CustomerRet.SelectSingleNode("./ShipAddress/Country").InnerText;
                                //    }
                                //}

                                if (CustomerRet.SelectSingleNode("./Phone") != null)
                                {
                                    oCustomer.Phone1 = CustomerRet.SelectSingleNode("./Phone").InnerText;
                                }
                                //Get value of Email
                                if (CustomerRet.SelectSingleNode("./Email") != null)
                                {
                                    oCustomer.Email = CustomerRet.SelectSingleNode("./Email").InnerText;
                                }

                                if (CustomerRet.SelectSingleNode("./Balance") != null)
                                {
                                    oCustomer.Balance = Convert.ToDecimal(CustomerRet.SelectSingleNode("./Balance").InnerText);
                                }

                                XmlNode TermsRef = CustomerRet.SelectSingleNode("./TermsRef");
                                if (TermsRef != null)
                                {
                                    if (CustomerRet.SelectSingleNode("./TermsRef/FullName") != null)
                                    {
                                        oCustomer.TermsName = CustomerRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                                    }
                                }

                                //XmlNode SalesRepRef = CustomerRet.SelectSingleNode("./SalesRepRef");
                                //if (SalesRepRef != null)
                                //{
                                //    if (CustomerRet.SelectSingleNode("./SalesRepRef/FullName") != null)
                                //    {
                                //        oCustomer.SalesRep = CustomerRet.SelectSingleNode("./SalesRepRef/FullName").InnerText;
                                //    }
                                //}

                                //XmlNode CurrencyRef = CustomerRet.SelectSingleNode("./CurrencyRef");
                                //if (CurrencyRef != null)
                                //{
                                //    //Get value of FullName
                                //    if (CustomerRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                                //    {
                                //        oCustomer.Currency = CustomerRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                                //    }
                                //}

                                //XmlNode SalesTaxCodeRef = CustomerRet.SelectSingleNode("./SalesTaxCodeRef");
                                //if (SalesTaxCodeRef != null)
                                //{
                                //    //Get value of FullName
                                //    if (CustomerRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                                //    {
                                //        oCustomer.TaxCode = CustomerRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                                //    }
                                //}

                                //if (CustomerRet.SelectSingleNode("./ItemSalesTaxRef") != null)
                                //{
                                //    //Get value of FullName
                                //    if (CustomerRet.SelectSingleNode("./ItemSalesTaxRef/FullName") != null)
                                //    {
                                //        oCustomer.ItemSalesTaxRef = CustomerRet.SelectSingleNode("./ItemSalesTaxRef/FullName").InnerText;
                                //    }
                                //}

                                if (CustomerRet.SelectSingleNode("./CreditLimit") != null)
                                {
                                    oCustomer.CreditLimits = Convert.ToDecimal(CustomerRet.SelectSingleNode("./CreditLimit").InnerText);
                                }

                                //oCustomer.CustomerType = "";
                                //if (CustomerRet.SelectSingleNode("./CustomerTypeRef") != null)
                                //{
                                //    //Get value of FullName
                                //    if (CustomerRet.SelectSingleNode("./CustomerTypeRef/FullName") != null)
                                //    {
                                //        oCustomer.CustomerType = CustomerRet.SelectSingleNode("./CustomerTypeRef/FullName").InnerText;
                                //    }
                                //}

                                if ("Wholesale".ToUpper() == "Wholesale".ToUpper()) //oCustomer.CustomerType.ToUpper()
                                {
                                    oCustomer.IsCustomer = true;
                                    oCustomer.AddUserID = -1;
                                    oCustomer.ModifyUserID = -1;
                                    oCustomer.IsLocked = true;
                                    oCustomer.EndEdit();
                                    taCustomer.Update(oCustomer);

                                    XmlNodeList ShipToAddressList = CustomerRet.SelectNodes("./ShipToAddress");//XPath Query                       
                                    for (int j = 0; j < ShipToAddressList.Count; j++)
                                    {
                                        XmlNode ShipToAddress = ShipToAddressList.Item(j);

                                        //var rowShipTo = ds.CustomerShipToAddress.NewCustomerShipToAddressRow();

                                        //rowShipTo.CustomerID = oCustomer.CustomerID;
                                        //rowShipTo.ListID = oCustomer.ListID;
                                        //rowShipTo.ShipAddressName = ShipToAddress.SelectSingleNode("./Name").InnerText;

                                        //Get value of Addr1
                                        //if (ShipToAddress.SelectSingleNode("./Addr1") != null)
                                        //{
                                        //    rowShipTo.ShipAdd1 = ShipToAddress.SelectSingleNode("./Addr1").InnerText;
                                        //}
                                        ////Get value of Addr2
                                        //if (ShipToAddress.SelectSingleNode("./Addr2") != null)
                                        //{
                                        //    rowShipTo.ShipAdd2 = ShipToAddress.SelectSingleNode("./Addr2").InnerText;
                                        //}
                                        //if (ShipToAddress.SelectSingleNode("./Addr3") != null)
                                        //{
                                        //    rowShipTo.ShipAdd3 = ShipToAddress.SelectSingleNode("./Addr3").InnerText;
                                        //}
                                        ////Get value of City
                                        //if (ShipToAddress.SelectSingleNode("./City") != null)
                                        //{
                                        //    rowShipTo.ShipCity = ShipToAddress.SelectSingleNode("./City").InnerText;
                                        //}
                                        ////Get value of State
                                        //if (ShipToAddress.SelectSingleNode("./State") != null)
                                        //{
                                        //    rowShipTo.ShipState = ShipToAddress.SelectSingleNode("./State").InnerText;
                                        //}
                                        ////Get value of PostalCode
                                        //if (ShipToAddress.SelectSingleNode("./PostalCode") != null)
                                        //{
                                        //    rowShipTo.ShipPostalCode = ShipToAddress.SelectSingleNode("./PostalCode").InnerText;
                                        //}
                                        ////Get value of Country
                                        //if (ShipToAddress.SelectSingleNode("./Country") != null)
                                        //{
                                        //    rowShipTo.ShipCountry = ShipToAddress.SelectSingleNode("./Country").InnerText;
                                        //}

                                        ////DefaultShipTo
                                        //if (ShipToAddress.SelectSingleNode("./DefaultShipTo") != null)
                                        //{
                                        //    rowShipTo.DefaultShipTo = Convert.ToBoolean(ShipToAddress.SelectSingleNode("./DefaultShipTo").InnerText);
                                        //}

                                        //ds.CustomerShipToAddress.AddCustomerShipToAddressRow(rowShipTo);

                                        //taCustomerShipTo.Update(rowShipTo);
                                    }

                                    bgWorker.ReportProgress(0, oCustomer.FirstName);
                                    bgWorker.ReportProgress(0, "Exported to Server");
                                    bgWorker.ReportProgress(0, "");

                                }
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }
                while (Convert.ToInt32(strRemaining) > 0);
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Customer Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public String GetCustomerEditSequence(String ListID)
        {
            String strResult = "";
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

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement CustomerQueryRq = inputXMLDoc.CreateElement("CustomerQueryRq");
                qbXMLMsgsRq.AppendChild(CustomerQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CustomerQueryRsList = responseXmlDoc.GetElementsByTagName("CustomerQueryRs");
                if (CustomerQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CustomerQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
                        for (int i = 0; i < CustomerRetList.Count; i++)
                        {
                            XmlNode CustomerRet = CustomerRetList.Item(i);
                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = CustomerRet.SelectSingleNode("./EditSequence").InnerText;

                            return strResult;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResult;
        }

        public MdlQB GetCustomerListID(String FullName)
        {
            MdlQB strResult = null;
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

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement CustomerQueryRq = inputXMLDoc.CreateElement("CustomerQueryRq");
                qbXMLMsgsRq.AppendChild(CustomerQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", FullName));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CustomerQueryRsList = responseXmlDoc.GetElementsByTagName("CustomerQueryRs");
                if (CustomerQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CustomerQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
                        for (int i = 0; i < CustomerRetList.Count; i++)
                        {
                            strResult = new MdlQB();

                            XmlNode CustomerRet = CustomerRetList.Item(i);
                            strResult.ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult.EditSequence = CustomerRet.SelectSingleNode("./EditSequence").InnerText;

                            return strResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResult;
        }

        public MdlQB GetCustomerBalance(String ListID)
        {
            MdlQB strResult = null;
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

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement CustomerQueryRq = inputXMLDoc.CreateElement("CustomerQueryRq");
                qbXMLMsgsRq.AppendChild(CustomerQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "FullName"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Balance"));
                CustomerQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TotalBalance"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CustomerQueryRsList = responseXmlDoc.GetElementsByTagName("CustomerQueryRs");
                if (CustomerQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CustomerQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
                        for (int i = 0; i < CustomerRetList.Count; i++)
                        {
                            strResult = new MdlQB();

                            XmlNode CustomerRet = CustomerRetList.Item(i);
                            strResult.ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult.EditSequence = CustomerRet.SelectSingleNode("./EditSequence").InnerText;
                            strResult.FullName = CustomerRet.SelectSingleNode("./FullName").InnerText;

                            //Get value of Balance
                            if (CustomerRet.SelectSingleNode("./Balance") != null)
                            {
                                strResult.Balance = Convert.ToDouble(CustomerRet.SelectSingleNode("./Balance").InnerText);
                            }

                            //Get value of TotalBalance
                            if (CustomerRet.SelectSingleNode("./TotalBalance") != null)
                            {
                                string TotalBalance = CustomerRet.SelectSingleNode("./TotalBalance").InnerText;
                            }

                            return strResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strResult;
        }

        public String QBAddCusomter(string CustomerFullName)
        {
            String strResult = "";
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(parent);
                parent.SetAttribute("onError", "stopOnError");

                //Create CustomerAddRq aggregate and fill in field values for it
                XmlElement CustomerAddRq = doc.CreateElement("CustomerAddRq");
                parent.AppendChild(CustomerAddRq);
                XmlElement CustomerAdd = doc.CreateElement("CustomerAdd");
                CustomerAddRq.AppendChild(CustomerAdd);

                CustomerAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(CustomerFullName, 41)));

                CustomerAdd.AppendChild(MakeSimpleElem(doc, "IsActive", (1).ToString()));

                if (!String.IsNullOrEmpty(CustomerFullName))
                    CustomerAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(CustomerFullName, 41)));

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CustomerAddRsList = responseXmlDoc.GetElementsByTagName("CustomerAddRs");
                if (CustomerAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CustomerAddRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + CustomerFullName + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        if (statusCode == "3140")
                        {

                        }
                        else if (Convert.ToInt32(statusCode) == 3100)
                        {
                            string[] stringSeparators = new string[] { "\"" };
                            string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            if (result.Count() > 1)
                            {
                                String CustomerName = result[1];

                                var mdlCustomer = GetCustomerListID(CustomerName);
                                strResult = mdlCustomer != null ? mdlCustomer.ListID : "";

                            }
                        }
                        else
                        {
                            XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
                            for (int i = 0; i < CustomerRetList.Count; i++)
                            {
                                XmlNode CustomerRet = CustomerRetList.Item(i);

                                String QBListID = CustomerRet.SelectSingleNode("./ListID").InnerText;

                                strResult = QBListID;
                            }
                        }
                    }

                }

                return strResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddCustomer(Data.dsQBSync.CustomerRow CustomerRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            string FullName = "";
            Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();

            //step2: create the qbXML request
            XmlDocument inputXMLDoc = new XmlDocument();
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));
            //inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"2.0\""));
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
            XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
            inputXMLDoc.AppendChild(qbXML);
            XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(qbXMLMsgsRq);
            qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
            XmlElement custAddRq = inputXMLDoc.CreateElement("CustomerAddRq");
            qbXMLMsgsRq.AppendChild(custAddRq);
            custAddRq.SetAttribute("requestID", "1");
            XmlElement custAdd = inputXMLDoc.CreateElement("CustomerAdd");
            custAddRq.AppendChild(custAdd);
            custAdd.AppendChild(inputXMLDoc.CreateElement("Name")).InnerText = CustomerRow.IsFirstNameNull() ? "" : CustomerRow.FirstName;

            if (!CustomerRow.IsPhone1Null())
                custAdd.AppendChild(inputXMLDoc.CreateElement("Phone")).InnerText = CustomerRow.IsPhone1Null() ? "" : CustomerRow.Phone1;
            //string companyName = CustomerRow.IsCompanyNameNull() ? "" : CustomerRow.CompanyName;
            //if (companyName.Length > 0)
            //    custAdd.AppendChild(inputXMLDoc.CreateElement("CompanyName")).InnerText = companyName;

            //if (CustomerRow.FirstName.Length > 0)
            //    FullName = CustomerRow.FirstName;

            //if (CustomerRow.LastName.Length > 0)
            //    FullName += CustomerRow.LastName;

            //custAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = FullName;

            if (!CustomerRow.IsEmailNull())
                custAdd.AppendChild(inputXMLDoc.CreateElement("Email")).InnerText = CustomerRow.IsEmailNull() ? "" : CustomerRow.Email;

            string input = inputXMLDoc.OuterXml;

            bool isEdit = false; string editSequence = "";
            if (!string.IsNullOrEmpty(listId))
            {
                editSequence = GetCustomerEditSequence(listId);
                if (!string.IsNullOrEmpty(editSequence))
                {
                    isEdit = true;
                }
                else
                {
                    bgWorker.ReportProgress(0, "Record not found in QuickBooks for update!");
                    return;
                }
            }

            string strResponse = QBConnection.ProcessRequest(input);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            XmlNodeList CustomerAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "CustomerModRs" : "CustomerAddRs");
            if (CustomerAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = CustomerAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);

                if (Convert.ToInt32(statusCode) >= 0)
                {
                    if (statusCode == "3140")
                    {
                        if (statusMessage.Contains("There is an invalid reference to QuickBooks Customer"))
                        {
                            ////bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
                            //Customers objCustomer = new Customers();
                            //if (objCustomer.QBAddCusomter(orderRow, bgWorker))
                            //{
                            //    blnResult = AddSalesOrder(orderRow, txnId, bgWorker);
                            //}
                            //else
                            //{
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                            //}
                        }
                        else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
                        {
                            //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Item");

                            //Items objItem = new Items();
                            //string[] stringSeparators = new string[] { "\"" };
                            //string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            //if (result.Count() > 1)
                            //{
                            //    String ProductName = result[1];

                            //    var itmListId = (from st in orderRow.SalesOrderDetailLines
                            //                     where st.ItemFullName == ProductName
                            //                     select st.ItemListID).FirstOrDefault();

                            //    if (!string.IsNullOrEmpty(itmListId))
                            //    {
                            //        if (objItem.AddItem(itmListId, orderRow.BranchID, bgWorker))
                            //            blnResult = AddSalesOrder(orderRow, txnId, bgWorker);
                            //        else
                            //        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                            //        }
                            //    }
                            //}
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Customer");
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                    }
                    else if (statusCode == "0")
                    {
                        XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
                        for (int i = 0; i < CustomerRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = CustomerRetList.Item(i);
                            string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

                            var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //Get value of TimeModified
                            var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);


                            //string NewRefNumber = "";
                            //if (SalesOrderRet.SelectSingleNode("./RefNumber") != null)
                            //{
                            //    NewRefNumber = SalesOrderRet.SelectSingleNode("./RefNumber").InnerText;
                            //}

                            string CustomerListID = "";
                            if (SalesOrderRet.SelectSingleNode("./CustomerRef/ListID") != null)
                            {
                                CustomerListID = SalesOrderRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
                            }

                            //Customers objCustomer = new Customers();
                            //var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

                            string sysNotes = CustomerRow.IsNotesNull() ? ("Exported to QuickBooks " + DateTime.Now) : (CustomerRow.Notes + System.Environment.NewLine + "Exported to QuickBooks " + DateTime.Now);

                            taCustomer.UpdateQBFields(newTxnId, TimeModified, sysNotes, CustomerRow.ID);

                            bgWorker.ReportProgress(0, "Customer " + (isEdit ? "updated" : "added") + " successfully");
                            //blnResult = true;
                        }
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Customer");
                        bgWorker.ReportProgress(0, statusMessage);
                    }
                }
            }

            //step3: do the qbXMLRP request
            //RequestProcessor2 rp = null;
            //string ticket = null;
            //string response = null;
            //try
            //{
            //    rp = new RequestProcessor2();
            //    rp.OpenConnection("", "IDN CustomerAdd C# sample");
            //    ticket = rp.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
            //    response = rp.ProcessRequest(ticket, input);

            //}
            //catch (System.Runtime.InteropServices.COMException ex)
            //{
            //    //MessageBox.Show("COM Error Description = " + ex.Message, "COM error");
            //    bgWorker.ReportProgress(0, ex.Message);
            //    return;
            //}
            //finally
            //{
            //    if (ticket != null)
            //    {
            //        rp.EndSession(ticket);
            //    }
            //    if (rp != null)
            //    {
            //        rp.CloseConnection();
            //    }
            //};

            //step4: parse the XML response and show a message
            //XmlDocument outputXMLDoc = new XmlDocument();
            //outputXMLDoc.LoadXml(response);
            //XmlNodeList qbXMLMsgsRsNodeList = outputXMLDoc.GetElementsByTagName("CustomerAddRs");

            //if (qbXMLMsgsRsNodeList.Count == 1) //it's always true, since we added a single Customer
            //{
            //    System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();

            //    XmlAttributeCollection rsAttributes = qbXMLMsgsRsNodeList.Item(0).Attributes;
            //    //get the status Code, info and Severity
            //    string retStatusCode = rsAttributes.GetNamedItem("statusCode").Value;
            //    string retStatusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
            //    string retStatusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
            //    popupMessage.AppendFormat("statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
            //        retStatusCode, retStatusSeverity, retStatusMessage);

            //    //get the CustomerRet node for detailed info

            //    //a CustomerAddRs contains max one childNode for "CustomerRet"
            //    XmlNodeList custAddRsNodeList = qbXMLMsgsRsNodeList.Item(0).ChildNodes;
            //    if (custAddRsNodeList.Count == 1 && custAddRsNodeList.Item(0).Name.Equals("CustomerRet"))
            //    {
            //        XmlNodeList custRetNodeList = custAddRsNodeList.Item(0).ChildNodes;

            //        foreach (XmlNode custRetNode in custRetNodeList)
            //        {
            //            if (custRetNode.Name.Equals("ListID"))
            //            {
            //                popupMessage.AppendFormat("\r\nCustomer ListID = {0}", custRetNode.InnerText);
            //            }
            //            else if (custRetNode.Name.Equals("Name"))
            //            {
            //                popupMessage.AppendFormat("\r\nCustomer Name = {0}", custRetNode.InnerText);
            //            }
            //            else if (custRetNode.Name.Equals("FullName"))
            //            {
            //                popupMessage.AppendFormat("\r\nCustomer FullName = {0}", custRetNode.InnerText);
            //            }
            //        }
            //    } // End of customerRet

            //    //MessageBox.Show(popupMessage.ToString(), "QuickBooks response");
            //    bgWorker.ReportProgress(0, "Error! Adding/Updating in Customer");
            //    bgWorker.ReportProgress(0, popupMessage.ToString());
            //    //Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            //    return;
            //End of customerAddRs}
            //}
        }

        //public bool AddCustomer(Data.dsQBSync.CustomerRow CustomerRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        Data.dsQBSync ds = new Data.dsQBSync();
        //        ds.EnforceConstraints = false;
        //        Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();
        //        //Data.dsQBSyncTableAdapters.OrderDetailTableAdapter taOrderDetail = new Data.dsQBSyncTableAdapters.OrderDetailTableAdapter();
        //        //taOrderDetail.FillByOrderID(ds.OrderDetail, orderRow.OrderID);

        //        //if (ds.OrderDetail.Count() == 0)
        //        //{
        //        //    bgWorker.ReportProgress(0, "There is no detail row!");
        //        //    return false;
        //        //}

        //        bool isEdit = false; string editSequence = "";
        //        if (!string.IsNullOrEmpty(listId))
        //        {
        //            editSequence = GetCustomerEditSequence(listId);
        //            if (!string.IsNullOrEmpty(editSequence))
        //            {
        //                isEdit = true;
        //            }
        //            else
        //            {
        //                bgWorker.ReportProgress(0, "Record not found in QuickBooks for update!");
        //                return false;
        //            }
        //        }

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        //Create SalesOrderAddRq aggregate and fill in field values for it SalesOrderModRq
        //        XmlElement CustomerAddRq = doc.CreateElement(isEdit ? "CustomerModRq" : "CustomerAddRq");
        //        parent.AppendChild(CustomerAddRq);
        //        //Create SalesOrderAdd aggregate and fill in field values for it
        //        XmlElement CustomerAdd = doc.CreateElement(isEdit ? "CustomerMod" : "CustomerAdd");
        //        CustomerAddRq.AppendChild(CustomerAdd);

        //        if (isEdit)
        //        {
        //            CustomerAdd.AppendChild(MakeSimpleElem(doc, "ListID", listId));
        //            //Set field value for EditSequence <!-- required -->
        //            CustomerAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
        //        }

        //        String CustomerFullName = CustomerRow.IsFirstNameNull() ? "" : CustomerRow.FirstName;
        //        CustomerFullName += CustomerRow.IsLastNameNull() ? "" : CustomerRow.LastName;
        //        if (string.IsNullOrEmpty(CustomerFullName))
        //        {
        //            bgWorker.ReportProgress(0, "Customer name is empty!");
        //            return false;
        //        }

        //        //CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
        //        //Create CustomerRef aggregate and fill in field values for it
        //        //XmlElement CustomerRef = doc.CreateElement("CustomerRef");
        //        //CustomerAdd.AppendChild(CustomerRef);
        //        ////Set field value for ListID <!-- optional -->
        //        //CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));

        //        //Set field value for TxnDate <!-- optional -->
        //        //if (orderRow.IsTxnDateNull() == false)
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", orderRow.TxnDate.ToString("yyyy-MM-dd")));
        //        //Set field value for RefNumber <!-- optional -->
        //        //if (!string.IsNullOrEmpty(orderRow.RefNumber))
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", orderRow.RefNumber));

        //        //Billing
        //        //XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        //SalesOrderAdd.AppendChild(BillAddress);

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(orderRow.IsBillAdd1Null() ? "" : orderRow.BillAdd1, 39)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(orderRow.IsBillAdd2Null() ? "" : orderRow.BillAdd2, 39)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(orderRow.IsBillAdd3Null() ? "" : orderRow.BillAdd3, 39)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(orderRow.IsBillCityNull() ? "" : orderRow.BillCity, 31)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(orderRow.IsBillStateNull() ? "" : orderRow.BillState, 21)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(orderRow.IsBillPostalCodeNull() ? "" : orderRow.BillPostalCode, 13)));

        //        //BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(orderRow.IsBillCountryNull() ? "" : orderRow.BillCountry, 21)));


        //        ////Shiping
        //        //XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        //SalesOrderAdd.AppendChild(ShipAddress);

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(orderRow.IsShipAdd1Null() ? "" : orderRow.ShipAdd1, 39)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(orderRow.IsShipAdd2Null() ? "" : orderRow.ShipAdd2, 39)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(orderRow.IsShipAdd3Null() ? "" : orderRow.ShipAdd3, 39)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(orderRow.IsShipCityNull() ? "" : orderRow.ShipCity, 31)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(orderRow.IsShipStateNull() ? "" : orderRow.ShipState, 21)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(orderRow.IsShipPostalCodeNull() ? "" : orderRow.ShipPostalCode, 13)));

        //        //ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(orderRow.IsShipCountryNull() ? "" : orderRow.ShipCountry, 21)));


        //        //Set field value for PONumber <!-- optional -->
        //        //if (!String.IsNullOrEmpty(orderRow.IsCustomerPONoNull() ? "" : orderRow.CustomerPONo))
        //        //{
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "PONumber", Common.Truncate(orderRow.CustomerPONo, 25)));
        //        //}

        //        //if (!String.IsNullOrEmpty(orderRow.IsPaymentTermsNull() ? "" : orderRow.PaymentTerms))
        //        //{
        //        //    //Create TermsRef aggregate and fill in field values for it
        //        //    XmlElement TermsRef = doc.CreateElement("TermsRef");
        //        //    SalesOrderAdd.AppendChild(TermsRef);
        //        //    //Set field value for ListID <!-- optional -->
        //        //    //TermsRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //        //    //Set field value for FullName <!-- optional -->
        //        //    TermsRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.PaymentTerms));
        //        //    //Done creating TermsRef aggregate
        //        //}

        //        ////Set field value for DueDate <!-- optional -->
        //        //if (orderRow.RequestedShipDate > DateTime.MinValue)
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "DueDate", orderRow.RequestedShipDate.ToString("yyyy-MM-dd")));

        //        ////if (!String.IsNullOrEmpty(orderRow.ShipCountry))
        //        ////{
        //        ////    //Create SalesRepRef aggregate and fill in field values for it
        //        ////    XmlElement SalesRepRef = doc.CreateElement("SalesRepRef");
        //        ////    SalesOrderAdd.AppendChild(SalesRepRef);
        //        ////    //Set field value for ListID <!-- optional -->
        //        ////    //SalesRepRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //        ////    //Set field value for FullName <!-- optional -->
        //        ////    SalesRepRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.SalesRep));
        //        ////    //Done creating SalesRepRef aggregate
        //        ////}

        //        //if (!String.IsNullOrEmpty(orderRow.ShipMethod))
        //        //{
        //        //    //Create ShipMethodRef aggregate and fill in field values for it
        //        //    XmlElement ShipMethodRef = doc.CreateElement("ShipMethodRef");
        //        //    SalesOrderAdd.AppendChild(ShipMethodRef);
        //        //    //Set field value for ListID <!-- optional -->
        //        //    //ShipMethodRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //        //    //Set field value for FullName <!-- optional -->
        //        //    ShipMethodRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.ShipMethod));
        //        //    //Done creating ShipMethodRef aggregate
        //        //}

        //        //if (isEdit == false)
        //        //{
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "Memo", "Online Order: " + (orderRow.IsOrderMemoNull() ? "" : orderRow.OrderMemo)));
        //        //}
        //        //else
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "Memo", orderRow.IsOrderMemoNull() ? "" : orderRow.OrderMemo));

        //        ////Set field value for ExchangeRate <!-- optional -->
        //        //if (orderRow.IsCurrencyRateNull() == false)
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", orderRow.CurrencyRate.ToString("###0.00")));


        //        //foreach (Data.dsQBSync.OrderDetailRow detailRow in ds.OrderDetail)
        //        //{
        //        //    SalesOrderAdd.AppendChild(AddSalesOrderLine(doc, isEdit ? "SalesOrderLineMod" : "SalesOrderLineAdd", detailRow));
        //        //}

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        XmlNodeList CustomerAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "CustomerModRs" : "CustomerAddRs");
        //        if (CustomerAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = CustomerAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);

        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Customer"))
        //                    {
        //                        ////bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
        //                        //Customers objCustomer = new Customers();
        //                        //if (objCustomer.QBAddCusomter(orderRow, bgWorker))
        //                        //{
        //                        //    blnResult = AddSalesOrder(orderRow, txnId, bgWorker);
        //                        //}
        //                        //else
        //                        //{
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                        //}
        //                    }
        //                    else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
        //                    {
        //                        //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Item");

        //                        //Items objItem = new Items();
        //                        //string[] stringSeparators = new string[] { "\"" };
        //                        //string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        //if (result.Count() > 1)
        //                        //{
        //                        //    String ProductName = result[1];

        //                        //    var itmListId = (from st in orderRow.SalesOrderDetailLines
        //                        //                     where st.ItemFullName == ProductName
        //                        //                     select st.ItemListID).FirstOrDefault();

        //                        //    if (!string.IsNullOrEmpty(itmListId))
        //                        //    {
        //                        //        if (objItem.AddItem(itmListId, orderRow.BranchID, bgWorker))
        //                        //            blnResult = AddSalesOrder(orderRow, txnId, bgWorker);
        //                        //        else
        //                        //        {
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                        //        }
        //                        //    }
        //                        //}
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Customer");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (statusCode == "0")
        //                {
        //                    XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
        //                    for (int i = 0; i < CustomerRetList.Count; i++)
        //                    {
        //                        XmlNode SalesOrderRet = CustomerRetList.Item(i);
        //                        string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

        //                        var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./AddDate").InnerText);
        //                        //Get value of TimeModified
        //                        var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./ModifyDate").InnerText);


        //                        //string NewRefNumber = "";
        //                        //if (SalesOrderRet.SelectSingleNode("./RefNumber") != null)
        //                        //{
        //                        //    NewRefNumber = SalesOrderRet.SelectSingleNode("./RefNumber").InnerText;
        //                        //}

        //                        string CustomerListID = "";
        //                        if (SalesOrderRet.SelectSingleNode("./CustomerRef/ListID") != null)
        //                        {
        //                            CustomerListID = SalesOrderRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                        }

        //                        //Customers objCustomer = new Customers();
        //                        //var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

        //                        string sysNotes = CustomerRow.IsNotesNull() ? ("Exported to QuickBooks " + DateTime.Now) : (CustomerRow.Notes + System.Environment.NewLine + "Exported to QuickBooks " + DateTime.Now);

        //                        taCustomer.UpdateQBFields(newTxnId, TimeCreated, TimeModified, sysNotes, CustomerRow.ID);

        //                        bgWorker.ReportProgress(0, "Customer " + (isEdit ? "updated" : "added") + " successfully");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Customer");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bgWorker.ReportProgress(0, "Error! Adding/Updating in Customer");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
        //    }

        //    return blnResult;
        //}

        //public Boolean QBAddCusomter(QBLinxDataService.MdlInvoice invoiceRow, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    String CustomerFullName = invoiceRow.CustomerFullName;
        //    CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);

        //    Boolean blnResult = false;
        //    try
        //    {
        //        if (string.IsNullOrEmpty(CustomerFullName)) return false;

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");

        //        //Create CustomerAddRq aggregate and fill in field values for it
        //        XmlElement CustomerAddRq = doc.CreateElement("CustomerAddRq");
        //        parent.AppendChild(CustomerAddRq);
        //        XmlElement CustomerAdd = doc.CreateElement("CustomerAdd");
        //        CustomerAddRq.AppendChild(CustomerAdd);

        //        CustomerAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(CustomerFullName, 41)));

        //        //CustomerAdd.AppendChild(MakeSimpleElem(doc, "IsActive", ((pCustomer.IsIsDeletedNull() ? false : pCustomer.IsDeleted) == true ? 0 : 1).ToString()));

        //        CustomerAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(CustomerFullName, 41)));

        //        //if (!String.IsNullOrEmpty(pCustomer.company_name))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(pCustomer.company_name, 41)));

        //        //if (!String.IsNullOrEmpty(pCustomer.first_name))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "FirstName", Common.Truncate(pCustomer.first_name, 25)));

        //        //if (!String.IsNullOrEmpty(pCustomer.last_name))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "LastName", Common.Truncate(pCustomer.last_name, 25)));

        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        CustomerAdd.AppendChild(BillAddress);

        //        if (!String.IsNullOrEmpty(invoiceRow.BillAdd1))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.BillAdd1, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillAdd2))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(invoiceRow.BillAdd2, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillAdd3))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(invoiceRow.BillAdd3, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillCity))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.BillCity, 31)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillState))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.BillState, 21)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillPostalCode))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.BillPostalCode, 13)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.BillCountry))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.BillCountry, 21)));
        //        }


        //        //Shiping
        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        CustomerAdd.AppendChild(ShipAddress);

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipAdd1))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.ShipAdd1, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipAdd2))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(invoiceRow.ShipAdd2, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipAdd3))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(invoiceRow.ShipAdd3, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipCity))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.ShipCity, 31)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipState))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.ShipState, 21)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipPostalCode))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.ShipPostalCode, 13)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipCountry))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.ShipCountry, 21)));
        //        }

        //        if (!string.IsNullOrEmpty(invoiceRow.Currency))
        //        {
        //            XmlElement CurrencyRef = doc.CreateElement("CurrencyRef");
        //            CustomerAdd.AppendChild(CurrencyRef);
        //            //Set field value for ListID <!-- optional -->
        //            //CurrencyRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            CurrencyRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.Currency));
        //        }

        //        //if (!String.IsNullOrEmpty(pCustomer.IsPhoneNull() ? "" : pCustomer.Phone))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "Phone", Common.Truncate(pCustomer.Phone, 21)));

        //        //if (!String.IsNullOrEmpty(pCustomer.IsAltPhoneNull() ? "" : pCustomer.AltPhone))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "AltPhone", Common.Truncate(pCustomer.AltPhone, 21)));

        //        //if (!String.IsNullOrEmpty(pCustomer.IsFaxNull() ? "" : pCustomer.Fax))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "Fax", Common.Truncate(pCustomer.Fax, 21)));

        //        //if (!String.IsNullOrEmpty(pCustomer.IsEmailNull() ? "" : pCustomer.Email))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "Email", Common.Truncate(pCustomer.Email, 1023)));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList CustomerAddRsList = responseXmlDoc.GetElementsByTagName("CustomerAddRs");
        //        if (CustomerAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = CustomerAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + CustomerFullName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {

        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + CustomerFullName + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
        //                    for (int i = 0; i < CustomerRetList.Count; i++)
        //                    {
        //                        XmlNode CustomerRet = CustomerRetList.Item(i);

        //                        String QBListID = CustomerRet.SelectSingleNode("./ListID").InnerText;

        //                        //Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();
        //                        //taCustomer.UpdateQBStatus(QBListID, true, pCustomer.ID);

        //                        bgWorker.ReportProgress(0, "'" + CustomerFullName + "' Customer added");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Customer '" + CustomerFullName + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Customer '" + CustomerFullName + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}

        //public Boolean QBModCusomter(Data.dsQBSync.CustomerRow pCustomer, string QBEditSequence, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String CustomerFullName = pCustomer.IsAccountNameNull() ? "" : pCustomer.AccountName;
        //        CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);

        //        if (string.IsNullOrEmpty(CustomerFullName)) return false;

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");

        //        //Create CustomerAddRq aggregate and fill in field values for it
        //        XmlElement CustomerModRq = doc.CreateElement("CustomerModRq");
        //        parent.AppendChild(CustomerModRq);
        //        XmlElement CustomerMod = doc.CreateElement("CustomerMod");
        //        CustomerModRq.AppendChild(CustomerMod);

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "ListID", pCustomer.QBListId));
        //        //Set field value for EditSequence <!-- required -->
        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "EditSequence", QBEditSequence));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(CustomerFullName, 41)));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "IsActive", ((pCustomer.IsIsDeletedNull() ? false : pCustomer.IsDeleted) == true ? 0 : 1).ToString()));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(CustomerFullName, 41)));

        //        //if (!String.IsNullOrEmpty(pCustomer.first_name))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "FirstName", Common.Truncate(pCustomer.first_name, 25)));

        //        //if (!String.IsNullOrEmpty(pCustomer.last_name))
        //        //    CustomerAdd.AppendChild(MakeSimpleElem(doc, "LastName", Common.Truncate(pCustomer.last_name, 25)));

        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        CustomerMod.AppendChild(BillAddress);

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate((pCustomer.IsBillAdd1Null() ? "" : pCustomer.BillAdd1), 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate((pCustomer.IsBillAdd2Null() ? "" : pCustomer.BillAdd2), 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pCustomer.IsBillAdd3Null() ? "" : pCustomer.BillAdd3, 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pCustomer.IsBillAdd4Null() ? "" : pCustomer.BillAdd4, 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pCustomer.IsBillCityNull() ? "" : pCustomer.BillCity, 31)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pCustomer.IsBillStateNull() ? "" : pCustomer.BillState, 21)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pCustomer.IsBillPostalCodeNull() ? "" : pCustomer.BillPostalCode, 13)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pCustomer.IsBillCountryNull() ? "" : pCustomer.BillCountry, 21)));

        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        CustomerMod.AppendChild(ShipAddress);

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate((pCustomer.IsShipAdd1Null() ? "" : pCustomer.ShipAdd1), 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate((pCustomer.IsShipAdd2Null() ? "" : pCustomer.ShipAdd2), 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pCustomer.IsShipAdd3Null() ? "" : pCustomer.ShipAdd3, 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pCustomer.IsShipAdd4Null() ? "" : pCustomer.ShipAdd4, 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pCustomer.IsShipCityNull() ? "" : pCustomer.ShipCity, 31)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pCustomer.IsShipStateNull() ? "" : pCustomer.ShipState, 21)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pCustomer.IsShipPostalCodeNull() ? "" : pCustomer.ShipPostalCode, 13)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pCustomer.IsShipCountryNull() ? "" : pCustomer.ShipCountry, 21)));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "Phone", Common.Truncate(pCustomer.IsPhoneNull() ? "" : pCustomer.Phone, 21)));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "AltPhone", Common.Truncate(pCustomer.IsAltPhoneNull() ? "" : pCustomer.AltPhone, 21)));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "Fax", Common.Truncate(pCustomer.IsFaxNull() ? "" : pCustomer.Fax, 21)));

        //        CustomerMod.AppendChild(MakeSimpleElem(doc, "Email", Common.Truncate(pCustomer.IsEmailNull() ? "" : pCustomer.Email, 1023)));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList CustomerModRsList = responseXmlDoc.GetElementsByTagName("CustomerModRs");
        //        if (CustomerModRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = CustomerModRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + CustomerFullName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {

        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    var custExist = GetCustomerListID(CustomerFullName);
        //                    //if (custExist != null)
        //                    //{
        //                    //    if (pCustomer.contact_id > 0)
        //                    //    {
        //                    //        MohidCustom mohid_webservice = new MohidCustom();
        //                    //        mohid_webservice.UpdateDonorQBListID(Common.Settings.MasjidKey, pCustomer.contact_id, custExist.ListID);
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        MohidCustom mohid_webservice = new MohidCustom();
        //                    //        mohid_webservice.UpdateCustomerQBListID(Common.Settings.MasjidKey, pCustomer.fin_customer_id, custExist.ListID);
        //                    //    }

        //                    //    pCustomer.qb_list_id = custExist.ListID;
        //                    //    QBModCusomter(pCustomer, custExist.EditSequence);
        //                    //}                           
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList CustomerRetList = responseNode.SelectNodes("//CustomerRet");//XPath Query
        //                    for (int i = 0; i < CustomerRetList.Count; i++)
        //                    {
        //                        XmlNode CustomerRet = CustomerRetList.Item(i);

        //                        String QBListID = CustomerRet.SelectSingleNode("./ListID").InnerText;

        //                        Data.dsQBSyncTableAdapters.CustomerTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomerTableAdapter();
        //                        taCustomer.UpdateQBStatus(QBListID, true, pCustomer.ID);

        //                        bgWorker.ReportProgress(0, "Successfully updated in QuickBooks");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Updating in Customer");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Updating in Customer");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        //throw ex;
        //    }

        //    return blnResult;
        //}

    }
}
