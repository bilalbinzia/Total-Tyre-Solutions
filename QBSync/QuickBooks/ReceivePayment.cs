using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class ReceivePayments
    {
        //public void ReceivePaymentQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
        //            XmlElement ReceivePaymentQueryRq = doc.CreateElement("ReceivePaymentQueryRq");
        //            qbXMLMsgsRq.AppendChild(ReceivePaymentQueryRq);
        //            ReceivePaymentQueryRq.SetAttribute("requestID", "1");

        //            if (!String.IsNullOrEmpty(strIterator))
        //                ReceivePaymentQueryRq.SetAttribute("iterator", strIterator);
        //            if (!String.IsNullOrEmpty(strIteratorID))
        //                ReceivePaymentQueryRq.SetAttribute("iteratorID", strIteratorID);

        //            ReceivePaymentQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

        //            //Create ModifiedDateRangeFilter aggregate and fill in field values for it
        //            XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
        //            ReceivePaymentQueryRq.AppendChild(ModifiedDateRangeFilter);
        //            //Set field value for FromModifiedDate <!-- optional -->
        //            ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
        //            //Set field value for ToModifiedDate <!-- optional -->
        //            if (Common.UseQBQueryToDate)
        //                ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
        //            //Done creating ModifiedDateRangeFilter aggregate

        //            ReceivePaymentQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

        //            strRemaining = "0";

        //            string strRequest = doc.OuterXml;
        //            string strResponse = QBConnection.ProcessRequest(strRequest);

        //            //Parse the response XML string into an XmlDocument
        //            XmlDocument responseXmlDoc = new XmlDocument();
        //            responseXmlDoc.LoadXml(strResponse);

        //            //Get the response for our request             
        //            XmlNodeList ReceivePaymentQueryRsList = responseXmlDoc.GetElementsByTagName("ReceivePaymentQueryRs");
        //            if (ReceivePaymentQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //            {
        //                XmlNode responseNode = ReceivePaymentQueryRsList.Item(0);
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
        //                    XmlNodeList ReceivePaymentRetList = responseNode.SelectNodes("//ReceivePaymentRet");//XPath Query

        //                    QBLinxWebService service = new QBLinxWebService();

        //                    for (int i = 0; i < ReceivePaymentRetList.Count; i++)
        //                    {
        //                        XmlNode ReceivePaymentRet = ReceivePaymentRetList.Item(i);

        //                        if (ReceivePaymentRet == null) continue;

        //                        var oPayment = new QBLinxDataService.MdlReceivePayments();
        //                        string strLogDesc = "";

        //                        string TxnID = ReceivePaymentRet.SelectSingleNode("./TxnID").InnerText;

        //                        oPayment.ReceivePaymentID = -1;
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
        //                        oPayment.TimeCreated = Convert.ToDateTime(ReceivePaymentRet.SelectSingleNode("./TimeCreated").InnerText);
        //                        oPayment.TimeModified = Convert.ToDateTime(ReceivePaymentRet.SelectSingleNode("./TimeModified").InnerText);

        //                        if (ReceivePaymentRet.SelectSingleNode("./CustomerRef/ListID") != null)
        //                        {
        //                            oPayment.CustomerListID = ReceivePaymentRet.SelectSingleNode("./CustomerRef/ListID").InnerText;

        //                        }
        //                        //Get value of FullName
        //                        if (ReceivePaymentRet.SelectSingleNode("./CustomerRef/FullName") != null)
        //                        {
        //                            oPayment.CustomerFullName = ReceivePaymentRet.SelectSingleNode("./CustomerRef/FullName").InnerText;

        //                        }
        //                        XmlNode ARAccountRef = ReceivePaymentRet.SelectSingleNode("./ARAccountRef");
        //                        if (ARAccountRef != null)
        //                        {
        //                            if (ReceivePaymentRet.SelectSingleNode("./ARAccountRef/FullName") != null)
        //                            {
        //                                oPayment.AccountName = ReceivePaymentRet.SelectSingleNode("./ARAccountRef/FullName").InnerText;
        //                            }
        //                        }
        //                        oPayment.TxnDate = Convert.ToDateTime(ReceivePaymentRet.SelectSingleNode("./TxnDate").InnerText);
        //                        //Get value of RefNumber
        //                        if (ReceivePaymentRet.SelectSingleNode("./TotalAmount") != null)
        //                        {
        //                            oPayment.TotalAmount = Convert.ToDouble(ReceivePaymentRet.SelectSingleNode("./TotalAmount").InnerText);
        //                            strLogDesc = "Payment Amt. " + oPayment.TotalAmount.ToString();
        //                        }

        //                        if (ReceivePaymentRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            oPayment.RefNumber = ReceivePaymentRet.SelectSingleNode("./RefNumber").InnerText;
        //                            strLogDesc += " Ref# " + oPayment.RefNumber;
        //                        }

        //                        strLogDesc += " Date. " + ReceivePaymentRet.SelectSingleNode("./TxnDate").InnerText;

        //                        //Get all field values for CurrencyRef aggregate 
        //                        XmlNode CurrencyRef = ReceivePaymentRet.SelectSingleNode("./CurrencyRef");
        //                        if (CurrencyRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (ReceivePaymentRet.SelectSingleNode("./CurrencyRef/FullName") != null)
        //                            {
        //                                oPayment.Currency = ReceivePaymentRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
        //                            }
        //                        }

        //                        if (ReceivePaymentRet.SelectSingleNode("./ExchangeRate") != null)
        //                        {
        //                            oPayment.CurrencyRate = Convert.ToDouble(ReceivePaymentRet.SelectSingleNode("./ExchangeRate").InnerText);
        //                        }

        //                        if (ReceivePaymentRet.SelectSingleNode("./TotalAmountInHomeCurrency") != null)
        //                        {
        //                            oPayment.TotalAmountInHomeCurrency = Convert.ToDouble(ReceivePaymentRet.SelectSingleNode("./TotalAmountInHomeCurrency").InnerText);

        //                        }
        //                        //Get all field values for PaymentMethodRef aggregate 
        //                        XmlNode PaymentMethodRef = ReceivePaymentRet.SelectSingleNode("./PaymentMethodRef");
        //                        if (PaymentMethodRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (ReceivePaymentRet.SelectSingleNode("./PaymentMethodRef/FullName") != null)
        //                            {
        //                                oPayment.PaymentMethod = ReceivePaymentRet.SelectSingleNode("./PaymentMethodRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for PaymentMethodRef aggregate

        //                        //Get value of Memo
        //                        if (ReceivePaymentRet.SelectSingleNode("./Memo") != null)
        //                        {
        //                            oPayment.PaymentMemo = ReceivePaymentRet.SelectSingleNode("./Memo").InnerText;

        //                        }


        //                        //oInvoice.InvoiceDetailLines = new QBInvoiceManager.QBIMService.InvoiceDetail();

        //                        List<QBLinxDataService.MdlReceivePaymentsDetail> lstDetail = new List<QBLinxDataService.MdlReceivePaymentsDetail>();

        //                        XmlNodeList AppliedToTxnRetList = ReceivePaymentRet.SelectNodes("./AppliedToTxnRet");
        //                        if (AppliedToTxnRetList != null)
        //                        {
        //                            for (int j = 0; j < AppliedToTxnRetList.Count; j++)
        //                            {
        //                                XmlNode AppliedToTxnRet = AppliedToTxnRetList.Item(j);

        //                                var paymentDetail = new QBLinxDataService.MdlReceivePaymentsDetail();

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

        //                        oPayment.ReceivePaymentsDetailLines = lstDetail.ToArray();

        //                        service.ReceivePaymentAddUpdate(oPayment);

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

        public bool AddReceivePayment(Data.dsQBSync.CustomerReceiptRow paymentRow, string txnId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            bool blnResult = false;
            Data.dsQBSync ds = new Data.dsQBSync();
            ds.EnforceConstraints = false;
            Data.dsQBSyncTableAdapters.WorkOrderTableAdapter taWorkorder = new Data.dsQBSyncTableAdapters.WorkOrderTableAdapter();
            Data.dsQBSyncTableAdapters.CustomerReceiptTableAdapter taCustomerReceipt = new Data.dsQBSyncTableAdapters.CustomerReceiptTableAdapter();
            try
            {
                bool isEdit = false; string editSequence = "";
                if (!string.IsNullOrEmpty(txnId))
                {
                    editSequence = GetReceivePaymentEditSequence(txnId);
                    if (!string.IsNullOrEmpty(editSequence))
                    {
                        isEdit = true;
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Record not found in QuickBooks for update!");
                        return false;
                    }
                }

                taWorkorder.FillByCustomerReceiptID(ds.WorkOrder, paymentRow.ID);
                if (ds.WorkOrder.Rows.Count == 0)
                {
                    bgWorker.ReportProgress(0, "Record not found for update!");
                    return false;
                }

                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
                XmlElement qbXML = doc.CreateElement("QBXML");
                doc.AppendChild(qbXML);
                XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
                qbXML.AppendChild(parent);
                parent.SetAttribute("onError", "stopOnError");
                //Create ReceivePaymentAddRq aggregate and fill in field values for it
                XmlElement ReceivePaymentAddRq = doc.CreateElement(isEdit ? "ReceivePaymentModRq" : "ReceivePaymentAddRq");
                parent.AppendChild(ReceivePaymentAddRq);
                //Create ReceivePaymentAdd aggregate and fill in field values for it
                XmlElement ReceivePaymentAdd = doc.CreateElement(isEdit ? "ReceivePaymentMod" : "ReceivePaymentAdd");
                ReceivePaymentAddRq.AppendChild(ReceivePaymentAdd);

                if (isEdit)
                {
                    ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
                    //Set field value for EditSequence <!-- required -->
                    ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
                }

                //String CustomerFullName = paymentRow.CustomerFullName;
                //CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
                //Create CustomerRef aggregate and fill in field values for it
                XmlElement CustomerRef = doc.CreateElement("CustomerRef");
                ReceivePaymentAdd.AppendChild(CustomerRef);
                //Set field value for ListID <!-- optional -->
                CustomerRef.AppendChild(MakeSimpleElem(doc, "ListID", paymentRow.CustomerListID));

                //if (!string.IsNullOrEmpty(paymentRow.AccountName))
                //{
                //    XmlElement ARAccountRef = doc.CreateElement("ARAccountRef");
                //    ReceivePaymentAdd.AppendChild(ARAccountRef);
                //    ARAccountRef.AppendChild(MakeSimpleElem(doc, "FullName", paymentRow.AccountName));
                //}

                //Set field value for TxnDate <!-- optional -->
                ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", paymentRow.TrnsDate.ToString("yyyy-MM-dd")));
                //Set field value for RefNumber <!-- optional -->
                if (!paymentRow.IsInvoiceNoNull())
                    ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", paymentRow.InvoiceNo));

                //Set field value for TotalAmount <!-- optional -->
                ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "TotalAmount", paymentRow.TotalReceivedAmount.ToString("###0.00")));

                //Set field value for ExchangeRate <!-- optional -->
                //ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", paymentRow.CurrencyRate.ToString("###0.00")));


                //if (!String.IsNullOrEmpty(paymentRow.PaymentMethod))
                //{
                XmlElement PaymentMethodRef = doc.CreateElement("PaymentMethodRef");
                ReceivePaymentAdd.AppendChild(PaymentMethodRef);
                PaymentMethodRef.AppendChild(MakeSimpleElem(doc, "FullName", "Cash"));  //paymentRow.PaymentMethod
                                                                                        // }

                //if (!string.IsNullOrEmpty(paymentRow.PaymentMemo))
                //{
                //    ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "Memo", paymentRow.PaymentMemo));
                //}


                //if (Common.BranchID == 1)
                //{
                foreach (Data.dsQBSync.WorkOrderRow detailRow in ds.WorkOrder)
                {
                    Invoices objInvoice = new Invoices();
                    double dblBalanceRemaining = 1; // objInvoice.GetInvoiceBalanceRemaining(detailRow.HOInvoiceTxnID);
                    if (detailRow.IsListIDNull())
                    {
                        detailRow.ListID = "";
                    }
                    ReceivePaymentAdd.AppendChild(AddReceivePaymentLine(doc, isEdit ? "AppliedToTxnMod" : "AppliedToTxnAdd", detailRow, dblBalanceRemaining));
                }
                //}
                //else
                //{
                //    if (isEdit == false)
                //    {
                //        ReceivePaymentAdd.AppendChild(MakeSimpleElem(doc, "IsAutoApply", "1"));
                //    }
                //}

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                XmlNodeList ReceivePaymentAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "ReceivePaymentModRs" : "ReceivePaymentAddRs");
                if (ReceivePaymentAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ReceivePaymentAddRsList.Item(0);
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
                                //if (!string.IsNullOrEmpty(objCustomer.QBAddCusomter(CustomerFullName)))
                                //{
                                //    blnResult = AddReceivePayment(paymentRow, txnId, bgWorker);
                                //}
                                //else
                                //{
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                                //}
                            }
                            else
                            {
                                bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in ReceivePayment");
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                            }
                        }
                        else if (statusCode == "0")
                        {
                            XmlNodeList ReceivePaymentRetList = responseNode.SelectNodes("//ReceivePaymentRet");//XPath Query
                            for (int i = 0; i < ReceivePaymentRetList.Count; i++)
                            {
                                XmlNode ReceivePaymentRet = ReceivePaymentRetList.Item(i);
                                string newTxnId = ReceivePaymentRet.SelectSingleNode("./TxnID").InnerText;
                                var TimeModified = Convert.ToDateTime(ReceivePaymentRet.SelectSingleNode("./TimeModified").InnerText);

                                string NewRefNumber = "";
                                if (ReceivePaymentRet.SelectSingleNode("./RefNumber") != null)
                                {
                                    NewRefNumber = ReceivePaymentRet.SelectSingleNode("./RefNumber").InnerText;
                                }

                                taCustomerReceipt.UpdateQBFields(newTxnId, TimeModified, paymentRow.ID);

                                //string CustomerListID = "";
                                //if (ReceivePaymentRet.SelectSingleNode("./CustomerRef/ListID") != null)
                                //{
                                //    CustomerListID = ReceivePaymentRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
                                //}

                                //List<QBLinxDataService.MdlReceivePaymentsDetail> lstDetail = new List<QBLinxDataService.MdlReceivePaymentsDetail>();

                                //XmlNodeList AppliedToTxnRetList = ReceivePaymentRet.SelectNodes("./AppliedToTxnRet");
                                //if (AppliedToTxnRetList != null)
                                //{
                                //    for (int j = 0; j < AppliedToTxnRetList.Count; j++)
                                //    {
                                //        XmlNode AppliedToTxnRet = AppliedToTxnRetList.Item(j);

                                //        //var paymentDetail = new QBLinxDataService.MdlReceivePaymentsDetail();
                                //        paymentDetail.ReceivePaymentID = paymentRow.ReceivePaymentID;

                                //        //Get value of TxnID
                                //        paymentDetail.TxnID = AppliedToTxnRet.SelectSingleNode("./TxnID").InnerText;
                                //        //Get value of TxnType
                                //        paymentDetail.TxnType = AppliedToTxnRet.SelectSingleNode("./TxnType").InnerText;
                                //        //Get value of TxnDate
                                //        if (AppliedToTxnRet.SelectSingleNode("./TxnDate") != null)
                                //        {
                                //            paymentDetail.TxnDate = Convert.ToDateTime(AppliedToTxnRet.SelectSingleNode("./TxnDate").InnerText);
                                //        }
                                //        //Get value of RefNumber
                                //        if (AppliedToTxnRet.SelectSingleNode("./RefNumber") != null)
                                //        {
                                //            paymentDetail.RefNumber = AppliedToTxnRet.SelectSingleNode("./RefNumber").InnerText;
                                //        }
                                //        //Get value of BalanceRemaining
                                //        if (AppliedToTxnRet.SelectSingleNode("./BalanceRemaining") != null)
                                //        {
                                //            paymentDetail.BalanceRemaining = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./BalanceRemaining").InnerText);
                                //        }
                                //        //Get value of Amount
                                //        if (AppliedToTxnRet.SelectSingleNode("./Amount") != null)
                                //        {
                                //            paymentDetail.Amount = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./Amount").InnerText);
                                //        }
                                //        //Get value of DiscountAmount
                                //        if (AppliedToTxnRet.SelectSingleNode("./DiscountAmount") != null)
                                //        {
                                //            paymentDetail.DiscountAmount = Convert.ToDouble(AppliedToTxnRet.SelectSingleNode("./DiscountAmount").InnerText);
                                //        }
                                //        //Get all field values for DiscountAccountRef aggregate 
                                //        XmlNode DiscountAccountRef = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef");
                                //        if (DiscountAccountRef != null)
                                //        {
                                //            //Get value of ListID
                                //            if (AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/ListID") != null)
                                //            {
                                //                paymentDetail.DiscountAccountListID = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/ListID").InnerText;
                                //            }
                                //            //Get value of FullName
                                //            if (AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/FullName") != null)
                                //            {
                                //                paymentDetail.DiscountAccountFullName = AppliedToTxnRet.SelectSingleNode("./DiscountAccountRef/FullName").InnerText;
                                //            }
                                //        }

                                //        lstDetail.Add(paymentDetail);
                                //    }
                                //}

                                ////Customers objCustomer = new Customers();
                                ////var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

                                //using (QBLinxWebService service = new QBLinxWebService())
                                //{
                                //    string sysNotes = "";

                                //    // if (Common.BranchID == 1) sysNotes = System.Environment.NewLine + "Exported to QuickBooks HeadOffice " + DateTime.Now;
                                //    // else sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;

                                //    var item = service.UpdateReceivePaymentQBInfo(Common.BranchID, paymentRow.ReceivePaymentID, true, newTxnId, lstDetail.ToArray());
                                //}

                                bgWorker.ReportProgress(0, "Payment " + (isEdit ? "updated" : "added") + " successfully");
                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Payment");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bgWorker.ReportProgress(0, "Error! Adding/Updating in Payment");
                bgWorker.ReportProgress(0, ex.Message);
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            }

            return blnResult;
        }

        private XmlElement AddReceivePaymentLine(XmlDocument inputXMLDoc, string AppliedToTxnAddMod, Data.dsQBSync.WorkOrderRow detailRow, double dblBalanceRemaining)
        {

            //Create InvoiceLineAdd aggregate and fill in field values for it
            XmlElement PaymentLine = inputXMLDoc.CreateElement(AppliedToTxnAddMod);

            //if (AppliedToTxnAddMod == "AppliedToTxnMod")
            //    PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

            PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", detailRow.ListID));

            //Set field value for PaymentAmount <!-- optional -->

            PaymentLine.AppendChild(MakeSimpleElem(inputXMLDoc, "PaymentAmount", detailRow.Total.ToString("###0.00")));

            return PaymentLine;
        }

        public String GetReceivePaymentEditSequence(String TxnID)
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
                XmlElement ReceivePaymentQueryRq = inputXMLDoc.CreateElement("ReceivePaymentQueryRq");
                qbXMLMsgsRq.AppendChild(ReceivePaymentQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                ReceivePaymentQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                ReceivePaymentQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                ReceivePaymentQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList ReceivePaymentQueryRsList = responseXmlDoc.GetElementsByTagName("ReceivePaymentQueryRs");
                if (ReceivePaymentQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ReceivePaymentQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList ReceivePaymentRetList = responseNode.SelectNodes("//ReceivePaymentRet");//XPath Query
                        for (int i = 0; i < ReceivePaymentRetList.Count; i++)
                        {
                            XmlNode ReceivePaymentRet = ReceivePaymentRetList.Item(i);
                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = ReceivePaymentRet.SelectSingleNode("./EditSequence").InnerText;

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

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

    }
}
