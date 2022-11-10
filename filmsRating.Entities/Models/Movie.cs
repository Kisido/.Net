namespace filmsRating.Entities.Models;

public class Movie : BaseEntity
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public Guid CountryID { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<MovieActor> MovieActors { get; set; }
    public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    public virtual ICollection<UserRating> UserRatings { get; set; }    
}