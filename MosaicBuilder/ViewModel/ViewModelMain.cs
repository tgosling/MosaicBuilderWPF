
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace MosaicBuilder.ViewModel
{
    class ViewModelMain : INotifyPropertyChanged
    {
       
        //Handle File->Exit menu click
        private void exitApp(object obj)
        {
            Application.Current.Shutdown();
        }

        //basic view model base
        internal void RaisePropertyChanged(string prop)
        {
            if(PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
