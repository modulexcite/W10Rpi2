using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Devices.Usb;
using Windows.Storage;
using Windows.UI.Xaml.Controls;


namespace W10Rpi2GetSystemInfo
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var str = await EnumerateHidDevices();
            TextBlockStatus.Text = str;
        }

        private async Task<string> EnumerateHidDevices()
        {
            var localDevices = await DeviceInformation.FindAllAsync();
            var uniqueDevices = localDevices.GroupBy(x => x.Name).Select(y => y.First());
            var ret = uniqueDevices.Aggregate("", (current, myDevice) => current + $@"{myDevice.Name} 
      - Id {myDevice.Id}{Environment.NewLine}");
            Debug.WriteLine(ret);
            return ret;
        }
    }
}
