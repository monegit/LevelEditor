using Newtonsoft.Json.Linq;
using System.IO;

namespace LevelEditor.Document
{
    internal class Document
    {
        private static JObject document = new();

        public static string title = "";
        public static JArray map = new();

        public static void Save(string path)
        {
            document = new();
            document.Add("Title", title);
            document.Add("Map", map);

            File.WriteAllText(path, document.ToString());
        }
    }
}
