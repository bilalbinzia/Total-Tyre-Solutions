using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;
using System32;

namespace ControlLibrary
{
    public partial class TAEncryptTextBox : UserControl
    {

        BindingSource bindingSource = null;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }

        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }
        private StaticInfo.YesNo encrypt = StaticInfo.YesNo.Yes;
        public StaticInfo.YesNo xIsEncrypt
        {
            get { return encrypt; }
            set { encrypt = value; }
        }
        private StaticInfo.YesNo allowDuplicate;
        public StaticInfo.YesNo xIsAllowDuplicate
        {
            get { return allowDuplicate; }
            set { allowDuplicate = value; }
        }

        private StaticInfo.YesNo showInGrid;
        public StaticInfo.YesNo xIsShowInGrid
        {
            get { return showInGrid; }
            set { showInGrid = value; }
        }
        private string columnName;
        public string xColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        private char passwordChar;
        public char xPasswordChar
        {
            get { return passwordChar; }
            set { passwordChar = value; }
        }
        private int columnWidth = 60;
        public int xColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }

        private StaticInfo.Mask m_mask;
        public StaticInfo.Mask xMasked
        {
            get { return m_mask; }
            set
            {
                m_mask = value;
                //this.Text = "";
            }
        }
        public TAEncryptTextBox()
        {
            InitializeComponent();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            this.TxtBox.TextChanged += TxtBox_TextChanged;
            this.taTextBox1.KeyDown += taTextBox1_KeyDown;
            this.taTextBox1.Leave += taTextBox1_Leave;
        }

        void taTextBox1_Leave(object sender, EventArgs e)
        {
            if (this.xIsEncrypt == StaticInfo.YesNo.Yes)
            {
                if (!string.IsNullOrEmpty(taTextBox1.Text.Trim()))
                {
                    this.TxtBox.Text = System32.EncryptDecrypt.Encrypt(taTextBox1.Text.Trim());
                    this.TxtBox.PasswordChar = this.xPasswordChar;
                }
                else
                    this.TxtBox.Text = string.Empty;
            }
        }

        void taTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                if (this.xIsEncrypt == StaticInfo.YesNo.Yes)
                {
                    if (!string.IsNullOrEmpty(taTextBox1.Text.Trim()))
                    {
                        this.TxtBox.Text = System32.EncryptDecrypt.Encrypt(taTextBox1.Text.Trim());
                        this.TxtBox.PasswordChar = this.xPasswordChar;
                    }
                    else
                        this.TxtBox.Text = string.Empty;
                }
            //}
        }

        void TxtBox_TextChanged(object sender, EventArgs e)
        {
            if (this.xIsEncrypt == StaticInfo.YesNo.Yes)
            {
                if (!string.IsNullOrEmpty(TxtBox.Text.Trim()))
                {
                    this.taTextBox1.Text = EncryptDecrypt.Decrypt(this.TxtBox.Text.Trim());
                    this.taTextBox1.PasswordChar = this.xPasswordChar;
                }
                else
                    this.taTextBox1.Text = string.Empty;
            }
        }

        public void BindControl(object bindingSource, string dataMember)
        {
            this.bindingSource = (BindingSource)bindingSource;
            if (this.xIsEncrypt == StaticInfo.YesNo.Yes)
            {
                if (this.xMasked == StaticInfo.Mask.Decimal)
                {
                    this.TxtBox.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "C", Cultures.Pakistan);
                }
                else
                    this.TxtBox.DataBindings.Add("Text", this.bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
            }
            if (this.xIsEncrypt == StaticInfo.YesNo.No)
            {
                if (this.xMasked == StaticInfo.Mask.Decimal)
                {
                    this.taTextBox1.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "C", Cultures.Pakistan);
                }
                else
                    this.taTextBox1.DataBindings.Add("Text", this.bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);

            }

            this.taTextBox1.xBindingProperty = this.xBindingProperty;
            this.taTextBox1.xColumnName = this.xColumnName;
            this.taTextBox1.xColumnWidth = this.xColumnWidth;
            this.taTextBox1.xIsAllowDuplicate = this.xIsAllowDuplicate;
            this.taTextBox1.xIsEncrypt = this.xIsEncrypt;
            this.taTextBox1.xIsRequired = this.xIsRequired;
            this.taTextBox1.xIsShowInGrid = this.xIsShowInGrid;
            this.taTextBox1.xMasked = this.xMasked;
            this.taTextBox1.PasswordChar = this.xPasswordChar;
            this.TxtBox.PasswordChar = this.xPasswordChar;
        }

    }
}
