using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class ExperienceEntityTypeConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ResumeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Duration).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.JobTitle).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CompanyName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Location).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Details).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Experiences");

            builder.HasOne<Resume>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.ResumeId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
