using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IMovieService
{
    MovieModel GetMovie(Guid id);

    MovieModel AddMovie(MovieModel movieModel);

    MovieModel UpdateMovie(Guid id, UpdateMovieModel movie);

    void DeleteMovie(Guid id);

    PageModel<MoviePreviewModel> GetMovies(int limit = 20, int offset = 0);
}