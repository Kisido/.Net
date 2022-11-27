using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Services.Models;

namespace filmsRating.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>().ReverseMap();

        #endregion

        #region UserRatings

        CreateMap<UserRating, UserRatingModel>().ReverseMap();
        CreateMap<UserRating, UpdateUserRatingModel>().ReverseMap();
        CreateMap<UserRating, UserRatingPreviewModel>().ReverseMap();

        #endregion

        #region Movies

        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Movie, UpdateMovieModel>().ReverseMap();
        CreateMap<Movie, MoviePreviewModel>().ReverseMap();

        #endregion

        #region Countrys

        CreateMap<Country, CountryModel>().ReverseMap();

        #endregion

        #region Actors

        CreateMap<Actor, CountryModel>().ReverseMap();

        #endregion

        #region MovieActors

        CreateMap<MovieActor, MovieActorModel>().ReverseMap();

        #endregion

        #region Genres

        CreateMap<Genre, GenreModel>().ReverseMap();

        #endregion

        #region MovieGenres

        CreateMap<MovieGenre, MovieGenreModel>().ReverseMap();

        #endregion
    }
}