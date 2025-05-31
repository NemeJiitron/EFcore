using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }
        [DefaultValue(25000)]
        public float Salary { get; set; }
        public int Age { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}, Age: {Age}";
        }
    }
}
