using System;
using System.ServiceModel.Dispatcher;
using Windows.Devices.Gpio;
using Windows.Devices.Spi;
using Windows.Storage.Streams;
using Windows.System;
using Windows.System.Profile;
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
                "TickCount:" + Environment.TickCount + Environment.NewLine;
            return ret;
        }
    }
}
