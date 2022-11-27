using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface IUserRatingService
{
    UserRatingModel GetUserRating(Guid id);

    UserRatingModel AddUserRating(UserRatingModel userRatingModel);

    UserRatingModel UpdateUserRating(Guid id, UpdateUserRatingModel userRating);

    void DeleteUserRating(Guid id);

    PageModel<UserRatingPreviewModel> GetUserRatings(int limit = 20, int offset = 0);
}