//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
using English.DataFiles;

namespace English
{
    public class Pronoun: IReadText
    {
        private const int countFieldText = 2;
        private string English { get; set; }
        private string Russian { get; set; }

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
    }




}
