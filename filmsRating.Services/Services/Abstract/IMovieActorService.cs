using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IMovieActorService
{
    MovieActorModel GetMovieActor(Guid id);

    PageModel<MovieActorModel> GetMovieActors(int limit = 20, int offset = 0);
}