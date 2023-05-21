using Data.Repositories;

namespace Data.Infracstructure
{
    public interface IUnitOfWork
    {
        void SetUser(Guid userId);
        int SaveChanges();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task SaveChangesAsync();

        #region Repo

        public IFeebackRespository FeedBacksRepo { get; }

        #endregion
    }

}
