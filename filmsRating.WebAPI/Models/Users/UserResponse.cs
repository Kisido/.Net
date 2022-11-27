namespace filmsRating.WebAPI.Models;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string PhoneNumber { get; set; }
    public int IsAdmin { get; set; }
}