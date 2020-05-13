using English.DB;
using English.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace English.WPF
{
    /// <summary>
    /// Логика взаимодействия для LearnFirstScheme.xaml
    /// </summary>
    public partial class LearnFirstScheme : Window
    {
        readonly Random rnd = new Random();
        readonly EnglishContext englishContext;
        int ind;
        List<RealTranslate> UnstudiedWords;


        public LearnFirstScheme(EnglishContext englishContext)
        {
            InitializeComponent();
            this.englishContext = englishContext;
            UnstudiedWords = englishContext.RealTranslates.Where(x => x.IsLearned <= 1).ToList();


            
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
            UnstudiedWords = englishContext.RealTranslates.Where(x => x.IsLearned <= 1).ToList();
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
                Next_Click();
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
            


            if (Translated.Visibility == Visibility.Visible)
            {
                UnstudiedWords[ind].IsLearned += 1;
                UnstudiedWords = englishContext.RealTranslates.Where(x => x.IsLearned <= 1).ToList();
                FillValue();
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

        private void FillValue()
        {
            englishContext.SaveChanges();
           
            Help.Visibility = Visibility.Hidden;
            Translated.Visibility = Visibility.Hidden;
           
            Number.Text = $"Пройдено Р-А: {englishContext.RealTranslates.Count(x => x.IsLearned == 1)}, Пройдено А-Р: {englishContext.RealTranslates.Count(x => x.IsLearned == 2)}, ";
            int rand = rnd.Next(0, 11);
            if (rand == 0)
            {
                //Показываем слова которые в прошлом не получились
                if (UnstudiedWords.Any(x=> x.IsLearned < 0))
                {
                    UnstudiedWords = UnstudiedWords.Where(x => x.IsLearned < 0).ToList();
                }
            }
            else if (rand <= 5)
            {
                //Показываем слова у которых IsLearned = 0. Т.е. перевод с русского на английский
                if (UnstudiedWords.Any(x => x.IsLearned == 0))
                {
                    UnstudiedWords = UnstudiedWords.Where(x => x.IsLearned == 0).ToList();
                }
            }
            else
            {
                //Показываем слова у которых IsLearned = 0. Т.е. перевод с английского на русский
                if (UnstudiedWords.Any(x => x.IsLearned > 0))
                {
                    UnstudiedWords = UnstudiedWords.Where(x => x.IsLearned > 0).ToList();
                }
            }
            ind = rnd.Next(0, UnstudiedWords.Count);
            var unstudiedWord = UnstudiedWords[ind]; 
             var text = UnstudiedWords[ind].RulesVerbAndPronouns.First();

            Verb.Text = text.Verb.ToString();

            
            if (rand <= 5)
            {
                Translated.Text = text.GetLine();
                Translate.Text = unstudiedWord.RussianSentence;
            }
            else
            {
                Translated.Text = unstudiedWord.RussianSentence; 
                Translate.Text = text.GetLine();
            }

            Help.Text= $"Почему - так как Время [{text.TimeOfASentence}], Предложение [{text.TypeOfASentences}]";
        }
    }
}
