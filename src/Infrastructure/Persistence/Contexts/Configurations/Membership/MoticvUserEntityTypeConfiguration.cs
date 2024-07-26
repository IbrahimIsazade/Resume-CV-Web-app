using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvUserEntityTypeConfiguration : IEntityTypeConfiguration<MoticvUser>
    {
        public void Configure(EntityTypeBuilder<MoticvUser> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Users", "Membership");
        }
    }
}
