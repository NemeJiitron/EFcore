using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations.MoviesDB
{
    /// <inheritdoc />
    public partial class FKMagration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Titles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Titles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserId",
                table: "Titles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Users_UserId",
                table: "Titles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Users_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Titles");
        }
    }
}
