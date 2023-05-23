using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.Identities;
using Model.Interfaces;
using System.Security.Claims;

namespace Data
{
    public class BuildDbContext : IdentityUserContext<User, Guid>
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;
        public BuildDbContext(DbContextOptions<BuildDbContext> options, IHttpContextAccessor? httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<FeedBack> FeedBacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating((modelBuilder));
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
                modelBuilder.Entity(entityType.ClrType)
                       .ToTable(entityType.GetTableName().Replace("AspNet", ""));
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            var entites = ChangeTracker.Entries();
            foreach (var entry in entites)
            {
                if (entry.Entity is IAudit)
                {
                    if (_httpContextAccessor.HttpContext != null && _httpContextAccessor?.HttpContext.User != null)
                    {
                        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                        var audit = (IAudit)entry.Entity;
                        var now = DateTime.UtcNow;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                audit.CreatedAt = now;
                                audit.CreatedBy = "userId";
                                break;
                            case EntityState.Modified:
                                audit.UpdatedAt = now;
                                audit.UpdatedBy = "userId";
                                break;
                        }
                    }

                }
            }
        }
    }
}
