﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Translator;
using English.DataFiles;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
   
    class Program
    {
        static void Main()
        {
            WorkWithFiles workWithFiles = new WorkWithFiles();
            List<RulesVerbAndPronoun> rulesVerbAndPronouns = new List<RulesVerbAndPronoun>();
            foreach (var verb in workWithFiles.Verbs)
            {
                foreach (var pronoun in workWithFiles.Pronouns)
                {
                    RulesVerbAndPronoun temp;
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Вопрос);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Отрицание);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Утверждение);
                    rulesVerbAndPronouns.Add(temp);

                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Вопрос);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Отрицание);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Утверждение);
                    rulesVerbAndPronouns.Add(temp);

                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Вопрос);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Отрицание);
                    rulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Утверждение);
                    rulesVerbAndPronouns.Add(temp);
                }
            }

            YandexTranslator yt = new YandexTranslator();


          
           
            Random rnd = new Random();
            int count = 0;
            while (rulesVerbAndPronouns.Count>0)
            {
                int ind = rnd.Next(0, rulesVerbAndPronouns.Count);
                var rul = rulesVerbAndPronouns[ind];

                string line = rul.GetLine();
                //string translate = yt.Translate(line, "en-ru");
                string translate = workWithFiles.RealTranslates.First(x=>x.EnglishSentence==line).RussianSentence;

                Console.WriteLine($"вы прошли: {count++}");
                Console.WriteLine();
                Console.WriteLine(rul.Verb);
                Console.Write($"{new string('-', 120)}");
                Console.WriteLine(translate);
                Console.Write($"{new string('-', 120)}");
                Console.WriteLine("\nДля перевода и объяснения нажмите Enter");
                Console.ReadLine();
                Console.Write($"{new string('=',120)}");
                Console.WriteLine($"Перевод - {line}");
                Console.WriteLine($"Почему - так как Время [{rul.TimeOfASentence}], Предложение [{rul.TypeOfASentences}]");
                Console.WriteLine($"{new string('=', 120)}");
                Console.WriteLine("\nДля следующего слова нажмите Enter");
                Console.ReadLine();
                Console.Clear();
                rulesVerbAndPronouns.RemoveAt(ind);


            }
           

            Console.ReadKey();
        }
    }




}
