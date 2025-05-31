using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFcore.Entities;

namespace EFcore.HomeWork.MoviesDB
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Title> Titles { get; set; } = new List<Title>();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Login: {Login}, Password: {Password}";
        }
    }
}
