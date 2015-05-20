using System;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
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
            var package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

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
    }
}
