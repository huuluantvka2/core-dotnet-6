using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace Data
{
    public class BuildDbContext : DbContext
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
                    var audit = (IAudit)entry.Entity;
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            audit.CreatedAt = now;
                            break;
                        case EntityState.Modified:
                            audit.UpdatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}
