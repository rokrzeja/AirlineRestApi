using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class FlightEntityTypeConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> entity)
        {
            entity.ToTable("Flight", "c");

            entity.HasKey(e => e.flightId);
            entity.Property(e => e.flightId).ValueGeneratedOnAdd().HasColumnName("flight_id");
            entity.Property(e => e.flightNumber).IsRequired().HasMaxLength(100).HasColumnName("flight_number");
            entity.Property(e => e.fixedCost).IsRequired().HasColumnName("fixed_cost");
            entity.Property(e => e.airportTax).IsRequired().HasColumnName("airport_tax");

            entity.HasOne(e => e.airplane)
                    .WithMany(s => s.flights)
                    .HasForeignKey(s => s.airplaneId);
            entity.HasOne(e => e.arrival)
                    .WithMany(s => s.flights)
                    .HasForeignKey(s => s.arrivalId);
            entity.HasOne(e => e.departure)
                    .WithMany(s => s.flights)
                    .HasForeignKey(s => s.departureId);
        }
    }
}
