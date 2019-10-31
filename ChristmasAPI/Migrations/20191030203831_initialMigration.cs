using Microsoft.EntityFrameworkCore.Migrations;

namespace ChristmasAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    First = table.Column<string>(maxLength: 100, nullable: false),
                    Last = table.Column<string>(maxLength: 200, nullable: false),
                    SpouseId = table.Column<int>(nullable: true),
                    FamilyId = table.Column<int>(nullable: false),
                    ExchangeUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_ExchangeUserId",
                        column: x => x.ExchangeUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_User_SpouseId",
                        column: x => x.SpouseId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ExchangeUserId",
                table: "User",
                column: "ExchangeUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_FamilyId",
                table: "User",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SpouseId",
                table: "User",
                column: "SpouseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
