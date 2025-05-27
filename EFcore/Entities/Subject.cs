using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Hours: {Hours}";
        }
    }
}
