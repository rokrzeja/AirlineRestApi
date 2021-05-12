using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class AirplaneEntityTypeConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> entity)
        {
            entity.ToTable("Airplane", "c");

            entity.HasKey(e => e.airplaneId);
            entity.Property(e => e.airplaneId).ValueGeneratedOnAdd().HasColumnName("airplane_id");
            entity.Property(e => e.code).IsRequired().HasMaxLength(30);
            entity.Property(e => e.shortcut).IsRequired().HasMaxLength(30);
            entity.Property(e => e.fullName).IsRequired().HasMaxLength(150).HasColumnName("full_name");
            entity.Property(e => e.economyClassCapacity).IsRequired().HasColumnName("economy_class_capacity");
            entity.Property(e => e.businessClassCapacity).IsRequired().HasColumnName("business_class_capacity");
            entity.Property(e => e.firstClassCapacity).IsRequired().HasColumnName("first_class_capacity");
            entity.Property(e => e.range).IsRequired();
            entity.Property(e => e.productionYear).IsRequired().HasColumnName("production_year");
            entity.Property(e => e.manufacturer).IsRequired().HasMaxLength(150);
            entity.Property(e => e.hoursFlown).IsRequired().HasColumnName("hours_flown");
            entity.Property(e => e.dateOfLastService).IsRequired().HasColumnName("date_of_last_service");
        }
    }
}
