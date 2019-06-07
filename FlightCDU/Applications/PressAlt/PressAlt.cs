using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU.Applications.PressAlt
{
    class PressAlt
    {
        private static double altSetting = -123456;
        private static int fieldElvation = -123456;

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
            Program.WriteText("L", 1, "▯▯,▯▯");
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
                    switch (num)
                    {
                        case 1:
                            R1Clicked();
                            break;
                        case 4:
                            R4Clicked();
                            break;
                    }
                    break;
            }
        }

        private static void R4Clicked()
        {
            if (altSetting != -123456 && fieldElvation != -123456)
            {
                int pressAlt = (int)(145366.45 * (1 - Math.Pow(altSetting / 29.92, 0.190284))) + fieldElvation;
                Program.WriteText("L", 4, pressAlt.ToString());
            }
        }

        private static void R1Clicked()
        {
            try
            {
                if (Program.inputMode == 0)
                {
                    string input = Program.input;
                    int altSettingHPa = int.Parse(input);
                    altSetting = altSettingHPa / 1013.25 * 29.92;
                    Program.WriteText("R", 1, altSettingHPa.ToString());
                    Program.input = "";
                    // convert it to inhg
                    Program.WriteText("L", 1, altSetting.ToString("#0.00"));
                    Program.WriteText("L", 4, "- - - - -");
                }
                else if (Program.inputMode == 2)
                {
                    Program.WriteText("L", 1, "▯▯,▯▯");
                    Program.WriteText("R", 1, "▯▯▯▯");
                    Program.WriteText("L", 4, "- - - - -");
                    altSetting = -123456;
                    Program.inputMode = 0;
                }

            }
            catch (FormatException ex)
            {
                Program.ShowMessage("INVALID ENTRY");
            }
        }

        private static void L2Clicked()
        {
            try
            {
                if (Program.inputMode == 0)
                {
                    string input = Program.input;
                    fieldElvation = int.Parse(input);
                    Program.WriteText("L", 2, fieldElvation.ToString());
                    Program.input = "";
                    Program.WriteText("L", 4, "- - - - -");
                }
                else if (Program.inputMode == 2)
                {
                    Program.WriteText("L", 2, "▯▯▯▯▯");
                    Program.WriteText("L", 4, "- - - - -");
                    fieldElvation = -123456;
                    Program.inputMode = 0;
                }

            }
            catch (FormatException ex)
            {
                Program.ShowMessage("INVALID ENTRY");
            }
        }

        private static void L1Clicked()
        {
            try
            {
                if (Program.inputMode == 0)
                {
                    string input = Program.input;
                    altSetting = double.Parse(input);
                    Program.WriteText("L", 1, altSetting.ToString("#0.00"));
                    Program.input = "";
                    // convert it to hpa
                    Program.WriteText("R", 1, (altSetting / 29.92 * 1013.25).ToString("###0"));
                    Program.WriteText("L", 4, "- - - - -");
                }
                else if (Program.inputMode == 2)
                {
                    Program.WriteText("L", 1, "▯▯,▯▯");
                    Program.WriteText("R", 1, "▯▯▯▯");
                    Program.WriteText("L", 4, "- - - - -");
                    altSetting = -123456;
                    Program.inputMode = 0;
                }

            }
            catch (FormatException ex)
            {
                Program.ShowMessage("INVALID ENTRY");
            }
        }

        private static void L6Clicked()
        {
            CDUMenu.Start();
        }
    }
}
