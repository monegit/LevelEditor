using Newtonsoft.Json.Linq;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LevelEditor.Tile
{
    /// <summary>
    /// Tile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();
        }

        public Position position = new(0, 0);
        public bool IsCollision { get; set; } = false;
        bool isRemove = false;

        public void SetPosition(int x, int y)
        {
            position = new Position(x, y);
        }

        private void DrawTile()
        {
            IsCollision = (bool)MainWindow.Instance?.UseCollision.IsChecked!;
            TileField.Source = new BitmapImage(new Uri(Global.SelectedTile, UriKind.Absolute));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Constant.isDrag = true;
            DrawTile();
        }

        public class Position
        {
            public int X;
            public int Y;

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (Constant.isDrag)
            {
                DrawTile();
            }
        }

        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
