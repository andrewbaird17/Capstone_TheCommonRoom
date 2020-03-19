using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Data.Migrations
{
    public partial class removedNamefromHousehold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3eb0809c-9b82-4401-8bd0-69823d612194", "526c10f5-9c1a-4701-9ead-479c74c0ef18", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a61f4a2-0c14-4367-a244-e978f4343075", "d3cd42c0-4c09-4171-a86d-5354d3b08e6d", "Roommate", "ROOMMATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a61f4a2-0c14-4367-a244-e978f4343075");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb0809c-9b82-4401-8bd0-69823d612194");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Households",
                type: "nvarchar(max)",
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
    }
}
