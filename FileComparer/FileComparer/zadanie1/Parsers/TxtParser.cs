using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.zadanie1.Parsers.Abstract;
using ClassLibrary1.zadanie1.Utils;

namespace ClassLibrary1.zadanie1.Parsers
{
    public class TxtParser : IDocumentParser
    {
        protected FileOperations FileOperations;
        private readonly char _splitter;

        public TxtParser(char splitter = '\n')
        {
            FileOperations = new FileOperations();
            _splitter = splitter;
        }

        public List<string> GetAllResults(string path)
        {
            string fileContent = FileOperations.ReadAllContent(path);
            return fileContent.Split(_splitter).ToList();
        }
    }
}