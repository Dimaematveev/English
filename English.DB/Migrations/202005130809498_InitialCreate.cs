namespace English.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pronouns",
                c => new
                    {
                        PronounID = c.Int(nullable: false, identity: true),
                        English = c.String(),
                        Russian = c.String(),
                    })
                .PrimaryKey(t => t.PronounID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pronouns");
        }
    }
}
