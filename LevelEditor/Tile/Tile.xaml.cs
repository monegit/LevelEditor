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
            Document.Document.map.Add($"{position.x}, {position.y}");
            TileField.Source = new BitmapImage(new System.Uri(Global.SelectedTile, System.UriKind.Absolute)); // Global.SelectedTile;
            //MessageBox.Show($"{position.x}, {position.y}");
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
    }
}
