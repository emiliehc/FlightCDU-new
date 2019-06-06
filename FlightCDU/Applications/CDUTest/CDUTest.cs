using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU.Applications.CDUTest
{
    class CDUTest
    {
        public static void Start()
        {
            Program.CDUClear();
            Program.activeProgram = 1;
            Program.WriteTitle("CDU TEST MENU");
            Program.WritePage("1/1");
            // message output test
            Program.WriteLabel("L", 1, "MSG OUTPUT TEST");
            Program.WriteText("L", 1, "<RUN");
            // text input test
            Program.WriteLabel("L", 2, "TEXT INPUT TEST");
            Program.WriteText("L", 2, "- - - - -");

            // back to the menu
            Program.WriteText("L", 6, "<MENU");
        }

        public static void BtnClicked(string side, int num)
        {
            switch (side)
            {
                case "L":
                    switch (num)
                    {
                        case 1:
                            L1Clicked();
                            break;
                        case 2:
                            L2Clicked();
                            break;
                        case 6:
                            L6Clicked();
                            break;
                    }
                    break;
                case "R":
                    break;
            }
        }

        private static void L1Clicked()
        {
            Program.ShowMessage("MESSAGE");
        }

        private static void L2Clicked()
        {
            if (Program.inputMode == 0)
            {
                if (!Program.input.Equals(""))
                {
                    Program.WriteText("L", 2, Program.input);
                    Program.input = "";
                }
                else
                {
                    Program.ShowMessage("INVALID ENTRY");
                }
            } else if (Program.inputMode == 2)
            {
                Program.WriteText("L", 2, "- - - - -");
                Program.inputMode = 0;
            }
        }

        private static void L6Clicked()
        {
            CDUMenu.Start();
        }
    }
}
