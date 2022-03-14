using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TAcboButton : Button
    {

        private string mAssemblyName;

        public string xAssemblyName
        {
            get { return mAssemblyName; }
            set { mAssemblyName = value; }
        }
        private string mTitle;

        public string xTitle
        {
            get { return mTitle; }
            set { mTitle = value; }
        }
        private string mTableName;

        public string xTableName
        {
            get { return mTableName; }
            set { mTableName = value; }
        }

        private System.ComponentModel.Container components = null;
        public TAcboButton()
        {
            InitializeComponent();
            this.Click += TAcboButton_Click;
        }

        void TAcboButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mAssemblyName) && !string.IsNullOrEmpty(mTitle) && !string.IsNullOrEmpty(mTableName))
                StaticInfo.LoadToChild(mAssemblyName, mTitle, mTableName);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            
            this.Name = "btncboButton";
            this.Size = new System.Drawing.Size(21, 21);
            this.TabIndex = 11415;
            this.UseVisualStyleBackColor = true;

        }
    }
}
