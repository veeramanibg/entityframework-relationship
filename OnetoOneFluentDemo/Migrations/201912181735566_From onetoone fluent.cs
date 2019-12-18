namespace OnetoOneFluentDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fromonetoonefluent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerDetails",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        Email = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerDetails", "CustomerID", "dbo.Customer");
            DropIndex("dbo.CustomerDetails", new[] { "CustomerID" });
            DropTable("dbo.CustomerDetails");
            DropTable("dbo.Customer");
        }
    }
}
