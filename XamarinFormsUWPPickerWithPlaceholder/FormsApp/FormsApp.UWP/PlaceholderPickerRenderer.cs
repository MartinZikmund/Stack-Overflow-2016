using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsApp;
using FormsApp.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
[assembly: ExportRenderer( typeof( PlaceholderPicker ), typeof( PlaceholderPickerRenderer ) )]
namespace FormsApp.UWP
{
    

    public class PlaceholderPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {            
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.PlaceholderText = Element.Title;
                Control.Header = null;
            }
        }
    }
}
