using English.DataFiles;
using System;
using System.Linq;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
    public class RealTranslate: IReadText
    {
        private const int countFieldText = 3;
        public string EnglishSentence { get; set; }
        public string RussianSentence { get; set; }
        public int IsLearned { get; set; }
        public int CountFieldText { get => countFieldText; }

        public RealTranslate(string englishSentence, string russianSentence, int isLearned)
        {
            EnglishSentence = englishSentence;
            RussianSentence = russianSentence;
            IsLearned = isLearned;
        }

        public RealTranslate(string line,char separator)
        {
            FillEverythingFromLine(line, separator);
        }

        public RealTranslate()
        {
            EnglishSentence = "";
            RussianSentence = "";
            IsLearned = 0;
        }

        public void FillEverythingFromLine(string line, char separator)
        {
            var str = line.Split(separator);
            EnglishSentence = str[0];
            RussianSentence = str[1];
            IsLearned = Convert.ToInt32(str[2]);
        }
        public override string ToString()
        {
            return $"{EnglishSentence} - {RussianSentence}";
        }

        public string LineForWriteFile(char separator)
        {
            string[] str = new string[countFieldText];
            str[0] = EnglishSentence;
            str[1] = RussianSentence;
            str[2] = IsLearned.ToString();

            string ret = "";
            foreach (var item in str)
            {
                ret += $"{item}{separator}";
            }
            return ret;
        }
    }




}
