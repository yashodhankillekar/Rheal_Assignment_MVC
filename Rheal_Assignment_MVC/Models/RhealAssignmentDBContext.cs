using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rheal_Assignment_MVC.Models
{
    public class RhealAssignmentDBContext : DbContext
    {

        public RhealAssignmentDBContext():base("name=RhealAssignmentConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<AreaOfInterest> AreaOfInterests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TrainerCourse> TrainerCourses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}