using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class CreditMemo
    {

        public void CreditMemoQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement CreditMemoQueryRq = doc.CreateElement("CreditMemoQueryRq");
                    qbXMLMsgsRq.AppendChild(CreditMemoQueryRq);
                    CreditMemoQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        CreditMemoQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        CreditMemoQueryRq.SetAttribute("iteratorID", strIteratorID);

                    CreditMemoQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    //Create ModifiedDateRangeFilter aggregate and fill in field values for it
                    XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
                    CreditMemoQueryRq.AppendChild(ModifiedDateRangeFilter);
                    //Set field value for FromModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    //Set field value for ToModifiedDate <!-- optional -->
                    if (Common.UseQBQueryToDate)
                        ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Done creating ModifiedDateRangeFilter aggregate

                    CreditMemoQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

                    //Set field value for IncludeLinkedTxns <!-- optional -->
                    CreditMemoQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLinkedTxns", "1"));

                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList CreditMemoQueryRsList = responseXmlDoc.GetElementsByTagName("CreditMemoQueryRs");
                    if (CreditMemoQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = CreditMemoQueryRsList.Item(0);
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
                            //XmlNodeList CreditMemoRetList = responseNode.SelectNodes("//CreditMemoRet");//XPath Query

                            //Data.dsQBSyncTableAdapters.CreditMemoTableAdapter taCreditMemo = new Data.dsQBSyncTableAdapters.CreditMemoTableAdapter();
                            //Data.dsQBSyncTableAdapters.CreditMemoDetailTableAdapter taCreditMemoDetail = new Data.dsQBSyncTableAdapters.CreditMemoDetailTableAdapter();

                            //for (int i = 0; i < CreditMemoRetList.Count; i++)
                            //{
                            //    XmlNode CreditMemoRet = CreditMemoRetList.Item(i);

                            //    if (CreditMemoRet == null) continue;

                            //    string TxnID = CreditMemoRet.SelectSingleNode("./TxnID").InnerText;

                            //    Data.dsQBSync ds = new Data.dsQBSync();
                            //    ds.EnforceConstraints = false;

                            //    var oCreditMemoRow = ds.CreditMemo.NewCreditMemoRow();
                            //    taCreditMemo.FillByTxnID(ds.CreditMemo, TxnID);
                            //    if (ds.CreditMemo.Count() > 0)
                            //    {
                            //        oCreditMemoRow = ds.CreditMemo[0];

                            //        taCreditMemoDetail.DeleteByCreditMemoID(oCreditMemoRow.CreditMemoID);
                            //    }
                            //    else
                            //    {
                            //        ds.CreditMemo.AddCreditMemoRow(oCreditMemoRow);
                            //        oCreditMemoRow.TxnID = TxnID;
                            //        oCreditMemoRow.UserID = 0;
                            //        oCreditMemoRow.CreditMemoStatus = 1;
                            //        oCreditMemoRow.SystemNotes = "Exported to Portal On: " + System.DateTime.Now;
                            //    }

                            //    oCreditMemoRow.IsQBSync = true;

                            //    //oCreditMemo.UtcOffset = Common.LoginUser.UtcOffset;
                            //    oCreditMemoRow.TimeCreated = Convert.ToDateTime(CreditMemoRet.SelectSingleNode("./TimeCreated").InnerText);
                            //    oCreditMemoRow.TimeModified = Convert.ToDateTime(CreditMemoRet.SelectSingleNode("./TimeModified").InnerText);

                            //    Data.dsQBSyncTableAdapters.CustomersTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomersTableAdapter();
                            //    if (CreditMemoRet.SelectSingleNode("./CustomerRef/ListID") != null)
                            //    {
                            //        oCreditMemoRow.CustomerListID = CreditMemoRet.SelectSingleNode("./CustomerRef/ListID").InnerText;

                            //        taCustomer.FillByQBListID(ds.Customers, oCreditMemoRow.CustomerListID);
                            //        if (ds.Customers.Count() > 0)
                            //        {
                            //            var customerRow = ds.Customers[0];
                            //            oCreditMemoRow.CustomerID = customerRow.CustomerID;
                            //        }
                            //    }
                            //    //Get value of FullName
                            //    if (CreditMemoRet.SelectSingleNode("./CustomerRef/FullName") != null)
                            //    {
                            //        oCreditMemoRow.CustomerFullName = CreditMemoRet.SelectSingleNode("./CustomerRef/FullName").InnerText;

                            //        if ((oCreditMemoRow.IsCustomerIDNull() ? 0 : oCreditMemoRow.CustomerID) == 0)
                            //        {
                            //            taCustomer.FillByFullName(ds.Customers, oCreditMemoRow.CustomerFullName);
                            //            if (ds.Customers.Count() > 0)
                            //            {
                            //                var customerRow = ds.Customers[0];
                            //                oCreditMemoRow.CustomerID = customerRow.CustomerID;
                            //            }
                            //        }
                            //    }

                            //    if ((oCreditMemoRow.IsCustomerIDNull() ? 0 : oCreditMemoRow.CustomerID) == 0) continue;

                            //    oCreditMemoRow.TxnDate = Convert.ToDateTime(CreditMemoRet.SelectSingleNode("./TxnDate").InnerText);
                            //    //Get value of RefNumber
                            //    if (CreditMemoRet.SelectSingleNode("./RefNumber") != null)
                            //    {
                            //        oCreditMemoRow.RefNumber = CreditMemoRet.SelectSingleNode("./RefNumber").InnerText;

                            //    }
                            //    //Get all field values for BillAddress aggregate 
                            //    XmlNode BillAddress = CreditMemoRet.SelectSingleNode("./BillAddress");
                            //    if (BillAddress != null)
                            //    {
                            //        //Get value of Addr1
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/Addr1") != null)
                            //        {
                            //            oCreditMemoRow.BillAdd1 = CreditMemoRet.SelectSingleNode("./BillAddress/Addr1").InnerText;

                            //        }
                            //        //Get value of Addr2
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/Addr2") != null)
                            //        {
                            //            oCreditMemoRow.BillAdd2 = CreditMemoRet.SelectSingleNode("./BillAddress/Addr2").InnerText;

                            //        }
                            //        //Get value of Addr3
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/Addr3") != null)
                            //        {
                            //            oCreditMemoRow.BillAdd3 = CreditMemoRet.SelectSingleNode("./BillAddress/Addr3").InnerText;

                            //        }
                            //        //Get value of City
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/City") != null)
                            //        {
                            //            oCreditMemoRow.BillCity = CreditMemoRet.SelectSingleNode("./BillAddress/City").InnerText;

                            //        }
                            //        //Get value of State
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/State") != null)
                            //        {
                            //            oCreditMemoRow.BillState = CreditMemoRet.SelectSingleNode("./BillAddress/State").InnerText;

                            //        }
                            //        //Get value of PostalCode
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/PostalCode") != null)
                            //        {
                            //            oCreditMemoRow.BillPostalCode = CreditMemoRet.SelectSingleNode("./BillAddress/PostalCode").InnerText;

                            //        }
                            //        //Get value of Country
                            //        if (CreditMemoRet.SelectSingleNode("./BillAddress/Country") != null)
                            //        {
                            //            oCreditMemoRow.BillCountry = CreditMemoRet.SelectSingleNode("./BillAddress/Country").InnerText;

                            //        }
                            //    }

                            //    //Get all field values for ShipAddress aggregate 
                            //    XmlNode ShipAddress = CreditMemoRet.SelectSingleNode("./ShipAddress");
                            //    if (ShipAddress != null)
                            //    {
                            //        //Get value of Addr1
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/Addr1") != null)
                            //        {
                            //            oCreditMemoRow.ShipAdd1 = CreditMemoRet.SelectSingleNode("./ShipAddress/Addr1").InnerText;

                            //        }
                            //        //Get value of Addr2
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/Addr2") != null)
                            //        {
                            //            oCreditMemoRow.ShipAdd2 = CreditMemoRet.SelectSingleNode("./ShipAddress/Addr2").InnerText;

                            //        }
                            //        //Get value of Addr3
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/Addr3") != null)
                            //        {
                            //            oCreditMemoRow.ShipAdd3 = CreditMemoRet.SelectSingleNode("./ShipAddress/Addr3").InnerText;

                            //        }
                            //        //Get value of City
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/City") != null)
                            //        {
                            //            oCreditMemoRow.ShipCity = CreditMemoRet.SelectSingleNode("./ShipAddress/City").InnerText;

                            //        }
                            //        //Get value of State
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/State") != null)
                            //        {
                            //            oCreditMemoRow.ShipState = CreditMemoRet.SelectSingleNode("./ShipAddress/State").InnerText;

                            //        }
                            //        //Get value of PostalCode
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/PostalCode") != null)
                            //        {
                            //            oCreditMemoRow.ShipPostalCode = CreditMemoRet.SelectSingleNode("./ShipAddress/PostalCode").InnerText;

                            //        }
                            //        //Get value of Country
                            //        if (CreditMemoRet.SelectSingleNode("./ShipAddress/Country") != null)
                            //        {
                            //            oCreditMemoRow.ShipCountry = CreditMemoRet.SelectSingleNode("./ShipAddress/Country").InnerText;

                            //        }
                            //    }

                            //    if (CreditMemoRet.SelectSingleNode("./PONumber") != null)
                            //    {
                            //        oCreditMemoRow.CustomerPONo = CreditMemoRet.SelectSingleNode("./PONumber").InnerText;

                            //    }
                            //    //Get all field values for TermsRef aggregate 
                            //    XmlNode TermsRef = CreditMemoRet.SelectSingleNode("./TermsRef");
                            //    if (TermsRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (CreditMemoRet.SelectSingleNode("./TermsRef/FullName") != null)
                            //        {
                            //            oCreditMemoRow.PaymentTerms = CreditMemoRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                            //        }
                            //    }
                            //    //Done with field values for TermsRef aggregate

                            //    //Get value of DueDate
                            //    if (CreditMemoRet.SelectSingleNode("./DueDate") != null)
                            //    {
                            //        oCreditMemoRow.DueDate = Convert.ToDateTime(CreditMemoRet.SelectSingleNode("./DueDate").InnerText);

                            //    }
                            //    //Get all field values for SalesRepRef aggregate 
                            //    //XmlNode SalesRepRef = CreditMemoRet.SelectSingleNode("./SalesRepRef");
                            //    //if (SalesRepRef != null)
                            //    //{
                            //    //    //Get value of FullName
                            //    //    if (CreditMemoRet.SelectSingleNode("./SalesRepRef/FullName") != null)
                            //    //    {
                            //    //        oCreditMemoRow.SalesRep = CreditMemoRet.SelectSingleNode("./SalesRepRef/FullName").InnerText;
                            //    //    }
                            //    //}
                            //    //Done with field values for SalesRepRef aggregate

                            //    //Get all field values for ShipMethodRef aggregate 
                            //    XmlNode ShipMethodRef = CreditMemoRet.SelectSingleNode("./ShipMethodRef");
                            //    if (ShipMethodRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (CreditMemoRet.SelectSingleNode("./ShipMethodRef/FullName") != null)
                            //        {
                            //            oCreditMemoRow.ShipMethod = CreditMemoRet.SelectSingleNode("./ShipMethodRef/FullName").InnerText;
                            //        }
                            //    }
                            //    //Done with field values for ShipMethodRef aggregate


                            //    if (CreditMemoRet.SelectSingleNode("./Subtotal") != null)
                            //    {
                            //        oCreditMemoRow.Subtotal = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./Subtotal").InnerText);

                            //    }

                            //    //Get value of SalesTaxPercentage
                            //    if (CreditMemoRet.SelectSingleNode("./SalesTaxPercentage") != null)
                            //    {
                            //        oCreditMemoRow.SalesTaxPercentage = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./SalesTaxPercentage").InnerText);

                            //    }

                            //    if (CreditMemoRet.SelectSingleNode("./SalesTaxTotal") != null)
                            //    {
                            //        oCreditMemoRow.SalesTaxTotal = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./SalesTaxTotal").InnerText);

                            //    }

                            //    if (CreditMemoRet.SelectSingleNode("./ItemSalesTaxRef") != null && CreditMemoRet.SelectSingleNode("./ItemSalesTaxRef/FullName") != null)
                            //    {
                            //        oCreditMemoRow.SalesTaxItem = CreditMemoRet.SelectSingleNode("./ItemSalesTaxRef/FullName").InnerText;
                            //    }

                            //    if (CreditMemoRet.SelectSingleNode("./TotalAmount") != null)
                            //    {
                            //        oCreditMemoRow.Total = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./TotalAmount").InnerText);

                            //    }
                            //    //Get value of CreditRemaining
                            //    if (CreditMemoRet.SelectSingleNode("./CreditRemaining") != null)
                            //    {
                            //        oCreditMemoRow.CreditRemaining = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./CreditRemaining").InnerText);

                            //    }


                            //    if (CreditMemoRet.SelectSingleNode("./Memo") != null)
                            //    {
                            //        oCreditMemoRow.CreditMemoMemo = CreditMemoRet.SelectSingleNode("./Memo").InnerText;
                            //    }

                            //    //oCreditMemoRow.Total = (oCreditMemoRow.IsSubtotalNull() ? 0 : oCreditMemoRow.Subtotal) + (oCreditMemoRow.IsSalesTaxTotalNull() ? 0 : oCreditMemoRow.SalesTaxTotal);

                            //    //if (CreditMemoRet.SelectSingleNode("./TemplateRef") != null && CreditMemoRet.SelectSingleNode("./TemplateRef/FullName") != null)
                            //    //{
                            //    //    oCreditMemoRow.CreditMemoTemplate = CreditMemoRet.SelectSingleNode("./TemplateRef/FullName").InnerText;
                            //    //}

                            //    //Get all field values for CurrencyRef aggregate 
                            //    XmlNode CurrencyRef = CreditMemoRet.SelectSingleNode("./CurrencyRef");
                            //    if (CurrencyRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (CreditMemoRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                            //        {
                            //            oCreditMemoRow.Currency = CreditMemoRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                            //        }
                            //    }

                            //    if (CreditMemoRet.SelectSingleNode("./ExchangeRate") != null)
                            //    {
                            //        oCreditMemoRow.CurrencyRate = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./ExchangeRate").InnerText);
                            //    }

                            //    //Done with field values for CurrencyRef aggregate

                            //    taCreditMemo.Update(oCreditMemoRow);

                            //    XmlNodeList ORCreditMemoLineRetListChildren = CreditMemoRet.SelectNodes("./CreditMemoLineRet");
                            //    for (int j = 0; j < ORCreditMemoLineRetListChildren.Count; j++)
                            //    {
                            //        XmlNode Child = ORCreditMemoLineRetListChildren.Item(j);
                            //        if (Child.Name == "CreditMemoLineRet")
                            //        {
                            //            var oDetailRow = ds.CreditMemoDetail.NewCreditMemoDetailRow();

                            //            oDetailRow.TxnID = TxnID;
                            //            oDetailRow.CreditMemoID = oCreditMemoRow.CreditMemoID;
                            //            oDetailRow.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;

                            //            Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();
                            //            if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/ListID") != null)
                            //            {
                            //                oDetailRow.ItemListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;

                            //                taItem.FillByQBListID(ds.Items, oDetailRow.ItemListID);
                            //                if (ds.Items.Count() > 0)
                            //                {
                            //                    var itemRow = ds.Items[0];
                            //                    oDetailRow.ItemID = itemRow.ItemID;
                            //                }
                            //            }
                            //            //if (String.IsNullOrEmpty(oDetailRow.ItemListID)) continue;

                            //            if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/FullName") != null)
                            //            {
                            //                oDetailRow.ItemFullName = Child.SelectSingleNode("./ItemRef/FullName").InnerText;

                            //                if ((oDetailRow.IsItemIDNull() ? 0 : oDetailRow.ItemID) == 0)
                            //                {
                            //                    taItem.FillByFullName(ds.Items, oDetailRow.ItemFullName);
                            //                    if (ds.Items.Count() > 0)
                            //                    {
                            //                        var itemRow = ds.Items[0];
                            //                        oDetailRow.ItemID = itemRow.ItemID;
                            //                    }
                            //                }
                            //            }
                            //            if (Child.SelectSingleNode("./Desc") != null)
                            //            {
                            //                oDetailRow.DetailDesc = Child.SelectSingleNode("./Desc").InnerText;
                            //            }
                            //            if (Child.SelectSingleNode("./Quantity") != null)
                            //            {
                            //                oDetailRow.Quantity = Convert.ToDouble(Child.SelectSingleNode("./Quantity").InnerText);
                            //            }
                            //            if (Child.SelectSingleNode("./Rate") != null)
                            //            {
                            //                oDetailRow.Rate = Convert.ToDouble(Child.SelectSingleNode("./Rate").InnerText);
                            //            }
                            //            if (Child.SelectSingleNode("./Amount") != null)
                            //            {
                            //                oDetailRow.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
                            //            }
                            //            if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                            //            {
                            //                oDetailRow.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                            //            }

                            //            ds.CreditMemoDetail.AddCreditMemoDetailRow(oDetailRow);
                            //        }
                            //    }

                            //    taCreditMemoDetail.Update(ds.CreditMemoDetail);

                            //    bgWorker.ReportProgress(0, "CreditMemo # " + oCreditMemoRow.RefNumber);
                            //    bgWorker.ReportProgress(0, "Exported to Server");
                            //    bgWorker.ReportProgress(0, "");

                            //}
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

                bgWorker.ReportProgress(0, "Error! CreditMemo Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        //public bool AddCreditMemo(QBLinxDataService.MdlCreditMemo invoiceRow, string txnId, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        bool isEdit = false; string editSequence = "";
        //        if (!string.IsNullOrEmpty(txnId))
        //        {
        //            editSequence = GetCreditMemoEditSequence(txnId);
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
        //        else if (Common.BranchID == 1 && !string.IsNullOrEmpty(invoiceRow.RefNumber))
        //        {
        //            var mdlInv = GetCreditMemoListID(invoiceRow.RefNumber);
        //            if (!string.IsNullOrEmpty(mdlInv.TxnID))
        //            {
        //                isEdit = true; txnId = mdlInv.TxnID; editSequence = mdlInv.EditSequence;
        //            }
        //        }

        //        if (invoiceRow.CreditMemoDetailLines == null || invoiceRow.CreditMemoDetailLines.Count() == 0)
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
        //        //Create CreditMemoAddRq aggregate and fill in field values for it
        //        XmlElement CreditMemoAddRq = doc.CreateElement(isEdit ? "CreditMemoModRq" : "CreditMemoAddRq");
        //        parent.AppendChild(CreditMemoAddRq);
        //        //Create CreditMemoAdd aggregate and fill in field values for it
        //        XmlElement CreditMemoAdd = doc.CreateElement(isEdit ? "CreditMemoMod" : "CreditMemoAdd");
        //        CreditMemoAddRq.AppendChild(CreditMemoAdd);

        //        if (isEdit)
        //        {
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
        //            //Set field value for EditSequence <!-- required -->
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
        //        }

        //        String CustomerFullName = invoiceRow.CustomerFullName;
        //        CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
        //        //Create CustomerRef aggregate and fill in field values for it
        //        XmlElement CustomerRef = doc.CreateElement("CustomerRef");
        //        CreditMemoAdd.AppendChild(CustomerRef);
        //        //Set field value for ListID <!-- optional -->
        //        CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));

        //        //Set field value for TxnDate <!-- optional -->
        //        CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", invoiceRow.TxnDate.ToString("yyyy-MM-dd")));
        //        //Set field value for RefNumber <!-- optional -->
        //        if (!string.IsNullOrEmpty(invoiceRow.RefNumber))
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", invoiceRow.RefNumber));

        //        //Billing
        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        CreditMemoAdd.AppendChild(BillAddress);

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
        //        CreditMemoAdd.AppendChild(ShipAddress);

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

        //        //Set field value for PONumber <!-- optional -->
        //        if (!String.IsNullOrEmpty(invoiceRow.PONo))
        //        {
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "PONumber", invoiceRow.PONo));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.Terms))
        //        {
        //            //Create TermsRef aggregate and fill in field values for it
        //            XmlElement TermsRef = doc.CreateElement("TermsRef");
        //            CreditMemoAdd.AppendChild(TermsRef);
        //            //Set field value for ListID <!-- optional -->
        //            //TermsRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            TermsRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.Terms));
        //            //Done creating TermsRef aggregate
        //        }

        //        //Set field value for DueDate <!-- optional -->
        //        if (invoiceRow.DueDate > DateTime.MinValue)
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "DueDate", invoiceRow.DueDate.ToString("yyyy-MM-dd")));

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipCountry))
        //        {
        //            //Create SalesRepRef aggregate and fill in field values for it
        //            XmlElement SalesRepRef = doc.CreateElement("SalesRepRef");
        //            CreditMemoAdd.AppendChild(SalesRepRef);
        //            //Set field value for ListID <!-- optional -->
        //            //SalesRepRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            SalesRepRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.SalesRep));
        //            //Done creating SalesRepRef aggregate
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.ShipMethod))
        //        {
        //            //Create ShipMethodRef aggregate and fill in field values for it
        //            XmlElement ShipMethodRef = doc.CreateElement("ShipMethodRef");
        //            CreditMemoAdd.AppendChild(ShipMethodRef);
        //            //Set field value for ListID <!-- optional -->
        //            //ShipMethodRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            ShipMethodRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.ShipMethod));
        //            //Done creating ShipMethodRef aggregate
        //        }

        //        if (!string.IsNullOrEmpty(invoiceRow.CreditMemoMemo))
        //        {
        //            CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "Memo", "Kiểm tra ghi nhớ"));
        //        }

        //        //Set field value for ExchangeRate <!-- optional -->
        //        CreditMemoAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", invoiceRow.CurrencyRate.ToString("###0.00")));


        //        foreach (QBLinxDataService.MdlCreditMemoDetail detailRow in invoiceRow.CreditMemoDetailLines)
        //        {

        //            CreditMemoAdd.AppendChild(AddCreditMemoLine(doc, isEdit ? "CreditMemoLineMod" : "CreditMemoLineAdd", detailRow));

        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        XmlNodeList CreditMemoAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "CreditMemoModRs" : "CreditMemoAddRs");
        //        if (CreditMemoAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = CreditMemoAddRsList.Item(0);
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
        //                        //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
        //                        Customers objCustomer = new Customers();
        //                        if (objCustomer.QBAddCusomter(invoiceRow, bgWorker))
        //                        {
        //                            blnResult = AddCreditMemo(invoiceRow, txnId, bgWorker);
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

        //                            var itmListId = (from st in invoiceRow.CreditMemoDetailLines
        //                                             where st.ItemFullName == ProductName
        //                                             select st.ItemListID).FirstOrDefault();

        //                            if (!string.IsNullOrEmpty(itmListId))
        //                            {
        //                                if (objItem.AddItem(itmListId, invoiceRow.BranchID, bgWorker))
        //                                    blnResult = AddCreditMemo(invoiceRow, txnId, bgWorker);
        //                                else
        //                                {
        //                                    bgWorker.ReportProgress(0, statusMessage);
        //                                    return false;
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in CreditMemo");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (statusCode == "0")
        //                {
        //                    XmlNodeList CreditMemoRetList = responseNode.SelectNodes("//CreditMemoRet");//XPath Query
        //                    for (int i = 0; i < CreditMemoRetList.Count; i++)
        //                    {
        //                        XmlNode CreditMemoRet = CreditMemoRetList.Item(i);
        //                        string newTxnId = CreditMemoRet.SelectSingleNode("./TxnID").InnerText;

        //                        string NewRefNumber = "";
        //                        if (CreditMemoRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            NewRefNumber = CreditMemoRet.SelectSingleNode("./RefNumber").InnerText;
        //                        }

        //                        string CustomerListID = "";
        //                        if (CreditMemoRet.SelectSingleNode("./CustomerRef/ListID") != null)
        //                        {
        //                            CustomerListID = CreditMemoRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                        }

        //                        //Customers objCustomer = new Customers();
        //                        //var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

        //                        using (QBLinxWebService service = new QBLinxWebService())
        //                        {
        //                            string sysNotes = "";

        //                            if (Common.BranchID == 1) sysNotes = System.Environment.NewLine + "Exported to QuickBooks HeadOffice " + DateTime.Now;
        //                            else sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;

        //                            var item = service.UpdateCreditMemoQBInfo(Common.BranchID, invoiceRow.CreditMemoID, true, newTxnId, sysNotes, NewRefNumber);
        //                        }

        //                        bgWorker.ReportProgress(0, "CreditMemo " + (isEdit ? "updated" : "added") + " successfully");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in CreditMemo");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bgWorker.ReportProgress(0, "Error! Adding/Updating in CreditMemo");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
        //    }

        //    return blnResult;
        //}

        //private XmlElement AddCreditMemoLine(XmlDocument inputXMLDoc, string CreditMemoLineAddMod, QBLinxDataService.MdlCreditMemoDetail detailRow)
        //{
        //    //Create CreditMemoLineAdd aggregate and fill in field values for it
        //    XmlElement CreditMemoLine = inputXMLDoc.CreateElement(CreditMemoLineAddMod);

        //    if (CreditMemoLineAddMod == "CreditMemoLineMod")
        //        CreditMemoLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

        //    if (!string.IsNullOrEmpty(detailRow.ItemFullName))
        //    {
        //        //Create ItemRef aggregate and fill in field values for it
        //        XmlElement ItemRef = inputXMLDoc.CreateElement("ItemRef");
        //        CreditMemoLine.AppendChild(ItemRef);
        //        ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.ItemFullName));
        //        //Set field value for Desc <!-- optional -->                           
        //        CreditMemoLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.DetailDesc));

        //        if (detailRow.Quantity > 0)
        //            CreditMemoLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Quantity", detailRow.Quantity.ToString("###0.00")));


        //        CreditMemoLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Rate", detailRow.Rate.ToString("###0.00")));


        //        if (!string.IsNullOrEmpty(detailRow.TaxCode))
        //        {
        //            XmlElement SalesTaxCodeRef = inputXMLDoc.CreateElement("SalesTaxCodeRef");
        //            CreditMemoLine.AppendChild(SalesTaxCodeRef);
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.TaxCode));
        //        }
        //    }
        //    else
        //    {
        //        CreditMemoLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.DetailDesc));
        //    }


        //    return CreditMemoLine;
        //}

        public String GetCreditMemoEditSequence(String TxnID)
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
                XmlElement CreditMemoQueryRq = inputXMLDoc.CreateElement("CreditMemoQueryRq");
                qbXMLMsgsRq.AppendChild(CreditMemoQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CreditMemoQueryRsList = responseXmlDoc.GetElementsByTagName("CreditMemoQueryRs");
                if (CreditMemoQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CreditMemoQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CreditMemoRetList = responseNode.SelectNodes("//CreditMemoRet");//XPath Query
                        for (int i = 0; i < CreditMemoRetList.Count; i++)
                        {
                            XmlNode CreditMemoRet = CreditMemoRetList.Item(i);

                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = CreditMemoRet.SelectSingleNode("./EditSequence").InnerText;

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

        public MdlQB GetCreditMemoListID(String RefNumber)
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
                XmlElement CreditMemoQueryRq = inputXMLDoc.CreateElement("CreditMemoQueryRq");
                qbXMLMsgsRq.AppendChild(CreditMemoQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "RefNumber", RefNumber));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CreditMemoQueryRsList = responseXmlDoc.GetElementsByTagName("CreditMemoQueryRs");
                if (CreditMemoQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CreditMemoQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CreditMemoRetList = responseNode.SelectNodes("//CreditMemoRet");//XPath Query
                        for (int i = 0; i < CreditMemoRetList.Count; i++)
                        {
                            XmlNode CreditMemoRet = CreditMemoRetList.Item(i);

                            mdlResult.TxnID = CreditMemoRet.SelectSingleNode("./TxnID").InnerText;
                            //Get value of EditSequence
                            mdlResult.EditSequence = CreditMemoRet.SelectSingleNode("./EditSequence").InnerText;

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

        public double GetCreditMemoBalanceRemaining(String TxnID)
        {
            double dblResult = 0;
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
                XmlElement CreditMemoQueryRq = inputXMLDoc.CreateElement("CreditMemoQueryRq");
                qbXMLMsgsRq.AppendChild(CreditMemoQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                CreditMemoQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "BalanceRemaining"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList CreditMemoQueryRsList = responseXmlDoc.GetElementsByTagName("CreditMemoQueryRs");
                if (CreditMemoQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = CreditMemoQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList CreditMemoRetList = responseNode.SelectNodes("//CreditMemoRet");//XPath Query
                        for (int i = 0; i < CreditMemoRetList.Count; i++)
                        {
                            XmlNode CreditMemoRet = CreditMemoRetList.Item(i);

                            if (CreditMemoRet.SelectSingleNode("./BalanceRemaining") != null)
                            {
                                dblResult = Convert.ToDouble(CreditMemoRet.SelectSingleNode("./BalanceRemaining").InnerText);
                            }

                            return dblResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dblResult;
        }

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

    }
}
