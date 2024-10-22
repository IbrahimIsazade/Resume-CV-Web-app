﻿using Domain;
using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence.Contexts
{
    class DataContext : IdentityDbContext<MoticvUser, MoticvRole, int, MoticvUserClaim, MoticvUserRole, MoticvUserLogin, MoticvRoleClaim, MoticvUserToken>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MoticvUserClaim>().HasKey(x => x.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ICreateEntity>())
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
