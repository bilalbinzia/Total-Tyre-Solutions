using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class SalesOrder
    {
        public void SalesOrderQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement SalesOrderQueryRq = doc.CreateElement("SalesOrderQueryRq");
                    qbXMLMsgsRq.AppendChild(SalesOrderQueryRq);
                    SalesOrderQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        SalesOrderQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        SalesOrderQueryRq.SetAttribute("iteratorID", strIteratorID);

                    SalesOrderQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    //Create ModifiedDateRangeFilter aggregate and fill in field values for it
                    XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
                    SalesOrderQueryRq.AppendChild(ModifiedDateRangeFilter);
                    //Set field value for FromModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    //Set field value for ToModifiedDate <!-- optional -->
                    if (Common.UseQBQueryToDate)
                        ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Done creating ModifiedDateRangeFilter aggregate

                    SalesOrderQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

                    //Set field value for IncludeLinkedTxns <!-- optional -->
                    SalesOrderQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLinkedTxns", "1"));


                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList SalesOrderQueryRsList = responseXmlDoc.GetElementsByTagName("SalesOrderQueryRs");
                    if (SalesOrderQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = SalesOrderQueryRsList.Item(0);
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
                            XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query

                            //Data.dsQBSyncTableAdapters.OrdersTableAdapter taOrder = new Data.dsQBSyncTableAdapters.OrdersTableAdapter();
                            //Data.dsQBSyncTableAdapters.OrderDetailTableAdapter taOrderDetail = new Data.dsQBSyncTableAdapters.OrderDetailTableAdapter();

                            for (int i = 0; i < SalesOrderRetList.Count; i++)
                            {
                                XmlNode SalesOrderRet = SalesOrderRetList.Item(i);

                                if (SalesOrderRet == null) continue;

                                string TxnID = SalesOrderRet.SelectSingleNode("./TxnID").InnerText;

                                Data.dsQBSync ds = new Data.dsQBSync();
                                ds.EnforceConstraints = false;

                                //var oOrderRow = ds.Orders.NewOrdersRow();
                                //taOrder.FillByTxnID(ds.Orders, TxnID);
                                //if (ds.Orders.Count() > 0)
                                //{
                                //    oOrderRow = ds.Orders[0];

                                //    taOrderDetail.DeleteByOrderID(oOrderRow.OrderID);
                                //    oOrderRow.SystemNotes = "Updated from QuickBooks On: " + System.DateTime.Now;
                                //}
                                //else
                                //{
                                //    ds.Orders.AddOrdersRow(oOrderRow);
                                //    oOrderRow.TxnID = TxnID;
                                //    oOrderRow.UserID = 0;
                                //    oOrderRow.OrderStatus = 1;
                                //    oOrderRow.SystemNotes = "Exported to Portal On: " + System.DateTime.Now;
                                //}

                            //    oOrderRow.IsQBSync = true;

                            //    //oSalesOrder.UtcOffset = Common.LoginUser.UtcOffset;
                            //    oOrderRow.TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //    oOrderRow.TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);

                            //    Data.dsQBSyncTableAdapters.CustomersTableAdapter taCustomer = new Data.dsQBSyncTableAdapters.CustomersTableAdapter();
                            //    if (SalesOrderRet.SelectSingleNode("./CustomerRef/ListID") != null)
                            //    {
                            //        oOrderRow.CustomerListID = SalesOrderRet.SelectSingleNode("./CustomerRef/ListID").InnerText;

                            //        taCustomer.FillByQBListID(ds.Customers, oOrderRow.CustomerListID);
                            //        if (ds.Customers.Count() > 0)
                            //        {
                            //            var customerRow = ds.Customers[0];
                            //            oOrderRow.CustomerID = customerRow.CustomerID;
                            //        }
                            //    }
                            //    //Get value of FullName
                            //    if (SalesOrderRet.SelectSingleNode("./CustomerRef/FullName") != null)
                            //    {
                            //        oOrderRow.CustomerFullName = SalesOrderRet.SelectSingleNode("./CustomerRef/FullName").InnerText;

                            //        if ((oOrderRow.IsCustomerIDNull() ? 0 : oOrderRow.CustomerID) == 0)
                            //        {
                            //            taCustomer.FillByFullName(ds.Customers, oOrderRow.CustomerFullName);
                            //            if (ds.Customers.Count() > 0)
                            //            {
                            //                var customerRow = ds.Customers[0];
                            //                oOrderRow.CustomerID = customerRow.CustomerID;
                            //            }
                            //        }
                            //    }

                            //    if ((oOrderRow.IsCustomerIDNull() ? 0 : oOrderRow.CustomerID) == 0) continue;

                            //    oOrderRow.TxnDate = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TxnDate").InnerText);
                            //    //Get value of RefNumber
                            //    if (SalesOrderRet.SelectSingleNode("./RefNumber") != null)
                            //    {
                            //        oOrderRow.RefNumber = SalesOrderRet.SelectSingleNode("./RefNumber").InnerText;

                            //    }
                            //    //Get all field values for BillAddress aggregate 
                            //    XmlNode BillAddress = SalesOrderRet.SelectSingleNode("./BillAddress");
                            //    if (BillAddress != null)
                            //    {
                            //        //Get value of Addr1
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/Addr1") != null)
                            //        {
                            //            oOrderRow.BillAdd1 = SalesOrderRet.SelectSingleNode("./BillAddress/Addr1").InnerText;

                            //        }
                            //        //Get value of Addr2
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/Addr2") != null)
                            //        {
                            //            oOrderRow.BillAdd2 = SalesOrderRet.SelectSingleNode("./BillAddress/Addr2").InnerText;

                            //        }
                            //        //Get value of Addr3
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/Addr3") != null)
                            //        {
                            //            oOrderRow.BillAdd3 = SalesOrderRet.SelectSingleNode("./BillAddress/Addr3").InnerText;

                            //        }
                            //        //Get value of City
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/City") != null)
                            //        {
                            //            oOrderRow.BillCity = SalesOrderRet.SelectSingleNode("./BillAddress/City").InnerText;

                            //        }
                            //        //Get value of State
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/State") != null)
                            //        {
                            //            oOrderRow.BillState = SalesOrderRet.SelectSingleNode("./BillAddress/State").InnerText;

                            //        }
                            //        //Get value of PostalCode
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/PostalCode") != null)
                            //        {
                            //            oOrderRow.BillPostalCode = SalesOrderRet.SelectSingleNode("./BillAddress/PostalCode").InnerText;

                            //        }
                            //        //Get value of Country
                            //        if (SalesOrderRet.SelectSingleNode("./BillAddress/Country") != null)
                            //        {
                            //            oOrderRow.BillCountry = SalesOrderRet.SelectSingleNode("./BillAddress/Country").InnerText;

                            //        }
                            //    }

                            //    //Get all field values for ShipAddress aggregate 
                            //    XmlNode ShipAddress = SalesOrderRet.SelectSingleNode("./ShipAddress");
                            //    if (ShipAddress != null)
                            //    {
                            //        //Get value of Addr1
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/Addr1") != null)
                            //        {
                            //            oOrderRow.ShipAdd1 = SalesOrderRet.SelectSingleNode("./ShipAddress/Addr1").InnerText;

                            //        }
                            //        //Get value of Addr2
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/Addr2") != null)
                            //        {
                            //            oOrderRow.ShipAdd2 = SalesOrderRet.SelectSingleNode("./ShipAddress/Addr2").InnerText;

                            //        }
                            //        //Get value of Addr3
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/Addr3") != null)
                            //        {
                            //            oOrderRow.ShipAdd3 = SalesOrderRet.SelectSingleNode("./ShipAddress/Addr3").InnerText;

                            //        }
                            //        //Get value of City
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/City") != null)
                            //        {
                            //            oOrderRow.ShipCity = SalesOrderRet.SelectSingleNode("./ShipAddress/City").InnerText;

                            //        }
                            //        //Get value of State
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/State") != null)
                            //        {
                            //            oOrderRow.ShipState = SalesOrderRet.SelectSingleNode("./ShipAddress/State").InnerText;

                            //        }
                            //        //Get value of PostalCode
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/PostalCode") != null)
                            //        {
                            //            oOrderRow.ShipPostalCode = SalesOrderRet.SelectSingleNode("./ShipAddress/PostalCode").InnerText;

                            //        }
                            //        //Get value of Country
                            //        if (SalesOrderRet.SelectSingleNode("./ShipAddress/Country") != null)
                            //        {
                            //            oOrderRow.ShipCountry = SalesOrderRet.SelectSingleNode("./ShipAddress/Country").InnerText;

                            //        }
                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./PONumber") != null)
                            //    {
                            //        oOrderRow.CustomerPONo = SalesOrderRet.SelectSingleNode("./PONumber").InnerText;

                            //    }
                            //    //Get all field values for TermsRef aggregate 
                            //    XmlNode TermsRef = SalesOrderRet.SelectSingleNode("./TermsRef");
                            //    if (TermsRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (SalesOrderRet.SelectSingleNode("./TermsRef/FullName") != null)
                            //        {
                            //            oOrderRow.PaymentTerms = SalesOrderRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                            //        }
                            //    }
                            //    //Done with field values for TermsRef aggregate

                            //    //Get value of DueDate
                            //    if (SalesOrderRet.SelectSingleNode("./DueDate") != null)
                            //    {
                            //        oOrderRow.RequestedShipDate = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./DueDate").InnerText);

                            //    }
                            //    //Get all field values for SalesRepRef aggregate 
                            //    //XmlNode SalesRepRef = SalesOrderRet.SelectSingleNode("./SalesRepRef");
                            //    //if (SalesRepRef != null)
                            //    //{
                            //    //    //Get value of FullName
                            //    //    if (SalesOrderRet.SelectSingleNode("./SalesRepRef/FullName") != null)
                            //    //    {
                            //    //        oOrderRow.SalesRep = SalesOrderRet.SelectSingleNode("./SalesRepRef/FullName").InnerText;
                            //    //    }
                            //    //}
                            //    //Done with field values for SalesRepRef aggregate

                            //    //Get all field values for ShipMethodRef aggregate 
                            //    XmlNode ShipMethodRef = SalesOrderRet.SelectSingleNode("./ShipMethodRef");
                            //    if (ShipMethodRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (SalesOrderRet.SelectSingleNode("./ShipMethodRef/FullName") != null)
                            //        {
                            //            oOrderRow.ShipMethod = SalesOrderRet.SelectSingleNode("./ShipMethodRef/FullName").InnerText;
                            //        }
                            //    }
                            //    //Done with field values for ShipMethodRef aggregate


                            //    if (SalesOrderRet.SelectSingleNode("./Subtotal") != null)
                            //    {
                            //        oOrderRow.Subtotal = Convert.ToDouble(SalesOrderRet.SelectSingleNode("./Subtotal").InnerText);

                            //    }

                            //    //Get value of SalesTaxPercentage
                            //    if (SalesOrderRet.SelectSingleNode("./SalesTaxPercentage") != null)
                            //    {
                            //        oOrderRow.TaxPercentage = Convert.ToDouble(SalesOrderRet.SelectSingleNode("./SalesTaxPercentage").InnerText);

                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./SalesTaxTotal") != null)
                            //    {
                            //        oOrderRow.TaxAmount = Convert.ToDouble(SalesOrderRet.SelectSingleNode("./SalesTaxTotal").InnerText);

                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./IsManuallyClosed") != null)
                            //    {
                            //        oOrderRow.IsManuallyClosed = Convert.ToBoolean(SalesOrderRet.SelectSingleNode("./IsManuallyClosed").InnerText);
                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./IsFullyInvoiced") != null)
                            //    {
                            //        oOrderRow.IsFullyInvoiced = Convert.ToBoolean(SalesOrderRet.SelectSingleNode("./IsFullyInvoiced").InnerText);
                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./Memo") != null)
                            //    {
                            //        oOrderRow.OrderMemo = SalesOrderRet.SelectSingleNode("./Memo").InnerText;
                            //    }

                            //    //if (SalesOrderRet.SelectSingleNode("./TemplateRef") != null && SalesOrderRet.SelectSingleNode("./TemplateRef/FullName") != null)
                            //    //{
                            //    //    oOrderRow.SalesOrderTemplate = SalesOrderRet.SelectSingleNode("./TemplateRef/FullName").InnerText;
                            //    //}

                            //    //Get all field values for CurrencyRef aggregate 
                            //    XmlNode CurrencyRef = SalesOrderRet.SelectSingleNode("./CurrencyRef");
                            //    if (CurrencyRef != null)
                            //    {
                            //        //Get value of FullName
                            //        if (SalesOrderRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                            //        {
                            //            oOrderRow.Currency = SalesOrderRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                            //        }
                            //    }

                            //    if (SalesOrderRet.SelectSingleNode("./ExchangeRate") != null)
                            //    {
                            //        oOrderRow.CurrencyRate = Convert.ToDouble(SalesOrderRet.SelectSingleNode("./ExchangeRate").InnerText);
                            //    }

                            //    oOrderRow.Total = (oOrderRow.IsSubtotalNull() ? 0 : oOrderRow.Subtotal) + (oOrderRow.IsTaxAmountNull() ? 0 : oOrderRow.TaxAmount);

                            //    taOrder.Update(oOrderRow);

                            //    XmlNodeList ORSalesOrderLineRetListChildren = SalesOrderRet.SelectNodes("./SalesOrderLineRet");
                            //    for (int j = 0; j < ORSalesOrderLineRetListChildren.Count; j++)
                            //    {
                            //        XmlNode Child = ORSalesOrderLineRetListChildren.Item(j);
                            //        if (Child.Name == "SalesOrderLineRet")
                            //        {
                            //            var oDetailRow = ds.OrderDetail.NewOrderDetailRow();

                            //            oDetailRow.TxnID = TxnID;
                            //            oDetailRow.OrderID = oOrderRow.OrderID;
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
                            //                    //oDetailRow.SalesDesc = itemRow.IsSalesDescNull() ? "" : itemRow.SalesDesc;
                            //                    //oDetailRow.PurchaseDesc = itemRow.IsPurchaseDescNull() ? "" : itemRow.PurchaseDesc;
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
                            //                        //oDetailRow.SalesDesc = itemRow.IsSalesDescNull() ? "" : itemRow.SalesDesc;
                            //                        //oDetailRow.PurchaseDesc = itemRow.IsPurchaseDescNull() ? "" : itemRow.PurchaseDesc;
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

                            //            ds.OrderDetail.AddOrderDetailRow(oDetailRow);
                            //        }
                            //    }

                            //    taOrderDetail.Update(ds.OrderDetail);

                            //    bgWorker.ReportProgress(0, "SalesOrder # " + oOrderRow.RefNumber);
                            //    bgWorker.ReportProgress(0, "Exported to Server");
                            //    bgWorker.ReportProgress(0, "");

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

                bgWorker.ReportProgress(0, "Error! SalesOrder Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        //public bool AddSalesOrder(Data.dsQBSync.OrdersRow orderRow, string txnId, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        Data.dsQBSync ds = new Data.dsQBSync();
        //        ds.EnforceConstraints = false;
        //        Data.dsQBSyncTableAdapters.OrdersTableAdapter taOrder = new Data.dsQBSyncTableAdapters.OrdersTableAdapter();
        //        Data.dsQBSyncTableAdapters.OrderDetailTableAdapter taOrderDetail = new Data.dsQBSyncTableAdapters.OrderDetailTableAdapter();
        //        taOrderDetail.FillByOrderID(ds.OrderDetail, orderRow.OrderID);

        //        if (ds.OrderDetail.Count() == 0)
        //        {
        //            bgWorker.ReportProgress(0, "There is no detail row!");
        //            return false;
        //        }

        //        bool isEdit = false; string editSequence = "";
        //        if (!string.IsNullOrEmpty(txnId))
        //        {
        //            editSequence = GetSalesOrderEditSequence(txnId);
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
        //        //Create SalesOrderAddRq aggregate and fill in field values for it
        //        XmlElement SalesOrderAddRq = doc.CreateElement(isEdit ? "SalesOrderModRq" : "SalesOrderAddRq");
        //        parent.AppendChild(SalesOrderAddRq);
        //        //Create SalesOrderAdd aggregate and fill in field values for it
        //        XmlElement SalesOrderAdd = doc.CreateElement(isEdit ? "SalesOrderMod" : "SalesOrderAdd");
        //        SalesOrderAddRq.AppendChild(SalesOrderAdd);

        //        if (isEdit)
        //        {
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "TxnID", txnId));
        //            //Set field value for EditSequence <!-- required -->
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "EditSequence", editSequence));
        //        }

        //        String CustomerFullName = orderRow.IsCustomerFullNameNull() ? "" : orderRow.CustomerFullName;
        //        if (string.IsNullOrEmpty(CustomerFullName))
        //        {
        //            bgWorker.ReportProgress(0, "Customer name is empty!");
        //            return false;
        //        }

        //        //CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
        //        //Create CustomerRef aggregate and fill in field values for it
        //        XmlElement CustomerRef = doc.CreateElement("CustomerRef");
        //        SalesOrderAdd.AppendChild(CustomerRef);
        //        //Set field value for ListID <!-- optional -->
        //        CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));

        //        //Set field value for TxnDate <!-- optional -->
        //        if (orderRow.IsTxnDateNull() == false)
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "TxnDate", orderRow.TxnDate.ToString("yyyy-MM-dd")));
        //        //Set field value for RefNumber <!-- optional -->
        //        //if (!string.IsNullOrEmpty(orderRow.RefNumber))
        //        //    SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "RefNumber", orderRow.RefNumber));

        //        //Billing
        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        SalesOrderAdd.AppendChild(BillAddress);

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(orderRow.IsBillAdd1Null() ? "" : orderRow.BillAdd1, 39)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(orderRow.IsBillAdd2Null() ? "" : orderRow.BillAdd2, 39)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(orderRow.IsBillAdd3Null() ? "" : orderRow.BillAdd3, 39)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(orderRow.IsBillCityNull() ? "" : orderRow.BillCity, 31)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(orderRow.IsBillStateNull() ? "" : orderRow.BillState, 21)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(orderRow.IsBillPostalCodeNull() ? "" : orderRow.BillPostalCode, 13)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(orderRow.IsBillCountryNull() ? "" : orderRow.BillCountry, 21)));


        //        //Shiping
        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        SalesOrderAdd.AppendChild(ShipAddress);

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(orderRow.IsShipAdd1Null() ? "" : orderRow.ShipAdd1, 39)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(orderRow.IsShipAdd2Null() ? "" : orderRow.ShipAdd2, 39)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(orderRow.IsShipAdd3Null() ? "" : orderRow.ShipAdd3, 39)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(orderRow.IsShipCityNull() ? "" : orderRow.ShipCity, 31)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(orderRow.IsShipStateNull() ? "" : orderRow.ShipState, 21)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(orderRow.IsShipPostalCodeNull() ? "" : orderRow.ShipPostalCode, 13)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(orderRow.IsShipCountryNull() ? "" : orderRow.ShipCountry, 21)));


        //        //Set field value for PONumber <!-- optional -->
        //        if (!String.IsNullOrEmpty(orderRow.IsCustomerPONoNull() ? "" : orderRow.CustomerPONo))
        //        {
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "PONumber", Common.Truncate(orderRow.CustomerPONo, 25)));
        //        }

        //        if (!String.IsNullOrEmpty(orderRow.IsPaymentTermsNull() ? "" : orderRow.PaymentTerms))
        //        {
        //            //Create TermsRef aggregate and fill in field values for it
        //            XmlElement TermsRef = doc.CreateElement("TermsRef");
        //            SalesOrderAdd.AppendChild(TermsRef);
        //            //Set field value for ListID <!-- optional -->
        //            //TermsRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            TermsRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.PaymentTerms));
        //            //Done creating TermsRef aggregate
        //        }

        //        //Set field value for DueDate <!-- optional -->
        //        if (orderRow.RequestedShipDate > DateTime.MinValue)
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "DueDate", orderRow.RequestedShipDate.ToString("yyyy-MM-dd")));

        //        //if (!String.IsNullOrEmpty(orderRow.ShipCountry))
        //        //{
        //        //    //Create SalesRepRef aggregate and fill in field values for it
        //        //    XmlElement SalesRepRef = doc.CreateElement("SalesRepRef");
        //        //    SalesOrderAdd.AppendChild(SalesRepRef);
        //        //    //Set field value for ListID <!-- optional -->
        //        //    //SalesRepRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //        //    //Set field value for FullName <!-- optional -->
        //        //    SalesRepRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.SalesRep));
        //        //    //Done creating SalesRepRef aggregate
        //        //}

        //        if (!String.IsNullOrEmpty(orderRow.ShipMethod))
        //        {
        //            //Create ShipMethodRef aggregate and fill in field values for it
        //            XmlElement ShipMethodRef = doc.CreateElement("ShipMethodRef");
        //            SalesOrderAdd.AppendChild(ShipMethodRef);
        //            //Set field value for ListID <!-- optional -->
        //            //ShipMethodRef.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
        //            //Set field value for FullName <!-- optional -->
        //            ShipMethodRef.AppendChild(MakeSimpleElem(doc, "FullName", orderRow.ShipMethod));
        //            //Done creating ShipMethodRef aggregate
        //        }

        //        if (isEdit == false)
        //        {
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "Memo", "Online Order: " + (orderRow.IsOrderMemoNull() ? "" : orderRow.OrderMemo)));
        //        }
        //        else
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "Memo", orderRow.IsOrderMemoNull() ? "" : orderRow.OrderMemo));

        //        //Set field value for ExchangeRate <!-- optional -->
        //        if (orderRow.IsCurrencyRateNull() == false)
        //            SalesOrderAdd.AppendChild(MakeSimpleElem(doc, "ExchangeRate", orderRow.CurrencyRate.ToString("###0.00")));


        //        foreach (Data.dsQBSync.OrderDetailRow detailRow in ds.OrderDetail)
        //        {
        //            SalesOrderAdd.AppendChild(AddSalesOrderLine(doc, isEdit ? "SalesOrderLineMod" : "SalesOrderLineAdd", detailRow));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        XmlNodeList SalesOrderAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "SalesOrderModRs" : "SalesOrderAddRs");
        //        if (SalesOrderAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = SalesOrderAddRsList.Item(0);
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
        //                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in SalesOrder");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (statusCode == "0")
        //                {
        //                    XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query
        //                    for (int i = 0; i < SalesOrderRetList.Count; i++)
        //                    {
        //                        XmlNode SalesOrderRet = SalesOrderRetList.Item(i);
        //                        string newTxnId = SalesOrderRet.SelectSingleNode("./TxnID").InnerText;

        //                        var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
        //                        //Get value of TimeModified
        //                        var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);


        //                        string NewRefNumber = "";
        //                        if (SalesOrderRet.SelectSingleNode("./RefNumber") != null)
        //                        {
        //                            NewRefNumber = SalesOrderRet.SelectSingleNode("./RefNumber").InnerText;
        //                        }

        //                        string CustomerListID = "";
        //                        if (SalesOrderRet.SelectSingleNode("./CustomerRef/ListID") != null)
        //                        {
        //                            CustomerListID = SalesOrderRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
        //                        }

        //                        //Customers objCustomer = new Customers();
        //                        //var mdlCustomer = objCustomer.GetCustomerBalance(CustomerListID);

        //                        string sysNotes = orderRow.IsSystemNotesNull() ? ("Exported to QuickBooks " + DateTime.Now) : (orderRow.SystemNotes + System.Environment.NewLine + "Exported to QuickBooks " + DateTime.Now);

        //                        taOrder.UpdateQBFields(newTxnId, TimeCreated, TimeModified, true, NewRefNumber, sysNotes, orderRow.OrderID);

        //                        bgWorker.ReportProgress(0, "SalesOrder " + (isEdit ? "updated" : "added") + " successfully");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in SalesOrder");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bgWorker.ReportProgress(0, "Error! Adding/Updating in SalesOrder");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
        //    }

        //    return blnResult;
        //}

        //private XmlElement AddSalesOrderLine(XmlDocument inputXMLDoc, string SalesOrderLineAddMod, Data.dsQBSync.OrderDetailRow detailRow)
        //{
        //    //Create SalesOrderLineAdd aggregate and fill in field values for it
        //    XmlElement SalesOrderLine = inputXMLDoc.CreateElement(SalesOrderLineAddMod);

        //    if (SalesOrderLineAddMod == "SalesOrderLineMod")
        //        SalesOrderLine.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnLineID", "-1"));

        //    if (!string.IsNullOrEmpty(detailRow.IsItemFullNameNull() ? "" : detailRow.ItemFullName))
        //    {
        //        //Create ItemRef aggregate and fill in field values for it
        //        XmlElement ItemRef = inputXMLDoc.CreateElement("ItemRef");
        //        SalesOrderLine.AppendChild(ItemRef);
        //        ItemRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.ItemFullName));
        //        //Set field value for Desc <!-- optional -->                           
        //        SalesOrderLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.IsDetailDescNull() ? "" : detailRow.DetailDesc));

        //        if (detailRow.Quantity > 0)
        //            SalesOrderLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Quantity", detailRow.Quantity.ToString("###0.00")));


        //        SalesOrderLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Rate", detailRow.Rate.ToString("###0.00")));


        //        if (!string.IsNullOrEmpty(detailRow.IsTaxCodeNull() ? "" : detailRow.TaxCode))
        //        {
        //            XmlElement SalesTaxCodeRef = inputXMLDoc.CreateElement("SalesTaxCodeRef");
        //            SalesOrderLine.AppendChild(SalesTaxCodeRef);
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", detailRow.TaxCode));
        //        }
        //    }
        //    else
        //    {
        //        SalesOrderLine.AppendChild(MakeSimpleElem(inputXMLDoc, "Desc", detailRow.IsDetailDescNull() ? "" : detailRow.DetailDesc));
        //    }


        //    return SalesOrderLine;
        //}

        public String GetSalesOrderEditSequence(String TxnID)
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
                XmlElement SalesOrderQueryRq = inputXMLDoc.CreateElement("SalesOrderQueryRq");
                qbXMLMsgsRq.AppendChild(SalesOrderQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList SalesOrderQueryRsList = responseXmlDoc.GetElementsByTagName("SalesOrderQueryRs");
                if (SalesOrderQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = SalesOrderQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query
                        for (int i = 0; i < SalesOrderRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = SalesOrderRetList.Item(i);

                            //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = SalesOrderRet.SelectSingleNode("./EditSequence").InnerText;

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

        public MdlQB GetSalesOrderListID(String RefNumber)
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
                XmlElement SalesOrderQueryRq = inputXMLDoc.CreateElement("SalesOrderQueryRq");
                qbXMLMsgsRq.AppendChild(SalesOrderQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "RefNumber", RefNumber));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList SalesOrderQueryRsList = responseXmlDoc.GetElementsByTagName("SalesOrderQueryRs");
                if (SalesOrderQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = SalesOrderQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query
                        for (int i = 0; i < SalesOrderRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = SalesOrderRetList.Item(i);

                            mdlResult.TxnID = SalesOrderRet.SelectSingleNode("./TxnID").InnerText;
                            //Get value of EditSequence
                            mdlResult.EditSequence = SalesOrderRet.SelectSingleNode("./EditSequence").InnerText;

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

        public double GetSalesOrderBalanceRemaining(String TxnID)
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
                XmlElement SalesOrderQueryRq = inputXMLDoc.CreateElement("SalesOrderQueryRq");
                qbXMLMsgsRq.AppendChild(SalesOrderQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "TxnID", TxnID));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TxnID"));
                SalesOrderQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "BalanceRemaining"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList SalesOrderQueryRsList = responseXmlDoc.GetElementsByTagName("SalesOrderQueryRs");
                if (SalesOrderQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = SalesOrderQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query
                        for (int i = 0; i < SalesOrderRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = SalesOrderRetList.Item(i);

                            if (SalesOrderRet.SelectSingleNode("./BalanceRemaining") != null)
                            {
                                dblResult = Convert.ToDouble(SalesOrderRet.SelectSingleNode("./BalanceRemaining").InnerText);
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

        //public bool UpdateSalesOrder(Data.dsQBSync.SalesOrderRow invoiceRow, string QBEditSequence, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        Data.dsQBSync ds = new Data.dsQBSync();
        //        ds.EnforceConstraints = false;
        //        Data.dsQBSyncTableAdapters.SalesOrderTableAdapter taSalesOrder = new Data.dsQBSyncTableAdapters.SalesOrderTableAdapter();
        //        Data.dsQBSyncTableAdapters.SalesOrderItemTableAdapter taSalesOrderItem = new Data.dsQBSyncTableAdapters.SalesOrderItemTableAdapter();

        //        taSalesOrderItem.FillBySalesOrderCRMId(ds.SalesOrderItem, invoiceRow.CRMId);
        //        if (ds.SalesOrderItem.Rows.Count == 0)
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
        //        //Create SalesOrderAddRq aggregate and fill in field values for it
        //        XmlElement SalesOrderModRq = doc.CreateElement("SalesOrderModRq");
        //        parent.AppendChild(SalesOrderModRq);
        //        //Create SalesOrderAdd aggregate and fill in field values for it
        //        XmlElement SalesOrderMod = doc.CreateElement("SalesOrderMod");
        //        SalesOrderModRq.AppendChild(SalesOrderMod);

        //        SalesOrderMod.AppendChild(MakeSimpleElem(doc, "TxnID", invoiceRow.QBTxnId));
        //        //Set field value for EditSequence <!-- required -->
        //        SalesOrderMod.AppendChild(MakeSimpleElem(doc, "EditSequence", QBEditSequence));

        //        String CustomerFullName = invoiceRow.BillingAccountName;
        //        CustomerFullName = Common.Truncate(CustomerFullName.Trim(), 41);
        //        //Create CustomerRef aggregate and fill in field values for it
        //        XmlElement CustomerRef = doc.CreateElement("CustomerRef");
        //        SalesOrderMod.AppendChild(CustomerRef);
        //        //Set field value for ListID <!-- optional -->
        //        CustomerRef.AppendChild(MakeSimpleElem(doc, "FullName", CustomerFullName));

        //        //Set field value for TxnDate <!-- optional -->
        //        DateTime dtTransaction = invoiceRow.IsSalesOrderDateNull() ? DateTime.Now : invoiceRow.SalesOrderDate;
        //        SalesOrderMod.AppendChild(MakeSimpleElem(doc, "TxnDate", dtTransaction.ToString("yyyy-MM-dd")));
        //        //Set field value for RefNumber <!-- optional -->
        //        String RefNumber = invoiceRow.IsSalesOrderNumberNull() ? "" : invoiceRow.SalesOrderNumber;
        //        //if (!string.IsNullOrEmpty(RefNumber))
        //        //    SalesOrderMod.AppendChild(MakeSimpleElem(doc, "RefNumber", RefNumber));

        //        //Billing
        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        SalesOrderMod.AppendChild(BillAddress);

        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillingAccountNameNull() ? "" : invoiceRow.BillingAccountName))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.BillingAccountName, 40)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillAdd1Null() ? "" : invoiceRow.BillAdd1))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(invoiceRow.BillAdd1, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillCityNull() ? "" : invoiceRow.BillCity))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.BillCity, 31)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillStateNull() ? "" : invoiceRow.BillState))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.BillState, 21)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillPostalCodeNull() ? "" : invoiceRow.BillPostalCode))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.BillPostalCode, 13)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsBillCountryNull() ? "" : invoiceRow.BillCountry))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.BillCountry, 21)));
        //        }


        //        //Shipping Address
        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        SalesOrderMod.AppendChild(ShipAddress);

        //        if (!String.IsNullOrEmpty(invoiceRow.IsShipAdd1Null() ? "" : invoiceRow.ShipAdd1))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(invoiceRow.ShipAdd1, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsShipCityNull() ? "" : invoiceRow.ShipCity))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(invoiceRow.ShipCity, 31)));
        //        }
        //        if (!String.IsNullOrEmpty(invoiceRow.IsShipStateNull() ? "" : invoiceRow.ShipState))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(invoiceRow.ShipState, 21)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.IsShipPostalCodeNull() ? "" : invoiceRow.ShipPostalCode))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(invoiceRow.ShipPostalCode, 13)));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.IsShipCountryNull() ? "" : invoiceRow.ShipCountry))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(invoiceRow.ShipCountry, 21)));
        //        }

        //        if (invoiceRow.IsDueDateNull() == false)
        //        {
        //            SalesOrderMod.AppendChild(MakeSimpleElem(doc, "DueDate", invoiceRow.DueDate.ToString("yyyy-MM-dd")));
        //        }

        //        if (!String.IsNullOrEmpty(invoiceRow.IsSalesOrderTitleNull() ? "" : invoiceRow.SalesOrderTitle))
        //        {
        //            SalesOrderMod.AppendChild(MakeSimpleElem(doc, "Memo", invoiceRow.SalesOrderTitle));
        //        }

        //        foreach (Data.dsQBSync.SalesOrderItemRow detailRow in ds.SalesOrderItem.Rows)
        //        {
        //            string ProductName = Common.Truncate(detailRow.IsItemNameNull() == true ? "" : detailRow.ItemName, 31);
        //            string Desc = detailRow.IsDescriptionNull() ? "" : detailRow.Description;
        //            double ProductPrice = detailRow.IsPriceNull() ? 0 : detailRow.Price;
        //            double Quantity = detailRow.IsQtyNull() ? 0 : detailRow.Qty;
        //            double ProductTax = detailRow.IsVatAmountNull() ? 0 : detailRow.VatAmount;

        //            SalesOrderMod.AppendChild(AddSalesOrderLine(doc, "SalesOrderLineMod", ProductName, Desc, Quantity, ProductPrice, false, true, true, (ProductTax > 0 ? true : false), "", ""));

        //        }

        //        //if ((invoiceRow.IsTaxAmountNull() ? 0 : invoiceRow.TaxAmount) > 0)
        //        //{
        //        //    SalesOrderMod.AppendChild(AddSalesOrderLine(doc, "SalesOrderLineMod", "VAT", "", 0, invoiceRow.TaxAmount, false, false, false, false, "", ""));
        //        //}

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        XmlNodeList SalesOrderModRsList = responseXmlDoc.GetElementsByTagName("SalesOrderModRs");
        //        if (SalesOrderModRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = SalesOrderModRsList.Item(0);
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
        //                        bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Customer");
        //                        //Customers objCustomer = new Customers();
        //                        //if (objCustomer.QBAddCusomter(order, bgWorker))
        //                        //{
        //                        //    blnResult = AddSalesOrder(order, bgWorker, log);
        //                        //}
        //                        //else
        //                        //{
        //                        //    bgWorker.ReportProgress(0, statusMessage);
        //                        //    return false;
        //                        //}
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

        //                            if (objItem.ServiceItemAdd(ProductName))
        //                                blnResult = UpdateSalesOrder(invoiceRow, QBEditSequence, bgWorker);
        //                            else
        //                            {
        //                                bgWorker.ReportProgress(0, statusMessage);
        //                                return false;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Updating in SalesOrder");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (statusCode == "0")
        //                {
        //                    XmlNodeList SalesOrderRetList = responseNode.SelectNodes("//SalesOrderRet");//XPath Query
        //                    for (int i = 0; i < SalesOrderRetList.Count; i++)
        //                    {
        //                        XmlNode SalesOrderRet = SalesOrderRetList.Item(i);
        //                        string TxnID = SalesOrderRet.SelectSingleNode("./TxnID").InnerText;

        //                        taSalesOrder.UpdateQBStatus(TxnID, true, invoiceRow.ID);

        //                        bgWorker.ReportProgress(0, "Successfully updated in QuickBooks");
        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Updating in SalesOrder");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bgWorker.ReportProgress(0, "Error! Updating in SalesOrder");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
        //    }

        //    return blnResult;
        //}

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

    }
}
