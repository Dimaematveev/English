using English.DataFiles;
using System;
using System.Linq;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
    public class RealTranslate: IReadText
    {
        private const int countFieldText = 2;
        public string EnglishSentence { get; set; }
        public string RussianSentence { get; set; }
        public int CountFieldText { get => countFieldText; }

        public RealTranslate(string englishSentence, string russianSentence)
        {
            EnglishSentence = englishSentence;
            RussianSentence = russianSentence;
        }

        public RealTranslate(string line,char separator)
        {
            FillEverythingFromLine(line, separator);
        }

        public RealTranslate()
        {
            EnglishSentence = "";
            RussianSentence = "";
        }

        public void FillEverythingFromLine(string line, char separator)
        {
            var str = line.Split(separator);
            EnglishSentence = str[0];
            RussianSentence = str[1];
        }
        public override string ToString()
        {
            return $"{EnglishSentence} - {RussianSentence}";
        }

    }




}
