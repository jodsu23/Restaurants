
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



//Esta config video 23 esta en ServiceCollectionExtensions.cs
//builder.Services.AddDbContext<RestaurantsDbContext>();
//builder.Services.AddInfrastructure();
//builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("RestaurantsDb"));
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
//        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Information)
//        .WriteTo.File("Logs/Restaurant-API-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
//        .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {Newline} {Message:lj}{NewLine}{Exception}]")
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
