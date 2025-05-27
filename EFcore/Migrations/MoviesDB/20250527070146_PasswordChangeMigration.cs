using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations.MoviesDB
{
    /// <inheritdoc />
    public partial class PasswordChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passward",
                table: "Users",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Passward");
        }
    }
}
