using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.Networking.Connectivity;

namespace SystemInfoV02
{
    public sealed partial class InternetConnectionProfile : Page
    {
        public InternetConnectionProfile()
        {
            InitializeComponent();
        }

        private void InternetConnectionProfile_Click(object sender, RoutedEventArgs e)
        {
            var connectionProfileInfo = string.Empty;
            try
            {
                var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

                if (internetConnectionProfile == null)
                {
                }
                else
                {
                    connectionProfileInfo = GetConnectionProfile(internetConnectionProfile);
                    OutputText.Text = connectionProfileInfo;
                }
            }
            catch (Exception ex)
            {
            }

        }

        string GetConnectionProfile(ConnectionProfile connectionProfile)
        {
            var connectionProfileInfo = string.Empty;
            if (connectionProfile != null)
            {
                connectionProfileInfo = "Profile Name : " + connectionProfile.ProfileName + "\n";

                switch (connectionProfile.GetNetworkConnectivityLevel())
                {
                    case NetworkConnectivityLevel.None:
                        connectionProfileInfo += "Connectivity Level : None\n";
                        break;
                    case NetworkConnectivityLevel.LocalAccess:
                        connectionProfileInfo += "Connectivity Level : Local Access\n";
                        break;
                    case NetworkConnectivityLevel.ConstrainedInternetAccess:
                        connectionProfileInfo += "Connectivity Level : Constrained Internet Access\n";
                        break;
                    case NetworkConnectivityLevel.InternetAccess:
                        connectionProfileInfo += "Connectivity Level : Internet Access\n";
                        break;
                }

                switch (connectionProfile.GetDomainConnectivityLevel())
                {
                    case DomainConnectivityLevel.None:
                        connectionProfileInfo += "Domain Connectivity Level : None\n";
                        break;
                    case DomainConnectivityLevel.Unauthenticated:
                        connectionProfileInfo += "Domain Connectivity Level : Unauthenticated\n";
                        break;
                    case DomainConnectivityLevel.Authenticated:
                        connectionProfileInfo += "Domain Connectivity Level : Authenticated\n";
                        break;
                }

                //Get the Service Provider GUID
                if (connectionProfile.ServiceProviderGuid.HasValue)
                {
                    connectionProfileInfo += "====================\n";
                    connectionProfileInfo += "Service Provider GUID: " + connectionProfile.ServiceProviderGuid + "\n";
                }

                //Get the number of signal bars
                if (connectionProfile.GetSignalBars().HasValue)
                {
                    connectionProfileInfo += "====================\n";
                    connectionProfileInfo += "Signal Bars: " + connectionProfile.GetSignalBars() + "\n";
                }
            }
            return connectionProfileInfo;
        }


    }
}

