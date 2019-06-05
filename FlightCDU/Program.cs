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
        public static Label[] lblLeft = new Label[6];
        public static Label[] lblRight = new Label[6];
        public static Label[] txtLeft = new Label[6];
        public static Label[] txtRight = new Label[6];


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

        /// <summary>
        /// write text to the texts
        /// </summary>
        /// <param name="side">the side, "L" or "R"</param>
        /// <param name="num">the key number, from 1 to 6</param>
        /// <param name="text">the actual text</param>
        public static void WriteText(string side, int num, string text)
        {
            switch(side)
            {
                case "L":
                    txtLeft[num - 1].Text = text;
                    break;
                case "R":
                    txtRight[num - 1].Text = text;
                    break;
            }
        }

        /// <summary>
        /// write text to the labels
        /// </summary>
        /// <param name="side">the side, "L" or "R"</param>
        /// <param name="num">the key number, from 1 to 6</param>
        /// <param name="text">the actual text</param>
        public static void WriteLabel(string side, int num, string text)
        {
            switch (side)
            {
                case "L":
                    lblLeft[num - 1].Text = text;
                    break;
                case "R":
                    lblRight[num - 1].Text = text;
                    break;
            }
        }
    }
}
