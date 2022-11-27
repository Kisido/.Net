namespace filmsRating.WebAPI.Models;

public class UserRatingResponse
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public string Review { get; set; }
    public int IsEdited { get; set; }
}