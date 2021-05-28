using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> entity)
        {
            entity.ToTable("Reservation", "c");

            entity.HasKey(e => e.reservationId);
            entity.Property(e => e.reservationId).ValueGeneratedOnAdd().HasColumnName("reservation_id");
            entity.Property(e => e.numberOfPassengers).IsRequired().HasColumnName("number_of_passengers");
            entity.Property(e => e.flightClass).IsRequired().HasMaxLength(30).HasColumnName("flight_class");
            entity.Property(e => e.extraLuggage).IsRequired().HasColumnName("extra_luggage");
            entity.Property(e => e.dateOfPurchase).IsRequired().HasColumnName("date_of_purchase");

            entity.HasOne(e => e.flightInstance)
                    .WithMany(s => s.reservations)
                    .HasForeignKey(s => s.flightInstanceId);

            entity.HasOne(e => e.client)
                    .WithMany(s => s.reservations)
                    .HasForeignKey(s => s.clientId);
        }
    }
}
