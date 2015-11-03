using System;
using System.Collections.Generic;
using ClassLibrary1.zadanie1.Comparer.Comparer;
using ClassLibrary1.zadanie1.Logic.FilesDifferents;
using ClassLibrary1.zadanie1.Logic.FilesDifferents.Abstract;

namespace ClassLibrary1.zadanie1.Comparer.FilesDifferents
{
    public static class DifferentsInFilesGeneratorFactory
    {
        public static IDifferentsInFilesGenerator Create(ComparerType type, List<string> content1, List<string> content2)
        {
            switch (type)
            {
                case ComparerType.Custom: return new CustomDifferentsInFilesGenerator(content1, content2);
            }
            throw new ArgumentException();
        }
    }
}