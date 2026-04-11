using Api.DataAccess.Models;

namespace Api.DataAccess.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task InsertNewUserAsync(User user);
}
