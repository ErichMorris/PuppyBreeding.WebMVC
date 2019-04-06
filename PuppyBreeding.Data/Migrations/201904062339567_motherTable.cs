namespace PuppyBreeding.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class motherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mother",
                c => new
                    {
                        MotherId = c.Int(nullable: false, identity: true),
                        MotherName = c.String(nullable: false),
                        MotherWeight = c.Double(nullable: false),
                        MotherAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mother");
        }
    }
}
