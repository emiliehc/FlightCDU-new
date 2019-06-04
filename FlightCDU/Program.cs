using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightCDU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // public properties
        public static string input = "";
        public static string message = "";
        public static int inputMode = 0;
        /*
         * input mode:
         * 0: available
         * 1: message
         * 2: delete
         */



        public static CDU cdu;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cdu = new CDU();
            Application.Run(cdu);
        }

        public static void ShowMessage(string txt)
        {
            inputMode = 1;
            message = txt;
        }
    }
}
