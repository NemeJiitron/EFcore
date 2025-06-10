using System.ComponentModel.DataAnnotations;
using EFcore;
using EFcore.Entities;
using EFcore.HomeWork.MoviesDB;
using EFcore.Migrations;
using EFcore.Migrations.MoviesDB;
using Microsoft.EntityFrameworkCore;

namespace DbTestProject
{
    public class Tests
    {
        [Test]
        public void AddGroupStudent_StudentGroupAddedToDB()
        {
            // Arrange - готуємось до тесту

            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Group g = new Group() { Name = "Test group" };

                db.Groups.Add(g);
                db.SaveChanges();

                Student s = new Student()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Age = 1,
                    Email = "Test@g.com",
                    StudyFormat = StudyFormat.Fulltime,
                    GroupId = g.Id
                };

                db.Students.Add(s);
                db.SaveChanges();
            }

            // Assert

            using(AppDbContext db = new AppDbContext())
            {
                Student s = db.Students.Include(s => s.Group).FirstOrDefault();

                Assert.IsNotNull(s);
                Assert.AreEqual("Test", s.FirstName);
                Assert.AreEqual("Test group", s.Group.Name);
            }



        }
        [Test]
        public void AddTeacher_TeacherAddedToDB()
        {
            // Arrange - готуємось до тесту

            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Teacher t = new Teacher() { Name = "Test", Salary = 10, Age = 10 };

                db.Teachers.Add(t);
                db.SaveChanges();
            }

            // Assert

            using (AppDbContext db = new AppDbContext())
            {
                Teacher t = db.Teachers.FirstOrDefault();

                Assert.IsNotNull(t);
                Assert.AreEqual("Test", t.Name);
            }
        }
        [Test]
        public void AddSubject_SubjectAddedToDB()
        {
            // Arrange - готуємось до тесту

            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Subject s = new Subject() { Name = "Test", Hours = 10, DepartamentId = 1, Description = "test" };

                db.Subjects.Add(s);
                db.SaveChanges();
            }

            // Assert

            using (AppDbContext db = new AppDbContext())
            {
                Subject s = db.Subjects.FirstOrDefault();

                Assert.IsNotNull(s);
                Assert.AreEqual("Test", s.Name);
            }
        }

        [Test]
        public void AddUserAndTitle_UserAndTitleAddedToDB()
        {
            using (MoviesDBContext db = new MoviesDBContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                User u = new User() { Name = "test", Email = "test@test.t", Login = "test", Password = "test" };
                db.Users.Add(u);
                db.SaveChanges();

                Title t = new Title() { Name = "test", UserId = db.Users.First().Id, ReleaseDate = DateTime.Now, Description = "test", Duration = 1 };
                db.Titles.Add(t);
                db.SaveChanges();

            }

            using (MoviesDBContext db = new MoviesDBContext())
            {
                User u = db.Users.FirstOrDefault();
                Title t = db.Titles.FirstOrDefault();

                Assert.IsNotNull(u);
                Assert.AreEqual("test", u.Name);
                Assert.IsNotNull(t);
                Assert.AreEqual("test", u.Name);
            }
        }

    }



}