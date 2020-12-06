using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.DataAccess.Concrete.EntityFramework.Configurations;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookPenaltyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "";
            optionsBuilder.UseSqlServer(connString);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DayOfWeekend> DayOfWeekends { get; set; }
        public DbSet<LocalHoliday> LocalHolidays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
        }
    }
}
