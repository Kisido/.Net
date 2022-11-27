using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class MovieService : IMovieService
{
    private readonly IRepository<Movie> moviesRepository;
    private readonly IMapper mapper;
    public MovieService(IRepository<Movie> moviesRepository, IMapper mapper)
    {
        this.moviesRepository = moviesRepository;
        this.mapper = mapper;
    }

    public MovieModel AddMovie(MovieModel movieModel)
    {
        moviesRepository.Save(mapper.Map<Movie>(movieModel));
        return movieModel;
    }

    public void DeleteMovie(Guid id)
    {
        var movieToDelete = moviesRepository.GetById(id);
        if (movieToDelete == null)
        {
            throw new Exception("Movie not found");
        }

        moviesRepository.Delete(movieToDelete);
    }

    public MovieModel GetMovie(Guid id)
    {
        var movie = moviesRepository.GetById(id);
        return mapper.Map<MovieModel>(movie);
    }

    public PageModel<MoviePreviewModel> GetMovies(int limit = 20, int offset = 0)
    {
        var movies = moviesRepository.GetAll();
        int totalCount = movies.Count();
        var chunk = movies.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<MoviePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<MoviePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public MovieModel UpdateMovie(Guid id, UpdateMovieModel movie)
    {
        var existingMovie = moviesRepository.GetById(id);
        if (existingMovie == null)
        {
            throw new Exception("Movie not found");
        }

        existingMovie.Name = movie.Name;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.Description = movie.Description;
        existingMovie.Director = movie.Director;

        existingMovie = moviesRepository.Save(existingMovie);
        return mapper.Map<MovieModel>(existingMovie);
    }
}