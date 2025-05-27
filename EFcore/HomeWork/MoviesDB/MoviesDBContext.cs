using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFcore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFcore.HomeWork.MoviesDB
{
    internal class MoviesDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfDemoDb;");
        }
        public void EnterUser()
        {
            User user = new User();
            Console.WriteLine("User Login: ");
            user.Login = Console.ReadLine();
            Console.WriteLine("User Password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("User Name: ");
            user.Name = Console.ReadLine();
            Users.Add(user);
            SaveChanges();
        }
    }


}
