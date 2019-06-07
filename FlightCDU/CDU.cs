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
        private Thread t; // text input synchronisation thread

        public CDU()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(SyncText));
            t.Start();
            // put the labels into the label arrays
            Program.lblLeft[0] = lblL1;
            Program.lblLeft[1] = lblL2;
            Program.lblLeft[2] = lblL3;
            Program.lblLeft[3] = lblL4;
            Program.lblLeft[4] = lblL5;
            Program.lblLeft[5] = lblL6;
            Program.lblRight[0] = lblR1;
            Program.lblRight[1] = lblR2;
            Program.lblRight[2] = lblR3;
            Program.lblRight[3] = lblR4;
            Program.lblRight[4] = lblR5;
            Program.lblRight[5] = lblR6;
            Program.txtLeft[0] = txtL1;
            Program.txtLeft[1] = txtL2;
            Program.txtLeft[2] = txtL3;
            Program.txtLeft[3] = txtL4;
            Program.txtLeft[4] = txtL5;
            Program.txtLeft[5] = txtL6;
            Program.txtRight[0] = txtR1;
            Program.txtRight[1] = txtR2;
            Program.txtRight[2] = txtR3;
            Program.txtRight[3] = txtR4;
            Program.txtRight[4] = txtR5;
            Program.txtRight[5] = txtR6;
            Program.title = lblTitle;
            Program.page = lblPage;
        }

        private void CDU_Load(object sender, EventArgs e)
        {
            Program.CDUStartup();
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
            try
            {
                string btnName = ((Button)sender).Name;
                string side = btnName.Substring(3, 1);
                int num = int.Parse(btnName.Substring(4, 1));
                switch (Program.activeProgram)
                {
                    // menu
                    case 0:
                        CDUMenu.BtnClicked(side, num);
                        break;
                    case 1:
                        Applications.CDUTest.CDUTest.BtnClicked(side, num);
                        break;
                    case 2:
                        Applications.PressAlt.PressAlt.BtnClicked(side, num);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                Program.ShowMessage("NOT IMPLEMENTED");
            }
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
