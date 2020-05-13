using System.ComponentModel.DataAnnotations;
using System.Linq;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English.DB.Model
{
    public class RulesVerbAndPronoun
    {

        [Key]
        public int RulesVerbAndPronounID { get; set; }
        public int VerbID { get; set; }
        public virtual Verb Verb { get; set; }
        public int PronounID { get; set; }
        public virtual Pronoun Pronoun { get; set; }
        public TimeOfASentence TimeOfASentence { get; set; }
        public TypeOfASentences TypeOfASentences { get; set; }
        public int RealTranslateID { get; set; }
        public virtual RealTranslate RealTranslate { get; set; }
        public RulesVerbAndPronoun(Verb verb, Pronoun pronoun,TimeOfASentence timeOfASentence, TypeOfASentences typeOfASentences, RealTranslate realTranslate)
        {
            Verb = verb;
            Pronoun = pronoun;
            TypeOfASentences = typeOfASentences;
            TimeOfASentence = timeOfASentence;
            RealTranslate = realTranslate;
        }

        public RulesVerbAndPronoun() { }

        public string GetLine()
        {
            
            if (TypeOfASentences== TypeOfASentences.Вопрос)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"Will {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                } 
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"Does {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                    }
                    return $"Do {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"Did {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
                else
                {
                    return $"нет такого времени";
                }
            }
            else if (TypeOfASentences == TypeOfASentences.Утверждение)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"{Pronoun.GetNameWithUpper()} will {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        string word = Verb.EnglishWord;
                        char[] sim1= new char[] { 'a', 'e', 'y', 'u', 'i' };
                        char[] sim2 = new char[] {  'o' };
                        if (sim1.Contains(word[word.Length-1]))
                        {
                            word = word.Substring(0, word.Length - 1);
                            word += "es";
                        }
                        else if (sim2.Contains(word[word.Length - 1]))
                        {
                            word += "s";
                        }
                        else
                        {
                            word += "es";
                        }
                        return $"{Pronoun.GetNameWithUpper()} {word}.";
                    }
                    return $"{Pronoun.GetNameWithUpper()} {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"{Pronoun.GetNameWithUpper()} {Verb.EnglishWord_Past}.";
                }
                else
                {
                    return $"Нет такого времени";
                }
            }
            else if(TypeOfASentences == TypeOfASentences.Отрицание)
            {
                if (TimeOfASentence == TimeOfASentence.Будущее)
                {
                    return $"{Pronoun.GetNameWithUpper()} will not {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Настоящее)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"{Pronoun.GetNameWithUpper()} doesn't {Verb.EnglishWord}.";
                    }
                    return $"{Pronoun.GetNameWithUpper()} don't {Verb.EnglishWord}.";
                }
                else if (TimeOfASentence == TimeOfASentence.Прошедшее)
                {
                    return $"{Pronoun.GetNameWithUpper()} didn't {Verb.EnglishWord}.";
                }
                else
                {
                    return $"Нет такого времени";
                }
            }
            else
            {
                return $"Нет такого типа предложения";
            }
        }

    }




}
