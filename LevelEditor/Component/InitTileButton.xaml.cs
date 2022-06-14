using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LevelEditor.Component
{
    /// <summary>
    /// InitTileButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InitTileButton : UserControl
    {
        //public event EventHandler Click;

        public InitTileButton()
        {
            InitializeComponent();

            Width = Constant.TILE_SIZE;
            Height = Constant.TILE_SIZE;

            //Tile.Source = new BitmapImage(new Uri(LevelEditor.Tile.Asset.Load.GetAssetList(Global.AssetPath)[0]));
        }

        public void SetTileImage(string url)
        {
            Tile.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
        }
    }
}
