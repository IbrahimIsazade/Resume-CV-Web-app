using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<MoticvUserClaim>
    {
        public void Configure(EntityTypeBuilder<MoticvUserClaim> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
