using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MosaicBuilder.ViewModel;


namespace MosaicBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Attributes for Mosaic Pallette
        private Point startPoint;
        private List<Ellipse> source = null;

        //Mosaic Pallette
        Ellipse e1 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Black };
        Ellipse e2 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Red };
        Ellipse e3 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Crimson };
        Ellipse e4 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.IndianRed };
        Ellipse e5 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Orange };
        Ellipse e6 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.DarkOrange };
        Ellipse e7 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Yellow };
        Ellipse e8 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.GreenYellow };
        Ellipse e9 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Green };
        Ellipse e10 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Blue };
        Ellipse e11 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Indigo };
        Ellipse e12 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Violet };
        Ellipse e13 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Black };
        Ellipse e14 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.White };
        Ellipse e15 = new Ellipse() { Width = 15, Height = 15, Fill = Brushes.Gray };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMain();
            Ellipse[] paletteArray = { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15 };
            source = new List<Ellipse>(paletteArray);
            //populate palette with colour selection
            PaletteView.ItemsSource = source;
        }

    
    }
}
