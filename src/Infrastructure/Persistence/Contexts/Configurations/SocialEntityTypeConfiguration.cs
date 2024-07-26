using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class SocialEntityTypeConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ResumeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Url).HasColumnType("varchar(max)").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Socials");

            builder.HasOne<Resume>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.ResumeId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
