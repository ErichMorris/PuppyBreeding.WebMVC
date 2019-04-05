namespace PuppyBreeding.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CustomerApproved = c.Boolean(nullable: false),
                        DepositPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
