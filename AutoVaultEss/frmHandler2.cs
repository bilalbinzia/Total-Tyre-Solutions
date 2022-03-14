
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using System.Drawing;
using System.Reflection;

using System32;
using DBModule;
using System.Data;
using AppControls;
using RptModule;

namespace AutoVaultEss
{
    public partial class FrmMain2 : Form, iFrmMain
    {
        public static Dictionary<string, bool> dicForm = new Dictionary<string, bool>();
        public static Dictionary<string, bool> dicButton = new Dictionary<string, bool>();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        MainDataSet objDataSet = null;
        DataTable dt;
        public int byID { get; set; }
        //Int32 _mAccID;
        //DateTime _mDate;                
        private void LoadMenu()
        {
            try
            {
                dicForm = new Dictionary<string, bool>();
                dicButton = new Dictionary<string, bool>();
                objDataSet = new MainDataSet();
                dt = dbClass.obj.Fill(objDataSet.FormWiseRights);

                this.MainMenuStrip.Items.Clear();
                foreach (Menu menu in MenuConfig.mList)
                {
                    TSMenuItem TSItem = new TSMenuItem(menu);
                    TSItem.Name = menu.MName;
                    TSItem.Text = menu.MHeading;
                    TSItem.ForeColor = System.Drawing.Color.White;
                    try
                    {
                        if (!string.IsNullOrEmpty(menu.MPicName))
                        {
                            string imageName = menu.MPicName;
                            object O = global::AutoVaultEss.Properties.Resources.ResourceManager.GetObject(imageName);
                            TSItem.Image = (Image)O;
                        }
                        else { TSItem.Image = null; }
                    }
                    catch { TSItem.Image = null; }

                    this.MainMenuStrip.Items.Add(TSItem);
                    List<MenuItem> xMenuItem = MenuConfig.miList.Where(x => x.MCode == menu.MCode).ToList();
                    this.LoadMenuItem(xMenuItem, TSItem);
                }

            }
            catch { }
        }
        //private void LoadLeftButtons()
        //{
        //    this.RecentPanel.Controls.Clear();
        //    foreach (LeftToolButton LtbButton in MenuConfig.LtbList)
        //    {
        //        LeftButton leftButton = new LeftButton(LtbButton);
        //        leftButton.Size = new System.Drawing.Size(66, 40);
        //        leftButton.Name = LtbButton.MMenuName;
        //        leftButton.Text = LtbButton.MMenuHeading;
        //        if (LtbButton.MObjectName.Length > 0)
        //            leftButton.Click += LButtonMenuItem_Clicked;
        //        this.RecentPanel.Controls.Add(leftButton);
        //    }
        //    //---------------------------------------
        //    //LoadLeftButtons();
        //}
        //void LoadLeftButtons()
        //{
        //    System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
        //    toolTip1.IsBalloon = true;
        //    TAButton btnRecent = new TAButton();
        //    btnRecent.BackColor = this.BackColor;
        //    btnRecent.ForeColor = System.Drawing.Color.White;
        //    btnRecent.Name = "btnClear";
        //    btnRecent.Tag = "btnClear";
        //    btnRecent.Size = new System.Drawing.Size(66, 40);
        //    btnRecent.Text = "Clear History";
        //    toolTip1.SetToolTip(btnRecent, "Clear History");
        //    btnRecent.Click += new System.EventHandler(btnClearHistory_Click);
        //    this.RecentPanel.Controls.Add(btnRecent);
        //}
        //private void btnClearHistory_Click(object sender, EventArgs e)
        //{
        //    List<Button> buttons = new List<Button>();
        //    foreach (Control ctr in this.RecentPanel.Controls)
        //    {
        //        Button btn = ctr as Button;
        //        if (btn != null)
        //            buttons.Add(btn);
        //    }
        //    foreach (Control ctr in buttons)
        //    {
        //        if (((Button)ctr).Name != "btnClear")
        //        { this.RecentPanel.Controls.Remove(ctr); ctr.Dispose(); dicButton.Remove(((Button)ctr).Tag.ToString()); }
        //    }
        //}
        private void LoadMenuItem(List<MenuItem> xMenuItem, TSMenuItem tm)
        {
            try
            {
                if (tm.DropDownItems.Count <= 0)
                {
                    foreach (MenuItem xitem in xMenuItem)
                    {
                        if (xitem.MType.ToUpper() == "S")
                        {                            
                            ToolStripSeparator ts = new ToolStripSeparator();
                            tm.DropDownItems.Add(ts);
                        }
                        else if ((xitem.MType.ToUpper() == "M") || (xitem.MType.ToUpper() == "M1") || (xitem.MType.ToUpper() == "V") || (xitem.MType.ToUpper() == "C") || (xitem.MType.ToUpper() == "BU") || (xitem.MType.ToUpper() == "RT") || (xitem.MType.ToUpper() == "L") || (xitem.MType.ToUpper() == "X") || (xitem.MType.ToUpper() == "R") || (xitem.MType.ToUpper() == "DB"))
                        {
                            TSMenuItem ts = new TSMenuItem(xitem);
                            ts.Text = xitem.MMenuHeading;
                            try
                            {
                                if (!string.IsNullOrEmpty(xitem.MPicName))
                                {
                                    string imageName = xitem.MPicName;
                                    object O = global::AutoVaultEss.Properties.Resources.ResourceManager.GetObject(imageName);
                                    ts.Image = (Image)O;
                                }
                                else { ts.Image = null; }
                            }
                            catch { ts.Image = null; }
                            tm.DropDownItems.Add(ts);
                            if (xitem.MObjectName.Length > 0) ts.Click += TSMenuItem_Clicked;
                            if (xitem.MType.ToUpper() == "L") ts.Click += TSLMenuItem_Clicked;
                            if (xitem.MType.ToUpper() == "X") ts.Click += TSXMenuItem_Clicked;

                            List<MenuItem> xMenuItem1 = MenuConfig.miList.Where(x => x.MCode == ts.XCode).ToList();
                            if (xMenuItem1.Count > 0)
                                this.LoadMenuItem(xMenuItem1, ts);
                        }
                    }
                }
            }
            catch { }
        }
        private void TSMenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                TSMenuItem tm = (TSMenuItem)sender;
                MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.XCode == tm.XCode);
                if (menuItem.MTableName.Equals("Receivables") || menuItem.MTableName.Equals("Payables"))
                    menuItem.MTableName = "";
                showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message.ToString());
            }
        }
        private void TSLMenuItem_Clicked(object sender, EventArgs e)
        {
            //xMessageBox.Show("TSLMenuItem_Clicked");
            this.Dispose();
            FrmLogin frmlogin = new FrmLogin();
            BaseControl.LogOff();
            frmlogin.Show();
            this.Cursor = Cursors.Default;
            return;
        }
        private void TSXMenuItem_Clicked(object sender, EventArgs e)
        {
            this.FrmMain_FormClosing(null, null);
            this.Cursor = Cursors.Default; return;
        }
        private void LButtonMenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                LeftButton LTB = (LeftButton)sender;
                MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.XCode == LTB.XCode);
                showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
            }
            catch (Exception ex)
            {
                xMessageBox.Show(ex.Message.ToString());
            }
        }
        //private void LButtonMenuItem_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LTButtonItem LTB = (LTButtonItem)sender;
        //        MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.XCode == LTB.XCode);
        //        showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
        //    }
        //    catch (Exception ex)
        //    {
        //        xMessageBox.Show(ex.Message.ToString());
        //    }
        //}
        private void showControl(string objAssemblyName, string objTypeName, string ctrName, string xCode, string mType, string mTableName, int byID = 0, int qid = 0)
        {
            try
            {
                this.byID = byID;
                var ctr = (Control)null;
                Cursor.Current = Cursors.WaitCursor;
                if (!dicForm.ContainsKey(xCode.ToString()))
                {

                    if (mType == "R") ctr = new frmRpt(objTypeName, mTableName, byID);
                    //else if (mType == "C") ctr = new ctrCodeFiles(mTableName);
                    ////else if (mType == "V") ctr = new AppControls.ctrVoucher(mTableName);
                    //else if (mType == "M1") { ctr = new AppControls.ctrCategory(mTableName); }
                    //else 
                    else if (mType == "M")
                    {
                        if ((mTableName == "CPV") || (mTableName == "CRV"))
                            ctr = new AppControls.ctrCashVoucher(mTableName);
                        else if ((mTableName == "BPV") || (mTableName == "BRV"))
                            ctr = new AppControls.ctrBankVoucher(mTableName);
                        else if (byID < 0 || qid > 0)
                        {
                            switch (objTypeName)
                            {
                                case "AppControls.ctrWorkOrder":
                                    if (ctrName.Equals("New Customer and New Work-Order"))
                                        ctr = new ctrWorkOrder(1);
                                    if (ctrName.Equals("New Customer and New Quote"))
                                        ctr = new ctrWorkOrder(2);
                                    if (ctrName.Equals("New WorkOrder for Selected Customer"))
                                        ctr = new ctrWorkOrder(3, qid);
                                    if (ctrName.Equals("New Quote for Selected Customer"))
                                        ctr = new ctrWorkOrder(4, qid);
                                    if (ctrName.Equals("WorkOrder"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    if (ctrName.Equals("WorkOrderOpen"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    break;

                                case "AppControls.ctrWorkOrderNegate":
                                    if (ctrName.Equals("WorkOrderNegateOpen"))
                                        ctr = new ctrWorkOrderNegate(byID);
                                    if (ctrName.Equals("WorkOrderNegate"))
                                        ctr = new ctrWorkOrderNegate(-1, byID, qid);
                                    break;
                                case "AppControls.ctrWorkOrderDetails":
                                    ctr = new AppControls.ctrWorkOrderDetails(byID);
                                    break;
                                case "AppControls.ctrItemDefination":
                                    ctr = new AppControls.ctrItemDefination(byID);
                                    break;
                                case "AppControls.ctrPackages":
                                    ctr = new AppControls.ctrPackages(byID);
                                    break;
                                case "AppControls.ctrPackage":
                                    ctr = new AppControls.ctrPackage(byID);
                                    break;
                                case "AppControls.ctrItemGroupItems":
                                    ctr = new AppControls.ctrItemGroupItems(byID);
                                    break;

                                case "AppControls.ctrCustomerReceipt":
                                    ctr = new ctrCustomerReceipt(byID, qid);
                                    break;

                                case "AppControls.ctrCustomerPayment":
                                    ctr = new ctrCustomerPayment(byID, qid);
                                    break;
                                case "AppControls.ctrWarrantyClaimAndCoresList":
                                    ctr = new ctrWarrantyClaimAndCoresList(qid);
                                    break;
                                //case "AppControls.ctrPurchaseOrder":
                                //    ctr = new AppControls.ctrPurchaseOrder(byID);
                                //    break;                                
                                //case "AppControls.ctrGoodsReceiptNote":
                                //    ctr = new AppControls.ctrGoodsReceiptNote(byID);
                                //    break;
                                //case "AppControls.ctrPurchaseReturn":
                                //    ctr = new AppControls.ctrPurchaseReturn(byID);
                                //    break;                                
                                //case "AppControls.ctrSaleReturn":
                                //ctr = new AppControls.ctrSaleReturn(byID);
                                //break;

                                default:
                                    break;
                            }
                        }
                        else
                            ctr = (Control)Activator.CreateInstance(Assembly.Load(objAssemblyName).GetType(objTypeName));
                    }


                    AppControls.frmCtr ctrForm = new AppControls.frmCtr(ctrName);
                    ctrForm.frmPnl.Controls.Add(ctr);
                    ctrForm.MdiParent = this;
                    //ctrForm.lblFormTitle.Text = ctrName;
                    ctrForm.Height = ctr.Height + 34;
                    ctrForm.Width = ctr.Width + 20;
                    //ctrForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    //this.MaximizeBox = true;
                    //this.MinimizeBox = true;                   
                    //if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "ctrWorkOrder") || (ctr.Name == "frmRpt"))
                    if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "frmRpt") || (ctr.Name == "ctrWorkOrder"))
                    {
                        ctrForm.Height = this.Height - 120;
                        ctrForm.Width = this.Width - 250;
                    }
                    if ((ctr.Name == "ctrCustomer") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        ctrForm.Height = this.Height - 120;
                    }
                    if ((ctr.Name == "ctrCompany") || (ctr.Name == "ctrWarehouse") || (ctr.Name == "ctrWarehouseStore") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrCustomer") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        if (ctrForm.Height > this.Height - 25)
                            ctrForm.Height = this.Height - 25;
                    }


                    ctrForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    ctr.Dock = DockStyle.Fill;
                    //ctrForm.Top = ((this.Height - ctrForm.Height) / 2) - 45;
                    //ctrForm.Left = ((this.Width - ctrForm.Width) / 2) - 45;
                    dicForm.Add(xCode, true);
                    //objctrForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                    ctrForm.childControl = ctr;
                    ctrForm.Tag = xCode.ToString(); ctrForm.BringToFront(); ctrForm.FormClosed += ctrForm_FormClosed;
                    ctrForm.GotFocus += ctrForm_GotFocus;
                    ctrForm.Show();

                    //((System.Windows.Forms.ContainerControl)(item)).BringToFront();

                    this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;

                }
                else
                {
                    foreach (var item in this.MdiChildren)
                    {
                        try
                        {
                            if (xCode.ToString() == ((System.Windows.Forms.ContainerControl)(item)).Tag.ToString())
                            {
                                try
                                {
                                    var iChild = ((ContainerControl)(item)).Controls[0];
                                    if (((ControlLibrary.BaseControl)(iChild)).frmStatus == ControlLibrary.BaseControl.currentStatus.Load)
                                    {
                                        if (((ControlLibrary.BaseControl)(iChild)).frmMode == ControlLibrary.BaseControl.currentMode.AddNew)
                                        {
                                            ((ControlLibrary.BaseControl)(iChild)).objBindingSource.AddNew();
                                            //((ControlLibrary.BaseControl)(iChild)).bindingNavigatorAddNewItem_Click(null, null);
                                            ((ControlLibrary.BaseControl)(iChild)).frmMode = ControlLibrary.BaseControl.currentMode.Position;
                                        }
                                        else
                                        {
                                            if (this.byID > 0)
                                            {
                                                int index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                if (index > 0)
                                                    ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //else
                                                //{
                                                //    if (((ControlLibrary.BaseControl)(iChild)).controlName.Equals("ctrCard"))
                                                //    {
                                                //        ((ControlLibrary.BaseControl)(iChild)).AddIDinBindingSource(this.byID);
                                                //        index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                //        ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //    }
                                                //}
                                            }
                                            else
                                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                        }

                                        ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                    }
                                }
                                catch { }
                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;
                                break;
                            }
                        }
                        catch { }
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
               //xMessageBox.Show(ex.Message.ToString());
            }
        }

        private void showControl2(string objAssemblyName, string objTypeName, string ctrName, string xCode, string mType, string mTableName, string date, int id, int qid = 0)
        {
            try
            {
               // this.date = date;
                var ctr = (Control)null;
                Cursor.Current = Cursors.WaitCursor;
                if (!dicForm.ContainsKey(xCode.ToString()))
                {

                    if (mType == "R") ctr = new frmRpt(objTypeName, mTableName, byID);
                    else if (mType == "C") ctr = new frmRpt(objTypeName, byID, byID, date);
                    ////else if (mType == "V") ctr = new AppControls.ctrVoucher(mTableName);
                    //else if (mType == "M1") { ctr = new AppControls.ctrCategory(mTableName); }
                    //else 
                    else if (mType == "M")
                    {
                        if ((mTableName == "CPV") || (mTableName == "CRV"))
                            ctr = new AppControls.ctrCashVoucher(mTableName);
                        else if ((mTableName == "BPV") || (mTableName == "BRV"))
                            ctr = new AppControls.ctrBankVoucher(mTableName);
                        else if (byID < 0 || qid > 0)
                        {
                            switch (objTypeName)
                            {
                                case "AppControls.ctrWorkOrder":
                                    if (ctrName.Equals("New Customer and New Work-Order"))
                                        ctr = new ctrWorkOrder(1);
                                    if (ctrName.Equals("New Customer and New Quote"))
                                        ctr = new ctrWorkOrder(2);
                                    if (ctrName.Equals("New WorkOrder for Selected Customer"))
                                        ctr = new ctrWorkOrder(3, qid);
                                    if (ctrName.Equals("New Quote for Selected Customer"))
                                        ctr = new ctrWorkOrder(4, qid);
                                    if (ctrName.Equals("WorkOrder"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    if (ctrName.Equals("WorkOrderOpen"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    break;

                                case "AppControls.ctrWorkOrderNegate":
                                    if (ctrName.Equals("WorkOrderNegateOpen"))
                                        ctr = new ctrWorkOrderNegate(byID);
                                    if (ctrName.Equals("WorkOrderNegate"))
                                        ctr = new ctrWorkOrderNegate(-1, byID, qid);
                                    break;

                                case "AppControls.ctrItemDefination":
                                    ctr = new AppControls.ctrItemDefination(byID);
                                    break;
                                case "AppControls.ctrBrowseInvoice":
                                    ctr = new AppControls.ctrBrowseInvoice(date,id);
                                    break;
                                case "AppControls.ctrInvoiceDetails":
                                    ctr = new AppControls.ctrInvoiceDetails(id,date);
                                    break;

                                case "AppControls.ctrCustomerReceipt":
                                    ctr = new ctrCustomerReceipt(byID, qid);
                                    break;

                                case "AppControls.ctrCustomerPayment":
                                    ctr = new ctrCustomerPayment(byID, qid);
                                    break;
                                case "AppControls.ctrWarrantyClaimAndCoresList":
                                    ctr = new ctrWarrantyClaimAndCoresList(qid);
                                    break;
                                //case "AppControls.ctrPurchaseOrder":
                                //    ctr = new AppControls.ctrPurchaseOrder(byID);
                                //    break;                                
                                //case "AppControls.ctrGoodsReceiptNote":
                                //    ctr = new AppControls.ctrGoodsReceiptNote(byID);
                                //    break;
                                //case "AppControls.ctrPurchaseReturn":
                                //    ctr = new AppControls.ctrPurchaseReturn(byID);
                                //    break;                                
                                //case "AppControls.ctrSaleReturn":
                                //ctr = new AppControls.ctrSaleReturn(byID);
                                //break;

                                default:
                                    break;
                            }
                        }
                        else
                            ctr = (Control)Activator.CreateInstance(Assembly.Load(objAssemblyName).GetType(objTypeName));
                    }

                    AppControls.frmCtr ctrForm = new AppControls.frmCtr(ctrName);
                    ctrForm.frmPnl.Controls.Add(ctr);
                    ctrForm.MdiParent = this;
                    //ctrForm.lblFormTitle.Text = ctrName;
                    //ctrForm.Height = ctr.Height + 34;
                    //ctrForm.Width = ctr.Width + 20;
                    //ctrForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    //this.MaximizeBox = true;
                    //this.MinimizeBox = true;                   
                    //if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "ctrWorkOrder") || (ctr.Name == "frmRpt"))
                    if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "frmRpt"))
                    {
                        ctrForm.Height = this.Height - 120;
                        ctrForm.Width = this.Width - 250;
                    }
                    if ((ctr.Name == "ctrCustomer") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        ctrForm.Height = this.Height - 120;
                    }
                    if ((ctr.Name == "ctrCompany") || (ctr.Name == "ctrWarehouse") || (ctr.Name == "ctrWarehouseStore") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrCustomer") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        if (ctrForm.Height > this.Height - 25)
                            ctrForm.Height = this.Height - 25;
                    }


                    ctrForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    ctr.Dock = DockStyle.Fill;
                    //ctrForm.Top = ((this.Height - ctrForm.Height) / 2) - 45;
                    //ctrForm.Left = ((this.Width - ctrForm.Width) / 2) - 45;
                    dicForm.Add(xCode, true);
                    //objctrForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                    ctrForm.childControl = ctr;
                    ctrForm.Tag = xCode.ToString(); ctrForm.BringToFront(); ctrForm.FormClosed += ctrForm_FormClosed;
                    ctrForm.GotFocus += ctrForm_GotFocus;
                    ctrForm.Show();

                    //((System.Windows.Forms.ContainerControl)(item)).BringToFront();

                    this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;

                }
                else
                {
                    foreach (var item in this.MdiChildren)
                    {
                        try
                        {
                            if (xCode.ToString() == ((System.Windows.Forms.ContainerControl)(item)).Tag.ToString())
                            {
                                try
                                {
                                    var iChild = ((ContainerControl)(item)).Controls[0];
                                    if (((ControlLibrary.BaseControl)(iChild)).frmStatus == ControlLibrary.BaseControl.currentStatus.Load)
                                    {
                                        if (((ControlLibrary.BaseControl)(iChild)).frmMode == ControlLibrary.BaseControl.currentMode.AddNew)
                                        {
                                            ((ControlLibrary.BaseControl)(iChild)).objBindingSource.AddNew();
                                            //((ControlLibrary.BaseControl)(iChild)).bindingNavigatorAddNewItem_Click(null, null);
                                            ((ControlLibrary.BaseControl)(iChild)).frmMode = ControlLibrary.BaseControl.currentMode.Position;
                                        }
                                        else
                                        {
                                            if (this.byID > 0)
                                            {
                                                int index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                if (index > 0)
                                                    ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //else
                                                //{
                                                //    if (((ControlLibrary.BaseControl)(iChild)).controlName.Equals("ctrCard"))
                                                //    {
                                                //        ((ControlLibrary.BaseControl)(iChild)).AddIDinBindingSource(this.byID);
                                                //        index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                //        ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //    }
                                                //}
                                            }
                                            else
                                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                        }

                                        ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                    }
                                }
                                catch { }
                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;
                                break;
                            }
                        }
                        catch { }
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) { }//xMessageBox.Show(ex.Message.ToString()); }
        }

        private void showControl3(string objAssemblyName, string objTypeName, string ctrName, string xCode, string mType, string mTableName, DataTable dt, int id, int qid = 0)
        {
            try
            {
                // this.date = date;
                var ctr = (Control)null;
                Cursor.Current = Cursors.WaitCursor;
                if (!dicForm.ContainsKey(xCode.ToString()))
                {

                    if (mType == "R") ctr = new frmRpt(objTypeName, mTableName, byID);
                    //else if (mType == "C") ctr = new ctrCodeFiles(mTableName);
                    ////else if (mType == "V") ctr = new AppControls.ctrVoucher(mTableName);
                    //else if (mType == "M1") { ctr = new AppControls.ctrCategory(mTableName); }
                    //else 
                    else if (mType == "M")
                    {
                        if ((mTableName == "CPV") || (mTableName == "CRV"))
                            ctr = new AppControls.ctrCashVoucher(mTableName);
                        else if ((mTableName == "BPV") || (mTableName == "BRV"))
                            ctr = new AppControls.ctrBankVoucher(mTableName);
                        else if (byID < 0 || qid > 0)
                        {
                            switch (objTypeName)
                            {
                                case "AppControls.ctrWorkOrder":
                                    if (ctrName.Equals("New Customer and New Work-Order"))
                                        ctr = new ctrWorkOrder(1);
                                    if (ctrName.Equals("New Customer and New Quote"))
                                        ctr = new ctrWorkOrder(2);
                                    if (ctrName.Equals("New WorkOrder for Selected Customer"))
                                        ctr = new ctrWorkOrder(3, qid);
                                    if (ctrName.Equals("New Quote for Selected Customer"))
                                        ctr = new ctrWorkOrder(4, qid);
                                    if (ctrName.Equals("WorkOrder"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    if (ctrName.Equals("WorkOrderOpen"))
                                        ctr = new ctrWorkOrder(-1, byID, qid);
                                    break;

                                case "AppControls.ctrWorkOrderNegate":
                                    if (ctrName.Equals("WorkOrderNegateOpen"))
                                        ctr = new ctrWorkOrderNegate(byID);
                                    if (ctrName.Equals("WorkOrderNegate"))
                                        ctr = new ctrWorkOrderNegate(-1, byID, qid);
                                    break;

                                case "AppControls.ctrItemDefination":
                                    ctr = new AppControls.ctrItemDefination(byID);
                                    break;
                                case "AppControls.ctrCustomerReceipt":
                                    ctr = new ctrCustomerReceipt(byID, qid);
                                    break;

                                case "AppControls.ctrCustomerPayment":
                                    ctr = new ctrCustomerPayment(byID, qid);
                                    break;
                                case "AppControls.ctrWarrantyClaimAndCoresList":
                                    ctr = new ctrWarrantyClaimAndCoresList(qid);
                                    break;
                                //case "AppControls.ctrPurchaseOrder":
                                //    ctr = new AppControls.ctrPurchaseOrder(byID);
                                //    break;                                
                                //case "AppControls.ctrGoodsReceiptNote":
                                //    ctr = new AppControls.ctrGoodsReceiptNote(byID);
                                //    break;
                                //case "AppControls.ctrPurchaseReturn":
                                //    ctr = new AppControls.ctrPurchaseReturn(byID);
                                //    break;                                
                                //case "AppControls.ctrSaleReturn":
                                //ctr = new AppControls.ctrSaleReturn(byID);
                                //break;

                                default:
                                    break;
                            }
                        }
                        else
                            ctr = (Control)Activator.CreateInstance(Assembly.Load(objAssemblyName).GetType(objTypeName));
                    }

                    AppControls.frmCtr ctrForm = new AppControls.frmCtr(ctrName);
                    ctrForm.frmPnl.Controls.Add(ctr);
                    ctrForm.MdiParent = this;
                    //ctrForm.lblFormTitle.Text = ctrName;
                    //ctrForm.Height = ctr.Height + 34;
                    //ctrForm.Width = ctr.Width + 20;
                    //ctrForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                    //this.MaximizeBox = true;
                    //this.MinimizeBox = true;                   
                    //if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "ctrWorkOrder") || (ctr.Name == "frmRpt"))
                    if ((ctr.Name == "ctrPurchaseOrderList") || (ctr.Name == "ctrVendorBillList") || (ctr.Name == "ctrVendorPaymentList") || (ctr.Name == "ctrWorkOrderList") || (ctr.Name == "frmRpt"))
                    {
                        ctrForm.Height = this.Height - 120;
                        ctrForm.Width = this.Width - 250;
                    }
                    if ((ctr.Name == "ctrCustomer") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        ctrForm.Height = this.Height - 120;
                    }
                    if ((ctr.Name == "ctrCompany") || (ctr.Name == "ctrWarehouse") || (ctr.Name == "ctrWarehouseStore") || (ctr.Name == "ctrEmployee") || (ctr.Name == "ctrCustomer") || (ctr.Name == "ctrVehicle") || (ctr.Name == "ctrChartofAccounts"))
                    {
                        if (ctrForm.Height > this.Height - 25)
                            ctrForm.Height = this.Height - 25;
                    }


                    ctrForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    ctr.Dock = DockStyle.Fill;
                    //ctrForm.Top = ((this.Height - ctrForm.Height) / 2) - 45;
                    //ctrForm.Left = ((this.Width - ctrForm.Width) / 2) - 45;
                    dicForm.Add(xCode, true);
                    //objctrForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                    ctrForm.childControl = ctr;
                    ctrForm.Tag = xCode.ToString(); ctrForm.BringToFront(); ctrForm.FormClosed += ctrForm_FormClosed;
                    ctrForm.GotFocus += ctrForm_GotFocus;
                    ctrForm.Show();

                    //((System.Windows.Forms.ContainerControl)(item)).BringToFront();

                    this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;

                }
                else
                {
                    foreach (var item in this.MdiChildren)
                    {
                        try
                        {
                            if (xCode.ToString() == ((System.Windows.Forms.ContainerControl)(item)).Tag.ToString())
                            {
                                try
                                {
                                    var iChild = ((ContainerControl)(item)).Controls[0];
                                    if (((ControlLibrary.BaseControl)(iChild)).frmStatus == ControlLibrary.BaseControl.currentStatus.Load)
                                    {
                                        if (((ControlLibrary.BaseControl)(iChild)).frmMode == ControlLibrary.BaseControl.currentMode.AddNew)
                                        {
                                            ((ControlLibrary.BaseControl)(iChild)).objBindingSource.AddNew();
                                            //((ControlLibrary.BaseControl)(iChild)).bindingNavigatorAddNewItem_Click(null, null);
                                            ((ControlLibrary.BaseControl)(iChild)).frmMode = ControlLibrary.BaseControl.currentMode.Position;
                                        }
                                        else
                                        {
                                            if (this.byID > 0)
                                            {
                                                int index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                if (index > 0)
                                                    ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //else
                                                //{
                                                //    if (((ControlLibrary.BaseControl)(iChild)).controlName.Equals("ctrCard"))
                                                //    {
                                                //        ((ControlLibrary.BaseControl)(iChild)).AddIDinBindingSource(this.byID);
                                                //        index = ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Find("ID", this.byID);
                                                //        ((ControlLibrary.BaseControl)(iChild)).objBindingSource.Position = index;
                                                //    }
                                                //}
                                            }
                                            else
                                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                        }

                                        ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                    }
                                }
                                catch { }
                                ((System.Windows.Forms.ContainerControl)(item)).BringToFront();
                                this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;
                                break;
                            }
                        }
                        catch { }
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex) { }//xMessageBox.Show(ex.Message.ToString()); }
        }
        public static void ctrForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string key = ((Form)sender).Tag.ToString();
            if (dicForm.ContainsKey(key))
            {
                dicForm.Remove(key);
                foreach (Control c in ((Form)sender).Controls)
                    c.Dispose();
                ((Form)sender).Controls.Clear();
            }
        }
        void ctrForm_GotFocus(object sender, EventArgs e)
        {
            Form form = sender as Form;
            this.lblStatusWorkingForm.Text = "Working Form : " + form.Text;
        }
        //private void LoadTabPage(ControlLibrary.TATabControl.TdhTabPage ctrTabPage, Control ctr)
        //{

        //    //if (taTabControl1.Controls.Contains(ctrTabPage))
        //    //{
        //    //    taTabControl1.SelectedTab = ctrTabPage;
        //    //}
        //    //else
        //    //{
        //    //this.POTabPage = new ControlLibrary.TATabControl.TdhTabPage(this.components);
        //    //this.ctrPO = new BeverageDistributor.ctrPurchaseOrder();

        //    //this.POTabPage.Location = new System.Drawing.Point(4, 28);            
        //    //this.POTabPage.Size = new System.Drawing.Size(984, 655);

        //    //ctrTabPage.Width = taTabControl1.Width;
        //    //ctrTabPage.Height = taTabControl1.Height;
        //    //ctrTabPage.BackColor = StaticInfo.globalctrBackColor;

        //    //ctr.Width = taTabControl1.Width;
        //    //ctr.Height = taTabControl1.Height-30;
        //    //ctr.BackColor = StaticInfo.globalctrBackColor;

        //    //ctrTabPage.TabAllowContextMenu = false;
        //    //ctrTabPage.TabConfirmOnClose = false;
        //    ////ctrTabPage.TabIndex = 1;
        //    //ctrTabPage.TabShowMenuButton = false;
        //    ////this.POTabPage.Text = "Purchase Order";

        //    //ctrTabPage.Controls.Add(ctr);

        //    //this.taTabControl1.Controls.Add(ctrTabPage);
        //    //taTabControl1.SelectedTab = ctrTabPage;
        //    //}
        //}
        void AddRecentButton(string ctrName, string xCode, System.Drawing.Color xColor)
        {
            try
            {
                if ((!dicButton.ContainsKey(xCode.ToString())) && (ctrName != "Grouping Card"))
                {
                    System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
                    toolTip1.IsBalloon = true;
                    //ControlLibrary.TAButton btnRecent = new ControlLibrary.TAButton();
                    //btnRecent.BackColor = xColor; //this.BackColor;
                    //btnRecent.ForeColor = System.Drawing.Color.Black;//System.Drawing.Color.White;

                    TAButton btnRecent = new TAButton();
                    btnRecent.Name = "btn" + xCode;
                    btnRecent.Tag = xCode;
                    //if(ctrName.Length > 10)
                    btnRecent.Size = new System.Drawing.Size(66, 40);
                    //else
                    //btnRecent.Size = new System.Drawing.Size(66, 23);
                    //btnRecent.UseVisualStyleBackColor = false;
                    btnRecent.Text = ctrName;
                    toolTip1.SetToolTip(btnRecent, ctrName);
                    btnRecent.Click += new System.EventHandler(btnRecent_Click);
                    //this.RecentPanel.Controls.Add(btnRecent);

                    dicButton.Add(xCode, true);
                }
            }
            catch { }
        }                        
        private void btnLeftButtion_Click(object sender, EventArgs e)
        {
            string xCode = ((ControlLibrary.LeftButton)sender).bXCode.ToString();
            try
            {
                MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.XCode == xCode);
                showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
            }
            catch { }
        }
        private void btnRecent_Click(object sender, EventArgs e)
        {
            string xCode = ((ControlLibrary.DashBoardButton)sender).bXCode.ToString();
            try
            {
                MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.XCode == xCode);
                showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
            }
            catch { }
        }
        private void ChildControl_LoadControl(string MAssemblyName, string ChildName, string TableName)
        {
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => (x.MObjectName == MAssemblyName && x.MTableName == TableName));
            if (menuItem == null)
                menuItem = MenuConfig.miList.FirstOrDefault(x => (x.MObjectName == MAssemblyName));
            showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName);
        }
        private void LoadReport_LoadRptReport(string MAssemblyName, string ReportName, string status, int id = 0)
        {
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.MObjectName == ReportName);
            showControl(menuItem.MAssemblyName, ReportName, ReportName, menuItem.XCode, "R", status, id);
        }
        private void LoadReport_LoadRptReport(string tblName, string MAssemblyName, string ReportName, string status, int id = 0)
        {
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.MObjectName == ReportName);
            //if (status.Equals("Receivables") || status.Equals("Payables"))
            //    menuItem.MTableName = status;
            showControl(menuItem.MAssemblyName, menuItem.MObjectName, menuItem.MMenuHeading, menuItem.XCode, menuItem.MType, menuItem.MTableName, id);
        }
        private void Control_LoadControl(string MAssemblyName, string ControlName, int id, int qid = 0)
        {
            //MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.MObjectName == ControlName);            
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => (x.MObjectName == MAssemblyName));
            showControl(menuItem.MAssemblyName, menuItem.MObjectName, ControlName, menuItem.XCode, menuItem.MType, menuItem.MTableName, id, qid);
        }
        private void Control_LoadControl2(string MAssemblyName, string ControlName, string date,int id, int qid = 0)
        {
            //MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.MObjectName == ControlName);            
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => (x.MObjectName == MAssemblyName));
            showControl2(menuItem.MAssemblyName, menuItem.MObjectName, ControlName, menuItem.XCode, menuItem.MType, menuItem.MTableName, date,id, qid);
        }
        private void Control_LoadControl3(string MAssemblyName, string ControlName, DataTable dt, int id, int qid = 0)
        {
            //MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => x.MObjectName == ControlName);            
            MenuItem menuItem = MenuConfig.miList.FirstOrDefault(x => (x.MObjectName == MAssemblyName));
            showControl3(menuItem.MAssemblyName, menuItem.MObjectName, ControlName, menuItem.XCode, menuItem.MType, menuItem.MTableName, dt, id, qid);
        }
        public void RefreshControls()
        {
            //for (int i = 1; i < this.taTabControl1.TabPages.Count; i++)
            //{
            //    //if (xCode.ToString() == this.taTabControl1.TabPages[i].Name.ToString())
            //    //{
            //    //    taTabControl1.SelectedTab = this.taTabControl1.TabPages[i];
            //    //    this.lblStatusWorkingForm.Text = "Working Form : " + ctrName;
            //    //    isExist = true;
            //    //    break;
            //    //}
            //}

            //foreach (Form form in this.MdiChildren)
            //{
            //    try { ((ControlLibrary.BaseControl)form.Controls[0]).ControlRefresh(); }
            //    catch { }
            //}
        }
    }
}
