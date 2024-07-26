using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<MoticvUserToken>
    {
        public void Configure(EntityTypeBuilder<MoticvUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
