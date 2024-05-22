using Happy.Common.Extensions;
using Happy.WebApi.Extensions;
using Happy.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .AddConfiguration();

builder.Services
    .AddAuthorization()
    .AddControllers().Services
    .AddDatabase()
    .AddIdentityServices()
    .AddEndpointsApiExplorer()
    .AddMvc().Services
    .AddSwaggerGen()
    .AddApiVersion()
    .AddCORS();

//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();