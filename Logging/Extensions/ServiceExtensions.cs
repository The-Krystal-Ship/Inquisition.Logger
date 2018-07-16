using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TheKrystalShip.Logging.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
            return services;
        }
    }
}
