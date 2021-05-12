using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("Client", "c");

            entity.HasKey(e => e.clientId);
            entity.Property(e => e.clientId).ValueGeneratedOnAdd().HasColumnName("client_id");
            entity.Property(e => e.personalId).IsRequired().HasColumnName("personal_id");
            entity.Property(e => e.firstName).IsRequired().HasMaxLength(100).HasColumnName("first_name");
            entity.Property(e => e.lastName).IsRequired().HasMaxLength(100).HasColumnName("last_name");
            entity.Property(e => e.sex).IsRequired().HasMaxLength(10);
            entity.Property(e => e.birthDate).IsRequired().HasColumnName("birth_date");
            entity.Property(e => e.birthPlace).IsRequired().HasMaxLength(150).HasColumnName("birth_place");
            entity.Property(e => e.placeOfResidance).IsRequired().HasMaxLength(150).HasColumnName("place_of_residance");
            entity.Property(e => e.telephoneNumber).IsRequired().HasColumnName("telephone_number");
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.documentNumber).IsRequired().HasMaxLength(100).HasColumnName("document_number");
        }
    }
}
