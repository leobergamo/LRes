using static LRes.PublicStructures;

namespace LRes
{
    internal class Api
    {
        public static List<DisplayResolutionInfo> getDisplayResolutionInfo()
        {
            List<DisplayResolutionInfo> listOfObjects_DisplayResolutionInfo = new List<DisplayResolutionInfo>();

            PublicStructures.Struct_DevMode struct_DevMode = new PublicStructures.Struct_DevMode();

            int int_Count = 0;
            while (WinApi.EnumDisplaySettings(null, int_Count, ref struct_DevMode))
            {
                listOfObjects_DisplayResolutionInfo.Add(new DisplayResolutionInfo(struct_DevMode.dmPelsWidth, struct_DevMode.dmPelsHeight, struct_DevMode.dmDisplayFrequency));
                int_Count++;
            }

            return listOfObjects_DisplayResolutionInfo;
        }
    }
}
