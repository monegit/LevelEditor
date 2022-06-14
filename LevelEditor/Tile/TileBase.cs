using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LevelEditor.Tile
{
    internal class TileBase
    {
        public static void CreateTileBase(int width, int height)
        {
            var canvas = new Grid()
            {
                Margin = new Thickness(20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            for (int i = 0; i < width; i++)
            {
                var column = new ColumnDefinition() { Width = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

                canvas.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i < height; i++)
            {
                var row = new RowDefinition() { Height = new GridLength(Constant.TILE_SIZE, GridUnitType.Pixel) };

                canvas.RowDefinitions.Add(row);
            }

            for (int w = 0; w < width; w++)
                for (int h = 0; h < height; h++)
                {
                    var tile = new Tile();

                    tile.SetPosition(w, h);

                    Grid.SetRow(tile, h);
                    Grid.SetColumn(tile, w);
                    canvas.Children.Add(tile);
                }

            MainWindow.Instance!.MapScroll.Content = canvas;
        }
    }
}
