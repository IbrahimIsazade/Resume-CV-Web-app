using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.CssClass).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");

            builder.HasKey(m => m.Id);
            builder.ToTable("Services");

            /*
              builder.HasOne<Service>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
            */
        }
    }

}
