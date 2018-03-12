using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Projct> Projcts { get; set; }
        public DbSet<AssignPerson> AssignPersons { get; set; }
        public DbSet<Tasks> Taskss { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Priority> Prioritys { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}