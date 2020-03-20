using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Migrations
{
    public partial class addedpropertyofdatepostedtoannouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b7c3c3-29e0-451a-8927-b69ec7503df2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3fcb823-f6ab-4647-a8de-262f8d16e4ed");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Announcements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c2eecc1-29b8-419a-8fe4-1d425238b33b", "220dcbfd-9256-421d-83a1-7b7fd2dc1ae0", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a7e941b-bab6-4222-95c9-49ed57fd4201", "8810c6b8-26e7-4ce9-ae89-5e00ed4d0901", "Roommate", "ROOMMATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a7e941b-bab6-4222-95c9-49ed57fd4201");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c2eecc1-29b8-419a-8fe4-1d425238b33b");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "Announcements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3fcb823-f6ab-4647-a8de-262f8d16e4ed", "1c0b76ba-dbe5-47d3-946e-b7c350c008dd", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15b7c3c3-29e0-451a-8927-b69ec7503df2", "7d781a3f-9e0e-4554-bf0b-6038d23599ea", "Roommate", "ROOMMATE" });
        }
    }
}
