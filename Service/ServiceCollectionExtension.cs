using Microsoft.Extensions.DependencyInjection;
using Sercurity;
using Service.Implements;
using Service.Interfaces;

namespace Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection service)
        {

            service.AddScoped<IFeedbackService, FeedbackService>();
            //JWT
            service.AddScoped<JwtService>();

            return service;
        }
    }
}
