using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperSkillsTracker.Database;
using Microsoft.EntityFrameworkCore;

namespace DeveloperSkillsTracker.Database
{
    internal class MyDbContext : DbContext
    {
        public DbSet<DimUser> Users { get; set; }
        public DbSet<DimCertification> Certifications { get; set; }
        public DbSet<DimExperience> Experiences { get; set; }
        public DbSet<DimSkill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify your SQL Server connection string
            optionsBuilder.UseSqlServer(@"data source=ASWW00227\\SQLEXPRESS;initial catalog=SkillsTracker;trusted_connection=true;TrustServerCertificate=True;");
        }
    }
}
