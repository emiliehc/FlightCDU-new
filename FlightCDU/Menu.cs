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
            Program.WriteText("R", 6, "CDU TEST>");
        }

        public static void BtnClicked(string side, int num)
        {
            switch (side)
            {
                case "L":
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
    }
}
