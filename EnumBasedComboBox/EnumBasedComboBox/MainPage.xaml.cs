using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TestComponent;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EnumBasedComboBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FontStyleContent.Content = FontStyle.Normal;
            CustomContent.Content = Test.A;
            ComponentEnumContent.Content = ApplicationDataLocality.Local;            
        }

        private void FontStyleClick(object sender, RoutedEventArgs e)
        {
            EnumComboBox.SelectedItemEnum = FontStyle.Normal;
        }

        private void CustomClick( object sender, RoutedEventArgs e )
        {
            EnumComboBox.SelectedItemEnum = Test.A;
        }

        private void ComponentEnumClick(object sender, RoutedEventArgs e)
        {
            EnumComboBox.SelectedItemEnum = ComponentEnum.A;
        }
    }

    public enum Test
    {
        A, B, C
    }
}
