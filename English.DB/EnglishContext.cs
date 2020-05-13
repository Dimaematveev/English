
using English.DB.Model;
using System.Data.Entity;

namespace English.DB
{
    public class EnglishContext:DbContext
    {
        public EnglishContext() : base("name=EnglishConnection") 
        {
        }

        public DbSet<Pronoun> Pronouns { get; set; }
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<RealTranslate> RealTranslates { get; set; }
        public DbSet<RulesVerbAndPronoun> RulesVerbAndPronouns { get; set; }
        
    }
}
