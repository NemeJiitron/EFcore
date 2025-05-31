using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Group
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Name { get; set; }

        // Navigation attribute
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Students count: {Students.Count}";
        }
    }
}
