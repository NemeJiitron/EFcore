using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations.MoviesDB
{
    /// <inheritdoc />
    public partial class UserTitleView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    create view vw_UserTitle as
                    select u.Id as UserId, u.Name as UserName, t.Id as TitleId, t.Name as TitleName
                    from Users u
                    join Titles t on t.UserId = u.Id;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view vw_UserTitle;");
        }
    }
}
