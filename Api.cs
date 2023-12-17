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
        public static List<DisplayInfo> getDisplayResolutionInfo()
        {
            List<DisplayInfo> listDisplayInfo = new List<DisplayInfo>();

            PublicStructures.structDevMode structDevMode = new PublicStructures.structDevMode();

            int intCount = 0;
            while (WinApi.EnumDisplaySettings(null, intCount, ref structDevMode))
            {
                listDisplayInfo.Add(new DisplayInfo(structDevMode.dmPelsWidth, structDevMode.dmPelsHeight, structDevMode.dmDisplayFrequency));
                intCount++;
            }

            return listDisplayInfo;
        }
    }
}
