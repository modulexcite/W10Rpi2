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
            var ret =
                @"Processor Count : " + Environment.ProcessorCount + Environment.NewLine +
                "TickCount:" + Environment.TickCount + Environment.NewLine;

            var package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            ret += String.Format(
                               "Name: \"{0}\"\n" +
                               "Version: {1}.{2}.{3}.{4}\n" +
                               "Architecture: {5}\n" +
                               "ResourceId: \"{6}\"\n" +
                               "Publisher: \"{7}\"\n" +
                               "PublisherId: \"{8}\"\n" +
                               "FullName: \"{9}\"\n" +
                               "FamilyName: \"{10}\"\n" +
                               "IsFramework: {11}",
                               packageId.Name,
                               version.Major, version.Minor, version.Build, version.Revision,
                               packageId.Architecture,
                               packageId.ResourceId,
                               packageId.Publisher,
                               packageId.PublisherId,
                               packageId.FullName,
                               packageId.FamilyName,
                               package.IsFramework);

            return ret;
        }
    }
}
