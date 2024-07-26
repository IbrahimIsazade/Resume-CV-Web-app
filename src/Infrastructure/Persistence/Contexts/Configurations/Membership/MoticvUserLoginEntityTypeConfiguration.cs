using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations.Membership
{
    public class MoticvUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<MoticvUserLogin>
    {
        public void Configure(EntityTypeBuilder<MoticvUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
