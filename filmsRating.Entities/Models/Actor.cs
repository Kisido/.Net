namespace filmsRating.Entities.Models;

public class Actor : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<MovieActor> MovieActors { get; set; }
}