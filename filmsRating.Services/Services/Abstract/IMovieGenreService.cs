using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IMovieGenreService
{
    MovieGenreModel GetMovieGenre(Guid id);

    PageModel<MovieGenreModel> GetMovieGenres(int limit = 20, int offset = 0);
}