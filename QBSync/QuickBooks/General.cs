using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;

namespace QBSync.QuickBooks
{
    public class General
    {
        public void GetDeletedRecords(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement parent = doc.CreateElement("QBXML");
                doc.AppendChild(parent);
                XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                parent.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement TxnDeletedQueryRq = doc.CreateElement("TxnDeletedQueryRq");
                qbXMLMsgsRq.AppendChild(TxnDeletedQueryRq);
                TxnDeletedQueryRq.SetAttribute("requestID", "1");

                //Set field value for TxnDelType <!-- required, may repeat -->
                TxnDeletedQueryRq.AppendChild(MakeSimpleElem(doc, "TxnDelType", "CreditMemo"));
                TxnDeletedQueryRq.AppendChild(MakeSimpleElem(doc, "TxnDelType", "Invoice"));
                TxnDeletedQueryRq.AppendChild(MakeSimpleElem(doc, "TxnDelType", "SalesOrder"));

                //Create DeletedDateRangeFilter aggregate and fill in field values for it
                XmlElement DeletedDateRangeFilter = doc.CreateElement("DeletedDateRangeFilter");
                TxnDeletedQueryRq.AppendChild(DeletedDateRangeFilter);
                //Set field value for FromDeletedDate <!-- optional -->
                DeletedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromDeletedDate", strLastRun));


                //if (!string.IsNullOrEmpty(strLastRun))
                //    TermsQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList TxnDeletedQueryRsList = responseXmlDoc.GetElementsByTagName("TxnDeletedQueryRs");
                if (TxnDeletedQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = TxnDeletedQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {

                        XmlNodeList TxnDeletedRetList = responseNode.SelectNodes("//TxnDeletedRet");//XPath Query

                        for (int i = 0; i < TxnDeletedRetList.Count; i++)
                        {
                            XmlNode TxnDeletedRet = TxnDeletedRetList.Item(i);

                            string TxnDelType = TxnDeletedRet.SelectSingleNode("./TxnDelType").InnerText;
                            //Get value of TxnID
                            string TxnID = TxnDeletedRet.SelectSingleNode("./TxnID").InnerText;

                            if (TxnDelType == "Invoice")
                            {
                                //Data.dsQBSyncTableAdapters.InvoiceTableAdapter taInvoice = new Data.dsQBSyncTableAdapters.InvoiceTableAdapter();
                                //taInvoice.UpdateStatus(2, TxnID);
                            }
                            else if (TxnDelType == "SalesOrder")
                            {
                                //Data.dsQBSyncTableAdapters.OrdersTableAdapter taOrder = new Data.dsQBSyncTableAdapters.OrdersTableAdapter();
                                //taOrder.UpdateStatus(2, TxnID);
                            }
                            else if (TxnDelType == "CreditMemo")
                            {
                                //Data.dsQBSyncTableAdapters.CreditMemoTableAdapter taCreditMemo = new Data.dsQBSyncTableAdapters.CreditMemoTableAdapter();
                                //taCreditMemo.UpdateStatus(2, TxnID);
                            }
                            //else if (TxnDelType == "BillPaymentCheck")
                            //{
                            //    //service.UpdateBillPaymentQBDeleted(Common.BranchID, TxnID);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Terms Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }
               
        //public static Boolean VoidTxn(string TxnVoidType, string TxnID, int MohidMasterId, System.ComponentModel.BackgroundWorker bgWorker, MdlTransactionLog log)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement TxnVoidRq = doc.CreateElement("TxnVoidRq");
        //        parent.AppendChild(TxnVoidRq);

        //        TxnVoidRq.AppendChild(MakeSimpleElem(doc, "TxnVoidType", TxnVoidType));
        //        //Set field value for TxnID <!-- required -->
        //        TxnVoidRq.AppendChild(MakeSimpleElem(doc, "TxnID", TxnID));


        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList TxnVoidRsList = responseXmlDoc.GetElementsByTagName("TxnVoidRs");
        //        if (TxnVoidRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = TxnVoidRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            //Common.ApplicationLog(responseNode.Name + " - " + TxnVoidType + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                log.StatusCode = 500;
        //                log.StatusDesc = statusMessage;

        //                if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList TxnVoidTypeList = responseNode.SelectNodes("//TxnVoidType");//XPath Query
        //                    for (int i = 0; i < TxnVoidTypeList.Count; i++)
        //                    {
        //                        XmlNode TxnVoidTypeRet = TxnVoidTypeList.Item(i);

        //                        //WebService.MohidData mohid_webservice = new QBSync.WebService.MohidData();
        //                        MohidCustom mohid_webservice = new MohidCustom();

        //                        if (TxnVoidType == "SalesReceipt" || TxnVoidType == "JournalEntry")
        //                            mohid_webservice.UpdateSalesModifiedTransaction(Common.Settings.MasjidKey, MohidMasterId);
        //                        else if (TxnVoidType == "Check" || TxnVoidType == "Bill" || TxnVoidType == "ItemReceipt")
        //                            mohid_webservice.UpdateBillsModifiedTransaction(Common.Settings.MasjidKey, MohidMasterId);

        //                        log.StatusDesc = "Voided";
        //                        log.SyncDetail += System.Environment.NewLine + "Voided Successfully";
        //                        bgWorker.ReportProgress(0, "Voided Successfully");

        //                        log.QBId = TxnID;
        //                        log.IsEdit = false;
        //                        log.StatusCode = 100;

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    log.SyncDetail += System.Environment.NewLine + statusMessage;
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                    return false;
        //                }
        //            }
        //        }
        //        return blnResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void DeleteTransaction(String pmtTxnDelType, String pmtTxnID, System.ComponentModel.BackgroundWorker bgWorker, int RecordID)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        //Create InvoiceAddRq aggregate and fill in field values for it
        //        XmlElement TxnDelRq = doc.CreateElement("TxnDelRq");
        //        parent.AppendChild(TxnDelRq);

        //        TxnDelRq.AppendChild(MakeSimpleElem(doc, "TxnDelType", pmtTxnDelType));
        //        //Set field value for TxnID <!-- required -->
        //        TxnDelRq.AppendChild(MakeSimpleElem(doc, "TxnID", pmtTxnID));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList TxnDelRsList = responseXmlDoc.GetElementsByTagName("TxnDelRs");
        //        if (TxnDelRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = TxnDelRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

        //            //Common.ApplicationLog(responseNode.Name + " - " + pmtTxnDelType + " - " + pmtRefNumber + " - " + statusCode, statusMessage, statusSeverity);
        //            //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);

        //            if (Convert.ToInt32(statusCode) == 0)
        //            {
        //                XmlNodeList TxnDelTypeList = responseNode.SelectNodes("//TxnDelType");//XPath Query
        //                for (int i = 0; i < TxnDelTypeList.Count; i++)
        //                {
        //                    XmlNode TxnDelType = TxnDelTypeList.Item(i);

        //                    //if (TxnDelType == null) return;


        //                    using (QBLinxWebService service = new QBLinxWebService())
        //                    {
        //                        string sysNotes = "";

        //                        if (pmtTxnDelType == "Invoice")
        //                        {
        //                            if (Common.BranchID == 1) sysNotes = System.Environment.NewLine + "Exported to QuickBooks HeadOffice " + DateTime.Now;
        //                            else sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;

        //                            var item = service.UpdateInvoiceSyncStatus(Common.BranchID, RecordID);

        //                            bgWorker.ReportProgress(0, "Invoice Deleted");
        //                        }
        //                        else if (pmtTxnDelType == "ReceivePayment")
        //                        {
        //                            var item = service.UpdateReceivePaymentSyncStatus(Common.BranchID, RecordID);

        //                            bgWorker.ReportProgress(0, "Payment Deleted");
        //                        }
        //                        if (pmtTxnDelType == "Bill")
        //                        {
        //                            if (Common.BranchID == 1) sysNotes = System.Environment.NewLine + "Exported to QuickBooks HeadOffice " + DateTime.Now;
        //                            else sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;

        //                            var item = service.UpdateBillSyncStatus(Common.BranchID, RecordID);

        //                            bgWorker.ReportProgress(0, "Bill Deleted");
        //                        }
        //                        else if (pmtTxnDelType == "BillPaymentCheck")
        //                        {
        //                            var item = service.UpdateBillPaymentSyncStatus(Common.BranchID, RecordID);

        //                            bgWorker.ReportProgress(0, "Bill Payment Deleted");
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                bgWorker.ReportProgress(0, "Error in deleting record in QB");
        //                bgWorker.ReportProgress(0, statusMessage);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public Boolean AddPaymentMethod(String PaymentMethod)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement PaymentMethodAddRq = doc.CreateElement("PaymentMethodAddRq");
            parent.AppendChild(PaymentMethodAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement PaymentMethodAdd = doc.CreateElement("PaymentMethodAdd");
            PaymentMethodAddRq.AppendChild(PaymentMethodAdd);
            //Set field value for Name <!-- required -->
            PaymentMethodAdd.AppendChild(MakeSimpleElem(doc, "Name", PaymentMethod));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList PaymentMethodAddRsList = responseXmlDoc.GetElementsByTagName("PaymentMethodAddRs");
            if (PaymentMethodAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = PaymentMethodAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList PaymentMethodRetList = responseNode.SelectNodes("//PaymentMethodRet");//XPath Query
                    for (int i = 0; i < PaymentMethodRetList.Count; i++)
                    {
                        XmlNode PaymentMethodRet = PaymentMethodRetList.Item(i);

                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddCustomerType(String CustomerType)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement CustomerTypeAddRq = doc.CreateElement("CustomerTypeAddRq");
            parent.AppendChild(CustomerTypeAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement CustomerTypeAdd = doc.CreateElement("CustomerTypeAdd");
            CustomerTypeAddRq.AppendChild(CustomerTypeAdd);
            //Set field value for Name <!-- required -->
            CustomerTypeAdd.AppendChild(MakeSimpleElem(doc, "Name", CustomerType));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList CustomerTypeAddRsList = responseXmlDoc.GetElementsByTagName("CustomerTypeAddRs");
            if (CustomerTypeAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = CustomerTypeAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList CustomerTypeRetList = responseNode.SelectNodes("//CustomerTypeRet");//XPath Query
                    for (int i = 0; i < CustomerTypeRetList.Count; i++)
                    {
                        XmlNode CustomerTypeRet = CustomerTypeRetList.Item(i);
                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddVendorType(String VendorType)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement VendorTypeAddRq = doc.CreateElement("VendorTypeAddRq");
            parent.AppendChild(VendorTypeAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement VendorTypeAdd = doc.CreateElement("VendorTypeAdd");
            VendorTypeAddRq.AppendChild(VendorTypeAdd);
            //Set field value for Name <!-- required -->
            VendorTypeAdd.AppendChild(MakeSimpleElem(doc, "Name", VendorType));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList VendorTypeAddRsList = responseXmlDoc.GetElementsByTagName("VendorTypeAddRs");
            if (VendorTypeAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = VendorTypeAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList VendorTypeRetList = responseNode.SelectNodes("//VendorTypeRet");//XPath Query
                    for (int i = 0; i < VendorTypeRetList.Count; i++)
                    {
                        XmlNode VendorTypeRet = VendorTypeRetList.Item(i);
                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddStandardTerms(String StandardTerm)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement StandardTermsAddRq = doc.CreateElement("StandardTermsAddRq");
            parent.AppendChild(StandardTermsAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement StandardTermsAdd = doc.CreateElement("StandardTermsAdd");
            StandardTermsAddRq.AppendChild(StandardTermsAdd);
            //Set field value for Name <!-- required -->
            StandardTermsAdd.AppendChild(MakeSimpleElem(doc, "Name", StandardTerm));
            StandardTermsAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList StandardTermsAddRsList = responseXmlDoc.GetElementsByTagName("StandardTermsAddRs");
            if (StandardTermsAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = StandardTermsAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList StandardTermsRetList = responseNode.SelectNodes("//StandardTermsRet");//XPath Query
                    for (int i = 0; i < StandardTermsRetList.Count; i++)
                    {
                        XmlNode StandardTermsRet = StandardTermsRetList.Item(i);
                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddClass(String ClassName)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement ClassAddRq = doc.CreateElement("ClassAddRq");
            parent.AppendChild(ClassAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement ClassAdd = doc.CreateElement("ClassAdd");
            ClassAddRq.AppendChild(ClassAdd);
            //Set field value for Name <!-- required -->
            ClassAdd.AppendChild(MakeSimpleElem(doc, "Name", ClassName));
            ClassAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList ClassAddRsList = responseXmlDoc.GetElementsByTagName("ClassAddRs");
            if (ClassAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = ClassAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList ClassRetList = responseNode.SelectNodes("//ClassRet");//XPath Query
                    for (int i = 0; i < ClassRetList.Count; i++)
                    {
                        XmlNode ClassRet = ClassRetList.Item(i);
                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddShipMethod(String ShipMethod)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement ShipMethodAddRq = doc.CreateElement("ShipMethodAddRq");
            parent.AppendChild(ShipMethodAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement ShipMethodAdd = doc.CreateElement("ShipMethodAdd");
            ShipMethodAddRq.AppendChild(ShipMethodAdd);
            //Set field value for Name <!-- required -->
            ShipMethodAdd.AppendChild(MakeSimpleElem(doc, "Name", ShipMethod));
            ShipMethodAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList ShipMethodAddRsList = responseXmlDoc.GetElementsByTagName("ShipMethodAddRs");
            if (ShipMethodAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = ShipMethodAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList ShipMethodRetList = responseNode.SelectNodes("//ShipMethodRet");//XPath Query
                    for (int i = 0; i < ShipMethodRetList.Count; i++)
                    {
                        XmlNode ShipMethodRet = ShipMethodRetList.Item(i);
                        blnResult = true;
                    }
                }
            }

            return blnResult;
        }

        public Boolean AddSalesRep(String SalesRepInitial, String EmployeeName)
        {
            Boolean blnResult = false;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
            XmlElement qbXML = doc.CreateElement("QBXML");
            doc.AppendChild(qbXML);
            XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(parent);
            parent.SetAttribute("onError", "continueOnError");

            //Create PaymentMethodAddRq aggregate and fill in field values for it
            XmlElement SalesRepAddRq = doc.CreateElement("SalesRepAddRq");
            parent.AppendChild(SalesRepAddRq);

            //Create PaymentMethodAdd aggregate and fill in field values for it
            XmlElement SalesRepAdd = doc.CreateElement("SalesRepAdd");
            SalesRepAddRq.AppendChild(SalesRepAdd);
            //Set field value for Name <!-- required -->
            SalesRepAdd.AppendChild(MakeSimpleElem(doc, "Initial", SalesRepInitial));
            SalesRepAdd.AppendChild(MakeSimpleElem(doc, "IsActive", "1"));

            XmlElement SalesRepEntityRef = doc.CreateElement("SalesRepEntityRef");
            SalesRepAdd.AppendChild(SalesRepEntityRef);
            //Set field value for FullName <!-- optional -->
            SalesRepEntityRef.AppendChild(MakeSimpleElem(doc, "FullName", Common.Truncate(EmployeeName, 25)));


            string strRequest = doc.OuterXml;
            string strResponse = QBConnection.ProcessRequest(strRequest);

            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            //Get the response for our request
            //Get the response for our request
            //Get the response for our request
            XmlNodeList SalesRepAddRsList = responseXmlDoc.GetElementsByTagName("SalesRepAddRs");
            if (SalesRepAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = SalesRepAddRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                //status code = 0 all OK, > 0 is warning
                if (statusCode == "3140")
                {
                    if (statusMessage.Contains("There is an invalid reference to QuickBooks SalesRep"))
                    {
                        //Employees emp = new Employees();
                        //if (emp.QBAddEmployee(EmployeeName))
                        //    blnResult = AddSalesRep(SalesRepInitial, EmployeeName);
                    }
                }
                else if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList SalesRepRetList = responseNode.SelectNodes("//SalesRepRet");//XPath Query
                    for (int i = 0; i < SalesRepRetList.Count; i++)
                    {
                        XmlNode SalesRepRet = SalesRepRetList.Item(i);
                        blnResult = true;
                    }
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

        public QBPreferences GetQBPreferences()
        {
            QBPreferences strResult = new QBPreferences();
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
                XmlElement PreferencesQueryRq = inputXMLDoc.CreateElement("PreferencesQueryRq");
                qbXMLMsgsRq.AppendChild(PreferencesQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                PreferencesQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "SalesTaxPreferences"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList PreferencesQueryRsList = responseXmlDoc.GetElementsByTagName("PreferencesQueryRs");
                if (PreferencesQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = PreferencesQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList PreferencesRetList = responseNode.SelectNodes("//PreferencesRet");//XPath Query
                        for (int i = 0; i < PreferencesRetList.Count; i++)
                        {
                            XmlNode PreferencesRet = PreferencesRetList.Item(i);
                            XmlNode SalesTaxPreferences = PreferencesRet.SelectSingleNode("./SalesTaxPreferences");
                            if (SalesTaxPreferences != null)
                            {
                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultItemSalesTaxRef/ListID") != null)
                                    strResult.DefaultItemSalesTaxListID = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultItemSalesTaxRef/ListID").InnerText;
                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultItemSalesTaxRef/FullName") != null)
                                    strResult.DefaultItemSalesTaxFullName = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultItemSalesTaxRef/FullName").InnerText;
                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultNonTaxableSalesTaxCodeRef/ListID") != null)
                                    strResult.DefaultNonTaxableSalesTaxCodeListID = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultNonTaxableSalesTaxCodeRef/ListID").InnerText;
                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultNonTaxableSalesTaxCodeRef/FullName") != null)
                                    strResult.DefaultNonTaxableSalesTaxCodeFullName = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultNonTaxableSalesTaxCodeRef/FullName").InnerText;

                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultTaxableSalesTaxCodeRef/ListID") != null)
                                {
                                    strResult.DefaultTaxableSalesTaxCodeListID = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultTaxableSalesTaxCodeRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultTaxableSalesTaxCodeRef/FullName") != null)
                                {
                                    strResult.DefaultTaxableSalesTaxCodeFullName = PreferencesRet.SelectSingleNode("./SalesTaxPreferences/DefaultTaxableSalesTaxCodeRef/FullName").InnerText;
                                }

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

        //public void SalesRepQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement parent = doc.CreateElement("QBXML");
        //        doc.AppendChild(parent);
        //        XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
        //        parent.AppendChild(qbXMLMsgsRq);
        //        qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

        //        //Create CustomerModRq  aggregate and fill in field values for it
        //        XmlElement SalesRepQueryRq = doc.CreateElement("SalesRepQueryRq");
        //        qbXMLMsgsRq.AppendChild(SalesRepQueryRq);
        //        SalesRepQueryRq.SetAttribute("requestID", "1");

        //        //if (!string.IsNullOrEmpty(strLastRun))
        //        //    SalesRepQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

        //        SalesRepQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeRetElement", "ListID"));
        //        SalesRepQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeRetElement", "Initial"));
        //        SalesRepQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeRetElement", "IsActive"));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList SalesRepQueryRsList = responseXmlDoc.GetElementsByTagName("SalesRepQueryRs");
        //        if (SalesRepQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = SalesRepQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                using (QBLinxWebService service = new QBLinxWebService())
        //                {

        //                    XmlNodeList SalesRepRetList = responseNode.SelectNodes("//SalesRepRet");//XPath Query

        //                    for (int i = 0; i < SalesRepRetList.Count; i++)
        //                    {
        //                        XmlNode SalesRepRet = SalesRepRetList.Item(i);

        //                        var oRow = new QBLinxDataService.MdlQBList();

        //                        oRow.BranchID = Common.BranchID;
        //                        oRow.QBListID = SalesRepRet.SelectSingleNode("./ListID").InnerText;
        //                        oRow.QBListName = SalesRepRet.SelectSingleNode("./Initial").InnerText;

        //                        service.SalesRepAddUpdate(oRow);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! SalesRep Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

        public void TermsQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement parent = doc.CreateElement("QBXML");
                doc.AppendChild(parent);
                XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                parent.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement TermsQueryRq = doc.CreateElement("TermsQueryRq");
                qbXMLMsgsRq.AppendChild(TermsQueryRq);
                TermsQueryRq.SetAttribute("requestID", "1");

                TermsQueryRq.AppendChild(MakeSimpleElem(doc, "ActiveStatus", "ActiveOnly"));
                //Set field value for FromModifiedDate <!-- optional -->
                TermsQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

                //if (!string.IsNullOrEmpty(strLastRun))
                //    TermsQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList TermsQueryRsList = responseXmlDoc.GetElementsByTagName("TermsQueryRs");
                if (TermsQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = TermsQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        //Data.dsQBSyncTableAdapters.TermsTableAdapter taTerms = new Data.dsQBSyncTableAdapters.TermsTableAdapter();
                        Data.dsQBSync ds = new Data.dsQBSync();
                        ds.EnforceConstraints = false;

                        XmlNodeList TermsRetList = responseNode.SelectNodes("//StandardTermsRet");//XPath Query

                        for (int i = 0; i < TermsRetList.Count; i++)
                        {
                            XmlNode TermsRet = TermsRetList.Item(i);

                            string ListID = TermsRet.SelectSingleNode("./ListID").InnerText;

                            //var oRow = ds.Terms.NewTermsRow();
                            //taTerms.FillByQBListID(ds.Terms, ListID);
                            //if (ds.Terms.Count > 0)
                            //{
                            //    oRow = ds.Terms[0];
                            //}
                            //else
                            //{
                            //    oRow.QBListID = ListID;
                            //    ds.Terms.AddTermsRow(oRow);
                            //}

                            //oRow.TermName = TermsRet.SelectSingleNode("./Name").InnerText;

                            //if (TermsRet.SelectSingleNode("./StdDueDays") != null)
                            //{
                            //    oRow.StdDueDays = Convert.ToInt32(TermsRet.SelectSingleNode("./StdDueDays").InnerText);
                            //}


                            //taTerms.Update(oRow);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Terms Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public void ShipMethodQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement parent = doc.CreateElement("QBXML");
                doc.AppendChild(parent);
                XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                parent.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

                //Create CustomerModRq  aggregate and fill in field values for it
                XmlElement ShipMethodQueryRq = doc.CreateElement("ShipMethodQueryRq");
                qbXMLMsgsRq.AppendChild(ShipMethodQueryRq);
                ShipMethodQueryRq.SetAttribute("requestID", "1");

                //if (!string.IsNullOrEmpty(strLastRun))
                //    ShipMethodQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList ShipMethodQueryRsList = responseXmlDoc.GetElementsByTagName("ShipMethodQueryRs");
                if (ShipMethodQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ShipMethodQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        //Data.dsQBSyncTableAdapters.ShipMethodsTableAdapter taShipMethod = new Data.dsQBSyncTableAdapters.ShipMethodsTableAdapter();
                        Data.dsQBSync ds = new Data.dsQBSync();
                        ds.EnforceConstraints = false;

                        XmlNodeList ShipMethodRetList = responseNode.SelectNodes("//ShipMethodRet");//XPath Query

                        for (int i = 0; i < ShipMethodRetList.Count; i++)
                        {
                            XmlNode ShipMethodRet = ShipMethodRetList.Item(i);

                            string ListID = ShipMethodRet.SelectSingleNode("./ListID").InnerText;
                            string Name = ShipMethodRet.SelectSingleNode("./Name").InnerText;

                            //var oRow = ds.ShipMethods.NewShipMethodsRow();
                            //taShipMethod.FillByQBListID(ds.ShipMethods, ListID);

                            //if (ds.ShipMethods.Count > 0)
                            //{
                            //    oRow = ds.ShipMethods[0];
                            //}
                            //else
                            //{
                            //    oRow.QBListID = ListID;
                            //    //ds.ShipMethods.AddShipMethodsRow(oRow);
                            //}

                            //if (ShipMethodRet.SelectSingleNode("./IsActive") != null)
                            //{
                            //    oRow.IsActive = Convert.ToBoolean(ShipMethodRet.SelectSingleNode("./IsActive").InnerText);
                            //}

                            //oRow.ShipMethod = Name;

                            //taShipMethod.Update(oRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! ShipMethod Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        //public void PaymentMethodQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement parent = doc.CreateElement("QBXML");
        //        doc.AppendChild(parent);
        //        XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
        //        parent.AppendChild(qbXMLMsgsRq);
        //        qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

        //        //Create CustomerModRq  aggregate and fill in field values for it
        //        XmlElement PaymentMethodQueryRq = doc.CreateElement("PaymentMethodQueryRq");
        //        qbXMLMsgsRq.AppendChild(PaymentMethodQueryRq);
        //        PaymentMethodQueryRq.SetAttribute("requestID", "1");

        //        //if (!string.IsNullOrEmpty(strLastRun))
        //        //    PaymentMethodQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList PaymentMethodQueryRsList = responseXmlDoc.GetElementsByTagName("PaymentMethodQueryRs");
        //        if (PaymentMethodQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = PaymentMethodQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                using (QBLinxWebService service = new QBLinxWebService())
        //                {

        //                    XmlNodeList PaymentMethodRetList = responseNode.SelectNodes("//PaymentMethodRet");//XPath Query

        //                    for (int i = 0; i < PaymentMethodRetList.Count; i++)
        //                    {
        //                        XmlNode PaymentMethodRet = PaymentMethodRetList.Item(i);

        //                        var oRow = new QBLinxDataService.MdlQBList();

        //                        oRow.BranchID = Common.BranchID;
        //                        oRow.QBListID = PaymentMethodRet.SelectSingleNode("./ListID").InnerText;
        //                        oRow.QBListName = PaymentMethodRet.SelectSingleNode("./Name").InnerText;

        //                        service.PaymentMethodsAddUpdate(oRow);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! PaymentMethod Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

        //public void ClassQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement parent = doc.CreateElement("QBXML");
        //        doc.AppendChild(parent);
        //        XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
        //        parent.AppendChild(qbXMLMsgsRq);
        //        qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

        //        //Create CustomerModRq  aggregate and fill in field values for it
        //        XmlElement ClassQueryRq = doc.CreateElement("ClassQueryRq");
        //        qbXMLMsgsRq.AppendChild(ClassQueryRq);
        //        ClassQueryRq.SetAttribute("requestID", "1");

        //        //if (!string.IsNullOrEmpty(strLastRun))
        //        //    ClassQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ClassQueryRsList = responseXmlDoc.GetElementsByTagName("ClassQueryRs");
        //        if (ClassQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ClassQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                using (QBLinxWebService service = new QBLinxWebService())
        //                {

        //                    XmlNodeList ClassRetList = responseNode.SelectNodes("//ClassRet");//XPath Query

        //                    for (int i = 0; i < ClassRetList.Count; i++)
        //                    {
        //                        XmlNode ClassRet = ClassRetList.Item(i);

        //                        var oRow = new QBLinxDataService.MdlQBList();

        //                        oRow.BranchID = Common.BranchID;
        //                        oRow.QBListID = ClassRet.SelectSingleNode("./ListID").InnerText;
        //                        oRow.QBListName = ClassRet.SelectSingleNode("./Name").InnerText;
        //                        if (ClassRet.SelectSingleNode("./FullName") != null)
        //                        {
        //                            oRow.QBListName = ClassRet.SelectSingleNode("./FullName").InnerText;
        //                        }

        //                        service.ClassAddUpdate(oRow);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Class Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

        //public void SalesTaxCodeQuery(String strLastRun, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement parent = doc.CreateElement("QBXML");
        //        doc.AppendChild(parent);
        //        XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
        //        parent.AppendChild(qbXMLMsgsRq);
        //        qbXMLMsgsRq.SetAttribute("onError", "continueOnError");

        //        //Create CustomerModRq  aggregate and fill in field values for it
        //        XmlElement SalesTaxCodeQueryRq = doc.CreateElement("SalesTaxCodeQueryRq");
        //        qbXMLMsgsRq.AppendChild(SalesTaxCodeQueryRq);
        //        SalesTaxCodeQueryRq.SetAttribute("requestID", "1");

        //        //if (!string.IsNullOrEmpty(strLastRun))
        //        //    SalesTaxCodeQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", strLastRun));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList SalesTaxCodeQueryRsList = responseXmlDoc.GetElementsByTagName("SalesTaxCodeQueryRs");
        //        if (SalesTaxCodeQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = SalesTaxCodeQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(statusMessage, responseNode.Name + " - " + statusCode, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                using (QBLinxWebService service = new QBLinxWebService())
        //                {

        //                    XmlNodeList SalesTaxCodeRetList = responseNode.SelectNodes("//SalesTaxCodeRet");//XPath Query
        //                    for (int i = 0; i < SalesTaxCodeRetList.Count; i++)
        //                    {
        //                        XmlNode SalesTaxCodeRet = SalesTaxCodeRetList.Item(i);

        //                        var oRow = new QBLinxDataService.MdlSalesTaxCode();

        //                        oRow.BranchID = Common.BranchID;
        //                        oRow.QBListID = SalesTaxCodeRet.SelectSingleNode("./ListID").InnerText;
        //                        oRow.TaxCode = SalesTaxCodeRet.SelectSingleNode("./Name").InnerText;

        //                        if (SalesTaxCodeRet.SelectSingleNode("./IsActive") != null)
        //                        {
        //                            oRow.IsActive = Convert.ToBoolean(SalesTaxCodeRet.SelectSingleNode("./IsActive").InnerText);
        //                        }

        //                        oRow.IsTaxable = Convert.ToBoolean(SalesTaxCodeRet.SelectSingleNode("./IsTaxable").InnerText);

        //                        XmlNode ItemPurchaseTaxRef = SalesTaxCodeRet.SelectSingleNode("./ItemPurchaseTaxRef");
        //                        if (ItemPurchaseTaxRef != null)
        //                        {
        //                            //Get value of ListID
        //                            if (SalesTaxCodeRet.SelectSingleNode("./ItemPurchaseTaxRef/ListID") != null)
        //                            {
        //                                oRow.PurchaseTaxItemListID = SalesTaxCodeRet.SelectSingleNode("./ItemPurchaseTaxRef/ListID").InnerText;

        //                            }
        //                            //Get value of FullName
        //                            if (SalesTaxCodeRet.SelectSingleNode("./ItemPurchaseTaxRef/FullName") != null)
        //                            {
        //                                oRow.PurchaseTaxItemName = SalesTaxCodeRet.SelectSingleNode("./ItemPurchaseTaxRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for ItemPurchaseTaxRef aggregate

        //                        //Get all field values for ItemSalesTaxRef aggregate 
        //                        XmlNode ItemSalesTaxRef = SalesTaxCodeRet.SelectSingleNode("./ItemSalesTaxRef");
        //                        if (ItemSalesTaxRef != null)
        //                        {
        //                            //Get value of ListID
        //                            if (SalesTaxCodeRet.SelectSingleNode("./ItemSalesTaxRef/ListID") != null)
        //                            {
        //                                oRow.SalesTaxItemListID = SalesTaxCodeRet.SelectSingleNode("./ItemSalesTaxRef/ListID").InnerText;

        //                            }
        //                            //Get value of FullName
        //                            if (SalesTaxCodeRet.SelectSingleNode("./ItemSalesTaxRef/FullName") != null)
        //                            {
        //                                oRow.SalesTaxItemName = SalesTaxCodeRet.SelectSingleNode("./ItemSalesTaxRef/FullName").InnerText;

        //                            }

        //                        }

        //                        service.SalesTaxCodeAddUpdate(oRow);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! SalesTaxCodes Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

    }


    public struct QBPreferences
    {
        public String DefaultItemSalesTaxListID;
        public String DefaultItemSalesTaxFullName;
        public String DefaultNonTaxableSalesTaxCodeListID;
        public String DefaultNonTaxableSalesTaxCodeFullName;
        public String DefaultTaxableSalesTaxCodeListID;
        public String DefaultTaxableSalesTaxCodeFullName;
    }
}
