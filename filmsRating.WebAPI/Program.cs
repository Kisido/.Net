using filmsRating.WebAPI.AppConfiguration.ApplicationExtensions;
using filmsRating.WebAPI.AppConfiguration.ServicesExtensions;
using filmsRating.Repository;
using filmsRating.Services;
using Serilog;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration(); 
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddMapperConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositoryConfiguration();
builder.Services.AddBusinessLogicConfiguration();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSerilogConfiguration(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Application starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}