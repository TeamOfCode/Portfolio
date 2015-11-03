using ClassLibrary1.zadanie1.Comparer.Comparer.Abstract;
using ClassLibrary1.zadanie1.Comparer.FilesDifferents;
using ClassLibrary1.zadanie1.Logic.FilesDifferents;
using ClassLibrary1.zadanie1.Parsers;

namespace ClassLibrary1.zadanie1.Comparer.Comparer
{
    public class FileComparer : IFileComparer
    {
        public string Compare(ComparerType type, string firstPath, string secondPath)
        {
            var firstContent = ParserFactory.Create(firstPath).GetAllResults(firstPath);
            var secondContent = ParserFactory.Create(secondPath).GetAllResults(secondPath);
            var generator = DifferentsInFilesGeneratorFactory.Create(type, firstContent, secondContent);
            return generator.Generate();
        }      
    }
}