namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            var now = DateTime.Now;
            var today = now.ToString("MM/dd/yyyy hh:mm");
            Sql(string.Format("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Hangover', 2, '11/6/2009', '{0}', 5)", today));
            Sql(string.Format("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Die Hard', 1, '7/22/1988', '{0}', 6)", today));
            Sql(string.Format("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Terminator', 1, '10/26/1984', '{0}', 3)", today));
            Sql(string.Format("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Toy Story', 4, '11/22/1995', '{0}', 3)", today));
            Sql(string.Format("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Titanic', 8, '12/19/1997', '{0}', 5)", today));
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Movies");
        }
    }
}
