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
            builder.Property(m => m.FullName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Subject).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Content).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.AnsweredBy).HasColumnType("int");
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            builder.Property(m => m.Answer).HasColumnType("nvarchar").HasMaxLength(500);

            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");

            /*
              builder.HasOne<ContactPost>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
            */
        }
    }

}
