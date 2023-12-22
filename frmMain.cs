using System.Diagnostics;
using System.IO;

namespace LRes
{
    public partial class frmMain : Form
    {

        private List<DisplayProfile> ListOfObjects_DisplayProfiles = new List<DisplayProfile>();





        public frmMain()
        {
            InitializeComponent();
        }






        private void btnTest_Click(object sender, EventArgs e)
        {
            DisplayProfile object_CurrentDisplaySettingInfo = Api.getCurrentDisplayProfile();
            PublicStructures.Struct_DevMode struct_origDevMode = object_CurrentDisplaySettingInfo.getStructDevMode();
            PublicStructures.Struct_DevMode struct_newDevMode = object_CurrentDisplaySettingInfo.getStructDevMode();

            int int_width = (this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).object_displayProfile.getWidth();
            int int_height = (this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).object_displayProfile.getHeight();
            int int_frequency = (this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).object_displayProfile.getFrequency();
            int int_colordepth = (this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).object_displayProfile.getColorDepth();

            struct_newDevMode.dmPelsWidth = int_width;
            struct_newDevMode.dmPelsHeight = int_height;
            struct_newDevMode.dmDisplayFrequency = int_frequency;
            struct_newDevMode.dmBitsPerPel = int_colordepth;

            if (WinApi.ChangeDisplaySettings(ref struct_newDevMode, 0) == PublicConstants.DISP_CHANGE_SUCCESSFUL)
            {
                PublicVariables.Object_SelectedDisplayProfile = new DisplayProfile(
                    int_width,
                    int_height,
                    int_frequency,
                    int_colordepth,
                    struct_newDevMode
                );

                Thread.Sleep(5000);
                WinApi.ChangeDisplaySettings(ref struct_origDevMode, 0);
                Thread.Sleep(1000);
                MessageBox.Show("Display settings are supported!");
            }
            else
            {
                MessageBox.Show("Display settings are not supported!");
            }
        }






        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgOpenFile.ShowDialog();
            if (dlgOpenFile.FileName != String.Empty)
            {
                tbFilename.Text = Path.GetFileName(dlgOpenFile.FileName);
                tbWorkingDirectory.Text = Directory.GetParent(dlgOpenFile.FileName).FullName;
            }
        }






        private void panel2_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] arrayOfStrings_files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string string_filename = Path.GetFileName(arrayOfStrings_files[0]);

                if (string_filename.Contains(".exe") || string_filename.Contains(".lnk"))
                {
                    tbFilename.Text = Path.GetFileName(arrayOfStrings_files[0]);
                    tbWorkingDirectory.Text = Directory.GetParent(arrayOfStrings_files[0]).FullName;
                    tbProcToMon.Text = tbFilename.Text;
                }
                else
                {
                    MessageBox.Show(
                        "Invalid file type!",
                        "LRes - Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }






        private void tmrUiMonitor_Tick(object sender, EventArgs e)
        {


            if(comboBox_DisplayProfiles.SelectedIndex >= 0)
            {
                panel2.Enabled = true;
            } else panel2.Enabled = false;



            if (
                comboBox_DisplayProfiles.SelectedIndex >= 0 &&
                tbFilename.Text != String.Empty &&
                tbWorkingDirectory.Text != String.Empty &&
                tbProcToMon.Text != String.Empty
            ) {
                btnSave.Enabled = true;
            } else btnSave.Enabled = false;



            if (btnSave.Enabled) { 
                tbSynopsis.Text =
                    $"Execute program or link: " +
                    $"'{tbWorkingDirectory.Text}\\{tbFilename.Text}'" +
                    " using resolution: '" +
                    $"{PublicVariables.Object_SelectedDisplayProfile.getWidth().ToString()}" +
                    "x" +
                    $"{PublicVariables.Object_SelectedDisplayProfile.getHeight().ToString()}', " +
                    "using screen refresh rate: " +
                    $"'{PublicVariables.Object_SelectedDisplayProfile.getFrequency().ToString()}Hz'," +
                    " using screen color depth: " +
                    $"'{PublicVariables.Object_SelectedDisplayProfile.getColorDepth().ToString()}BPP'" +
                    " while watching process: " +
                    $"'{tbProcToMon.Text}'" +
                    "...";
                btnSave.Enabled = true;
            } else tbSynopsis.Text = "...";


        }






        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] arrayOfStrings_linesOfText = {
                string.Format("FILENAME={0}", tbFilename.Text),
                string.Format("WORKING_DIRECTORY={0}", tbWorkingDirectory.Text),
                string.Format("PROCESS_TO_MONITOR={0}", tbProcToMon.Text),
                string.Format("SCREEN_WIDTH={0}", PublicVariables.Object_SelectedDisplayProfile.getWidth()),
                string.Format("SCREEN_HEIGHT={0}", PublicVariables.Object_SelectedDisplayProfile.getHeight()),
                string.Format("SCREEN_FREQUENCY={0}", PublicVariables.Object_SelectedDisplayProfile.getFrequency()),
                string.Format("SCREEN_COLOR_DEPTH={0}", PublicVariables.Object_SelectedDisplayProfile.getColorDepth()),
                string.Format("SYNOPSIS={0}", tbSynopsis.Text)
            };

            if (
                Api.writeTextToFile(
                    arrayOfStrings_linesOfText,
                    PublicVariables.String_AppWorkingDirectory + "\\" + Path.GetFileNameWithoutExtension(tbFilename.Text) + ".lres"
                )
            )
            {
                Api.createShortcut(
                    Path.GetFileNameWithoutExtension(tbFilename.Text),
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                    PublicVariables.String_AppWorkingDirectory + "\\" + Path.GetFileNameWithoutExtension(tbFilename.Text) + ".lres",
                    tbSynopsis.Text
                );
                MessageBox.Show("Configuration saved!");
            }
            else
            {
                MessageBox.Show("Configuration not saved!");
            }
        }






        private void comboBox_DisplayProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicVariables.Object_SelectedDisplayProfile = (this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).object_displayProfile;
            Debug.WriteLine((this.comboBox_DisplayProfiles.SelectedItem as DisplayProfileComboBoxItem).string_text);
        }






        private void frmMain_Load(object sender, EventArgs e)
        {

            Log.DEBUG("gathering available display profiles...");
            List<DisplayProfileComboBoxItem> listOfObject_DisplayProfilesComboBoxItems = new List<DisplayProfileComboBoxItem>();

            foreach (DisplayProfile object_DisplayProfile in Api.getAllDisplayProfiles())
            {
                DisplayProfileComboBoxItem object_displayProfileComboItem = new DisplayProfileComboBoxItem();
                object_displayProfileComboItem.string_text = object_DisplayProfile.ToString();
                object_displayProfileComboItem.object_displayProfile = object_DisplayProfile;
                listOfObject_DisplayProfilesComboBoxItems.Add(object_displayProfileComboItem);
            }

            Log.DEBUG($"Found {listOfObject_DisplayProfilesComboBoxItems.Count} display profiles...");

            comboBox_DisplayProfiles.Items.AddRange(
                listOfObject_DisplayProfilesComboBoxItems.Distinct().ToArray()
            );

            listOfObject_DisplayProfilesComboBoxItems.Clear();

        }

        private void dlgOpenFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
