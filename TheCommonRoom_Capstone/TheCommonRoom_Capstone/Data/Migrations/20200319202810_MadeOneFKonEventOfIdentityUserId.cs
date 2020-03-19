using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Data.Migrations
{
    public partial class MadeOneFKonEventOfIdentityUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_HouseholdAdministrators_HouseholdAdminId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Roommates_RoommateId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_HouseholdAdminId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RoommateId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d32eb7-15ca-44c6-9b9d-309e1e0db76a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb1b06a6-139e-4a79-87cb-eade9723d985");

            migrationBuilder.DropColumn(
                name: "HouseholdAdminId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RoommateId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Events",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec819ac5-a06e-4248-9347-87b2f9c423d5", "741533ee-79a1-4d59-9ce8-5dec288d111b", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14d54629-7a23-4a82-bbe2-aa9774261940", "926e66ac-1987-44f1-b569-dae0c8f1e32c", "Roommate", "ROOMMATE" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_IdentityUserId",
                table: "Events",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_IdentityUserId",
                table: "Events",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_IdentityUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_IdentityUserId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14d54629-7a23-4a82-bbe2-aa9774261940");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec819ac5-a06e-4248-9347-87b2f9c423d5");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "HouseholdAdminId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoommateId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb1b06a6-139e-4a79-87cb-eade9723d985", "8ff8cb3f-eb01-4938-87a5-4245a655d994", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78d32eb7-15ca-44c6-9b9d-309e1e0db76a", "1400edd4-3d3d-49c1-8a5d-4f9f51a9ca23", "Roommate", "ROOMMATE" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_HouseholdAdminId",
                table: "Events",
                column: "HouseholdAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RoommateId",
                table: "Events",
                column: "RoommateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_HouseholdAdministrators_HouseholdAdminId",
                table: "Events",
                column: "HouseholdAdminId",
                principalTable: "HouseholdAdministrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Roommates_RoommateId",
                table: "Events",
                column: "RoommateId",
                principalTable: "Roommates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
