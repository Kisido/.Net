using filmsRating.Services.Abstract;
using filmsRating.Services.Implementation;
using filmsRating.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace filmsRating.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IMovieActorService, MovieActorService>();
        services.AddScoped<IMovieGenreService, MovieGenreService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IUserRatingService, UserRatingService>();
        services.AddScoped<IUserService, UserService>();
    }
}