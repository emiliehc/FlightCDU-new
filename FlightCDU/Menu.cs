using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU
{
    class CDUMenu
    {
        public static void Start()
        {
            Program.CDUClear();
            Program.activeProgram = 0;
            // init the text
            Program.WriteTitle("MENU");
            // cdu test
            Program.WriteText("R", 6, "CDU TEST>");
            // pressAlt
            Program.WriteText("L", 1, "<PRESS ALT");
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
                    }
                    break;
                case "R":
                    switch (num)
                    {
                        case 6:
                            R6Clicked();
                            break;
                    }
                    break;
            }
        }

        private static void R6Clicked()
        {
            Applications.CDUTest.CDUTest.Start();
        }

        private static void L1Clicked()
        {
            Applications.PressAlt.PressAlt.Start();
        }
    }
}
