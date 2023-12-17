using System.Diagnostics;

namespace LRes
{
    public partial class Form1 : Form
    {

        private List<DisplayResolutionInfo> ListOfObjects_DisplayResolutionInfo = new List<DisplayResolutionInfo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ListOfObjects_DisplayResolutionInfo = Api.getDisplayResolutionInfo();

            foreach (var object_DisplayResolutionInfo in ListOfObjects_DisplayResolutionInfo)
            {
                Debug.WriteLine(object_DisplayResolutionInfo.toString());                
            }
        }
    }
}
