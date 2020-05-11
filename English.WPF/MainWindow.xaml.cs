using System.Windows;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowVerbs.Click += ShowVerbs_Click;
            LearnFirstSheme.Click += LearnFirstSheme_Click;
        }

        private void LearnFirstSheme_Click(object sender, RoutedEventArgs e)
        {
            var form = new LearnFirstScheme();
            form.ShowDialog();
        }

        private void ShowVerbs_Click(object sender, RoutedEventArgs e)
        {
            var form = new ShowVerbs();
            form.ShowDialog();
        }
    }
}
