//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Interop.QBXMLRP2;

//namespace QBSync.QuickBooks
//{
//    public static class QBConnection
//    {
//        private static string m_ticket;
//        private static RequestProcessor2 m_ReqProcess;
//        private static bool connected;

//        public static string Ticket
//        {
//            get { return m_ticket; }
//            set { m_ticket = value; }
//        }

//        public static RequestProcessor2 ReqProcess
//        {
//            get
//            {
//                if (m_ReqProcess == null) m_ReqProcess = new RequestProcessor2();
//                return m_ReqProcess;
//            }
//            set
//            {
//                m_ReqProcess = value;
//            }
//        }
//        public static void StartQBSession(string strFile)
//        {
//            try
//            {
//                if (connected == false)
//                {
//                    ReqProcess.OpenConnection("", Common.ApplicationName);
//                    connected = true;
//                }

//                if (Ticket == null)
//                {
//                    Ticket = m_ReqProcess.BeginSession(strFile, QBFileMode.qbFileOpenDoNotCare);
//                }
//            }
//            catch (System.Runtime.InteropServices.COMException ex)
//            {
//                if (ex.ErrorCode == -2147220472)//-2147220472
//                {
//                    throw new ApplicationException("You must have QuickBooks running with the company" + Environment.NewLine + "file open to use this application.", ex);
//                }
//                else
//                {
//                    throw ex;
//                }
//            }
//        }
//        public static void EndQBSession()
//        {
//            try
//            {
//                if (m_ticket != null)
//                {
//                    m_ReqProcess.EndSession(m_ticket);
//                    m_ticket = null;
//                }

//                if (m_ReqProcess != null)
//                {
//                    m_ReqProcess.CloseConnection();
//                    connected = false;
//                    m_ReqProcess = null;
//                }
//            }
//            catch (System.Runtime.InteropServices.COMException ex)
//            {
//                throw ex;
//            }
//        }
//        public static string ProcessRequest(string Request)
//        {
//            try
//            {
//                string Response = null;
//                Response = m_ReqProcess.ProcessRequest(m_ticket, Request);
//                return Response;
//            }
//            catch (System.Runtime.InteropServices.COMException ex)
//            {
//                throw ex;
//            }
//        }

//    }

//    public class MdlQB
//    {
//        public string ListID { get; set; }

//        public string EditSequence { get; set; }

//        public string FullName { get; set; }

//        public double Balance { get; set; }

//        public string TxnID { get; set; }
//    }
//}
