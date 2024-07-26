using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<MoticvRoleClaim>
    {
        public void Configure(EntityTypeBuilder<MoticvRoleClaim> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
