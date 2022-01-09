namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncModel : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Rental2", "Customer_Id", "dbo.Customers");
            //DropForeignKey("dbo.Rental2", "Movie_Id", "dbo.Movies");
            //DropIndex("dbo.Rental2", new[] { "Customer_Id" });
            //DropIndex("dbo.Rental2", new[] { "Movie_Id" });
            //DropTable("dbo.Rental2");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Rental2",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DateRented = c.DateTime(nullable: false),
            //            DateReturned = c.DateTime(),
            //            Customer_Id = c.Int(nullable: false),
            //            Movie_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateIndex("dbo.Rental2", "Movie_Id");
            //CreateIndex("dbo.Rental2", "Customer_Id");
            //AddForeignKey("dbo.Rental2", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Rental2", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
