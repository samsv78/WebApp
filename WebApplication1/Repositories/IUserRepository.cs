using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsername(string username);
    Task CreateUser(User user);
}