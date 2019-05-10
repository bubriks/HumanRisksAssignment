using Microsoft.EntityFrameworkCore;
using HumanRisks.Models;

namespace HumanRisks
{
    //add-migration InitialMigration
    //Update-Database

    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Localhost;Database=HumanRisksExercise;Trusted_Connection=True;");
        }

        public DbSet<RiskAssessment> RiskAssessments { get; set; }
        public DbSet<Threat> Threats { get; set; }

        /// <summary>
        /// Creates seed
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RiskAssessment>().HasData(
                new RiskAssessment {Id = "1", Title = "Test", Latitude = 0.1, Longitude = 0.2},
                new RiskAssessment {Id = "2", Title = "XPPR", Latitude = 3, Longitude = 77.5},
                new RiskAssessment {Id = "3", Title = "GP", Latitude = 4.31, Longitude = 4.2}
            );

            modelBuilder.Entity<Threat>().HasData(
                new Threat {Id = "1", Title = "T1", Level = 1, RiskAssessmentId = "1"},
                new Threat {Id = "2", Title = "T2", Level = 0, RiskAssessmentId = "1"},
                new Threat {Id = "3", Title = "T3", Level = 2, RiskAssessmentId = "2"}
            );
        }
    }
}
