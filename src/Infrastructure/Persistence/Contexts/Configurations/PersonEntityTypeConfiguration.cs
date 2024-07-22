using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.FullName).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Experience).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.Location).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Degree).HasColumnType("int").IsRequired();
            builder.Property(m => m.Location).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Fax).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Website).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.AttachmentPath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CareerLevel).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Persons");
        }
    }

}
