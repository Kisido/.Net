namespace filmsRating.Entities.Models;

public class MovieActor : BaseEntity
{
    public Guid MovieID { get; set; }
    public virtual Movie Movie { get; set; }
    public Guid ActorID { get; set; }
    public virtual Actor Actor { get; set; }
}