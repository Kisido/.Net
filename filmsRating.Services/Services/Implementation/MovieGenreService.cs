using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class MovieGenreService : IMovieGenreService
{
    private readonly IRepository<MovieGenre> movieGenresRepository;
    private readonly IMapper mapper;
    public MovieGenreService(IRepository<MovieGenre> movieGenresRepository, IMapper mapper)
    {
        this.movieGenresRepository = movieGenresRepository;
        this.mapper = mapper;
    }

    public MovieGenreModel GetMovieGenre(Guid id)
    {
        var movieGenre = movieGenresRepository.GetById(id);
        return mapper.Map<MovieGenreModel>(movieGenre);
    }

    public PageModel<MovieGenreModel> GetMovieGenres(int limit = 20, int offset = 0)
    {
        var movieGenres = movieGenresRepository.GetAll();
        int totalCount = movieGenres.Count();
        var chunk = movieGenres.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<MovieGenreModel>()
        {
            Items = mapper.Map<IEnumerable<MovieGenreModel>>(chunk),
            TotalCount = totalCount
        };
    }
}