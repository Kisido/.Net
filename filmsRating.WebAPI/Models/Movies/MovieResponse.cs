namespace filmsRating.WebAPI.Models;

public class MovieResponse
{
    public Guid Id { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
}