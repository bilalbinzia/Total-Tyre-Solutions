using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QBSync.QuickBooks;
using QBSync;

namespace QBSync.QuickBooks
{
    public class Vendors
    {
        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void VendorQuery(DateTime FromModifiedDate, DateTime ToModifiedDate, System.ComponentModel.BackgroundWorker bgWorker)
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
                    XmlElement VendorQueryRq = doc.CreateElement("VendorQueryRq");
                    qbXMLMsgsRq.AppendChild(VendorQueryRq);
                    VendorQueryRq.SetAttribute("requestID", "1");

                    if (!String.IsNullOrEmpty(strIterator))
                        VendorQueryRq.SetAttribute("iterator", strIterator);
                    if (!String.IsNullOrEmpty(strIteratorID))
                        VendorQueryRq.SetAttribute("iteratorID", strIteratorID);

                    VendorQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", Common.MaxRecordReturn));

                    VendorQueryRq.AppendChild(MakeSimpleElem(doc, "ActiveStatus", "All"));
                    VendorQueryRq.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", FromModifiedDate.ToString("s")));
                    if (Common.UseQBQueryToDate)
                        VendorQueryRq.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", ToModifiedDate.ToString("s")));
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
                    XmlNodeList VendorQueryRsList = responseXmlDoc.GetElementsByTagName("VendorQueryRs");
                    if (VendorQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                    {
                        XmlNode responseNode = VendorQueryRsList.Item(0);
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
                            XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query

                            Data.dsQBSyncTableAdapters.VendorTableAdapter taVendor = new Data.dsQBSyncTableAdapters.VendorTableAdapter();

                            Data.dsQBSync ds = new Data.dsQBSync();
                            ds.EnforceConstraints = false;
                            ds.Vendor.Clear();

                            for (int i = 0; i < VendorRetList.Count; i++)
                            {
                                XmlNode VendorRet = VendorRetList.Item(i);

                                if (VendorRet == null) continue;

                                String QBListID = VendorRet.SelectSingleNode("./ListID").InnerText;

                                var oVendor = ds.Vendor.NewVendorRow();

                                taVendor.FillByQBListID(ds.Vendor, QBListID);
                                if (ds.Vendor.Count > 0)
                                {
                                    oVendor = ds.Vendor[0];

                                    //taCustomerShipTo.DeleteByCustomerID(oCustomer.CustomerID);
                                }
                                else
                                {
                                    oVendor.ListID = QBListID;
                                    ds.Vendor.AddVendorRow(oVendor);
                                }


                                //oVendor.ID = -1;
                                //oVendor.UtcOffset = Common.LoginUser.UtcOffset;
                                oVendor.ListID = QBListID;
                                //oVendor.BranchID = Common.BranchID;
                                oVendor.RegDate = Convert.ToDateTime(VendorRet.SelectSingleNode("./TimeCreated").InnerText);
                                oVendor.AddDate = Convert.ToDateTime(VendorRet.SelectSingleNode("./TimeCreated").InnerText);
                                oVendor.ModifyDate = Convert.ToDateTime(VendorRet.SelectSingleNode("./TimeModified").InnerText);
                                oVendor.Name = VendorRet.SelectSingleNode("./Name").InnerText;

                                if (VendorRet.SelectSingleNode("./IsActive") != null)
                                {
                                    oVendor.Active = Convert.ToBoolean(VendorRet.SelectSingleNode("./IsActive").InnerText);
                                }
                                //if (VendorRet.SelectSingleNode("./CompanyName") != null)
                                //{
                                //    oVendor.CompanyName = VendorRet.SelectSingleNode("./CompanyName").InnerText;

                                //}
                                //Get value of FirstName
                                if (VendorRet.SelectSingleNode("./FirstName") != null)
                                {
                                    oVendor.Name = VendorRet.SelectSingleNode("./FirstName").InnerText;

                                }
                                //Get value of MiddleName
                                //if (VendorRet.SelectSingleNode("./MiddleName") != null)
                                //{
                                //    oVendor.MiddleName = VendorRet.SelectSingleNode("./MiddleName").InnerText;

                                //}
                                //Get value of LastName
                                if (VendorRet.SelectSingleNode("./LastName") != null)
                                {
                                    oVendor.Name += " " + VendorRet.SelectSingleNode("./LastName").InnerText;

                                }

                                //XmlNode VendorAddress = VendorRet.SelectSingleNode("./VendorAddress");
                                //if (VendorAddress != null)
                                //{
                                //    //Get value of Addr1
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/Addr1") != null)
                                //    {
                                //        oVendor.VendorAdd1 = VendorRet.SelectSingleNode("./VendorAddress/Addr1").InnerText;
                                //    }
                                //    //Get value of Addr2
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/Addr2") != null)
                                //    {
                                //        oVendor.VendorAdd2 = VendorRet.SelectSingleNode("./VendorAddress/Addr2").InnerText;
                                //    }
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/Addr3") != null)
                                //    {
                                //        oVendor.VendorAdd3 = VendorRet.SelectSingleNode("./VendorAddress/Addr3").InnerText;
                                //    }
                                //    //Get value of City
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/City") != null)
                                //    {
                                //        oVendor.VendorCity = VendorRet.SelectSingleNode("./VendorAddress/City").InnerText;
                                //    }
                                //    //Get value of State
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/State") != null)
                                //    {
                                //        oVendor.VendorState = VendorRet.SelectSingleNode("./VendorAddress/State").InnerText;

                                //    }
                                //    //Get value of PostalCode
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/PostalCode") != null)
                                //    {
                                //        oVendor.VendorPostalCode = VendorRet.SelectSingleNode("./VendorAddress/PostalCode").InnerText;

                                //    }
                                //    //Get value of Country
                                //    if (VendorRet.SelectSingleNode("./VendorAddress/Country") != null)
                                //    {
                                //        oVendor.VendorCountry = VendorRet.SelectSingleNode("./VendorAddress/Country").InnerText;
                                //    }
                                //}



                                if (VendorRet.SelectSingleNode("./Phone") != null)
                                {
                                    oVendor.Phone = VendorRet.SelectSingleNode("./Phone").InnerText;
                                }
                                //Get value of Email
                                if (VendorRet.SelectSingleNode("./Email") != null)
                                {
                                    oVendor.Email = VendorRet.SelectSingleNode("./Email").InnerText;
                                }
                                //Get value of Contact
                                //if (VendorRet.SelectSingleNode("./Contact") != null)
                                //{
                                //    oVendor.Contact = VendorRet.SelectSingleNode("./Contact").InnerText;
                                //}

                                //if (VendorRet.SelectSingleNode("./Balance") != null)
                                //{
                                //    oVendor.Balance = Convert.ToDouble(VendorRet.SelectSingleNode("./Balance").InnerText);
                                //}

                                //Get all field values for TermsRef aggregate 
                                //XmlNode TermsRef = VendorRet.SelectSingleNode("./TermsRef");
                                //if (TermsRef != null)
                                //{
                                //    //Get value of FullName
                                //    if (VendorRet.SelectSingleNode("./TermsRef/FullName") != null)
                                //    {
                                //        oVendor.Terms = VendorRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                                //    }
                                //}
                                //Done with field values for TermsRef aggregate

                                //XmlNode CurrencyRef = VendorRet.SelectSingleNode("./CurrencyRef");
                                //if (CurrencyRef != null)
                                //{
                                //    //Get value of FullName
                                //    if (VendorRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                                //    {
                                //        oVendor.Currency = VendorRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                                //    }
                                //}

                                //XmlNode SalesTaxCodeRef = VendorRet.SelectSingleNode("./SalesTaxCodeRef");
                                //if (SalesTaxCodeRef != null)
                                //{                                  
                                //    //Get value of FullName
                                //    if (VendorRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                                //    {
                                //        oVendor.TaxCode = VendorRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                                //    }
                                //}

                                oVendor.AddUserID = -1;
                                oVendor.ModifyUserID = -1;
                                oVendor.IsLocked = true;
                                oVendor.EndEdit();
                                taVendor.Update(oVendor);


                                //service.VendorsAddUpdate(oVendor);

                                bgWorker.ReportProgress(0, oVendor.Name);
                                bgWorker.ReportProgress(0, "Exported to Server");
                                bgWorker.ReportProgress(0, "");
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

                bgWorker.ReportProgress(0, "Error! Vendor Query");
                bgWorker.ReportProgress(0, ex.Message);
            }
        }

        public Boolean QBAddVendor(string VendorFullName, System.ComponentModel.BackgroundWorker bgWorker)
        {
            Boolean blnResult = false;
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

                //Create VendorAddRq aggregate and fill in field values for it
                XmlElement VendorAddRq = doc.CreateElement("VendorAddRq");
                parent.AppendChild(VendorAddRq);
                XmlElement VendorAdd = doc.CreateElement("VendorAdd");
                VendorAddRq.AppendChild(VendorAdd);

                VendorAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(VendorFullName, 41)));

