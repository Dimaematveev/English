using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.DataFiles
{
    public class WorkWithFiles
    {
        public List<Verb> Verbs { get; set; }
        public List<RealTranslate> RealTranslates { get; set; }
        public List<Pronoun> Pronouns { get; set; }
        public List<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }

        public WorkWithFiles()
        {
            
            Verbs = LoadFile<Verb>(@"D:\Дмитрий\source\repos\English\English\DataFiles\Verbs.txt", Encoding.Default, ';');
           
            RealTranslates = LoadFile<RealTranslate>(@"D:\Дмитрий\source\repos\English\English\DataFiles\RealTranslate.txt", Encoding.Default, ';');
         
            Pronouns = LoadFile<Pronoun>(@"D:\Дмитрий\source\repos\English\English\DataFiles\Pronoun.txt", Encoding.Default, ';');

            FillRulesVerbAndPronoun(RealTranslates);
        }
        private List<T> LoadFile<T>(string path, Encoding encoding, char separator) where T : IReadText, new()
        {
            var readTexts = new List<T>();
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    T tmp = new T();
                    if (line.Count(x => x.Equals(separator)) >= tmp.CountFieldText - 1)
                    {
                        tmp.FillEverythingFromLine(line, separator);
                        readTexts.Add(tmp);
                    }

                }
            }
            return readTexts;
        }

        public void SaveRealTranslates()
        {
            SaveFile(@"D:\Дмитрий\source\repos\English\English\DataFiles\RealTranslate.txt", Encoding.Default, ';', RealTranslates);
        }
        private void SaveFile<T>(string path, Encoding encoding, char separator,List<T> listSave) where T : IReadText
        {
            using (StreamWriter sw = new StreamWriter(path, false, encoding))
            {
                foreach (var item in listSave)
                {
                    sw.WriteLine(item.LineForWriteFile(separator));
                }
            }
        }



        private void FillRulesVerbAndPronoun(List<RealTranslate> realTranslate)
        {
            RulesVerbAndPronouns = new List<RulesVerbAndPronoun>();
            foreach (var verb in Verbs)
            {
                foreach (var pronoun in Pronouns)
                {
                    RulesVerbAndPronoun temp;
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Вопрос);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Отрицание);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Будущее, TypeOfASentences.Утверждение);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);

                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Вопрос);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Отрицание);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Настоящее, TypeOfASentences.Утверждение);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);

                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Вопрос);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Отрицание);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                    temp = new RulesVerbAndPronoun(verb, pronoun, TimeOfASentence.Прошедшее, TypeOfASentences.Утверждение);
                    temp.RealTranslate = realTranslate.FirstOrDefault(x => x.EnglishSentence == temp.GetLine());
                    RulesVerbAndPronouns.Add(temp);
                }
            }
        }
    }
}
