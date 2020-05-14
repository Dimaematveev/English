namespace English.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBase14052020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RulesVerbAndPronouns", "RealTranslateID", "dbo.RealTranslates");
            DropIndex("dbo.RulesVerbAndPronouns", new[] { "RealTranslateID" });
            DropColumn("dbo.RulesVerbAndPronouns", "RealTranslateID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RulesVerbAndPronouns", "RealTranslateID", c => c.Int(nullable: false));
            CreateIndex("dbo.RulesVerbAndPronouns", "RealTranslateID");
            AddForeignKey("dbo.RulesVerbAndPronouns", "RealTranslateID", "dbo.RealTranslates", "RealTranslateID", cascadeDelete: true);
        }
    }
}
