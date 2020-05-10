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
        }

        private void ShowVerbs_Click(object sender, RoutedEventArgs e)
        {
            var form = new ShowVerbs();
            form.ShowDialog();
        }
    }
}
