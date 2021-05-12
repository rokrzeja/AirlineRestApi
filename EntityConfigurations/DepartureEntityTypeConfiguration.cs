using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class DepartureEntityTypeConfiguration : IEntityTypeConfiguration<Departure>
    {
        public void Configure(EntityTypeBuilder<Departure> entity)
        {
            entity.ToTable("Departure", "c");

            entity.HasKey(e => e.departureId);
            entity.Property(e => e.departureId).ValueGeneratedOnAdd().HasColumnName("arrival_id");
            entity.Property(e => e.airportShortcut).IsRequired().HasMaxLength(30).HasColumnName("airport_shortcut");
            entity.Property(e => e.city).IsRequired().HasMaxLength(150);
            entity.Property(e => e.country).IsRequired().HasMaxLength(150);
        }
    }
}
