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

namespace AppControls
{
    public partial class ctrBankAccount : BaseControl
    {        
        public ctrBankAccount()
        {
            InitializeComponent();
            btnAccountsList.Click += btnAccountsList_Click;
        }

        void btnAccountsList_Click(object sender, EventArgs e)
        {
            ctrAccountList ctrAccountList = new ctrAccountList();
            ctrAccountList.AccountSelected += AddAccountDetail_ObjectSelected;
            frmCtr ctrfrmCtr = new frmCtr("Select Account ...");            
            ctrfrmCtr.Height = ctrAccountList.Height + 40; ctrfrmCtr.Width = ctrAccountList.Width + 20;
            ctrfrmCtr.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ctrfrmCtr.frmPnl.Controls.Add(ctrAccountList);
            ctrfrmCtr.BringToFront();
            ctrfrmCtr.ShowDialog();
        }
        void AddAccountDetail_ObjectSelected(object sender, DataRow AccountRow)
        {
            if ((frmStatus == currentStatus.Add) || (frmStatus == currentStatus.Edit))
            {
                if (AccountRow != null)
                {
                    try
                    {
                        DataRowView curRow = (DataRowView)objBindingSource.Current;
                        curRow.BeginEdit();
                        curRow["AccountID"] = AccountRow["ID"];
                        curRow.EndEdit();
                    }
                    catch { }
                    //---------------------------------------------//       
                    //ctrfrmCtr.Close();
                }
            }
        }
    }
}
