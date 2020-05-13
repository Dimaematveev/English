using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace English.DB.Model
{
    public class RealTranslate
    {
        [Key]
        public int RealTranslateID { get; set; }
        public string EnglishSentence { get; set; }
        public string RussianSentence { get; set; }
        public int IsLearned { get; set; }
        public virtual ICollection<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }

        public RealTranslate(string englishSentence, string russianSentence, int isLearned)
        {
            EnglishSentence = englishSentence;
            RussianSentence = russianSentence;
            IsLearned = isLearned;
        }

        public RealTranslate() { }

       
        public override string ToString()
        {
            return $"{EnglishSentence} - {RussianSentence}";
        }

       
    }




}
