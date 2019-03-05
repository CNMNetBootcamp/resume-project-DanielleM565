using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResumeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeProject.Data
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }

        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Event> Events {get; set;}
        public DbSet<Experience> Experiences {get; set;}
        public DbSet<ExperienceType> ExperienceTypes {get; set;}
        public DbSet<Person> People { get; set; }
        public DbSet<PersonalSkill> PersonalSkills {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>().ToTable("Description");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Experience>().ToTable("Experience");
            modelBuilder.Entity<ExperienceType>().ToTable("ExperienceType");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PersonalSkill>().ToTable("PersonalSkill");

        }
    }
}
