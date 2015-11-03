using System;
using ClassLibrary1.zadanie1.Parsers.Abstract;

namespace ClassLibrary1.zadanie1.Parsers
{
    public class ParserFactory
    {
        private const string TextFileExtension = ".txt";

        public static IDocumentParser Create(string path)
        {
            if(path.EndsWith(TextFileExtension))
                return new TxtParser();
            throw new ArgumentException();
        }
    }
}