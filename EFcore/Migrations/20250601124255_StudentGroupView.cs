using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations
{
    /// <inheritdoc />
    public partial class StudentGroupView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
                (@"create view vw_StudentGroup as
                   select s.FirstName as StudentName, g.Name as GroupName
                   from Students s
                   join Groups g on s.GroupId = g.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view vw_StudentGroup;");
        }
    }
}
