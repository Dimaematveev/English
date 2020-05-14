namespace English.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBase14052020_2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RealTranslates");
            AlterColumn("dbo.RealTranslates", "RulesVerbAndPronounID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RealTranslates", "RulesVerbAndPronounID");
            CreateIndex("dbo.RealTranslates", "RulesVerbAndPronounID");
            AddForeignKey("dbo.RealTranslates", "RulesVerbAndPronounID", "dbo.RulesVerbAndPronouns", "RulesVerbAndPronounID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RealTranslates", "RulesVerbAndPronounID", "dbo.RulesVerbAndPronouns");
            DropIndex("dbo.RealTranslates", new[] { "RulesVerbAndPronounID" });
            DropPrimaryKey("dbo.RealTranslates");
            AlterColumn("dbo.RealTranslates", "RulesVerbAndPronounID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RealTranslates", "RulesVerbAndPronounID");
        }
    }
}
