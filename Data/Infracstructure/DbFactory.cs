using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Data.Infracstructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BuildDbContext dbContext;
        private DbContextOptions<BuildDbContext> options;
        private IHttpContextAccessor httpContextAccessor;
        public DbFactory(DbContextOptions<BuildDbContext> options, IHttpContextAccessor httpContextAccessor)
        {
            this.options = options;
            this.httpContextAccessor = httpContextAccessor;
        }
        public BuildDbContext Init()
        {
            Console.WriteLine("Da Initialize");
            return dbContext ?? (dbContext = new BuildDbContext(options, httpContextAccessor));
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
