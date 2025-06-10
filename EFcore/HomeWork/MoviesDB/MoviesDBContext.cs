using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFcore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFcore.HomeWork.MoviesDB
{
    public class MoviesDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<UserTitleView> UserTitleView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfDemoDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users").HasKey(e => e.Id);
                e.HasIndex(u => u.Name).IsUnique();
                e.ToTable(u => u.HasCheckConstraint("CK_Users_Name", "[Name] <> ''"));
                e.ToTable(t => t.HasCheckConstraint("CK_Users_Email", "[Email] LIKE '%@%.%'"));
            });
            modelBuilder.Entity<User>()
                .HasMany(u => u.Titles)
                .WithOne(t => t.User);

            modelBuilder.Entity<Title>(e =>
            {
                e.ToTable("Titles").HasKey(e => e.Id);
                e.Property(u => u.Name).HasMaxLength(50);
                e.Property(u => u.ReleaseDate).HasDefaultValueSql("GETDATE()");

            });

            modelBuilder.Entity<Title>()
                .HasOne(t => t.User)
                .WithMany(u => u.Titles)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<UserTitleView>()
                .HasNoKey()
                .ToView("vw_UserTitle");
        }

        public User Registration()
        {
            Console.WriteLine("User Login: ");
            string login = Console.ReadLine();
            Console.WriteLine("User Password: ");
            string password = Console.ReadLine();
            return Users.First(u => u.Login == login & u.Password == password);
        }
        public void ChangeUser(User user)
        {
            Console.WriteLine("Change:\n\t1 - Password\n\t2 - Name\n\t3 - Email\n\t0 - Quit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("User new password: ");
                    user.Password = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("User new Name: ");
                    user.Name = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("User new Email: ");
                    user.Email = Console.ReadLine();
                    break;
                default:
                    break;
            }
            SaveChanges();
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
            Console.WriteLine("Email Name: ");
            user.Email = Console.ReadLine();
            Users.Add(user);
            SaveChanges();
        }
        public void EnterTitle(int Id)
        {
            Title title = new Title();
            title.UserId = Users.First(u => u.Id == Id).Id;
            title.User = Users.First(u => u.Id == Id);
            Console.WriteLine("Title name: ");
            title.Name = Console.ReadLine();
            Console.WriteLine("Title release date: ");
            title.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Title duration (min): ");
            title.Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Title description: ");
            title.Description = Console.ReadLine();
            Titles.Add(title);
            SaveChanges();
        }
        public void DeleteTitle(int UId)
        {
            var titles = Titles.Include(x => x.User).ToList();
            foreach(var t in titles)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("Id of film you want to delete: ");
            int TId = int.Parse(Console.ReadLine());
            Title title = Titles.First(t => t.Id == TId & t.UserId == UId);
            Titles.Remove(title);
            SaveChanges();
        }
    }


}
