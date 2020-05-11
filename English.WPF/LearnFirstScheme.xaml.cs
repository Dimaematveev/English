using English.DataFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для LearnFirstScheme.xaml
    /// </summary>
    public partial class LearnFirstScheme : Window
    {
        readonly Random rnd = new Random();
        readonly WorkWithFiles workWithFiles;
        int ind;
        List<RealTranslate> UnstudiedWords;


        public LearnFirstScheme(WorkWithFiles workWithFiles)
        {
            InitializeComponent();
            this.workWithFiles = workWithFiles;
            UnstudiedWords = workWithFiles.RealTranslates.Where(x => x.IsLearned <= 0).ToList();


            
            Next.Click += (s, e) => { Next_Click(); }; ;
            Helped.Click += (s, e) => { Helped_Click(); };
            Answer.Click += (s, e) => { Answer_Click(); };
            KeyDown += LearnFirstScheme_KeyDown;
            Fall.Click += (s, e) => { Fall_Click(); };

            FillValue();
        }

        private void Fall_Click()
        {
            UnstudiedWords[ind].IsLearned -= 2;
            UnstudiedWords = workWithFiles.RealTranslates.Where(x => x.IsLearned <= 0).ToList();
            FillValue();
        }

        private void LearnFirstScheme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.H || e.Key == Key.Up)
            {
                Help.Visibility = Visibility.Visible;
                return;
            }
            if (e.Key== Key.A || e.Key == Key.Down)
            {
                Translated.Visibility = Visibility.Visible;
                return;
            }
            if (e.Key == Key.N || e.Key == Key.Right)
            {
                if (Translated.Visibility == Visibility.Visible)
                {
                    Next_Click();
                    return;
                }
                else if (Help.Visibility == Visibility.Visible)
                {
                    Translated.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    Help.Visibility = Visibility.Visible;
                    return;
                }
            }
            if (e.Key == Key.N || e.Key == Key.Left)
            {
                Fall_Click();
                return;
            }
        }

        private void Answer_Click()
        {
            Translated.Visibility = Visibility.Visible;
        }

        private void Helped_Click()
        {
            Help.Visibility = Visibility.Visible;
        }

        private void Next_Click()
        {
            UnstudiedWords[ind].IsLearned += 1;
            UnstudiedWords = workWithFiles.RealTranslates.Where(x => x.IsLearned <= 0).ToList();

            FillValue();

        }

        private void FillValue()
        {
            workWithFiles.SaveRealTranslates();
           
            Help.Visibility = Visibility.Hidden;
            Translated.Visibility = Visibility.Hidden;
           
            Number.Text = $"Осталось: {UnstudiedWords.Count}. Пройдено: {workWithFiles.RealTranslates.Count- UnstudiedWords.Count}";
            if (rnd.Next(0, 5) == 1)
            {
                if (UnstudiedWords.Any(x=> x.IsLearned < 0))
                {
                    UnstudiedWords = UnstudiedWords.Where(x => x.IsLearned < 0).ToList();
                }
                
            }
            ind = rnd.Next(0, UnstudiedWords.Count);
            var unstudiedWord = UnstudiedWords[ind];
            var text = workWithFiles.RulesVerbAndPronouns.Find(x => x.GetLine() == unstudiedWord.EnglishSentence);

            Verb.Text = text.Verb.ToString();
            Translated.Text= text.GetLine();
            Translate.Text = unstudiedWord.RussianSentence;
            Help.Text= $"Почему - так как Время [{text.TimeOfASentence}], Предложение [{text.TypeOfASentences}]";
        }
    }
}
