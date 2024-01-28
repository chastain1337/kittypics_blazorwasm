using KittyPics.Shared;
using KittyPics.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

#if LOCAL
    var appSettingsPath = "appsettings.local.json";
#else
    var appSettingsPath = "appsettings.json";
#endif

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile(appSettingsPath, false, true)
    .Build();

var connectionStrings = config.GetSection("ConnectionStrings").Get<ConnectionStrings>();
services.AddSingleton<ConnectionStrings>(connectionStrings);
services.AddTransient<IPicsRepository, PicsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#if LOCAL
var originMatchString = "localhost";
#else
var originMatchString = "chastain1337.github.io";
#endif
app.UseCors(x => x
                .SetIsOriginAllowed(origin => origin.Contains(originMatchString))
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();