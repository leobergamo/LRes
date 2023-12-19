using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;


namespace LRes
{

    internal class Startup
    {

        private static int Int_BufferSize = 128;
        private static int Int_VerificationCount = 0;
        private static int Int_ScreenWidth = 0;
        private static int Int_ScreenHeight = 0;
        private static int Int_ScreenFrequency = 0;
        private static int Int_ScreenColorDepth = 0;

        private static String String_Filename = "";
        private static String String_WorkingDirectory = "";
        private static String String_ProcessToMonitor = "";

        private static System.Timers.Timer Timer_ProcessMonitor;

        private static void Timer_ProcessMonitor_OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (Process.GetProcessesByName(String_ProcessToMonitor).Length == 0)
            {
                Log.DEBUG("'" + String_ProcessToMonitor + "' process not running...");
                /*Api.changeDisplaySettings(
                    PublicVariables.Object_CurrentDisplayProfile.getWidth(),
                    PublicVariables.Object_CurrentDisplayProfile.getHeight(),
                    PublicVariables.Object_CurrentDisplayProfile.getFrequency(),
                    PublicVariables.Object_CurrentDisplayProfile.getColorDepth()
                );*/
            }
            else
            {
                Log.DEBUG("'" + String_ProcessToMonitor + "' process running...");
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            PublicVariables.Object_CurrentDisplayProfile = Api.getCurrentDisplayProfile();

            if (args.Length == 0) 
            {
                Log.DEBUG("starting GUI...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                Log.DEBUG("starting headless...");
                if (args[0].Contains(".lres"))
                {
                    Log.DEBUG("parsing file '" + args[0] + "'...");
                    using (FileStream fileStream_a = File.OpenRead(args[0]))
                    using (StreamReader streamReader_a = new StreamReader(fileStream_a, Encoding.UTF8, true, Int_BufferSize))
                    {
                        String string_lineOfText;
                        while ((string_lineOfText = streamReader_a.ReadLine()) != null)
                        {
                            switch (true)
                            {
                                case true when Regex.IsMatch(string_lineOfText, "^FILENAME=[a-zA-Z]"):
                                    String_Filename = string_lineOfText.Split('=')[1];
                                    Log.DEBUG("found value 'FILENAME'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^WORKING_DIRECTORY=[a-zA-Z]"):
                                    String_WorkingDirectory = string_lineOfText.Split('=')[1];
                                    Log.DEBUG("found value 'WORKING_DIRECTORY'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^PROCESS_TO_MONITOR=[a-zA-Z]"):
                                    String_ProcessToMonitor = string_lineOfText.Split('=')[1];
                                    Log.DEBUG("found value 'PROCESS_TO_MONITOR'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_WIDTH=[0-9]"):
                                    Int_ScreenWidth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Log.DEBUG("found value 'SCREEN_WIDTH'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_HEIGHT=[0-9]"):
                                    Int_ScreenHeight = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Log.DEBUG("found value 'SCREEN_HEIGHT'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_FREQUENCY=[0-9]"):
                                    Int_ScreenFrequency = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Log.DEBUG("found value 'SCREEN_FREQUENCY'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_COLOR_DEPTH=[0-9]"):
                                    Int_ScreenColorDepth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Log.DEBUG("found value 'SCREEN_COLOR_DEPTH'...");
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^#"):
                                    continue;
                                default:
                                    continue;
                            }
                        }
                        
                        Log.DEBUG(
                            "Values Derived from File --->\n\n" + 
                            "\tFilename: " + String_Filename + "\n" +
                            "\tWorking Directory: " + String_WorkingDirectory + "\n" +
                            "\tProcess to Monitor: " + String_ProcessToMonitor + "\n" +
                            "\tScreen Width: " + Int_ScreenWidth.ToString() + "px\n" +
                            "\tScreen Height: " + Int_ScreenHeight.ToString() + "px\n" +
                            "\tScreen Frequency: " + Int_ScreenFrequency.ToString() + "hz\n" +
                            "\tScreen Color Depth: " + Int_ScreenColorDepth.ToString() + "BPP\n\n" +
                            "\tFile Parameter Verification Count: " + Int_VerificationCount.ToString() + " out of 7" + "\n" +
                            "<---"
                        );

                        if (Int_VerificationCount < 7)
                        {
                            Log.ERROR("file verification failed!");
                            MessageBox.Show(
                                "File verification failed!",
                                "LRes - Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            Log.DEBUG("terminating...");
                            Environment.Exit(1);

                        }

                        Log.DEBUG("changing screen profile to the one defined in file...");
                        if (Api.changeDisplaySettings(Int_ScreenWidth, Int_ScreenHeight, Int_ScreenFrequency, Int_ScreenColorDepth))
                        {
                            Log.DEBUG("success");
                            Thread.Sleep(2000);

                            if (String_Filename.Contains(".lnk"))
                            {
                                Log.DEBUG("starting program indirectly...");
                                Api.runLinkFile(String_Filename, String_WorkingDirectory, false);

                                Thread.Sleep(15000);

                                Log.DEBUG("starting process monitor...");

                                while (true)
                                {
                                    if (Process.GetProcessesByName(String_ProcessToMonitor).Length == 0)
                                    {
                                        Log.DEBUG("'" + String_ProcessToMonitor + "' process not running...");
                                        Log.DEBUG("reverting display profile...");
                                        Thread.Sleep(1000);

                                        if(
                                            Api.changeDisplaySettings(
                                            PublicVariables.Object_CurrentDisplayProfile.getWidth(),
                                            PublicVariables.Object_CurrentDisplayProfile.getHeight(),
                                            PublicVariables.Object_CurrentDisplayProfile.getFrequency(),
                                            PublicVariables.Object_CurrentDisplayProfile.getColorDepth()
                                            )
                                        )
                                        {
                                            Log.DEBUG("success");
                                        } else
                                        {
                                            Log.ERROR("failed to revert display profile...");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Log.DEBUG("'" + String_ProcessToMonitor + "' process running...");
                                    }
                                    Thread.Sleep(5000);
                                }
                                Log.DEBUG("terminating...");
                            }
                            else if (String_Filename.Contains(".exe"))
                            {
                                Log.DEBUG("starting program directly...");
                                Api.runExecFile(String_Filename, String_WorkingDirectory, false);

                                Thread.Sleep(15000);

                                Log.DEBUG("starting process monitor...");

                                while (true)
                                {
                                    if (Process.GetProcessesByName(String_ProcessToMonitor).Length == 0)
                                    {
                                        Log.DEBUG("'" + String_ProcessToMonitor + "' process not running...");
                                        Log.DEBUG("reverting display profile...");
                                        Thread.Sleep(1000);
                                        if(
                                            Api.changeDisplaySettings(
                                                PublicVariables.Object_CurrentDisplayProfile.getWidth(),
                                                PublicVariables.Object_CurrentDisplayProfile.getHeight(),
                                                PublicVariables.Object_CurrentDisplayProfile.getFrequency(),
                                                PublicVariables.Object_CurrentDisplayProfile.getColorDepth()
                                            )
                                        )
                                        {
                                            Log.DEBUG("success");
                                        }
                                        else
                                        {
                                            Log.ERROR("failed to revert display profile...");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Log.DEBUG("'" + String_ProcessToMonitor + "' process running...");
                                    }
                                    Thread.Sleep(5000);
                                }
                                Log.DEBUG("terminating...");
                            }
                            else
                            {
                                Log.ERROR("filename is neither executable or link!");
                                MessageBox.Show(
                                    "Failed to launch program!",
                                    "LRes - Critical Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                Log.DEBUG("terminating...");
                                Environment.Exit(1);                                
                            }
                        }
                        else
                        {
                            Log.ERROR("failed to change display profile!");
                            MessageBox.Show(
                                "Failed to change display settings!",
                                "LRes - Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            Log.DEBUG("terminating...");
                            Environment.Exit(1);
                        }
                    }
                }
            }
        }
    }
}
