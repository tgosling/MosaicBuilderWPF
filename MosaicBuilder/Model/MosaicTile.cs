using System.ComponentModel;

namespace MosaicBuilder.Model
{
    class MosaicTile : INotifyPropertyChanged
    {
        //Required attributes for Ellipse dimension and colour
        private int _radius;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; RaisePropertyChanged(nameof(Radius)); }
        }
        private string _colour;
        public string Colour
        {
            get { return _colour; }
            set { _colour = value; RaisePropertyChanged(nameof(Colour)); }
        }
        //MosaicTile Constructor
        public MosaicTile()
        {
            Radius = 10;
            Colour = "Black";
        }
        
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
