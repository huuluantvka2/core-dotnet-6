using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection service)
        {
            service.AddScoped<IFeebackRespository, FeebackRespository>();

            return service;
        }
    }
}
