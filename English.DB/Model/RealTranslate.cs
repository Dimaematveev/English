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
        public int IsLearnedRuEn { get; set; }
        public int IsLearnedEnRu { get; set; }
        public virtual ICollection<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }

        public RealTranslate(string englishSentence, string russianSentence, int isLearnedRuEn, int isLearnedEnRu)
        {
            EnglishSentence = englishSentence;
            RussianSentence = russianSentence;
            IsLearnedRuEn = isLearnedRuEn;
            IsLearnedEnRu = isLearnedEnRu;
        }

        public RealTranslate() { }

       
        public override string ToString()
        {
            return $"{EnglishSentence} - {RussianSentence}";
        }

       
    }




}
