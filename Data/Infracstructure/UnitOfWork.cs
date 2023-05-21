using Data.Repositories;

namespace Data.Infracstructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private BuildDbContext dbContext { get; set; }
        protected BuildDbContext DbContext { get { return dbContext ?? (dbContext = DbFactory.Init()); } }
        private Guid userId { get; set; }
        private IDbFactory DbFactory { get; set; }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }
        public void BeginTransaction()
        {
            DbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            DbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            DbContext.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public void SetUser(Guid userId)
        {
            this.userId = userId;
        }

        #region InitAndGetRepo
        private IFeebackRespository _FeedBacksRepo { get; set; }
        public IFeebackRespository FeedBacksRepo => _FeedBacksRepo ?? (_FeedBacksRepo = new FeebackRespository(DbFactory));
        #endregion
    }
}
