using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace QBSync.QuickBooks
{
    public class Items
    {
        private XmlElement MakeSimpleElemt(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void ItemQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement ItemQueryRq = doc.CreateElement("ItemQueryRq");
                    qbXMLMsgsRq.AppendChild(ItemQueryRq);
                    ItemQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        ItemQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        ItemQueryRq.SetAttribute("iteratorID", strIteratorID);

                    ItemQueryRq.AppendChild(MakeSimpleElemt(doc, "MaxReturned", Common.MaxRecordReturn));

                    ItemQueryRq.AppendChild(MakeSimpleElemt(doc, "ActiveStatus", "All"));
                    ItemQueryRq.AppendChild(MakeSimpleElemt(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    if (Common.UseQBQueryToDate)
                        ItemQueryRq.AppendChild(MakeSimpleElemt(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
                    //Set field value for IncludeRetElement <!-- optional, may repeat -->
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Name"));

                    ItemQueryRq.AppendChild(MakeSimpleElemt(doc, "OwnerID", "0"));

                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList ItemQueryRsList = responseXmlDoc.GetElementsByTagName("ItemQueryRs");
                    if (ItemQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = ItemQueryRsList.Item(0);
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
                        //    Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();
                        //    Data.dsQBSync ds = new Data.dsQBSync();
                        //    ds.EnforceConstraints = false;

                        //    XmlNodeList ItemInventoryRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query                       
                        //    for (int i = 0; i < ItemInventoryRetList.Count; i++)
                        //    {
                        //        double dblOldPrice = -1;
                        //        XmlNode ItemInventoryRet = ItemInventoryRetList.Item(i);
                        //        string ListID = ItemInventoryRet.SelectSingleNode("./ListID").InnerText;

                        //        var oItemRow = ds.Items.NewItemsRow();

                        //        taItem.FillByQBListID(ds.Items, ListID);
                        //        if (ds.Items.Count > 0)
                        //        {
                        //            oItemRow = ds.Items[0];
                        //            //oItemRow.UpdateStatus = "OTHER";
                        //            dblOldPrice = oItemRow.IsWholeSalePriceNull() ? 0 : oItemRow.WholeSalePrice;
                        //        }
                        //        else
                        //        {
                        //            oItemRow.ListID = ListID;
                        //            oItemRow.ItemType = "Inventory";
                        //            oItemRow.UpdateStatus = "NEW";
                        //            oItemRow.TimeModified = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeModified").InnerText);
                        //            ds.Items.AddItemsRow(oItemRow);
                        //        }

                        //        oItemRow.TimeCreated = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeCreated").InnerText);
                        //        //oItemRow.TimeModified = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeModified").InnerText);
                        //        oItemRow.Name = ItemInventoryRet.SelectSingleNode("./Name").InnerText;
                        //        oItemRow.FullName = ItemInventoryRet.SelectSingleNode("./FullName").InnerText;
                        //        if (ItemInventoryRet.SelectSingleNode("./IsActive") != null)
                        //        {
                        //            oItemRow.IsActive = Convert.ToBoolean(ItemInventoryRet.SelectSingleNode("./IsActive").InnerText);
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./ParentRef") != null)
                        //        {
                        //            if (ItemInventoryRet.SelectSingleNode("./ParentRef/FullName") != null)
                        //            {
                        //                oItemRow.ParentRef = ItemInventoryRet.SelectSingleNode("./ParentRef/FullName").InnerText;

                        //                var lst = oItemRow.ParentRef.Split(':');

                        //                if (lst.Count() == 1)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = oItemRow.Name;
                        //                }
                        //                else if (lst.Count() == 2)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = lst[1];
                        //                    oItemRow.ItemGroup = oItemRow.Name;
                        //                }
                        //                else if (lst.Count() == 3)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = lst[1];
                        //                    oItemRow.ItemGroup = lst[2];
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            oItemRow.Category = oItemRow.Name;
                        //        }

                        //        oItemRow.Sublevel = Convert.ToInt32(ItemInventoryRet.SelectSingleNode("./Sublevel").InnerText);

                        //        if (ItemInventoryRet.SelectSingleNode("./ClassRef") != null)
                        //        {
                        //            if (ItemInventoryRet.SelectSingleNode("./ClassRef/FullName") != null)
                        //            {
                        //                oItemRow.ClassRef = ItemInventoryRet.SelectSingleNode("./ClassRef/FullName").InnerText;
                        //            }
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./SalesDesc") != null)
                        //        {
                        //            oItemRow.SalesDesc = ItemInventoryRet.SelectSingleNode("./SalesDesc").InnerText;
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef") != null && ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                        //        {
                        //            oItemRow.TaxCode = ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                        //        }

                        //        //Get value of SalesPrice
                        //        if (ItemInventoryRet.SelectSingleNode("./SalesPrice") != null)
                        //        {
                        //            var salePrice = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./SalesPrice").InnerText);

                        //            oItemRow.SalePrice = salePrice;

                        //            if (oItemRow.TaxCode == "Tax")
                        //            {
                        //                oItemRow.MSRP = Math.Round(oItemRow.SalePrice * 1.10, 2);
                        //            }
                        //            else
                        //            {
                        //                oItemRow.MSRP = oItemRow.SalePrice;
                        //            }

                        //            string classRef = oItemRow.IsClassRefNull() ? "" : oItemRow.ClassRef;

                        //            if (!string.IsNullOrEmpty(classRef))
                        //            {
                        //                double markup = 0;
                        //                double.TryParse(classRef.Replace("%", "").Trim(), out markup);
                        //                markup = 1 - markup / 100;
                        //                var wholeSalePrice = oItemRow.SalePrice * markup;
                        //                //wholeSalePrice = Math.Floor(wholeSalePrice / 1000d) * 1000;
                        //                oItemRow.WholeSalePrice = wholeSalePrice;
                        //            }

                        //            if (oItemRow.IsWholeSalePriceNull() == false && dblOldPrice != -1)
                        //            {
                        //                if (dblOldPrice != oItemRow.WholeSalePrice)
                        //                {
                        //                    oItemRow.TimeModified = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeModified").InnerText);
                        //                    oItemRow.UpdateStatus = "PRICE CHANGE";
                        //                }
                        //            }
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./PurchaseDesc") != null)
                        //        {
                        //            oItemRow.PurchaseDesc = ItemInventoryRet.SelectSingleNode("./PurchaseDesc").InnerText;
                        //        }

                        //        //if (ItemInventoryRet.SelectSingleNode("./PurchaseCost") != null)
                        //        //{
                        //        //    oItemRow.PurchaseCost = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./PurchaseCost").InnerText);
                        //        //}


                        //        //Get value of QuantityOnOrder
                        //        if (ItemInventoryRet.SelectSingleNode("./QuantityOnOrder") != null)
                        //        {
                        //            oItemRow.QuantityOnOrder = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./QuantityOnOrder").InnerText);
                        //        }

                        //        //Get value of QuantityOnSalesOrder
                        //        if (ItemInventoryRet.SelectSingleNode("./QuantityOnSalesOrder") != null)
                        //        {
                        //            oItemRow.QuantityOnSalesOrder = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./QuantityOnSalesOrder").InnerText);
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./QuantityOnHand") != null)
                        //        {
                        //            oItemRow.StockInHand = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./QuantityOnHand").InnerText);
                        //        }

                        //        oItemRow.AvailableQuantity = (oItemRow.IsStockInHandNull() ? 0 : oItemRow.StockInHand) - (oItemRow.IsQuantityOnSalesOrderNull() ? 0 : oItemRow.QuantityOnSalesOrder);

                        //        if (oItemRow.AvailableQuantity > 0)
                        //            oItemRow.StockStatus = "IN STOCK";
                        //        else
                        //            oItemRow.StockStatus = "OUT OF STOCK";

                        //        XmlNodeList DataExtRetList = ItemInventoryRet.SelectNodes("./DataExtRet");
                        //        foreach (XmlNode xmNode in DataExtRetList)
                        //        {
                        //            if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "COLOUR".ToUpper())
                        //            {
                        //                oItemRow.Color = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR1".ToUpper())
                        //            {
                        //                oItemRow.Attr1 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR2".ToUpper())
                        //            {
                        //                oItemRow.Attr2 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR3".ToUpper())
                        //            {
                        //                oItemRow.Attr3 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR4".ToUpper())
                        //            {
                        //                oItemRow.Attr4 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR5".ToUpper())
                        //            {
                        //                oItemRow.Attr5 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "YEAR".ToUpper())
                        //            {
                        //                oItemRow.Year = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "BRAND".ToUpper())
                        //            {
                        //                oItemRow.Brand = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "SIZE".ToUpper())
                        //            {
                        //                oItemRow.Size = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ITEM STATUS".ToUpper())
                        //            {
                        //                oItemRow.ItemStatus = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "GENDER".ToUpper())
                        //            {
                        //                oItemRow.Gender = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "WARRANTY".ToUpper())
                        //            {
                        //                oItemRow.Warranty = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "TYPE".ToUpper())
                        //            {
                        //                oItemRow.CustomFieldType = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "CATEGORY".ToUpper())
                        //            {
                        //                oItemRow.CustomFieldCategory = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "CATEGORY".ToUpper())
                        //            {
                        //                //oItemRow.ItemID = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //        }

                        //        taItem.Update(oItemRow);

                        //        bgWorker.ReportProgress(0, oItemRow.FullName);
                        //        bgWorker.ReportProgress(0, "Exported to Server");
                        //        bgWorker.ReportProgress(0, "");

                        //        System.Threading.Thread.Sleep(20);
                        //    }
                        //}
                        //else
                        //{
                        //    bgWorker.ReportProgress(0, statusMessage);
                        //}
                    }

                    System.Threading.Thread.Sleep(50);
                }
                while (Convert.ToInt32(strRemaining) > 0);
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Item Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public void InventoryQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement ItemInventoryQueryRq = doc.CreateElement("ItemInventoryQueryRq");
                    qbXMLMsgsRq.AppendChild(ItemInventoryQueryRq);
                    ItemInventoryQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        ItemInventoryQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        ItemInventoryQueryRq.SetAttribute("iteratorID", strIteratorID);

                    ItemInventoryQueryRq.AppendChild(MakeSimpleElemt(doc, "MaxReturned", Common.MaxRecordReturn));

                    ItemInventoryQueryRq.AppendChild(MakeSimpleElemt(doc, "ActiveStatus", "All"));
                    ItemInventoryQueryRq.AppendChild(MakeSimpleElemt(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));

                    if (Common.UseQBQueryToDate)
                        ItemInventoryQueryRq.AppendChild(MakeSimpleElemt(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));

                    //Set field value for IncludeRetElement <!-- optional, may repeat -->
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                    //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Name"));

                    ItemInventoryQueryRq.AppendChild(MakeSimpleElemt(doc, "OwnerID", "0"));

                    strRemaining = "0";

                    string strRequest = doc.OuterXml;
                    string strResponse = QBConnection.ProcessRequest(strRequest);

                    //Parse the response XML string into an XmlDocument
                    XmlDocument responseXmlDoc = new XmlDocument();
                    responseXmlDoc.LoadXml(strResponse);

                    //Get the response for our request             
                    XmlNodeList ItemInventoryQueryRsList = responseXmlDoc.GetElementsByTagName("ItemInventoryQueryRs");
                    if (ItemInventoryQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = ItemInventoryQueryRsList.Item(0);
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
                        //    Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();
                        //    Data.dsQBSync ds = new Data.dsQBSync();
                        //    ds.EnforceConstraints = false;

                        //    XmlNodeList ItemInventoryRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query
                        //    for (int i = 0; i < ItemInventoryRetList.Count; i++)
                        //    {
                        //        XmlNode ItemInventoryRet = ItemInventoryRetList.Item(i);
                        //        string ListID = ItemInventoryRet.SelectSingleNode("./ListID").InnerText;

                        //        var oItemRow = ds.Items.NewItemsRow();

                        //        taItem.FillByQBListID(ds.Items, ListID);
                        //        if (ds.Items.Count > 0)
                        //        {
                        //            oItemRow = ds.Items[0];
                        //            oItemRow.UpdateStatus = "OTHER";
                        //        }
                        //        else
                        //        {
                        //            oItemRow.ListID = ListID;
                        //            oItemRow.ItemType = "Inventory";
                        //            oItemRow.UpdateStatus = "NEW";
                        //            ds.Items.AddItemsRow(oItemRow);
                        //        }

                        //        oItemRow.TimeCreated = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeCreated").InnerText);
                        //        oItemRow.TimeModified = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeModified").InnerText);
                        //        oItemRow.Name = ItemInventoryRet.SelectSingleNode("./Name").InnerText;
                        //        oItemRow.FullName = ItemInventoryRet.SelectSingleNode("./FullName").InnerText;
                        //        if (ItemInventoryRet.SelectSingleNode("./IsActive") != null)
                        //        {
                        //            oItemRow.IsActive = Convert.ToBoolean(ItemInventoryRet.SelectSingleNode("./IsActive").InnerText);
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./ParentRef") != null)
                        //        {
                        //            if (ItemInventoryRet.SelectSingleNode("./ParentRef/FullName") != null)
                        //            {
                        //                oItemRow.ParentRef = ItemInventoryRet.SelectSingleNode("./ParentRef/FullName").InnerText;

                        //                var lst = oItemRow.ParentRef.Split(':');

                        //                if (lst.Count() == 1)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = oItemRow.Name;
                        //                }
                        //                else if (lst.Count() == 2)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = lst[1];
                        //                    oItemRow.ItemGroup = oItemRow.Name;
                        //                }
                        //                else if (lst.Count() == 3)
                        //                {
                        //                    oItemRow.Category = lst[0];
                        //                    oItemRow.SubCategory = lst[1];
                        //                    oItemRow.ItemGroup = lst[2];
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            oItemRow.Category = oItemRow.Name;
                        //        }

                        //        oItemRow.Sublevel = Convert.ToInt32(ItemInventoryRet.SelectSingleNode("./Sublevel").InnerText);

                        //        if (ItemInventoryRet.SelectSingleNode("./ClassRef") != null)
                        //        {
                        //            if (ItemInventoryRet.SelectSingleNode("./ClassRef/FullName") != null)
                        //            {
                        //                oItemRow.ClassRef = ItemInventoryRet.SelectSingleNode("./ClassRef/FullName").InnerText;
                        //            }
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./SalesDesc") != null)
                        //        {
                        //            oItemRow.SalesDesc = ItemInventoryRet.SelectSingleNode("./SalesDesc").InnerText;
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef") != null && ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                        //        {
                        //            oItemRow.TaxCode = ItemInventoryRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                        //        }

                        //        //Get value of SalesPrice
                        //        if (ItemInventoryRet.SelectSingleNode("./SalesPrice") != null)
                        //        {
                        //            var salePrice = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./SalesPrice").InnerText);

                        //            if (oItemRow.IsSalePriceNull() == false)
                        //            {
                        //                if (salePrice != oItemRow.SalePrice)
                        //                    oItemRow.UpdateStatus = "PRICE CHANGE";
                        //            }

                        //            oItemRow.SalePrice = salePrice;

                        //            if (oItemRow.TaxCode == "Tax")
                        //            {
                        //                oItemRow.MSRP = Math.Round(oItemRow.SalePrice * 1.10, 2);
                        //            }
                        //            else
                        //            {
                        //                oItemRow.MSRP = oItemRow.SalePrice;
                        //            }

                        //            string classRef = oItemRow.IsClassRefNull() ? "" : oItemRow.ClassRef;

                        //            if (!string.IsNullOrEmpty(classRef))
                        //            {
                        //                double markup = 0;
                        //                double.TryParse(classRef.Replace("%", "").Trim(), out markup);
                        //                markup = markup / 100 + 1;
                        //                var wholeSalePrice = oItemRow.SalePrice * markup;
                        //                wholeSalePrice = Math.Round(wholeSalePrice / 1000d, 0) * 1000;
                        //                oItemRow.WholeSalePrice = wholeSalePrice;
                        //            }
                        //        }

                        //        if (ItemInventoryRet.SelectSingleNode("./PurchaseDesc") != null)
                        //        {
                        //            oItemRow.PurchaseDesc = ItemInventoryRet.SelectSingleNode("./PurchaseDesc").InnerText;
                        //        }

                        //        //if (ItemInventoryRet.SelectSingleNode("./PurchaseCost") != null)
                        //        //{
                        //        //    oItemRow.PurchaseCost = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./PurchaseCost").InnerText);
                        //        //}



                        //        if (ItemInventoryRet.SelectSingleNode("./QuantityOnHand") != null)
                        //        {
                        //            oItemRow.StockInHand = Convert.ToDouble(ItemInventoryRet.SelectSingleNode("./QuantityOnHand").InnerText);

                        //            if (oItemRow.StockInHand > 0)
                        //                oItemRow.StockStatus = "IN STOCK";
                        //            else
                        //                oItemRow.StockStatus = "OUT OF STOCK";
                        //        }

                        //        //if (ItemInventoryRet.SelectSingleNode("./IncomeAccountRef") != null)
                        //        //{
                        //        //    if (ItemInventoryRet.SelectSingleNode("./IncomeAccountRef/ListID") != null)
                        //        //    {
                        //        //        oItemRow.IncomeAccountListID = ItemInventoryRet.SelectSingleNode("./IncomeAccountRef/ListID").InnerText;
                        //        //    }

                        //        //    //Get value of FullName
                        //        //    if (ItemInventoryRet.SelectSingleNode("./IncomeAccountRef/FullName") != null)
                        //        //    {
                        //        //        oItemRow.IncomeAccountFullName = ItemInventoryRet.SelectSingleNode("./IncomeAccountRef/FullName").InnerText;
                        //        //    }
                        //        //}

                        //        //if (ItemInventoryRet.SelectSingleNode("./COGSAccountRef") != null)
                        //        //{
                        //        //    if (ItemInventoryRet.SelectSingleNode("./COGSAccountRef/ListID") != null)
                        //        //    {
                        //        //        oItemRow.ExpenseAccountListID = ItemInventoryRet.SelectSingleNode("./COGSAccountRef/ListID").InnerText;
                        //        //    }

                        //        //    //Get value of FullName
                        //        //    if (ItemInventoryRet.SelectSingleNode("./COGSAccountRef/FullName") != null)
                        //        //    {
                        //        //        oItemRow.ExpenseAccountFullName = ItemInventoryRet.SelectSingleNode("./COGSAccountRef/FullName").InnerText;
                        //        //    }
                        //        //}

                        //        //if (ItemInventoryRet.SelectSingleNode("./AssetAccountRef") != null)
                        //        //{
                        //        //    if (ItemInventoryRet.SelectSingleNode("./AssetAccountRef/ListID") != null)
                        //        //    {
                        //        //        oItemRow.AssetAccountListID = ItemInventoryRet.SelectSingleNode("./AssetAccountRef/ListID").InnerText;
                        //        //    }

                        //        //    //Get value of FullName
                        //        //    if (ItemInventoryRet.SelectSingleNode("./AssetAccountRef/FullName") != null)
                        //        //    {
                        //        //        oItemRow.AssetAccountFullName = ItemInventoryRet.SelectSingleNode("./AssetAccountRef/FullName").InnerText;
                        //        //    }
                        //        //}

                        //        //if (ItemInventoryRet.SelectSingleNode("./PrefVendorRef") != null)
                        //        //{
                        //        //    if (ItemInventoryRet.SelectSingleNode("./PrefVendorRef/ListID") != null)
                        //        //    {
                        //        //        oItemRow.VendorListID = ItemInventoryRet.SelectSingleNode("./PrefVendorRef/ListID").InnerText;
                        //        //    }

                        //        //    //Get value of FullName
                        //        //    if (ItemInventoryRet.SelectSingleNode("./PrefVendorRef/FullName") != null)
                        //        //    {
                        //        //        oItemRow.VendorFullName = ItemInventoryRet.SelectSingleNode("./PrefVendorRef/FullName").InnerText;
                        //        //    }
                        //        //}

                        //        XmlNodeList DataExtRetList = ItemInventoryRet.SelectNodes("./DataExtRet");
                        //        foreach (XmlNode xmNode in DataExtRetList)
                        //        {
                        //            if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "COLOUR".ToUpper())
                        //            {
                        //                oItemRow.Color = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR1".ToUpper())
                        //            {
                        //                oItemRow.Attr1 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR2".ToUpper())
                        //            {
                        //                oItemRow.Attr2 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR3".ToUpper())
                        //            {
                        //                oItemRow.Attr3 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR4".ToUpper())
                        //            {
                        //                oItemRow.Attr4 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ATTR5".ToUpper())
                        //            {
                        //                oItemRow.Attr5 = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "YEAR".ToUpper())
                        //            {
                        //                oItemRow.Year = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "BRAND".ToUpper())
                        //            {
                        //                oItemRow.Brand = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "SIZE".ToUpper())
                        //            {
                        //                oItemRow.Size = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ITEM STATUS".ToUpper())
                        //            {
                        //                oItemRow.ItemStatus = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "GENDER".ToUpper())
                        //            {
                        //                oItemRow.Gender = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "WARRANTY".ToUpper())
                        //            {
                        //                oItemRow.Warranty = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //            else if (xmNode.SelectSingleNode("./DataExtName") != null && xmNode.SelectSingleNode("./DataExtName").InnerText.ToUpper() == "ITEM ID".ToUpper())
                        //            {
                        //                //oItemRow.ItemID = xmNode.SelectSingleNode("./DataExtValue").InnerText;
                        //            }
                        //        }

                        //        taItem.Update(oItemRow);

                        //        bgWorker.ReportProgress(0, oItemRow.FullName);
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

                bgWorker.ReportProgress(0, "Error! Item Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        private void AddUpdateCategory(string strName)
        {
            try
            {
                Data.dsQBSync ds = new Data.dsQBSync();
                ds.EnforceConstraints = false;


            }
            catch (Exception ex)
            { }
        }

        public void ItemStockReport(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
                doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
                XmlElement parent = doc.CreateElement("QBXML");
                doc.AppendChild(parent);
                XmlElement qbXMLMsgsRq = doc.CreateElement("QBXMLMsgsRq");
                parent.AppendChild(qbXMLMsgsRq);
                qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
                XmlElement GeneralSummaryReportQueryRq = doc.CreateElement("GeneralSummaryReportQueryRq");
                qbXMLMsgsRq.AppendChild(GeneralSummaryReportQueryRq);
                //Set field value for GeneralSummaryReportType <!-- required -->
                GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "GeneralSummaryReportType", "InventoryStockStatusByItem"));
                //Set field value for DisplayReport <!-- optional -->
                GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "DisplayReport", "0"));

                GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "ReportDateMacro", "Today"));

                //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "IncludeRetElement", "CompanyName"));

                //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "ReturnRows", "NonZero"));
                //Set field value for ReturnColumns <!-- optional -->
                //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "ReturnColumns", "NonZero"));


                //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElemt(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));


                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request             
                XmlNodeList GeneralSummaryReportQueryRsList = responseXmlDoc.GetElementsByTagName("GeneralSummaryReportQueryRs");
                if (GeneralSummaryReportQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = GeneralSummaryReportQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                    //Common.ApplicationLog(responseNode.Name + "-" + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    //if (Convert.ToInt32(statusCode) == 0)
                    //{
                    //    Data.dsQBSyncTableAdapters.ItemsTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemsTableAdapter();
                    //    Data.dsQBSync ds = new Data.dsQBSync();
                    //    ds.EnforceConstraints = false;

                    //    XmlNodeList ReportRetList = responseNode.SelectNodes("//ReportRet");//XPath Query
                    //    for (int i = 0; i < ReportRetList.Count; i++)
                    //    {
                    //        XmlNode ReportRet = ReportRetList.Item(i);

                    //        string ReportTitle = ReportRet.SelectSingleNode("./ReportTitle").InnerText;
                    //        //Get value of ReportSubtitle
                    //        string ReportSubtitle = ReportRet.SelectSingleNode("./ReportSubtitle").InnerText;
                    //        //Get value of ReportBasis
                    //        if (ReportRet.SelectSingleNode("./ReportBasis") != null)
                    //        {
                    //            string ReportBasis = ReportRet.SelectSingleNode("./ReportBasis").InnerText;

                    //        }
                    //        //Get value of NumRows
                    //        string NumRows = ReportRet.SelectSingleNode("./NumRows").InnerText;
                    //        //Get value of NumColumns
                    //        string NumColumns = ReportRet.SelectSingleNode("./NumColumns").InnerText;
                    //        //Get value of NumColTitleRows
                    //        string NumColTitleRows = ReportRet.SelectSingleNode("./NumColTitleRows").InnerText;

                    //        string colIDNextDeliv = "";
                    //        //Walk list of ColDesc aggregates
                    //        XmlNodeList ColDescList = ReportRet.SelectNodes("./ColDesc");
                    //        if (ColDescList != null)
                    //        {
                    //            for (int j = 0; j < ColDescList.Count; j++)
                    //            {
                    //                XmlNode ColDesc = ColDescList.Item(j);

                    //                if (ColDesc.SelectSingleNode("./ColTitle") != null)
                    //                {
                    //                    XmlNode ColTitle = ColDesc.SelectSingleNode("./ColTitle");
                    //                    if (ColTitle.Attributes["value"] != null)
                    //                    {
                    //                        string colName = ColTitle.Attributes["value"].InnerText;

                    //                        if (colName == "Next Deliv")
                    //                        {
                    //                            if (ColDesc.Attributes["colID"] != null)
                    //                            {
                    //                                colIDNextDeliv = ColDesc.Attributes["colID"].InnerText;
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                //XmlNodeList ColTitleList = ColDesc.SelectNodes("./ColTitle");
                    //                //if (ColTitleList != null)
                    //                //{
                    //                //    for (int k = 0; k < ColTitleList.Count; k++)
                    //                //    {
                    //                //        XmlNode ColTitle = ColTitleList.Item(k);

                    //                //        //if(ColTitle == "")
                    //                //    }
                    //                //}
                    //                //Get value of ColType
                    //                string ColType = ColDesc.SelectSingleNode("./ColType").InnerText;
                    //            }
                    //        }

                    //        //Get all field values for ReportData aggregate 
                    //        XmlNode ReportData = ReportRet.SelectSingleNode("./ReportData");
                    //        if (ReportData != null)
                    //        {
                    //            XmlNodeList ORReportDataListChildren = ReportRet.SelectNodes("./ReportData/DataRow");
                    //            for (int m = 0; m < ORReportDataListChildren.Count; m++)
                    //            {
                    //                XmlNode Child = ORReportDataListChildren.Item(m);
                    //                if (Child.Name == "DataRow")
                    //                {
                    //                    //Get all field values for RowData aggregate 
                    //                    string ItemFullName = "";
                    //                    XmlNode RowData = Child.SelectSingleNode("./RowData");
                    //                    if (RowData != null)
                    //                    {
                    //                        ItemFullName = RowData.Attributes["value"].InnerText;
                    //                    }
                    //                    //Done with field values for RowData aggregate

                    //                    XmlNode ColDataNextDel = Child.SelectSingleNode("./ColData[@colID='" + colIDNextDeliv + "']");

                    //                    if (ColDataNextDel != null)
                    //                    {
                    //                        string colValue = ColDataNextDel.Attributes["value"].InnerText;

                    //                        taItem.UpdateNextDeliveryByFullName(Convert.ToDateTime(colValue), ItemFullName);
                    //                    }
                    //                    else
                    //                    {
                    //                        taItem.SetNextDeliveryNullByFullName(ItemFullName);
                    //                    }
                    //                    ////Walk list of ColData aggregates
                    //                    //XmlNodeList ColDataList = Child.SelectNodes("./ColData");
                    //                    //if (ColDataList != null)
                    //                    //{
                    //                    //    for (int ii = 0; ii < ColDataList.Count; ii++)
                    //                    //    {
                    //                    //        XmlNode ColData = ColDataList.Item(ii);
                    //                    //    }
                    //                    //}
                    //                }
                    //            }
                    //        }
                    //        //Done with field values for ReportData aggregate
                    //    }
                    //}
                    //else
                    //{
                    //    bgWorker.ReportProgress(0, statusMessage);
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! ItemStockReport");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public String GetItemGroupTypeEditSequence(String ListID)
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

                //Create VendorModRq  aggregate and fill in field values for it
                XmlElement ItemQueryRq = inputXMLDoc.CreateElement("ItemQueryRq");
                qbXMLMsgsRq.AppendChild(ItemQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "ListID", ListID));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "ListID"));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList ItemQueryRsList = responseXmlDoc.GetElementsByTagName("ItemQueryRs");
                if (ItemQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ItemQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode VendorRet = ItemRetList.Item(i);
                            //string ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = VendorRet.SelectSingleNode("./EditSequence").InnerText;

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

        public String GetItemTypeEditSequence(String ListID)
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

                //Create VendorModRq  aggregate and fill in field values for it
                XmlElement ItemQueryRq = inputXMLDoc.CreateElement("ItemQueryRq");
                qbXMLMsgsRq.AppendChild(ItemQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "ListID", ListID));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "ListID"));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList ItemQueryRsList = responseXmlDoc.GetElementsByTagName("ItemQueryRs");
                if (ItemQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ItemQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode VendorRet = ItemRetList.Item(i);
                            //string ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = VendorRet.SelectSingleNode("./EditSequence").InnerText;

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

        public String GetItemEditSequence(String ListID)
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

                //Create VendorModRq  aggregate and fill in field values for it
                XmlElement ItemQueryRq = inputXMLDoc.CreateElement("ItemQueryRq");
                qbXMLMsgsRq.AppendChild(ItemQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "ListID", ListID));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "ListID"));
                ItemQueryRq.AppendChild(MakeSimpleElemt(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList ItemQueryRsList = responseXmlDoc.GetElementsByTagName("ItemQueryRs");
                if (ItemQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = ItemQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode VendorRet = ItemRetList.Item(i);
                            //string ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult = VendorRet.SelectSingleNode("./EditSequence").InnerText;

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

        public void AddItemGroupType(Data.dsQBSync.ItemGroupTypeRow ItemGroupTypeRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            Data.dsQBSyncTableAdapters.ItemGroupTypeTableAdapter taItemGroupType = new Data.dsQBSyncTableAdapters.ItemGroupTypeTableAdapter();

            //step2: create the qbXML request
            XmlDocument inputXMLDoc = new XmlDocument();
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
            XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
            inputXMLDoc.AppendChild(qbXML);
            XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(qbXMLMsgsRq);
            qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
            XmlElement custAddRq = inputXMLDoc.CreateElement("ItemInventoryAddRq");
            qbXMLMsgsRq.AppendChild(custAddRq);
            custAddRq.SetAttribute("requestID", "1");
            XmlElement custAdd = inputXMLDoc.CreateElement("ItemInventoryAdd");
            custAddRq.AppendChild(custAdd);
            custAdd.AppendChild(inputXMLDoc.CreateElement("Name")).InnerText = ItemGroupTypeRow.Name;

            XmlElement IncomeAccountAdd = inputXMLDoc.CreateElement("IncomeAccountRef");
            custAdd.AppendChild(IncomeAccountAdd);
            IncomeAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            XmlElement COGSAccountAdd = inputXMLDoc.CreateElement("COGSAccountRef");
            custAdd.AppendChild(COGSAccountAdd);
            COGSAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            XmlElement AssetAccountAdd = inputXMLDoc.CreateElement("AssetAccountRef");
            custAdd.AppendChild(AssetAccountAdd);
            AssetAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            string input = inputXMLDoc.OuterXml;
            string strResponse = "";
            bool isEdit = false; string editSequence = "";
            if (!string.IsNullOrEmpty(listId))
            {
                editSequence = GetItemGroupTypeEditSequence(listId);
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
            try
            {
                strResponse = QBConnection.ProcessRequest(input);
            }
            catch (Exception ex)
            {

            }
            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            XmlNodeList ItemAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "ItemInventoryModRs" : "ItemInventoryAddRs");
            if (ItemAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = ItemAddRsList.Item(0);
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
                        if (statusMessage.Contains("There is an invalid reference to QuickBooks Item Group Type"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item Group Type"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item Group Type");
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                    }
                    else if (statusCode == "0")
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = ItemRetList.Item(i);
                            string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

                            var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //Get value of TimeModified
                            var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);

                            string ItemListID = "";
                            if (SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID") != null)
                            {
                                ItemListID = SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID").InnerText;
                            }

                            string sysNotes = ("Exported to QuickBooks " + DateTime.Now);

                            taItemGroupType.UpdateQBFields(newTxnId, TimeCreated, TimeModified, ItemGroupTypeRow.ID);

                            bgWorker.ReportProgress(0, "Item Group Type " + (isEdit ? "updated" : "added") + " successfully");
                        }
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item Group Type");
                        bgWorker.ReportProgress(0, statusMessage);
                    }
                }
            }

        }

        public void AddItemType(Data.dsQBSync.ItemTypeRow ItemTypeRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            Data.dsQBSyncTableAdapters.ItemTypeTableAdapter taItemType = new Data.dsQBSyncTableAdapters.ItemTypeTableAdapter();

            //step2: create the qbXML request
            XmlDocument inputXMLDoc = new XmlDocument();
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
            XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
            inputXMLDoc.AppendChild(qbXML);
            XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(qbXMLMsgsRq);
            qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
            XmlElement custAddRq = inputXMLDoc.CreateElement("ItemInventoryAddRq");
            qbXMLMsgsRq.AppendChild(custAddRq);
            custAddRq.SetAttribute("requestID", "1");
            XmlElement custAdd = inputXMLDoc.CreateElement("ItemInventoryAdd");
            custAddRq.AppendChild(custAdd);
            custAdd.AppendChild(inputXMLDoc.CreateElement("Name")).InnerText = ItemTypeRow.Name;

            XmlElement IncomeAccountAdd = inputXMLDoc.CreateElement("IncomeAccountRef");
            custAdd.AppendChild(IncomeAccountAdd);
            IncomeAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            XmlElement COGSAccountAdd = inputXMLDoc.CreateElement("COGSAccountRef");
            custAdd.AppendChild(COGSAccountAdd);
            COGSAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            XmlElement AssetAccountAdd = inputXMLDoc.CreateElement("AssetAccountRef");
            custAdd.AppendChild(AssetAccountAdd);
            AssetAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            string input = inputXMLDoc.OuterXml;
            string strResponse = "";
            bool isEdit = false; string editSequence = "";
            if (!string.IsNullOrEmpty(listId))
            {
                editSequence = GetItemTypeEditSequence(listId);
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
            try
            {
                strResponse = QBConnection.ProcessRequest(input);
            }
            catch (Exception ex)
            {

            }
            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            XmlNodeList ItemAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "ItemInventoryModRs" : "ItemInventoryAddRs");
            if (ItemAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = ItemAddRsList.Item(0);
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
                        if (statusMessage.Contains("There is an invalid reference to QuickBooks Item Type"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item Type"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item Type");
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                    }
                    else if (statusCode == "0")
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = ItemRetList.Item(i);
                            string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

                            var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //Get value of TimeModified
                            var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);

                            string ItemListID = "";
                            if (SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID") != null)
                            {
                                ItemListID = SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID").InnerText;
                            }

                            string sysNotes = ("Exported to QuickBooks " + DateTime.Now);

                            taItemType.UpdateQBFields(newTxnId, TimeModified, ItemTypeRow.ID);

                            bgWorker.ReportProgress(0, "Item Type " + (isEdit ? "updated" : "added") + " successfully");
                        }
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item Type");
                        bgWorker.ReportProgress(0, statusMessage);
                    }
                }
            }
        }

        public void AddItem(Data.dsQBSync.ItemRow ItemRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            Data.dsQBSyncTableAdapters.ItemTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemTableAdapter();

            //step2: create the qbXML request
            XmlDocument inputXMLDoc = new XmlDocument();
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"" + QBSync.Common.QuickBookVersion + "\""));
            XmlElement qbXML = inputXMLDoc.CreateElement("QBXML");
            inputXMLDoc.AppendChild(qbXML);
            XmlElement qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");
            qbXML.AppendChild(qbXMLMsgsRq);
            qbXMLMsgsRq.SetAttribute("onError", "stopOnError");
            XmlElement custAddRq = inputXMLDoc.CreateElement("ItemInventoryAddRq");
            qbXMLMsgsRq.AppendChild(custAddRq);
            custAddRq.SetAttribute("requestID", "1");
            XmlElement custAdd = inputXMLDoc.CreateElement("ItemInventoryAdd");
            custAddRq.AppendChild(custAdd);
            custAdd.AppendChild(inputXMLDoc.CreateElement("Name")).InnerText = ItemRow.Catalog;
            custAdd.AppendChild(inputXMLDoc.CreateElement("IsActive")).InnerText = ItemRow.Active ? "1" : "0";

            XmlElement ParentRef = inputXMLDoc.CreateElement("ParentRef");
            custAdd.AppendChild(ParentRef);
            ParentRef.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = ItemRow.ItemTypeName;


            XmlElement IncomeAccountAdd = inputXMLDoc.CreateElement("IncomeAccountRef");
            custAdd.AppendChild(IncomeAccountAdd);
            IncomeAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            custAdd.AppendChild(inputXMLDoc.CreateElement("PurchaseCost")).InnerText = ItemRow.CatalogCost.ToString();

            XmlElement COGSAccountAdd = inputXMLDoc.CreateElement("COGSAccountRef");
            custAdd.AppendChild(COGSAccountAdd);
            COGSAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            XmlElement AssetAccountAdd = inputXMLDoc.CreateElement("AssetAccountRef");
            custAdd.AppendChild(AssetAccountAdd);
            AssetAccountAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = "Sales";

            //custAdd.AppendChild(inputXMLDoc.CreateElement("PurchaseCost")).InnerText = ItemRow.CatalogCost.ToString();
            custAdd.AppendChild(inputXMLDoc.CreateElement("QuantityOnHand")).InnerText = ItemRow.QtyOnHand.ToString();
            //custAdd.AppendChild(inputXMLDoc.CreateElement("QuantityOnSalesOrder")).InnerText = ItemRow.AvailableQty.ToString();

            string input = inputXMLDoc.OuterXml;
            string strResponse = "";
            bool isEdit = false; string editSequence = "";
            if (!string.IsNullOrEmpty(listId))
            {
                editSequence = GetItemEditSequence(listId);
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
            try
            {
                strResponse = QBConnection.ProcessRequest(input);
            }
            catch (Exception ex)
            {

            }
            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(strResponse);

            XmlNodeList ItemAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "ItemInventoryModRs" : "ItemInventoryAddRs");
            if (ItemAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = ItemAddRsList.Item(0);
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
                        if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else if (statusMessage.Contains("There is an invalid reference to QuickBooks Item"))
                        {
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item");
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                    }
                    else if (statusCode == "0")
                    {
                        XmlNodeList ItemRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query
                        for (int i = 0; i < ItemRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = ItemRetList.Item(i);
                            string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

                            var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //Get value of TimeModified
                            var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);

                            string ItemListID = "";
                            if (SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID") != null)
                            {
                                ItemListID = SalesOrderRet.SelectSingleNode("./ItemInventoryRef/ListID").InnerText;
                            }

                            string sysNotes = ("Exported to QuickBooks " + DateTime.Now);

                            taItem.UpdateQBFields(newTxnId, TimeModified, ItemRow.ID);

                            bgWorker.ReportProgress(0, "Item " + (isEdit ? "updated" : "added") + " successfully");
                        }
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Item");
                        bgWorker.ReportProgress(0, statusMessage);
                    }
                }
            }

        }

        //public Boolean ServiceItemAdd(Data.dsQBSync.ItemRow pItem, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String ItemName = Common.Truncate(pItem.ItemName, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemServiceAddRq = doc.CreateElement("ItemServiceAddRq");
        //        parent.AppendChild(ItemServiceAddRq);
        //        XmlElement ItemServiceAdd = doc.CreateElement("ItemServiceAdd");
        //        ItemServiceAddRq.AppendChild(ItemServiceAdd);

        //        ItemServiceAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(ItemName, 41)));
        //        ItemServiceAdd.AppendChild(MakeSimpleElem(doc, "IsActive", ((pItem.IsIsDeletedNull() ? false : pItem.IsDeleted) == true ? 0 : 1).ToString()));

        //        XmlElement SalesOrPurchase = doc.CreateElement("SalesOrPurchase");
        //        ItemServiceAdd.AppendChild(SalesOrPurchase);

        //        if (!String.IsNullOrEmpty(pItem.IsDescriptionNull() ? "" : pItem.Description))
        //            SalesOrPurchase.AppendChild(MakeSimpleElem(doc, "Desc", pItem.Description));

        //        SalesOrPurchase.AppendChild(MakeSimpleElem(doc, "Price", (pItem.IsPriceNull() ? 0 : pItem.Price).ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(Common.Settings.IsIncomeAccountNull() ? "" : Common.Settings.IncomeAccount))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            SalesOrPurchase.AppendChild(AccountRef);
        //            AccountRef.AppendChild(MakeSimpleElem(doc, "FullName", Common.Settings.IncomeAccount));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemServiceAddRsList = responseXmlDoc.GetElementsByTagName("ItemServiceAddRs");
        //        if (ItemServiceAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemServiceAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    var custExist = GetServiceItemListID(ItemName);
        //                    if (custExist != null)
        //                    {
        //                        pItem.QBListId = custExist.ListID;
        //                        blnResult = ServiceItemMod(pItem, custExist.EditSequence, bgWorker);
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemServiceRetList = responseNode.SelectNodes("//ItemServiceRet");//XPath Query
        //                    for (int i = 0; i < ItemServiceRetList.Count; i++)
        //                    {
        //                        XmlNode ItemServiceRet = ItemServiceRetList.Item(i);

        //                        String ListID = ItemServiceRet.SelectSingleNode("./ListID").InnerText;
        //                        String FullName = ItemServiceRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemServiceRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemServiceRet.SelectSingleNode("./EditSequence").InnerText;

        //                        Data.dsQBSyncTableAdapters.ItemTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemTableAdapter();
        //                        taItem.UpdateQBStatus(ListID, true, pItem.ID);

        //                        bgWorker.ReportProgress(0, "Added in QuickBooks");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //    return blnResult;
        //}

        //public Boolean ServiceItemMod(Data.dsQBSync.ItemRow pItem, string QBEditSequence, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String ItemName = Common.Truncate(pItem.ItemName, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemServiceModRq = doc.CreateElement("ItemServiceModRq");
        //        parent.AppendChild(ItemServiceModRq);
        //        XmlElement ItemServiceMod = doc.CreateElement("ItemServiceMod");
        //        ItemServiceModRq.AppendChild(ItemServiceMod);

        //        ItemServiceMod.AppendChild(MakeSimpleElem(doc, "ListID", pItem.QBListId));
        //        //Set field value for EditSequence <!-- required -->
        //        ItemServiceMod.AppendChild(MakeSimpleElem(doc, "EditSequence", QBEditSequence));

        //        ItemServiceMod.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(ItemName, 41)));
        //        ItemServiceMod.AppendChild(MakeSimpleElem(doc, "IsActive", ((pItem.IsIsDeletedNull() ? false : pItem.IsDeleted) == true ? 0 : 1).ToString()));

        //        XmlElement SalesOrPurchase = doc.CreateElement("SalesOrPurchaseMod");
        //        ItemServiceMod.AppendChild(SalesOrPurchase);

        //        if (!String.IsNullOrEmpty(pItem.IsDescriptionNull() ? "" : pItem.Description))
        //            SalesOrPurchase.AppendChild(MakeSimpleElem(doc, "Desc", pItem.Description));

        //        SalesOrPurchase.AppendChild(MakeSimpleElem(doc, "Price", (pItem.IsPriceNull() ? 0 : pItem.Price).ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(Common.Settings.IsIncomeAccountNull() ? "" : Common.Settings.IncomeAccount))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            SalesOrPurchase.AppendChild(AccountRef);
        //            AccountRef.AppendChild(MakeSimpleElem(doc, "FullName", Common.Settings.IncomeAccount));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemServiceModRsList = responseXmlDoc.GetElementsByTagName("ItemServiceModRs");
        //        if (ItemServiceModRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemServiceModRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    blnResult = true;
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemServiceRetList = responseNode.SelectNodes("//ItemServiceRet");//XPath Query
        //                    for (int i = 0; i < ItemServiceRetList.Count; i++)
        //                    {
        //                        XmlNode ItemServiceRet = ItemServiceRetList.Item(i);

        //                        String ListID = ItemServiceRet.SelectSingleNode("./ListID").InnerText;
        //                        String FullName = ItemServiceRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemServiceRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemServiceRet.SelectSingleNode("./EditSequence").InnerText;

        //                        Data.dsQBSyncTableAdapters.ItemTableAdapter taItem = new Data.dsQBSyncTableAdapters.ItemTableAdapter();
        //                        taItem.UpdateQBStatus(ListID, true, pItem.ID);

        //                        bgWorker.ReportProgress(0, "Updated in QuickBooks");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Updating in Item");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Updating in Item");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }
        //    return blnResult;
        //}

        //public String GetServiceItemEditSequence(String ListID)
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
        //        XmlElement ItemServiceQueryRq = inputXMLDoc.CreateElement("ItemServiceQueryRq");
        //        qbXMLMsgsRq.AppendChild(ItemServiceQueryRq);
        //        //custRq.SetAttribute("requestID", "1");

        //        //Set field value for FullName <!-- optional, may repeat -->              
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

        //        string strRequest = inputXMLDoc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemServiceQueryRsList = responseXmlDoc.GetElementsByTagName("ItemServiceQueryRs");
        //        if (ItemServiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemServiceQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                XmlNodeList ItemServiceRetList = responseNode.SelectNodes("//ItemServiceRet");//XPath Query
        //                for (int i = 0; i < ItemServiceRetList.Count; i++)
        //                {
        //                    XmlNode ItemServiceRet = ItemServiceRetList.Item(i);
        //                    //string ListID = CustomerRet.SelectSingleNode("./ListID").InnerText;
        //                    //Get value of EditSequence
        //                    strResult = ItemServiceRet.SelectSingleNode("./EditSequence").InnerText;

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

        //public MdlQB GetServiceItemListID(String FullName)
        //{
        //    MdlQB strResult = null;
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
        //        XmlElement ItemServiceQueryRq = inputXMLDoc.CreateElement("ItemServiceQueryRq");
        //        qbXMLMsgsRq.AppendChild(ItemServiceQueryRq);
        //        //custRq.SetAttribute("requestID", "1");

        //        //Set field value for FullName <!-- optional, may repeat -->              
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", FullName));
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
        //        ItemServiceQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

        //        string strRequest = inputXMLDoc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemServiceQueryRsList = responseXmlDoc.GetElementsByTagName("ItemServiceQueryRs");
        //        if (ItemServiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemServiceQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                XmlNodeList ItemServiceRetList = responseNode.SelectNodes("//ItemServiceRet");//XPath Query
        //                for (int i = 0; i < ItemServiceRetList.Count; i++)
        //                {
        //                    strResult = new MdlQB();

        //                    XmlNode ItemServiceRet = ItemServiceRetList.Item(i);
        //                    strResult.ListID = ItemServiceRet.SelectSingleNode("./ListID").InnerText;
        //                    //Get value of EditSequence
        //                    strResult.EditSequence = ItemServiceRet.SelectSingleNode("./EditSequence").InnerText;

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

        //public Boolean AddItem(String ItemListID, int BranchID, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    bool blnResult = false;

        //    using (QBSyncWebService service = new QBLinxWebService())
        //    {
        //        var item = service.GetItemByListID(ItemListID, BranchID);

        //        if (item != null)
        //        {
        //            switch (item.ItemType)
        //            {
        //                case "Discount":
        //                    blnResult = DiscountItemAdd(item, bgWorker);
        //                    break;

        //                case "Inventory":
        //                    blnResult = InventoryItemAdd(item, bgWorker);
        //                    break;

        //                case "NonInventory":
        //                    blnResult = NonInventoryItemAdd(item, bgWorker);
        //                    break;

        //                case "OtherCharge":
        //                    blnResult = OtherChargesAdd(item, bgWorker);
        //                    break;

        //                case "Service":
        //                    blnResult = ServiceItemAdd(item, bgWorker);
        //                    break;
        //            }
        //        }
        //    }


        //    return blnResult;
        //}

        //public Boolean ServiceItemAdd(QBLinxDataService.MdlItems item, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String ItemName = Common.Truncate(item.Name, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemServiceAddRq = doc.CreateElement("ItemServiceAddRq");
        //        parent.AppendChild(ItemServiceAddRq);
        //        XmlElement ItemServiceAdd = doc.CreateElement("ItemServiceAdd");
        //        ItemServiceAddRq.AppendChild(ItemServiceAdd);

        //        ItemServiceAdd.AppendChild(MakeSimpleElemt(doc, "Name", Common.Truncate(ItemName, 41)));

        //        if (!string.IsNullOrEmpty(item.TaxCode))
        //        {
        //            //Create SalesTaxCodeRef aggregate and fill in field values for it
        //            XmlElement SalesTaxCodeRef = doc.CreateElement("SalesTaxCodeRef");
        //            ItemServiceAdd.AppendChild(SalesTaxCodeRef);
        //            //Set field value for FullName <!-- optional -->
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.TaxCode));
        //        }

        //        XmlElement SalesOrPurchase = doc.CreateElement("SalesOrPurchase");
        //        ItemServiceAdd.AppendChild(SalesOrPurchase);

        //        if (!string.IsNullOrEmpty(item.SalesDesc))
        //        {
        //            SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Desc", item.SalesDesc));
        //        }

        //        SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Price", item.SalesPrice.ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(item.IncomeAccountFullName))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            SalesOrPurchase.AppendChild(AccountRef);
        //            AccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.IncomeAccountFullName));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemServiceAddRsList = responseXmlDoc.GetElementsByTagName("ItemServiceAddRs");
        //        if (ItemServiceAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemServiceAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            Accounts objAccount = new Accounts();
        //                            String account = result[1];

        //                            if (objAccount.AddAccount(account, item.BranchID, bgWorker))
        //                                blnResult = ServiceItemAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + item.Name + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemServiceRetList = responseNode.SelectNodes("//ItemServiceRet");//XPath Query
        //                    for (int i = 0; i < ItemServiceRetList.Count; i++)
        //                    {
        //                        XmlNode ItemServiceRet = ItemServiceRetList.Item(i);

        //                        String ListID = ItemServiceRet.SelectSingleNode("./ListID").InnerText;
        //                        String Name = ItemServiceRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemServiceRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemServiceRet.SelectSingleNode("./EditSequence").InnerText;

        //                        bgWorker.ReportProgress(0, "'" + Name + "' Item added");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}

        //public Boolean NonInventoryItemAdd(QBLinxDataService.MdlItems item, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String ItemName = Common.Truncate(item.Name, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemNonInventoryAddRq = doc.CreateElement("ItemNonInventoryAddRq");
        //        parent.AppendChild(ItemNonInventoryAddRq);
        //        XmlElement ItemNonInventoryAdd = doc.CreateElement("ItemNonInventoryAdd");
        //        ItemNonInventoryAddRq.AppendChild(ItemNonInventoryAdd);

        //        ItemNonInventoryAdd.AppendChild(MakeSimpleElemt(doc, "Name", Common.Truncate(ItemName, 41)));

        //        if (!string.IsNullOrEmpty(item.TaxCode))
        //        {
        //            //Create SalesTaxCodeRef aggregate and fill in field values for it
        //            XmlElement SalesTaxCodeRef = doc.CreateElement("SalesTaxCodeRef");
        //            ItemNonInventoryAdd.AppendChild(SalesTaxCodeRef);
        //            //Set field value for FullName <!-- optional -->
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.TaxCode));
        //        }

        //        XmlElement SalesOrPurchase = doc.CreateElement("SalesOrPurchase");
        //        ItemNonInventoryAdd.AppendChild(SalesOrPurchase);

        //        if (!string.IsNullOrEmpty(item.SalesDesc))
        //        {
        //            SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Desc", item.SalesDesc));
        //        }

        //        SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Price", item.SalesPrice.ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(item.IncomeAccountFullName))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            SalesOrPurchase.AppendChild(AccountRef);
        //            AccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.IncomeAccountFullName));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemNonInventoryAddRsList = responseXmlDoc.GetElementsByTagName("ItemNonInventoryAddRs");
        //        if (ItemNonInventoryAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemNonInventoryAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            Accounts objAccount = new Accounts();
        //                            String account = result[1];

        //                            if (objAccount.AddAccount(account, item.BranchID, bgWorker))
        //                                blnResult = NonInventoryItemAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + item.Name + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemNonInventoryRetList = responseNode.SelectNodes("//ItemNonInventoryRet");//XPath Query
        //                    for (int i = 0; i < ItemNonInventoryRetList.Count; i++)
        //                    {
        //                        XmlNode ItemNonInventoryRet = ItemNonInventoryRetList.Item(i);

        //                        String ListID = ItemNonInventoryRet.SelectSingleNode("./ListID").InnerText;
        //                        String Name = ItemNonInventoryRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemNonInventoryRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemNonInventoryRet.SelectSingleNode("./EditSequence").InnerText;

        //                        bgWorker.ReportProgress(0, "'" + Name + "' Item added");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}

        //public Boolean InventoryItemAdd(QBLinxDataService.MdlItems item, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String ItemName = Common.Truncate(item.Name, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemInventoryAddRq = doc.CreateElement("ItemInventoryAddRq");
        //        parent.AppendChild(ItemInventoryAddRq);
        //        XmlElement ItemInventoryAdd = doc.CreateElement("ItemInventoryAdd");
        //        ItemInventoryAddRq.AppendChild(ItemInventoryAdd);

        //        ItemInventoryAdd.AppendChild(MakeSimpleElemt(doc, "Name", Common.Truncate(ItemName, 41)));

        //        if (!string.IsNullOrEmpty(item.TaxCode))
        //        {
        //            //Create SalesTaxCodeRef aggregate and fill in field values for it
        //            XmlElement SalesTaxCodeRef = doc.CreateElement("SalesTaxCodeRef");
        //            ItemInventoryAdd.AppendChild(SalesTaxCodeRef);
        //            //Set field value for FullName <!-- optional -->
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.TaxCode));
        //        }

        //        if (!string.IsNullOrEmpty(item.SalesDesc))
        //        {
        //            ItemInventoryAdd.AppendChild(MakeSimpleElemt(doc, "SalesDesc", item.SalesDesc));
        //        }

        //        ItemInventoryAdd.AppendChild(MakeSimpleElemt(doc, "SalesPrice", item.SalesPrice.ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(item.IncomeAccountFullName))
        //        {
        //            XmlElement IncomeAccountRef = doc.CreateElement("IncomeAccountRef");
        //            ItemInventoryAdd.AppendChild(IncomeAccountRef);
        //            IncomeAccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.IncomeAccountFullName));
        //        }

        //        if (!string.IsNullOrEmpty(item.PurchaseDesc))
        //        {
        //            ItemInventoryAdd.AppendChild(MakeSimpleElemt(doc, "PurchaseDesc", item.PurchaseDesc));
        //        }

        //        ItemInventoryAdd.AppendChild(MakeSimpleElemt(doc, "PurchaseCost", item.PurchaseCost.ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(item.ExpenseAccountFullName))
        //        {
        //            XmlElement COGSAccountRef = doc.CreateElement("COGSAccountRef");
        //            ItemInventoryAdd.AppendChild(COGSAccountRef);
        //            COGSAccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.ExpenseAccountFullName));
        //        }

        //        if (!String.IsNullOrEmpty(item.VendorFullName))
        //        {
        //            XmlElement PrefVendorRef = doc.CreateElement("PrefVendorRef");
        //            ItemInventoryAdd.AppendChild(PrefVendorRef);
        //            PrefVendorRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.VendorFullName));
        //        }

        //        if (!String.IsNullOrEmpty(item.AssetAccountFullName))
        //        {
        //            XmlElement AssetAccountRef = doc.CreateElement("AssetAccountRef");
        //            ItemInventoryAdd.AppendChild(AssetAccountRef);
        //            AssetAccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.AssetAccountFullName));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemInventoryAddRsList = responseXmlDoc.GetElementsByTagName("ItemInventoryAddRs");
        //        if (ItemInventoryAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemInventoryAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            Accounts objAccount = new Accounts();
        //                            String account = result[1];

        //                            if (objAccount.AddAccount(account, item.BranchID, bgWorker))
        //                                blnResult = InventoryItemAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else if (statusMessage.Contains("There is an invalid reference to QuickBooks Vendor"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            String vendor = result[1];

        //                            Vendors objVendor = new Vendors();
        //                            if (objVendor.QBAddVendor(vendor, bgWorker))
        //                                blnResult = InventoryItemAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + item.Name + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemInventoryRetList = responseNode.SelectNodes("//ItemInventoryRet");//XPath Query
        //                    for (int i = 0; i < ItemInventoryRetList.Count; i++)
        //                    {
        //                        XmlNode ItemInventoryRet = ItemInventoryRetList.Item(i);

        //                        String ListID = ItemInventoryRet.SelectSingleNode("./ListID").InnerText;
        //                        String Name = ItemInventoryRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemInventoryRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemInventoryRet.SelectSingleNode("./EditSequence").InnerText;

        //                        bgWorker.ReportProgress(0, "'" + Name + "' Item added");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}

        //public Boolean OtherChargesAdd(QBLinxDataService.MdlItems item, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        //string[] words = item.Name.Trim().Split(':');
        //        //if (words.Count() > 0)
        //        //    pItemName = words[0];

        //        string ItemName = Common.Truncate(item.Name, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemOtherChargeAddRq = doc.CreateElement("ItemOtherChargeAddRq");
        //        parent.AppendChild(ItemOtherChargeAddRq);
        //        XmlElement ItemOtherChargeAdd = doc.CreateElement("ItemOtherChargeAdd");
        //        ItemOtherChargeAddRq.AppendChild(ItemOtherChargeAdd);

        //        ItemOtherChargeAdd.AppendChild(MakeSimpleElemt(doc, "Name", ItemName));
        //        ItemOtherChargeAdd.AppendChild(MakeSimpleElemt(doc, "IsActive", "1"));

        //        if (!string.IsNullOrEmpty(item.TaxCode))
        //        {
        //            //Create SalesTaxCodeRef aggregate and fill in field values for it
        //            XmlElement SalesTaxCodeRef = doc.CreateElement("SalesTaxCodeRef");
        //            ItemOtherChargeAdd.AppendChild(SalesTaxCodeRef);
        //            //Set field value for FullName <!-- optional -->
        //            SalesTaxCodeRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.TaxCode));
        //        }

        //        XmlElement SalesOrPurchase = doc.CreateElement("SalesOrPurchase");
        //        ItemOtherChargeAdd.AppendChild(SalesOrPurchase);


        //        if (!String.IsNullOrEmpty(item.SalesDesc))
        //            SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Desc", item.SalesDesc));

        //        SalesOrPurchase.AppendChild(MakeSimpleElemt(doc, "Price", item.SalesPrice.ToString("###0.00")));

        //        if (!String.IsNullOrEmpty(item.IncomeAccountFullName))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            SalesOrPurchase.AppendChild(AccountRef);

        //            AccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.IncomeAccountFullName));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemOtherChargeAddRsList = responseXmlDoc.GetElementsByTagName("ItemOtherChargeAddRs");
        //        if (ItemOtherChargeAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemOtherChargeAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + ItemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            Accounts objAccount = new Accounts();
        //                            String account = result[1];

        //                            if (objAccount.AddAccount(account, item.BranchID, bgWorker))
        //                                blnResult = OtherChargesAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + item.Name + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemOtherChargeRetList = responseNode.SelectNodes("//ItemOtherChargeRet");//XPath Query
        //                    for (int i = 0; i < ItemOtherChargeRetList.Count; i++)
        //                    {
        //                        XmlNode ItemOtherChargeRet = ItemOtherChargeRetList.Item(i);

        //                        String ListID = ItemOtherChargeRet.SelectSingleNode("./ListID").InnerText;
        //                        String Name = ItemOtherChargeRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemOtherChargeRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemOtherChargeRet.SelectSingleNode("./EditSequence").InnerText;

        //                        bgWorker.ReportProgress(0, "'" + Name + "' Item added");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}

        //public Boolean DiscountItemAdd(QBLinxDataService.MdlItems item, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        //string[] words = pItemName.Trim().Split(':');
        //        //if (words.Count() > 0)
        //        //    pItemName = words[0];

        //        string itemName = Common.Truncate(item.Name, 41);

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");
        //        XmlElement ItemDiscountAddRq = doc.CreateElement("ItemDiscountAddRq");
        //        parent.AppendChild(ItemDiscountAddRq);
        //        XmlElement ItemDiscountAdd = doc.CreateElement("ItemDiscountAdd");
        //        ItemDiscountAddRq.AppendChild(ItemDiscountAdd);

        //        ItemDiscountAdd.AppendChild(MakeSimpleElemt(doc, "Name", itemName));
        //        ItemDiscountAdd.AppendChild(MakeSimpleElemt(doc, "IsActive", "1"));

        //        if (!String.IsNullOrEmpty(item.SalesDesc))
        //            ItemDiscountAdd.AppendChild(MakeSimpleElemt(doc, "ItemDesc", item.SalesDesc));

        //        if (!String.IsNullOrEmpty(item.IncomeAccountFullName))
        //        {
        //            XmlElement AccountRef = doc.CreateElement("AccountRef");
        //            ItemDiscountAdd.AppendChild(AccountRef);

        //            AccountRef.AppendChild(MakeSimpleElemt(doc, "FullName", item.IncomeAccountFullName));
        //        }

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList ItemDiscountAddRsList = responseXmlDoc.GetElementsByTagName("ItemDiscountAddRs");
        //        if (ItemDiscountAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = ItemDiscountAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + itemName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {
        //                    if (statusMessage.Contains("There is an invalid reference to QuickBooks Account"))
        //                    {
        //                        string[] stringSeparators = new string[] { "\"" };
        //                        string[] result = statusMessage.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //                        if (result.Count() > 1)
        //                        {
        //                            Accounts objAccount = new Accounts();
        //                            String account = result[1];

        //                            if (objAccount.AddAccount(account, item.BranchID, bgWorker))
        //                                blnResult = DiscountItemAdd(item, bgWorker);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                        bgWorker.ReportProgress(0, statusMessage);
        //                        return false;
        //                    }
        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    bgWorker.ReportProgress(0, "'" + item.Name + "' name already used in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList ItemDiscountRetList = responseNode.SelectNodes("//ItemDiscountRet");//XPath Query
        //                    for (int i = 0; i < ItemDiscountRetList.Count; i++)
        //                    {
        //                        XmlNode ItemDiscountRet = ItemDiscountRetList.Item(i);

        //                        String ListID = ItemDiscountRet.SelectSingleNode("./ListID").InnerText;
        //                        String Name = ItemDiscountRet.SelectSingleNode("./Name").InnerText;
        //                        DateTime dtmModified = Convert.ToDateTime(ItemDiscountRet.SelectSingleNode("./TimeModified").InnerText);
        //                        string EditSequence = ItemDiscountRet.SelectSingleNode("./EditSequence").InnerText;

        //                        bgWorker.ReportProgress(0, "'" + Name + "' Item added");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Item '" + item.Name + "'");
        //        bgWorker.ReportProgress(0, ex.Message);
        //    }

        //    return blnResult;
        //}     
    }
}
