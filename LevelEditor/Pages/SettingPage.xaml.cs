using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace LevelEditor.Pages
{
    /// <summary>
    /// SettingPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingPage : System.Windows.Controls.UserControl
    {
        InitTileSelectPage? initTileSelectPage;

        public SettingPage()
        {
            InitializeComponent();

            SavePathSettingButton.Content = Global.SavePath ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            AssetPathSettingButton.Content = Global.AssetPath ?? "(선택)";
        }

        private void SavePathSettingButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.SaveFileDialog()
            {
                Filter = "Json File|*.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePathSettingButton.Content = Global.SavePath = dialog.FileName;
            }
        }

        private void AssetPathSettingButton_Click(object sender, RoutedEventArgs e)
        {
            var folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                AssetPathSettingButton.Content = Global.AssetPath = folder.SelectedPath;
                InitTileSelectedButton.SetTileImage(Tile.Asset.Load.GetAssetList(folder.SelectedPath)[0]);
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow.Instance!.ModalBackground.Visibility = Visibility.Collapsed;

            if (int.TryParse(WidthValue.Text, out int width) && int.TryParse(HeightValue.Text, out int height))
                Tile.TileBase.CreateTileBase(width, height);
            else
                System.Windows.MessageBox.Show("asdf");
        }

        private void InitTileSelectedButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var windowPosition = System.Windows.Application.Current.MainWindow;

            if (initTileSelectPage == null)
            {
                initTileSelectPage = new InitTileSelectPage()
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                };
                initTileSelectPage.Margin = new Thickness(InitTileSelectedButton.PointToScreen(
                    new Point(0, 0)).X - windowPosition.Left + InitTileSelectedButton.Width,
                        InitTileSelectedButton.PointToScreen(new Point(0, 0)).Y - windowPosition.Top - (initTileSelectPage.Height / 2) - (InitTileSelectedButton.Height / 2) + (SystemParameters.WindowCaptionHeight / 2),
                        0, 0);

                MainWindow.Instance?.Modal.Children.Add(initTileSelectPage);
            }
            else
                initTileSelectPage.Visibility = Visibility.Visible;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var windowPosition = System.Windows.Application.Current.MainWindow;

            if (initTileSelectPage != null)
                initTileSelectPage!.Margin = new Thickness(InitTileSelectedButton.PointToScreen(
                    new Point(0, 0)).X - windowPosition.Left + InitTileSelectedButton.Width,
                    InitTileSelectedButton.PointToScreen(new Point(0, 0)).Y - windowPosition.Top - (initTileSelectPage.Height / 2) - (InitTileSelectedButton.Height / 2) + (SystemParameters.WindowCaptionHeight / 2),
                    0, 0);
        }
    }
}
