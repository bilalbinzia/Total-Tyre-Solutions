using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlLibrary
{
    public partial class DashBoardButton : UserControl
    {
        public string bXCode { get; set; }
        public string headingText { get; set; }
        public Color headingColor { get; set; }
        public Image bXPic { get; set; }


        public DashBoardButton()
        {
            InitializeComponent();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }
        public event EventHandler bXClick;

        private void DashBoardButton_Load(object sender, EventArgs e)
        {
            this.Pic.BackgroundImage = bXPic;
            this.lblHeading1.Text = headingText;
            this.lblHeading1.LinkColor = headingColor;
            
        }

        protected void Pic_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.bXClick != null)
                this.bXClick(this, e);
        }

        private void lblHeading1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void lblHeading1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}