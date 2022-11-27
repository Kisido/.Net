using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class ActorService : IActorService
{
    private readonly IRepository<Actor> actorsRepository;
    private readonly IMapper mapper;
    public ActorService(IRepository<Actor> actorsRepository, IMapper mapper)
    {
        this.actorsRepository = actorsRepository;
        this.mapper = mapper;
    }

    public void DeleteActor(Guid id)
    {
        var actorToDelete = actorsRepository.GetById(id);
        if (actorToDelete == null)
        {
            throw new Exception("Actor not found");
        }

        actorsRepository.Delete(actorToDelete);
    }

    public ActorModel GetActor(Guid id)
    {
        var actor = actorsRepository.GetById(id);
        return mapper.Map<ActorModel>(actor);
    }

    public PageModel<ActorModel> GetActors(int limit = 20, int offset = 0)
    {
        var actors = actorsRepository.GetAll();
        int totalCount = actors.Count();
        var chunk = actors.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<ActorModel>()
        {
            Items = mapper.Map<IEnumerable<ActorModel>>(chunk),
            TotalCount = totalCount
        };
    }

    ActorModel IActorService.AddActor(ActorModel actorModel)
    {
        actorsRepository.Save(mapper.Map<Entities.Models.Actor>(actorModel));
        return actorModel;
    }
}