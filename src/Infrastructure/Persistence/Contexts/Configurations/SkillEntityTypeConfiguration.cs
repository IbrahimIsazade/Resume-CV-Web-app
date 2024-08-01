using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class SkillEntityTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.GroupId).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.LastModifieAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");

            builder.HasKey(m => m.Id);
            builder.ToTable("Skills");

            builder.HasOne<SkillGroup>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.GroupId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
