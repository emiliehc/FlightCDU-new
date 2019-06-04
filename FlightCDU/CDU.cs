using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightCDU
{
    public partial class CDU : Form
    {

        

        public CDU()
        {
            InitializeComponent();
        }

        private void CDU_Load(object sender, EventArgs e)
        {

        }

        private void btnKeyPressed(object sender, EventArgs e)
        {
            string txtEntered = ((Button)sender).Text;
            if (txtEntered.Equals("SP"))
            {
                txtEntered = " ";
            }
            Program.input += txtEntered;
            ActionInterpreter.showInput();
        }

        private void SideKeyPressed(object sender, EventArgs e)
        {

        }
    }
}
