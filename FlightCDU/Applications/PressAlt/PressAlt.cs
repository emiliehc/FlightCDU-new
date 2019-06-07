using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU.Applications.PressAlt
{
    class PressAlt
    {
        private static double altSetting;

        public static void Start()
        {
            Program.CDUClear();
            Program.activeProgram = 2;
            // init the text
            Program.WriteTitle("PRESS ALT CALC");
            Program.WritePage("1/1");
            // back to menu
            Program.WriteText("L", 6, "<MENU");
            // input for the altimeter setting or the qnh
            Program.WriteLabel("L", 1, "ALTIMETER SETTING");
            Program.WriteText("L", 1, "▯▯.▯▯");
            Program.WriteLabel("R", 1, "QNH");
            Program.WriteText("R", 1, "▯▯▯▯");
            // field elevation label
            Program.WriteLabel("L", 2, "FIELD ELEVATION");
            Program.WriteText("L", 2, "▯▯▯▯▯");
            // output label
            Program.WriteLabel("L", 4, "PRESSURE ALTITUDE");
            Program.WriteText("L", 4, "- - - - -");
            // run label
            Program.WriteText("R", 4, "CALC>");
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
