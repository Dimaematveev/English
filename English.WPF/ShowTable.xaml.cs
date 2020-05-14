using System.Collections.Generic;
using System.Windows;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для ShowVerbs.xaml
    /// </summary>
    public partial class ShowTable : Window
    {
        readonly List<object> ListObject;
        public ShowTable(List<object> listObject)
        {
            InitializeComponent();
            ListObject = listObject;
            Loaded += ShowVerbs_Loaded;
        }

        private void ShowVerbs_Loaded(object sender, RoutedEventArgs e)
        {
            ListVerbs.ItemsSource = ListObject;
        }


    }
}
