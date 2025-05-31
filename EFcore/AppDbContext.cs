using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFcore.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EFcore
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfDemoDb;");
        }

        public static void CreateGroup(AppDbContext db)
        {
            Group g = new Group();
            Console.WriteLine("Group name:");
            g.Name = Console.ReadLine();
            db.Groups.Add(g);
            db.SaveChanges();
        }

        public static void DeleteStudent(AppDbContext db)
        {
            Console.WriteLine("Enter Id of student you want to delete");
            int id = int.Parse(Console.ReadLine());

            Student? student = db.Students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                db.Students.Remove(student);
                Console.WriteLine($"Student with id: {id} is removed");
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Student with id: {id} is non-existant");
            }
        }

        public static void UpdateStudent(AppDbContext db)
        {
            Console.WriteLine("Enter Id of student you want to change");
            int id = int.Parse(Console.ReadLine());

            Student? student = db.Students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                student.FirstName = Console.ReadLine();
                student.LastName = Console.ReadLine();
                student.Age = int.Parse(Console.ReadLine());
                string scholarship = Console.ReadLine();
                student.Scholarship = scholarship.IsNullOrEmpty() ? null : float.Parse(scholarship);

                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Student with id: {id} is non-existant");
            }
        }

        public static void ReadAllStudents(AppDbContext db)
        {
            var students = db.Students.Include(g => g.Group).ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public static void ReadAllGroups(AppDbContext db)
        {
            var groups = db.Groups.Include(x => x.Students).ToList();
            var gs = db.Groups.ToList();
            foreach (var g in gs)
            {
                Console.WriteLine(g.ToString());
            }
        }

        public static void CreateStudent(AppDbContext db)
        {
            Student student = new Student();
            Console.WriteLine("FirstName: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("LastName: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Scholarship: ");
            string scholarship = Console.ReadLine();
            student.Scholarship = scholarship.IsNullOrEmpty() ? null : float.Parse(scholarship);

            Console.WriteLine("Group ID: ");
            student.GroupId = int.Parse(Console.ReadLine());

            student.Group = db.Groups.FirstOrDefault(g => g.Id == student.GroupId);
            
            db.Students.Add(student);

            db.SaveChanges();
        }

    }

}
