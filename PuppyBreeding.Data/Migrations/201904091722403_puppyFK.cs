namespace PuppyBreeding.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class puppyFK : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Puppy", "FatherName");
            DropColumn("dbo.Puppy", "MotherName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Puppy", "MotherName", c => c.String(nullable: false));
            AddColumn("dbo.Puppy", "FatherName", c => c.String(nullable: false));
        }
    }
}