                VendorAdd.AppendChild(MakeSimpleElem(doc, "IsActive", (1).ToString()));

                if (!String.IsNullOrEmpty(VendorFullName))
                    VendorAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(VendorFullName, 41)));

                string strRequest = doc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList VendorAddRsList = responseXmlDoc.GetElementsByTagName("VendorAddRs");
                if (VendorAddRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = VendorAddRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + VendorFullName + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        if (Convert.ToInt32(statusCode) == 3100)
                        {
                            bgWorker.ReportProgress(0, "'" + VendorFullName + "' name already used in QuickBooks");
                        }
                        else if (Convert.ToInt32(statusCode) == 0)
                        {
                            XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
                            for (int i = 0; i < VendorRetList.Count; i++)
                            {
                                XmlNode VendorRet = VendorRetList.Item(i);

                                String QBListID = VendorRet.SelectSingleNode("./ListID").InnerText;

                                bgWorker.ReportProgress(0, "'" + VendorFullName + "' Vendor added");

                                blnResult = true;
                            }
                        }
                        else
                        {
                            bgWorker.ReportProgress(0, "Error! Adding in Vendor '" + VendorFullName + "'");
                            bgWorker.ReportProgress(0, statusMessage);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

                bgWorker.ReportProgress(0, "Error! Adding in Vendor '" + VendorFullName + "'");
                bgWorker.ReportProgress(0, ex.Message);
            }

            return blnResult;
        }

        public void AddVendor(Data.dsQBSync.VendorRow VendorRow, string listId, System.ComponentModel.BackgroundWorker bgWorker)
        {
            string FullName = "";
            Data.dsQBSyncTableAdapters.VendorTableAdapter taVendor = new Data.dsQBSyncTableAdapters.VendorTableAdapter();

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
            XmlElement custAddRq = inputXMLDoc.CreateElement("VendorAddRq");
            qbXMLMsgsRq.AppendChild(custAddRq);
            custAddRq.SetAttribute("requestID", "1");
            XmlElement custAdd = inputXMLDoc.CreateElement("VendorAdd");
            custAddRq.AppendChild(custAdd);
            custAdd.AppendChild(inputXMLDoc.CreateElement("Name")).InnerText = VendorRow.IsNameNull() ? "" : VendorRow.Name;

            if (!VendorRow.IsPhoneNull())
                custAdd.AppendChild(inputXMLDoc.CreateElement("Phone")).InnerText = VendorRow.IsPhoneNull() ? "" : VendorRow.Phone;
            //string companyName = VendorRow.IsCompanyNameNull() ? "" : VendorRow.CompanyName;
            //if (companyName.Length > 0)
            //    custAdd.AppendChild(inputXMLDoc.CreateElement("CompanyName")).InnerText = companyName;

            //if (VendorRow.FirstName.Length > 0)
            //    FullName = VendorRow.FirstName;

            //if (VendorRow.LastName.Length > 0)
            //    FullName += VendorRow.LastName;

            //custAdd.AppendChild(inputXMLDoc.CreateElement("FullName")).InnerText = FullName;

            if (VendorRow.IsEmailNull())
                custAdd.AppendChild(inputXMLDoc.CreateElement("Email")).InnerText = VendorRow.IsEmailNull() ? "" : VendorRow.Email;

            string input = inputXMLDoc.OuterXml;

            bool isEdit = false; string editSequence = "";
            if (!string.IsNullOrEmpty(listId))
            {
                editSequence = GetVendorEditSequence(listId);
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

            XmlNodeList VendorAddRsList = responseXmlDoc.GetElementsByTagName(isEdit ? "VendorModRs" : "VendorAddRs");
            if (VendorAddRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = VendorAddRsList.Item(0);
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
                        if (statusMessage.Contains("There is an invalid reference to QuickBooks Vendor"))
                        {
                            ////bgWorker.ReportProgress(0, "Invalid reference to QuickBooks Vendor");
                            //Vendors objVendor = new Vendors();
                            //if (objVendor.QBAddCusomter(orderRow, bgWorker))
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
                            bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Vendor");
                            bgWorker.ReportProgress(0, statusMessage);
                            return;
                        }
                    }
                    else if (statusCode == "0")
                    {
                        XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
                        for (int i = 0; i < VendorRetList.Count; i++)
                        {
                            XmlNode SalesOrderRet = VendorRetList.Item(i);
                            string newTxnId = SalesOrderRet.SelectSingleNode("./ListID").InnerText;

                            var TimeCreated = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeCreated").InnerText);
                            //Get value of TimeModified
                            var TimeModified = Convert.ToDateTime(SalesOrderRet.SelectSingleNode("./TimeModified").InnerText);


                            //string NewRefNumber = "";
                            //if (SalesOrderRet.SelectSingleNode("./RefNumber") != null)
                            //{
                            //    NewRefNumber = SalesOrderRet.SelectSingleNode("./RefNumber").InnerText;
                            //}

                            string VendorListID = "";
                            if (SalesOrderRet.SelectSingleNode("./VendorRef/ListID") != null)
                            {
                                VendorListID = SalesOrderRet.SelectSingleNode("./VendorRef/ListID").InnerText;
                            }

                            //Vendors objVendor = new Vendors();
                            //var mdlVendor = objVendor.GetVendorBalance(VendorListID);

                            string sysNotes = VendorRow.IsNotesNull() ? ("Exported to QuickBooks " + DateTime.Now) : (VendorRow.Notes + System.Environment.NewLine + "Exported to QuickBooks " + DateTime.Now);

                            taVendor.UpdateQBFields(newTxnId, TimeModified, sysNotes, VendorRow.ID);

                            bgWorker.ReportProgress(0, "Vendor " + (isEdit ? "updated" : "added") + " successfully");
                            //blnResult = true;
                        }
                    }
                    else
                    {
                        bgWorker.ReportProgress(0, "Error! " + (isEdit ? "Updating" : "Adding") + " in Vendor");
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
            //    rp.OpenConnection("", "IDN VendorAdd C# sample");
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
            //XmlNodeList qbXMLMsgsRsNodeList = outputXMLDoc.GetElementsByTagName("VendorAddRs");

            //if (qbXMLMsgsRsNodeList.Count == 1) //it's always true, since we added a single Vendor
            //{
            //    System.Text.StringBuilder popupMessage = new System.Text.StringBuilder();

            //    XmlAttributeCollection rsAttributes = qbXMLMsgsRsNodeList.Item(0).Attributes;
            //    //get the status Code, info and Severity
            //    string retStatusCode = rsAttributes.GetNamedItem("statusCode").Value;
            //    string retStatusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
            //    string retStatusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
            //    popupMessage.AppendFormat("statusCode = {0}, statusSeverity = {1}, statusMessage = {2}",
            //        retStatusCode, retStatusSeverity, retStatusMessage);

            //    //get the VendorRet node for detailed info

            //    //a VendorAddRs contains max one childNode for "VendorRet"
            //    XmlNodeList custAddRsNodeList = qbXMLMsgsRsNodeList.Item(0).ChildNodes;
            //    if (custAddRsNodeList.Count == 1 && custAddRsNodeList.Item(0).Name.Equals("VendorRet"))
            //    {
            //        XmlNodeList custRetNodeList = custAddRsNodeList.Item(0).ChildNodes;

            //        foreach (XmlNode custRetNode in custRetNodeList)
            //        {
            //            if (custRetNode.Name.Equals("ListID"))
            //            {
            //                popupMessage.AppendFormat("\r\nVendor ListID = {0}", custRetNode.InnerText);
            //            }
            //            else if (custRetNode.Name.Equals("Name"))
            //            {
            //                popupMessage.AppendFormat("\r\nVendor Name = {0}", custRetNode.InnerText);
            //            }
            //            else if (custRetNode.Name.Equals("FullName"))
            //            {
            //                popupMessage.AppendFormat("\r\nVendor FullName = {0}", custRetNode.InnerText);
            //            }
            //        }
            //    } // End of VendorRet

            //    //MessageBox.Show(popupMessage.ToString(), "QuickBooks response");
            //    bgWorker.ReportProgress(0, "Error! Adding/Updating in Vendor");
            //    bgWorker.ReportProgress(0, popupMessage.ToString());
            //    //Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");
            //    return;
            //End of VendorAddRs}
            //}
        }

        public String GetVendorEditSequence(String ListID)
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
                XmlElement VendorQueryRq = inputXMLDoc.CreateElement("VendorQueryRq");
                qbXMLMsgsRq.AppendChild(VendorQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList VendorQueryRsList = responseXmlDoc.GetElementsByTagName("VendorQueryRs");
                if (VendorQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = VendorQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
                        for (int i = 0; i < VendorRetList.Count; i++)
                        {
                            XmlNode VendorRet = VendorRetList.Item(i);
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

        public MdlQB GetVendorBalance(String ListID)
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

                //Create VendorModRq  aggregate and fill in field values for it
                XmlElement VendorQueryRq = inputXMLDoc.CreateElement("VendorQueryRq");
                qbXMLMsgsRq.AppendChild(VendorQueryRq);
                //custRq.SetAttribute("requestID", "1");

                //Set field value for FullName <!-- optional, may repeat -->              
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Name"));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));
                VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "Balance"));
                //VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "TotalBalance"));

                string strRequest = inputXMLDoc.OuterXml;
                string strResponse = QBConnection.ProcessRequest(strRequest);

                //Parse the response XML string into an XmlDocument
                XmlDocument responseXmlDoc = new XmlDocument();
                responseXmlDoc.LoadXml(strResponse);

                //Get the response for our request
                XmlNodeList VendorQueryRsList = responseXmlDoc.GetElementsByTagName("VendorQueryRs");
                if (VendorQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
                {
                    XmlNode responseNode = VendorQueryRsList.Item(0);
                    //Check the status code, info, and severity
                    XmlAttributeCollection rsAttributes = responseNode.Attributes;
                    string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                    string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                    string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
                    Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
                    //status code = 0 all OK, > 0 is warning
                    if (Convert.ToInt32(statusCode) >= 0)
                    {
                        XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
                        for (int i = 0; i < VendorRetList.Count; i++)
                        {
                            strResult = new MdlQB();

                            XmlNode VendorRet = VendorRetList.Item(i);
                            strResult.ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
                            //Get value of EditSequence
                            strResult.EditSequence = VendorRet.SelectSingleNode("./EditSequence").InnerText;
                            strResult.FullName = VendorRet.SelectSingleNode("./Name").InnerText;

                            //Get value of Balance
                            if (VendorRet.SelectSingleNode("./Balance") != null)
                            {
                                strResult.Balance = Convert.ToDouble(VendorRet.SelectSingleNode("./Balance").InnerText);
                            }

                            //Get value of TotalBalance
                            //if (VendorRet.SelectSingleNode("./TotalBalance") != null)
                            //{
                            //    string TotalBalance = VendorRet.SelectSingleNode("./TotalBalance").InnerText;
                            //}

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

        //public Boolean QBAddCusomter(Data.dsQBSync.VendorRow pVendor, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String VendorFullName = pVendor.IsAccountNameNull() ? "" : pVendor.AccountName;
        //        VendorFullName = Common.Truncate(VendorFullName.Trim(), 41);

        //        if (string.IsNullOrEmpty(VendorFullName)) return false;

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");

        //        //Create VendorAddRq aggregate and fill in field values for it
        //        XmlElement VendorAddRq = doc.CreateElement("VendorAddRq");
        //        parent.AppendChild(VendorAddRq);
        //        XmlElement VendorAdd = doc.CreateElement("VendorAdd");
        //        VendorAddRq.AppendChild(VendorAdd);

        //        VendorAdd.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(VendorFullName, 41)));

        //        VendorAdd.AppendChild(MakeSimpleElem(doc, "IsActive", ((pVendor.IsIsDeletedNull() ? false : pVendor.IsDeleted) == true ? 0 : 1).ToString()));

        //        VendorAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(VendorFullName, 41)));

        //        //if (!String.IsNullOrEmpty(pVendor.company_name))
        //        //    VendorAdd.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(pVendor.company_name, 41)));

        //        //if (!String.IsNullOrEmpty(pVendor.first_name))
        //        //    VendorAdd.AppendChild(MakeSimpleElem(doc, "FirstName", Common.Truncate(pVendor.first_name, 25)));

        //        //if (!String.IsNullOrEmpty(pVendor.last_name))
        //        //    VendorAdd.AppendChild(MakeSimpleElem(doc, "LastName", Common.Truncate(pVendor.last_name, 25)));

        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        VendorAdd.AppendChild(BillAddress);

        //        if (!String.IsNullOrEmpty(pVendor.IsBillAdd1Null() ? "" : pVendor.BillAdd1))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(pVendor.BillAdd1, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillAdd2Null() ? "" : pVendor.BillAdd2))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(pVendor.BillAdd2, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillAdd3Null() ? "" : pVendor.BillAdd3))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pVendor.BillAdd3, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillAdd4Null() ? "" : pVendor.BillAdd4))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pVendor.BillAdd4, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillCityNull() ? "" : pVendor.BillCity))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pVendor.BillCity, 31)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillStateNull() ? "" : pVendor.BillState))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pVendor.BillState, 21)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillPostalCodeNull() ? "" : pVendor.BillPostalCode))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pVendor.BillPostalCode, 13)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsBillCountryNull() ? "" : pVendor.BillCountry))
        //        {
        //            BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pVendor.BillCountry, 21)));
        //        }

        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        VendorAdd.AppendChild(ShipAddress);

        //        if (!String.IsNullOrEmpty(pVendor.IsShipAdd1Null() ? "" : pVendor.ShipAdd1))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate(pVendor.ShipAdd1, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipAdd2Null() ? "" : pVendor.ShipAdd2))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate(pVendor.ShipAdd2, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipAdd3Null() ? "" : pVendor.ShipAdd3))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pVendor.ShipAdd3, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipAdd4Null() ? "" : pVendor.ShipAdd4))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pVendor.ShipAdd4, 40)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipCityNull() ? "" : pVendor.ShipCity))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pVendor.ShipCity, 31)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipStateNull() ? "" : pVendor.ShipState))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pVendor.ShipState, 21)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipPostalCodeNull() ? "" : pVendor.ShipPostalCode))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pVendor.ShipPostalCode, 13)));
        //        }
        //        if (!String.IsNullOrEmpty(pVendor.IsShipCountryNull() ? "" : pVendor.ShipCountry))
        //        {
        //            ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pVendor.ShipCountry, 21)));
        //        }

        //        if (!String.IsNullOrEmpty(pVendor.IsPhoneNull() ? "" : pVendor.Phone))
        //            VendorAdd.AppendChild(MakeSimpleElem(doc, "Phone", Common.Truncate(pVendor.Phone, 21)));

        //        if (!String.IsNullOrEmpty(pVendor.IsAltPhoneNull() ? "" : pVendor.AltPhone))
        //            VendorAdd.AppendChild(MakeSimpleElem(doc, "AltPhone", Common.Truncate(pVendor.AltPhone, 21)));

        //        if (!String.IsNullOrEmpty(pVendor.IsFaxNull() ? "" : pVendor.Fax))
        //            VendorAdd.AppendChild(MakeSimpleElem(doc, "Fax", Common.Truncate(pVendor.Fax, 21)));

        //        if (!String.IsNullOrEmpty(pVendor.IsEmailNull() ? "" : pVendor.Email))
        //            VendorAdd.AppendChild(MakeSimpleElem(doc, "Email", Common.Truncate(pVendor.Email, 1023)));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList VendorAddRsList = responseXmlDoc.GetElementsByTagName("VendorAddRs");
        //        if (VendorAddRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = VendorAddRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + VendorFullName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {

        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    //var custExist = GetVendorListID(VendorFullName);
        //                    //if (custExist != null)
        //                    //{
        //                    //    pVendor.QBListId = custExist.ListID;
        //                    //    blnResult = QBModCusomter(pVendor, custExist.EditSequence, bgWorker);
        //                    //}

        //                    bgWorker.ReportProgress(0, "Already exist in QuickBooks");
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
        //                    for (int i = 0; i < VendorRetList.Count; i++)
        //                    {
        //                        XmlNode VendorRet = VendorRetList.Item(i);

        //                        String QBListID = VendorRet.SelectSingleNode("./ListID").InnerText;

        //                        Data.dsQBSyncTableAdapters.VendorTableAdapter taVendor = new Data.dsQBSyncTableAdapters.VendorTableAdapter();
        //                        taVendor.UpdateQBStatus(QBListID, true, pVendor.ID);

        //                        bgWorker.ReportProgress(0, "Successfully added in QuickBooks");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Adding in Vendor");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Adding in Vendor");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        //throw ex;
        //    }

        //    return blnResult;
        //}

        //public Boolean QBModCusomter(Data.dsQBSync.VendorRow pVendor, string QBEditSequence, System.ComponentModel.BackgroundWorker bgWorker)
        //{
        //    Boolean blnResult = false;
        //    try
        //    {
        //        String VendorFullName = pVendor.IsAccountNameNull() ? "" : pVendor.AccountName;
        //        VendorFullName = Common.Truncate(VendorFullName.Trim(), 41);

        //        if (string.IsNullOrEmpty(VendorFullName)) return false;

        //        XmlDocument doc = new XmlDocument();
        //        doc.AppendChild(doc.CreateXmlDeclaration("1.0", Common.XMLEncoding, null));
        //        doc.AppendChild(doc.CreateProcessingInstruction("qbxml", "version=\"" + Common.QuickBookVersion + "\""));
        //        XmlElement qbXML = doc.CreateElement("QBXML");
        //        doc.AppendChild(qbXML);
        //        XmlElement parent = doc.CreateElement("QBXMLMsgsRq");
        //        qbXML.AppendChild(parent);
        //        parent.SetAttribute("onError", "stopOnError");

        //        //Create VendorAddRq aggregate and fill in field values for it
        //        XmlElement VendorModRq = doc.CreateElement("VendorModRq");
        //        parent.AppendChild(VendorModRq);
        //        XmlElement VendorMod = doc.CreateElement("VendorMod");
        //        VendorModRq.AppendChild(VendorMod);

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "ListID", pVendor.QBListId));
        //        //Set field value for EditSequence <!-- required -->
        //        VendorMod.AppendChild(MakeSimpleElem(doc, "EditSequence", QBEditSequence));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "Name", Common.Truncate(VendorFullName, 41)));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "IsActive", ((pVendor.IsIsDeletedNull() ? false : pVendor.IsDeleted) == true ? 0 : 1).ToString()));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "CompanyName", Common.Truncate(VendorFullName, 41)));

        //        //if (!String.IsNullOrEmpty(pVendor.first_name))
        //        //    VendorAdd.AppendChild(MakeSimpleElem(doc, "FirstName", Common.Truncate(pVendor.first_name, 25)));

        //        //if (!String.IsNullOrEmpty(pVendor.last_name))
        //        //    VendorAdd.AppendChild(MakeSimpleElem(doc, "LastName", Common.Truncate(pVendor.last_name, 25)));

        //        XmlElement BillAddress = doc.CreateElement("BillAddress");
        //        VendorMod.AppendChild(BillAddress);

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate((pVendor.IsBillAdd1Null() ? "" : pVendor.BillAdd1), 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate((pVendor.IsBillAdd2Null() ? "" : pVendor.BillAdd2), 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pVendor.IsBillAdd3Null() ? "" : pVendor.BillAdd3, 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pVendor.IsBillAdd4Null() ? "" : pVendor.BillAdd4, 41)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pVendor.IsBillCityNull() ? "" : pVendor.BillCity, 31)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pVendor.IsBillStateNull() ? "" : pVendor.BillState, 21)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pVendor.IsBillPostalCodeNull() ? "" : pVendor.BillPostalCode, 13)));

        //        BillAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pVendor.IsBillCountryNull() ? "" : pVendor.BillCountry, 21)));

        //        XmlElement ShipAddress = doc.CreateElement("ShipAddress");
        //        VendorMod.AppendChild(ShipAddress);

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr1", Common.Truncate((pVendor.IsShipAdd1Null() ? "" : pVendor.ShipAdd1), 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr2", Common.Truncate((pVendor.IsShipAdd2Null() ? "" : pVendor.ShipAdd2), 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr3", Common.Truncate(pVendor.IsShipAdd3Null() ? "" : pVendor.ShipAdd3, 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Addr4", Common.Truncate(pVendor.IsShipAdd4Null() ? "" : pVendor.ShipAdd4, 41)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "City", Common.Truncate(pVendor.IsShipCityNull() ? "" : pVendor.ShipCity, 31)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "State", Common.Truncate(pVendor.IsShipStateNull() ? "" : pVendor.ShipState, 21)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "PostalCode", Common.Truncate(pVendor.IsShipPostalCodeNull() ? "" : pVendor.ShipPostalCode, 13)));

        //        ShipAddress.AppendChild(MakeSimpleElem(doc, "Country", Common.Truncate(pVendor.IsShipCountryNull() ? "" : pVendor.ShipCountry, 21)));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "Phone", Common.Truncate(pVendor.IsPhoneNull() ? "" : pVendor.Phone, 21)));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "AltPhone", Common.Truncate(pVendor.IsAltPhoneNull() ? "" : pVendor.AltPhone, 21)));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "Fax", Common.Truncate(pVendor.IsFaxNull() ? "" : pVendor.Fax, 21)));

        //        VendorMod.AppendChild(MakeSimpleElem(doc, "Email", Common.Truncate(pVendor.IsEmailNull() ? "" : pVendor.Email, 1023)));

        //        string strRequest = doc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList VendorModRsList = responseXmlDoc.GetElementsByTagName("VendorModRs");
        //        if (VendorModRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = VendorModRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + VendorFullName + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                if (statusCode == "3140")
        //                {

        //                }
        //                else if (Convert.ToInt32(statusCode) == 3100)
        //                {
        //                    var custExist = GetVendorListID(VendorFullName);
        //                    //if (custExist != null)
        //                    //{
        //                    //    if (pVendor.contact_id > 0)
        //                    //    {
        //                    //        MohidCustom mohid_webservice = new MohidCustom();
        //                    //        mohid_webservice.UpdateDonorQBListID(Common.Settings.MasjidKey, pVendor.contact_id, custExist.ListID);
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        MohidCustom mohid_webservice = new MohidCustom();
        //                    //        mohid_webservice.UpdateVendorQBListID(Common.Settings.MasjidKey, pVendor.fin_Vendor_id, custExist.ListID);
        //                    //    }

        //                    //    pVendor.qb_list_id = custExist.ListID;
        //                    //    QBModCusomter(pVendor, custExist.EditSequence);
        //                    //}                           
        //                }
        //                else if (Convert.ToInt32(statusCode) == 0)
        //                {
        //                    XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
        //                    for (int i = 0; i < VendorRetList.Count; i++)
        //                    {
        //                        XmlNode VendorRet = VendorRetList.Item(i);

        //                        String QBListID = VendorRet.SelectSingleNode("./ListID").InnerText;

        //                        Data.dsQBSyncTableAdapters.VendorTableAdapter taVendor = new Data.dsQBSyncTableAdapters.VendorTableAdapter();
        //                        taVendor.UpdateQBStatus(QBListID, true, pVendor.ID);

        //                        bgWorker.ReportProgress(0, "Successfully updated in QuickBooks");

        //                        blnResult = true;
        //                    }
        //                }
        //                else
        //                {
        //                    bgWorker.ReportProgress(0, "Error! Updating in Vendor");
        //                    bgWorker.ReportProgress(0, statusMessage);
        //                }
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ApplicationLog(ex.Message, ex.StackTrace, "System Error");

        //        bgWorker.ReportProgress(0, "Error! Updating in Vendor");
        //        bgWorker.ReportProgress(0, ex.Message);
        //        //throw ex;
        //    }

        //    return blnResult;
        //}

        //public String GetVendorEditSequence(String ListID)
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

        //        //Create VendorModRq  aggregate and fill in field values for it
        //        XmlElement VendorQueryRq = inputXMLDoc.CreateElement("VendorQueryRq");
        //        qbXMLMsgsRq.AppendChild(VendorQueryRq);
        //        //custRq.SetAttribute("requestID", "1");

        //        //Set field value for FullName <!-- optional, may repeat -->              
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "ListID", ListID));
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

        //        string strRequest = inputXMLDoc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList VendorQueryRsList = responseXmlDoc.GetElementsByTagName("VendorQueryRs");
        //        if (VendorQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = VendorQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            //Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
        //                for (int i = 0; i < VendorRetList.Count; i++)
        //                {
        //                    XmlNode VendorRet = VendorRetList.Item(i);
        //                    //string ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
        //                    //Get value of EditSequence
        //                    strResult = VendorRet.SelectSingleNode("./EditSequence").InnerText;

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

        //public MdlQB GetVendorListID(String FullName)
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

        //        //Create VendorModRq  aggregate and fill in field values for it
        //        XmlElement VendorQueryRq = inputXMLDoc.CreateElement("VendorQueryRq");
        //        qbXMLMsgsRq.AppendChild(VendorQueryRq);
        //        //custRq.SetAttribute("requestID", "1");

        //        //Set field value for FullName <!-- optional, may repeat -->              
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "FullName", FullName));
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "ListID"));
        //        VendorQueryRq.AppendChild(MakeSimpleElem(inputXMLDoc, "IncludeRetElement", "EditSequence"));

        //        string strRequest = inputXMLDoc.OuterXml;
        //        string strResponse = QBConnection.ProcessRequest(strRequest);

        //        //Parse the response XML string into an XmlDocument
        //        XmlDocument responseXmlDoc = new XmlDocument();
        //        responseXmlDoc.LoadXml(strResponse);

        //        //Get the response for our request
        //        XmlNodeList VendorQueryRsList = responseXmlDoc.GetElementsByTagName("VendorQueryRs");
        //        if (VendorQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
        //        {
        //            XmlNode responseNode = VendorQueryRsList.Item(0);
        //            //Check the status code, info, and severity
        //            XmlAttributeCollection rsAttributes = responseNode.Attributes;
        //            string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
        //            string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
        //            string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;
        //            Common.ApplicationLog(responseNode.Name + " - " + statusCode, statusMessage, statusSeverity);
        //            //status code = 0 all OK, > 0 is warning
        //            if (Convert.ToInt32(statusCode) >= 0)
        //            {
        //                XmlNodeList VendorRetList = responseNode.SelectNodes("//VendorRet");//XPath Query
        //                for (int i = 0; i < VendorRetList.Count; i++)
        //                {
        //                    strResult = new MdlQB();

        //                    XmlNode VendorRet = VendorRetList.Item(i);
        //                    strResult.ListID = VendorRet.SelectSingleNode("./ListID").InnerText;
        //                    //Get value of EditSequence
        //                    strResult.EditSequence = VendorRet.SelectSingleNode("./EditSequence").InnerText;

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

    }

}
