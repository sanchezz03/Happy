using Happy.Service.Services;
using Happy.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Service.Extensions;

public static class CoreServiceExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IComplexService, ComplexService>()
            .AddScoped<IComplexExerciseService, ComplexExerciseService>()
            .AddScoped<IComplexWeekService, ComplexWeekService>()
            .AddScoped<IExerciseService, ExerciseService>()
            .AddScoped<IProgressService, ProgressService>();
    }
}
