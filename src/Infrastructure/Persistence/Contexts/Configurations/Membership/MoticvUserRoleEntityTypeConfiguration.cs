using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<MoticvUserRole>
    {
        public void Configure(EntityTypeBuilder<MoticvUserRole> builder)
        {
            builder.HasKey(m => new { m.UserId, m.RoleId });
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
