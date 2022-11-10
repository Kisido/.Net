namespace filmsRating.Entities.Models;

public class Country : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}