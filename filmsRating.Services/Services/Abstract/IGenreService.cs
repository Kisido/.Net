using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IGenreService
{
    GenreModel GetGenre(Guid id);

    GenreModel AddGenre(GenreModel genreModel);

    void DeleteGenre(Guid id);

    PageModel<GenreModel> GetGenres(int limit = 20, int offset = 0);
}