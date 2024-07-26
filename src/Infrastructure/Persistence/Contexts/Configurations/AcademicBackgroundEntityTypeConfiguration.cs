using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class AcademicBackgroundEntityTypeConfiguration : IEntityTypeConfiguration<AcademicBackground>
    {
        public void Configure(EntityTypeBuilder<AcademicBackground> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ResumeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Qualification).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Degree).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.EducationName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Obtention).HasColumnType("int").IsRequired();
            builder.Property(m => m.Details).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("AcademicBackgrounds");


            builder.HasOne<Resume>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.ResumeId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
