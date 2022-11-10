namespace filmsRating.Entities.Models;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<MovieGenre> MovieGenres { get; set; }
}