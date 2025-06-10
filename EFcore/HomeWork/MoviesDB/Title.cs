using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.HomeWork.MoviesDB
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Duration { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, UserId: {UserId}, Name: {Name}, Duration: {Duration}, Description: {Description}, Release Date: {ReleaseDate}";
        }
    }
}
