using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class ResumeEntityTypeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.UserId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Bio).HasColumnType("nvarchar").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Resumes");
        }
    }
}
