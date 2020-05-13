//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг 
//кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace English.DB.Model
{
    public class Pronoun
    {
        [Key]
        public int PronounID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public virtual ICollection<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }

        public Pronoun(string english, string russian)
        {
            English = english;
            Russian = russian;
        }
        public Pronoun() { }
        

        public string GetNameWithUpper()
        {
            return English;
        }
        public string GetNameLower()
        {
            return English.ToLower();
        }

       
    }




}
