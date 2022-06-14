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
