using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockBuster.Data.Migrations
{
    public partial class SeedGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Genres", "Type", "Action");
            migrationBuilder.InsertData("Genres", "Type", "Comedy");
            migrationBuilder.InsertData("Genres", "Type", "Family");
            migrationBuilder.InsertData("Genres", "Type", "Romance");
            migrationBuilder.InsertData("Genres", "Type", "Thriller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
