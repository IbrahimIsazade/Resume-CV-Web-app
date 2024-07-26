using Domain;
using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    class DataContext : IdentityDbContext<MoticvUser, MoticvRole, int, MoticvUserClaim, MoticvUserRole, MoticvUserLogin, MoticvRoleClaim, MoticvUserToken>
    {
        public DataContext(DbContextOptions options) : base(options) { }


        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AcademicBackground> AcademicBackgrounds { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Social> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<ICreateEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
                else
                {
                    entry.Property(m => m.CreatedAt).IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
