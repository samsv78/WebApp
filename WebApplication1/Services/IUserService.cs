using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public interface IUserService
{
    Task CreateUser(CreateUserCommand request);
    Task<List<UserInfo>> GetUser(long? id);
}