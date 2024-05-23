using Happy.Service.Services.DataProviders;
using Happy.Service.Services.DataProviders.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Service.Extensions;

public static class DataProvidersServiceExtension
{
    public static IServiceCollection AddDataProviders(this IServiceCollection services)
    {
        return services
            .AddScoped<IWeekDataProvider, WeekDataProvider>();
    }
}
