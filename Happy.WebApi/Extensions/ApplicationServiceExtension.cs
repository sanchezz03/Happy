using Happy.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Happy.WebApi.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddDbContext<HappyDbContext>(opt =>
                {
                    var connectionString = GetConnectionString(configuration);
                    opt.UseNpgsql(connectionString);
                })
                .AddCors(opt =>
                {
                    opt.AddPolicy("CorsPolicy", policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4000");
                    });
                });
        }

        #region Private methods

        private static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("Database").GetSection("ConnectionString").Value;
            if (connectionString is null)
            {
                throw new Exception("Can't find connection string for database");
            }

            return connectionString;
        }

        #endregion
    }
}
