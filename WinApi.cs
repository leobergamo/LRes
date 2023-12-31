﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static LRes.PublicStructures;
using static LRes.PublicVariables;

namespace LRes
{
    internal class WinApi
    {

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(
            string deviceName, 
            int modeNum, 
            ref PublicStructures.Struct_DevMode devMode
        );

        [DllImport("User32.dll")]
        public static extern int ChangeDisplaySettings(
            ref PublicStructures.Struct_DevMode devMode, 
            int flags
        );       

    }
}
