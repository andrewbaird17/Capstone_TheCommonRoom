using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Data.Migrations
{
    public partial class FirstGoAtModelsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00405e14-7250-483b-ab2b-a37bc1ff7e18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b19a457-e7d6-4cd4-91c5-8f9b6519adb5");

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: true),
                    PostedBy = table.Column<string>(nullable: true),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    PostedBy = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<double>(nullable: false),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chores_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Households",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Households", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Households_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    OptionOne = table.Column<string>(nullable: true),
                    OptionTwo = table.Column<string>(nullable: true),
                    VotesForOptionOne = table.Column<int>(nullable: false),
                    VotesForOptionTwo = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polls_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdAdministrators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    HouseholdId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdAdministrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdAdministrators_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdAdministrators_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roommates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    HouseholdId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roommates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roommates_Households_HouseholdId",
                        column: x => x.HouseholdId,
                        principalTable: "Households",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roommates_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    IsFullDay = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    HouseholdAdminId = table.Column<int>(nullable: true),
                    RoommateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_HouseholdAdministrators_HouseholdAdminId",
                        column: x => x.HouseholdAdminId,
                        principalTable: "HouseholdAdministrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Roommates_RoommateId",
                        column: x => x.RoommateId,
                        principalTable: "Roommates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dd48658-f124-4a96-bf92-903f74a1d5c8", "acb5e9c4-e49c-4d06-8587-8e5f568c118f", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d26cdacf-c379-4508-ad33-7ca9833f7107", "9091ae22-dab6-4040-a773-abd9cd02e683", "Roommate", "ROOMMATE" });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_BoardId",
                table: "Announcements",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BoardId",
                table: "Bills",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_BoardId",
                table: "Chores",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_HouseholdAdminId",
                table: "Events",
                column: "HouseholdAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RoommateId",
                table: "Events",
                column: "RoommateId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdAdministrators_HouseholdId",
                table: "HouseholdAdministrators",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdAdministrators_IdentityUserId",
                table: "HouseholdAdministrators",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Households_BoardId",
                table: "Households",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_BoardId",
                table: "Polls",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Roommates_HouseholdId",
                table: "Roommates",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Roommates_IdentityUserId",
                table: "Roommates",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "HouseholdAdministrators");

            migrationBuilder.DropTable(
                name: "Roommates");

            migrationBuilder.DropTable(
                name: "Households");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dd48658-f124-4a96-bf92-903f74a1d5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d26cdacf-c379-4508-ad33-7ca9833f7107");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00405e14-7250-483b-ab2b-a37bc1ff7e18", "ff48a44b-27c0-46dc-8102-b8de41cdda90", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b19a457-e7d6-4cd4-91c5-8f9b6519adb5", "0cc7304f-1ddf-465f-9ccb-b5a1cbae4d84", "Roommate", "ROOMMATE" });
        }
    }
}
