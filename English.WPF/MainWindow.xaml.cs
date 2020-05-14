using English.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly EnglishContext englishContext;
        public MainWindow()
        {
            InitializeComponent();
            englishContext = new EnglishContext();
            
            ShowVerbs.Click += (s, e) => { ShowList_Click(englishContext.Verbs); };
            ShowPronouns.Click += (s, e) => { ShowList_Click(englishContext.Pronouns); };
            LearnFirstSheme.Click += LearnFirstSheme_Click;

            //Priz();

        }

        //private void Priz()
        //{
        //    foreach (var item in workWithFiles.RulesVerbAndPronouns)
        //    {
        //        var tempVerb = BDToList.Verbs.First(x => x.EnglishWord.Equals(item.Verb.EnglishWord));
        //        var tempPronoun = BDToList.Pronouns.First(x => x.English.Equals(item.Pronoun.English));
        //        var t = item.GetLine();
        //        var tempReal = BDToList.RealTranslates.First(x => x.EnglishSentence.Replace(' ', ' ').Equals(item.RealTranslate.EnglishSentence));
        //        var temp = new DB.Model.RulesVerbAndPronoun(tempVerb,tempPronoun,item.TimeOfASentence,item.TypeOfASentences,tempReal);
        //        BDToList.RulesVerbAndPronouns.Add(temp);
        //    }
        //    BDToList.Save();
        //}

        private void LearnFirstSheme_Click(object sender, RoutedEventArgs e)
        {
            var form = new LearnFirstScheme(englishContext);
            form.ShowDialog();
        }

        private void ShowList_Click<T>(IEnumerable<T> outPut) where T:class
        {
            var form = new ShowTable(outPut.Select(x=>(object)x).ToList());
            form.ShowDialog();
        }
    }
}
