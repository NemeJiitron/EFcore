using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Financing { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
