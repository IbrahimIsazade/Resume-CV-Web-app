using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvRoleEntityTypeConfiguration : IEntityTypeConfiguration<MoticvRole>
    {
        public void Configure(EntityTypeBuilder<MoticvRole> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Roles", "Membership");
        }
    }
}
