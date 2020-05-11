using English.DataFiles;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkWithFiles workWithFiles;
        public MainWindow()
        {
            InitializeComponent();
            workWithFiles = new WorkWithFiles();
            ShowVerbs.Click += (s, e) => { ShowList_Click(workWithFiles.Verbs); };
            ShowPronouns.Click += (s, e) => { ShowList_Click(workWithFiles.Pronouns); };
            LearnFirstSheme.Click += LearnFirstSheme_Click;
        }

        private void LearnFirstSheme_Click(object sender, RoutedEventArgs e)
        {
            var form = new LearnFirstScheme(workWithFiles);
            form.ShowDialog();
        }

        private void ShowList_Click<T>(List<T> outPut) where T:class
        {
            var form = new ShowVerbs(outPut.Select(x=>(object)x).ToList());
            form.ShowDialog();
        }
    }
}
