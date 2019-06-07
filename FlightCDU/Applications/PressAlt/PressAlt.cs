using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU.Applications.PressAlt
{
    class PressAlt
    {
        public static void Start()
        {
            Program.CDUClear();
            Program.activeProgram = 2;
            // init the text
            Program.WriteTitle("PRESS ALT CALC");
            Program.WritePage("1/1");
            // back to menu
            Program.WriteText("L", 6, "<MENU");
        }

        public static void BtnClicked(string side, int num)
        {
            switch (side)
            {
                case "L":
                    switch (num)
                    {
                        case 6:
                            L6Clicked();
                            break;
                    }
                    break;
                case "R":
                    break;
            }
        }

        private static void L6Clicked()
        {
            CDUMenu.Start();
        }
    }
}
