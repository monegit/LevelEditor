using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace LevelEditor.Document
{
    internal class Document
    {
        public static JObject document = new();

        public static string title = "";
        public static JArray map = new();

        public static void Init()
        {
            document = new();
            map = new();
            document.Add("Title", title);
            document.Add("Map", map);
        }

        public static void Save(string path)
        {
            Init();

            var grid = (MainWindow.Instance?.MapScroll.Content as Grid)!;

            int index = 0;
            foreach (Tile.Tile t in grid.Children)
            {
                if (t.TileField.Source != null)
                {
                    var tile = new JArray
                    {
                        $"{t.position.X}, {t.position.Y}",
                        t.TileField.Source.ToString().Split("/")[Global.SelectedTile.Split("/").Length - 1].Split(".")[0],
                        t.IsCollision
                    };

                    //Trace.WriteLine(index, t.TileField.Source.ToString());
                    map.Add(tile);
                    index++;
                }
            }


            File.WriteAllText(path, document.ToString());
        }

    }
}
