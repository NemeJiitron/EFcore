using EFcore.Entities;
using EFcore.HomeWork.MoviesDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

            //string name = Console.ReadLine();
            //db.Database.ExecuteSqlRaw("Exec p_AddGroup @p0", name);

            while (true)
            {
                Console.WriteLine("1 - Expand table\n2 - View table\n0 - Quit");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        Console.WriteLine("1 - Students\n2 - Teachers\n3 - Group\n0 - Quit");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            case "1":
                                AppDbContext.CreateStudent(db);
                                break;
                            case "2":
                                AppDbContext.CreateTeacher(db);
                                break;
                            case "3":
                                AppDbContext.CreateGroup(db);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("1 - Students\n2 - Teachers\n3 - Group\n0 - Quit");
                        string input3 = Console.ReadLine();
                        switch (input3)
                        {
                            case "1":
                                AppDbContext.ReadAllStudents(db);
                                break;
                            case "2":
                                AppDbContext.ReadAllTeachers(db);
                                break;
                            case "3":
                                AppDbContext.ReadAllGroups(db);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                if (input == "0")
                {
                    break;
                }
            }
            
        }
    }
}
