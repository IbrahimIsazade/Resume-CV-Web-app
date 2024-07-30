using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class ProjectCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ProjectId).HasColumnType("int").IsRequired();

            builder.HasKey(m => new { m.CategoryId, m.ProjectId });
            builder.ToTable("ProjectCategories");


            builder.HasOne<Project>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.ProjectId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Category>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.CategoryId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }

}
