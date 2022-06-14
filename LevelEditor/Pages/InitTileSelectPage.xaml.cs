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

namespace LevelEditor.Pages
{
    /// <summary>
    /// InitTileSelectPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InitTileSelectPage : UserControl
    {
        public InitTileSelectPage()
        {
            InitializeComponent();

            Width = 300;
            Height = 400;

            Grid.SetRowSpan(this, MainWindow.Instance!.Modal.RowDefinitions.Count);
            Grid.SetColumnSpan(this, MainWindow.Instance.Modal.ColumnDefinitions.Count);
        }

        private void HidePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
