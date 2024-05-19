using Happy.Service.Servises;
using Happy.Service.Servises.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Service.Extensions;

public static class HappyServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
    }

}
