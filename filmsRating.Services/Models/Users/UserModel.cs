namespace filmsRating.Services.Models;

public class UserModel : BaseModel
{
    public string Login { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int IsAdmin { get; set; }
}