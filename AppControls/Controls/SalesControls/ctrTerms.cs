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

namespace AppControls
{
    public partial class ctrTerms : BaseControl
    {
        public ctrTerms()
        {
            InitializeComponent();

            //------ DueBy -----------------------------------------------------------------
            rdoIsDueByDate.CheckedChanged += rdoIsDueByDate_CheckedChanged;
            cboDueByDayOfTheD1.SelectionChangeCommitted += cboDueByDayOfTheD1_SelectionChangeCommitted;
            cboDueByMonthD1.SelectionChangeCommitted += cboDueByMonthD1_SelectionChangeCommitted;
            rdoIsDueByDays.CheckedChanged += rdoIsDueByDays_CheckedChanged;
            txtDueByDaysD1.TextChanged += txtDueByDaysD1_TextChanged;
            //------ Discount1 -----------------------------------------------------------------
            numDiscount1.ValueChanged += numDiscount1_ValueChanged;
            rdoIsDiscount1ByDate.CheckedChanged += rdoIsDiscount1ByDate_CheckedChanged;
            cboDiscount1DayOfTheD1.SelectionChangeCommitted += cboDiscount1DayOfTheD1_SelectionChangeCommitted;
            cboDiscount1MonthD1.SelectionChangeCommitted += cboDiscount1MonthD1_SelectionChangeCommitted;
            rdoIsDiscount1ByDays.CheckedChanged += rdoIsDiscount1ByDays_CheckedChanged;
            txtDiscount1ByDaysD1.ValueChanged += txtDiscount1ByDaysD1_ValueChanged;
            rdoIsDiscount1DontUse.CheckedChanged += rdoIsDiscount1DontUse_CheckedChanged;
            //------ Discount2 -----------------------------------------------------------------
            numDiscount2.ValueChanged += numDiscount2_ValueChanged;
            rdoIsDiscount2ByDate.CheckedChanged += rdoIsDiscount2ByDate_CheckedChanged;
            cboDiscount2DayOfTheD1.SelectionChangeCommitted += cboDiscount2DayOfTheD1_SelectionChangeCommitted;
            cboDiscount2MonthD1.SelectionChangeCommitted += cboDiscount2MonthD1_SelectionChangeCommitted;
            rdoIsDiscount2ByDays.CheckedChanged += rdoIsDiscount2ByDays_CheckedChanged;
            txtDiscount2ByDaysD1.ValueChanged += txtDiscount2ByDaysD1_ValueChanged;
            rdoIsDiscount2DontUse.CheckedChanged += rdoIsDiscount2DontUse_CheckedChanged;
            //------ Discount3 -----------------------------------------------------------------
            numDiscount3.ValueChanged += numDiscount3_ValueChanged;
            rdoIsDiscount3ByDate.CheckedChanged += rdoIsDiscount3ByDate_CheckedChanged;
            cboDiscount3DayOfTheD1.SelectionChangeCommitted += cboDiscount3DayOfTheD1_SelectionChangeCommitted;
            cboDiscount3MonthD1.SelectionChangeCommitted += cboDiscount3MonthD1_SelectionChangeCommitted;
            rdoIsDiscount3ByDays.CheckedChanged += rdoIsDiscount3ByDays_CheckedChanged;
            txtDiscount3ByDaysD1.ValueChanged += txtDiscount3ByDaysD1_ValueChanged;
            rdoIsDiscount3DontUse.CheckedChanged += rdoIsDiscount3DontUse_CheckedChanged;

        }

