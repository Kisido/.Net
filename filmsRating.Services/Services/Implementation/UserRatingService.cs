using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class UserRatingService : IUserRatingService
{
    private readonly IRepository<UserRating> userRatingsRepository;
    private readonly IMapper mapper;
    public UserRatingService(IRepository<UserRating> userRatingsRepository, IMapper mapper)
    {
        this.userRatingsRepository = userRatingsRepository;
        this.mapper = mapper;
    }

    public UserRatingModel AddUserRating(UserRatingModel userRatingModel)
    {
        userRatingsRepository.Save(mapper.Map<UserRating>(userRatingModel));
        return userRatingModel;
    }

    public void DeleteUserRating(Guid id)
    {
        var userRatingToDelete = userRatingsRepository.GetById(id);
        if (userRatingToDelete == null)
        {
            throw new Exception("UserRating not found");
        }

        userRatingsRepository.Delete(userRatingToDelete);
    }

    public UserRatingModel GetUserRating(Guid id)
    {
        var userRating = userRatingsRepository.GetById(id);
        return mapper.Map<UserRatingModel>(userRating);
    }

    public PageModel<UserRatingPreviewModel> GetUserRatings(int limit = 20, int offset = 0)
    {
        var userRatings = userRatingsRepository.GetAll();
        int totalCount = userRatings.Count();
        var chunk = userRatings.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<UserRatingPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<UserRatingPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public UserRatingModel UpdateUserRating(Guid id, UpdateUserRatingModel userRating)
    {
        var existingUserRating = userRatingsRepository.GetById(id);
        if (existingUserRating == null)
        {
            throw new Exception("UserRating not found");
        }

        existingUserRating.Value = userRating.Value;
        existingUserRating.Review = userRating.Review;

        existingUserRating = userRatingsRepository.Save(existingUserRating);
        return mapper.Map<UserRatingModel>(existingUserRating);
    }
}