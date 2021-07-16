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
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}