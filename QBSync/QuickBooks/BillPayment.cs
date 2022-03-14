using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class BillPayments
    {
        //public void BillPaymentCheckQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    try
        //    {
        //        string strIterator = "Start";
        //        string strIteratorID = "";
        //        string strRemaining = "0";

        //        do
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //            doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
        //            XmlElement parent = doc.CreateElement("QBXML");
        //            doc.AppendChild(parent);
        //            XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
        //            parent.AppendChild(qbXMLMsgsRq);
        //            qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
        //            XmlElement BillPaymentCheckQueryRq = doc.CreateElement("BillPaymentCheckQueryRq");
        //            qbXMLMsgsRq.AppendChild(BillPaymentCheckQueryRq);
        //            BillPaymentCheckQueryRq.SetAttribute("requestID", "1");

        //            if (!String.IsNullOrEmpty(strIterator))
        //                BillPaymentCheckQueryRq.SetAttribute("iterator", strIterator);
        //            if (!String.IsNullOrEmpty(strIteratorID))
        //                BillPaymentCheckQueryRq.SetAttribute("iteratorID", strIteratorID);

        //            BillPaymentCheckQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

        //            //Create ModifiedDateRangeFilter aggregate and fill in field values for it
        //            XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
        //            BillPaymentCheckQueryRq.AppendChild(ModifiedDateRangeFilter);
        //            //Set field value for FromModifiedDate <!-- optional -->
        //            ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
        //            //Set field value for ToModifiedDate <!-- optional -->
        //            if (Common.UseQBQueryToDate)
        //                ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
        //            //Done creating ModifiedDateRangeFilter aggregate

        //            BillPaymentCheckQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

        //            strRemaining = "0";

        //            string strRequest = doc.OuterXml;
        //            string strResponse = QBConnection.ProcessRequest(strRequest);

        //            //Parse the response XML string into an XmlDocument
        //            XmlDocument responseXmlDoc = new XmlDocument();
        //            responseXmlDoc.LoadXml(strResponse);

        //            //Get the response for our request             
        //            XmlNodeList BillPaymentCheckQueryRsList = responseXmlDoc.GetElementsByTagName("BillPaymentCheckQueryRs");
        //            if (BillPaymentCheckQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //            {
        //                XmlNode responseNode = BillPaymentCheckQueryRsList.Item(0);
        //                //Check the status code, info, and severity
        //                XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //                strRemaining = rsAttributes.GetNamedItem("iteratorRemainingCount") == null ? "" : rsAttributes.GetNamedItem("iteratorRemainingCount").Value;
        //                strIteratorID = rsAttributes.GetNamedItem("iteratorID") == null ? "" : rsAttributes.GetNamedItem("iteratorID").Value;

        //                if (Convert.ToInt32(strRemaining) > 0)
        //                {
        //                    strIterator = "Continue";
        //                }

        //                Common.ApplicationLog(responseNode.Name + "-" + statusCode, statusMessage, statusSeverity);
        //                //status code = 0 all OK, > 0 is warning
        //                if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList BillPaymentCheckRetList = responseNode.SelectNodes("//BillPaymentCheckRet");//XPath Query

        //                    QBLinxWebService service = new QBLinxWebService();

        //                    for (int i = 0; i < BillPaymentCheckRetList.Count; i++)
        //                    {
        //                        XmlNode BillPaymentCheckRet = BillPaymentCheckRetList.Item(i);

        //                        if (BillPaymentCheckRet == null) continue;

        //                        var oPayment = new QBLinxDataService.MdlBillPayments();
        //                        string strLogDesc = "";

        //                        string TxnID = BillPaymentCheckRet.SelectSingleNode("./TxnID").InnerText;

        //                        oPayment.BillPaymentID = -1;
        //                        oPayment.PaymentType = "BillPaymentCheck";
        //                        oPayment.BranchID = Common.BranchID;
        //                        oPayment.PaymentStatus = 1;
        //                        if (Common.BranchID == 1)
        //                        {
        //                            oPayment.HOSync = true;
        //                            oPayment.TxnID = TxnID;
        //                            //oPayment.SystemNotes = "Exported to Cloud From Head Office On: " + System.DateTime.Now;
        //                        }
        //                        else
        //                        {
        //                            oPayment.BRSync = true;
        //                            oPayment.BRTxnID = TxnID;
        //                            //oPayment.SystemNotes = "Exported to Cloud From Branch On: " + System.DateTime.Now;
        //                        }

        //                        //oInvoice.UtcOffset = Common.LoginUser.UtcOffset;
        //                        oPayment.TimeCreated = Convert.ToDateTime(BillPaymentCheckRet.SelectSingleNode("./TimeCreated").InnerText);
        //                        oPayment.TimeModified = Convert.ToDateTime(BillPaymentCheckRet.SelectSingleNode("./TimeModified").InnerText);

        //                        if (BillPaymentCheckRet.SelectSingleNode("./PayeeEntityRef/ListID") != null)
        //                        {
        //                            oPayment.PayeeListID = BillPaymentCheckRet.SelectSingleNode("./PayeeEntityRef/ListID").InnerText;

        //                        }
        //                        //Get value of FullName
        //                        if (BillPaymentCheckRet.SelectSingleNode("./APAccountRef/FullName") != null)
        //                        {
        //                            oPayment.APAccount = BillPaymentCheckRet.SelectSingleNode("./APAccountRef/FullName").InnerText;

        //                        }

        //                        if (BillPaymentCheckRet.SelectSingleNode("./PayeeEntityRef/FullName") != null)
        //                        {
        //                            oPayment.PayeeFullName = BillPaymentCheckRet.SelectSingleNode("./PayeeEntityRef/FullName").InnerText;

        //                        }

        //                        if (BillPaymentCheckRet.SelectSingleNode("./BankAccountRef/ListID") != null)
        //                        {
        //                            oPayment.BankAccountListID = BillPaymentCheckRet.SelectSingleNode("./BankAccountRef/ListID").InnerText;

        //                        }
        //                        //Get value of FullName
        //                        if (BillPaymentCheckRet.SelectSingleNode("./BankAccountRef/FullName") != null)
        //                        {
        //                            oPayment.BankAccountFullName = BillPaymentCheckRet.SelectSingleNode("./BankAccountRef/FullName").InnerText;

        //                        }

        //                        oPayment.TxnDate = Convert.ToDateTime(BillPaymentCheckRet.SelectSingleNode("./TxnDate").InnerText);
        //                        //Get value of RefNumber
        //                        if (BillPaymentCheckRet.SelectSingleNode("./Amount") != null)
        //                        {
        //                            oPayment.Amount = Convert.ToDouble(BillPaymentCheckRet.SelectSingleNode("./Amount").InnerText);
        //                            strLogDesc = "Payment Amt. " + oPayment.Amount.ToString();
        //                        }

        //                        if (BillPaymentCheckRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            oPayment.RefNumber = BillPaymentCheckRet.SelectSingleNode("./RefNumber").InnerText;
        //                            strLogDesc += " Ref# " + oPayment.RefNumber;
        //                        }

        //                        strLogDesc += " Date. " + BillPaymentCheckRet.SelectSingleNode("./TxnDate").InnerText;

        //                        //Get all field values for CurrencyRef aggregate 
        //                        XmlNode CurrencyRef = BillPaymentCheckRet.SelectSingleNode("./CurrencyRef");
        //                        if (CurrencyRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillPaymentCheckRet.SelectSingleNode("./CurrencyRef/FullName") != null)
        //                            {
        //                                oPayment.Currency = BillPaymentCheckRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
        //                            }
        //                        }

        //                        if (BillPaymentCheckRet.SelectSingleNode("./ExchangeRate") != null)
        //                        {
        //                            oPayment.CurrencyRate = Convert.ToDouble(BillPaymentCheckRet.SelectSingleNode("./ExchangeRate").InnerText);
        //                        }

        //                        if (BillPaymentCheckRet.SelectSingleNode("./TotalAmountInHomeCurrency") != null)
        //                        {
        //                            oPayment.TotalAmountInHomeCurrency = Convert.ToDouble(BillPaymentCheckRet.SelectSingleNode("./TotalAmountInHomeCurrency").InnerText);

        //                        }

        //                        //Get value of Memo
        //                        if (BillPaymentCheckRet.SelectSingleNode("./Memo") != null)
        //                        {
        //                            oPayment.PaymentMemo = BillPaymentCheckRet.SelectSingleNode("./Memo").InnerText;

        //                        }

        //                        XmlNode Address = BillPaymentCheckRet.SelectSingleNode("./Address");
        //                        if (Address != null)
        //                        {
        //                            //Get value of Addr1
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/Addr1") != null)
        //                            {
        //                                oPayment.PayeeAdd1 = BillPaymentCheckRet.SelectSingleNode("./Address/Addr1").InnerText;

        //                            }
        //                            //Get value of Addr2
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/Addr2") != null)
        //                            {
        //                                oPayment.PayeeAdd2 = BillPaymentCheckRet.SelectSingleNode("./Address/Addr2").InnerText;

        //                            }
        //                            //Get value of Addr3
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/Addr3") != null)
        //                            {
        //                                oPayment.PayeeAdd3 = BillPaymentCheckRet.SelectSingleNode("./Address/Addr3").InnerText;

        //                            }
        //                            //Get value of City
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/City") != null)
        //                            {
        //                                oPayment.PayeeCity = BillPaymentCheckRet.SelectSingleNode("./Address/City").InnerText;

        //                            }
        //                            //Get value of State
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/State") != null)
        //                            {
        //                                oPayment.PayeeState = BillPaymentCheckRet.SelectSingleNode("./Address/State").InnerText;

        //                            }
        //                            //Get value of PostalCode
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/PostalCode") != null)
        //                            {
        //                                oPayment.PayeePostalCode = BillPaymentCheckRet.SelectSingleNode("./Address/PostalCode").InnerText;

        //                            }
        //                            //Get value of Country
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/Country") != null)
        //                            {
        //                                oPayment.PayeeCountry = BillPaymentCheckRet.SelectSingleNode("./Address/Country").InnerText;

        //                            }
        //                            //Get value of Note
        //                            if (BillPaymentCheckRet.SelectSingleNode("./Address/Note") != null)
        //                            {
        //                                string Note = BillPaymentCheckRet.SelectSingleNode("./Address/Note").InnerText;

        //                            }

        //                        }
        //                        //Done with field values for Address aggregate


        //                        List<QBLinxDataService.MdlBillPaymentsDetail> lstDetail = new List<QBLinxDataService.MdlBillPaymentsDetail>();

        //                        XmlNodeList AppliedToTxnRetList = BillPaymentCheckRet.SelectNodes("./AppliedToTxnRet");
        //                        if (AppliedToTxnRetList != null)
        //                        {
        //                            for (int j = 0; j < AppliedToTxnRetList.Count; j++)
        //                            {
        //                                XmlNode AppliedToTxnRet = AppliedToTxnRetList.Item(j);

        //                                var paymentDetail = new QBLinxDataService.MdlBillPaymentsDetail();

        //                                //Get value of TxnID
        //                                paymentDetail.TxnID = AppliedToTxnRet.SelectSingleNode("./TxnID").InnerText;
        //                                //Get value of TxnType
        //                                paymentDetail.TxnType = AppliedToTxnRet.SelectSingleNode("./TxnType").InnerText;
        //                                //Get value of TxnDate
        //                                if (AppliedToTxnRet.SelectSingleNode("./TxnDate") != null)
        //                                {
        //                                    paymentDetail.TxnDate = Convert.ToDateTime(AppliedToTxnRet.SelectSingleNode("./TxnDate").InnerText);
        //                                }
        //                                //Get value of RefNumber
        //                                if (AppliedToTxnRet.SelectSingleNode("./RefNumber") != null)
        //                                {
        //                                    paymentDetail.RefNumber = AppliedToTxnRet.SelectSingleNode("./RefNumber").InnerText;
        //                                }
        //                                //Get value of BalanceRemaining
        //                                if (AppliedToTxnRet.SelectSingleNode("./BalanceRemaining") != null)
        //                                {
        //                                    paymentDetail.BalanceRemaining = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./BalanceRemaining").InnerText);
        //                                }
        //                                //Get value of Amount
        //                                if (AppliedToTxnRet.SelectSingleNode("./Amount") != null)
        //                                {
        //                                    paymentDetail.Amount = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./Amount").InnerText);
        //                                }
        //                                //Get value of DiscountAmount
        //                                if (AppliedToTxnRet.SelectSingleNode("./DiscountAmount") != null)
        //                                {
        //                                    paymentDetail.DiscountAmount = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./DiscountAmount").InnerText);
        //                                }
        //                                //Get all field values for DiscountAccountRef aggregate 
        //                                XmlNode DiscountAccountRef = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef");
        //                                if (DiscountAccountRef != null)
        //                                {
        //                                    //Get value of ListID
        //                                    if (AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/ListID") != null)
        //                                    {
        //                                        paymentDetail.DiscountAccountListID = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/ListID").InnerText;
        //                                    }
        //                                    //Get value of FullName
        //                                    if (AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/FullName") != null)
        //                                    {
        //                                        paymentDetail.DiscountAccountFullName = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/FullName").InnerText;
        //                                    }
        //                                }

        //                                lstDetail.Add(paymentDetail);
        //                            }
        //                        }

        //                        oPayment.BillPaymentsDetailLines = lstDetail.ToArray();

        //                        service.BillPaymentAddUpdate(oPayment);

        //                        bgWorker.ReportProgress(0, strLogDesc);
        //                        bgWorker.ReportProgress(0, "Exported to Server");
        //                        bgWorker.ReportProgress(0, "");

        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //        while (Convert.ToInt32(strRemaining) > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Payment Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

        public bool AddBillPaymentCheck(Data.dsQBSync.VendorPaymentHistoryRow paymentHistoryRow, System.ComponentModel.BackgroundWorker bgWorker)
        {
            bool blnResult = false;
            try
            {
                Data.dsQBSync ds = new Data.dsQBSync();
                ds.EnforceConstraints = false;
                Data.dsQBSyncTableAdapters.VendorPaymentTableAdapter taVendorPayment = new Data.dsQBSyncTableAdapters.VendorPaymentTableAdapter();
                Data.dsQBSyncTableAdapters.VendorPaymentHistoryTableAdapter taVendorPaymentHistory = new Data.dsQBSyncTableAdapters.VendorPaymentHistoryTableAdapter();

                taVendorPayment.FillByVendorPaymentID(ds.VendorPayment, paymentHistoryRow.PaymentID);
                if (ds.VendorPayment.Rows.Count == 0)
                {
                    bgWorker.ReportProgress(0, "Record not found for update!");
                    return false;
                }

                //bool isEdit = false; string editSequence = "";
                //if (!string.IsNullOrEmpty(txnId))
                //{
                //    editSequence = GetBillPaymentCheckEditSequence(txnId);
                //    if (!string.IsNullOrEmpty(editSequence))
                //    {
                //        isEdit = true;
                //    }
                //    else
                //    {
                //        bgWorker.ReportProgress(0, "Record not found in QuickBooks for update!");
                //        return false;
                //    }
                //}

                //if (paymentRow.BillPaymentsDetailLines == null || paymentRow.BillPaymentsDetailLines.Count() == 0)
                //{
                //    bgWorker.ReportProgress(0, "There is no detail row!");
                //    return false;
                //}

                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(parent);
                parent.SetAttribute("onError", "stopOnError");
                //Create BillPaymentCheckAddRq aggregate and fill in field values for it
                XmlElement BillPaymentCheckRq = doc.CreateElement("BillPaymentCheckAddRq");
                parent.AppendChild(BillPaymentCheckRq);
                //Create BillPaymentAdd aggregate and fill in field values for it
                XmlElement BillPaymentCheckAdd = doc.CreateElement("BillPaymentCheckAdd");
                BillPaymentCheckRq.AppendChild(BillPaymentCheckAdd);

                String PayeeFullName = paymentHistoryRow.VendorName;
                PayeeFullName = Common.Truncate(PayeeFullName.Trim(), 41);

                //if (isEdit)
                //{
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
                //    //Set field value for EditSequence <!-- required -->
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));

                //    //Set field value for TxnDate <!-- optional -->
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", paymentRow.TxnDate.ToString("yyyy-MM-dd")));

                //    if (!string.IsNullOrEmpty(paymentRow.BankAccountFullName))
                //    {
                //        XmlElement BankAccountRef = doc.CreateElement("BankAccountRef");
                //        BillPaymentCheckAdd.AppendChild(BankAccountRef);
                //        BankAccountRef.AppendChild(MakeSimpleElem(doc, "FullName", paymentRow.BankAccountFullName));
                //    }

                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "Amount", paymentRow.Amount.ToString("###0.00")));

                //    //Set field value for ExchangeRate <!-- optional -->
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", paymentRow.CurrencyRate.ToString("###0.00")));
                //}
                //else
                //{
                //Create PayeeRef aggregate and fill in field values for it
                XmlElement PayeeRef = doc.CreateElement("PayeeEntityRef");
                BillPaymentCheckAdd.AppendChild(PayeeRef);
                //Set field value for ListID <!-- optional -->
                PayeeRef.AppendChild(MakeSimpleElem(doc, "ListID", paymentHistoryRow.VendorListID));
                PayeeRef.AppendChild(MakeSimpleElem(doc, "FullName", PayeeFullName));

                //if (!string.IsNullOrEmpty(paymentHistoryRow.APAccount))
                //{
                //XmlElement ARAccountRef = doc.CreateElement("APAccountRef");
                //BillPaymentCheckAdd.AppendChild(ARAccountRef);
                //ARAccountRef.AppendChild(MakeSimpleElem(doc, "FullName", "Company Bank"));
                //}

                XmlElement BankAccountRef = doc.CreateElement("BankAccountRef");
                BillPaymentCheckAdd.AppendChild(BankAccountRef);
                BankAccountRef.AppendChild(MakeSimpleElem(doc, "FullName", "Company Bank"));

                //Set field value for TxnDate <!-- optional -->
                //BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", paymentRow.TxnDate.ToString("yyyy-MM-dd")));

                //if (!string.IsNullOrEmpty(paymentRow.BankAccountFullName))
                //{
                //    XmlElement BankAccountRef = doc.CreateElement("BankAccountRef");
                //    BillPaymentCheckAdd.AppendChild(BankAccountRef);
                //    BankAccountRef.AppendChild(MakeSimpleElem(doc, "FullName", paymentRow.BankAccountFullName));
                //}
                //}

                //Set field value for RefNumber <!-- optional -->
                if (!string.IsNullOrEmpty(paymentHistoryRow.InvoiceNo))
                    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", paymentHistoryRow.InvoiceNo));
                else
                    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "IsToBePrinted", "1"));

                //if (!string.IsNullOrEmpty(paymentRow.PaymentMemo))
                //{
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "Memo", paymentRow.PaymentMemo));
                //}

                //if (isEdit == false)
                //{
                //    //Set field value for ExchangeRate <!-- optional -->
                //    BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", paymentRow.CurrencyRate.ToString("###0.00")));
                //}

                //if (Common.BranchID == 1)
                //{
                foreach (Data.dsQBSync.VendorPaymentRow detailRow in ds.VendorPayment)
                {
                    Invoices objInvoice = new Invoices();
                    //double dblBalanceRemaining = 1; // objInvoice.GetInvoiceBalanceRemaining(detailRow.HOInvoiceTxnID);

                    string BillListID = detailRow.IsBillListIDNull() ? "" : detailRow.BillListID;
                    decimal BillPaidAmount = detailRow.PaidAmount;
                    //if (!string.IsNullOrEmpty(detailRow.lis))
                    //{
                    BillPaymentCheckAdd.AppendChild(AddBillPaymentCheckLine(doc, BillListID, BillPaidAmount));
                    //}
                }
                //}
                //else
                //{
                //    if (isEdit == false)
                //    {
                //        //BillPaymentCheckAdd.AppendChild(MakeSimpleElem(doc, "IsAutoApply", "1"));
                //    }
                //}

                string strRequest = doc.OuterXml;
                string strResponse = "";
                try
                {
                    strResponse = QBConnection.ProcessRequest(strRequest);
                }
                catch (Exception ex)
                {

                }
                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                XmlNodeList BillPaymentCheckAddRsList = responseXmlDoc.GetElementsByTagName("BillPaymentCheckAddRs");
                if (BillPaymentCheckAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = BillPaymentCheckAddRsList.Item(0);
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
                            if (statusMessage.Contains("There is an invalid reference to QuickBooks Payee"))
                            {
                                //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Payee");
                                //Customers objCustomer = new Customers();
                                //if (!string.IsNullOrEmpty(objCustomer.QBAddCusomter(PayeeFullName)))
                                //{
                                //    blnResult = AddBillPaymentCheck(paymentRow, txnId, bgWorker);
                                //}
                                //else
                                //{
                                //    bgWorker.ReportProgress(0, statusMessage);
                                //    return false;
                                //}
                            }
                            else
                            {
                                bgWorker.ReportProgress(0, "Error! " + ("Adding ") + paymentHistoryRow.InvoiceNo + " in BillPayment");
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                            }
                        }
                        else if (statusCode == "0")
                        {
                            XmlNodeList BillPaymentCheckRetList = responseNode.SelectNodes("//BillPaymentCheckRet");//XPath Query
                            for (int i = 0; i < BillPaymentCheckRetList.Count; i++)
                            {
                                XmlNode BillPaymentCheckRet = BillPaymentCheckRetList.Item(i);
                                string newTxnId = BillPaymentCheckRet.SelectSingleNode("./TxnID").InnerText;

                                var TimeCreated = Convert.ToDateTime(BillPaymentCheckRet.SelectSingleNode("./TimeCreated").InnerText);
                                var TimeModified = Convert.ToDateTime(BillPaymentCheckRet.SelectSingleNode("./TimeModified").InnerText);

                                taVendorPaymentHistory.UpdateQBFields(newTxnId, TimeModified, paymentHistoryRow.ID);


                                bgWorker.ReportProgress(0, "Payment " + paymentHistoryRow.InvoiceNo + (" added") + " successfully");
                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + paymentHistoryRow.InvoiceNo + (" Adding") + " in Payment");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bgWorker.ReportProgress(0, "Error! Adding/Updating in Payment " + paymentHistoryRow.InvoiceNo);
                bgWorker.ReportProgress(0, ex.Message);
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            }

            return blnResult;
        }

        private XmlElement AddBillPaymentCheckLine(XmlDocument inputXMLDoc, string BillListID, decimal PaidAmount)
        {

            //Create InvoiceLineAdd aggregate and fill in field values for it
            XmlElement PaymentLine = inputXMLDoc.CreateElement("AppliedToTxnAdd");

            //if (AppliedToTxnAddMod == "AppliedToTxnMod")
            //    PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

            PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", BillListID));

            //Set field value for PaymentAmount <!-- optional -->
            PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "PaymentAmount", PaidAmount.ToString("###0.00")));

            return PaymentLine;
        }

        //public String GetBillPaymentCheckEditSequence(String TxnID)
        //{
        //    String strResult = "";
        //    try
        //    {
        //        XmlDocument inputXMLDoc = new XmlDocument();
        //        inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
        //        inputXMLDoc.AppendChild(qbXML);
        //        XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(qbXMLMsgsRq);
        //        qbXMLMsgsRq.SetAttribute("onError", "stopOnError");

        //        //Create CustomerModRq  aggregate and fill in field values for it
        //        XmlElement BillPaymentCheckQueryRq = inputXMLDoc.CreateElement("BillPaymentCheckQueryRq");
        //        qbXMLMsgsRq.AppendChild(BillPaymentCheckQueryRq);
        //        //custRq.SetAttribute("requestID", "1");

        //        //Set field value for FullName <!-- optional, may repeat -->              
        //        BillPaymentCheckQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
        //        BillPaymentCheckQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
        //        BillPaymentCheckQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

        //        string strRequest = inputXMLDoc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList BillPaymentCheckQueryRsList = responseXmlDoc.GetElementsByTagName("BillPaymentCheckQueryRs");
        //        if (BillPaymentCheckQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = BillPaymentCheckQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                XmlNodeList BillPaymentCheckRetList = responseNode.SelectNodes("//BillPaymentCheckRet");//XPath Query
        //                for (int i = 0; i < BillPaymentCheckRetList.Count; i++)
        //                {
        //                    XmlNode BillPaymentCheckRet = BillPaymentCheckRetList.Item(i);

        //                    //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
        //                    //Get value of EditSequence
        //                    strResult = BillPaymentCheckRet.SelectSingleNode("./EditSequence").InnerText;

        //                    return strResult;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return strResult;
        //}

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

    }
}
