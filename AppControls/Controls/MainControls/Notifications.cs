using ControlLibrary.LibControls;
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

namespace AppControls
{
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            DataTable dt = dbClass.obj.GetAllNotifications();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Notification notification = new Notification(dr["Module"].ToString(), dr["AddDate"].ToString(), dr["Notification"].ToString(), Convert.ToInt32(dr["ID"]));
                    notification.Enabled = !Convert.ToBoolean(dr["Seen"]);
                    NotificationPanel.Controls.Add(notification);
                }
            }
            else
            {
                Notification notification = new Notification("Information!", "You have 0 Notifications...!", "", 0);
                notification.Enabled = !Convert.ToBoolean(0);
                NotificationPanel.Controls.Add(notification);
                //MessageBox.Show("You have 0 Notifications...!");
            }
        }
    }
}
