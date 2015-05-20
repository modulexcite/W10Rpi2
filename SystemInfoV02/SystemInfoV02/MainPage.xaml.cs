using System;
using Windows.ApplicationModel;
using Windows.System;
using Windows.UI.Popups;
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

        private async void ButtonGetSystemInformation_Click(object sender, RoutedEventArgs e)
        {
            var systemInformation = GetSystemInformation();
            if (IsArmArchitecture())
            {
                TextBlockSystemInformation.Text = systemInformation;
            }
            else
            {
                var   md = new MessageDialog(systemInformation);
                await md.ShowAsync();
            }
        }

        private string GetSystemInformation()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;
            var ret =
                $@"========================
Name: { packageId.Name}
========================
Version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}
Architecture: {packageId.Architecture}
========================
ResourceId: {packageId.ResourceId}
Publisher: {packageId.Publisher}
PublisherId: {packageId.PublisherId} 
========================
FullName: {packageId.FullName}
FamilyName: {packageId.FamilyName} 
IsFramework: {package.IsFramework}
========================
Processor Count : {Environment.ProcessorCount}
TickCount:{Environment.TickCount} 
========================
";
            return ret;
        }

        private bool IsArmArchitecture()
        {
            var package = Package.Current;
            var architecture = package.Id.Architecture;
            return architecture == ProcessorArchitecture.Arm;
        }
    }
}
