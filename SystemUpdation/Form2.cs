using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace SystemUpdation
{
    public partial class Form2 : Form
    {
        ThreadStart delegateRetrieveData;
        Thread mainThread;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnRetrieveData_Click(object sender, EventArgs e)
        {
            //initializations
            txtRetrievedData.Clear();
            prgStatus.Value = 0;

            //the methods that will be executed by the main thread is "retrieveData"
            delegateRetrieveData = new ThreadStart(retrieveData);
            mainThread = new Thread(delegateRetrieveData);

            //start the main thread
            mainThread.Start();

        }
        private void retrieveData()
        {
            //read all lines in the csv file
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ESS\Downloads\SampleCSVFile_11kb.csv");

            //set the max value for the progress bar
            if (prgStatus.InvokeRequired)
            {
                Invoke(new MethodInvoker(

                    delegate
                    {
                        prgStatus.Maximum = lines.Length;

                    }));
            }
            else
            {
                prgStatus.Maximum = lines.Length;
            }


            //read lines and add them in the TextBox
            foreach (string line in lines)
            {
                //thread-safe call: append line in TextBox
                if (txtRetrievedData.InvokeRequired)
                {
                    Invoke(new MethodInvoker(

                        delegate
                        {
                            txtRetrievedData.AppendText(@line);
                        }));
                }
                else
                {
                    txtRetrievedData.AppendText(@line);
                }


                //thread-safe call: update progress bar
                if (prgStatus.InvokeRequired)
                {
                    Invoke(new MethodInvoker(

                        delegate
                        {
                            prgStatus.Invoke(new updatebar(this.UpdateBarProgress));

                        }));
                }
                else
                {
                    prgStatus.Invoke(new updatebar(this.UpdateBarProgress));

                }
            }


        }
        //delegate for calling the UpdateBarProgress method
        public delegate void updatebar();
        private void UpdateBarProgress()
        {
            if (prgStatus.Value < prgStatus.Maximum)
            {
                prgStatus.Value += 1;

                //thread-safe call: update lblStatus value
                if (lblStatus.InvokeRequired)
                {
                    Invoke(new MethodInvoker(

                        delegate
                        {
                            lblStatus.Text = (((float)prgStatus.Value / (float)prgStatus.Maximum) * 100).ToString("0") + " %";

                        }));
                }
                else
                {
                    lblStatus.Text = (((float)prgStatus.Value / (float)prgStatus.Maximum) * 100).ToString("0") + " %";
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //abort main thread's execution
            mainThread.Abort();
        }

    }
}
