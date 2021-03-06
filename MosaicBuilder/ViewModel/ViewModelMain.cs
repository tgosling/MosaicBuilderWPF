﻿
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using MosaicBuilder.Model;
using MosaicBuilder.Helper;

namespace MosaicBuilder.ViewModel
{
    class ViewModelMain : INotifyPropertyChanged
    {
       //RelayCommands
       public RelayCommand exitCommand { get; set; }
       public RelayCommand aboutCommand { get; set; }
        
       public ViewModelMain()
        {
            //Mosaic Board
            MosaicBrd = new ObservableCollection<MosaicTile>();
            const int TOTAL_MOSAIC_TILES = 2500;
            //populate Mosaic Board with Tile Pieces
            for (int i = 0; i < TOTAL_MOSAIC_TILES; i++)
                MosaicBrd.Add(new MosaicTile());

            //Relay Commands
            exitCommand = new RelayCommand(exitApp);
            aboutCommand = new RelayCommand(aboutApp);
        }

        #region Menu Handlers
        //Handle File->Exit menu click
        private void exitApp(object obj)
        {
            Application.Current.Shutdown();
        }

        //Handle Help->About menu click
        private void aboutApp(object obj)
        {
            MessageBox.Show("Click and Drag Tile Pieces from Tile Control\non to the Mosaic Board to make pretty pictures\n\nAuthor: Tyler MJ Gosling", "About");
        }
        #endregion //End Menu Handlers

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
