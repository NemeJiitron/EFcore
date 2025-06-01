using EFcore;
using EFcore.Entities;
using EFcore.Migrations;
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
    }
}