using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace English.DB.Model
{
    public class RealTranslate
    {
        [Key]
        [ForeignKey("RulesVerbAndPronoun")]
        public int RulesVerbAndPronounID { get; set; }
        public string EnglishSentence { get; set; }
        public string RussianSentence { get; set; }
        public int IsLearnedRuEn { get; set; }
        public int IsLearnedEnRu { get; set; }

        public virtual RulesVerbAndPronoun RulesVerbAndPronoun { get; set; }

        public RealTranslate(string englishSentence, string russianSentence, int isLearnedRuEn, int isLearnedEnRu, RulesVerbAndPronoun rulesVerbAndPronoun)
        {
            EnglishSentence = englishSentence;
            RussianSentence = russianSentence;
            IsLearnedRuEn = isLearnedRuEn;
            IsLearnedEnRu = isLearnedEnRu;
            RulesVerbAndPronoun = rulesVerbAndPronoun;
        }

        public RealTranslate() { }

       
        public override string ToString()
        {
            return $"{EnglishSentence} - {RussianSentence}";
        }

       
    }




}
