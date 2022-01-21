using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockBuster.Data.Migrations
{
    public partial class AddMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Movies", 
                columns: new string[] { "Name", "DateAdded", "GenreId", "ReleaseDate", "Stock" }, 
                values: new string[] {"Hangover", "01/01/2020", "2", "01/01/1998", "5"});

            migrationBuilder.InsertData("Movies",
                columns: new string[] { "Name", "DateAdded", "GenreId", "ReleaseDate", "Stock" },
                values: new string[] { "Die Hard", "01/01/2020", "1", "01/01/1998", "5" });

            migrationBuilder.InsertData("Movies",
                columns: new string[] { "Name", "DateAdded", "GenreId", "ReleaseDate", "Stock" },
                values: new string[] { "The Terminator", "01/01/2020", "1", "01/01/1998", "5" });

            migrationBuilder.InsertData("Movies",
                columns: new string[] { "Name", "DateAdded", "GenreId", "ReleaseDate", "Stock" },
                values: new string[] { "Toy Story", "01/01/2020", "3", "01/01/1998", "5" });

            migrationBuilder.InsertData("Movies",
                columns: new string[] { "Name", "DateAdded", "GenreId", "ReleaseDate", "Stock" },
                values: new string[] { "Titanic", "01/01/2020", "4", "01/01/1998", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
