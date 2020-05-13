using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English.DB.Model
{
    public class Verb
    {
        [Key]
        public int VerbID { get; set; }
        public string EnglishWord { get; set; }
        public string RussialWord { get; set; }
        public string EnglishWord_Past { get; set; }
        public string EnglishWord_Participle { get; set; }
        public virtual ICollection<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }

        public Verb(int number, string englishWord, string russialWord, string englishWord_Past, string englishWord_Participle)
        {
            EnglishWord = englishWord;
            RussialWord = russialWord;
            EnglishWord_Past = englishWord_Past;
            EnglishWord_Participle = englishWord_Participle;
        }
        public Verb() { }
        public override string ToString()
        {
            return $"Глагол {EnglishWord}({EnglishWord_Past}) - {RussialWord}";
        }

    }




}
