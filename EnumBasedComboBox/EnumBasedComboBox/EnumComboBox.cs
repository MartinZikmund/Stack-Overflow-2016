using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EnumBasedComboBox
{
    public class EnumComboBox : ComboBox
    {
        public static readonly DependencyProperty SelectedItemEnumProperty = DependencyProperty.Register(
            "SelectedItemEnum", typeof( object ), typeof( EnumComboBox ), new PropertyMetadata( default( object ), SelectedItemEnumChanged ) );

        private static void SelectedItemEnumChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
        {
            if ( e.NewValue != null )
            {
                if ( e.OldValue == null || e.OldValue.GetType() != e.NewValue.GetType() )
                {
                    var enumComboBox = ( EnumComboBox )dependencyObject;
                    var values = Enum.GetValues( enumComboBox.SelectedItemEnum.GetType() ).Cast<object>().ToList();
                    enumComboBox.ItemsSource = values;
                }
            }
        }

        public object SelectedItemEnum
        {
            get { return ( object )GetValue( SelectedItemEnumProperty ); }
            set { SetValue( SelectedItemEnumProperty, value ); }
        }
    }
}
