using System.Diagnostics;
using System.Runtime.InteropServices;
using static LRes.PublicStructures;

namespace LRes
{
    internal class Api
    {
        public static List<DisplaySettingsInfo> getAllSupportedDisplaySettings()
        {

            Debug.WriteLine("Gathering all supported display settings...\n");

            List<DisplaySettingsInfo> listOfObjects_DisplayResolutionInfo = new List<DisplaySettingsInfo>();

            PublicStructures.Struct_DevMode struct_devMode = new PublicStructures.Struct_DevMode();

            int int_Count = 0;
            while (WinApi.EnumDisplaySettings(null, int_Count, ref struct_devMode))
            {
                listOfObjects_DisplayResolutionInfo.Add(
                    new DisplaySettingsInfo(
                        struct_devMode.dmPelsWidth,
                        struct_devMode.dmPelsHeight,
                        struct_devMode.dmDisplayFrequency,
                        struct_devMode.dmBitsPerPel,
                        struct_devMode
                    )
                );
                int_Count++;
            }

            return listOfObjects_DisplayResolutionInfo;
        }

        public static void getCurrentDisplaySettings()
        {

            /*  
             *  
             *  Attribution:
             *      Based on code by Mohammad Elsheimy @ 
             *          https://www.c-sharpcorner.com/uploadfile/GemingLeader/changing-display-settings-programmatically/
             *      
            */

            Debug.WriteLine("Gathering current display settings...\n");

            PublicStructures.Struct_DevMode struct_DevMode = new PublicStructures.Struct_DevMode();

            struct_DevMode.dmSize = (short)Marshal.SizeOf(struct_DevMode);
            if (WinApi.EnumDisplaySettings(null, PublicConstants.ENUM_CURRENT_SETTINGS, ref struct_DevMode))
            {
                PublicVariables.Struct_CurrDevMode = struct_DevMode;
            }
        }

        public static bool changeDisplaySettings(int int_width, int int_height, int int_colorDepth)
        {

            /*  
             *  
             *  Attribution:
             *      Based on code by Mohammad Elsheimy @ 
             *          https://www.c-sharpcorner.com/uploadfile/GemingLeader/changing-display-settings-programmatically/
             *      
            */

            Debug.WriteLine("Changing display settings...\n");

            PublicStructures.Struct_DevMode struct_origDevMode = new PublicStructures.Struct_DevMode();

            struct_origDevMode.dmSize = (short)Marshal.SizeOf(struct_origDevMode);

            WinApi.EnumDisplaySettings(null, PublicConstants.ENUM_CURRENT_SETTINGS, ref struct_origDevMode);

            PublicStructures.Struct_DevMode struct_newDevMode = struct_origDevMode;

            struct_newDevMode.dmPelsWidth = int_width;
            struct_newDevMode.dmPelsHeight = int_height;
            struct_newDevMode.dmBitsPerPel = int_colorDepth;

            int int_result = WinApi.ChangeDisplaySettings(ref struct_newDevMode, 0);
            if (int_result == PublicConstants.DISP_CHANGE_SUCCESSFUL)
            {
                Debug.WriteLine("Succeeded.\n");
                return true;
            }
            else if (int_result == PublicConstants.DISP_CHANGE_BADMODE)
            {
                Debug.WriteLine("Mode not supported.");
                return false;
            }
            else if (int_result == PublicConstants.DISP_CHANGE_RESTART)
            {
                Debug.WriteLine("Restart required.");
                return true;
            }
            else
            {
                Debug.WriteLine("Failed. Error code = {0}", int_result);
                return false;
            }
        }
    }
}

