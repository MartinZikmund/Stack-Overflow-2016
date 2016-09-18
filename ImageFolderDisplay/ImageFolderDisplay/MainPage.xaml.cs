using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImageFolderDisplay
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


        private async void ButtonBase_OnClick( object sender, RoutedEventArgs e )
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.FileTypeFilter.Add( ".jpg" );
            var folder = await folderPicker.PickSingleFolderAsync();
            var filesList =
                await folder.CreateFileQueryWithOptions(new QueryOptions(CommonFileQuery.DefaultQuery,
                        new string[] {".jpg"})).GetFilesAsync();
            for ( int i = 0; i < filesList.Count; i++ )
            {
                using ( var stream = await filesList[ i ].OpenAsync( Windows.Storage.FileAccessMode.Read ) )
                {
                    Debug.WriteLine( filesList[ i].Name);
                    var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    await bitmapImage.SetSourceAsync( stream );
                    Image m = new Image();
                    m.Source = bitmapImage;
                    Stack.Children.Add( m );
                }

            }
        }
    }
}
