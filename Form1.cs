using System.Diagnostics;

namespace LRes
{
    public partial class Form1 : Form
    {

        private List<DisplaySettingsInfo> ListOfObjects_DisplayResolutionInfo = new List<DisplaySettingsInfo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            PublicVariables.Object_CurrentDisplaySettingInfo = Api.getCurrentDisplaySettings();

            this.ListOfObjects_DisplayResolutionInfo = Api.getAllSupportedDisplaySettings();

            foreach (var object_DisplayResolutionInfo in ListOfObjects_DisplayResolutionInfo)
            {
                DisplaySettingsInfoComboItem object_displayResolutionInfoComboItem = new DisplaySettingsInfoComboItem();
                object_displayResolutionInfoComboItem.string_text = object_DisplayResolutionInfo.ToString();
                object_displayResolutionInfoComboItem.object_displaySettingsInfo = object_DisplayResolutionInfo;
                this.comboBox_DisplaySettingsInfo.Items.Add(object_displayResolutionInfoComboItem);
            }
        }

        private void comboBox_DisplaySettingsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine((this.comboBox_DisplaySettingsInfo.SelectedItem as DisplaySettingsInfoComboItem).string_text);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DisplaySettingsInfo object_CurrentDisplaySettingInfo = Api.getCurrentDisplaySettings();
            PublicStructures.Struct_DevMode struct_origDevMode = object_CurrentDisplaySettingInfo.getStructDevMode();
            PublicStructures.Struct_DevMode struct_newDevMode = object_CurrentDisplaySettingInfo.getStructDevMode();
            
            int int_width = (this.comboBox_DisplaySettingsInfo.SelectedItem as DisplaySettingsInfoComboItem).object_displaySettingsInfo.getWidth();
            int int_height = (this.comboBox_DisplaySettingsInfo.SelectedItem as DisplaySettingsInfoComboItem).object_displaySettingsInfo.getHeight();
            
            struct_newDevMode.dmPelsWidth = int_width;
            struct_newDevMode.dmPelsHeight = int_height;

            if (WinApi.ChangeDisplaySettings(ref struct_newDevMode, 0) == PublicConstants.DISP_CHANGE_SUCCESSFUL)
            {
                Thread.Sleep(5000);
                WinApi.ChangeDisplaySettings(ref struct_origDevMode, 0);
            }
            else
            {
                MessageBox.Show("Unable to change display settings!");
            }
        }
    }
}
