using Happy.Common.Extensions;
using Happy.WebApi.Extensions;
using Happy.Infrastructure.Extensions;
using Happy.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .AddConfiguration();

builder.Services
    .AddAuthorization()
    .AddControllers().Services
    .AddDatabase()
    .AddDataProviders()
    .AddCoreServices()
    .AddMapping()
    .AddIdentityServices()
    .AddEndpointsApiExplorer()
    .AddMvc().Services
    .AddSwaggerGen()
    .AddApiVersion()
    .AddCORS();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();