﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Entities
{
    public class Passport
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;


    }
}
