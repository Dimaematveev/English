using English.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.DB
{
    public class BDToList
    {
        

        public English.DB.EnglishContext EnglishContext { get; set; }
        public List<Pronoun> Pronouns { get; private set; }
        public List<Verb> Verbs { get; private set; }
        public List<RealTranslate> RealTranslates { get; private set; }
        public List<RulesVerbAndPronoun> RulesVerbAndPronouns { get; private set; }
        public BDToList()
        {
            EnglishContext = new EnglishContext();
            Pronouns= EnglishContext.Pronouns.ToList();
            Verbs = EnglishContext.Verbs.ToList();
            RealTranslates = EnglishContext.RealTranslates.ToList();
            RulesVerbAndPronouns = EnglishContext.RulesVerbAndPronouns.ToList();
        }

        public void Save()
        {
            EnglishContext.RulesVerbAndPronouns.AddRange(RulesVerbAndPronouns);
            EnglishContext.SaveChanges();
        }
    }
}
