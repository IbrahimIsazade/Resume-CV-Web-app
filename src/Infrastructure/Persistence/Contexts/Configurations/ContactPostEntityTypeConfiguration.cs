using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.SenderId).HasColumnType("int").IsRequired();
            builder.Property(m => m.RecieverId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Content).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }

}
