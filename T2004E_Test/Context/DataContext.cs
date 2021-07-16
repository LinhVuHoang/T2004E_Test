using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using T2004E_Test.Models;
namespace T2004E_Test.Context
{
    public class DataContext : DbContext
    {
        public DataContext(): base("T2004E_Test")
        { }
        public DbSet<Classroom> Classrooms { get; set; }

        public DbSet<Exam> Exams { get; set; }
        public System.Data.Entity.DbSet<T2004E_Test.Models.Faculty> Faculties { get; set; }
    }
}