using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        //Palette 
        #region Palette Ellipses
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
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMain();
            Ellipse[] paletteArray = { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15 };
            source = new List<Ellipse>(paletteArray);
            //populate palette with colour selection
            PaletteView.ItemsSource = source;
        }


        //Drag and Drop Controls
        #region List Box Drag
        //ListBox Preview Click
        private void ListBoxsource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Get the starting point
            startPoint = e.GetPosition(null);//abs position
        }

        //ListBox Mouse Move/Drag
        private void ListBoxSource_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if(e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                //get the selected listbox item
                ListBox palletteBox = sender as ListBox;
                //use FindAnccestor to acquire the OriginalSource, go up the visual tree 
                //until a ListBoxItem is hit. Require ListBoxItem to get the string
                ListBoxItem listBoxItem = findAncestor<ListBoxItem>((DependencyObject)e.OriginalSource);

                if(listBoxItem != null)
                {
                    //Find the data behind the listBoxItem
                    Ellipse theItem = (Ellipse)palletteBox.ItemContainerGenerator.ItemFromContainer(listBoxItem);
                    //Create a DataObject continaing the string to be dragged
                    DataObject dragData = new DataObject(typeof(Ellipse), theItem);
                    //Initialize the dragging 
                    DragDrop.DoDragDrop(listBoxItem, dragData, DragDropEffects.Move);
                }
                
            }
        }
        #endregion

        #region Ellipse DragDrop
        private void EllipseDestination_DragEnter(object sender, DragEventArgs e)
        {
            //check if it is not ellipse or if it is the sending source
            if (!e.Data.GetDataPresent(typeof(Ellipse)) || sender == e.Source)
                e.Effects = DragDropEffects.None;
        }

        private void EllipseDestination_Drop(object sender, DragEventArgs e)
        {
            //Check if it is ellipse
            if(e.Data.GetDataPresent(typeof(Ellipse)))
            {
                Ellipse ColorSrc = (Ellipse)e.Data.GetData(typeof(Ellipse));
                Ellipse destEllip = sender as Ellipse;
                destEllip.Fill = ColorSrc.Fill;
            }
        }
        #endregion

        private static T findAncestor<T>(DependencyObject current)
       where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }
}
