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
        bool isRusEn;
        List<RulesVerbAndPronoun> UnstudiedWords;


        public LearnFirstScheme(EnglishContext englishContext)
        {
            InitializeComponent();
            this.englishContext = englishContext;

            SelectAllWordWhatsNotLearned();




            Next.Click += (s, e) => { Next_Click(); }; ;
            Helped.Click += (s, e) => { Helped_Click(); };
            Answer.Click += (s, e) => { Answer_Click(); };
            KeyDown += LearnFirstScheme_KeyDown;
            Fall.Click += (s, e) => { Fall_Click(); };

            
        }

        private void SelectAllWordWhatsNotLearned()
        {
            
            englishContext.SaveChanges();
            //Выборка всех слов которые не прошли
            UnstudiedWords = englishContext.RulesVerbAndPronouns.Where(x => x.RealTranslate.IsLearnedRuEn <= 1 || x.RealTranslate.IsLearnedEnRu <= 1).ToList();
            FillValue();
        }

        private void Fall_Click()
        {
            if (isRusEn)
            {
                if (UnstudiedWords[ind].RealTranslate.IsLearnedRuEn > -100)
                {
                    UnstudiedWords[ind].RealTranslate.IsLearnedRuEn -= 2;
                }
            }
            else
            {
                if (UnstudiedWords[ind].RealTranslate.IsLearnedEnRu > -100)
                {
                    UnstudiedWords[ind].RealTranslate.IsLearnedEnRu -= 2;
                }
            }
           
            SelectAllWordWhatsNotLearned();
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
                return;
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
                if (isRusEn)
                {
                    UnstudiedWords[ind].RealTranslate.IsLearnedRuEn += 1;
                }
                else
                {
                    UnstudiedWords[ind].RealTranslate.IsLearnedEnRu += 1;
                }
                
                SelectAllWordWhatsNotLearned();
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
            HiddenNeedElement();

            {
                int RuEnRight = englishContext.RealTranslates.Count(x => x.IsLearnedRuEn >= 1);
                int RuEnNotRight = englishContext.RealTranslates.Count(x => x.IsLearnedRuEn < 0);
                int EnRuRight = englishContext.RealTranslates.Count(x => x.IsLearnedEnRu >= 1);
                int EnRuNotRight = englishContext.RealTranslates.Count(x => x.IsLearnedEnRu < 0);
                Number.Text = $"Rus-En: {RuEnRight}({RuEnNotRight}); En-Rus: {EnRuRight}({EnRuNotRight})!";
            }
            SelectWords();

            ind = rnd.Next(0, UnstudiedWords.Count);
            var unstudiedWord = UnstudiedWords[ind];
            Verb.Text = unstudiedWord.Verb.ToString();

            if (isRusEn)
            {
                Translate.Text = unstudiedWord.RealTranslate.RussianSentence;
                Translated.Text = unstudiedWord.RealTranslate.EnglishSentence;
            }
            else
            {
                Translate.Text = unstudiedWord.RealTranslate.EnglishSentence;
                Translated.Text = unstudiedWord.RealTranslate.RussianSentence;
            }

            Help.Text = $"Почему - так как Время [{unstudiedWord.TimeOfASentence}], Предложение [{unstudiedWord.TypeOfASentences}].";
        }

        private void SelectWords()
        {
            //выбор языка перевода(является язык русский)
            isRusEn = rnd.Next(0, 2) == 0;
            //если не получившиеся слова? Иначе все
            bool IsNotLearned = rnd.Next(0, 5) == 0;

            if (isRusEn)
            {
                //Показываем слова с русского на английский
                if (UnstudiedWords.Any(x => x.RealTranslate.IsLearnedRuEn <= 1))
                {
                    if (IsNotLearned)
                    {

                        if (UnstudiedWords.Any(x => x.RealTranslate.IsLearnedRuEn < 0))
                        {
                            UnstudiedWords = UnstudiedWords.Where(x => x.RealTranslate.IsLearnedRuEn < 0).ToList();
                        }
                    }
                    UnstudiedWords = UnstudiedWords.Where(x => x.RealTranslate.IsLearnedRuEn <= 1).ToList();
                }
            }
            else
            {
                //Показываем слова с английского на русский
                if (UnstudiedWords.Any(x => x.RealTranslate.IsLearnedEnRu <= 1))
                {
                    if (IsNotLearned)
                    {

                        if (UnstudiedWords.Any(x => x.RealTranslate.IsLearnedEnRu < 0))
                        {
                            UnstudiedWords = UnstudiedWords.Where(x => x.RealTranslate.IsLearnedEnRu < 0).ToList();
                        }
                    }
                    UnstudiedWords = UnstudiedWords.Where(x => x.RealTranslate.IsLearnedEnRu <= 1).ToList();
                }
            }
        }

        private void HiddenNeedElement()
        {
            Help.Visibility = Visibility.Hidden;
            Translated.Visibility = Visibility.Hidden;
        }
    }
}
