﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCDU
{
    class Menu
    {
        public static void Start()
        {
            Program.activeProgram = 0;
            // init the text
            Program.WriteText("R", 6, "CDU TEST>");
        }
    }
}
