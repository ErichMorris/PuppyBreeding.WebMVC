namespace PuppyBreeding.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PriceInFullPaid = c.Boolean(nullable: false),
                        PuppyId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Puppy", t => t.PuppyId, cascadeDelete: true)
                .Index(t => t.PuppyId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "PuppyId", "dbo.Puppy");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Order", new[] { "PuppyId" });
            DropTable("dbo.Order");
        }
    }
}
