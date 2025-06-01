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

            string name = Console.ReadLine();
            //db.Database.ExecuteSqlRaw("Exec p_AddGroup @p0", name);
            
            AppDbContext.ReadAllGroups(db);

            foreach (var sg in db.StudentGroupViews)
            {
                Console.WriteLine(sg.StudentName + " - " + sg.GroupName);
            }
        }
    }
}
