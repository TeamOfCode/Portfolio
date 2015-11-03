using System.Windows;

namespace Application
{
    /// <summary>
    /// Interaction logic for WorningWindow.xaml
    /// </summary>
    public partial class WarningWindow : Window
    {

        public WarningWindow(string text, MainWindow main)
        {
            InitializeComponent();
            Left = main.Left + main.Width /6;
            Top = main.Top + main.Height /3;
            LabelForWarning.Content = text;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
