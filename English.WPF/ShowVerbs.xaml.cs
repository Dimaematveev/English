using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для ShowVerbs.xaml
    /// </summary>
    public partial class ShowVerbs : Window
    {
        List<Verb> Verbs = new List<Verb>();
        public ShowVerbs()
        {
            InitializeComponent();
            Loaded += ShowVerbs_Loaded;
        }

        private void ShowVerbs_Loaded(object sender, RoutedEventArgs e)
        {
            VerbsList();
            ListVerbs.ItemsSource = Verbs;
        }

        private void VerbsList()
        {
            string path = @"D:\Дмитрий\source\repos\English\English\DataFiles\Verbs.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Verb tmp = new Verb(line, ';');
                    Verbs.Add(tmp);
                }
            }
        }

    }
}
