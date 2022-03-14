using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class Invoices
    {

        public void InvoiceQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement InvoiceQueryRq = doc.CreateElement("InvoiceQueryRq");
                    qbXMLMsgsRq.AppendChild(InvoiceQueryRq);
                    InvoiceQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        InvoiceQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        InvoiceQueryRq.SetAttribute("iteratorID", strIteratorID);

                    InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    //Create ModifiedDateRangeFilter aggregate and fill in field values for it
                    XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
                    InvoiceQueryRq.AppendChild(ModifiedDateRangeFilter);
                    //Set field value for FromModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    //Set field value for ToModifiedDate <!-- optional -->
                    if (Common.UseQBQueryToDate)
                        ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Done creating ModifiedDateRangeFilter aggregate

                    InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

                    //Set field value for IncludeLinkedTxns <!-- optional -->
                    InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLinkedTxns", "1"));

                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList InvoiceQueryRsList = responseXmlDoc.GetElementsByTagName("InvoiceQueryRs");
                    if (InvoiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = InvoiceQueryRsList.Item(0);
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
                        //if (Convert.ToInt32(statusCode) == 0)
                        //{
                        //    XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query

                        //    Data.dsQBSyncTableAdapters.InvoiceTableAdapter taInvoice = new Data.dsQBSyncTableAdapters.InvoiceTableAdapter();
                        //    Data.dsQBSyncTableAdapters.InvoiceDetailTableAdapter taInvoiceDetail = new Data.dsQBSyncTableAdapters.InvoiceDetailTableAdapter();

                        //    for (int i = 0; i < InvoiceRetList.Count; i++)
                        //    {
                        //        XmlNode InvoiceRet = InvoiceRetList.Item(i);

                        //        if (InvoiceRet == null) continue;

                        //        string TxnID = InvoiceRet.SelectSingleNode("./TxnID").InnerText;

                        //        Data.dsQBSync ds = new Data.dsQBSync();
                        //        ds.EnforceConstraints = false;

                        //        var oInvoiceRow = ds.Invoice.NewInvoiceRow();
                        //        taInvoice.FillByTxnID(ds.Invoice, TxnID);
                        //        if (ds.Invoice.Count() > 0)
                        //        {
                        //            oInvoiceRow = ds.Invoice[0];

                        //            taInvoiceDetail.DeleteByInvoiceID(oInvoiceRow.InvoiceID);
                        //        }
                        //        else
                        //        {
                        //            ds.Invoice.AddInvoiceRow(oInvoiceRow);
                        //            oInvoiceRow.TxnID = TxnID;
                        //            oInvoiceRow.UserID = 0;
                        //            oInvoiceRow.InvoiceStatus = 1;
                        //            oInvoiceRow.SystemNotes = "Exported to Portal On: " + System.DateTime.Now;
                        //        }

                        //        oInvoiceRow.IsQBSync = true;

                        //        //oInvoice.UtcOffset = Common.LoginUser.UtcOffset;
                        //        oInvoiceRow.TimeCreated = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./TimeCreated").InnerText);
                        //        oInvoiceRow.TimeModified = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./TimeModified").InnerText);

                        //        Data.dsQBSyncTableAdapters.CustomersTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomersTableAdapter();                                   
                        //        if (InvoiceRet.SelectSingleNode("./CustomerRef/ListID") != null)
                        //        {
                        //            oInvoiceRow.CustomerListID = InvoiceRet.SelectSingleNode("./CustomerRef/ListID").InnerText;

                        //            taCustomer.FillByQBListID(ds.Customers, oInvoiceRow.CustomerListID);
                        //            if (ds.Customers.Count() > 0)
                        //            {
                        //                var customerRow = ds.Customers[0];
                        //                oInvoiceRow.CustomerID = customerRow.CustomerID;
                        //            }
                        //        }
                        //        //Get value of FullName
                        //        if (InvoiceRet.SelectSingleNode("./CustomerRef/FullName") != null)
                        //        {
                        //            oInvoiceRow.CustomerFullName = InvoiceRet.SelectSingleNode("./CustomerRef/FullName").InnerText;

                        //            if ((oInvoiceRow.IsCustomerIDNull() ? 0 : oInvoiceRow.CustomerID) == 0)
                        //            {
                        //                taCustomer.FillByFullName(ds.Customers, oInvoiceRow.CustomerFullName);
                        //                if (ds.Customers.Count() > 0)
                        //                {
                        //                    var customerRow = ds.Customers[0];
                        //                    oInvoiceRow.CustomerID = customerRow.CustomerID;
                        //                }
                        //            }
                        //        }

                        //        if ((oInvoiceRow.IsCustomerIDNull() ? 0 : oInvoiceRow.CustomerID) == 0) continue;

                        //        oInvoiceRow.TxnDate = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./TxnDate").InnerText);
                        //        //Get value of RefNumber
                        //        if (InvoiceRet.SelectSingleNode("./RefNumber") != null)
                        //        {
                        //            oInvoiceRow.RefNumber = InvoiceRet.SelectSingleNode("./RefNumber").InnerText;

                        //        }
                        //        //Get all field values for BillAddress aggregate 
                        //        XmlNode BillAddress = InvoiceRet.SelectSingleNode("./BillAddress");
                        //        if (BillAddress != null)
                        //        {
                        //            //Get value of Addr1
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/Addr1") != null)
                        //            {
                        //                oInvoiceRow.BillAdd1 = InvoiceRet.SelectSingleNode("./BillAddress/Addr1").InnerText;

                        //            }
                        //            //Get value of Addr2
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/Addr2") != null)
                        //            {
                        //                oInvoiceRow.BillAdd2 = InvoiceRet.SelectSingleNode("./BillAddress/Addr2").InnerText;

                        //            }
                        //            //Get value of Addr3
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/Addr3") != null)
                        //            {
                        //                oInvoiceRow.BillAdd3 = InvoiceRet.SelectSingleNode("./BillAddress/Addr3").InnerText;

                        //            }
                        //            //Get value of City
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/City") != null)
                        //            {
                        //                oInvoiceRow.BillCity = InvoiceRet.SelectSingleNode("./BillAddress/City").InnerText;

                        //            }
                        //            //Get value of State
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/State") != null)
                        //            {
                        //                oInvoiceRow.BillState = InvoiceRet.SelectSingleNode("./BillAddress/State").InnerText;

                        //            }
                        //            //Get value of PostalCode
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/PostalCode") != null)
                        //            {
                        //                oInvoiceRow.BillPostalCode = InvoiceRet.SelectSingleNode("./BillAddress/PostalCode").InnerText;

                        //            }
                        //            //Get value of Country
                        //            if (InvoiceRet.SelectSingleNode("./BillAddress/Country") != null)
                        //            {
                        //                oInvoiceRow.BillCountry = InvoiceRet.SelectSingleNode("./BillAddress/Country").InnerText;

                        //            }
                        //        }

                        //        //Get all field values for ShipAddress aggregate 
                        //        XmlNode ShipAddress = InvoiceRet.SelectSingleNode("./ShipAddress");
                        //        if (ShipAddress != null)
                        //        {
                        //            //Get value of Addr1
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr1") != null)
                        //            {
                        //                oInvoiceRow.ShipAdd1 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr1").InnerText;

                        //            }
                        //            //Get value of Addr2
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr2") != null)
                        //            {
                        //                oInvoiceRow.ShipAdd2 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr2").InnerText;

                        //            }
                        //            //Get value of Addr3
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr3") != null)
                        //            {
                        //                oInvoiceRow.ShipAdd3 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr3").InnerText;

                        //            }
                        //            //Get value of City
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/City") != null)
                        //            {
                        //                oInvoiceRow.ShipCity = InvoiceRet.SelectSingleNode("./ShipAddress/City").InnerText;

                        //            }
                        //            //Get value of State
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/State") != null)
                        //            {
                        //                oInvoiceRow.ShipState = InvoiceRet.SelectSingleNode("./ShipAddress/State").InnerText;

                        //            }
                        //            //Get value of PostalCode
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/PostalCode") != null)
                        //            {
                        //                oInvoiceRow.ShipPostalCode = InvoiceRet.SelectSingleNode("./ShipAddress/PostalCode").InnerText;

                        //            }
                        //            //Get value of Country
                        //            if (InvoiceRet.SelectSingleNode("./ShipAddress/Country") != null)
                        //            {
                        //                oInvoiceRow.ShipCountry = InvoiceRet.SelectSingleNode("./ShipAddress/Country").InnerText;

                        //            }
                        //        }

                        //        if (InvoiceRet.SelectSingleNode("./PONumber") != null)
                        //        {
                        //            oInvoiceRow.CustomerPONo = InvoiceRet.SelectSingleNode("./PONumber").InnerText;

                        //        }
                        //        //Get all field values for TermsRef aggregate 
                        //        XmlNode TermsRef = InvoiceRet.SelectSingleNode("./TermsRef");
                        //        if (TermsRef != null)
                        //        {
                        //            //Get value of FullName
                        //            if (InvoiceRet.SelectSingleNode("./TermsRef/FullName") != null)
                        //            {
                        //                oInvoiceRow.PaymentTerms = InvoiceRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                        //            }
                        //        }
                        //        //Done with field values for TermsRef aggregate

                        //        //Get value of DueDate
                        //        if (InvoiceRet.SelectSingleNode("./DueDate") != null)
                        //        {
                        //            oInvoiceRow.DueDate = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./DueDate").InnerText);

                        //        }
                        //        //Get all field values for SalesRepRef aggregate 
                        //        //XmlNode SalesRepRef = InvoiceRet.SelectSingleNode("./SalesRepRef");
                        //        //if (SalesRepRef != null)
                        //        //{
                        //        //    //Get value of FullName
                        //        //    if (InvoiceRet.SelectSingleNode("./SalesRepRef/FullName") != null)
                        //        //    {
                        //        //        oInvoiceRow.SalesRep = InvoiceRet.SelectSingleNode("./SalesRepRef/FullName").InnerText;
                        //        //    }
                        //        //}
                        //        //Done with field values for SalesRepRef aggregate

                        //        //Get all field values for ShipMethodRef aggregate 
                        //        XmlNode ShipMethodRef = InvoiceRet.SelectSingleNode("./ShipMethodRef");
                        //        if (ShipMethodRef != null)
                        //        {
                        //            //Get value of FullName
                        //            if (InvoiceRet.SelectSingleNode("./ShipMethodRef/FullName") != null)
                        //            {
                        //                oInvoiceRow.ShipMethod = InvoiceRet.SelectSingleNode("./ShipMethodRef/FullName").InnerText;
                        //            }
                        //        }
                        //        //Done with field values for ShipMethodRef aggregate


                        //        if (InvoiceRet.SelectSingleNode("./Subtotal") != null)
                        //        {
                        //            oInvoiceRow.Subtotal = Convert.ToDouble(InvoiceRet.SelectSingleNode("./Subtotal").InnerText);

                        //        }

                        //        //Get value of SalesTaxPercentage
                        //        if (InvoiceRet.SelectSingleNode("./SalesTaxPercentage") != null)
                        //        {
                        //            oInvoiceRow.SalesTaxPercentage = Convert.ToDouble(InvoiceRet.SelectSingleNode("./SalesTaxPercentage").InnerText);

                        //        }

                        //        if (InvoiceRet.SelectSingleNode("./SalesTaxTotal") != null)
                        //        {
                        //            oInvoiceRow.SalesTaxTotal = Convert.ToDouble(InvoiceRet.SelectSingleNode("./SalesTaxTotal").InnerText);

                        //        }

                        //        if (InvoiceRet.SelectSingleNode("./ItemSalesTaxRef") != null && InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/FullName") != null)
                        //        {
                        //            oInvoiceRow.SalesTaxItem = InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/FullName").InnerText;
                        //        }

                        //        //Get value of AppliedAmount
                        //        if (InvoiceRet.SelectSingleNode("./AppliedAmount") != null)
                        //        {
                        //            oInvoiceRow.AppliedAmount = Convert.ToDouble(InvoiceRet.SelectSingleNode("./AppliedAmount").InnerText);

                        //        }

                        //        //Get value of BalanceRemaining
                        //        if (InvoiceRet.SelectSingleNode("./BalanceRemaining") != null)
                        //        {
                        //            oInvoiceRow.BalanceRemaining = Convert.ToDouble(InvoiceRet.SelectSingleNode("./BalanceRemaining").InnerText);

                        //        }
                        //        if (InvoiceRet.SelectSingleNode("./Memo") != null)
                        //        {
                        //            oInvoiceRow.InvoiceMemo = InvoiceRet.SelectSingleNode("./Memo").InnerText;
                        //        }

                        //        oInvoiceRow.Total = (oInvoiceRow.IsSubtotalNull() ? 0 : oInvoiceRow.Subtotal) + (oInvoiceRow.IsSalesTaxTotalNull() ? 0 : oInvoiceRow.SalesTaxTotal);

                        //        //if (InvoiceRet.SelectSingleNode("./TemplateRef") != null && InvoiceRet.SelectSingleNode("./TemplateRef/FullName") != null)
                        //        //{
                        //        //    oInvoiceRow.InvoiceTemplate = InvoiceRet.SelectSingleNode("./TemplateRef/FullName").InnerText;
                        //        //}

                        //        //Get all field values for CurrencyRef aggregate 
                        //        XmlNode CurrencyRef = InvoiceRet.SelectSingleNode("./CurrencyRef");
                        //        if (CurrencyRef != null)
                        //        {
                        //            //Get value of FullName
                        //            if (InvoiceRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                        //            {
                        //                oInvoiceRow.Currency = InvoiceRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                        //            }
                        //        }

                        //        if (InvoiceRet.SelectSingleNode("./ExchangeRate") != null)
                        //        {
                        //            oInvoiceRow.CurrencyRate = Convert.ToDouble(InvoiceRet.SelectSingleNode("./ExchangeRate").InnerText);
                        //        }

                        //        //Done with field values for CurrencyRef aggregate

                        //        taInvoice.Update(oInvoiceRow);

                        //        XmlNodeList ORInvoiceLineRetListChildren = InvoiceRet.SelectNodes("./InvoiceLineRet");
                        //        for (int j = 0; j < ORInvoiceLineRetListChildren.Count; j++)
                        //        {
                        //            XmlNode Child = ORInvoiceLineRetListChildren.Item(j);
                        //            if (Child.Name == "InvoiceLineRet")
                        //            {
                        //                var oDetailRow = ds.InvoiceDetail.NewInvoiceDetailRow();

                        //                oDetailRow.TxnID = TxnID;
                        //                oDetailRow.InvoiceID = oInvoiceRow.InvoiceID;
                        //                oDetailRow.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;

                        //                Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();                                           
                        //                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/ListID") != null)
                        //                {
                        //                    oDetailRow.ItemListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;

                        //                    taItem.FillByQBListID(ds.Items, oDetailRow.ItemListID);
                        //                    if (ds.Items.Count() > 0)
                        //                    {
                        //                        var itemRow = ds.Items[0];
                        //                        oDetailRow.ItemID = itemRow.ItemID;
                        //                    }
                        //                }
                        //                //if (String.IsNullOrEmpty(oDetailRow.ItemListID)) continue;

                        //                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/FullName") != null)
                        //                {
                        //                    oDetailRow.ItemFullName = Child.SelectSingleNode("./ItemRef/FullName").InnerText;

                        //                    if ((oDetailRow.IsItemIDNull() ? 0 : oDetailRow.ItemID) == 0)
                        //                    {
                        //                        taItem.FillByFullName(ds.Items, oDetailRow.ItemFullName);
                        //                        if (ds.Items.Count() > 0)
                        //                        {
                        //                            var itemRow = ds.Items[0];
                        //                            oDetailRow.ItemID = itemRow.ItemID;
                        //                        }
                        //                    }
                        //                }
                        //                if (Child.SelectSingleNode("./Desc") != null)
                        //                {
                        //                    oDetailRow.DetailDesc = Child.SelectSingleNode("./Desc").InnerText;
                        //                }
                        //                if (Child.SelectSingleNode("./Quantity") != null)
                        //                {
                        //                    oDetailRow.Quantity = Convert.ToDouble(Child.SelectSingleNode("./Quantity").InnerText);
                        //                }
                        //                if (Child.SelectSingleNode("./Rate") != null)
                        //                {
                        //                    oDetailRow.Rate = Convert.ToDouble(Child.SelectSingleNode("./Rate").InnerText);
                        //                }
                        //                if (Child.SelectSingleNode("./Amount") != null)
                        //                {
                        //                    oDetailRow.Amount = Convert.ToDouble(Child.SelectSingleNode("./Amount").InnerText);
                        //                }

                        //                if (Child.SelectSingleNode("./SalesTaxCodeRef") != null && Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                        //                {
                        //                    oDetailRow.TaxCode = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                        //                }

                        //                ds.InvoiceDetail.AddInvoiceDetailRow(oDetailRow);
                        //            }
                        //        }

                        //        taInvoiceDetail.Update(ds.InvoiceDetail);

                        //        bgWorker.ReportProgress(0, "Invoice # " + oInvoiceRow.RefNumber);
                        //        bgWorker.ReportProgress(0, "Exported to Server");
                        //        bgWorker.ReportProgress(0, "");

                        //    }
                        //}
                        //else
                        //{
                        //    bgWorker.ReportProgress(0, statusMessage);
                        //}
                    }
                }
                while (Convert.ToInt32(strRemaining) > 0);
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Invoice Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public bool AddInvoice(Data.dsQBSync.WorkOrderRow invoiceRow, string txnId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            bool blnResult = false;
            Data.dsQBSync ds = new Data.dsQBSync();
            ds.EnforceConstraints = false;
            Data.dsQBSyncTableAdapters.WorkOrderDetailTableAdapter taWorkorderDetail = new Data.dsQBSyncTableAdapters.WorkOrderDetailTableAdapter();
            Data.dsQBSyncTableAdapters.WorkOrderTableAdapter taWorkOrder = new Data.dsQBSyncTableAdapters.WorkOrderTableAdapter();
            try
            {
                bool isEdit = false; string editSequence = "";
                if (!string.IsNullOrEmpty(txnId))
                {
                    editSequence = GetInvoiceEditSequence(txnId);
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
                else if (!invoiceRow.IsWorkOrderNoNull())
                {
                    var mdlInv = GetInvoiceListID(invoiceRow.WorkOrderNo.ToString());
                    if (!string.IsNullOrEmpty(mdlInv.TxnID))
                    {
                        isEdit = true; txnId = mdlInv.TxnID; editSequence = mdlInv.EditSequence;
                    }
                }



                taWorkorderDetail.FillByWOID(ds.WorkOrderDetail, invoiceRow.ID);
                if (ds.WorkOrderDetail.Rows.Count == 0)
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
                //Create InvoiceAddRq aggregate and fill in field values for it
                XmlElement InvoiceAddRq = doc.CreateElement(isEdit ? "InvoiceModRq" : "InvoiceAddRq");
                parent.AppendChild(InvoiceAddRq);
                //Create InvoiceAdd aggregate and fill in field values for it
                XmlElement InvoiceAdd = doc.CreateElement(isEdit ? "InvoiceMod" : "InvoiceAdd");
                InvoiceAddRq.AppendChild(InvoiceAdd);

                if (isEdit)
                {
                    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
                    //Set field value for EditSequence <!-- required -->
                    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
                }

                //String CustomerFullName = invoiceRow.CustomerFullName;
                //CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
                //Create CustomerRef aggregate and fill in field values for it
                XmlElement CustomerRef = doc.CreateElement("CustomerRef");
                InvoiceAdd.AppendChild(CustomerRef);
                //Set field value for ListID <!-- optional -->
                //CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));
                CustomerRef.AppendChild(MakeSimpleElem(doc, "ListID", invoiceRow.CustomerListID));


                //Set field value for TxnDate <!-- optional -->
                DateTime dtTransaction = invoiceRow.IsRegDateNull() ? DateTime.Now : invoiceRow.RegDate;
                InvoiceAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", dtTransaction.ToString("yyyy-MM-dd")));
                //Set field value for RefNumber <!-- optional -->
                if (!invoiceRow.IsWorkOrderNoNull())
                    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", invoiceRow.WorkOrderNo.ToString()));

                //Billing
                //XmlElement BillAddress = doc.CreateElement("BillAddress");
                //InvoiceAdd.AppendChild(BillAddress);

                //if (!String.IsNullOrEmpty(invoiceRow.BillAdd1))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.BillAdd1, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillAdd2))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(invoiceRow.BillAdd2, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillAdd3))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(invoiceRow.BillAdd3, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillCity))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.BillCity, 31)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillState))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.BillState, 21)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillPostalCode))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.BillPostalCode, 13)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.BillCountry))
                //{
                //    BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.BillCountry, 21)));
                //}


                ////Shiping
                //XmlElement ShipAddress = doc.CreateElement("ShipAddress");
                //InvoiceAdd.AppendChild(ShipAddress);

                //if (!String.IsNullOrEmpty(invoiceRow.ShipAdd1))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.ShipAdd1, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipAdd2))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(invoiceRow.ShipAdd2, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipAdd3))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(invoiceRow.ShipAdd3, 39)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipCity))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.ShipCity, 31)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipState))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.ShipState, 21)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipPostalCode))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.ShipPostalCode, 13)));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipCountry))
                //{
                //    ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.ShipCountry, 21)));
                //}

                //Set field value for PONumber <!-- optional -->
                //if (!String.IsNullOrEmpty(invoiceRow.PONo))
                //{
                //    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "PONumber", invoiceRow.PONo));
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.Terms))
                //{
                //    //Create TermsRef aggregate and fill in field values for it
                //    XmlElement TermsRef = doc.CreateElement("TermsRef");
                //    InvoiceAdd.AppendChild(TermsRef);
                //    //Set field value for ListID <!-- optional -->
                //    //TermsRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                //    //Set field value for FullName <!-- optional -->
                //    TermsRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.Terms));
                //    //Done creating TermsRef aggregate
                //}

                //Set field value for DueDate <!-- optional -->
                //if (invoiceRow.DueDate > DateTime.MinValue)
                //    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "DueDate", invoiceRow.DueDate.ToString("yyyy-MM-dd")));

                //if (!String.IsNullOrEmpty(invoiceRow.ShipCountry))
                //{
                //    //Create SalesRepRef aggregate and fill in field values for it
                //    XmlElement SalesRepRef = doc.CreateElement("SalesRepRef");
                //    InvoiceAdd.AppendChild(SalesRepRef);
                //    //Set field value for ListID <!-- optional -->
                //    //SalesRepRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                //    //Set field value for FullName <!-- optional -->
                //    SalesRepRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.SalesRep));
                //    //Done creating SalesRepRef aggregate
                //}

                //if (!String.IsNullOrEmpty(invoiceRow.ShipMethod))
                //{
                //    //Create ShipMethodRef aggregate and fill in field values for it
                //    XmlElement ShipMethodRef = doc.CreateElement("ShipMethodRef");
                //    InvoiceAdd.AppendChild(ShipMethodRef);
                //    //Set field value for ListID <!-- optional -->
                //    //ShipMethodRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                //    //Set field value for FullName <!-- optional -->
                //    ShipMethodRef.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.ShipMethod));
                //    //Done creating ShipMethodRef aggregate
                //}

                //if (!string.IsNullOrEmpty(invoiceRow.InvoiceMemo))
                //{
                //    InvoiceAdd.AppendChild(MakeSimpleElem(doc, "Memo", "Kiểm tra ghi nhớ"));
                //}

                ////Set field value for ExchangeRate <!-- optional -->
                //InvoiceAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", invoiceRow.CurrencyRate.ToString("###0.00")));

                if (!invoiceRow.IsTaxCodeNull())
                {
                    //Create TermsRef aggregate and fill in field values for it
                    XmlElement ItemSalesTax = doc.CreateElement("ItemSalesTaxRef");
                    InvoiceAdd.AppendChild(ItemSalesTax);

                    ItemSalesTax.AppendChild(MakeSimpleElem(doc, "FullName", invoiceRow.TaxCode));
                    //Done creating TermsRef aggregate
                }
                foreach (Data.dsQBSync.WorkOrderDetailRow detailRow in ds.WorkOrderDetail)
                {

                    InvoiceAdd.AppendChild(AddInvoiceLine(doc, isEdit ? "InvoiceLineMod" : "InvoiceLineAdd", detailRow));

                }

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

                XmlNodeList InvoiceAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "InvoiceModRs" : "InvoiceAddRs");
                if (InvoiceAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = InvoiceAddRsList.Item(0);
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
                                //bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
                                //Customers objCustomer = new Customers();
                                //if (objCustomer.QBAddCusomter(invoiceRow, bgWorker))
                                //{
                                //    blnResult = AddInvoice(invoiceRow, txnId, bgWorker);
                                //}
                                //else
                                //{
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
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

                                //    var itmListId = (from st in invoiceRow.InvoiceDetailLines
                                //                     where st.ItemFullName == ProductName
                                //                     select st.ItemListID).FirstOrDefault();

                                //    if (!string.IsNullOrEmpty(itmListId))
                                //    {
                                //        if (objItem.AddItem(itmListId, invoiceRow.BranchID, bgWorker))
                                //            blnResult = AddInvoice(invoiceRow, txnId, bgWorker);
                                //        else
                                //        {
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                                //        }
                                //    }
                                //}
                            }
                            else
                            {
                                bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Invoice");
                                bgWorker.ReportProgress(0, statusMessage);
                                return false;
                            }
                        }
                        else if (statusCode == "0")
                        {
                            XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query
                            for (int i = 0; i < InvoiceRetList.Count; i++)
                            {
                                XmlNode InvoiceRet = InvoiceRetList.Item(i);
                                string newTxnId = InvoiceRet.SelectSingleNode("./TxnID").InnerText;
                                var TimeCreated = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./TimeCreated").InnerText);
                                var TimeModified = Convert.ToDateTime(InvoiceRet.SelectSingleNode("./TimeModified").InnerText);

                                string NewRefNumber = "";
                                if (InvoiceRet.SelectSingleNode("./RefNumber") != null)
                                {
                                    NewRefNumber = InvoiceRet.SelectSingleNode("./RefNumber").InnerText;
                                }

                                string CustomerListID = "";
                                if (InvoiceRet.SelectSingleNode("./CustomerRef/ListID") != null)
                                {
                                    CustomerListID = InvoiceRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
                                }
                                taWorkOrder.UpdateQBFields(newTxnId, TimeModified, invoiceRow.ID);
                                //Customers objCustomer = new Customers();
                                //var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

                                //using (QBLinxWebService service = new QBLinxWebService())
                                //{
                                string sysNotes = "";

                                //if (Common.BranchID == 1) 
                                sysNotes = System.Environment.NewLine + "Exported to QuickBooks " + DateTime.Now;
                                //else 
                                //sysNotes = System.Environment.NewLine + "Exported to QuickBooks Branch " + DateTime.Now;



                                //}

                                bgWorker.ReportProgress(0, "Invoice " + (isEdit ? "updated" : "added") + " successfully");
                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Invoice");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bgWorker.ReportProgress(0, "Error! Adding/Updating in Invoice");
                bgWorker.ReportProgress(0, ex.Message);
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            }

            return blnResult;
        }

        private XmlElement AddInvoiceLine(XmlDocument inputXMLDoc, string InvoiceLineAddMod, Data.dsQBSync.WorkOrderDetailRow detailRow)
        {
            //Create InvoiceLineAdd aggregate and fill in field values for it
            XmlElement InvoiceLine = inputXMLDoc.CreateElement(InvoiceLineAddMod);

            if (InvoiceLineAddMod == "InvoiceLineMod")
                InvoiceLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

            if (!string.IsNullOrEmpty(detailRow.ItemListID))
            {
                //Create ItemRef aggregate and fill in field values for it
                XmlElement ItemRef = inputXMLDoc.CreateElement("ItemRef");
                InvoiceLine.AppendChild(ItemRef);
                //ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.ItemFullName));
                ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", detailRow.ItemListID));
                //Set field value for Desc <!-- optional -->                           
                InvoiceLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.IsCommentsNull() ? "" : detailRow.Comments));

                if (detailRow.Qty > 0)
                    InvoiceLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Quantity", detailRow.Qty.ToString("###0.00")));

                InvoiceLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Rate", detailRow.Price.ToString("###0.00")));

                if (!detailRow.IsIsItemTaxableNull())
                {
                    XmlElement SalesTaxCodeRef = inputXMLDoc.CreateElement("SalesTaxCodeRef");
                    InvoiceLine.AppendChild(SalesTaxCodeRef);
                    if (detailRow.IsItemTaxable)
                        SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", "Tax"));
                    else
                        SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", "Non"));
                }
            }
            else
            {
                InvoiceLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.Comments));
            }


            return InvoiceLine;
        }

        public String GetInvoiceEditSequence(String TxnID)
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
                XmlElement InvoiceQueryRq = inputXMLDoc.CreateElement("InvoiceQueryRq");
                qbXMLMsgsRq.AppendChild(InvoiceQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList InvoiceQueryRsList = responseXmlDoc.GetElementsByTagName("InvoiceQueryRs");
                if (InvoiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = InvoiceQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query
                        for (int i = 0; i < InvoiceRetList.Count; i++)
                        {
                            XmlNode InvoiceRet = InvoiceRetList.Item(i);

                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = InvoiceRet.SelectSingleNode("./EditSequence").InnerText;

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

        public MdlQB GetInvoiceListID(String RefNumber)
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
                XmlElement InvoiceQueryRq = inputXMLDoc.CreateElement("InvoiceQueryRq");
                qbXMLMsgsRq.AppendChild(InvoiceQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "RefNumber", RefNumber));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList InvoiceQueryRsList = responseXmlDoc.GetElementsByTagName("InvoiceQueryRs");
                if (InvoiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = InvoiceQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query
                        for (int i = 0; i < InvoiceRetList.Count; i++)
                        {
                            XmlNode InvoiceRet = InvoiceRetList.Item(i);

                            mdlResult.TxnID = InvoiceRet.SelectSingleNode("./TxnID").InnerText;
                            //Get value of EditSequence
                            mdlResult.EditSequence = InvoiceRet.SelectSingleNode("./EditSequence").InnerText;

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

        public double GetInvoiceBalanceRemaining(String TxnID)
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
                XmlElement InvoiceQueryRq = inputXMLDoc.CreateElement("InvoiceQueryRq");
                qbXMLMsgsRq.AppendChild(InvoiceQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                InvoiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "BalanceRemaining"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList InvoiceQueryRsList = responseXmlDoc.GetElementsByTagName("InvoiceQueryRs");
                if (InvoiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = InvoiceQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query
                        for (int i = 0; i < InvoiceRetList.Count; i++)
                        {
                            XmlNode InvoiceRet = InvoiceRetList.Item(i);

                            if (InvoiceRet.SelectSingleNode("./BalanceRemaining") != null)
                            {
                                dblResult = Convert.ToDouble(InvoiceRet.SelectSingleNode("./BalanceRemaining").InnerText);
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
