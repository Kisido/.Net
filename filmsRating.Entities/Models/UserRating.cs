namespace filmsRating.Entities.Models;

public class UserRating : BaseEntity
{
    public int Value { get; set; }
    public string Review { get; set; }
    public int IsEdited { get; set; }
    public Guid UserID { get; set; }
    public virtual User User { get; set; }
    public Guid MovieID { get; set; }
    public virtual Movie Movie { get; set; }
}