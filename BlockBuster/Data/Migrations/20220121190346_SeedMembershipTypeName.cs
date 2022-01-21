using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockBuster.Data.Migrations
{
    public partial class SeedMembershipTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("MembershipType", "ID", 1, "Name", "Pay As You Go");
            migrationBuilder.UpdateData("MembershipType", "ID", 2, "Name", "Monthly");
            migrationBuilder.UpdateData("MembershipType", "ID", 3, "Name", "Quarterly");
            migrationBuilder.UpdateData("MembershipType", "ID", 4, "Name", "Yearly");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
