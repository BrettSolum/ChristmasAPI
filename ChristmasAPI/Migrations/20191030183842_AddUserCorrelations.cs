using Microsoft.EntityFrameworkCore.Migrations;

namespace ChristmasAPI.Migrations
{
    public partial class AddUserCorrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql((@"
select * into UserTemp from ChristmasAPI.Models.User"));
            
            
            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "ChristmasAPI.Models.User");

            migrationBuilder.RenameColumn(
                name: "Family",
                table: "ChristmasAPI.Models.User",
                newName: "FamilyId");

            migrationBuilder.AlterColumn<int>(
                name: "SpouseId",
                table: "ChristmasAPI.Models.User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ExchangeUserId",
                table: "ChristmasAPI.Models.User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeUserId",
                table: "ChristmasAPI.Models.User");

            migrationBuilder.RenameColumn(
                name: "FamilyId",
                table: "ChristmasAPI.Models.User",
                newName: "Family");

            migrationBuilder.AlterColumn<int>(
                name: "SpouseId",
                table: "ChristmasAPI.Models.User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exchange",
                table: "ChristmasAPI.Models.User",
                nullable: false,
                defaultValue: 0);
        }
    }
}
