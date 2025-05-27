using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public int Age { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}, Age: {Age}";
        }
    }
}
