using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCommonRoom_Capstone.Migrations
{
    public partial class UpdatePollsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8c019f-971e-484c-bc33-69f25871afc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c40add-6dfc-4bbc-8f15-f021d0482e31");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Polls");

            migrationBuilder.AddColumn<bool>(
                name: "CastVoteOptionOne",
                table: "Polls",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CastVoteOptionTwo",
                table: "Polls",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1bf1c40-9142-4760-9743-656793ffbeb6", "fe7cdc49-cf98-4017-aee3-bde16c9252bc", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "116ed299-bb60-43a1-86ca-141cd4411125", "ad511d4d-ba08-4d40-af20-2a6c5a96592d", "Roommate", "ROOMMATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "116ed299-bb60-43a1-86ca-141cd4411125");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bf1c40-9142-4760-9743-656793ffbeb6");

            migrationBuilder.DropColumn(
                name: "CastVoteOptionOne",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "CastVoteOptionTwo",
                table: "Polls");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Polls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e8c019f-971e-484c-bc33-69f25871afc6", "a2995688-62a1-4aef-8cd9-1decc28ce625", "Household Administrator", "HOUSEHOLD ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6c40add-6dfc-4bbc-8f15-f021d0482e31", "b139ef56-63df-426f-a652-0fc9f695152f", "Roommate", "ROOMMATE" });
        }
    }
}
