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

            while (true)
            {
                Console.WriteLine("1 - Add User\n2 - All users\n0 - Quit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        MDb.EnterUser();
                        break;
                    case 2:
                        foreach (var user in MDb.Users)
                        {
                            Console.WriteLine(user.ToString());
                        }
                        break;
                    default:
                        break;
                }
                if (choice == 0) 
                {
                    break;
                }
            }
        }
    }
}
