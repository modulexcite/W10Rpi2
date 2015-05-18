using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SystemInfoV02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonGetSystemInformation_Click(object sender, RoutedEventArgs e)
        {
            TextBlockSystemInformation.Text = GetSystemInformation();
        }

        private string GetSystemInformation()
        {
            var ret = 
                @"Processor Count : " + Environment.ProcessorCount + Environment.NewLine +
                "TickCount:" + Environment.TickCount;
            return ret;
        }
    }
}
