using Microsoft.Extensions.DependencyInjection;

namespace Happy.Service.Extensions;

public static class CoreServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }
}
