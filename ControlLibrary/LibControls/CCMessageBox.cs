﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public partial class CCMessageBox : Form
    {
        string sLabel = string.Empty;
        string sMessage = string.Empty;
        public enum iMessageBoxButtons
        {
            //AbortRetryIgnore,
            OK,
            //RetryCancel,
            OKCancel,
            YesNo
            //YesNoCancel
        };
        public iMessageBoxButtons IMessageBoxButtons;

        public enum iMessageBoxIcon
        {
            //Asterisk,
            Error,
            //Exclamation,
            //Hand,
            Information,
            None,
            Question,
            //Stop,
            Warning
        };
        public iMessageBoxIcon IMessageBoxIcon;

        public CCMessageBox()
        {
            InitializeComponent();        
        }
        public CCMessageBox(string text)
        {
            InitializeComponent();

            this.sLabel = "Information";
            this.sMessage = text;
        }
        public CCMessageBox(string text, string Caption)
        {
            InitializeComponent();
                        
            this.sMessage = text;
            this.sLabel = Caption;
        }
        public CCMessageBox(string text, string Caption, iMessageBoxButtons buttons)
        {
            InitializeComponent();
                        
            this.sMessage = text;
            this.sLabel = Caption;
            this.IMessageBoxButtons = buttons;
        }
        public CCMessageBox(string text, iMessageBoxButtons buttons, iMessageBoxIcon icon)
        {
            InitializeComponent();

            this.lblTitle.Text = "Information";
            this.sMessage = text;
            this.IMessageBoxButtons = buttons;
            this.IMessageBoxIcon = icon;
        }
        public CCMessageBox(string text, string Caption, iMessageBoxButtons buttons, iMessageBoxIcon icon)
        {
            InitializeComponent();
                        
            this.sMessage = text;
            this.sLabel = Caption;
            this.IMessageBoxButtons = buttons;
            this.IMessageBoxIcon = icon;
        }
        private void CCMessageBox_Load(object sender, EventArgs e)
        {
            this.BackColor = StaticInfo.ctrBackColor;            
            lblMessage.ForeColor = StaticInfo.ctrLabelForeColor;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblTitle.Text = this.sLabel;            
            this.lblMessage.Text = this.sMessage;
            switch (this.IMessageBoxButtons)
            {
                case iMessageBoxButtons.OK:
                    this.btn2.Visible = false;
                    this.setIcon();
                    break;
                case iMessageBoxButtons.OKCancel:
                    this.btn2.Visible = true;
                    this.btn2.Text = "OK";
                    this.btn1.Text = "Cancel";
                    this.setIcon();
                    break;
                case iMessageBoxButtons.YesNo:
                    this.btn2.Visible = true;
                    this.btn2.Text = "Yes";
                    this.btn1.Text = "No";
                    this.setIcon();
                    break;
                default:
                    this.btn2.Visible = false;
                    this.setIcon();
                    break;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            switch (this.IMessageBoxButtons)
            {
                case iMessageBoxButtons.OK:
                    this.Close();
                    break;
                case iMessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                    break;
                case iMessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.No;
                    this.Close();
                    break;
                default:
                    this.btn2.Visible = false;
                    break;
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            switch (this.IMessageBoxButtons)
            {
                case iMessageBoxButtons.OK:
                    this.Close();
                    break;
                case iMessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                    break;
                case iMessageBoxButtons.YesNo:
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                    break;
                default:

                    break;
            }

        }

        private void setIcon()
        {
            switch (this.IMessageBoxIcon)
            {
                case iMessageBoxIcon.Error:
                    //this.picBoxIcon.Image = 
                    break;
                case iMessageBoxIcon.Information:
                    this.lblTitle.Text = "Information";
                    break;
                case iMessageBoxIcon.Question:

                    break;
                case iMessageBoxIcon.Warning:

                    break;
                case iMessageBoxIcon.None:

                    break;
                default:
                    this.btn2.Visible = false;
                    break;
            }
        }
    }
}
