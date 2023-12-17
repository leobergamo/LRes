using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace LRes
{

    internal class Startup
    {
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
                    int int_bufferSize = 128;
                    int int_verificationCount = 0;
                    int int_screenWidth = 0;
                    int int_screenHeight = 0;
                    int int_screenFrequency = 0;
                    int int_screenColorDepth = 0;

                    String string_filename = "";
                    String string_workingDirectory = "";


                    using (FileStream fileStream_a = File.OpenRead(args[0]))
                    using (StreamReader streamReader_a = new StreamReader(fileStream_a, Encoding.UTF8, true, int_bufferSize))
                    {
                        String string_lineOfText;
                        while ((string_lineOfText = streamReader_a.ReadLine()) != null)
                        {
                            switch (true)
                            {
                                case true when Regex.IsMatch(string_lineOfText, "^FILENAME=[a-zA-Z]"):
                                    string_filename = string_lineOfText.Split('=')[1];
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^WORKING_DIRECTORY=[a-zA-Z]"):
                                    string_workingDirectory = string_lineOfText.Split('=')[1];
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_WIDTH=[0-9]"):
                                    int_screenWidth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_HEIGHT=[0-9]"):
                                    int_screenHeight = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_FREQUENCY=[0-9]"):
                                    int_screenFrequency = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^SCREEN_COLOR_DEPTH=[0-9]"):
                                    int_screenColorDepth = Int32.Parse(string_lineOfText.Split('=')[1]);
                                    int_verificationCount++;
                                    break;
                                case true when Regex.IsMatch(string_lineOfText, "^#"):
                                    continue;
                                default:
                                    continue;
                            }
                        }
                        MessageBox.Show(
                            "Values Derived from File:\n\n" + 
                            "Filename: " + string_filename + "\n" +
                            "Working Directory: " + string_workingDirectory + "\n" +
                            "Screen Width: " + int_screenWidth.ToString() + "px\n" +
                            "Screen Height: " + int_screenHeight.ToString() + "px\n" +
                            "Screen Frequency: " + int_screenFrequency.ToString() + "hz\n" +
                            "Screen Color Depth: " + int_screenColorDepth.ToString() + "BPP\n\n" +
                            "Verification Count: " + int_verificationCount.ToString() + " out of 6",
                            "LRes - Debug",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        if (Api.changeDisplaySettings(int_screenWidth, int_screenHeight, int_screenFrequency, int_screenColorDepth))
                        {
                            Process.Start(string_workingDirectory + "\\" + string_filename).WaitForExit();

                            Api.changeDisplaySettings(
                                PublicVariables.Object_CurrentDisplayProfile.getWidth(),
                                PublicVariables.Object_CurrentDisplayProfile.getHeight(),
                                PublicVariables.Object_CurrentDisplayProfile.getFrequency(),
                                PublicVariables.Object_CurrentDisplayProfile.getColorDepth()
                            );
                        } else
                        {
                            MessageBox.Show(
                                "Failed to change display settings!",
                                "LRes - Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
        }
    }
}
