using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.zadanie1.Logic.FilesDifferents.Abstract;

namespace ClassLibrary1.zadanie1.Logic.FilesDifferents
{
    public class CustomDifferentsInFilesGenerator : IDifferentsInFilesGenerator
    {
        private readonly List<string> _firstFileContent;
        private readonly List<string> _secondFileContent;
        private readonly StringBuilder _contentsDifferents;

        public CustomDifferentsInFilesGenerator(List<string> firstFileContent, List<string> secondFileContent)
        {
            _firstFileContent = firstFileContent;
            _secondFileContent = secondFileContent;
            _contentsDifferents = new StringBuilder();
        }

        public string Generate()
        {
            if (_firstFileContent.Count < _secondFileContent.Count)
            {
                AddDifferentsFromCompareFiles(_firstFileContent);
                AddOnlyOneLineDifferents(_firstFileContent, _secondFileContent);
            }
            else
            {
                AddDifferentsFromCompareFiles(_secondFileContent);
                AddOnlyOneLineDifferents(_secondFileContent,_firstFileContent);
            }
            return _contentsDifferents.ToString();
        }

        private void AddDifferentsFromCompareFiles(List<string> smallerContent)
        {
            for (int i = 0; i < smallerContent.Count; i++)
            {
                if (IsStringsEquals(_firstFileContent[i], _secondFileContent[i]))
                {
                    continue;
                }
                if (OnlyOneLineIsEmpty(_firstFileContent[i], _secondFileContent[i]))
                {
                    AddDifferentsDetails(DifferentInFilesPatterns.OneLineEmptyPattern, i);
                }
                if (IsStringsEqualsWithIgnoreCase(_firstFileContent[i], _secondFileContent[i]))
                {
                    AddDifferentsDetails(DifferentInFilesPatterns.LinesEqualsWithIgnoreCasePattern, i);
                }
                else
                {
                    AddDifferentsDetails(DifferentInFilesPatterns.DifferentLinePattern, i);
                }
            }
        }

        private void AddOnlyOneLineDifferents(List<string> firstFileContent, List<string> secondFileContent)
        {
            for (int i = firstFileContent.Count; i < secondFileContent.Count; i++)
            {
                _contentsDifferents.Append(string.Format(DifferentInFilesPatterns.OneLineEmptyPattern, i + 1));
            }
        }

        private bool OnlyOneLineIsEmpty(string text, string text2)
        {
            string textTrimmed = text.Trim();
            string text2Trimmed = text2.Trim();
            return ((textTrimmed.Length > 0 && text2Trimmed.Length == 0) ||
                    (textTrimmed.Length == 0 && text2Trimmed.Length > 0));
        }

        private bool IsStringsEquals(string text, string text2)
        {
            return (string.CompareOrdinal(text, text2) == 0);
        }

        private bool IsStringsEqualsWithIgnoreCase(string text, string text2)
        {
            return (string.Compare(text, text2, StringComparison.OrdinalIgnoreCase) == 0);
        }

        private void AddDifferentsDetails(string pattern, int lineNumber)
        {
            _contentsDifferents.Append(string.Format(pattern, lineNumber + 1));
            _contentsDifferents.Append(string.Format(DifferentInFilesPatterns.LinesDetailsPattern,
                        _firstFileContent[lineNumber], _secondFileContent[lineNumber]));
        }
    }
}