using DBModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary.LibControls
{
    public partial class Notification : UserControl
    {
        string Module;
        string Add_Date;
        string Notifications;
        int ID;
        MessageBox xMessageBox = null;
        public Notification()
        {
            InitializeComponent();
        }
        public Notification(string ModuleName, string AddDate, string Notification, int NotifyID)
        {
            Module = ModuleName;
            Add_Date = AddDate;
            Notifications = Notification;
            ID = NotifyID;
            xMessageBox = new MessageBox();
            InitializeComponent();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            lblModule.Text = Module;
            lblNotification.Text = Notifications;
            lblDate.Text = Add_Date;
            lblID.Text = ID.ToString();
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            int NotifyID = Convert.ToInt32(lblID.Text);
            dbClass.obj.UpdateSeenNotifications(NotifyID);
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }

        private void lblNotification_Click(object sender, EventArgs e)
        {
            int NotifyID = Convert.ToInt32(lblID.Text);
            dbClass.obj.UpdateSeenNotifications(NotifyID);
            bool AccessPurchase = false;
            DataRow[] row = StaticInfo.UserRights.Select("Code = '030'");
            if (row[0]["CanView"] != DBNull.Value)
                AccessPurchase = Convert.ToBoolean(row[0]["CanView"]);
            if (AccessPurchase)
                StaticInfo.LoadToControl("AppControls.ctrPurchaseOrderList", "Purchase", 0);
            else
            {
                xMessageBox.Show("Sorry! You don't have Permissions on Purchase.");
            }
        }
    }
}
