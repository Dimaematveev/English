//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
using English.DataFiles;
using System.Collections.Generic;

namespace English
{
    public class Pronoun: IReadText
    {
        private const int countFieldText = 2;
        public string English { get; set; }
        public string Russian { get; set; }

        public int CountFieldText => countFieldText;

        public Pronoun(string english, string russian)
        {
            English = english;
            Russian = russian;
        }
        public Pronoun()
        {
            English = "";
            Russian = "";
        }
        public Pronoun(string line, char separator)
        {
            FillEverythingFromLine(line, separator);
        }


        public string GetNameWithUpper()
        {
            return English;
        }
        public string GetNameLower()
        {
            return English.ToLower();
        }

        public void FillEverythingFromLine(string line, char separator)
        {
            var str = line.Split(separator);
            English = str[0];
            Russian = str[1];
        }

        public string LineForWriteFile(char separator)
        {
            string[] str = new string[countFieldText];
            str[0] = English;
            str[1] = Russian;
            string ret = "";
            foreach (var item in str)
            {
                ret += $"{item}{separator}";
            }
            return ret;
        }
    }




}
