using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Hours { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int DepartamentId { get; set; }
        public Department Department { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Hours: {Hours}";
        }
    }
}
