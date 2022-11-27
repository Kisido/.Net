using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IActorService
{
    ActorModel GetActor(Guid id);

    ActorModel AddActor(ActorModel actorModel);

    void DeleteActor(Guid id);

    PageModel<ActorModel> GetActors(int limit = 20, int offset = 0);
}