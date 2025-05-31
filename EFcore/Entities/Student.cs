using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public enum StudyFormat
    {
        Fulltime, Parttime, Online, Hybrid
    }
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [StringLength(50)] [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        public StudyFormat StudyFormat { get; set; }
        public float? Scholarship { get; set; }
        public int Age { get; set; }

        // foreign key
        public int? GroupId {  get; set; }
        // Navigation attribute
        public Group? Group { get; set; }

        public Passport? Passport { get; set; } = null!;

        public override string ToString()
        {
            return $"Id: {Id}, Full name: {FirstName + " " + LastName}, Scholarship: {Scholarship}, Group name: {Group.Name}";
        }
    }
}
