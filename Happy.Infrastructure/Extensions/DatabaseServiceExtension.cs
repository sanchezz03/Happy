using Happy.Common;
using Happy.Common.ConfigurationModels;
using Happy.Common.ConfigurationOptions;
using Happy.Common.Helpers;
using Happy.Domain.Repositories;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Happy.Infrastructure.Extensions;

public static class DatabaseServiceExtension
{

    #region Public methods

    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.ConfigureOptions();

        var configuration = services
            .BuildServiceProvider()
            .GetRequiredService(typeof(IOptions<DatabaseConfiguration>)) as IOptions<DatabaseConfiguration>;

        if (configuration == null || configuration.Value == null || configuration.Value.ConnectionString == null)
        {
            throw new Exception("Not found DB configuration in config file");
        }

        services.AddDbContextPool<AppDbContext>((services, options) =>
        {
            options.UseNpgsql(configuration.Value.ConnectionString, b => b.MigrationsAssembly(Constants.MIGRATION_PROJECT_NAME));
        });

        SetDIRepositories();

        return services;

        void SetDIRepositories()
        {
            services.AddScoped(typeof(IRelationalRepository<>), typeof(BaseRelationalRepository<>));

            var relationalRepositiries = TypesHelper.GetDerivedTypesFromAssembly(typeof(BaseRelationalRepository<>));
            relationalRepositiries.ToList().ForEach(type => services.AddScoped(type));
        }
    }

    #endregion

    #region Private methods

    private static IServiceCollection ConfigureOptions(this IServiceCollection services)
    {
        return services.AddTransient<IConfigureOptions<DatabaseConfiguration>, DatabaseConfigurationOption>();
    }

    #endregion
}
