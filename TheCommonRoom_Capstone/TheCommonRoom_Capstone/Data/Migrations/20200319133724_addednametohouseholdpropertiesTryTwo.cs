using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Data.Migrations
{
    public partial class addednametohouseholdpropertiesTryTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb1b06a6-139e-4a79-87cb-eade9723d985", "8ff8cb3f-eb01-4938-87a5-4245a655d994", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" },
                    { "78d32eb7-15ca-44c6-9b9d-309e1e0db76a", "1400edd4-3d3d-49c1-8a5d-4f9f51a9ca23", "Roommate", "ROOMMATE" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "Id", "BoardId", "Name" },
                values: new object[] { 1, 1, "Andrew's Group" });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "Id", "BoardId", "Name" },
                values: new object[] { 2, 2, "Steve's Group" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d32eb7-15ca-44c6-9b9d-309e1e0db76a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb1b06a6-139e-4a79-87cb-eade9723d985");

            migrationBuilder.DeleteData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
