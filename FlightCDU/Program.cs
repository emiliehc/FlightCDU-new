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
         * Active program:
         * 0: Menu
         * 1: CDU Test
         */
        public static int activeProgram;
        public static Label[] lblLeft = new Label[6];
        public static Label[] lblRight = new Label[6];
        public static Label[] txtLeft = new Label[6];
        public static Label[] txtRight = new Label[6];
        public static Label title;
        public static Label page;



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

        /// <summary>
        /// Get the label text specified by the user
        /// </summary>
        /// <param name="side">the side, "L" or "R"</param>
        /// <param name="num">the key number, from 1 to 6</param>
        /// <returns>the text the user wants</returns>
        public static string GetLabelText(string side, int num) {
            switch (side)
            {
                case "L":
                    return lblLeft[num - 1].Text;
                case "R":
                    return lblRight[num - 1].Text;
            }
            return null;
        }

        /// <summary>
        /// Write the title of the CDU
        /// </summary>
        /// <param name="text">the title text</param>
        public static void WriteTitle(string text)
        {
            title.Text = text;
        }

        /// <summary>
        /// Write the page number of the CDU page
        /// </summary>
        /// <param name="text">the page number indication text</param>
        public static void WritePage(string text)
        {
            page.Text = text;
        }


        public static void CDUStartup()
        {
            CDUClear();
            // start the mcdu menu
            CDUMenu.Start();
        }

        /// <summary>
        /// clear all cdu texts
        /// </summary>
        public static void CDUClear()
        {
            for (int i = 1; i <= 6; i++)
            {
                WriteLabel("L", i, "");
                WriteLabel("R", i, "");
                WriteText("L", i, "");
                WriteText("R", i, "");
            }
            WriteTitle("");
            WritePage("");
        }
    }
}
