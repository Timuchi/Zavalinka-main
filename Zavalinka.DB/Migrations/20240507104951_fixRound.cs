using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zavalinka.DB.Migrations
{
    /// <inheritdoc />
    public partial class fixRound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Theme_ThemeId",
                table: "Round");

            migrationBuilder.DropIndex(
                name: "IX_Round_ThemeId",
                table: "Round");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Round");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThemeId",
                table: "Round",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Round_ThemeId",
                table: "Round",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Theme_ThemeId",
                table: "Round",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
