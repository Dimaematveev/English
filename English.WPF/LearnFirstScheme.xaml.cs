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
        
        public LearnFirstScheme()
        {
            InitializeComponent();
            workWithFiles = new WorkWithFiles();
            FillValue();
            Next.Click += Next_Click;
            Helped.Click += Helped_Click;
            Answer.Click += Answer_Click;
            KeyDown += LearnFirstScheme_KeyDown;
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
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Translated.Visibility = Visibility.Visible;
        }

        private void Helped_Click(object sender, RoutedEventArgs e)
        {
            Help.Visibility = Visibility.Visible;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            FillValue();
        }

        private void FillValue()
        {
            Help.Visibility = Visibility.Hidden;
            Translated.Visibility = Visibility.Hidden;
            var temp = workWithFiles.RealTranslates.Where(x=>x.IsLearned==0).ToArray();

            int ind = rnd.Next(0, temp.Length);

            var text = workWithFiles.RulesVerbAndPronouns.Find(x => x.GetLine() == temp[ind].EnglishSentence);

            Verb.Text = text.Verb.ToString();
            Translated.Text= text.GetLine();
            Translate.Text = temp[ind].RussianSentence;
            Help.Text= $"Почему - так как Время [{text.TimeOfASentence}], Предложение [{text.TypeOfASentences}]";

            temp[ind].IsLearned = 1;

            workWithFiles.SaveRealTranslates();


        }
    }
}
