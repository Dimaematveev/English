using System.Collections.Generic;
using System.Linq;


//TODO: Я хочу сделать еще 1 файл с о всеми переводами гугла, если вдуг кажется неверным моно поменять,п после форму и отмечать что я правильно понял что нет и т.д.
namespace English
{
    public class RulesVerbAndPronoun
    {
       
        
        public Verb Verb { get; set; }
        public Pronoun Pronoun { get; set; }
        public TimeOfASentence TimeOfASentence { get; set; }
        public TypeOfASentences TypeOfASentences { get; set; }
        public RulesVerbAndPronoun(Verb verb, Pronoun pronoun,TimeOfASentence timeOfASentence, TypeOfASentences typeOfASentences)
        {
            Verb = verb;
            Pronoun = pronoun;
            TypeOfASentences = typeOfASentences;
            TimeOfASentence = timeOfASentence;
        }

        public string GetLine_v3()
        {
            string str = "";

            switch (TypeOfASentences)
            {
                case TypeOfASentences.Утверждение:

                    break;
                case TypeOfASentences.Вопрос:

                    break;
                case TypeOfASentences.Отрицание:

                    break;
                default:
                    break;
            }

            return str;
        }
        public string GetLine_v2()
        {
            if (TimeOfASentence == TimeOfASentence.Настоящее)
            {
                if (TypeOfASentences == TypeOfASentences.Утверждение)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        string word = Verb.EnglishWord;
                        char[] sim1 = new char[] { 'a', 'e', 'y', 'u', 'i' };
                        char[] sim2 = new char[] { 'o' };
                        if (sim1.Contains(word[word.Length - 1]))
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
                else if (TypeOfASentences == TypeOfASentences.Отрицание)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"{Pronoun.GetNameWithUpper()} doesn't {Verb.EnglishWord}.";
                    }
                    return $"{Pronoun.GetNameWithUpper()} don't {Verb.EnglishWord}.";
                }
                else if (TypeOfASentences == TypeOfASentences.Вопрос)
                {
                    if (Pronoun.GetNameLower().Equals("she") || Pronoun.GetNameLower().Equals("he"))
                    {
                        return $"Does {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                    }
                    return $"Do {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
            }
            else if (TimeOfASentence == TimeOfASentence.Будущее)
            {
                if (TypeOfASentences == TypeOfASentences.Утверждение)
                {
                    return $"{Pronoun.GetNameWithUpper()} will {Verb.EnglishWord}.";
                }
                else if (TypeOfASentences == TypeOfASentences.Отрицание)
                {
                    return $"{Pronoun.GetNameWithUpper()} will not {Verb.EnglishWord}.";
                }
                else if (TypeOfASentences == TypeOfASentences.Вопрос)
                {
                    return $"Will {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }

            }
            else if (TimeOfASentence == TimeOfASentence.Прошедшее)
            {
                if (TypeOfASentences == TypeOfASentences.Утверждение)
                {
                    return $"{Pronoun.GetNameWithUpper()} {Verb.EnglishWord_Past}.";
                }
                else if (TypeOfASentences == TypeOfASentences.Отрицание)
                {
                    return $"{Pronoun.GetNameWithUpper()} didn't {Verb.EnglishWord}.";
                }
                else if (TypeOfASentences == TypeOfASentences.Вопрос)
                {
                    return $"Did {Pronoun.GetNameLower()} {Verb.EnglishWord}?";
                }
            }
            return null;
        }
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
