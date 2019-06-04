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

        public CDU()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(SyncText));
            t.Start();
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
                        lblInput.Text = Program.message;
                        WriteText(Program.message);
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
    }
}
