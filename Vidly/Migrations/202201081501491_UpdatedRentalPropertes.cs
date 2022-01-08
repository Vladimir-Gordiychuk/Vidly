namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRentalPropertes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "CustomerId");
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "CustomerId");
            CreateIndex("dbo.Rentals", "MovieId");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "MovieId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropColumn("dbo.Rentals", "MovieId");
            DropColumn("dbo.Rentals", "CustomerId");
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
