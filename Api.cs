using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static LRes.PublicStructures;
using static LRes.PublicVariables;

namespace LRes
{
    internal class Api
    {
        public static void gatherDisplayInfo()
        {
            DEVMODE vDevMode = new DEVMODE();
            int i = 0;
            while (WinApi.EnumDisplaySettings(null, i, ref vDevMode))
            {
                Debug.WriteLine("Width:{0} Height:{1} Color:{2} Frequency:{3}",
                                        vDevMode.dmPelsWidth,
                                        vDevMode.dmPelsHeight,
                                        1 << vDevMode.dmBitsPerPel, vDevMode.dmDisplayFrequency
                                    );
                i++;
            }
        }
    }
}
