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

        Position position = new(0, 0);

        public void SetPosition(int x, int y)
        {
            position = new Position(x, y);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Constant.isDrag = true;
            Document.Document.map.Add($"{position.x}, {position.y}");
            TileField.Source = new BitmapImage(new System.Uri(Global.SelectedTile, System.UriKind.Absolute)); // Global.SelectedTile;
        }

        private class Position
        {
            public int x;
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (Constant.isDrag)
                TileField.Source = new BitmapImage(new System.Uri(Global.SelectedTile, System.UriKind.Absolute));
        }
    }
}
