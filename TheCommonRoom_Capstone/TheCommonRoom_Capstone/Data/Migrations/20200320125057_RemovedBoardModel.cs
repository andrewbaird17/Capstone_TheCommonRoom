using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Migrations
{
    public partial class RemovedBoardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Boards_BoardId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Boards_BoardId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Boards_BoardId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_Households_Boards_BoardId",
                table: "Households");

            migrationBuilder.DropForeignKey(
                name: "FK_Polls_Boards_BoardId",
                table: "Polls");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Polls_BoardId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Households_BoardId",
                table: "Households");

            migrationBuilder.DropIndex(
                name: "IX_Chores_BoardId",
                table: "Chores");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BoardId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_BoardId",
                table: "Announcements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "318c30f1-20c6-443c-b78f-ea83a9b166ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e174299c-35f5-431e-a31f-74e75235e530");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Households");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Polls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Chores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Announcements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c366858d-c387-4aa1-98d7-4cafdb87e3c7", "40c86034-c0de-4401-a652-3f738d573b3c", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db68a4be-1a4c-4508-9236-bafe845e6cee", "5ceea952-82d0-4e7a-9a7a-3f7555845044", "Roommate", "ROOMMATE" });

            migrationBuilder.InsertData(
                table: "Households",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Emily's Group" });

            migrationBuilder.CreateIndex(
                name: "IX_Polls_HouseholdId",
                table: "Polls",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_HouseholdId",
                table: "Chores",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_HouseholdId",
                table: "Bills",
                column: "HouseholdId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_HouseholdId",
                table: "Announcements",
                column: "HouseholdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Households_HouseholdId",
                table: "Announcements",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Households_HouseholdId",
                table: "Bills",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Households_HouseholdId",
                table: "Chores",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_Households_HouseholdId",
                table: "Polls",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Households_HouseholdId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Households_HouseholdId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Households_HouseholdId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_Polls_Households_HouseholdId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Polls_HouseholdId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Chores_HouseholdId",
                table: "Chores");

            migrationBuilder.DropIndex(
                name: "IX_Bills_HouseholdId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_HouseholdId",
                table: "Announcements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c366858d-c387-4aa1-98d7-4cafdb87e3c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db68a4be-1a4c-4508-9236-bafe845e6cee");

            migrationBuilder.DeleteData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Households",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Chores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "318c30f1-20c6-443c-b78f-ea83a9b166ab", "836defd2-1fbf-4bb5-aa75-3d007916eadb", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" },
                    { "e174299c-35f5-431e-a31f-74e75235e530", "b40b6e47-e40c-4a8d-9771-b9400350c9e5", "Roommate", "ROOMMATE" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.UpdateData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 1,
                column: "BoardId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Households",
                keyColumn: "Id",
                keyValue: 2,
                column: "BoardId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Polls_BoardId",
                table: "Polls",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Households_BoardId",
                table: "Households",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_BoardId",
                table: "Chores",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BoardId",
                table: "Bills",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_BoardId",
                table: "Announcements",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Boards_BoardId",
                table: "Announcements",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Boards_BoardId",
                table: "Bills",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Boards_BoardId",
                table: "Chores",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Households_Boards_BoardId",
                table: "Households",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_Boards_BoardId",
                table: "Polls",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
