using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Infrastructure
{
    public class TalentManagementContext : DbContext
    {
        public TalentManagementContext() { }

        public TalentManagementContext(DbContextOptions option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TalentManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonKnowledge> PersonKnowledges { get; set; }
        public DbSet<PersonTimeWork> PersonTimeWorks { get; set; }
        public DbSet<PersonWillingness> PersonWillingnesss { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TimeWork> TimeWorks { get; set; }
        public DbSet<Willingness> Willingnesss { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().ToTable("AccountType").HasKey(at => new { at.Id });
            modelBuilder.Entity<Bank>().ToTable("Bank").HasKey(b => new { b.Id });
            modelBuilder.Entity<City>().ToTable("City").HasKey(c => new { c.Id });
            modelBuilder.Entity<Knowledge>().ToTable("Knowledge").HasKey(k => new { k.Id });
            modelBuilder.Entity<Person>().ToTable("Person").HasKey(p => new { p.Id });
            modelBuilder.Entity<PersonKnowledge>().ToTable("PersonKnowledge").HasKey(pw => new { pw.PersonId, pw.KnowledgeId });
            modelBuilder.Entity<PersonTimeWork>().ToTable("PersonTimeWork").HasKey(pt => new { pt.PersonId, pt.TimeWorkId }); ;
            modelBuilder.Entity<PersonWillingness>().ToTable("PersonWillingness").HasKey(pw => new { pw.PersonId, pw.WillingnessId }); ;
            modelBuilder.Entity<State>().ToTable("State").HasKey(s => new { s.Id });
            modelBuilder.Entity<TimeWork>().ToTable("TimeWork").HasKey(t => new { t.Id });
            modelBuilder.Entity<Willingness>().ToTable("Willingness").HasKey(w => new { w.Id });
            modelBuilder.Entity<Profile>().ToTable("Profile").HasKey(p => new { p.Id });
        }
    }
}