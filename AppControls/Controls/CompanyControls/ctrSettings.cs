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
using DBModule;
using System32;

namespace AppControls
{
    public partial class ctrSettings : BaseControl
    {
        bool IsSaveThemeColor = false;
        int backColor;
        int foreColor;
        int recID;

        public ctrSettings()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.ctrSettings_Load);
            btnLightSteelBlue.Click += btn_Click;
            btnCornflowerBlue.Click += btn_Click;
            btnRoyalBlue.Click += btn_Click;
            btnSilver.Click += btn_Click;
            btnLightSlateGray.Click += btn_Click;
            btnDimGray.Click += btn_Click;
            btnBackColor.Click += btn_Click;
            btnForeColor.Click += btn_Click;

        }
        void btn_Click(object sender, EventArgs e)
        {
            IsSaveThemeColor = true;
            string btnTxt = ((Button)sender).Text.ToString();
            switch(btnTxt)
            {
                case "LightSteelBlue":
                    backColor = Color.LightSteelBlue.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "CornflowerBlue":
                    backColor = Color.CornflowerBlue.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "RoyalBlue":
                    backColor = Color.RoyalBlue.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "Silver":
                    backColor = Color.Silver.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "LightSlateGray":
                    backColor = Color.LightSlateGray.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "DimGray":
                    backColor = Color.DimGray.ToArgb();
                    foreColor = Color.White.ToArgb();
                    break;
                case "BackColor":
                    setBackColor();
                    break;
                case "ForeColor":
                    setForeColor();
                    break;
                default :
                    break;
            }            
        }
        void setBackColor()
        {
            
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnCustom.BackColor = colorDlg.Color;
                backColor = btnCustom.BackColor.ToArgb();
                foreColor = btnCustom.ForeColor.ToArgb();                
            }
        }
        void setForeColor()
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.White;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnCustom.ForeColor = colorDlg.Color;
                backColor = btnCustom.BackColor.ToArgb();
                foreColor = btnCustom.ForeColor.ToArgb();                
            }
        }
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {            
            base.bindingNavigatorEditItem_Click(sender, e);

            DataRowView curRow = (DataRowView)objBindingSource.Current;
            recID = Convert.ToInt32(curRow["ID"]);
        }
        protected override void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {            
            base.bindingNavigatorCancelItem_Click(sender, e);
        }
        protected override void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveThemeColor();
            base.bindingNavigatorSaveItem_Click(sender,e);
            //base.ApplySetting();
        }
        void SaveThemeColor()
        {
            if (IsSaveThemeColor)
            {
                if ((backColor != 0) && (foreColor != 0) && (recID > 0))
                {
                    if (dbClass.obj.SaveThemeColor(recID, backColor, foreColor))
                    {
                        StaticInfo.ctrBackColor = Color.FromArgb(backColor);
                        StaticInfo.ctrLabelForeColor = Color.FromArgb(foreColor);
                        IsSaveThemeColor = false;
                    }
                }
            }
        }
        private void ctrSettings_Load(object sender, EventArgs e)
        {
            btnLightSteelBlue.BackColor = Color.LightSteelBlue;
            btnLightSteelBlue.ForeColor = Color.White;

            DataTable dt = objDataSet.Tables["WarehouseSettings"];
            backColor = Convert.ToInt32(dt.Rows[0]["BackColor"]);
            foreColor = Convert.ToInt32(dt.Rows[0]["ForeColor"]);
            btnCustom.BackColor = Color.FromArgb(backColor);
            btnCustom.ForeColor = Color.FromArgb(foreColor);

        }

        

    }
}
