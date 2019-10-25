using Microsoft.EntityFrameworkCore.Migrations;

namespace ChristmasAPI.Migrations
{
    public partial class singularTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.DropPrimaryKey(
//                name: "PK_Users",
//                table: "Users");
//
//            migrationBuilder.DropPrimaryKey(
//                name: "PK_Families",
//                table: "Families");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ChristmasAPI.Models.User");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "ChristmasAPI.Models.Family");

//            migrationBuilder.AddPrimaryKey(
//                name: "PK_ChristmasAPI.Models.User",
//                table: "ChristmasAPI.Models.User",
//                column: "Id");
//
//            migrationBuilder.AddPrimaryKey(
//                name: "PK_ChristmasAPI.Models.Family",
//                table: "ChristmasAPI.Models.Family",
//                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChristmasAPI.Models.User",
                table: "ChristmasAPI.Models.User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChristmasAPI.Models.Family",
                table: "ChristmasAPI.Models.Family");

            migrationBuilder.RenameTable(
                name: "ChristmasAPI.Models.User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ChristmasAPI.Models.Family",
                newName: "Families");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "Id");
        }
    }
}
