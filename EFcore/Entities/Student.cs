using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float? Scholarship { get; set; }
        public int Age { get; set; }

        // foreign key
        public int? GroupId {  get; set; }
        // Navigation attribute
        public Group? Group { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Full name: {FirstName + " " + LastName}, Scholarship: {Scholarship}, Group name: {Group.Name}";
        }
    }
}
