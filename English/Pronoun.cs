//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
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




}
