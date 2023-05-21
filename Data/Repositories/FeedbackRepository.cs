using Data.Infracstructure;
using Model.Entities;

namespace Data.Repositories
{
    public interface IFeebackRespository : IRepository<FeedBack, Guid>
    {
    }
    public class FeebackRespository : RepositoryBase<FeedBack, Guid>, IFeebackRespository
    {
        public FeebackRespository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
