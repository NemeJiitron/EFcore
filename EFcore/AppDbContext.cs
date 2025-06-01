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
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroupView> StudentGroupViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfDemoDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(e =>
            {
                e.ToTable("Students").HasKey(s => s.Id);

                e.Property(s => s.FirstName).IsRequired().HasMaxLength(25);
                e.Property(s => s.LastName).IsRequired().HasMaxLength(25);

                e.HasIndex(s => s.Email).IsUnique();
                e.ToTable(t => t.HasCheckConstraint("CK_Student_Email", "[Email] LIKE '%@%.%'"));

                e.Property(s => s.Scholarship).HasColumnType("decimal(6,2)");

                e.Property(s => s.StudyFormat).HasConversion<string>();
                e.ToTable(t => t.HasCheckConstraint(
                    "CK_Student_StudyFormat",
                    $"[StudyFormat] IN ('FullTime', 'PartTime', 'Online', 'Hybrid')"));

            });
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Passport)
                .WithOne(s => s.Student)
                .HasForeignKey<Passport>(p => p.StudentId);
            modelBuilder.Entity<Group>()
               .HasMany(s => s.Students)
               .WithOne(s => s.Group)
               .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Passport>(e =>
                e.ToTable(t => t.HasCheckConstraint("CK_Passport_Number", "[Number] LIKE '_________'"))
            );

            modelBuilder.Entity<Teacher>(e =>
            {
               e.ToTable(t => t.HasCheckConstraint("CK_Teacher_Salary", "[Salary] > 0"));
               e.Property(s => s.Salary).HasColumnType("decimal(8,2)");
            }
            );
            modelBuilder.Entity<Teacher>()
               .HasMany(t => t.Subjects)
               .WithMany(s => s.Teachers)
               .UsingEntity(j => j.ToTable("TeachersSubjects"));

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Department)
                .WithOne(s => s.Subject);

            modelBuilder.Entity<StudentGroupView>()
                .HasNoKey()
                .ToView("vw_StudentGroup");
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
            Console.WriteLine("Email: ");
            student.Email = Console.ReadLine();
            Console.WriteLine("Age: ");
            student.Age = int.Parse(Console.ReadLine());
            student.StudyFormat = StudyFormat.Fulltime;
            Console.WriteLine("Scholarship: ");
            string scholarship = Console.ReadLine();
            student.Scholarship = scholarship.IsNullOrEmpty() ? null : float.Parse(scholarship);

            Console.WriteLine("Group ID: ");
            student.GroupId = int.Parse(Console.ReadLine());

            student.Group = db.Groups.FirstOrDefault(g => g.Id == student.GroupId);

            db.Students.Add(student);

            db.SaveChanges();
        }
        
        //teacher
        public static void CreateTeacher(AppDbContext db)
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("Name: ");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Salary: ");
            teacher.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Age: ");
            teacher.Age = int.Parse(Console.ReadLine());
            db.Teachers.Add(teacher);
            db.SaveChanges();
        }
        public static void DeleteTeacher(AppDbContext db)
        {
            Console.WriteLine("Teacher Id: ");
            int Id = int.Parse(Console.ReadLine());
            db.Teachers.Remove(db.Teachers.First(t => t.Id == Id));
            db.SaveChanges();
        }
        public static void ReadAllTeachers(AppDbContext db)
        {
            var teachers = db.Teachers.Include(g => g.Subjects).ToList();
            foreach (var t in teachers)
            {
                Console.WriteLine(t.ToString());
            }
        }

        //Subjects
        public static void CreateSubject(AppDbContext db)
        {
            Subject subject = new Subject();
            Console.WriteLine("Name: ");
            subject.Name = Console.ReadLine();
            Console.WriteLine("Description: ");
            subject.Description = Console.ReadLine();
            Console.WriteLine("Department Id: ");
            subject.DepartamentId = int.Parse(Console.ReadLine());
            subject.Department = db.Departments.First(d => d.Id == subject.DepartamentId);
            db.Subjects.Add(subject);
            db.SaveChanges();
        }
        public static void DeleteSubject(AppDbContext db)
        {
            Console.WriteLine("Subject Id: ");
            int Id = int.Parse(Console.ReadLine());
            db.Subjects.Remove(db.Subjects.First(s => s.Id == Id));
            db.SaveChanges();
        }
        public static void ReadAllSubjects(AppDbContext db)
        {
            var subjects = db.Subjects.Include(s => s.Teachers).ToList();
            foreach (var t in subjects)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}

