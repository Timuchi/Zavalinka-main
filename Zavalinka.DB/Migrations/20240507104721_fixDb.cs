using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zavalinka.DB.Migrations
{
    /// <inheritdoc />
    public partial class fixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThemeRound_Round_RoundId",
                table: "ThemeRound");

            migrationBuilder.DropIndex(
                name: "IX_ThemeRound_RoundId",
                table: "ThemeRound");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ThemeRound_RoundId",
                table: "ThemeRound",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeRound_Round_RoundId",
                table: "ThemeRound",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
