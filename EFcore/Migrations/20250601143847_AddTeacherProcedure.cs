using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
                (@"create procedure p_AggTeacher
                   @name nvarchar(450), @salary decimal(8,2), @age int
                   as
                   begin 
                        insert into Teachers(Name, Salary, Age) values (@name, @salary, @age)
                   end
                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure p_AggTeacher;");
        }
    }
}