        #region "DueBy"
        //-----------------------------------------------------------------------------------
        void rdoIsDueByDate_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDueByDate.Checked)
                {
                    cboDueByDayOfTheD1.Enabled = true;
                    cboDueByMonthD1.Enabled = true;
                    txtDueByDaysD1.Enabled = false;
                    txtDueByDaysD1.Text = "0";
                }
                else
                {
                    cboDueByDayOfTheD1.SelectedValue = -1;
                    cboDueByDayOfTheD1.Enabled = false;
                    cboDueByMonthD1.SelectedValue = -1;
                    cboDueByMonthD1.Enabled = false;
                    txtDueByDaysD1.Enabled = true;
                }
            }
        }
        void cboDueByDayOfTheD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    if (cboDueByMonthD1.SelectedIndex < 0)
                        cboDueByMonthD1.SelectedIndex = 0;

                    string txt = (((System.Data.DataRowView)(cboDueByDayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                    string txt1 = (((System.Data.DataRowView)(cboDueByMonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                    txtDueByDescription.Text = txt + " of " + txt1 + " Month.";
                }
                catch { }
            }
        }
        void cboDueByMonthD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    if (cboDueByDayOfTheD1.SelectedIndex < 0)
                        cboDueByDayOfTheD1.SelectedIndex = 0;

                    string txt = (((System.Data.DataRowView)(cboDueByDayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                    string txt1 = (((System.Data.DataRowView)(cboDueByMonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                    txtDueByDescription.Text = txt + " of " + txt1 + " Month.";
                }
                catch { }
            }
        }
        void rdoIsDueByDays_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDueByDays.Checked)
                {

                    if (!string.IsNullOrEmpty(txtDueByDaysD1.Text.ToString().Trim()))
                    {
                        string txt = txtDueByDaysD1.Text.ToString().Trim();
                        txtDueByDescription.Text = txt + " Days.";
                    }
                    else
                        txtDueByDescription.Text = "0 Days.";
                }
            }
        }
        void txtDueByDaysD1_TextChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (!string.IsNullOrEmpty(txtDueByDaysD1.Text.ToString().Trim()))
                {
                    string txt = txtDueByDaysD1.Text.ToString().Trim();
                    txtDueByDescription.Text = txt + " Days.";
                }
                else
                    txtDueByDescription.Text = "0 Days.";
            }
        }
        //-----------------------------------------------------------------------------------  
        #endregion
        #region "Discount1"
        void numDiscount1_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    if (!string.IsNullOrEmpty(numDiscount1.Value.ToString().Trim()))
                    {
                        string txt = numDiscount1.Value.ToString().Trim();
                        if (rdoIsDiscount1ByDate.Checked)
                        {
                            string txt0 = (((System.Data.DataRowView)(cboDiscount1DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                            string txt1 = (((System.Data.DataRowView)(cboDiscount1MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                            txt += "% " + txt0 + " of " + txt1 + " Month.";
                        }
                        if (rdoIsDiscount1ByDays.Checked)
                        {
                            string txt0 = txtDiscount1ByDaysD1.Value.ToString().Trim();
                            txt += "% " + txt0 + " Days.";
                        }
                        txtDiscount1Description.Text = txt;
                    }
                    else
                        txtDiscount1Description.Text = "0 %";
                }
                catch { }
            }
        }
        void rdoIsDiscount1ByDate_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount1ByDate.Checked)
                {
                    numDiscount1.Enabled = true;
                    cboDiscount1DayOfTheD1.Enabled = true;
                    cboDiscount1MonthD1.Enabled = true;
                    txtDiscount1ByDaysD1.Enabled = false;
                    txtDiscount1ByDaysD1.Text = "0";
                }
            }
        }
        void cboDiscount1DayOfTheD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount1.Value.ToString().Trim();
                    if (rdoIsDiscount1ByDate.Checked)
                    {
                        if (cboDiscount1MonthD1.SelectedIndex < 0)
                            cboDiscount1MonthD1.SelectedIndex = 0;

                        string txt0 = (((System.Data.DataRowView)(cboDiscount1DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount1MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount1Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void cboDiscount1MonthD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount1.Value.ToString().Trim();
                    if (rdoIsDiscount1ByDate.Checked)
                    {
                        string txt0 = (((System.Data.DataRowView)(cboDiscount1DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount1MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount1Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void rdoIsDiscount1ByDays_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount1ByDays.Checked)
                {

                    cboDiscount1DayOfTheD1.SelectedValue = -1;
                    cboDiscount1MonthD1.SelectedValue = -1;

                    numDiscount1.Enabled = true;
                    cboDiscount1DayOfTheD1.Enabled = false;
                    cboDiscount1MonthD1.Enabled = false;
                    txtDiscount1ByDaysD1.Enabled = true;
                    txtDiscount1ByDaysD1.Value = 0;
                    string txt = numDiscount1.Value.ToString().Trim();
                    txtDiscount1Description.Text = txt + "% of 0 Days";
                }
            }
        }
        void txtDiscount1ByDaysD1_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount1ByDays.Checked)
                {
                    string txt = numDiscount1.Value.ToString().Trim();
                    string txt1 = txtDiscount1ByDaysD1.Value.ToString().Trim();
                    txtDiscount1Description.Text = txt + "% of " + txt1 + " Days";
                }
            }
        }
        void rdoIsDiscount1DontUse_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount1DontUse.Checked)
                {
                    numDiscount1.Enabled = false;
                    numDiscount1.Value = 0;
                    cboDiscount1DayOfTheD1.Enabled = false;
                    cboDiscount1DayOfTheD1.SelectedValue = 0;
                    cboDiscount1MonthD1.Enabled = false;
                    cboDiscount1MonthD1.SelectedValue = 0;
                    txtDiscount1ByDaysD1.Enabled = false;
                    txtDiscount1ByDaysD1.Value = 0;
                }
            }
        }
        #endregion
        #region "Discount2"
        void numDiscount2_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    if (!string.IsNullOrEmpty(numDiscount2.Value.ToString().Trim()))
                    {
                        string txt = numDiscount2.Value.ToString().Trim();
                        if (rdoIsDiscount2ByDate.Checked)
                        {
                            string txt0 = (((System.Data.DataRowView)(cboDiscount2DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                            string txt1 = (((System.Data.DataRowView)(cboDiscount2MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                            txt += "% " + txt0 + " of " + txt1 + " Month.";
                        }
                        if (rdoIsDiscount2ByDays.Checked)
                        {
                            string txt0 = txtDiscount2ByDaysD1.Value.ToString().Trim();
                            txt += "% " + txt0 + " Days.";
                        }
                        txtDiscount2Description.Text = txt;
                    }
                    else
                        txtDiscount2Description.Text = "0 %";
                }
                catch { }
            }
        }
        void rdoIsDiscount2ByDate_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount2ByDate.Checked)
                {
                    numDiscount2.Enabled = true;
                    cboDiscount2DayOfTheD1.Enabled = true;
                    cboDiscount2MonthD1.Enabled = true;
                    txtDiscount2ByDaysD1.Enabled = false;
                    txtDiscount2ByDaysD1.Text = "0";
                }
            }
        }
        void cboDiscount2DayOfTheD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount2.Value.ToString().Trim();
                    if (rdoIsDiscount2ByDate.Checked)
                    {
                        if (cboDiscount2MonthD1.SelectedIndex < 0)
                            cboDiscount2MonthD1.SelectedIndex = 0;

                        string txt0 = (((System.Data.DataRowView)(cboDiscount2DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount2MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount2Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void cboDiscount2MonthD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount2.Value.ToString().Trim();
                    if (rdoIsDiscount2ByDate.Checked)
                    {
                        string txt0 = (((System.Data.DataRowView)(cboDiscount2DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount2MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount2Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void rdoIsDiscount2ByDays_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount2ByDays.Checked)
                {

                    cboDiscount2DayOfTheD1.SelectedValue = -1;
                    cboDiscount2MonthD1.SelectedValue = -1;

                    numDiscount2.Enabled = true;
                    cboDiscount2DayOfTheD1.Enabled = false;
                    cboDiscount2MonthD1.Enabled = false;
                    txtDiscount2ByDaysD1.Enabled = true;
                    txtDiscount2ByDaysD1.Value = 0;
                    string txt = numDiscount2.Value.ToString().Trim();
                    txtDiscount2Description.Text = txt + "% of 0 Days";
                }
            }
        }
        void txtDiscount2ByDaysD1_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount2ByDays.Checked)
                {
                    string txt = numDiscount2.Value.ToString().Trim();
                    string txt1 = txtDiscount2ByDaysD1.Value.ToString().Trim();
                    txtDiscount2Description.Text = txt + "% of " + txt1 + " Days";
                }
            }
        }
        void rdoIsDiscount2DontUse_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount2DontUse.Checked)
                {
                    numDiscount2.Enabled = false;
                    numDiscount2.Value = 0;
                    cboDiscount2DayOfTheD1.Enabled = false;
                    cboDiscount2DayOfTheD1.SelectedValue = 0;
                    cboDiscount2MonthD1.Enabled = false;
                    cboDiscount2MonthD1.SelectedValue = 0;
                    txtDiscount2ByDaysD1.Enabled = false;
                    txtDiscount2ByDaysD1.Value = 0;
                }
            }
        }
        #endregion
        #region "Discount3"
        void numDiscount3_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    if (!string.IsNullOrEmpty(numDiscount3.Value.ToString().Trim()))
                    {
                        string txt = numDiscount3.Value.ToString().Trim();
                        if (rdoIsDiscount3ByDate.Checked)
                        {
                            string txt0 = (((System.Data.DataRowView)(cboDiscount3DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                            string txt1 = (((System.Data.DataRowView)(cboDiscount3MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                            txt += "% " + txt0 + " of " + txt1 + " Month.";
                        }
                        if (rdoIsDiscount3ByDays.Checked)
                        {
                            string txt0 = txtDiscount3ByDaysD1.Value.ToString().Trim();
                            txt += "% " + txt0 + " Days.";
                        }
                        txtDiscount3Description.Text = txt;
                    }
                    else
                        txtDiscount3Description.Text = "0 %";
                }
                catch { }
            }
        }
        void rdoIsDiscount3ByDate_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount3ByDate.Checked)
                {
                    numDiscount3.Enabled = true;
                    cboDiscount3DayOfTheD1.Enabled = true;
                    cboDiscount3MonthD1.Enabled = true;
                    txtDiscount3ByDaysD1.Enabled = false;
                    txtDiscount3ByDaysD1.Text = "0";
                }
            }
        }
        void cboDiscount3DayOfTheD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount3.Value.ToString().Trim();
                    if (rdoIsDiscount3ByDate.Checked)
                    {
                        if (cboDiscount3MonthD1.SelectedIndex < 0)
                            cboDiscount3MonthD1.SelectedIndex = 0;

                        string txt0 = (((System.Data.DataRowView)(cboDiscount3DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount3MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount3Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void cboDiscount3MonthD1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                try
                {
                    string txt = numDiscount3.Value.ToString().Trim();
                    if (rdoIsDiscount3ByDate.Checked)
                    {
                        string txt0 = (((System.Data.DataRowView)(cboDiscount3DayOfTheD1.SelectedItem)).Row).ItemArray[1].ToString();
                        string txt1 = (((System.Data.DataRowView)(cboDiscount3MonthD1.SelectedItem)).Row).ItemArray[1].ToString();
                        txtDiscount3Description.Text = txt + "% " + txt0 + " of " + txt1 + " Month.";
                    }
                }
                catch { }
            }
        }
        void rdoIsDiscount3ByDays_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount3ByDays.Checked)
                {

                    cboDiscount3DayOfTheD1.SelectedValue = -1;
                    cboDiscount3MonthD1.SelectedValue = -1;

                    numDiscount3.Enabled = true;
                    cboDiscount3DayOfTheD1.Enabled = false;
                    cboDiscount3MonthD1.Enabled = false;
                    txtDiscount3ByDaysD1.Enabled = true;
                    txtDiscount3ByDaysD1.Value = 0;
                    string txt = numDiscount3.Value.ToString().Trim();
                    txtDiscount3Description.Text = txt + "% of 0 Days";
                }
            }
        }
        void txtDiscount3ByDaysD1_ValueChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount3ByDays.Checked)
                {
                    string txt = numDiscount3.Value.ToString().Trim();
                    string txt1 = txtDiscount3ByDaysD1.Value.ToString().Trim();
                    txtDiscount3Description.Text = txt + "% of " + txt1 + " Days";
                }
            }
        }
        void rdoIsDiscount3DontUse_CheckedChanged(object sender, EventArgs e)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (rdoIsDiscount3DontUse.Checked)
                {
                    numDiscount3.Enabled = false;
                    numDiscount3.Value = 0;
                    cboDiscount3DayOfTheD1.Enabled = false;
                    cboDiscount3DayOfTheD1.SelectedValue = 0;
                    cboDiscount3MonthD1.Enabled = false;
                    cboDiscount3MonthD1.SelectedValue = 0;
                    txtDiscount3ByDaysD1.Enabled = false;
                    txtDiscount3ByDaysD1.Value = 0;
                }
            }
        }
        #endregion
        protected override void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorEditItem_Click(sender, e);

            //-----DueBy---------------------------
            if (rdoIsDueByDate.Checked)
            {
                cboDueByDayOfTheD1.Enabled = true;
                cboDueByMonthD1.Enabled = true;
            }
            else
            {
                cboDueByDayOfTheD1.Enabled = false;
                cboDueByMonthD1.Enabled = false;
            }
            if (rdoIsDueByDays.Checked)
                txtDueByDaysD1.Enabled = true;
            else
                txtDueByDaysD1.Enabled = false;

            //-----Discount1----------------------
            if (rdoIsDiscount1DontUse.Checked)
            {
                numDiscount1.Enabled = false;
                cboDiscount1DayOfTheD1.Enabled = false;
                cboDiscount1MonthD1.Enabled = false;
                txtDiscount1ByDaysD1.Enabled = false;
            }
            if (!rdoIsDiscount1ByDate.Checked)
            {
                cboDiscount1DayOfTheD1.Enabled = false;
                cboDiscount1MonthD1.Enabled = false;
            }
            if (!rdoIsDiscount1ByDays.Checked)
                txtDiscount1ByDaysD1.Enabled = false;

            //-----Discount2----------------------
            if (rdoIsDiscount2DontUse.Checked)
            {
                numDiscount2.Enabled = false;
                cboDiscount2DayOfTheD1.Enabled = false;
                cboDiscount2MonthD1.Enabled = false;
                txtDiscount2ByDaysD1.Enabled = false;
            }
            if (!rdoIsDiscount2ByDate.Checked)
            {
                cboDiscount2DayOfTheD1.Enabled = false;
                cboDiscount2MonthD1.Enabled = false;
            }
            if (!rdoIsDiscount2ByDays.Checked)
                txtDiscount2ByDaysD1.Enabled = false;

            //-----Discount3----------------------
            if (rdoIsDiscount3DontUse.Checked)
            {
                numDiscount3.Enabled = false;
                cboDiscount3DayOfTheD1.Enabled = false;
                cboDiscount3MonthD1.Enabled = false;
                txtDiscount3ByDaysD1.Enabled = false;
            }
            if (!rdoIsDiscount3ByDate.Checked)
            {
                cboDiscount3DayOfTheD1.Enabled = false;
                cboDiscount3MonthD1.Enabled = false;
            }
            if (!rdoIsDiscount3ByDays.Checked)
                txtDiscount3ByDaysD1.Enabled = false;

        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                base.bindingNavigatorAddNewItem_Click(sender, e);
                //-------------------------------
                DataRowView curRow = (DataRowView)objBindingSource.Current;
                curRow.BeginEdit();

                curRow["IsCash"] = true;
                curRow["IsVendorOnly"] = false;
                curRow["DiscountTypeID"] = 1;
                curRow["IsDueByDays"] = 1;
                curRow["DueByDaysD1"] = false;
                curRow["DueByDescription"] = "0 Days.";

                curRow["Discount1"] = 0;
                curRow["Discount1ByDaysD1"] = false;
                curRow["IsDiscount1DontUse"] = true;
                curRow["Discount1Description"] = "";

                curRow["Discount2"] = 0;
                curRow["Discount2ByDaysD1"] = false;
                curRow["IsDiscount2DontUse"] = true;
                curRow["Discount2Description"] = "";

                curRow["Discount3"] = 0;
                curRow["Discount3ByDaysD1"] = false;
                curRow["IsDiscount3DontUse"] = true;
                curRow["Discount3Description"] = "";

                curRow.EndEdit();

            }
            catch { }
        }

    }
}
