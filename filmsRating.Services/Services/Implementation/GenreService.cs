using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class GenreService : IGenreService
{
    private readonly IRepository<Genre> genresRepository;
    private readonly IMapper mapper;
    public GenreService(IRepository<Genre> genresRepository, IMapper mapper)
    {
        this.genresRepository = genresRepository;
        this.mapper = mapper;
    }

    public void DeleteGenre(Guid id)
    {
        var genreToDelete = genresRepository.GetById(id);
        if (genreToDelete == null)
        {
            throw new Exception("Genre not found");
        }

        genresRepository.Delete(genreToDelete);
    }

    public GenreModel GetGenre(Guid id)
    {
        var genre = genresRepository.GetById(id);
        return mapper.Map<GenreModel>(genre);
    }

    public PageModel<GenreModel> GetGenres(int limit = 20, int offset = 0)
    {
        var genres = genresRepository.GetAll();
        int totalCount = genres.Count();
        var chunk = genres.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<GenreModel>()
        {
            Items = mapper.Map<IEnumerable<GenreModel>>(chunk),
            TotalCount = totalCount
        };
    }

    GenreModel IGenreService.AddGenre(GenreModel genreModel)
    {
        genresRepository.Save(mapper.Map<Genre>(genreModel));
        return genreModel;
    }
}