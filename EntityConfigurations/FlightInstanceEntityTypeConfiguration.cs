using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class FlightInstanceEntityTypeConfiguration : IEntityTypeConfiguration<FlightInstance>
    {
        public void Configure(EntityTypeBuilder<FlightInstance> builder)
        {
            builder.ToTable("Flight_Instance", "c");

            builder.HasKey(e => e.flightInstanceId);
            builder.Property(e => e.flightInstanceId).ValueGeneratedOnAdd().HasColumnName("flight_instance_id");
            builder.Property(e => e.departureDate).IsRequired().HasColumnName("departure_date");
            builder.Property(e => e.arrivalDate).IsRequired().HasColumnName("arrival_date");
            builder.Property(e => e.ticketPrice).IsRequired().HasColumnName("ticket_price");

            builder.HasOne(e => e.flight)
                    .WithMany(s => s.flightInstances)
                    .HasForeignKey(s => s.flightId);
        }
    }
}
