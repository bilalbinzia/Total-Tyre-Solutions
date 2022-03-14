using ControlLibrary;
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
    public partial class frmCtr : Form
    {
        ControlLibrary.MessageBox xMessageBox = null;
        public Control childControl = null;
        string sTitle = "";
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        public frmCtr()
        {
            InitializeComponent();

            xMessageBox = new ControlLibrary.MessageBox();                        
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCtr_FormClosing);
            this.Load += frmCtr_Load;
        }

        void frmCtr_Load(object sender, EventArgs e)
        {
            this.Text = this.sTitle;
        }
        public frmCtr(string title)
        {
            InitializeComponent();
            this.sTitle = title;
            xMessageBox = new ControlLibrary.MessageBox();
            this.Load += frmCtr_Load;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCtr_FormClosing);
        }
        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 0x00A0: //ncmousemove
        //            // Print the Cursor position (in screen coordinates)
        //            Point screenPoint = new Point(m.LParam.ToInt32());
        //            //Debug.WriteLine(screenPoint);
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}
        private void frmCtr_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    System32.StaticInfo.CanApplicationExit = true;
            //    if (((ControlLibrary.BaseControl)childControl).Locked)
            //    {
            //        System32.StaticInfo.CanApplicationExit = false;
            //        if(xMessageBox.Show("Do you want to save data....?", "Exit..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
            //        e.Cancel = true;

            //        this.frmStatus = currentStatus.Load;
            //        this.objBindingSource.EndEdit();

            //        if (base.bindingNavigatorSaveItemClick(sender, e))
            //        {
            //            this.BaseEnableDisble(this.frmStatus);
            //        }
            //    }
            //    else
            //    {
            //        System32.StaticInfo.CanApplicationExit = false;
            //        e.Cancel = true;
            //    }
            //}
            //catch { }

            //if (System32.StaticInfo.CanApplicationExit)
            //{
            //    if (xMessageBox.Show("Do you want to save changes....?", "Exit..!", CCMessageBox.iMessageBoxButtons.YesNo) == DialogResult.No)
            //    { e.Cancel = true; }
            //    else
            //    {
            //        e.Cancel = false;
            //        //BaseControl.LogOff(); Environment.Exit(0);
            //    }
            //}
            try
            {
                System32.StaticInfo.CanApplicationExit = true;
                if (((ControlLibrary.BaseControl)childControl).Locked)
                {
                    System32.StaticInfo.CanApplicationExit = false;
                    xMessageBox.Show("Form in Add/Edit state..." + Environment.NewLine + "Please Save or Cancel...");
                    e.Cancel = true;
                }
            }
            catch { }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int wWidth =  this.Width/2+150;
                //int wHeight = this.Height;

                mouseX = MousePosition.X - wWidth; // This way we have the mouse closer to the middle of the window
                mouseY = MousePosition.Y - 90;

                this.SetDesktopLocation(mouseX, mouseY);
                
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
