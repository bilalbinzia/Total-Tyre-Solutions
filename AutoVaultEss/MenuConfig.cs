using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using System32;

namespace AutoVaultEss
{
    class TSMenuItem : ToolStripMenuItem
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
        }
        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mName;
        public string MName
        {
            get { return mName; }
        }
        private string mHeading;
        public string MHeading
        {
            get { return mHeading; }
        }
        public TSMenuItem(Menu menu)
        {
            this.mCode = menu.MCode;
            this.xCode = menu.XCode;
            this.mName = menu.MName;
            this.mHeading = menu.MHeading;
            this.AutoSize = true;
        }
        public TSMenuItem(MenuItem menuItem)
        {
            this.mCode = menuItem.MCode;
            this.xCode = menuItem.XCode;
            this.mName = menuItem.MMenuName;
            this.mHeading = menuItem.MMenuHeading;
            this.AutoSize = true;
            this.Visible = menuItem.MVisible;
        }
    }
    public static partial class MenuConfig
    {
        public static List<Menu> mList;
        public static List<MenuItem> miList;
        public static List<LeftToolButton> LtbList;
        public static List<LeftToolButton> tbList;
        static string xmCode = string.Empty;
        static MenuConfig()
        {
            mList = new List<Menu>();
            miList = new List<MenuItem>();
            tbList = new List<LeftToolButton>();
            LtbList = new List<LeftToolButton>();

            AddTopMenuAppControls();
        }
        private static void AddMenu(string mCode, string mType, string mName, string mHeading, string mPicName)
        {
            Menu nMenu = new Menu();
            nMenu.MCode = mCode;
            nMenu.MType = mType;
            nMenu.MName = mName;
            nMenu.MHeading = mHeading;
            nMenu.MPicName = mPicName;            
            mList.Add(nMenu);
        }
        private static void AddMenuItem(string mCode, string xCode, string mType, string mMenuHeading, string mMenuName, string mAssemblyName, string mObjectName, string mTableName, string mPicName, bool IsVisible = true)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.MCode = mCode;
            menuItem.XCode = xCode;
            menuItem.MType = mType;
            menuItem.MMenuHeading = mMenuHeading;
            menuItem.MMenuName = mMenuName;
            menuItem.MAssemblyName = mAssemblyName;
            menuItem.MObjectName = mObjectName;
            menuItem.MTableName = mTableName;
            menuItem.MPicName = mPicName;
            menuItem.MVisible = IsVisible;
            miList.Add(menuItem);
        }
        private static void AddToolButton(string mCode, string xCode, string mType, string mMenuHeading, string mMenuName, string mAssemblyName, string mObjectName, string mTableName, string mPicName)
        {
            LeftToolButton nMenu = new LeftToolButton();
            nMenu.MCode = mCode;
            nMenu.XCode = xCode;
            nMenu.MType = mType;
            nMenu.MMenuHeading = mMenuHeading;
            nMenu.MMenuName = mMenuName;
            nMenu.MAssemblyName = mAssemblyName;
            nMenu.MObjectName = mObjectName;
            nMenu.MTableName = mTableName;
            nMenu.MPicName = mPicName;
            LtbList.Add(nMenu);
        }
        private static void AddLeftButton(string mCode, string xCode, string mType, string mButtonHeading, string mButtonName, string mAssemblyName, string mObjectName)
        {
            LeftToolButton nMenu = new LeftToolButton();
            nMenu.MCode = mCode;
            nMenu.XCode = xCode;
            nMenu.MType = mType;
            nMenu.MMenuHeading = mButtonHeading;
            nMenu.MMenuName = mButtonName;
            nMenu.MAssemblyName = mAssemblyName;
            nMenu.MObjectName = mObjectName;
            LtbList.Add(nMenu);
        }

    }
    public class Menu
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
            set { mCode = value; }
        }
        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mType;
        public string MType
        {
            get { return mType; }
            set { mType = value; }
        }
        private string mName;
        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }
        private string mHeading;
        public string MHeading
        {
            get { return mHeading; }
            set { mHeading = value; }
        }
        private string mPicName;
        public string MPicName
        {
            get { return mPicName; }
            set { mPicName = value; }
        }
    }
    public class MenuItem
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
            set { mCode = value; }
        }

        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mType;
        public string MType
        {
            get { return mType; }
            set { mType = value; }
        }
        private string mMenuType;
        public string MMenuType
        {
            get { return mMenuType; }
            set { mMenuType = value; }
        }
        private string mMenuHeading;
        public string MMenuHeading
        {
            get { return mMenuHeading; }
            set { mMenuHeading = value; }
        }
        private string mMenuName;
        public string MMenuName
        {
            get { return mMenuName; }
            set { mMenuName = value; }
        }
        private string mAssemblyName;
        public string MAssemblyName
        {
            get { return mAssemblyName; }
            set { mAssemblyName = value; }
        }
        private string mObjectName;
        public string MObjectName
        {
            get { return mObjectName; }
            set { mObjectName = value; }
        }
        private string mTableName;
        public string MTableName
        {
            get { return mTableName; }
            set { mTableName = value; }
        }
        private string mPicName;
        public string MPicName
        {
            get { return mPicName; }
            set { mPicName = value; }
        }
        private bool mVisible;
        public bool MVisible
        {
            get { return mVisible; }
            set { mVisible = value; }
        }
    }
    public class LeftToolButton
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
            set { mCode = value; }
        }
        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mType;
        public string MType
        {
            get { return mType; }
            set { mType = value; }
        }
        private string mMenuType;
        public string MMenuType
        {
            get { return mMenuType; }
            set { mMenuType = value; }
        }
        private string mMenuHeading;
        public string MMenuHeading
        {
            get { return mMenuHeading; }
            set { mMenuHeading = value; }
        }
        private string mMenuName;
        public string MMenuName
        {
            get { return mMenuName; }
            set { mMenuName = value; }
        }
        private string mAssemblyName;
        public string MAssemblyName
        {
            get { return mAssemblyName; }
            set { mAssemblyName = value; }
        }
        private string mObjectName;
        public string MObjectName
        {
            get { return mObjectName; }
            set { mObjectName = value; }
        }
        private string mTableName;
        public string MTableName
        {
            get { return mTableName; }
            set { mTableName = value; }
        }
        private string mPicName;
        public string MPicName
        {
            get { return mPicName; }
            set { mPicName = value; }
        }
    }
    class LTButtonItem : ToolStripMenuItem
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
        }
        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mName;
        public string MName
        {
            get { return mName; }
        }
        private string mHeading;
        public string MHeading
        {
            get { return mHeading; }
        }
        public LTButtonItem(LeftToolButton LTButon)
        {
            this.mCode = LTButon.MCode;
            this.xCode = LTButon.XCode;
            this.mName = LTButon.MMenuName;
            this.mHeading = LTButon.MMenuHeading;
        }
    }
    class LeftButton : TAButton
    {
        private string mCode;
        public string MCode
        {
            get { return mCode; }
        }
        private string xCode;
        public string XCode
        {
            get { return xCode; }
            set { xCode = value; }
        }
        private string mName;
        public string MName
        {
            get { return mName; }
        }
        private string mHeading;
        public string MHeading
        {
            get { return mHeading; }
        }
        public LeftButton(LeftToolButton LTButon)
        {
            this.mCode = LTButon.MCode;
            this.xCode = LTButon.XCode;
            this.mName = LTButon.MMenuName;
            this.mHeading = LTButon.MMenuHeading;
        }
    }
}
