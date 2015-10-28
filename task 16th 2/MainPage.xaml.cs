using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace task_16th_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        IReadOnlyList<StorageFile> f1;
        StorageFile sf;
      

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.SuggestedStartLocation = PickerLocationId.Desktop;
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.FileTypeFilter.Add(".jpeg");
            fp.FileTypeFilter.Add(".jpg");
            fp.FileTypeFilter.Add(".png");
           // StorageFolder sf = await fp.PickSingleFolderAsync();
            var file = await fp.PickSingleFolderAsync();
            f1 = await file.GetFilesAsync();
          if(file!=null)
            {
                StorageFile sf = f1[0];
                foreach(StorageFile a in f1 )
                {
                IRandomAccessStream i = await a.OpenAsync(FileAccessMode.Read);
                BitmapImage b = new BitmapImage();
                b.SetSource(i);
                flip.Items.Add(b);
              //  ImageProperties img = await sf.Properties.GetImagePropertiesAsync();
                //name.Text = img.DateTaken.ToString();
               //camera.Text = img.CameraModel;
               //Location l = new Location();
                //l.Latitude = img.Latitude.GetValueOrDefault();
                //l.Longitude = img.Longitude.GetValueOrDefault();
                //map.SetView(l, 15);
               //MapLayer.SetPosition(pp, l);
                }

            }
           
        }

       private async void flip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            map.Visibility = Visibility.Visible;
           // StorageFile sf = f1[0];
                foreach(StorageFile a in f1 )
                {
                    ImageProperties img = await a.Properties.GetImagePropertiesAsync();
                    name.Text = img.DateTaken.ToString();
                    camera.Text = img.CameraModel;
                    Location l = new Location();
                    l.Latitude = img.Latitude.GetValueOrDefault();
                    l.Longitude = img.Longitude.GetValueOrDefault();
                    map.SetView(l, 15);
                    MapLayer.SetPosition(pp, l);
                }

        }
    }
}
