using WebApplication1.Commands;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public interface IUserService
{
    Task CreateUser(CreateUserCommand request);
    Task<List<UserInfo>> GetUser(long? id);
    Task DeleteUser(DeleteUserCommand request);
    Task UpdateUser(UpdateUserCommand request);
}