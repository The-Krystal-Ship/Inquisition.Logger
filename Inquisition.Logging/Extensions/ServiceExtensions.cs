using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Inquisition.Logging.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
            return services;
        }
    }
}
