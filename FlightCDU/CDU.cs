using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightCDU
{
    public partial class CDU : Form
    {

        private delegate void callTextSync(string text);
        Thread t; // text input synchronisation thread
        Label[] lblLeft = new Label[6];
        Label[] lblRight = new Label[6];
        Label[] txtLeft = new Label[6];
        Label[] txtRight = new Label[6];

        public CDU()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(SyncText));
            t.Start();
            // put the labels into the label arrays
            lblLeft[0] = lblL1;
            lblLeft[1] = lblL2;
            lblLeft[2] = lblL3;
            lblLeft[3] = lblL4;
            lblLeft[4] = lblL5;
            lblLeft[5] = lblL6;
            lblRight[0] = lblR1;
            lblRight[1] = lblR2;
            lblRight[2] = lblR3;
            lblRight[3] = lblR4;
            lblRight[4] = lblR5;
            lblRight[5] = lblR6;
            txtLeft[0] = txtL1;
            txtLeft[1] = txtL2;
            txtLeft[2] = txtL3;
            txtLeft[3] = txtL4;
            txtLeft[4] = txtL5;
            txtLeft[5] = txtL6;
            txtRight[0] = txtR1;
            txtRight[1] = txtR2;
            txtRight[2] = txtR3;
            txtRight[3] = txtR4;
            txtRight[4] = txtR5;
            txtRight[5] = txtR6;
        }

        private void CDU_Load(object sender, EventArgs e)
        {
            lblInput.Text = "";
        }

        private void btnKeyPressed(object sender, EventArgs e)
        {
            // only when the inputbox is available can the user enter information
            if (Program.inputMode == 0)
            {
                string txtEntered = ((Button)sender).Text;
                if (txtEntered.Equals("SP"))
                {
                    txtEntered = " ";
                }
                Program.input += txtEntered;
                //ActionInterpreter.showInput();
            }
            
        }

        private void SideKeyPressed(object sender, EventArgs e)
        {

        }

        private void SyncText()
        {
            while (true)
            {
                try
                {
                    if (Program.inputMode == 0)
                    {
                        //Console.WriteLine(Program.input);
                        WriteText(Program.input);
                    }
                    else if (Program.inputMode == 1)
                    {
                        WriteText(Program.message);
                    }
                    else if (Program.inputMode == 2)
                    {
                        WriteText("DELETE");
                    }
                }
                catch (System.InvalidOperationException ex)
                {
                    Console.WriteLine(ex);
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        private void WriteText(string text)
        {
            if (lblInput.InvokeRequired)
            {
                var d = new callTextSync(WriteText);
                Invoke(d, new object[] { text });
            }
            else
            {
                lblInput.Text = text;
            }
        }

        private void CDU_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop the synchronisation when closing
            t.Abort();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (Program.inputMode == 0 && Program.input.Length > 0)
            {
                // clear the last character of the input
                Program.input = Program.input.Substring(0, Program.input.Length - 1);
            }
            else if (Program.inputMode == 1)
            {
                // clear the message and revert to input mode
                Program.message = "";
                Program.inputMode = 0;
            }
            else if (Program.inputMode == 2)
            {
                // clear the delete and revert to input mode
                Program.inputMode = 0;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Program.inputMode == 0 && Program.input.Equals(""))
            {
                Program.inputMode = 2;
            }
        }
    }
}
