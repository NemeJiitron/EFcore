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
            MoviesDBContext MDb = new MoviesDBContext();

            User user = MDb.Registration();
            //MDb.EnterTitle(user.Id);
            //MDb.ChangeUser(user);
            foreach(var t in MDb.Titles.Include(g => g.User).ToList())
            {
                if(t.UserId == user.Id)
                {
                    Console.WriteLine(t.ToString());
                }
            }
        }
    }
}
