using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для LearnWord.xaml
    /// </summary>
    public partial class LearnWord : Window
    {
        List<TranslateWorld> TranslateWorlds;
        TranslateWorld translateWorld;
        Random rnd = new Random();
        public LearnWord(List<TranslateWorld> translateWorlds)
        {
            InitializeComponent();
            TranslateWorlds = translateWorlds;

            Fall.Click += (s, e) => { Fall_Click(); };
            Answer.Click += (s, e) => { Answer_Click(); };
            Next.Click += (s, e) => { Next_Click(); };

            KeyDown += LearnWord_KeyDown;
            FillValue();
        }

        private void LearnWord_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void Next_Click()
        {
            if (Translated.Visibility == Visibility.Hidden)
            {
                Answer_Click();
                return;
            }
            translateWorld.Learn(1);
            FillValue();
        }

        private void Answer_Click()
        {
            Translated.Visibility = Visibility.Visible;
        }

        private void Fall_Click()
        {
            translateWorld.Learn(-2);
            FillValue();
        }

        private void FillValue()
        {
            Translated.Visibility = Visibility.Hidden;
            TranslateWorlds.RemoveAll(x => x.IsLearnEnRu >= 2 && x.IsLearnRuEn >= 2);
            bool isEnRu = rnd.Next(0, 2) == 0;
            var temp = TranslateWorlds.Where(x => (x.IsEnRu && x.IsLearnEnRu < 2) || (!x.IsEnRu && x.IsLearnRuEn < 2)).ToList();
            translateWorld = temp[rnd.Next(0, temp.Count)];
            translateWorld.IsEnRu = isEnRu;
            if (translateWorld.IsEnRu)
            {
                Translated.Text = translateWorld.EnglishWord;
                Word.Text = translateWorld.RussianWord;
            }
            else
            {
                Translated.Text = translateWorld.RussianWord;
                Word.Text = translateWorld.EnglishWord;
            }
            

        }
    }

    public class TranslateWorld
    {


        public string EnglishWord { get; set; }
        public string RussianWord { get; set; }
        public int IsLearnEnRu { get; set; }
        public int IsLearnRuEn { get; set; }
        public bool IsEnRu { get; set; }

        public TranslateWorld(string englishWord, string russianWord)
        {
            EnglishWord = englishWord;
            RussianWord = russianWord;
            IsLearnEnRu = 0;
            IsLearnRuEn = 0;
            IsEnRu = false;
        }

        public TranslateWorld():this("","")
        {
        }

        public void Learn(int k)
        {
            if (IsEnRu)
            {
                IsLearnEnRu += k;
            }
            else
            {
                IsLearnRuEn += k;
            }
        }

    }
}
