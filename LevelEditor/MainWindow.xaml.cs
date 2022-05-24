using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            string path = $@"{Directory.GetCurrentDirectory()}\Asset";
            if (Directory.Exists(path))
            {
                Console.WriteLine("dd");
                foreach (var a in Tile.Asset.Load.GetAssetList($@"{path}\Tile"))
                {
                    var q = new Template.Tile()
                    {
                        Source = a,
                        Margin = new Thickness(5),
                        Width = Constant.TILE_SIZE,
                        Height = Constant.TILE_SIZE,
                    };

                    /*var assetImage = new Image()
                    {
                        Margin = new Thickness(5),
                        Width = Constant.TILE_SIZE,
                        Height = Constant.TILE_SIZE,
                    };

                    assetImage.Source = new BitmapImage(new Uri(a, UriKind.Absolute));
                    AssetList.Children.Add(assetImage);**/
                    AssetList.Children.Add(q);

                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            var canvas = new Grid() { Margin = new Thickness(20) };

            if (int.TryParse(WidthValue.Text, out int _widthValue))
                for (int i = 0; i < _widthValue; i++)
                {
                    var column = new ColumnDefinition() { Width = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

                    canvas.ColumnDefinitions.Add(column);
                }

            if(int.TryParse(HeightValue.Text,out int _heightValue))
                for (int i = 0; i < _heightValue; i++)
                {
                    var row = new RowDefinition() { Height = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

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
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //TODO: dialog로 저장
            Document.Document.Save($@"{Directory.GetCurrentDirectory()}\a.json");
        }
    }
}
