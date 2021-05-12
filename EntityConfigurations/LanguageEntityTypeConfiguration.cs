using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.EntityConfigurations
{
    public class LanguageEntityTypeConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("Language", "c");

            entity.HasKey(e => e.languageId);
            entity.Property(e => e.languageId).ValueGeneratedOnAdd().HasColumnName("language_id");
            entity.Property(e => e.language).IsRequired().HasMaxLength(50);
        }
    }
}
