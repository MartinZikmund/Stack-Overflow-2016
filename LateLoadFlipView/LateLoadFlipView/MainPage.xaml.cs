using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LateLoadFlipView
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

        /// <summary>
        /// Just a sample data source
        /// </summary>
        public ObservableCollection<FlipViewItemViewModel> Items = new ObservableCollection<FlipViewItemViewModel>()
        {
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel(),
            new FlipViewItemViewModel()
        };

        private void Selector_OnSelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            //get the currently selected item
            var currentItem = FlipControl.SelectedItem as FlipViewItemViewModel;
            //force-load it
            currentItem?.ForceLoad();
        }
    }
}
