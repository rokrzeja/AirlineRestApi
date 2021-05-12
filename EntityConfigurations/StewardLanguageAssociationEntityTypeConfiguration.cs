using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class StewardLanguageAssociationEntityTypeConfiguration : IEntityTypeConfiguration<StewardLanguageAssociation>
    {
        public void Configure(EntityTypeBuilder<StewardLanguageAssociation> entity)
        {
            entity.ToTable("Steward_Language_Association", "c");

            entity.HasKey(e => e.stewardLanguageAssociationId);
            entity.Property(e => e.stewardLanguageAssociationId).HasColumnName("steward_language_association_id");
            entity.Property(e => e.employeeId).IsRequired().HasColumnName("employee_id");
            entity.Property(e => e.languageId).IsRequired().HasColumnName("language_id");

            entity.HasOne(e => e.steward)
                    .WithMany(s => s.stewardLanguageList)
                    .HasForeignKey(s => s.employeeId);

            entity.HasOne(e => e.language)
                    .WithMany(s => s.stewardLanguageList)
                    .HasForeignKey(s => s.languageId);
        }
    }
}
