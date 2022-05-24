using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace LevelEditor.Template
{
    /// <summary>
    /// Tile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Tile : UserControl
    {
        [Category("Source"), Description("이미지 등록")]
        public string Source
        {
            set => TileTemplate.Source = new BitmapImage(new Uri(value, UriKind.Absolute));
        }

        public Tile()
        {
            InitializeComponent();
        }

        private void TileTemplate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Global.SelectedTile = TileTemplate.Source.ToString();
        }
    }
}
