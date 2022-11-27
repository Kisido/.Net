using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class MovieActorService : IMovieActorService
{
    private readonly IRepository<MovieActor> movieActorsRepository;
    private readonly IMapper mapper;
    public MovieActorService(IRepository<MovieActor> movieActorsRepository, IMapper mapper)
    {
        this.movieActorsRepository = movieActorsRepository;
        this.mapper = mapper;
    }

    public MovieActorModel GetMovieActor(Guid id)
    {
        var movieActor = movieActorsRepository.GetById(id);
        return mapper.Map<MovieActorModel>(movieActor);
    }

    public PageModel<MovieActorModel> GetMovieActors(int limit = 20, int offset = 0)
    {
        var movieActors = movieActorsRepository.GetAll();
        int totalCount = movieActors.Count();
        var chunk = movieActors.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<MovieActorModel>()
        {
            Items = mapper.Map<IEnumerable<MovieActorModel>>(chunk),
            TotalCount = totalCount
        };
    }
}