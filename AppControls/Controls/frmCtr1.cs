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
    public partial class frmCtr1 : Form
    {
        ControlLibrary.MessageBox xMessageBox = null;
        public Control childControl = null;

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        public frmCtr1()
        {
            InitializeComponent();

            xMessageBox = new ControlLibrary.MessageBox();

            this.panel1.MouseDown += panel1_MouseDown;
            this.panel1.MouseMove += panel1_MouseMove;
            this.panel1.MouseUp += panel1_MouseUp;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCtr1_FormClosing);            
            this.btnClose.Click += btnClose_Click;
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
        private void frmCtr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (((ControlLibrary.BaseControl)childControl).Locked)
                {
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
