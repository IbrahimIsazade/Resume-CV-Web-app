using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Configurations
{

    public class PersonSkillEntityTypeConfiguration : IEntityTypeConfiguration<PersonSkill>
    {
        public void Configure(EntityTypeBuilder<PersonSkill> builder)
        {
            builder.Property(m => m.PersonId).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.SkillId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Mode).HasColumnType("int").IsRequired();
            builder.Property(m => m.Percentage).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");

            builder.HasKey(m => m.PersonId);
            builder.ToTable("PersonSkills");
        }
    }

}
