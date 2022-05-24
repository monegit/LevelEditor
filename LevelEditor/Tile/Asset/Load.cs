using System.Collections.Generic;
using System.IO;

namespace LevelEditor.Tile.Asset
{
    internal class Load
    {
        public static List<string> GetAssetList(string path)
        {
            var files = new List<string>();

            foreach(var file in Directory.GetFiles(path))
                files.Add(file);

            return files;
        }
    }
}
