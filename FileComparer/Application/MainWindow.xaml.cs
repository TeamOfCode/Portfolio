using System;
using System.Windows;
using ClassLibrary1.zadanie1.Comparer.Comparer;
using ClassLibrary1.zadanie1.Comparer.Comparer.Abstract;

using Microsoft.Win32;

namespace Application
{
    public partial class MainWindow : Window
    {
        private string _firstPath;
        private string _secondPath;
        private IFileComparer _fileComparer;

        public MainWindow()
        {
            _fileComparer = new FileComparer();
            InitializeComponent();
        }

        private void BtnOpenFirstFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _firstPath = dialog.FileName;
                LabelForFirstPath.Content = GetFileName(_firstPath);
            }
        }

        private void BtnOpenSecondFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _secondPath = dialog.FileName;
                LabelForSecondPath.Content = GetFileName(_secondPath);
            }
        }

        private void Compare_Click(object sender, RoutedEventArgs e)
        {
            if (_firstPath == null || _secondPath == null)
            {
                WarningWindow worningWindow = new WarningWindow("Choose two files !!!", this);
                worningWindow.Show();
            }
            else
            {
                try
                {
                    var result = _fileComparer.Compare(ComparerType.Custom, _firstPath, _secondPath);
                    TextBlock.Text = result;
                }
                catch (Exception ex)
                {
                    TextBlock.Text = ex.Message;
                }
                
            }
        }

        private string GetFileName(string path)
        {
            var splittedPath = path.Split('\\');
            return splittedPath[splittedPath.Length - 1];
        }
    }
}