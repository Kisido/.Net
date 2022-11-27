namespace filmsRating.Services.Models;

public class UpdateMovieModel
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
}