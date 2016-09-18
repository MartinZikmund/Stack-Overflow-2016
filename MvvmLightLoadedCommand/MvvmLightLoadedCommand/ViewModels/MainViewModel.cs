using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLightLoadedCommand.ViewModels
{
    public class MainViewModel : ViewModelBase
    {      
        public ICommand LoadedCommand { get; } = new RelayCommand( async () => await new MessageDialog( "Loaded", "Some Content" ).ShowAsync() );
    }
}
