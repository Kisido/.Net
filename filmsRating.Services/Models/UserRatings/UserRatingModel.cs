namespace filmsRating.Services.Models;

public class UserRatingModel : BaseModel
{
    public int Value { get; set; }
    public string Review { get; set; }
    public int IsEdited { get; set; }
}