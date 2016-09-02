using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace LateLoadFlipView
{
    public class FlipViewItemViewModel : INotifyPropertyChanged
    {
        private bool _isLoaded = false;

        private string _dateLoaded = "";

        public string DateLoaded
        {
            get
            {
                return _dateLoaded;
            }
            set
            {
                _dateLoaded = value;
                OnPropertyChanged();
            }
        }

        private ImageSource _imageSource = null;

        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Forces the loading of the item
        /// </summary>
        public void ForceLoad()
        {
            //prevent loading twice
            if ( !_isLoaded )
            {                
                //set current date (just to prove it didn't load aheead of time)
                DateLoaded = DateTime.Now.ToString( "F" );
                //load the image (probably from network?)
                ImageSource = new BitmapImage( new Uri( "ms-appx:///Assets/StoreLogo.png" ) );

                _isLoaded = true;
            }
        }

        /// <summary>
        /// INotifyPropertyChanged implementation
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
