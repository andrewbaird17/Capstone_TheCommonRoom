using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Data.Migrations
{
    public partial class addednametohouseholdproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dd48658-f124-4a96-bf92-903f74a1d5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d26cdacf-c379-4508-ad33-7ca9833f7107");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Households",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "960e5ffe-27b0-4679-a2ea-bfb46fdf7b99", "520873c8-6e78-4b79-96b3-6d5944636b7f", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9429abb-86e2-4917-862f-e2b2542e9f08", "b1099e83-226e-490a-b6ec-a0db5c20418e", "Roommate", "ROOMMATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "960e5ffe-27b0-4679-a2ea-bfb46fdf7b99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9429abb-86e2-4917-862f-e2b2542e9f08");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Households");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dd48658-f124-4a96-bf92-903f74a1d5c8", "acb5e9c4-e49c-4d06-8587-8e5f568c118f", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d26cdacf-c379-4508-ad33-7ca9833f7107", "9091ae22-dab6-4040-a773-abd9cd02e683", "Roommate", "ROOMMATE" });
        }
    }
}
