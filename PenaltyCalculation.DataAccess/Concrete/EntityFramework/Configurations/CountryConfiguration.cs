using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PenaltyCalculation.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne<Currency>(x => x.Currency).WithMany(x => x.Countries).HasForeignKey(x => x.CurrencyId);
            builder.HasMany(x => x.LocalHolidays).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
            builder.HasMany(x => x.DayOfWeekends).WithOne(x => x.Country).HasForeignKey(x => x.CountryId);
        }
    }
}
