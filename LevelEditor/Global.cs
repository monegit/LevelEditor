using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LevelEditor
{
    internal class Global
    {
        internal static string SelectedTile = String.Empty;
        internal static string? AssetPath;
        internal static string? SavePath;

        internal static string? TileType;

        internal static Point GetInitTileSelectedPagePosition { get; set; }
    }
}
