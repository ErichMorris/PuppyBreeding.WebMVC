namespace PuppyBreeding.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Father",
                c => new
                    {
                        FatherId = c.Int(nullable: false, identity: true),
                        FatherName = c.String(nullable: false),
                        FatherWeight = c.Double(nullable: false),
                        FatherAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FatherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Father");
        }
    }
}
