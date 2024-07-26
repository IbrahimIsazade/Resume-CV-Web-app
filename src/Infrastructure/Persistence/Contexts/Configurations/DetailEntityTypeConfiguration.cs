using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class DetailEntityTypeConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ResumeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.Content).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Details");

            builder.HasOne<Resume>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.ResumeId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
