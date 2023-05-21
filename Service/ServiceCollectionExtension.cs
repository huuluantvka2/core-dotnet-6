using Microsoft.Extensions.DependencyInjection;
using Service.Implements;
using Service.Interfaces;

namespace Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection service)
        {
            service.AddScoped<IFeedbackService, FeedbackService>();

            return service;
        }
    }
}
