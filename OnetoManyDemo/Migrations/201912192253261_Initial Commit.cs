namespace OnetoManyDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerDetails",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ContactID, t.CustomerID })
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerDetails", "CustomerID", "dbo.Customer");
            DropIndex("dbo.CustomerDetails", new[] { "CustomerID" });
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerDetails");
        }
    }
}
