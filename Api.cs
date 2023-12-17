using IWshRuntimeLibrary;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static LRes.PublicStructures;

namespace LRes
{
    internal class Api
    {
        public static List<DisplayProfile> getAllDisplayProfiles()
        {

            Debug.WriteLine("Gathering all supported display settings...\n");

            List<DisplayProfile> listOfObjects_DisplayResolutionInfo = new List<DisplayProfile>();

            PublicStructures.Struct_DevMode struct_devMode = new PublicStructures.Struct_DevMode();

            int int_Count = 0;
            while (WinApi.EnumDisplaySettings(null, int_Count, ref struct_devMode))
            {
                listOfObjects_DisplayResolutionInfo.Add(
                    new DisplayProfile(
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

        public static void CreateShortcut(string string_shortcutName, string string_shortcutPath, string string_targetFileLocation)
        {
            /*  
             *  
             *  Attribution:
             *      Based on code by CoolMinE @ 
             *          https://www.fluxbytes.com/csharp/create-shortcut-programmatically-in-c/
             *      
             */

            string string_shortcutLocation = System.IO.Path.Combine(string_shortcutPath, string_shortcutName + ".lnk");
            WshShell object_shell = new WshShell();
            IWshShortcut object_shortcut = (IWshShortcut)object_shell.CreateShortcut(string_shortcutLocation);

            object_shortcut.Description = string_shortcutName;   // The description of the shortcut
            object_shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
            object_shortcut.TargetPath = string_targetFileLocation;    // The path of the file that will launch when the shortcut is run
            object_shortcut.Save();                                    // Save the shortcut
        }

        public static DisplayProfile? getCurrentDisplayProfile()
        {

            /*  
             *  
             *  Attribution:
             *      Based on code by Mohammad Elsheimy @ 
             *          https://www.c-sharpcorner.com/uploadfile/GemingLeader/changing-display-settings-programmatically/
             *      
             */

            Debug.WriteLine("Gathering current display settings...\n");

            PublicStructures.Struct_DevMode struct_devMode = new PublicStructures.Struct_DevMode();
            DisplayProfile object_displaySettingsInfo;

            struct_devMode.dmSize = (short)Marshal.SizeOf(struct_devMode);
            if (WinApi.EnumDisplaySettings(null, PublicConstants.ENUM_CURRENT_SETTINGS, ref struct_devMode))
            {
                object_displaySettingsInfo = new DisplayProfile(
                    struct_devMode.dmPelsWidth,
                    struct_devMode.dmPelsHeight,
                    struct_devMode.dmDisplayFrequency,
                    struct_devMode.dmBitsPerPel,
                    struct_devMode
                );
                return object_displaySettingsInfo;
            }
            else
            {
                return null;
            }
        }

        public static bool changeDisplaySettings(int int_screenWidth, int int_screenHeight, int int_screenFrequency, int int_screenColorDepth)
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

            struct_newDevMode.dmPelsWidth = int_screenWidth;
            struct_newDevMode.dmPelsHeight = int_screenHeight;
            struct_newDevMode.dmDisplayFrequency = int_screenFrequency;
            struct_newDevMode.dmBitsPerPel = int_screenColorDepth;

            int int_result = WinApi.ChangeDisplaySettings(ref struct_newDevMode, 0);

            if (int_result == PublicConstants.DISP_CHANGE_SUCCESSFUL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool writeTextToFile(string[] arrayOfstrings_linesOfText, string string_targetFilespec)
        {
            try
            {
                using (StreamWriter streamWriter_outputFile = new StreamWriter(string_targetFilespec))
                {
                    foreach (string string_lineOfText in arrayOfstrings_linesOfText)
                        streamWriter_outputFile.WriteLine(string_lineOfText);
                }
                return true;
            } 
            catch (Exception object_exception)
            {
                return false;
            }
        }
    }
}

