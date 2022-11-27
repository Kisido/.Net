using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public UserModel AddUser(UserModel userModel)
    {
        usersRepository.Save(mapper.Map<User>(userModel));
        return userModel;
    }

    public void DeleteUser(Guid id)
    {
        var userToDelete = usersRepository.GetById(id);
        if (userToDelete == null)
        {
            throw new Exception("User not found");
        }

        usersRepository.Delete(userToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var user = usersRepository.GetById(id);
        return mapper.Map<UserModel>(user);
    }

    public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
        var users = usersRepository.GetAll();
        int totalCount = users.Count();
        var chunk = users.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<UserPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<UserPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel user)
    {
        var existingUser = usersRepository.GetById(id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.Nickname = user.Nickname;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;

        existingUser = usersRepository.Save(existingUser);
        return mapper.Map<UserModel>(existingUser);
    }
}