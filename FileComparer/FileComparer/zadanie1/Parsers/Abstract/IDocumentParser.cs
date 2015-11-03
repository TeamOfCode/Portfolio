using System.Collections.Generic;

namespace ClassLibrary1.zadanie1.Parsers.Abstract
{
    public interface IDocumentParser
    {
        List<string> GetAllResults(string path);
    }
}