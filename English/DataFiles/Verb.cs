using English.DataFiles;
using System;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
    public class Verb: IReadText
    {
        private const  int countFieldText = 5;
        public int Number { get; set; }
        public string EnglishWord { get; set; }
        public string RussialWord { get; set; }
        public string EnglishWord_Past { get; set; }
        public string EnglishWord_Participle { get; set; }
        public int CountFieldText { get => countFieldText; }

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
            FillEverythingFromLine(line, separator);
        }

        public Verb()
        {
            Number = 0;
            EnglishWord = "";
            RussialWord = "";
            EnglishWord_Past = "";
            EnglishWord_Participle = "";
        }

        public void FillEverythingFromLine(string line, char separator)
        {
            var str = line.Split(separator);
            Number = Convert.ToInt32(str[0]);
            EnglishWord = str[1];
            RussialWord = str[2];
            EnglishWord_Past = str[3];
            EnglishWord_Participle = str[4];
        }
        public string LineForWriteFile(char separator)
        {
            string[] str = new string[countFieldText];
            str[0] = Number.ToString();
            str[1] = EnglishWord;
            str[2] = RussialWord;
            str[3] = EnglishWord_Past;
            str[4] = EnglishWord_Participle;
            
            string ret = "";
            foreach (var item in str)
            {
                ret += $"{item}{separator}";
            }
            return ret;
        }

        public override string ToString()
        {
            return $"Глагол {EnglishWord}({EnglishWord_Past}) - {RussialWord}";
        }

    }




}
