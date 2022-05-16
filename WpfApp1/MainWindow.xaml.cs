using LevelEditor.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

            int _widthValue;
            int _heightValue;

            bool isWidth = int.TryParse(WidthValue.Text, out _widthValue);

            if (isWidth)
                for (int w = 0; w < int.Parse(WidthValue.Text); w++)
                {
                    bool isHeight = int.TryParse(HeightValue.Text, out _heightValue);

                    if (isHeight)
                        for (int h = 0; h < int.Parse(HeightValue.Text); h++)
                        {
                            var row = new RowDefinition() { Height = new GridLength(tileSize, GridUnitType.Pixel) };
                            var column = new ColumnDefinition() { Width = new GridLength(tileSize, GridUnitType.Pixel) };

                            MapCanvas.RowDefinitions.Add(row);
                            MapCanvas.ColumnDefinitions.Add(column);

                            var tile = new Tile();

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
            }

        }
    }
}
