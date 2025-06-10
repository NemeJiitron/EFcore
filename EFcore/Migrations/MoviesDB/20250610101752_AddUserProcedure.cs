using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations.MoviesDB
{
    /// <inheritdoc />
    public partial class AddUserProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    create procedure p_AddUser
                    @Name nvarchar(50), @Email nvarchar(50), @Login nvarchar(50), @Password nvarchar(50)
                    as
                    begin
                    insert into Users(Name, Email, Login, Password) 
                    values (@Name, @Email, @Login, @Password)
                    end");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure p_AddUser;");
        }
    }
}
