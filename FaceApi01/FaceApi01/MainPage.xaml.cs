﻿using System;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using FaceApi01.Model;
using Oltiva.Azure.FaceApi;

namespace FaceApi01
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            InitImageList();
        }

        private async void ButtonGetFacesImage1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var subscriptionKey = "4c138b4d82b947beb2e2926c92d1e514";
                var fileUrl = GetSelectedItemUrl();
                var client = new FaceServiceClient(subscriptionKey);
                var faces = await client.DetectAsync(fileUrl, false, true, true);
            }
            catch (Exception exception)
            {
                TextBlockOutput.Text = exception.ToString();
            }
        }

        void InitImageList()
        {
            var imageList = new List<OneDriveImage>
            {
                new OneDriveImage(@"drawing", @"https://brunocapuano.files.wordpress.com/2015/05/20-face-drawings.jpg"),
                new OneDriveImage(@"family", @"https://brunocapuano.files.wordpress.com/2015/05/family.jpg"),
                new OneDriveImage(@"princesas", @"https://brunocapuano.files.wordpress.com/2015/05/princesas.jpg"),
                new OneDriveImage(@"jesus", @"https://brunocapuano.files.wordpress.com/2015/05/jesus-thumbs-up-pic.jpg"),
                new OneDriveImage(@"Yoda", @"https://brunocapuano.files.wordpress.com/2015/05/yoda-jedi-council.jpg"),
                new OneDriveImage(@"Star Wars",@"https://brunocapuano.files.wordpress.com/2015/05/star-wars-original.jpg"),
                new OneDriveImage(@"Star Wars 2015",@"https://brunocapuano.files.wordpress.com/2015/05/star-wars-han-solo-y-chewbacca-2015.jpg")
            };

            ListViewImages.ItemsSource = imageList;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ImageFaces.Source = new BitmapImage(new Uri(GetSelectedItemUrl(), UriKind.RelativeOrAbsolute));
            }
            catch (Exception exception)
            {
                TextBlockOutput.Text = exception.ToString();
            }
        }

        private string GetSelectedItemUrl()
        {
            var odi = ListViewImages.SelectedItem as OneDriveImage;
            return odi == null ? "" : odi.OneDriveUrl;
        }
    }
}
