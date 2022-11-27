using AutoMapper;
using filmsRating.WebAPI.Models;
using filmsRating.Services.Models;

namespace filmsRating.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion

        #region Actors

        CreateMap<ActorModel, ActorResponse>().ReverseMap();;

        #endregion


        #region Countrys

        CreateMap<CountryModel, CountryResponse>().ReverseMap();;

        #endregion

        
        #region Genres

        CreateMap<GenreModel, GenreResponse>().ReverseMap();;

        #endregion

        
        #region MovieActors

        CreateMap<MovieActorModel, MovieActorResponse>().ReverseMap();;

        #endregion

        
        #region MovieGenres

        CreateMap<MovieGenreModel, MovieGenreResponse>().ReverseMap();;

        #endregion


        #region Movies

        CreateMap<MovieModel, MovieResponse>().ReverseMap();;
        CreateMap<UpdateMovieRequest, UpdateMovieModel>().ReverseMap();;
        CreateMap<MoviePreviewModel, MoviePreviewResponse>().ReverseMap();; 

        #endregion


        #region UserRatings

        CreateMap<UserRatingModel, UserRatingResponse>().ReverseMap();;
        CreateMap<UpdateUserRatingRequest, UpdateUserRatingModel>().ReverseMap();;
        CreateMap<UserRatingPreviewModel, UserRatingPreviewResponse>().ReverseMap();;

        #endregion


        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();;
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();;
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();;

        #endregion                
    }
}