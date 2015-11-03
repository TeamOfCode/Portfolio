using System.IO;

namespace ClassLibrary1.zadanie1.Utils
{
    public class FileOperations
    {
        public string ReadAllContent(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}