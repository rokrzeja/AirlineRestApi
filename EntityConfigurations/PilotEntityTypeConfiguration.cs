using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class PilotEntityTypeConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> entity)
        {
            entity.ToTable("Pilot", "c");

            entity.Property(e => e.rank).IsRequired().HasMaxLength(50);
        }
    }
}
