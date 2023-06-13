using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsername(string username);
    Task CreateUser(User user);
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(long id);
    Task DeleteUser(User user);
}