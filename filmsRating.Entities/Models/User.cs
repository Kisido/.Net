namespace filmsRating.Entities.Models;

public class User : BaseEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Nickname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int IsAdmin { get; set; }
    public virtual ICollection<UserRating> UserRatings { get; set; }
}