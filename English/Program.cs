using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Translator;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
    public enum TypeOfASentences
    {
        Утверждение,
        Вопрос,
        Отрицание
    }
    public enum TimeOfASentence
    {
        Настоящее,
        Будущее,
        Прошедшее
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Дмитрий\source\repos\English\English\Verbs.txt";
            
            List<Verb> verbs = new List<Verb>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Verb tmp = new Verb(line, ';');
                    verbs.Add(tmp);
                }
            }

            List<Pronoun> pronouns = new List<Pronoun>();
            pronouns.Add(new Pronoun("I"));
            pronouns.Add(new Pronoun("You"));
            pronouns.Add(new Pronoun("We"));
            pronouns.Add(new Pronoun("They"));
            pronouns.Add(new Pronoun("He"));
            pronouns.Add(new Pronoun("She"));

            List<RulesVerbAndPronoun> rulesVerbAndPronouns = new List<RulesVerbAndPronoun>();
            foreach (var verb in verbs)
            {
                foreach (var pronoun in pronouns)
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


            //string path1 = @"D:\Дмитрий\source\repos\English\English\Verbs1.txt";

            //using (StreamWriter sw = new StreamWriter(path1, false, System.Text.Encoding.Default))
            //{

            //    for (int i = 0; i < rulesVerbAndPronouns.Count; i++)
            //    {
            //        sw.WriteLine(rulesVerbAndPronouns[i].GetLine());
            //    }
            //}
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(rulesVerbAndPronouns[i].GetLine());
            //}

            Dictionary<string, string> realTranslate = new Dictionary<string, string>();
            path = @"D:\Дмитрий\source\repos\English\English\RealTranslate.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(';'))
                    {
                        var split = line.Split(';');
                        if (!realTranslate.ContainsKey(split[0]))
                        {
                            realTranslate.Add(split[0], split[1]);
                        }
                    }

                }
            }
            Random rnd = new Random();
            int count = 0;
            while (rulesVerbAndPronouns.Count>0)
            {
                int ind = rnd.Next(0, rulesVerbAndPronouns.Count);
                var rul = rulesVerbAndPronouns[ind];

                string line = rul.GetLine();
                //string translate = yt.Translate(line, "en-ru");
                string translate = realTranslate[line];

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

    public class Verb
    {
        public int Number { get; set; }
        public string EnglishWord { get; set; }
        public string RussialWord { get; set; }
        public string EnglishWord_Past { get; set; }
        public string EnglishWord_Participle { get; set; }

        public Verb(int number, string englishWord, string russialWord, string englishWord_Past, string englishWord_Participle)
        {
            Number = number;
            EnglishWord = englishWord;
            RussialWord = russialWord;
            EnglishWord_Past = englishWord_Past;
            EnglishWord_Participle = englishWord_Participle;
        }

        public Verb(string line,char separator)
        {
            var str = line.Split(separator);
            Number = Convert.ToInt32( str[0]);
            EnglishWord = str[1];
            RussialWord = str[2];
            EnglishWord_Past = str[3];
            EnglishWord_Participle = str[4];
        }


        public override string ToString()
        {
            return $"Глагол {EnglishWord}({EnglishWord_Past}) - {RussialWord}";
        }

    }
    public class Pronoun
    {
        private string Name { get; set; }
        public Pronoun(string name)
        {
            Name = name;
        }

        public string GetNameWithUpper()
        {
            return Name;
        }
        public string GetNameLower()
        {
            return Name.ToLower();
        }
    }

    

    public class RulesVerbAndPronoun
    {
       
        
        public Verb Verb { get; set; }
        public Pronoun Pronoun { get; set; }
        public TimeOfASentence TimeOfASentence { get; set; }
        public TypeOfASentences TypeOfASentences { get; set; }
        public RulesVerbAndPronoun(Verb verb, Pronoun pronoun,TimeOfASentence timeOfASentence, TypeOfASentences typeOfASentences)
        {
            Verb = verb;
            Pronoun = pronoun;
            TypeOfASentences = typeOfASentences;
            TimeOfASentence = timeOfASentence;
        }

        public string GetLine()
        {
            if (TypeOfASentences== TypeOfASentences.Вопрос)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"Will {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                } 
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"Does {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                    }
                    return $"Do {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"Did {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
                else
                {
                    return $"нет такого времени";
                }
            }
            else if (TypeOfASentences == TypeOfASentences.Утверждение)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"{Pronoun.GetNameWithUpper()} will {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        string word = Verb.EnglishWord;
                        char[] sim1= new char[] { 'a', 'e', 'y', 'u', 'i' };
                        char[] sim2 = new char[] {  'o' };
                        if (sim1.Contains(word[word.Length-1]))
                        {
                            word = word.Substring(0, word.Length - 1);
                            word += "es";
                        }
                        else if (sim2.Contains(word[word.Length - 1]))
                        {
                            word += "s";
                        }
                        else
                        {
                            word += "es";
                        }
                        return $"{Pronoun.GetNameWithUpper()} {word}.";
                    }
                    return $"{Pronoun.GetNameWithUpper()} {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"{Pronoun.GetNameWithUpper()} {Verb.EnglishWord_Past}.";
                }
                else
                {
                    return $"Нет такого времени";
                }
            }
            else if(TypeOfASentences == TypeOfASentences.Отрицание)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"{Pronoun.GetNameWithUpper()} will not {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"{Pronoun.GetNameWithUpper()} doesn't {Verb.EnglishWord}.";
                    }
                    return $"{Pronoun.GetNameWithUpper()} don't {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"{Pronoun.GetNameWithUpper()} didn't {Verb.EnglishWord}.";
                }
                else
                {
                    return $"Нет такого времени";
                }
            }
            else
            {
                return $"Нет такого типа предложения";
            }
        }

    }




}
