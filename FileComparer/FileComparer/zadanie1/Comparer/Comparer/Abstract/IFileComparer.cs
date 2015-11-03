namespace ClassLibrary1.zadanie1.Comparer.Comparer.Abstract
{
    public interface IFileComparer
    {
        string Compare(ComparerType type, string firstPath, string secondPath);
    }
}