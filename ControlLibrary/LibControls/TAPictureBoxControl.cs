
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using System.Drawing;
using System32;

namespace ControlLibrary
{
    public partial class TAPictureBoxControl : UserControl
    {

        //BindingSource bindingSource = null;

        //DataTable DataSource = null;
        //DbClass dbClass.obj = null;


        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }

        private StaticInfo.YesNo showInGrid;
        public StaticInfo.YesNo xIsShowInGrid
        {
            get { return showInGrid; }
            set { showInGrid = value; }
        }

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }
        private string displayMember;
        public string xDisplayMember
        {
            get { return displayMember; }
            set { displayMember = value; }
        }
        private string valueMember;
        public string xValueMember
        {
            get { return valueMember; }
            set { valueMember = value; }
        }

        private string tableName;
        public string xTableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public TAPictureBoxControl()
        {
            InitializeComponent();
        }

        public void BindControl(object bindingSource, DataTable dataSource, string xTableName, string xValueMember, int ID)
        {
            //this.imagePictureBox
            //dbClass.obj.Fill(dataSource);
            //this.bindingSource = (BindingSource)bindingSource;
            //this.DataSource = dataSource;
            //this.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, this.xBindingProperty, true));

            //DataTable dt = dbClass.obj.LoadImage();
            //if (dt.Rows.Count > 0)
            //    ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = StaticInfo.byteArrayToImage((byte[])dt.Rows[0][bindingProperty]);
            //else
            //    ((TAPictureBoxControl)ctr).imagePictureBox.BackgroundImage = null;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.imagePictureBox.BackgroundImage = null;
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    //dlg.Filter = "bmp files (*.bmp)|*.bmp";
                    dlg.Filter = "All Files|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.imagePictureBox.Image = new Bitmap(dlg.FileName);
                            this.imagePictureBox.BackgroundImage = this.imagePictureBox.Image;
                            this.imagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            this.imagePictureBox.Image = null;
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }


    }
}
