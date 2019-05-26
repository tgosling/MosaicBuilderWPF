
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using MosaicBuilder.Model;

namespace MosaicBuilder.ViewModel
{
    class ViewModelMain : INotifyPropertyChanged
    {
       public ViewModelMain()
        {
            //Mosaic Board
            MosaicBrd = new ObservableCollection<MosaicTile>();
            const int TOTAL_MOSAIC_TILES = 2500;
            //populate Mosaic Board with Tile Pieces
            for (int i = 0; i < TOTAL_MOSAIC_TILES; i++)
                MosaicBrd.Add(new MosaicTile());
        }

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

        #region Mosiac Board Pieces
        private ObservableCollection<MosaicTile> MosaicBrd_;
        public ObservableCollection<MosaicTile> MosaicBrd
        {
            get { return MosaicBrd_; }
            set { MosaicBrd_ = value; }
        }
        #endregion
    }
}
