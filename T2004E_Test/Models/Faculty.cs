﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T2004E_Test.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int FacultiesID { get; set; }
        public virtual Exam Exam { get; set; }
    }
}