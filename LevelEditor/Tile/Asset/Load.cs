using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LevelEditor.Tile.Asset
{
    internal class Load
    {
        public static List<string> getAssetList(string path)
        {
            var files = new List<string>();

            foreach(var file in Directory.GetFiles(path))
                files.Add(file);

            return files;
        }
    }
}
