using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace QBSync.QuickBooks
{
    public class PurchaseOrders
    {

        public void PurchaseOrderQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement PurchaseOrderQueryRq = doc.CreateElement("PurchaseOrderQueryRq");
                    qbXMLMsgsRq.AppendChild(PurchaseOrderQueryRq);
                    PurchaseOrderQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        PurchaseOrderQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        PurchaseOrderQueryRq.SetAttribute("iteratorID", strIteratorID);

                    PurchaseOrderQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    //Create ModifiedDateRangeFilter aggregate and fill in field values for it
                    XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
                    PurchaseOrderQueryRq.AppendChild(ModifiedDateRangeFilter);
                    //Set field value for FromModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    //Set field value for ToModifiedDate <!-- optional -->
                    if (Common.UseQBQueryToDate)
                        ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Done creating ModifiedDateRangeFilter aggregate

                    PurchaseOrderQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));

                    //Set field value for IncludeLinkedTxns <!-- optional -->
                    //PurchaseOrderQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLinkedTxns", "1"));

                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList PurchaseOrderQueryRsList = responseXmlDoc.GetElementsByTagName("PurchaseOrderQueryRs");
                    if (PurchaseOrderQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = PurchaseOrderQueryRsList.Item(0);
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
                        //    XmlNodeList PurchaseOrderRetList = responseNode.SelectNodes("//PurchaseOrderRet");//XPath Query

                        //    Data.dsQBSyncTableAdapters.PurchaseOrderTableAdapter taPurchaseOrder = new Data.dsQBSyncTableAdapters.PurchaseOrderTableAdapter();
                        //    Data.dsQBSyncTableAdapters.PurchaseOrderDetailTableAdapter taPurchaseOrderDetail = new Data.dsQBSyncTableAdapters.PurchaseOrderDetailTableAdapter();

                        //    for (int i = 0; i < PurchaseOrderRetList.Count; i++)
                        //    {
                        //        XmlNode PurchaseOrderRet = PurchaseOrderRetList.Item(i);

                        //        if (PurchaseOrderRet == null) continue;

                        //        string TxnID = PurchaseOrderRet.SelectSingleNode("./TxnID").InnerText;

                        //        Data.dsQBSync ds = new Data.dsQBSync();
                        //        ds.EnforceConstraints = false;

                        //        var oPurchaseOrderRow = ds.PurchaseOrder.NewPurchaseOrderRow();
                        //        taPurchaseOrder.FillByTxnID(ds.PurchaseOrder, TxnID);
                        //        if (ds.PurchaseOrder.Count() > 0)
                        //        {
                        //            oPurchaseOrderRow = ds.PurchaseOrder[0];

                        //            taPurchaseOrderDetail.DeleteByPurchaseOrderID(oPurchaseOrderRow.PurchaseOrderID);
                        //        }
                        //        else
                        //        {
                        //            ds.PurchaseOrder.AddPurchaseOrderRow(oPurchaseOrderRow);
                        //            oPurchaseOrderRow.TxnID = TxnID;
                        //        }

                        //        oPurchaseOrderRow.TimeCreated = Convert.ToDateTime(PurchaseOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                        //        oPurchaseOrderRow.TimeModified = Convert.ToDateTime(PurchaseOrderRet.SelectSingleNode("./TimeModified").InnerText);

                        //        if (PurchaseOrderRet.SelectSingleNode("./VendorRef/FullName") != null)
                        //        {
                        //            oPurchaseOrderRow.VendorListID = PurchaseOrderRet.SelectSingleNode("./VendorRef/ListID").InnerText;
                        //            oPurchaseOrderRow.VendorName = PurchaseOrderRet.SelectSingleNode("./VendorRef/FullName").InnerText;
                        //        }

                        //        oPurchaseOrderRow.TxnDate = Convert.ToDateTime(PurchaseOrderRet.SelectSingleNode("./TxnDate").InnerText);
                        //        //Get value of RefNumber
                        //        if (PurchaseOrderRet.SelectSingleNode("./RefNumber") != null)
                        //        {
                        //            oPurchaseOrderRow.RefNumber = PurchaseOrderRet.SelectSingleNode("./RefNumber").InnerText;

                        //        }

                        //        //Get value of DueDate
                        //        if (PurchaseOrderRet.SelectSingleNode("./DueDate") != null)
                        //        {
                        //            oPurchaseOrderRow.DueDate = Convert.ToDateTime(PurchaseOrderRet.SelectSingleNode("./DueDate").InnerText);

                        //        }

                        //        //Get value of DueDate
                        //        if (PurchaseOrderRet.SelectSingleNode("./ExpectedDate") != null)
                        //        {
                        //            oPurchaseOrderRow.ExpectedDate = Convert.ToDateTime(PurchaseOrderRet.SelectSingleNode("./ExpectedDate").InnerText);

                        //        }

                        //        //Get all field values for ShipMethodRef aggregate 
                        //        XmlNode ShipMethodRef = PurchaseOrderRet.SelectSingleNode("./ShipMethodRef");
                        //        if (ShipMethodRef != null)
                        //        {
                        //            //Get value of FullName
                        //            if (PurchaseOrderRet.SelectSingleNode("./ShipMethodRef/FullName") != null)
                        //            {
                        //                oPurchaseOrderRow.ShipMethod = PurchaseOrderRet.SelectSingleNode("./ShipMethodRef/FullName").InnerText;
                        //            }
                        //        }
                        //        //Done with field values for ShipMethodRef aggregate


                        //        if (PurchaseOrderRet.SelectSingleNode("./TotalAmount") != null)
                        //        {
                        //            oPurchaseOrderRow.TotalAmount = Convert.ToDouble(PurchaseOrderRet.SelectSingleNode("./TotalAmount").InnerText);
                        //        }

                        //        if (PurchaseOrderRet.SelectSingleNode("./IsManuallyClosed") != null)
                        //        {
                        //            oPurchaseOrderRow.IsManuallyClosed = Convert.ToBoolean(PurchaseOrderRet.SelectSingleNode("./IsManuallyClosed").InnerText);
                        //        }

                        //        if (PurchaseOrderRet.SelectSingleNode("./IsFullyReceived") != null)
                        //        {
                        //            oPurchaseOrderRow.IsFullyReceived = Convert.ToBoolean(PurchaseOrderRet.SelectSingleNode("./IsFullyReceived").InnerText);
                        //        }

                        //        taPurchaseOrder.Update(oPurchaseOrderRow);

                        //        XmlNodeList ORPurchaseOrderLineRetListChildren = PurchaseOrderRet.SelectNodes("./PurchaseOrderLineRet");
                        //        for (int j = 0; j < ORPurchaseOrderLineRetListChildren.Count; j++)
                        //        {
                        //            XmlNode Child = ORPurchaseOrderLineRetListChildren.Item(j);
                        //            if (Child.Name == "PurchaseOrderLineRet")
                        //            {
                        //                var oDetailRow = ds.PurchaseOrderDetail.NewPurchaseOrderDetailRow();

                        //                oDetailRow.TxnID = TxnID;
                        //                oDetailRow.PurchaseOrderID = oPurchaseOrderRow.PurchaseOrderID;
                        //                oDetailRow.TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;

                        //                oDetailRow.Quantity = 0;
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

                        //                oDetailRow.ReceivedQuantity = 0;
                        //                if (Child.SelectSingleNode("./ReceivedQuantity") != null)
                        //                {
                        //                    oDetailRow.ReceivedQuantity = Convert.ToDouble(Child.SelectSingleNode("./ReceivedQuantity").InnerText);
                        //                }

                        //                if (Child.SelectSingleNode("./UnbilledQuantity") != null)
                        //                {
                        //                    oDetailRow.UnbilledQuantity = Convert.ToDouble(Child.SelectSingleNode("./UnbilledQuantity").InnerText);
                        //                }

                        //                if (Child.SelectSingleNode("./IsBilled") != null)
                        //                {
                        //                    oDetailRow.IsBilled = Convert.ToBoolean(Child.SelectSingleNode("./IsBilled").InnerText);
                        //                }

                        //                if (Child.SelectSingleNode("./IsManuallyClosed") != null)
                        //                {
                        //                    oDetailRow.IsManuallyClosed = Convert.ToBoolean(Child.SelectSingleNode("./IsManuallyClosed").InnerText);
                        //                }

                        //                Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();
                        //                if (Child.SelectSingleNode("./ItemRef") != null && Child.SelectSingleNode("./ItemRef/ListID") != null)
                        //                {
                        //                    oDetailRow.ItemListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;

                        //                    taItem.FillByQBListID(ds.Items, oDetailRow.ItemListID);
                        //                    if (ds.Items.Count() > 0)
                        //                    {
                        //                        var itemRow = ds.Items[0];
                        //                        oDetailRow.ItemID = itemRow.ItemID;

                        //                        if (oPurchaseOrderRow.IsManuallyClosed == false && oPurchaseOrderRow.IsFullyReceived == false && oPurchaseOrderRow.IsExpectedDateNull() == false &&
                        //                            oDetailRow.ReceivedQuantity < oDetailRow.Quantity)
                        //                        {
                        //                            taItem.UpdateNextDelivery(oPurchaseOrderRow.ExpectedDate, itemRow.ItemID);
                        //                        }
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

                        //                            if (oPurchaseOrderRow.IsManuallyClosed == false && oPurchaseOrderRow.IsFullyReceived == false && oPurchaseOrderRow.IsExpectedDateNull() == false &&
                        //                             oDetailRow.ReceivedQuantity < oDetailRow.Quantity)
                        //                            {
                        //                                taItem.UpdateNextDelivery(oPurchaseOrderRow.ExpectedDate, itemRow.ItemID);
                        //                            }
                        //                            //else
                        //                            //    taItem.SetNextDeliveryNull(itemRow.ItemID);
                        //                        }
                        //                    }
                        //                }

                        //                if (Child.SelectSingleNode("./Desc") != null)
                        //                {
                        //                    oDetailRow.DetailDesc = Child.SelectSingleNode("./Desc").InnerText;
                        //                }

                        //                ds.PurchaseOrderDetail.AddPurchaseOrderDetailRow(oDetailRow);
                        //            }
                        //        }

                        //        taPurchaseOrderDetail.Update(ds.PurchaseOrderDetail);

                        //        bgWorker.ReportProgress(0, "PurchaseOrder # " + oPurchaseOrderRow.RefNumber);
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

                bgWorker.ReportProgress(0, "Error! PurchaseOrder Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        private XmlElement MakeSimpleElem(XmlDocument doc, String tagName, String tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

    }
}
