namespace filmsRating.Entities.Models;

public class MovieGenre : BaseEntity
{
    public Guid MovieID { get; set; }
    public virtual Movie Movie { get; set; }
    public Guid GenreID { get; set; }
    public virtual Genre Genre { get; set; } 
}