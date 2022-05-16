using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            int tileSize = 30;
            var canvas = new Grid() { Margin = new Thickness(20) };

            if (int.TryParse(WidthValue.Text, out int _widthValue))
                for (int i = 0; i < _widthValue; i++)
                {
                    var column = new ColumnDefinition() { Width = new GridLength(tileSize, GridUnitType.Pixel) };

                    canvas.ColumnDefinitions.Add(column);
                }

            if(int.TryParse(HeightValue.Text,out int _heightValue))
                for (int i = 0; i < _heightValue; i++)
                {
                    var row = new RowDefinition() { Height = new GridLength(tileSize, GridUnitType.Pixel) };

                    canvas.RowDefinitions.Add(row);
                }

            for(int w = 0; w < _widthValue; w++)
                for(int h = 0; h < _heightValue; h++)
                {
                    var tile = new Tile.Tile();

                    tile.SetPosition(w, h);

                    Grid.SetRow(tile, h);
                    Grid.SetColumn(tile, w);
                    canvas.Children.Add(tile);
                }

            MapScroll.Content = canvas;


            /*bool isWidth = int.TryParse(WidthValue.Text, out int _widthValue);

            if (isWidth)
                for (int w = 0; w < _widthValue; w++)
                {

                    int _heightValue;
                    bool isHeight = int.TryParse(HeightValue.Text, out _heightValue);

                    if (isHeight)
                        for (int h = 0; h < _heightValue; h++)
                        {
                            var row = new RowDefinition() { Height = new GridLength(tileSize, GridUnitType.Pixel) };
                            var column = new ColumnDefinition() { Width = new GridLength(tileSize, GridUnitType.Pixel) };

                            MapCanvas.RowDefinitions.Add(row);
                            MapCanvas.ColumnDefinitions.Add(column);

                            var tile = new Tile.Tile();
                            tile.SetPosition(w, h);

                            Grid.SetRow(tile, h);
                            Grid.SetColumn(tile, w);
                            MapCanvas.Children.Add(tile);
                        }
                    else
                    {
                        MessageBox.Show("Height is not Number", "Error");
                        HeightValue.Focus();
                        break;
                    }
                }
            else
            {
                MessageBox.Show("Width is not Number", "Error");
                WidthValue.Focus();
            }*/
            //MessageBox.Show(MapCanvas.ActualWidth.ToString());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Document.Document.Save(@"C:\Users\pjw97\Desktop\a.txt");
            //File.WriteAllText(@"C:\Users\pjw97\Desktop\a.txt", Document.Document.map.ToString());
        }
    }
}
