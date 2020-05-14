namespace English.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBase14052020_1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.RealTranslates", "RealTranslateID", "RulesVerbAndPronounID");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.RealTranslates", "RulesVerbAndPronounID", "RealTranslateID");
        }
    }
}
