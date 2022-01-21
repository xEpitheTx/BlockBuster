using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockBuster.Data.Migrations
{
    public partial class AddMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeID",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "tinyint", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRatePercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeID",
                table: "Customers",
                column: "MembershipTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeID",
                table: "Customers",
                column: "MembershipTypeID",
                principalTable: "MembershipType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeID",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeID",
                table: "Customers");
        }
    }
}
