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

            Api.getCurrentDisplaySettings();

            this.ListOfObjects_DisplayResolutionInfo = Api.getAllSupportedDisplaySettings();

            foreach (var object_DisplayResolutionInfo in ListOfObjects_DisplayResolutionInfo)
            {
                DisplaySettingsInfoComboItem object_displayResolutionInfoComboItem = new DisplaySettingsInfoComboItem();
                object_displayResolutionInfoComboItem.string_Text = object_DisplayResolutionInfo.ToString();
                object_displayResolutionInfoComboItem.object_Value = object_DisplayResolutionInfo;
                this.comboBox_DisplaySettingsInfo.Items.Add(object_displayResolutionInfoComboItem);
            }
        }
                
        private void comboBox_DisplaySettingsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine((this.comboBox_DisplaySettingsInfo.SelectedItem as DisplaySettingsInfoComboItem).string_Text);
        }
    }
}
