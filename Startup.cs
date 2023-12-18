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

        [STAThread]

        private static void Timer_ProcessMonitor_OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (Process.GetProcessesByName(String_ProcessToMonitor).Length == 0)
            {
                Api.changeDisplaySettings(
                    PublicVariables.Object_CurrentDisplayProfile.getWidth(),
                    PublicVariables.Object_CurrentDisplayProfile.getHeight(),
                    PublicVariables.Object_CurrentDisplayProfile.getFrequency(),
                    PublicVariables.Object_CurrentDisplayProfile.getColorDepth()
                );
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            PublicVariables.Object_CurrentDisplayProfile = Api.getCurrentDisplayProfile();

            if (args.Length == 0) 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                if (args[0].Contains(".lres"))
                {

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
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^WORKING_DIRECTORY=[a-zA-Z]"):
                                    String_WorkingDirectory = string_lineOfText.Split('=')[1];
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^PROCESS_TO_MONITOR=[a-zA-Z]"):
                                    String_ProcessToMonitor = string_lineOfText.Split('=')[1];
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_WIDTH=[0-9]"):
                                    Int_ScreenWidth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_HEIGHT=[0-9]"):
                                    Int_ScreenHeight = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_FREQUENCY=[0-9]"):
                                    Int_ScreenFrequency = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_COLOR_DEPTH=[0-9]"):
                                    Int_ScreenColorDepth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    Int_VerificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^#"):
                                    continue;
                                default:
                                    continue;
                            }
                        }
                        MessageBox.Show(
                            "Values Derived from File:\n\n" + 
                            "Filename: " + String_Filename + "\n" +
                            "Working Directory: " + String_WorkingDirectory + "\n" +
                            "Process to Monitor: " + String_ProcessToMonitor + "\n" +
                            "Screen Width: " + Int_ScreenWidth.ToString() + "px\n" +
                            "Screen Height: " + Int_ScreenHeight.ToString() + "px\n" +
                            "Screen Frequency: " + Int_ScreenFrequency.ToString() + "hz\n" +
                            "Screen Color Depth: " + Int_ScreenColorDepth.ToString() + "BPP\n\n" +
                            "Verification Count: " + Int_VerificationCount.ToString() + " out of 7",
                            "LRes - Debug",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        if (Int_VerificationCount < 7)
                        {
                            MessageBox.Show(
                                "File verification failed!",
                                "LRes - Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            Environment.Exit(1);

                        }

                        if (Api.changeDisplaySettings(Int_ScreenWidth, Int_ScreenHeight, Int_ScreenFrequency, Int_ScreenColorDepth))
                        {
                            Thread.Sleep(2000);

                            if (String_Filename.Contains(".lnk"))
                            {
                                Api.runLinkFile(String_Filename, String_WorkingDirectory, false);

                                Thread.Sleep(15000 /* 15 seconds */);

                                Timer_ProcessMonitor = new System.Timers.Timer(15000 /* 15 seconds */);
                                Timer_ProcessMonitor.Elapsed += Timer_ProcessMonitor_OnTimedEvent;
                                Timer_ProcessMonitor.AutoReset = true;
                                Timer_ProcessMonitor.Enabled = true;
                            }
                            else if (String_Filename.Contains(".exe"))
                            {
                                Api.runExecFile(String_Filename, String_WorkingDirectory, false);

                                Thread.Sleep(15000 /* 15 seconds */);

                                Timer_ProcessMonitor = new System.Timers.Timer(15000 /* 15 seconds */);
                                Timer_ProcessMonitor.Elapsed += Timer_ProcessMonitor_OnTimedEvent;
                                Timer_ProcessMonitor.AutoReset = true;
                                Timer_ProcessMonitor.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Failed to launch program!",
                                    "LRes - Critical Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                Environment.Exit(1);                                
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to change display settings!",
                                "LRes - Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            Environment.Exit(1);
                        }
                    }
                }
            }
        }
    }
}
