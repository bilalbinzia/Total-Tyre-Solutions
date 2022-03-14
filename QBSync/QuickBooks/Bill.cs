using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class Bill
    {

        //public void BillQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
        //            XmlElement BillQueryRq = doc.CreateElement("BillQueryRq");
        //            qbXMLMsgsRq.AppendChild(BillQueryRq);
        //            BillQueryRq.SetAttribute("requestID", "1");

        //            if (!String.IsNullOrEmpty(strIterator))
        //                BillQueryRq.SetAttribute("iterator", strIterator);
        //            if (!String.IsNullOrEmpty(strIteratorID))
        //                BillQueryRq.SetAttribute("iteratorID", strIteratorID);

        //            BillQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

        //            //Create ModifiedDateRangeFilter aggregate and fill in field values for it
        //            XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
        //            BillQueryRq.AppendChild(ModifiedDateRangeFilter);
        //            //Set field value for FromModifiedDate <!-- optional -->
        //            ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
        //            //Set field value for ToModifiedDate <!-- optional -->
        //            if (Common.UseQBQueryToDate)
        //                ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
        //            //Done creating ModifiedDateRangeFilter aggregate

        //            BillQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

        //            strRemaining = "0";

        //            string strRequest = doc.OuterXml;
        //            string strResponse = QBConnection.ProcessRequest(strRequest);

        //            //Parse the response XML string into an XmlDocument
        //            XmlDocument responseXmlDoc = new XmlDocument();
        //            responseXmlDoc.LoadXml(strResponse);

        //            //Get the response for our request             
        //            XmlNodeList BillQueryRsList = responseXmlDoc.GetElementsByTagName("BillQueryRs");
        //            if (BillQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //            {
        //                XmlNode responseNode = BillQueryRsList.Item(0);
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
        //                    XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query

        //                    QBLinxWebService service = new QBLinxWebService();

        //                    for (int i = 0; i < BillRetList.Count; i++)
        //                    {
        //                        XmlNode BillRet = BillRetList.Item(i);

        //                        if (BillRet == null) continue;

        //                        var oBill = new QBLinxDataService.MdlBill();

        //                        string TxnID = BillRet.SelectSingleNode("./TxnID").InnerText;

        //                        oBill.BillID = -1;
        //                        oBill.BranchID = Common.BranchID;
        //                        oBill.BillStatus = 1;
        //                        if (Common.BranchID == 1)
        //                        {
        //                            oBill.HOSync = true;
        //                            oBill.TxnID = TxnID;
        //                            oBill.SystemNotes = "Exported to Cloud From Head Office On: " + System.DateTime.Now;
        //                        }
        //                        else
        //                        {
        //                            oBill.BRSync = true;
        //                            oBill.BRTxnID = TxnID;
        //                            oBill.SystemNotes = "Exported to Cloud From Branch On: " + System.DateTime.Now;
        //                        }

        //                        //oBill.UtcOffset = Common.LoginUser.UtcOffset;
        //                        oBill.TimeCreated = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeCreated").InnerText);
        //                        oBill.TimeModified = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeModified").InnerText);

        //                        if (BillRet.SelectSingleNode("./VendorRef/ListID") != null)
        //                        {
        //                            oBill.VendorListID = BillRet.SelectSingleNode("./VendorRef/ListID").InnerText;

        //                        }
        //                        //Get value of FullName
        //                        if (BillRet.SelectSingleNode("./VendorRef/FullName") != null)
        //                        {
        //                            oBill.VendorFullName = BillRet.SelectSingleNode("./VendorRef/FullName").InnerText;

        //                        }

        //                        oBill.TxnDate = Convert.ToDateTime(BillRet.SelectSingleNode("./TxnDate").InnerText);
        //                        //Get value of RefNumber
        //                        if (BillRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            oBill.RefNumber = BillRet.SelectSingleNode("./RefNumber").InnerText;

        //                        }
        //                        //Get all field values for BillAddress aggregate 
        //                        XmlNode VendorAddress = BillRet.SelectSingleNode("./VendorAddress");
        //                        if (VendorAddress != null)
        //                        {
        //                            //Get value of Addr1
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr1") != null)
        //                            {
        //                                oBill.VendorAdd1 = BillRet.SelectSingleNode("./VendorAddress/Addr1").InnerText;

        //                            }
        //                            //Get value of Addr2
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr2") != null)
        //                            {
        //                                oBill.VendorAdd2 = BillRet.SelectSingleNode("./VendorAddress/Addr2").InnerText;

        //                            }
        //                            //Get value of Addr3
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr3") != null)
        //                            {
        //                                oBill.VendorAdd3 = BillRet.SelectSingleNode("./VendorAddress/Addr3").InnerText;

        //                            }
        //                            //Get value of City
        //                            if (BillRet.SelectSingleNode("./VendorAddress/City") != null)
        //                            {
        //                                oBill.VendorCity = BillRet.SelectSingleNode("./VendorAddress/City").InnerText;

        //                            }
        //                            //Get value of State
        //                            if (BillRet.SelectSingleNode("./VendorAddress/State") != null)
        //                            {
        //                                oBill.VendorState = BillRet.SelectSingleNode("./VendorAddress/State").InnerText;

        //                            }
        //                            //Get value of PostalCode
        //                            if (BillRet.SelectSingleNode("./VendorAddress/PostalCode") != null)
        //                            {
        //                                oBill.VendorPostalCode = BillRet.SelectSingleNode("./VendorAddress/PostalCode").InnerText;

        //                            }
        //                            //Get value of Country
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Country") != null)
        //                            {
        //                                oBill.VendorCountry = BillRet.SelectSingleNode("./VendorAddress/Country").InnerText;

        //                            }
        //                        }

        //                        //Get all field values for TermsRef aggregate 
        //                        XmlNode TermsRef = BillRet.SelectSingleNode("./TermsRef");
        //                        if (TermsRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./TermsRef/FullName") != null)
        //                            {
        //                                oBill.Terms = BillRet.SelectSingleNode("./TermsRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for TermsRef aggregate

        //                        //Get value of DueDate
        //                        if (BillRet.SelectSingleNode("./DueDate") != null)
        //                        {
        //                            oBill.DueDate = Convert.ToDateTime(BillRet.SelectSingleNode("./DueDate").InnerText);

        //                        }


        //                        if (BillRet.SelectSingleNode("./AmountDue") != null)
        //                        {
        //                            oBill.AmountDue = Convert.ToDouble(BillRet.SelectSingleNode("./AmountDue").InnerText);

        //                        }

        //                        if (BillRet.SelectSingleNode("./Memo") != null)
        //                        {
        //                            oBill.BillMemo = BillRet.SelectSingleNode("./Memo").InnerText;
        //                        }

        //                        //Get all field values for CurrencyRef aggregate 
        //                        XmlNode CurrencyRef = BillRet.SelectSingleNode("./CurrencyRef");
        //                        if (CurrencyRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./CurrencyRef/FullName") != null)
        //                            {
        //                                oBill.Currency = BillRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for CurrencyRef aggregate

        //                        if (BillRet.SelectSingleNode("./ExchangeRate") != null)
        //                        {
        //                            oBill.CurrencyRate = Convert.ToDouble(BillRet.SelectSingleNode("./ExchangeRate").InnerText);
        //                        }

        //                        if (BillRet.SelectSingleNode("./AmountDueInHomeCurrency") != null)
        //                        {
        //                            string AmountDueInHomeCurrency = BillRet.SelectSingleNode("./AmountDueInHomeCurrency").InnerText;

        //                        }

        //                        //Get all field values for SalesTaxCodeRef aggregate 
        //                        XmlNode SalesTaxCodeRef = BillRet.SelectSingleNode("./SalesTaxCodeRef");
        //                        if (SalesTaxCodeRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                            {
        //                                oBill.SalesTaxCode = BillRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;

        //                            }
        //                        }
        //                        //Done with field values for SalesTaxCodeRef aggregate

        //                        //Get value of IsPaid
        //                        if (BillRet.SelectSingleNode("./IsPaid") != null)
        //                        {
        //                            oBill.IsPaid = Convert.ToBoolean(BillRet.SelectSingleNode("./IsPaid").InnerText);
        //                        }

        //                        if (BillRet.SelectSingleNode("./OpenAmount") != null)
        //                        {
        //                            oBill.OpenAmount = Convert.ToDouble(BillRet.SelectSingleNode("./OpenAmount").InnerText);
        //                        }

        //                        //oBill.BillDetailLines = new QBBillManager.QBIMService.BillDetail();

        //                        List<QBLinxDataService.MdlBillDetail> lstDetail = new List<QBLinxDataService.MdlBillDetail>();

        //                        XmlNodeList ExpenseLineRetListChildren = BillRet.SelectNodes("./ExpenseLineRet");
        //                        for (int j = 0; j < ExpenseLineRetListChildren.Count; j++)
        //                        {
        //                            XmlNode Child = ExpenseLineRetListChildren.Item(j);
        //                            if (Child.Name == "ExpenseLineRet")
        //                            {
        //                                var rowBillDetail = new QBLinxDataService.MdlBillDetail();

        //                                rowBillDetail.TxnID = TxnID;
        //                                rowBillDetail.BillID = oBill.BillID;
        //                                rowBillDetail.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
        //                                rowBillDetail.DetailLineType = "ExpenseLine";

        //                                if (Child.SelectSingleNode("./AccountRef") != null && Child.SelectSingleNode("./AccountRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.AccountListID = Child.SelectSingleNode("./AccountRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./AccountRef") != null && Child.SelectSingleNode("./AccountRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.AccountFullName = Child.SelectSingleNode("./AccountRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Memo") != null)
        //                                {
        //                                    rowBillDetail.DetailMemo = Child.SelectSingleNode("./Memo").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Amount") != null)
        //                                {
        //                                    rowBillDetail.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                    rowBillDetail.Cost = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                    rowBillDetail.Quantity = 1;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.CustomerListID = Child.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.CustomerFullName = Child.SelectSingleNode("./CustomerRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./BillableStatus") != null)
        //                                {
        //                                    rowBillDetail.BillableStatus = Child.SelectSingleNode("./BillableStatus").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ClassRef") != null && Child.SelectSingleNode("./ClassRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.ClassName = Child.SelectSingleNode("./ClassRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
        //                                }

        //                                lstDetail.Add(rowBillDetail);
        //                            }
        //                        }

        //                        XmlNodeList ItemLineRetListChildren = BillRet.SelectNodes("./ItemLineRet");
        //                        for (int j = 0; j < ItemLineRetListChildren.Count; j++)
        //                        {
        //                            XmlNode Child = ItemLineRetListChildren.Item(j);
        //                            if (Child.Name == "ItemLineRet")
        //                            {
        //                                var rowBillDetail = new QBLinxDataService.MdlBillDetail();

        //                                rowBillDetail.TxnID = TxnID;
        //                                rowBillDetail.BillID = oBill.BillID;
        //                                rowBillDetail.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
        //                                rowBillDetail.DetailLineType = "ItemLine";

        //                                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.AccountListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.AccountFullName = Child.SelectSingleNode("./ItemRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Desc") != null)
        //                                {
        //                                    rowBillDetail.DetailMemo = Child.SelectSingleNode("./Desc").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Cost") != null)
        //                                {
        //                                    rowBillDetail.Cost = Convert.ToDouble(Child.SelectSingleNode("./Cost").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./Quantity") != null)
        //                                {
        //                                    rowBillDetail.Quantity = Convert.ToDouble(Child.SelectSingleNode("./Quantity").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./Amount") != null)
        //                                {
        //                                    rowBillDetail.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.CustomerListID = Child.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.CustomerFullName = Child.SelectSingleNode("./CustomerRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./BillableStatus") != null)
        //                                {
        //                                    rowBillDetail.BillableStatus = Child.SelectSingleNode("./BillableStatus").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ClassRef") != null && Child.SelectSingleNode("./ClassRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.ClassName = Child.SelectSingleNode("./ClassRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
        //                                }

        //                                lstDetail.Add(rowBillDetail);
        //                            }
        //                        }

        //                        oBill.BillDetailLines = lstDetail.ToArray();

        //                        service.BillAddUpdate(oBill);

        //                        bgWorker.ReportProgress(0, "Bill # " + oBill.RefNumber);
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

        //        bgWorker.ReportProgress(0, "Error! Bill Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

        //public bool AddBill(QBLinxDataService.MdlBill billRow, string txnId, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        bool isEdit = false; string editSequence = "";
        //        if (!string.IsNullOrEmpty(txnId))
        //        {
        //            editSequence = GetBillEditSequence(txnId);
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
        //        else if (Common.BranchID == 1 && !string.IsNullOrEmpty(billRow.RefNumber))
        //        {
        //            var mdlInv = GetBillListID(billRow.RefNumber);
        //            if (!string.IsNullOrEmpty(mdlInv.TxnID))
        //            {
        //                isEdit = true; txnId = mdlInv.TxnID; editSequence = mdlInv.EditSequence;
        //            }
        //        }


        //        if (billRow.BillDetailLines == null || billRow.BillDetailLines.Count() == 0)
        //        {
        //            bgWorker.ReportProgress(0, "There is no detail row!");
        //            return false;
        //        }

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        //Create BillAddRq aggregate and fill in field values for it
        //        XmlElement BillAddRq = doc.CreateElement(isEdit ? "BillModRq" : "BillAddRq");
        //        parent.AppendChild(BillAddRq);
        //        //Create BillAdd aggregate and fill in field values for it
        //        XmlElement BillAdd = doc.CreateElement(isEdit ? "BillMod" : "BillAdd");
        //        BillAddRq.AppendChild(BillAdd);

        //        if (isEdit)
        //        {
        //            BillAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
        //            //Set field value for EditSequence <!-- required -->
        //            BillAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
        //        }

        //        String VendorFullName = billRow.VendorFullName;
        //        VendorFullName = Common.Truncate(VendorFullName.Trim(), 41);
        //        //Create CustomerRef aggregate and fill in field values for it
        //        XmlElement VendorRef = doc.CreateElement("VendorRef");
        //        BillAdd.AppendChild(VendorRef);
        //        //Set field value for ListID <!-- optional -->
        //        VendorRef.AppendChild(MakeSimpleElem(doc, "FullName", VendorFullName));

        //        XmlElement VendorAddress = doc.CreateElement("VendorAddress");
        //        BillAdd.AppendChild(VendorAddress);

        //        if (!String.IsNullOrEmpty(billRow.VendorAdd1))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(billRow.VendorAdd1, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorAdd2))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(billRow.VendorAdd2, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorAdd3))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(billRow.VendorAdd3, 39)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorCity))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(billRow.VendorCity, 31)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorState))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(billRow.VendorState, 21)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorPostalCode))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(billRow.VendorPostalCode, 13)));
        //        }

        //        if (!String.IsNullOrEmpty(billRow.VendorCountry))
        //        {
        //            VendorAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(billRow.VendorCountry, 21)));
        //        }

        //        //Set field value for TxnDate <!-- optional -->
        //        BillAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", billRow.TxnDate.ToString("yyyy-MM-dd")));

        //        //Set field value for DueDate <!-- optional -->
        //        if (billRow.DueDate > DateTime.MinValue)
        //            BillAdd.AppendChild(MakeSimpleElem(doc, "DueDate", billRow.DueDate.ToString("yyyy-MM-dd")));

        //        //Set field value for RefNumber <!-- optional -->
        //        if (!string.IsNullOrEmpty(billRow.RefNumber))
        //            BillAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", billRow.RefNumber));


        //        if (!String.IsNullOrEmpty(billRow.Terms))
        //        {
        //            //Create TermsRef aggregate and fill in field values for it
        //            XmlElement TermsRef = doc.CreateElement("TermsRef");
        //            BillAdd.AppendChild(TermsRef);
        //            //Set field value for ListID <!-- optional -->
        //            //TermsRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            TermsRef.AppendChild(MakeSimpleElem(doc, "FullName", billRow.Terms));
        //            //Done creating TermsRef aggregate
        //        }

        //        if (!string.IsNullOrEmpty(billRow.BillMemo))
        //        {
        //            BillAdd.AppendChild(MakeSimpleElem(doc, "Memo", billRow.BillMemo));
        //        }

        //        if (!string.IsNullOrEmpty(billRow.SalesTaxCode))
        //        {
        //            //Create SalesTaxCodeRef aggregate and fill in field values for it
        //            XmlElement SalesTaxCodeRef = doc.CreateElement("SalesTaxCodeRef");
        //            BillAdd.AppendChild(SalesTaxCodeRef);
        //            //Set field value for FullName <!-- optional -->
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElem(doc, "FullName", "ab"));
        //        }

        //        //Set field value for ExchangeRate <!-- optional -->
        //        BillAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", billRow.CurrencyRate.ToString("###0.00")));


        //        foreach (QBLinxDataService.MdlBillDetail detailRow in billRow.BillDetailLines)
        //        {
        //            var detailLine = AddBillLine(doc, isEdit, detailRow);

        //            if (detailLine != null)
        //                BillAdd.AppendChild(detailLine);
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        XmlNodeList BillAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "BillModRs" : "BillAddRs");
        //        if (BillAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = BillAddRsList.Item(0);
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
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Vendor"))
        //                    {
        //                        //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
        //                        Vendors objVendor = new Vendors();
        //                        if (objVendor.QBAddVendor(billRow, bgWorker))
        //                        {
        //                            blnResult = AddBill(billRow, txnId, bgWorker);
        //                        }
        //                        else
        //                        {
        //                            bgWorker.ReportProgress(0, statusMessage);
        //                            return false;
        //                        }
        //                    }
        //                    else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
        //                    {
        //                        //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Item");

        //                        Items objItem = new Items();
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            String ProductName = result[1];

        //                            var itmListId = (from st in billRow.BillDetailLines
        //                                             where st.AccountFullName == ProductName
        //                                             select st.AccountListID).FirstOrDefault();

        //                            if (!string.IsNullOrEmpty(itmListId))
        //                            {
        //                                if (objItem.AddItem(itmListId, billRow.BranchID, bgWorker))
        //                                    blnResult = AddBill(billRow, txnId, bgWorker);
        //                                else
        //                                {
        //                                    //bgWorker.ReportProgress(0, statusMessage);
        //                                    return false;
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Bill");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (statusCode == "0" || statusCode == "530")
        //                {
        //                    XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query
        //                    for (int i = 0; i < BillRetList.Count; i++)
        //                    {
        //                        XmlNode BillRet = BillRetList.Item(i);
        //                        string newTxnId = BillRet.SelectSingleNode("./TxnID").InnerText;

        //                        string NewRefNumber = "";
        //                        if (BillRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            NewRefNumber = BillRet.SelectSingleNode("./RefNumber").InnerText;
        //                        }

        //                        string VendorListID = "";
        //                        if (BillRet.SelectSingleNode("./VendorRef/ListID") != null)
        //                        {
        //                            VendorListID = BillRet.SelectSingleNode("./VendorRef/ListID").InnerText;
        //                        }

        //                        //Vendors objVendor = new  Vendors ();
        //                        //var mdlVendor = objVendor.GetVendorBalance(VendorListID);

        //                        using (QBLinxWebService service = new QBLinxWebService())
        //                        {
        //                            string sysNotes = "";

        //                            if (Common.BranchID == 1) sysNotes = System.Environment.NewLine + "Exported to QuickBooks HeadOffice " + DateTime.Now;
        //                            else sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;

        //                            var item = service.UpdateBillQBInfo(Common.BranchID, billRow.BillID, true, newTxnId, sysNotes, NewRefNumber);
        //                        }

        //                        bgWorker.ReportProgress(0, "Bill " + (isEdit ? "updated" : "added") + " successfully");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Bill");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bgWorker.ReportProgress(0, "Error! Adding/Updating in Bill");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
        //    }

        //    return blnResult;
        //}

        public bool AddBill(Data.dsQBSync.VendorBillRow BillRow, System.ComponentModel.BackgroundWorker bgWorker)
        {
            bool blnResult = false;
            try
            {
                Data.dsQBSync ds = new Data.dsQBSync();
                ds.EnforceConstraints = false;
                Data.dsQBSyncTableAdapters.VendorBillTableAdapter taBill = new Data.dsQBSyncTableAdapters.VendorBillTableAdapter();
                Data.dsQBSyncTableAdapters.VendorBillDetailsTableAdapter taBillItem = new Data.dsQBSyncTableAdapters.VendorBillDetailsTableAdapter();

                taBillItem.FillByVendorBillID(ds.VendorBillDetails, BillRow.ID);
                if (ds.VendorBillDetails.Rows.Count == 0)
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
                //Create BillAddRq aggregate and fill in field values for it
                XmlElement BillAddRq = doc.CreateElement("BillAddRq");
                parent.AppendChild(BillAddRq);
                //Create BillAdd aggregate and fill in field values for it
                XmlElement BillAdd = doc.CreateElement("BillAdd");
                BillAddRq.AppendChild(BillAdd);

                String CustomerFullName = BillRow.VendorName;
                CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
                //Create CustomerRef aggregate and fill in field values for it
                XmlElement CustomerRef = doc.CreateElement("VendorRef");
                BillAdd.AppendChild(CustomerRef);
                //Set field value for ListID <!-- optional -->
                CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));

                //Set field value for TxnDate <!-- optional -->
                DateTime dtTransaction = BillRow.IsBillDateNull() ? DateTime.Now : BillRow.BillDate;
                BillAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", dtTransaction.ToString("yyyy-MM-dd")));

                if (BillRow.IsDueDateNull() == false)
                {
                    BillAdd.AppendChild(MakeSimpleElem(doc, "DueDate", BillRow.DueDate.ToString("yyyy-MM-dd")));
                }

                //Set field value for RefNumber <!-- optional -->
                String RefNumber = BillRow.IsInvoiceNoNull() ? "" : BillRow.InvoiceNo;
                if (!string.IsNullOrEmpty(RefNumber))
                    BillAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", RefNumber));

                //Billing
                //XmlElement BillAddress = doc.CreateElement("BillAddress");
                //BillAdd.AppendChild(BillAddress);

                //if (!String.IsNullOrEmpty(BillRow.IsBillingAccountNameNull() ? "" : BillRow.BillingAccountName))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(BillRow.BillingAccountName.Replace(":", ";"), 39)));
                //}

                //if (!String.IsNullOrEmpty(BillRow.IsBillAdd1Null() ? "" : BillRow.BillAdd1))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(BillRow.BillAdd1.Replace(":", ";"), 39)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsBillCityNull() ? "" : BillRow.BillCity))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(BillRow.BillCity, 31)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsBillStateNull() ? "" : BillRow.BillState))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(BillRow.BillState, 21)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsBillPostalCodeNull() ? "" : BillRow.BillPostalCode))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(BillRow.BillPostalCode, 13)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsBillCountryNull() ? "" : BillRow.BillCountry))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(BillRow.BillCountry, 21)));
                //}


                //Shipping Address
                //XmlElement ShipAddress = doc.CreateElement("ShipAddress");
                //BillAdd.AppendChild(ShipAddress);

                //if (!String.IsNullOrEmpty(BillRow.IsShipAdd1Null() ? "" : BillRow.ShipAdd1))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(BillRow.ShipAdd1.Replace(":", ";"), 39)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsShipCityNull() ? "" : BillRow.ShipCity))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(BillRow.ShipCity, 31)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsShipStateNull() ? "" : BillRow.ShipState))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(BillRow.ShipState, 21)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsShipPostalCodeNull() ? "" : BillRow.ShipPostalCode))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(BillRow.ShipPostalCode, 13)));
                //}
                //if (!String.IsNullOrEmpty(BillRow.IsShipCountryNull() ? "" : BillRow.ShipCountry))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(BillRow.ShipCountry, 21)));
                //}



                //if (!String.IsNullOrEmpty(BillRow.IsBillTitleNull() ? "" : BillRow.BillTitle))
                //{
                //    BillAdd.AppendChild(MakeSimpleElem(doc, "Memo", BillRow.BillTitle));
                //}

                foreach (Data.dsQBSync.VendorBillDetailsRow detailRow in ds.VendorBillDetails.Rows)
                {
                    string ProductName = Common.Truncate(detailRow.IsCatalogNull() == true ? "" : detailRow.Catalog, 31);
                    string Desc = detailRow.IsNameNull() ? "" : detailRow.Name;
                    string listID = detailRow.IsItemListIDNull() ? "" : detailRow.ItemListID;
                    decimal ProductPrice = detailRow.CatalogCost;
                    int Quantity = detailRow.BillQty;
                    decimal BillAmount = detailRow.BillAmount;

                    BillAdd.AppendChild(AddBillLine(doc, "ItemLine", listID, ProductName, Desc, Quantity, ProductPrice, BillAmount));
                }

                string strRequest = doc.OuterXml;
                string strResponse = "";
                try
                {
                    strResponse = QBConnection.ProcessRequest(strRequest);
                }
                catch (Exception ex) { }

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                XmlNodeList BillAddRsList = responseXmlDoc.GetElementsByTagName("BillAddRs");
                if (BillAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = BillAddRsList.Item(0);
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
                                bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
                                //Customers objCustomer = new Customers();
                                //if (objCustomer.QBAddCusomter(order, bgWorker))
                                //{
                                //    blnResult = AddBill(order, bgWorker, log);
                                //}
                                //else
                                //{
                                //    bgWorker.ReportProgress(0, statusMessage);
                                //    return false;
                                //}
                            }
                            else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
                            {
                                bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Item");

                                //Items objItem = new Items();
                                //string[] stringSeparators = new string[] { "\"" };
                                //string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                //if (result.Count() > 1)
                                //{
                                //    String ProductName = result[1];

                                //    if (objItem.ServiceItemAdd(ProductName))
                                //        blnResult = AddBill(BillRow, bgWorker);
                                //    else
                                //    {
                                //        bgWorker.ReportProgress(0, statusMessage);
                                //        return false;
                                //    }
                                //}
                            }
                            else
                            {
                                bgWorker.ReportProgress(0, "Error! Adding in Bill");
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                            }
                        }
                        else if (statusCode == "0")
                        {
                            XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query
                            for (int i = 0; i < BillRetList.Count; i++)
                            {
                                XmlNode BillRet = BillRetList.Item(i);
                                string TxnID = BillRet.SelectSingleNode("./TxnID").InnerText;
                                var TimeCreated = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeCreated").InnerText);
                                var TimeModified = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeModified").InnerText);

                                taBill.UpdateQBFields(TxnID, TimeModified, BillRow.ID);

                                bgWorker.ReportProgress(0, BillRow.InvoiceNo + " Successfully added in QuickBooks");
                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! Adding in Bill");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bgWorker.ReportProgress(0, "Error! Adding in Bill");
                bgWorker.ReportProgress(0, ex.Message);
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            }

            return blnResult;
        }

        private XmlElement AddBillLine(XmlDocument inputXMLDoc, string LineType, string ItemListID, string ProductName, string Desc, int Qty, Decimal Cost, decimal BillAmount)
        {
            //if (LineType == "ExpenseLine")
            //{
            //    XmlElement ExpenseLine = inputXMLDoc.CreateElement(isEdit ? "ExpenseLineMod" : "ExpenseLineAdd");

            //    if (isEdit)
            //        ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

            //    if (!string.IsNullOrEmpty(detailRow.AccountFullName))
            //    {
            //        //Create ItemRef aggregate and fill in field values for it
            //        XmlElement AccountRef = inputXMLDoc.CreateElement("AccountRef");
            //        ExpenseLine.AppendChild(AccountRef);
            //        AccountRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.AccountFullName));

            //        ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Amount", detailRow.Amount.ToString("###0.00")));

            //        ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Memo", detailRow.DetailMemo));

            //        if (!string.IsNullOrEmpty(detailRow.CustomerFullName))
            //        {
            //            //Create CustomerRef aggregate and fill in field values for it
            //            XmlElement CustomerRef = inputXMLDoc.CreateElement("CustomerRef");
            //            ExpenseLine.AppendChild(CustomerRef);
            //            //Set field value for ListID <!-- optional -->
            //            //CustomerRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", "200000-1011023419"));
            //            //Set field value for FullName <!-- optional -->
            //            CustomerRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.CustomerFullName));
            //            //Done creating CustomerRef aggregate
            //        }


            //        if (!string.IsNullOrEmpty(detailRow.ClassName))
            //        {
            //            //Create ClassRef aggregate and fill in field values for it
            //            XmlElement ClassRef = inputXMLDoc.CreateElement("ClassRef");
            //            ExpenseLine.AppendChild(ClassRef);
            //            //Set field value for ListID <!-- optional -->
            //            //ClassRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", "200000-1011023419"));
            //            //Set field value for FullName <!-- optional -->
            //            ClassRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.ClassName));
            //            //Done creating ClassRef aggregate
            //        }


            //        if (!string.IsNullOrEmpty(detailRow.TaxCode))
            //        {
            //            XmlElement SalesTaxCodeRef = inputXMLDoc.CreateElement("SalesTaxCodeRef");
            //            ExpenseLine.AppendChild(SalesTaxCodeRef);
            //            SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.TaxCode));
            //        }

            //        if (detailRow.BillableStatus == "Billable")
            //            ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "BillableStatus", "Billable"));
            //        else if (detailRow.BillableStatus == "NotBillable")
            //            ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "BillableStatus", "NotBillable"));

            //    }
            //    else
            //    {
            //        ExpenseLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Memo", detailRow.DetailMemo));
            //    }

            //    return ExpenseLine;
            //}else
            if (LineType == "ItemLine")
            {
                XmlElement ItemLine = inputXMLDoc.CreateElement("ItemLineAdd");

                //if (isEdit)
                //    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

                if (!string.IsNullOrEmpty(ProductName))
                {
                    //Create ItemRef aggregate and fill in field values for it
                    XmlElement ItemRef = inputXMLDoc.CreateElement("ItemRef");
                    ItemLine.AppendChild(ItemRef);
                    //ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", ProductName));
                    ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ItemListID));
                    //Set field value for Desc <!-- optional -->                           
                    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", Desc));

                    if (Qty > 0)
                        ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Quantity", Qty.ToString("###0.00")));


                    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Cost", Cost.ToString("###0.00")));
                    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Amount", BillAmount.ToString("###0.00")));

                    //if (!string.IsNullOrEmpty(detailRow.CustomerFullName))
                    //{
                    //    //Create CustomerRef aggregate and fill in field values for it
                    //    XmlElement CustomerRef = inputXMLDoc.CreateElement("CustomerRef");
                    //    ItemLine.AppendChild(CustomerRef);
                    //    //Set field value for ListID <!-- optional -->
                    //    //CustomerRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", "200000-1011023419"));
                    //    //Set field value for FullName <!-- optional -->
                    //    CustomerRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.CustomerFullName));
                    //    //Done creating CustomerRef aggregate
                    //}


                    //if (!string.IsNullOrEmpty(detailRow.ClassName))
                    //{
                    //    //Create ClassRef aggregate and fill in field values for it
                    //    XmlElement ClassRef = inputXMLDoc.CreateElement("ClassRef");
                    //    ItemLine.AppendChild(ClassRef);
                    //    //Set field value for ListID <!-- optional -->
                    //    //ClassRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", "200000-1011023419"));
                    //    //Set field value for FullName <!-- optional -->
                    //    ClassRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.ClassName));
                    //    //Done creating ClassRef aggregate
                    //}

                    //if (!string.IsNullOrEmpty(detailRow.TaxCode))
                    //{
                    //    XmlElement SalesTaxCodeRef = inputXMLDoc.CreateElement("SalesTaxCodeRef");
                    //    ItemLine.AppendChild(SalesTaxCodeRef);
                    //    SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.TaxCode));
                    //}

                    //if (detailRow.BillableStatus == "Billable")
                    //ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "BillableStatus", "Billable"));
                    //else if (detailRow.BillableStatus == "NotBillable")
                    //    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "BillableStatus", "NotBillable"));
                }
                else
                {
                    ItemLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", Desc));
                }

                return ItemLine;
            }

            return null;
        }

        public String GetBillEditSequence(String TxnID)
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
                XmlElement BillQueryRq = inputXMLDoc.CreateElement("BillQueryRq");
                qbXMLMsgsRq.AppendChild(BillQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList BillQueryRsList = responseXmlDoc.GetElementsByTagName("BillQueryRs");
                if (BillQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = BillQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query
                        for (int i = 0; i < BillRetList.Count; i++)
                        {
                            XmlNode BillRet = BillRetList.Item(i);

                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = BillRet.SelectSingleNode("./EditSequence").InnerText;

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

        public MdlQB GetBillListID(String RefNumber)
        {
            MdlQB mdlResult = new MdlQB();
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
                XmlElement BillQueryRq = inputXMLDoc.CreateElement("BillQueryRq");
                qbXMLMsgsRq.AppendChild(BillQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "RefNumber", RefNumber));
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                BillQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList BillQueryRsList = responseXmlDoc.GetElementsByTagName("BillQueryRs");
                if (BillQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = BillQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query
                        for (int i = 0; i < BillRetList.Count; i++)
                        {
                            XmlNode BillRet = BillRetList.Item(i);

                            mdlResult.TxnID = BillRet.SelectSingleNode("./TxnID").InnerText;
                            //Get value of EditSequence
                            mdlResult.EditSequence = BillRet.SelectSingleNode("./EditSequence").InnerText;

                            return mdlResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mdlResult;
        }

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        //public void BillToPayQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
        //            XmlElement BillToPayQueryRq = doc.CreateElement("BillToPayQueryRq");
        //            qbXMLMsgsRq.AppendChild(BillToPayQueryRq);
        //            //BillToPayQueryRq.SetAttribute("requestID", "1");

        //            //if (!String.IsNullOrEmpty(strIterator))
        //            //    BillToPayQueryRq.SetAttribute("iterator", strIterator);
        //            //if (!String.IsNullOrEmpty(strIteratorID))
        //            //    BillToPayQueryRq.SetAttribute("iteratorID", strIteratorID);

        //            //BillToPayQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

        //            ////Create ModifiedDateRangeFilter aggregate and fill in field values for it
        //            //XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
        //            //BillQueryRq.AppendChild(ModifiedDateRangeFilter);
        //            ////Set field value for FromModifiedDate <!-- optional -->
        //            //ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
        //            ////Set field value for ToModifiedDate <!-- optional -->
        //            //if (Common.UseQBQueryToDate)
        //            //    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
        //            ////Done creating ModifiedDateRangeFilter aggregate

        //            ///BillToPayQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

        //            strRemaining = "0";

        //            string strRequest = doc.OuterXml;
        //            string strResponse = QBConnection.ProcessRequest(strRequest);

        //            //Parse the response XML string into an XmlDocument
        //            XmlDocument responseXmlDoc = new XmlDocument();
        //            responseXmlDoc.LoadXml(strResponse);

        //            //Get the response for our request             
        //            XmlNodeList BillQueryRsList = responseXmlDoc.GetElementsByTagName("BillQueryRs");
        //            if (BillQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //            {
        //                XmlNode responseNode = BillQueryRsList.Item(0);
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
        //                    XmlNodeList BillRetList = responseNode.SelectNodes("//BillRet");//XPath Query

        //                    QBLinxWebService service = new QBLinxWebService();

        //                    for (int i = 0; i < BillRetList.Count; i++)
        //                    {
        //                        XmlNode BillRet = BillRetList.Item(i);

        //                        if (BillRet == null) continue;

        //                        var oBill = new QBLinxDataService.MdlBill();

        //                        string TxnID = BillRet.SelectSingleNode("./TxnID").InnerText;

        //                        oBill.BillID = -1;
        //                        oBill.BranchID = Common.BranchID;
        //                        oBill.BillStatus = 1;
        //                        if (Common.BranchID == 1)
        //                        {
        //                            oBill.HOSync = true;
        //                            oBill.TxnID = TxnID;
        //                            oBill.SystemNotes = "Exported to Cloud From Head Office On: " + System.DateTime.Now;
        //                        }
        //                        else
        //                        {
        //                            oBill.BRSync = true;
        //                            oBill.BRTxnID = TxnID;
        //                            oBill.SystemNotes = "Exported to Cloud From Branch On: " + System.DateTime.Now;
        //                        }

        //                        //oBill.UtcOffset = Common.LoginUser.UtcOffset;
        //                        oBill.TimeCreated = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeCreated").InnerText);
        //                        oBill.TimeModified = Convert.ToDateTime(BillRet.SelectSingleNode("./TimeModified").InnerText);

        //                        if (BillRet.SelectSingleNode("./VendorRef/ListID") != null)
        //                        {
        //                            oBill.VendorListID = BillRet.SelectSingleNode("./VendorRef/ListID").InnerText;

        //                        }
        //                        //Get value of FullName
        //                        if (BillRet.SelectSingleNode("./VendorRef/FullName") != null)
        //                        {
        //                            oBill.VendorFullName = BillRet.SelectSingleNode("./VendorRef/FullName").InnerText;

        //                        }

        //                        oBill.TxnDate = Convert.ToDateTime(BillRet.SelectSingleNode("./TxnDate").InnerText);
        //                        //Get value of RefNumber
        //                        if (BillRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            oBill.RefNumber = BillRet.SelectSingleNode("./RefNumber").InnerText;

        //                        }
        //                        //Get all field values for BillAddress aggregate 
        //                        XmlNode VendorAddress = BillRet.SelectSingleNode("./VendorAddress");
        //                        if (VendorAddress != null)
        //                        {
        //                            //Get value of Addr1
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr1") != null)
        //                            {
        //                                oBill.VendorAdd1 = BillRet.SelectSingleNode("./VendorAddress/Addr1").InnerText;

        //                            }
        //                            //Get value of Addr2
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr2") != null)
        //                            {
        //                                oBill.VendorAdd2 = BillRet.SelectSingleNode("./VendorAddress/Addr2").InnerText;

        //                            }
        //                            //Get value of Addr3
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Addr3") != null)
        //                            {
        //                                oBill.VendorAdd3 = BillRet.SelectSingleNode("./VendorAddress/Addr3").InnerText;

        //                            }
        //                            //Get value of City
        //                            if (BillRet.SelectSingleNode("./VendorAddress/City") != null)
        //                            {
        //                                oBill.VendorCity = BillRet.SelectSingleNode("./VendorAddress/City").InnerText;

        //                            }
        //                            //Get value of State
        //                            if (BillRet.SelectSingleNode("./VendorAddress/State") != null)
        //                            {
        //                                oBill.VendorState = BillRet.SelectSingleNode("./VendorAddress/State").InnerText;

        //                            }
        //                            //Get value of PostalCode
        //                            if (BillRet.SelectSingleNode("./VendorAddress/PostalCode") != null)
        //                            {
        //                                oBill.VendorPostalCode = BillRet.SelectSingleNode("./VendorAddress/PostalCode").InnerText;

        //                            }
        //                            //Get value of Country
        //                            if (BillRet.SelectSingleNode("./VendorAddress/Country") != null)
        //                            {
        //                                oBill.VendorCountry = BillRet.SelectSingleNode("./VendorAddress/Country").InnerText;

        //                            }
        //                        }

        //                        //Get all field values for TermsRef aggregate 
        //                        XmlNode TermsRef = BillRet.SelectSingleNode("./TermsRef");
        //                        if (TermsRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./TermsRef/FullName") != null)
        //                            {
        //                                oBill.Terms = BillRet.SelectSingleNode("./TermsRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for TermsRef aggregate

        //                        //Get value of DueDate
        //                        if (BillRet.SelectSingleNode("./DueDate") != null)
        //                        {
        //                            oBill.DueDate = Convert.ToDateTime(BillRet.SelectSingleNode("./DueDate").InnerText);

        //                        }


        //                        if (BillRet.SelectSingleNode("./AmountDue") != null)
        //                        {
        //                            oBill.AmountDue = Convert.ToDouble(BillRet.SelectSingleNode("./AmountDue").InnerText);

        //                        }

        //                        if (BillRet.SelectSingleNode("./Memo") != null)
        //                        {
        //                            oBill.BillMemo = BillRet.SelectSingleNode("./Memo").InnerText;
        //                        }

        //                        //Get all field values for CurrencyRef aggregate 
        //                        XmlNode CurrencyRef = BillRet.SelectSingleNode("./CurrencyRef");
        //                        if (CurrencyRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./CurrencyRef/FullName") != null)
        //                            {
        //                                oBill.Currency = BillRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
        //                            }
        //                        }
        //                        //Done with field values for CurrencyRef aggregate

        //                        if (BillRet.SelectSingleNode("./ExchangeRate") != null)
        //                        {
        //                            oBill.CurrencyRate = Convert.ToDouble(BillRet.SelectSingleNode("./ExchangeRate").InnerText);
        //                        }

        //                        if (BillRet.SelectSingleNode("./AmountDueInHomeCurrency") != null)
        //                        {
        //                            string AmountDueInHomeCurrency = BillRet.SelectSingleNode("./AmountDueInHomeCurrency").InnerText;

        //                        }

        //                        //Get all field values for SalesTaxCodeRef aggregate 
        //                        XmlNode SalesTaxCodeRef = BillRet.SelectSingleNode("./SalesTaxCodeRef");
        //                        if (SalesTaxCodeRef != null)
        //                        {
        //                            //Get value of FullName
        //                            if (BillRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                            {
        //                                oBill.SalesTaxCode = BillRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;

        //                            }
        //                        }
        //                        //Done with field values for SalesTaxCodeRef aggregate

        //                        //Get value of IsPaid
        //                        if (BillRet.SelectSingleNode("./IsPaid") != null)
        //                        {
        //                            oBill.IsPaid = Convert.ToBoolean(BillRet.SelectSingleNode("./IsPaid").InnerText);
        //                        }

        //                        if (BillRet.SelectSingleNode("./OpenAmount") != null)
        //                        {
        //                            oBill.OpenAmount = Convert.ToDouble(BillRet.SelectSingleNode("./OpenAmount").InnerText);
        //                        }

        //                        //oBill.BillDetailLines = new QBBillManager.QBIMService.BillDetail();

        //                        List<QBLinxDataService.MdlBillDetail> lstDetail = new List<QBLinxDataService.MdlBillDetail>();

        //                        XmlNodeList ExpenseLineRetListChildren = BillRet.SelectNodes("./ExpenseLineRet");
        //                        for (int j = 0; j < ExpenseLineRetListChildren.Count; j++)
        //                        {
        //                            XmlNode Child = ExpenseLineRetListChildren.Item(j);
        //                            if (Child.Name == "ExpenseLineRet")
        //                            {
        //                                var rowBillDetail = new QBLinxDataService.MdlBillDetail();

        //                                rowBillDetail.TxnID = TxnID;
        //                                rowBillDetail.BillID = oBill.BillID;
        //                                rowBillDetail.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
        //                                rowBillDetail.DetailLineType = "ExpenseLine";

        //                                if (Child.SelectSingleNode("./AccountRef") != null && Child.SelectSingleNode("./AccountRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.AccountListID = Child.SelectSingleNode("./AccountRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./AccountRef") != null && Child.SelectSingleNode("./AccountRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.AccountFullName = Child.SelectSingleNode("./AccountRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Memo") != null)
        //                                {
        //                                    rowBillDetail.DetailMemo = Child.SelectSingleNode("./Memo").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Amount") != null)
        //                                {
        //                                    rowBillDetail.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                    rowBillDetail.Cost = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                    rowBillDetail.Quantity = 1;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.CustomerListID = Child.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.CustomerFullName = Child.SelectSingleNode("./CustomerRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./BillableStatus") != null)
        //                                {
        //                                    rowBillDetail.BillableStatus = Child.SelectSingleNode("./BillableStatus").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ClassRef") != null && Child.SelectSingleNode("./ClassRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.ClassName = Child.SelectSingleNode("./ClassRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
        //                                }

        //                                lstDetail.Add(rowBillDetail);
        //                            }
        //                        }

        //                        XmlNodeList ItemLineRetListChildren = BillRet.SelectNodes("./ItemLineRet");
        //                        for (int j = 0; j < ItemLineRetListChildren.Count; j++)
        //                        {
        //                            XmlNode Child = ItemLineRetListChildren.Item(j);
        //                            if (Child.Name == "ItemLineRet")
        //                            {
        //                                var rowBillDetail = new QBLinxDataService.MdlBillDetail();

        //                                rowBillDetail.TxnID = TxnID;
        //                                rowBillDetail.BillID = oBill.BillID;
        //                                rowBillDetail.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
        //                                rowBillDetail.DetailLineType = "ItemLine";

        //                                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.AccountListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.AccountFullName = Child.SelectSingleNode("./ItemRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Desc") != null)
        //                                {
        //                                    rowBillDetail.DetailMemo = Child.SelectSingleNode("./Desc").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./Cost") != null)
        //                                {
        //                                    rowBillDetail.Cost = Convert.ToDouble(Child.SelectSingleNode("./Cost").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./Quantity") != null)
        //                                {
        //                                    rowBillDetail.Quantity = Convert.ToDouble(Child.SelectSingleNode("./Quantity").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./Amount") != null)
        //                                {
        //                                    rowBillDetail.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/ListID") != null)
        //                                {
        //                                    rowBillDetail.CustomerListID = Child.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./CustomerRef") != null && Child.SelectSingleNode("./CustomerRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.CustomerFullName = Child.SelectSingleNode("./CustomerRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./BillableStatus") != null)
        //                                {
        //                                    rowBillDetail.BillableStatus = Child.SelectSingleNode("./BillableStatus").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./ClassRef") != null && Child.SelectSingleNode("./ClassRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.ClassName = Child.SelectSingleNode("./ClassRef/FullName").InnerText;
        //                                }

        //                                if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
        //                                {
        //                                    rowBillDetail.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
        //                                }

        //                                lstDetail.Add(rowBillDetail);
        //                            }
        //                        }

        //                        oBill.BillDetailLines = lstDetail.ToArray();

        //                        service.BillAddUpdate(oBill);

        //                        bgWorker.ReportProgress(0, "Bill # " + oBill.RefNumber);
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

        //        bgWorker.ReportProgress(0, "Error! Bill Query");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //}

    }
}
