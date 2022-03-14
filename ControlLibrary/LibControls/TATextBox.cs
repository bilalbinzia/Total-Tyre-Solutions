using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TATextBox : System.Windows.Forms.TextBox
    {

        private System.ComponentModel.Container components = null;
        BindingSource bindingSource = null;
        public string dataMember = null;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private string bindingProperty;
        public string xBindingProperty
        {
            get { return bindingProperty; }
            set { bindingProperty = value; }
        }
        private bool cReadOnly;
        public bool xReadOnly
        {
            get { return cReadOnly; }
            set { cReadOnly = value; }
        }
        private StaticInfo.YesNo required;
        public StaticInfo.YesNo xIsRequired
        {
            get { return required; }
            set { required = value; }
        }

        private StaticInfo.YesNo encrypt;
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
                this.Text = "";
            }
        }

        private StaticInfo.YesNo showCashSymbol;
        public StaticInfo.YesNo xIsShowCashSymbol
        {
            get { return showCashSymbol; }
            set { showCashSymbol = value; }
        }

        private int digitPos = 0;
        private int DelimitNumber = 0;
        public TATextBox()
        {
            InitializeComponent();
            if (xMasked != StaticInfo.Mask.None)
                m_mask = xMasked;
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            //this.Leave += new System.EventHandler(this.OnLeave);
        }


        public void BindControl(object bindingSource, string dataMember)
        {
            this.bindingSource = (BindingSource)bindingSource;
            this.dataMember = dataMember;

            if ((this.xMasked == StaticInfo.Mask.Decimal) && (this.xIsShowCashSymbol == StaticInfo.YesNo.Yes))
                this.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "C", Cultures.USA);
            else
                this.DataBindings.Add("Text", this.bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }
        //public void BindControl(object bindingSource, string dataMember)
        //{
        //    this.bindingSource = (BindingSource)bindingSource;
        //    this.dataMember = dataMember;

        //    if (this.Masked == Mask.Decimal)
        //        this.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "#00.00");
        //    else if (this.Masked == Mask.Rate)
        //        this.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "#00.000");
        //    else if (this.Masked == Mask.Currency)
        //        this.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, 0, "C2");
        //    else if (this.Masked == Mask.DateOnly)
        //        this.DataBindings.Add("Text", bindingSource, dataMember, true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
        //    else
        //        this.DataBindings.Add("Text", this.bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        //}
        protected override void OnKeyDown(KeyEventArgs e)
        {
                base.OnKeyDown(e);
            try
                {
                if (e.Control && e.KeyCode == Keys.F)
                {
                    if (this.ReadOnly)
                    {
                        if (!this.bindingSource.Equals(null) && !this.dataMember.Equals(null) && !typeof(string).Equals(null))
                        {
                            DataRow dataRow = ((DataRowView)bindingSource.Current).Row;
                            if (dataRow.RowState != DataRowState.Added)
                            {
                                if (!this.dataMember.ToString().Contains("Date"))
                                {
                                    if (this.Parent.Name.Equals("WorkingPanel"))
                                    {
                                        Search search = new Search(this.bindingSource, this.dataMember, typeof(string), this.Parent);
                                    }
                                    else if (this.Parent.Parent.Name.Equals("WorkingPanel"))
                                    {
                                        Search search = new Search(this.bindingSource, this.dataMember, typeof(string), this.Parent.Parent);
                                    }
                                    else if (this.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                                    {
                                        Search search = new Search(this.bindingSource, this.dataMember, typeof(string), this.Parent.Parent.Parent);
                                    }
                                    else if (this.Parent.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                                    {
                                        Search search = new Search(this.bindingSource, this.dataMember, typeof(string), this.Parent.Parent.Parent.Parent);
                                    }
                                    else if (this.Parent.Parent.Parent.Parent.Parent.Name.Equals("WorkingPanel"))
                                    {
                                        Search search = new Search(this.bindingSource, this.dataMember, typeof(string), this.Parent.Parent.Parent.Parent.Parent);
                                    }
                                    //search.Show();
                                }
                            }
                        }
                    }
                }
                if (e.Control && e.KeyCode == Keys.C) { }
                if (e.Control && e.KeyCode == Keys.V) { }
                if (e.KeyCode == Keys.Enter) {  SendKeys.Send("{TAB}");  }
            }
            catch { }   
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            try
            {
                if (CheckMasking())
                {
                    //if (!this.allowDuplicate)
                    //{
                    //    if (!string.IsNullOrEmpty(this.Text.Trim()))
                    //    {
                    //        DBModule.DbClass dbClass.obj = new DBModule.DbClass();
                    //        System.Data.DataTable dataTable = (System.Data.DataTable)this.bindingSource.DataSource;
                    //        System.Data.DataRowView curRow = (System.Data.DataRowView)this.bindingSource.Current;
                    //        if (Convert.ToInt32(curRow["ID"]) < 0)
                    //        {
                    //            if (dbClass.obj.checkDuplicate(dataTable, this.bindingProperty, this.Text.Trim().ToString(), -1))
                    //            {
                    //                errorProvider1.SetError(this, "Duplicate value validation...!");
                    //                this.Focus();
                    //            }
                    //            else { errorProvider1.SetError(this, ""); }
                    //        }
                    //        if (Convert.ToInt32(curRow["ID"]) > 0)
                    //        {
                    //            if (dbClass.obj.checkDuplicate(dataTable, this.bindingProperty, this.Text.Trim().ToString(), Convert.ToInt32(curRow["ID"])))
                    //            {
                    //                errorProvider1.SetError(this, "Duplicate value validation...!");
                    //                this.Focus();
                    //            }
                    //            else { errorProvider1.SetError(this, ""); }
                    //        }

                    //    }
                    //}
                }
            }
            catch { }
        }
        bool CheckMasking()
        {
            if (!this.ReadOnly)
            {
                switch (m_mask)
                {
                    case StaticInfo.Mask.DateOnly:
                        if (this.Text.Trim().Length < 8) { errorProvider1.SetError(this, "Date Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.PhoneWithArea:
                        if (this.Text.Trim().Length < 15) { errorProvider1.SetError(this, "PhoneWithArea Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.MobileNo:
                        if (this.Text.Trim().Length < 12) { errorProvider1.SetError(this, "MobileNo Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.PhoneNo:
                        if (this.Text.Trim().Length < 10) { errorProvider1.SetError(this, "PhoneNo Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.IpAddress:
                        if (this.Text.Trim().Length < 10) { errorProvider1.SetError(this, "IpAddress Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.SSN:
                        if (this.Text.Trim().Length < 8) { errorProvider1.SetError(this, "SSN Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.eMail:
                        if ((!this.Text.Trim().Contains("@")) || !this.Text.Trim().Contains(".com")) { errorProvider1.SetError(this, "eMail Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    case StaticInfo.Mask.CNIC:
                        if (this.Text.Trim().Length < 15) { errorProvider1.SetError(this, "CNIC Mask validation...!"); this.Focus(); return false; } else { errorProvider1.SetError(this, ""); return true; }
                    default:
                        return true;
                }
            }
            else
                return true;
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            TATextBox sd = (TATextBox)sender;
            if (!sd.ReadOnly)
            {
                switch (m_mask)
                {
                    case StaticInfo.Mask.DateOnly:
                        sd.MaskDate(e);
                        break;
                    case StaticInfo.Mask.PhoneWithArea:
                        sd.MaskPhoneSSN(e, 3, 3);
                        break;
                    case StaticInfo.Mask.MobileNo:
                        sd.MaskMobileNo(e);
                        break;
                    case StaticInfo.Mask.MaskMobileNoCC:
                        sd.MaskMobileNoCC(e);
                        break;
                    case StaticInfo.Mask.PhoneNo:
                        sd.MaskPhoneNo(e);
                        break;
                    case StaticInfo.Mask.IpAddress:
                        sd.MaskIpAddr(e);
                        break;
                    case StaticInfo.Mask.SSN:
                        sd.MaskPhoneSSN(e, 3, 2);
                        break;
                    case StaticInfo.Mask.Decimal:
                        sd.MaskDecimal(e);
                        break;
                    case StaticInfo.Mask.Digit:
                        sd.MaskDigit(e);
                        break;
                    case StaticInfo.Mask.eMail:
                        sd.MaskeMail(e);
                        break;
                    case StaticInfo.Mask.CNIC:
                        sd.MaskCNICNo(e);
                        break;
                }
            }
        }
        //void OnLeave(object sender, EventArgs e)
        //{
        //    TATextBox sd = (TATextBox)sender;
        //    if (!sd.ReadOnly)
        //    {
        //        //Regex regStr;
        //        switch (m_mask)
        //        {
        //            case Mask.Decimal:
        //                sd.FormatDecimal(sender, e);
        //                break;
        //            //case Mask.DateOnly:
        //            //    regStr = new Regex(@"\d{2}/\d{2}/\d{4}");
        //            //    if (!regStr.IsMatch(sd.Text))
        //            //        errorProvider1.SetError(this, "");
        //            //    //errorProvider1.SetError(this, "Date is not valid; mm/dd/yyyy");
        //            //    break;
        //            //case Mask.PhoneWithArea:
        //            //    regStr = new Regex(@"\d{3}-\d{3}-\d{4}");
        //            //    if (!regStr.IsMatch(sd.Text)) errorProvider1.SetError(this, "");
        //            //    //errorProvider1.SetError(this, "Phone number is not valid; xxx-xxx-xxxx");
        //            //    break;
        //            //case Mask.IpAddress:
        //            //    short cnt = 0;
        //            //    int len = sd.Text.Length;
        //            //    for (short i = 0; i < len; i++)
        //            //        if (sd.Text[i] == '.')
        //            //        {
        //            //            cnt++;
        //            //            if (i + 1 < len)
        //            //                if (sd.Text[i + 1] == '.')
        //            //                {
        //            //                    errorProvider1.SetError(this, "");
        //            //                    //errorProvider1.SetError(this, "IP Address is not valid; x??.x??.x??.x??");
        //            //                    break;
        //            //                }
        //            //        }
        //            //    if (cnt < 3 || sd.Text[len - 1] == '.')
        //            //        errorProvider1.SetError(this, "");
        //            //    //errorProvider1.SetError(this, "IP Address is not valid; x??.x??.x??.x??");
        //            //    break;
        //            //case Mask.SSN:
        //            //    regStr = new Regex(@"\d{3}-\d{2}-\d{4}");
        //            //    if (!regStr.IsMatch(sd.Text))
        //            //        errorProvider1.SetError(this, "");
        //            //    //errorProvider1.SetError(this, "SSN is not valid; xxx-xx-xxxx");
        //            //    break;
        //            //case Mask.Decimal:
        //            //    //Regex.Match(tb.Text, @"\d+(\.\d+)?");
        //            //    regStr = new Regex(@"\d+(\.\d+)?");
        //            //    //if (regStr.IsMatch(sd.Text))
        //            //    //    sd.FormatDecimal(sender, e);
        //            //    break;
        //            //case Mask.Digit:
        //            //    regStr = new Regex(@"\d+?");
        //            //    break;
        //            //case Mask.eMail:
        //            //    regStr = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        //            //    if (!regStr.IsMatch(sd.Text))
        //            //        errorProvider1.SetError(this, "");
        //            //    //errorProvider1.SetError(this, "EMail is not valid; xxxx@xxxx.xxx");
        //            //    else
        //            //        errorProvider1.SetError(this, "");
        //            //    break;
        //        }
        //    }
        //}                
        
        void FormatDecimal(object sender, EventArgs e)
        {
            TATextBox tb = (TATextBox)sender;
            if (tb.Text != null)
            {
                try
                {
                    string resultString = Regex.Match(tb.Text, @"\d+(\.\d+)?").Value;
                    tb.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "$.{0:C2}", resultString);
                }
                catch { }
            }
        }
        void MaskDigit(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '\r')
            {
                errorProvider1.SetError(this, "");
                e.Handled = false;
            }
            else
            {
                errorProvider1.SetError(this, "Only valid for Digit");
                e.Handled = true;
            }
        }
        void MaskeMail(KeyPressEventArgs e)
        {
            //IF System.Text.RegularExpressions.Regex.IsMatch(@ "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" , myString) Then
        }
        void MaskDecimal(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8 || e.KeyChar == '\r')
            {
                errorProvider1.SetError(this, "");
                e.Handled = false;
            }
            else
            {
                errorProvider1.SetError(this, "Only valid for Digit and dot");
                e.Handled = true;
            }
        }
        void MaskDate(KeyPressEventArgs e)
        {
            string tmp = string.Empty;
            string tmp2 = string.Empty;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = this.Text.Length;
                        //string text = this.Text.Trim();
                        if (len.Equals(0) || len.Equals(3) || len.Equals(6))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        if (len.Equals(1) || len.Equals(4))
                        {
                            if (len.Equals(1))
                            {
                                tmp = this.Text + e.KeyChar.ToString();
                                if (int.Parse(tmp) < 32)
                                {
                                    this.AppendText(e.KeyChar.ToString());
                                    this.AppendText("/");
                                    e.Handled = true;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            if (len.Equals(4))
                            {
                                tmp = this.Text + e.KeyChar.ToString();
                                int indx = tmp.IndexOf("/");
                                tmp2 = tmp.Substring(indx + 1, 2);
                                if (int.Parse(tmp2) < 13)
                                {
                                    this.AppendText(e.KeyChar.ToString());
                                    this.AppendText("/");
                                    e.Handled = true;
                                }
                                else
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }

                        }
                        if (len.Equals(7))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        void MaskPhoneSSN(KeyPressEventArgs e, int pos, int pos2)
        {
            int len = this.Text.Length;
            int indx = this.Text.LastIndexOf("-");
            // if test is highlighted reset vars
            if (this.SelectedText == this.Text)
            {
                indx = -1;
                digitPos = 0;
                DelimitNumber = 0;
            }
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == 8)
            { // only digit, Backspace and - are accepted
                string tmp = this.Text;
                if (e.KeyChar != 8)
                {
                    //errorProvider1.SetError(this, "");
                    if (e.KeyChar != '-')
                    {
                        if (indx > 0)
                            digitPos = len - indx;
                        else
                            digitPos++;
                    }
                    if (indx > -1 && digitPos == pos2 && DelimitNumber == 1)
                    {
                        if (e.KeyChar != '-')
                        {
                            this.AppendText(e.KeyChar.ToString());
                            this.AppendText("-");
                            e.Handled = true;
                            DelimitNumber++;
                        }
                    }
                    if (digitPos == pos && DelimitNumber == 0)
                    {
                        if (e.KeyChar != '-')
                        {
                            this.AppendText(e.KeyChar.ToString());
                            this.AppendText("-");
                            e.Handled = true;
                            DelimitNumber++;
                        }
                    }
                    if (digitPos > 4)
                        e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                    if ((len - indx) == 1)
                    {
                        DelimitNumber--;
                        if ((indx) > -1)
                            digitPos = len - indx;
                        else
                            digitPos--;
                    }
                    else
                    {
                        if (indx > -1)
                            digitPos = len - indx - 1;
                        else
                            digitPos = len - 1;
                    }
                }
            }
            else
            {
                e.Handled = true;
                //errorProvider1.SetError(this, "Only valid for Digit and -");
            }
        }
        void MaskMobileNo(KeyPressEventArgs e)
        {
            //0300-9733522
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = this.Text.Length;
                        if (len.Equals(3))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            this.AppendText("-");
                            e.Handled = true;
                        }
                        else if ((len < 3) || ((len > 4) && (len < 12)))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        void MaskMobileNoCC(KeyPressEventArgs e)
        {
            //923009733522
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = this.Text.Length;
                        if (len < 12)
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        void MaskPhoneNo(KeyPressEventArgs e)
        {
            //042-3545555
            //062-2439815
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = this.Text.Length;
                        if (len.Equals(2))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            this.AppendText("-");
                            e.Handled = true;
                        }
                        else if ((len < 2) || ((len > 3) && (len < 12)))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        void MaskCNICNo(KeyPressEventArgs e)
        {
            //31203-1718321-3
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (!e.Handled)
            {
                if (e.KeyChar != 8)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        int len = this.Text.Length;
                        if ((len.Equals(4)) || (len.Equals(12)))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            this.AppendText("-");
                            e.Handled = true;
                        }
                        else if ((len < 4) || ((len > 5) && (len < 12)) || ((len > 12) && (len < 15)))
                        {
                            this.AppendText(e.KeyChar.ToString());
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
        void MaskIpAddr(KeyPressEventArgs e)
        {
            int len = this.Text.Length;
            int indx = this.Text.LastIndexOf(".");
            // if test is highlighted reset vars
            if (this.SelectedText == this.Text)
            {
                indx = -1;
                digitPos = 0;
                DelimitNumber = 0;
            }
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
            { // only digit, Backspace and dot are accepted
                string tmp = this.Text;
                //errorProvider1.SetError(this, "");
                if (e.KeyChar != 8)
                {
                    if (e.KeyChar != '.')
                    {
                        if (indx > 0)
                            digitPos = len - indx;
                        else
                            digitPos++;
                        if (digitPos == 3)
                        {
                            string tmp2 = this.Text.Substring(indx + 1) + e.KeyChar;
                            if (Int32.Parse(tmp2) > 255) { }// check validation
                            //errorProvider1.SetError(this, "");
                            //errorProvider1.SetError(this, "The number can't be bigger than 255");
                            else
                            {
                                if (DelimitNumber < 3)
                                {
                                    this.AppendText(e.KeyChar.ToString());
                                    this.AppendText(".");
                                    DelimitNumber++;
                                    e.Handled = true;
                                }
                            }
                        }
                        if (digitPos == 4)
                        {
                            if (DelimitNumber < 3)
                            {
                                this.AppendText(".");
                                DelimitNumber++;
                            }
                            else
                                e.Handled = true;
                        }
                    }
                    else
                    {   // added - MAC
                        // process the "."
                        if (DelimitNumber + 1 > 3) // cant have more than 3 dots (at least for IPv4)
                        {
                            //errorProvider1.SetError(this, "No more . please!");
                            e.Handled = true; // dont add 4th dot
                            this.Text.TrimEnd(e.KeyChar);
                        }
                        else
                        {	// got the right number, but don't allow two in a row
                            if (this.Text.EndsWith("."))
                            {
                                //errorProvider1.SetError(this, "Can't do two dots in a row");
                                e.Handled = true;
                            }
                            else
                            {	// ok, add the dot
                                DelimitNumber++;
                            }
                        }
                    }
                }
                else
                {
                    e.Handled = false;
                    if ((len - indx) == 1)
                    {
                        DelimitNumber--;
                        if (indx > -1)
                        {
                            digitPos = len - indx;
                        }
                        else
                            digitPos--;
                    }
                    else
                    {
                        if (indx > -1)
                            digitPos = len - indx - 1;
                        else
                            digitPos = len - 1;
                    }
                }
            }
            else
            {
                e.Handled = true;
                //errorProvider1.SetError(this, "Only valid for Digit and dot");
            }
        }
        bool CheckDayOfMonth(int mon, int day)
        {
            bool ret = true;
            if (day == 0) ret = false;
            switch (mon)
            {
                case 1:
                    if (day > 31)
                        ret = false;
                    break;
                case 2:
                    System.DateTime moment = DateTime.Now;
                    int year = moment.Year;
                    int d = ((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28;
                    if (day > d)
                        ret = false;
                    break;
                case 3:
                    if (day > 31)
                        ret = false;
                    break;
                case 4:
                    if (day > 30)
                        ret = false;
                    break;
                case 5:
                    if (day > 31)
                        ret = false;
                    break;
                case 6:
                    if (day > 30)
                        ret = false;
                    break;
                case 7:
                    if (day > 31)
                        ret = false;
                    break;
                case 8:
                    if (day > 31)
                        ret = false;
                    break;
                case 9:
                    if (day > 30)
                        ret = false;
                    break;
                case 10:
                    if (day > 31)
                        ret = false;
                    break;
                case 11:
                    if (day > 30)
                        ret = false;
                    break;
                case 12:
                    if (day > 31)
                        ret = false;
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

    }
    public static class Cultures
    {
        ////http://www.c-sharpcorner.com/UploadFile/0f68f2/converting-a-number-in-currency-format-for-different-culture/

        public static readonly CultureInfo UnitedKingdom = CultureInfo.GetCultureInfo("en-GB");
        public static readonly CultureInfo Pakistan = CultureInfo.GetCultureInfo("ur-PK");
        public static readonly CultureInfo USA = CultureInfo.GetCultureInfo("en-US");
    }
}
