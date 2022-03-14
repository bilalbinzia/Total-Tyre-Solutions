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
    public partial class LeftButton : UserControl
    {
        public string bXCode { get; set; }
        public string headingText { get; set; }        
        public Image bXPic1 { get; set; }
        public Image bXPic2 { get; set; }


        public LeftButton()
        {
            InitializeComponent();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.lblHeading1.Click += new System.EventHandler(this.Pic_Click);
            this.Pic.Click += new System.EventHandler(this.Pic_Click);
            this.Click += new System.EventHandler(this.Pic_Click);
            this.tableLayoutPanel1.Click += new System.EventHandler(this.Pic_Click);

            this.lblHeading1.MouseLeave += new System.EventHandler(this.lblHeading1_MouseLeave);
            this.lblHeading1.MouseHover += new System.EventHandler(this.lblHeading1_MouseHover);
        }        
        public event EventHandler bxClick;

        private void LeftButton_Load(object sender, EventArgs e)
        {
            this.Pic.BackgroundImage = bXPic1;
            this.lblHeading1.Text = headingText;
        }

        protected void Pic_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            //if (this.bXClick != null)
                //this.bXClick(this, e);

            bxClick(this, EventArgs.Empty);
        }

        private void lblHeading1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            LeftPanel.BackColor = Color.Red;
            //this.BackColor = Color.LightSlateGray;
            lblHeading1.LinkColor = Color.Red;
            this.Pic.BackgroundImage = bXPic2;
        }

        private void lblHeading1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            LeftPanel.BackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
            lblHeading1.LinkColor = Color.White;
            this.Pic.BackgroundImage = bXPic1;
        }
     
    }
}