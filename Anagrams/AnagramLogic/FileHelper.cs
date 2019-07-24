using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AnagramLogic
{
    public static class FileHelper
    {
        public static IEnumerable<string> GetAllWordsFromFile(string filename)
        {
            var fileWithPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filename.Contains(".txt") ? filename : $"{filename}.txt");
            var allData = File.ReadAllLines(fileWithPath);

            return allData;
        }
    }
}
