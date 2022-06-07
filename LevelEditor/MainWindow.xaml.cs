using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow? Instance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;

            string path = $@"{Directory.GetCurrentDirectory()}\Asset";
            if (Directory.Exists(path))
            {
                foreach (var a in Tile.Asset.Load.GetAssetList($@"{path}\Tile"))
                {
                    var assetImage = new Template.Tile()
                    {
                        Source = a,
                        Margin = new Thickness(5),
                        Width = Constant.TILE_SIZE,
                        Height = Constant.TILE_SIZE,
                    };

                    AssetList.Children.Add(assetImage);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            var canvas = new Grid()
            {
                Margin = new Thickness(20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            if (int.TryParse(WidthValue.Text, out int _widthValue))
                for (int i = 0; i < _widthValue; i++)
                {
                    var column = new ColumnDefinition() { Width = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

                    canvas.ColumnDefinitions.Add(column);
                }

            if (int.TryParse(HeightValue.Text, out int _heightValue))
                for (int i = 0; i < _heightValue; i++)
                {
                    var row = new RowDefinition() { Height = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

                    canvas.RowDefinitions.Add(row);
                }

            for (int w = 0; w < _widthValue; w++)
                for (int h = 0; h < _heightValue; h++)
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

            //Document.Document.Save();
            //Trace.WriteLine((a.Children[11] as Tile.Tile).TileField.Source.ToString());
        }

        private void TileBorderVisible_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)((CheckBox)sender).IsChecked!)
            {
                //MessageBox.Show("true");
            }
        }

        private void Window_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Constant.isDrag = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show((MapScroll.Content as Grid)?.RowDefinitions.Count.ToString());
        }
    }
}
