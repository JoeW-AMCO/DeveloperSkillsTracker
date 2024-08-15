using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperSkillsTracker.Database;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;    Causes a lot of errors but is probably key to getting Migrations (important!) to work

namespace DeveloperSkillsTracker
{
    internal class MyDbContext : DbContext
    {
        public DbSet<DimUser> Users { get; set; }
        public DbSet<DimCertification> Certifications { get; set; }
        public DbSet<DimExperience> Experiences { get; set; }
        public DbSet<DimSkill> Skills { get; set; }

        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify your SQL Server connection string
            optionsBuilder.UseSqlServer(@"data source=ASWW00227\SQLEXPRESS;initial catalog=SkillsTracker;trusted_connection=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimSkill>()
                .HasOne(s => s.UserPK)          // Each Skill has one User
                .WithMany(u => u.SkillFK)      // Each User has many Skills
                .HasForeignKey(s => s.User_ID) // Foreign key on DimSkill table
                .HasConstraintName("PK_User_ID_FK_User_ID"); // Optional: specify a constraint name

            modelBuilder.Entity<DimExperience>()
                .HasOne(s => s.UserPK)          // Each Experience has one User
                .WithMany(u => u.ExperienceFK)      // Each User has many Experiences
                .HasForeignKey(s => s.User_ID) // Foreign key on DimExperience table
                .HasConstraintName("PK_User_ID_FK_Experience_ID"); // Optional: specify a constraint name

            modelBuilder.Entity<DimCertification>()
                .HasOne(s => s.UserPK)          // Each Certification has one User
                .WithMany(u => u.CertificationFK)      // Each User has many Certifications
                .HasForeignKey(s => s.User_ID) // Foreign key on DimCertification table
                .HasConstraintName("PK_User_ID_FK_Certification_ID"); // Optional: specify a constraint name
        }
    }
}