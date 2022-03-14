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
using DBModule;

namespace AppControls
{
    public partial class ctrCompany : BaseControl
    {
        BindingSource WarehouseBS;
        public ctrCompany()
        {
            InitializeComponent();

            WarehouseBS = new BindingSource();
            this.Load += ctrCompany_Load;

            this.txtZipCode.KeyDown += txtZipCode_KeyDown;
        }

        void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadCountryByZipCode();
            }
        }



        void ctrCompany_Load(object sender, EventArgs e)
        {
            if (StaticInfo.userLevel <= 2)
            {
                this.btnBNMoveFirstItem.Visible = true;
                this.btnBNMovePreviousItem.Visible = true;
                this.BNSeparator.Visible = true;
                this.BNPositionItem.Visible = true;
                this.BNCountItem.Visible = true;
                this.BNSeparator1.Visible = true;
                this.btnBNMoveNextItem.Visible = true;
                this.btnBNMoveLastItem.Visible = true;
                this.BNSeparator2.Visible = true;

                this.btnBNEditItem.Enabled = true;
            }
            else
            {
                this.btnBNAddItem.Enabled = false;
                this.btnBNEditItem.Enabled = false;
                this.btnBNDeleteItem.Enabled = false;
                this.btnBNSaveItem.Enabled = false;
                this.btnBNCancelItem.Enabled = false;
                this.btnBNRefresh.Enabled = false;
            }

            loadCountryByZipCode();

        }

        void loadCountryByZipCode()
        {
            if (!string.IsNullOrEmpty(txtZipCode.Text.Trim()))
            {
                int zipcode = Convert.ToInt32(txtZipCode.Text.Trim());
                if (zipcode > 0)
                {
                    DataRow dr = dbClass.obj.getRowByZipCode(zipcode);
                    if (dr != null)
                    {
                        txtCountry.Text = Convert.ToString(dr["Country"]);
                        txtStateName.Text = Convert.ToString(dr["StateName"]);
                        txtStateInitial.Text = Convert.ToString(dr["StateInitial"]);
                        txtCityName.Text = Convert.ToString(dr["CityName"]);
                    }
                    else
                    {
                        txtCountry.Text = "";
                        txtStateName.Text = "";
                        txtStateInitial.Text = "";
                        txtCityName.Text = "";
                    }
                }
                else
                {
                    txtCountry.Text = "";
                    txtStateName.Text = "";
                    txtStateInitial.Text = "";
                    txtCityName.Text = "";
                }
            }
            else
            {
                txtCountry.Text = "";
                txtStateName.Text = "";
                txtStateInitial.Text = "";
                txtCityName.Text = "";
            }
        }

    }
}
